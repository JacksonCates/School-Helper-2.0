using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;

namespace SchoolHelper2._0
{
    internal class Database
    {
        private SqlConnection cnn;
        internal bool isConnected;

        // Consturctor
        internal Database(string connectionString)
        {
            try
            {
                // connects
                cnn = new SqlConnection(connectionString);

                cnn.Open();

                Console.WriteLine("Connection Open!");

                isConnected = true;
            }
            // Error
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                isConnected = false;
            }
        }

        internal void Close()
        {
            // close the connection
            cnn.Dispose();
        }

        internal bool AddRow(string tableName, List<string> varNames, List<string> values)
        {
            // Adds the variables
            string queryString = "INSERT INTO " + tableName + " (" + varNames[0];

            // Checks for proper usage
            if (varNames.Count() != values.Count())
                return false;

            // Adds the rest of the query
            for (int i = 1; i < varNames.Count(); i++)
            {
                queryString += ", " + varNames[i];
            }

            // Now adds the values
            queryString += ") VALUES (";

            // Now we have to detect if it is a string or not
            // test for null
            if (values[0] == "-1")
                queryString += "NULL";
            else if (IsNumeric(values[0]) == false)
                queryString += "'" + values[0] + "'";
            else
                queryString += values[0];

            // Applies to the rest
            for (int i = 1; i < values.Count(); i++)
            {
                if (values[i] == "-1")
                    queryString += ", " + "NULL";
                else if (IsNumeric(values[i]) == false)
                    queryString += ", '" + values[i] + "'";
                else
                    queryString += ", " + values[i];
            }
            queryString += ");";

            // Debugging
            Console.WriteLine(queryString);

            // Runs the command
            SqlCommand command = new SqlCommand(queryString, cnn);
            command.ExecuteNonQuery();

            return true;
        }

        internal DataTable Select(string tableName, string whereStatement = "", List<string> colNames = null)
        {
            try
            {
                // Test for default
                if (colNames == null)
                    colNames = new List<string>() { "*" };

                // Builds the query string
                string queryString = "SELECT ";

                // Adds the first
                queryString += colNames[0];

                // Adds the rest
                for (int i = 1; i < colNames.Count(); i++)
                    queryString += ", " + colNames[i];

                // Keeps building
                queryString += " FROM " + tableName;

                // Checks if we need to add the where statement
                if (whereStatement != "")
                    queryString += " WHERE " + whereStatement + ";";

                // Debugging
                //Console.WriteLine(queryString);

                // Runs the query
                return GetQueryResults(queryString);
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return null;
            }
        }

        // This function updates a table with an give ID
        // This function does not add rows or deletes cols
        // the amount of rows has to be the same, and the cols have to be the same (with ID omitted)
        // colNames must include ID col at front
        internal bool UpdateTable(string tableName, string whereStatement, List<string> colNames, List<List<string>> currData)
        {
            try
            {
                // Checks if curr data is empty
                if (currData.Count() == 0)
                {
                    Console.WriteLine("ERROR: Empty data given");
                    return false;
                }

                // Gets the table
                DataTable oldTable = Select(tableName, whereStatement, colNames);

                // DEBUGGING
                /*
                foreach (DataRow row in oldTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        Console.Write(item);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                */

                // Checks if the table sizes are the same amount of rows
                if (oldTable.Rows.Count != currData.Count())
                {
                    Console.WriteLine("ERROR: Table row count does not match");
                    return false;
                }

                // Loops though each row in the data given
                for (int i = 0; i < currData.Count(); i++)
                {
                    List<string> row = currData[i];

                    // Checks if the proper amount of data is given
                    if (row.Count() != colNames.Count() - 1)
                    {
                        Console.WriteLine("ERROR: Column count does not match");
                        return false;
                    }

                    // Check each col
                    for (int j = 0; j < row.Count(); j++)
                    {
                        string data = row[j];

                        // Checks data for null, changes it if it is
                        if (oldTable.Rows[i].ItemArray[j + 1] == DBNull.Value)
                            oldTable.Rows[i][j + 1] = -1;

                        // Compare if the two strings are not equal
                        if (data != oldTable.Rows[i].ItemArray[j + 1].ToString())
                        {
                            // Debugging
                            Console.WriteLine("UPDATE: " + colNames[j + 1] + " ~ " + row[j] + " " + oldTable.Rows[i].ItemArray[j + 1].ToString());

                            // Now we have to detect if it is a string or not
                            // test for null
                            if (data == "-1")
                                data = "NULL";
                            else if (IsNumeric(data) == false)
                                data = "'" + data + "'";

                            // Updates old table for query
                            if (oldTable.Rows[i][j + 1].ToString() == "-1")
                                oldTable.Rows[i][j + 1] = DBNull.Value;
                            else if (IsNumeric(oldTable.Rows[i][j + 1].ToString()) == false)
                                oldTable.Rows[i][j + 1] = "'" + oldTable.Rows[i][j] + "'";

                            Update(tableName, new List<string> { colNames[j + 1] + " = " + data }, colNames[0] + " = " + oldTable.Rows[i][0].ToString());
                        }
                    }
                }

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return false;
            }
        }

        internal DataTable Update(string tableName, List<string> setStatements, string whereStatement)
        {
            try
            {
                // Builds the query string and first set statement
                string queryString = "UPDATE " + tableName + " SET " + setStatements[0];

                // Builds the rest
                for (int i = 1; i < setStatements.Count(); i++)
                    queryString += ", " + setStatements[i];

                // Adds the where statement
                queryString += " WHERE " + whereStatement + ";";

                // Debugging
                //Console.WriteLine(queryString);

                return GetQueryResults(queryString);
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return null;
            }
        }

        internal DataTable Delete(string tableName, string whereStatement)
        {
            try
            {
                // Builds the query string
                string queryString = "DELETE FROM " + tableName + " WHERE " + whereStatement;

                // Runs the query
                return GetQueryResults(queryString);
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return null;
            }
        }

        // This inner join assumes the ID names in the two tables are the same
        internal DataTable InnerJoin(string firstTable, string secondTable, string ID, 
            List<string> firstColNames = null, List<string> secondColNames = null, string whereStatement = "")
        {
            try
            {
                // Builds the query string
                string queryString = "SELECT ";

                // Test for null for first
                if (firstColNames == null)
                    firstColNames = new List<string>() { "*" };

                // Test for null for second
                if (secondColNames == null)
                    secondColNames = new List<string>() { "*" };

                // Adds the first col;
                queryString += firstTable + "." + firstColNames[0];

                // Adds the rest
                for (int i = 1; i < firstColNames.Count(); i++)
                    queryString += ", " + firstTable + "." + firstColNames[i];

                // Adds all the second cols
                foreach (string col in secondColNames)
                    queryString += ", " + secondTable + "." + col;

                // Keeps building
                queryString += " FROM " + firstTable + " INNER JOIN " + secondTable + " ON " + firstTable + "." + ID + " = " + secondTable + "." + ID;

                // Adds where statement
                if (whereStatement.Equals(""))
                    queryString += ";";
                else
                    queryString += " WHERE " + whereStatement + ";";

                // Debugging
                //Console.WriteLine(queryString);

                return GetQueryResults(queryString);
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return null;
            }
        }

        internal DataTable DoubleInnerJoin(string firstTable, string secondTable, string thirdTable, string firstID, string secondID,
            List<string> firstColNames = null, List<string> secondColNames = null, List<string> thirdColNames = null, 
            string whereStatement = "")
        {
            try
            {
                // Builds the query string
                string queryString = "SELECT ";

                // Test for null for first
                if (firstColNames == null)
                    firstColNames = new List<string>() { "*" };

                // Test for null for second
                if (secondColNames == null)
                    secondColNames = new List<string>() { "*" };

                // Test for null for third
                if (thirdColNames == null)
                    thirdColNames = new List<string>() { "*" };

                // Adds the first col;
                queryString += firstTable + "." + firstColNames[0];

                // Adds the rest
                for (int i = 1; i < firstColNames.Count(); i++)
                    queryString += ", " + firstTable + "." + firstColNames[i];

                // Adds all the second cols
                foreach (string col in secondColNames)
                    queryString += ", " + secondTable + "." + col;

                // Adds all the third cols
                foreach (string col in thirdColNames)
                    queryString += ", " + thirdTable + "." + col;

                // Adds the inner join
                queryString += " FROM " + firstTable + " INNER JOIN " + secondTable + " ON " + firstTable + "." + firstID + " = " + secondTable + "." + firstID;
                queryString += " INNER JOIN " + thirdTable + " ON " + secondTable + "." + secondID + " = " + thirdTable + "." + secondID;

                // Adds where statement
                if (whereStatement.Equals(""))
                    queryString += ";";
                else
                    queryString += " WHERE " + whereStatement + ";";

                // Debugging
                //Console.WriteLine(queryString);

                return GetQueryResults(queryString);
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return null;
            }
        }

        private bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private DataTable GetQueryResults(string queryString)
        {
            DataTable table = new DataTable();

            // Makes the command
            SqlCommand command = new SqlCommand(queryString, cnn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                table.Load(reader);
            }

            return table;
        }
        
        // This function assumes the foreign key and primary key has the same var name
        internal int CountInnerJoin(string firstTable, string secondTable, string ID, string whereStatement = "")
        {
            try
            {
                // Builds the query string
                string queryString = "SELECT COUNT(*) FROM " + firstTable + " INNER JOIN " + secondTable
                    + " ON " + firstTable + "." + ID + "= " + secondTable + "." + ID;

                // Adds where statement
                if (whereStatement.Equals(""))
                    queryString += ";";
                else
                    queryString += " WHERE " + whereStatement + ";";

                // Gets the table
                DataTable table = GetQueryResults(queryString);

                // Test if the table is empty
                if (table.Rows[0].IsNull(0))
                    return -1;

                // Returns the value
                return table.Rows[0].Field<int>(0);
            }
            catch (Exception exp)
            {
                // Failed
                Console.WriteLine(exp.ToString());
                return -1;
            }
        }

        internal int Count(string tableName)
        {
            try
            {
                // Builds the queryString   
                string queryString = "SELECT COUNT(*) FROM " + tableName;

                // Gets the table
                DataTable table = GetQueryResults(queryString);

                // Test if the table is empty
                if (table.Rows[0].IsNull(0))
                    return -1;

                // Returns the value
                return table.Rows[0].Field<int>(0);

            }
            catch (Exception exp)
            {
                // Failed
                Console.WriteLine(exp.ToString());
                return -1;
            }
        }

        internal int GetNewID(string tableName, string IDName)
        {
            try
            {
                // Query to get the max id
                string queryString = "SELECT MAX(" + IDName + ") FROM " + tableName + ";";

                DataTable table = GetQueryResults(queryString);

                // Test if the table is empty
                if (table.Rows[0].IsNull(0))
                    return 1;

                // Returns incremented index
                return table.Rows[0].Field<int>(0) + 1;
            }
            catch (Exception exp)
            { 
                // Failed
                Console.WriteLine(exp.ToString());
                return -1;
            }
        }
        
        internal bool CleanTable(string tableName)
        {
            try
            { 
                // Runs the command
                string queryString = "DELETE FROM " + tableName + ";";
                SqlCommand command = new SqlCommand(queryString, cnn);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return false;
            }
        }
    }
}

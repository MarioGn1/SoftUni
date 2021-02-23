using ADO.NET.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET
{
    public class SQLComandManager
    {
        const string sqlConnectionStringMaster = "Server=.; Database = master; Integrated security = true";
        const string sqlConnectionString = "Server=.; Database = MinionsDB; Integrated security = true";

        private SQLCommandExecution exec;

        public SQLComandManager()
        {
            exec = new SQLCommandExecution();
        }

        public void InitializeMinionsDB()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionStringMaster))
            {
                connection.Open();

                var createMinionsDB = SQLStatements.CreateDBStatements();

                exec.ExecuteNonQuery(connection, createMinionsDB);
            }
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                var createTables = SQLStatements.CreateTablesStatements();

                exec.ExecuteNonQuery(connection, createTables);
            }
        }

        public void InsertInitialData()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                var tableInserts = SQLStatements.InsertTablesStatements();

                exec.ExecuteNonQuery(connection, tableInserts);
            }
        }

        public string VillainNames()
        {
            var sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                var reader = exec.ExecuteReader(connection, SQLStatements.getVillainsNames);

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = reader["Name"] as string;
                        int count = (int)reader["MinionCounts"];
                        sb.AppendLine($"{name} - {count}");
                    }
                }
            }
            return sb.ToString().Trim();
        }

        public string MinionNames(int villainID)
        {
            var sb = new StringBuilder();

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@villainID", villainID);

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                var reader = exec.ExecuteReader(connection, SQLStatements.getMinionNames, parameters);

                using (reader)
                {
                    if (reader.HasRows == false)
                    {
                        return $"No villain with ID {villainID} exists in the database.";
                    }

                    string name = string.Empty;
                    int counter = 1;

                    while (reader.Read())
                    {
                        if (name == string.Empty)
                        {
                            name = reader["Name"] as string;
                            sb.AppendLine($"Villain: {reader["Name"]}");
                        }
                        if (reader["MName"] as string == null)
                        {
                            sb.AppendLine("(no minions)");
                            break;
                        }
                        sb.AppendLine($"{counter}. {reader["MName"]} {reader["Age"]}");
                        counter++;
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string AddMinion(Dictionary<string, object> parameters)
        {
            var sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                object townId = exec.ExecuteScalar(SQLStatements.getTownId, connection, parameters);
                if (townId == null)
                {
                    exec.ExecuteNonQuery(connection, SQLStatements.insertTown, parameters);
                    townId = exec.ExecuteScalar(SQLStatements.getTownId, connection, parameters);
                    sb.AppendLine($"Town {parameters["@TownName"]} was added to the database.");
                }
                parameters.Add("@TownId", townId);


                object villainId = exec.ExecuteScalar(SQLStatements.getVillainId, connection, parameters);
                if (villainId == null)
                {
                    exec.ExecuteNonQuery(connection, SQLStatements.insertVillain, parameters);
                    villainId = exec.ExecuteScalar(SQLStatements.getVillainId, connection, parameters);
                    sb.AppendLine($"Villain {parameters["@VillainName"]} was added to the database.");
                }
                parameters.Add("@VillainId", villainId);


                exec.ExecuteNonQuery(connection, SQLStatements.insertMinion, parameters);
                object minionId = exec.ExecuteScalar(SQLStatements.getMinionId, connection, parameters);
                parameters.Add("@MinionId", minionId);


                exec.ExecuteNonQuery(connection, SQLStatements.insertVillainMinionMap, parameters);
                sb.AppendLine($"Successfully added {parameters["@MinionName"]} to be minion of {parameters["@VillainName"]}.");
            }
            return sb.ToString().Trim();
        }

        public string ChangeTownNamesCasing(string country)
        {
            var sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@CountryName", country);

                object countryId = exec.ExecuteScalar(SQLStatements.getCountryId, connection, parameters);
                if (countryId == null)
                {
                    return "No town names were affected.";
                }
                parameters.Add("@CountryCode", countryId);

                int afectedLines = exec.ExecuteNonQuery(connection, SQLStatements.updateTownsNamesToUpercase, parameters);
                sb.AppendLine($"{afectedLines} town names were affected.");
                if (afectedLines == 0)
                {
                    return "No town names were affected.";
                }

                var reader = exec.ExecuteReader(connection, SQLStatements.getTownsNames, parameters);
                using (reader)
                {
                    List<string> towns = new List<string>();
                    while (reader.Read())
                    {
                        towns.Add(reader["Name"] as string);
                    }
                    sb.AppendLine($"[{string.Join(", ", towns)}]");
                }
            }
            return sb.ToString().Trim();
        }

        public string RemoveVillain(object villainId)
        {
            StringBuilder sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@VillainId", villainId);

                object villainName = exec.ExecuteScalar(SQLStatements.getVillainName, connection, parameters);

                if (villainName == null)
                {
                    return "No such villain was found.";
                }

                int deletedMaps = exec.ExecuteNonQuery(connection, SQLStatements.deleteMinionsVillainsMap, parameters);
                exec.ExecuteNonQuery(connection, SQLStatements.deleteVillain, parameters);

                sb.AppendLine($"{villainName} was deleted.");
                sb.AppendLine($"{deletedMaps} minions were released.");
            }

            return sb.ToString().Trim();
        }

        public string PrintAllMinionNames()
        {
            StringBuilder sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                var reader = exec.ExecuteReader(connection, SQLStatements.getMinionNamesOnly);

                using (reader)
                {
                    List<string> names = new List<string>();

                    while (reader.Read())
                    {
                        names.Add(reader["Name"] as string);
                    }

                    List<string> orderedNames = new List<string>();
                    int lenght = 0;
                    if (names.Count % 2 == 0)
                    {
                        lenght = names.Count / 2;
                    }
                    else
                    {
                        lenght = (names.Count / 2) + 1;
                    }

                    for (int i = 0; i < lenght; i++)
                    {
                        if (names.Count % 2 != 0 && i == lenght - 1)
                        {
                            orderedNames.Add(names[i]);
                        }
                        else
                        {
                            orderedNames.Add(names[i]);
                            orderedNames.Add(names[names.Count - 1 - i]);
                        }
                    }
                    sb.AppendLine(string.Join(Environment.NewLine, orderedNames));
                }
            }

            return sb.ToString().Trim();
        }

        public string IncreaseMinionAge(int[] minionsIds)
        {
            StringBuilder sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                foreach (var id in minionsIds)
                {
                    exec.ExecuteNonQuery(connection, SQLStatements.updateMinionAgeByOne, "@MinionId", id);
                    exec.ExecuteNonQuery(connection, SQLStatements.updateMinionNameFirstLetterUpercase, "@MinionId", id);
                }

                var reader = exec.ExecuteReader(connection, SQLStatements.getMinionNameAndAge);

                using (reader)
                {
                    while (reader.Read())
                    {
                        sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string IncreaseAgeWithStoredProcedure(int minionId)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                exec.ExecuteNonQuery(connection, SQLStatements.updateMinionAgeStoredProcedure, "@MinionId", minionId);

                var reader = exec.ExecuteReader(connection, SQLStatements.getMinionNameAndAge);

                using (reader)
                {
                    reader.Read();
                    return $"{reader["Name"]} - {reader["Age"]} years old";
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET
{
    public static class SQLStatements
    {
        public static string[] CreateDBStatements()
        {
            var result = new string[]
            {
                "CREATE DATABASE MinionsDB"
            };
            return result;
        }

        public static string[] CreateTablesStatements()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(50) NOT NULL)",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(50) NOT NULL, CoutryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(50) NOT NULL, Age INT NOT NULL, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(50))",
                "CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id), CONSTRAINT pk_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };
            return result;
        }

        public static string[] InsertTablesStatements()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('Greece'),('Romania'),('North Macedonia'),('Serbia')",
                "INSERT INTO Towns([Name],CoutryCode) VALUES ('Sofia', 1),('Atina', 2),('Bucharest', 3),('Skopje', 4),('Belgrade', 5)",
                "INSERT INTO Minions([Name],Age,TownId) VALUES ('Ed', 21, 1),('Rob', 15, 2),('Steve', 10, 3),('John', 2, 4),('Dooby', 6, 5)",
                "INSERT INTO EvilnessFactors ([Name]) VALUES ('SuperStrong'),('Poison'),('MindControl'),('Freez'),('Nightmares')",
                "INSERT INTO Villains ([Name], EvilnessFactorId) VALUES ('Pesho', 1),('Gosho', 2),('Stamat', 3),('Geri', 4),('Nikol', 5)",
                "INSERT INTO MinionsVillains (MinionId,VillainId) VALUES (1,5),(2,4),(3,3),(4,2),(5,1),(1,1),(2,1),(3,1),(4,1),(1,2),(2,3),(3,4),(1,3),(4,5),(1,4),(2,2),(3,2),(4,4)"
            };
            return result;
        }

        public static string getMinionNames = "SELECT V.Name,M.Name as MName,M.Age FROM Villains V LEFT JOIN MinionsVillains MV ON V.Id = MV.VillainId LEFT JOIN Minions M ON MV.MinionId = M.Id WHERE V.Id = @villainID ORDER BY M.Name";
        public static string getVillainsNames = "SELECT V.Name,	COUNT(*) AS MinionCounts FROM Villains V JOIN MinionsVillains MV ON V.Id = MV.VillainId GROUP BY V.Name HAVING COUNT(*) > 3 ORDER BY MinionCounts DESC";
        public static string getTownId = "SELECT Id FROM Towns WHERE Name = @TownName";
        public static string getTownsNames = "SELECT Name FROM Towns WHERE CountryCode = @CountryCode";
        public static string getCountryId = "SELECT Id FROM Countries WHERE Name = @CountryName";
        public static string getVillainName = "SELECT Name FROM Villains WHERE Id = @VillainId";
        public static string getVillainId = "SELECT Id FROM Villains WHERE Name = @VillainName";
        public static string getMinionId = "SELECT Id FROM Minions WHERE Name = @MinionName";
        public static string getMinionNamesOnly = "SELECT Name FROM Minions";
        public static string getMinionNameAndAge = "SELECT Name, Age FROM Minions";

        public static string insertTown = "INSERT INTO Towns (Name, CountryCode) VALUES (@TownName, 1)"; //can be made with another parameter for country code
        public static string insertVillain = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@VillainName, 4)";//Default evilness factor eveil = 4
        public static string insertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@MinionName, @MinionAge, @TownId)";
        public static string insertVillainMinionMap = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@MinionId, @VillainId)";

        public static string updateTownsNamesToUpercase = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @CountryCode";
        public static string updateMinionNameFirstLetterUpercase = "UPDATE Minions SET Name=UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name))) where id = @MinionId";
        public static string updateMinionAgeByOne = "UPDATE Minions set Age = Age + 1 where id = @MinionId";
        public static string updateMinionAgeStoredProcedure = "EXEC usp_IncreaseMinionAgeByOne @MinionId";

        public static string deleteMinionsVillainsMap = "DELETE FROM MinionsVillains WHERE VillainId = @VillainId";
        public static string deleteVillain = "DELETE FROM Villains WHERE Id = @VillainId";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.NET.Utils
{
    public class Menu
    {
        private SQLComandManager manager;

        public Menu()
        {
            manager = new SQLComandManager();
        }
        public bool MainMenu()
        {
            bool running = true;
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Create DB structure");
                Console.WriteLine("2. Fill tables with initial data");
                Console.WriteLine("3. Task Manipulations");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option... ");
                string opt = Console.ReadLine();
                int.TryParse(opt, out option);

            } while (option < 1 || option > 4);

            Console.Clear();

            switch (option)
            {
                case 1:
                    manager.InitializeMinionsDB();
                    ActionComplete("MinionsDB structure created!");
                    break;
                case 2:
                    manager.InsertInitialData();
                    ActionComplete("All tables fulfilled with initial data.");
                    break;
                case 3:
                    bool tasksMenuRunning = true;
                    while (tasksMenuRunning)
                    {
                        tasksMenuRunning = TasksMenu();
                    }
                    break;
                case 4:
                    running = false;
                    break;
                default:
                    break;
            }

            return running;
        }

        public bool TasksMenu()
        {
            bool running = true;
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Villain Names");
                Console.WriteLine("2. Minion Names");
                Console.WriteLine("3. Add Minion");
                Console.WriteLine("4. Change Town Names Casing");
                Console.WriteLine("5. Remove Villiain");
                Console.WriteLine("6. Print All Minion Names");
                Console.WriteLine("7. Increase Minion Age");
                Console.WriteLine("8. Increse Age Stored Procedure");
                Console.WriteLine("9. Return to Main menu");
                Console.Write("Choose an option... ");
                string opt = Console.ReadLine();
                int.TryParse(opt, out option);

            } while (option < 1 || option > 9);

            Console.Clear();

            switch (option)
            {
                case 1:
                    ActionComplete(manager.VillainNames());
                    break;
                case 2:
                    Console.Write("Enter Villain Id: ");
                    int villainId = int.Parse(Console.ReadLine());
                    ActionComplete(manager.MinionNames(villainId));
                    break;
                case 3:
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    Console.WriteLine("Enter the input data:");
                    string[] minionData = Console.ReadLine().Split();
                    string[] villainData = Console.ReadLine().Split();
                    parameters.Add("@MinionName", minionData[1]);
                    parameters.Add("@MinionAge", int.Parse(minionData[2]));
                    parameters.Add("@TownName", minionData[3]);
                    parameters.Add("@VillainName", villainData[1]);
                    ActionComplete(manager.AddMinion(parameters));
                    break;
                case 4:
                    Console.Write("Enter country name: ");
                    ActionComplete(manager.ChangeTownNamesCasing(Console.ReadLine()));
                    break;
                case 5:
                    Console.Write("Enter villain id: ");
                    ActionComplete(manager.RemoveVillain(Console.ReadLine()));
                    break;
                case 6:
                    Console.WriteLine("Existing minions:");
                    ActionComplete(manager.PrintAllMinionNames());
                    break;
                case 7:
                    Console.Write("Enter minions Id numbers: ");
                    int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    ActionComplete(manager.IncreaseMinionAge(minionIds));
                    break;
                case 8:
                    Console.Write("Enter minion id: ");
                    ActionComplete(manager.IncreaseAgeWithStoredProcedure(int.Parse(Console.ReadLine())));
                    break;
                case 9:
                    running = false;
                    break;
                default:
                    break;
            }

            return running;
        }

        private void ActionComplete(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Press any key to return to previous menu...");
            Console.ReadKey();
        }
    }
}

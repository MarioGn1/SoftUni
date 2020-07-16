using MilitaryElite.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> army = new List<Soldier>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] curCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string soldierType = curCommand[0];
                int Id = int.Parse(curCommand[1]);
                string firstName = curCommand[2];
                string lastName = curCommand[3];

                switch (soldierType)
                {
                    case "Private":
                        Private curPrivate = new Private(Id, firstName, lastName, decimal.Parse(curCommand[4]));
                        army.Add(curPrivate);
                        break;
                    case "LieutenantGeneral":
                        LieutenantGeneral curLieutenantGeneral = new LieutenantGeneral(Id, firstName, lastName, decimal.Parse(curCommand[4]));


                        for (int i = 5; i < curCommand.Length; i++)
                        {
                            Soldier searchPrivate = army.First(el => el.Id == int.Parse(curCommand[i]) && el.GetType().Name == "Private");
                            curLieutenantGeneral.Add((Private)searchPrivate);
                        }

                        army.Add(curLieutenantGeneral);
                        break;
                    case "Engineer":
                        try
                        {
                            Engineer curEngineer = new Engineer(Id, firstName, lastName, decimal.Parse(curCommand[4]), curCommand[5]);
                            string[] repairs = curCommand.Skip(6).ToArray();
                            for (int i = 0; i < repairs.Length; i += 2)
                            {
                                Repair curRepair = new Repair(repairs[i], int.Parse(repairs[i + 1]));
                                curEngineer.Add(curRepair);
                            }

                            army.Add(curEngineer);
                        }
                        catch (Exception)
                        {
                            continue; 
                        }

                        break;
                    case "Commando":
                        try
                        {
                            Commando curCommando = new Commando(Id, firstName, lastName, decimal.Parse(curCommand[4]), curCommand[5]);
                            string[] missions = curCommand.Skip(6).ToArray();
                            for (int i = 0; i < missions.Length; i += 2)
                            {
                                try
                                {
                                    Mission curMission = new Mission(missions[i], missions[i + 1]);
                                    curCommando.Add(curMission);
                                }
                                catch (Exception)
                                {
                                    continue;
                                }

                            }

                            army.Add(curCommando);
                        }
                        catch (Exception)
                        {
                            continue; 
                        }

                        break;
                    case "Spy":
                        Spy curSpy = new Spy(Id, firstName, lastName, int.Parse(curCommand[4]));
                        army.Add(curSpy);
                        break;

                }
            }

            foreach (var item in army)
            {
                Console.WriteLine(item);
            }
        }
    }
}

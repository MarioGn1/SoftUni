using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private Workshop workshop;

        public Controller()
        {
            dwarfs = new DwarfRepository();
            presents = new PresentRepository();
            workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            
            IInstrument instrument = new Instrument(power);
            if (dwarfs.FindByName(dwarfName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            IDwarf dwarf = dwarfs.FindByName(dwarfName);
            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present present = new Present(presentName, energyRequired);
            presents.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            List<IDwarf> readyToWorkDwarves = dwarfs.Models.Where(el => el.Energy >= 50).OrderByDescending(el => el.Energy).ToList();
            IPresent present = presents.FindByName(presentName);
            if (readyToWorkDwarves.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            foreach (var dwarf in readyToWorkDwarves)
            {
                workshop.Craft(present, dwarf);
                if (dwarf.Energy == 0)
                {
                    dwarfs.Remove(dwarf);
                }
                if (present.IsDone())
                {
                    return string.Format(OutputMessages.PresentIsDone, presentName);
                }
            }
            return string.Format(OutputMessages.PresentIsNotDone, presentName);

        }

        public string Report()
        {
            int countCraftedPresents = presents.Models.Where(el => el.IsDone()).ToList().Count;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var dwarf in dwarfs.Models)
            {
                sb.Append(dwarf + Environment.NewLine);
            }

            return sb.ToString().Trim();
        }
    }
}

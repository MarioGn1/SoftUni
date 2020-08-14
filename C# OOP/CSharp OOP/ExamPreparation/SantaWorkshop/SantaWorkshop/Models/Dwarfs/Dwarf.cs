using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private ICollection<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }
        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }

            }
        }
        public ICollection<IInstrument> Instruments { get => instruments;}

        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }
        public virtual void Work()
        {
            if (this.Energy - 10 < 0)
            {
                Energy = 0;
            }
            else
            this.Energy -= 10;
        }

        public override string ToString()
        {
            int notBrokenInstruments = instruments.Where(el => !el.IsBroken()).ToList().Count;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Energy: {Energy}");
            sb.AppendLine($"Instruments: {notBrokenInstruments} not broken left");

            return sb.ToString().Trim();
        }
    }
}

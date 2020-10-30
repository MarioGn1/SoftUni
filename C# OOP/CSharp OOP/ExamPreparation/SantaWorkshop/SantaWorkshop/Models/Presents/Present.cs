using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get { return this.energyRequired; }
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }

            }
        }

        public void GetCrafted()
        {
            if (this.EnergyRequired - 10 < 0)
            {
                this.EnergyRequired = 0;
            }
            else
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}

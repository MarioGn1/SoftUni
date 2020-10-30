using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            Power = power;
        }

        public int Power
        {
            get
            {
                return power;
            }
            private set
            {
                if (value < 0)
                {
                    power = 0;
                }
                else
                {
                    power = value;
                }
                
            }
        }

        public bool IsBroken()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            if (this.Power - 10 < 0)
            {
                this.Power = 0;
            }
            else
            this.Power -= 10;
        }
    }
}

using MilitaryElite.Enumerators;
using MilitaryElite.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Mission : IMission
    {       
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = TryParseState(state);
        }

        private MissionState TryParseState(string stateStr)
        {
            MissionState state;
            bool parsed = Enum.TryParse(stateStr, out state);
            if (!parsed)
            {
                throw new ArgumentException();
            }
            return state;
        }

        public string CodeName { get; private set; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == MissionState.Finished)
            {
                throw new MyExeption();
            }
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}

using MilitaryElite.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get; }
        public MissionState State { get; }
        public void CompleteMission();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id,firstName,lastName)
        {
            
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {CodeNumber}");
            return sb.ToString().TrimEnd();            
        }
        //Name: <firstName> <lastName> Id: <id>
        //Code Number: <codeNumber>

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id,firstName,lastName,salary)
        {
            this.privates = new List<IPrivate>();
        }

        public void Add(IPrivate soldier)
        {
            privates.Add(soldier);
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection<IPrivate>)this.privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in privates)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().Trim();
        }


        //Name: <firstName> <lastName> Id: <id> Salary: <salary>
        //Privates:
        //<private1 ToString()>
        //<private2 ToString()>
        // …
        //<privateN ToString()>

    }
}

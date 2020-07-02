using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> test = new Dictionary<string, Dictionary<string, List<string>>>();

            string tekst = "mario";
            if (!test.ContainsKey(tekst))
            {
                test[tekst] = new Dictionary<string, List<string>>();
                test["Ivo"] = new Dictionary<string, List<string>>();
                test["Gabi"] = new Dictionary<string, List<string>>();
                test["Margi"] = new Dictionary<string, List<string>>();

                test["Ivo"]["последване"] = new List<string>();
                test["Ivo"]["последване"].Add("asd");
                test["Ivo"]["последване"].Add("asd");
                test["Ivo"]["последване"].Add("asd");
                test["Ivo"]["ne"] = new List<string>();
                test["Ivo"]["ne"].Add("asd");

                test[tekst]["последване"] = new List<string>();
                test[tekst]["последване"].Add("asd");
                test[tekst]["последване"].Add("asd");
                test[tekst]["последване"].Add("asd");
                test[tekst]["ne"] = new List<string>();

                test["Margi"]["последване"] = new List<string>();
                test["Margi"]["последване"].Add("asd");
                test["Margi"]["последване"].Add("asd");                
                test["Margi"]["ne"] = new List<string>();
                test["Margi"]["ne"].Add("asd");

                test["Gabi"]["последване"] = new List<string>();
                test["Gabi"]["последване"].Add("asd");
                test["Gabi"]["последване"].Add("asd");
                test["Gabi"]["ne"] = new List<string>();
                
            }
            var sortedTekst = test.OrderByDescending(v => v.Value["последване"].Count).ThenBy((v => v.Value["ne"].Count));

            foreach (var item in sortedTekst)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}

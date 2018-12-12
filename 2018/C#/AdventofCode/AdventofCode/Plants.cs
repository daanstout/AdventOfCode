using System;
using System.Collections.Generic;
using System.Text;

namespace AdventofCode {
    public class Plants {
        List<bool> plants = new List<bool>();
        readonly string[] rules;
        int nullIndex = 0;

        public Plants(string start, string[] rules) {
            foreach (char c in start) {
                if (!(c == '.' || c == '#'))
                    continue;
                plants.Add(c == '#');
            }

            this.rules = rules;
        }

        public void NextGen() {

            List<bool> nextGen = new List<bool>();

            for (int i = -2; i < plants.Count + 2; i++) {
                string planted = GetString(i);

                foreach (string rule in rules) {
                    if (planted.Equals(rule.Substring(0, 5))) {
                        bool plant = rule[rule.Length - 2] == '#';
                        if (i < 0 && !plant && nextGen.Count == 0)
                            break;
                        else {
                            if (i < 0)
                                nullIndex++;
                            nextGen.Add(plant);
                        }
                    }
                }
            }

            plants = nextGen;
        }

        public long Count() {
            long total = 0;

            for(int i = 0; i < plants.Count; i++) 
                if (plants[i])
                    total += i - nullIndex;

            return total;
        }

        public void Test() {
            Console.WriteLine(GetString(0));
            Console.WriteLine(GetString(1));
            Console.WriteLine(GetString(2));
            Console.WriteLine(GetString(3));
            Console.WriteLine(GetString(4));
        }

        public override string ToString() {
            string s = $"{nullIndex}\n";

            foreach (bool b in plants)
                s += (b ? '#' : '.');

            return s;
        }

        private string GetString(int index) {
            string s = "";

            for (int i = index - 2; i <= index + 2; i++) {
                if (i < 0)
                    s += ".";
                else if (i >= plants.Count)
                    s += ".";
                else
                    s += (plants[i] ? '#' : '.');
            }

            return s;
        }
    }
}

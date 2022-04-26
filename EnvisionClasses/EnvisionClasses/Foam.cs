using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvisionClasses
{
    class Foam
    {
        public int id;
        public string name;
        public int LastStepCompleted;
        public DateTime lastUpdated;
        public Dictionary<Bin, int> ItemsRequired; //Screws, 13; Bolts, 4
        public Foam(string[] saveInfo, List<Bin> AllBins)
        {
            id = int.Parse(saveInfo[0]);
            name = saveInfo[1];
            LastStepCompleted = int.Parse(saveInfo[2]);
            int[] timeParsed = Array.ConvertAll(saveInfo[3].Split(':'), s => int.Parse(s));
            lastUpdated = new DateTime(timeParsed[0], timeParsed[1], timeParsed[2], timeParsed[3], timeParsed[4], timeParsed[5]);
            ItemsRequired = new Dictionary<Bin, int>();
            foreach (string s in saveInfo[4].Split(','))
            {
                int[] bins = Array.ConvertAll(s.Split(':'), str => int.Parse(str));
                //bool binFound = false;
                foreach (Bin b in AllBins)
                    if (b.BinID == bins[0])
                    {
                        ItemsRequired.Add(b, bins[1]);
                        //binFound = true;
                        break;
                    }
                //if (!binFound)
                //    MessageBox.Show("Could not find information for bin " + bins[0].ToString() + ". Please verify that the bin displayed has the correct id, and that the given bin is stored in the save file.");
            }
        }
    }
}

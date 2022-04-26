using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvisionClasses
{
    enum BinColor
    {
        Red,
        Yellow,
        Blue
    }

    [System.Configuration.SettingsSerializeAs(System.Configuration.SettingsSerializeAs.String)]
    class Bin
    {
        public int BinID;
        public string QRCode;
        public string PartName;
        public bool OutOfStock;
        public BinColor color;
        public int order; //Note: Alternatively, this could be stored in an array, where the element of the array corresponds to the order of the bin.
        public DateTime lastUpdated;

        public Bin(string[] saveInfo)
        {
            BinID = int.Parse(saveInfo[0]);
            QRCode = saveInfo[1];
            PartName = saveInfo[2];
            OutOfStock = saveInfo[3] == "true";
            if (saveInfo[4] == "Yellow")
                color = BinColor.Yellow;
            else if (saveInfo[4] == "Red")
                color = BinColor.Red;
            order = int.Parse(saveInfo[5]);
            int[] timeParsed = Array.ConvertAll(saveInfo[6].Split(':'), s => int.Parse(s));
            lastUpdated = new DateTime(timeParsed[0], timeParsed[1], timeParsed[2], timeParsed[3], timeParsed[4], timeParsed[5]);
        }

        public Bin()
        {
            BinID = 0;
            QRCode = "";
            PartName = "";
            OutOfStock = true;
            color = BinColor.Blue;
            order = -1;
            lastUpdated = DateTime.MinValue;
        }
    }
}

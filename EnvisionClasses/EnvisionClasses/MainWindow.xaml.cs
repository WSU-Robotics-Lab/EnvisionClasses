using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnvisionClasses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static List<Bin> AllBins = new List<Bin>();
        List<Foam> AllFoams = new List<Foam>();

        

        

        struct User
        {
            DateTime ClockinTime; //If the user is clocked in for more than 24 hours, auto-clock out
            bool isClocked;
        }

        

        void FileWriter()
        {
            AllBins[0].OutOfStock = false;

            for (int i = 0; i < AllBins.Count; i++)
                if (AllBins[i].QRCode == "123")
                    AllBins[i].OutOfStock = true;

            List<Bin> a;

            System.Collections.Generic.List<Bin> b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currRead = "Bins";
            foreach (string s in System.IO.File.ReadAllLines(System.IO.Directory.GetCurrentDirectory() + "/SaveFile.txt").Skip(1))
            {
                switch (s)
                {
                    case "":
                        break;
                    case "Foams":
                        currRead = "Foams";
                        break;
                    default:
                        switch (currRead)
                        {
                            case "Foams":
                                AllFoams.Add(new Foam(s.Split(';'), AllBins));
                                break;
                            case "Bins":
                                AllBins.Add(new Bin(s.Split(';')));
                                break;
                        }
                        break;
                }
            }
        }
    }
}

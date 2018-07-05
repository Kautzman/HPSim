using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace BadSimCraft
{
    /// <summary>
    /// Interaction logic for HealerWindow.xaml
    /// </summary>
    public partial class HealerWindow : Window
    {
        public HealerWindow()
        {
            InitializeComponent();
            ReadFile();
        }

        public void ReadFile()
        {
            //var lines = File.ReadAllLines("C:\\healertemp\\data.csv");

            //var data = from l in lines.Skip(1)
            //           let split = l.Split(';')
            //           select new Party
            //           {
            //               Action = split[0],
            //               Time = split[1],
            //               Healer = split[2],
            //               Tank = split[3],
            //               DPS1 = split[4],
            //               DPS2 = split[5],
            //               DPS3 = split[6]
            //           };

            //HealerGrid.ItemsSource = data.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using BattleSim.Model;
using MahApps.Metro.Controls;

namespace BattleSim
{
    /// <summary>
    /// Interaction logic for DefendingPlayer.xaml
    /// </summary>
    public partial class DefendingPlayer : MetroWindow
    {
        public IList<Ship> Ships = MainWindow.ShipsDef;
        public IList<Technology> Technologies = MainWindow.TechnologiesDef;
        public DefendingPlayer()
        {
            InitializeComponent();
            Ship.ItemsSource = Ships;
            Technology.ItemsSource = Technologies;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MainWindow.TechnologiesDef = Technologies;
            MainWindow.ShipsDef = Ships;
            base.OnClosing(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using BattleSim.Model;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace BattleSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static IList<Ship> ShipsAtk = new List<Ship>();
        public static IList<Technology> TechnologiesAtk = new List<Technology>();
        public static IList<Ship> ShipsDef = new List<Ship>();
        public static IList<Technology> TechnologiesDef = new List<Technology>();

        public MainWindow()
        {
            for (int id = 0; id<ShipValues.Names.Length; ++id)
            {
                ShipsAtk.Add(new Ship(id));
                ShipsDef.Add(new Ship(id));
            }

            for (int id = 0; id < TechnologyValues.Name.Length; ++id)
            {
                TechnologiesAtk.Add(new Technology(id));
                TechnologiesDef.Add(new Technology(id));
            }

            DataContext = this;
            InitializeComponent();
        }

        private void OpenDefenderWindow(object sender, RoutedEventArgs e)
        {
            new DefendingPlayer().ShowDialog();
        }

        private void OpenAttackerWindow(object sender, RoutedEventArgs e)
        {
            new AttackPlayer().ShowDialog();
        }

        private void OnSimulateClick(object sender, RoutedEventArgs e)
        {
            BattleBox.Text = BattleScript.Run(ShipsAtk, ShipsDef, TechnologiesAtk, TechnologiesDef);
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            var safeFileDialog = new SaveFileDialog {Filter = "SOF|*.sof", InitialDirectory = AppDomain.CurrentDomain.BaseDirectory };
            safeFileDialog.ShowDialog();
            if (safeFileDialog.FileName != "")
            {
                var stream = (FileStream) safeFileDialog.OpenFile();
                var writer = new StreamWriter(stream);
                foreach (var ship in ShipsAtk)
                {
                    writer.WriteLine(ship.Amount);
                }

                foreach (var ship in ShipsDef)
                {
                    writer.WriteLine(ship.Amount);
                }

                foreach (var tech in TechnologiesAtk)
                {
                    writer.WriteLine(tech.Level);
                }

                foreach (var tech in TechnologiesDef)
                {
                    writer.WriteLine(tech.Level);
                }

                writer.Flush();
            }
        }

        private void OnLoadClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog() {Filter = "SOF|*.sof", Multiselect = false, InitialDirectory = AppDomain.CurrentDomain.BaseDirectory };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                var stream = (FileStream) openFileDialog.OpenFile();
                var reader = new StreamReader(stream);
                foreach (var ship in ShipsAtk)
                {
                    ship.Amount = int.Parse(reader.ReadLine() ?? throw new InvalidOperationException());
                }

                foreach (var ship in ShipsDef)
                {
                    ship.Amount = int.Parse(reader.ReadLine() ?? throw new InvalidOperationException());
                }

                foreach (var tech in TechnologiesAtk)
                {
                    tech.Level = int.Parse(reader.ReadLine() ?? throw new InvalidOperationException());
                }

                foreach (var tech in TechnologiesDef)
                {
                    tech.Level = int.Parse(reader.ReadLine() ?? throw new InvalidOperationException());
                }
            }
        }
    }
}
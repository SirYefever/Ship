using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ship.Additional_Windows
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public MainModel Main;
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public StartWindowViewModel viewModel { get; set; }
        public StartWindow(StartWindowViewModel givenViewModel)
        {
            InitializeComponent();
            viewModel = givenViewModel;
            DataContext = viewModel;
        }

        public void ClickLesGo(object sender, RoutedEventArgs e)
        {
            viewModel.CrowsNestRequired = CNCheckBox.IsChecked.GetValueOrDefault();
            viewModel.CannonsQuantity = int.Parse(Cannons.Text);
            viewModel.StockCapacity = int.Parse(StockCapacity.Text);
            viewModel.TreasureRoomCapacity = int.Parse(TreasureRoomCapacity.Text);
            
            Close();
        }
    }
}

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
using System.Windows.Shapes;

namespace Ship
{
    /// <summary>
    /// Interaction logic for CrewerRedactWindow.xaml
    /// </summary>
    public partial class CrewerRedactWindow : Window
    {
        public CrewerRedactWindow(CrewMember givenCrewer)
        {
            InitializeComponent();
            DataContext = givenCrewer;
        }

        public void ClickOK(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

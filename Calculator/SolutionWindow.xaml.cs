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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        public SolutionWindow(double conversion, string conversionType)
        {
            InitializeComponent();

            if (conversionType == "kg")
            {
                Label_Conversion.Content = conversion * 2.205;
            }
            else if (conversionType == "lbs")
            {
                Label_Conversion.Content = conversion / 2.205;
            } 
            else
            {
                Label_Conversion.Content = "Error...";
            }
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

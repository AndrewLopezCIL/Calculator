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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {

            InitializeComponent();
            InitializeWindowElements();
        }

        private void InitializeWindowElements()
        {

           
            TextBox_WeightToConvert.Focus();


        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double weight = 0;
            
            string typeOfConversion = "";




            if (validateInputs())
            {
              double.TryParse(TextBox_WeightToConvert.Text, out weight);
                if (RadioButton_Kilograms.IsChecked == true)
                {
                    typeOfConversion = "kg";
                    weight = weight * 2.205;
                    TextBox_WeightConverted.Text = weight.ToString();
                }
                else if (RadioButton_LBS.IsChecked == true)
                {
                    typeOfConversion = "lbs";
                    weight = weight / 2.205;
                    TextBox_WeightConverted.Text = weight.ToString();

                }

                SolutionWindow solutionWindow = new SolutionWindow(weight, typeOfConversion);

                solutionWindow.ShowDialog();
            }
         
        }

        private bool validateInputs()
        {
            bool validInputs = true;
            if (
                !double.TryParse(TextBox_WeightToConvert.Text, out double length) 
                )
            {
                MessageBox.Show("Please enter in decimal format.");
                validInputs = false;
                ResetInputs();
            } 
            return validInputs;
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
             
        }
            private void ResetInputs()
        { 
            TextBox_WeightConverted.Text = "";
            TextBox_WeightToConvert.Text = "";
            TextBox_WeightToConvert.Focus();
        }
      
    }
}

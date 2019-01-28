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
       static string currencyType = "";
        public MainWindow()
        {

            InitializeComponent();
            InitializeWindowElements();
        }

        private void InitializeWindowElements()
        {

           
            TextBox_incomeVariable.Focus();

            updateCurrency();

        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double income = 0;
            string timeOfincome; 

            
            if (validateInputs())
            {
                

                timeOfincome = ComboBox_Shape.SelectionBoxItem as string;

                    switch (timeOfincome)
                    {
                        case "Yearly":
                        income = double.Parse(TextBox_incomeVariable.Text) * double.Parse(TextBox_hoursVariable.Text) * 52.14;
                        break; 
                        case "Monthly":
                        income = double.Parse(TextBox_incomeVariable.Text) * double.Parse(TextBox_hoursVariable.Text) * 4;
                            break;
                        default:
                        income = double.Parse(TextBox_incomeVariable.Text) * double.Parse(TextBox_hoursVariable.Text);
                            break;
                    }
               

                TextBox_incomeResultVariable.Text = income.ToString();
                SolutionWindow solutionWindow = new SolutionWindow(income, currencyType);

                solutionWindow.ShowDialog();
            }
         
        }

        private bool validateInputs()
        {
            bool validInputs = true;
            if (
                !double.TryParse(TextBox_incomeVariable.Text, out double length)
                || 
                !double.TryParse(TextBox_hoursVariable.Text, out double width) 
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
            TextBox_hoursVariable.Text = "";
            TextBox_incomeVariable.Text = "";
            TextBox_incomeResultVariable.Text = "";
            TextBox_hoursVariable.Focus();
        }
        private void currencyCheck(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                updateCurrency();
            }
        }
        private void updateCurrency()
        {
            if ((bool)RadioButton_USD.IsChecked)
            {
                Label_incomeResult.Content = "Income (USD):";
                currencyType = "$";
            }
            else if ((bool)RadioButton_EURO.IsChecked)
            {
                Label_incomeResult.Content = "Income (EURO):";
                currencyType = "€";
            } 
        }
         
    }
}

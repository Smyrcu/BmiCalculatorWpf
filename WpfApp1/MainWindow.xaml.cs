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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accessibility;
using WpfApp1.Exceptions;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            heightTextBox.Text = String.Empty;
            weightTextBox.Text = String.Empty;
            systemComboBox.Items.Clear();
            systemComboBox.SelectedIndex = 0;
            systemComboBox.Items.Add("Metric");
            systemComboBox.Items.Add("Imperial");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox ?? throw new InvalidOperationException();

            switch (comboBox.SelectedIndex)
                {
                case 0:
                    weightLabel.Content = "Weight: (kg)";
                    heightLabel.Content = "Height: (cm)";
                    break;
                case 1:
                    weightLabel.Content = "Weight: (lbs)";
                    heightLabel.Content = "Height: (in)";
                    break;
            }



        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            double weight = double.Parse(weightTextBox.Text);
            double height = double.Parse(heightTextBox.Text);
            BmiCalculator bmiCalculator;
            BmiResult result = new BmiResult();
            switch (systemComboBox.SelectedIndex)
            {
                case 0:
                    bmiCalculator = new BmiCalculator(UnitSystem.Metric);
                    result = bmiCalculator.GetResult(weight, height);
                    break;
                case 1:
                    bmiCalculator = new BmiCalculator(UnitSystem.Imperial);
                    result = bmiCalculator.GetResult(weight, height);
                    break;
            }

            bmiLabel.Content = $"BMI: {result.Bmi} ({result.BmiClassification})";
            classificationLabel.Content = result.Summary;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

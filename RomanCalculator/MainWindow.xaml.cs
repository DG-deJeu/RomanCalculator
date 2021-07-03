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

namespace RomanCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Input1String;
        public static string Input2String;
        public static int Input1Int;
        public static int Input2Int;
        public static char Operand;
        public static int ResultInt;
        public static string ResultString;
        public static string OutputString;

        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void IButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "I";
            ResultLabel2.Content = Input1String;
        }

        private void VButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "V";
            ResultLabel2.Content = Input1String;
        }

        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "X";
            ResultLabel2.Content = Input1String;
        }

        private void LButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "L";
            ResultLabel2.Content = Input1String;
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "C";
            ResultLabel2.Content = Input1String;
        }

        private void DButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "D";
            ResultLabel2.Content = Input1String;
        }

        private void MButton_Click(object sender, RoutedEventArgs e)
        {
            Input1String += "M";
            ResultLabel2.Content = Input1String;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Operand = '+';
            OperandLabel.Content = Operand;
            ResultLabel1.Content = Input1String;
            ResultLabel2.Content = string.Empty;
            Input2String = Input1String;
            Input1String = string.Empty;
        }

        private void SubstractButton_Click(object sender, RoutedEventArgs e)
        {
            Operand = '-';
            OperandLabel.Content = Operand;
            ResultLabel1.Content = Input1String;
            ResultLabel2.Content = string.Empty;
            Input2String = Input1String;
            Input1String = string.Empty;
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            Operand = '*';
            OperandLabel.Content = Operand;
            ResultLabel1.Content = Input1String;
            ResultLabel2.Content = string.Empty;
            Input2String = Input1String;
            Input1String = string.Empty;
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            Operand = '/';
            OperandLabel.Content = Operand;
            ResultLabel1.Content = Input1String;
            ResultLabel2.Content = string.Empty;
            Input2String = Input1String;
            Input1String = string.Empty;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            ConvertRN();

            switch (Operand)
            {
                case '+':
                    ResultInt = Input2Int + Input1Int;
                    break;
                case '-':
                    ResultInt = Input2Int - Input1Int;
                    break;
                case '*':
                    ResultInt = Input2Int * Input1Int;
                    break;
                case '/':
                    ResultInt = Input2Int / Input1Int;
                    break;
                default:
                    break;
            }

            if (ResultInt == 0)
            {
                ResultString = "0";
            }
            else
            {
                ResultString = ConvertNR(ResultInt);
            }

            OperandLabel.Content = string.Empty;
            ResultLabel1.Content = string.Format("{0} {1} {2} = {3}", Input2String, Operand, Input1String, ResultString);
            ResultLabel2.Content = string.Empty;
            Reset();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            OperandLabel.Content = string.Empty;
            ResultLabel1.Content = string.Empty;
            ResultLabel2.Content = string.Empty;
        }

        private void Reset()
        {
            Input1Int = 0;
            Input2Int = 0;
            Input1String = string.Empty;
            Input2String = string.Empty;
            ResultInt = 0;
            ResultString = string.Empty;
        }

        public void ConvertRN()
        {
            for (int i = 0; i < Input1String.Length; i++)
            {
                if (i + 1 < Input1String.Length && RomanMap[Input1String[i]] < RomanMap[Input1String[i + 1]])
                {
                    Input1Int -= RomanMap[Input1String[i]];
                }
                else
                {
                    Input1Int += RomanMap[Input1String[i]];
                }
            }
            for (int i = 0; i < Input2String.Length; i++)
            {
                if (i + 1 < Input2String.Length && RomanMap[Input2String[i]] < RomanMap[Input2String[i + 1]])
                {
                    Input2Int -= RomanMap[Input2String[i]];
                }
                else
                {
                    Input2Int += RomanMap[Input2String[i]];
                }
            }
        }
        public static string ConvertNR(int number)
        {
            if ((number < 0) || (number > 3999)) return "insert value betwheen 1 and 3999";
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ConvertNR(number - 1000);
            if (number >= 900) return "CM" + ConvertNR(number - 900);
            if (number >= 500) return "D" + ConvertNR(number - 500);
            if (number >= 400) return "CD" + ConvertNR(number - 400);
            if (number >= 100) return "C" + ConvertNR(number - 100);
            if (number >= 90) return "XC" + ConvertNR(number - 90);
            if (number >= 50) return "L" + ConvertNR(number - 50);
            if (number >= 40) return "XL" + ConvertNR(number - 40);
            if (number >= 10) return "X" + ConvertNR(number - 10);
            if (number >= 9) return "IX" + ConvertNR(number - 9);
            if (number >= 5) return "V" + ConvertNR(number - 5);
            if (number >= 4) return "IV" + ConvertNR(number - 4);
            if (number >= 1) return "I" + ConvertNR(number - 1);
            else return "Error";
        }
    }
}

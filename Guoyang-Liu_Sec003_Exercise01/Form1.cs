using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Guoyang_Liu_Sec003_Exercise01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //groupBox 1
        private async void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                long number = int.Parse(factonalTextBox.Text);
                long factorNumber = await myFactorFun2(number);
                factonalDisplayLabel.Text = $"Factonal of {number} is:{factorNumber}";
            }
            
            catch
            {
                MessageBox.Show("Please enter a valied number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        // displays factor numbers in factorTextBox
        private async Task<long> myFactorFun2(long n)
        {
            // find primes less than maximum
            
                if (n == 0)
                    return 1;
                       
                long temp = await myFactorFun2(n - 1) * n;
                
                return temp;                      
        }//groupBox1 end

        //groupBox2
       
        private async void checkButton_Click(object sender, EventArgs e)
        {
            try
            {
                int number2 = int.Parse(evenOrOddTextBox.Text);
                Func<int, bool> IsEven = (int number) => number % 2 == 0;
                Func<int, bool> IsOdd = (int number) => number % 2 != 0;
                if (IsEven(number2))
                {
                    //  evenOrOddResultLabel.Visible = true;
                    oddEvenLabel.Text = $"{number2} is an even";
                }
                else if (IsOdd(number2))
                {
                    //evenOrOddResultLabel.Visible = true;
                    oddEvenLabel.Text = $"{number2} is an odd";
                }             
            }
            catch
            {
                MessageBox.Show("Please enter a valid number!");
            }
            
        }

        //groupBox2 end

        //groupBox3
        int[] integerArray = new int[10];
        double[] doubleArray = new double[10];
        char[] charArray = new char[10];
        Random random = new Random();
        private async void generateButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            try
            {
                if (IntegerRadioButton.Checked)
                {                  
                    for (int i = 0; i < 10; i++)
                    {

                        integerArray[i] = random.Next(10, 99);
                        radomTextBox.AppendText($"{integerArray[i]}{Environment.NewLine}");
                    }
                }
                else if (DoubleRadioButton.Checked)
                {
                    string result = null;
                    for (int i = 0; i < 10; i++)
                    {
                        doubleArray[i] = Math.Round(rnd.NextDouble() * (100 - 10) + 10, 2);
                        result = doubleArray[i].ToString();
                        radomTextBox.AppendText(result + Environment.NewLine);
                    }

                }
                else if (CharRadioButton.Checked)
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    chars.ToCharArray();
                    for (int i = 0; i < 10; i++)
                    {
                        int index = random.Next(0, 51);
                        char selectedChar = Convert.ToChar(chars.Substring(index, 1));
                        radomTextBox.AppendText(selectedChar + Environment.NewLine);
                        charArray[i] = selectedChar;
                    }
                }               
            }
            catch
            {
                MessageBox.Show("Please select your option!");
            }
        }

        private bool SearhData<T>(List<T> list, T value) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(value) == 0)
                {
                    return true;
                    //break;
                }
            }

            return false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (IntegerRadioButton.Checked)
            {
                try
                {
                    int searchIntValue = int.Parse(searchValueTextBox.Text); //Convert.ToInt32(searchValueTextBox.Text.ToString());
                    List<int> intList = new List<int>(integerArray);//. OfType<int>().ToList();
                    if (SearhData(intList, searchIntValue))
                        MessageBox.Show(searchIntValue + " " + " is Found");
                    else
                        MessageBox.Show(searchIntValue + " " + " is not found");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Wrong information! ", MessageBoxButtons.OK);
                }

            }
            if (DoubleRadioButton.Checked)
            {
                try
                {
                    if (!searchValueTextBox.Text.ToString().Contains("."))
                    {
                        MessageBox.Show("Please enter a double value");
                    }
                    else
                    {
                        double searchDoubleValue = Convert.ToDouble(searchValueTextBox.Text.ToString());
                        List<double> doubleList = new List<double>(doubleArray);
                        if (SearhData(doubleList, searchDoubleValue))
                            MessageBox.Show(searchDoubleValue + " " + "Found");
                        else
                            MessageBox.Show(searchDoubleValue + " " + "Not found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Wrong information! ", MessageBoxButtons.OK);
                }
            }
            if (CharRadioButton.Checked)
            {
                try
                {
                    char searchCharValue = Convert.ToChar(searchValueTextBox.Text.ToString());
                    List<char> charList = new List<char>(charArray);
                    if (Char.IsDigit(searchCharValue))
                    {
                        MessageBox.Show("Please enter a character");
                    }
                    else if (SearhData(charList, searchCharValue))
                    {
                        MessageBox.Show(searchCharValue + " " + "Found");
                    }
                    else
                    {
                        MessageBox.Show(searchCharValue + " " + "Not found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Wrong information! ", MessageBoxButtons.OK);
                }
            }
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            try
            {
                int lowIndex = Convert.ToInt32(lowIndexTextBox.Text);
                int highIndex = Convert.ToInt32(highIndexTextBox.Text);
                if (lowIndex < highIndex)
                {
                    string result = null;
                    for (int i = lowIndex; i <= highIndex; i++)
                    {
                        if (IntegerRadioButton.Checked) result += integerArray[i-1] + ", ";
                        if (DoubleRadioButton.Checked) result += doubleArray[i-1] + ", ";
                        if (CharRadioButton.Checked) result += charArray[i-1] + ", ";
                    }
                    resultTextBox.Text = result;
                }
                else MessageBox.Show("Low index can not be greater than high index.");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

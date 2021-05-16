using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                {
                    textBox_Result.Text = textBox_Result.Text + button.Text;
                    label1.Text += button.Text;
                }
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
                label1.Text += button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
                equalsTo();
            if (resultValue == 0)
                resultValue = Double.Parse(textBox_Result.Text);

            operationPerformed = button.Text;
            label1.Text += button.Text;
            isOperationPerformed = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox_Result.Text;
            if (str != "" && str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
            textBox_Result.Text = str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            label1.Text = "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            equalsTo();
            resultValue = 0;
            label1.Text = textBox_Result.Text;
        }

        public void equalsTo()
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "x":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    Double zeroTry = Double.Parse(textBox_Result.Text);
                    if (zeroTry != 0)
                        textBox_Result.Text = (resultValue / zeroTry).ToString();
                    else
                    {
                        MessageBox.Show("Division by 0 will result in ∞", "DivideByZeroException ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Result.Text = resultValue.ToString();
                    }
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = (float.Parse(textBox_Result.Text) / 100).ToString();
            label1.Text += "%";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = (Math.Sqrt(double.Parse(textBox_Result.Text))).ToString();
            label1.Text += "√";
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
    
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        List<string> calculationHistory = new List<string>();
        int maxHistoryCount = 2; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" || isOperationPerformed)
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button15.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            string calculation = labelCurrentOperation.Text + " " + textBox_Result.Text + " = ";

            double currentValue = Double.Parse(textBox_Result.Text); 
            switch (operationPerformed)
            {
                case "+":
                    resultValue += currentValue;
                    break;
                case "-":
                    resultValue -= currentValue; 
                    break;
                case "*":
                    resultValue *= currentValue; 
                    break;
                case "/":
                    if (currentValue != 0)
                    {
                        resultValue /= currentValue; 
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                default:
                    break;
            }

            calculation += resultValue; 

            if (calculationHistory.Count >= maxHistoryCount)
            {
                calculationHistory.RemoveAt(0);
            }
            calculationHistory.Add(calculation);

            textBox_Result.Text = resultValue.ToString();
            labelCurrentOperation.Text = "";
        }


        private void buttonHistory_Click(object sender, EventArgs e)
        {
            string historyText = string.Join("\n", calculationHistory);
            MessageBox.Show(historyText, "Calculation History");
        }
       
    }
}

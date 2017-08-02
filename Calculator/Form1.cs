using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private double _textBoxValue = 0; //the value as seen in the textbox
        private string _operator = ""; //operator clicked +,-,/,* or %
        private bool _operationDone = false; //used operator?

        public Calculator()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox.Text.Contains(".") && e.KeyChar == '.')
            {
                e.Handled = true;
            }
                

            else if ((e.KeyChar > (char) Keys.D9 || e.KeyChar < (char) Keys.D0) && e.KeyChar != (char) Keys.Back &&
                     e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
         
        }
        //for buttons 0 to 9
        private void button_click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || _operationDone)
            {
                textBox.Clear(); //when initial value is zero clear the zero
                //when operator pressed clear the text
            }
            var button = (Button)sender;
            textBox.Text = textBox.Text + button.Text;
            _operationDone = false;//set _operation done back to false 
        }

        private void period_Click(Object sender, EventArgs e)
        {
            if (textBox.Text.Contains("."))
            {
                textBox.Text = textBox.Text;
            }
            else textBox.Text = textBox.Text + ".";
        }

        private void operator_click(object sender, EventArgs e)
        {
            var button = (Button) sender;
            if (_textBoxValue != 0)
            {
                equalsTo.PerformClick();
            }
            _operator = button.Text;
            if (_operator == "%")
            {
                textBox.Text = (Double.Parse(textBox.Text) / 100).ToString();
                _textBoxValue = (Double.Parse(textBox.Text)) / 100;
            }
            else
            _textBoxValue = Double.Parse(textBox.Text);

            labelCurrent.Text = _textBoxValue + " " + _operator;
    
            _operationDone = true;
           


        }

        private void buttonCE_click(object sender, EventArgs e)
        {
            textBox.Text = "0";

        }

        private void picture_click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright Baibhav");
        }


        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
            _textBoxValue = 0;
            labelCurrent.Text = "";

        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            switch (_operator)
            {
                case "+":
                    textBox.Text =( _textBoxValue + Double.Parse(textBox.Text)).ToString();
                    break;
                

                case "-":
                
                    textBox.Text = (_textBoxValue - Double.Parse(textBox.Text)).ToString();
                    break;
                
                case "*":
                    textBox.Text = (_textBoxValue * Double.Parse(textBox.Text)).ToString();
                    break;

                 case "/":
                     textBox.Text = (_textBoxValue / Double.Parse(textBox.Text)).ToString();
                     break;
                default:
                    break;

            }
            
        }
    }
}

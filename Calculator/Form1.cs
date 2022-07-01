namespace Calculator
{
    public enum Operations
    {
        Add,
        Subtract,
        Divide,
        Multiply,
        None
    }
    public partial class Form1 : Form
    {
        private string _firstValue, _secondValue;
        private Operations _operator = Operations.None;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void onButtonNumberClick(object sender, EventArgs e)
        {
            var clickedValue = (sender as Button).Text;

            if (textBox1.Text == "0")
                textBox1.Text = String.Empty;

            textBox1.Text += clickedValue;

            if(_operator != Operations.None)
            {
                _secondValue += clickedValue;
            }
        }

        private void onButtonOperation(object sender, EventArgs e)
        {
            if(_operator == Operations.None)
            {
                _firstValue = textBox1.Text;
                var operation = (sender as Button).Text;
                _operator = operation switch
                {
                    "+" => Operations.Add,
                    "-" => Operations.Subtract,
                    "*" => Operations.Multiply,
                    "/" => Operations.Divide,
                    _ => Operations.None,

                };
                textBox1.Text += $" {operation} ";

            }
              
        }

        private void onButtonResult(object sender, EventArgs e)
        {
            var firstNumber = double.Parse(_firstValue);
            var secondNumber = double.Parse(_secondValue);
            var result = 0d;
            switch (_operator)
            {
                case Operations.None:
                    result = firstNumber;
                    break;
                case Operations.Add:
                    result = firstNumber + secondNumber;
                    break;
                case Operations.Subtract:
                    result = firstNumber - secondNumber;
                    break;
                case Operations.Divide:
                    if(secondNumber == 0)
                    {
                        MessageBox.Show("Nie mo¿na dzieliæ przez zero");
                        result = 0;
                    }
                    result = firstNumber / secondNumber;
                    break;
                case Operations.Multiply: 
                    result = firstNumber * secondNumber;
                    break;
            }

            textBox1.Text = result.ToString();
            _secondValue = "";
            _operator = Operations.None;
        }

        private void onButtonClear(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            _firstValue = String.Empty;
            _secondValue = String.Empty;
            _operator = Operations.None;

        }

      
    }
}
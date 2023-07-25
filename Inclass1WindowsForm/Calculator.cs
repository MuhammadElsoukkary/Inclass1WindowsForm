namespace Inclass1WindowsForm
{
    public partial class Calculator : Form
    {
        private double x = 0; // Left-hand operand
        private double y = 0; // Right-hand operand or result
        private bool isNewNum = true; // Flag to track new number input

        private string pendingOperation = ""; // Operator to be applied between x and the next number



        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DigtalClickHandler(object sender, EventArgs e)
        {
            if (isNewNum)
            {
                lblEquation.Clear();
                isNewNum = false;
            }

            Button btnClicked = (Button)sender;
            string buttonText = btnClicked.Text;

            if (buttonText == ".")
            {
                // Check if the current number already contains a decimal point
                if (!lblEquation.Text.Contains("."))
                {
                    lblEquation.Text += buttonText; // Append the decimal point to the label
                }
            }
            else
            {
                lblEquation.Text += buttonText; // Append the digit to the label
            }
        }



        private void operations_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;

            if (!string.IsNullOrEmpty(pendingOperation))
            {
                Calculate();
            }
            else if (!double.TryParse(lblEquation.Text, out x))
            {
                MessageBox.Show("Invalid input");
                return;
            }

            lblEquation.Text += " " + btnClicked.Text + " "; // Append the operator to the label
            pendingOperation = btnClicked.Text; // Set the pendingOperation to the operator displayed on the button
            isNewNum = true;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            if (!double.TryParse(lblEquation.Text, out y))
            {
                MessageBox.Show("Invalid input");
                return;
            }

            double result = 0;

            switch (pendingOperation)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    if (y != 0) // Check for division by zero
                        result = x / y;
                    else
                    {
                        MessageBox.Show("Error: Division by zero");
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("Invalid operation");
                    return;
            }

            lblEquation.Text = result.ToString();
            x = 0;
            pendingOperation = "";
            isNewNum = true;
        }
        private void txtDisplay(object sender, EventArgs e)
        {


        }
        private void clear_Click(object sender, EventArgs e)
        {
            lblEquation.Clear();
            isNewNum = true;
            pendingOperation = "";
            x = 0;
            y = 0;
        }

        private void backspace_Click(object sender, EventArgs e)
        {


            if (isNewNum)
                return;

            if (lblEquation.Text.Length > 0)
            {
                lblEquation.Text = lblEquation.Text.Substring(0, lblEquation.Text.Length - 1);
            }
        }
    }   }
using System.Windows.Forms;

namespace PANBTG_GUI.Forms
{
    public partial class NumericPopupForm : Form
    {
        public NumericPopupForm()
        {
            InitializeComponent();
        }

        public void setupInput(double val = 0, int decimalPlaces = 0, double increment = 1, double min = double.MinValue, double max = double.MaxValue)
        {
            numericInput.Value = new decimal(val);
            numericInput.Minimum = new decimal(min);
            numericInput.Maximum = new decimal(max);
            numericInput.DecimalPlaces = decimalPlaces;
            numericInput.Increment = new decimal(increment);
        }

        public void setQuestionText(string question)
        {
            questionLabel.Text = question;
        }

        public decimal getResult()
        {
            return numericInput.Value;
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void applyButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

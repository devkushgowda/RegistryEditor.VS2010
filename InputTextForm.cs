using System.Drawing;
using System.Windows.Forms;

namespace RegistryEditor
{
    public partial class InputTextForm : Form
    {
        private readonly string _initialValue;
        public string InputText { private set; get; }
        public InputTextForm(string title, string initialValue)
        {
            InitializeComponent();
            _initialValue = textBox1.Text = initialValue ?? "";
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && _initialValue != textBox1.Text)
            {
                InputText = textBox1.Text;
                this.Close();
            }
        }
    }
}

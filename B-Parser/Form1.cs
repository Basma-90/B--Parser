using com.calitha.goldparser;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P_Parser
{
    public partial class Form1 : Form
    {
        MyParser myParser;

        public Form1()
        {
            InitializeComponent();
            myParser = new MyParser("grammer6.cgt", listBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            myParser.Parse(textBox1.Text);
        }
    }
}

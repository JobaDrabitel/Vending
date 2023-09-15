using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class MoneyEnterForm : Form
    {
        private List<int> bills = new List<int> { 10, 50, 100, 200, 500, 1000, 5000, 2000 };
        private MainForm _mainForm;
        public MoneyEnterForm()
        {
            InitializeComponent();
        }
        public MoneyEnterForm(MainForm main)
        {

            InitializeComponent();
            _mainForm = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                var bill = Convert.ToInt32(textBox1.Text);
                if (!bills.Contains(bill))
                {
                    textBox1.Text = "";
                    _mainForm.ChangeTextBox("ОШИБКА ПОПОЛНЕНИЯ");
                    return;
                }
                _mainForm.AddSumToMachine(Convert.ToDecimal(textBox1.Text));
                this.Close();
            }
            catch
            {
                _mainForm.ChangeTextBox("ОШИБКА ПОПОЛНЕНИЯ");
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}

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
    public partial class CoinEnterForm : Form
    {
        public CoinEnterForm()
        {
            InitializeComponent();
        }

        private List<int> bills = new List<int> { 1, 2, 5 , 10 };
        private MainForm _mainForm;

        public CoinEnterForm(MainForm main)
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
                    _mainForm.ChangeTextBox("ОШИБКА ПОПОЛНЕНИЯ");
                    textBox1.Text = "";
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
      
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}

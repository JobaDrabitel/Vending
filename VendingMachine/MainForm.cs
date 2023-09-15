using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VendingMachine
{
    public partial class MainForm : Form
    {
        private VendingMachine machine;
        public MainForm()
        {
            InitializeComponent();
            machine = new VendingMachine();
            AddProducts();
            AddCoins();
            LoadProducts();
            UpdateDeposit();
            textBox1.ReadOnly = true;
            textBox1.Height = 60;
            ChangeTextBox("Внесите сумму или выберите товар");
        }

        private void AddProducts()
        {
            machine.AddProduct(new Product("Coca Cola", 16, 1.50m, Properties.Resources.Coca_Cola_Can_icon));
            machine.AddProduct(new Product("Sprite", 10, 1.20m, Properties.Resources.Sprite1));
            machine.AddProduct(new Product("Soda", 11, 1.10m, Properties.Resources.soda_glass_drink_icon_vector_13258706));
            machine.AddProduct(new Product("Pepsi", 12, 1.50m, Properties.Resources.images_pepsi_can_icon_coke_pepsi_can_iconset_michael_334748));
            machine.AddProduct(new Product("Carlsberg beer", 5, 2.0m, Properties.Resources.images_carlsberg_can_x_malta_beers_ciders_malta_foreign_334730));
            machine.AddProduct(new Product("Japanese Green Tea", 6, 1.90m, Properties.Resources.images_japanese_green_tea_wasabi_sushibar_bento_sushi_et_gastronomie_334743));
            machine.AddProduct(new Product("Bottle of water", 4, 1.55m, Properties.Resources._45));
            machine.AddProduct(new Product("Twix", 5, 1.25m, Properties.Resources.icon_512_512_true_91c73aa52b373f5f5f90894525dbec96));
            machine.AddProduct(new Product("Snickers", 1, 1.35m, Properties.Resources.snickers_by_slamiticon_d6ox3f5_fullview));
            machine.AddProduct(new Product("Stickletti", 6, 0.90m, Properties.Resources.front_sr_7_full));
            machine.AddProduct(new Product("McDonald's Burger", 7, 2.50m, Properties.Resources.sous_vide_burgers_80013b_f8b0a00b960c2f00e00bbaac));
            machine.AddProduct(new Product("Lay's", 4, 1.20m, Properties.Resources._00028400199141));
        }

        private void AddCoins()
        {
            machine.AddCountedCoins(new int[6] { 10, 5, 2, 1, 7, 4 });
        }

        private void LoadProducts()
        {
            PictureBox[] images = { pbProduct1, pbProduct5, pbProduct6,pbProduct8, };
            Label[] prices = {lblProductPrice6,
                lblProductPrice8 };
            for (int i = 0; i < images.Length; i++)
            {
           
             
            }
        }

        private string ToAmountString(decimal amount)
        {
            return "€" + amount.ToString("0.00");
        }

        private void SelectProduct(int slot)
        {
            machine.SelectedProduct = machine.Products[slot - 1];
            textBox1.Text = $"Выбран товар {machine.SelectedProduct.Name}";
        }

        private void pbProduct1_Click(object sender, EventArgs e)
        {
            SelectProduct(1);
        }

        private void pbProduct2_Click(object sender, EventArgs e)
        {
            SelectProduct(2);
        }

        private void pbProduct3_Click(object sender, EventArgs e)
        {
            SelectProduct(3);
        }

        private void pbProduct4_Click(object sender, EventArgs e)
        {
            SelectProduct(4);
        }

        private void pbProduct5_Click(object sender, EventArgs e)
        {
            SelectProduct(5);
        }

        private void pbProduct6_Click(object sender, EventArgs e)
        {
            SelectProduct(6);
        }

        private void pbProduct7_Click(object sender, EventArgs e)
        {
            SelectProduct(7);
        }

        private void pbProduct8_Click(object sender, EventArgs e)
        {
            SelectProduct(8);
        }

        private void pbProduct9_Click(object sender, EventArgs e)
        {
            SelectProduct(9);
        }

        private void pbProduct10_Click(object sender, EventArgs e)
        {
            SelectProduct(10);
        }

        private void pbProduct11_Click(object sender, EventArgs e)
        {
            SelectProduct(11);
        }

        private void pbProduct12_Click(object sender, EventArgs e)
        {
            SelectProduct(12);
        }

        private void UpdateDeposit()
        {
            rtbDeposit.Text = ToAmountString(machine.Deposit);
            rtbDeposit.SelectAll();
            rtbDeposit.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void pb2euros_Click(object sender, EventArgs e)
        {
            machine.AddDeposit(new _2EurosCoin());
            UpdateDeposit();
        }

        private void pb1euro_Click(object sender, EventArgs e)
        {
            machine.AddDeposit(new _1EuroCoin());
            UpdateDeposit();
        }

        private void pb50cents_Click(object sender, EventArgs e)
        {
            machine.AddDeposit(new _50CentsCoin());
            UpdateDeposit();
        }

        private void pb20cents_Click(object sender, EventArgs e)
        {
            machine.AddDeposit(new _20CentsCoin());
            UpdateDeposit();
        }

        private void pb10cents_Click(object sender, EventArgs e)
        {
            machine.AddDeposit(new _10CentsCoin());
            UpdateDeposit();
        }

        private void pb5cents_Click(object sender, EventArgs e)
        {
            machine.AddDeposit(new _5CentsCoin());
            UpdateDeposit();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                machine.BuyProduct();
                UpdateDeposit();
                pbSelectedProduct.Image = machine.Products[machine.SelectedProduct.UID - 1].Image;
                textBox1.Text = $"Куплен товар {machine.SelectedProduct.Name}, Цена: {machine.SelectedProduct.Price}";
            }
            catch 
            {
                textBox1.Text = $"Ошибка покупки";
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (machine.Deposit != 0)
            {
                textBox1.Text = $"Выдается сдача: {machine.Deposit}";
                machine.Abort();
                UpdateDeposit();
                pictureBox3.Image = System.Drawing.Image.FromFile(@"C:\Users\Saida\Source\Repos\VendingMachineSimulator\VendingMachine\images\coins.png");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MoneyEnterForm coinEnterForm = new MoneyEnterForm(this);
            coinEnterForm.Show();
        }
        public  void AddSumToMachine(decimal sum)
        {
            textBox1.Text = $"Пополнение на сумму {sum}";
            machine.AddDeposit(sum);
            UpdateDeposit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CoinEnterForm coinEnterForm = new CoinEnterForm(this);
            coinEnterForm.Show();
        }

        private void pbSelectedProduct_Click(object sender, EventArgs e)
        {
            pbSelectedProduct.Image = null;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
        }
        public void ChangeTextBox(string text)
        {
            textBox1.Text = text;
        }
    }
}

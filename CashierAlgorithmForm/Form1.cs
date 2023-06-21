using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierAlgorithmForm
{
    public partial class Form1 : Form
    {
        bool canWithdraw = false;
        Currency currency;
        Account account;
        Account accountTRY = new Account { name = "TRY", amount = 742 };
        Account accountGBP = new Account { name = "GBP", amount = 352 };
        Account accountUSD = new Account { name = "USD", amount = 132 };
        Account accountEUR = new Account { name = "EUR", amount = 513 };


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(amountTbx.Text) <= account.amount)
            {
                moneyLbl.Text = findMin(Convert.ToInt32(amountTbx.Text), currency.Deno);
                canWithdraw = true;
            }
            else
            {
                successLbl.Text = "Not enough balance!";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            currency = new Currency { Name = "TRY", Deno = new int[] { 1, 5, 10, 20, 50, 100, 200 } };

            accountCbx.Items.Add("TRY");
            accountCbx.Items.Add("GBP");
            accountCbx.Items.Add("USD");
            accountCbx.Items.Add("EUR");

            
        }

        private void currencyCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        static string findMin(int V, int[] denom)
        {
            int n = denom.Length;

            string output = "";
            List<int> ans = new List<int>();


            for (int i = n - 1; i >= 0; i--)
            {

                while (V >= denom[i])
                {
                    V -= denom[i];
                    ans.Add(denom[i]);
                }
            }


            for (int i = 0; i < ans.Count; i++)
            {
                output += ans[i] + " ";
            }
            return output;
        }

        private void accountCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (accountCbx.SelectedIndex)
            {
                case 0:
                    currency = new Currency { Name = "TRY", Deno = new int[] { 1, 5, 10, 20, 50, 100, 200 }, Sign = "TL" };
                    account = accountTRY;
                    balanceLbl.Text = account.amount.ToString() + currency.Sign;
                    break;
                case 1:
                    currency = new Currency { Name = "GBP", Deno = new int[] { 1, 2, 5, 10, 20, 50 }, Sign = "£" };
                    account = accountGBP;
                    balanceLbl.Text = account.amount.ToString() + currency.Sign;
                    break;
                case 2:
                    currency = new Currency { Name = "USD", Deno = new int[] { 1, 2, 5, 10, 20, 50, 100 }, Sign = "$" };
                    account = accountUSD;
                    balanceLbl.Text = account.amount.ToString() + currency.Sign;
                    break;
                case 3:
                    currency = new Currency { Name = "EUR", Deno = new int[] { 1,2,5, 10, 20, 50, 100, 200 }, Sign = "€" };
                    account = accountEUR;
                    balanceLbl.Text = account.amount.ToString() + currency.Sign;
                    break;
                default:
                    break;
            }

        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            if (canWithdraw)
            {
                account.amount -= Convert.ToInt32(amountTbx.Text);
                balanceLbl.Text = account.amount.ToString() + currency.Sign;
                successLbl.Text = "Withdraw is succesfull!";
                canWithdraw = false;
            }
            else
                successLbl.Text = "Calculate First! ";
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            canWithdraw = false;
        }
    }
}

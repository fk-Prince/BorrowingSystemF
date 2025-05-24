using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorrowingSystem
{
    public partial class PaymentPenalty : Form
    {
        public PaymentPenalty()
        {
            InitializeComponent();
        }

        private void PaymentPenalty_Load(object sender, EventArgs e)
        {
            btnProcess.FlatStyle = FlatStyle.Flat;
            btnProcess.FlatAppearance.BorderSize = 0;
            btnProcess.BackColor = ColorTranslator.FromHtml("#89CFF0 ");
            btnProcess.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnProcess.ForeColor = Color.White;

            btnProcess.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnProcess.Width, btnProcess.Height, 20, 20));

            btnView.FlatStyle = FlatStyle.Flat;
            btnView.FlatAppearance.BorderSize = 0;
            btnView.BackColor = ColorTranslator.FromHtml("#89CFF0 ");
            btnView.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnView.ForeColor = Color.White;

            btnView.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnView.Width, btnView.Height, 20, 20));

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClose.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClose.ForeColor = Color.White;

            btnClose.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 30, 30));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();  

            form.Show();
            this.Hide();
        }
        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = ColorTranslator.FromHtml("#89CFF0 ");
            btnSave.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnSave.ForeColor = Color.White;

            btnSave.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnSave.Width, btnSave.Height, 20, 20));

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
    }
}

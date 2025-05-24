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
    public partial class ReturnEquipment : Form
    {
        public static ReturnEquipment instance;
        public ReturnEquipment()
        {
            InitializeComponent();

            instance = this;

            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }

        private void ReturnEquipment_Load(object sender, EventArgs e)
        {
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.FlatAppearance.BorderSize = 0;
            btnCheck.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnCheck.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnCheck.ForeColor = Color.White;

            btnCheck.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnCheck.Width, btnCheck.Height, 30, 30));

            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnSubmit.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnSubmit.ForeColor = Color.White;

            btnSubmit.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnSubmit.Width, btnSubmit.Height, 30, 30));


            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnClear.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClear.ForeColor = Color.White;

            btnClear.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, 5, 5));

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
    }
}

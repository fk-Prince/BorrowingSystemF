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
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnConfirm.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnConfirm.ForeColor = Color.White;

            btnConfirm.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnConfirm.Width, btnConfirm.Height, 30, 30));


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

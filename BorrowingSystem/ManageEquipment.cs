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
    public partial class ManageEquipment : Form
    {
        public ManageEquipment()
        {
            InitializeComponent();

            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void ManageEquipment_Load(object sender, EventArgs e)
        {
             

            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnAdd.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnAdd.ForeColor = Color.White;

            btnAdd.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 30, 30));

            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnUpdate.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnUpdate.ForeColor = Color.White;

            btnUpdate.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnUpdate.Width, btnUpdate.Height, 30, 30));

            btnRetire.FlatStyle = FlatStyle.Flat;
            btnRetire.FlatAppearance.BorderSize = 0;
            btnRetire.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnRetire.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnRetire.ForeColor = Color.White;

            btnRetire.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnRetire.Width, btnRetire.Height, 30, 30));

            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 2;
            btnRefresh.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnRefresh.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnRefresh.ForeColor = Color.White;

            btnRefresh.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnRefresh.Width, btnRefresh.Height, 5, 5));

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClose.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClose.ForeColor = Color.White;

            btnClose.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 30, 30));
        }
        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRetire_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}

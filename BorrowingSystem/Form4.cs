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
    public partial class AddBorrower : Form
    {
        public static AddBorrower instance;
        public AddBorrower()
        {
            InitializeComponent();

            instance = this;

            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void AddBorrower_Load(object sender, EventArgs e)
        {
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnSave.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnSave.ForeColor = Color.White;

            btnSave.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnSave.Width, btnSave.Height, 30, 30));

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClose.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClose.ForeColor = Color.White;

            btnClose.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 30, 30));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();

            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

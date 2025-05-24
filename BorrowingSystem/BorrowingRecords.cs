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
    public partial class Records : Form
    {
        public static Records instance;
        public Records()
        {
            InitializeComponent();

            instance = this;

            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Records_Load(object sender, EventArgs e)
        {

            btnView.FlatStyle = FlatStyle.Flat;
            btnView.FlatAppearance.BorderSize = 0;
            btnView.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnView.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnView.ForeColor = Color.White;

            btnView.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnView.Width, btnClose.Height, 30, 30));

            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnPrint.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnPrint.ForeColor = Color.White;

            btnPrint.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnPrint.Width, btnClose.Height, 30, 30));

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClose.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClose.ForeColor = Color.White;

            btnClose.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 30, 30));

            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.FlatAppearance.BorderSize = 2;
            btnApply.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnApply.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnApply.ForeColor = Color.White;

            btnApply.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnApply.Width, btnApply.Height, 5, 5));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

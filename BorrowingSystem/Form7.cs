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
   
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();

            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.BackColor = ColorTranslator.FromHtml("#89CFF0 ");
            btnAdd.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnAdd.ForeColor = Color.White;

            btnAdd.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));

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
            
        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();

            form.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

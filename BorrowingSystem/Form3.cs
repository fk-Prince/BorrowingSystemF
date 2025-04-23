using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorrowingSystem;

namespace BorrowingSystem
{
    public partial class Form3 : Form
    {

        public static Form3 instance;
        public Form3()
        {
            InitializeComponent();

            instance = this;

            this.MaximizeBox = false;
            this.MinimizeBox = true;


                
         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(255, 0, 39, 77);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(15, 255, 255, 255);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.BackColor = ColorTranslator.FromHtml("#89CFF0 ");
            btnNew.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnNew.ForeColor = Color.White;

            btnNew.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnNew.Width, btnNew.Height, 20, 20));

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();

            this.Hide();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            AddBorrower form = new AddBorrower();
            form.Show();

            this.Hide();
        }
    }
}

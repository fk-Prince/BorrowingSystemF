using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorrowingSystem;

namespace BorrowingSystem
{

    public partial class LoginForm : Form
    {
        public static LoginForm instance;
        public LoginForm()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            instance = this; 
            this.MinimizeBox = true;
            this.MaximizeBox = false;


             

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(15, 255, 255, 255);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
             
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Don't leave blank space", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (username.Text == "admin" && password.Text == "password")  
            {
                Dashboard form = new Dashboard();
                form.Show();  

                this.Hide();  
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = ColorTranslator.FromHtml("#00274D");
            btnLogin.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnLogin.ForeColor = Color.White;

            btnLogin.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 30, 30));


            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.BackColor = ColorTranslator.FromHtml("#00274D");
            btnCancel.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnCancel.ForeColor = Color.White;

            btnCancel.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 30, 30));

            
        }
    }
}


 

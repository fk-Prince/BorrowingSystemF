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
using MySql.Data.MySqlClient;

namespace BorrowingSystem
{
    public partial class LoginForm : Form
    {
        public static LoginForm instance;
        private readonly DatabaseConnection dbConnection;  // Add reference to your DbConn class

        public LoginForm()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            instance = this;
            this.MinimizeBox = true;
            this.MaximizeBox = false;

            dbConnection = new DatabaseConnection();
        }
        public static string CurrentUser { get; private set; }

        // In your successful login code:
        private void SuccessfulLogin(string username)
        {
            CurrentUser = username;  // Set the current user
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }


      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameInput = username.Text;
            string passwordInput = password.Text;

            // Validate that fields are not empty
            if (string.IsNullOrWhiteSpace(usernameInput) || string.IsNullOrWhiteSpace(passwordInput))
            {
                MessageBox.Show("Don't leave blank space", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Database connection to check user credentials
            try
            {
                using (var conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT username FROM users WHERE username = @username AND password_hash = @password_hash LIMIT 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameInput);
                        cmd.Parameters.AddWithValue("@password_hash", passwordInput);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Dashboard form = new Dashboard();
                                form.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';  
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();  
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();  
        }
    }
}


 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BorrowingSystem
{
    public partial class AddBorrower : Form
    {
        public static AddBorrower instance;
        private DatabaseConnection conn;
        public AddBorrower()
        {
            InitializeComponent();
            conn = new DatabaseConnection();
            instance = this;
            textBox1.Text = getLastId();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }
        private string getLastId()
        {
            MySqlConnection c = null;
            string id = "";
            try
            {
                c = conn.GetConnection();
                c.Open();
                string query = "SELECT borrower_id FROM borrowers ORDER BY borrower_id DESC LIMIT 1";
                MySqlCommand comm = new MySqlCommand(query, c);
                MySqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                     id = reader.GetString("borrower_id");
                    int ids = int.Parse(id.Substring(4));
                    ids++;

                     id = id.Substring(0,4) + ids.ToString("D3"); 
                }
                else
                {
                     id = "BRW-001";
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                c.Close();
            }
            return id;
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
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }






        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            string fname = textBox2.Text.Trim();
            string lname = textBox3.Text.Trim();
            string mname = textBox4.Text.Trim();
            string address = textBox5.Text.Trim();
            string age = textBox6.Text.Trim();
            string gender = radioButton1.Checked ? "Male" : "Female";   
            string contact = textBox7.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(fname) ||
                string.IsNullOrWhiteSpace(lname) ||
                string.IsNullOrWhiteSpace(mname) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(age) ||
                string.IsNullOrWhiteSpace(contact) ||
                !radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Empty Fields","Empty Input",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MySqlConnection c = null;
            try
            {
                c = conn.GetConnection();
                c.Open();

                string query = "INSERT INTO borrowers (borrower_id, first_name, last_name, middle_name, address, age, gender, contact_number)" +
                    "VALUES (@borrower_id, @first_name, @last_name, @middle_name, @address, @age, @gender, @contact_number)";

                MySqlCommand comm = new MySqlCommand(query, c);
                comm.Parameters.AddWithValue("@borrower_id", id);
                comm.Parameters.AddWithValue("@first_name", fname);
                comm.Parameters.AddWithValue("@last_name", lname);
                comm.Parameters.AddWithValue("@middle_name", mname);
                comm.Parameters.AddWithValue("@address", address);
                comm.Parameters.AddWithValue("@age", age);
                comm.Parameters.AddWithValue("@gender", gender);
                comm.Parameters.AddWithValue("@contact_number", contact);
                comm.ExecuteNonQuery();
                MessageBox.Show("Suceess fully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BorrowEquipment browser = new BorrowEquipment();
                browser.Show();
                this.Hide();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                c.Close();
            }

        }
    }
}

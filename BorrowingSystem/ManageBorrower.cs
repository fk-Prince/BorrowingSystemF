using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;

namespace BorrowingSystem
{
   
    public partial class ManageBorrower : Form
    {
        private DatabaseConnection con;
        public ManageBorrower()
        {
            InitializeComponent();

            this.MinimizeBox = true;
            this.MaximizeBox = false;
            con= new DatabaseConnection();

            displayDataGrid();
                


        }
        private MySqlDataAdapter adapter;
        private void displayDataGrid()
        {
            try
            {
                MySqlConnection c = con.GetConnection();
                c.Open();

                string query = "SELECT * FROM borrowers WHERE is_active = 'Yes'";
                adapter = new MySqlDataAdapter(query,c);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGrid.DataSource = table;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

  
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.BackColor = ColorTranslator.FromHtml("#89CFF0 ");
            btnAdd.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnAdd.ForeColor = Color.White;

            btnAdd.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));

            btnDeact.FlatStyle = FlatStyle.Flat;
            btnDeact.FlatAppearance.BorderSize = 0;
            btnDeact.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnDeact.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnDeact.ForeColor = Color.White;

            btnDeact.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnDeact.Width, btnDeact.Height, 30, 30));

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClose.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClose.ForeColor = Color.White;

            btnClose.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 30, 30));

            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 2;
            btnEdit.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnEdit.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnEdit.ForeColor = Color.White;

            btnEdit.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnEdit.Width, btnEdit.Height, 5, 5));

            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 2;
            btnRefresh.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnRefresh.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnRefresh.ForeColor = Color.White;

            btnRefresh.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnRefresh.Width, btnRefresh.Height, 5, 5));

            btnsearch.FlatStyle = FlatStyle.Flat;
            btnsearch.FlatAppearance.BorderSize = 2;
            btnsearch.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnsearch.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnsearch.ForeColor = Color.White;

            btnsearch.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnsearch.Width, btnsearch.Height, 5, 5));



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }
 
        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        string id = "";

  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddBorrower form = new AddBorrower();
            form.Show();
            this.Hide();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGrid.EndEdit();
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.Update((DataTable)dataGrid.DataSource);

        }

        private void btnDeact_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id)) return;


            DialogResult rseult = MessageBox.Show($"Do you want to deactive this borrower {id}","Deacitveate", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (rseult == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection c = con.GetConnection();
                    c.Open();
                    string query = "UPDATE borrowers SET is_active = 'No' WHERE borrower_id = @borrower_id ";
                    MySqlCommand command  = new MySqlCommand(query, c);
                    command.Parameters.AddWithValue("@borrower_id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Success deacitveated id {id}");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    displayDataGrid();
                }
            }
        }

      

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGrid.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell || hit.Type == DataGridViewHitTestType.RowHeader)
            {

                int rowIndex = hit.RowIndex;
                if (rowIndex >= 0)
                {
                    DataGridViewRow row = dataGrid.Rows[rowIndex];
                    id = row.Cells["borrower_id"].Value.ToString();
                    MessageBox.Show(id);

                }    
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchBar.Text.Trim().ToLower().Replace("'", "''");

            if (dataGrid == null || dataGrid.Rows.Count == 0 && string.IsNullOrEmpty(keyword))
                return;

            DataTable dt = dataGrid.DataSource as DataTable;
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format(
                    "[borrower_id] LIKE '%{0}%' OR " +
                    "[First_Name] LIKE '{0}%' OR " +
                    "[Middle_Name] LIKE '{0}%' OR " +
                    "[Last_Name] LIKE '{0}%' ",
                    keyword
                );
            }
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BorrowingSystem;

namespace BorrowingSystem
{
    public partial class Dashboard : Form
    {
        private DatabaseConnection dbConn;
        public static Dashboard instance;

        public Dashboard()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
            instance = this;

            this.MaximizeBox = false;
            this.MinimizeBox = true;

            InitializeSearchSystem();
            InitializeDataGridView();
            this.Load += Dashboard_Load;
        }

        private void InitializeSearchSystem()
        {
            txtSearch.Text = "Search equipment...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            btnsearch.Click += Btnsearch_Click;
        }

        private void InitializeDataGridView()
        {
            //dataGridView1.Visible = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.MultiSelect = false;
            //dataGridView1.ReadOnly = true;
            //dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();

            // Button styling (preserved from original)
            btnsearch.FlatStyle = FlatStyle.Flat;
            btnsearch.FlatAppearance.BorderSize = 2;
            btnsearch.BackColor = ColorTranslator.FromHtml("#0066CC");
            btnsearch.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#89CFF0");
            btnsearch.ForeColor = Color.White;
            btnsearch.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnsearch.Width, btnsearch.Height, 5, 5));

            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.FlatAppearance.BorderSize = 2;
            btnBorrow.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnBorrow.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnBorrow.ForeColor = Color.White;
            btnBorrow.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnBorrow.Width, btnBorrow.Height, 5, 5));

            btnManageU.FlatStyle = FlatStyle.Flat;
            btnManageU.FlatAppearance.BorderSize = 2;
            btnManageU.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnManageU.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnManageU.ForeColor = Color.White;
            btnManageU.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnManageU.Width, btnManageU.Height, 5, 5));

            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.FlatAppearance.BorderSize = 2;
            btnReturn.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnReturn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnReturn.ForeColor = Color.White;
            btnReturn.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnReturn.Width, btnReturn.Height, 5, 5));

            btnManageE.FlatStyle = FlatStyle.Flat;
            btnManageE.FlatAppearance.BorderSize = 2;
            btnManageE.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnManageE.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnManageE.ForeColor = Color.White;
            btnManageE.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnManageE.Width, btnManageE.Height, 5, 5));

            btnRecords.FlatStyle = FlatStyle.Flat;
            btnRecords.FlatAppearance.BorderSize = 2;
            btnRecords.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnRecords.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnRecords.ForeColor = Color.White;
            btnRecords.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnRecords.Width, btnRecords.Height, 5, 5));

            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.FlatAppearance.BorderSize = 2;
            btnPayment.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnPayment.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnPayment.ForeColor = Color.White;
            btnPayment.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnPayment.Width, btnPayment.Height, 5, 5));
        }

        private void LoadEquipmentData(string searchTerm = "")
        {
            try
            {
                using (var conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                    equipment_id AS 'ID',
                                    equipment_name AS 'Equipment Name',
                                    description AS 'Description',
                                    total_quantity AS 'Total',
                                    available_quantity AS 'Available'
                                FROM equipment_inventory
                                WHERE equipment_name LIKE @searchTerm 
                                   OR description LIKE @searchTerm
                                ORDER BY equipment_name";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                //dataGridView1.DataSource = dt;
                                //dataGridView1.Visible = true;

                                //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#00274D");
                                //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                                //dataGridView1.EnableHeadersVisualStyles = false;
                            }
                            else
                            {
                                //dataGridView1.Visible = false;
                                MessageBox.Show("No equipment found matching your search.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //string equipmentId = row.Cells["ID"].Value.ToString();
                //string equipmentName = row.Cells["Equipment Name"].Value.ToString();

                BorrowEquipment form = new BorrowEquipment();
                form.Show();
                this.Hide();
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search equipment...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search equipment...";
                txtSearch.ForeColor = Color.Gray;
                //dataGridView1.Visible = false;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Focused && txtSearch.Text != "Search equipment...")
            {
                LoadEquipmentData(txtSearch.Text.Trim());
            }
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Search equipment...")
            {
                LoadEquipmentData(txtSearch.Text.Trim());
            }
            else
            {
                //dataGridView1.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(15, 255, 255, 255);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 217, 217, 217);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 137, 207, 240);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 137, 207, 240);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 217, 217, 217);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 0, 39, 77);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ManageEquipment form = new ManageEquipment();
            form.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageBorrower Form = new ManageBorrower();
            Form.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnEquipment form = new ReturnEquipment();
            form.Show();
            this.Hide();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            Records form = new Records();
            form.Show();
            this.Hide();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            LoginForm.instance.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentPenalty form = new PaymentPenalty();
            form.Show();
            this.Hide();
        }

        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Other existing methods
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void welcome_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void time_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(255, 0, 39, 77);
        }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void pictureBox8_Click(object sender, EventArgs e) { }

        private void btnManageE_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            AddBorrower addBorrower = new AddBorrower();
            addBorrower.Show();
            this.Hide();

        }
    }
}
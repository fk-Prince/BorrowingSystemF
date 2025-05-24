using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BorrowingSystem;

namespace BorrowingSystem
{
    public partial class BorrowEquipment : Form
    {
        private DatabaseConnection dbConn;

        public BorrowEquipment()
        {
            InitializeComponent();
            dbConn = new DatabaseConnection();
            this.FormClosing += closeform;
        }

        private void BorrowEquipment_Load(object sender, EventArgs e)
        {
            // Button Styling
            StyleButtons();

            // Load Data
            LoadBorrowersList();
            LoadEquipmentList();
            LoadStaffList();
        }

        private void StyleButtons()
        {
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnNew.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnNew.ForeColor = Color.White;
            btnNew.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnNew.Width, btnNew.Height, 20, 20));

            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnSubmit.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnSubmit.Width, btnSubmit.Height, 30, 30));

            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClear.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClear.ForeColor = Color.White;
            btnClear.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, 30, 30));

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#89CFF0");
            btnClose.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00274D");
            btnClose.ForeColor = Color.White;
            btnClose.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 30, 30));
        }

        private void LoadBorrowersList()
        {
            try
            {
                using (var conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT borrower_id, full_name FROM borrowers ORDER BY full_name";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        cbBorrower.DisplayMember = "full_name";
                        cbBorrower.ValueMember = "borrower_id";
                        cbBorrower.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowers: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEquipmentList()
        {
            try
            {
                using (var conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT equipment_id, equipment_name FROM equipment_inventory WHERE available_quantity > 0 ORDER BY equipment_name";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        cbEquipment.DisplayMember = "equipment_name";
                        cbEquipment.ValueMember = "equipment_id";
                        cbEquipment.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment list: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStaffList()
        {
            try
            {
                using (var conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT user_id, full_name FROM system_users WHERE role = 'Staff' ORDER BY full_name";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        cbStaff.DisplayMember = "full_name";
                        cbStaff.ValueMember = "user_id";
                        cbStaff.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff list: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEquipmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEquipment.SelectedIndex != -1)
            {
                LoadEquipmentDetails(cbEquipment.SelectedValue.ToString());
            }
        }

        private void LoadEquipmentDetails(string equipmentId)
        {
            try
            {
                using (var conn = dbConn.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT description, available_quantity FROM equipment_inventory WHERE equipment_id = @equipmentId";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@equipmentId", equipmentId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //txtDescription.Text = reader["description"].ToString();
                                //lblAvailableQty.Text = reader["available_quantity"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateBorrowForm())
            {
                try
                {
                    using (var conn = dbConn.GetConnection())
                    {
                        conn.Open();
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Insert into borrow_records
                                string borrowQuery = @"INSERT INTO borrow_records 
                                    (borrower_id, borrow_datetime, expected_return_datetime, created_by_user_id)
                                    VALUES (@borrowerId, @borrowDate, @returnDate, @staffId)";

                                int borrowId;
                                using (var cmd = new MySqlCommand(borrowQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@borrowerId", cbBorrower.SelectedValue);
                                    cmd.Parameters.AddWithValue("@borrowDate", dtpBorrowDate.Value);
                                    cmd.Parameters.AddWithValue("@returnDate", dtpReturnDate.Value);
                                    cmd.Parameters.AddWithValue("@staffId", cbStaff.SelectedValue);

                                    cmd.ExecuteNonQuery();
                                    borrowId = (int)cmd.LastInsertedId;
                                }

                                // Insert into borrow_details
                                string detailQuery = @"INSERT INTO borrow_details 
                                    (borrow_id, equipment_id, quantity_borrowed)
                                    VALUES (@borrowId, @equipmentId, @quantity)";

                                using (var cmd = new MySqlCommand(detailQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@borrowId", borrowId);
                                    cmd.Parameters.AddWithValue("@equipmentId", cbEquipment.SelectedValue);
                                    //cmd.Parameters.AddWithValue("@quantity", numQuantity.Value);
                                    cmd.ExecuteNonQuery();
                                }

                                // Update equipment_inventory
                                string updateQuery = @"UPDATE equipment_inventory 
                                    SET available_quantity = available_quantity - @quantity
                                    WHERE equipment_id = @equipmentId";

                                using (var cmd = new MySqlCommand(updateQuery, conn, transaction))
                                {
                                    //cmd.Parameters.AddWithValue("@quantity", numQuantity.Value);
                                    cmd.Parameters.AddWithValue("@equipmentId", cbEquipment.SelectedValue);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Equipment borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Reset form
                                ClearFields();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Error saving borrow: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            cbBorrower.SelectedIndex = -1;
            cbEquipment.SelectedIndex = -1;
            cbStaff.SelectedIndex = -1;
            //txtDescription.Clear();
            //lblAvailableQty.Text = "0";
            //numQuantity.Value = 1;
            dtpBorrowDate.Value = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today;
        }

        private bool ValidateBorrowForm()
        {
            if (cbBorrower.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a borrower.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbEquipment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select equipment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbStaff.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a staff in-charge.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (numQuantity.Value <= 0)
            //{
            //    MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //int availableQty = Convert.ToInt32(lblAvailableQty.Text);
            //if (numQuantity.Value > availableQty)
            //{
            //    MessageBox.Show($"Only {availableQty} items available.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                MessageBox.Show("Return date must be after borrow date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddBorrower addBorrowerForm = new AddBorrower();
            if (addBorrowerForm.ShowDialog() == DialogResult.OK)
            {
                LoadBorrowersList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(255, 0, 39, 77);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(15, 255, 255, 255);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Customize panel background
        }

        private void closeform(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BorrowEquipment_Load_1(object sender, EventArgs e)
        {

        }

        private void cbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

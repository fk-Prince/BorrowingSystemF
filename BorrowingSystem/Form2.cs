using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BorrowingSystem;

namespace BorrowingSystem
{
    public partial class Dashboard : Form
    {
        public static Dashboard instance;
        public Dashboard()
        {

            InitializeComponent();

            this.Load += Form2_Load;
            instance = this;

            this.MaximizeBox = false;
            this.MinimizeBox = true;

             
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(15, 255, 255, 255);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 217, 217, 217);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void welcome_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ManageEquipment form = new ManageEquipment();
            form.Show();
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();

            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
             
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(255, 0, 39, 77);
        }

        
         

        private void btnManage_Click(object sender, EventArgs e)
        {
             ManageUsers Form = new ManageUsers();

            Form.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();

            this.Hide();
        }

        

        private void pictureBox8_Click(object sender, EventArgs e)
        {
                
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
            LoginForm form = new LoginForm();

            form.Show();

            this.Hide();


        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentPenalty form = new PaymentPenalty();
            form.Show();
            this.Hide();
        }
    }
}

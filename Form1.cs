using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_diemB_QLCanBo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string ConnectionString = "Data Source=LAPTOP-Q5R2N5N2\\SQLL;Initial Catalog=qlycanBo;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaCB.Text != null || txtMaCB.Text.Trim() == "")
            {

            }
            else
            {
                MessageBox.Show("Chưa nhập tên tài khoản", "Thông báo");
                txtMaCB.Focus();
                return;
            }
            if (txtMatKhau.Text != null || txtMatKhau.Text.Trim() == "")
            {

            }
            else
            {
                MessageBox.Show("Chưa nhập tên mật khẩu", "Thông báo");
                txtMatKhau.Focus();
                return;
            }
            string userName = txtMaCB.Text;
            string passWord = txtMatKhau.Text;
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Open)
            {
                conn.Open();
            }
            string query = "SELECT * FROM CanBo WHERE MaCB='" + userName + "' AND  MatKhau='" + passWord + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Form2 main = new Form2();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu nhập chưa chính xác");
            }

        }

        private void F_Logout(object sender, EventArgs e)
        {
            (sender as Form2).isExit = false;// k tắt chương trình mà chỉ đăng xuất
            (sender as Form2).Close();
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                //Hides Textbox password
                txtMatKhau.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
        }
    }
}

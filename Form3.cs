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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_diemB_QLCanBo
{
    public partial class Form3_ThemCB : Form
    {
        public Form3_ThemCB()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Hide();
        }
        public static string ConnectionString = "Data Source=LAPTOP-Q5R2N5N2\\SQLL;Initial Catalog=qlycanBo;Integrated Security=True";


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Chưa nhập thông tin tên cán bộ", "Thông báo"); textBox1.Focus(); return; }
            if (textBox9.Text == "") { MessageBox.Show("Chưa nhập thông tin mật khẩu", "Thông báo"); textBox2.Focus(); return; }
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string MaCB = textBox1.Text.Trim();
            string HoTen = textBox2.Text.Trim();
            string DiaChi = textBox3.Text.Trim();
            string GioiTinh = comboBox1.Text.Trim();
            string NgaySinh = dateTimePicker1.Text.Trim();
            string MatKhau = textBox9.Text.Trim();
            string Khoa_ID = comboBox2.Text.Trim();
            string BoMon_ID = comboBox3.Text.Trim();
            string ChucVu_ID = comboBox4.Text.Trim();
            string TrinhDo_ID = comboBox5.Text.Trim();
            string LuongCB = textBox6.Text.Trim();
            string SoGioLV = textBox7.Text.Trim();
            string PhuCap = textBox8.Text.Trim();
            string Quyen = comboBox6.Text.Trim();
            string SDT = textBox4.Text.Trim();




            string query = "INSERT INTO CANBO (MaCB,HoTen,DiaChi,GioiTinh,NgaySinh,MatKhau,Khoa_ID,BoMon_ID,ChucVu_ID,TrinhDo_ID,LuongCB,SoGioLV,PhuCap, Quyen)  Values (N'" + MaCB + "',N'" + HoTen + "',N'" + DiaChi + "',N'" + GioiTinh + "',N'" + NgaySinh + "',N'" + MatKhau + "',N'" + Khoa_ID + "',N'" + BoMon_ID + "',N'" + ChucVu_ID + "',N'" + TrinhDo_ID + "',N'" + LuongCB + "',N'" + SoGioLV + "',N'" + PhuCap + "',N'" + Quyen +"')";
            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
                Form2 form2 = new Form2();
                form2 = new Form2();
                
                form2.Close();
            }
            else
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo");
            }
        }
    }
}

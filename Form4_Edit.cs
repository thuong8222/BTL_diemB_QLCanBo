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

namespace BTL_diemB_QLCanBo
{
    public partial class Form4_Edit : Form
    {
        public Form4_Edit(string maCB, string HoTen,string GioiTinh,string NgaySinh, string MatKhau, string Khoa_ID,
            string  Bomon_ID, string ChucVu_ID, string TrinhDo_ID, string DiaChi, string SDT, string LuongCB, string SoGioLV, string PhuCap, string Quyen )
        {
            InitializeComponent();
            textBox1.Text = maCB;
            textBox2.Text = HoTen;
            textBox3.Text = DiaChi;
            textBox4.Text = SDT;
            dateTimePicker1.Text = NgaySinh;
            textBox6.Text = LuongCB;
            textBox7.Text = SoGioLV;
            textBox8.Text = PhuCap;
            textBox9.Text = MatKhau;
            comboBox1.Text = GioiTinh;
            comboBox2.Text = Khoa_ID;
            comboBox3.Text = Bomon_ID;
            comboBox4.Text = ChucVu_ID;
            comboBox5.Text = TrinhDo_ID;
            comboBox6.Text = Quyen;
            
            
        }

        private void label1_Click(object sender, EventArgs e)
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

            string query = "UPDATE CANBO SET HoTen= N'" + HoTen + "',DiaChi= N'" + DiaChi + "',GioiTinh= N'" + GioiTinh + "',NgaySinh= N'" + NgaySinh + "',MatKhau= N'" + MatKhau + "',Khoa_ID= N'" + Khoa_ID + "',BoMon_ID = N'" + BoMon_ID + "',ChucVu_ID = N'" + ChucVu_ID  +"',TrinhDo_ID = N'" + TrinhDo_ID + "',LuongCB = N'" + LuongCB+ "',PhuCap = N'" + PhuCap + "',Quyen = N'" + Quyen + "',SoGioLV = N'" + SoGioLV+ "',SDT = N'" + SDT + "' WHERE MaCB = '" + MaCB + "';";


            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu", "Thông báo");
            }
            this.Close();
        }
    }
}

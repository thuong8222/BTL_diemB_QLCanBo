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
    public partial class Form2 : Form
    {
        public bool isExit = true; // mặc định tắt hoàn toàn chương trình
        public event EventHandler Logout;

        public Form2()
        {
            InitializeComponent();
            GetData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public static string ConnectionString = "Data Source=LAPTOP-Q5R2N5N2\\SQLL;Initial Catalog=qlycanBo;Integrated Security=True";

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Ban muon dong chuong trinh", "Canh bao", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;

            }
            
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isExit)
                Application.Exit();
        }



        private void dangxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());//ham uy thac
        }
        public void GetData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Open();
                }
                string query = "SELECT * FROM CANBO";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    label1.Text = "Tổng số :" + (dataGridView1.Rows.Count - 1) + " bản ghi";

                }
                else
                {
                    dataGridView1.DataSource = null;
                    label1.Text = "Tổng số :0 bản ghi";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Open();
                }
                string chon=comboBox1.Text.ToString();
                string key = txtTimKiemMaCB.Text.Trim();
                string query = "SELECT * FROM CANBO WHERE "+ chon + " = '" + key + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    label1.Text = "Tổng số :" + (dataGridView1.Rows.Count - 1) + " bản ghi";

                }
                else
                {
                    dataGridView1.DataSource = null;
                    label1.Text = "Tổng số :0 bản ghi";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlycanBoDataSet.CANBO' table. You can move, or remove it, as needed.
            this.cANBOTableAdapter.Fill(this.qlycanBoDataSet.CANBO);

        }
        public string maCB,HoTen, GioiTinh, NgaySinh, MatKhau, Khoa_ID, Bomon_ID, ChucVu_ID, TrinhDo_ID, DiaChi, SDT, LuongCB, SoGioLV, PhuCap, Quyen ;

        private void chứcVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5_ThongKeChucVu form5_ThongKeChucVu = new Form5_ThongKeChucVu();
            form5_ThongKeChucVu.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4=new Form4();
            form4.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult results = MessageBox.Show("Bạn có thực sự muốn xóa???", "Xác nhận xóa chức vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (results == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    string query = "DELETE FROM CANBO  WHERE maCB = '" + maCB + "' ";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo");
                        GetData();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xóa dữ liệu", "Thông báo");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form4_Edit edit_Page = new Form4_Edit(maCB, HoTen, GioiTinh, NgaySinh, MatKhau, Khoa_ID, Bomon_ID, ChucVu_ID, TrinhDo_ID, DiaChi, SDT, LuongCB, SoGioLV, PhuCap, Quyen);
            edit_Page.Show();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form3_ThemCB add_Page = new Form3_ThemCB();
            add_Page.Show();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[index];
                maCB = row.Cells["MaCB"].Value.ToString();
                HoTen = row.Cells["HoTen"].Value.ToString();
                GioiTinh = row.Cells["GioiTinh"].Value.ToString();
                NgaySinh = row.Cells["NgaySinh"].Value.ToString();
                MatKhau = row.Cells["MatKhau"].Value.ToString();
                Khoa_ID = row.Cells["Khoa_ID"].Value.ToString();
                Bomon_ID = row.Cells["Bomon_ID"].Value.ToString();
                ChucVu_ID = row.Cells["ChucVu_ID"].Value.ToString();
                TrinhDo_ID = row.Cells["TrinhDo_ID"].Value.ToString();
                DiaChi = row.Cells["DiaChi"].Value.ToString();
                SDT = row.Cells["SDT"].Value.ToString();
                LuongCB = row.Cells["LuongCB"].Value.ToString();
                SoGioLV = row.Cells["SoGioLV"].Value.ToString();
                PhuCap = row.Cells["PhuCap"].Value.ToString();
                Quyen = row.Cells["Quyen"].Value.ToString();

            }
            catch (Exception)
            {

            }
        }
    }
}

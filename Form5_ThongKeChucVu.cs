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
    public partial class Form5_ThongKeChucVu : Form
    {
        public Form5_ThongKeChucVu()
        {
            InitializeComponent();
        }
        public static string ConnectionString = "Data Source=LAPTOP-Q5R2N5N2\\SQLL;Initial Catalog=qlycanBo;Integrated Security=True";

        private void Form5_ThongKeChucVu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlycanBoDataSet.ChucVu' table. You can move, or remove it, as needed.
            this.chucVuTableAdapter.Fill(this.qlycanBoDataSet.ChucVu);
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT COUNT(ChucVu_ID) as SLCV  from ChucVu";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                label4.Text = ds.Tables[0].Rows[0]["SLCV"].ToString();
            }
            else
            {
                label4.Text = "";

            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void chucVuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.chucVuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qlycanBoDataSet);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

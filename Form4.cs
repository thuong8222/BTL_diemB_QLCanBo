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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public static string ConnectionString = "Data Source=LAPTOP-Q5R2N5N2\\SQLL;Initial Catalog=qlycanBo;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlycanBoDataSet.TRINHDO' table. You can move, or remove it, as needed.
            this.tRINHDOTableAdapter.Fill(this.qlycanBoDataSet.TRINHDO);
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT TenTrinhDo,COUNT(TrinhDo_ID) as SLTD  from TRINHDO WHERE TenTrinhDo='thac sy' GROUP BY TenTrinhDo";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                label4.Text = ds.Tables[0].Rows[0]["SLTD"].ToString();
            }
            else
            {
                label4.Text ="";

            }
            string query1 = "SELECT TenTrinhDo,COUNT(TrinhDo_ID) as SLTD  from TRINHDO WHERE TenTrinhDo='tien si' GROUP BY TenTrinhDo";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                label5.Text = ds1.Tables[0].Rows[0]["SLTD"].ToString();
            }
            else
            {
                label5.Text = "";
            }
            string query2 = "SELECT TenTrinhDo,COUNT(TrinhDo_ID) as SLTD  from TRINHDO WHERE TenTrinhDo='giao su' GROUP BY TenTrinhDo";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                label6.Text = ds2.Tables[0].Rows[0]["SLTD"].ToString();
            }
            else
            {
                label6.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void tRINHDOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tRINHDOBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qlycanBoDataSet);

        }
    }
}

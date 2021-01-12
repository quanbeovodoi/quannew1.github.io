using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraThaoMocPhuongThao
{
    class Connect
    {
        public string strCon = @"Data Source=DESKTOP-GFL0M2R\SQLEXPRESS;Initial Catalog=bandotrangsuc;Integrated Security=True";
        public DataSet ds;
        public SqlCommand cmd;
        public SqlConnection conn;
        SqlDataAdapter sda;
        public DataSet select(string sql)
        {
            conn = new SqlConnection(strCon);
            conn.Open();
            ds = new DataSet();
            cmd = new SqlCommand(sql, conn);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            conn.Close();
            return ds;
        }

        public bool update(string sql)
        {
            conn = new SqlConnection(strCon);
            bool check = false;
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                check = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("failure");
            }
            conn.Close();
            return check;
        }
        public void Ngatketnoi()
        {
            if (conn.State != 0)
            {
                conn.Close();
            }
        }
        public DataTable XemDL(string sql)
        {
            conn = new SqlConnection(strCon);
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
            Ngatketnoi();
        }
        public SqlCommand ThucThiDl(string sql)
        {
            conn = new SqlConnection(strCon);
            conn.Open();
            SqlCommand cm = new SqlCommand(sql, conn);
            cm.ExecuteNonQuery();
            return cm;
            Ngatketnoi();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraThaoMocPhuongThao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.RememberMe == "true")
            {
                txtName.Text = Properties.Settings.Default.User;
                txtPassword.Text = Properties.Settings.Default.Password;
                checkSave.Checked = true;
            }
            else
            {
                txtName.Text = "";
                txtPassword.Text = "";
                checkSave.Checked = false;
            }
        }

        private void checkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSave.Checked)
            {
                Properties.Settings.Default.User = txtName.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.RememberMe = "true";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.User = txtName.Text;
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RememberMe = "false";
                Properties.Settings.Default.Save();
            }
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Tài Khoản hoặc mật khẩu không được trống !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Connect conn = new Connect();
                DataSet ds = new DataSet();
                ds = conn.select("select * from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    checkSave_CheckedChanged(sender, e);
                    HomePage.quyen = conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyHoaDon.quyen = conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyKhachHang.quyen = conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLySanPham.quyen = conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim();
                    QuanLyNhanVien.quyen = conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim();
                    DatHang.quyen = conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim(); 
                    danhmucsanpham.quyen= conn.XemDL("select decentralization from UserAccount where UserName = '" + txtName.Text + "' and Password = '" + txtPassword.Text + "'").Rows[0][0].ToString().Trim();
                    MessageBox.Show("You login successfully ");
                    HomePage homePage = new HomePage();
                    this.Hide();
                    homePage.Show();
                    
                }
                else
                {
                    MessageBox.Show("You login unsuccessful");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool insert = conn.update("INSERT INTO UserAccount values(N'" + txtSetUserName.Text + "', N'" + txtSetPassword.Text + "', N'" + txtPhanQuyen.Text + "')");
            if (insert == true)
            {
                MessageBox.Show("Sign Up Success");
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();

            }
            else
            {
                MessageBox.Show("Registration failed");
            }
        }
    }
}

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
    public partial class DatHang : Form
    {
        public static string quyen;
        public DatHang()
        {
            InitializeComponent();
            Connect conn = new Connect();
            DataSet ds = new DataSet();
            ds = conn.select("select * from nhanvien");
            cbNhanvien.DataSource = ds.Tables[0];
            cbNhanvien.ValueMember = "manv";
            cbNhanvien.DisplayMember = "tennv";

            ds = conn.select("select * from khachhang");
            cbkhanhhang.DataSource = ds.Tables[0];
            cbkhanhhang.ValueMember = "makh";
            cbkhanhhang.DisplayMember = "tenkh";
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();
            this.Hide();
            qlnv.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang qlkh = new QuanLyKhachHang();
            this.Hide();
            qlkh.Show();
        }


        private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatHang dathang = new DatHang();
            this.Hide();
            dathang.Show();
        }

        private void danhSáchHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon qlhd = new QuanLyHoaDon();
            this.Hide();
            qlhd.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DatHang_Load(object sender, EventArgs e)
        {
            if (quyen == "User")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            else if (quyen == "KhachHang")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            Connect connect = new Connect();
            DataSet ds = new DataSet();
            ds = connect.select("Select * from sanpham");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for(int i = 0; i< connect.XemDL("Select * from sanpham").Rows.Count; i++)
                {
                    lstSanPham.Items.Add(connect.XemDL("Select * from sanpham").Rows[i][1].ToString());
                }
            }
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhmucsanpham a = new danhmucsanpham();
            this.Hide();
            a.Show();
        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham qlsp = new QuanLySanPham();
            this.Hide();
            qlsp.Show();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            while (lstSanPham.SelectedItems.Count > 0)
            {
                lstchitiet.Items.Add(lstSanPham.SelectedItem);
                lstSanPham.Items.Remove(lstSanPham.SelectedItem);
            }
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            while (lstchitiet.SelectedItems.Count > 0)
            {
                lstSanPham.Items.Add(lstchitiet.SelectedItem);
                lstchitiet.Items.Remove(lstchitiet.SelectedItem);
            } 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstchitiet.Text = "";
            txtMaHoaDon.Text = "";
            txtPhone.Text = "";
            txtDiaChi.Text = "";
        }

        private void btnDathang_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            conn.ThucThiDl("insert into hoadon values ('"+txtMaHoaDon.Text+ "','" + cbkhanhhang.SelectedValue + "','" + cbNhanvien.SelectedValue + "','"+datetimeLHD.Value+"','"+0+"' )");
            for (int i = 0; i <lstchitiet.Items.Count; i++)
            {
                string masp = conn.XemDL("select masanpham from sanpham where tensanpham = N'" + lstchitiet.Items[i].ToString().Trim() + "' ").Rows[0][0].ToString().Trim();
                string tien = conn.XemDL("select giasanpham from sanpham where masanpham='" + masp + "'").Rows[0][0].ToString().Trim();
                conn.ThucThiDl("insert into CTHD values ('" + txtMaHoaDon.Text.ToString().Trim() + "','" + masp + "','" + 1 + "','" + Convert.ToInt32(tien) + "')");
                MessageBox.Show("Thêm thành công");
            }
            QuanLyHoaDon.MaHD = txtMaHoaDon.Text.Trim();
            QuanLyHoaDon frm = new QuanLyHoaDon();
            this.Hide();
            frm.ShowDialog();
        }

    }
}

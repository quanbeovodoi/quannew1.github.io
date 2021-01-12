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
    public partial class QuanLySanPham : Form
    {
        public static string quyen;
        public QuanLySanPham()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select * from danhmucsanpham");
            cbsanpham.DataSource = ds.Tables[0];
            cbsanpham.ValueMember = "madanhmucsanpham";
            cbsanpham.DisplayMember = "tendanhmucsanpham";
            KetQua();
        }
        public void KetQua()
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select masanpham as 'Mã sản phẩm', tensanpham as 'Tên sản phẩm', tendanhmucsanpham as 'Loại sản phẩm',giasanpham as 'Giá sản phẩm' from sanpham,danhmucsanpham where sanpham.madanhmucsanpham=danhmucsanpham.madanhmucsanpham");
            dgvsanpham.DataSource = ds.Tables[0];
        }
        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            if (quyen == "User")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            else if (quyen == "KhachHang")
            {
                btnSua.Enabled = false;
                btnThemsanpham.Enabled = false;
                btnXoaSanpham.Enabled = false;
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
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


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhmucsanpham DMSP = new danhmucsanpham();
            this.Hide();
            DMSP.Show();
        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham qlsp = new QuanLySanPham();
            this.Hide();
            qlsp.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtgiasanpham.Text = "";
            txtmasanpham.Text = "";
            txttensanpham.Text = "";
            cbsanpham.SelectedValue = "";
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select masanpham as 'Mã sản phẩm', tensanpham as 'Tên sản phẩm', danhmucsanpham.tendanhmucsanpham as 'Loại sản phẩm',giasanpham as 'Giá sản phẩm' from sanpham,danhmucsanpham where sanpham.madanhmucsanpham=danhmucsanpham.madanhmucsanpham");
            dgvsanpham.DataSource = ds.Tables[0];
        }

        private void btnThemsanpham_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("insert into sanpham values(N'" + txtmasanpham.Text + "',N'" + txttensanpham.Text + "',N'"+cbsanpham.SelectedValue+ "',N'" + txtgiasanpham.Text + "') ");
            if (kiemtra == true)
            {
                MessageBox.Show("Bạn đã thêm thành công");
                KetQua();
            }
            else
            {
                MessageBox.Show("Bạn thêm thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("UPDATE sanpham set tensanpham = N'" + txttensanpham.Text + "',madanhmucsanpham = N'" + cbsanpham.SelectedValue + "',giasanpham = N'" + txtgiasanpham.Text + "' where masanpham = N'" + txtmasanpham.Text + "'");
            if (kiemtra == true)
            {
                MessageBox.Show("Bạn đã sửa thành công");
                KetQua();
            }
            else
            {
                MessageBox.Show("Bạn sửa thất bại");
            }
        }

        private void btnXoaSanpham_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("delete sanpham where masanpham = N'" + txtmasanpham.Text + "'");
            if (kiemtra == true)
            {
                MessageBox.Show("Bạn đã xoá thành công");
                KetQua();
            }
            else
            {
                MessageBox.Show("Bạn xoá thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select masanpham as 'Mã sản phẩm', tensanpham as 'Tên sản phẩm', danhmucsanpham.tendanhmucsanpham as 'Loại sản phẩm',giasanpham as 'Giá sản phẩm' from sanpham,danhmucsanpham where sanpham.madanhmucsanpham=danhmucsanpham.madanhmucsanpham and masanpham like N'%" + txtmasanpham.Text + "%'  ");
            dgvsanpham.DataSource = ds.Tables[0];
        }

        private void dgvsanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _row = e.RowIndex;
            txtmasanpham.Text = dgvsanpham.Rows[_row].Cells[0].Value.ToString();
            txttensanpham.Text = dgvsanpham.Rows[_row].Cells[1].Value.ToString();
            cbsanpham.Text = dgvsanpham.Rows[_row].Cells[2].Value.ToString();
            txtgiasanpham.Text = dgvsanpham.Rows[_row].Cells[3].Value.ToString();
        }
    }
}

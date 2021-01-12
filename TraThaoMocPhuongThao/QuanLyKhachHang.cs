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
    public partial class QuanLyKhachHang : Form
    {
        public static string quyen;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            KetQua();
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

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            if (quyen == "User")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            else if (quyen == "KhachHang")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                btnXoa.Enabled = false;
                btnthem.Enabled = false;
                btnSua.Enabled = false;
                quảnLýKháchHàngToolStripMenuItem.Visible = false;
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
        public void KetQua()
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select makh as 'Mã khách hàng', tenkh as 'Tên khách hàng', ngaysinh as 'Ngày sinh',sodienthoai as 'Số điện thoại',diachi as 'Địa chỉ' from khachhang");
            dgvkhachhang.DataSource = ds.Tables[0];
        }
        private void btnHienthi_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select makh as 'Mã khách hàng', tenkh as 'Tên khách hàng', ngaysinh as 'Ngày sinh',sodienthoai as 'Số điện thoại',diachi as 'Địa chỉ' from khachhang");
            dgvkhachhang.DataSource = ds.Tables[0];
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmakh.Text = "";
            txtTenkh.Text = "";
            txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("insert into khachhang values(N'" + txtmakh.Text + "',N'" + txtTenkh.Text + "',N'" + txtNgaySinh.Text + "',N'" + txtSDT.Text + "',N'" + txtDiaChi.Text + "') ");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("delete khachhang where makh = '" + txtmakh.Text + "' ");
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("UPDATE khachhang set tenkh =N'" + txtTenkh.Text + "',ngaysinh =N'" + txtNgaySinh.Text + "',sodienthoai =N'" + txtSDT.Text + "',diachi =N'" + txtDiaChi.Text + "' where makh = '" + txtmakh.Text + "' ");


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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DataSet ds = new DataSet();
            ds = conn.select("select makh as 'Mã khách hàng', tenkh as 'Tên khách hàng', ngaysinh as 'Ngày sinh',sodienthoai as 'Số điện thoại',diachi as 'Địa chỉ' from khachhang where makh like N'%" + txtmakh.Text + "%' ");
            dgvkhachhang.DataSource = ds.Tables[0];
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _row = e.RowIndex;
            txtmakh.Text = dgvkhachhang.Rows[_row].Cells[0].Value.ToString();
            txtTenkh.Text = dgvkhachhang.Rows[_row].Cells[1].Value.ToString();
            txtNgaySinh.Text = dgvkhachhang.Rows[_row].Cells[2].Value.ToString();
            txtSDT.Text = dgvkhachhang.Rows[_row].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvkhachhang.Rows[_row].Cells[4].Value.ToString();
        }
    }
}

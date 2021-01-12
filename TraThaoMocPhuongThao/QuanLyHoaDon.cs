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
    public partial class QuanLyHoaDon : Form
    {
        public static string quyen;
        public static string MaHD;
        public string macthd;
        Connect conn = new Connect();
        DataSet ds = new DataSet();
        public QuanLyHoaDon()
        {
            InitializeComponent();
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

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            if (quyen == "User")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            else if (quyen == "KhachHang")
            {
                
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            dgvSanPham.DataSource = conn.XemDL("select MaCTHD, tensanpham, soluong, thanhtien from hoadon, CTHD, sanpham where hoadon.mahoadon = CTHD.mahoadon and CTHD.masanpham=sanpham.masanpham and hoadon.mahoadon='" + MaHD + "'");
            //Tính tổng tiền của hóa đơn
            txtTongTien.Text = conn.XemDL("select sum(thanhtien) as tongtien from CTHD where mahoadon='" + MaHD + "'").Rows[0][0].ToString();
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //lấy mã sp tương ứng với macthd, mahd, ténp
            string masp = conn.XemDL("select masanpham from sanpham where tensanpham =N'" + txtTenSP.Text.Trim() + "'").Rows[0][0].ToString().Trim();
            //Tính tiền của sản phẩm khi đã thay đổi số lượng
            float tien = Convert.ToInt32(conn.XemDL("select giasanpham from sanpham where masanpham='" + masp + "'").Rows[0][0].ToString().Trim()) * Convert.ToInt32(txtSoLuong.Text.Trim());
            //thực thi câu lệnh update số lượng và tiền của sản phẩm
            conn.ThucThiDl("update CTHD set soluong ='" + Convert.ToInt32(txtSoLuong.Text.ToString()) + "', thanhtien='" + tien + "' where MaCTHD='" + txtCTHD.Text.ToString() + "' and  mahoadon ='" + MaHD + "' and  masanpham ='" + masp + "'");
            //Load lại dữ liệu
            dgvSanPham.DataSource = conn.XemDL("select MaCTHD, tensanpham, soluong, thanhtien from hoadon, CTHD, sanpham where hoadon.mahoadon=CTHD.mahoadon and CTHD.masanpham=sanpham.masanpham and hoadon.mahoadon='" + MaHD + "'");
            //Tính lại tổng tiền
            txtTongTien.Text = conn.XemDL("select sum(thanhtien) as tongtien from CTHD where mahoadon='" + MaHD + "'").Rows[0][0].ToString();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            conn.ThucThiDl("update hoadon set tongtien='" + Convert.ToInt32(txtTongTien.Text.Trim()) + "' where mahoadon='"+MaHD+"'");
            MessageBox.Show("Lưu thành công");
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _row = e.RowIndex;
            txtCTHD.Text = dgvSanPham.Rows[_row].Cells[0].Value.ToString();
            txtTenSP.Text = dgvSanPham.Rows[_row].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvSanPham.Rows[_row].Cells[2].Value.ToString();
        }
    }
}

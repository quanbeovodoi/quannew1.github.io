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
    public partial class QuanLyNhanVien : Form
    {
        public static string quyen;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            KetQua();
        }
        private string getGioiTinh()
        {
            if (radionam.Checked == true && radionu.Checked == false)
                return "Nam";
            else if (radionam.Checked == false && radionu.Checked == true)
                return "Nữ";
            else
                return "Bê đê";
        }
        public void KetQua()
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select manv as 'Mã nhân viên', tennv as 'Tên nhân viên',ngaysinh as 'Ngày sinh', sodienthoai as 'Số điện thoại', diachi as 'Địa Chỉ', gioitinh as 'Giới Tính' from nhanvien");
            dgvnhanvien.DataSource = ds.Tables[0];
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
            Registration r = new Registration();
            this.Hide();
            r.Show();
        }

        private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatHang dh = new DatHang();
            this.Hide();
            dh.Show();
        }

        private void danhSáchHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon qlhd = new QuanLyHoaDon();
            this.Hide();
            qlhd.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang qlkh = new QuanLyKhachHang();
            this.Hide();
            qlkh.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();
            this.Hide();
            qlnv.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (radionam.Checked == false && radionu.Checked == false)
                MessageBox.Show("bạn chưa chọn giới tính!");
            else
            {
                Connect conn = new Connect();
                string GioiTinh = getGioiTinh();
                bool kiemtra = conn.update("insert into nhanvien values(N'" + txtmanhanvien.Text + "',N'" + txttennhanvien.Text + "',N'" + txtngaysinh.Text + "',N'" + txtsodienthoai.Text + "',N'" + txtdiachi.Text + "',N'" + GioiTinh + "') ");
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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("delete nhanvien where manv = '" + txtmanhanvien.Text + "' ");
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

        private void btnsua_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("UPDATE nhanvien set manv = N'" + txtmanhanvien.Text + "',tennv =N'"+txttennhanvien.Text+ "',ngaysinh =N'" + txtngaysinh.Text + "',sodienthoai =N'" + txtsodienthoai.Text + "',diachi =N'" + txtdiachi.Text + "',gioitinh =N'" + getGioiTinh() + "' where manv = '" + txtmanhanvien.Text + "' ");
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
        private void SetGioitinh(string gioitinh)
        {
            if (gioitinh == "Nam")
            { 
                radionam.Checked = true; radionu.Checked = false; 
            }
            else
            {
                radionam.Checked = true;
                radionu.Checked = false;
            }
        }
        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _row = e.RowIndex;
            txtmanhanvien.Text = dgvnhanvien.Rows[_row].Cells[0].Value.ToString();
            txttennhanvien.Text = dgvnhanvien.Rows[_row].Cells[1].Value.ToString();
            txtngaysinh.Text = dgvnhanvien.Rows[_row].Cells[2].Value.ToString();
            txtsodienthoai.Text = dgvnhanvien.Rows[_row].Cells[3].Value.ToString();
            txtdiachi.Text = dgvnhanvien.Rows[_row].Cells[4].Value.ToString();
            SetGioitinh(dgvnhanvien.Rows[_row].Cells[5].Value.ToString());
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DataSet ds = new DataSet();
            ds = conn.select("select manv as 'Mã nhân viên', tennv as 'Tên nhân viên',ngaysinh as 'Ngày sinh', sodienthoai as 'Số điện thoại', diachi as 'Địa Chỉ', gioitinh as 'Giới Tính' from nhanvien where manv like N'%" + txtmanhanvien.Text + "%' ");
            dgvnhanvien.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            txtngaysinh.Text = "";
            txtsodienthoai.Text = "";
            txtdiachi.Text = "";
            radionam.Checked = false;
            radionu.Checked = false;
            
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            if (quyen == "User")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
            }
            else if (quyen == "KhachHang")
            {
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                btnXoa.Enabled = false;
                btnsua.Enabled = false;
                btnThem.Enabled = false;
            }
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhmucsanpham dam = new danhmucsanpham();
            this.Hide();
            dam.Show();
        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham qlsp = new QuanLySanPham();
            this.Hide();
            qlsp.Show();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select manv as 'Mã nhân viên', tennv as 'Tên nhân viên',ngaysinh as 'Ngày sinh', sodienthoai as 'Số điện thoại', diachi as 'Địa Chỉ', gioitinh as 'Giới Tính' from nhanvien");
            dgvnhanvien.DataSource = ds.Tables[0];
        }
    }
}

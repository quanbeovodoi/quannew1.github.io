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
    public partial class danhmucsanpham : Form
    {
        public static string quyen;
        public danhmucsanpham()
        {
            InitializeComponent();
            KetQua();
        }
        public void KetQua()
        {
            DataSet ds = new DataSet();
            Connect conn = new Connect();
            ds = conn.select("select madanhmucsanpham as 'Mã danh mục sản phẩm', tendanhmucsanpham as 'Tên danh mục sản phẩm' from danhmucsanpham");
            dgvdanhmucsanpham.DataSource = ds.Tables[0];
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmadanhmuc.Text = "";
            txttendanhmuc.Text = "";
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            this.Close();
            home.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("insert into danhmucsanpham values(N'" + txtmadanhmuc.Text + "',N'" + txttendanhmuc.Text + "') ");
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
            bool kiemtra = conn.update("UPDATE danhmucsanpham set tendanhmucsanpham = N'" + txttendanhmuc.Text + "' where madanhmucsanpham = N'" + txtmadanhmuc.Text + "'");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            bool kiemtra = conn.update("delete danhmucsanpham where madanhmucsanpham = N'" + txtmadanhmuc.Text + "'");
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

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DataSet ds = new DataSet();
            ds = conn.select("select madanhmucsanpham as 'Mã danh mục sản phẩm',tendanhmucsanpham as 'Tên danh mục sản phẩm' from danhmucsanpham where madanhmucsanpham like N'%" + txtmadanhmuc.Text + "%' ");
            dgvdanhmucsanpham.DataSource = ds.Tables[0];

        }

        private void dgvdanhmucsanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int _row = e.RowIndex;
            txtmadanhmuc.Text = dgvdanhmucsanpham.Rows[_row].Cells[0].Value.ToString();
            txttendanhmuc.Text = dgvdanhmucsanpham.Rows[_row].Cells[1].Value.ToString();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            KetQua();
        }

        private void danhmucsanpham_Load(object sender, EventArgs e)
        {
            if (quyen == "KhachHang")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
            }
        }
    }
}

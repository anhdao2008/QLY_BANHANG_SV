using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLY_BANHANG_SV.Class;

namespace QLY_BANHANG_SV
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        DataTable tbkhachhang;
        private void KhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridview();
        }
        private void LoadDataGridview()
        {
            string sql;
            sql = "select makhach,tenkhach,gioitinh,diachi,dienthoai from khachhang";
            tbkhachhang = Class.Functions.GetDataToTable(sql); //độc dữ liệu
            dgvKhachHang.DataSource = tbkhachhang;//nguồn dữ liệu
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Giới Tính";
            dgvKhachHang.Columns[3].HeaderText = "Địa CHỉ";
            dgvKhachHang.Columns[4].HeaderText = "Điện Thoại";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 100;
            dgvKhachHang.Columns[3].Width = 150;
            dgvKhachHang.Columns[4].Width = 100;
            dgvKhachHang.AllowUserToAddRows = false; //không cho người dùng thêm dữ liệu trực tiếp.
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically; //không cho người dùng sửa dữ liệu trực tiếp

        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }    
            if(tbkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = dgvKhachHang.CurrentRow.Cells["makhach"].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["tenkhach"].Value.ToString();
            txtGioiTinh.Text = dgvKhachHang.CurrentRow.Cells["gioitinh"].Value.ToString();
            txtDiachi.Text = dgvKhachHang.CurrentRow.Cells["diachi"].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells["dienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            Resetvalue();//xóa các vô hiệu háo của texbox
            txtMaKH.Enabled = true;// cho phép thêm mới
            txtTenKH.Focus();
            txtGioiTinh.Focus();
            txtDiachi.Focus();
            txtDienThoai.Focus();
        }
        private void Resetvalue()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtGioiTinh.Text = "";
            txtDiachi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //lưu trưc sql
            if(txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }    
            if(txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhâp tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }    
            if(txtGioiTinh.Text.Trim().Length ==0)
            {
                MessageBox.Show("Bạn phải nhâp thông tin giới tính.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioiTinh.Focus();
                return;
            }    
            if(txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }    
            if(txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            sql = "SELECT makhach FROM khachhang WHERE makhach='" + txtMaKH.Text.Trim() + "'";
            if(Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại vui lòng nhâp mã khác.", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            sql = "INSERT INTO khachhang(makhach,tenkhach,gioitinh,diachi,dienthoai) VALUES (N'" + txtMaKH.Text.Trim() + "',N'" + txtTenKH.Text.Trim() + "',N'" + txtGioiTinh.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "',N'" + txtDienThoai.Text.Trim() + "')";
            Class.Functions.RunSQL(sql);
            LoadDataGridview();
            Resetvalue();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKH.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn Chưa chọn bản ghi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn tên khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn Điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE khachhang SET makhach=N'" + txtMaKH.Text.ToString() + "',tenkhach=N'" + txtTenKH.Text.ToString() + "',gioitinh=N'" + txtGioiTinh.Text.ToString() + "',diachi=N'" + txtDiachi.Text.ToString() + "',dienthoai=N'" + txtDienThoai.Text.ToString() + "' WHERE makhach=N'"+txtMaKH.Text +"'";
            Class.Functions.RunSQL(sql);
            LoadDataGridview();
            Resetvalue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(MessageBox.Show("Bạn có Muốn xóa", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                sql = "DELETE khachhang WHERE makhach=N'" + txtMaKH.Text + "'";
                Class.Functions.RunSQL(sql);
                LoadDataGridview();
                Resetvalue();
            }    
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormRPKHACHHANG rpkh = new FormRPKHACHHANG();
            rpkh.ShowDialog();
        }
    }
}

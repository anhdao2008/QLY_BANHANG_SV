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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        DataTable tbnhanvien;
        private void NhanVien_Load(object sender, EventArgs e)
        {
            txtmanv.Enabled = false;
            btnLuu.Enabled = false;
            //btnBoQua.Enabled = false;
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT manv,tennv,ngaysinh,dienthoai,diachi,gioitinh,email FROm nhanvien";
            tbnhanvien = Functions.GetDataToTable(sql); //lấy dữ liệu
            dgNhanvien.DataSource = tbnhanvien;
            dgNhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgNhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgNhanvien.Columns[2].HeaderText = "Ngày Sinh";
            dgNhanvien.Columns[3].HeaderText = "Điện Thoại";
            dgNhanvien.Columns[4].HeaderText = "Địa chỉ";
            dgNhanvien.Columns[5].HeaderText = "Giới Tính";
            dgNhanvien.Columns[6].HeaderText = "Email";
            dgNhanvien.Columns[0].Width = 100;
            dgNhanvien.Columns[1].Width = 150;
            dgNhanvien.Columns[2].Width = 100;
            dgNhanvien.Columns[3].Width = 150;
            dgNhanvien.Columns[4].Width = 100;
            dgNhanvien.Columns[5].Width = 100;
            dgNhanvien.Columns[6].Width = 100;
            dgNhanvien.AllowUserToAddRows = false;
            dgNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
                return;
            }
            if (tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanv.Text = dgNhanvien.CurrentRow.Cells["manv"].Value.ToString();
            txttennv.Text = dgNhanvien.CurrentRow.Cells["tennv"].Value.ToString();
            dtpngaysinh.Text = dgNhanvien.CurrentRow.Cells["ngaysinh"].Value.ToString();
            txtdienthoai.Text = dgNhanvien.CurrentRow.Cells["dienthoai"].Value.ToString();
            txtdiachi.Text = dgNhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtgioitinh.Text = dgNhanvien.CurrentRow.Cells["gioitinh"].Value.ToString();
            txtemail.Text = dgNhanvien.CurrentRow.Cells["email"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmanv.Enabled = true;
            txtmanv.Focus();
        }
        private void ResetValues()
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            dtpngaysinh.Text = "";
            txtdienthoai.Text = "";
            txtdiachi.Text = "";
            txtgioitinh.Text = "";
            txtemail.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmanv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanv.Focus();
                return;
            }
            if (txttennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennv.Focus();
                return;
            }
            if (dtpngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpngaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(dtpngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // mskNgaySinh.Text = "";
                dtpngaysinh.Focus();
                return;
            }
            if (txtdienthoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtgioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgioitinh.Focus();
                return;
            }
            if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }
            sql = "SELECT manv FROM nhanvien WHERE manv=N'" + txtmanv.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanv.Focus();
                txtmanv.Text = "";
                return;
            }
            sql = "INSERT INTO nhanvien(manv,tennv,ngaysinh, dienthoai,diachi, gioitinh,email) VALUES (N'" + txtmanv.Text.Trim() + "',N'" + txttennv.Text.Trim() + "', '" + Functions.ConvertDateTime(dtpngaysinh.Text) + "',N'" + txtdienthoai.Text.Trim() + "',N'" + txtdiachi.Text + "', N'" + txtgioitinh.Text.Trim() + "',N'"+txtemail.Text.Trim()+"')";
            //
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            //btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtmanv.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennv.Focus();
                return;
            }
            if (dtpngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpngaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(dtpngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // mskNgaySinh.Text = "";
                dtpngaysinh.Focus();
                return;
            }
            if (txtdienthoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtgioitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgioitinh.Focus();
                return;
            }
            if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            
            sql = "UPDATE nhanvien SET  tennv=N'" + txttennv.Text.Trim().ToString() +
                    "',ngaysinh='" + Functions.ConvertDateTime(dtpngaysinh.Text) +
                    "',dienthoai =N'"+txtdienthoai.Text.Trim().ToString()+"',diachi=N'"+txtdiachi.Text.Trim().ToString()+"',gioitinh=N'"+txtgioitinh.Text.Trim().ToString()+"',email=N'"+txtemail.Text.Trim().ToString()+"' WHERE manv=N'" + txtmanv.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            //btnBoQua.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE nhanvien WHERE manv=N'" + txtmanv.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormRPNhanVien rpnv = new FormRPNhanVien();
            rpnv.ShowDialog();
        }
    }
}

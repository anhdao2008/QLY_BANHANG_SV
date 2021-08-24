using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QLY_BANHANG_SV.Class;

namespace QLY_BANHANG_SV
{
    public partial class NguoiDung : Form
    {
        public NguoiDung()
        {
            InitializeComponent();
        }

        DataTable tbnguoidung;
        private void NguoiDung_Load(object sender, EventArgs e)
        {
            txtMaND.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "select mand, manv, taikhoan, matkhau from nguoidung";
            tbnguoidung = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridViewNguoiDung.DataSource = tbnguoidung; //Nguồn dữ liệu            
            dataGridViewNguoiDung.Columns[0].HeaderText = "Mã ND";
            dataGridViewNguoiDung.Columns[1].HeaderText = "Mã NV";
            dataGridViewNguoiDung.Columns[2].HeaderText = "Tài Khoản";
            dataGridViewNguoiDung.Columns[3].HeaderText = "Mật Khẩu";
            dataGridViewNguoiDung.Columns[0].Width = 100;
            dataGridViewNguoiDung.Columns[1].Width = 100;
            dataGridViewNguoiDung.Columns[2].Width = 300;
            dataGridViewNguoiDung.Columns[3].Width = 300;
            dataGridViewNguoiDung.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dataGridViewNguoiDung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dataGridViewNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaND.Focus();
                return;
            }
            if (tbnguoidung.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaND.Text = dataGridViewNguoiDung.CurrentRow.Cells["mand"].Value.ToString();
            txtMaNV.Text = dataGridViewNguoiDung.CurrentRow.Cells["manv"].Value.ToString();
            txttaikhoan.Text = dataGridViewNguoiDung.CurrentRow.Cells["taikhoan"].Value.ToString();
            txtMatkhau.Text = dataGridViewNguoiDung.CurrentRow.Cells["matkhau"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            //btnHuy.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaND.Enabled = true; //cho phép nhập mới
            txtMaNV.Focus();
            txttaikhoan.Focus();
            txtMatkhau.Focus();
        }
        private void ResetValue()
        {
            txtMaND.Text = "";
            txtMaNV.Text = "";
            txttaikhoan.Text = "";
            txtMatkhau.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaND.Text.Trim().Length == 0) //Nếu chưa nhập ma nguoif dùng
            {
                MessageBox.Show("Bạn phải nhập mã người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaND.Focus();
                return;
            }
            if (txtMaNV.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txttaikhoan.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttaikhoan.Focus();
                return;
            }
            if (txtMatkhau.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatkhau.Focus();
                return;
            }
            sql = "SELECT mand FROM nguoidung WHERE mand='" + txtMaND.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaND.Focus();
                return;
            }

            sql = "INSERT INTO nguoidung(mand, manv, taikhoan, matkhau) VALUES(N'" +
                txtMaND.Text.Trim() + "',N'" + txtMatkhau.Text.Trim() + "',N'" + txttaikhoan.Text.Trim() + "',N'" +txtMatkhau.Text.Trim()+"')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            //btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaND.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tbnguoidung.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaND.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập ma nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttaikhoan.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatkhau.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE nguoidung SET manv=N'" +
                txtMaNV.Text.ToString() + "', taikhoan = '"+txttaikhoan.Text.ToString() +"',matkhau='"+ txtMatkhau.Text.ToString()+"' WHERE mand=N'" + txtMaND.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            //btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbnguoidung.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaND.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE nguoidung WHERE mand=N'" + txtMaND.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //them người dùng
        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormRPNguoiDung frpnd = new FormRPNguoiDung();
            frpnd.Show();
        }
    }
}

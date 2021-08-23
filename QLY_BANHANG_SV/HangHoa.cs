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
    public partial class HangHoa : Form
    {
        public HangHoa()
        {
            InitializeComponent();
        }
        DataTable tbhanghoa; //Bảng hàng
        private void HangHoa_Load(object sender, EventArgs e)
        {
            txtMahh.Enabled = false;
            btnLuu.Enabled = false;
            //btnBoQua.Enabled = false;
            LoadDataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMahh.Text = "";
            txtTenhh.Text = "";
            txtGiaban.Text = "0";
            txtDonvitinh.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT mahh,tenhh,giaban,donvitinh,soluong from hanghoa";
            tbhanghoa = Functions.GetDataToTable(sql);
            dgvHangHoa.DataSource = tbhanghoa;
            dgvHangHoa.Columns[0].HeaderText = "Mã hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên hàng";
            dgvHangHoa.Columns[2].HeaderText = "Giá bán";
            dgvHangHoa.Columns[3].HeaderText = "Đơn Vị Tính";
            dgvHangHoa.Columns[4].HeaderText = "Số Luọng";
            dgvHangHoa.Columns[0].Width = 80;
            dgvHangHoa.Columns[1].Width = 140;
            dgvHangHoa.Columns[2].Width = 80;
            dgvHangHoa.Columns[3].Width = 80;
            dgvHangHoa.Columns[4].Width = 80;
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahh.Focus();
                return;
            }
            if (tbhanghoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMahh.Text = dgvHangHoa.CurrentRow.Cells["mahh"].Value.ToString();
            txtTenhh.Text = dgvHangHoa.CurrentRow.Cells["tenhh"].Value.ToString();
            txtGiaban.Text = dgvHangHoa.CurrentRow.Cells["giaban"].Value.ToString();
            txtDonvitinh.Text = dgvHangHoa.CurrentRow.Cells["donvitinh"].Value.ToString();
            txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["soluong"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            //btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMahh.Enabled = true;
            txtTenhh.Focus();
            txtGiaban.Focus();
            txtDonvitinh.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahh.Focus();
                return;
            }
            if (txtTenhh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhh.Focus();
                return;
            }
            sql = "SELECT mahh FROM hanghoa WHERE mahh=N'" + txtMahh.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahh.Focus();
                return;
            }
            sql = "INSERT INTO hanghoa(mahh,tenhh,giaban,donvitinh,soluong) VALUES(N'" + txtMahh.Text.Trim() + "',N'" + txtTenhh.Text.Trim() +"',N'"+txtGiaban.Text.Trim()+"', N'"+txtDonvitinh.Text.Trim()+"',N'"+txtSoLuong.Text.Trim()+"')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            //btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahh.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbhanghoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenhh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE hanghoa SET tenhh=N'" + txtTenhh.Text.Trim().ToString() +
                "',giaban=N'"+txtGiaban.Text.Trim()+"',donvitinh=N'"+txtDonvitinh.Text.Trim()+ "',soluong=N'" + txtSoLuong.Text.Trim() + "' WHERE mahh=N'" + txtMahh.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            //btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbhanghoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE hanghoa WHERE mahh=N'" + txtMahh.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormRPHangHoa rphh = new FormRPHangHoa();
            rphh.ShowDialog();
        }
    }
}

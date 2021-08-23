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
    public partial class TKHOADON : Form
    {
        public TKHOADON()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        DataTable tblHoaDonBan;
        private void TKHOADON_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiem.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtManv.Text == "") && (txtMakh.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM hoadon WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND mahd Like N'%" + txtMaHDBan.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(ngayban) =" + txtNam.Text;
            if (txtManv.Text != "")
                sql = sql + " AND manv Like N'%" + txtManv.Text + "%'";
            if (txtMakh.Text != "")
                sql = sql + " AND makhach Like N'%" + txtMakh.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND tongtien <=" + txtTongTien.Text;
            tblHoaDonBan = Functions.GetDataToTable(sql);
            if (tblHoaDonBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHoaDonBan.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTimKiem.DataSource = tblHoaDonBan;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTimKiem.Columns[0].HeaderText = "Mã HĐB";
            dgvTimKiem.Columns[1].HeaderText = "Mã nhân viên";
            dgvTimKiem.Columns[2].HeaderText = "Ngày bán";
            dgvTimKiem.Columns[3].HeaderText = "Mã khách";
            dgvTimKiem.Columns[4].HeaderText = "Tổng tiền";
            dgvTimKiem.Columns[0].Width = 150;
            dgvTimKiem.Columns[1].Width = 100;
            dgvTimKiem.Columns[2].Width = 80;
            dgvTimKiem.Columns[3].Width = 80;
            dgvTimKiem.Columns[4].Width = 80;
            dgvTimKiem.AllowUserToAddRows = false;
            dgvTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void bttimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiem.DataSource = null;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTimKiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvTimKiem.CurrentRow.Cells["mahd"].Value.ToString();
                HoaDon hd = new HoaDon();
                //hd.txtMaHDBan.Text=mahd;
                hd.StartPosition = FormStartPosition.CenterParent;
                hd.ShowDialog();
            }
        }
    }
}

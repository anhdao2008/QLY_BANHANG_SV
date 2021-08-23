using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLY_BANHANG_SV
{
    public partial class FormRPNguoiDung : Form
    {
        public FormRPNguoiDung()
        {
            InitializeComponent();
        }

        private void FormRPNguoiDung_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLY_BanHangDataSet.nguoidung' table. You can move, or remove it, as needed.
            this.nguoidungTableAdapter.Fill(this.QLY_BanHangDataSet.nguoidung);

            this.reportViewer1.RefreshReport();
        }
    }
}

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
    public partial class FormRPHoaDon : Form
    {
        public FormRPHoaDon()
        {
            InitializeComponent();
        }

        private void FormRPHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLY_BanHangDataSet1.hoadon' table. You can move, or remove it, as needed.
            this.hoadonTableAdapter.Fill(this.QLY_BanHangDataSet1.hoadon);

            this.reportViewer1.RefreshReport();
        }
    }
}

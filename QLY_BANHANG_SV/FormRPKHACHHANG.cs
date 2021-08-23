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
    public partial class FormRPKHACHHANG : Form
    {
        public FormRPKHACHHANG()
        {
            InitializeComponent();
        }

        private void FormRPKHACHHANG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLY_BanHangDataSet1.khachhang' table. You can move, or remove it, as needed.
            this.khachhangTableAdapter.Fill(this.QLY_BanHangDataSet1.khachhang);

            this.reportViewer1.RefreshReport();
        }
    }
}

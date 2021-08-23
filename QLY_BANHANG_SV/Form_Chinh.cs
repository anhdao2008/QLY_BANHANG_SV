using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLY_BANHANG_SV
{
    public partial class Form_Chinh : Form
    {
        public Form_Chinh()
        {
            InitializeComponent();
        }

        private void Form_Chinh_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect(); //Mở kết nối
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NguoiDung nd = new NguoiDung();
            nd.MdiParent = this;
            nd.Show();
        }

        private void tsnhanvien_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MdiParent = this;
            nv.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HangHoa hh = new HangHoa();
            hh.MdiParent = this;
            hh.Show();
        }

        private void tskhachhang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.MdiParent = this;
            hd.Show();
        }

        private void tìmKiếmHáoĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TKHOADON tkh = new TKHOADON();
            tkh.MdiParent = this;
            tkh.Show();
        }
    }
}

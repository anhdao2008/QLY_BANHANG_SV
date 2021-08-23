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
using System.Security.Cryptography;

namespace QLY_BANHANG_SV
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BPN90P8;Initial Catalog=QLY_BanHang;Persist Security Info=True;User ID=sa; Password = 05112002@VANG");
        private void NguoiDung_Load(object sender, EventArgs e)
        {
            
        }

        private void Btdangnhap_Click(object sender, EventArgs e)
        {
            
            taikhoan = getID();
            if (taikhoan != "")
            {
                Form_Chinh fchinh = new Form_Chinh();
                fchinh.Show();
                //fchinh.Hide();Ư
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
        private string getID()
        {
            
            string id = "";
            try
            {
                conn.Open();
                SqlCommand cmm = new SqlCommand("SELECT * FROM nguoidung WHERE taikhoan = '" + txttendangnhap.Text + "' AND matkhau = '" + txtmatkhau.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["manv"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lỗi");
            }
            finally
            {
                conn.Close();
            }
            return id;
        }
        public static string taikhoan = "";

        private void btthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {
            //byte[] temp = ASCIIEncoding.ASCII.GetBytes(getID());
            
        }
    }
}

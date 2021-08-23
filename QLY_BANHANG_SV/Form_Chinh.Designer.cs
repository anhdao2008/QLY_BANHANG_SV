
namespace QLY_BANHANG_SV
{
    partial class Form_Chinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.hóaĐơnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmHáoĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tskhachhang = new System.Windows.Forms.ToolStripButton();
            this.tsnhanvien = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLY_BANHANG_SV.Properties.Resources.icon8;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ BÁN HÀNG";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 21);
            this.panel2.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSplitButton2,
            this.tskhachhang,
            this.tsnhanvien});
            this.toolStrip1.Location = new System.Drawing.Point(0, 80);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(905, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::QLY_BANHANG_SV.Properties.Resources.icon1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(143, 32);
            this.toolStripButton1.Text = "Người dùng";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::QLY_BANHANG_SV.Properties.Resources.icon12;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(143, 36);
            this.toolStripButton2.Text = "Hàng hóa";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnToolStripMenuItem1,
            this.tìmKiếmHáoĐơnToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::QLY_BANHANG_SV.Properties.Resources.icon3;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(149, 36);
            this.toolStripSplitButton2.Text = "Hóa Đơn";
            // 
            // hóaĐơnToolStripMenuItem1
            // 
            this.hóaĐơnToolStripMenuItem1.Image = global::QLY_BANHANG_SV.Properties.Resources.icon6;
            this.hóaĐơnToolStripMenuItem1.Name = "hóaĐơnToolStripMenuItem1";
            this.hóaĐơnToolStripMenuItem1.Size = new System.Drawing.Size(299, 36);
            this.hóaĐơnToolStripMenuItem1.Text = "Hóa Đơn";
            this.hóaĐơnToolStripMenuItem1.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem1_Click);
            // 
            // tìmKiếmHáoĐơnToolStripMenuItem
            // 
            this.tìmKiếmHáoĐơnToolStripMenuItem.Image = global::QLY_BANHANG_SV.Properties.Resources.icon4;
            this.tìmKiếmHáoĐơnToolStripMenuItem.Name = "tìmKiếmHáoĐơnToolStripMenuItem";
            this.tìmKiếmHáoĐơnToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.tìmKiếmHáoĐơnToolStripMenuItem.Text = "Tìm kiếm háo đơn";
            this.tìmKiếmHáoĐơnToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmHáoĐơnToolStripMenuItem_Click);
            // 
            // tskhachhang
            // 
            this.tskhachhang.Image = global::QLY_BANHANG_SV.Properties.Resources.customer;
            this.tskhachhang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tskhachhang.Name = "tskhachhang";
            this.tskhachhang.Size = new System.Drawing.Size(168, 36);
            this.tskhachhang.Text = "Khách Hàng";
            this.tskhachhang.Click += new System.EventHandler(this.tskhachhang_Click);
            // 
            // tsnhanvien
            // 
            this.tsnhanvien.Image = global::QLY_BANHANG_SV.Properties.Resources.icon5;
            this.tsnhanvien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsnhanvien.Name = "tsnhanvien";
            this.tsnhanvien.Size = new System.Drawing.Size(152, 36);
            this.tsnhanvien.Text = "Nhân Viên";
            this.tsnhanvien.Click += new System.EventHandler(this.tsnhanvien_Click);
            // 
            // Form_Chinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "Form_Chinh";
            this.Text = "Form_Chủ";
            this.Load += new System.EventHandler(this.Form_Chinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmHáoĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tskhachhang;
        private System.Windows.Forms.ToolStripButton tsnhanvien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}


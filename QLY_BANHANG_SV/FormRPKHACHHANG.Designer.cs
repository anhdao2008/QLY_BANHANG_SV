
namespace QLY_BANHANG_SV
{
    partial class FormRPKHACHHANG
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLY_BanHangDataSet1 = new QLY_BANHANG_SV.QLY_BanHangDataSet1();
            this.khachhangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachhangTableAdapter = new QLY_BANHANG_SV.QLY_BanHangDataSet1TableAdapters.khachhangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLY_BanHangDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachhangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.khachhangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLY_BANHANG_SV.RPKhachHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLY_BanHangDataSet1
            // 
            this.QLY_BanHangDataSet1.DataSetName = "QLY_BanHangDataSet1";
            this.QLY_BanHangDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khachhangBindingSource
            // 
            this.khachhangBindingSource.DataMember = "khachhang";
            this.khachhangBindingSource.DataSource = this.QLY_BanHangDataSet1;
            // 
            // khachhangTableAdapter
            // 
            this.khachhangTableAdapter.ClearBeforeFill = true;
            // 
            // FormRPKHACHHANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormRPKHACHHANG";
            this.Text = "FormRPKHACHHANG";
            this.Load += new System.EventHandler(this.FormRPKHACHHANG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLY_BanHangDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachhangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource khachhangBindingSource;
        private QLY_BanHangDataSet1 QLY_BanHangDataSet1;
        private QLY_BanHangDataSet1TableAdapters.khachhangTableAdapter khachhangTableAdapter;
    }
}
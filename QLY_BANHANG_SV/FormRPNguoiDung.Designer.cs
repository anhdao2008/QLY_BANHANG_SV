
namespace QLY_BANHANG_SV
{
    partial class FormRPNguoiDung
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
            this.QLY_BanHangDataSet = new QLY_BANHANG_SV.QLY_BanHangDataSet();
            this.nguoidungBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nguoidungTableAdapter = new QLY_BANHANG_SV.QLY_BanHangDataSetTableAdapters.nguoidungTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLY_BanHangDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoidungBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.nguoidungBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLY_BANHANG_SV.ReportNGUOIDUNG.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLY_BanHangDataSet
            // 
            this.QLY_BanHangDataSet.DataSetName = "QLY_BanHangDataSet";
            this.QLY_BanHangDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nguoidungBindingSource
            // 
            this.nguoidungBindingSource.DataMember = "nguoidung";
            this.nguoidungBindingSource.DataSource = this.QLY_BanHangDataSet;
            // 
            // nguoidungTableAdapter
            // 
            this.nguoidungTableAdapter.ClearBeforeFill = true;
            // 
            // FormRPNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormRPNguoiDung";
            this.Text = "FormRPNguoiDung";
            this.Load += new System.EventHandler(this.FormRPNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLY_BanHangDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoidungBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource nguoidungBindingSource;
        private QLY_BanHangDataSet QLY_BanHangDataSet;
        private QLY_BanHangDataSetTableAdapters.nguoidungTableAdapter nguoidungTableAdapter;
    }
}
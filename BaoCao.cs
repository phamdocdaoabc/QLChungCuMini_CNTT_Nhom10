using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace QLChungCuMini
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }
        public DataSet ReportDataSet { get; set; }
        private void BaoCao_Load(object sender, EventArgs e)
        {
            if (ReportDataSet != null && ReportDataSet.Tables.Count > 0 && ReportDataSet.Tables[0].Rows.Count > 0)
            {
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = "Report1.rdlc";

                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ReportDataSet.Tables[0];
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

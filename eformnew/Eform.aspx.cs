using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;


namespace eformnew
{
    public partial class Eform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EFORMConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from DataTable1 where ID = '" + Convert.ToInt32(TextBox1.Text) + "'", con);

            DataTable dt = new DataTable(" Table1 ");
            da.Fill(dt);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ReportViewer1.LocalReport.Refresh(); 


        }
        
        
          
    }
}
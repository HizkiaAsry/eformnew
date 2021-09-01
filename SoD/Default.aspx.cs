using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fileExtension = "";

        Document document = new Document();
        document.LoadFromFile(Server.MapPath("~/document/SoD.docx"));
     

        //Get From DB
        /**DataTable dt = getData(TextBox1.Text);
        if (dt.Rows.Count > 0)
        {
            document.Replace("[NO_PERMIT]", dt.Rows[0]["NO_PERMIT"].ToString(), true, true);
            document.Replace("[LOKASI]", dt.Rows[0]["LOKASI_PEKERJAAN"].ToString(), true, true);
        }
        **/
        document.Replace("[EQUIP_NO]","IS/PH177", true, true);
        document.Replace("[EQUIP_DESC1]", "Samsung", true, true);
        document.Replace("[EQUIP_DESC2]", "Mobile Phone", true, true);


        string loc = Server.MapPath("~/document/hasil/SoD_" + TextBox1.Text + ".pdf");

        document.SaveToFile(loc, Spire.Doc.FileFormat.PDF);

        string filePath = Server.MapPath("~/document/hasil/SoD_" + TextBox1.Text + ".pdf");
        fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
        if (fileExtension == ".pdf")
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
    }

    public string koneksi()
    {
        return ConfigurationManager.ConnectionStrings["EFORMConnectionString"].ConnectionString;
    }


    protected DataTable getData(string id)
    {
        SqlConnection sqlConn = new SqlConnection(koneksi());
        SqlCommand sqlCmd = new SqlCommand(" select * from [tabel] where id = '"+id+"'", sqlConn);
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        DataTable dt = new DataTable();
        sqlDA.SelectCommand = sqlCmd;
        sqlDA.Fill(dt);
        return dt;
    }
}
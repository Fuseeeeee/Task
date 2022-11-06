using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    public partial class profileview : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-OOFAQU9\SQLEXPRESS;database=proj;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bind_gird();
            }
        }
        public void bind_gird()
        {
            string s = "select * from project_tab";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int uid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from project_tab where id=" + uid + "";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bind_gird();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind_gird();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int uid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtusername = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtemail_id = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtphn_no = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            TextBox txtcountry = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            string strup = "update project_tab set username='" + txtusername.Text + "', [email-id]='" + txtemail_id.Text + "',[phone number]='" + txtphn_no.Text + "',country='" + txtcountry.Text + "' where id=" + uid + "";
            SqlCommand cmd = new SqlCommand(strup, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            bind_gird();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}
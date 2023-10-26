using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.Services.Description;
using System.Data.Common;

namespace ADO.NET_Lecture_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        int display = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["counter"] = 0;
            }
            con = new SqlConnection("Data Source = DESKTOP-VMI00U7\\SQLEXPRESS; Initial Catalog = iiht; Integrated Security = True");
            con.Open();
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                cmd = new SqlCommand("pinsertdata", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid", TextBox1.Text);
                cmd.Parameters.AddWithValue("@prname", TextBox2.Text);
                cmd.Parameters.AddWithValue("@pprice", TextBox3.Text);
                cmd.ExecuteNonQuery();
              
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("pupdatedata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", TextBox1.Text);
            cmd.Parameters.AddWithValue("@proname", TextBox2.Text);
            cmd.Parameters.AddWithValue("@proprice", TextBox3.Text);
            cmd.ExecuteNonQuery();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("pdeletedata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", TextBox1.Text);
            cmd.ExecuteNonQuery();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(ViewState["counter"]) == 0)

            {
                GridView1.Visible = true;
                SqlCommand cmd = new SqlCommand("pviewdata", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ViewState["counter"] = Convert.ToInt32(ViewState["counter"]) + 1;
            }
            else 
            {
                GridView1.Visible = false;
                display = 0;

            }
            
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("psearchbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", TextBox1.Text);

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();

                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
             //   da.Fill(dt);
               

            }
        }
    }
}

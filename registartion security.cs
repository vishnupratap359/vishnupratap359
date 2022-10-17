using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Reg : System.Web.UI.Page
{
    Master ob = new Master();
    string Str, n, k, k1, k2; string sql;
    int g;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        ob.constr();
        try
        {

            if (ob.searchrec("Select userid from Registration where userid='" + userid.Text + "'"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User Id Already exists Please Try Another user')", true);
            }
            else
            {

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Max(SrNo) from AddDSR", ob.con1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (da.Fill(ds) > 0)
                    { Str = ds.Tables[0].Rows[0][0].ToString(); }
                    g = int.Parse(Str) + 1;
                    n = g.ToString();
                }
                catch (Exception)
                {
                    g = 1; n = g.ToString();
                }


                SqlCommand cmd = new SqlCommand("spInsertreg", ob.con1);

                cmd.Parameters.Add(new SqlParameter("@Name", name.Text));
                cmd.Parameters.Add(new SqlParameter("@Fname", fname.Text));
                cmd.Parameters.Add(new SqlParameter("@DOB", DOB.Text));
                cmd.Parameters.Add(new SqlParameter("@Mobile", Mobile.Text));


                cmd.Parameters.Add(new SqlParameter("@adhar", adhar.Text));
                cmd.Parameters.Add(new SqlParameter("@userid", userid.Text));
                cmd.Parameters.Add(new SqlParameter("@Password", password.Text));
                cmd.Parameters.Add(new SqlParameter("@Email", Email.Text));
                cmd.Parameters.Add(new SqlParameter("@Gender", gender.Text));
                if (pic.HasFile)
                {
                    string zz = pic.FileName;
                    k1 = n + zz;
                    pic.SaveAs(Server.MapPath("/Upload/" + k1.ToString()));

                    cmd.Parameters.Add(new SqlParameter("@img", SqlDbType.NVarChar, -1)).Value = "/upload/" + k1.ToString();
                    //cmd.Parameters.Add(new SqlParameter("@Img", SqlDbType.NVarChar, -1)).Value = k1.ToString();

                }


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' your registration has been successfull')", true);


                name.Text = "";
                fname.Text = "";
                DOB.Text = "";

                Mobile.Text = "";
                adhar.Text = "";
                password.Text = "";
                Email.Text = "";
                gender.Text = "select";

                ob.con1.Close();

            }


        }
        catch (Exception ex)
        {
            Response.Redirect("~/user/userdasboard.aspx");
        }

    }
}


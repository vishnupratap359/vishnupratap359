using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class customer_cartItems : System.Web.UI.Page
{
    Master ob = new Master();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        try
        {
            ob.constr();
            DataTable table = new DataTable();
            String sql = "Select * from Cart where userMobile='" + Session["Phone"] + "'";
            SqlCommand cmd = new SqlCommand(sql, ob.con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            DtlEvents.DataSource = table;
            DtlEvents.DataBind();

        }
        catch (Exception ex)
        {
            //err.Text = ex.Message;
        }
        ob.con1.Close();
    }


    protected void DtlEvents_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        ob.constr();

        int id = (int)DtlEvents.DataKeys[(int)e.Item.ItemIndex];

        Label quan1 = (Label)e.Item.FindControl("quan");

        int quan = Convert.ToInt16(quan1.Text);

        int quantity = quan + 1;

        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "Update cart set productQuantity='" + quantity + "' where id=" + id + " and userMobile='" + Session["Phone"] + "'";
        cmd.Connection = ob.con1;
        cmd.ExecuteNonQuery();

        DtlEvents.EditItemIndex = -1;
        ob.con1.Close();
        BindData();
    }

    protected void DtlEvents_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        ob.constr();

        int id = (int)DtlEvents.DataKeys[(int)e.Item.ItemIndex];

        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "delete from cart where id=" + id + " and userMobile='" + Session["Phone"] + "'";
        cmd.Connection = ob.con1;
        cmd.ExecuteNonQuery();

        DtlEvents.EditItemIndex = -1;
        ob.con1.Close();
        BindData();
    }

    protected void DtlEvents_CancelCommand(object source, DataListCommandEventArgs e)
    {
        ob.constr();

        int id = (int)DtlEvents.DataKeys[(int)e.Item.ItemIndex];

        Label quan1 = (Label)e.Item.FindControl("quan");

        int quan = Convert.ToInt16(quan1.Text);

        int quantity = quan - 1;

        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "Update cart set productQuantity='" + quantity + "' where id=" + id + " and userMobile='" + Session["Phone"] + "'";
        cmd.Connection = ob.con1;
        cmd.ExecuteNonQuery();

        DtlEvents.EditItemIndex = -1;
        ob.con1.Close();
        BindData();
    }
}

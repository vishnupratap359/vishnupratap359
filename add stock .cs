using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class StockM_AddStock : System.Web.UI.Page
{
    Master ob = new Master();
    SqlDataAdapter da;
    DataSet ds;
    int g;
    String n, Str, k, ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //BindData();
                RecNo();
                CustomerId();
                Product();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Qty"), new DataColumn("Item"), new DataColumn("Amount"),new DataColumn("Price")});
                ViewState["Product"] = dt;
                this.BindGrid();
            }
            catch { }
        }
    }
    public void Product()
    {
        ob.constr();
        da = new SqlDataAdapter("select distinct(Item_name) from Itme_Master order by Item_name", ob.con1);
        ds = new DataSet();
        item.Items.Clear();
        item.Items.Add("Select");
        if (da.Fill(ds) > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                item.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
        ob.con1.Close();
    }
    protected void CustomerId()
    {
        ob.constr();
        string sqlText = "SELECT Max(cast (Customer_id as int)) FROM Customers";
        SqlCommand command = new SqlCommand(sqlText, ob.con1);
        try
        {
            string pcount = Convert.ToString(command.ExecuteScalar());
            if (pcount.Length == 0)
            {
               // recno.InnerText = "1001";
                cust.Text = "1001";
            }
            else
            {
                int pcount1 = Convert.ToInt32(pcount);
                int pcountAdd = pcount1 + 1;
                cust.Text = pcountAdd.ToString();
                //cust.Text = recno.InnerText;
            }
        }
        catch (Exception) { }
        ob.con1.Close();
    }


    protected void RecNo()
    {
        ob.constr();
        string sqlText = "SELECT Max(cast (order_number as int)) FROM Service";
        SqlCommand command = new SqlCommand(sqlText, ob.con1);
        try
        {
            string pcount = Convert.ToString(command.ExecuteScalar());
            if (pcount.Length == 0)
            {
                 recno.InnerText = "10001";
                //cust.Text = "1001";
            }
            else
            {
                int pcount1 = Convert.ToInt32(pcount);
                int pcountAdd = pcount1 + 1;
                recno.InnerText = pcountAdd.ToString();
               // cust.Text = recno.InnerText;
            }
        }
        catch (Exception) { }
        ob.con1.Close();
    }
    protected void BindGrid()
    {
        grd1.DataSource = (DataTable)ViewState["Product"];
        grd1.DataBind();
    }
    //private void BindData()
    //{
    //    ob.constr();
    //    DataSet table = new DataSet();
    //    string sql = @"select sr_no as [srno],MID as [MID],name as [PName],Firm as [Firm],
    //    status as [Status] from MesserMaster order by sr_no";
    //    SqlCommand cmd = new SqlCommand(sql, ob.con1);
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(table);
    //    GridView1.DataSource = table;
    //    GridView1.DataBind();
    //    ob.con1.Close();
    //}

    //protected void binddate()
    //{
    //    ob.constr();
    //    String str1 = "select * from Customer";
    //    SqlCommand cmd1 = new SqlCommand(str1, ob.con1);
    //    SqlDataReader dr1 = cmd1.ExecuteReader();
    //    dr1.Read();


    //    name.Text = dr1["name"].ToString();
    //    job.Text = dr1["job_role"].ToString();
    //    descritpion.Text = dr1["description"].ToString();
    //    desgination.Text = dr1["Desgination"].ToString();
    //    Email.Text = dr1["Email"].ToString();
    //    Mobile.Text = dr1["Mobile"].ToString();
    //    Address.Text = dr1["Address"].ToString();
    //    //person.InnerText = dr1["name"].ToString();
    //    //acc.InnerText = dr1["account_number"].ToString();
    //    ob.con1.Close();
    //}

    //protected void OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    mid.Text = ""; firm.Text = ""; salt.Text = "";
    //    billto.Text = "RAVA"; cat.Text = "Type"; product.Text = "Category"; subcat.Text = "Product Name"; qty.Text = ""; mrp.Text = "";
    //    price.Text = ""; tamt.Text = ""; expdt.Text = ""; t_amt.Text = "0"; gst5.Text = "0"; gst12.Text = "0"; gst18.Text = "0";
    //    gst28.Text = "0"; tdis.Text = "0"; tgst.Text = "0"; g_tamt.Text = "0"; invoiceno.Text = ""; t_paid.Text = "0"; bal.Text = "0";
    //    RecNo();
    //    String lblmid = (GridView1.SelectedRow.FindControl("lblmid") as Label).Text;
    //    ob.constr();
    //    String str = ("select * from MesserMaster where mid='" + lblmid + "' order by sr_no desc");
    //    SqlCommand cmd1 = new SqlCommand(str, ob.con1);
    //    SqlDataReader dtr = cmd1.ExecuteReader();
    //    dtr.Read();
    //    firm.Text = dtr["firm"].ToString();
    //    mid.Text = dtr["mid"].ToString();
    //    ob.con1.Close();
    //}
    //protected void price_TextChanged(object sender, EventArgs e)
    //{
    //    if (price.Text == "") { price.Text = "0"; }
    //    if (qty.Text == "") { qty.Text = "0"; }
    //    tamt.Text = Convert.ToString((Convert.ToDouble(qty.Text) * Convert.ToDouble(price.Text)).ToString("0.00"));
    //    qty.Focus();
    //}
    //protected void qty_TextChanged(object sender, EventArgs e)
    //{
    //    if (qty.Text == "") { qty.Text = "0"; }
    //    tamt.Text = Convert.ToString((Convert.ToDouble(qty.Text) * Convert.ToDouble(price.Text)).ToString("0.00"));
    //    discount.Focus();
    //}
    protected void add_Click(object sender, EventArgs e)
    {
        //try
        //{
            
        DataTable dt = (DataTable)ViewState["Product"];
        dt.Rows.Add(Quty.Text.Trim(), item.Text.Trim(), price.Text.Trim(),rate.Text.Trim());
        ViewState["Product"] = dt;
        this.BindGrid();
            Quty.Text = ""; Quty.Text = ""; price.Text = ""; rate.Text = "";
        Product();
        Double GTotal = 0;
        for (int i = 0; i < grd1.Rows.Count; i++)
        {
            Label lblamt = grd1.Rows[i].FindControl("tamt") as Label;
            GTotal += Convert.ToDouble(lblamt.Text);
            t_amt.Text = Convert.ToString(GTotal);

        }
        p1.Visible = true;
        //}
        //catch { Response.Redirect("~/index.aspx"); }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["Product"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["Product"] = dt;
        BindGrid();
        Double GTotal = 0;
        for (int i = 0; i < grd1.Rows.Count; i++)
        {
            Label lblamt = grd1.Rows[i].FindControl("tamt") as Label;
            GTotal += Convert.ToDouble(lblamt.Text);
            t_amt.Text = Convert.ToString(GTotal);

        }

    }
    //protected void t_paid_TextChanged(object sender, EventArgs e)
    //{
    //    if (t_paid.Text == "")
    //    {
    //        t_paid.Text = "0";
    //    }
    //    bal.Text = (Convert.ToDouble(g_tamt.Text) - Convert.ToDouble(t_paid.Text)).ToString("0.00");
    //}
    //protected void cat_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ob.constr();
    //    da = new SqlDataAdapter("select Product from ProductMaster where cat='" + cat.Text + "' order by Product", ob.con1);
    //    ds = new DataSet();
    //    product.Items.Clear();
    //    product.Items.Add("Category");
    //    subcat.Items.Clear();
    //    subcat.Items.Add("Product Name");
    //    salt.Text = "";
    //    if (da.Fill(ds) > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            product.Items.Add(ds.Tables[0].Rows[i]["Product"].ToString());
    //        }
    //    }
    //    ob.con1.Close();
    //}
    //protected void product_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ob.constr();
    //    salt.Text = "";
    //    da = new SqlDataAdapter("select Details from ProDetails where cat='" + cat.Text + "' and product='"+ product.Text +"' order by Details", ob.con1);
    //    ds = new DataSet();
    //    subcat.Items.Clear();
    //    subcat.Items.Add("Product Name");
    //    if (da.Fill(ds) > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            subcat.Items.Add(ds.Tables[0].Rows[i]["Details"].ToString());
    //        }
    //    }
    //    ob.con1.Close();
    //}
    //protected void subcat_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ob.constr();
    //    salt.Text = "";
    //    if (ob.searchrec("select * from ProDetails where cat='" + cat.Text + "' and product='" + product.Text + "' and details='" + subcat.Text + "'"))
    //    {
    //        String str = ("select * from ProDetails where cat='" + cat.Text + "' and product='" + product.Text + "' and details='" + subcat.Text + "'");
    //        SqlCommand cmd1 = new SqlCommand(str, ob.con1);
    //        SqlDataReader dr = cmd1.ExecuteReader();
    //        dr.Read();
    //        pid.Text = dr["pid"].ToString();
    //        salt.Text = dr["Salt"].ToString();
    //        dr.Close();
    //    }
    //    else 
    //    {
    //        pid.Text = "";
    //        salt.Text = "";
    //    }
    //    ob.con1.Close();
    //}
    protected void submit_Click(object sender, EventArgs e)
    {
        //try
        //  { 
        RecNo();
        CustomerId();

        ob.constr();
   
                DateTime utctime = DateTime.UtcNow;
                utctime = DateTime.UtcNow.AddHours(5);
                utctime = utctime.AddMinutes(30);

        

        

        if (ob.searchrec("Select Customer_id from Customers where  Customer_id='" + cust.Text + "'"))
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Customer Id Already exists Please Try Another Invoice No. ')", true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("spCustomers", ob.con1);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@RecNo", recno.InnerText);
            cmd.Parameters.AddWithValue("@Customer_id", cust.Text);
            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@Mobile", Mobile.Text);
            cmd.Parameters.AddWithValue("@Address", Address.Text);
            cmd.Parameters.AddWithValue("@Post_date", utctime.ToShortDateString());
            cmd.Parameters.AddWithValue("@Status ", "Pending");
            cmd.ExecuteNonQuery();
        }


        if (ob.searchrec("Select order_number,customer_id from Service where order_number='" + recno.InnerText + "' and customer_id='" + cust.Text + "'"))
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Customer Id Already exists Please Try Another Invoice No. ')", true);
        }

        else
        {

            foreach (GridViewRow row in grd1.Rows)
            {
                Label lblqty = row.FindControl("qty") as Label;
                Label lblpanme = row.FindControl("pname") as Label;
                Label lblrate = row.FindControl("rate") as Label;
                Label lbltamt = row.FindControl("tamt") as Label;

               
                
                    SqlCommand cmd1 = new SqlCommand("spservice", ob.con1);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@order_date", dldate.Text);
                    cmd1.Parameters.AddWithValue("@order_number", recno.InnerText);
                    cmd1.Parameters.AddWithValue("@customer_id", cust.Text);
                    cmd1.Parameters.AddWithValue("@Quanity", lblqty.Text);
                    cmd1.Parameters.AddWithValue("@Item ", lblpanme.Text);
                    cmd1.Parameters.AddWithValue("@price", lblrate.Text);
                    cmd1.Parameters.AddWithValue("@total", lbltamt.Text);
                    cmd1.Parameters.AddWithValue("@Total_amount", t_amt.Text);
                    cmd1.Parameters.AddWithValue("@delivery_date", "");
                    cmd1.Parameters.AddWithValue("@actual_delivery_date", "");
                    cmd1.Parameters.AddWithValue("@post_date", utctime.ToShortDateString());
                    cmd1.Parameters.AddWithValue("@Status", "Pending");
                    cmd1.Parameters.AddWithValue("@Discount", "");
                    cmd1.ExecuteNonQuery();
                }
               
                ViewState["Product"] = null;
                grd1.DataSource = null;
                grd1.DataBind();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Qty"), new DataColumn("Item"), new DataColumn("Amount"), new DataColumn("Price") });
                ViewState["Product"] = dt;
                this.BindGrid();
        }

        name.Text = ""; Mobile.Text = ""; dldate.Text = ""; Address.Text = ""; price.Text = ""; Quty.Text = "";
        price.Text = ""; rate.Text = "";
            ob.con1.Close();
            RecNo();
            CustomerId();
            p1.Visible = false;
                string message = "Customer Added Successfully.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            
        //}
        //catch { Response.Redirect("~/index.aspx"); }

    }
    //    protected void reset_Click(object sender, EventArgs e)
    //    {
    //        ViewState["Product"] = null;
    //        grd1.DataSource = null;
    //        grd1.DataBind();
    //        DataTable dt = new DataTable();
    //        dt.Columns.AddRange(new DataColumn[14] { new DataColumn("Pid"), new DataColumn("Product"), new DataColumn("Salt"), new DataColumn("MRP"), new DataColumn("Rate"), new DataColumn("Qty"), new DataColumn("Dis"), new DataColumn("CGST"), new DataColumn("SGST"), new DataColumn("Amount"), new DataColumn("ExpDt"), new DataColumn("BatchNo"), new DataColumn("GstAmt"), new DataColumn("DisAmt") });
    //        ViewState["Product"] = dt;
    //        this.BindGrid();
    //        mid.Text = ""; firm.Text = "";  salt.Text = "";
    //        billto.Text = "For"; cat.Text = "Type"; product.Text = "Category"; subcat.Text = "Product Name";qty.Text = ""; mrp.Text = ""; 
    //        price.Text = ""; tamt.Text = ""; expdt.Text = ""; t_amt.Text = "0"; gst5.Text = "0"; gst12.Text = "0"; gst18.Text = "0"; 
    //        gst28.Text = "0"; tdis.Text = "0"; tgst.Text = "0"; g_tamt.Text = "0"; invoiceno.Text = ""; t_paid.Text = "0"; bal.Text = "0";
    //        RecNo();
    //    }


    //    protected void discount_TextChanged(object sender, EventArgs e)
    //    {
    //        tamt.Text = Convert.ToString(Convert.ToDouble(tamt.Text) - (Convert.ToDouble(tamt.Text) * Convert.ToDouble(discount.Text)/100));
    //    }

    protected void item_SelectedIndexChanged(object sender, EventArgs e)
    {
        ob.constr();
        string str1 = "select Rate from Itme_Master where Item_name='" + item.Text + "' ";
        SqlCommand cmd1 = new SqlCommand(str1, ob.con1);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        dr1.Read();
        rate.Text = dr1["Rate"].ToString();
        dr1.Close();
        price.Text = Convert.ToString(Convert.ToDouble(Quty.Text) * Convert.ToDouble(rate.Text));
        ob.con1.Close();
    }
}

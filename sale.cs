using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

public partial class StockM_Sale : System.Web.UI.Page
{
    Master ob = new Master();
    SqlDataAdapter da;
    DataSet ds;
    int g;
    String n, Str, k, ad;
    Double per;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //BindData();
                RecNo();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Qty"), new DataColumn("Item"), new DataColumn("Amount"), new DataColumn("Price") });
                ViewState["Product"] = dt;
                this.BindGrid();
            }
            catch { }
        }
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
    protected void search_Click(object sender, ImageClickEventArgs e)
    {
        ob.constr();
        DataSet ds = new DataSet();
        string sql;
        sql = @"select * from Customers where Name like '" + key.Text + "%' or Customer_id='" + key.Text + "' or Mobile='" + key.Text + "' order by srno";

        SqlCommand cmd = new SqlCommand(sql, ob.con1);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        ob.con1.Close();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RecNo();
        Product();
        Quty.Text = ""; Quty.Text = ""; price.Text = ""; rate.Text = ""; cust.Text = "";
        name.Text = ""; Address.Text=""; dldate.Text = "";
        String lblmid = (GridView1.SelectedRow.FindControl("srno") as Label).Text;
        ob.constr();
        String str = ("select * from Customers where srno='" + lblmid + "' order by srno desc");
        SqlCommand cmd1 = new SqlCommand(str, ob.con1);
        SqlDataReader dtr = cmd1.ExecuteReader();
        dtr.Read();
        name.Text = dtr["name"].ToString();
        cust.Text = dtr["Customer_id"].ToString();
        Mobile.Text = dtr["Mobile"].ToString();
        Address.Text = dtr["Address"].ToString();
       
        ob.con1.Close();
    }

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
    protected void BindGrid()
    {
        grd1.DataSource = (DataTable)ViewState["Product"];
        grd1.DataBind();
    }
    protected void add_Click(object sender, EventArgs e)
    {
        //try
        //{

        DataTable dt = (DataTable)ViewState["Product"];
        dt.Rows.Add(Quty.Text.Trim(), item.Text.Trim(), price.Text.Trim(), rate.Text.Trim());
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

    protected void submit_Click(object sender, EventArgs e)
    {
        //try
        //  { 
        RecNo();
        ob.constr();

        DateTime utctime = DateTime.UtcNow;
        utctime = DateTime.UtcNow.AddHours(5);
        utctime = utctime.AddMinutes(30);
        
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
                cmd1.Parameters.AddWithValue("@delivery_date", dldate.Text);
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
}
//    protected void RecNo()
//    {
//        ob.constr();
//        string sqlText = "SELECT Max(cast (InvoiceNo as int)) FROM Psale";
//        SqlCommand command = new SqlCommand(sqlText, ob.con1);
//        try
//        {
//            string pcount = Convert.ToString(command.ExecuteScalar());
//            if (pcount.Length == 0)
//            {
//                recno.InnerText = "100001";
//            }
//            else
//            {
//                int pcount1 = Convert.ToInt32(pcount);
//                int pcountAdd = pcount1 + 1;
//                recno.InnerText = pcountAdd.ToString();
//            }
//        }
//        catch (Exception) { }
//        ob.con1.Close();
//    }
//    protected void BindGrid()
//    {
//        grd1.DataSource = (DataTable)ViewState["Product"];
//        grd1.DataBind();
//    }
//    protected void search_Click(object sender, ImageClickEventArgs e)
//    {
//       
//    }


//    protected void bindFirm()
//    {
//        ob.constr();
//        DataTable table = new DataTable();
//        String str = ("select * from regcust order by sr_no desc");
//        SqlCommand cmd1 = new SqlCommand(str, ob.con1);
//        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
//        sda.Fill(table);
//        GridView1.DataSource = table;
//        GridView1.DataBind();
//        ob.con1.Close();
//    }
//    protected void cat_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        ob.constr();
//        da = new SqlDataAdapter("select Product from ProductMaster where cat='" + cat.Text + "' order by Product", ob.con1);
//        ds = new DataSet();
//        product.Items.Clear();
//        product.Items.Add("Category");
//        subcat.Items.Clear();
//        subcat.Items.Add("Product Name");
//        salt.Text = "";
//        if (da.Fill(ds) > 0)
//        {
//            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//            {
//                product.Items.Add(ds.Tables[0].Rows[i]["Product"].ToString());
//            }
//        }
//        ob.con1.Close();
//    }
//    protected void product_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        ob.constr();
//        salt.Text = "";
//        da = new SqlDataAdapter("select Details from ProDetails where cat='" + cat.Text + "' and product='" + product.Text + "' order by Details", ob.con1);
//        ds = new DataSet();
//        subcat.Items.Clear();
//        subcat.Items.Add("Product Name");
//        if (da.Fill(ds) > 0)
//        {
//            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//            {
//                subcat.Items.Add(ds.Tables[0].Rows[i]["Details"].ToString());
//            }
//        }

//        ob.con1.Close();
//    }

//    protected void subcat_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        //try
//        //{
//            ob.constr();
//        mrp.Text = "";
//        price.Text = "";
//        qty.Text = "0";
//        String str = ("select * from ProDetails where cat='" + cat.Text + "' and product='"+ product.Text + "' and Details='"+ subcat.Text + "' ");
//        SqlCommand cmd1 = new SqlCommand(str, ob.con1);
//        SqlDataReader dtr = cmd1.ExecuteReader();
//        dtr.Read();
//        productid.Text = dtr["pid"].ToString();
//        dtr.Close();

//            DataTable table = new DataTable();
//            string sql = "select A.sr_no,A.Pid,A.ExpDt,A.BatchNo,A.MRP,A.Price,A.Qty,B.Details from StockMaster A INNER JOIN ProDetails B ON A.Pid=B.Pid where A.Pid='" + productid.Text + "' and A.qty>0 order by A.sr_no";
//            SqlCommand cmd = new SqlCommand(sql, ob.con1);
//            SqlDataAdapter da = new SqlDataAdapter(cmd);
//            da.Fill(table);
//            GridView2.DataSource = table;
//            GridView2.DataBind();
//            //For Rate and MRP
//            //String str1 = ("select * from stockmaster where PID='" + productid.Text + "' order by sr_no desc");
//            //SqlCommand cmd11 = new SqlCommand(str1, ob.con1);
//            //SqlDataReader dtr1 = cmd11.ExecuteReader();
//            //dtr1.Read();
//            //price.Text = dtr1["Price"].ToString();
//            //mrp.Text = dtr1["MRP"].ToString();
//            //dtr1.Close();

//            //string TotalQty = "SELECT isnull(sum(Cast(Qty as float)), 0) FROM stockmaster Where PID = '" + productid.Text + "' ";
//            //SqlCommand cmd4 = new SqlCommand(TotalQty, ob.con1);
//            //double Tsub = Convert.ToDouble(cmd4.ExecuteScalar());
//            //subqty.InnerText = Convert.ToString(Tsub);
//            ob.con1.Close();
//        //}
//        //catch
//        //{
//        //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something went wrong')", true);
//        //}
//    }

//    protected void qty_TextChanged(object sender, EventArgs e)
//    {
//        discount.Text = "0";
//        totalamt.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(mrp.Text));
//        per = (Convert.ToDouble(cgst.SelectedItem.Text) + Convert.ToDouble(sgst.SelectedItem.Text)) / 100 * Convert.ToDouble(totalamt.Text);
//        payamt.Text = Convert.ToString((Convert.ToDouble(qty.Text) * Convert.ToDouble(mrp.Text)) + per);
//        disAmt.Text = Convert.ToString(Convert.ToDouble(totalamt.Text) * (Convert.ToDouble(discount.Text) / 100));
//        tamt.Text= Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(mrp.Text));
//        //tamt.Text = payamt.Text;


//    }

//    protected void discount_TextChanged(object sender, EventArgs e)
//    {
//        disAmt.Text = Convert.ToString(Convert.ToDouble(totalamt.Text) * (Convert.ToDouble(discount.Text) / 100));
//        tamt.Text = Convert.ToString(Convert.ToDouble(totalamt.Text) - (Convert.ToDouble(disAmt.Text) ));
//        per = (Convert.ToDouble(cgst.SelectedItem.Text) + Convert.ToDouble(sgst.SelectedItem.Text)) / 100 * Convert.ToDouble(tamt.Text);
//        payamt.Text = Convert.ToString((Convert.ToDouble(tamt.Text)) + per);
//    }

//    protected void add_Click(object sender, EventArgs e)
//    {
//        //try
//        //{
//        P21.Visible = true;
//        submit.Visible = true;
//        cgstamt.Text = Convert.ToString((Convert.ToDouble(price.Text) * Convert.ToDouble(cgst.Text) / 100).ToString("0.00"));
//        sgstamt.Text = Convert.ToString((Convert.ToDouble(price.Text) * Convert.ToDouble(sgst.Text) / 100).ToString("0.00"));
//        Double gstAmount = ((Convert.ToDouble(payamt.Text) - Convert.ToDouble(tamt.Text)));
//        //disamt.Text = Convert.ToString((Convert.ToDouble(qty.Text) * (Convert.ToDouble(price.Text) * Convert.ToDouble(discount.Text) / 100)).ToString("0.00"));
//        String gstamt = Convert.ToString((Convert.ToDouble(qty.Text) * (Convert.ToDouble(price.Text) * (Convert.ToDouble(cgst.Text) + Convert.ToDouble(sgst.Text)) / 100)).ToString("0.00"));
//        //String qty12 = Convert.ToString((Convert.ToInt64(qty.Text)+ (Convert.ToInt64(qty1.Text))));
//        DataTable dt = (DataTable)ViewState["Product"];
//        dt.Rows.Add(productid.Text.Trim(), bno.Text.Trim(), subcat.Text.Trim(), mrp.Text.Trim(), price.Text.Trim(), qty.Text.Trim(), /*qty1.Text.Trim(),*/ discount.Text.Trim(), disAmt.Text.Trim(),
//        cgst.Text.Trim(), sgst.Text.Trim(), gstAmount, tamt.Text.Trim(), payamt.Text.Trim() /*expdt.Text.Trim(),*/ /*bno.Text.Trim(),*/ /*gstamt.Trim()*//*, disamt.Text.Trim()*/);
//        ViewState["Product"] = dt;
//        this.BindGrid();
//        subcat.Text = "Product Name"; qty.Text = ""; /*qty1.Text = "0";*/ mrp.Text = ""; totalamt.Text = "";subqty.InnerText = ""; cgst.Text = "CGST"; sgst.Text = "SGST"; cgstamt.Text = "0";
//        sgstamt.Text = "0"; discount.Text = "0"; /*payamt.Text = "";*/ /*disamt.Text = "0";*/ /*t_paid.Text = "0";*/ /*bal.Text = "0";*/ price.Text = "";
//        salt.Text = ""; /*tamt.Text = "";*/ /*expdt.Text = "";*/ /*bno.Text = "";*/
//        Double GTotal = 0, gst_5 = 0, gst_12 = 0, gst_18 = 0, gst_28 = 0, t_dis = 0, t_gst = 0;

//        GridView2.DataSource = null;
//        GridView2.DataBind();
//        double sum = 0;
//        double tdiscount = 0;
//        double gstSum = 0;
//        double z = 0;
//        for (int i = 0; i < grd1.Rows.Count; i++)
//        {
//            Label lbldisamt = grd1.Rows[i].FindControl("DisAmt") as Label;
//            Label lblamt = grd1.Rows[i].FindControl("pblamt") as Label;
//            Label lblgstamt = grd1.Rows[i].FindControl("gstAmt") as Label;

//            //Label lblcgst = grd1.Rows[i].FindControl("lblcgst") as Label;
//            //Label lblsgst = grd1.Rows[i].FindControl("lblsgst") as Label;
//            //Label lblgstamt = grd1.Rows[i].FindControl("gstamt") as Label;
//            //if (lblcgst.Text == "2.50" && lblsgst.Text == "2.50")
//            //{ gst_5 = gst_5 + Convert.ToDouble(lblgstamt.Text); }
//            //if (lblcgst.Text == "6.00" && lblsgst.Text == "6.00")
//            //{ gst_12 = gst_12 + Convert.ToDouble(lblgstamt.Text); }
//            //if (lblcgst.Text == "9.00" && lblsgst.Text == "9.00")
//            //{ gst_18 = gst_18 + Convert.ToDouble(lblgstamt.Text); }
//            //if (lblcgst.Text == "14.00" && lblsgst.Text == "14.00")
//            //{ gst_28 = gst_28 + Convert.ToDouble(lblgstamt.Text); }
//            //GTotal += Convert.ToDouble(lblamt.Text);
//            //t_dis += Convert.ToDouble(lbldisamt.Text);
//            //t_gst += Convert.ToDouble(lblgstamt.Text);

//            //sum += Double.Parse(grd1.Rows[i].Cells[11].Text);

//            tdiscount += Double.Parse(lbldisamt.Text);
//            sum += Double.Parse(lblamt.Text);
//            gstSum += Double.Parse(lblgstamt.Text);
//        }

//        total_amt.Text = Convert.ToString(sum);
//        t_qty.Text = Convert.ToString(grd1.Rows.Count);
//        t_amt.Text = (Math.Round(Convert.ToDouble(sum))).ToString();
//        //gst5.Text = Convert.ToDouble(gst_5).ToString("0.00");
//        //gst12.Text = Convert.ToDouble(gst_12).ToString("0.00");
//        tdis.Text = Convert.ToString(tdiscount);
//        //gst28.Text = Convert.ToDouble(gst_28).ToString("0.00");
//        gst18.Text = gstSum.ToString("0.00");
//        //tgst.Text = Convert.ToDouble(t_gst).ToString("0.00");
//        g_tamt.Text = Math.Round((Convert.ToDecimal(total_amt.Text) + Convert.ToDecimal(gst18.Text)),0).ToString();
//        //}
//        //catch { Response.Redirect("~/SMLogin.aspx"); }
//    }
//    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
//    {
//        int index = Convert.ToInt32(e.RowIndex);
//        DataTable dt = ViewState["Product"] as DataTable;
//        dt.Rows[index].Delete();
//        ViewState["Product"] = dt;
//        BindGrid();
//        Double GTotal = 0, gst_5 = 0, gst_12 = 0, gst_18 = 0, gst_28 = 0, t_dis = 0, t_gst = 0;
//        for (int i = 0; i < grd1.Rows.Count; i++)
//        {
//            //    Label lblamt = grd1.Rows[i].FindControl("lblamt") as Label;
//            //    Label lblcgst = grd1.Rows[i].FindControl("lblcgst") as Label;
//            //    Label lblsgst = grd1.Rows[i].FindControl("lblsgst") as Label;
//            //    Label lblgstamt = grd1.Rows[i].FindControl("gstamt") as Label;
//            //    Label lbldisamt = grd1.Rows[i].FindControl("disamt") as Label;
//            //    if (lblcgst.Text == "2.50" && lblsgst.Text == "2.50")
//            //    { gst_5 = gst_5 + Convert.ToDouble(lblgstamt.Text); }
//            //    if (lblcgst.Text == "6.00" && lblsgst.Text == "6.00")
//            //    { gst_12 = gst_12 + Convert.ToDouble(lblgstamt.Text); }
//            //    if (lblcgst.Text == "9.00" && lblsgst.Text == "9.00")
//            //    { gst_18 = gst_18 + Convert.ToDouble(lblgstamt.Text); }
//            //    if (lblcgst.Text == "14.00" && lblsgst.Text == "14.00")
//            //    { gst_28 = gst_28 + Convert.ToDouble(lblgstamt.Text); }
//            //    GTotal += Convert.ToDouble(lblamt.Text);
//            //    t_dis += Convert.ToDouble(lbldisamt.Text);
//            //    t_gst += Convert.ToDouble(lblgstamt.Text);
//            //}
//            //t_amt.Text = Convert.ToDouble(GTotal).ToString("0.00");
//            //gst5.Text = Convert.ToDouble(gst_5).ToString("0.00");
//            //gst12.Text = Convert.ToDouble(gst_12).ToString("0.00");
//            //gst18.Text = Convert.ToDouble(gst_18).ToString("0.00");
//            //gst28.Text = Convert.ToDouble(gst_28).ToString("0.00");
//            //tdis.Text = Convert.ToDouble(t_dis).ToString("0.00");
//            //tgst.Text = Convert.ToDouble(t_gst).ToString("0.00");
//            //g_tamt.Text = (Convert.ToDecimal(t_amt.Text) + Convert.ToDecimal(tgst.Text) - Convert.ToDecimal(tdis.Text)).ToString("0.00");
//        }
//    }

//    protected void submit_Click(object sender, EventArgs e)
//    {
//        DateTime utctime = DateTime.UtcNow;
//        utctime = DateTime.UtcNow.AddHours(5);
//        utctime = utctime.AddMinutes(30);
//        String ad = Session["StockM"].ToString();
//        ob.constr();
//        if (ob.searchrec("select InvoiceNo from Psale where InvoiceNo='" + recno.InnerText + "'"))
//        {
//            string message1 = "Invoice No. Already Exist! Please Try With Another.";
//            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
//            sb1.Append("<script type = 'text/javascript'>");
//            sb1.Append("window.onload=function(){");
//            sb1.Append("alert('");
//            sb1.Append(message1);
//            sb1.Append("')};");
//            sb1.Append("</script>");
//            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
//        }
//        else
//        {
//            foreach (GridViewRow row in grd1.Rows)
//            {
//                Label lblpid = row.FindControl("lblpid1") as Label;
//                Label BatchNo = row.FindControl("batchno") as Label;
//                Label lblamt = row.FindControl("lblamt") as Label;
//                Label lblcgst = row.FindControl("lblcgst") as Label;
//                Label lblsgst = row.FindControl("lblsgst") as Label;
//                Label lblgstamt = row.FindControl("gstamt") as Label;
//                Label lbldisamt = row.FindControl("disamt") as Label;
//                Label pblamt = row.FindControl("pblamt") as Label;
//                //Double gst = Convert.ToDouble(lblcgst.Text) + Convert.ToDouble(lblsgst.Text);

//                SqlCommand cmd1 = new SqlCommand("in_Psale", ob.con1);
//                cmd1.CommandType = CommandType.StoredProcedure;
//                cmd1.Parameters.AddWithValue("@InvoiceNo", recno.InnerText);
//                cmd1.Parameters.AddWithValue("@PID", mid.Text);
//                cmd1.Parameters.AddWithValue("@PName", firm.Text);
//                cmd1.Parameters.AddWithValue("@ProductId", lblpid.Text);
//                cmd1.Parameters.AddWithValue("@BatchNo", BatchNo.Text);
//                cmd1.Parameters.AddWithValue("@ProductName", row.Cells[3].Text);
//                cmd1.Parameters.AddWithValue("@MRP", row.Cells[4].Text);
//                cmd1.Parameters.AddWithValue("@Rate","");
//                cmd1.Parameters.AddWithValue("@Qty", row.Cells[5].Text);
//                cmd1.Parameters.AddWithValue("@Dis", row.Cells[6].Text);
//                cmd1.Parameters.AddWithValue("@PayableAmt", pblamt.Text);
//                cmd1.Parameters.AddWithValue("@CGst", lblcgst.Text);
//                cmd1.Parameters.AddWithValue("@SGSt", lblsgst.Text);

//                cmd1.Parameters.AddWithValue("@Total", lblamt.Text);
//                cmd1.Parameters.AddWithValue("@PostDt", utctime.ToShortDateString());
//                cmd1.Parameters.AddWithValue("@Via", ad);

//                if (Bdt.Text == "")
//                {
//                    cmd1.Parameters.AddWithValue("@BackDt", utctime.ToShortDateString());
//                }
//                else
//                {
//                    cmd1.Parameters.AddWithValue("@BackDt", Bdt.Text);
//                }

//                cmd1.ExecuteNonQuery();

//                //------------StockMAster--------------//
//                Double oldqty = 0, newqty = 0, sqty = 0, rate = 0, newtamt = 0;
//                if (ob.searchrec("select PID from StockMaster where PID='" + lblpid.Text + "' and BatchNo='"+ BatchNo.Text + "' "))
//                {
//                    String str = ("select PID,Qty,Total from StockMaster where PID='" + lblpid.Text + "' and BatchNo='" + BatchNo.Text + "' ");
//                    SqlCommand cmd11 = new SqlCommand(str, ob.con1);
//                    SqlDataReader dtr = cmd11.ExecuteReader();
//                    dtr.Read();
//                    oldqty = Convert.ToDouble(dtr["Qty"].ToString());
//                    rate = Convert.ToDouble(row.Cells[5].Text);
//                    newqty = oldqty - Convert.ToInt32(row.Cells[5].Text);
//                    newtamt = newqty * rate;
//                    dtr.Close();
//                    //--------//
//                    //SqlCommand cmd2 = new SqlCommand("up_Stock_Psale", ob.con1);
//                    //cmd2.CommandType = CommandType.StoredProcedure;
//                    //cmd2.Parameters.AddWithValue("@PID", lblpid.Text);
//                    //cmd2.Parameters.AddWithValue("@Qty", newqty.ToString());
//                    //cmd2.Parameters.AddWithValue("@Total", newtamt.ToString("0.00"));
//                    //cmd2.ExecuteNonQuery();

//                    ob.Updaterec("update StockMaster  set Qty='" + newqty.ToString() + "', Total='" + newtamt.ToString("0.00") + "' where PID='" + lblpid.Text + "' and BatchNo='" + BatchNo.Text + "'");
//                }
//            }
//        }

//        ob.con1.Close();
//        ViewState["Product"] = null;
//        grd1.DataSource = null;
//        grd1.DataBind();
//        DataTable dt = new DataTable();
//        dt.Columns.AddRange(new DataColumn[13] { new DataColumn("Pid"), new DataColumn("BatchNo"), new DataColumn("Product"), new DataColumn("MRP"), new DataColumn("Rate"), new DataColumn("Qty"), new DataColumn("Dis"), new DataColumn("DisAmt"), new DataColumn("CGST"), new DataColumn("SGST"), new DataColumn("gstAmount"), new DataColumn("Amount"), new DataColumn("PayableAmt"), });
//        ViewState["Product"] = dt;
//        this.BindGrid();
//        mid.Text = ""; firm.Text = ""; salt.Text = "";
//        billto.Text = "RAVA"; cat.Text = "Type"; product.Text = "Category"; subcat.Text = "Product Name"; qty.Text = ""; mrp.Text = "";
//        price.Text = ""; tamt.Text = "";

//        GridView2.DataSource = null;
//        GridView2.DataBind();
//        try { 
//        Session.Add("Rc", recno.InnerText);

//            Response.Redirect("bill_print.aspx");


//        }
//        catch (ThreadAbortException ex)
//        {
//        }
//        RecNo();

//        string message = "StockOut Successfully.";
//        System.Text.StringBuilder sb = new System.Text.StringBuilder();
//        sb.Append("<script type = 'text/javascript'>");
//        sb.Append("window.onload=function(){");
//        sb.Append("alert('");
//        sb.Append(message);
//        sb.Append("')};");
//        sb.Append("</script>");
//        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
//        P21.Visible = false;
//    }

//    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        String lblmid = (GridView2.SelectedRow.FindControl("lblpid") as Label).Text;
//        ob.constr();
//        //For Rate and MRP
//        String str1 = ("select * from stockmaster where sr_no='" + lblmid + "' order by sr_no desc");
//        SqlCommand cmd11 = new SqlCommand(str1, ob.con1);
//        SqlDataReader dtr1 = cmd11.ExecuteReader();
//        dtr1.Read();
//        price.Text = dtr1["Price"].ToString();
//        mrp.Text = dtr1["MRP"].ToString();
//        bno.Text = dtr1["BatchNo"].ToString();
//        dtr1.Close();

//        string TotalQty = "SELECT isnull(sum(Cast(Qty as float)), 0) FROM stockmaster Where sr_no = '" + lblmid + "' ";
//        SqlCommand cmd4 = new SqlCommand(TotalQty, ob.con1);
//        double Tsub = Convert.ToDouble(cmd4.ExecuteScalar());
//        subqty.InnerText = Convert.ToString(Tsub);
//        ob.con1.Close();
//    }

//    protected void mrp_TextChanged(object sender, EventArgs e)
//    {
//        totalamt.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(mrp.Text));

//         tamt.Text= Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(mrp.Text));
//        //tamt.Text = payamt.Text;
//    }

//    protected void t_paid_TextChanged(object sender, EventArgs e)
//    {
//        bal.Text = (Convert.ToDouble(t_amt.Text) - Convert.ToDouble(t_paid.Text)).ToString("0.00");
//    }
//}

//[Serializable]
//public class ThreadAbortException : Exception
//{
//    public ThreadAbortException()
//    {
//    }

//    public ThreadAbortException(string message) : base(message)
//    {
//    }

//    public ThreadAbortException(string message, Exception innerException) : base(message, innerException)
//    {
//    }

//    protected ThreadAbortException(SerializationInfo info, StreamingContext context) : base(info, context)
//    {
//    }
//}

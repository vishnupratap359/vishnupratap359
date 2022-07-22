<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Panel/home.master" AutoEventWireup="true" CodeFile="upupdate.aspx.cs" Inherits="Admin_Panel_upupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-content">

       

        <div id="page-wrapper">
            <div class="main-page">
                <div class="forms">
                    <%--	<h2 class="title1">Forms</h2>--%>
                    <div class="form-grids row widget-shadow" data-example-id="basic-forms">
                        <div class="form-title">
                            <h4>Party Name :</h4>
                        </div>
                        <div class="form-body">
                            <form>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputID">ID</label>
                                      <%--  <input type="email" class="form-control" id="exampleInputID" placeholder="ID">--%>
                                      <asp:RequiredFieldValidator ID="Rfv21" runat="server" ControlToValidate="id1" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To Id" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="id1" runat="server" ReadOnly="true" class="form-control" placeholder="id"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputCompanyname">Firm/Company Name</label>
                                       <%-- <input type="email" class="form-control" id="exampleInputCompanyname" placeholder="Company name">--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="company" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To company name" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="company" runat="server" class="form-control" placeholder="company name"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputAddress">Address</label>
                                       <%-- <input type="Address" class="form-control" id="exampleInputAddress" placeholder="address">--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="address" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To Address" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="address" runat="server" class="form-control" placeholder="address"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputPersonName">Person Name</label>
                                       <%-- <input type="PersonName" class="form-control" id="exampleInputPersonName" placeholder="Person Name">--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="person" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To person" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="person" runat="server" class="form-control" placeholder="person name"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputMobileno.1">Mobile No.1</label>
                                       <%-- <input type="Mobileno.1" class="form-control" id="exampleInputMoblieno.1" placeholder="Mobile No">--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="mobile1" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To mobile1" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="mobile1" runat="server" class="form-control" placeholder="mobile no" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Please Enter Valid Number.')" pattern="[0-9]{10}"  MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputMobileno.2">mobile No.2</label>
                                       <%-- <input type="Mobileno.2" class="form-control" id="exampleInputMobileno.2" placeholder="Mobile No">--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Mobile2" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To mobile2" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="Mobile2" runat="server" class="form-control" placeholder="mobile no2" oninput="setCustomValidity('')" oninvalid="setCustomValidity('Please Enter Valid Number.')" pattern="[0-9]{10}"   MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="exampleInputLimit">Limit(In Amount)</label>
                                        <%--<input type="Limit" class="form-control" id="exampleInputLimit" placeholder="Limit">--%>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Limit" ErrorMessage="*" ForeColor="Red" 
                                         ToolTip="Please Enter To Limit" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="limit" runat="server" class="form-control" placeholder="limit(in amount)"></asp:TextBox>
                                    </div>
                                </div>

<%--                                <div class="form-group">
                                    <label for="exampleInputFile">File input</label>
                                    <input type="file" id="exampleInputFile">
                                    <p class="help-block">Example block-level help text here.</p>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox">
                                        Check me out </label>
                                </div>--%>

                                 <div class="col-md-8">
                                    <div class="form-group">
                                <%--<button type="Submit" class="btn btn-default" style="float:right;margin-top:30px">Submit</button>--%>
                                        <asp:Button ID="update" Class="btn btn-default" runat="server" Text="update" ValidationGroup="abc" onclick="update_Click1"/>
                                    </div>
                                </div>


                            </form>
                        </div>
                    </div>



                </div>
            </div>
        </div>


        <!--Report-->

</asp:Content>


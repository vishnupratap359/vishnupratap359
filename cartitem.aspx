<%@ Page Title="" Language="C#" MasterPageFile="~/customer/VillaCityUser.master" AutoEventWireup="true" CodeFile="cartItems.aspx.cs" Inherits="customer_cartItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>
        /*.card {
            box-shadow: 10px 10px 5px 0px rgba(0,0,0,0.40);
        }*/
        body {
             background-color: rgba(0,0,0,.03);
        }
        .card-body {
            padding: 0.5rem;
        }

        h3 {
            /*text-decoration: underline;*/
            margin-bottom: 10px;
        }

        .card-footer {
            padding: 0.5rem 0.5rem;
            background-color: rgba(0,0,0,.03);
            border-top: 1px solid rgba(0,0,0,.125);
        }

        .cover {
            margin-bottom: 63px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
        <div class="cover mx-2">
            <h1>Your Cart</h1>
            <asp:DataList CssClass="container-fluid" OnCancelCommand="DtlEvents_CancelCommand" ID="DtlEvents" DataKeyField="id" runat="server" OnUpdateCommand="DtlEvents_UpdateCommand" OnDeleteCommand="DtlEvents_DeleteCommand" RepeatLayout="Table" RepeatColumn="1" RepeatDirection="Vertical">
                <ItemTemplate>
                    <div class="dtDatalist">
                        <div class="card border-secondary">
                            <div class="card-body" id="cardBody">
                                <div class="row">
                                    <div class="col">

                                        Name: <asp:Label CssClass="card-title" runat="server" ID="pName" Text='<%# Bind("productName") %>'></asp:Label> <br />
                                         Price: <asp:Label runat="server" CssClass="" ID="pPrice" Text='<%# Bind("productPrice") %>'></asp:Label> <br />
                                        Description: <asp:Label runat="server" CssClass="" ID="Label1" Text='<%# Bind("userMobile") %>'></asp:Label>
                                  </div>

                                    <div class="col text-center">
                                          <asp:Image CssClass="img-thumbnail" runat="server" ImageUrl="https://img.freepik.com/free-vector/realistic-fruits-composition-with-images-whole-sliced-apple-fruit-blank-background-vector-illustration_1284-66032.jpg?w=740&t=st=1661257678~exp=1661258278~hmac=93fa7bb0eef8b961d6c18c32717b6f1c239fcf66c4eb506a5435bf84581ac555" />
                                    </div>
                                </div>
                                </div>
                                 <div class="card-footer">
                                    <div class="row">
                                        <div class="col-2">
                                            <asp:ImageButton ID="minus" runat="server" ImageUrl="~/customer/images/minus.png" CommandName="Cancel" /></div>
                                        <div class="col-5 text-center">
                                            Quantity: <asp:Label runat="server" ID="quan" Text='<%# Bind("productQuantity") %>'></asp:Label></div>
                                        <div class="col-2">
                                            <asp:ImageButton ID="plus" runat="server" ImageUrl="~/customer/images/plus.png" CommandName="update" /></div>
                                        <div class="col-2 pl-4">
                                           <asp:ImageButton ID="delete" runat="server" ImageUrl="~/customer/images/delete.png" CommandName="delete"></asp:ImageButton>
                                        </div>
                                        <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </div>


</asp:Content>

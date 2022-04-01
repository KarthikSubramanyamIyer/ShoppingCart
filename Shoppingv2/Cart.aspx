<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Shoppingv2.Cart" %>
<asp:Content ID ="Content1" ContentPlaceHolderID ="head" runat = "Server">
</asp:Content>
<asp:Content ID ="Content2" ContentPlaceHolderID ="ContentPlaceHolder1" runat = "Server">
    <div style ="padding-top:50px;">

<div class="col-md-9" >
    
     <%--Show cart details Start--%>
    <div class=" media">
        <br />
        <br />
        <div class=" media-left">
            <a href ="#">
                <img class="media-object" width="100px" src="Images/Shirts/Peter England-1/1.jpg" />
            </a>

        </div>

        <div class=" media-body">
            <h4 class="media-heading">Peter England Cotton Shirt</h4>
            <p class="proPriceDiscountView">Size: L</p>
            <span class="proPriceView">Rs.1250</span>
             <span class="proOgPriceView">Rs.1400</span> 
            <p>
                 <asp:button ID="btnRemoveCart" CssClass="RemoveButton1" runat="server" text="REMOVE FROM CART" onclick="btnRemoveCart_Click"/>
            </p>
        </div>

    </div>
             
     <%--Show cart details Ends--%>


    </div>
        <div class=" col-md-3">

            <%---------------------%> 

            <div>
                <h5>Price Details</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="pull-right priceGray">1400</span>
                </div>


                <div>
                    <label>Cart Discount</label>
                    <span class="pull-right priceGreen">-150</span>
                </div>

            </div>
            <%---------------------%> 
            <div>
                <div class="proPriceView">
                    <label>Cart Total</label>
                    <span class="pull-right">1250</span>
                </div>
                <div>
                     <asp:button ID="btnBuy" CssClass="buyNowbtn" runat="server" text="BUY NOW" onclick="btnBuy_Click"/>
                </div>

            </div>
        </div>
      </div>
</asp:Content>


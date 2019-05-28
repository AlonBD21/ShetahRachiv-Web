<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Catalog.aspx.cs" Inherits="Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>שטח רכיב - קטלוג אופניים</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form method="post" runat="server">
    <h1>קטלוג אופניים מלא</h1>
    <br />

    <span class="link"><a href="FindBike.aspx">חפש בקטלוג</a></span><br />
    <asp:ListView runat="server" ID="lv">
        <ItemTemplate>
        <div class="bikeTemplate" lang="en" dir="rtl">
            <a href='<%# Eval("url") %>' target="_blank">
                <img src='<%# "../Media/BikeImages/" + Eval("img_name") %>' />
                <br /><div class="bikeTxt">
                <label class="bikeManu"><%#: Eval("manu_name") %></label>
                <label class="bikeName"><%#: Eval("bike_name") %></label>
                </div>
            </a>
            <br />
        </div>
            <br />
        </ItemTemplate>
    </asp:ListView>
        </form>
</asp:Content>


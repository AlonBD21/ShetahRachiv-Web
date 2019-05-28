<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="FindBike.aspx.cs" Inherits="FindBike" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>שטח רכיב - חיפוש אופניים</title>
    <script src="../Scripts/FindBike.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form method="get" runat="server">
    <h1>חיפוש אופניים בקטלוג</h1>
       
    <a href="Catalog.aspx">לחץ כאן כדי לעבור לקטלוג אופניים מלא</a>
    <asp:Label ID="mainErr" runat="server" Text="" AssociatedControlID=""></asp:Label>
    <fieldset>
        <p>מלא את הטופס ומצא את האופניים המתאימות ביותר עבורך! <span>:</span></p>
        <br />
        <asp:Label ID="lblHeight" runat="server" Text="בחר... " AssociatedControlID="ddlFS"></asp:Label>
        <asp:DropDownList ID="ddlFS" runat="server">
            <asp:ListItem>הצג הכל</asp:ListItem>
            <asp:ListItem>זנב קשיח</asp:ListItem>
            <asp:ListItem>שיכוך מלא</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />

        <asp:Label ID="lblStyle" runat="server" Text="סגנון רכיבה" AssociatedControlID="ddlStyle"></asp:Label>
        <br />
        <a href="RideStyles.aspx" target="_blank">לחץ כאן כדי ללמוד עוד על סוגי הרכיבה</a><br />
        <asp:DropDownList ID="ddlStyle" runat="server">
            <asp:ListItem>הצג הכל</asp:ListItem>
            <asp:ListItem>Dirt Jump</asp:ListItem>
            <asp:ListItem>Trails</asp:ListItem>
            <asp:ListItem>All Mountain / Enduro</asp:ListItem>
            <asp:ListItem>Downhill</asp:ListItem>
        </asp:DropDownList>
        <br />
        <label class="err" id="styleLbl"></label>
        <br />
        <asp:Label ID="lblManu" runat="server" Text="יצרן\ים" AssociatedControlID="cblManu"></asp:Label>
        <br />
        <div dir="ltr">
            <asp:CheckBoxList runat="server" ID="cblManu">
            </asp:CheckBoxList>
        </div>
        <br />
    </fieldset>
    <asp:Button ID="Send" runat="server" Text="מצא" OnClick="Send_Click" />
    <br />
        <asp:Label runat="server" Visible="false" id="resCount"/><br />
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


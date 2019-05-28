<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Pages_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>שטח רכיב - <%=user.username %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form method="post" runat="server">
    <h6>פרטי משתמש
    </h6>
    <h1>
        <%=user.username %>
    </h1>
    <h5 id="adminTag" runat="server">מנהל אתר</h5>
    <div id="editable">
        <fieldset>
            <legend>פרטים פתוחים לעריכה</legend>
            <label for="txtEmail">כתובת מייל</label>
            <input type="email" id="txtEmail" name="txtEmail" value='<%=user.email %>' required />
            <br />



            <label for="txtFullname">שם מלא</label>
            <input type="text" name="txtFullname" id="txtFullname" value='<%=user.name %>' /><br />
            <br />
            <label for="gender">מין</label><br />
            <input type="radio" name="gender" id="male" value="0" required <%=(user.gender == 0 ? "checked" : "") %> /><label class="small" for="male">&male; רוכב</label><br />
            <input type="radio" name="gender" id="female" value="1" required <%=(user.gender == 1 ? "checked" : "") %> /><label class="small" for="female">&female; רוכבת</label><br />
            <input type="radio" name="gender" id="other" value="2" required <%=(user.gender == 2 ? "checked" : "") %> /><label class="small" for="other">אחר</label><br />
            <br />
            <br />
            <label for="rideStyle">סגנונות רכיבה אהובים</label><br />
            <br />
            <a href="RideStyles.aspx" target="_blank">לחץ כאן כדי ללמוד עוד על סוגי הרכיבה</a><br />
            <input type="checkbox" name="dj" id="dj" value="0" <%=(user.dj ? "checked" : "") %> /><label for="dj">Dirt Jump</label><br />
            <input type="checkbox" name="tr" id="tr" value="1" <%=(user.tr ? "checked" : "") %> /><label for="tr">Trails</label><br />
            <input type="checkbox" name="am" id="am" value="2" <%=(user.am ? "checked" : "") %> /><label for="am">All Mountain / Enduro</label><br />
            <input type="checkbox" name="dh" id="dh" value="3" <%=(user.dh ? "checked" : "") %> /><label for="dh">Downhill / Gravity</label><br />
            <br />
            <label for="txtMoto">מעט עלי</label><br />
            <textarea id="txtMoto" name="txtMoto"><%=user.bio %></textarea>
            <br />
            <br />
        </fieldset>
        <input type="submit" value="שמור שינויים" name="submit" /><input type="submit" name="cancel"  value="ביטול" />
        <br />
        <label id="mainErr"><%=mainErr %></label>
    </div>
    <div id="noneditable" visible='<%=!user.id.Equals(App_Code.AppCode.GetSesID(Session)) %>'>
    </div>
    <br />
        </form>
</asp:Content>


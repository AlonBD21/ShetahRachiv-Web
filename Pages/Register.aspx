<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../Scripts/RegisterPage.js"></script>
    <title>שטח רכיב - הרשמה</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form method="post" runat="server">
    <h1>הרשמה</h1>
    <br />

    <fieldset>
        <legend>חשבון</legend>
        <label for="txtUser">שם משתמש</label>
        <input type="text" id="txtUser" name="txtUser" onkeyup="checkUserName()" required />
        <label for="txtUser" class="err" id="userErr"></label>
        <br />

        <label for="txtEmail">כתובת מייל</label>
        <input type="email" id="txtEmail" name="txtEmail" onkeyup="checkEmail()" required />
        <label for="txtEmail" class="err" id="emailErr"></label>
        <br />

        <label for="txtPass">סיסמה</label>
        <input type="password" id="txtPass" onkeyup="verifyPass()" required name="txtPass" />
        <label for="txtPass" class="err"></label>
        <br />
        <label for="txtVerify">אימות סיסמה</label>
        <input type="password" name="txtVerify" onkeyup="verifyPass()" id="txtVerify" required />
        <label for="txtVerify" id="passErr" class="err"></label>
        <br />
    </fieldset>

    <fieldset>
        <legend>פרטי רוכב</legend>
        <label for="txtFullname">שם מלא</label>
        <input type="text" name="txtFullname" onkeyup="checkName()" id="txtFullname" /><label for="txtFullName" id="fullNameErr" class="err"></label><br />
        <br />
        <label for="gender">מין</label><br />
        <input type="radio" name="gender" id="male" value="0" required /><label class="small" for="male">&male; רוכב</label><br />
        <input type="radio" name="gender" id="female" value="1" required /><label class="small" for="female">&female; רוכבת</label><br />
        <input type="radio" name="gender" id="other" value="2" required /><label class="small" for="other">אחר</label><br />
        <br /><br />
        <label for="rideStyle" >סגנונות רכיבה אהובים</label><br /><br />
        <a href="RideStyles.aspx" target="_blank">לחץ כאן כדי ללמוד עוד על סוגי הרכיבה</a><br />
        <input type="checkbox" name="dj" id="dj" value="0"/><label for="dj">Dirt Jump</label><br />
        <input type="checkbox" name="tr" id="tr"  value="1"/><label for="tr">Trails</label><br />
        <input type="checkbox" name="am" id="am" value="2"/><label for="am">All Mountain / Enduro</label><br />
        <input type="checkbox" name="dh" id="dh" value="3"/><label for="dh">Downhill / Gravity</label><br />
        <br />
        <label for="txtMoto">מעט עלי</label><br />
        <textarea id="txtMoto" name="txtMoto" onkeyup="checkBio()" ></textarea>
        <br />
        <label class="err" id="motoErr" ></label>
        <br />
    </fieldset>
    <input type="submit" value="הרשם! " name="submit" />
    <br />
    <label id="mainErr"><%=mainErr %></label>
        </form>
</asp:Content>


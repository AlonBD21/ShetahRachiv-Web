<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>שטח רכיב - התחברות</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form method="post" runat="server">
    <h1>כניסה</h1>
    <span class="link"><a href="Register.aspx"><span>חדש כאן? הרשם</span>!<span></span></a></span><br />
    <table class="logintbl">
        <tr>
            <td>
                <label for="txtUser">שם משתמש</label>
            </td>
            <td>
               <input type="text" id="txtUser" name="username" />
            </td>
        </tr>
        <tr>
            <td>
               <label for="txtPass">סיסמה</label>
            </td>
            <td>
                 <input type="password" id="txtPass" name="password"/>
            </td>
        </tr>
    </table>
    <input type="submit" name="submit"/>
    <br />
    <label id="mainErr" for='<%=focusID %>' ><%=error %></label>
        </form>
</asp:Content>


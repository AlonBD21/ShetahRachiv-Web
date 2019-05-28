<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>שטח רכיב - ניהול משתמשים</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form method="post" runat="server">
        <header>
            <h2>ניהול האתר</h2>
            <h5>ברוך הבא</h5>
            <h3 id="adminTag"><%=App_Code.AppCode.GetSesUsrName(Session) %></h3>
            <br />
            <br />
        </header>
        <div class="adminPanel" dir="ltr">
            <table>
                <tr>
                    <th>User ID</th>
                    <th>Username</th>
                    <th>Password</th>
                    <th>E-Mail</th>
                    <th>Active?</th>
                    <th>Admin?</th>
                    <th>UPDATE</th>
                    <th>DELETE</th>
                </tr>
                <asp:ListView ID="lv" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <label><%# Eval("user_id") %></label></td>
                            <td>
                                <input type="text" required name='<%# "username"+ Eval("user_id") %>' value='<%#: Eval("user_name") %>' /></td>
                            <td>
                                <input type="text" required name='<%# "password"+ Eval("user_id") %>' value='<%#: Eval("password") %>' /></td>
                            <td>
                                <input type="email" required name='<%# "email"+ Eval("user_id") %>' value='<%#: Eval("email") %>' /></td>

                            <td>
                                <input type="checkbox" name='<%# "active"+ Eval("user_id") %>' value="true" <%#(bool)Eval("is_active") ? "checked" : ""%> /></td>
                            <td>
                                <input type="checkbox" name='<%# "admin"+ Eval("user_id") %>' value="true" <%#(bool)Eval("is_admin") ? "checked" : ""%> /></td>
                            <td>
                                <button type="submit" name="del" value='<%# Eval("user_id") %>'>מחק משתמש</button>
                            </td>
                            <td>
                                <button type="submit" name="upd" value='<%# Eval("user_id") %>'>עדכן משתמש</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
            <label id="mainErr"><%=mainErr %></label>
        </div>
        <input type="submit" value="בטל שינויים" />
    </form>
</asp:Content>


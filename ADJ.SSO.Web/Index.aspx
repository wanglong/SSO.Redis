<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ADJ.SSO.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SSO demo</title>
</head>
<body>
    <form id="form1" runat="server">
           用  户：<input id="txtUserName" type="text" name="userName" /><br /><br />
           密  码：<input type="password" name="passWord" /><br /><br />
            <input type="submit" value="登录" /><br /><br />
         
            <span style="color: red; margin-top: 20px;"><%=StrTip %></span>
    </form>

</body>
</html>

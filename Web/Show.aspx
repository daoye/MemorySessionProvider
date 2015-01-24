<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Web.Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .containor {
            padding: 50px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="containor">
               The session value is: <%=Session["test"]%> <br/>
                <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>

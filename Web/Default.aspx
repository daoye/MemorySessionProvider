<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .containor{
            padding:50px; text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="containor">
            <asp:TextBox ID="txtVal" runat="server"></asp:TextBox>
            <asp:Button ID="btnSave" runat="server" Text="Store Session" OnClick="btnSave_Click" />
            <asp:Button ID="Button1" runat="server" Text="View Value" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>

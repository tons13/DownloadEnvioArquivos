<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationExcel._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="bntUpload" runat="server" Height="23px" 
            Text="Upload" Width="121px" onclick="bntUpload_Click" />
    
        <br />
    
        <br />
        <asp:LinkButton ID="lbtDownload" Text="Download Template" runat="server" 
            onclick="lbtDownload_Click"></asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>

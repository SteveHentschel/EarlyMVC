<%@Page Language="C#"AutoEventWireup="true"
CodeBehind="PersonUI.aspx.cs"Inherits="Partial_Class.PersonUI"%>

<!DOCTYPEhtml>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Partial Class Example</title>
</head>
    <body>
       <h3>Partial Class Table</h3>
       <form id="form1" runat="server">
       <div>
           <asp:GridView ID="gridPerson" runat="server">
           </asp:GridView>
       </div>
       </form>
       <span>Age property is added after building from DB first.</span> 
    </body>
</html>
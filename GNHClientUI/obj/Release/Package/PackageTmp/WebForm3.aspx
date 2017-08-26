<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="GNHClientUI.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridEllergie" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EMnEllergieID" HeaderText="EMnEllergieID" InsertVisible="False" ReadOnly="True" SortExpression="EMnEllergieID" />
                <asp:BoundField DataField="EMsEllergieName" HeaderText="EMsEllergieName" SortExpression="EMsEllergieName" />
                <asp:BoundField DataField="EMsFoodName" HeaderText="EMsFoodName" SortExpression="EMsFoodName" />
                <asp:CheckBoxField DataField="SMbIsDeleted" HeaderText="SMbIsDeleted" SortExpression="SMbIsDeleted" />
                <asp:BoundField DataField="EMdtCreated" HeaderText="EMdtCreated" SortExpression="EMdtCreated" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [EllergieMaster]"></asp:SqlDataSource>
    </form>
</body>
</html>

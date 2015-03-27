<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="D20150327Homework.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <!--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HOMEWORKConnectionString %>" SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
        -->
        <asp:TextBox ID="searchTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="searchButton" runat="server" Text="查詢" OnClick="searchButton_Click" />

        <asp:GridView ID="resultGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

        ID:<asp:TextBox ID="insertIDTextBox" runat="server"></asp:TextBox>
        Name:<asp:TextBox ID="insertNameTextBox" runat="server"></asp:TextBox>
        Class:<asp:TextBox ID="insertClassTextBox" runat="server"></asp:TextBox>
        Birthday:<asp:TextBox ID="insertBirthdayTextBox" runat="server"></asp:TextBox>
        Phone:<asp:TextBox ID="insertPhoneTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="insertButton" runat="server" OnClick="insertButton_Click" Text="新增" />
        
        <br />

        ID:<asp:TextBox ID="updateIDTextBox" runat="server" OnTextChanged="updateIDTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
        Name:<asp:TextBox ID="updateNameTextBox" runat="server" Enabled="false"></asp:TextBox>
        Class:<asp:TextBox ID="updateClassTextBox" runat="server" Enabled="false"></asp:TextBox>
        Birthday:<asp:TextBox ID="updateBirthdayTextBox" runat="server" Enabled="false"></asp:TextBox>
        Phone:<asp:TextBox ID="updatePhoneTextBox" runat="server" Enabled="false"></asp:TextBox>
        <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="修改" Enabled="false" />

        <br />

        ID:<asp:TextBox ID="deleteIDTextBox" runat="server" ></asp:TextBox>
        <asp:Button ID="deleteButton" runat="server" Text="刪除" OnClick="deleteButton_Click" />
        <!--OnTextChanged="deleteIDTextBox_TextChanged" AutoPostBack="true"-->
        <!--Enabled="false"--> 

    </div>
    </form>
</body>
</html>

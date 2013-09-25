<%@ Page Title="GRE" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Test_GRE.aspx.cs" Inherits="SoftwareDesignII.Test.Test_GRE" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        &nbsp;<asp:Label ID="Label_Title" runat="server"></asp:Label>
    </h2>
    <p>
        Please select the paper that you want to view.</p>
    <p>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ExamSystemConnectionString %>" 
            SelectCommand="SELECT * FROM [PaperCategory] WHERE ([Category] = @Category)">
            <SelectParameters>
                <asp:Parameter DefaultValue="GRE" Name="Category" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="PaperID" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" onselectedindexchanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="PaperID" HeaderText="PaperID" ReadOnly="True" 
                    SortExpression="PaperID" />
                <asp:BoundField DataField="Category" HeaderText="Category" 
                    SortExpression="Category" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="UpdateUserID" HeaderText="UpdateUserID" 
                    SortExpression="UpdateUserID" />
                <asp:BoundField DataField="FinishTime" HeaderText="FinishTime" 
                    SortExpression="FinishTime" />
                <asp:BoundField DataField="UsedTimes" HeaderText="UsedTimes" 
                    SortExpression="UsedTimes" />
                <asp:CommandField ShowSelectButton="True" HeaderText="Operation" 
                    SelectText="Choose this paper!" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" BorderStyle="Inset" Font-Bold="True" 
                ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        
    </p>
    <p>
        
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Exam.aspx">Choose Exam</asp:LinkButton>
        
    </p>
</asp:Content>

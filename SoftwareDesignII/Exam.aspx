<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="SoftwareDesignII.Exam_Page" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Exam
    </h2>
    <p>
        <asp:TreeView ID="TreeView1" runat="server" BorderStyle="Dotted" 
        ExpandDepth="0" ImageSet="Msdn" NodeIndent="10" ShowLines="True">
        <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" 
            Font-Underline="True" />
        <Nodes>
            <asp:TreeNode Text="Computer" Value="Computer">
                <asp:TreeNode Text="Oracle" Value="Programmer"></asp:TreeNode>
                <asp:TreeNode Text="Microsoft" Value="Microsoft"></asp:TreeNode>
                <asp:TreeNode Text="Tecent" Value="Tecent"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="Mathematics" Value="Mathematics">
                <asp:TreeNode Text="Calculus" Value="Calculus"></asp:TreeNode>
                <asp:TreeNode Text="Linear Algebra" Value="Linear Algebra"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="English" Value="English">
                <asp:TreeNode Text="TOEFL" Value="TOEFL"></asp:TreeNode>
                <asp:TreeNode Text="IELTS" Value="IELTS"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/Test/Test_GRE.aspx" Text="GRE" Value="GRE">
                </asp:TreeNode>
                <asp:TreeNode Text="CET" Value="CET">
                    <asp:TreeNode Text="Level 4" Value="Level 4"></asp:TreeNode>
                    <asp:TreeNode Text="Level 6" Value="Level 6"></asp:TreeNode>
                </asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" 
            BorderWidth="1px" Font-Underline="False" HorizontalPadding="3px" 
            VerticalPadding="1px" />
        </asp:TreeView>
    </p>
</asp:Content>
<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="SoftwareDesignII.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Upload Paper
    </h2>
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            PostBackUrl="~/UploadPaper.aspx">Upload Paper</asp:LinkButton>
        <asp:Label ID="Label1" runat="server" 
            Text="You are not a teacher. You cannot upload a paper."></asp:Label>
    </p>
</asp:Content>

<%@ Page Title="Reset my favorite subject" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ResetFavorite.aspx.cs" Inherits="SoftwareDesignII.ResetFavorite" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Reset my favorite subject
    </h2>
    <p>
        Now you are interested in 
        <asp:Label ID="LabelInterest" runat="server"></asp:Label>
        .
    </p>
    <p>
        Please input your new interest:
        <asp:TextBox ID="TextBoxInterest" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonOK" runat="server" Text="OK" onclick="ButtonOK_Click" />
    </p>
</asp:Content>

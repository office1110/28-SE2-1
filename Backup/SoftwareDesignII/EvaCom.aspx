<%@ Page Title="Evaluate by Exam Master" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EvaCom.aspx.cs" Inherits="SoftwareDesignII.EvaCom" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        <asp:Label ID="LabelTitle" runat="server" Text="Evaluate by Exam Master"></asp:Label>
    </h1>
    <h2>
        <asp:Label ID="LabelQNo" runat="server" Text=""></asp:Label>
    </h2>
    <p>
        <asp:TextBox ID="TextBoxQuestion" runat="server" Height="209px" 
            TextMode="MultiLine" Width="758px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="TextBoxCorrect" runat="server" Height="209px" 
            TextMode="MultiLine" Width="758px"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="TextBoxMine" runat="server" Height="209px" 
            TextMode="MultiLine" Width="758px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Result: "></asp:Label>
        <asp:Label ID="LabelResult" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="ButtonPre" runat="server" onclick="ButtonPre_Click" 
            Text="&lt;--Previous" />
        <asp:Button ID="ButtonNxt" runat="server" onclick="ButtonNxt_Click" 
            Text="Next--&gt;" />
        <asp:Button ID="ButtonFns" runat="server" Text="Finish!" />
    </p>
</asp:Content>

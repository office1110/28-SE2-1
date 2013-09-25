<%@ Page Title="Upload Paper" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UploadPaper.aspx.cs" Inherits="SoftwareDesignII.UploadPaper" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        
        <asp:Label ID="LabelTitle" runat="server" Text="Label"></asp:Label>
        
    </h2>
    <p>
        <asp:Label ID="LabelPaperID" runat="server" Text="Paper ID: "></asp:Label>
        <asp:Label ID="LabelRealID" runat="server"></asp:Label>
    </p>
    <p>
        
        <asp:Label ID="LabelCategory" runat="server" Text="Paper Category: "></asp:Label>
        <asp:TextBox ID="TextBoxPaperCategory" runat="server" 
            ontextchanged="TextBoxPaperCategory_TextChanged"></asp:TextBox>
    </p>
    <p>
        
        <asp:Label ID="LabelPaperName" runat="server" Text="Paper Name: "></asp:Label>
        <asp:TextBox ID="TextBoxPaperName" runat="server"></asp:TextBox>
    </p>
    <p>    
        <asp:Label ID="LabelQuestionCategory" runat="server" Text="Question Category: "></asp:Label>
        <asp:DropDownList ID="DropDownListCategory" runat="server">
            <asp:ListItem>Fill in the blanks</asp:ListItem>
            <asp:ListItem>Choose One Answer</asp:ListItem>
            <asp:ListItem>Choose One or More Answer</asp:ListItem>
            <asp:ListItem>Right or Wrong</asp:ListItem>
            <asp:ListItem>Answer a Question</asp:ListItem>
        </asp:DropDownList>
        
    </p>
    <p>
        
        <asp:TextBox ID="TextBoxQuestion" runat="server" Height="226px" 
            TextMode="MultiLine" Width="813px">Please input the question here.</asp:TextBox>
        
    </p>
    <p>
        
        <asp:TextBox ID="TextBoxAnswer" runat="server" Height="218px" 
            TextMode="MultiLine" Width="811px">Please input the answer here.</asp:TextBox>
        
    </p>
    <p>
        
        <asp:Button ID="ButtonPre" runat="server" onclick="ButtonPre_Click" 
            Text="&lt;--Previous" />
        <asp:Button ID="ButtonNxt" runat="server" onclick="ButtonNxt_Click" 
            Text="Next--&gt;" />
        <asp:Button ID="ButtonFinish" runat="server" Text="Finish" 
            onclick="ButtonFinish_Click" />
        
    </p>
</asp:Content>

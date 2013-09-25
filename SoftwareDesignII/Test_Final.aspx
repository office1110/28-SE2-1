<%@ Page Title="Test" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Test_Final.aspx.cs" Inherits="SoftwareDesignII.Test_Final" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Testing...
    </h2>
    <h3>
        <asp:Label ID="LabelTitle" runat="server" Text="Label"></asp:Label>
    </h3>
    <asp:ScriptManager ID="TestScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            You have spent
            <asp:Label ID="LabelTimer" runat="server" Text=""></asp:Label>
            &nbsp;on this paper.
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
            </asp:Timer>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    </p>
    <p>
        <asp:TextBox ID="QuestionTextBox" runat="server" BorderStyle="Dotted" 
            Height="142px" ReadOnly="True" TextMode="MultiLine" Width="798px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Answer: "></asp:Label>
        <asp:TextBox ID="AnswerTextBox" runat="server"></asp:TextBox>
        <asp:Label ID="HintLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="preButton" runat="server" onclick="Button1_Click" 
            Text="&lt;--Previous Question" />
        <asp:Button ID="nxtButton" runat="server" onclick="nxtButton_Click" 
            Text="Next Question--&gt;" />
        <asp:Button ID="FinishButton" runat="server" onclick="FinishButton_Click" 
            Text="Finish Test!" Visible="False"/>
        <asp:Button ID="ButtonEva" runat="server" PostBackUrl="~/EvaluateChoice.aspx" 
            Text="Go to evaluate--&gt;" />
    </p>
</asp:Content>

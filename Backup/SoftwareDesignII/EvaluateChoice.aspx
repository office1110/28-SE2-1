<%@ Page Title="Choose a evaluation method" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EvaluateChoice.aspx.cs" Inherits="SoftwareDesignII.EvaluateChoice" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3>
        Please choose a evaluation method.
    </h3>
    <p>
        <asp:LinkButton ID="LinkButtonSelf" runat="server" PostBackUrl="~/EvaSelf.aspx">Give me the answer! I will evaluate this paper by myself!</asp:LinkButton>
    </p>
    <p>
        <asp:LinkButton ID="LinkButtonComputer" runat="server" PostBackUrl="~/EvaCom.aspx">Mr. ExamMaster, please help me to evaluate this paper.</asp:LinkButton>
    </p>
    <p>
        <asp:LinkButton ID="LinkButtonTeacher" runat="server" PostBackUrl="~/EvaTeacher.aspx">I want to let a teacher evaluate my paper.</asp:LinkButton>
    </p>
</asp:Content>

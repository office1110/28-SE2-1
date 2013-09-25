<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="SoftwareDesignII.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="False" 
        OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <h2>
                        Create a New Account
                    </h2>
                    <p>
                        Use the form below to create a new account.
                    </p>
                    <p>
                        Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="UserIDLabel" runat="server" AssociatedControlID="UserID">User ID:</asp:Label>
                                <asp:TextBox ID="UserID" runat="server" CssClass="textEntry" ReadOnly="true" BorderStyle="None"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="EmailFormatRequired" runat="server" ControlToValidate="Email"
                                     CssClass="failureNotification" ErrorMessage="E-mail format is wrong." ToolTip="Please input a valid E-mail."
                                     ValidationGroup="RegisterUserValidationGroup" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordQuestionLabel" runat="server" AssociatedControlID="PasswordQuestion">Password Hint Question:</asp:Label>
                                <asp:TextBox ID="PasswordQuestion" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="PasswordAnswerLabel" runat="server" AssociatedControlID="PasswordAnswer">Answer to the question above:</asp:Label>
                                <asp:TextBox ID="PasswordAnswer" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="IsTeacherLabel" runat="server" AssociatedControlID="IsTeacher">Is a Teacher?</asp:Label>
                                <asp:TextBox ID="IsTeacher" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="IsTeacherRequired" runat="server" ControlToValidate="IsTeacher"
                                     CssClass="failureNotification" ErrorMessage="You must tell me whether you are a teacher." ToolTip="You must tell me whether you are a teacher."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="IsTeacherValidator" runat="server" ControlToValidate="IsTeacher"
                                     CssClass="failureNotification" ErrorMessage="Invalid Format." ToolTip="'Y' or 'N' only."
                                     ValidationGroup="RegisterUserValidationGroup" ValidationExpression="Y|N">*</asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label ID="InterestLabel" runat="server" AssociatedControlID="Interest">Choose a subject that you are interested in:</asp:Label>
                                <asp:TextBox ID="Interest" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="ClassIDLabel" runat="server" AssociatedControlID="ClassID">Join the following class:</asp:Label>
                                <asp:TextBox ID="ClassID" runat="server" CssClass="textEntry"></asp:TextBox>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User" 
                                 ValidationGroup="RegisterUserValidationGroup" 
                                onclick="CreateUserButton_Click"/>
                        </p>
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="center" colspan="2">
                                Complete</td>
                        </tr>
                        <tr>
                            <td>
                                Your account has been successfully created. Your ID is: 
                                <asp:Label ID = "FinalIDLabel" runat = "server" Text="123"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                                    CommandName="Continue" Text="Continue" ValidationGroup="RegisterUser" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

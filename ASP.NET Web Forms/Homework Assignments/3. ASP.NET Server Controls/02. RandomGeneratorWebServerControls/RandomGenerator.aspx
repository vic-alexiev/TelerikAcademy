<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGeneratorWebServerControls.RandomGenerator" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="LabelFirstNumber" runat="server" AssociatedControlID="TextBoxFirstNumber" Text="First Number"></asp:Label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />
        <asp:CompareValidator ID="CompareValidatorFirstNumber" runat="server" ControlToValidate="TextBoxFirstNumber" ErrorMessage="Value must be an integer." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstNumber" runat="server" ControlToValidate="TextBoxFirstNumber" ErrorMessage="Value is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidatorNumbers" runat="server" ControlToCompare="TextBoxSecondNumber" ControlToValidate="TextBoxFirstNumber" ErrorMessage="The first number should be smaller than the second number!" ForeColor="Red" Operator="LessThan" Type="Integer"></asp:CompareValidator>
        <br />
        <asp:Label ID="LabelSecondNumber" runat="server" AssociatedControlID="TextBoxSecondNumber" Text="Second Number"></asp:Label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>

        <br />
        <asp:CompareValidator ID="CompareValidatorSecondNumber" runat="server" ControlToValidate="TextBoxSecondNumber" ErrorMessage="Value must be an integer." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSecondNumber" runat="server" ControlToValidate="TextBoxSecondNumber" ErrorMessage="Value is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <p>
            <asp:Button ID="ButtonGenerate" runat="server" Text="Generate" OnClick="ButtonGenerate_Click" />
            <asp:TextBox ID="TextBoxResult" runat="server" ReadOnly="True"></asp:TextBox>
        </p>
    </form>
</body>
</html>

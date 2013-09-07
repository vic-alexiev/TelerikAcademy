<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGeneratorHtmlServerControls.RandomGenerator" ValidateRequest="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #txtFirstNumber {
            width: 75px;
        }

        #txtSecondNumber {
            width: 75px;
        }
    </style>
</head>
<body>
    <form id="generator" runat="server">
        <label for="txtFirstNumber" runat="server" id="lblFirstNumber">First number</label>
        <input type="text" id="txtFirstNumber" runat="server" />
        <br />
        <asp:CompareValidator ID="CompareValidatorFirstNumber" runat="server" ControlToValidate="txtFirstNumber" ErrorMessage="Value must be an integer." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstNumber" runat="server" ControlToValidate="txtFirstNumber" ErrorMessage="Value is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidatorNumbers" runat="server" ControlToCompare="txtSecondNumber" ControlToValidate="txtFirstNumber" ErrorMessage="The first number should be smaller than the second number!" ForeColor="Red" Operator="LessThan" Type="Integer"></asp:CompareValidator>
        <br />
        &nbsp;<label for="txtSecondNumber" runat="server" id="lblSecondNumber">Second number</label><input type="text" id="txtSecondNumber" runat="server" /><br />
        <asp:CompareValidator ID="CompareValidatorSecondNumber" runat="server" ControlToValidate="txtSecondNumber" ErrorMessage="Value must be an integer." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        &nbsp;<br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSecondNumber" runat="server" ControlToValidate="txtSecondNumber" ErrorMessage="Value is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <p>
            <input id="btnGenerate" type="button" onserverclick="btnGenerate_Click" runat="server" value="Generate" />
            <input id="txtResult" readonly="true" type="text" runat="server" />
        </p>
    </form>

</body>
</html>

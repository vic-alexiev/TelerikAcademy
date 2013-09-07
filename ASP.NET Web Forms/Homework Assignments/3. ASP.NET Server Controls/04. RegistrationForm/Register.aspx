<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegistrationForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Student StudStudent data</legend>
            <asp:Label ID="LabelFirstName" runat="server" Text="First Name" AssociatedControlID="TextBoxFirstName"></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="LabelLastName" runat="server" Text="Last Name" AssociatedControlID="TextBoxLastName"></asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <asp:Label ID="LabelFacultyNumber" runat="server" Text="Faculty Number" AssociatedControlID="TextBoxFacultyNumber"></asp:Label>
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidatorFacultyNumber" runat="server" ControlToValidate="TextBoxFacultyNumber" ErrorMessage="Value must be an integer." ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            <br />
            <asp:Label ID="LabelUniversity" runat="server" AssociatedControlID="DropDownListUniversity" Text="University"></asp:Label>
            <asp:DropDownList ID="DropDownListUniversity" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelSpeciality" runat="server" AssociatedControlID="DropDownListSpeciality" Text="Speciality"></asp:Label>
            <asp:DropDownList ID="DropDownListSpeciality" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSpeciality_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelCourses" runat="server" Text="Courses"></asp:Label>
            <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
            <br />
        </fieldset>
    </form>
</body>
</html>

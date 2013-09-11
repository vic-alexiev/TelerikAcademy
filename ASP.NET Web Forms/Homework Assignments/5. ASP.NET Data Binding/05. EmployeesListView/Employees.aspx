<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        ul {
            display: table-cell;
            list-style-type: none;
        }
    </style>
</head>
<body>
    <form id="formEmployees" runat="server">
        <div>

            <asp:ListView ID="ListViewEmployees" runat="server">

                <ItemTemplate>
                    <ul>
                        <li>
                            <strong>ID: </strong><%#: Eval("EmployeeID") %>
                        </li>
                        <li>
                            <strong>Last name: </strong><%#: Eval("LastName") %>
                        </li>
                        <li>
                            <strong>First name: </strong><%#: Eval("FirstName") %>
                        </li>
                        <li>
                            <strong>Title: </strong><%#: Eval("Title") %>
                        </li>
                        <li>
                            <strong>Title of courtesy: </strong><%#: Eval("TitleOfCourtesy") %>
                        </li>
                        <li>
                            <strong>Birth date: </strong><%#: Eval("BirthDate") %>
                        </li>
                        <li>
                            <strong>Hire date: </strong><%#: Eval("HireDate") %>
                        </li>
                        <li>
                            <strong>Address: </strong><%#: Eval("Address") %>
                        </li>
                        <li>
                            <strong>City: </strong><%#: Eval("City") %>
                        </li>
                        <li>
                            <strong>Region: </strong><%#: Eval("Region") %>
                        </li>
                        <li>
                            <strong>Postal code: </strong><%#: Eval("PostalCode") %>
                        </li>
                        <li>
                            <strong>Country: </strong><%#: Eval("Country") %>
                        </li>
                        <li>
                            <strong>Home phone: </strong><%#: Eval("HomePhone") %>
                        </li>
                        <li>
                            <strong>Extension: </strong><%#: Eval("Extension") %>
                        </li>
                        <li>
                            <strong>Notes: </strong><%#: Eval("Notes") %>
                        </li>
                        <li>
                            <strong>Photo path: </strong><%#: Eval("PhotoPath") %>
                        </li>
                    </ul>
                </ItemTemplate>

            </asp:ListView>

        </div>
    </form>
</body>
</html>

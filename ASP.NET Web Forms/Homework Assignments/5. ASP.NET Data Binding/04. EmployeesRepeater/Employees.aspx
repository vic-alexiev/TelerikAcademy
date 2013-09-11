<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table, th, td {
            border: 1px solid gray;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="formEmployees" runat="server">
        <div>

            <asp:Repeater ID="RepeaterEmployees" runat="server">

                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Last name</th>
                                <th>First name</th>
                                <th>Title</th>
                                <th>Title of courtesy</th>
                                <th>Birth date</th>
                                <th>Hire date</th>
                                <th>Address</th>
                                <th>City</th>
                                <th>Region</th>
                                <th>Postal code</th>
                                <th>Country</th>
                                <th>Home phone</th>
                                <th>Extension</th>
                                <th>Notes</th>
                                <th>Photo path</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Eval("EmployeeID") %></td>
                        <td><%#: Eval("LastName") %></td>
                        <td><%#: Eval("FirstName") %></td>
                        <td><%#: Eval("Title") %></td>
                        <td><%#: Eval("TitleOfCourtesy") %></td>
                        <td><%#: Eval("BirthDate") %></td>
                        <td><%#: Eval("HireDate") %></td>
                        <td><%#: Eval("Address") %></td>
                        <td><%#: Eval("City") %></td>
                        <td><%#: Eval("Region") %></td>
                        <td><%#: Eval("PostalCode") %></td>
                        <td><%#: Eval("Country") %></td>
                        <td><%#: Eval("HomePhone") %></td>
                        <td><%#: Eval("Extension") %></td>
                        <td><%#: Eval("Notes") %></td>
                        <td><%#: Eval("PhotoPath") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>

        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 148px;
        }
    </style>
</head>
<body>
    <form id="formEmployees" runat="server">
        <div>

            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged" DataKeyNames="Id">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField DataField="FullName" HeaderText="Name" />
                    <asp:CommandField ShowSelectButton="True" />

                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <br />

            <asp:FormView ID="FormViewDetails" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                    <table border="0">
                        <tr>
                            <td class="auto-style1"><strong>ID:</strong></td>
                            <td><%#: Eval("EmployeeID")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Last name:</strong></td>
                            <td><%#: Eval("LastName")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>First name:</strong></td>
                            <td><%#: Eval("FirstName")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Title:</strong></td>
                            <td><%#: Eval("Title")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Title of courtesy:</strong></td>
                            <td><%#: Eval("TitleOfCourtesy")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Birth date:</strong></td>
                            <td><%#: Eval("BirthDate")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Hire date:</strong></td>
                            <td><%#: Eval("HireDate")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Address:</strong></td>
                            <td><%#: Eval("Address")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>City:</strong></td>
                            <td><%#: Eval("City")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Region:</strong></td>
                            <td><%#: Eval("Region")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Postal code:</strong></td>
                            <td><%#: Eval("PostalCode")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Country:</strong></td>
                            <td><%#: Eval("Country")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Home phone:</strong></td>
                            <td><%#: Eval("HomePhone")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Extension:</strong></td>
                            <td><%#: Eval("Extension")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Notes:</strong></td>
                            <td><%#: Eval("Notes")%></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><strong>Photo path:</strong></td>
                            <td><%#: Eval("PhotoPath")%></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            </asp:FormView>
            <br />
            <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Back" />
            <br />

        </div>
    </form>
</body>
</html>

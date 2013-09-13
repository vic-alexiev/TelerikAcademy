<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="World.aspx.cs" Inherits="WorldManagement.World" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Confirm() {
            var confirmValue = document.createElement("input");
            confirmValue.type = "hidden";
            confirmValue.name = "confirm-value";
            if (confirm("Do you want to continue with the operation?")) {
                confirmValue.value = "Yes";
            } else {
                confirmValue.value = "No";
            }

            document.forms[0].appendChild(confirmValue);
        }
    </script>
</head>
<body>
    <form id="formWorld" runat="server">
        <div>
            <fieldset>
                <legend>Continents</legend>
                <asp:ListBox AutoPostBack="true" ID="ListBoxContinents" runat="server" DataSourceID="EntityDataSourceContinents" DataTextField="ContinentName" DataValueField="ContinentId" OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"></asp:ListBox>
                <br />
                <asp:TextBox ID="TextBoxContinentName" MaxLength="20" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonUpdateContinent" runat="server" Text="Update" OnClick="ButtonUpdateContinent_Click" />
                <asp:Button ID="ButtonDeleteContinent" runat="server" OnClick="ButtonDeleteContinent_Click" OnClientClick="Confirm()" Text="Delete" />
                <br />
                <asp:TextBox ID="TextBoxNewContinentName" MaxLength="20" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonAddContinent" runat="server" Text="Add" OnClick="ButtonAddContinent_Click" />
                <br />
                <asp:Label ID="LabelContinentErrors" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server" ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Continents" EntityTypeFilter="Continent">
                </asp:EntityDataSource>
            </fieldset>
            <br />
            <fieldset>
                <legend>Countries</legend>
                <asp:GridView ID="GridViewCountries" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="CountryId" DataSourceID="EntityDataSourceCountries"
                    ItemType="WorldModels.Country" ShowFooter="True" OnRowUpdated="GridViewCountries_RowUpdated" OnRowUpdating="GridViewCountries_RowUpdating" OnRowDataBound="GridViewCountries_RowDataBound" OnRowDeleting="GridViewCountries_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />

                        <asp:TemplateField HeaderText="Country Id" SortExpression="CountryId">
                            <ItemTemplate>
                                <%#: Eval("CountryId")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewCountryId" MaxLength="3" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country Name" SortExpression="CountryName">
                            <ItemTemplate>
                                <%#: Eval("CountryName")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxCountryName" MaxLength="50" runat="server"
                                    Text='<%# Bind("CountryName")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewCountryName" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Latitude" SortExpression="Latitude">
                            <ItemTemplate>
                                <%#: Eval("Latitude")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxLatitude" runat="server"
                                    Text='<%# Bind("Latitude")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewLatitude" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Longitude" SortExpression="Longitude">
                            <ItemTemplate>
                                <%#: Eval("Longitude")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxLongitude" runat="server"
                                    Text='<%# Bind("Longitude")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewLongitude" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Surface Area" SortExpression="SurfaceArea">
                            <ItemTemplate>
                                <%#: Eval("SurfaceArea")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxSurfaceArea" runat="server"
                                    Text='<%# Bind("SurfaceArea")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewSurfaceArea" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" Visible="False" />

                        <asp:TemplateField HeaderText="Population" SortExpression="Population">
                            <ItemTemplate>
                                <%#: Eval("Population")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxPopulation" runat="server"
                                    Text='<%# Bind("Population")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewPopulation" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Continent">
                            <ItemTemplate>
                                <%#: Eval("Continent.ContinentName") %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%#: this.ListBoxContinents.SelectedItem.Text %>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Languages">
                            <ItemTemplate>
                                <%#: string.Join(", ", Item.Languages.Select(l => l.LanguageName)) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxLanguages" runat="server"
                                    Text='<%# string.Join(", ", Item.Languages.Select(l => l.LanguageName))%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxNewLanguages" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Flag">
                            <ItemTemplate>
                                <img src='data:image/png;base64,<%# Eval("FlagImage") != null ? Convert.ToBase64String((byte[])Eval("FlagImage")) : string.Empty %>' alt="flag" height="50" width="100" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:FileUpload ID="FileUploadNewCountryFlag" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:FileUpload ID="FileUploadChangeFlag" runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAddCountry" runat="server" OnClick="ButtonAddCountry_Click" Text="Add" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:Label ID="LabelCountryErrors" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Countries"
                    Include="Continent, Languages" Where="it.ContinentId=@ContinentId">
                    <WhereParameters>
                        <asp:ControlParameter Name="ContinentId" Type="Int32"
                            ControlID="ListBoxContinents" />
                    </WhereParameters>
                </asp:EntityDataSource>
            </fieldset>
            <br />
            <fieldset>
                <legend>Cities</legend>
                <asp:ListView ID="ListViewCities" runat="server" DataKeyNames="CityId" DataSourceID="EntityDataSourceCities" InsertItemPosition="LastItem" OnItemInserting="ListViewCities_ItemInserting" OnItemDeleting="ListViewCities_ItemDeleting" OnItemUpdating="ListViewCities_ItemUpdating">
                    <AlternatingItemTemplate>
                        <tr style="background-color: #FFF8DC;">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            </td>
                            <td>
                                <asp:Label ID="CityNameLabel" runat="server" Text='<%#: Eval("CityName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LatitudeLabel" runat="server" Text='<%#: Eval("Latitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LongitudeLabel" runat="server" Text='<%#: Eval("Longitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <tr style="background-color: #008A8C; color: #FFFFFF;">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                            </td>
                            <td>
                                <asp:TextBox ID="CityNameTextBox" MaxLength="50" runat="server" Text='<%# Bind("CityName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LatitudeTextBox" runat="server" Text='<%# Bind("Latitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LongitudeTextBox" runat="server" Text='<%# Bind("Longitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            </td>
                            <td>
                                <asp:TextBox ID="CityNameTextBox" runat="server" MaxLength="50" Text='<%# Bind("CityName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LatitudeTextBox" runat="server" Text='<%# Bind("Latitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LongitudeTextBox" runat="server" Text='<%# Bind("Longitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DCDCDC; color: #000000;">
                            <td>
                                <asp:Button ID="DeleteButton" OnClientClick="Confirm()" runat="server" CommandName="Delete" Text="Delete" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            </td>
                            <td>
                                <asp:Label ID="CityNameLabel" runat="server" Text='<%#: Eval("CityName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LatitudeLabel" runat="server" Text='<%#: Eval("Latitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LongitudeLabel" runat="server" Text='<%#: Eval("Longitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                            <th runat="server"></th>
                                            <th runat="server">City Name</th>
                                            <th runat="server">Latitude</th>
                                            <th runat="server">Longitude</th>
                                            <th runat="server">Population</th>
                                            <th runat="server">Country</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            </td>
                            <td>
                                <asp:Label ID="CityNameLabel" runat="server" Text='<%#: Eval("CityName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LatitudeLabel" runat="server" Text='<%#: Eval("Latitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LongitudeLabel" runat="server" Text='<%#: Eval("Longitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:Label ID="LabelCityErrors" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:EntityDataSource ID="EntityDataSourceCities" runat="server" ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Cities" EntityTypeFilter="City"
                    Where="it.CountryId=@CountryId" Include="Country">
                    <WhereParameters>
                        <asp:ControlParameter Name="CountryId" Type="String"
                            ControlID="GridViewCountries" />
                    </WhereParameters>
                </asp:EntityDataSource>
            </fieldset>
        </div>
    </form>
</body>
</html>

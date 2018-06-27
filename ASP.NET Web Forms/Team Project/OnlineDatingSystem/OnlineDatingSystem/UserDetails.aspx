<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserDetails.aspx.cs" Inherits="OnlineDatingSystem.UserDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:FormView runat="server"
        ID="UserDetailsFormView"
        ItemType="OnlineDatingSystem.Models.ApplicationUser"
        DataKeyNames="Id"
        SelectMethod="UserDetailsFormView_GetUserInfo"
        UpdateMethod="UserDetailsFormView_UpdateUserInfo"
        OnDataBound="UserDetailsFormView_PreEditCommand">
        <ItemTemplate>
            <div class="container container-fluid">
                <div class="row">
                    <div class="span4">
                        <img class="detailed-profile-pic" src='data:image/png;base64,<%# Item.Photo != null ? Convert.ToBase64String(Item.Photo) : string.Empty %>' alt="photo" height="400" width="400" />
                        <asp:Panel runat="server" ID="FileUploadContainer">
                            <asp:FileUpload ID="ProfilePhotoFileUpload" runat="server" />
                            <asp:LinkButton ID="UploadProfileImage" OnClick="UploadProfileImage_OnClick" CssClass="ProfileButton SavePhotoButton" Text="Save" runat="server" />
                        </asp:Panel>
                    </div>
                    <div class="span6">
                        <div class="well">
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="MainName" ID="FirstNameTb" Text="<%#: Item.FirstName %>"></asp:Label>
                                <asp:Label runat="server" CssClass="MainName" ID="LastNameTb" Text="<%#: Item.LastName %>"></asp:Label>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Sex: "></asp:Label>
                                <asp:Literal runat="server" ID="SexTb" Text="<%#: Item.Sex %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Looking for: "></asp:Label>
                                <asp:Literal runat="server" ID="LookingForTb" Text="<%#: Item.LookingFor %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Description: "></asp:Label>
                                <asp:Literal runat="server" ID="DescriptionTb" Text="<%#: Item.Description %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Reason: "></asp:Label>
                                <asp:Literal runat="server" ID="ReasonTb" Text="<%#: Item.Reason.Name %>"></asp:Literal>
                            </div>
                        </div>
                        <div class="well">
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Username: "></asp:Label>
                                <asp:Literal runat="server" ID="UserNameTb" Mode="Encode" Text="<%#: Item.UserName %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Email: "></asp:Label>
                                <asp:Literal runat="server" ID="EmailTb" Text="<%#: Item.Email %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Phone: "></asp:Label>
                                <asp:Literal runat="server" ID="PhoneTb" Text="<%#: Item.Phone %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Birthdate: "></asp:Label>
                                <asp:Literal runat="server" ID="BirthDateTb" Text="<%#: Item.BirthDate %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Country: "></asp:Label>
                                <asp:Literal runat="server" ID="CountryTb" Text="<%#: Item.Country.Name %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="City: "></asp:Label>
                                <asp:Literal runat="server" ID="CityTb" Text="<%#: Item.City.Name %>"></asp:Literal>
                            </div>

                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Education: "></asp:Label>
                                <asp:Literal runat="server" ID="EducationTb" Text="<%#: Item.Education.Name %>"></asp:Literal>
                            </div>
                        </div>
                        <div>
                            <asp:LinkButton ID="EditUserDetailsButton" CssClass="ProfileButton" CommandName="Edit" Text="Edit" runat="server"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="container container-fluid">
                <div class="row">
                    <div class="span4">
                        <img class="detailed-profile-pic" src='data:image/png;base64,<%# Item.Photo != null ? Convert.ToBase64String(Item.Photo) : string.Empty %>' alt="photo" height="400" width="400" />
                    </div>
                    <div class="span4">
                        <div class="well form-horizontal rightAlign">
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="First name: "></asp:Label>
                                <asp:TextBox runat="server" ID="FirstNameTb" Text="<%#: BindItem.FirstName %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Last name: "></asp:Label>
                                <asp:TextBox runat="server" ID="LastNameTb" Text="<%#: BindItem.LastName %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Sex: "></asp:Label>
                                <asp:TextBox runat="server" ID="SexTb" Text="<%#: BindItem.Sex %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Looking for: "></asp:Label>
                                <asp:TextBox runat="server" ID="LookingForTb" Text="<%#: BindItem.LookingFor %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Description: "></asp:Label>
                                <asp:TextBox runat="server" ID="DescriptionTb" Text="<%#: BindItem.Description %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Reason: "></asp:Label>
                                <asp:DropDownList runat="server" ID="EditReasonTb"
                                    DataTextField="Name"
                                    DataValueField="Id">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="well rightAlign">
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Username: "></asp:Label>
                                <asp:Literal runat="server" ID="EditUserNameTb" Text="<%#: BindItem.UserName %>"></asp:Literal>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Email: "></asp:Label>
                                <asp:TextBox runat="server" ID="EmailTb" Text="<%#: BindItem.Email %>"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidatorEmail"
                                    runat="server" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Email address is incorrect!"
                                    ControlToValidate="EmailTb" EnableClientScript="False"
                                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Phone: "></asp:Label>
                                <asp:TextBox runat="server" ID="PhoneTb" Text="<%#: BindItem.Phone %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Birthdate: "></asp:Label>
                                <asp:TextBox runat="server" ID="BirthDateTb" Text="<%#: BindItem.BirthDate %>"></asp:TextBox>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Country: "></asp:Label>
                                <asp:DropDownList runat="server" ID="EditCountryTb"
                                    AutoPostBack="True"
                                    DataTextField="Name"
                                    DataValueField="Id"
                                    OnSelectedIndexChanged="EditCountryTb_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="City: "></asp:Label>
                                <asp:DropDownList runat="server" ID="EditCityTb"
                                    DataTextField="Name"
                                    DataValueField="Id">
                                </asp:DropDownList>
                            </div>
                            <div class="user-item">
                                <asp:Label runat="server" CssClass="InfoLabel" Text="Education: "></asp:Label>
                                <asp:DropDownList runat="server" ID="EditEducationTb"
                                    DataTextField="Name"
                                    DataValueField="Id">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <asp:LinkButton ID="UpdateUserDetailsButton" CssClass="ProfileButton" CommandName="Update" Text="Save" runat="server" />
                            <asp:LinkButton ID="CancelUserDetailsButton" CssClass="ProfileButton" CommandName="Cancel" Text="Cancel" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUserEdit.aspx.cs" Inherits="OnlineDatingSystem.Administrator.AdminUserEdit" %>

<asp:Content ID="AdminUserContent" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <asp:ScriptManager runat="server" ID="ScriptManager" />--%>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <asp:Button runat="server" OnClick="ChangeUser_Click" Text="Save changes" CssClass="btn btn-primary"/>
    <a href="AdministratorDefault.aspx" class="btn btn-info">Back to main admin window</a>
    <div class="row-fluid">
        
        <div class="form-horizontal span4">

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="FileUploadPhoto" CssClass="control-label" ID="LabelPhoto">Change user photo</asp:Label>
                <div class="controls">
                    <asp:FileUpload ID="FileUploadPhoto" runat="server" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="DropDownListRole" CssClass="control-label" ID="Label1">User Role type:</asp:Label>
                <div class="controls">
                    <asp:DropDownList runat="server" ID="DropDownListRole" 
                        ItemType="OnlineDatingSystem.Data.ApplicationDbContext.UserRole"
                        DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxUserName" CssClass="control-label">Username</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxUserName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUserName"
                        CssClass="text-error" ErrorMessage="The user name field is required." />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxFirstName" CssClass="control-label" ID="LabelFirstName">First name</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxFirstName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFirstName"
                        CssClass="text-error" ErrorMessage="The First Name field is required." ID="RequiredFieldValidatorFirstName" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxLastName" CssClass="control-label" ID="LabelLastName">Last name</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxLastName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLastName"
                        CssClass="text-error" ErrorMessage="The Last Name field is required." ID="RequiredFieldValidatorLastName" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="control-label" ID="LabelEmail">Email</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxEmail" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                        CssClass="text-error" ErrorMessage="The Email field is required." ID="RequiredFieldValidatorEmail" />
                    <asp:RegularExpressionValidator ID="validateEmail" runat="server" ErrorMessage="Invalid email."
                        ControlToValidate="TextBoxEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ForeColor="Red" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxPhone" CssClass="control-label" ID="LabelPhone">Phone</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxPhone" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPhone"
                        CssClass="text-error" ErrorMessage="The phone field is required." ID="RequiredFieldValidatorPhone" />
                </div>
            </div>

        </div>

        <div class="form-horizontal span4">
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="DropDownListSex" CssClass="control-label" ID="LabelSex">Sex</asp:Label>
                <div class="controls">
                    <asp:DropDownList runat="server" ID="DropDownListSex">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="N">Not specified</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListSex"
                        CssClass="text-error" ErrorMessage="The sex field is required." ID="RequiredFieldValidatorSex" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="DropDownListReason" CssClass="control-label" ID="LabelReason">Reason</asp:Label>
                <div class="controls">
                    <asp:DropDownList runat="server" ID="DropDownListReason"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListReason"
                        CssClass="text-error" ErrorMessage="The reason field is required." ID="RequiredFieldValidatorReason" />
                </div>
            </div>

            
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxBirthDate" CssClass="control-label" ID="LabelBirthDate">Birth date (dd-MM-yyyy)</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxBirthDate"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxBirthDate"
                        CssClass="text-error" ErrorMessage="The birth date is required." ID="RequiredFieldValidatorBirthDate" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="DropDownListCountry" CssClass="control-label" ID="LabelCountry">Country</asp:Label>
                        <div class="controls">
                            <asp:DropDownList runat="server" ID="DropDownListCountry" 
                                OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged"
                                AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListCountry"
                                CssClass="text-error" ErrorMessage="The country field is required." ID="RequiredFieldValidatorCountry" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" Id="UpdatePanelCities" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="control-group">
                        <asp:Label runat="server" 
                            AssociatedControlID="DropDownListCity" 
                            CssClass="control-label" 
                            ID="LabelCity">City</asp:Label>
                        <div class="controls">
                            <asp:DropDownList runat="server" ID="DropDownListCity"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListCity"
                                CssClass="text-error" ErrorMessage="The city field is required." ID="RequiredFieldValidatorCity" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="DropDownListLookingFor" CssClass="control-label" ID="LabelLookingFor">Looking for</asp:Label>
                <div class="controls">
                    <asp:DropDownList runat="server" ID="DropDownListLookingFor">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="B">Both</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListLookingFor"
                        CssClass="text-error" ErrorMessage="The Looking for field is required." ID="RequiredFieldValidatorLookingFor" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="DropDownListEducation" CssClass="control-label" ID="LabelEducation">Education</asp:Label>
                <div class="controls">
                    <asp:DropDownList runat="server" ID="DropDownListEducation"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListEducation"
                        CssClass="text-error" ErrorMessage="The education field is required." ID="RequiredFieldValidatorEducation" />
                </div>
            </div>
        </div>

        <div class="form-horizontal span4">
          

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxDescription" CssClass="control-label" ID="LabelDescription">Description</asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="TextBoxDescription" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxDescription"
                        CssClass="text-error" ErrorMessage="The description field is required." ID="RequiredFieldValidatorDescription" />
                </div>
            </div>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="CheckBoxListInterests" CssClass="control-label" ID="LabelInterests">Interests</asp:Label>
                <div class="controls">
                    <asp:CheckBoxList runat="server" ID="CheckBoxListInterests"></asp:CheckBoxList>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

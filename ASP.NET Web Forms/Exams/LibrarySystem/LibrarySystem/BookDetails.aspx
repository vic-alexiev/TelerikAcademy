<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1>Book Details</h1>
        <p class="book-title" ID="LabelBookTitle" runat="server"></p>
        <p class="book-author" ID="LabelBookAuthor" runat="server"></p>
        <p class="book-isbn" ID="LabelBookIsbn" runat="server"></p>
        <asp:Label CssClass="book-isbn" ID="LabelBookWebSite" runat="server">Web site:</asp:Label>
        <asp:LinkButton ID="LinkButtonBookWebSite" runat="server"></asp:LinkButton>
    </header>
    <div>
        <asp:Label CssClass="book-description" ID="LabelBookDescription" runat="server"></asp:Label>
    </div>
</asp:Content>

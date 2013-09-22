<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheableUserControl.ascx.cs" Inherits="_01.Caching.CacheableUserControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>

<h1>I am a cacheable user control.</h1>
<h2>My time is <%= DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") %></h2>

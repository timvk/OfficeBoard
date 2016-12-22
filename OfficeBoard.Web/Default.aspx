<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OfficeBoard.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <div class="loginRegister centered">
                <h4> Welcome,</h4>
                <br />
                <p>you can <a href="~/Account/Register" runat="server" >Register</a> or <a href="~/Account/Login" runat="server">Login</a> </p>  
            </div>                     
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="loginRegister centered">
               <h4>WELCOME,</h4> 
                <br/>
                You can check the office notes from <a href="~/OfficeNotes" runat="server">here</a>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

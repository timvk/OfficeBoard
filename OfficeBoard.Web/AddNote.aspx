<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNote.aspx.cs" Inherits="OfficeBoard.Web.AddNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {

            function ViewModel() {
                var self = this;

                self.title = ko.observable();
                self.content = ko.observable();
                self.addNote = function () {

                    window.location.href = "/OfficeNotes";
                    requester.post('api/notes/AddNote', { Title: self.title(), Content: self.content() })
                        .then(function (resp) {
                            console.log(resp);
                        }, function (err) {
                            console.log(err);
                        });
                };
            }

            var vm = new ViewModel();
            ko.applyBindings(vm);
        })
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <div class="loginRegister centered">
                <h4> Welcome,</h4>
                <p>you can <a href="~/Account/Register" runat="server" >Register</a> or <a href="~/Account/Login" runat="server">Login</a> </p>  
            </div>                     
        </AnonymousTemplate>
        <LoggedInTemplate>         
            <div class="loginRegister">
                <h1>Add new note</h1>
                <input ID="hiddenField" type="hidden" runat="server" />
                <label for="title">Title:</label>
                <input type="text" data-bind="value: title"/>
                <br />
                <label for="text">Content:</label>
                <input type="text" data-bind="value: content"/>
                <br />
                <a href="/OfficeNotes" id="add-note" data-bind="click: addNote" class="btn btn-default">Add note</a>
                <%--<a href="#/home/"><button>Cancel</button></a>--%>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

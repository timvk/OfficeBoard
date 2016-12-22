<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficeNotes.aspx.cs" Inherits="OfficeBoard.Web.OfficeNotes" %>

<asp:Content ID="Scripts" ContentPlaceHolderID="head" runat="server">
    <link href="Content/simplePagination.css" rel="stylesheet" />
    <script src="Scripts/jquery.simplePagination.js"></script>
    <script>
        $(function () {
            var notes;

            function ViewModel() {
                var self = this;
                self.notes = ko.observableArray();
                self.canEdit = ko.observable(false);
                self.getTodays = function () {
                    self.canEdit(false);
                    requester.get("api/notes/GetTodaysNotes")
                    .then(function (resp) {
                        self.notes(resp);
                        console.log(resp);
                        $('#pagination').pagination('updateItems', self.notes().length);
                    });
                };

                self.getOld = function () {
                    self.canEdit(false);
                    requester.get("api/notes/GetOld")
                    .then(function (resp) {
                        self.notes(resp);
                        console.log(resp);
                        $('#pagination').pagination('updateItems', self.notes().length);
                    });
                };

                self.getMine = function () {
                    self.canEdit(true);
                    requester.get("api/notes/GetOwnNotes")
                    .then(function (resp) {
                        self.notes(resp);
                        console.log(resp);
                        $('#pagination').pagination('updateItems', self.notes().length);
                    });
                }
            };

            var vm = new ViewModel();
            
            requester.get("api/notes/GetTodaysNotes")
            .then(function (resp) {
                vm.notes(resp);
                console.log(vm.notes());
            });

            ko.applyBindings(vm);

            $('#pagination').pagination({
                items: vm.notes().length,
                itemsOnPage: 6,
                cssStyle: 'light-theme'
            });

        });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <div class="loginRegister centered">
                <h4> Welcome,</h4>
                <p>you can <a href="~/Account/Register" runat="server" >Register</a> or <a href="~/Account/Login" runat="server">Login</a> </p>  
            </div>                     
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="mainbrd">
                <div class="notesContainer">
                    <ul class="listItems" data-bind="foreach: notes">
                        <li class="item">
                            <a href="#"> 
                                <div class="note"> 
                                    <div>                             
                                        <h5 data-bind="text: Title"></h5>
                                        <p data-bind="text: Content"></p>
                                    </div>
                                    <div class="noteFooter">
                                        <p data-bind="text: DateAdded"></p>
                                        <p data-bind="text: Author"></p>
                                    </div>
                                    <div class="some-btns" data-bind="visible: $parent.canEdit">
                                        <button id="edit-btn"></button>
                                        <button id="delete-btn"></button>
                                    </div>
                                </div>                    
                            </a>
                        </li>
                    </ul>
                    <div class="side-btns">
                        <button id="todaysNotes" data-bind="click: getTodays" class="btn btn-default">Today's Notes</button>
                        <button id="oldNotes" data-bind="click: getOld" class="btn btn-default">Old Notes</button>
                        <button id="myNotes" data-bind="click: getMine" class="btn btn-default">My Notes</button>
                    </div>
                </div>
                <div id="pagination"></div>
            </div>            
        </LoggedInTemplate>
    </asp:LoginView>  
</asp:Content>

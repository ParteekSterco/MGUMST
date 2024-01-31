<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="backoffice_homebanner_test" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script language="javascript" type="text/javascript">
       //this script will get the date selected from the given calendarextender (ie: "sender") and append the
       //current time to it.
       function AppendTime(sender, args) {
           var selectedDate = new Date();
           selectedDate = sender.get_selectedDate();
           var now = new Date();
           sender.get_element().value = selectedDate.format("MM/dd/yyyy") + " " + now.format("hh:mm:ss tt");
       }
    </script>
    <h2>
        Add Home Banner</h2>
    <div class="content-panel">
        <asp:TextBox ID="bannerstartdate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                         <img src="/images/icon-calender.png" width="18" height="18" alt="" runat="server"
                                                    id="Img1" />
                       
                             <ajaxToolkit:CalendarExtender ID="ce1" runat="server" PopupButtonID="calImg" Enabled="true" Format="dd/MM/yyyy" TargetControlID="bannerstartdate" PopupPosition="TopRight" OnClientDateSelectionChanged="AppendTime"></ajaxToolkit:CalendarExtender>
    </div>
</asp:Content>

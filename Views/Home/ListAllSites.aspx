<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HIO.Models.place>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListAllSites
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ListAllSites</h2>

    <table>
        <tr>
            <th></th>
            <th>
                PID
            </th>
            <th>
                LatVal
            </th>
            <th>
                LongVal
            </th>
            <th>
                Name
            </th>
            <th>
                Flag
            </th>
            <th>
                UserID
            </th>
            <th>
                Town
            </th>
            <th>
                Username
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.PID }) %> |
                <%: Html.ActionLink("Comments", "Comments", new { id=item.PID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.PID })%>
            </td>
            <td>
                <%: item.PID %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.LatVal) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.LongVal) %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Flag %>
            </td>
            <td>
                <%: item.UserID %>
            </td>
            <td>
                <%: item.Town %>
            </td>
            <td>
                <%: item.Username %>
            </td>
        </tr>
    <div id="comments"<%=item.PID %>>
            <% foreach (var comment in Model.First().AllComments(item.PID)) { %>

    
       <p><%=comment.Comment1 %></p>
       
    
    <% } %>
     </div>
      <% } %>
    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageTitleContent" runat="server">
</asp:Content>


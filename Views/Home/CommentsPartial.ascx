<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HIO.Models.comment>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                CID
            </th>
            <th>
                PlaceID
            </th>
            <th>
                Comment1
            </th>
            <th>
                UserID
            </th>
            <th>
                Datetime
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.CID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.CID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.CID })%>
            </td>
            <td>
                <%: item.CID %>
            </td>
            <td>
                <%: item.PlaceID %>
            </td>
            <td>
                <%: item.Comment1 %>
            </td>
            <td>
                <%: item.UserID %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Datetime) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>



<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
            <% foreach (var department in ((IEnumerable<Department>)Context.Items["blah"])) { %>
            <tr class="ListItem">
                <td>
                    <% if (department.has_sub_departments)
                       {%>
                    <a href="ViewSubDepartments?d=<%= department.name %>"><%=department.name%></a>
                    <%
                        }
                       else
{%>
                    <a href="ViewProducts?d=<%= department.name %>"><%=department.name%></a>
<%
}%>
                </td>
            </tr>        
            <% } %>
        </table>            
</asp:Content>

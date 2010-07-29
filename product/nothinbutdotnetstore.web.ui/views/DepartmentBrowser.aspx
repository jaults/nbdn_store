<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" MasterPageFile="Store.master" 
CodeFile="DepartmentBrowser.aspx.cs"%>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
            <% foreach (var department in this.display_model) { %>
            <tr class="ListItem">
                <td>

                    <%= Link<Department>().when(x => x.has_sub_departments, "ViewSubDepartments")
                                          .when(x => !x.has_sub_departments, "ViewProducts")
                                          .render(department) %>


                    <% if (department.has_sub_departments)
                       {%>
                    <a href="/dept.store/ViewSubDepartments?d=<%= department.name %>"><%=department.name%></a>
                    <%
                        }
                       else
{%>
                    <a href="/dept.store/ViewProducts?d=<%= department.name %>"><%=department.name%></a>
<%
}%>
                </td>
            </tr>        
            <% } %>
        </table>            
</asp:Content>

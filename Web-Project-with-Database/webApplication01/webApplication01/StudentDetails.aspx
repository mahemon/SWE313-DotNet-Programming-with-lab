<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="webApplication01.StudentDetails" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">
     <div>
       <table>
                <tr>
                    <td>

                        <asp:Label ID="lbl" runat="server" Text="ID"></asp:Label>

                    </td>
                    <td>

                        <asp:Label ID="lblID" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="dddd" runat="server" Text="Name"></asp:Label>

                    </td>
                    <td>

                         <asp:Label ID="lblName" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="Label3" runat="server" Text="Father Name"></asp:Label>

                    </td>
                    <td>

                          <asp:Label ID="lblFName" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="Label1" runat="server" Text="Mother Name"></asp:Label>

                    </td>
                    <td>

                          <asp:Label ID="lblMName" runat="server"></asp:Label>

                    </td>
                </tr>


                <tr>
                    <td>

                        <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>

                    </td>
                    <td>

                        <asp:Label ID="lblAddress" runat="server"></asp:Label>

                    </td>
                </tr>
            </table>
    </div>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="webApplication01.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">
    <table>
       <tr>
           <td>
               <asp:Label ID="lblMessage" runat="server" />
           </td>
       </tr>
         <tr>
            <td>
                <asp:Label ID="adsfasd" Text="User Name" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxUserName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" Text="Password" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" />
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Button ID="btnLogIn" Text="LogIn" runat="server" OnClick="btnLogIn_Click"  />
            </td>
        </tr>
    </table>
</asp:Content>

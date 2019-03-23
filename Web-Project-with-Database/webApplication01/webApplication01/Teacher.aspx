<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="webApplication01.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">

    <table>
        <tr>
            <td>
                ID
            </td>
            <td>
              
                <asp:TextBox ID="tbxID" runat="server"></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
              
                <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td>
                Designation
            </td>
            <td>
              
                <asp:TextBox ID="tbxDes" runat="server"></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>


                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />


            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="TID" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="TID" HeaderText="TID" ReadOnly="True" />
            <asp:BoundField DataField="TName" HeaderText="TName"  />
            <asp:BoundField DataField="Designation" HeaderText="Designation" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversitySystemConnectionString2 %>" SelectCommand="SELECT * FROM [Teacher] ORDER BY [TID]"></asp:SqlDataSource>--%>
    <br />




</asp:Content>

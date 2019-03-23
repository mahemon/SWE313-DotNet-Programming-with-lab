<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="CourseAssign.aspx.cs" Inherits="webApplication01.CourseAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">

    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div>
        <table>

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Course"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server" DataSourceID="SqlDataSourceCourse" DataTextField="Title" DataValueField="CCode">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceCourse" runat="server" ConnectionString="<%$ ConnectionStrings:UniversitySystemConnectionString %>" SelectCommand="SELECT [Title], [CCode] FROM [Course] ORDER BY [CCode], [Title]"></asp:SqlDataSource>
                </td>
            </tr>

            <tr>
                <td>

                    <asp:Label ID="Label2" runat="server" Text="Student"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList Width="120px" Height="25px" runat="server" ID="ddlStudent" DataValueField="ID" DataTextField="Name" />
                </td>
            </tr>

            <tr>
               <td></td> <td  class="auto-style1">
                    <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="gvCT" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="Both" Width="271px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="CCode" HeaderText="Code" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Credit" HeaderText="Credit" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="Delete" ID="btnDelete" runat="server" CommandArgument='<%# Eval("TKID") %>' OnCommand="btnDelete_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />

        </asp:GridView>
    </div>
</asp:Content>

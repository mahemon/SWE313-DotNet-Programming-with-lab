<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="webApplication01.Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">

    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>

                    <asp:Label ID="lbl" runat="server" Text="Course Code"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxCCode" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="lblTitle" runat="server" Text="Course Title"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxTitle" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label3" runat="server" Text="Credit Hours"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxCredit" runat="server"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvCourse" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="271px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="CCode" HeaderText="Course Code" />
                <asp:BoundField DataField="Title" HeaderText="Course Title" />
                <asp:BoundField DataField="Credit" HeaderText="Credit Hours" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="Edit" ID="btnEdit" runat="server" CommandArgument='<%# Eval("CCode") %>' OnCommand="btnEdit_Command" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="Delete" ID="btnDelete" runat="server" CommandArgument='<%# Eval("CCode") %>' OnCommand="btnDelete_Command" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSourceADO" runat="server" ConnectionString="<%$ ConnectionStrings:ADOSampleDBConnectionString %>" SelectCommand="SELECT * FROM [StudentInfo]"></asp:SqlDataSource>--%>
    </div>
</asp:Content>

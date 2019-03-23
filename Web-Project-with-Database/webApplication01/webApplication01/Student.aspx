<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs"
    Inherits="webApplication01.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <div>
        <table>
            <tr>
                <td>

                    <asp:Label ID="lbl" runat="server" Text="ID"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxID" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="t" runat="server" Text="Name"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label3" runat="server" Text="Father Name"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxFName" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label1" runat="server" Text="Mother Name"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxMName" runat="server"></asp:TextBox>

                </td>
            </tr>


            <tr>
                <td>

                    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="tbxAddress" runat="server"></asp:TextBox>

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
        <asp:GridView ID="gvStudent" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="271px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="FName" HeaderText="FName" />
                <asp:BoundField DataField="MName" HeaderText="MName" />
                <asp:BoundField DataField="Address" HeaderText="Address" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="Edit" ID="btnEdit" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="btnEdit_Command" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="Delete" ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="btnDelete_Command" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" Text="Details" PostBackUrl='<%# String.Concat("~/StudentDetails.aspx?ID=", Eval("ID").ToString()) %>'
                            runat="server" />
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


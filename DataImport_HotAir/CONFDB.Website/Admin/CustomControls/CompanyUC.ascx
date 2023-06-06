<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompanyUC.ascx.cs" Inherits="CompanyUC" %>
<%--NOTE: This is a custom control used to display and Add Company all in one control.
--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <%--Hidden control used to pass value to NetTiers Typed DataSource control or between page postbacks.
        <asp:Label Visible="false" ID="lblCompanyID" runat="server" />
        --%>
        <asp:DropDownList runat="server" ID="dataCompanyId"
            DataTextField="Description" DataValueField="Id" ToolTip="Select a company or add a new company."
        />

        OR &nbsp
        <asp:TextBox ID="txtNewCompany" runat="server" ToolTip="Add new company" Width="200px"></asp:TextBox>
        <asp:LinkButton ID="btnAddNewCompany" runat="server" Text="Add New" ToolTip="Add new company" OnClick="btnAddNewCompany_Click" CausesValidation="false"/>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="ErrorMessage" Visible="false"></asp:Label>
        </ContentTemplate>                        
    </asp:UpdatePanel>

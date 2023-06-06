<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DNISModerator.ascx.cs" Inherits="DNISModerator" %>
<asp:UpdatePanel ID="UpdatePanelDNISModerator" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelDNISModerator" 
            DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
            <div class="">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" /> Please Wait...
            </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    
        <%--Hidden control used to pass value to NetTiers Typed DataSource control.--%>
        <asp:Label Visible="false" ID="lblModeratorID" runat="server" />
        <data:EntityGridView ID="GridViewDnisModerator" runat="server" SkinID="CustomGrid"
            AutoGenerateColumns="False" DataSourceID="DnisDataSourceModerator" DataKeyNames="Id"
            AllowMultiColumnSorting="false" ExcelExportFileName="Export_Dnis.xls" OnSelectedIndexChanged="GridViewDnisModerator_SelectedIndexChanged"
            Visible="<%# this.Visible %>" Enabled="<%# this.Enabled %>">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Save" />
                <data:HyperLinkField HeaderText="Dnis Type" DataContainer="DnisTypeIdSource" DataTextField="Name" />
                <asp:TemplateField HeaderText="DNIS">
                    <itemtemplate>                 
                        <asp:DropDownList ID="ddlDNIS" runat="server" DataSource='<%# GetDNISByDNISTypeID(Eval("DnisTypeID").ToString()) %>' DataValueField="DNISID" DataTextField="DDLInfo" SelectedValue='<%# Eval("ID").ToString() %>' />
                        <asp:Label Visible="false" ID="lblDNISTypeID" runat="server" Text='<%# Eval("DnisTypeID") %>'/> <%--Hidden value used in Update--%>
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <b>No Dnis Found! </b>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:DnisDataSource ID="DnisDataSourceModerator" runat="server" SelectMethod="GetByModeratorIdFromModerator_Dnis"
            EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:DnisProperty Name="DnisType" />
                    <data:DnisProperty Name="PromptSet" />
                    <data:DnisProperty Name="CallFlow" />
                    <%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
                    <%--<data:DnisProperty Name="Moderator_DnisCollection" /> //Load data from Mod/Dnis table by DNISID --%>
                    <%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
                    <%--<data:DnisProperty Name="Moderator_DnisCollection" />--%>
                    <%--//Load data from Cust/Dnis table by DNISID--%>
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <%--NetTiers Controls don't handle the <%# this.ModeratorID %> syntax correctly used a ControlParameter so use a hidden control.--%>
                <asp:ControlParameter Name="ModeratorId" ControlID="lblModeratorID" PropertyName="Text"
                    Type="int32" />
                <%--<data:CustomParameter Name="ModeratorId" Value='14' Type="int32" ConvertEmptyStringToNull="false" />--%>
                <data:CustomParameter Name="OrderBy" Value="DNISTypeID, DisplayOrder" ConvertEmptyStringToNull="false" />
            </Parameters>
        </data:DnisDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
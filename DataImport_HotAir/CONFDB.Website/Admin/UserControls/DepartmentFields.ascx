<%@ Control Language="C#" ClassName="DepartmentFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><%--<asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler" AssociatedControlID="dataWholesalerId" />--%></td>
        <td>
					<data:EntityDropDownList visible="false" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
                        <Parameters>
                            <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
                        </Parameters>
                    </data:WholesalerDataSource>
				</td>
			</tr>

			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer:" AssociatedControlID="dataCustomerId" /></td>
            <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerDataSource1" DataTextField="DDLDescription" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:Vw_CustomerListDataSource ID="CustomerDataSource1" runat="server" SelectMethod="Get">
                        <Parameters>
                            <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID" Type="string">
                            </data:SqlParameter>
                            <data:CustomParameter Name="OrderBy" Value="CompanyName,PriCustomerNumber" ConvertEmptyStringToNull="false" />
                        </Parameters>					
					</data:Vw_CustomerListDataSource>
					
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
<%--			<tr>
        <td class="literal"><asp:Label ID="lbldataParentId" runat="server" Text="Parent Id:" AssociatedControlID="dataParentId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataParentId" Text='<%# Bind("ParentId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataParentId" runat="server" Display="Dynamic" ControlToValidate="dataParentId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>--%>
			
		</table>

	</ItemTemplate>
</asp:FormView>



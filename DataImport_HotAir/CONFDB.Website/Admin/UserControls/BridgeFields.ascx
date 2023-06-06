<%@ Control Language="C#" ClassName="BridgeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIpAddress" runat="server" Text="Ip Address:" AssociatedControlID="dataIpAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIpAddress" Text='<%# Bind("IpAddress") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebRequestSecurityToken" runat="server" Text="Web Request Security Token:" AssociatedControlID="dataWebRequestSecurityToken" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebRequestSecurityToken" Text='<%# Bind("WebRequestSecurityToken") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebRequestApiurl" runat="server" Text="Web Request Apiurl:" AssociatedControlID="dataWebRequestApiurl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebRequestApiurl" Text='<%# Bind("WebRequestApiurl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebRequestMethod" runat="server" Text="Web Request Method:" AssociatedControlID="dataWebRequestMethod" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebRequestMethod" Text='<%# Bind("WebRequestMethod") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebRequestContentType" runat="server" Text="Web Request Content Type:" AssociatedControlID="dataWebRequestContentType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebRequestContentType" Text='<%# Bind("WebRequestContentType") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassword" runat="server" Text="Password:" AssociatedControlID="dataPassword" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBridgeTypeId" runat="server" Text="Bridge Type Id:" AssociatedControlID="dataBridgeTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataBridgeTypeId" DataSourceID="BridgeTypeIdBridgeTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("BridgeTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:BridgeTypeDataSource ID="BridgeTypeIdBridgeTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDbConnectionString" runat="server" Text="Db Connection String:" AssociatedControlID="dataDbConnectionString" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDbConnectionString" Text='<%# Bind("DbConnectionString") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



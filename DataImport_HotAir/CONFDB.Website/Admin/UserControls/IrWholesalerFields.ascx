<%@ Control Language="C#" ClassName="IrWholesalerFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLanguageId" runat="server" Text="Language Id:" AssociatedControlID="dataLanguageId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLanguageId" DataSourceID="LanguageIdLanguageDataSource" DataTextField="DisplayName" DataValueField="Id" SelectedValue='<%# Bind("LanguageId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LanguageDataSource ID="LanguageIdLanguageDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIrCustomerId" runat="server" Text="Ir Customer Id:" AssociatedControlID="dataIrCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIrCustomerId" Text='<%# Bind("IrCustomerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIrCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataIrCustomerId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalDnis" runat="server" Text="Local Dnis:" AssociatedControlID="dataLocalDnis" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalDnis" Text='<%# Bind("LocalDnis") %>' MaxLength="36"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalDialNumber" runat="server" Text="Local Dial Number:" AssociatedControlID="dataLocalDialNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalDialNumber" Text='<%# Bind("LocalDialNumber") %>' MaxLength="36"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalAccessType" runat="server" Text="Local Access Type:" AssociatedControlID="dataLocalAccessType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalAccessType" Text='<%# Bind("LocalAccessType") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLocalAccessType" runat="server" Display="Dynamic" ControlToValidate="dataLocalAccessType" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTollFreeDnis" runat="server" Text="Toll Free Dnis:" AssociatedControlID="dataTollFreeDnis" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTollFreeDnis" Text='<%# Bind("TollFreeDnis") %>' MaxLength="36"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTollFreeDialNumber" runat="server" Text="Toll Free Dial Number:" AssociatedControlID="dataTollFreeDialNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTollFreeDialNumber" Text='<%# Bind("TollFreeDialNumber") %>' MaxLength="36"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTollFreeAccessType" runat="server" Text="Toll Free Access Type:" AssociatedControlID="dataTollFreeAccessType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTollFreeAccessType" Text='<%# Bind("TollFreeAccessType") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTollFreeAccessType" runat="server" Display="Dynamic" ControlToValidate="dataTollFreeAccessType" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInstantReplayUrl" runat="server" Text="Instant Replay Url:" AssociatedControlID="dataInstantReplayUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInstantReplayUrl" Text='<%# Bind("InstantReplayUrl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStorageDuration" runat="server" Text="Storage Duration:" AssociatedControlID="dataStorageDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStorageDuration" Text='<%# Bind("StorageDuration") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStorageDuration" runat="server" Display="Dynamic" ControlToValidate="dataStorageDuration" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInstantReplayLoginUrl" runat="server" Text="Instant Replay Login Url:" AssociatedControlID="dataInstantReplayLoginUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInstantReplayLoginUrl" Text='<%# Bind("InstantReplayLoginUrl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



<%@ Control Language="C#" ClassName="User_MarketingServiceFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdUserDataSource" DataTextField="Username" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:UserDataSource ID="UserIdUserDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMarketingServiceId" runat="server" Text="Marketing Service Id:" AssociatedControlID="dataMarketingServiceId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataMarketingServiceId" DataSourceID="MarketingServiceIdMarketingServiceDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("MarketingServiceId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:MarketingServiceDataSource ID="MarketingServiceIdMarketingServiceDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataLastModified" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataLastModified" id="calext_dataLastModified" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModifiedBy" runat="server" Text="Last Modified By:" AssociatedControlID="dataLastModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModifiedBy" Text='<%# Bind("LastModifiedBy") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastContactDate" runat="server" Text="Last Contact Date:" AssociatedControlID="dataLastContactDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastContactDate" Text='<%# Bind("LastContactDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastContactDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataLastContactDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataLastContactDate" id="calext_dataLastContactDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNextContactDate" runat="server" Text="Next Contact Date:" AssociatedControlID="dataNextContactDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNextContactDate" Text='<%# Bind("NextContactDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNextContactDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataNextContactDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataNextContactDate" id="calext_dataNextContactDate" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



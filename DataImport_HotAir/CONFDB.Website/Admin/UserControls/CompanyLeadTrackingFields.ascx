<%@ Control Language="C#" ClassName="CompanyLeadTrackingFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyInfoId" runat="server" Text="Company Info Id:" AssociatedControlID="dataCompanyInfoId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCompanyInfoId" DataSourceID="CompanyInfoIdCompanyInfoDataSource" DataTextField="LeadId" DataValueField="Id" SelectedValue='<%# Bind("CompanyInfoId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CompanyInfoDataSource ID="CompanyInfoIdCompanyInfoDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProjectedRevenue" runat="server" Text="Projected Revenue:" AssociatedControlID="dataProjectedRevenue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProjectedRevenue" Text='<%# Bind("ProjectedRevenue") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProjectedRevenue" runat="server" Display="Dynamic" ControlToValidate="dataProjectedRevenue" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadProductId" runat="server" Text="Lead Product Id:" AssociatedControlID="dataLeadProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLeadProductId" DataSourceID="LeadProductIdLeadProductDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("LeadProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LeadProductDataSource ID="LeadProductIdLeadProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadSourceId" runat="server" Text="Lead Source Id:" AssociatedControlID="dataLeadSourceId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLeadSourceId" DataSourceID="LeadSourceIdLeadSourceDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("LeadSourceId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LeadSourceDataSource ID="LeadSourceIdLeadSourceDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadStageId" runat="server" Text="Lead Stage Id:" AssociatedControlID="dataLeadStageId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLeadStageId" DataSourceID="LeadStageIdLeadStageDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("LeadStageId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LeadStageDataSource ID="LeadStageIdLeadStageDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpectedCloseDate" runat="server" Text="Expected Close Date:" AssociatedControlID="dataExpectedCloseDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExpectedCloseDate" Text='<%# Bind("ExpectedCloseDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataExpectedCloseDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataExpectedCloseDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataExpectedCloseDate" id="calext_dataExpectedCloseDate" /><asp:RequiredFieldValidator ID="ReqVal_dataExpectedCloseDate" runat="server" Display="Dynamic" ControlToValidate="dataExpectedCloseDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadPeriodId" runat="server" Text="Lead Period Id:" AssociatedControlID="dataLeadPeriodId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLeadPeriodId" DataSourceID="LeadPeriodIdLeadPeriodDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("LeadPeriodId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LeadPeriodDataSource ID="LeadPeriodIdLeadPeriodDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLeadChurnReasonId" runat="server" Text="Lead Churn Reason Id:" AssociatedControlID="dataLeadChurnReasonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLeadChurnReasonId" DataSourceID="LeadChurnReasonIdLeadChurnReasonDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("LeadChurnReasonId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LeadChurnReasonDataSource ID="LeadChurnReasonIdLeadChurnReasonDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



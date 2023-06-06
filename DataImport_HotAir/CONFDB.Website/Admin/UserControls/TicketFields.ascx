<%@ Control Language="C#" ClassName="TicketFields" %>

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
        <td class="literal"><asp:Label ID="lbldataTitle" runat="server" Text="Title:" AssociatedControlID="dataTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTitle" Text='<%# Bind("Title") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIssueDescription" runat="server" Text="Issue Description:" AssociatedControlID="dataIssueDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIssueDescription" Text='<%# Bind("IssueDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataClientContactInfo" runat="server" Text="Client Contact Info:" AssociatedControlID="dataClientContactInfo" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataClientContactInfo" Text='<%# Bind("ClientContactInfo") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataModeratorId" DataSourceID="ModeratorIdModeratorDataSource" DataTextField="WholesalerId" DataValueField="Id" SelectedValue='<%# Bind("ModeratorId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ModeratorDataSource ID="ModeratorIdModeratorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatusId" runat="server" Text="Status Id:" AssociatedControlID="dataStatusId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataStatusId" DataSourceID="StatusIdTicketStatusDataSource" DataTextField="Abbreviation" DataValueField="Id" SelectedValue='<%# Bind("StatusId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketStatusDataSource ID="StatusIdTicketStatusDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataResolutionText" runat="server" Text="Resolution Text:" AssociatedControlID="dataResolutionText" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataResolutionText" Text='<%# Bind("ResolutionText") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTicketPriorityId" runat="server" Text="Ticket Priority Id:" AssociatedControlID="dataTicketPriorityId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTicketPriorityId" DataSourceID="TicketPriorityIdTicketPriorityDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TicketPriorityId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketPriorityDataSource ID="TicketPriorityIdTicketPriorityDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedByUserId" runat="server" Text="Created By User Id:" AssociatedControlID="dataCreatedByUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedByUserId" Text='<%# Bind("CreatedByUserId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCreatedByUserId" runat="server" Display="Dynamic" ControlToValidate="dataCreatedByUserId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCreatedByUserId" runat="server" Display="Dynamic" ControlToValidate="dataCreatedByUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAssignedToUserId" runat="server" Text="Assigned To User Id:" AssociatedControlID="dataAssignedToUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAssignedToUserId" Text='<%# Bind("AssignedToUserId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAssignedToUserId" runat="server" Display="Dynamic" ControlToValidate="dataAssignedToUserId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAssignedToUserId" runat="server" Display="Dynamic" ControlToValidate="dataAssignedToUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAssignedDate" runat="server" Text="Assigned Date:" AssociatedControlID="dataAssignedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAssignedDate" Text='<%# Bind("AssignedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataAssignedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataAssignedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataAssignedDate" id="calext_dataAssignedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataAssignedDate" runat="server" Display="Dynamic" ControlToValidate="dataAssignedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFixedByUserId" runat="server" Text="Fixed By User Id:" AssociatedControlID="dataFixedByUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFixedByUserId" Text='<%# Bind("FixedByUserId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFixedByUserId" runat="server" Display="Dynamic" ControlToValidate="dataFixedByUserId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataFixedByUserId" runat="server" Display="Dynamic" ControlToValidate="dataFixedByUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFixedDate" runat="server" Text="Fixed Date:" AssociatedControlID="dataFixedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFixedDate" Text='<%# Bind("FixedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFixedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataFixedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataFixedDate" id="calext_dataFixedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataFixedDate" runat="server" Display="Dynamic" ControlToValidate="dataFixedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataClosedByUserId" runat="server" Text="Closed By User Id:" AssociatedControlID="dataClosedByUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataClosedByUserId" Text='<%# Bind("ClosedByUserId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataClosedByUserId" runat="server" Display="Dynamic" ControlToValidate="dataClosedByUserId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataClosedByUserId" runat="server" Display="Dynamic" ControlToValidate="dataClosedByUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataClosedDate" runat="server" Text="Closed Date:" AssociatedControlID="dataClosedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataClosedDate" Text='<%# Bind("ClosedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataClosedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataClosedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataClosedDate" id="calext_dataClosedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataClosedDate" runat="server" Display="Dynamic" ControlToValidate="dataClosedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTicketProductId" runat="server" Text="Ticket Product Id:" AssociatedControlID="dataTicketProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTicketProductId" DataSourceID="TicketProductIdTicketProductDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TicketProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketProductDataSource ID="TicketProductIdTicketProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTicketCategoryId" runat="server" Text="Ticket Category Id:" AssociatedControlID="dataTicketCategoryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTicketCategoryId" DataSourceID="TicketCategoryIdTicketCategoryDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TicketCategoryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketCategoryDataSource ID="TicketCategoryIdTicketCategoryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDuplicateTicketId" runat="server" Text="Duplicate Ticket Id:" AssociatedControlID="dataDuplicateTicketId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDuplicateTicketId" Text='<%# Bind("DuplicateTicketId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDuplicateTicketId" runat="server" Display="Dynamic" ControlToValidate="dataDuplicateTicketId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDuplicateTicketId" runat="server" Display="Dynamic" ControlToValidate="dataDuplicateTicketId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



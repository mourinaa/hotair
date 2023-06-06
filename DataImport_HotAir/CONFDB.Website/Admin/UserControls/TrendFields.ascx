<%@ Control Language="C#" ClassName="TrendFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyId" runat="server" Text="Company Id:" AssociatedControlID="dataCompanyId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyId" Text='<%# Bind("CompanyId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCompanyId" runat="server" Display="Dynamic" ControlToValidate="dataCompanyId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCompanyId" runat="server" Display="Dynamic" ControlToValidate="dataCompanyId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerId" Text='<%# Bind("CustomerId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person Id:" AssociatedControlID="dataSalesPersonId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalesPersonId" Text='<%# Bind("SalesPersonId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalesPersonId" runat="server" Display="Dynamic" ControlToValidate="dataSalesPersonId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSalesPersonId" runat="server" Display="Dynamic" ControlToValidate="dataSalesPersonId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailCurrency" runat="server" Text="Retail Currency:" AssociatedControlID="dataRetailCurrency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailCurrency" Text='<%# Bind("RetailCurrency") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRetailCurrency" runat="server" Display="Dynamic" ControlToValidate="dataRetailCurrency" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyName" runat="server" Text="Company Name:" AssociatedControlID="dataCompanyName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyName" Text='<%# Bind("CompanyName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCompanyName" runat="server" Display="Dynamic" ControlToValidate="dataCompanyName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth01" runat="server" Text="Total Revenue Month01:" AssociatedControlID="dataTotalRevenueMonth01" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth01" Text='<%# Bind("TotalRevenueMonth01") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth01" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth01" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth02" runat="server" Text="Total Revenue Month02:" AssociatedControlID="dataTotalRevenueMonth02" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth02" Text='<%# Bind("TotalRevenueMonth02") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth02" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth02" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth03" runat="server" Text="Total Revenue Month03:" AssociatedControlID="dataTotalRevenueMonth03" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth03" Text='<%# Bind("TotalRevenueMonth03") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth03" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth03" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth04" runat="server" Text="Total Revenue Month04:" AssociatedControlID="dataTotalRevenueMonth04" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth04" Text='<%# Bind("TotalRevenueMonth04") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth04" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth04" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth05" runat="server" Text="Total Revenue Month05:" AssociatedControlID="dataTotalRevenueMonth05" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth05" Text='<%# Bind("TotalRevenueMonth05") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth05" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth05" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth06" runat="server" Text="Total Revenue Month06:" AssociatedControlID="dataTotalRevenueMonth06" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth06" Text='<%# Bind("TotalRevenueMonth06") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth06" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth06" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth07" runat="server" Text="Total Revenue Month07:" AssociatedControlID="dataTotalRevenueMonth07" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth07" Text='<%# Bind("TotalRevenueMonth07") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth07" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth07" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth08" runat="server" Text="Total Revenue Month08:" AssociatedControlID="dataTotalRevenueMonth08" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth08" Text='<%# Bind("TotalRevenueMonth08") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth08" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth08" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth09" runat="server" Text="Total Revenue Month09:" AssociatedControlID="dataTotalRevenueMonth09" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth09" Text='<%# Bind("TotalRevenueMonth09") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth09" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth09" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth10" runat="server" Text="Total Revenue Month10:" AssociatedControlID="dataTotalRevenueMonth10" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth10" Text='<%# Bind("TotalRevenueMonth10") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth10" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth10" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth11" runat="server" Text="Total Revenue Month11:" AssociatedControlID="dataTotalRevenueMonth11" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth11" Text='<%# Bind("TotalRevenueMonth11") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth11" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth11" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalRevenueMonth12" runat="server" Text="Total Revenue Month12:" AssociatedControlID="dataTotalRevenueMonth12" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalRevenueMonth12" Text='<%# Bind("TotalRevenueMonth12") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalRevenueMonth12" runat="server" Display="Dynamic" ControlToValidate="dataTotalRevenueMonth12" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataYearCategory" runat="server" Text="Year Category:" AssociatedControlID="dataYearCategory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataYearCategory" Text='<%# Bind("YearCategory") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataYearCategory" runat="server" Display="Dynamic" ControlToValidate="dataYearCategory" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartDate" runat="server" Text="Start Date:" AssociatedControlID="dataStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartDate" Text='<%# Bind("StartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataStartDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataStartDate" id="calext_dataStartDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndDate" runat="server" Text="End Date:" AssociatedControlID="dataEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndDate" Text='<%# Bind("EndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataEndDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataEndDate" id="calext_dataEndDate" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



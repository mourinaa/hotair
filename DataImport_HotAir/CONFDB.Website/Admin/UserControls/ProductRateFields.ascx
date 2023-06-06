<%@ Control Language="C#" ClassName="ProductRateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductId" runat="server" Text="Product Id:" AssociatedControlID="dataProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductId" DataSourceID="ProductIdProductDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductDataSource ID="ProductIdProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateTypeId" runat="server" Text="Product Rate Type Id:" AssociatedControlID="dataProductRateTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductRateTypeId" DataSourceID="ProductRateTypeIdProductRateTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductRateTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductRateTypeDataSource ID="ProductRateTypeIdProductRateTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateIntervalId" runat="server" Text="Product Rate Interval Id:" AssociatedControlID="dataProductRateIntervalId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductRateIntervalId" DataSourceID="ProductRateIntervalIdProductRateIntervalDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductRateIntervalId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductRateIntervalDataSource ID="ProductRateIntervalIdProductRateIntervalDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTaxableId" runat="server" Text="Taxable Id:" AssociatedControlID="dataTaxableId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTaxableId" DataSourceID="TaxableIdTaxableDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TaxableId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TaxableDataSource ID="TaxableIdTaxableDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryId" runat="server" Text="Country Id:" AssociatedControlID="dataCountryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryId" DataSourceID="CountryIdCountryDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CountryId") %>' AppendNullItem="false" Required="false" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountryDataSource ID="CountryIdCountryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayName" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayOrder" runat="server" Text="Display Order:" AssociatedControlID="dataDisplayOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayOrder" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMinimumTimeBeforeChargedSec" runat="server" Text="Minimum Time Before Charged Sec:" AssociatedControlID="dataMinimumTimeBeforeChargedSec" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMinimumTimeBeforeChargedSec" Text='<%# Bind("MinimumTimeBeforeChargedSec") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMinimumTimeBeforeChargedSec" runat="server" Display="Dynamic" ControlToValidate="dataMinimumTimeBeforeChargedSec" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRatingTypeId" runat="server" Text="Rating Type Id:" AssociatedControlID="dataRatingTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataRatingTypeId" DataSourceID="RatingTypeIdRatingTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("RatingTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:RatingTypeDataSource ID="RatingTypeIdRatingTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



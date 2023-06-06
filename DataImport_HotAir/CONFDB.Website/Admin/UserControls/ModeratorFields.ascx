<%@ Control Language="C#" ClassName="ModeratorFields" %>
<%--
************************NOTE: Use this control for Inserting******************************
Made changes as a lot of items are auto generated after the moderator is added. ie. mod code, 
    pass code, PriCustomerNumber, SecCustomerNumber, etc. and no validate is required.
*******************************************************************************************    
--%>
<asp:FormView ID="ModFormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                </td>
                <td>
                    <%-- <asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    <asp:HiddenField runat="server" ID="dataWholesalerId" Value='<%$ AppSettings:WholesalerID %>' />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCustomerId" runat="server" Text="Customer:" AssociatedControlID="dataCustomerId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource"
                        DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetByWholesalerId">
                        <Parameters>
                            <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID"
                                Type="string">
                            </data:SqlParameter>
                        </Parameters>
                    </data:CustomerDataSource>
                </td>
            </tr>
            <%--			<tr>
                <td class="literal"><asp:Label Visible="false" ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
                <td>
                    <asp:HiddenField runat="server" ID="dataCustomerI" Value='<%# Eval("CustomerId") %>'/>
                </td>
			</tr>
			<tr>--%>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:"
                        AssociatedControlID="dataPriCustomerNumber" /></td>
                <td>
                    <asp:TextBox ReadOnly="true" runat="server" ID="dataPriCustomerNumber" Text='<%# Eval("PriCustomerNumber") %>'
                        MaxLength="10"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                        TargetControlID="dataPriCustomerNumber" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:"
                        AssociatedControlID="dataSecCustomerNumber" /></td>
                <td>
                    <asp:TextBox ReadOnly="true" runat="server" ID="dataSecCustomerNumber" Text='<%# Eval("SecCustomerNumber") %>'
                        MaxLength="6"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                        TargetControlID="dataSecCustomerNumber" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataExternalModeratorNumber" runat="server" Text="External Moderator Number:"
                        AssociatedControlID="dataExternalModeratorNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataExternalModeratorNumber" Text='<%# Bind("ExternalModeratorNumber") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataModeratorCode" runat="server" Text="Moderator Code:" AssociatedControlID="dataModeratorCode" /></td>
                <td>
                    <asp:TextBox runat="server" ReadOnly="true" ID="dataModeratorCode" Text='<%# Bind("ModeratorCode") %>'
                        MaxLength="16"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                        TargetControlID="dataModeratorCode" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPassCode" runat="server" Text="Pass Code:" AssociatedControlID="dataPassCode" /></td>
                <td>
                    <asp:TextBox runat="server" ReadOnly="true" ID="dataPassCode" Text='<%# Bind("PassCode") %>'
                        MaxLength="16"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server"
                        TargetControlID="dataPassCode" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPhoneNumber" runat="server" Text="Phone Number:" AssociatedControlID="dataPhoneNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPhoneNumber" Text='<%# Bind("PhoneNumber") %>'
                        MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ControlToValidate="dataPhoneNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEmailAddress" runat="server" Text="Email Address:" AssociatedControlID="dataEmailAddress" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataEmailAddress" Text='<%# Bind("EmailAddress") %>'
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="dataEmailAddress" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDepartmentId" runat="server" Text="Department Id:" AssociatedControlID="dataDepartmentId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataDepartmentId" DataSourceID="DepartmentIdDepartmentDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentId") %>'
                        AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <%--<data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetAll"  />--%>
                    <%--When added, force to No Department, they can change it in Edit mode. There is a bug when linking controls in FormView in insert mode--%>
                    <data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetByName">
                        <Parameters>
                            <data:SqlParameter Name="Name" DefaultValue="No Department" Type="String" />
                        </Parameters>
                    </data:DepartmentDataSource>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSecContactName" runat="server" Text="Sec Contact Name:" AssociatedControlID="dataSecContactName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataSecContactName" Text='<%# Bind("SecContactName") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSecContactPhoneNumber" runat="server" Text="Sec Contact Phone Number:"
                        AssociatedControlID="dataSecContactPhoneNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataSecContactPhoneNumber" Text='<%# Bind("SecContactPhoneNumber") %>'
                        MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSecContactEmailAddress" runat="server" Text="Sec Contact Email Address:"
                        AssociatedControlID="dataSecContactEmailAddress" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataSecContactEmailAddress" Text='<%# Bind("SecContactEmailAddress") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
                <td>
                    <asp:TextBox ReadOnly="true" runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
                <td>
                    <asp:Label runat="server" ID="dataCreatedDate" Text='<%# Eval("CreatedDate", "{0:d}") %>' />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
                <td>
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Eval("LastModified", "{0:d}") %>' />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <%--			<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueModeratorId" runat="server" Text="Unique Moderator Id:" AssociatedControlID="dataUniqueModeratorId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataUniqueModeratorId" Value='<%# Bind("UniqueModeratorId") %>'></asp:HiddenField>
				</td>
			</tr>	--%>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdUserDataSource"
                        DataTextField="Username" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                    <data:UserDataSource ID="UserIdUserDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWebMeetingId" runat="server" Text="Web Meeting Id:" AssociatedControlID="dataWebMeetingId" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataWebMeetingId" Text='<%# Bind("WebMeetingId") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>

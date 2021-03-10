<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeFacingMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="GreenValleyAuctionsSystem.EmployeeDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="tblWelcome" runat="server">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                 <asp:Label ID="lblWelcometoDashboard" runat="server" Text="Welcome to the Employee Dashboard!" Font-Size="Larger" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblServiceRequests" runat="server" Text="New Service Requests:" Font-Bold="true" Font-Size="Large"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    <asp:GridView ID="grdVwServiceRequest" 
        runat="server"
        DataSourceID ="datasrcServiceRequest"
        AllowSorting="true"
        AllowPaging="true"
        AutoGenerateColumns="false"
        AutoGenerateSelectButton="true"
        DataKeyNames ="requestID"
        GridLines="Horizontal" EmptyDataText="No Customer Service Requests Available"
        AlternatingRowStyle-BackColor = "LightGray" CellPadding="5" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#266141"
        HeaderStyle-ForeColor ="White">
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="CustServiceRequestID"
                DataField="requestID" SortExpression="requestID" Visible="false" />
            <asp:TemplateField HeaderText="Customer Name" ItemStyle-Width="200px">
                <ItemTemplate>
                    <asp:Label ID="lblCustName" runat="server" Text=' <%#Eval("firstName") + " " + Eval("lastName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Service Type" DataField="serviceType" SortExpression="serviceType" />
            <asp:BoundField HeaderText="Date" DataField="timeDate" SortExpression="timeDate" />
            <asp:BoundField HeaderText="Description" DataField="requestDescription" SortExpression="requestDescription" />
             <asp:TemplateField HeaderText="Seen?">
                 <ItemTemplate>
                     <asp:CheckBox 
                         ID="seenCheckBox" 
                         runat="server"
                         AutoPostBack="true"
                         OnCheckedChanged="seenCheckBox_CheckedChanged"
                         />
                 </ItemTemplate>
             </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource
        ID ="datasrcServiceRequest"
        runat ="server"
        ConnectionString ="<%$ ConnectionStrings:Lab4 %>"
        SelectCommand="Select CUSTOMER.firstName, CUSTOMER.lastName, SERVICEREQUEST.requestID, SERVICEREQUEST.serviceType, SERVICEREQUEST.timeDate, SERVICEREQUEST.requestDescription, 
SERVICEREQUEST.requestSeen FROM SERVICEREQUEST inner join CUSTOMER on SERVICEREQUEST.customerID = CUSTOMER.customerID;">
    </asp:SqlDataSource>
</asp:Content>

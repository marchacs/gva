using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenValleyAuctionsSystem
{
    public partial class EmployeeDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void seenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //String custID = "";
            //int i = 0;
            //foreach (GridViewRow row in grdVwServiceRequest.Rows)
            //{
            //    //find the checkbox
            //    CheckBox seenCheckBox = row.FindControl("seenCheckBox") as CheckBox;
            //    if (seenCheckBox != null && seenCheckBox.Checked)
            //    {
            //        //make the row not visible
            //        grdVwServiceRequest.Rows[row.RowIndex].Visible = false;
            //        String customerFName = grdVwServiceRequest.Rows[i].Cells[1].Text;
            //        String customerLName = grdVwServiceRequest.Rows[i].Cells[2].Text;
            //        custID = getCustID(customerFName, customerLName);
            //        String dbConnection = System.Configuration.ConfigurationManager.ConnectionStrings["Lab4"].ConnectionString;
            //        using (SqlConnection connection = new SqlConnection(dbConnection))

            //        using (SqlCommand command = connection.CreateCommand())

            //        {
            //            command.CommandText = "UPDATE dbo.ServiceRequest SET requestSeen = @seen FROM dbo.Customer, dbo.TicketHistory, dbo.CustomerService WHERE Customer.customerID = CustomerService.customerID AND CustomerService.tktID = TicketHistory.tktID AND ServiceRequest.customerID = '" + custID + "' AND ServiceRequest.serviceType = 'Moving'";
            //            command.Parameters.AddWithValue("@seen", 1);

            //            connection.Open();

            //            command.ExecuteNonQuery();

            //            connection.Close();
            //            i++;
            //        }
            //    }
            //}

        }
    }
}
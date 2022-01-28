using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.BL
{
    public class CustomerCreation : WBT.Common.BLActivate
    {
        public override object GetAction(object Context)
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations customerCreation = new DLCustomerCreation.CustomerCreations();
                return customerCreation.DataActivate(Context);
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        public override object SetAction(object Context)
        {
            try
            {
                WBT.DLCustomerCreation.CustomerCreations customerCreation = new DLCustomerCreation.CustomerCreations();
                return customerCreation.DataActivate(Context);
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
    }
}

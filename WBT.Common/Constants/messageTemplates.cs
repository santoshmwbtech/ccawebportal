using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.Common.Constants
{
    public static class messageTemplates
    {
        public static string SALES_ORDER_PLACED = "Dear {0}, we have received your Purchase request through {1} and we will notify you against admin's approval. Thank you - MWB Tech India Pvt. Ltd";
        public static string SALES_ORDER_APPROVED = "Dear {0}, against your Purchase Request {1}, Admin has approved your order. To view click on {2}. Thank you - MWB Tech India Pvt. Ltd";
        public static string RECEIPT_PLACED = "Dear {0}, we have received your payment deposit details {1} and we will notify you against admin's approval. Thank you - MWB Tech India Pvt Ltd";
        public static string RECEIPT_CONFIRMED = "Dear {0}, against your receipt {1} we confirm the receipt {2}of your payment in our books of account. Click on {3} - Thank you - MWB Tech India Pvt Ltd";
    }
}

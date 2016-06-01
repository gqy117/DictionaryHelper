using System.Collections.Generic;

namespace ObjectExtensions.Test
{
    public class IndividualPayGPaymentSummary
    {
        public int TFN { get; set; }

        public Name Name { get; set; }

        public IList<Payment> Payments { get; set; }

        public string Address { get; set; }
    }
}
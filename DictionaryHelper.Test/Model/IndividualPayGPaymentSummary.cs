using System.Collections.Generic;

namespace ObjectExtensions.Test
{
    public class IndividualPayGPaymentSummary
    {
        public string TFN { get; set; }

        public Name Name { get; set; }

        public IList<Payment> Payments { get; set; }
    }
}
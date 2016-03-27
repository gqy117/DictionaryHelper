using ObjectExtensions.Test.Model;

namespace ObjectExtensions.Test
{
    public class Payment
    {
        public string ABNOrWPN { get; set; }

        public TaxWithheld TaxWithheld { get; set; }
    }
}
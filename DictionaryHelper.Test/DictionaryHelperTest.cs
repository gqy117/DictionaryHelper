namespace ObjectExtensions.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using ObjectExtensions.Test.Model;

    [TestClass]
    public class DictionaryHelperTest
    {
        [TestMethod]
        public void AsDictionary_ShouldReturnADictionaryWithFlattenStructor()
        {
            // Arrange
            IndividualPayGPaymentSummary paymentSummary = new IndividualPayGPaymentSummary
            {
                TFN = 865414088,
                Name = new Name
                {
                    Title = "Mr.",
                    Surname = "Li",
                    GivenName = "Leo"
                },

                Payments = new List<Payment>()
                {
                    new Payment()
                    {
                        ABNOrWPN = "12345678",
                        TaxWithheld = new TaxWithheld()
                        {
                            Dollars = 999,
                            Cents = 12
                        }
                    }
                }
            };

            // Act
            IDictionary<string, string> actual = paymentSummary.MapToDictionary();

            // Assert
            IDictionary<string, string> expected = new Dictionary<string, string>();

            expected.Add("TFN", "865414088");
            expected.Add("Name.Title", "Mr.");
            expected.Add("Name.Surname", "Li");
            expected.Add("Name.GivenName", "Leo");
            expected.Add("Payments[0].ABNOrWPN", "12345678");
            expected.Add("Payments[0].TaxWithheld.Dollars", "999");
            expected.Add("Payments[0].TaxWithheld.Cents", "12");
            expected.Add("Address", string.Empty);

            actual.ShouldAllBeEquivalentTo(expected);
        }

        [TestMethod]
        public void AsDictionary_ShouldReturnEmptyString_WhenStringIsNull()
        {
            // Arrange
            IndividualPayGPaymentSummary paymentSummary = new IndividualPayGPaymentSummary
            {
                Address = null
            };

            // Act
            IDictionary<string, string> dictionary = paymentSummary.MapToDictionary();
            string actual = dictionary["Address"];

            // Assert
            string expected = "";

            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}
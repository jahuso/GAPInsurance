using Insurance.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurance.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly RiskValidator riskValidator;
        public UnitTest1()
        {
            riskValidator = new RiskValidator("Alto", 0.6);
        }
        
        [TestMethod]
        public void CanBeCancelledBy_Risk_ReturnsTrue()
        {

            var result = riskValidator.ValidateRisk();
            Assert.AreEqual("OK", "La cobertura esta bien");

        }

        [TestMethod]
        public void CanBeCancelledBy_Risk_ReturnsFalse()
        {

            var result = riskValidator.ValidateRisk();

            Assert.AreNotEqual("OK", "La cobertura no puede ser tan alta");
        }
    }
}

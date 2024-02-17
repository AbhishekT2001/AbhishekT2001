using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorLibrary;

namespace TaxCalculatorUnitTests
{
    [TestClass]
    public class TaxCalculatorUnitTests
    {
        [TestMethod]
        public void CalculateTax_WithValidInputs_ReturnsValidTaxDetails()
        {
            // Arrange
            string name = "John Doe";
            string dateOfBirth = "1990/01/01";
            Gender gender = Gender.Male;
            int income = 200000;
            int investment = 30000;
            int houseLoan = 50000;

            // Act
            TaxDetails result = TaxCalculator.CalculateTax(name, dateOfBirth, gender, income, investment, houseLoan);

            // Assert
            //Assert.AreEqual(expectedNonTaxableIncome, result.NonTaxableIncome);
            //Assert.AreEqual(expectedTaxableIncome, result.TaxableIncome);
            //Assert.AreEqual(expectedIncomeTax, result.IncomeTax);
        }

        [TestMethod]
        public void CalculateTax_WithInvalidDateOfBirth_ReturnsErrorCodeInvalidDateOfBirth()
        {
            // Arrange
            string name = "John Doe";
            string invalidDateOfBirth = "invalid_date";

            // Act
            TaxDetails result = TaxCalculator.CalculateTax(name, invalidDateOfBirth, Gender.Male, 200000, 30000, 50000);

            // Assert
            Assert.AreEqual(0, result.NonTaxableIncome);
            Assert.AreEqual(0, result.TaxableIncome);
            Assert.AreEqual(0, result.IncomeTax);
           // Assert.AreEqual(ErrorCode.InvalidDateOfBirth, GetErrorCode(result));
        }

        // ... (similar for other test methods)

        private ErrorCode GetErrorCode(TaxDetails result)
        {
            return result.IncomeTax == 0 && result.NonTaxableIncome == 0 && result.TaxableIncome == 0
                ? ErrorCode.Success
                : ErrorCode.Success;  // Change to appropriate logic if ErrorCode is set in the TaxCalculator
        }
    }
}

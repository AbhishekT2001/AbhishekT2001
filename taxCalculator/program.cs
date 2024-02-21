using System;

namespace TaxCalculator
{
    public class TestTaxCalculator
    {
        static void Main(string[] args)
        {
            // Test cases

            Test("John Doe", "1990/05/01", 'M', 100000, 10000, 5000, "54000", "46000", "0");

            Test("Jane Doe", "2000/05/01", 'F', 440000, 100000, 50000, "140000", "300000", "14000");

            Test("Senior Citizen", "1960/05/01", 'M', 800000, 110000, 50000, "140000", "660000", "102000");

            // Invalid test cases

            Test("Invalid Name", "1990/05/01", 'M', 100000, 10000, 5000, "E03", "-", "-");

            Test("John Doe", "200005/01", 'M', 100000, 10000, 5000, "E04", "-", "-");

            Test("John Doe", "1800/05/01", 'M', 100000, 10000, 5000, "E05", "-", "-");

            Test("John Doe", "", 'M', 100000, 10000, 5000, "E06", "-", "-");

            Test("John Doe", "1990/05/01", 'A', 100000, 10000, 5000, "E07", "-", "-");

            Test("", "1990/05/01", 'M', 100000, 10000, 5000, "E02", "-", "-");

            Test("John Doe", "1990/05/01", 'M', -100, 10000, 5000, "E07", "-", "-");

            Test("John Doe", "1990/05/01", 'M', 100000, -1000, 5000, "E07", "-", "-");

            Test("John Doe", "1990/05/01", 'M', 100000, 10000, -500, "E07", "-", "-");

            Test("John Doe", "1990/05/01", 'M', 100000, 110000, 5000, "E12", "-", "-");

            Test("John Doe", "1990/05/01", 'M', 100000, 50000, 70000, "E13", "-", "-");
        }

        static void Test(string name, string dob, char gender, int income, int investment, int homeLoan,
            string expectedNonTaxable, string expectedTaxable, string expectedTotalTax)
        {
            PersonalInfo personalInfo = new PersonalInfo(name, DateTime.ParseExact(dob, "yyyy/MM/dd", null), gender);
            InvestmentInfo investmentInfo = new InvestmentInfo(income, investment, homeLoan);

            TaxCalculator calculator = new TaxCalculator();
            string errorCode = calculator.CalculateTaxDetails(personalInfo, investmentInfo);

            string nonTaxable = calculator.NonTaxableAmount.ToString();
            string taxable = calculator.TaxableAmount.ToString();
            string totalTax = calculator.TotalTax.ToString();

            bool isError = errorCode != "";

            Console.WriteLine("Input: ");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"DOB: {dob}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Income: {income}");
            Console.WriteLine($"Investment: {investment}");
            Console.WriteLine($"Home Loan: {homeLoan}");

            Console.WriteLine();

            Console.WriteLine("Output: ");
            Console.WriteLine($"Error code: {errorCode}");
            Console.WriteLine($"Non Taxable Amount: {nonTaxable}");
            Console.WriteLine($"Taxable Amount: {taxable}");
            Console.WriteLine($"Total Tax: {totalTax}");

            Console.WriteLine();

            if (isError)
            {
                Console.WriteLine($"Expected error code: {expectedNonTaxable}");
            }
            else
            {
                Console.WriteLine($"Expected Non Taxable Amount: {expectedNonTaxable}");
                Console.WriteLine($"Expected Taxable Amount: {expectedTaxable}");
                Console.WriteLine($"Expected Total Tax: {expectedTotalTax}");

                if (nonTaxable != expectedNonTaxable || taxable != expectedTaxable || totalTax != expectedTotalTax)
                {
                    Console.WriteLine("Test Failed!");
                }
                else
                {
                    Console.WriteLine("Test Passed!");
                }
            }

            Console.WriteLine();
        }
    }
}

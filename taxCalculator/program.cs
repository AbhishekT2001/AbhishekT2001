using System;
using TaxCalculatorLibrary;

namespace TaxCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gather user input
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter date of birth (format: yyyy/MM/dd):");
            string dateOfBirth = Console.ReadLine();

            Console.WriteLine("Enter gender (M/F):");
            char genderInput = Console.ReadKey().KeyChar;
            Gender gender = GetGenderFromInput(genderInput);

            Console.WriteLine("\nEnter income:");
            if (int.TryParse(Console.ReadLine(), out int income))
            {
                // User input for income is successfully parsed as an integer

                // Continue gathering input for investment
                Console.WriteLine("Enter investment:");
                if (int.TryParse(Console.ReadLine(), out int investment))
                {
                    // Continue gathering input for house loan/rent
                    Console.WriteLine("Enter house loan/rent:");
                    if (int.TryParse(Console.ReadLine(), out int houseLoan))
                    {
                        // All input values are successfully parsed

                        // Call the TaxCalculator to calculate tax details
                        TaxDetails taxDetails = TaxCalculator.CalculateTax(name, dateOfBirth, gender, income, investment, houseLoan);

                        // Display the results
                        DisplayTaxDetails(taxDetails);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for house loan/rent. Please enter a valid positive integer.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for investment. Please enter a valid positive integer.");
                }
            }
            else
            {
                // User input for income is not a valid positive integer
                Console.WriteLine("Invalid input for income. Please enter a valid positive integer.");
            }

        }

        static Gender GetGenderFromInput(char genderInput)
        {
            // Convert the char input to the Gender enum
            switch (char.ToUpper(genderInput))
            {
                case 'M':
                    return Gender.Male;
                case 'F':
                    return Gender.Female;
                default:
                    Console.WriteLine("Invalid input for gender. Defaulting to Male.");
                    return Gender.Male;
            }
        }

        static void DisplayTaxDetails(TaxDetails taxDetails)
        {
            // Implement logic to display tax details to the console
            Console.WriteLine("\nTax Details:");
            Console.WriteLine($"Non-Taxable Income: {taxDetails.NonTaxableIncome:C}");
            Console.WriteLine($"Taxable Income: {taxDetails.TaxableIncome:C}");
            Console.WriteLine($"Income Tax: {taxDetails.IncomeTax:C}");
        }
    }
}

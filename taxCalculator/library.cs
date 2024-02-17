using System;

namespace TaxCalculatorLibrary
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum ErrorCode
    {
        Success,
        InputOutOfTextLimit = 1, // E01
        InputNotGivenForName = 2, // E02
        InputContainsInvalidCharacters = 3, // E03
        DateFormatInvalid = 4, // E04
        BirthYearOutOfRange = 5, // E05
        InputNotGivenForDateOfBirth = 6, // E06
        InvalidInput = 7, // E07
        InputNotGivenForGender = 8, // E08
        InputNotGivenForIncome = 9, // E09
        InputNotGivenForHouseLoanRent = 10, // E10
        InvestmentExceedsIncome = 12, // E12
        InvestmentAndHouseLoanExceedsIncome = 13 // E13
    }

    public class TaxDetails
    {
        public decimal NonTaxableIncome { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }

    public class TaxCalculator
    {
        public static TaxDetails CalculateTax(string name, string dateOfBirth, Gender gender, int income, int investment, int houseLoan)
        {
            if (!IsValidName(name))
            {
                return CreateErrorResult(ErrorCode.InputNotGivenForName);
            }

            if (name.Length > 50)
            {
                return CreateErrorResult(ErrorCode.InputOutOfTextLimit);
            }

            if (!IsValidDateOfBirth(dateOfBirth))
            {
                return CreateErrorResult(ErrorCode.InputNotGivenForDateOfBirth);
            }

            if (!IsValidGender(gender))
            {
                return CreateErrorResult(ErrorCode.InputNotGivenForGender);
            }

            if (!IsValidIncome(income) || !IsValidInvestment(investment) || !IsValidHouseLoan(houseLoan))
            {
                return CreateErrorResult(ErrorCode.InvalidInput);
            }

            if (investment > income)
            {
                return CreateErrorResult(ErrorCode.InvestmentExceedsIncome);
            }

            if (investment + houseLoan > income)
            {
                return CreateErrorResult(ErrorCode.InvestmentAndHouseLoanExceedsIncome);
            }

            decimal totalIncome = income;
            decimal nonTaxableIncome = CalculateNonTaxableIncome(income, investment, houseLoan);

            // Calculate taxable income
            decimal taxableIncome = totalIncome - nonTaxableIncome;

            // Implement tax slab logic
            decimal incomeTax = 0;

            if (gender == Gender.Male)
            {
                incomeTax = CalculateMaleTax(taxableIncome);
            }
            else
            {
                incomeTax = CalculateFemaleTax(taxableIncome);
            }

            TaxDetails taxDetails = new TaxDetails
            {
                NonTaxableIncome = nonTaxableIncome,
                TaxableIncome = taxableIncome,
                IncomeTax = incomeTax
            };

            return taxDetails;
        }

        private static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        private static bool IsValidDateOfBirth(string dateOfBirth)
        {
            if (DateTime.TryParseExact(dateOfBirth, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out _))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Date of Birth");
                return false;
            }
        }

        private static bool IsValidGender(Gender gender)
        {
            return gender == Gender.Male || gender == Gender.Female;
        }

        private static bool IsValidIncome(int income)
        {
            return income >= 0;
        }

        private static bool IsValidInvestment(int investment)
        {
            return investment >= 0;
        }

        private static bool IsValidHouseLoan(int houseLoan)
        {
            return houseLoan >= 0;
        }

        private static decimal CalculateNonTaxableIncome(int income, int investment, int houseLoan)
        {
            // Implement investment rules
            decimal eightyPercentOfHouseLoan = 0.8m * houseLoan;
            decimal twentyPercentOfIncome = 0.2m * income;

            return Math.Min(eightyPercentOfHouseLoan, twentyPercentOfIncome);
        }

        private static decimal CalculateMaleTax(decimal taxableIncome)
        {
            if (taxableIncome <= 160000)
                return 0;
            else if (taxableIncome <= 300000)
                return 0.1m * (taxableIncome - 160000);
            else if (taxableIncome <= 500000)
                return 0.2m * (taxableIncome - 300000);
            else
                return 0.3m * (taxableIncome - 500000);
        }

        private static decimal CalculateFemaleTax(decimal taxableIncome)
        {
            if (taxableIncome <= 190000)
                return 0;
            else if (taxableIncome <= 300000)
                return 0.1m * (taxableIncome - 190000);
            else if (taxableIncome <= 500000)
                return 0.2m * (taxableIncome - 300000);
            else
                return 0.3m * (taxableIncome - 500000);
        }

        private static TaxDetails CreateErrorResult(ErrorCode errorCode)
        {
            return new TaxDetails { IncomeTax = 0, NonTaxableIncome = 0, TaxableIncome = 0, ErrorCode = errorCode };
        }
    }
}

using FluentValidation;

namespace CompoundInterestApi.Models
{
    public class CompoundInterest
    {
        public double Principal { get; set; } = 0; // Starting Amount
        public double InterestRate { get; set; } = 0; // Faiz Oranı (yıllık)
        public int Years { get; set; } = 0; // Number of Years
    }
}

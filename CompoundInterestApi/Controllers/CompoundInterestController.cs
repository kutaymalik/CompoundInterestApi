using CompoundInterestApi.Models;
using CompoundInterestApi.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CompoundInterestApi.Controllers
{
    [Route("ci/api/[controller]")]
    [ApiController]
    public class CompoundInterestController: ControllerBase
    {
        public CompoundInterestController()
        {

        }



        [HttpPost]
        public dynamic Post([FromBody] CompoundInterest interest)
        {
            // This line prevents the validator object from getting a null value.
            var context = new ValidationContext<CompoundInterest>(interest);

            // Called the validator and got the result of the request.
            CompoundInterestValidator validator = new CompoundInterestValidator();
            var result = validator.Validate(interest);
            

            if(result.IsValid)
            {
                // The necessary calculations were made here.
                double principal = interest.Principal;
                double rate = interest.InterestRate / 100; // Faiz oranını yüzde olarak kabul edin
                int years = interest.Years;

                double amount = principal * Math.Pow(1 + rate, years);

                // Returning the object to be displayed to the user with the status code.
                return Ok(new { Amount = amount, InterestRate = rate, Principal = principal, Years = years });
            }
            else
            {
                // If the expected request is not made, we return the error list with the error code.
                return BadRequest(result.Errors);
            }
        }
    }
}

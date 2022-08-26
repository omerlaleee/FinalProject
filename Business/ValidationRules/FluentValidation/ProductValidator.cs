using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Ready-made Rules
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            // If you want to create new rule;
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Product Names have to start with 'A/a'!");
        }

        public bool StartWithA(string productName)
        {
            return productName.StartsWith("A") || productName.StartsWith("a");
        }
    }
}

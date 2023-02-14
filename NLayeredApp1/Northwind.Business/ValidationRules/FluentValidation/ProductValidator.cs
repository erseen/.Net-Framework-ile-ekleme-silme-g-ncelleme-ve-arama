using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>
    {
        //Fluent Validation 
        //constractor 
        public ProductValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori seçimi yapınız ");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Fiyat boş olamaz");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Birim adedi boş olamaz");
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Stok adedi boş olamaz");

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);
           
        }
        //RuleFor(p => p.ProductName).Must(StartWithA);

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}

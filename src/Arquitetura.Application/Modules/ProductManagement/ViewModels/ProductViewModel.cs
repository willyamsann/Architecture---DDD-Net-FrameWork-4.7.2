using System.ComponentModel.DataAnnotations;

namespace Arquitetura.Application.Modules.ProductManagement.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        public double Value { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

        [Display(Name = "Está ativo?")]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

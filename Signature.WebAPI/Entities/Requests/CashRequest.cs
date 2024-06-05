using System.ComponentModel.DataAnnotations;

namespace Signature.WebAPI.Entities.Requests
{
    public class CashRequest
    {
        [Required]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string codigoEmpresa { get; set; }
        [Required]
        public string Caja { get; set; }
        [Required(ErrorMessage = "No se ha podido comprobar el operador")]
        public string Operador { get; set; }
        [Required]
        [StringLength(23)]
        public string FechaCierre { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 1)]
        [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo SaldoCarburantes solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
        public string SaldoCarburantes { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 1)]
        [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo SaldoTienda solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
        public string SaldoTienda { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo SaldoServicio solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
        public string SaldoServicio { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
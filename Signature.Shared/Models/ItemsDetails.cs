using System.Collections.Generic;

namespace Signature.Shared.Models
{
    public class ItemsDetails
    {
        #region Properties
        /// <summary>
        /// Cantidad
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// Linea del ticket en la que se encuentra el articulo. Campo obligatorio con un valor requerido.
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Valor total de la linea del ticket con el IVA y los descuentos incluidos.
        /// Acepta 2 decimales usando el caracter punto. Campo obligatorio con un valor requerido.
        /// </summary>
        public string TotalLineAmount { get; set; }

        /// <summary>
        /// Coste de cada unidad del articulo, con el Iva añadido pero sin incluir los descuentos.
        /// Acepta 2 decimales usando el caracter punto. Campo obligatorio con un valor requerido.
        /// </summary>
        public string UnitaryPriceWithTax { get; set; }

        /// <summary>
        /// CantidadCantidad de descuento aplicado incluyendo el IVA. 
        /// Campo obligatorio con un valor requerido por defercto cero.
        /// </summary>
        public string TotalDiscountedAmount { get; set; }

        /// <summary>
        /// Codigo del articulo, formado por el codigo de empresa y de 1 a 25 caracteres. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Cantidad de descuento aplicado al total de la linea. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string DiscountPercentage { get; set; }

        /// <summary>
        /// Tipo de Iva que se aplica a la venta del articulo. 
        /// Campo obligatorio con un valor requerido
        /// </summary>
        public string TaxPercentage { get; set; }

        /// <summary>
        /// Cantidad de IVA aplicado al valor del articulo. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string TotalTaxAmount { get; set; }

        /// <summary>
        /// Detalle de Promociones No Requerido en Request / Calculado en Response
        /// </summary>
        public List<PromotionsApplied> PromotionsApplied { get; set; }
        #endregion
    }
}
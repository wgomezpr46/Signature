namespace Signature.Shared.Models
{
    public class PromotionsApplied
    {
        #region Properties
        /// <summary>
        /// Codigo de promocion
        /// </summary>
        public string PromotionId { get; set; }

        /// <summary>
        /// Descripcion de la promocion
        /// </summary>
        public string PromotionDescription { get; set; }

        /// <summary>
        /// Cantidad descontada debido a la promocion sobre la linea indicada. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string TotalDiscountedAmount { get; set; }

        /// <summary>
        /// Porcentaje aplicado debido a la promocion sobre la linea indicada. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string TotalDiscountPercentage { get; set; }
        #endregion
    }
}
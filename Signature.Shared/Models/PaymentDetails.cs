namespace Signature.Shared.Models
{
    public class PaymentDetails
    {
        #region Properties
        /// <summary>
        /// Metodo de Pago
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Codigo de Moneda
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Cantidad Cobrada
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Factor de Cambio
        /// </summary>
        public string ExchangeFactor { get; set; }

        /// <summary>
        /// Cantidad Recibida
        /// </summary>
        public string GivenAmount { get; set; }
        #endregion

        /// <summary>
        /// Informacion Extra
        /// </summary>
        public List<ExtraInfo> ExtraInfo { get; set; }
    }
}
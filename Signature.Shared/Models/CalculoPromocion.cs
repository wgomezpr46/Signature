using System.Collections.Generic;

namespace Signature.Shared.Models
{
    public class CalculoPromocion
    {
        #region Properties
        /// <summary>
        /// Clave unica del TPV. Campo obligatorio con un valor requerido.
        /// </summary>
        public string POSGuid { get; set; }

        /// <summary>
        /// Identificador de la caja, formado por el codigo de empresa y de 1 a 5 caracteres. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string CashBoxId { get; set; }

        /// <summary>
        /// Identificador del usuario que realiza el ticket, formado por el codigo de empresa y de 1 a 15 caracteres. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string OperatorCode { get; set; }

        /// <summary>
        /// Numero de ticket. Compuesto por el identificador de la serie (codigo de empresa + 1 a 5 caracteres) y de 1 a 10 caracteres.
        /// Campo obligatorio con valor requerido
        /// </summary>
        public string DocumentId { get; set; }

        /// <summary>
        /// Codigo de la serie del ticket, formado por el codigo de la empresa y de 1 a 5 caracteres. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string SeriesId { get; set; }

        /// <summary>
        /// Identificador de la moneda utilizada para el cobro, formado por el codigo de empresa y de 1 a 15 caracteres.
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Fecha en la que se ha creado el ticket. 
        /// Campo obligatorio con un valor fecha requerido.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Numero de kilometros del vehiculo en el momento de la venta. 
        /// Campo opcional.
        /// </summary>
        public string Kilometers { get; set; }

        /// <summary>
        /// Identificador del cliente, formado por el codigo de empresa y de 1 a 5 caracteres. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Numero de tarjeta de debito o credito asociada al cliente. 
        /// Campo opcional
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Matricula del vehiculo asociado al cliente.
        /// Campo opcional
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Indica el numero de ticket al cual está anulando el ticket actual. 
        /// Compuesto por el identificador de la serie (codigo de empresa + 1 a 5 caracteres) y de 1 a 10 caracteres
        /// , en caso de ser una operación de anulación. 
        /// Campo opcional
        /// </summary>
        public string AnnulatedDocument { get; set; }

        /// <summary>
        /// Valor del ticket con el IVA y los descuentos incluidos. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string TotalAmountWithTax { get; set; }

        /// <summary>
        /// Valor al que se le va a aplicar el IVA. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string TotalTaxableAmount { get; set; }

        /// <summary>
        /// Valor calculado de IVA usando el tipo de Iva aplicado. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string TotalTaxAmount { get; set; }

        /// <summary>
        /// Cantidad de descuento aplicado al total del ticket. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string DiscountPercentage { get; set; }

        /// <summary>
        /// Cantidad de dinero recibida para el cobro del mismo. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido.
        /// </summary>
        public string GivenAmount { get; set; }

        /// <summary>
        /// Cambio devuelto al cliente, restante de la cantidad recibida. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string ChangeDelivered { get; set; }

        /// <summary>
        /// Detalle de Productos
        /// </summary>
        public List<ItemsDetails> ItemsDetails { get; set; }

        /// <summary>
        /// Detalle de Pagos
        /// </summary>
        public List<PaymentDetails> PaymentDetails { get; set; }

        /// <summary>
        /// Información Extra
        /// </summary>
        public List<ExtraInfo> ExtraData { get; set; }

        /// <summary>
        /// Tipo de serie que se recupera al solicitar una factura. 
        /// Campo opcional con valor por defecto vacio.
        /// </summary>
        public string SeriesType { get; set; }

        /// <summary>
        /// Cantidad total descontada en el ticket. 
        /// Acepta 2 decimales usando el caracter punto. 
        /// Campo obligatorio con un valor requerido por defecto cero.
        /// </summary>
        public string TotalDiscountedAmount { get; set; }

        /// <summary>
        /// Fecha de aplicacion contable. Campo opcional con valor requerido vacio.
        /// </summary>
        public string BusinessDate { get; set; }

        /// <summary>
        /// Mesaje que puede devolver el controlador
        /// </summary>
        public string Message { get; set; }
        #endregion
    }
}
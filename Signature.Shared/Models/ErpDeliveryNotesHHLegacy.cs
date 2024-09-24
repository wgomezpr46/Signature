using System.Xml.Serialization;

namespace Signature.Shared.Models
{
    public class ErpDeliveryNotesHHLegacy
    {

        /**********************************************************************
         *   FORMATO DEL XML RECIBIDO DESDE HANDHELD:
         *   
         *   XmlData = "<header>
         *             <CONTEO>
         *                  <DETALLE> .... </DETALLE>
         *                           ....
         *                  <DETALLE> .... </DETALLE>
         *             </CONTEO>"
         *   
         *   Siendo un elemento interno de la forma
         *             <DETALLE>
         *                  <NAlbaran> ... </NAlbaran>
         *                  <NPedido> ... </NPedido>
         *                  <NProveedor> ... </NProveedor>
         *                  <Item> ... </Item>
         *                  <Referencia> ... </Referencia>
         *                  <Cantidad> ... </Cantidad>
         *                  <FechaAlbaran> ... </FechaAlbaran>    dd/MM/2019
         *                  <Devolucion> ... </Devolucion> => Evolutivo: STRY0165779
         *             </DETALLE>
         *   
         ***********************************************************************/

        #region Getters & Setters
        public string NCompany { get; set; }

        public string User { get; set; }

        public string NPDA { get; set; }

        public string XmlData { get; set; }

        #endregion

        #region Constructors
        // Constructor vacio
        public ErpDeliveryNotesHHLegacy()
        {
            NCompany = String.Empty;
            User = String.Empty;
            NPDA = String.Empty;
            XmlData = String.Empty;
        }

        // Constructor de llamada
        public ErpDeliveryNotesHHLegacy(string _NCompany, string _User, string _NPDA, string _XmlData)
        {
            this.NCompany = _NCompany;
            this.User = _User;
            this.NPDA = _NPDA;
            this.XmlData = _XmlData;
        }
        #endregion
    }



    public class ErpArticuloAlbaranLegacy
    {
        [XmlElement("NAlbaran")]
        public string NAlbaran { get; set; }
        [XmlElement("NProveedor")]
        public string NProveedor { get; set; }
        [XmlElement("NPedido")]
        public string NPedido { get; set; }
        [XmlElement("Referencia")]
        public string Referencia { get; set; }
        [XmlElement("Item")]
        public int Item { get; set; }
        [XmlElement("Cantidad")]
        public Single Cantidad { get; set; }
        /// <summary>
        /// Campo FECHA DE ALBARAN introducido tras certificación de sp 10-11
        /// </summary>
        [XmlElement("FechaAlbaran")]
        public string FechaAlbaran { get; set; }
        [XmlIgnore]
        public int? Packaging { get; set; }

        [XmlElement("Packaging")]
        public string PackagingAsText
        {
            get { return (Packaging.HasValue) ? Packaging.ToString() : null; }
            set { Packaging = !string.IsNullOrEmpty(value) ? int.Parse(value) : default(int?); }
        }

        [XmlElement("TipoAlbaran")]
        public string TipoAlbaran { get; set; }
        [XmlElement("EstadoDoc")]
        public string EstadoDoc { get; set; }
        // campos calculados en en DAL
        public string Descripcion { get; set; }
        public decimal PVP { get; set; }
        public decimal Importe { get; set; }
        public Single IVA { get; set; }
        public Single Descuento { get; set; }
        public string Divisa { get; set; }
        // Sp 15 - Precio de Compra enviado desde HH (Histórico de Precios) - Se envía a partir de la versión 520 de HH
        [XmlElement("PrecioCompra")]
        public string PrecioCompra { get; set; }

        [XmlElement("Devolucion")]
        public bool Devolucion { get; set; }

        /// constructores para deserialización
        public ErpArticuloAlbaranLegacy() { }

        public ErpArticuloAlbaranLegacy(string nalb, string prov, string ped, string referencia, int item, Single cant, string desc,
                                decimal pvp, decimal imp, Single iva, Single descuento, string divisa, string fecha, string precioCompra, int packaging,
                                bool devolucion)
        {
            NAlbaran = nalb;
            NProveedor = prov;
            NPedido = ped;
            Referencia = referencia;
            Item = item;
            Cantidad = cant;
            Descripcion = desc;
            PVP = pvp;
            Importe = imp;
            IVA = iva;
            Descuento = descuento;
            Divisa = divisa;
            FechaAlbaran = fecha;
            PrecioCompra = precioCompra;
            Packaging = packaging;
            Devolucion = devolucion;
        }
    }

    /// <summary>
    /// clase auxiliar para deserializar el xmlData
    /// </summary>
    [XmlRoot("CONTEO")]
    public class ErpListArticuloAlbaranLegacy
    {
        [XmlElement("DETALLE")]
        public List<ErpArticuloAlbaranLegacy> ErplistArticulosAlbaran { get; set; }

        public decimal BaseImponible { get; set; }
        public decimal ImporteTotal { get; set; }
        public string Empresa { get; set; }
        public string Almacen { get; set; }
        public string Usuario { get; set; }
        public string Tienda { get; set; }

        public ErpListArticuloAlbaranLegacy()
        {
            ErplistArticulosAlbaran = new List<ErpArticuloAlbaranLegacy>();
        }

        public ErpListArticuloAlbaranLegacy(List<ErpArticuloAlbaranLegacy> list, decimal baseImp, decimal importe, string empr, string alma, string usuario, string tienda)
        {
            ErplistArticulosAlbaran = list;
            BaseImponible = baseImp;
            ImporteTotal = importe;
            Empresa = empr;
            Almacen = alma;
            Usuario = usuario;
            Tienda = tienda;
        }
    }
}

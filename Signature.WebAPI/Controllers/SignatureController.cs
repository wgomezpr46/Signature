using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Signature.Shared.Entities.Requests;
using Signature.Shared.Helpers;
using Signature.Shared.Models;

namespace Signature.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        /// <summary>
        /// Genera firma a partir de un payload enviado en el cuerpo de cada solicitud.
        /// </summary>
        /// <param name="request">Payload con datos necesarios para generar la firma.</param>
        /// <param name="TimeStamp">Marca de tiempo de la solicitud en formato 'dd/MM/yyyy HH:mm:ss', Ejm: 20/09/2024 11:30:00.</param>
        /// <param name="Endpoint">El endpoint que se está llamando, Ejm: /GetArticle</param>
        /// <returns>retorna firma</returns>
        /// <remarks>
        /// Sample body request:
        ///
        ///     POST /GetArticle
        ///     {
        ///        "CodigoEmpresa": "69947",
        ///        "CodigoEAN": "",
        ///        "Referencia": "69947876673",
        ///        "Caja": "6994701"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">SHA256 string signature.</response>
        /// <response code="400">TimeStamp y Endpoint son obligatorios || Endpoint '{Endpoint}' no es válido.</response>
        // POST: api/Signature/GeneratedSignature
        [HttpPost]
        public IActionResult GeneratedSignature([FromBody] Object request, [FromQuery] string TimeStamp, [FromQuery] string Endpoint)
        {
            string sGenerateSignatureInput = string.Empty;

            try
            {
                Request.Headers.TryGetValue("TimeStamp", out var strTimeStamp);
                Request.Headers.TryGetValue("Endpoint", out var strEndpoint);

                if ((!string.IsNullOrEmpty(strTimeStamp) || !string.IsNullOrEmpty(strEndpoint)) && (string.IsNullOrEmpty(TimeStamp) && string.IsNullOrEmpty(Endpoint)))
                {
                    TimeStamp = strTimeStamp;
                    Endpoint = strEndpoint;
                }

                if ((!string.IsNullOrEmpty(TimeStamp) || !string.IsNullOrEmpty(Endpoint)) && (string.IsNullOrEmpty(strTimeStamp) && string.IsNullOrEmpty(strEndpoint)))
                {
                    strTimeStamp = TimeStamp;
                    strEndpoint = Endpoint;
                }

                if (string.IsNullOrEmpty(strTimeStamp) && string.IsNullOrEmpty(strEndpoint))
                {
                    return BadRequest(new { error = "TimeStamp y Endpoint son obligatorios" });
                }
                if (string.IsNullOrEmpty(strTimeStamp) || string.IsNullOrEmpty(strEndpoint))
                {
                    return BadRequest(new { error = "TimeStamp y Endpoint son obligatorios" });
                }

#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                };
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances

                string jsonString = System.Text.Json.JsonSerializer.Serialize(request, options);

                switch (strEndpoint.ToString())
                {
                    case "/GetArticle":
                    case "/GetArticleType":
                    case "/ilionservices4/COFOWSAPITPV/GetArticle":
                    case "/ilionservices4/COFOWSInterface/api/Article/GetArticle/request":
                    case "/IlionServices4/COFOWSInterface/api/Article/GetArticle/request":
                        var objArticleRequest = JsonConvert.DeserializeObject<ArticleRequest>(jsonString);
                        if (strEndpoint.ToString().Contains("COFOWSAPITPV")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticleRequest, strTimeStamp); }
                        if (strEndpoint.ToString().Contains("COFOWSInterface")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objArticleRequest, strTimeStamp); }
                        else { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticleRequest, strTimeStamp); }
                        break;
                    case "/GetPromotions":
                        var objTicketPromotionsRequest = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objTicketPromotionsRequest, strTimeStamp);
                        break;
                    case "/GetPromotionsNew":
                    case "/ilionservices4/COFOWSAPITPV/GetPromotionsNew":
                    case "/ilionServices4/COFOWSAPITPV/GetPromotionsNew":
                        var objTicketPromotionsRequestNew = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objTicketPromotionsRequestNew, strTimeStamp);
                        break;
                    case "/api/Promotion/GetListarPromocionNew/Request":
                    case "/ilionservices4/COFOWSInterface/api/Promotion/GetListarPromocionNew/Request":
                        var objPromocionRequest = JsonConvert.DeserializeObject<CalculoPromocion>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objPromocionRequest, strTimeStamp);
                        break;
                    case "/SetTicket":
                    case "/SetRefundTicket":
                    case "/ilionservices4/COFOWSAPITPV/SetTicket":
                        var objPOSDocumentsCOFORequest = JsonConvert.DeserializeObject<POSDocumentsCOFORequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objPOSDocumentsCOFORequest, strTimeStamp);
                        break;
                    case "/GetDeliveryNotes":
                        var objDeliveryNotesRequest = JsonConvert.DeserializeObject<DeliveryNotesRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objDeliveryNotesRequest, strTimeStamp);
                        break;
                    case "/GetDeliveryNotesV2":
                        var objDeliveryNotesRequestV2 = JsonConvert.DeserializeObject<DeliveryNotesRequestV2>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objDeliveryNotesRequestV2, strTimeStamp);
                        break;
                    case "/ListArticlesPaged":
                    case "/IlionServices4/COFOWSInterface/api/ArticlesPaged/ListArticlesPagedFamilies/request":
                    case "/api/ArticlesPaged/ListArticlesPagedFamilies/request":
                    case "/ilionservices4/COFOWSInterface/api/ArticlesPaged/ListArticlesPagedFamilies/request":
                        var objArticlesRequest = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                        if (strEndpoint.ToString().Contains("COFOWSAPITPV")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticlesRequest, strTimeStamp); }
                        if (strEndpoint.ToString().Contains("COFOWSInterface")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objArticlesRequest, strTimeStamp); }
                        else { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objArticlesRequest, strTimeStamp); }
                        break;
                    case "/ListArticlesPagedFamilies":
                        var objArticlesRequest_ = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticlesRequest_, strTimeStamp);
                        break;
                    case "/GetSettingsLosses":
                        var objSettingsLossesRequest = JsonConvert.DeserializeObject<SettingsLossesRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objSettingsLossesRequest, strTimeStamp);
                        break;
                    case "/SetAdjustmentsLosses":
                        var objSetAdjustmentsLossesRequest = JsonConvert.DeserializeObject<SetAdjustmentsLossesRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objSetAdjustmentsLossesRequest, strTimeStamp);
                        break;
                    case "/SetClosingCash":
                    case "/SetClosingCashTransaction": //No se encuentra el Endpoint en COFOWSAPITPV
                        var objCashRequest = JsonConvert.DeserializeObject<CashRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objCashRequest, strTimeStamp);
                        break;
                    case "/GetFailedTickets":
                        var objFailedTicketRequest = JsonConvert.DeserializeObject<FailedTicketRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objFailedTicketRequest, strTimeStamp);
                        break;
                    case "/GetFamilies":
                        var objFamiliesRequest = JsonConvert.DeserializeObject<FamiliesRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objFamiliesRequest, strTimeStamp);
                        break;
                    case "/TransactionStatus": //No se encuentra el Endpoint en COFOWSAPITPV
                    case "/ilionservices4/COFOWSInterface/api/ClosingCash/TransactionStatus/request":
                    case "/api/ClosingCash/TransactionStatus/request":
                        var objTransactionStatusRequest = JsonConvert.DeserializeObject<TransactionStatusRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objTransactionStatusRequest, strTimeStamp);
                        break;
                    case "/api/DeliveryNotes/COFOSetDeliveryNotesHandHeld/request":
                    case "/ilionservices4/custom/repsol/HandHeldWS_COFO/api/DeliveryNotes/COFOSetDeliveryNotesHandHeld/request":
                        var objErpDeliveryNotesHHLegacy = JsonConvert.DeserializeObject<ErpDeliveryNotesHHLegacy>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objErpDeliveryNotesHHLegacy, strTimeStamp);
                        break;
                    case "/SupplierOrders/COFOSetSupplierOrdersConts/request":
                    case "/ilionservices4/custom/repsol/HandHeldWS_COFO/api/SupplierOrders/COFOSetSupplierOrdersConts/request":
                        var objSupplierOrders = JsonConvert.DeserializeObject<SupplierOrders>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objSupplierOrders, strTimeStamp);
                        break;
                    case "/ilionservices4/custom/repsol/HandHeldWS_COFO/api/update/checkVersion":
                        var objCheckVersionRequest = JsonConvert.DeserializeObject<CheckVersionRequest>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objCheckVersionRequest, strTimeStamp);
                        break;
                    case "/api/Trace/SetTraceV2/request":
                    case "/ilionservices4/COFOWSInterface/api/Trace/SetTraceV2/request":
                        var objTraceAPI = JsonConvert.DeserializeObject<TracesAPI>(jsonString);
                        sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objTraceAPI, strTimeStamp);
                        break;
                    default:
                        return BadRequest(new { error = $"Endpoint '{strEndpoint}' no es válido" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(sGenerateSignatureInput);
        }
    }
}
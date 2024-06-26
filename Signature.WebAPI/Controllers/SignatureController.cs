﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Signature.WebAPI.Entities.Requests;
using Signature.WebAPI.Helpers;
using Signature.WebAPI.Models;

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
        /// <param name="request"></param>
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
        public IActionResult GeneratedSignature([FromBody] Object request)
        {
            Request.Headers.TryGetValue("TimeStamp", out var strTimeStamp);
            Request.Headers.TryGetValue("Endpoint", out var strEndpoint);

            if (string.IsNullOrEmpty(strTimeStamp) || string.IsNullOrEmpty(strEndpoint))
            {
                return BadRequest(new { error = "TimeStamp y Endpoint son obligatorios" });
            }

            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(request, options);
            string sGenerateSignatureInput = string.Empty;

            switch (strEndpoint.ToString())
            {
                case "/GetArticle":
                case "/GetArticleType":
                case "/ilionservices4/COFOWSAPITPV/GetArticle":
                case "/ilionservices4/COFOWSInterface/api/Article/GetArticle/request":
                    var objArticleRequest = JsonConvert.DeserializeObject<ArticleRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objArticleRequest, strTimeStamp);
                    break;
                case "/GetPromotions":
                    var objTicketPromotionsRequest = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objTicketPromotionsRequest, strTimeStamp);
                    break;
                case "/GetPromotionsNew":
                case "/ilionservices4/COFOWSAPITPV/GetPromotionsNew":
                case "/ilionServices4/COFOWSAPITPV/GetPromotionsNew":
                    var objTicketPromotionsRequestNew = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objTicketPromotionsRequestNew, strTimeStamp);
                    break;
                case "/api/Promotion/GetListarPromocionNew/Request":
                case "/ilionservices4/COFOWSInterface/api/Promotion/GetListarPromocionNew/Request":
                case "/IlionServices4/COFOWSInterface/api/Article/GetArticle/request":
                    var objPromocionRequest = JsonConvert.DeserializeObject<CalculoPromocion>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objPromocionRequest, strTimeStamp);
                    break;
                case "/SetTicket":
                case "/SetRefundTicket":
                    var objPOSDocumentsCOFORequest = JsonConvert.DeserializeObject<POSDocumentsCOFORequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objPOSDocumentsCOFORequest, strTimeStamp);
                    break;
                case "/GetDeliveryNotes":
                    var objDeliveryNotesRequest = JsonConvert.DeserializeObject<DeliveryNotesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objDeliveryNotesRequest, strTimeStamp);
                    break;
                case "/GetDeliveryNotesV2":
                    var objDeliveryNotesRequestV2 = JsonConvert.DeserializeObject<DeliveryNotesRequestV2>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objDeliveryNotesRequestV2, strTimeStamp);
                    break;
                case "/ListArticlesPaged":
                    var objArticlesRequest = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objArticlesRequest, strTimeStamp);
                    break;
                case "/ListArticlesPagedFamilies":
                    var objArticlesRequest_ = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objArticlesRequest_, strTimeStamp);
                    break;
                case "/GetSettingsLosses":
                    var objSettingsLossesRequest = JsonConvert.DeserializeObject<SettingsLossesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objSettingsLossesRequest, strTimeStamp);
                    break;
                case "/SetAdjustmentsLosses":
                    var objSetAdjustmentsLossesRequest = JsonConvert.DeserializeObject<SetAdjustmentsLossesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objSetAdjustmentsLossesRequest, strTimeStamp);
                    break;
                case "/SetClosingCash":
                case "/SetClosingCashTransaction": //No se encuentra el Endpoint en COFOWSAPITPV
                    var objCashRequest = JsonConvert.DeserializeObject<CashRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objCashRequest, strTimeStamp);
                    break;
                case "/GetFailedTickets":
                    var objFailedTicketRequest = JsonConvert.DeserializeObject<FailedTicketRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objFailedTicketRequest, strTimeStamp);
                    break;
                case "/GetFamilies":
                    var objFamiliesRequest = JsonConvert.DeserializeObject<FamiliesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objFamiliesRequest, strTimeStamp);
                    break;
                case "/TransactionStatus": //No se encuentra el Endpoint en COFOWSAPITPV
                    break;
                case "/api/DeliveryNotes/COFOSetDeliveryNotesHandHeld/request":
                    var objErpDeliveryNotesHHLegacy = JsonConvert.DeserializeObject<ErpDeliveryNotesHHLegacy>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objErpDeliveryNotesHHLegacy, strTimeStamp);
                    break;
                default:
                    return BadRequest(new { error = $"Endpoint '{strEndpoint}' no es válido" });
            }

            return Ok(sGenerateSignatureInput);
        }
    }
}
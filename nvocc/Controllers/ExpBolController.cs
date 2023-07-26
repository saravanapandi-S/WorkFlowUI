using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataManager;
using DataTier;
using Microsoft.Extensions.Configuration;
using nvocc.FunServices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web;
using System.Drawing;
using Rectangle = iTextSharp.text.Rectangle;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Net.Mail;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpBolController : ControllerBase
    {
        List<MyBOLData> ListBol = new List<MyBOLData>();
        CommonAccessManager cm = new CommonAccessManager();
        BOLManger bl = new BOLManger();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }
        public ExpBolController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("CustomerMaster")]
        public List<MyCommonAccess> CustomerMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CustomerMaster();
            return st;
        }
        [HttpPost("BolMaster")]
        public List<MyBOLData> BolMaster(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.InsertBOLMaster(Data);
            return sl;
        }

        [HttpPost("BLNumber")]
        public List<BLNo> BLNumber(BLNo Data)
        {
            BOLManger bl = new BOLManger();
            List<BLNo> sl = bl.BLNumberList(Data);
            return sl;
        }



        [HttpPost("BkgPortVessel")]
        public List<MyBOLData> BkgPortVessel(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BkgPortDetails(Data);
            return sl;
        }

        [HttpPost("BLNumberValue")]
        public List<BLNo> BLNumberValue(BLNo Data)
        {
            BOLManger bl = new BOLManger();
            List<BLNo> sl = bl.BLNumberDtls(Data);
            return sl;
        }

        [HttpPost("BLTypes")]
        public List<BLTypes> BLTypes(BLTypes Data)
        {
            BOLManger bl = new BOLManger();
            List<BLTypes> sl = bl.BkgPortDetails(Data);
            return sl;
        }
        [HttpPost("BkgContainerDtls")]
        public List<BLContainer> BkgContainerDtls(BLContainer Data)
        {
            BOLManger bl = new BOLManger();
            List<BLContainer> sl = bl.BkgContainerDtls(Data);
            return sl;
        }
        [HttpPost("BLContainerDtls")]
        public List<BLContainer> BLContainerDtls(BLContainer Data)
        {
            BOLManger bl = new BOLManger();
            List<BLContainer> sl = bl.BLContainerDtls(Data);
            return sl;
        }
        [HttpPost("ShipperList")]
        public List<MyBOLData> ShipperList(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.ShipperName(Data);
            return sl;
        }
        [HttpPost("ConsigneeList")]
        public List<MyBOLData> ConsigneeList(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.Consignee(Data);
            return sl;
        }
        [HttpPost("NotifyList")]
        public List<MyBOLData> Notify(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.Notify(Data);
            return sl;
        }
        [HttpPost("NotifyAlsoList")]
        public List<MyBOLData> NotifyAlsoList(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.NotifyAlso(Data);
            return sl;
        }

        [HttpPost("ExistingBOLDtls")]
        public List<MyBOLData> ExistingBOLDtls(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.ExistingBOLDtls(Data);
            return sl;
        }
        //[HttpPost("ExistingBOLDefaultDtls")]
        //public List<MyBOLData> ExistingBOLDefaultDtls(MyBOLData Data)
        //{
        //    BOLManger bl = new BOLManger();
        //    List<MyBOLData> sl = bl.ExistingDefaultBOLDtls(Data);
        //    return sl;
        //}
        [HttpPost("ExistingPartiesDtls")]
        public List<MyBOLData> ExistingPartiesDtls(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.ExistingPartiesDtls(Data);
            return sl;
        }

        [HttpPost("UpdateBLStatus")]
        public List<MyBOLData> UpdateBLStatus(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateApprovalStatus(Data);
            return sl;
        }

        [HttpPost("BLNumberView")]
        public List<MyBOLData> BLNumberView(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLReleaseList(Data);
            return sl;
        }

        [HttpPost("BLNumberSurrenderView")]
        public List<MyBOLData> BLNumberSurrenderView(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLSurrenderList(Data);
            return sl;
        }

        [HttpPost("UpdateCntrDtls")]
        public List<MyBOLData> UpdateCntrDtls(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateCntrDtls(Data);
            return sl;
        }

        [HttpPost("BLAttachments")]
        public List<MyBOLData> BLAttachments(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLAttachmentView(Data);
            return sl;
        }
        [HttpPost("BLDeleteAttachments")]
        public List<MyBOLData> BLDeleteAttachments(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.DeletAttachDtls(Data);
            return sl;
        }
        [HttpPost("BLNotesList")]
        public List<BLNotes> BLNotesList(BLNotes Data)
        {
            BOLManger bl = new BOLManger();
            List<BLNotes> sl = bl.BLNotesList(Data);
            return sl;
        }

        [HttpPost("BLNotesExistList")]
        public List<BLNotes> BLNotesExistList(BLNotes Data)
        {
            BOLManger bl = new BOLManger();
            List<BLNotes> sl = bl.BLNotesExistList(Data);
            return sl;
        }

        [HttpPost("UpdateSubmitApprove")]
        public List<MyBOLData> UpdateSubmitApprove(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateSubmitApproveStatus(Data);
            return sl;
        }

        [HttpPost("UpdateApprovedBOL")]
        public List<MyBOLData> UpdateApprovedBOL(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateApprovedBOL(Data);
            return sl;
        }

        [HttpPost("UpdateRejectBOL")]
        public List<MyBOLData> UpdateRejectBOL(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateRejectBOL(Data);
            return sl;
        }

        [HttpPost("UpdateReleaseBOL")]
        public List<MyBOLData> UpdateReleaseBOL(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateReleaseBOL(Data);
            return sl;
        }

        [HttpPost("InsertTemplate")]
        public List<MyBOLData> InsertTemplate(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.InsertBLTemplate(Data);
            return sl;
        }
        [HttpPost("BLTemplateList")]
        public List<MyBOLData> BLTemplateList(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLTemplateListDtls(Data);
            return sl;
        }
        [HttpPost("BLTemplateChange")]
        public List<MyBOLData> BLTemplateChange(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLTemplateChangeDtls(Data);
            return sl;
        }

        [HttpPost("BLTemplateExistDtls")]
        public List<MyBOLData> BLTemplateExistDtls(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLTemplateExistDtls(Data);
            return sl;
        }


        [HttpPost("UpdateSOBDate")]
        public List<MyBOLData> UpdateSOBDate(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.UpdateSOBDate(Data);
            return sl;
        }
        [HttpPost("ExistingSOBDate")]
        public List<MyBOLData> ExistingSOBDate(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.ExistingSOBDate(Data);
            return sl;
        }

        [HttpPost("ApprovalBLNumbers")]
        public List<BLNo> ApprovalBLNumbers(BLNo Data)
        {
            BOLManger bl = new BOLManger();
            List<BLNo> sl = bl.ApprovalBLNumberList(Data);
            return sl;
        }

        [HttpPost("BLSurrenderInsert")]
        public List<MyBOLData> BLSurrenderInsert(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.InsertBLSurrenderDtls(Data);
            return sl;
        }

        [HttpPost("BLSurrenderAttachList")]
        public List<MyBOLData> BLSurrenderAttachList(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLSurrenderList(Data);
            return sl;
        }

        [HttpPost("BlSurrenderDelete")]
        public List<MyBOLData> BlSurrenderDelete(MyBOLData Data)
        {
            BOLManger bl = new BOLManger();
            List<MyBOLData> sl = bl.BLSurrenderDelete(Data);
            return sl;
        }


        [HttpPost("PrincipleMaster")]
        public List<MyBOLData> PrincipleMaster()
        {
            BOLManger cm = new BOLManger();
            List<MyBOLData> st = cm.PrincipleCustomerMaster();
            return st;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadShip")]
        public IActionResult UploadShip()
        {

            try
            {

                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "ShippingBill");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Length > 0)
                {
                   
                        var FileNamev = "";
                        var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
                        Random rd = new Random();
                        FileNamev = rd.Next(1000).ToString() + "_" + fileName;
                        // FileNamev = fileName;
                        var fullPath = Path.Combine(pathToSave, FileNamev);
                        var dbPath = Path.Combine(folderName, FileNamev);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            files.CopyTo(stream);
                        }
                        return Ok(new { dbPath });

                    }
                
            
                else
            {
                return BadRequest();

            }
        
            }
         
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }


        }


        [HttpGet, DisableRequestSizeLimit]
        [Route("downloadAttachShippingBill")]
        public async Task<IActionResult> downloadAttachShippingBill([FromQuery] string fileShipUrl)
        {
            var filePath = Path.Combine("UploadFolder", "ShippingBill", fileShipUrl);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "ShippingBill");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Length > 0)
                {
                    var FileNamev = "";
                    var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
                    Random rd = new Random();
                    FileNamev = rd.Next(1000).ToString() + "_" + fileName;
                    // FileNamev = fileName;
                    var fullPath = Path.Combine(pathToSave, FileNamev);
                    var dbPath = Path.Combine(folderName, FileNamev);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                    //return Ok();
                }

                else
                {
                    return BadRequest();
                }
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadApproval")]
        public IActionResult UploadApproval()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "CustomerApproval");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Length > 0)
                {
                    var FileNamev = "";
                    var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
                    Random rd = new Random();
                    FileNamev = rd.Next(1000).ToString() + "_" + fileName;
                    // FileNamev = fileName;
                    var fullPath = Path.Combine(pathToSave, FileNamev);
                    var dbPath = Path.Combine(folderName, FileNamev);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                    //return Ok();
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("downloadShippingBill")]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine("UploadFolder", "ShippingBill", fileUrl);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("downloadCustomerApproval")]
        public async Task<IActionResult> downloadCustomerApproval([FromQuery] string fileUrl2)
        {
            var filePath = Path.Combine("UploadFolder", "CustomerApproval", fileUrl2);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadSurrender")]
        public IActionResult UploadSurrender()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "SurrenderBL");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Length > 0)
                {
                    var FileNamev = "";
                    var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
                    Random rd = new Random();
                    FileNamev = rd.Next(1000).ToString() + "_" + fileName;
                    // FileNamev = fileName;
                    var fullPath = Path.Combine(pathToSave, FileNamev);
                    var dbPath = Path.Combine(folderName, FileNamev);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                    //return Ok();
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }




        [HttpGet, DisableRequestSizeLimit]
        [Route("downloadSurrender")]
        public async Task<IActionResult> downloadSurrender([FromQuery] string SurrenderfileUrl)
        {
            var filePath = Path.Combine("UploadFolder", "SurrenderBL", SurrenderfileUrl);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
        }

        //[HttpPost("VesselEmailSend")]
        //public List<MySendingEmailAlert> VesselEmailSend(MySendingEmailAlert Data)
        //{
        //    List<MySendingEmailAlert> ViewList = new List<MySendingEmailAlert>();
        //    string strHTML = "";



        //    //var EmailIDTo = Data.To.Split(',');
        //    //for (int y = 0; y < EmailIDTo.Length; y++)
        //    //{
        //    //    if (EmailIDTo[y].ToString() != "")
        //    //    {
        //    //        EmailObject.To.Add(new MailAddress(EmailIDTo[y].ToString()));
        //    //    }
        //    //}

        //    //var EmailIDCC = Data.CC.Split(',');
        //    //for (int y = 0; y < EmailIDCC.Length; y++)
        //    //{
        //    //    if (EmailIDCC[y].ToString() != "")
        //    //    {
        //    //        EmailObject.CC.Add(new MailAddress(EmailIDCC[y].ToString()));
        //    //    }
        //    //}

        //    //var EmailIDBCC = Data.BCC.Split(',');
        //    //for (int y = 0; y < EmailIDBCC.Length; y++)
        //    //{
        //    //    if (EmailIDBCC[y].ToString() != "")
        //    //    {
        //    //        EmailObject.CC.Add(new MailAddress(EmailIDBCC[y].ToString()));
        //    //    }
        //    //}


        //    strHTML = "<table border='0' cellpadding='0' cellspacing='0' width='80%' style='font-family:Arial;'>" +
        //                         "<tbody>" +
        //                         "<tr>" +
        //                         "<td style='border:none!important;'>" +
        //                         "<table cellpadding='0' cellspacing='0' width='100%' style='margin-bottom:15px;'>" +
        //                         "<tr><td style='padding-bottom:17px;'>Good Day!</td></tr>" +
        //                         "<tr><td style='padding-bottom:17px;'>Please note we are loading below container on subject vessel</td></tr>" +
        //                         "<tr><td>" +
        //                         "<table style='width:100%;' border='0'>" +
        //                         "<tr>" +
        //                         "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>PRINCIPAL</td><td style='padding-bottom:16px;'>MERCHANT</td>" +
        //                         "</tr>" +
        //                          "<tr>" +
        //                         "<td style='color:#535353;font-weight:600;padding-bottom:16px;'>SLOT</td><td style='padding-bottom:16px;'>SIMATECH</td>" +
        //                         "</tr>" +
        //                         "<tr>" +
        //                         "<td style='color:#535353;font-weight:600;padding-bottom:16px;'>VSL</td><td style='padding-bottom:16px;'>GFS GISELLE(V)0059</td>" +
        //                         "</tr>" +
        //                         "</table>" +
        //                         "</td></tr>" +
        //                         "</table>" +
        //                         "</td>" +
        //                         "</tr>" +
        //                         "<tr>" +
        //                         "<td>" +
        //                          "<table border='1' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom:15px;'>" +
        //                          "<tr>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>CONT NO</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>SIZE & TYPE</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>TYPE</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>TEMP/ODC</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>BL NO</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>COMMODITY TYPE</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>POL</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>POD</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>FPOD</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>DIRECT OR T/S</th>" +
        //                          "<th style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;background-color:#0f2555;color:#fff;'>SLOT OPERATOR</th>" +
        //                          "</tr>" +

        //                          "<tr>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "<td></td>" +
        //                          "</tr>" +
        //                          "</table>" +
        //                          "</td>" +
        //                          "</tr>" +
        //                          "<tbody>" +
        //                          "</table>";


        //    MailMessage EmailObject = new MailMessage();
        //    EmailObject.From = new MailAddress("info@odaksolutions.com", "Info Odak");
        //    EmailObject.To.Add(new MailAddress("anandmt122@gmail.com"));
        //    EmailObject.Subject = "PRE-ALERT";
        //    EmailObject.Body = strHTML;
        //    EmailObject.IsBodyHtml = true;
        //    EmailObject.Priority = MailPriority.Normal;
        //    SmtpClient SMTPServer = new SmtpClient();
        //    SMTPServer.UseDefaultCredentials = false;
        //    SMTPServer.Credentials = new NetworkCredential("info@odaksolutions.com", "Focus$321");
        //    SMTPServer.Port = 587;
        //    SMTPServer.Host = "smtp.office365.com";
        //    SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    SMTPServer.EnableSsl = true;
        //    SMTPServer.Send(EmailObject);

        //    //EmailObject.To.Add("anandmt122@gmail.com");
        //    //EmailObject.Body = strHTML;
        //    //EmailObject.IsBodyHtml = true;
        //    //EmailObject.Priority = MailPriority.Normal;
        //    //EmailObject.Subject = "PRE-ALERT";
        //    //EmailObject.Priority = MailPriority.Normal;
        //    //SmtpClient SMTPServer = new SmtpClient();
        //    //SMTPServer.UseDefaultCredentials = true;
        //    //SMTPServer.Credentials = new NetworkCredential("info@odaksolutions.com", "Focus$321");
        //    //SMTPServer.Host = "smtp.office365.com";
        //    //SMTPServer.ServicePoint.MaxIdleTime = 1;
        //    //SMTPServer.Port = 587;
        //    //SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    //SMTPServer.EnableSsl = true;
        //    //SMTPServer.Send(EmailObject);

        //    ViewList.Add(new MySendingEmailAlert
        //    {
        //        AlertMessage = "Email sent successfully"

        //    });

        //    return ViewList;
        //}
    }
}

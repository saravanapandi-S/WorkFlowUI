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
using System.Net.Http;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateApprovalController : ControllerBase
    {

        [HttpPost("BindPrinciples")]
        public List<MyRateApproval> BindPrinciples(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindPrinciplesList(Data);
            return st;
        }

        [HttpPost("BindRouteType")]
        public List<MyRateApproval> BindRouteType(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindRouteTypeList(Data);
            return st;
        }
        [HttpPost("BindDeliveryTerms")]
        public List<MyRateApproval> BindDeliveryTerms(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindDeliveryTermsList(Data);
            return st;
        }
        [HttpPost("BindEnquiry")]
        public List<MyRateApproval> BindEnquiry(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindEnquiryList(Data);
            return st;
        }
        [HttpPost("BindSalesPersonList")]
        public List<MyRateApproval> BindSalesPersonList(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindSalesPersonList(Data);
            return st;
        }
        [HttpPost("BindCargoTypes")]
        public List<MyRateApproval> BindCargoTypes(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindCargoTypesList(Data);
            return st;
        }
        [HttpPost("ExistEnquiryDetailsBind")]
        public List<MyRateApproval> ExistEnquiryDetailsBind(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.ExistEnquiryDetailsList(Data);
            return st;
        }

        [HttpPost("ExistEnquiryChargesBind")]
        public List<MyRateApprovalCharges> ExistEnquiryChargesBind(MyRateApprovalCharges Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApprovalCharges> st = cm.ExistEnquiryChargesBindList(Data);
            return st;
        }
        [HttpPost("RateApprovalSave")]
        public List<MyRateApproval> RateApprovalSave(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.InsertRateApproval(Data);
            return st;
        }
        [HttpPost("SubmitCopyRR")]
        public List<MyRateApproval> SubmitCopyRR(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.InsertSubmitCopyRR(Data);
            return st;
        }


        [HttpPost("RateApprovalView")]
        public List<MyRateApproval> RateApprovalView(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.RateApprovalViewList(Data);
            return st;
        }
        [HttpPost("RateApprovalEdit")]
        public List<MyRateApproval> RateApprovalEdit(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.RateApprovalEditList(Data);
            return st;
        }
        [HttpPost("RateApprovalChargesEdit")]
        public List<MyRateApprovalCharges> RateApprovalChargesEdit(MyRateApprovalCharges Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApprovalCharges> st = cm.RateApprovalChargesEdit(Data);
            return st;
        }
        [HttpPost("RateApprovalAttachmentView")]
        public List<MyRateApprovalCharges> RateApprovalAttachmentView(MyRateApprovalCharges Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApprovalCharges> st = cm.RateApprovalAttachmentView(Data);
            return st;
        }
        [HttpPost("SubmitRateApproval")]
        public List<MyRateApproval> SubmitRateApproval(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.InsertSubmitRateApproval(Data);
            return st;
        }
        [HttpPost("RejectRateApproval")]
        public List<MyRateApproval> RejectRateApproval(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.InsertRejectRateApproval(Data);
            return st;
        }
        [HttpPost("onCancelRateApproval")]
        public List<MyRateApproval> onCancelRateApproval(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.InsertCancelRateApproval(Data);
            return st;
        }
        [HttpPost("RRAttachDelete")]
        public List<MyRateApproval> RRAttachDelete(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.RRAttachDeleteMaster(Data);
            return st;
        }
        [HttpPost("BindEnquiryByoffice")]
        public List<MyRateApproval> BindEnquiryByoffice(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindEnquiryByofficeList(Data);
            return st;
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "Attachments");
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

        [HttpPost("BindDDReject")]
        public List<MyRateApproval> BindDDReject(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindDDRejectList(Data);
            return st;
        }
        [HttpPost("BindDDCancel")]
        public List<MyRateApproval> BindDDCancel(MyRateApproval Data)
        {
            RateApprovalManager cm = new RateApprovalManager();
            List<MyRateApproval> st = cm.BindDDCancelList(Data);
            return st;
        }
    }
}

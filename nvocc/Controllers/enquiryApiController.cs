using Microsoft.AspNetCore.Http;
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
using Microsoft.AspNetCore.StaticFiles;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class enquiryApiController : ControllerBase
    {
        [HttpPost("equiryPrincipalport")]
        public List<MyEnquiry> equiryPrincipalport(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.PriciblePortList(Data);
            return st;
        }

        [HttpPost("equiryPrincipalFreightCharges")]
        public List<MyEnquiry> equiryPrincipalFreightCharges(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.EnquiryOccenFreightCharges(Data);
            return st;
        }

        [HttpPost("equiryPrincipalRevenuCharges")]
        public List<MyEnquiry> equiryPrincipalRevenuCharges(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.EnquiryRevenuCostCharges(Data);
            return st;
        }

        [HttpPost("enquiryInsert")]
        public List<MyEnquiry> enquiryInsert(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.InsertenquiryMaster(Data);
            return st;
        }

        [HttpPost("exsistingenquiry")]
        public List<MyEnquiry> exsistingenquiry(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryvalues(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryBind")]
        public List<MyEnquiry> ExistingEnquiryBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryCntrTypeBind")]
        public List<MyEnquiry> ExistingEnquiryCntrTypeBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryCntrTypeBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryHazardousBind")]
        public List<MyEnquiry> ExistingEnquiryHazardousBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryHazardousBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryOutGaugeBind")]
        public List<MyEnquiry> ExistingEnquiryOutGaugeBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryOutGaugesBind(Data);
            return st;
        }


        [HttpPost("ExistingEnquiryRefferBind")]
        public List<MyEnquiry> ExistingEnquiryRefferBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryRefferBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryShimpmentPOLBind")]
        public List<MyEnquiry> ExistingEnquiryShimpmentPOLBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryShimpmentPOLBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryShimpmentPODBind")]
        public List<MyEnquiry> ExistingEnquiryShimpmentPODBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryShimpmentPODBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryFreightRateBind")]
        public List<MyEnquiry> ExistingEnquiryFreightRateBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryFreightRateBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquirySlotRateBind")]
        public List<MyEnquiry> ExistingEnquirySlotRateBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquirySlotRateBind(Data);
            return st;
        }


        [HttpPost("ExistingEnquiryRevenuRateBind")]
        public List<MyEnquiry> ExistingEnquiryRevenuRateBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryRevenuRateBind(Data);
            return st;
        }

        [HttpPost("InsertFromEnquiry")]
        public List<MyEnquiry> InsertDirectEnqBooking(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.InsertDirectEnqBooking(Data);
            return st;
        }


        [HttpPost("enquiryFreightBrackupInsert")]
        public List<MyEnquiry> enquiryFreightBrackupInsert(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.InsertEnquiryBrackupMaster(Data);
            return st;
        }


        [HttpPost("ExistingFreightBrackupvalues")]
        public List<MyEnquiry> ExistingFreightBrackupvalues(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryFreightBrackupvalues(Data);
            return st;
        }

        [HttpPost("ExistingBkgFreightBrackupvalues")]
        public List<MyEnquiry> ExistingBkgFreightBrackupvalues(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryBkgFreightBrackupvalues(Data);
            return st;
        }


        [HttpPost("ExistingCommodityHSCode")]
        public List<MyEnquiry> ExistingCommodityHSCode(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.BindCommodityHSCode(Data);
            return st;
        }

        [HttpPost("LinerMaster")]
        public List<MyEnquiry> LinerMaster(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.BindLinerMaster(Data);
            return st;
        }

        [HttpPost("CustomerContractMaster")]
        public List<MyEnquiry> CustomerContractMaster(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.BindCustomerContractMaster(Data);
            return st;
        }

        [HttpPost("enquiryCopyInsert")]
        public List<MyEnquiry> enquiryCopyInsert(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.InsertCopyEnquiry(Data);
            return st;
        }


        [HttpPost("enquiryStatusUpdate")]
        public List<MyEnquiry> enquiryStatusUpdate(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.InsertStatusUpdate(Data);
            return st;
        }

        [HttpPost("EnquiryCntrTypeDelete")]
        public List<MyEnquiry> EnquiryCntrTypeDelete(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.EnqDeleteCntrTypes(Data);
            return st;
        }


        [HttpPost("ExistingEnquiryAttched")]
        public List<MyEnquiry> ExistingEnquiryAttched(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryAttahced(Data);
            return st;
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine("UploadFolder", "Attachments", fileUrl);
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


        [HttpPost("EnquiryAttahcedDelete")]
        public List<MyEnquiry> EnquiryAttahcedDelete(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.EnqAttahcedDeletd(Data);
            return st;
        }

    }
}

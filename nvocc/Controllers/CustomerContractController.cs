
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

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContractController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public CustomerContractController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("CustomerContractInsert")]
        public List<MyCustomerContract> Contract(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.InsertCustomerContractMaster(Data);
            return st;
        }

        [HttpPost("CustomerMaster")]

        public List<MyCustomer> Customer(MyCustomer Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomer> st = cm.GetCustDropDownMaster(Data);
            return st;
        }
        [HttpPost("PrincipalMasterBind")]
        public List<MyPortAgency> GetPrincipalNames(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = cm.PrincipalList(Data);
            return st;
        }
        [HttpPost("RouteMaster")]
        public List<MyGeneralMaster> GetRouteMaster(MyGeneralMaster Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyGeneralMaster> st = cm.RouteMaster(Data);
            return st;
        }
        [HttpPost("DeliveryTermsMaster")]
        public List<MyGeneralMaster> GetDeliveryTerms(MyGeneralMaster Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyGeneralMaster> st = cm.DeliveryTermsMaster(Data);
            return st;
        }

        [HttpPost("SalesPersonMaster")]
        public List<MyCustomerContract> SalesPersonMaster(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.SalesPersonMaster(Data);
            return st;
        }

        [HttpPost("CustomerContractMasterView")]
        public List<MyCustomerContract> CustomeContractrMasterView(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.CustomerContractMasterView(Data);
            return st;
        }

        [HttpPost("CustomerContractMasterEdit")]
        public List<MyCustomerContract> CustomerContractMasterEdit(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.GetCustomerContractRecord(Data);
            return st;
        }
        [HttpPost("CargoTypeMaster")]
        public List<MyGeneralMaster> GetCargoTypes(MyGeneralMaster Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyGeneralMaster> st = cm.CargoTypeMaster(Data);
            return st;
        }
        [HttpPost("ContainerMasterEdit")]
        public List<MyCustomerContract> ContainerMasterEdit(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.ContainerMaster(Data);
            return st;
        }

        [HttpPost("RateReqDropDown")]
        public List<MyCustomerContract> RateReqDropDown(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.RateReqDropDown(Data);
            return st;
        }

        [HttpPost("ExRRValues")]
        public List<MyCustomerContract> ExRRValues(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.RateReqChange(Data);
            return st;
        }

        [HttpPost("ExRRContValues")]
        public List<MyCustomerContract> ExRRContValues(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.ExContainerMaster(Data);
            return st;
        }

        [HttpPost("InsertCopyContract")]
        public List<MyCustomerContract> InsertCopyContract(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.InsertCopyCustomerContractMaster(Data);
            return st;
        }

        [HttpPost("ApproveStatus")]
        public List<MyCustomerContract> ApproveStatus(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.UpdateApprovalStatus(Data);
            return st;
        }

        [HttpPost("RejectStatus")]
        public List<MyCustomerContract> RejectStatus(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.UpdateRejectStatus(Data);
            return st;
        }

        [HttpPost("CancelStatus")]
        public List<MyCustomerContract> CancelStatus(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.UpdateCancelStatus(Data);
            return st;
        }

        [HttpPost("AttachDelete")]
        public List<MyCustomerContract> AttachDelete(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.AttachDelete(Data);
            return st;
        }
        [HttpPost("AttachmentView")]
        public List<MyCustomerContract> AttachmentView(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.AttachmentView(Data);
            return st;
        }
        [HttpPost("RejectReason")]
        public List<MyGeneralMaster> RejectReason(MyGeneralMaster Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyGeneralMaster> st = cm.RejectReason(Data);
            return st;
        }
        [HttpPost("CancelReason")]
        public List<MyGeneralMaster> CancelReason(MyGeneralMaster Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyGeneralMaster> st = cm.CancelReason(Data);
            return st;
        }
        [HttpPost("ContainerDelete")]
        public List<MyCustomerContract> ContainerDelete(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.DeleteContractDtls(Data);
            return st;
        }

        [HttpPost("BindCustContractByoffice")]
        public List<MyCustomerContract> BindCustContractByoffice(MyCustomerContract Data)
        {
            CustomerContractManager cm = new CustomerContractManager();
            List<MyCustomerContract> st = cm.GetBindCustContractByoffice(Data);
            return st;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "CusContract");
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
    }
}

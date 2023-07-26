using DataManager;
using DataTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public InvoiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("OfficeLocationMaster")]
        public List<MyInvoice> OfficeLocationMaster()
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.OfficeLocationMaster();
            return st;
        }


        [HttpPost("OfficeTaxGSTNo")]
        public List<MyInvoice> OfficeTaxGSTNo(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.OfficeTaxGSTNo(Data);
            return st;
        }

        [HttpPost("GetCustomerNameList")]
        public List<MyInvoice> CustomerNameList(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.CustomerNameList(Data);
            return st;
        }

        [HttpPost("GetCustomerBranchCode")]
        public List<MyInvoice> CustomerBranchCode(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.CustomerBranchCode(Data);
            return st;
        }

        [HttpPost("GetCustomerGSTIN")]
        public List<MyInvoice> CustomerGSTIN(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.CustomerGSTIN(Data);
            return st;
        }

        [HttpPost("GetCustomerAddress")]
        public List<MyInvoice> CustomerAddress(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.CustomerAddress(Data);
            return st;
        }

        [HttpPost("GetInvoiceChargeCode")]
        public List<MyInvoice> InvoiceChargeCode(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.InvoiceChargeCode(Data);
            return st;
        }

        [HttpPost("GetCustomerGSTCategory")]
        public List<MyInvoice> CustomerGSTCategory(MyInvoice Data)
        {
            InvoiceManager cm = new InvoiceManager();
            List<MyInvoice> st = cm.CustomerGSTCategory(Data);
            return st;
        }


    }
}

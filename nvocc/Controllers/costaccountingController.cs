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

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class costaccountingController : Controller
    {

        CostAccountingMaster Manag = new CostAccountingMaster();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }
        public costaccountingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("IMCostAccountingList")]
        public List<myCostAccounting> IMCostAccountingList(myCostAccounting Data)
        {
            CostAccountingMaster cm = new CostAccountingMaster();
            List<myCostAccounting> st = cm.IMCostAccountingListView(Data);
            return st;
        }
        [HttpPost("EXportCostAccountingList")]
        public List<myCostAccounting> EXportCostAccountingList(myCostAccounting Data)
        {
            CostAccountingMaster cm = new CostAccountingMaster();
            List<myCostAccounting> st = cm.EXportCostAccountingListView(Data);
            return st;
        }


        [HttpPost("IMCostAccountingDrillDownList")]
        public List<myCostAccounting> IMCostAccountingDrillDownList(myCostAccounting Data)
        {
            
            CostAccountingMaster cm = new CostAccountingMaster();
            List<myCostAccounting> st = cm.IMCostAccountingDrillDownListView(Data);
            return st;
        }


        [HttpPost("ExportCostAccountingDrillDown")]
        public List<myCostAccounting> ExportCostAccountingDrillDownList(myCostAccounting Data)
        {

            CostAccountingMaster cm = new CostAccountingMaster();
            List<myCostAccounting> st = cm.ExportCostAccountingDrillDownList(Data);
            return st;
        }
    }
}



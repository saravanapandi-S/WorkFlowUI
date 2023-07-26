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
    public class ImdeliverydetailsController : Controller
    {

        ImdeliveryDetailsManager Manag = new ImdeliveryDetailsManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public ImdeliverydetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveDeliverydetails")]
        public List<ImdeliveryDetails> SaveDeliverydetails(ImdeliveryDetails Data)
        {
            ImdeliveryDetailsManager cm = new ImdeliveryDetailsManager();
            List<ImdeliveryDetails> st = cm.GetSaveDeliverydetails(Data);
            return st;
        }

        [HttpPost("DeliverydetailsEdit")]
        public List<ImdeliveryDetails> DeliverydetailsEdit(ImdeliveryDetails Data)
        {
            ImdeliveryDetailsManager cm = new ImdeliveryDetailsManager();
            List<ImdeliveryDetails> st = cm.GetDeliverydetailsEdit(Data);
            return st;
        }

        [HttpPost("IMVesselValues")]
        public List<ImdeliveryDetails> IMVesselValues(ImdeliveryDetails Data)
        {
            ImdeliveryDetailsManager cm = new ImdeliveryDetailsManager();
            List<ImdeliveryDetails> st = cm.GetIMVesselValues(Data);
            return st;
        }
    }
}





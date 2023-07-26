
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
    public class ExportBookingController : ControllerBase
    {
        ExportBookingManager Manag = new ExportBookingManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public ExportBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("BookingBind")]
        public List<MyExportBooking> BookingBind(MyExportBooking Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExportBooking> st = cm.ExistingBooking(Data);
            return st;
        }

        [HttpPost("ExBookingCntrBind")]
        public List<MyExpBkgContainer> ExBookingCntrBind(MyExpBkgContainer Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgContainer> st = cm.ExistingBookingCntrBind(Data);
            return st;
        }

        [HttpPost("ExBookingHazBind")]
        public List<MyExpBkgHaz> ExBookingHazBind(MyExpBkgHaz Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgHaz> st = cm.ExistingHazardous(Data);
            return st;
        }

        [HttpPost("ExBookingOutBind")]
        public List<MyExpBkgOutGauge> ExBookingOutBind(MyExpBkgOutGauge Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgOutGauge> st = cm.ExistingOutGauge(Data);
            return st;
        }

        [HttpPost("ExBookingReeferBind")]
        public List<MyExpBkgReefer> ExBookingReeferBind(MyExpBkgReefer Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgReefer> st = cm.ExistingReefer(Data);
            return st;
        }

        [HttpPost("ExistingOceanFrtCharges")]
        public List<MyExpBkgOceanFrtCharges> ExistingOceanFrtCharges(MyExpBkgOceanFrtCharges Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgOceanFrtCharges> st = cm.ExistingOceanFrtCharges(Data);
            return st;
        }

        [HttpPost("ExistingSlotFrtCharges")]
        public List<MyExpBkgOceanFrtCharges> ExistingSlotFrtCharges(MyExpBkgOceanFrtCharges Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgOceanFrtCharges> st = cm.ExistingSlotFrtCharges(Data);
            return st;
        }

        [HttpPost("ExistingPOL")]
        public List<MyExpBkgShipmentTerms> ExistingPOL(MyExpBkgShipmentTerms Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgShipmentTerms> st = cm.ExistingPOL(Data);
            return st;
        }
        [HttpPost("ExistingPOD")]
        public List<MyExpBkgShipmentTerms> ExistingPOD(MyExpBkgShipmentTerms Data)
        {
            ExportBookingManager cm = new ExportBookingManager();
            List<MyExpBkgShipmentTerms> st = cm.ExistingPOD(Data);
            return st;
        }
    }
}

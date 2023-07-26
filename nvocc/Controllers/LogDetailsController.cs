
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
    public class LogDetailsController : ControllerBase
    {
        LogManager Manag = new LogManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public LogDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("LogDetails")]
        public List<MyLogData> Contract(MyLogData Data)
        {
            LogManager cm = new LogManager();
            List<MyLogData> st = cm.GetLogDetails(Data);
            return st;
        }

        [HttpPost("LogInsert")]
        public List<MyLogData> LogInsert(MyLogData Data)
        {
            LogManager cm = new LogManager();
            List<MyLogData> st = cm.InsertLogMaster(Data);
            return st;
        }


    }
}

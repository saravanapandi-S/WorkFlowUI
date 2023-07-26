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
    public class MovementUploadConfigController : ControllerBase
    {
        MovementUploadConfigMaster Manag = new MovementUploadConfigMaster();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public MovementUploadConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveMovementUpload")]
        public List<MyMovementUploadConfig> SaveMovementUploadValue(MyMovementUploadConfig Data)
        {
            MovementUploadConfigMaster cm = new MovementUploadConfigMaster();
            List<MyMovementUploadConfig> st = cm.SaveMovementUploadValue(Data);
            return st;
        }

        [HttpPost("MovementUploadList")]
        public List<MyMovementUploadConfig> MovementUploadList(MyMovementUploadConfig Data)        {
            
            MovementUploadConfigMaster cm = new MovementUploadConfigMaster();
            List<MyMovementUploadConfig> st = cm.GetMovementUploadList(Data);
            return st;
        }
        [HttpPost("MovementUploadEdit")]
        public List<MyMovementUploadConfig> MovementUploadEdit(MyMovementUploadConfig Data)
        {

            MovementUploadConfigMaster cm = new MovementUploadConfigMaster();
            List<MyMovementUploadConfig> st = cm.GetMovementUploadEdit(Data);
            return st;
        }
    }
}

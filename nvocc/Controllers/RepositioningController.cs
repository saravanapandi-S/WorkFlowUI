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
    public class RepositioningController : ControllerBase
    {
        RepositioningManager Manag = new RepositioningManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public RepositioningController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SaveRepositioning")]
        public List<MyRepositioning> SaveRepositioning (MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();

            List<MyRepositioning> st = cm.GetSaveRepositioning(Data);
            return st;
        }
        [HttpPost("RepositioningList")]
        public List<MyRepositioning> RepositioningList(MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();

            List<MyRepositioning> st = cm.GetRepositioningList (Data);
            return st;
        }
        [HttpPost("RepositioningEdit")]
        public List<MyRepositioning> RepositioningEdit(MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();

            List<MyRepositioning> st = cm.GetRepositioningEdit(Data);
            return st;
        }
        [HttpPost("RepositioningCntrsEdit")]
        public List<MyRepositioning> RepositioningCntrsEdit(MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();

            List<MyRepositioning> st = cm.GetRepositioningCntrsEdit(Data);
            return st;
        }


        [HttpPost("getValidCntrvalues")]
        public List<MyRepositioning> getValidCntrvalues(MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();
            List<MyRepositioning> st = cm.BindValidContainerNos(Data);
            return st;
        }

        [HttpPost("SaveRepositioningCntrs")]
        public List<MyRepositioning> SaveRepositioningCntrs(MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();

            List<MyRepositioning> st = cm.SaveRepositioningCntrsValues(Data);
            return st;
        }

        [HttpPost("RepositioningCntrsTabView")]
        public List<MyRepositioning> RepositioningCntrsTabView(MyRepositioning Data)
        {
            RepositioningManager cm = new RepositioningManager();
            List<MyRepositioning> st = cm.BindRepositioningCntrsTabView(Data);
            return st;
        }

    }
}

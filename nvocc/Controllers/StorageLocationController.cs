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
    public class StorageLocationController : ControllerBase
    { 

         StorageLocationMaster Manag = new StorageLocationMaster();
    private readonly IConfiguration _configuration;

    public object Server { get; private set; }
    public object MimeMapping { get; private set; }

    public StorageLocationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
        [HttpPost("PortCodeMasterBind")]
        public List<MyStoragelocation> PortCodeMasterBindView(MyStoragelocation Data)
        {
            StorageLocationMaster cm = new StorageLocationMaster();
            List<MyStoragelocation> st = cm.GetPortCodeMasterBindView(Data);
            return st;
        }

        [HttpPost("SaveStoragealocation")]
        public List<mystoragelocationsave> SaveStoragealocation(mystoragelocationsave Data)
        {
            StorageLocationMaster cm = new StorageLocationMaster();
            List<mystoragelocationsave> st = cm.GetSaveStoragealocation(Data);
            return st;
        }
        [HttpPost("StorageLocationList")]
        public List<mystoragelocationsave> StorageLocationList(mystoragelocationsave Data)
        {
            StorageLocationMaster cm = new StorageLocationMaster();
            List<mystoragelocationsave> st = cm.GetStorageLocationList(Data);
            return st;
        }
        [HttpPost("StorageLocationEdit")]
        public List<mystoragelocationsave> StorageLocationEdit(mystoragelocationsave Data)
        {
            StorageLocationMaster cm = new StorageLocationMaster();
            List<mystoragelocationsave> st = cm.GetStorageLocationEdit(Data);
            return st;
        }
    }
}




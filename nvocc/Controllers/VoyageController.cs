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
    public class VoyageController : ControllerBase
    {
        VoyageManager Manag = new VoyageManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public VoyageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("Vesseldropdown")]
        public List<myVoyage> Vesseldropdown(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVesseldorpdown(Data);
            return st;
        }
        [HttpPost("VoyageTypedropdown")]
        public List<myVoyage> VoyageTypedropdown(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVoyageNoteTypedropdown(Data);
            return st;
        }
        [HttpPost("Terminaldropdown")]
        public List<myVoyage> Terminaldropdown(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetTerminaldropdown(Data);
            return st;
        }
        [HttpPost("InsertVoyageform")]
        public List<myVoyage> InsertVoyageform(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.InsertVoyageContracts(Data);
            return st;
        }
        [HttpPost("VoyageViewlist")]
        public List<myVoyage> VoyageViewlist(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVoyageViewlist(Data);
            return st;
        }
        [HttpPost("VoyageEdit")]
        public List<myVoyage> VoyageEdit(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVoyageEdit(Data);
            return st;
        }
        [HttpPost("VoyageEditTerminal")]
        public List<myVoyage> VoyageEditTerminal(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVoyageEditTerminal(Data);
            return st;
        }
        [HttpPost("VoyNoteEdit")]
        public List<myVoyage> VoyNoteEdit(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVoyNoteEdit(Data);
            return st;
        }
        [HttpPost("TeminalDelete")]
        public List<myVoyage> TeminalDelete(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetTeminalDeletet(Data);
            return st;
        }
        [HttpPost("VoyageNoteDelete")]
        public List<myVoyage> VoyageNoteDelete(myVoyage Data)
        {
            VoyageManager cm = new VoyageManager();
            List<myVoyage> st = cm.GetVoyageNoteDelete(Data);
            return st;
        }
    }

}


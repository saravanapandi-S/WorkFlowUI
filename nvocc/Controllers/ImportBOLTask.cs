using DataManager;
using DataTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace nvocc.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImportBOLTask : ControllerBase
    {
        ImpBOL Manag = new ImpBOL();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public ImportBOLTask(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("ImportBOLView")]
        public List<MyImpBOL> ImportBOLView(MyImpBOL Data)
        {
            ImpBOL cm = new ImpBOL();
            List<MyImpBOL> st = cm.ImportBOLView(Data);
            return st;
        }

        [HttpPost("ImportBOLVsDisplay")]
        public List<MyImpBOL> ImportBOLVsDisplay(MyImpBOL Data)
        {
            ImpBOL cm = new ImpBOL();
            List<MyImpBOL> st = cm.ImportBOLVsDisplay(Data);
            return st;
        }

        [HttpPost("ImportBOLStatusView")]
        public List<MyImpBOL> ImportBOLStatusView(MyImpBOL Data)
        {
            ImpBOL cm = new ImpBOL();
            List<MyImpBOL> st = cm.ImportBOLStatusView(Data);
            return st;
        }

        [HttpPost("ImportBOLSearchView")]
        public List<MyImpBOL> ImportBOLSearchView(MyImpBOL Data)
        {
            ImpBOL cm = new ImpBOL();
            List<MyImpBOL> st = cm.ImportBOLSearchView(Data);
            return st;
        }

        [HttpPost("ImportBOLContainerView")]
        public List<MyImpBOL> ImportBOLContainerView(MyImpBOL Data)
        {
            ImpBOL cm = new ImpBOL();
            List<MyImpBOL> st = cm.ImportBOLContainerView(Data);
            return st;
        }

    }
}

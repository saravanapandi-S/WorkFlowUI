using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataManager;
using DataTier;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using nvocc.FunServices;
using System.Net.Http.Headers;


namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotApiController : ControllerBase
    {
        [HttpPost("SlotView")]
        public List<MySLotManagement> SlotView(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.GetSlotMaster(Data);
            return st;
        }
        [HttpPost("VoyageBind")]
        public List<MyVoyage> VoyageView(MyVoyage Data)
        {
            SlotManager cm = new SlotManager();
            List<MyVoyage> st = cm.GetVoyageMasterDropDown(Data);
            return st;
        }
        [HttpPost("VoyageBindMaster")]
        public List<MyVoyage> VoyageBindMaster(MyVoyage Data)
        {
            SlotManager cm = new SlotManager();
            List<MyVoyage> st = cm.GetVoyageBindMaster(Data);
            return st;
        }
        [HttpPost("BindVoyageETAETD")]
        public List<MySLotManagement> BindVoyageETAETD(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.GetBindVoyageETAETD(Data);
            return st;
        }

        [HttpPost("VOAList")]
        public List<MyVOA> VOAList(MyVOA Data)
        {
            SlotManager cm = new SlotManager();
            List<MyVOA> st = cm.GetVOAMasterDropDown(Data);
            return st;
        }

        [HttpPost("SlotSearch")]
        public List<MySLotManagement> SlotSearch(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.GetSlotRecord(Data);
            return st;
        }

        [HttpPost("InsertSlotdtls")]
        public List<MySlotRecords> InsertSlotdtls(MySlotRecords Data)
        {

            SlotManager cm = new SlotManager();
            List<MySlotRecords> st = cm.InsertSlotdetails(Data);
            return st;
        }

        //[HttpPost("SlotAttachments")]
        //public List<MySlotAttach> SlotAttachments(MySlotAttach Data)
        //{
        //    SlotManager cm = new SlotManager();
        //    List<MySlotAttach> st = cm.insertslotAttachments(Data);
        //    return st;
        //}

        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "SlotAttachment");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Length > 0)
                {
                    var FileNamev = "";
                    var fileName = ContentDispositionHeaderValue.Parse(files.ContentDisposition).FileName.Trim('"');
                    Random rd = new Random();
                    FileNamev = rd.Next(1000).ToString() + "_" + fileName;
                    // FileNamev = fileName;
                    var fullPath = Path.Combine(pathToSave, FileNamev);
                    var dbPath = Path.Combine(folderName, FileNamev);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                    //return Ok();
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        [HttpPost("EditSlotLoadMaster")]
        public List<LoadSlotInit> EditSlotLoadMaster(LoadSlotInit Data)
        {
            SlotManager cm = new SlotManager();
            List<LoadSlotInit> st = cm.EditSlotMaster(Data);
            return st;
        }

        [HttpPost("ExistingSlotLoad")]
        public List<MySlotRecords> ExistingSlotLoad(MySlotRecords Data)
        {
            SlotManager cm = new SlotManager();
            List<MySlotRecords> st = cm.ViewExistingSlotLoad(Data);
            return st;

        }
        [HttpPost("SlotMgtDtlsEdit")]
        public List<MySLotManagement> ExistingSlotLoad1(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.ViewExistingSlotDtls(Data);
            return st;
        }
        [HttpPost("SpacePlanningView")]
        public List<MySlotRecords> SpacePlanningView(MySlotRecords Data)
        {
            SlotManager cm = new SlotManager();
            List<MySlotRecords> st = cm.GetSpacePlanning(Data);
            return st;
        }
        [HttpPost("SlotMgtDtlsRemoveValues")]
        public List<MySLotManagement> SlotMgtDtlsRemove(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.SlotMgtDtlsRemoveValues(Data);
            return st;
        }
        [HttpPost("InsertAttachment")]
        public List<MySLotManagement> InsertAttachment(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.SlotMgtDtlsInsertAttachment(Data);
            return st;
        }

        [HttpPost("SlotMgtCountDtlsView")]
        public List<MySLotManagement> SlotMgtCountDtlsView(MySLotManagement Data)
        {
            SlotManager cm = new SlotManager();
            List<MySLotManagement> st = cm.GetSlotMgtCountDtlsView(Data);
            return st;
        }

    }

}

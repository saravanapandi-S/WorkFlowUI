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
using System.Net.Http;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.StaticFiles;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BkgLevelController : ControllerBase
    {

        [HttpPost("BkgLevelBolListView")]
        public List<MyBkgLevel> BkgLevelBolListView(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BkgLevelBolListViewvalues(Data);
            return st;
        }
        [HttpPost("BkgLevelVesselListView")]
        public List<MyBkgLevel> ExistingBookinglevel(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.ExistingBookinglevelvalues(Data);
            return st;
        }
        [HttpPost("BkgLevelTaskSearchView")]
        public List<MyBkgLevel> BkgLevelTaskSearchView(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BkgLevelTaskSearchViewvalues(Data);
            return st;
        }
        [HttpPost("BindBookingNoList")]
        public List<MyBkgLevel> BindBookingNoList(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BindBookingNoListvalues(Data);
            return st;
        }
        [HttpPost("BindBLNoList")]
        public List<MyBkgLevel> BindBLNoList(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BindBLNoListvalues(Data);
            return st;
        }
        [HttpPost("BindBkgPartyList")]
        public List<MyBkgLevel> BindBkgPartyList(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BindBkgPartyListvalues(Data);
            return st;
        }
        [HttpPost("BindVesselVoyList")]
        public List<MyBkgLevel> BindVesselVoyList(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BindVesselVoyListvalues(Data);
            return st;
        }
        [HttpPost("BindCntrNos")]
        public List<MyBkgLevel> BindCntrNosList(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BindCntrNosListvalues(Data);
            return st;
        }
        [HttpPost("BindUserDetails")]
        public List<MyBkgLevel> BindUserDetails(MyBkgLevel Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgLevel> st = cm.BindUserDetailsvalues(Data);
            return st;
        }
        #region BkgdOCS
        [HttpPost("ViewDocsHazlist")]
        public List<BkgDocsList> ViewDocsHazlist(BkgDocsList Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<BkgDocsList> st = cm.ViewDocsHazlistvalues(Data);
            return st;
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "BkgDocs");
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

        [HttpPost("BkgDocSave")]
        public List<MyBkgDocs> BkgDocSave(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.InsertBkgDocSave(Data);
            return st;
        }
        [HttpPost("ViewDocsOOGlist")]
        public List<MyBkgDocs> ViewDocsOOGlist(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.ViewDocsOOGlistvalues(Data);
            return st;
        }
        [HttpPost("BkgDocOOGSave")]
        public List<MyBkgDocs> BkgDocOOGSave(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.InsertBkgDocOOGSave(Data);
            return st;
        }
        [HttpPost("ViewDocsReeferlist")]
        public List<MyBkgDocs> ViewDocsReeferlist(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.ViewDocsReeferlistvalues(Data);
            return st;
        }
        [HttpPost("ViewDocsOdolist")]
        public List<MyBkgDocs> ViewDocsOdolist(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.ViewDocsOdolistvalues(Data);
            return st;
        }
        [HttpPost("BkgDocODOSave")]
        public List<MyBkgDocs> BkgDocODOSave(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.InsertBkgDocODOSave(Data);
            return st;
        }
        [HttpPost("ViewDocsHazAttachlist")]
        public List<MyBkgDocs> ViewDocsHazAttachlist(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.ViewDocsHazAttachlistvalues(Data);
            return st;
        }
        [HttpPost("ViewDocsOOGAttachlist")]
        public List<MyBkgDocs> ViewDocsOOGAttachlist(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.ViewDocsOOGAttachlistvalues(Data);
            return st;
        }
        [HttpPost("ViewDocsODOAttachlist")]
        public List<MyBkgDocs> ViewDocsODOAttachlist(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.ViewDocsODOAttachlistvalues(Data);
            return st;
        }

        [HttpPost("DocsAttachDelete")]
        public List<MyBkgDocs> DocsAttachDelete(MyBkgDocs Data)
        {
            BkgLevelManager cm = new BkgLevelManager();
            List<MyBkgDocs> st = cm.DocsAttachDeleteMaster(Data);
            return st;
        }
        #endregion

        [HttpGet, DisableRequestSizeLimit]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine("UploadFolder", "BkgDocs", fileUrl);
            // var folderName = Path.Combine("UploadFolder", "BkgDocs");
            // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}

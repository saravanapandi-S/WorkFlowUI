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
    public class CntrPickDropController : ControllerBase
    {
        #region Cntrpickdrop
        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "Attachments");
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

        [HttpPost("BindPickUpDropTypes")]
        public List<MyCntrPickDrop> BindPickUpDropTypes(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindPickUpDropTypesList(Data);
            return st;
        }
        [HttpPost("BindPickUpDropTypesDrop")]
        public List<MyCntrPickDrop> BindPickUpDropTypesDrop(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindPickUpDropTypesDropList(Data);
            return st;
        }

        [HttpPost("BindStorageLocation")]
        public List<MyCntrPickDrop> BindStorageLocation(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindStorageLocationList(Data);
            return st;
        }
        [HttpPost("BindCntrTypes")]
        public List<MyCntrPickDrop> BindCntrTypes(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindCntrTypesList(Data);
            return st;
        }

        [HttpPost("BindOwningTypes")]
        public List<MyCntrPickDrop> BindOwningTypes(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindOwningTypesList(Data);
            return st;
        }
        [HttpPost("BindCntrNos")]
        public List<MyCntrPickDrop> BindCntrNos(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindCntrNosList(Data);
            return st;
        }

        [HttpPost("BindISOCodesByType")]
        public List<MyCntrPickDrop> BindISOCodesByType(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindISOCodesByTypeList(Data);
            return st;
        }
        [HttpPost("CntrPickDropSave")]
        public List<MyCntrPickDrop> CntrPickDropSave(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.InsertCntrPickDropSave(Data);
            return st;
        }
        [HttpPost("CntrPickDropListView")]
        public List<MyCntrPickDrop> CntrPickDropListView(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindCntrPickDropListView(Data);
            return st;
        }
        [HttpPost("CntrPickDropListEdit")]
        public List<MyCntrPickDrop> CntrPickDropListEdit(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindCntrPickDropListEdit(Data);
            return st;
        }
        [HttpPost("CntrPickDropCntrsEdit")]
        public List<MyCntrPickDrop> CntrPickDropCntrsEdit(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindCntrPickDropCntrsEdit(Data);
            return st;
        }


        [HttpPost("OfficeLocByUser")]
        public List<MyCntrPickDrop> OfficeLocByUser(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.OfficeLocByUserMaster(Data);
            return st;
        }

        [HttpPost("ExcelContainersSave")]
        public List<MyCntrPickDrop> ExcelContainersSave(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.InsertExcelContainersSave(Data);
            return st;
        }
        #endregion

        #region CntrTrace
        [HttpPost("BindCntrNosList")]
        public List<MyCntrPickDrop> BindCntrNosList(MyCntrPickDrop Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrPickDrop> st = cm.BindCntrNosListValues(Data);
            return st;
        }

        [HttpPost("CntrTraceView")]
        public List<MyCntrTrace> CntrTraceView(MyCntrTrace Data)
        {
            CntrPickDropManager cm = new CntrPickDropManager();
            List<MyCntrTrace> st = cm.BindCntrTraceView(Data);
            return st;
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine("UploadFolder", "ExcelTemplate", fileUrl);
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
        #endregion
    }
}

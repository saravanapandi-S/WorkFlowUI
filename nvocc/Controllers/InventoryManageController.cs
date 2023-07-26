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
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Net.Mail;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryManageController : ControllerBase
    {
        [HttpPost("EmtyCntrStatusViewlist")]
        public List<MyInventory> EmtyCntrStatusViewlist(MyInventory Data)
        {
            InventoryManger cm = new InventoryManger();
            List<MyInventory> st = cm.GetEmtyCntrStatusViewlistr(Data);
            return st;
        }

        [HttpPost("EmtyIdlingViewlist")]
        public List<MyInventory> EmtyIdlingViewlist(MyInventory Data)
        {
            InventoryManger cm = new InventoryManger();
            List<MyInventory> st = cm.GetEmtyIdlingViewlist(Data);
            return st;
        }

        [HttpPost("ContainerStockViewlist")]
        public List<MyInventory> ContainerStockViewlist(MyInventory Data)
        {
            InventoryManger cm = new InventoryManger();
            List<MyInventory> st = cm.GetContainerStockViewlist(Data);
            return st;
        }

        [HttpPost("ViewLongIdlingWithConsigViewlist")]
        public List<MyInventory> ViewLongIdlingWithConsigViewlist(MyInventory Data)
        {
            InventoryManger cm = new InventoryManger();
            List<MyInventory> st = cm.GetViewLongIdlingWithConsigViewlist(Data);
            return st;
        }

        [HttpPost("ViewLongIdlingWithShipper")]
        public List<MyInventory> ViewLongIdlingWithShipper(MyInventory Data)
        {
            InventoryManger cm = new InventoryManger();
            List<MyInventory> st = cm.GetViewLongIdlingWithShipper(Data);
            return st;
        }
        [HttpPost("MixUpCntrStatusViewlist")]
        public List<MyInventory> MixUpCntrStatusViewlist(MyInventory Data)
        {
            InventoryManger cm = new InventoryManger();
            List<MyInventory> st = cm.GetMixUpCntrStatusViewlist(Data);
            return st;
        }
    }
}

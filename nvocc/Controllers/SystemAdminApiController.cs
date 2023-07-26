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
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Net.Mail;
using System.Net;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAdminApiController : ControllerBase
    {
        #region Common Api's

        [HttpPost("GetCountries")]
        public List<MySACountry> GetCountries()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySACountry> st = cm.GetCountries();
            return st;
        }


        [HttpPost("GetState")]
        public List<MySAState> GetStates()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAState> st = cm.GetStates();
            return st;
        }

        [HttpPost("GetStates")]
        public List<MySAState> GetStatesByCountry(MySAState Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAState> st = cm.GetStatesByCountry(Data);
            return st;
        }

        [HttpPost("GetCity")]
        public List<MySACity> GetCity()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySACity> st = cm.GetCity();
            return st;
        }
        [HttpPost("GetCities")]
        public List<MySACity> GetCities(MySACity Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySACity> st = cm.GetCities(Data);
            return st;
        }

        [HttpPost("GetPort")]
        public List<MySAPort> GetPort()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetPort();
            return st;
        }

        [HttpPost("GetPorts")]
        public List<MySAPort> GetPort(MySAPort Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetPorts(Data);
            return st;
        }

        [HttpPost("GetSeaPortsByCountry")]
        public List<MySAPort> GetSeaPortsByCountry(MySAPort Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetSeaPortsByCountry(Data);
            return st;
        }


        [HttpPost("GetICDPortsByCountry")]
        public List<MySAPort> GetICDPortsByCountry(MySAPort Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetICDPortsByCountry(Data);
            return st;
        }

        [HttpPost("GetAirPortsByCountry")]
        public List<MySAPort> GetAirPortsByCountry(MySAPort Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetAirPortsByCountry(Data);
            return st;
        }



        [HttpPost("GetSeaPorts")]
        public List<MySAPort> GetSeaPort()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetSeaPorts();
            return st;
        }

        [HttpPost("GetICDPorts")]
        public List<MySAPort> GetICDPort()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetICDPorts();
            return st;
        }

        [HttpPost("GetAirPorts")]
        public List<MySAPort> GetAirPort()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPort> st = cm.GetAirPorts();
            return st;
        }

        [HttpPost("GetTerminal")]
        public List<MySATerminal> GetTerminalByPort(MySATerminal Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySATerminal> st = cm.GetTerminalByPort(Data);
            return st;
        }

        [HttpPost("GetShipmentLocation")]
        public List<MySAShipmentLocation> GetShipmentLocations()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAShipmentLocation> st = cm.GetShipmentLocations();
            return st;
        }
        [HttpPost("GetShipmentLocations")]
        public List<MySAShipmentLocation> GetShipmentLocationsByCountry(MySAShipmentLocation Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAShipmentLocation> st = cm.GetShipmentLocationsByCountry(Data);
            return st;
        }
        [HttpPost("GetCommodities")]
        public List<MySACommodity> GetCommoditiesvalues()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySACommodity> st = cm.GetCommodities();
            return st;
        }
        [HttpPost("GetPackageTypes")]
        public List<MySAPackageType> GetPackageTypes()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAPackageType> st = cm.GetPackageTypes();
            return st;
        }

        [HttpPost("GetContainerTypes")]
        public List<MySAContainerType> GetContainerTypes()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAContainerType> st = cm.GetContainerTypes();
            return st;
        }
        [HttpPost("GetContainerTypeDetails")]
        public List<MySAContainerTypeDetails> GetContainerTypeDetails(MySAContainerTypeDetails Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAContainerTypeDetails> st = cm.GetContainerTypeDetails(Data);
            return st;
        }
        [HttpPost("GetCntrTypeDetailsByGroup")]
        public List<MySAContainerTypeDetails> GetCntrTypeDetailsByGroup(MySAContainerTypeDetails Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAContainerTypeDetails> st = cm.GetCntrTypeDetailsByGroup(Data);
            return st;
        }
        [HttpPost("GetHazClasses")]
        public List<MySAHazClass> GetHazClasses()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAHazClass> st = cm.GetHazClasses();
            return st;
        }

        [HttpPost("GetCompanyDetails")]
        public List<MyCompany> GetCompanyDetails()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyCompany> st = cm.GetCompanyDetails();
            return st;
        }

        [HttpPost("GetCommodityDetails")]
        public List<MyCommodity> GetCommodityDetails(MyCommodity Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyCommodity> st = cm.GetCommodityDetails(Data);
            return st;
        }
        [HttpPost("GetContainerGroups")]
        public List<MySAContainerGroup> GetContainerGroups()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAContainerGroup> st = cm.GetContainerGroups();
            return st;
        }

        [HttpPost("GetCurrency")]
        public List<MySACurrency> GetCurrency()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySACurrency> st = cm.GetCurrency();
            return st;
        }
        [HttpPost("GetCurrencies")]
        public List<MySACurrency> GetCurrencies(MySACurrency Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySACurrency> st = cm.GetCurrencies(Data);
            return st;
        }

        [HttpPost("GetUOM")]
        public List<MySAUOM> GetUOM()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAUOM> st = cm.GetUOM();
            return st;
        }

        [HttpPost("GetUOMByType")]
        public List<MySAUOM> GetUOMByType(MySAUOM Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAUOM> st = cm.GetUOMByType(Data);
            return st;
        }

        [HttpPost("GetEmailConfiguration")]
        public List<MySAEmailConfig> GetEmailConfiguration()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAEmailConfig> st = cm.GetEmailConfiguration();
            return st;
        }

        [HttpPost("GetUOMTypes")]
        public List<MySAUOMTypes> GetUOMTypes()
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MySAUOMTypes> st = cm.GetUOMTypes();
            return st;
        }

        #endregion

        #region Instance Profile

        [HttpPost("SaveCompany")]
        public List<MyCompany> Company(MyCompany Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyCompany> st = cm.InsertCompanyMaster(Data);
            return st;
        }

        [HttpPost("GetCompanyView")]
        public List<MyCompany> GetCompanyView(MyCompany Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyCompany> st = cm.GetCompanyView(Data);
            return st;
        }
        [HttpPost("GetCompanyEdit")]
        public List<MyCompany> GetCompanyEdit(MyCompany Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyCompany> st = cm.GetCompanyEdit(Data);
            return st;
        }

        [HttpPost("SaveConfig")]
        public List<MyConfig> SaveConfig(MyConfig Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyConfig> st = cm.InsertSaveConfig(Data);
            return st;
        }

        [HttpPost("GetConfigEdit")]
        public List<MyConfig> GetConfigEdit(MyConfig Data)
        {
            SystemAdminManager cm = new SystemAdminManager();
            List<MyConfig> st = cm.GetConfigEdit(Data);
            return st;
        }

        [HttpPost("SendTestEmail")]
        public List<MyConfig> TestConnection(MyConfig Data)
        {
            List<MyConfig> ViewList = new List<MyConfig>();

            string strHTML = "";
            Boolean SSLEnable;
            strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='70%' style='font-family:Arial;'>";
            strHTML += "<tbody>";
            strHTML += "<tr>";
            strHTML += "<td style='border:none!important;'>";
            strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";

            strHTML += "<tr>";
            strHTML += "<td>";
            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;padding-top:17px'>This mail was directly sent by " + Data.HostName + "</td>";
            strHTML += "</tr>";

            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;'>SMTP Host: " + Data.HostName + "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;'>Port: " + Data.IPPort + "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            if (Data.IsSSLTLS == 1)
            {
                SSLEnable = true;
            }
            else
            {
                SSLEnable = false;
            }
            strHTML += "<td style='padding-bottom:17px;'>Use SSL: " + SSLEnable + "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;'>Authentication Name: " + Data.SenderID + "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;'>Authentication Password:</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;'>Email From: " + Data.SenderID + "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td style='padding-bottom:17px;'>Email To: " + Data.SenderID + "</td>";
            strHTML += "</tr>";

            strHTML += "<tr style='margin-top:30px;'>";
            strHTML += "<td>";
            strHTML += "<table style='width:100%;' border='0'>";
            strHTML += "<tr>";
            strHTML += "<td style ='font-weight:600;padding-bottom:16px;color:red;'>Note:</td>";
            strHTML += "<td style ='padding-bottom:16px;'>This is a System generated e-mail. Please do not respond to this e-mail.</td>";
            strHTML += "</tr> ";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";

            strHTML += "</td>";
            strHTML += "</tr>";

            strHTML += "</tbody>";
            strHTML += "</table>";

            Boolean SSLV;

            MailMessage EmailObject = new MailMessage();
            EmailObject.From = new MailAddress(Data.SenderID, "Info Odak");

            EmailObject.To.Add(new MailAddress("anand@odaksolutions.com"));
            //EmailObject.CC.Add(new MailAddress("anand@odaksolutions.com"));
            EmailObject.Subject = "Mail sent by " + Data.HostName + ":Successful";
            EmailObject.Body = strHTML;
            EmailObject.IsBodyHtml = true;
            EmailObject.Priority = MailPriority.Normal;

            SmtpClient SMTPServer = new SmtpClient();
            SMTPServer.UseDefaultCredentials = false;
            SMTPServer.Credentials = new NetworkCredential(Data.SenderID, Data.Password);
            SMTPServer.Port = Data.IPPort;
            SMTPServer.Host = Data.HostName;
            SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (Data.IsSSLTLS == 1)
            {
                SSLV = true;
            }
            else
            {
                SSLV = false;
            }
            SMTPServer.EnableSsl = SSLV;
            SMTPServer.Send(EmailObject);


            //EmailObject.To.Add(new MailAddress("anand@odaksolutions.com"));                
            //EmailObject.Subject = "Arrival Notice Mail";      
            //EmailObject.Body = strHTML;        
            //EmailObject.IsBodyHtml = true;
            //EmailObject.Priority = MailPriority.Normal;
            //SmtpClient SMTPServer = new SmtpClient();           
            //SMTPServer.UseDefaultCredentials = false;
            //SMTPServer.Credentials = new NetworkCredential("info@odaksolutions.com", "Focus$321");
            //SMTPServer.Port = 587;
            //SMTPServer.Host = "smtp.office365.com";
            //SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //SMTPServer.EnableSsl = true;
            //SMTPServer.Send(EmailObject);



            ViewList.Add(new MyConfig
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("ImageUpload")]
        public IActionResult DocumentUpload()
        {
            try
            {
                var files = Request.Form.Files[0];

                var folderName = Path.Combine("UploadFolder", "CompanyLogo");
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
        #endregion
    }
}

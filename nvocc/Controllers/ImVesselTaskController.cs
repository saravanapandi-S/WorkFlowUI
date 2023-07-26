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
using System.Net.Mail;
using System.Net;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImVesselTaskController : ControllerBase
    {

        ImVesselTaskManager Manag = new ImVesselTaskManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public ImVesselTaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("VesselTaskList")]
        public List<MyImVesselTask> VesselTaskList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetVesselTaskList(Data);
            return st;
        }
        [HttpPost("VesselFormList")]
        public List<MyImVesselTask> VesselFormList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetVesselFormList(Data);
            return st;
        }

        [HttpPost("GetDischargeStatusList")]
        public List<MyImVesselTask> GetDischargeStatusList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetDischargeStatusList(Data);
            return st;
        }

        [HttpPost("GetDischargeList")]
        public List<MyImVesselTask> GetDischargeList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetDischargeList(Data);
            return st;
        }

        [HttpPost("ImpDischargeListInsert")]
        public List<MyImVesselTask> ImpDischargeListInsert(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.ImpDischargeListInsert(Data);
            return st;
        }


        [HttpPost("GetImportManifestStsList")]
        public List<MyImVesselTask> GetImportManifestStsList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetImportManifestStsList(Data);
            return st;
        }

        [HttpPost("GetImportManifestStsTabList")]
        public List<MyImVesselTask> GetImportManifestStsTabList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetImportManifestStsTabList(Data);
            return st;
        }

        [HttpPost("GetImportManifestList")]
        public List<MyImVesselTask> GetImportManifestList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetImportManifestList(Data);
            return st;
        }

        [HttpPost("GetImportArrivalList")]
        public List<MyImVesselTask> GetImportArrivalList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetImportArrivalList(Data);
            return st;
        }

        [HttpPost("GetImportDischargeCnfrmStsList")]
        public List<MyImVesselTask> GetImportDischargeCnfrmStsList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetImportDischargeCnfrmStsList(Data);
            return st;
        }

        [HttpPost("GetImportDischargeCnfrmList")]
        public List<MyImVesselTask> GetImportDischargeCnfrmList(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetImportDischargeCnfrmList(Data);
            return st;
        }

        [HttpPost("ImpDischargeConfirmInsert")]
        public List<MyImVesselTask> ImpDischargeConfirmInsert(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.ImpDischargeConfirmInsert(Data);
            return st;
        }
        #region tab values controller udhaya

        [HttpPost("IMVesselValues")]
        public List<MyImVesselTask> IMVesselValues(MyImVesselTask Data)
        {
            ImVesselTaskManager cm = new ImVesselTaskManager();
            List<MyImVesselTask> st = cm.GetIMVesselValues(Data);
            return st;
        }

        #endregion

        #region send mail

        [HttpPost("ArrivalEmailSend")]
        public List<MyImVesselTask> ArrivalEmailSend(MyImVesselTask Data)
        {
            List<MyImVesselTask> ViewList = new List<MyImVesselTask>();

            DataTable dts = GetArrivalEmailSendValues1(Data);
            if (dts.Rows.Count > 0)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    DataTable dtv = GetArrivalEmailSendValues(dts.Rows[i]["ID"].ToString());
                    if (dtv.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtv.Rows.Count; k++)
                        {
                            string strHTML = "";
                            strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='70%' style='font-family:Arial;'>";
                            strHTML += "<tbody>";
                            strHTML += "<tr>";
                            strHTML += "<td style='border:none!important;'>";
                            strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";

                            strHTML += "<tr>";
                            strHTML += "<td>";
                            strHTML += "<table style='width:100%;' border='0'>";
                            strHTML += "<tr>";
                            strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>Vessel</td>";
                            strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[k]["VesselName"].ToString() + "</td>";
                            strHTML += "</tr>";
                            strHTML += "<tr>";
                            strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>VoyageNo</td>";
                            strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[k]["VoyageNo"].ToString() + "</td>";
                            strHTML += "</tr>";
                            strHTML += "<tr>";
                            strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> Sailed Date </td>";
                            strHTML += "<td style = 'padding-bottom:16px;' > " + dtv.Rows[k]["ETD"].ToString() + "</td>";
                            strHTML += "</tr>";
                            strHTML += "<tr>";
                            strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> Arriving On </td>";
                            strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[k]["POD"].ToString() + "</td>";
                            strHTML += "</tr> ";
                            strHTML += "<tr>";
                            strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> BOL Ref </td>";
                            strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[k]["BLNumber"].ToString() + "</td>";
                            strHTML += "</tr> ";
                            strHTML += "</table>";
                            strHTML += "</td>";
                            strHTML += "</tr>";
                            strHTML += "</table>";
                            strHTML += "</td>";
                            strHTML += "</tr>";

                            strHTML += "</table>";

                            strHTML += "<tr>";
                            strHTML += "<td style='padding-bottom:17px;padding-top:17px'>Thank You for serving your shipment through NAVIO SHIPPING PRIVATE LIMITED.</td>";
                            strHTML += "</tr>";

                            strHTML += "<tr>";
                            strHTML += "<td style='padding-bottom:17px;'>Best Regards</td>";
                            strHTML += "</tr>";

                            strHTML += "<tr>";
                            strHTML += "<td>";
                            strHTML += "<table style='width:100%;' border='0'>";
                            strHTML += "<tr>";
                            strHTML += "<td style ='font-weight:600;padding-bottom:16px;'>Note:</td>";
                            strHTML += "<td style ='padding-bottom:16px;'>This is a System generated e-mail. Please do not respond to this e-mail.</td>";
                            strHTML += "</tr> ";
                            strHTML += "</table>";
                            strHTML += "</td>";
                            strHTML += "</tr>";

                            strHTML += "</td>";
                            strHTML += "</tr>";

                            strHTML += "</tbody>";
                            strHTML += "</table>";



                            MailMessage EmailObject = new MailMessage();
                            EmailObject.From = new MailAddress("info@odaksolutions.com", "Info Odak");
                            var EmailTo = dtv.Rows[k]["ShipperEmail"].ToString().Split(',');
                            for (int y = 0; y < EmailTo.Length; y++)
                            {
                                if (EmailTo[y].ToString() != "")
                                {
                                    EmailObject.To.Add(new MailAddress(EmailTo[y].ToString()));
                                }
                            }


                            // EmailObject.To.Add(new MailAddress("anand@odaksolutions.com"));
                            // EmailObject.To.Add(new MailAddress("udayakumarkoliking99@gmail.com"));                                   
                            EmailObject.Subject = "Arrival Notice Mail" + " - " + dtv.Rows[k]["VesselName"].ToString() + " & " + dtv.Rows[k]["VoyageNo"].ToString().ToUpper();
                            //EmailObject.Subject = "Customer OnBoard Confirmation Mail";              
                            EmailObject.Body = strHTML;
                            EmailObject.IsBodyHtml = true;
                            EmailObject.Priority = MailPriority.Normal;
                            SmtpClient SMTPServer = new SmtpClient();
                            SMTPServer.UseDefaultCredentials = false;
                            SMTPServer.Credentials = new NetworkCredential("info@odaksolutions.com", "Focus$321");
                            SMTPServer.Port = 587;
                            SMTPServer.Host = "smtp.office365.com";
                            SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                            SMTPServer.EnableSsl = true;
                            SMTPServer.Send(EmailObject);

                        }
                    }
                }
            }
            ViewList.Add(new MyImVesselTask
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }

        public DataTable GetArrivalEmailSendValues(string ID)
        {


            string _Query = " select (select top(1) VesselName from NVO_VesselMaster  where ID = Nvo_ImpBL.VesselID) as VesselName, " +
                            " (select top(1) VoyageNo from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as VoyageNo, " +
                            " (select top(1) convert(varchar, ETD, 106) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ETD, " +
                            " (select top 1 PortName from NVO_PortMaster where NVO_PortMaster.ID =Nvo_ImpBL.PODID) POD,BLNumber,ShipperEmail " +
                            " from Nvo_ImpBL where ID =" + ID;

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetArrivalEmailSendValues1(MyImVesselTask Data)
        {


            string _Query = " select * from Nvo_ImpBL where ID IN (" + Data.EmailItems + " )";

            return Manag.GetViewData(_Query, "");
        }



        #endregion

        [HttpPost("BindEmailView")]
        public List<MyImVesselTask> BindEmailView(MyImVesselTask Data)
        {
            ImVesselTaskManager bl = new ImVesselTaskManager();
            List<MyImVesselTask> sl = bl.BindEmailViewList(Data);
            return sl;
        }

        [HttpPost("ImSaveArrival")]
        public List<MyImVesselTask> ImSaveArrival(MyImVesselTask Data)
        {
            ImVesselTaskManager bl = new ImVesselTaskManager();
            List<MyImVesselTask> sl = bl.ImSaveArrivalValues(Data);
            return sl;
        }
    }



}



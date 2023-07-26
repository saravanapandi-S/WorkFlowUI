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
using System.Net;
using System.Net.Mail;


namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselTaskController : ControllerBase
    {




        VesselTaskManager Manag = new VesselTaskManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public VesselTaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("VesselTasklistBind")]
        public List<MyVesselTask> BindVesselListvalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindVesselListvalues(Data);
            return st;
        }

        [HttpPost("PreAlertStatusBind")]
        public List<MyVesselTask> BindPreAlertListvalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindPreAlertStatusvalues(Data);
            return st;
        }


        [HttpPost("PreAlertFinalBind")]
        public List<MyVesselTask> BindPreAlertFinalizevalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindPreAlertFinalizevalues(Data);
            return st;
        }

        [HttpPost("InsertPreAlertFinalInstr")]
        public List<MyVesselTask> InsertPreAlertFinalInstr(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertPreAlertFinalInstr(Data);
            return st;
        }

        [HttpPost("InsertPreAlertMailInstr")]
        public List<MyVesselTask> InsertPreAlertMailInstr(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertPreAlertMailInstr(Data);
            return st;
        }


        [HttpPost("InsertPreAlertAttachStatus")]
        public List<MyVesselTask> InsertPreAlertAttachStatus(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertPreAlertAttachStatus(Data);
            return st;
        }


        [HttpPost("PreAlertMailBind")]
        public List<MyVesselTask> BindPreAlertMailvalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindPreAlertMailvalues(Data);
            return st;
        }

        [HttpPost("PreAlertMailToBind")]
        public List<MyVesselTask> BindPreAlertMailTovalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindPreAlertMailTovalues(Data);
            return st;
        }

        [HttpPost("OnboardConfirmBind")]
        public List<MyVesselTask> BindOnBoardConfirmvalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindOnBoardConfirmvalues(Data);
            return st;
        }

        [HttpPost("InsertOnboardMail")]
        public List<MyVesselTask> InsertOnboardConfirm(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertOnboardConfirm(Data);
            return st;
        }

        [HttpPost("InsertOnboardConfirmStatus")]
        public List<MyVesselTask> InsertOnboardConfirmStatus(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertOnboardConfirmStatus(Data);
            return st;
        }


        [HttpPost("TDRStatusBind")]
        public List<MyVesselTask> BindTDRStatusvalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindTDRStatusvalues(Data);
            return st;
        }


        [HttpPost("TDRFinalBind")]
        public List<MyVesselTask> BindTDRFinalizevalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindTDRFinalizevalues(Data);
            return st;
        }

        [HttpPost("InsertTDRFinalInstr")]
        public List<MyVesselTask> InsertTDRFinalInstr(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertTDRFinalInstr(Data);
            return st;
        }

        [HttpPost("InsertTDRMailInstr")]
        public List<MyVesselTask> InsertTDRMailInstr(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertTDRMailInstr(Data);
            return st;
        }

        [HttpPost("InsertTDRAttachStatus")]
        public List<MyVesselTask> InsertTDRAttachStatus(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.InsertTDRAttachStatus(Data);
            return st;
        }


        [HttpPost("TDRMailBind")]
        public List<MyVesselTask> BindTDRMailvalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindTDRMailvalues(Data);
            return st;
        }

        [HttpPost("TDRMailToBind")]
        public List<MyVesselTask> BindTDRMailTovalues(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.BindTDRMailTovalues(Data);
            return st;
        }



        [HttpPost("LoadListStatusBind")]
        public List<MyVesselTask> GetVesselLoadListStatuslist(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.GetVesselLoadListStatuslist(Data);
            return st;
        }

        [HttpPost("LoadListFinalBind")]
        public List<MyVesselTask> GetVesselLoadListFinallist(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.GetVesselLoadListFinallist(Data);
            return st;
        }

        [HttpPost("LoadListFinalTabBind")]
        public List<MyVesselTask> GetVesselLoadListFinalTablist(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.GetVesselLoadListFinalTablist(Data);
            return st;
        }

        [HttpPost("LoadListMailBind")]
        public List<MyVesselTask> GetVesselLoadListMaillist(MyVesselTask Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselTask> st = cm.GetVesselLoadListMaillist(Data);
            return st;
        }








        #region udhaya

        [HttpPost("VesselTaskViewlist")]
        public List<myVesselTask1> VesselTaskViewlist(myVesselTask1 Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<myVesselTask1> st = cm.GetVesselTaskViewlist(Data);
            return st;
        }

        [HttpPost("VesselLoadCnfrmViewlist")]
        public List<MyVesselLoadCnfrm> VesselLoadCnfrmViewlist(MyVesselLoadCnfrm Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselLoadCnfrm> st = cm.GetVesselLoadCnfrmViewlist(Data);
            return st;
        }
        #endregion


        [HttpPost("VesselEmailSend")]
        public List<MyVesselTask> VesselEmailSend(MyVesselTask Data)
        {
            List<MyVesselTask> ViewList = new List<MyVesselTask>();
            DataTable dtv = GetVesselEmailValues(Data);
            if (dtv.Rows.Count > 0)
            {


                string strHTML = "";


                string THRow = "<th style='text-align:left;font-size:11px; background-color:#1f618d;color:#fff;font-family:Arial;width:15rem;vertical-align:middle;text-align:center;padding-top:5px;padding-left:0px;padding-bottom:5px;margin-bottom:0px;'>";
                string TDRow = "<td style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:5px;padding-left:5px;padding-bottom:5px;padding-right:5px;vertical-align:middle;margin-bottom:0px;'>";

                strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='font-family:Arial;'>";
                strHTML += "<tbody>";
                strHTML += "<tr>";
                strHTML += "<td style='border:none!important;'>";
                strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";
                strHTML += "<tr>";
                strHTML += "<td style='font-weight:600;padding-bottom:17px;'>Good Day!</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='padding-bottom:17px;'>Please note we are loading below container on subject vessel</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table style='width:100%;' border='0'>";
                strHTML += "<tr>";
                strHTML += "<td style='color:#535353;font-weight:bold; padding-bottom:16px;'>PRINCIPAL</td>";
                strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[0]["PrincipleName"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:bold;padding-bottom:16px;'> SLOT </td>";
                strHTML += "<td style = 'padding-bottom:16px;' > " + dtv.Rows[0]["SlotOperator"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:bold;padding-bottom:16px;'> VSL </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper() + " </td>";
                strHTML += "</tr> ";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table border='1' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom:15px;'>";
                strHTML += "<tr>";
                strHTML += THRow + "CONT NO </th>";
                strHTML += THRow + "SIZE & TYPE</th>";
                strHTML += THRow + "TEMP/ODC</th>";
                strHTML += THRow + "BOL NO</th>";
                strHTML += THRow + "COMMODITY TYPE</th>";
                strHTML += THRow + "POL</th>";
                strHTML += THRow + "POD</th>";
                strHTML += THRow + "FPOD</th>";
                strHTML += THRow + "DIRECT OR T/S</th>";
                strHTML += THRow + "SLOT OPERATOR</th>";
                strHTML += "</tr>";

                int RowIndex = 14;
                for (int i = 0; i < dtv.Rows.Count; i++)
                {
                    strHTML += "<tr>";
                    strHTML += TDRow + dtv.Rows[i]["CntrNo"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["CntrType"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["Temperature"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["BLNumber"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["CargoType"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["POLName"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["PODName"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["FPODName"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["DirTS"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["SlotOperator"].ToString() + "</td>";
                    strHTML += "</tr>";
                    RowIndex++;
                }


                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "</tbody>";
                strHTML += "</table>";



                MailMessage EmailObject = new MailMessage();


                EmailObject.From = new MailAddress("info@odaksolutions.com", "Info Odak");
                var EmailTo = Data.EmailTo.Split(',');
                for (int y = 0; y < EmailTo.Length; y++)
                {
                    if (EmailTo[y].ToString() != "")
                    {
                        EmailObject.To.Add(new MailAddress(EmailTo[y].ToString()));
                    }
                }
                var EmailCC = Data.EmailCC.Split(',');
                for (int y = 0; y < EmailCC.Length; y++)
                {
                    if (EmailCC[y].ToString() != "")
                    {
                        EmailObject.CC.Add(new MailAddress(EmailCC[y].ToString()));
                    }
                }
                var EmailBcc = Data.EmailBcc.Split(',');
                for (int y = 0; y < EmailBcc.Length; y++)
                {
                    if (EmailBcc[y].ToString() != "")
                    {
                        EmailObject.Bcc.Add(new MailAddress(EmailBcc[y].ToString()));
                    }
                }
                //EmailObject.To.Add(new MailAddress("aravindhan2196@gmail.com"));
                //EmailObject.To.Add(new MailAddress("aravind@odaksolutions.com"));
                if (Data.Status == "" || Data.Status == null)
                {
                    EmailObject.Subject = Data.EmailSub + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper();
                }
                else
                {
                    EmailObject.Subject = Data.EmailSub + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper() + " - " + Data.Status.ToString();
                }
                EmailObject.Body = strHTML;

                if (Data.BLID != "")
                {
                    DataTable dtd = GetVesselEmailAttachValues(Data);
                    if (dtd.Rows.Count > 0)
                    {


                        for (int y = 0; y < dtd.Rows.Count; y++)
                        {
                            if (dtd.Rows[y]["BLPrintPath"].ToString() != "")
                            {
                                EmailObject.Attachments.Add(new Attachment(Path.Combine("UploadFolder/" + dtd.Rows[y]["BLPrintPath"].ToString())));
                            }

                        }
                    }
                }

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

            ViewList.Add(new MyVesselTask
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }

        public DataTable GetVesselEmailValues(MyVesselTask Data)
        {
            string _Query = "select VesselID,VoyageID,SlotOperatorID,NVO_Booking.Id as BkgID,NVO_BL.Id as BLID, BookingNo,NVO_BL.BLNumber as BLNumber," +
                "(select top(1) CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo," +
                "(select top(1)(select top(1) Size from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrType, " +
                "(select(select top(1) TEUS from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as Tues, " +
                "case when HazarOpt = 1 then 'GENERAL' ELSE 'HAZARDOUS' END AS CargoType, (select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = LoadPortID) as POLName, case when EnquirySourceID = 1 then 'Direct' else 'TS' end as DirTS, " +
                "(select  top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
                "ISNULL((select top(1) LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID), 'NA') as PrincipleName,  " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo," +
                "'NA' as LoadStatus, 'NA' as LoadDate, " +
                "Temperature from NVO_Booking inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID " +
                "inner join NVO_BLContainer on NVO_BLContainer.BLID = NVO_BL.ID and NVO_BLContainer.BkgID = NVO_Booking.ID " +
                "inner join NVO_BLCargo on NVO_BLCargo.BkgID = NVO_BL.BkgID and NVO_BLCargo.BkgID = NVO_Booking.ID  and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetVesselEmailAttachValues(MyVesselTask Data)
        {
            string _Query = " select BLID,BLStatus,BLPrintPath from NVO_BOLNew where BLID in (" + Data.BLID + ") ";

            return Manag.GetViewData(_Query, "");
        }


        [HttpPost("OnBoardEmailSend")]
        public List<MyVesselTask> OnboardEmailSend(MyVesselTask Data)
        {
            List<MyVesselTask> ViewList = new List<MyVesselTask>();
            DataTable dtv = GetOnboardEmailValues(Data);
            if (dtv.Rows.Count > 0)
            {


                string strHTML = "";


                string THRow = "<th style='text-align:left;font-size:11px; background-color:#1f618d;color:#fff;font-family:Arial;width:10rem;vertical-align:middle;text-align:center;padding-top:5px;padding-left:0px;padding-bottom:5px;margin-bottom:0px;'>";
                string TDRow = "<td style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:5px;padding-left:5px;padding-bottom:5px;padding-right:5px;vertical-align:middle;margin-bottom:0px;'>";

                strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='70%' style='font-family:Arial;'>";
                strHTML += "<tbody>";
                strHTML += "<tr>";
                strHTML += "<td style='border:none!important;'>";
                strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";
                strHTML += "<tr>";
                strHTML += "<td style='font-weight:600;padding-bottom:17px;'> Dear " + dtv.Rows[0]["CusName"].ToString() + ",</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='padding-bottom:17px;'>Please to inform you that below mentioned " + dtv.Rows[0]["CntrCount"].ToString() + " x " + dtv.Rows[0]["CntrType"].ToString() + " are on board.</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table style='width:100%;' border='0'>";
                strHTML += "<tr>";
                strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>Vessel</td>";
                strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[0]["VesselName"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> Sailed From </td>";
                strHTML += "<td style = 'padding-bottom:16px;' > " + dtv.Rows[0]["SailedFrom"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> Sailed On </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["SailedOn"].ToString() + "</td>";
                strHTML += "</tr> ";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> BOL Ref </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["BLNumber"].ToString() + "</td>";
                strHTML += "</tr> ";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table border='1' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom:15px;'>";
                strHTML += "<tr>";
                strHTML += THRow + "S.No. </th>";
                strHTML += THRow + "NO. OF CONTAINERS</th>";
                strHTML += THRow + "SIZE & TYPE</th>";
                strHTML += THRow + "FPOD</th>";
                strHTML += "</tr>";

                int RowIndex = 14;
                int Slno = 1;
                for (int i = 0; i < dtv.Rows.Count; i++)
                {
                    strHTML += "<tr>";
                    strHTML += TDRow + Slno + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["CntrCount"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["CntrType"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["FPODName"].ToString() + "</td>";
                    strHTML += "</tr>";
                    RowIndex++;
                    Slno++;
                }


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
                var EmailTo = Data.EmailTo.Split(',');
                for (int y = 0; y < EmailTo.Length; y++)
                {
                    if (EmailTo[y].ToString() != "")
                    {
                        EmailObject.To.Add(new MailAddress(EmailTo[y].ToString()));
                    }
                }
                //var EmailCC = Data.EmailCC.Split(',');
                //for (int y = 0; y < EmailCC.Length; y++)
                //{
                //    if (EmailCC[y].ToString() != "")
                //    {
                //        EmailObject.CC.Add(new MailAddress(EmailCC[y].ToString()));
                //    }
                //}
                //var EmailBcc = Data.EmailBcc.Split(',');
                //for (int y = 0; y < EmailBcc.Length; y++)
                //{
                //    if (EmailBcc[y].ToString() != "")
                //    {
                //        EmailObject.Bcc.Add(new MailAddress(EmailBcc[y].ToString()));
                //    }
                //}
                //EmailObject.To.Add(new MailAddress("aravindhan2196@gmail.com"));
                //EmailObject.To.Add(new MailAddress("aravind@odaksolutions.com"));
                EmailObject.Subject = "Customer OnBoard Confirmation Mail" + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper();
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

            ViewList.Add(new MyVesselTask
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }

        public DataTable GetOnboardEmailValues(MyVesselTask Data)
        {
            //string _Query = "select VesselID,VoyageID,NVO_Booking.Id as BkgID,NVO_BL.Id as BLID, BookingNo,NVO_BL.BLNumber as BLNumber,CntrType, " +
            //    "(select top(1) PortName  from NVO_PortMaster where ID = DischargePortID) as FPODName, 'NA' as SailedFrom, " +
            //    "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
            //    "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
            //    "(select top(1) CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_Booking.CustomerID) as CusName, " +
            //    "(select  top(1) convert(varchar, ATD, 103)  from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as SailedOn, " +
            //    "(select count(CntrID) from NVO_BLContainer where NVO_BLContainer.BLID = NVO_BL.ID) as CntrCount from NVO_Booking " +
            //    "inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID " +
            //    "inner join NVO_BLContainer on NVO_BLContainer.BLID = NVO_BL.ID and NVO_BLContainer.BkgID = NVO_Booking.ID " +
            //    "inner join NVO_BLCargo on NVO_BLCargo.BLID = NVO_BL.ID and NVO_BLCargo.BkgID = NVO_Booking.ID and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID " +
            //    "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";

            string _Query = "select VesselID,VoyageID,NVO_Booking.Id as BkgID,BookingNo,NVO_BL.BLNumber as BLNumber, " +
                "(select top(1) CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_Booking.CustomerID) as CusName, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "(select count(CntrID) from NVO_BLContainer where NVO_BLContainer.BLID = NVO_BL.ID) as CntrCount, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, 'NA' as SailedFrom, " +
                "(select  top(1) convert(varchar, ATD, 103)  from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as SailedOn, " +
                "(select top(1) CntrType from NVO_BLCargo where NVO_BLCargo.BkgID = NVO_Booking.ID) as CntrType " +
                "from NVO_Booking inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " and NVO_BL.ID = " + Data.BLID + "";

            return Manag.GetViewData(_Query, "");
        }



        [HttpPost("TDREmailSend")]
        public List<MyVesselTask> TDREmailSend(MyVesselTask Data)
        {
            List<MyVesselTask> ViewList = new List<MyVesselTask>();
            DataTable dtv = GetTDREmailValues(Data);
            if (dtv.Rows.Count > 0)
            {


                string strHTML = "";


                string THRow = "<th style='text-align:left;font-size:11px; background-color:#1f618d;color:#fff;font-family:Arial;width:15rem;vertical-align:middle;text-align:center;padding-top:5px;padding-left:0px;padding-bottom:5px;margin-bottom:0px;'>";
                string TDRow = "<td style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:5px;padding-left:5px;padding-bottom:5px;padding-right:5px;vertical-align:middle;margin-bottom:0px;'>";

                strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='font-family:Arial;'>";
                strHTML += "<tbody>";
                strHTML += "<tr>";
                strHTML += "<td style='border:none!important;'>";
                strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";
                strHTML += "<tr>";
                strHTML += "<td style='font-weight:600;padding-bottom:17px;'>Good Day!</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='padding-bottom:17px;'>Please note we are loading below container on subject vessel</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table style='width:100%;' border='0'>";
                strHTML += "<tr>";
                strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>PRINCIPAL</td>";
                strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[0]["PrincipleName"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> SLOT </td>";
                strHTML += "<td style = 'padding-bottom:16px;' > " + dtv.Rows[0]["SlotOperator"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> VSL </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper() + " </td>";
                strHTML += "</tr> ";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table border='1' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom:15px;'>";
                strHTML += "<tr>";
                strHTML += THRow + "CONT NO </th>";
                strHTML += THRow + "SIZE & TYPE</th>";
                strHTML += THRow + "TEMP/ODC</th>";
                strHTML += THRow + "BOL NO</th>";
                strHTML += THRow + "COMMODITY TYPE</th>";
                strHTML += THRow + "POL</th>";
                strHTML += THRow + "POD</th>";
                strHTML += THRow + "FPOD</th>";
                strHTML += THRow + "DIRECT OR T/S</th>";
                strHTML += THRow + "SLOT OPERATOR</th>";
                strHTML += "</tr>";

                int RowIndex = 14;
                for (int i = 0; i < dtv.Rows.Count; i++)
                {
                    strHTML += "<tr>";
                    strHTML += TDRow + dtv.Rows[i]["CntrNo"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["CntrType"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["Temperature"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["BLNumber"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["CargoType"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["POLName"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["PODName"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["FPODName"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["DirTS"].ToString() + "</td>";
                    strHTML += TDRow + dtv.Rows[i]["SlotOperator"].ToString() + "</td>";
                    strHTML += "</tr>";
                    RowIndex++;
                }


                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "</tbody>";
                strHTML += "</table>";



                MailMessage EmailObject = new MailMessage();


                EmailObject.From = new MailAddress("info@odaksolutions.com", "Info Odak");
                var EmailTo = Data.EmailTo.Split(',');
                for (int y = 0; y < EmailTo.Length; y++)
                {
                    if (EmailTo[y].ToString() != "")
                    {
                        EmailObject.To.Add(new MailAddress(EmailTo[y].ToString()));
                    }
                }
                var EmailCC = Data.EmailCC.Split(',');
                for (int y = 0; y < EmailCC.Length; y++)
                {
                    if (EmailCC[y].ToString() != "")
                    {
                        EmailObject.CC.Add(new MailAddress(EmailCC[y].ToString()));
                    }
                }
                var EmailBcc = Data.EmailBcc.Split(',');
                for (int y = 0; y < EmailBcc.Length; y++)
                {
                    if (EmailBcc[y].ToString() != "")
                    {
                        EmailObject.Bcc.Add(new MailAddress(EmailBcc[y].ToString()));
                    }
                }
                //EmailObject.To.Add(new MailAddress("aravindhan2196@gmail.com"));
                //EmailObject.To.Add(new MailAddress("aravind@odaksolutions.com"));
                if (Data.Status == "" || Data.Status == null)
                {
                    EmailObject.Subject = Data.EmailSub + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper();
                }
                else
                {
                    EmailObject.Subject = Data.EmailSub + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper() + " - " + Data.Status.ToString();
                }
                EmailObject.Body = strHTML;

                if (Data.BLID != "")
                {
                    DataTable dtd = GetVesselEmailTDRAttachValues(Data);
                    if (dtd.Rows.Count > 0)
                    {
                        for (int y = 0; y < dtd.Rows.Count; y++)
                        {
                            if (dtd.Rows[y]["BLPrintPath"].ToString() != "")
                            {
                                EmailObject.Attachments.Add(new Attachment(Path.Combine("UploadFolder/" + dtd.Rows[y]["BLPrintPath"].ToString())));
                            }

                        }
                    }
                }

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

            ViewList.Add(new MyVesselTask
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }



        public DataTable GetTDREmailValues(MyVesselTask Data)
        {
            string _Query = "select VesselID,VoyageID,SlotOperatorID,NVO_Booking.Id as BkgID,NVO_BL.Id as BLID, BookingNo,NVO_BL.BLNumber as BLNumber," +
                "(select top(1) CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo," +
                "(select top(1)(select top(1) Size from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrType, " +
                "(select(select top(1) TEUS from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as Tues, " +
                "case when HazarOpt = 1 then 'GENERAL' ELSE 'HAZARDOUS' END AS CargoType, (select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = LoadPortID) as POLName, case when EnquirySourceID = 1 then 'Direct' else 'TS' end as DirTS, " +
                "ISNULL((select top(1) CustomerName from NVO_CustomerMaster where Id = NVO_Booking.SlotOperatorID), 'NA') as SlotOperator, " +
                "ISNULL((select top(1) LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID), 'NA') as PrincipleName,  " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo,'NA' as LoadStatus, 'NA' as LoadDate, " +
                "Temperature from NVO_Booking inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID " +
                "inner join NVO_BLContainer on NVO_BLContainer.BLID = NVO_BL.ID and NVO_BLContainer.BkgID = NVO_Booking.ID " +
                "inner join NVO_BLCargo on NVO_BLCargo.BkgID = NVO_BL.BkgID and NVO_BLCargo.BkgID = NVO_Booking.ID  and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";

            return Manag.GetViewData(_Query, "");
        }


        public DataTable GetVesselEmailTDRAttachValues(MyVesselTask Data)
        {

            string _Query = "select BLID,BLStatus,BLPrintPath from NVO_BOLNew where BLID in (" + Data.BLID + ")";

            return Manag.GetViewData(_Query, "");



            //return Manag.GetViewData(_Query, "");
        }


        [HttpPost("LoadListEmailSend")]
        public List<MyVesselTask> LoadListEmailSend(MyVesselTask Data)
        {
            List<MyVesselTask> ViewList = new List<MyVesselTask>();
            DataTable dtv = GetLoadListEmailValues(Data);
            if (dtv.Rows.Count > 0)
            {


                string strHTML = "";


                string THRow = "<th style='text-align:left;font-size:11px; background-color:#1f618d;color:#fff;font-family:Arial;width:15rem;vertical-align:middle;text-align:center;padding-top:5px;padding-left:0px;padding-bottom:5px;margin-bottom:0px;'>";
                string TDRow = "<td style='font-family:Arial;font-weight: bold;font-size:11px;padding-top:5px;padding-left:5px;padding-bottom:5px;padding-right:5px;vertical-align:middle;margin-bottom:0px;'>";

                strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='font-family:Arial;'>";
                strHTML += "<tbody>";
                strHTML += "<tr>";
                strHTML += "<td style='border:none!important;'>";
                strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";
                strHTML += "<tr>";
                strHTML += "<td style='font-weight:600;padding-bottom:17px;'>Good Day!</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='padding-bottom:17px;'>Please note we are loading below container on subject vessel</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table style='width:100%;' border='0'>";
                //strHTML += "<tr>";
                //strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>PRINCIPAL</td>";
                //strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[0]["PrincipleName"].ToString() + "</td>";
                //strHTML += "</tr>";
                //strHTML += "<tr>";
                //strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> SLOT </td>";
                //strHTML += "<td style = 'padding-bottom:16px;' > " + dtv.Rows[0]["SlotOperator"].ToString() + "</td>";
                //strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> VSL </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper() + " </td>";
                strHTML += "</tr> ";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                //strHTML += "<tr>";
                //strHTML += "<td>";
                //strHTML += "<table border='1' cellpadding='0' cellspacing='0' width='100%' style='margin-bottom:15px;'>";
                //strHTML += "<tr>";
                //strHTML += THRow + "CONT NO </th>";
                //strHTML += THRow + "SIZE & TYPE</th>";
                //strHTML += THRow + "TEMP/ODC</th>";
                //strHTML += THRow + "BOL NO</th>";
                //strHTML += THRow + "COMMODITY TYPE</th>";
                //strHTML += THRow + "POL</th>";
                //strHTML += THRow + "POD</th>";
                //strHTML += THRow + "FPOD</th>";
                //strHTML += THRow + "DIRECT OR T/S</th>";
                //strHTML += THRow + "SLOT OPERATOR</th>";
                //strHTML += "</tr>";

                //int RowIndex = 14;
                //for (int i = 0; i < dtv.Rows.Count; i++)
                //{
                //    strHTML += "<tr>";
                //    strHTML += TDRow + dtv.Rows[i]["CntrNo"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["CntrType"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["Temperature"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["BLNumber"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["CargoType"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["POLName"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["PODName"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["FPODName"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["DirTS"].ToString() + "</td>";
                //    strHTML += TDRow + dtv.Rows[i]["SlotOperator"].ToString() + "</td>";
                //    strHTML += "</tr>";
                //    RowIndex++;
                //}


                //strHTML += "</table>";
                //strHTML += "</td>";
                //strHTML += "</tr>";

                strHTML += "</tbody>";
                strHTML += "</table>";



                MailMessage EmailObject = new MailMessage();


                EmailObject.From = new MailAddress("info@odaksolutions.com", "Info Odak");
                var EmailTo = Data.EmailTo.Split(',');
                for (int y = 0; y < EmailTo.Length; y++)
                {
                    if (EmailTo[y].ToString() != "")
                    {
                        EmailObject.To.Add(new MailAddress(EmailTo[y].ToString()));
                    }
                }
                var EmailCC = Data.EmailCC.Split(',');
                for (int y = 0; y < EmailCC.Length; y++)
                {
                    if (EmailCC[y].ToString() != "")
                    {
                        EmailObject.CC.Add(new MailAddress(EmailCC[y].ToString()));
                    }
                }
                var EmailBcc = Data.EmailBcc.Split(',');
                for (int y = 0; y < EmailBcc.Length; y++)
                {
                    if (EmailBcc[y].ToString() != "")
                    {
                        EmailObject.Bcc.Add(new MailAddress(EmailBcc[y].ToString()));
                    }
                }
                //EmailObject.To.Add(new MailAddress("aravindhan2196@gmail.com"));
                //EmailObject.To.Add(new MailAddress("aravind@odaksolutions.com"));
                if (Data.Status == "" || Data.Status == null)
                {
                    EmailObject.Subject = Data.EmailSub + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper();
                }
                else
                {
                    EmailObject.Subject = Data.EmailSub + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper() + " - " + Data.Status.ToString();
                }

                EmailObject.Body = strHTML;
                EmailObject.Attachments.Add(new Attachment(Path.Combine("UploadFolder/" + dtv.Rows[0]["VesselName"].ToString() + ".pdf")));
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

            ViewList.Add(new MyVesselTask
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }

        public DataTable GetLoadListEmailValues(MyVesselTask Data)
        {
            string _Query = " select VesselID,VoyageID, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD, 'NA' as SailedStatus from NVO_Booking " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";

            return Manag.GetViewData(_Query, "");
        }






        [HttpPost("VesselLoadCnfrmViewlist1")]
        public List<MyVesselLoadCnfrm> VesselLoadCnfrmViewlist1(MyVesselLoadCnfrm Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselLoadCnfrm> st = cm.GetVesselLoadCnfrmViewlist1(Data);
            return st;
        }

        [HttpPost("InsertOnboardStatusValue")]
        public List<MyVesselLoadCnfrm> InsertOnboardStatusValue(MyVesselLoadCnfrm Data)
        {
            VesselTaskManager cm = new VesselTaskManager();
            List<MyVesselLoadCnfrm> st = cm.InsertOnboardStatusValue(Data);
            return st;
        }
    }






}



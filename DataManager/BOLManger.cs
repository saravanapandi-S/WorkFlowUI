using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using DataBaseFactory;
using System.Data;
using System.Data.Common;
using DataTier;
using System.Data.SqlClient;
using System.Net.PeerToPeer;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace DataManager
{
   public class BOLManger
    {
        List<MyBOLData> ListBol = new List<MyBOLData>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public BOLManger()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyBOLData> InsertBOLMaster(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = " IF((select count(*) from NVO_BOLNew where ID=@ID and BLID=@BLID)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_BOLNew(BkgID,InputSourceID,BLTemplateID,DeliveryAgent,DeliveryAgentAddress,PlaceofRecID,PortofLoadID,PortofDischargeID,PortofDestinationID,MarksNos,Packages,Description,Weight,FreightPayableAt,BLTypeID,NoOfOriginal,RFLBol,BLIssueDate,PlaceOfIssue,ShipOnboardDate,PrintWt,PrintNetWt,NotPrint,CurrentDate,BLNumberID,BLID,PaymentTermsID,AttachShippingBill,AttachCustomerApproval,BLStatus,OriginTxt,LoadPortTxt,DischargeTxt,DestinationTxt,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify,NotifyAddress,Notifyalso,NotifyalsoAddress,UserID) " +
                                       " values (@BkgID,@InputSourceID,@BLTemplateID,@DeliveryAgent,@DeliveryAgentAddress,@PlaceofRecID,@PortofLoadID,@PortofDischargeID,@PortofDestinationID,@MarksNos,@Packages,@Description,@Weight,@FreightPayableAt,@BLTypeID,@NoOfOriginal,@RFLBol,@BLIssueDate,@PlaceOfIssue,@ShipOnboardDate,@PrintWt,@PrintNetWt,@NotPrint,@CurrentDate,@BLNumberID,@BLID,@PaymentTermsID,@AttachShippingBill,@AttachCustomerApproval,@BLStatus,@OriginTxt,@LoadPortTxt,@DischargeTxt,@DestinationTxt,@Shipper,@ShipperAddress,@Consignee,@ConsigneeAddress,@Notify,@NotifyAddress,@Notifyalso,@NotifyalsoAddress,@UserID) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_BOLNew SET BkgID=@BkgID,InputSourceID=@InputSourceID,BLTemplateID=@BLTemplateID,DeliveryAgent=@DeliveryAgent,DeliveryAgentAddress=@DeliveryAgentAddress,PlaceofRecID=@PlaceofRecID,PortofLoadID=@PortofLoadID,PortofDischargeID=@PortofDischargeID,PortofDestinationID=@PortofDestinationID,MarksNos=@MarksNos,Packages=@Packages,Description=@Description,Weight=@Weight,FreightPayableAt=@FreightPayableAt,BLTypeID=@BLTypeID,NoOfOriginal=@NoOfOriginal,RFLBol=@RFLBol,BLIssueDate=@BLIssueDate,PlaceOfIssue=@PlaceOfIssue,ShipOnboardDate=@ShipOnboardDate,PrintWt=@PrintWt,PrintNetWt=@PrintNetWt,NotPrint=@NotPrint,CurrentDate=@CurrentDate,BLNumberID=@BLNumberID,BLID=@BLID,PaymentTermsID=@PaymentTermsID,AttachShippingBill=@AttachShippingBill,AttachCustomerApproval=@AttachCustomerApproval,BLStatus=@BLStatus,OriginTxt=@OriginTxt,LoadPortTxt=@LoadPortTxt,DischargeTxt=@DischargeTxt,DestinationTxt=@DestinationTxt,Shipper=@Shipper,ShipperAddress=@ShipperAddress,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,Notify=@Notify,NotifyAddress=@NotifyAddress,Notifyalso=@Notifyalso,NotifyalsoAddress=@NotifyalsoAddress,UserID=@UserID where ID=@ID and BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.MainID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InputSourceID", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTemplateID", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OriginTxt", Data.Origin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPortTxt", Data.LoadPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DischargeTxt", Data.Discharge));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationTxt", Data.Destination));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceofRecID", Data.OriginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortofLoadID", Data.LoadPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortofDischargeID", Data.DischargeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortofDestinationID", Data.DestinationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MarksNos", Data.MarksNos));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Packages", Data.Packages));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Weight", Data.Weight));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTermsID", Data.PaymentTermsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPayableAt", Data.FreightPayableAt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypeID", Data.BLTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfOriginal", Data.NoOfOriginal));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RFLBol", Data.RFLBol));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLIssueDate", Data.BLIssueDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceOfIssue", Data.PlaceOfIssue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipOnboardDate", Data.ShipOnboardDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintWt", Data.PrintWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintNetWt", Data.PrintNetWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotPrint", Data.NotPrint));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumberID", Data.BLNumberID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryAgent", Data.DeliveryAgent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryAgentAddress", Data.DeliveryAgentAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachShippingBill", Data.AttachShippingBill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachCustomerApproval", Data.AttachCustomerApproval));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.ShipperName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", Data.Consignee));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify", Data.Notify));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAddress", Data.NotifyAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notifyalso", Data.NotifyAlso));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyalsoAddress", Data.NotifyAlsoAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    int ID = 0;
                    Cmd.CommandText = "select ID from NVO_PartiesDtls where CustomerName=@CustomerName";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.ShipperName));
                    ID = Convert.ToInt32(Cmd.ExecuteScalar());
                    Cmd.Parameters.Clear();
                    if (ID == 0)
                    {
                        if (Data.ShipperName != "")
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_PartiesDtls where ID=@ID)<=0) " +
                                                             " BEGIN " +
                                                             " INSERT INTO  NVO_PartiesDtls(CustomerName,PartyTypeID,PartyType,CustomerAddress) " +
                                                             " values (@CustomerName,@PartyTypeID,@PartyType,@CustomerAddress) " +
                                                             " END  " +
                                                             " ELSE " +
                                                             " UPDATE NVO_PartiesDtls SET CustomerName=@CustomerName,PartyTypeID=@PartyTypeID,PartyType=@PartyType,CustomerAddress=@CustomerAddress where ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.PartyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.ShipperName));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyType", "Shipper"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerAddress", Data.ShipperAddress));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }
                    int CID = 0;
                    Cmd.CommandText = "select ID from NVO_PartiesDtls where CustomerName=@CustomerName";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.Consignee));
                    CID = Convert.ToInt32(Cmd.ExecuteScalar());
                    Cmd.Parameters.Clear();
                    if (CID == 0)
                        {
                            if (Data.Consignee != "")
                            {

                                Cmd.CommandText = " IF((select count(*) from NVO_PartiesDtls where ID=@ID)<=0) " +
                                                                " BEGIN " +
                                                                " INSERT INTO  NVO_PartiesDtls(CustomerName,PartyTypeID,PartyType,CustomerAddress) " +
                                                                " values (@CustomerName,@PartyTypeID,@PartyType,@CustomerAddress) " +
                                                                " END  " +
                                                                " ELSE " +
                                                                " UPDATE NVO_PartiesDtls SET CustomerName=@CustomerName,PartyTypeID=@PartyTypeID,PartyType=@PartyType,CustomerAddress=@CustomerAddress where ID=@ID";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.PartyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.Consignee));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 2));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyType", "Consinge"));             
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerAddress", Data.ConsigneeAddress));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }
                        }
                    int NID = 0;
                    Cmd.CommandText = "select ID from NVO_PartiesDtls where CustomerName=@CustomerName";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.Notify));
                    NID = Convert.ToInt32(Cmd.ExecuteScalar());
                    Cmd.Parameters.Clear();
                    if (NID == 0)
                        {
                            if (Data.Notify != "")
                            {

                                Cmd.CommandText = " IF((select count(*) from NVO_PartiesDtls where ID=@ID)<=0) " +
                                                                " BEGIN " +
                                                                " INSERT INTO  NVO_PartiesDtls(CustomerName,PartyTypeID,PartyType,CustomerAddress) " +
                                                                " values (@CustomerName,@PartyTypeID,@PartyType,@CustomerAddress) " +
                                                                " END  " +
                                                                " ELSE " +
                                                                " UPDATE NVO_PartiesDtls SET CustomerName=@CustomerName,PartyTypeID=@PartyTypeID,PartyType=@PartyType,CustomerAddress=@CustomerAddress where ID=@ID";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.PartyID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.Notify));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 3));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyType","Notiy"));             
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerAddress", Data.NotifyAddress));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }
                        }
                    int NIDA = 0;
                    Cmd.CommandText = "select ID from NVO_PartiesDtls where CustomerName=@CustomerName";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.NotifyAlso));
                    NIDA = Convert.ToInt32(Cmd.ExecuteScalar());
                    Cmd.Parameters.Clear();

                    if (NIDA == 0)
                        {


                            if (Data.NotifyAlso != "")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_PartiesDtls where ID=@ID)<=0) " +
                                                                " BEGIN " +
                                                                " INSERT INTO  NVO_PartiesDtls(CustomerName,PartyTypeID,PartyType,CustomerAddress) " +
                                                                " values (@CustomerName,@PartyTypeID,@PartyType,@CustomerAddress) " +
                                                                " END  " +
                                                                " ELSE " +
                                                                " UPDATE NVO_PartiesDtls SET CustomerName=@CustomerName,PartyTypeID=@PartyTypeID,PartyType=@PartyType,CustomerAddress=@CustomerAddress where ID=@ID";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.PartyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.NotifyAlso));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 4));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyType", "NotifyAlso"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerAddress", Data.NotifyAlsoAddress));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }
                        }

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_BOLCntrDtls where ID=@ID and BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BOLCntrDtls(BkgID,BLID,ContainerNo,CntrType,AgentSealNo,CustomerSealNo,GrsWt,NetWt,NoOfPkgs,Volume) " +
                                     " values (@BkgID,@BLID,@ContainerNo,@CntrType,@AgentSealNo,@CustomerSealNo,@GrsWt,@NetWt,@NoOfPkgs,@Volume) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BOLCntrDtls SET BkgID=@BkgID,BLID=@BLID,ContainerNo=@ContainerNo,CntrType=@CntrType,AgentSealNo=@AgentSealNo,CustomerSealNo=@CustomerSealNo,GrsWt=@GrsWt,NetWt=@NetWt,NoOfPkgs=@NoOfPkgs,Volume=@Volume where ID=@ID and BLID=@BLID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ContID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerNo", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentSealNo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerSealNo", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NetWt", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkgs", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Volume", CharSplit[7]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    string[] ArrayAttach = Data.ItemsAttach.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayAttach.Length; i++)
                    {

                        var CharSplit = ArrayAttach[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_BLAttachments where AID=@AID and BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLAttachments(BkgID,BLID,AttachName,AttachFile) " +
                                     " values (@BkgID,@BLID,@AttachName,@AttachFile) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLAttachments SET BkgID=@BkgID,BLID=@BLID,AttachName=@AttachName,AttachFile=@AttachFile where AID=@AID and BLID=@BLID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachName", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", CharSplit[2]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    if (Data.ItemsBLNotes != "")
                    {
                        string[] ArrayBLNotes = Data.ItemsBLNotes.Split(new[] { "Insert:" }, StringSplitOptions.None);

                        Cmd.CommandText = "delete from NVO_ExpBLNotes where BLID=" + Data.BLID;
                        result = Cmd.ExecuteNonQuery();

                        for (int i = 1; i < ArrayBLNotes.Length; i++)
                        {
                            var CharSplit1 = ArrayBLNotes[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_ExpBLNotes where NID=@NID and BLID=@BLID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_ExpBLNotes(BkgID,BLID,NID,Notes) " +
                                         " values (@BkgID,@BLID,@NID,@Notes) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_ExpBLNotes SET BkgID=@BkgID,BLID=@BLID,NID=@NID,Notes=@Notes where NID=@NID and BLID=@BLID";


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NID", CharSplit1[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", CharSplit1[1]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }
                    trans.Commit();
                    ListBol.Add(new MyBOLData
                    {
                        MainID = Data.MainID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<BLNo> BLNumberList(BLNo Data)
        {
            List<BLNo> ListBL = new List<BLNo>();
            DataTable dt = GetBLDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new BLNo
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    MainID = Int32.Parse(dt.Rows[i]["MainID"].ToString()),
                });
            }
            return ListBL;
        }
        public DataTable GetBLDtls(BLNo Data)
        {
            string _Query = "select isnull((select top (1)NVO_BOLNew.ID from  NVO_BOLNew where NVO_BOLNew.BLID = NVO_BL.ID),0)as MainID, ID,BkgID,BLNumber from NVO_BL where BkgID=" + Data.BkgId;
            return GetViewData(_Query, "");
        }
        public List<MyBOLData> BkgPortDetails(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetPortDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Origin = dt.Rows[i]["Origin"].ToString(),
                    LoadPort = dt.Rows[i]["LoadPort"].ToString(),
                    Discharge = dt.Rows[i]["DischargePort"].ToString(),
                    Destination = dt.Rows[i]["Destination"].ToString(),
                    PaymentTermsID = Int32.Parse(dt.Rows[i]["PaymentTermsID"].ToString()),
                    OriginID = Int32.Parse(dt.Rows[i]["OriginID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["LoadPortID"].ToString()),
                    DischargeID = Int32.Parse(dt.Rows[i]["DischargePortID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["DestinationID"].ToString()),
                    DeliveryAgent = Int32.Parse(dt.Rows[i]["PODAgentID"].ToString()),

                });
            }
            return ListBL;
        }
        public DataTable GetPortDetails(MyBOLData Data)
        {
            string _Query = "select NVO_Booking.ID,(select PortName +'-' +PortCode from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.OriginID)as Origin, " +
                            " (select PortName + '-' + PortCode from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.LoadPortID) as LoadPort, " +
                            " (select PortName + '-' + PortCode from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DischargePortID)as DischargePort, " +
                            " (select PortName + '-' + PortCode from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DestinationID)as Destination,PaymentTermsID,PODAgentID, " +
                            " * from NVO_Booking where ID=" + Data.BkgId;
            return GetViewData(_Query, "");
        }

        public List<BLNo> BLNumberDtls(BLNo Data)
        {
            List<BLNo> ListBL = new List<BLNo>();
            DataTable dt = GetBLNumberValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new BLNo
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgId = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    
                });
            }
            return ListBL;
        }
        public DataTable GetBLNumberValue(BLNo Data)
        {
            string _Query = "select * from NVO_BL where BkgID="+ Data.BkgId +" and ID=" + Data.BLID;
            return GetViewData(_Query, "");
        }

        public List<BLTypes> BkgPortDetails(BLTypes Data)
        {
            List<BLTypes> ListBLType = new List<BLTypes>();
            DataTable dt = GetBLTypes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBLType.Add(new BLTypes
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLType = dt.Rows[i]["BLTypes"].ToString(),
                    
                });
            }
            return ListBLType;
        }
        public DataTable GetBLTypes(BLTypes Data)
        {
            string _Query = "select * from NVO_BLPrintTypes where id in(12,5,7)";
            return GetViewData(_Query, "");
        }


        public List<BLContainer> BkgContainerDtls(BLContainer Data)
        {
            List<BLContainer> ListBLContainer = new List<BLContainer>();
            DataTable dt = GetBkgContainerValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBLContainer.Add(new BLContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgId = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    ContainerNo = dt.Rows[i]["CntrNO"].ToString(),
                    ContrType = dt.Rows[i]["CntrType"].ToString(),
                    AgentSealNo = dt.Rows[i]["SealNo"].ToString(),
                    CustomerSealNo = dt.Rows[i]["CustomerSeal"].ToString(),
                    GrsWt = dt.Rows[i]["KgsWeight"].ToString(),
                    NetWt = dt.Rows[i]["NetWeight"].ToString(),
                    NoOfPkgs = dt.Rows[i]["NoofPkgs"].ToString(),
                    Volume = dt.Rows[i]["CBMVolume"].ToString(),

                });
            }
            return ListBLContainer;
        }

        public DataTable GetBkgContainerValues(BLContainer Data)
        {
           
            string _Query = "select ID,BkgID,CntrNO,CntrType,SealNo,CustomerSeal,KgsWeight,NetWeight,NoofPkgs,CBMVolume from NVO_BLCargo where BkgID=" + Data.BkgId;
            return GetViewData(_Query, "");
        }
        public List<BLContainer> BLContainerDtls(BLContainer Data)
        {
            List<BLContainer> ListBLContainer = new List<BLContainer>();
            DataTable dt = GetBLContainer(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBLContainer.Add(new BLContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    //CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    //CargoID = Int32.Parse(dt.Rows[i]["CargoID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BkgId = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    ContainerNo = dt.Rows[i]["CntrNo"].ToString(),
                    ContrType = dt.Rows[i]["Size"].ToString(),
                    AgentSealNo = dt.Rows[i]["SealNo"].ToString(),
                    CustomerSealNo = dt.Rows[i]["CustomerSeal"].ToString(),
                    GrsWt = dt.Rows[i]["KGSWeight"].ToString(),
                    NetWt = dt.Rows[i]["NetWeight"].ToString(),
                    NoOfPkgs = dt.Rows[i]["NoofPkgs"].ToString(),
                    Volume = dt.Rows[i]["CBMVolume"].ToString(),

                });
            }
            return ListBLContainer;
        }
        public DataTable GetBLContainer(BLContainer Data)
        {
            //string _Query = "Select NVO_Containers.Id,NVO_Containers.CntrNo,ISNULL(NVO_BLCargo.BLID,0)as BLID,(select top(1) Size from NVO_tblCntrTypes  where SizeID= SizeID) as Size, " +
            //               " (select top(1) Type from NVO_tblCntrTypes  where SizeID = SizeID) as CntrType, SealNo, CustomerSeal, KGSWeight, NetWeight, " +
            //               " CBMVolume, NVO_ContainerTxns.BkgID,NoofPkgs from NVO_Containers " +
            //               " inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
            //               " LEFT OUTER JOIN NVO_BLCargo on NVO_BLCargo.CntrID = NVO_Containers.ID " +
            //               " where NVO_ContainerTxns.BLNumber = 1 and NVO_ContainerTxns.BkgID =" + Data.BkgId;
            //string _Query = "select NVO_BLContainer.ID,NVO_BLCargo.ID as CargoID,  NVO_BLContainer.BLID, NVO_BLContainer.BKgID,(select CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID)as CntrNo, " +
            //                " (select top(1) Size from NVO_tblCntrTypes inner join NVO_Containers  on NVO_Containers.TypeID = NVO_tblCntrTypes.ID ) as Size, " +
            //                " (select SealNo from NVO_BLCargo where NVO_BLCargo.CntrID = NVO_BLContainer.CntrID)as AgentSeal, " +
            //                " (select CustomerSeal from NVO_BLCargo where NVO_BLCargo.CntrID = NVO_BLContainer.CntrID)as CustomerSeal, " +
            //                " (select KGSWeight from NVO_BLCargo where NVO_BLCargo.CntrID = NVO_BLContainer.CntrID)as KGSWeight, " +
            //                " (select NetWeight from NVO_BLCargo where NVO_BLCargo.CntrID = NVO_BLContainer.CntrID)as NetWeight, " +
            //                " (select NoofPkgs from NVO_BLCargo where NVO_BLCargo.CntrID = NVO_BLContainer.CntrID)as NoofPkgs, " +
            //                " (select CBMVolume from NVO_BLCargo where NVO_BLCargo.CntrID = NVO_BLContainer.CntrID)as CBMVolume " +
            //                " from NVO_BLContainer inner join NVO_BLCargo on NVO_BLCargo.CntrID = NVO_BLContainer.CntrID where NVO_BLContainer.BkgID=" + Data.BkgId + " and NVO_BLContainer.BLID=" + Data.BLID;

            string _Query = "select NVO_BLContainer.CntrID,NVO_BLContainer.BLID,NVO_BLCargo.ID as CargoID, " +
                            " (select CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo, " +
                            " (select top(1) Size from NVO_tblCntrTypes inner join NVO_Containers  on NVO_Containers.TypeID = NVO_tblCntrTypes.ID where NVO_Containers.ID = NVO_BLContainer.CntrID ) as Size,SealNo,CustomerSeal,KGSWeight,NetWeight,NoofPkgs,CBMVolume, * " +
                            " from NVO_BLContainer " +
                            " Left Outer join NVO_BLCargo on NVO_BLCargo.CntrID = NVO_BLContainer.CntrID " +
                            " where NVO_BLContainer.BkgID = " + Data.BkgId + " and NVO_BLContainer.BLID =" + Data.BLID;
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> ShipperName(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetShipperName(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipperName = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ListBL;
        }
        public DataTable GetShipperName(MyBOLData Data)
        {
            string _Query = "select ID,CustomerName from NVO_PartiesDtls where PartyTypeID=1";
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> Consignee(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetConsignee(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Consignee = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ListBL;
        }
        public DataTable GetConsignee(MyBOLData Data)
        {
            string _Query = "select ID,CustomerName from NVO_PartiesDtls where PartyTypeID=2";
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> Notify(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetNotify(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Notify = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ListBL;
        }
        public DataTable GetNotify(MyBOLData Data)
        {
            string _Query = "select ID,CustomerName from NVO_PartiesDtls where PartyTypeID=3";
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> NotifyAlso(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetNotifyAlso(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    NotifyAlso = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ListBL;
        }
        public DataTable GetNotifyAlso(MyBOLData Data)
        {
            string _Query = "select ID,CustomerName from NVO_PartiesDtls where PartyTypeID=4";
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> ExistingBOLDtls(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetBOLDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    MainID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DeliveryAgent = Int32.Parse(dt.Rows[i]["DeliveryAgent"].ToString()),
                    DeliveryAgentAddress = dt.Rows[i]["DeliveryAgentAddress"].ToString(),
                    BLNumberID = Int32.Parse(dt.Rows[i]["BLNumberID"].ToString()),
                    OriginID = Int32.Parse(dt.Rows[i]["PlaceofRecID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["PortofLoadID"].ToString()),
                    DischargeID = Int32.Parse(dt.Rows[i]["PortofDischargeID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["PortofDestinationID"].ToString()),
                    MarksNos = dt.Rows[i]["MarksNos"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    Packages = dt.Rows[i]["Packages"].ToString(),
                    Weight = dt.Rows[i]["Weight"].ToString(),
                    PaymentTermsID = Int32.Parse(dt.Rows[i]["PaymentTermsID"].ToString()),
                    FreightPayableAt = dt.Rows[i]["FreightPayableAt"].ToString(),
                    BLTypeID = Int32.Parse(dt.Rows[i]["BLTypeID"].ToString()),
                    NoOfOriginal = dt.Rows[i]["NoOfOriginal"].ToString(),
                    RFLBol = Int32.Parse(dt.Rows[i]["RFLBol"].ToString()),
                    BLIssueDate = dt.Rows[i]["BLIssueDate"].ToString(),
                    PlaceOfIssue = dt.Rows[i]["PlaceOfIssue"].ToString(),
                    ShipOnboardDate = dt.Rows[i]["ShipOnboardDate"].ToString(),
                    PrintWt = Int32.Parse(dt.Rows[i]["PrintWt"].ToString()),
                    PrintNetWt = Int32.Parse(dt.Rows[i]["PrintNetWt"].ToString()),
                    NotPrint = Int32.Parse(dt.Rows[i]["NotPrint"].ToString()),
                    AttachShippingBill = dt.Rows[i]["AttachShippingBill"].ToString(),
                    AttachCustomerApproval = dt.Rows[i]["AttachCustomerApproval"].ToString(),
                    Origin = dt.Rows[i]["OriginTxt"].ToString(),
                    LoadPort = dt.Rows[i]["LoadPortTxt"].ToString(),
                    Discharge = dt.Rows[i]["DischargeTxt"].ToString(),
                    Destination = dt.Rows[i]["DestinationTxt"].ToString(),
                    ShipperName = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify = dt.Rows[i]["Notify"].ToString(),
                    NotifyAddress = dt.Rows[i]["NotifyAddress"].ToString(),
                    NotifyAlso = dt.Rows[i]["Notifyalso"].ToString(),
                    NotifyAlsoAddress = dt.Rows[i]["NotifyAlsoAddress"].ToString(),
                    BkgId = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLStatus = Int32.Parse(dt.Rows[i]["BLStatus"].ToString()),
                });
            }
            return ListBL;
        }
        public DataTable GetBOLDtls(MyBOLData Data)
        {
            string _Query = "select convert(varchar, NVO_BOLNew.BLIssueDate, 23) as BLIssueDate,convert(varchar, NVO_BOLNew.ShipOnboardDate, 23) as ShipOnboardDate,AttachShippingBill, * from NVO_BOLNew " +                           
                            " where BkgID=" + Data.BkgId + " and BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }

        //public List<MyBOLData> ExistingDefaultBOLDtls(MyBOLData Data)
        //{
        //    List<MyBOLData> ListBL = new List<MyBOLData>();
        //    DataTable dt = GetBOLDefaultDtls(Data);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ListBL.Add(new MyBOLData
        //        {
        //            MainID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                   
        //            ShipperName = dt.Rows[i]["Shipper"].ToString(),
        //            ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
        //            Consignee = dt.Rows[i]["Consignee"].ToString(),
        //            ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
        //            Notify = dt.Rows[i]["Notify"].ToString(),
        //            NotifyAddress = dt.Rows[i]["NotifyAddress"].ToString(),
        //            NotifyAlso = dt.Rows[i]["Notifyalso"].ToString(),
        //            NotifyAlsoAddress = dt.Rows[i]["NotifyAlsoAddress"].ToString(),
        //            BkgId = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
        //            BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
        //            BLStatus = Int32.Parse(dt.Rows[i]["BLStatus"].ToString()),
        //        });
        //    }
        //    return ListBL;
        //}
        //public DataTable GetBOLDefaultDtls(MyBOLData Data)
        //{
        //    string _Query = "select convert(varchar, NVO_BOLNew.BLIssueDate, 23) as BLIssueDate,convert(varchar, NVO_BOLNew.ShipOnboardDate, 23) as ShipOnboardDate,AttachShippingBill, * from NVO_BOLNew " +
        //                    " where BkgID=" + Data.BkgId + " and BLID=" + Data.BLID;
        //    return GetViewData(_Query, "");
        //}




        public List<MyBOLData> ExistingPartiesDtls(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetPartiesDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipperName = dt.Rows[i]["ShipperName"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify = dt.Rows[i]["Notify"].ToString(),
                    NotifyAddress = dt.Rows[i]["NotifyAddress"].ToString(),
                    NotifyAlso = dt.Rows[i]["NotifyAlso"].ToString(),
                    NotifyAlsoAddress = dt.Rows[i]["NotifyAlsoAddress"].ToString(),
                   
                });
            }
            return ListBL;
        }
        public DataTable GetPartiesDtls(MyBOLData Data)
        {
            string _Query = "select * from NVO_PartiesDtls where ID=" + Data.PartyID + " and BkgID="+ Data.BkgId+" and BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }

      
        public List<MyBOLData> UpdateApprovalStatus(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNew Set BLStatus=@BLStatus where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.MainID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> UpdateCntrDtls(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " UPDATE NVO_BLCargo SET SealNo=@SealNo,CustomerSeal=@CustomerSeal,KGSWeight=@KGSWeight,NetWeight=@NetWeight,NoOfPkgs=@NoOfPkgs,CBMVolume=@CBMVolume where CntrID=@CntrID and BkgID=@BkgID";

                        
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerSeal", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@KGSWeight", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NetWeight", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkgs", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CBMVolume", CharSplit[6]));
                       int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                   
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> BLReleaseList(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetBLReleaseDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),                    
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLType = dt.Rows[i]["BLType"].ToString(),
                    BLStatusv = dt.Rows[i]["BLStatusv"].ToString(),
                    IssueDate = dt.Rows[i]["IssueDate"].ToString(),
                    IssuedBy = dt.Rows[i]["IssuedBy"].ToString(),
                    BLStatus = Int32.Parse(dt.Rows[i]["BLStatus"].ToString())

                });
            }
            return ListBL;
        }
        public DataTable GetBLReleaseDtls(MyBOLData Data)
        {
            string _Query = "select NVO_BL.ID,NVO_BL.BLNumber,BLStatus, " +
                            " (select BLTypes from NVO_BLPrintTypes where NVO_BLPrintTypes.ID = NVO_BOLNew.BLTypeID)as BLType, " +
                            "  Case when BLstatus = 3 then 'FINAL' else Case when BLstatus = 5 then 'ISSUED' end end as BLStatusv, " +
                            " Case when PaymentTermsID = 1 then 'PREPAID' else 'COLLECT' end as PaymentStatus,convert(varchar, BLIssueDate, 103) as IssueDate, " +
                            " (select username from NVO_UserDetails where NVO_UserDetails.ID = NVO_BOLNew.UserID)as IssuedBy " +
                            " from NVO_BL " +
                            " inner join NVO_BOLNew on NVO_bolnew.BLID = NVO_BL.ID " +
                            " where NVO_BOLNew.BLStatus in (3,5) and NVO_BL.BkgID=" + Data.BkgId;
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> BLSurrenderList(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetBLSurrenderDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),                  
                    IssuedBy = dt.Rows[i]["ProcessedBy"].ToString(),
                    SurrenderDate = dt.Rows[i]["SurrenderDate"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    AttachSurrenderFile = dt.Rows[i]["AttachFile"].ToString()

                });
            }
            return ListBL;
        }

        public DataTable GetBLSurrenderDtls(MyBOLData Data)
        {
            string _Query = "select NVO_BL.ID,NVO_BL.BkgID,NVO_BL.BLNumber,(select username from NVO_UserDetails where NVO_UserDetails.ID = NVO_BOLNew.UserID)as ProcessedBy,convert(varchar, SurrenderDate, 23) as SurrenderDate,Remarks,AttachFile from NVO_BL inner join NVO_BOLNew on NVO_bolnew.BLID = NVO_BL.ID left outer join NVO_BLSurrenderDtls on NVO_BLSurrenderDtls.BLID = NVO_BOLNew.BLID where NVO_BL.BkgID=" + Data.BkgId;
            //string _Query = "select NVO_BL.ID,NVO_BL.BkgID,NVO_BL.BLNumber,(select username from NVO_UserDetails where NVO_UserDetails.ID = NVO_BOLNew.UserID)as ProcessedBy from NVO_BL inner join NVO_BOLNew on NVO_bolnew.BLID = NVO_BL.ID where NVO_BL.BkgID=" + Data.BkgId;
            //string _Query = "select NVO_BL.ID,NVO_BL.BLNumber, " +
            //                " (select username from NVO_UserDetails where NVO_UserDetails.ID = NVO_BOLNew.UserID) as ProcessedBy  from NVO_BL " +
            //                " inner join NVO_BOLNew on NVO_bolnew.BLID = NVO_BL.ID where NVO_BOLNew.BLTypeID=7 and NVO_BL.BkgID=" + Data.BkgId;
            return GetViewData(_Query, "");
        }


        public List<MyBOLData> BLAttachmentView(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetBLAttachmentDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {
                    AID = Int32.Parse(dt.Rows[i]["AID"].ToString()),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    AttachName = dt.Rows[i]["AttachName"].ToString(),
                    AttachCount = Int32.Parse(dt.Rows[i]["AttachCount"].ToString()),
                });
            }
            return ListBL;
        }
        public DataTable GetBLAttachmentDtls(MyBOLData Data)
        {
            string _Query = "select AT.AID,BLID, (select top(1) count(AID) from NVO_BLAttachments where NVO_BLAttachments.BLID = AT.BLID) as AttachCount,AT.AttachFile,AT.AttachName from NVO_BLAttachments AT  where BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> DeletAttachDtls(MyBOLData Data)
        {
            List<MyBOLData> ListGeneral = new List<MyBOLData>();
            DataTable dt = AttachDeleteValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBOLData
                {
                    AID = Int32.Parse(dt.Rows[i]["AID"].ToString()),

                });
            }
            return ListGeneral;
        }
        public DataTable AttachDeleteValues(MyBOLData Data)
        {
            string _Query = "Delete from NVO_BLAttachments where AID=" + Data.AID;
            return GetViewData(_Query, "");
        }
        public List<BLNotes> BLNotesList(BLNotes Data)
        {
            List<BLNotes> ListGeneral = new List<BLNotes>();
            DataTable dt = BLNotesDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new BLNotes
                {
                    ID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    IsTrue = Int32.Parse(dt.Rows[i]["IsTrue"].ToString()),

                });
            }
            return ListGeneral;
        }
        public DataTable BLNotesDtls(BLNotes Data)
        {
            //string _Query = "select NID,DocID,Notes from NVO_BLNotesClauses where DocID=264";
            string _Query = "select NID,Notes, case when(select top(1) NID from NVO_ExpBLNotes where NVO_ExpBLNotes.NID = NVO_BLNotesClauses.NID and BLID = '"+ Data.BLID +"') > 0 then 1 else 0 end as IsTrue from NVO_BLNotesClauses where NVO_BLNotesClauses.DocID=264";
            return GetViewData(_Query, "");
        }

        public List<BLNotes> BLNotesExistList(BLNotes Data)
        {
            List<BLNotes> ListGeneral = new List<BLNotes>();
            DataTable dt = BLNotesExistDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new BLNotes
                {
                    ID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString()


                });
            }
            return ListGeneral;
        }
        public DataTable BLNotesExistDtls(BLNotes Data)
        {
            string _Query = "select *  from NVO_ExpBLNotes where BLID=" + Data.BLID +" and BkgID=" + Data.BkgId;
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> UpdateSubmitApproveStatus(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNEW Set BLStatus=@BLStatus where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.MainID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> UpdateApprovedBOL(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNEW Set BLStatus=@BLStatus where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.MainID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }



        public List<MyBOLData> UpdateRejectBOL(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNEW Set BLStatus=@BLStatus where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.MainID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> UpdateReleaseBOL(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNEW Set BLStatus=@BLStatus,BLIssueDate=@BLIssueDate  where BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLIssueDate", System.DateTime.Now.Date));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> InsertBLTemplate(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = " IF((select count(*) from NVO_BLTemplateDtls where ID=@ID and BLID=@BLID)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_BLTemplateDtls(BLMainID,TemplateName,BkgID,InputSourceID,BLTemplateID,DeliveryAgent,DeliveryAgentAddress,PlaceofRecID,PortofLoadID,PortofDischargeID,PortofDestinationID,MarksNos,Packages,Description,Weight,FreightPayableAt,BLTypeID,NoOfOriginal,RFLBol,BLIssueDate,PlaceOfIssue,ShipOnboardDate,PrintWt,PrintNetWt,NotPrint,CurrentDate,BLNumberID,BLID,PaymentTermsID,BLStatus,OriginTxt,LoadPortTxt,DischargeTxt,DestinationTxt,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify,NotifyAddress,Notifyalso,NotifyalsoAddress,UserID,BLNumber,PartyID,PartyName) " +
                                       " values (@BLMainID,@TemplateName,@BkgID,@InputSourceID,@BLTemplateID,@DeliveryAgent,@DeliveryAgentAddress,@PlaceofRecID,@PortofLoadID,@PortofDischargeID,@PortofDestinationID,@MarksNos,@Packages,@Description,@Weight,@FreightPayableAt,@BLTypeID,@NoOfOriginal,@RFLBol,@BLIssueDate,@PlaceOfIssue,@ShipOnboardDate,@PrintWt,@PrintNetWt,@NotPrint,@CurrentDate,@BLNumberID,@BLID,@PaymentTermsID,@BLStatus,@OriginTxt,@LoadPortTxt,@DischargeTxt,@DestinationTxt,@Shipper,@ShipperAddress,@Consignee,@ConsigneeAddress,@Notify,@NotifyAddress,@Notifyalso,@NotifyalsoAddress,@UserID,@BLNumber,@PartyID,@PartyName) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_BLTemplateDtls SET BLMainID=@BLMainID,TemplateName=@TemplateName,BkgID=@BkgID,InputSourceID=@InputSourceID,BLTemplateID=@BLTemplateID,DeliveryAgent=@DeliveryAgent,DeliveryAgentAddress=@DeliveryAgentAddress,PlaceofRecID=@PlaceofRecID,PortofLoadID=@PortofLoadID,PortofDischargeID=@PortofDischargeID,PortofDestinationID=@PortofDestinationID,MarksNos=@MarksNos,Packages=@Packages,Description=@Description,Weight=@Weight,FreightPayableAt=@FreightPayableAt,BLTypeID=@BLTypeID,NoOfOriginal=@NoOfOriginal,RFLBol=@RFLBol,BLIssueDate=@BLIssueDate,PlaceOfIssue=@PlaceOfIssue,ShipOnboardDate=@ShipOnboardDate,PrintWt=@PrintWt,PrintNetWt=@PrintNetWt,NotPrint=@NotPrint,CurrentDate=@CurrentDate,BLNumberID=@BLNumberID,BLID=@BLID,PaymentTermsID=@PaymentTermsID,BLStatus=@BLStatus,OriginTxt=@OriginTxt,LoadPortTxt=@LoadPortTxt,DischargeTxt=@DischargeTxt,DestinationTxt=@DestinationTxt,Shipper=@Shipper,ShipperAddress=@ShipperAddress,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,Notify=@Notify,NotifyAddress=@NotifyAddress,Notifyalso=@Notifyalso,NotifyalsoAddress=@NotifyalsoAddress,UserID=@UserID,BLNumber=@BLNumber,PartyID=@PartyID,PartyName=@PartyName where ID=@ID and BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLTempID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLMainID", Data.MainID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TemplateName", Data.BLTemplateName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InputSourceID", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTemplateID", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OriginTxt", Data.Origin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPortTxt", Data.LoadPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DischargeTxt", Data.Discharge));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationTxt", Data.Destination));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceofRecID", Data.OriginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortofLoadID", Data.LoadPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortofDischargeID", Data.DischargeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortofDestinationID", Data.DestinationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MarksNos", Data.MarksNos));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Packages", Data.Packages));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Weight", Data.Weight));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTermsID", Data.PaymentTermsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPayableAt", Data.FreightPayableAt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypeID", Data.BLTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfOriginal", Data.NoOfOriginal));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RFLBol", Data.RFLBol));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLIssueDate", Data.BLIssueDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceOfIssue", Data.PlaceOfIssue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipOnboardDate", Data.ShipOnboardDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintWt", Data.PrintWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintNetWt", Data.PrintNetWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotPrint", Data.NotPrint));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumberID", Data.BLNumberID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryAgent", Data.DeliveryAgent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryAgentAddress", Data.DeliveryAgentAddress));                   
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.ShipperName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", Data.Consignee));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify", Data.Notify));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAddress", Data.NotifyAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notifyalso", Data.NotifyAlso));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyalsoAddress", Data.NotifyAlsoAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.PartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", Data.PartyName));


                    //Cmd.CommandText = " IF((select count(*) from NVO_BLTemplateDtls where ID=@ID and BLMainID=@BLMainID and BLID=@BLID)<=0) " +
                    //                   " BEGIN " +
                    //                   " INSERT INTO  NVO_BLTemplateDtls(BLMainID,BLID,BkgID,ShipperName,ShipperAddress,ConsigneeName,ConsigneeAddress,DeliveryAgent,DeliveryAgentAddress,Notify,NotifyAddress,NotifyAlso,NotifyAlsoAddress,MarksNos,Description,TemplateName) " +
                    //                   " values (@BLMainID,@BLID,@BkgID,@ShipperName,@ShipperAddress,@ConsigneeName,@ConsigneeAddress,@DeliveryAgent,@DeliveryAgentAddress,@Notify,@NotifyAddress,@NotifyAlso,@NotifyAlsoAddress,@MarksNos,@Description,@TemplateName) " +
                    //                   " END  " +
                    //                   " ELSE " +
                    //                   " UPDATE NVO_BLTemplateDtls SET BLMainID=@BLMainID,BLID=@BLID,BkgID=@BkgID,ShipperName=@ShipperName,ShipperAddress=@ShipperAddress,ConsigneeName=@ConsigneeName,ConsigneeAddress=@ConsigneeAddress,DeliveryAgent=@DeliveryAgent,DeliveryAgentAddress=@DeliveryAgentAddress,Notify=@Notify,NotifyAddress=@NotifyAddress,NotifyAlso=@NotifyAlso,NotifyAlsoAddress=@NotifyAlsoAddress,MarksNos=@MarksNos,Description=@Description,TemplateName=@TemplateName where ID=@ID and BLMainID=@BLMainID and BLID=@BLID";

                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLTempID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLMainID", Data.MainID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperName", Data.ShipperName));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeName", Data.Consignee));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryAgent", Data.DeliveryAgent));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryAgentAddress", Data.DeliveryAgentAddress));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify", Data.Notify));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAddress", Data.NotifyAddress));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAlso", Data.NotifyAlso));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAlsoAddress", Data.NotifyAlsoAddress));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@MarksNos", Data.MarksNos));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@TemplateName", Data.BLTemplateName));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                  

                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> BLTemplateListDtls(MyBOLData Data)
        {
            List<MyBOLData> ListGeneral = new List<MyBOLData>();
            DataTable dt = BLTemplateList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLTemplateName = dt.Rows[i]["TemplateName"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString())
                });
            }
            return ListGeneral;
        }
        public DataTable BLTemplateList(MyBOLData Data)
        {
            string _Query = "select ID,TemplateName, *  from NVO_BLTemplateDtls where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> BLTemplateExistDtls(MyBOLData Data)
        {
            List<MyBOLData> ListGeneral = new List<MyBOLData>();
            DataTable dt = BLTemplateExistValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLTemplateName = dt.Rows[i]["TemplateName"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString())
                });
            }
            return ListGeneral;
        }
        public DataTable BLTemplateExistValues(MyBOLData Data)
        {
            string _Query = "select ID,TemplateName, *  from NVO_BLTemplateDtls";
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> BLTemplateChangeDtls(MyBOLData Data)
        {
            List<MyBOLData> ListGeneral = new List<MyBOLData>();
            DataTable dt = BLTemplateChangeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBOLData
                {
                    BLTempID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLTemplateName = dt.Rows[i]["TemplateName"].ToString(),
                    DeliveryAgent = Int32.Parse(dt.Rows[i]["DeliveryAgent"].ToString()),
                    DeliveryAgentAddress = dt.Rows[i]["DeliveryAgentAddress"].ToString(),
                    BLNumberID = Int32.Parse(dt.Rows[i]["BLNumberID"].ToString()),
                    OriginID = Int32.Parse(dt.Rows[i]["PlaceofRecID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["PortofLoadID"].ToString()),
                    DischargeID = Int32.Parse(dt.Rows[i]["PortofDischargeID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["PortofDestinationID"].ToString()),
                    MarksNos = dt.Rows[i]["MarksNos"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    Packages = dt.Rows[i]["Packages"].ToString(),
                    Weight = dt.Rows[i]["Weight"].ToString(),
                    PaymentTermsID = Int32.Parse(dt.Rows[i]["PaymentTermsID"].ToString()),
                    FreightPayableAt = dt.Rows[i]["FreightPayableAt"].ToString(),
                    BLTypeID = Int32.Parse(dt.Rows[i]["BLTypeID"].ToString()),
                    NoOfOriginal = dt.Rows[i]["NoOfOriginal"].ToString(),
                    RFLBol = Int32.Parse(dt.Rows[i]["RFLBol"].ToString()),
                    BLIssueDate = dt.Rows[i]["BLIssueDate"].ToString(),
                    PlaceOfIssue = dt.Rows[i]["PlaceOfIssue"].ToString(),
                    ShipOnboardDate = dt.Rows[i]["ShipOnboardDate"].ToString(),
                    PrintWt = Int32.Parse(dt.Rows[i]["PrintWt"].ToString()),
                    PrintNetWt = Int32.Parse(dt.Rows[i]["PrintNetWt"].ToString()),
                    NotPrint = Int32.Parse(dt.Rows[i]["NotPrint"].ToString()),
                    AttachShippingBill = dt.Rows[i]["AttachShippingBill"].ToString(),
                    AttachCustomerApproval = dt.Rows[i]["AttachCustomerApproval"].ToString(),
                    Origin = dt.Rows[i]["OriginTxt"].ToString(),
                    LoadPort = dt.Rows[i]["LoadPortTxt"].ToString(),
                    Discharge = dt.Rows[i]["DischargeTxt"].ToString(),
                    Destination = dt.Rows[i]["DestinationTxt"].ToString(),
                    ShipperName = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify = dt.Rows[i]["Notify"].ToString(),
                    NotifyAddress = dt.Rows[i]["NotifyAddress"].ToString(),
                    NotifyAlso = dt.Rows[i]["Notifyalso"].ToString(),
                    NotifyAlsoAddress = dt.Rows[i]["NotifyAlsoAddress"].ToString(),
                    BkgId = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLStatus = Int32.Parse(dt.Rows[i]["BLStatus"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                });
            }
            return ListGeneral;
        }
        public DataTable BLTemplateChangeValues(MyBOLData Data)
        {
            string _Query = "select * from NVO_BLTemplateDtls where ID=" + Data.BLTempID;
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> UpdateSOBDate(MyBOLData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNEW Set SOBDate=@SOBDate where BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SOBDate", Data.SOBDate));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }


        public List<MyBOLData> ExistingSOBDate(MyBOLData Data)
        {
            List<MyBOLData> ListGeneral = new List<MyBOLData>();
            DataTable dt = GetSOBDateValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    SOBDate = dt.Rows[i]["SOBDate"].ToString(),
                });
            }
            return ListGeneral;
        }
        public DataTable GetSOBDateValues(MyBOLData Data)
        {
            string _Query = "select convert(varchar, NVO_BOLNew.SOBDate, 23) as SOBDate, * from NVO_BOLNew where BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }

        public List<BLNo> ApprovalBLNumberList(BLNo Data)
        {
            List<BLNo> ListGeneral = new List<BLNo>();
            DataTable dt = GetApprovalBLDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new BLNo
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                });
            }
            return ListGeneral;
        }
        public DataTable GetApprovalBLDtls(BLNo Data)
        {
            string _Query = "select NVO_BL.ID,NVO_BL.BLNumber  from NVO_BL inner join NVO_BOLNew on NVO_BOLNew.BLID = NVO_BL.ID where BLStatus=2";
            return GetViewData(_Query, "");
        }



        public List<MyBOLData> InsertBLSurrenderDtls(MyBOLData Data)
        {


            DbConnection con = null;
            DbTransaction trans;


            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');


                            Cmd.CommandText = " IF((select count(*) from NVO_BLSurrenderDtls where BLID=@BLID)<=0) " +
                                                            " BEGIN " +
                                                            " INSERT INTO  NVO_BLSurrenderDtls(BLID,BkgID,BLNumber,SurrenderDate,IssuedBy,Remarks,AttachFile) " +
                                                            " values(@BLID,@BkgID,@BLNumber,@SurrenderDate,@IssuedBy,@Remarks,@AttachFile) " +
                                                            " END  " +
                                                            " ELSE " +
                                                            " UPDATE NVO_BLSurrenderDtls SET BLID=@BLID,BkgID=@BkgID,BLNumber=@BLNumber,SurrenderDate=@SurrenderDate,IssuedBy=@IssuedBy,Remarks=@Remarks,AttachFile=@AttachFile where BLID=@BLID";

                            
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SurrenderDate", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IssuedBy", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.AttachSurrenderFile));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgId));
                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();


                        }
                    }
                    trans.Commit();
                    ListBol.Add(new MyBOLData
                    {
                        ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public List<MyBOLData> BLSurrenderAttachList(MyBOLData Data)
        {
            List<MyBOLData> ListBL = new List<MyBOLData>();
            DataTable dt = GetBLSurrenderAttachDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBL.Add(new MyBOLData
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    IssuedBy = dt.Rows[i]["IssuedBy"].ToString(),
                    SurrenderDate = dt.Rows[i]["SurrenderDate"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    AttachSurrenderFile = dt.Rows[i]["AttachFile"].ToString()

                });
            }
            return ListBL;
        }

        public DataTable GetBLSurrenderAttachDtls(MyBOLData Data)
        {
            string _Query = "select convert(varchar, SurrenderDate, 23) as SurrenderDate, * from NVO_BLSurrenderDtls where BkgID=" + Data.BkgID;


            return GetViewData(_Query, "");
        }

        public List<MyBOLData> BLSurrenderDelete(MyBOLData Data)
        {
            List<MyBOLData> ListGeneral = new List<MyBOLData>();
            DataTable dt = GetBLSurrenderDelete(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SurrenderDate = dt.Rows[i]["SurrenderDate"].ToString(),
                    AttachSurrenderFile = dt.Rows[i]["AttachFile"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString()
                });
            }
            return ListGeneral;
        }
        public DataTable GetBLSurrenderDelete(MyBOLData Data)
        {
            string _Query = "Delete NVO_BLSurrenderDtls where BkgID=" + Data.BkgId + " and BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MyBOLData> PrincipleCustomerMaster()
        {
            List<MyBOLData> CustomerList = new List<MyBOLData>();
            DataTable dt = GetPrincipalMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyBOLData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["LineName"].ToString().ToUpper()
                });
            }
            return CustomerList;
        }

        public DataTable GetPrincipalMaster()
        {
            string _Query = "select ID,LineName from NVO_PrincipalMaster where ID=7";
            return GetViewData(_Query, "");
        }

        public List<MyBOLData> UpdateBLPrintPath(string BLID, string MergePDF)
        {
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Update NVO_BOLNEW Set BLPrintPath=@BLPrintPath  where BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLPrintPath", MergePDF));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListBol.Add(new MyBOLData
                    {
                        ///ID = Data.ID,
                    });
                    return ListBol;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBol;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        #region get values
        public DataTable GetViewData(string Query, string CmdType)
        {
            DbConnection con = null;
            DataTable DT = null;
            try
            {
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();

                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;

                    if (CmdType == "SP")
                        cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = Query;
                    DbDataAdapter adapter = _dbFactory.GetAdapter();
                    adapter.SelectCommand = cmd;
                    DT = new DataTable();
                    adapter.Fill(DT);
                }
                return DT;

            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public string Getvalue(string Query)
        {
            DbConnection con = null;
            try
            {
                string Result = "";
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();
                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Query;
                    object objresult = cmd.ExecuteScalar();
                    if (objresult != null)
                        Result = objresult.ToString();

                }
                return Result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        #endregion
    }


}

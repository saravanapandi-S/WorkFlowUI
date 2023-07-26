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

namespace DataManager
{
    public class DocumentManager
    {
        List<MyBooking> MyBkgList = new List<MyBooking>();
        List<MyCROMaster> MyCROList = new List<MyCROMaster>();
        List<MYBOL> MyBOLList = new List<MYBOL>();
        List<MYBLRelease> MyBLRList = new List<MYBLRelease>();
        List<ChargeCorrectorInsert> MyChargeCorrector = new List<ChargeCorrectorInsert>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public DocumentManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion


        public List<MYRRBooking> BookingRRSearchBindValus(MYRRBooking Data)
        {
            List<MYRRBooking> ViewList = new List<MYRRBooking>();
            DataTable dt = GetBookingRRSearchBindValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYRRBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    POL = dt.Rows[i]["POLCode"].ToString(),
                    POD = dt.Rows[i]["PODCode"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    ShipmentTypes = dt.Rows[i]["ShipmentTypes"].ToString(),
                    serviceTypes = dt.Rows[i]["serviceTypes"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTillv"].ToString(),
                    BaseAmt = dt.Rows[i]["Base"].ToString(),
                    Rate = dt.Rows[i]["Rate"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    SlotCntr20Rate = dt.Rows[i]["SlotCntr20Rate"].ToString(),
                    SlotCntr4Rate = dt.Rows[i]["SlotCntr4Rate"].ToString(),
                    SlotTerm = dt.Rows[i]["SlotTerm"].ToString(),
                    Oceanfr20 = dt.Rows[i]["Oceanfr20"].ToString(),
                    Oceanfr40 = dt.Rows[i]["Oceanfr40"].ToString(),
                    Cntr20 = dt.Rows[i]["Cntr20"].ToString(),
                    Cntr40 = dt.Rows[i]["Cntr40"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    Commodity40 = dt.Rows[i]["Commodity40"].ToString(),

                    FRT20 = dt.Rows[i]["FRT20"].ToString(),
                    FRT40 = dt.Rows[i]["FRT40"].ToString(),

                    BAF20 = dt.Rows[i]["BAF20"].ToString(),
                    BAF40 = dt.Rows[i]["BAF40"].ToString(),

                    ECRS20 = dt.Rows[i]["ECRS20"].ToString(),
                    ECRS40 = dt.Rows[i]["ECRS40"].ToString(),

                    LSS20 = dt.Rows[i]["LSS20"].ToString(),
                    LSS40 = dt.Rows[i]["LSS40"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    Transhipment = dt.Rows[i]["Transhipment"].ToString(),



                });
            }
            return ViewList;
        }
        public DataTable GetBookingRRSearchBindValus(MYRRBooking Data)
        {
            string strWhere = "";
            string _Query = "select * from v_NVO_BookingRatesheetView";

            if (Data.RatesheetNo != "" && Data.RatesheetNo != "0" && Data.RatesheetNo != null && Data.RatesheetNo != "?")
                if (strWhere == "")
                    strWhere += _Query + " where Id= " + Data.RatesheetNo;
                else
                    strWhere += " and Id= " + Data.RatesheetNo;

            if (Data.POD != "" && Data.POD != "0" && Data.POD != null && Data.POD != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PlaceofDischargeId= " + Data.POD;
                else
                    strWhere += " and PlaceofDischargeId= " + Data.POD;

            if (Data.POL != "" && Data.POL != "0" && Data.POL != null && Data.POL != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PortofLoading= " + Data.POL;
                else
                    strWhere += " and PortofLoading= " + Data.POL;

            if (Data.FPOD != "" && Data.FPOD != "0" && Data.FPOD != null && Data.FPOD != "?")
                if (strWhere == "")
                    strWhere += _Query + " where FinalPODID= " + Data.FPOD;
                else
                    strWhere += " and FinalPODID= " + Data.FPOD;

            if (Data.ShipmentTypes != "" && Data.ShipmentTypes != "0" && Data.ShipmentTypes != null && Data.ShipmentTypes != "?")
                if (strWhere == "")
                    strWhere += _Query + " where ShipmentID= " + Data.ShipmentTypes;
                else
                    strWhere += " and ShipmentID= " + Data.ShipmentTypes;

            if (Data.BookingParty != "" && Data.BookingParty != "0" && Data.BookingParty != null && Data.BookingParty != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BookingPartyID= " + Data.BookingParty;
                else
                    strWhere += " and BookingPartyID= " + Data.BookingParty;

            if (Data.AgentID != "" && Data.AgentID != "0" && Data.AgentID != null && Data.AgentID != "?")
                if (strWhere == "")
                    strWhere += _Query + " where AgentID= " + Data.AgentID;
                else
                    strWhere += " and AgentID= " + Data.AgentID;

            if (Data.LogInAgentID != "" && Data.LogInAgentID != "0" && Data.LogInAgentID != null && Data.LogInAgentID != "?" && Data.LogInAgentID != "2")
                if (strWhere == "")
                    strWhere += _Query + " where AgentID= " + Data.LogInAgentID;
                else
                    strWhere += " and AgentID= " + Data.LogInAgentID;


            if (Data.ShipperID != "" && Data.ShipperID != "0" && Data.ShipperID != null && Data.ShipperID != "?")
                if (strWhere == "")
                    strWhere += _Query + " where ShipperID= " + Data.ShipperID;
                else
                    strWhere += " and ShipperID= " + Data.ShipperID;


            if (Data.RSStatus != "" && Data.RSStatus != "0" && Data.RSStatus != null && Data.RSStatus != "?" && Data.LogInAgentID == "2")
                if (strWhere == "")
                    strWhere += _Query + " where RSStatus= " + Data.RSStatus;
                else
                    strWhere += " and RSStatus= " + Data.RSStatus;

            if (strWhere == "")
                strWhere = _Query;

            strWhere += "  union select * from v_NVO_BookingRatesheetView where ID in (select RRID from NVO_RRBLAccessTable where AgencyID= " + Data.LogInAgentID + ")";

            return GetViewData(strWhere, "");
        }

        public List<MyBooking> BookingInsert(MyBooking Data)
        {

            int result = 0;
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
                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("BkgNo", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'OCL' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)" + "+''+" + "(select top(1) DocumentSuffix from NVO_AgencyMaster where Id=" + Data.DestinationAgentID + ")";
                        Data.BookingNo = Cmd.ExecuteScalar().ToString();
                    }


                    Cmd.CommandText = " IF((select count(*) from NVO_Booking where ID=@ID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_Booking(BookingNo,BkgDate,RRID,RRNo,SlotRefNo,BkgPartyID,BkgParty,ShipmentTypeID,ShipmentType,POOID,POO,POLID,POL,PODID,POD,FPODID,FPOD,ServiceTypeID,ServiceType,CommodityTypeID,CommodityType,SalesPersonID,SalesPerson," +
                                 " CarrierID,Carrier,VesVoyID,VesVoy,ShipperID,Shipper, PickUpDepotID, PickUpDepot, ValidTill,PortNtRef,Remarks,AgentID,UserID,CurrentDate,PreparedBYID,PreparedBY,CTQ20,CTQ40,TSPORT,TSPORTID,DestinationAgent,DestinationAgentID,BkgStatus,SlotContractID,SlotOperatorID,SlotAmt20,SlotAmt40,SlotTermsID,DirectImport,TranshipmetAgentID) " +
                                 " values (@BookingNo,@BkgDate,@RRID,@RRNo,@SlotRefNo,@BkgPartyID,@BkgParty,@ShipmentTypeID,@ShipmentType,@POOID,@POO,@POLID,@POL,@PODID,@POD,@FPODID,@FPOD,@ServiceTypeID,@ServiceType,@CommodityTypeID,@CommodityType,@SalesPersonID,@SalesPerson," +
                                 " @CarrierID,@Carrier,@VesVoyID,@VesVoy,@ShipperID,@Shipper,@PickUpDepotID,@PickUpDepot,@ValidTill,@PortNtRef,@Remarks,@AgentID,@UserID,@CurrentDate,@PreparedBYID,@PreparedBY,@CTQ20,@CTQ40,@TSPORT,@TSPORTID,@DestinationAgent,@DestinationAgentID,@BkgStatus,@SlotContractID,@SlotOperatorID,@SlotAmt20,@SlotAmt40,@SlotTermsID,@DirectImport,@TranshipmetAgentID) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_Booking SET BookingNo=@BookingNo,BkgDate=@BkgDate,RRID=@RRID,RRNo=@RRNo,SlotRefNo=@SlotRefNo,BkgPartyID=@BkgPartyID,BkgParty=@BkgParty,ShipmentTypeID=@ShipmentTypeID,ShipmentType=@ShipmentType,POOID=@POOID,POO=@POO," +
                                 " POLID=@POLID,POL=@POL,PODID=@PODID,POD=@POD,FPODID=@FPODID,FPOD=@FPOD,ServiceTypeID=@ServiceTypeID,ServiceType=@ServiceType,CommodityTypeID=@CommodityTypeID,CommodityType=@CommodityType,SalesPersonID=@SalesPersonID,SalesPerson=@SalesPerson," +
                                 " CarrierID=@CarrierID,Carrier=@Carrier,VesVoyID=@VesVoyID,VesVoy=@VesVoy,ShipperID=@ShipperID,Shipper=@Shipper,PickUpDepotID=@PickUpDepotID,PickUpDepot=@PickUpDepot,ValidTill=@ValidTill,PortNtRef=@PortNtRef,Remarks=@Remarks," +
                                 " AgentID=@AgentID,UserID=@UserID,CurrentDate=@CurrentDate,PreparedBYID=@PreparedBYID,PreparedBY=@PreparedBY,CTQ20=@CTQ20,CTQ40=@CTQ40,TSPORT=@TSPORT,TSPORTID=@TSPORTID,DestinationAgent=@DestinationAgent,DestinationAgentID=@DestinationAgentID,BkgStatus=@BkgStatus,SlotContractID=@SlotContractID,SlotOperatorID=@SlotOperatorID,SlotAmt20=@SlotAmt20,SlotAmt40=@SlotAmt40,SlotTermsID=@SlotTermsID,DirectImport=@DirectImport,TranshipmetAgentID=@TranshipmetAgentID where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingNo", Data.BookingNo));
                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgDate", DateTime.ParseExact(Data.BkgDate, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgDate", Data.BkgDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRNo", Data.RRNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRefNo", Data.SlotRefNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgPartyID", Data.BkgPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgParty", Data.BkgParty));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", Data.ShipmentTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", Data.ShipmentType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POO", Data.POO));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", Data.POL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPOD", Data.FPOD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypeID", Data.ServiceTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceType", Data.ServiceType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", Data.CommodityTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityType", Data.CommodityType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPerson", Data.SalesPerson));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CarrierID", Data.CarrierID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Carrier", Data.Carrier));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", Data.ShipperID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.Shipper));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDepotID", Data.PickUpDepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDepot", Data.PickUpDepot));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", DateTime.ParseExact(Data.ValidTill.ToString(), "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortNtRef", Data.PortNtRef));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", Data.AgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", Data.POD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PreparedBYID", Data.PreparedBYID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PreparedBY", Data.PreparedBY));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CTQ20", Data.CTQ20));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CTQ40", Data.CTQ40));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPORT", Data.TSPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPORTID", Data.TsPortID));
                    if (Data.TranshipmetAgentID == "?")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TranshipmetAgentID", 0));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TranshipmetAgentID", Data.TranshipmetAgentID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationAgent", Data.DestinationAgent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationAgentID", Data.DestinationAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgStatus", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotContractID", Data.SlotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperatorID", Data.SlotOperatorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmt20", Data.Cnt20));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmt40", Data.Cnt40));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotTermsID", Data.SlotTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DirectImport", 1));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Booking')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BookingCntrTypes where BID=@BID and BkgID=@BkgID and CntrTypes=@CntrTypes)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BookingCntrTypes(BkgID,CntrTypes,Qty,CommodityType) " +
                                     " values (@BkgID,@CntrTypes,@Qty,@CommodityType) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BookingCntrTypes SET BkgID=@BkgID,CntrTypes=@CntrTypes,Qty=@Qty,CommodityType=@CommodityType where BID=@BID and BkgID=@BkgID and CntrTypes=@CntrTypes";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypes", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityType", CharSplit[3]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayTs = Data.TranshimentPort.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayTs.Length; i++)
                    {
                        var CharSplit = ArrayTs[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_BkgTranshipmentPort where BkgID=@BkgID and TSPortID=@TSPortID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BkgTranshipmentPort(BkgID,TSPortID) " +
                                     " values (@BkgID,@TSPortID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BkgTranshipmentPort SET BkgID=@BkgID,TSPortID=@TSPortID where BkgID=@BkgID and TSPortID=@TSPortID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPortID", CharSplit[0]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //DataTable _dtRR = GetRatesheetCharge(Data.RRID.ToString(), "1");
                    //if (_dtRR.Rows.Count > 0)
                    //{
                    //    for (int y = 0; y < _dtRR.Rows.Count; y++)
                    //    {


                    //        Cmd.CommandText = " IF((select count(*) from NVO_BLCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID)<=0) " +
                    //                     " BEGIN " +
                    //                     " INSERT INTO  NVO_BLCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                    //                     " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                    //                     " END  " +
                    //                     " ELSE " +
                    //                     " UPDATE NVO_BLCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                    //                     " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", _dtRR.Rows[y]["CID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtRR.Rows[y]["TariffTypeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtRR.Rows[y]["CntrType"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtRR.Rows[y]["ChargeCodeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtRR.Rows[y]["CurrencyID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtRR.Rows[y]["PaymentModeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtRR.Rows[y]["ReqRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtRR.Rows[y]["ManifRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtRR.Rows[y]["CustomerRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtRR.Rows[y]["RateDiff"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtRR.Rows[y]["TariffID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}

                    //DataTable _dtRR1 = GetRatesheetCharge(Data.RRID.ToString(), "2");
                    //if (_dtRR1.Rows.Count > 0)
                    //{
                    //    for (int y = 0; y < _dtRR1.Rows.Count; y++)
                    //    {


                    //        Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID)<=0) " +
                    //                     " BEGIN " +
                    //                     " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                    //                     " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                    //                     " END  " +
                    //                     " ELSE " +
                    //                     " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                    //                     " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", _dtRR1.Rows[y]["CID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtRR1.Rows[y]["TariffTypeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtRR1.Rows[y]["CntrType"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtRR1.Rows[y]["ChargeCodeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtRR1.Rows[y]["CurrencyID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtRR1.Rows[y]["PaymentModeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtRR1.Rows[y]["ReqRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtRR1.Rows[y]["ManifRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtRR1.Rows[y]["CustomerRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtRR1.Rows[y]["RateDiff"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtRR1.Rows[y]["TariffID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}
                    //trans.Commit();

                    //DataTable dtST = GetSlatCost(Data.ID.ToString());
                    //if (dtST.Rows.Count > 0)
                    //{
                    //    for (int s = 0; s < dtST.Rows.Count; s++)
                    //    {
                    //        Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID)<=0) " +
                    //                    " BEGIN " +
                    //                    " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                    //                    " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                    //                    " END  " +
                    //                    " ELSE " +
                    //                    " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                    //                    " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", dtST.Rows[s]["RCID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 108));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", dtST.Rows[s]["CntrType"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", dtST.Rows[s]["ChargeCodeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", dtST.Rows[s]["CurrencyID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", dtST.Rows[s]["PaymentModeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", dtST.Rows[s]["ReqRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", dtST.Rows[s]["ManifRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", dtST.Rows[s]["CustomerRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}
                    //DataTable GetTS = GetTSCost(Data.ID.ToString(), Data.TsPortID);
                    //if (GetTS.Rows.Count > 0)
                    //{
                    //    for (int y = 0; y < dtST.Rows.Count; y++)
                    //    {
                    //        Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID)<=0) " +
                    //                    " BEGIN " +
                    //                    " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                    //                    " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                    //                    " END  " +
                    //                    " ELSE " +
                    //                    " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                    //                    " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", GetTS.Rows[y]["RCID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 0));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", GetTS.Rows[y]["CntrType"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", GetTS.Rows[y]["ChargeCodeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", GetTS.Rows[y]["CurrencyID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", GetTS.Rows[y]["PaymentModeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", GetTS.Rows[y]["ReqRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", GetTS.Rows[y]["ManifRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", GetTS.Rows[y]["CustomerRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", GetTS.Rows[y]["TariffTypeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}

                    //DataTable _dtComm = GetEITCommision(Data.ID.ToString());
                    //if (_dtComm.Rows.Count > 0)
                    //{
                    //    for (int m = 0; m < _dtComm.Rows.Count; m++)
                    //    {
                    //        if (_dtComm.Rows[m]["ChargeCodeID"].ToString() != "34")
                    //        {
                    //            Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where  ChargeCodeID=@ChargeCodeID and BkgID=@BkgID)<=0) " +
                    //                        " BEGIN " +
                    //                        " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                    //                        " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                    //                        " END  " +
                    //                        " ELSE " +
                    //                        " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                    //                        " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where ChargeCodeID=@ChargeCodeID and BkgID=@BkgID";
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", 0));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 0));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtComm.Rows[m]["CntrTypes"].ToString()));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtComm.Rows[m]["ChargeCodeID"].ToString()));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtComm.Rows[m]["CurrencyID"].ToString()));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", 19));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                    //            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                    //            result = Cmd.ExecuteNonQuery();
                    //            Cmd.Parameters.Clear();
                    //        }
                    //        else
                    //        {  if (Data.TranshipmetAgentID != "0")
                    //            {
                    //                Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where  ChargeCodeID=@ChargeCodeID and BkgID=@BkgID)<=0) " +
                    //                           " BEGIN " +
                    //                           " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                    //                           " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                    //                           " END  " +
                    //                           " ELSE " +
                    //                           " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                    //                           " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where ChargeCodeID=@ChargeCodeID and BkgID=@BkgID";
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", 0));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 0));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtComm.Rows[m]["CntrTypes"].ToString()));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtComm.Rows[m]["ChargeCodeID"].ToString()));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtComm.Rows[m]["CurrencyID"].ToString()));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", 19));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                    //                Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                    //                result = Cmd.ExecuteNonQuery();
                    //                Cmd.Parameters.Clear();
                    //            }
                    //        }
                            
                    //    }
                    //}


                    MyBkgList.Add(new MyBooking { ID = Data.ID, BookingNo = Data.BookingNo });
                    return MyBkgList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBkgList;
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


        public DataTable GetRatesheetCharge(string RRID, string ChargeTypeID)
        {
            string _Query = "select CID, RRID, TariffTypeID, CntrType, ChargeCodeID, CurrencyID, PaymentModeID, ReqRate, ManifRate, CustomerRate, RateDiff, TariffID from NVO_RatesheetCharges where ChargeTypeID= " + ChargeTypeID + " and RRID=" + RRID;
            return GetViewData(_Query, "");
        }

        public DataTable GetSlatCost(string BkgID)
        {
            string _Query = " select SID as RCID,ChargeID as ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where Id = ChargeID) as ChargeCode,SizeID as CntrType,  " +
                            " (select top(1) size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_SLOTDDtls.SizeID) as CntrTypes, CurrencyID, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID) as Currency,19 as PaymentModeID, 'COLLECT' as PaymentMode, " +
                            " Amount as ReqRate,Amount as ManifRate,Amount as CustomerRate,'' RateDiff, " +
                            " Case when SizeID = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = SizeID) end as Qty, " +
                            " ((select top(1)(CustomerName + '-' + Branch) from NVO_CustomerMaster " +
                            " inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.ID  where CID = SlotOperatorID)) as VendorName, " +
                            " SlotOperatorID as VendorID from NVO_SLOTDDtls " +
                            " inner join NVO_Booking on NVO_Booking.SlotContractID = NVO_SLOTDDtls.SLID " +
                            " inner join NVO_BookingCntrTypes on NVO_BookingCntrTypes.BKgID = NVO_Booking.ID and NVO_BookingCntrTypes.CntrTypes = NVO_SLOTDDtls.SizeID " +
                            " where NVO_Booking.ID = " + BkgID + " and Commodity in ((select CommodityType from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID)) ";
            return GetViewData(_Query, "");
        }

        public DataTable GetTSCost(string BkgID, string TsPortID)
        {
            string _Query = "";
            if (TsPortID == "279")
            {
                _Query = " select TID as RCID,case when PortLocationID in (237, 232)  then Amount *2 else Amount end ReqRate," +
                           " case when PortLocationID in (237, 232)  then Amount *2 else Amount end ManifRate," +
                           " case when PortLocationID in (237, 232)  then Amount *2 else Amount end CustomerRate,0 as RateDiff," +
                           " CntrID as CntrType,CommodityTypeID, ChargeCodeID,CurrencyID,TraiffRegular as TariffTypeID,19 as PaymentModeID " +
                           " from NVO_PortTariffMaster " +
                           " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                           " where PortLocationID = (select TSPORTID from NVO_Booking where Id = " + BkgID + ") and HandlingChargeID = (select top(1) SlotTermsID from NVO_Booking where Id = " + BkgID + ")" +
                           " and ShipmentTypeID = 192 and CommodityTypeID = (select CommodityType from NVO_BookingCntrTypes where BKgID = " + BkgID + ")  " +
                           " and CntrID = (select CntrTypes from NVO_BookingCntrTypes where BKgID = " + BkgID + ") and ValidTO >= getdate()";
            }
            else
            {
                _Query = " select TID as RCID,case when PortLocationID in (237, 232)  then Amount *2 else Amount end ReqRate," +
                               " case when PortLocationID in (237, 232)  then Amount *2 else Amount end ManifRate," +
                               " case when PortLocationID in (237, 232)  then Amount *2 else Amount end CustomerRate,0 as RateDiff," +
                               " CntrID as CntrType,CommodityTypeID, ChargeCodeID,CurrencyID,TraiffRegular as TariffTypeID,19 as PaymentModeID " +
                               " from NVO_PortTariffMaster " +
                               " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                               " where PortLocationID = (select TSPORTID from NVO_Booking where Id = " + BkgID + ") " +
                               " and ShipmentTypeID = 192 and CommodityTypeID = (select CommodityType from NVO_BookingCntrTypes where BKgID = " + BkgID + ")  " +
                               " and CntrID = (select CntrTypes from NVO_BookingCntrTypes where BKgID = " + BkgID + ") and ValidTO >= getdate()";
            }
            return GetViewData(_Query, "");
        }

        public DataTable GetEITCommision(string BkgID)
        {
            string _Query = " select distinct '1'AS RCID,(select(select Size from NVO_tblCntrTypes where NVO_tblCntrTypes.Id = NVO_BookingCntrTypes.CntrTypes) from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = Bkg.ID) as CntrType, " +
                            " (select top(1) Qty from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = Bkg.ID) as Qty, 32 as ChargeCodeID , 'EXPORT COMMISSION' as ChargeCode, 146 as CurrencyID, 'USD' as Currency, " +
                            " (select top(1) CntrTypes from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = Bkg.ID) as CntrTypes, " +
                            " isnull((select  top(1) case when FixedRate <= (select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
                            " from NVO_Booking where NVO_Booking.Id = Bkg.ID) then((CommPercentage * ((select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
                            " from NVO_Booking where NVO_Booking.Id = Bkg.ID))) / 100)  else FixedRate end from NVO_CommissionContract where AgencyID = Bkg.AgentID and ShipmentType = 1),0) as FixedRate,'' as RateDiff " +
                            " from NVO_Booking Bkg " +
                            " inner join NVO_RatesheetCharges  on NVO_RatesheetCharges.RRID = Bkg.RRID where Bkg.Id = " + BkgID +
                            " union " +
                            " select distinct '2'AS RCID, " +
                            " (select(select Size from NVO_tblCntrTypes where NVO_tblCntrTypes.Id = NVO_BookingCntrTypes.CntrTypes) from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = Bkg.ID) as CntrType, " +
                            " (select top(1) Qty from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = Bkg.ID) as Qty, " +
                            " 33 as ChargeCodeID , 'IMPORT COMMISSION' as ChargeCode, 146 as CurrencyID, 'USD' as Currency, " +
                            " (select top(1) CntrTypes from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = Bkg.ID) as CntrTypes, " +
                            " isnull((select  top(1) case when FixedRate <= (select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
                            " from NVO_Booking where NVO_Booking.Id = Bkg.ID) then((CommPercentage * ((select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
                            " from NVO_Booking where NVO_Booking.Id = Bkg.ID))) / 100)  else FixedRate end from NVO_CommissionContract where AgencyID = Bkg.DestinationAgentID and ShipmentType = 2),0) as FixedRate, " +
                            " '' as RateDiff from NVO_Booking Bkg " +
                            " inner join NVO_RatesheetCharges  on NVO_RatesheetCharges.RRID = Bkg.RRID where  Bkg.Id = " + BkgID +
                            " union " +
                            " select distinct '3'AS RCID, " +
                            " (select(select Size from NVO_tblCntrTypes where NVO_tblCntrTypes.Id = NVO_BookingCntrTypes.CntrTypes) from NVO_BookingCntrTypes " +
                            " where NVO_BookingCntrTypes.BKgID = NVO_Booking.ID) as CntrTypes, " +
                            " (select top(1) Qty from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = NVO_Booking.ID) as Qty, " +
                            " 34 as ChargeCodeID , 'TRANSHIPMENT COMMISSION' as ChargeCode, 146 as CurrencyID, 'USD' as Currency, " +
                            " (select top(1) CntrTypes from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BKgID = NVO_Booking.ID) as CntrType, " +
                            " isnull((select top(1) FixedRate from NVO_CommissionContract where AgencyID = NVO_Booking.AgentID and ShipmentType = 179),0)  as FixedRate,'' as RateDiff " +
                            " from NVO_Booking where  NVO_Booking.Id = " + BkgID;
            return GetViewData(_Query, "");
        }




        public List<MyBooking> BookingConfirmInsert(MyBooking Data)
        {

            int result = 0;
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
                    DataTable _dt = GetCheckAfterConfirm(Data);
                   
                    if (_dt.Rows.Count > 0)
                    {
                        if (_dt.Rows[0]["CheckCRO"].ToString() != "0")
                        {
                            Data.Status = "CheckCRO";
                        }
                        else if (_dt.Rows[0]["CheckCRO"].ToString() == "0")
                        {
                            Data.Status = "Confirm";
                        }
                        if (_dt.Rows[0]["ReqQty"].ToString() == _dt.Rows[0]["CntrTotal"].ToString())
                        {
                            Data.Status = "Confirm";
                        }

                        if (_dt.Rows[0]["ReqQty"].ToString() != Data.QtyItems)
                        {
                            Data.Status = "CheckCROQty";
                        }
                        else if (_dt.Rows[0]["ReqQty"].ToString() != _dt.Rows[0]["CntrTotal"].ToString())
                        {
                            Data.Status = "CheckCNTRNo";
                        }
                        if (Data.Status == "Confirm")
                        {
                            Cmd.CommandText = " UPDATE NVO_Booking SET BkgStatus=@BkgStatus,ConfirmDate=@ConfirmDate where  ID=@ID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgStatus", Data.IntStatus));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmDate", System.DateTime.Now));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                            trans.Commit();
                            Data.Status = "Confirm";
                        }
                    }
                    else
                    {
                        Data.Status = "CheckCRO";
                    }


                    MyBkgList.Add(new MyBooking { ID = Data.ID, Status = Data.Status });
                    return MyBkgList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBkgList;
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


        public DataTable GetCheckAfterConfirm(MyBooking Data)
        {



            //string _Query = " select ((select sum(Qty) from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BkgId= "+ Data.ID +")  - isnull(sum(ReqQty),0)) as CheckCRO, " +
            //                " sum(ReqQty) as ReqQty,(select Count(CntrNo) as CntrTotal from NVO_BOLCntrPickup where BkgId = " + Data.ID + ") as CntrTotal " +
            //                " from NVO_CROMaster " +
            //                " inner join NVO_CRODetails on NVO_CRODetails.CROID = NVO_CROMaster.ID where BkgID = " + Data.ID + " and CROStatus = 0 group by ReqQty";
            //return GetViewData(_Query, "");

            string _Query = " select ((select sum(Qty) from NVO_BookingCntrTypes where NVO_BookingCntrTypes.BkgId= " + Data.ID + ")  - isnull(sum(ReqQty),0)) as CheckCRO, " +
                            " sum(ReqQty) as ReqQty,(select Count(distinct  ContainerID) as CntrTotal from NVO_ContainerTxns where BLNUMBER = " + Data.ID + ") as CntrTotal " +
                            " from NVO_CROMaster " +
                            " inner join NVO_CRODetails on NVO_CRODetails.CROID = NVO_CROMaster.ID where BkgID = " + Data.ID + " and CROStatus = 0 group by ReqQty";
            return GetViewData(_Query, "");
        }



        public List<MyBooking> BookingViewValus(MyBooking Data)
        {
            List<MyBooking> ViewList = new List<MyBooking>();
            DataTable dt = GetBookingSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BkgDatev = dt.Rows[i]["BkgDate"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBookingSearchValus(MyBooking Data)
        {
            string strWhere = "";
            string _Query = "select ID,BookingNo,RRNo,convert(varchar, BkgDate,106) as BkgDate,ShipmentType,BkgParty,POL,case when BkgStatus =1 then 'DRAFT' else case when BKGStatus= 2  then 'CONFIRM' else case when BkgStatus = 3 then 'CANCELED' end end end as Status from NVO_Booking";

            strWhere += _Query + " where DirectImport=1";

            if (Data.BookingNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where BookingNo like '%" + Data.BookingNo + "%'";
                else
                    strWhere += " and BookingNo like '%" + Data.BookingNo + "%'";

            if (Data.RRNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where RRNO like '%" + Data.RRNo + "%'";
                else
                    strWhere += " and RRNO like '%" + Data.RRNo + "%'";

            if (Data.BkgPartyID != "" && Data.BkgPartyID != "0" && Data.BkgPartyID != null && Data.BkgPartyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BkgPartyID = " + Data.BkgPartyID;
                else
                    strWhere += " and BkgPartyID = " + Data.BkgPartyID;

            if (Data.POL != "" && Data.POL != "0" && Data.POL != null && Data.POL != "?")
                if (strWhere == "")
                    strWhere += _Query + " where POLID= " + Data.POL;
                else
                    strWhere += " and POLID= " + Data.POL;

            if (Data.POD != "" && Data.POD != "0" && Data.POD != null && Data.POD != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PODID= " + Data.POD;
                else
                    strWhere += " and PODID= " + Data.POD;
            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BkgStatus=" + Data.Status;
                else
                    strWhere += " and BkgStatus=" + Data.Status;

            if (Data.AgentID != "" && Data.AgentID != "0" && Data.AgentID != "2" && Data.AgentID != "undefined" && Data.AgentID != null)

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.AgentID = " + Data.AgentID;
                else
                    strWhere += " and NVO_Booking.AgentID = " + Data.AgentID;

            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere + " order by Id desc", "");
        }


        public List<MyBooking> BookingCountValus(MyBooking Data)
        {
            List<MyBooking> ViewList = new List<MyBooking>();
            DataTable dt = GetBookingCount(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyBooking
                {

                    Draft = dt.Rows[i]["Draft"].ToString(),
                    Cancelled = dt.Rows[i]["Cancel"].ToString(),
                    Confirm = dt.Rows[i]["Confirm"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBookingCount(MyBooking Data)
        {
            if (Data.AgentID.ToString() == "2")
            {
                string _Query = " select  " +
                            " (select count(ID) from NVO_Booking where BkgStatus = 1 ) as Draft, " +
                            " (select count(ID) as Draft  from NVO_Booking where BkgStatus = 2 ) as Confirm, " +
                            " (select count(ID) as Draft  from NVO_Booking where BkgStatus = 3 ) as Cancel";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = " select  " +
                          " (select count(ID) from NVO_Booking where BkgStatus = 1 and AgentID=" + Data.AgentID + ") as Draft, " +
                          " (select count(ID) as Draft  from NVO_Booking where BkgStatus = 2 and AgentID=" + Data.AgentID + ") as Confirm, " +
                          " (select count(ID) as Draft  from NVO_Booking where BkgStatus = 3 and AgentID=" + Data.AgentID + ") as Cancel";
                return GetViewData(_Query, "");
            }
        }

        public List<MyBooking> BookingExistingViewValus(MyBooking Data)
        {
            List<MyBooking> ViewList = new List<MyBooking>();
            DataTable dt = GetBookingExistingSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BkgDatev = dt.Rows[i]["BkgDatev"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    SlotRefNo = dt.Rows[i]["SlotRefNo"].ToString(),
                    BkgPartyID = dt.Rows[i]["BkgPartyID"].ToString(),
                    ShipmentTypeID = dt.Rows[i]["ShipmentTypeID"].ToString(),
                    POOID = dt.Rows[i]["POOID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),
                    ServiceTypeID = dt.Rows[i]["ServiceTypeID"].ToString(),
                    CommodityTypeID = dt.Rows[i]["CommodityTypeID"].ToString(),
                    SalesPersonID = dt.Rows[i]["SalesPersonID"].ToString(),
                    CarrierID = dt.Rows[i]["CarrierID"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    PortNtRef = dt.Rows[i]["PortNtRef"].ToString(),
                    ValidTillv = dt.Rows[i]["ValidTillv"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    ShipperID = dt.Rows[i]["ShipperID"].ToString(),
                    PickUpDepotID = dt.Rows[i]["PickUpDepotID"].ToString(),
                    PreparedBYID = dt.Rows[i]["PreparedBYID"].ToString(),
                    CTQ20 = dt.Rows[i]["CTQ20"].ToString(),
                    CTQ40 = dt.Rows[i]["CTQ40"].ToString(),
                    TsPortID = dt.Rows[i]["TSPORTID"].ToString(),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    Cnt20 = dt.Rows[i]["SlotAmt20"].ToString(),
                    Cnt40 = dt.Rows[i]["SlotAmt40"].ToString(),
                    SlotTermID = dt.Rows[i]["SlotTermsID"].ToString(),
                    SlotOperatorID = dt.Rows[i]["SlotOperatorID"].ToString(),
                    SlotID = dt.Rows[i]["SlotContractID"].ToString(),
                    Status = dt.Rows[i]["BkgStatusv"].ToString(),
                    TranshimentPort = dt.Rows[i]["TSPORTID"].ToString(),
                    TranshipmetAgentID = dt.Rows[i]["TranshipmetAgentID"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetBookingExistingSearchValus(MyBooking Data)
        {
            string _Query = "select ID,convert(varchar, BkgDate,23) as BkgDatev,convert(varchar, ValidTill,23) as ValidTillv,case when BkgStatus= 1 then 'DRAFT'  when BkgStatus= 2 then  'CONFIRM'  else 'CANCEL' end as BkgStatusv,* from NVO_Booking where ID= " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyBooking> BkgCntrTypesExistingValus(MyBooking Data)
        {
            List<MyBooking> ViewList = new List<MyBooking>();
            DataTable dt = GetBkgCntrTypesExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyBooking
                {
                    BID = dt.Rows[i]["BID"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrTypes"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    CommodityType = dt.Rows[i]["CommodityType"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBkgCntrTypesExistingValus(MyBooking Data)
        {
            string _Query = "select * from NVO_BookingCntrTypes where BkgID= " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyCROMaster> CROInsert(MyCROMaster Data)
        {

            int result = 0;
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
                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("CRO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'CRO' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.ReleaseOrderNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_CROMaster where ID=@ID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_CROMaster(ReleaseOrderNo,Date,BkgID,CusID,CommodityID,VesselID,ETADate,ETDDate,CutDate,PickDepoID,Surveyor,LineCode,Remarks,CurrentDate,ValidTill,CROStatus,UserID,AgencyID) " +
                                 " values (@ReleaseOrderNo,@Date,@BkgID,@CusID,@CommodityID,@VesselID,@ETADate,@ETDDate,@CutDate,@PickDepoID,@Surveyor,@LineCode,@Remarks,@CurrentDate,@ValidTill,@CROStatus,@UserID,@AgencyID) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_CROMaster SET ReleaseOrderNo=@ReleaseOrderNo,Date=@Date,BkgID=@BkgID,CusID=@CusID,CommodityID=@CommodityID,VesselID=@VesselID,ETADate=@ETADate,ETDDate=@ETDDate," +
                                 " CutDate=@CutDate,PickDepoID=@PickDepoID,Surveyor=@Surveyor,LineCode=@LineCode,Remarks=@Remarks,CurrentDate=@CurrentDate,ValidTill=@ValidTill,CROStatus=@CROStatus,UserID=@UserID,AgencyID=@AgencyID where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReleaseOrderNo", Data.ReleaseOrderNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", Data.Date));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CusID", Data.CusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", Data.CommodityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETADate", Data.ETADate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETDDate", Data.ETDDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CutDate", DateTime.Parse(Data.CutDate).ToString("yyyy-MM-dd h:mm tt")));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@CutDate", Data.CutDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickDepoID", Data.PickDepoID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Surveyor", Data.Surveyor));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LineCode", Data.LineCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CROStatus", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentId));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_CROMaster')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_CRODetails where CID=@CID and CROID=@CROID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CRODetails(CROID,CntrTypeID,Qty,ReqQty,PenQty) " +
                                     " values (@CROID,@CntrTypeID,@Qty,@ReqQty,@PenQty) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CRODetails SET CROID=@CROID,CntrTypeID=@CntrTypeID,Qty=@Qty,ReqQty=@ReqQty,PenQty=@PenQty where CID=@CID and CROID=@CROID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CROID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqQty", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PenQty", CharSplit[4]));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();
                    MyCROList.Add(new MyCROMaster { ID = Data.ID, ReleaseOrderNo = Data.ReleaseOrderNo });
                    return MyCROList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyCROList;
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


        public List<MyCROMaster> CROUpdate(MyCROMaster Data)
        {

            int result = 0;
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

                    Cmd.CommandText = " UPDATE NVO_CROMaster SET CutDate=@CutDate,PickDepoID=@PickDepoID,Surveyor=@Surveyor,LineCode=@LineCode,ValidTill=@ValidTill where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CutDate", Data.CutDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickDepoID", Data.PickDepoID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Surveyor", Data.Surveyor));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LineCode", Data.LineCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    MyCROList.Add(new MyCROMaster { ID = Data.ID, ReleaseOrderNo = Data.ReleaseOrderNo });
                    return MyCROList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyCROList;
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


        public List<MyCROMaster> CROCancelled(MyCROMaster Data)
        {

            int result = 0;
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


                    Cmd.CommandText = " UPDATE NVO_CROMaster SET CROStatus=@CROStatus where  ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CROStatus", Data.Status));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    trans.Commit();
                    MyCROList.Add(new MyCROMaster { ID = Data.ID });
                    return MyCROList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyCROList;
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


        public List<MyCROMaster> CROViewValus(MyCROMaster Data)
        {
            List<MyCROMaster> ViewList = new List<MyCROMaster>();
            DataTable dt = GetCROSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCROMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReleaseOrderNo = dt.Rows[i]["ReleaseOrderNo"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Date = dt.Rows[i]["ValidFrom"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),


                });
            }
            return ViewList;
        }

        public List<MyCROMaster> CROViewValusAll(MyCROMaster Data)
        {
            List<MyCROMaster> ViewList = new List<MyCROMaster>();
            DataTable dt = GetCROSearchValusALL(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCROMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReleaseOrderNo = dt.Rows[i]["ReleaseOrderNo"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Date = dt.Rows[i]["ValidFrom"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetCROSearchValusALL(MyCROMaster Data)
        {
            string _Query = " Select ReleaseOrderNo, (select top(1) BookingNo from NVO_Booking where ID = BkgID) as BookingNo," +
                            "  convert(varchar, Date, 106) as ValidFrom,convert(varchar, ValidTill, 106) as ValidTill,case when CROStatus = 1 then 'CANCELLED' ELSE 'ACTIVE' END AS Status,* from NVO_CROMaster where BkgID=" + Data.BkgID;


            return GetViewData(_Query, "");
        }


        public List<MyCROMaster> CROBkgSelectView(MyCROMaster Data)
        {
            List<MyCROMaster> ViewList = new List<MyCROMaster>();
            DataTable dt = GetCROBkgselectValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCROMaster
                {

                    BkgParty = dt.Rows[i]["BkgPartyID"].ToString(),
                    CommodityID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoyID"].ToString(),
                    ETADate = dt.Rows[i]["ETADate"].ToString(),
                    ETDDate = dt.Rows[i]["ETDDate"].ToString(),
                    CutDate = dt.Rows[i]["CutOffDate"].ToString(),
                    PickDepoID = Int32.Parse(dt.Rows[i]["PickUpDepotID"].ToString())

                });
            }
            return ViewList;
        }

        public DataTable GetCROBkgselectValues(MyCROMaster Data)
        {
            string _Query = " select top(1) NVO_VoyageRoute.RID,BkgPartyID,CommodityTypeID,VesVoyID,convert(varchar,ETA,23) as ETADate,convert(varchar,ETD,23) as ETDDate, " +
                            " convert(varchar, ETD, 23) as CutOffDate,PickUpDepotID from NVO_Booking " +
                            " inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = NVO_Booking.VesVoyID  where NVO_Booking.ID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public DataTable GetCROSearchValus(MyCROMaster Data)
        {
            string strWhere = "";
            string _Query = "Select ReleaseOrderNo, (select top(1) BookingNo from NVO_Booking where ID = BkgID) as BookingNo,convert(varchar, ValidTill, 106) as ValidTill,convert(varchar, Date, 106) as ValidFrom,case when CROStatus = 1 then 'CANCELLED' ELSE 'ACTIVE' END AS Status,* from NVO_CROMaster ";

            if (Data.ReleaseOrderNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where ReleaseOrderNo like '%" + Data.ReleaseOrderNo + "%'";
                else
                    strWhere += " and ReleaseOrderNo like '%" + Data.ReleaseOrderNo + "%'";

            if (Data.BkgID.ToString() != "" && Data.BkgID.ToString() != "0" && Data.BkgID.ToString() != null && Data.BkgID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BkgID= " + Data.BkgID.ToString();
                else
                    strWhere += " and BkgID= " + Data.BkgID.ToString();

            if (Data.CusID.ToString() != "" && Data.CusID.ToString() != "0" && Data.CusID.ToString() != null && Data.CusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where CusID=" + Data.CusID.ToString();
                else
                    strWhere += " and CusID=" + Data.CusID.ToString();

            if (Data.AgentId != "" && Data.AgentId != "0" && Data.AgentId != "2" && Data.AgentId != "undefined" && Data.AgentId != null)

                if (strWhere == "")
                    strWhere += _Query + " where AgencyID = " + Data.AgentId;
                else
                    strWhere += " and AgencyID = " + Data.AgentId;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }


        public List<MyCROMaster> CROExistingViewValus(MyCROMaster Data)
        {
            List<MyCROMaster> ViewList = new List<MyCROMaster>();
            DataTable dt = GetCROExistingSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCROMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReleaseOrderNo = dt.Rows[i]["ReleaseOrderNo"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CusID"].ToString()),
                    CommodityID = Int32.Parse(dt.Rows[i]["CommodityID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    ETADate = dt.Rows[i]["ETADate"].ToString(),
                    ETDDate = dt.Rows[i]["ETDDate"].ToString(),

                    CutDate = dt.Rows[i]["CutDate"].ToString(),
                    PickDepoID = Int32.Parse(dt.Rows[i]["PickDepoID"].ToString()),
                    Surveyor = dt.Rows[i]["Surveyor"].ToString(),
                    LineCode = dt.Rows[i]["LineCode"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetCROExistingSearchValus(MyCROMaster Data)
        {
            string _Query = " Select ID, ReleaseOrderNo, convert(varchar, Date, 23) as Date,BkgID,CusID,CommodityID,VesselID," +
                            " convert(varchar, ETADate, 23) as ETADate,convert(varchar, ETDDate, 23) as ETDDate, " +
                            " FORMAT(CutDate, 'yyyy-MM-ddTHH:mm:ss') as CutDate,PickDepoID,Surveyor,case when CROStatus = 1 then 'CANCELLED' ELSE 'ACTIVE' END AS Status, " +
                            " LineCode,Remarks,CurrentDate, convert(varchar, ValidTill, 23) as ValidTill from NVO_CROMaster where ID= " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyCROMaster> CRODetailsExistingValus(MyCROMaster Data)
        {
            List<MyCROMaster> ViewList = new List<MyCROMaster>();
            DataTable dt = GetCROExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCROMaster
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Qty = Int32.Parse(dt.Rows[i]["Qty"].ToString()),
                    ReqQty = Int32.Parse(dt.Rows[i]["ReqQty"].ToString()),
                    PenQty = Int32.Parse(dt.Rows[i]["PenQty"].ToString())
                    //ContainerID = Int32.Parse(dt.Rows[i]["ContainerID"].ToString())

                });
            }
            return ViewList;
        }

        public DataTable GetCROExistingValus(MyCROMaster Data)
        {
            string _Query = "select CID,CROID,CntrTypeID,Qty,ReqQty,PenQty from NVO_CRODetails where CROID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> BOLBkgSelectExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLBkgSelectExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    BLNumber = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),

                    POOID = dt.Rows[i]["POOID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),

                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    ServiceType = dt.Rows[i]["ServiceType"].ToString(),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    DesAgentID = Int32.Parse(dt.Rows[i]["DestinationAgentID"].ToString()),
                    Shipper = dt.Rows[i]["ShipperID"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    CommodityTypeID = dt.Rows[i]["CommodityTypeID"].ToString(),
                    BkgPartyID = dt.Rows[i]["BkgPartyID"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLBkgSelectExistingValus(MYBOL Data)
        {
            string _Query = " select BookingNo,RRNo,BkgParty,POO,POL,POD,FPOD,POOID,POLID,PODID,FPODID,ShipmentType,ServiceType,SalesPerson,VesVoy,'20' + ' x ' +  convert(varchar,CTQ20) + ',' + '40' + ' x ' + convert(varchar,CTQ40) as CntrCount," +
                            " DestinationAgentID, ShipperID, Shipper,(select top(1) Address from NVO_CusBranchLocation where CustomerID= ShipperID) as Address," +
                            " (select top(1) ImpFreeDays from NVO_RatesheetMode  where RRId = RRID) as FreeDays,case when bkgstatus = 1 then 'DRAFT' WHEN bkgstatus = 3 THEN 'CANCELLED' When bkgstatus = 2 then 'DRAFT'  end as Status,VesVoyID,CommodityTypeID,BkgPartyID from NVO_Booking where ID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> BOLCntrNoSelectExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLSelectCntrNoExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    Size = dt.Rows[i]["size"].ToString(),
                    ISOCode = dt.Rows[i]["IsOCodeID"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLSelectCntrNoExistingValus(MYBOL Data)
        {
            string _Query = "select Id,CntrNo,(select size  from NVO_tblCntrTypes where Id =TypeID) as size,IsOCodeID  from NVO_Containers where ID=" + Data.CntrID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> BOLInsert(MYBOL Data)
        {

            int result = 0;
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



                    Cmd.CommandText = " IF((select count(*) from NVO_BOL where ID=@ID and BkgID=@BkgID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_BOL(BLNumber,BkgID,DesAgentID,NoofOriginal,SurrenderStatus,MarkNo,CagoDescription,BLTypes,MotherBL,FreeDays,FreightPaymentID,Remarks,CurrentDate,POOID,POLID,PODID,FPODID,AgencyID,BLCommodityTypeID,BLVesVoyID,BLVesVoy,BLDirectImport,BLBkgPartyID,BLDirect) " +
                                 " values (@BLNumber,@BkgID,@DesAgentID,@NoofOriginal,@SurrenderStatus,@MarkNo,@CagoDescription,@BLTypes,@MotherBL,@FreeDays,@FreightPaymentID,@Remarks,@CurrentDate,@POOID,@POLID,@PODID,@FPODID,@AgencyID,@BLCommodityTypeID,@BLVesVoyID,@BLVesVoy,@BLDirectImport,@BLBkgPartyID,@BLDirect) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_BOL SET BLNumber=@BLNumber,BkgID=@BkgID,DesAgentID=@DesAgentID,NoofOriginal=@NoofOriginal,SurrenderStatus=@SurrenderStatus,MarkNo=@MarkNo,CagoDescription=@CagoDescription," +
                                 " BLTypes=@BLTypes,MotherBL=@MotherBL,FreeDays=@FreeDays,FreightPaymentID=@FreightPaymentID,Remarks=@Remarks,CurrentDate=@CurrentDate,POOID=@POOID,POLID=@POLID,PODID=@PODID,FPODID=@FPODID,AgencyID=@AgencyID,BLCommodityTypeID=@BLCommodityTypeID,BLVesVoyID=@BLVesVoyID,BLVesVoy=@BLVesVoy,BLDirectImport=@BLDirectImport,BLBkgPartyID=@BLBkgPartyID,BLDirect=@BLDirect where ID=@ID and BkgID=@BkgID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DesAgentID", Data.DesAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofOriginal", Data.NoofOriginal));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SurrenderStatus", Data.SurrenderStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MarkNo", Data.MarkNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CagoDescription", Data.CagoDescription));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypes", Data.BLTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MotherBL", Data.MotherBL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", Data.FreeDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPaymentID", Data.FreightPaymentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.ToString("MM/dd/yyyy")));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLCommodityTypeID", Data.CommodityTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoyID", Data.VesVoyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoy", Data.VesVoy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirectImport", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLBkgPartyID", Data.BkgPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirect", 1));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_BOL')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().Split(new[] { "Address:" }, StringSplitOptions.None);
                        var CharSplitA = CharSplit[0].ToString().Split(',');
                        var CharSplitB = CharSplit[1].ToString();
                        Cmd.CommandText = " IF((select count(*) from NVO_BOLCustomerDetails where BLID=@BLID and BkgID=@BkgID and PartyTypeID=@PartyTypeID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BOLCustomerDetails(BLID,PartyTypeID,PartID,PartType,PartyName,PartyAddress,BkgId) " +
                                     " values (@BLID,@PartyTypeID,@PartID,@PartType,@PartyName,@PartyAddress,@BkgId) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BOLCustomerDetails SET BLID=@BLID,PartyTypeID=@PartyTypeID,PartID=@PartID,PartType=@PartType,PartyName=@PartyName,PartyAddress=@PartyAddress,BkgId=@BkgId where BLID=@BLID and BkgID=@BkgID and PartyTypeID=@PartyTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BCID", CharSplitA[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", CharSplitA[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", CharSplitA[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartType", CharSplitA[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", CharSplitA[4]));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyAddress", CharSplitB));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayCntr = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayCntr.Length; i++)
                    {
                        var CharSplit = ArrayCntr[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BOLCntrDetails where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BOLCntrDetails(BLID,CntrNo,CntrID,Size,ISOCode,SealNo,NoOfPkg,PakgType,PakgTypeName,GrsWt,NtWt,VGM,CBM,BkgId) " +
                                     " values (@BLID,@CntrNo,@CntrID,@Size,@ISOCode,@SealNo,@NoOfPkg,@PakgType,@PakgTypeName,@GrsWt,@NtWt,@VGM,@CBM,@BkgId) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BOLCntrDetails SET BLID=@BLID,CntrNo=@CntrNo,CntrID=@CntrID,Size=@Size,ISOCode=@ISOCode,SealNo=@SealNo,NoOfPkg=@NoOfPkg,PakgType=@PakgType" +
                                     " ,PakgTypeName=@PakgTypeName,GrsWt=@GrsWt,NtWt=@NtWt,VGM=@VGM,CBM=@CBM,BkgId=@BkgId where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BCNID", CharSplit[0]));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Size", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkg", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgType", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgTypeName", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWt", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", CharSplit[12]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayVs = Data.ItemsVS.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayVs.Length; i++)
                    {
                        var CharSplit = ArrayVs[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BOLVoyageDetails where VID=@VID and BLID=@BLID and BkgID=@BkgID and LegInformation=@LegInformation)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BOLVoyageDetails(VoyageTypes,LegInformation,VesVoyID,LoadPort,NextPort,ETA,ETD,BLID,BkgID) " +
                                     " values (@VoyageTypes,@LegInformation,@VesVoyID,@LoadPort,@NextPort,@ETA,@ETD,@BLID,@BkgID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BOLVoyageDetails SET VoyageTypes=@VoyageTypes,LegInformation=@LegInformation,VesVoyID=@VesVoyID,LoadPort=@LoadPort," +
                                     " NextPort=@NextPort,ETA=@ETA,ETD=@ETD,BLID=@BLID,BkgID=@BkgID where VID=@VID and BLID=@BLID and BkgID=@BkgID and LegInformation=@LegInformation";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VID", CharSplit[0]));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageTypes", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LegInformation", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPort", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPort", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", DateTime.ParseExact(CharSplit[6], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", DateTime.ParseExact(CharSplit[7], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();
                    MyBOLList.Add(new MYBOL { ID = Data.ID });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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



        public List<MYBOL> BOLExemptionUpdate(MYBOL Data)
        {

            int result = 0;
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

                    Cmd.CommandText = " UPDATE NVO_BOL SET ShipmentTypeID=@ShipmentTypeID,ReasonDescription=@ReasonDescription where  BkgID=@BkgID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", Data.ShipmentType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReasonDescription", Data.Remarks));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    MyBOLList.Add(new MYBOL { BkgID = Data.BkgID });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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


        public List<MYBOL> BOLCargoReleaseUpdate(MYBOL Data)
        {

            int result = 0;
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

                    Cmd.CommandText = " UPDATE NVO_BOL SET CargoReleaseStatus=@CargoReleaseStatus where  BkgID=@BkgID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoReleaseStatus", Data.CargoReleaseStatus));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    MyBOLList.Add(new MYBOL { BkgID = Data.BkgID });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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


        public List<MYBOL> BOLViewValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLSearchValus(Data);
            string Statusvs = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["BLTypes"].ToString() != "")
                    Statusvs = dt.Rows[i]["BLTypes"].ToString();
                else
                    Statusvs = "MOTHER BL";

                ViewList.Add(new MYBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    BLTypes = Statusvs
                });
            }
            return ViewList;
        }

        public DataTable GetBOLSearchValus(MYBOL Data)
        {
            string strWhere = "";
            string _Query = "  select ID,BkgId,BLNumber,Status,BookingNo,RRNo,BkgParty,ShipmentType,POL,POD,BLTypes from(" +
                            " Select case when NVO_BOL.ID is null  then 0 else NVO_BOL.ID end as ID,NVO_Booking.Id as BkgID,case when NVO_BOL.ID is null  then BookingNo else NVO_BOL.BLNumber end as BLNumber,case when isnull(NVO_BOL.Status,0)= 0 then 'DRAFT'  when NVO_BOL.Status = 2 then 'CONFIRMED' when BkgStatus = 3 then 'CANCELLED'  end as Status , BookingNo,RRNo,BkgParty,ShipmentType,POL,POD," +
                            "  (select top(1) GeneralName from NVO_GeneralMaster where Id = BLTypes) as BLTypes from NVO_Booking left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where BkgStatus=2 ";

            if (Data.BookingNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and BookingNo like '%" + Data.BookingNo + "%'";
                else
                    strWhere += " and BookingNo like '%" + Data.BookingNo + "%'";

            if (Data.RRNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and RRNO like '%" + Data.RRNo + "%'";
                else
                    strWhere += " and RRNO like '%" + Data.RRNo + "%'";

            if (Data.BkgParty != "" && Data.BkgParty != "0" && Data.BkgParty != null && Data.BkgParty != "?")
                if (strWhere == "")
                    strWhere += _Query + " and BkgPartyID = " + Data.BkgParty;
                else
                    strWhere += " and BkgPartyID = " + Data.BkgParty;

            if (Data.POL != "" && Data.POL != "0" && Data.POL != null && Data.POL != "?")
                if (strWhere == "")
                    strWhere += _Query + " and NVO_Booking.POLID= " + Data.POL;
                else
                    strWhere += " and NVO_Booking.POLID= " + Data.POL;

            if (Data.POD != "" && Data.POD != "0" && Data.POD != null && Data.POD != "?")
                if (strWhere == "")
                    strWhere += _Query + " and NVO_Booking.PODID= " + Data.POD;
                else
                    strWhere += " and NVO_Booking.PODID= " + Data.POD;

            if (Data.AgentId != "" && Data.AgentId != "0" && Data.AgentId != "2" && Data.AgentId != "undefined" && Data.AgentId != null)

                if (strWhere == "")
                    strWhere += _Query + " and NVO_Booking.AgentID = " + Data.AgentId;
                else
                    strWhere += " and NVO_Booking.AgentID = " + Data.AgentId;

            if (strWhere == "")
                strWhere = _Query;

            strWhere += " Union  " +
                        " Select case when NVO_BOL.ID is null  then 0 else NVO_BOL.ID end as ID,NVO_Booking.Id as BkgID,case when NVO_BOL.ID is null  then BookingNo else NVO_BOL.BLNumber end as BLNumber,case when isnull(NVO_BOL.Status,0)= 0 then 'DRAFT'  when NVO_BOL.Status = 2 then 'CONFIRMED' when BkgStatus = 3 then 'CANCELLED'  end as Status , BookingNo,RRNo,BkgParty,ShipmentType,POL,POD," +
                        " (select top(1) GeneralName from NVO_GeneralMaster where Id = BLTypes) as BLTypes from NVO_Booking inner join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where NVO_BOL.Status = 2 " +
                        " and NVO_BOL.ID in (select BLID from NVO_RRBLAccessTable where AgencyID= " + Data.AgentId + ")) t order by Status desc,BkgID desc";

            return GetViewData(strWhere, "");
        }

        public List<MYBOL> BOLExistingViewValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLExistingSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),

                    POOID = dt.Rows[i]["POOID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),


                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    ServiceType = dt.Rows[i]["ServiceType"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),

                    DesAgentID = Int32.Parse(dt.Rows[i]["DesAgentID"].ToString()),
                    NoofOriginal = Int32.Parse(dt.Rows[i]["NoofOriginal"].ToString()),
                    SurrenderStatus = Int32.Parse(dt.Rows[i]["SurrenderStatus"].ToString()),
                    MarkNo = dt.Rows[i]["MarkNo"].ToString(),
                    CagoDescription = dt.Rows[i]["CagoDescription"].ToString(),
                    BLTypes = dt.Rows[i]["BLTypes"].ToString(),
                    MotherBL = dt.Rows[i]["MotherBL"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    FreightPaymentID = dt.Rows[i]["FreightPaymentID"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ShipmentTypeID = dt.Rows[i]["ShipmentTypeID"].ToString(),
                    ReasonDescription = dt.Rows[i]["ReasonDescription"].ToString(),
                    CargoReleaseStatus = dt.Rows[i]["CargoReleaseStatus"].ToString(),
                    BLLockStatus = dt.Rows[i]["BLLockStatus"].ToString(),
                    CommodityTypeID = dt.Rows[i]["BLCommodityTypeID"].ToString(),
                    VesVoyID = dt.Rows[i]["BLVesVoyID"].ToString(),
                    BkgPartyID = dt.Rows[i]["BLBkgPartyID"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLExistingSearchValus(MYBOL Data)
        {
            string _Query = " Select NVO_BOL.Id,BLNumber,BLBkgPartyID," +
                            " Case when IsBLLocked=1 Then 'LOCKED' Else 'UNLOCK' end as BLLockStatus, NVO_Booking.Id as BkgId,BookingNo,RRNo,BkgParty,POO,POL,POD,FPOD,NVO_BOL.POOID,NVO_BOL.POLID,NVO_BOL.PODID,NVO_BOL.FPODID,ShipmentType,ServiceType,SalesPerson,VesVoy,'20' + ' x ' + convert(varchar, CTQ20) + ',' + '40' + ' x ' + convert(varchar, CTQ40) as CntrCount, " +
                            " DesAgentID,NoofOriginal,SurrenderStatus,MarkNo,CagoDescription,BLTypes,MotherBL,FreeDays,FreightPaymentID,NVO_BOL.Remarks,case when Status= 2 then 'CONFIRMED' else 'DRAFT' end AS Status,NVO_BOL.ShipmentTypeID,ReasonDescription,CargoReleaseStatus,BLCommodityTypeID,BLVesVoyID " +
                            " from NVO_BOL inner join NVO_Booking on NVO_Booking.Id = NVO_BOL.BkgId " +
                            " where NVO_BOL.ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BOLCustomerExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLCustomerExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    BCID = Int32.Parse(dt.Rows[i]["BCID"].ToString()),
                    PartyTypeID = Int32.Parse(dt.Rows[i]["PartyTypeID"].ToString()),
                    PartyID = Int32.Parse(dt.Rows[i]["PartID"].ToString()),
                    Address = dt.Rows[i]["PartyAddress"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLCustomerExistingValus(MYBOL Data)
        {
            string _Query = "select * from NVO_BOLCustomerDetails where BLID= " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> BOLCntrExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLCntrExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    BCNID = Int32.Parse(dt.Rows[i]["BCNID"].ToString()),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    PakgType = dt.Rows[i]["PakgType"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    NtWt = dt.Rows[i]["NtWt"].ToString(),
                    VGM = dt.Rows[i]["VGM"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString()



                });
            }
            return ViewList;
        }

        public DataTable GetBOLCntrExistingValus(MYBOL Data)
        {
            //string _Query = "select * from NVO_BOLCntrDetails where BLID= " + Data.ID;
            //string _Query = " select 0 as BCNID,CntrID,CntrType,(select top(1) ISOCode  from NVO_tblCntrTypes where ID = CntrType) as ISOCode, " +
            //                " (select top(1) Size  from NVO_tblCntrTypes where ID = CntrType) as Size, " +
            //                " (select top(1) SealNo from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as SealNo, " +
            //                " (select top(1) NoOfPkg from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as NoOfPkg, " +
            //                " (select top(1) PakgType from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as PakgType, " +
            //                " (select top(1) PakgTypeName from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as PakgTypeName, " +
            //                " (select top(1) GrsWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as GrsWt, " +
            //                " (select top(1) NtWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as NtWt, " +
            //                " (select top(1) VGM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as VGM, " +
            //                " (select top(1) CBM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_BOLCntrPickup.BkgId) as CBM " +
            //                " from NVO_BOLCntrPickup where BkgID = " + Data.BkgID;

            string _Query = "  select distinct 0 as BCNID,NVO_Containers.Id as CntrID,TypeID,(select top(1) ISOCode  from NVO_tblCntrTypes where ID = TypeID) as ISOCode, " +
                            " (select top(1) Size  from NVO_tblCntrTypes where ID = TypeID) as Size, " +
                            " (select top(1) SealNo from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as SealNo, " +
                            " (select top(1) NoOfPkg from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as NoOfPkg,  " +
                            " (select top(1) PakgType from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as PakgType, " +
                            " (select top(1) PakgTypeName from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as PakgTypeName, " +
                            " (select top(1) GrsWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as GrsWt," +
                            " (select top(1) NtWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as NtWt,  " +
                            " (select top(1) VGM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as VGM, " +
                            " (select top(1) CBM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as CBM " +
                            " from NVO_ContainerTxns " +
                            " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
                            " where BLNumber = " + Data.BkgID;

            return GetViewData(_Query, "");
        }

        public List<MYBLRelease> BLReleaseExisCheckValus(MYBLRelease Data)
        {
            List<MYBLRelease> ViewList = new List<MYBLRelease>();
            DataTable dt = GetBLReleaseExistingCheckValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBLRelease
                {
                    BLID = dt.Rows[i]["BLID"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBLReleaseExistingCheckValus(MYBLRelease Data)
        {
            string _Query = " SELECT BLID FROM NVO_BLRelease  where BLID = " + Data.BLID;

            return GetViewData(_Query, "");
        }

        public List<MYBLRelease> BLReleaseExistingViewValus(MYBLRelease Data)
        {
            List<MYBLRelease> ViewList = new List<MYBLRelease>();
            DataTable dt = GetBLReleaseExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBLRelease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    ShiperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    ShiperContactNo = dt.Rows[i]["ShipperTelNo"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeEmail = dt.Rows[i]["ConsigneeEmail"].ToString(),
                    ConsigneeContactNo = dt.Rows[i]["ConsigneeTelNo"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify1 = dt.Rows[i]["Notify1"].ToString(),
                    Notify1Email = dt.Rows[i]["Notify1Email"].ToString(),
                    Notify1ContactNo = dt.Rows[i]["Notify1TelNo"].ToString(),
                    Notify1Address = dt.Rows[i]["Notify1Address"].ToString(),
                    Notify2 = dt.Rows[i]["Notify2"].ToString(),

                    Notify2Email = dt.Rows[i]["Notify2Email"].ToString(),
                    Notify2ContactNo = dt.Rows[i]["Notify2TelNo"].ToString(),

                    Notify2Address = dt.Rows[i]["Notify2Address"].ToString(),
                    Agent = dt.Rows[i]["DesignationAgent"].ToString(),
                    AgentAddress = dt.Rows[i]["DesignationAgentAddress"].ToString(),
                    GrsWt = dt.Rows[i]["GRWT"].ToString(),
                    NtWt = dt.Rows[i]["NTWT"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    Packages = dt.Rows[i]["PakgType"].ToString(),
                    Marks = dt.Rows[i]["MarkNo"].ToString(),
                    Description = dt.Rows[i]["CagoDescription"].ToString(),
                    FreightPayment = dt.Rows[i]["FreightPayment"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLStatus = dt.Rows[i]["Status"].ToString()

                });
            }
            return ViewList;
        }



        public DataTable GetBLReleaseExistingValus(MYBLRelease Data)
        {
            string _Query = " Select NVO_BOL.Id,BLNumber,NVO_Booking.Id as BkgId,BookingNo,RRNo,BkgParty,(select top(1) CityName from NVO_CityMaster where ID =NVO_BOL.POOID) as POO,POL,POD,(select top(1) CityName from NVO_CityMaster where ID =NVO_BOL.FPODID) as FPOD,ShipmentType,ServiceType,SalesPerson,VesVoyID, " +
                            " VesVoy,'20' + ' x ' + convert(varchar, CTQ20) + ',' + '40' + ' x ' + convert(varchar, CTQ40) as CntrCount, " +
                            " DesAgentID,NoofOriginal,SurrenderStatus,MarkNo,CagoDescription,BLTypes,MotherBL,FreeDays,FreightPaymentID,NVO_BOL.Remarks, " +
                            " (select sum(Grswt) from NVO_BOLCntrDetails Cd where Cd.BLID = NVO_BOL.Id AND Cd.BkgId = NVO_BOL.BkgID) as GRWT, " +
                            " (select sum(NtWt) from NVO_BOLCntrDetails Cd where Cd.BLID = NVO_BOL.Id  AND Cd.BkgId = NVO_BOL.BkgID) as NTWT, " +
                            " (select sum(CBM) from NVO_BOLCntrDetails Cd where Cd.BLID = NVO_BOL.Id  AND Cd.BkgId = NVO_BOL.BkgID) as CBM, " +
                            " (select sum(NoOfPkg) from NVO_BOLCntrDetails Cd where CD.BLID = NVO_BOL.Id  AND Cd.BkgId = NVO_BOL.BkgID) as PakgType, " +
                            " (select (select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_BOLCustomerDetails where  PartyTypeID= 1 and BLId =NVO_BOL.Id) as Shipper, " +
                            " (select (select top(1) EmailID from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where  PartyTypeID= 1 and BLId =NVO_BOL.Id) as ShipperEmail,  " +
                            " (select(select top(1) TelNo from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where PartyTypeID = 1 and BLId = NVO_BOL.Id) as ShipperTelNo, " +
                            " (select top(1) PartyAddress from NVO_BOLCustomerDetails BC where PartyTypeID = 1 and BC.BLID = NVO_BOL.Id  AND BC.BkgId = NVO_BOL.BkgID) as ShipperAddress, " +
                            " (select (select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_BOLCustomerDetails where  PartyTypeID= 2 and BLId =NVO_BOL.Id) as Consignee, " +
                            " (select(select top(1) EmailID from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where PartyTypeID = 2 and BLId = NVO_BOL.Id) as ConsigneeEmail,  " +
                            " (select(select top(1) TelNo from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where PartyTypeID = 2 and BLId = NVO_BOL.Id) as ConsigneeTelNo,  " +
                            " (select top(1) PartyAddress from NVO_BOLCustomerDetails BC where PartyTypeID = 2 and BC.BLID = NVO_BOL.Id  AND BC.BkgId = NVO_BOL.BkgID) as ConsigneeAddress, " +
                            " (select (select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_BOLCustomerDetails where  PartyTypeID= 3 and BLId =NVO_BOL.Id) as Notify1, " +
                            " (select (select top(1) EmailID from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where  PartyTypeID= 3 and BLId =NVO_BOL.Id) as Notify1Email, " +
                            " (select(select top(1) TelNo from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where PartyTypeID = 3 and BLId = NVO_BOL.Id) as Notify1TelNo, " +
                            " (select top(1) PartyAddress from NVO_BOLCustomerDetails BC where PartyTypeID = 3 and BC.BLID = NVO_BOL.Id  AND BC.BkgId = NVO_BOL.BkgID) as Notify1Address, " +
                            " (select (select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_BOLCustomerDetails where  PartyTypeID= 12 and BLId =NVO_BOL.Id) as Notify2, " +
                            " (select(select top(1) EmailID from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where PartyTypeID = 12 and BLId = NVO_BOL.Id) as Notify2Email, " +
                            " (select(select top(1) TelNo from NVO_CusBranchLocation where CustomerID = PartID) from NVO_BOLCustomerDetails where PartyTypeID = 12 and BLId = NVO_BOL.Id) as Notify2TelNo, " +
                            " (select top(1) PartyAddress from NVO_BOLCustomerDetails BC where PartyTypeID = 12 and BC.BLID = NVO_BOL.Id  AND BC.BkgId = NVO_BOL.BkgID) as Notify2Address, " +
                            " (select top(1) AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.Id = DesAgentID) as DesignationAgent, " +
                            " (select top(1) Address from NVO_AgencyMaster where NVO_AgencyMaster.Id = DesAgentID) as DesignationAgentAddress, " +
                            " (select top(1) GeneralName  from NVO_GeneralMaster where Id = FreightPaymentID) as FreightPayment,case when Status=2 then 'CONFIRM' else 'DRAFT' end as Status " +
                            " from NVO_BOL inner join NVO_Booking on NVO_Booking.Id = NVO_BOL.BkgId where NVO_BOL.ID=" + Data.BLID;

            return GetViewData(_Query, "");
        }



        public List<MYBLRelease> BLReleaseCntrExistingViewValus(MYBLRelease Data)
        {
            var CntrDetailsv = "";
            List<MYBLRelease> ViewList = new List<MYBLRelease>();
            DataTable dt = GetBLReleaseCntrExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrDetailsv += dt.Rows[i]["CntrNo"].ToString() + "/" + dt.Rows[i]["Size"].ToString() + "/" + dt.Rows[i]["SealNo"].ToString() + "/" + dt.Rows[i]["NoOfPkg"].ToString() + "/" + dt.Rows[i]["PackageType"].ToString() + "/" + dt.Rows[i]["GrsWt"].ToString() + "/" + dt.Rows[i]["NtWt"].ToString() + "/" + dt.Rows[i]["CBM"].ToString() + "\n";


            }
            ViewList.Add(new MYBLRelease
            {
                CntrDetails = CntrDetailsv
            });
            return ViewList;
        }


        public DataTable GetBLReleaseCntrExistingValus(MYBLRelease Data)
        {
            string _Query = " Select(select top(1) CntrNo from NVO_Containers where ID = CntrID) as CntrNo,Size,SealNo,NoOfPkg, " +
                            " (select top(1) PkgCode from NVO_CargoPkgMaster where Id = PakgType) as PackageType,GrsWt,NtWt,CBM from NVO_BOLCntrDetails " +
                            " where BLID=" + Data.BLID;

            return GetViewData(_Query, "");
        }



        public List<MYBLRelease> BLReleaseFinalExistingViewValus(MYBLRelease Data)
        {
            List<MYBLRelease> ViewList = new List<MYBLRelease>();
            DataTable dt = GetBLReleaseFinalExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBLRelease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify1 = dt.Rows[i]["Notify1"].ToString(),
                    Notify1Address = dt.Rows[i]["Notify1Address"].ToString(),
                    Notify2 = dt.Rows[i]["Notify2"].ToString(),
                    Notify2Address = dt.Rows[i]["Notify2Address"].ToString(),
                    Agent = dt.Rows[i]["Agent"].ToString(),
                    AgentAddress = dt.Rows[i]["AgentAddress"].ToString(),
                    GrsWt = dt.Rows[i]["GRWT"].ToString(),
                    NtWt = dt.Rows[i]["NTWT"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    Packages = dt.Rows[i]["Packages"].ToString(),
                    Marks = dt.Rows[i]["Marks"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    FreightPayment = dt.Rows[i]["FreightPayment"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    BLNumber = dt.Rows[i]["BLNo"].ToString(),
                    BLDate = dt.Rows[i]["BLDate"].ToString(),
                    SOBDate = dt.Rows[i]["SOBDate"].ToString(),
                    CntrDetails = dt.Rows[i]["CntrDetails"].ToString(),
                    IssuedAt = dt.Rows[i]["IssuedAt"].ToString(),
                    ShiperEmail = dt.Rows[i]["ShiperEmail"].ToString(),
                    ShiperContactNo = dt.Rows[i]["ShiperContactNo"].ToString(),
                    ConsigneeEmail = dt.Rows[i]["ConsigneeEmail"].ToString(),
                    ConsigneeContactNo = dt.Rows[i]["ConsigneeContactNo"].ToString(),
                    Notify1Email = dt.Rows[i]["Notify1Email"].ToString(),
                    Notify1ContactNo = dt.Rows[i]["Notify1ContactNo"].ToString(),
                    Notify2Email = dt.Rows[i]["Notify2Email"].ToString(),
                    Notify2ContactNo = dt.Rows[i]["Notify2ContactNo"].ToString(),
                    AgentEmail = dt.Rows[i]["AgentEmail"].ToString(),
                    AgentContactNo = dt.Rows[i]["AgentContactNo"].ToString(),
                    BLLayout = dt.Rows[i]["BLLayout"].ToString(),




                });
            }
            return ViewList;
        }

        public DataTable GetBLReleaseFinalExistingValus(MYBLRelease Data)
        {
            string _Query = " SELECT NVO_BLRelease.ID,BkgID,BLNo,VesVoy,convert(varchar, BLDate, 23) as BLDate,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify1,Notify1Address,Notify2,Notify2Address,Agent,AgentAddress,POO,POL,POD,FPOD, " +
                            " GRWT,NTWT,CBM,Packages,Description,Marks,CntrDetails,FreightPayment,FreeDays, FORMAT(SOBDate, 'yyyy-MM-ddTHH:mm:ss') as SOBDate,IssuedAt,BLLayout,CurrentDate,BLStatus, " +
                            " shiperEmail,ShiperContactNo,ConsigneeEmail,ConsigneeContactNo,Notify1Email,Notify1ContactNo,Notify2Email,Notify2ContactNo,AgentEmail,AgentContactNo, " +
                            " (select case when Status=2 then 'CONFIRM' else 'DRAFT' end as Status  from NVO_BOL where NVO_BOL.Id = NVO_BLRelease.BLID) as Status,BLLayout " +
                            " FROM NVO_BLRelease where BLID = " + Data.BLID;

            return GetViewData(_Query, "");
        }

        public List<MYBLRelease> BLReleaseSOBDateCheckViewValus(MYBLRelease Data)
        {
            List<MYBLRelease> ViewList = new List<MYBLRelease>();
            DataTable dt = GetBLReleaseFinalExistingValus(Data);
            if (dt.Rows.Count > 0)
            {
                ViewList.Add(new MYBLRelease
                {
                    Message = "Success"
                });
            }
            else
            {

                ViewList.Add(new MYBLRelease
                {
                    Message = "Failed"
                });
            }
            return ViewList;
        }

        public DataTable GetBLReleaseSOBDatevalue(MYBLRelease Data)
        {
            string _Query = " select ID FROM NVO_BLRelease where BLID = " + Data.BLID;

            return GetViewData(_Query, "");
        }

        public List<MYBLRelease> BLReleaseInsert(MYBLRelease Data)
        {

            int result = 0;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_BLRelease where BLID=@BLID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_BLRelease(BLNo,VesVoy,BLDate,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify1,Notify1Address,Notify2,Notify2Address,Agent,AgentAddress,POO,POL,POD,FPOD,GRWT,NTWT,CBM," +
                                 " Packages,Description,Marks,CntrDetails,FreightPayment,FreeDays,SOBDate,IssuedAt,BLLayout,CurrentDate,BLStatus,BkgId,BLID,shiperEmail,ShiperContactNo,ConsigneeEmail,ConsigneeContactNo,Notify1Email,Notify1ContactNo,Notify2Email,Notify2ContactNo,AgentEmail,AgentContactNo) " +
                                 " values (@BLNo,@VesVoy,@BLDate,@Shipper,@ShipperAddress,@Consignee,@ConsigneeAddress,@Notify1,@Notify1Address,@Notify2,@Notify2Address,@Agent,@AgentAddress,@POO,@POL,@POD,@FPOD,@GRWT,@NTWT,@CBM," +
                                 " @Packages,@Description,@Marks,@CntrDetails,@FreightPayment,@FreeDays,@SOBDate,@IssuedAt,@BLLayout,@CurrentDate,@BLStatus,@BkgId,@BLID,@shiperEmail,@ShiperContactNo,@ConsigneeEmail,@ConsigneeContactNo,@Notify1Email,@Notify1ContactNo,@Notify2Email,@Notify2ContactNo,@AgentEmail,@AgentContactNo) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_BLRelease SET BLNo=@BLNo,VesVoy=@VesVoy,BLDate=@BLDate,Shipper=@Shipper,ShipperAddress=@ShipperAddress,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,Notify1=@Notify1,Notify1Address=@Notify1Address," +
                                 " Notify2=@Notify2,Notify2Address=@Notify2Address,Agent=@Agent,AgentAddress=@AgentAddress,POO=@POO,POL=@POL,POD=@POD,FPOD=@FPOD,GRWT=@GRWT,NTWT=@NTWT,CBM=@CBM," +
                                 " Packages=@Packages,Description=@Description,Marks=@Marks,CntrDetails=@CntrDetails,FreightPayment=@FreightPayment,FreeDays=@FreeDays,SOBDate=@SOBDate,IssuedAt=@IssuedAt,BLLayout=@BLLayout,CurrentDate=@CurrentDate," +
                                 " BLStatus=@BLStatus,BkgId=@BkgId,BLID=@BLID,shiperEmail=@shiperEmail,ShiperContactNo=@ShiperContactNo,ConsigneeEmail=@ConsigneeEmail,ConsigneeContactNo=@ConsigneeContactNo,Notify1Email=@Notify1Email,Notify1ContactNo=@Notify1ContactNo,Notify2Email=@Notify2Email,Notify2ContactNo=@Notify2ContactNo,AgentEmail=@AgentEmail,AgentContactNo=@AgentContactNo where BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNo", Data.BLNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDate", Data.BLDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.Shipper));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", Data.Consignee));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1", Data.Notify1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1Address", Data.Notify1Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2", Data.Notify2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Address", Data.Notify2Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Agent", Data.Agent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentAddress", Data.AgentAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POO", Data.POO));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", Data.POL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", Data.POD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPOD", Data.FPOD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GRWT", Data.GrsWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NTWT", Data.NtWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", Data.CBM));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Packages", Data.Packages));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Marks", Data.Marks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrDetails", Data.CntrDetails));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPayment", Data.FreightPayment));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", Data.FreeDays));
                    if (Data.SOBDate != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SOBDate", DateTime.Parse(Data.SOBDate).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SOBDate", DBNull.Value));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IssuedAt", Data.IssuedAt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLLayout", Data.BLLayout));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@shiperEmail", Data.ShiperEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShiperContactNo", Data.ShiperContactNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeEmail", Data.ConsigneeEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeContactNo", Data.ConsigneeContactNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1Email", Data.Notify1Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1ContactNo", Data.Notify1ContactNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Email", Data.Notify2Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2ContactNo", Data.Notify2ContactNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentEmail", Data.AgentEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentContactNo", Data.AgentContactNo));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_BLRelease')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;



                    trans.Commit();
                    MyBLRList.Add(new MYBLRelease { ID = Data.ID });
                    return MyBLRList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBLRList;
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



        public List<MYBOL> BOLVesselVoyageValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetVesselVoyageValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {

                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetVesselVoyageValus(MYBOL Data)
        {
            string _Query = " select distinct (select top(1)PortID from NVO_VoyageRoute VR where VR.VoyageID=NVO_VoyageRoute.VoyageID order by Vr.RID asc)as CurrentPortID, " +
          " (select top(1)PortID from NVO_VoyageRoute VR where VR.VoyageID = NVO_VoyageRoute.VoyageID order by Vr.RID desc) as NextPortID, " +
         " convert(varchar, (select top(1)ETD from NVO_VoyageRoute VR where VR.VoyageID = NVO_VoyageRoute.VoyageID order by Vr.RID asc),103)as ETD, " +
         " convert(varchar, (select top(1)ETA from NVO_VoyageRoute VR where VR.VoyageID = NVO_VoyageRoute.VoyageID order by Vr.RID desc),103)as ETA from NVO_VoyageRoute where VoyageID = " + Data.VesVoyID;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BkgBOLVesselVoyageValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBkgVesselVoyageValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    VesVoyID = dt.Rows[i]["ID"].ToString(),
                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetBkgVesselVoyageValus(MYBOL Data)
        {
            string _Query = " select NVO_VoyageDetails.ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID) + ' -' + VoyageNo as VesVoy, " +
                            " CurrentPortID,(select top(1) NextPortID from NVO_VoyPortDtls where VoydtID = NVO_VoyageDetails.Id) as NextPortID, " +
                            " convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD " +
                            " from NVO_VoyageDetails " +
                            " inner join NVO_Booking on NVO_Booking.VesVoyID = NVO_VoyageDetails.Id where NVO_Booking.Id = " + Data.BkgID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> BkgVoyagedtlsExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBkgVoyageDtlsValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    // VID = dt.Rows[i]["VID"].ToString(),
                    VoyageTypes = dt.Rows[i]["GeneralLeg"].ToString(),
                    LegInformation = dt.Rows[i]["Leg"].ToString(),
                    VesVoyID = dt.Rows[i]["ID"].ToString(),
                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBkgVoyageDtlsValus(MYBOL Data)
        {
            //string _Query = " select NVO_VoyageDetails.ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID) + ' -' + VoyageNo as VesVoy,  " +
            //                " CurrentPortID,(select top(1) NextPortID from NVO_VoyPortDtls where VoydtID = NVO_VoyageDetails.Id) as NextPortID, " +
            //                " convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD,(select count(ID) from NVO_BkgTranshipmentPort where BkgID = NVO_Booking.ID) as CoutTrans,  " +
            //                " case when(select count(ID) from NVO_BkgTranshipmentPort where BkgID = NVO_Booking.ID) > 0 then 78 else 77 end as GeneralLeg,74 as Leg " +
            //                " from NVO_VoyageDetails " +
            //                " inner join NVO_Booking on NVO_Booking.VesVoyID = NVO_VoyageDetails.ID " +
            //                " where NVO_Booking.ID = " + Data.BkgID;

            string _Query = " select NVO_Voyage.ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) + ' -' +  (select top(1) ExportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID) as VesVoy,  " +
                            " (select top(1) PortID from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID order by RID asc) as CurrentPortID, " +
                            " (select top(1) PortID from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID order by RID desc) as NextPortID, " +
                            " (select top(1) convert(varchar, ETA, 103) from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID order by RID asc) as ETA, " +
                            " (select top(1) convert(varchar, ETD, 103) from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID order by RID desc) as ETD, " +
                            " (select count(ID) from NVO_BkgTranshipmentPort where BkgID = NVO_Booking.ID) as CoutTrans, " +
                            " case when TSPORTID = 0  then(select ID from NVO_GeneralMaster where SeqNo = 27  and ID in (77)) else (select ID from NVO_GeneralMaster where SeqNo = 27  and ID in (78)) end as GeneralLeg, 74 as Leg " +
                            " from NVO_Voyage " +
                            " inner join NVO_Booking on NVO_Booking.VesVoyID = NVO_Voyage.ID  where NVO_Booking.ID = " + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BOLVoyagedtlsExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLVoyageDtlsValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    VID = dt.Rows[i]["VID"].ToString(),
                    VoyageTypes = dt.Rows[i]["VoyageTypes"].ToString(),
                    LegInformation = dt.Rows[i]["LegInformation"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    CurPortID = dt.Rows[i]["LoadPort"].ToString(),
                    NextPortID = dt.Rows[i]["NextPort"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLVoyageDtlsValus(MYBOL Data)
        {
            string _Query = " select VID, VoyageTypes,LegInformation,VesVoyID,LoadPort,NextPort,convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD from NVO_BOLVoyageDetails where BLID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> BOLRRUpDate(MYBOL Data)
        {

            int result = 0;
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
                    Cmd.CommandText = "select RatesheetNo from NVO_Ratesheet  where ID = " + Data.RRID;
                    Data.RRNo = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "update NVO_Booking set RRID=@RRID,RRNo=@RRNo where Id=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRNo", Data.RRNo));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    MyBOLList.Add(new MYBOL { RRNo = Data.RRNo });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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


        public List<MYBOL> BOLStatusUpDate(MYBOL Data)
        {

            int result = 0;
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
                    if (Data.Status == "2")
                    {
                        DataTable _dt = GetCheckKyCForm(Data);
                        if (_dt.Rows.Count > 0)
                        {
                            if(_dt.Rows[0]["ParaMeterBLKYC"].ToString() == "Y")
                            {
                                if(_dt.Rows[0]["AttachedParty"].ToString() == "KYC" && _dt.Rows[0]["AttachedShipper"].ToString() == "KYC")
                                {
                                    Cmd.CommandText = "update NVO_BOL set Status=@Status,ConfirmedBy=@ConfirmedBy,ConfirmedOn=@ConfirmedOn where ID=@ID";
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedBy", Data.UserID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedOn", System.DateTime.Now));
                                    result = Cmd.ExecuteNonQuery();
                                    Cmd.Parameters.Clear();
                                }
                                else
                                {
                                    MyBOLList.Add(new MYBOL { Alert = "0", Message = "KYC not Exist for Shipper or Booking party" });
                                    return MyBOLList;
                                }

                            }
                            else
                            {
                              

                                DataTable _GetRRID = GetRRNoInsertBLCharges(Data.BLID);
                                if (_GetRRID.Rows.Count > 0)
                                {
                                    Data.RRID = _GetRRID.Rows[0]["RRID"].ToString();
                                    Data.TsPortID = _GetRRID.Rows[0]["TsPortID"].ToString();
                                    Data.TranshipmetAgentID = _GetRRID.Rows[0]["TranshipmetAgentID"].ToString();
                                    DataTable _dtRR = GetRatesheetCharge(Data.RRID, "1");
                                    if (_dtRR.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < _dtRR.Rows.Count; y++)
                                        {

                                            Cmd.CommandText = " IF((select count(*) from NVO_BLCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID)<=0) " +
                                                         " BEGIN " +
                                                         " INSERT INTO  NVO_BLCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                                         " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                                         " END  " +
                                                         " ELSE " +
                                                         " UPDATE NVO_BLCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                                         " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID,BLID=@BLID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID";
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", _dtRR.Rows[y]["CID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtRR.Rows[y]["TariffTypeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtRR.Rows[y]["CntrType"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtRR.Rows[y]["ChargeCodeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtRR.Rows[y]["CurrencyID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtRR.Rows[y]["PaymentModeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtRR.Rows[y]["ReqRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtRR.Rows[y]["ManifRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtRR.Rows[y]["CustomerRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtRR.Rows[y]["RateDiff"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtRR.Rows[y]["TariffID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                            result = Cmd.ExecuteNonQuery();
                                            Cmd.Parameters.Clear();
                                        }
                                    }

                                    DataTable _dtRR1 = GetRatesheetCharge(Data.RRID.ToString(), "2");
                                    if (_dtRR1.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < _dtRR1.Rows.Count; y++)
                                        {


                                            Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID)<=0) " +
                                                         " BEGIN " +
                                                         " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                                         " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                                         " END  " +
                                                         " ELSE " +
                                                         " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                                         " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID,BLID=@BLID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID";
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", _dtRR1.Rows[y]["CID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtRR1.Rows[y]["TariffTypeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtRR1.Rows[y]["CntrType"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtRR1.Rows[y]["ChargeCodeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtRR1.Rows[y]["CurrencyID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtRR1.Rows[y]["PaymentModeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtRR1.Rows[y]["ReqRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtRR1.Rows[y]["ManifRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtRR1.Rows[y]["CustomerRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtRR1.Rows[y]["RateDiff"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtRR1.Rows[y]["TariffID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                            result = Cmd.ExecuteNonQuery();
                                            Cmd.Parameters.Clear();
                                        }
                                    }
                                    //trans.Commit();


                                    DataTable dtST = GetSlatCost(Data.BkgID.ToString());
                                    if (dtST.Rows.Count > 0)
                                    {
                                        for (int s = 0; s < dtST.Rows.Count; s++)
                                        {
                                            Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID)<=0) " +
                                                        " BEGIN " +
                                                        " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                                        " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                                        " END  " +
                                                        " ELSE " +
                                                        " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                                        " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID";
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", dtST.Rows[s]["RCID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 108));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", dtST.Rows[s]["CntrType"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", dtST.Rows[s]["ChargeCodeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", dtST.Rows[s]["CurrencyID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", dtST.Rows[s]["PaymentModeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", dtST.Rows[s]["ReqRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", dtST.Rows[s]["ManifRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", dtST.Rows[s]["CustomerRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                            result = Cmd.ExecuteNonQuery();
                                            Cmd.Parameters.Clear();
                                        }
                                    }


                                    DataTable GetTS = GetTSCost(Data.BkgID.ToString(), Data.TsPortID);
                                    if (GetTS.Rows.Count > 0)
                                    {
                                        for (int y = 0; y < dtST.Rows.Count; y++)
                                        {
                                            Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID)<=0) " +
                                                        " BEGIN " +
                                                        " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                                        " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                                        " END  " +
                                                        " ELSE " +
                                                        " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                                        " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where RRID=@RRID and RTID=@RTID and BkgID=@BkgID and BLID=@BLID";
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", GetTS.Rows[y]["RCID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 0));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", GetTS.Rows[y]["CntrType"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", GetTS.Rows[y]["ChargeCodeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", GetTS.Rows[y]["CurrencyID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", GetTS.Rows[y]["PaymentModeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", GetTS.Rows[y]["ReqRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", GetTS.Rows[y]["ManifRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", GetTS.Rows[y]["CustomerRate"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", GetTS.Rows[y]["TariffTypeID"].ToString()));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                            result = Cmd.ExecuteNonQuery();
                                            Cmd.Parameters.Clear();
                                        }
                                    }

                                    DataTable _dtComm = GetEITCommision(Data.BkgID.ToString());
                                    if (_dtComm.Rows.Count > 0)
                                    {
                                        for (int m = 0; m < _dtComm.Rows.Count; m++)
                                        {
                                            if (_dtComm.Rows[m]["ChargeCodeID"].ToString() != "34")
                                            {
                                                Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where  ChargeCodeID=@ChargeCodeID and BkgID=@BkgID)<=0) " +
                                                            " BEGIN " +
                                                            " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                                                            " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                                                            " END  " +
                                                            " ELSE " +
                                                            " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                                            " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where ChargeCodeID=@ChargeCodeID and BkgID=@BkgID";
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", 0));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 0));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtComm.Rows[m]["CntrTypes"].ToString()));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtComm.Rows[m]["ChargeCodeID"].ToString()));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtComm.Rows[m]["CurrencyID"].ToString()));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", 19));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                                result = Cmd.ExecuteNonQuery();
                                                Cmd.Parameters.Clear();
                                            }
                                            else
                                            {
                                                if (Data.TranshipmetAgentID != "0")
                                                {
                                                    Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where  ChargeCodeID=@ChargeCodeID and BkgID=@BkgID, and BLID=@BLID)<=0) " +
                                                               " BEGIN " +
                                                               " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                                               " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                                               " END  " +
                                                               " ELSE " +
                                                               " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                                               " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID,BLID=@BLID where ChargeCodeID=@ChargeCodeID and BkgID=@BkgID and BLID=@BLID";
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", 0));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 0));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtComm.Rows[m]["CntrTypes"].ToString()));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtComm.Rows[m]["ChargeCodeID"].ToString()));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtComm.Rows[m]["CurrencyID"].ToString()));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", 19));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtComm.Rows[m]["FixedRate"].ToString()));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                                    result = Cmd.ExecuteNonQuery();
                                                    Cmd.Parameters.Clear();
                                                }
                                            }

                                        }
                                    }


                                    Cmd.CommandText = "update NVO_BOL set Status=@Status,ConfirmedBy=@ConfirmedBy,ConfirmedOn=@ConfirmedOn where ID=@ID";
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedBy", Data.UserID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedOn", System.DateTime.Now));
                                    result = Cmd.ExecuteNonQuery();
                                    Cmd.Parameters.Clear();
                                    //end

                                }

                            }
                           
                        }

                        Data.Message = "BOL confirm as Sucessfully";
                    }
                    else if(Data.Status == "3")
                    {
                        DataTable dtx = GetCheckBLCancelled(Data.BLID);
                        if (dtx.Rows[0]["Typev"].ToString() == "0" || dtx.Rows[0]["Typev"].ToString() == "1")
                        {
                            Cmd.CommandText = "update NVO_BOL set Status=@Status,ConfirmedBy=@ConfirmedBy,ConfirmedOn=@ConfirmedOn where ID=@ID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedBy", Data.UserID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedOn", System.DateTime.Now));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                            Data.Message = "BOL Cancelled as Sucessfully";
                        }
                        else
                        {
                            Data.Message = "Alredy BL Printed done not Cancelled";
                        }
                    }
                    else if(Data.Status == "1")
                    {
                        Cmd.CommandText = "update NVO_BOL set Status=@Status,ConfirmedBy=@ConfirmedBy,ConfirmedOn=@ConfirmedOn where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedOn", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        Data.Message = "BOL Draft as Sucessfully";
                        
                    }

                    trans.Commit();
                    MyBOLList.Add(new MYBOL { RRNo = Data.RRNo, Alert = Data.Status, Message = Data.Message });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    MyBOLList.Add(new MYBOL { Alert = "0", Message = ex.Message});
                    return MyBOLList;
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

        public DataTable GetCheckBLCancelled(string BLID)
        {
            string _Query = "select count(Type) from NVO_BLPrintLog where Type = 1 and BLID=" + BLID;

            return GetViewData(_Query, "");
        }

        public DataTable GetRRNoInsertBLCharges(string BLID)
        {
            string _Query = " select(select top(1) RRID from NVO_Booking where NVO_Booking.Id = NVO_BOL.BkgID) as RRID,(select top(1) TsPortID from NVO_Booking where NVO_Booking.Id = NVO_BOL.BkgID) as TsPortID,(select top(1) TranshipmetAgentID from NVO_Booking where NVO_Booking.Id = NVO_BOL.BkgID) as TranshipmetAgentID from NVO_BOL where Id=" + BLID;
            return GetViewData(_Query, "");
        }

        public DataTable GetCheckKyCForm(MYBOL Data)
        {
            string _Query = " select BLBkgPartyID,(select top(1) PartID from NVO_BOLCustomerDetails where BLID=NVO_BOL.ID and PartyTypeID= 1) as ShiperID, " +
                            " (select top(1) AttachName from NVO_CusAttachments where CustomerID = BLBkgPartyID) as AttachedParty, " +
                            " (select top(1)(select top(1) AttachName from NVO_CusAttachments where NVO_CusAttachments.CustomerID = NVO_BOLCustomerDetails.PartID) " +
                            " from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 1) as AttachedShipper, " +
                            " (select top(1) Value from NVO_ControlParameter where  Parameter = 'BL_KYC' and AgencyID = " + Data.AgentId + ") as ParaMeterBLKYC " +
                            " from NVO_BOL where Id = " + Data.BLID;
                return GetViewData(_Query, "");
        }


        public List<MYBOL> BOLCountValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLCount(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {

                    Draft = dt.Rows[i]["Draft"].ToString(),
                    Cancelled = dt.Rows[i]["Cancel"].ToString(),
                    Confirm = dt.Rows[i]["Confirm"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLCount(MYBOL Data)
        {
            if (Data.AgentId.ToString() == "2")

            {
                string _Query = "  select(select Count(BkgStatus) from NVO_Booking  left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID  where BkgStatus = 3 and isnull(NVO_BOL.Status,0)= 3) as Cancel,(select Count(Status) from NVO_Booking left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where BkgStatus = 2 and NVO_BOL.Status = 2 ) as Confirm,(select Count(BkgStatus) from NVO_Booking left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where BkgStatus = 2 and isnull(NVO_BOL.Status,0)= 0) as Draft ";

                return GetViewData(_Query, "");

            }

            else

            {
                string _Query = "   select(select Count(BkgStatus) from NVO_Booking  left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID  where BkgStatus = 3  and AgentID = " + Data.AgentId + " and isnull(NVO_BOL.Status,0)= 3) as Cancel,(select Count(Status) from NVO_Booking left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where BkgStatus = 2 and NVO_BOL.Status = 2 and AgentID = " + Data.AgentId + ") as Confirm,(select Count(BkgStatus) from NVO_Booking left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where BkgStatus = 2 and AgentID = " + Data.AgentId + " and isnull(NVO_BOL.Status,0)= 0) as Draft";
                return GetViewData(_Query, "");

            }
        }

        public List<MYBOL> BLUnlock(MYBOL Data)
        {

            int result = 0;
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

                    Cmd.CommandText = "update NVO_BOL set IsBLLocked=@IsBLLocked where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBLLocked", Data.BLLockStatus));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    MyBOLList.Add(new MYBOL { BLLockStatus = Data.BLLockStatus });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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

        public List<MYBOL> RRUnLink(MYBOL Data)
        {

            DataTable dts = GetRRUnLinkecheckBLNo(Data.BkgID);
            if (dts.Rows.Count > 0)
            {
                MyBOLList.Add(new MYBOL { BLLockStatus = "BL Alredy Confirmed RR Unlink not Possible" });
                return MyBOLList;
            }
            else
            {
                int RRID = 0;
                string RRNo = "";
                DataTable _dtE = GetRRIDUnLinkecheckBLNo(Data.BkgID);
                if (_dtE.Rows.Count > 0)
                {
                    RRID = Int32.Parse(_dtE.Rows[0]["RRID"].ToString());
                    RRNo = _dtE.Rows[0]["RRNo"].ToString();
                }


                int result = 0;
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

                        Cmd.CommandText = "Update NVO_Booking set RRID =0,RRNo = 'UNLINKED'  where ID = " + Data.BkgID; ;
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        Cmd.CommandText = "delete from NVO_BLCharges where RRID = " + Data.RRID;
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();



                        trans.Commit();
                        MyBOLList.Add(new MYBOL { BLLockStatus = "RRNo " + RRNo + " UNLINKED SucessFully" });
                        return MyBOLList;

                    }
                    catch (Exception ex)
                    {
                        string ss = ex.ToString();
                        trans.Rollback();
                        return MyBOLList;
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



        }


        public DataTable GetRRUnLinkecheckBLNo(int BkgId)
        {
            string _Query = "select count(ID) from NVO_BOL where Status = 2 and  BkgID = " + BkgId;
            return GetViewData(_Query, "");
        }

        public DataTable GetRRIDUnLinkecheckBLNo(int BkgId)
        {
            string _Query = "select RRID from NVO_Booking where  ID = " + BkgId;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BLNoBind()
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBLNo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetBLNo()
        {
            string _Query = "select ID,BookingNo from NVO_Booking where BkgStatus= 2";
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BLNoAgentwiseBind(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBLAgentwise(Data.AgentId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString()
                });
            }
            return ViewList;
        }


        public DataTable GetBLAgentwise(string AgentID)
        {
            string _Query = "select ID,BookingNo from NVO_Booking where BkgStatus= 2 and DirectImport= 1 and AgentID=" + AgentID;
            return GetViewData(_Query, "");
        }

        #region SlotVesselVoyage

        public List<ChargeCorrector> ExportSlotOpVesselManeger(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetSlotOpVesselValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    BKgID = dt.Rows[i]["ID"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    SlotRefNo = dt.Rows[i]["SlotRefNo"].ToString(),
                    SlotOperatorID = dt.Rows[i]["SlotOperatorID"].ToString(),
                    SlotOperatorName = dt.Rows[i]["SlotOperatorName"].ToString(),
                    BkgStatus = dt.Rows[i]["BkgStatus"].ToString(),
                    FreightCharges = dt.Rows[i]["FreightCharges"].ToString(),
                    SlatCharges = dt.Rows[i]["SlatCharges"].ToString(),
                    SlotAmdAmt = dt.Rows[i]["SlotAmdAmt"].ToString(),


                });
            }
            return ViewList;
        }


        public DataTable GetSlotOpVesselValues(ChargeCorrector Data)
        {

            string _Query = " select NVO_Booking.ID,BookingNo,RRNo,RRID,POL,POD,VesVoy,(select top(1) SlotRef from NVO_SLOTMaster where ID =SlotContractID) as  " +
                            " SlotRefNo,SlotOperatorID,(select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperatorID) as SlotOperatorName, " +
                            " BkgStatus,(select sum(ManifRate) from NVO_RatesheetCharges where  TariffTypeID = 135 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) as FreightCharges," +
                            " (SlotAmt20+ SlotAmt40) as SlatCharges, (select top(1) SlotAmt  from NVO_SLOTCorrector where BkgID=NVO_Booking.ID) as SlotAmdAmt from NVO_Booking where ID = " + Data.BKgID;
            return GetViewData(_Query, "");
        }


        public List<ChargeCorrector> ExportSlotOpVesselManegerAmd(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetSlotOpVesselValuesAmd(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    BKgID = dt.Rows[i]["ID"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    SlotRefNo = dt.Rows[i]["SlotRefNo"].ToString(),
                    //SlotOperatorID = dt.Rows[i]["SlotOperatorID"].ToString(),
                    SlotOperatorName = dt.Rows[i]["SlotOperatorName"].ToString(),
                    //BkgStatus = dt.Rows[i]["BkgStatus"].ToString(),
                    FreightCharges = dt.Rows[i]["FreightCharges"].ToString(),
                    // SlatCharges = dt.Rows[i]["SlatCharges"].ToString(),
                    SlotAmdAmt = dt.Rows[i]["SlotAmdAmt"].ToString(),


                });
            }
            return ViewList;
        }

        public DataTable GetSlotOpVesselValuesAmd(ChargeCorrector Data)
        {

            string _Query = " select NVO_Booking.Id,BookingNo,RRNo,RRID,POL,POD, " +
                           " (select top(1)(select top(1) SlotRef from NVO_SLOTMaster where ID = NVO_SLOTCorrector.SlotID) from NVO_SLOTCorrector where BkgID = NVO_Booking.ID) as SlotRefNo,  " +
                           " (select top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_SLOTCorrector.SlotOperatorID) as SlotOperatorName, " +
                           " (Select top(1)(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID)  from NVO_Voyage V WHERE V.ID = NVO_SLOTCorrector.VesVoyID) as VesVoy,  " +
                           " (select sum(ManifRate) from NVO_RatesheetCharges where TariffTypeID = 135 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) as FreightCharges, " +
                           " SlotAmt as SlotAmdAmt " +
                           " from NVO_Booking  inner join NVO_SLOTCorrector on NVO_SLOTCorrector.BkgID=NVO_Booking.ID where NVO_SLOTCorrector.ID=" + Data.ID;


            return GetViewData(_Query, "");
        }


        public List<ChargeCorrector> ExportSlotOpVesselManegerAmdNew(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetSlotOpVesselValuesAmdNew(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    BKgID = dt.Rows[i]["ID"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    VesVoy = "",
                    SlotRefNo = "",
                    SlotOperatorName = "",
                    FreightCharges = dt.Rows[i]["FreightCharges"].ToString(),
                    SlotAmdAmt = "0.00"


                });
            }
            return ViewList;
        }

        public DataTable GetSlotOpVesselValuesAmdNew(ChargeCorrector Data)
        {

            string _Query = " select NVO_Booking.Id,BookingNo,RRNo,RRID,POL,POD, " +
                            " (select top(1)(select top(1) SlotRef from NVO_SLOTMaster where ID = NVO_SLOTCorrector.SlotID) from NVO_SLOTCorrector where BkgID = NVO_Booking.ID) as SlotRefNo," +
                            " (select top(1)(select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperatorID) from NVO_SLOTCorrector where BkgID = NVO_Booking.ID) as SlotOperatorName, " +
                            " (select top(1)(Select top(1) (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute " +
                            " where VoyageID = V.ID) " +
                            " from NVO_Voyage V WHERE V.ID = NVO_SLOTCorrector.VesVoyID) from NVO_SLOTCorrector where NVO_SLOTCorrector.BkgID = NVO_Booking.ID) as VesVoy, " +
                            " (select sum(ManifRate) from NVO_RatesheetCharges where TariffTypeID = 135 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) as FreightCharges, " +
                            " (select top(1) SlotAmt from NVO_SLOTCorrector where BkgID = NVO_Booking.ID) as SlotAmdAmt " +
                            " from NVO_Booking where ID =" + Data.BKgID;


            return GetViewData(_Query, "");
        }


        public List<ChargeCorrector> ExportSlotChargesChange(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetSlotRateValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    SlatCharges = dt.Rows[i]["SlatCharges"].ToString(),
                    SlotAmt20 = dt.Rows[i]["SlotAmt20"].ToString(),
                    SlotAmt40 = dt.Rows[i]["SlotAmt40"].ToString(),

                });
            }
            return ViewList;
        }


        public DataTable GetSlotRateValues(ChargeCorrector Data)
        {
            string _Query = " select sum(Amount) as SlatCharges,isnull((select  Amount from NVO_SLOTDDtls slv where slv.SID=NVO_SLOTDDtls.SID and SizeID= 1),0) as SlotAmt20," +
                " isnull((select  Amount from NVO_SLOTDDtls slv where slv.SID=NVO_SLOTDDtls.SID and SizeID in (2,3)),0) as SlotAmt40 " +
                " from NVO_SLOTDDtls  where SLID=" + Data.SlotID + "   and SizeID in ((select CntrTypes from NVO_BookingCntrTypes where BKgID= " + Data.BKgID + "))" +
                " and Commodity in ((select CommodityType from NVO_BookingCntrTypes where BKgID= " + Data.BKgID + ")) group by NVO_SLOTDDtls.SID";
            return GetViewData(_Query, "");
        }
        #endregion

        public List<ChargeCorrector> PrincipalChargeCorrectorMaster(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetPrincipalChargeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    RID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    PaymentMode = dt.Rows[i]["PaymentMode"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentModeID"].ToString(),
                    OwnershipID = dt.Rows[i]["OwnershipID"].ToString(),
                    BillAmount = dt.Rows[i]["BillAmount"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetPrincipalChargeValues(ChargeCorrector Data)
        {

            string _Query = " Select RTID as CID, NVO_BLCharges.RRID,(select top(1) size from NVO_tblCntrTypes where Id = CntrType) as CntrTypes,CntrType, " +
                            " (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType) as Qty, " +
                            " (select ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode,ChargeCodeID, " +
                            " (select OwnershipID from NVO_ChargeTB where ID = ChargeCodeID) as OwnershipID," +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID) as Currency,CurrencyID, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = PaymentModeID) as PaymentMode,PaymentModeID,ManifRate,CustomerRate, " +
                            " ((select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType) * (CustomerRate)) as BillAmount " +
                            " from NVO_BLCharges inner join NVO_Booking on NVO_Booking.ID = NVO_BLCharges.BkgID " +
                            " where NVO_Booking.ID=" + Data.BKgID;
            return GetViewData(_Query, "");
        }


        public List<ChargeCorrector> BLCorrectionExistingValues(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetBLCorrcetionExistingValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    CMID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectionNo"].ToString(),
                    BKgID = dt.Rows[i]["BLID"].ToString()

                });
            }
            return ViewList;
        }

        //public DataTable GetBLCorrcetionExistingValues(ChargeCorrector Data)
        //{

        //    string _Query = "select * from NVO_ChargeCorrectorMaster where ID=" + Data.CMID;
        //    return GetViewData(_Query, "");
        //}


        public List<ChargeCorrector> BLCorrectionExistingChargeValues(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetBLCorrcetionExistingChargeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    RID = Int32.Parse(dt.Rows[i]["RRID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypeID"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    NewCurrency = dt.Rows[i]["NewCurrency"].ToString(),
                    NewCurrencyID = dt.Rows[i]["NewCurrencyID"].ToString(),
                    PaymentMode = dt.Rows[i]["PaymentMode"].ToString(),
                    PaymentModeID = dt.Rows[i]["CollectionModeID"].ToString(),
                    NewPaymentMode = dt.Rows[i]["NewPaymentMode"].ToString(),
                    NewPaymentModeID = dt.Rows[i]["NewCollectionModeID"].ToString(),
                    ManifRate = dt.Rows[i]["ManifestRate"].ToString(),
                    NewManifRate = dt.Rows[i]["NewManifestRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    NewCustomerRate = dt.Rows[i]["NewCustomerRate"].ToString(),
                    Ownership = dt.Rows[i]["Ownership"].ToString(),
                    OwnershipID = dt.Rows[i]["OwnershipID"].ToString(),
                    BillAmount = dt.Rows[i]["BillAmt"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBLCorrcetionExistingChargeValues(ChargeCorrector Data)
        {

            string _Query = " select ID, CID, RRID, BLID, CntrTypeID, Qty,(select top(1) Size from NVO_tblCntrTypes where Id = CntrTypeID) as CntrTypes, " +
                            " ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where Id = ChargeCodeID) as ChargeCode,CurrencyID,NewCurrencyID, " +
                            " (select top(1) Currencycode from NVO_CurrencyMaster where ID = CurrencyID) as Currency, " +
                            " (select top(1) Currencycode from NVO_CurrencyMaster where ID = NewCurrencyID) as NewCurrency, " +
                            " CollectionModeID,NewCollectionModeID,(select top(1) GeneralName from NVO_GeneralMaster where Id = CollectionModeID) as PaymentMode, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = NewCollectionModeID) as NewPaymentMode, " +
                            " ManifestRate,NewManifestRate,CustomerRate,NewCustomerRate,BillAmt,OwnershipID, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = OwnershipID) as Ownership " +
                            " from NVO_ChargeCorrector where CID = " + Data.CMID;
            return GetViewData(_Query, "");
        }



        public List<ChargeCorrector> AgencyChargeCorrectorMaster(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetAgencyChargeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ChargeCodeV = dt.Rows[i]["ChgCodeV"].ToString(),
                    ShipmentTypeV = dt.Rows[i]["ShipmentTypeV"].ToString(),
                    CollectionModeV = dt.Rows[i]["CollectionModeV"].ToString(),
                    OwnershipV = dt.Rows[i]["OwnershipV"].ToString(),
                    InfoChIDV = dt.Rows[i]["InfoChIDV"].ToString(),
                    CntrTypeV = dt.Rows[i]["CntrTypeV"].ToString(),
                    CommodityTypeV = dt.Rows[i]["CommodityTypeV"].ToString(),
                    CurrencyV = dt.Rows[i]["CurrencyV"].ToString(),
                    Amt = dt.Rows[i]["Amt"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetAgencyChargeValues(ChargeCorrector Data)
        {
            //string _Query = "select NVO_RatesheetRevRate.RID, (select ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChgCodeV, " +
            //                " GM1.GeneralName as ShipmentTypeV,GM2.GeneralName as CollectionModeV,GM3.GeneralName as OwnershipV, " +
            //                " (select ChgCode from NVO_ChargeTB where ID = infoChID) as InfoChIDV, " +
            //                " (Select Type from NVO_tblCntrTypes where ID = CntrTypeID)as CntrTypeV, " +
            //                " (Select CommodityName from NVO_CommodityMaster where ID = CommodityTypeID)as CommodityTypeV, " +
            //                " (Select CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)as CurrencyV,Amt " +
            //                " from NVO_RatesheetRevRate " +
            //                " inner join NVO_GeneralMaster GM1 On GM1.ID = NVO_RatesheetRevRate.ShipmentType and GM1.SeqNo = 1 " +
            //                " inner join NVO_GeneralMaster GM2 On GM2.ID = NVO_RatesheetRevRate.CollectionModeID and GM2.SeqNo = 9 " +
            //                " inner join NVO_GeneralMaster GM3 On GM3.ID = NVO_RatesheetRevRate.ChargeOwnershipID and GM3.SeqNo = 11 " +
            //                " where NVO_RatesheetRevRate.ChargeOwnershipID = 24";
            string _Query = "select BookingNo,NVO_RatesheetRevRate.RID, " +
                " (select ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChgCodeV, " +
                " GM1.GeneralName as ShipmentTypeV,GM2.GeneralName as CollectionModeV,GM3.GeneralName as OwnershipV, " +
                " (select ChgCode from NVO_ChargeTB where ID = infoChID) as InfoChIDV, " +
                " (Select Size from NVO_tblCntrTypes where ID = CntrTypeID)as CntrTypeV, " +
                " (Select CommodityName from NVO_CommodityMaster where ID = NVO_RatesheetRevRate.CommodityTypeID)as CommodityTypeV, " +
                " (Select CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)as CurrencyV,Amt " +
                " from NVO_Booking " +
                " inner join NVO_RatesheetRevRate on NVO_RatesheetRevRate.RRID = NVO_Booking.RRID " +
                " inner join NVO_GeneralMaster GM1 On GM1.ID = NVO_RatesheetRevRate.ShipmentType and GM1.SeqNo = 1 " +
                " inner join NVO_GeneralMaster GM2 On GM2.ID = NVO_RatesheetRevRate.CollectionModeID and GM2.SeqNo = 9 " +
                " inner join NVO_GeneralMaster GM3 On GM3.ID = NVO_RatesheetRevRate.ChargeOwnershipID and GM3.SeqNo = 11 " +
                " where NVO_Booking.ID = " + Data.RID + " and ChargeOwnershipID = 24";
            return GetViewData(_Query, "");
        }



        public List<ChargeCorrector> BLSlotCorrectorExistingValues(ChargeCorrector Data)
        {
            List<ChargeCorrector> ViewList = new List<ChargeCorrector>();
            DataTable dt = GetBLCorrcetionExistingValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrector
                {
                    CMID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BkgNo"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectorNo"].ToString(),
                    BKgID = dt.Rows[i]["BkgID"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoyID"].ToString(),
                    SlotOperatorID = dt.Rows[i]["SlotOperatorID"].ToString(),
                    SlotID = dt.Rows[i]["SlotID"].ToString(),
                    BkgStatus = dt.Rows[i]["intStatus"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetBLCorrcetionExistingValues(ChargeCorrector Data)
        {

            string _Query = "select * from NVO_SLOTCorrector where ID=" + Data.CMID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheetRates> ChargeCorrectorRecordMaster(MyRatesheetRates Data)
        {
            List<MyRatesheetRates> ViewList = new List<MyRatesheetRates>();
            DataTable dt = GetChargeRecords(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheetRates
                {
                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    BasicID = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    CollectionModeID = Int32.Parse(dt.Rows[i]["CollectionModeID"].ToString()),
                    ChargeOwnershipID = Int32.Parse(dt.Rows[i]["ChargeOwnershipID"].ToString()),
                    infoChID = Int32.Parse(dt.Rows[i]["infoChID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amt = decimal.Parse(dt.Rows[i]["Amt"].ToString())
                });
            }
            return ViewList;
        }
        public DataTable GetChargeRecords(MyRatesheetRates Data)
        {
            string _Query = "Select * from NVO_RatesheetRevRate where RID=" + Data.RID;
            return GetViewData(_Query, "");
        }




        public List<ChargeCorrectorInsert> InsertChargeCorrector(ChargeCorrectorInsert Data)
        {

            int result = 0;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ChargeCorrectorMaster where ID=@ID and BLID=@BLID)<=0) " +
                                  " BEGIN " +
                                  " INSERT INTO  NVO_ChargeCorrectorMaster(BLID,BLNumber,CorrectionNo,Status,CurrentDate) " +
                                  " values (@BLID,@BLNumber,@CorrectionNo,@Status,@CurrentDate) " +
                                  " END  " +
                                  " ELSE " +
                                  " UPDATE NVO_ChargeCorrectorMaster SET BLID=@BLID,BLNumber=@BLNumber,CorrectionNo=@CorrectionNo,Status=@Status,CurrentDate=@CurrentDate where ID=@ID and BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CorrectionNo", Data.CorrectionNo + "-1"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.CID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_ChargeCorrectorMaster')";
                        Data.CID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }


                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_ChargeCorrector where CID=@CID and BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ChargeCorrector(RRID,BLID,CntrTypeID,ChargeCodeID,CurrencyID,NewCurrencyID,CollectionModeID,NewCollectionModeID,ManifestRate,NewManifestRate,CustomerRate,NewCustomerRate,BillAmt,CurrentDate,CID,Qty,OwnershipID) " +
                                     " values (@RRID,@BLID,@CntrTypeID,@ChargeCodeID,@CurrencyID,@NewCurrencyID,@CollectionModeID,@NewCollectionModeID,@ManifestRate,@NewManifestRate,@CustomerRate,@NewCustomerRate,@BillAmt,@CurrentDate,@CID,@Qty,@OwnershipID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ChargeCorrector SET  RRID=@RRID,BLID=@BLID,CntrTypeID=@CntrTypeID,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,NewCurrencyID=@NewCurrencyID,CollectionModeID=@CollectionModeID,NewCollectionModeID=@NewCollectionModeID," +
                                     " ManifestRate=@ManifestRate,NewManifestRate=@NewManifestRate,CustomerRate=@CustomerRate,NewCustomerRate=@NewCustomerRate,BillAmt=@BillAmt,CurrentDate=@CurrentDate,CID=@CID,Qty=@Qty,OwnershipID=@OwnershipID where CID=@CID and BLID=@BLID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", Data.CID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NewCurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NewCollectionModeID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifestRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NewManifestRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NewCustomerRate", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BillAmt", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnershipID", CharSplit[13]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    MyChargeCorrector.Add(new ChargeCorrectorInsert { ID = Data.ID });
                    return MyChargeCorrector;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyChargeCorrector;
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


        public List<ChargeCorrectorInsert> BLCorrectionUpdateApproval(ChargeCorrectorInsert Data)
        {

            int result = 0;
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
                    DataTable dtCh = GetBLCorrectionChargeUpdate(Data);
                    for (int i = 0; i < dtCh.Rows.Count; i++)
                    {
                        Cmd.CommandText = "UPDATE NVO_BLCharges set CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ManifRate=@ManifRate,CustomerRate=@CustomerRate  where BkgId=@BkgId and ChargeCodeID=@ChargeCodeID and CntrType=@CntrType";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", dtCh.Rows[i]["NewCurrencyID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", dtCh.Rows[i]["NewCollectionModeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", dtCh.Rows[i]["NewManifestRate"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", dtCh.Rows[i]["NewCustomerRate"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", dtCh.Rows[i]["BLID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("ChargeCodeID", dtCh.Rows[i]["ChargeCodeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("CntrType", dtCh.Rows[i]["CntrTypeID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    MyChargeCorrector.Add(new ChargeCorrectorInsert { CID = Data.CID });
                    return MyChargeCorrector;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyChargeCorrector;
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


        //public DataTable GetBLCorrectionChargeUpdate(ChargeCorrectorInsert Data)
        //{
        //    string _Query = " select ChargeCodeID,CntrTypeID,RRID,BLID,NewCurrencyID,NewCollectionModeID,NewManifestRate,NewCustomerRate,BillAmt  " +
        //                    " from NVO_ChargeCorrector where CID =" + Data.CID;
        //    return GetViewData(_Query, "");
        //}


        public List<ChargeCorrectorInsert> BLChargeCorrectorSearch(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetBLChargeCorrectorSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectionNo"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    CurrentDatev = dt.Rows[i]["CurrentDate"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBLChargeCorrectorSearch(ChargeCorrectorInsert Data)
        {
            string _Query = " select ID,BLNumber,CorrectionNo,case  when Status= 1 then 'Pending' else 'Approval' end as Status,convert(varchar,CurrentDate, 103) as CurrentDate  " +
                            " from NVO_ChargeCorrectorMaster";
            return GetViewData(_Query, "");
        }


        public List<ChargeCorrectorInsert> ChargeCorrectorMasterDetails(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetChargeCorrectorValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {
                    ChID = Int32.Parse(dt.Rows[i]["ChID"].ToString()),
                    EID = Int32.Parse(dt.Rows[i]["EID"].ToString()),
                    ChargeCodeV = dt.Rows[i]["ChgCodeV"].ToString(),
                    CollectionModeV = dt.Rows[i]["CollectionModeV"].ToString(),
                    ChargeOwnershipV = dt.Rows[i]["OwnershipV"].ToString(),
                    infoChIDV = dt.Rows[i]["InfoChIDV"].ToString(),
                    CntryTypeIDV = dt.Rows[i]["CntrTypeV"].ToString(),
                    CommodityTypeV = dt.Rows[i]["CommodityTypeV"].ToString(),
                    CurrencyV = dt.Rows[i]["CurrencyV"].ToString(),
                    AmtV = decimal.Parse(dt.Rows[i]["AmtV"].ToString())
                });
            }
            return ViewList;
        }
        public DataTable GetChargeCorrectorValues(ChargeCorrectorInsert Data)
        {
            string _Query = "select NVO_ChargeCorrectorDtls.ChID,NVO_ChargeCorrectorDtls.EID, (select ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChgCodeV, " +
                            " GM2.GeneralName as CollectionModeV,GM3.GeneralName as OwnershipV, " +
                            " (select ChgCode from NVO_ChargeTB where ID = infoChID) as InfoChIDV, " +
                            " (Select Size from NVO_tblCntrTypes where ID = CntrTypeID)as CntrTypeV, " +
                            " (Select CommodityName from NVO_CommodityMaster where ID = CommodityTypeID)as CommodityTypeV, " +
                            " (Select CurrencyCode from NVO_CurrencyMaster where ID = CurrencyIDV)as CurrencyV,AmtV " +
                            " from NVO_ChargeCorrectorDtls " +
                            " inner join NVO_GeneralMaster GM2 On GM2.ID = NVO_ChargeCorrectorDtls.CollectionModeIDV and GM2.SeqNo = 9 " +
                            " inner join NVO_GeneralMaster GM3 On GM3.ID = NVO_ChargeCorrectorDtls.ChargeOwnershipIDV and GM3.SeqNo = 11 where EID=" + Data.EID;
            return GetViewData(_Query, "");
        }


        public List<ChargeCorrector> BLCorrectionSlotChargeInsert(ChargeCorrector Data)
        {
            List<ChargeCorrector> MyChargeCorrector = new List<ChargeCorrector>();
            int result = 0;
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

                    DataTable dtc = GetNVO_SLOTCorrectorExistingValueCheck(Data.BKgID);
                    if (dtc.Rows.Count > 0)
                    {
                        MyChargeCorrector.Add(new ChargeCorrector { ResultSuccess = "Previous corrector was pending for this BL,</br>please either reject approve it" });
                        return MyChargeCorrector;
                    }
                    else
                    {

                        Cmd.CommandText = " IF((select count(*) from NVO_SLOTCorrector where ID=@ID and BkgID=@BkgID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_SLOTCorrector(BkgID,BkgNo,SlotID,SlotAmt,CorrectorNo,CurrentDate,intStatus,VesVoyID,SlotOperatorID,AgentID,VesVoy,CSlotAmt20,CSlotAmt40) " +
                                         " values (@BkgID,@BkgNo,@SlotID,@SlotAmt,@CorrectorNo,@CurrentDate,@intStatus,@VesVoyID,@SlotOperatorID,@AgentID,@VesVoy,@CSlotAmt20,@CSlotAmt40) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_SLOTCorrector SET BkgID=@BkgID,BkgNo=@BkgNo,SlotID=@SlotID,SlotAmt=@SlotAmt,CorrectorNo=@CorrectorNo,CurrentDate=@CurrentDate,intStatus=@intStatus,VesVoyID=@VesVoyID," +
                                         " SlotOperatorID=@SlotOperatorID,AgentID=@AgentID,VesVoy=@VesVoy,CSlotAmt20=@CSlotAmt20,CSlotAmt40=@CSlotAmt40 where ID=@ID and BkgID=@BkgID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BKgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgNo", Data.BLNumber));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotID", Data.SlotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmt", Data.SlatCharges));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CSlotAmt20", Data.SlotAmt20));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CSlotAmt40", Data.SlotAmt40));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CorrectorNo", Data.CorrectionNo));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@intStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperatorID", Data.SlotOperatorID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();

                        MyChargeCorrector.Add(new ChargeCorrector { ResultSuccess = "Approval Updated Successfully" });
                        return MyChargeCorrector;
                    }

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyChargeCorrector;
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

        public List<ChargeCorrectorInsert> BLCorrectionUpdateApprovalAmd(ChargeCorrectorInsert Data)
        {

            int result = 0;
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
                    DataTable _dtx = GetNVO_SLOTCorrectorUpdate(Data);
                    if (_dtx.Rows.Count > 0)
                    {
                        Cmd.CommandText = " UPDATE NVO_Booking SET VesVoyID=@VesVoyID,VesVoy=@VesVoy,SlotOperatorID=@SlotOperatorID,SlotContractID=@SlotContractID,SlotAmt20=@SlotAmt20,SlotAmt40=SlotAmt40 " +
                                    " FROM NVO_Booking WHERE ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", _dtx.Rows[0]["VesVoyID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", _dtx.Rows[0]["VesVoy"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperatorID", _dtx.Rows[0]["SlotOperatorID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotContractID", _dtx.Rows[0]["SlotID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmt20", _dtx.Rows[0]["CSlotAmt20"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmt40", _dtx.Rows[0]["CSlotAmt40"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BkgID));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        Cmd.CommandText = "update NVO_SLOTCorrector set intStatus=@intStatus where BkgID=@BkgID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@intStatus", 2));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                        MyChargeCorrector.Add(new ChargeCorrectorInsert { ResultSuccess = "Approval Updated Successfully" });
                        //return MyChargeCorrector;
                    }
                    //MyChargeCorrector.Add(new ChargeCorrectorInsert { ResultSuccess = "Approval Updated Successfully" });
                    return MyChargeCorrector;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    MyChargeCorrector.Add(new ChargeCorrectorInsert { ResultSuccess = ss.ToString() });
                    return MyChargeCorrector;
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


        public List<ChargeCorrectorInsert> BLCorrectionSlotReject(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> MyChargeCorrector = new List<ChargeCorrectorInsert>();
            int result = 0;
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
                    Cmd.CommandText = " UPDATE NVO_SLOTCorrector SET intStatus=@intStatus where ID=@ID and BkgID=@BkgID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@intStatus", 3));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    MyChargeCorrector.Add(new ChargeCorrectorInsert { ResultSuccess = "Rejected Updated Successfully" });
                    return MyChargeCorrector;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    MyChargeCorrector.Add(new ChargeCorrectorInsert { ResultSuccess = ex.Message });
                    return MyChargeCorrector;
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


        public DataTable GetNVO_SLOTCorrectorExistingValueCheck(string BkgID)
        {
            string _Query = "select * from NVO_SLOTCorrector where intStatus = 1 and BkgId=" + BkgID;
            return GetViewData(_Query, "");
        }
        public DataTable GetNVO_SLOTCorrectorUpdate(ChargeCorrectorInsert Data)
        {
            string _Query = " select * from NVO_SLOTCorrector where ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable GetBLCorrectionChargeUpdate(ChargeCorrectorInsert Data)
        {
            string _Query = " select ChargeCodeID,CntrTypeID,RRID,BLID,NewCurrencyID,NewCollectionModeID,NewManifestRate,NewCustomerRate,BillAmt  " +
                            " from NVO_ChargeCorrector where CID =" + Data.CID;
            return GetViewData(_Query, "");
        }


        public List<ChargeCorrectorInsert> ChargeCorrectorDelete(ChargeCorrectorInsert Data)
        {
            DataTable dt = DeleteChargeValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyChargeCorrector.Add(new ChargeCorrectorInsert
                {
                    ChID = Int32.Parse(dt.Rows[i]["ChID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    infoChID = Int32.Parse(dt.Rows[i]["infoChID"].ToString()),
                    BasicID = Int32.Parse(dt.Rows[i]["EmailID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    CurrencyIDV = Int32.Parse(dt.Rows[i]["CurrencyIDV"].ToString()),
                    Amt = decimal.Parse(dt.Rows[i]["Amt"].ToString()),
                    AmtV = decimal.Parse(dt.Rows[i]["AmtV"].ToString()),
                    CollectionModeID = Int32.Parse(dt.Rows[i]["CollectionModeID"].ToString()),
                    CollectionModeIDV = Int32.Parse(dt.Rows[i]["CollectionModeIDV"].ToString()),
                    ChargeOwnershipID = Int32.Parse(dt.Rows[i]["ChargeOwnershipID"].ToString()),
                    ChargeOwnershipIDV = Int32.Parse(dt.Rows[i]["ChargeOwnershipIDV"].ToString()),
                    CurrentDate = DateTime.Parse(dt.Rows[i]["CurrentDate"].ToString()),
                    EID = Int32.Parse(dt.Rows[i]["EID"].ToString())
                });
            }
            return MyChargeCorrector;
        }
        public DataTable DeleteChargeValues(ChargeCorrectorInsert Data)
        {
            string _Query = "Delete NVO_ChargeCorrectorDtls where ChID=" + Data.ChID;
            return GetViewData(_Query, "");
        }


        public List<ChargeCorrectorInsert> ExpSlotCorrectorValues(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetSlotCorrectorView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BkgNo"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectorNo"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    CurrentDatev = dt.Rows[i]["CurrentDate"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetSlotCorrectorView(ChargeCorrectorInsert Data)
        {
            string strWhere = "";
            string _Query = " select ID,BkgNo,CorrectorNo,convert(varchar,CurrentDate, 103) as CurrentDate,case when INTStatus= 1 then 'PENDING' when INTStatus= 2 then 'APPROVED' when INTStatus= 3 then 'CANCELLED' end as Status " +
                            " from NVO_SLOTCorrector";
            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where BKGNo like '%" + Data.BLNumber + "%'";
                else
                    strWhere += " and BLNumber like '%" + Data.BLNumber + "%'";

            if (Data.CorrectionNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where CorrectorNo like '%" + Data.CorrectionNo + "%'";
                else
                    strWhere += " and CorrectorNo like '%" + Data.CorrectionNo + "%'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where AgentID = " + Data.AgencyID;
                else
                    strWhere += " and AgentID = " + Data.AgencyID;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }
        public List<MyBooking> BookingSlotValies(MyBooking Data)
        {

            DataTable dt = GetBookingSlotValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyBkgList.Add(new MyBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["OperatorID"].ToString()),
                    VesOperator = dt.Rows[i]["Operator"].ToString()

                });
            }
            return MyBkgList;
        }

        public DataTable GetBookingSlotValues(MyBooking Data)
        {
            string _Query = "select OperatorID,Operator from NVO_VoyageOpertaors where VoyageID = " + Data.VesVoyID;
            return GetViewData(_Query, "");

        }


        public List<MyBooking> BookingSlotRefNoValies(MyBooking Data)
        {
            DataTable dt = GetBookingSlotRefNoValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyBkgList.Add(new MyBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["SlotRefID"].ToString()),
                    SlotRefNo = dt.Rows[i]["SlotRef"].ToString()

                });
            }
            return MyBkgList;
        }

        public DataTable GetBookingSlotRefNoValues(MyBooking Data)
        {
            string _Query = "select SlotRefID, SlotRef from NVO_VoyageOpertaors where VoyageID = " + Data.VesVoyID + " AND OperatorID =" + Data.SlotID;
            return GetViewData(_Query, "");

        }


        public List<MyBooking> BookingSlotContactNoValies(MyBooking Data)
        {
            DataTable dt = GetBookingSlotContactNoValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyBkgList.Add(new MyBooking
                {

                    SlotTermID = dt.Rows[i]["SlotTermID"].ToString(),
                    Cnt20 = dt.Rows[i]["Ctr20"].ToString(),
                    Cnt40 = dt.Rows[i]["Ctr40"].ToString()

                });
            }
            return MyBkgList;
        }

        public DataTable GetBookingSlotContactNoValues(MyBooking Data)
        {
            //string _Query = " Select SlotTermID,(select sum(Amount) from NVO_SLOTDDtls where SLID = NVO_SLOTMaster.ID and SizeID = 1) as Ctr20, " +
            //                " (select sum(Amount) from NVO_SLOTDDtls where SLID = NVO_SLOTMaster.ID and SizeID in(2, 3)) as Ctr40 " +
            //                " from NVO_SLOTMaster where Id = " + Data.ID;

            string _Query = " Select SlotTermID,isnull((select sum(Amount) from NVO_SLOTDDtls where SLID = NVO_SLOTMaster.ID and SizeID = 1 and NVO_SLOTDDtls.SizeID in (" + Data.CntrTypeID + ") and Commodity in (" + Data.CommodityTypeID + ")),0) as Ctr20,  " +
                            " isnull((select sum(Amount) from NVO_SLOTDDtls where SLID = NVO_SLOTMaster.ID and SizeID in(2, 3) and NVO_SLOTDDtls.SizeID in (" + Data.CntrTypeID + ") and Commodity in (" + Data.CommodityTypeID + ")),0) as Ctr40 " +
                            " from NVO_SLOTMaster " +
                            " inner join NVO_SLOTDDtls on NVO_SLOTDDtls.SLID = NVO_SLOTMaster.ID " +
                            " where Id = " + Data.ID + " and SizeID in (" + Data.CntrTypeID + ") and Commodity in (" + Data.CommodityTypeID + ")";
            return GetViewData(_Query, "");
        }

        public List<MyBooking> BookingTransPortValues(MyBooking Data)
        {
            DataTable dt = GetBookingTransPortValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyBkgList.Add(new MyBooking
                {
                    TsPortID = dt.Rows[i]["TsPortID"].ToString()

                });
            }
            return MyBkgList;
        }

        public DataTable GetBookingTransPortValues(MyBooking Data)
        {
            string _Query = "select * from NVO_BkgTranshipmentPort where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BOLBtnViewDtlsRecordValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLBtnViewDtlsRecordValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetBOLBtnViewDtlsRecordValus(MYBOL Data)
        {


            string _Query = " Select case when NVO_BOL.ID is null  then 0 else NVO_BOL.ID end as ID,NVO_Booking.Id as BkgID,BookingNo as BLNumber,case when isnull(NVO_BOL.Status,0)= 0 then 'DRAFT' when NVO_BOL.Status = 2 then 'CONFIRMED' when " +
        "  BkgStatus = 3 then 'CANCELLED'  end as Status ,BookingNo,RRNo,BkgParty,ShipmentType,POL,POD from NVO_Booking " +
      " left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where BkgStatus =  " + Data.BkgStatus + " and ( case when isnull(NVO_BOL.Status,0)= 0 then 'DRAFT'  when " + " NVO_BOL.Status = 2 then 'CONFIRMED' when BkgStatus = 3 then 'CANCELLED' end) = '" + Data.Status + "'";
            if (Data.AgentId != "2")
                _Query += " and AgentId=" + Data.AgentId + " ";

            return GetViewData(_Query, "");
        }


        public List<MyBooking> ListDepotByPortRecordValus(MyBooking Data)
        {
            DataTable dt = GetDepotByPortRecordValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyBkgList.Add(new MyBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PickUpDepot = dt.Rows[i]["DepName"].ToString(),

                });
            }
            return MyBkgList;
        }

        public DataTable GetDepotByPortRecordValus(MyBooking Data)

        {

            string _Query = "select D.ID,DepName from NVO_DepotMasterPortDtls DP inner join NVO_DepotMaster D ON D.ID = DP.DepotID where DP.PortID = " + Data.ID;

            return GetViewData(_Query, "");

        }

        public List<MyBooking> ListModuleValues(MyBooking Data)
        {
            DataTable dt = GetListModuleValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyBkgList.Add(new MyBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return MyBkgList;
        }

        public DataTable GetListModuleValues(MyBooking Data)
        {
            string _Query = "select case when TSPORTID = 0  then(select ID from NVO_GeneralMaster where SeqNo = 27  and ID in (77)) else (select ID from NVO_GeneralMaster where SeqNo = 27  and ID in (78)) end as ID, case when TSPORTID = 0  then (select GeneralName from NVO_GeneralMaster where SeqNo = 27  and ID in (77)) else  (select GeneralName from NVO_GeneralMaster where SeqNo = 27  and ID in (78)) end as GeneralName from NVO_Booking where ID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYBLPrintLog> BLPrintLogInsert(MYBLPrintLog Data)
        {
            List<MYBLPrintLog> MyList = new List<MYBLPrintLog>();
            int result = 0;
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
                    Cmd.CommandText = "Select(count(Copy)) from NVO_BLPrintLog  where Type=" + Data.Type + " and BkgID=" + Data.BkgID + " and BLID=" + Data.BLID;
                    Data.Copy = Cmd.ExecuteScalar().ToString();
                    int StatusRow = 0;
                    if (Data.Type == "1")
                        StatusRow = 1;
                    else
                        StatusRow = 2;


                    if (Data.Type == "1")
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_BLPrintLog where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLPrintLog(AgentName,Copy,Type,PrintBy,PrintedOn,BkgID,Status,BLID) " +
                                     " values (@AgentName,@Copy,@Type,@PrintBy,@PrintedOn,@BkgID,@Status,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLPrintLog SET AgentName=@AgentName,Copy=@Copy,Type=@Type,PrintBy=@PrintBy,PrintedOn=@PrintedOn,BkgID=@BkgID,Status=@Status,BLID=@BLID where  ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", Data.AgentName));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Copy", Int32.Parse(Data.Copy) + 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", Data.Type));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@Reason", Data.Reason));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintBy", Data.PrintBy));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintedOn", System.DateTime.Now.Date));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedBy", Data.DeletedBy));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedOn", System.DateTime.Now.Date));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", StatusRow));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                        MyList.Add(new MYBLPrintLog { ID = Data.ID, Errer = "PRINT" });
                        return MyList;
                    }
                    else
                    {
                        DataTable _dtEx = GetBLPrintExistingLogValus(Data.BkgID, Data.Type);
                        if (_dtEx.Rows.Count > 0)
                        {
                            if (_dtEx.Rows[0]["Status"].ToString() == "3")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_BLPrintLog where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLPrintLog(AgentName,Copy,Type,PrintBy,PrintedOn,BkgID,Status,BLID) " +
                                     " values (@AgentName,@Copy,@Type,@PrintBy,@PrintedOn,@BkgID,@Status,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLPrintLog SET AgentName=@AgentName,Copy=@Copy,Type=@Type,PrintBy=@PrintBy,PrintedOn=@PrintedOn,BkgID=@BkgID,Status=@Status,BLID=@BLID where  ID=@ID";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", Data.AgentName));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Copy", Int32.Parse(Data.Copy) + 1));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", Data.Type));
                                //Cmd.Parameters.Add(_dbFactory.GetParameter("@Reason", Data.Reason));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintBy", Data.PrintBy));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintedOn", System.DateTime.Now.Date));
                                //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedBy", Data.DeletedBy));
                                //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedOn", System.DateTime.Now.Date));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", StatusRow));

                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                                trans.Commit();
                                MyList.Add(new MYBLPrintLog { ID = Data.ID });
                                return MyList;
                            }
                            else
                            {
                                MyList.Add(new MYBLPrintLog { Errer = "Alredy Printed", });
                                return MyList;
                            }
                        }
                        else
                        {

                            Cmd.CommandText = " IF((select count(*) from NVO_BLPrintLog where ID=@ID)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_BLPrintLog(AgentName,Copy,Type,PrintBy,PrintedOn,BkgID,Status,BLID) " +
                                   " values (@AgentName,@Copy,@Type,@PrintBy,@PrintedOn,@BkgID,@Status,@BLID) " +
                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_BLPrintLog SET AgentName=@AgentName,Copy=@Copy,Type=@Type,PrintBy=@PrintBy,PrintedOn=@PrintedOn,BkgID=@BkgID,Status=@Status,BLID=@BLID where  ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", Data.AgentName));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Copy", Int32.Parse(Data.Copy) + 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", Data.Type));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@Reason", Data.Reason));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintBy", Data.PrintBy));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PrintedOn", System.DateTime.Now.Date));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedBy", Data.DeletedBy));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedOn", System.DateTime.Now.Date));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", StatusRow));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                            trans.Commit();
                            MyList.Add(new MYBLPrintLog { ID = Data.ID, Errer = "PRINT" });
                            return MyList;
                        }
                    }

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyList;
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

        public List<MYBLPrintLog> BLPrintLogViewValus(MYBLPrintLog Data)
        {
            List<MYBLPrintLog> ViewList = new List<MYBLPrintLog>();
            DataTable dt = GetBLPrintLogValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBLPrintLog
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgentName = dt.Rows[i]["AgentName"].ToString(),
                    Copy = dt.Rows[i]["Copy"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    Reason = dt.Rows[i]["Reason"].ToString(),
                    PrintBy = dt.Rows[i]["PrintBy"].ToString(),
                    PrintedOn = dt.Rows[i]["PrintedOn"].ToString(),
                    DeletedBy = dt.Rows[i]["DeletedBy"].ToString(),
                    DeletedOn = dt.Rows[i]["DeletedOn"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    IsFinal = dt.Rows[i]["IsFinal"].ToString(),


                });
            }
            return ViewList;
        }

        public DataTable GetBLPrintLogValus(MYBLPrintLog Data)
        {
            string _Query = " select ID,AgentName,Copy,(select top(1) BLTypes from NVO_BLPrintTypes where Id = Type) as Type, Reason, PrintBy,  " +
                            " convert(varchar, PrintedOn, 103) as PrintedOn,DeletedBy, convert(varchar, DeletedOn, 103) as DeletedOn, " +
                            " case when  Status =1 then 'ACTIVE' when Status = 2 then 'PRINT'  WHEN Status = 3 THEN 'DELETE' END  AS Status,'0' as IsFinal " +
                            " from NVO_BLPrintLog where BkgID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public DataTable GetBLPrintExistingLogValus(string BkgID, string Type)
        {
            string _Query = "select top(1) * from NVO_BLPrintLog where BkgID=" + BkgID + " and Type=" + Type + " Order by Id desc";
            return GetViewData(_Query, "");
        }

        public List<MYBLPrintLog> BLPrintLogDelete(MYBLPrintLog Data)
        {
            List<MYBLPrintLog> MyList = new List<MYBLPrintLog>();
            int result = 0;
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

                    Cmd.CommandText = " UPDATE NVO_BLPrintLog SET Reason=@Reason,DeletedBy=@DeletedBy,DeletedOn=@DeletedOn,Status=@Status where BkgID=@BkgID and ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reason", Data.Reason));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedBy", Data.DeletedBy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeletedOn", System.DateTime.Now.Date));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 3));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    MyList.Add(new MYBLPrintLog { ID = Data.ID });
                    return MyList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyList;
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


        public List<ChargeCorrectorInsert> BLCorrectorViewValues(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetBLCorrectorViewValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectionNo"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    CurrentDatev = dt.Rows[i]["CurrentDate"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetBLCorrectorViewValues(ChargeCorrectorInsert Data)
        {
            string strWhere = "";
            string _Query = " select ID,BLNumber,CorrectionNo,convert(varchar,CurrentDate, 103) as CurrentDate,case when Status= 1 then 'PENDING' when Status= 2 then 'APPROVED' when Status= 3 then 'CANCELLED' end as Status,BLID " +
                            " from NVO_ChargeCorrectorMaster";

            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where BLNumber like '%" + Data.BLNumber + "%'";
                else
                    strWhere += " and BLNumber like '%" + Data.BLNumber + "%'";

            if (Data.CorrectionNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where CorrectionNo like '%" + Data.CorrectionNo + "%'";
                else
                    strWhere += " and CorrectionNo like '%" + Data.CorrectionNo + "%'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where AgencyID = " + Data.AgencyID;
                else
                    strWhere += " and AgencyID = " + Data.AgencyID;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<ChargeCorrectorInsert> BLCorrectorCountRecordValues(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetBLCorrectorCountRecordValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {

                    Draft = dt.Rows[i]["Draft"].ToString(),
                    Cancelled = dt.Rows[i]["Cancel"].ToString(),
                    Confirm = dt.Rows[i]["Confirm"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBLCorrectorCountRecordValues(ChargeCorrectorInsert Data)
        {
            if (Data.AgencyID.ToString() == "2")
            {
                string _Query = " select  " +
                            " (select count(ID) from NVO_ChargeCorrectorMaster where Status = 1 ) as Draft, " +
                            " (select count(ID) from NVO_ChargeCorrectorMaster where Status = 2 ) as Confirm, " +
                            " (select count(ID) from NVO_ChargeCorrectorMaster where Status = 3 ) as Cancel";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = " select  " +
                          " (select count(ID) from NVO_ChargeCorrectorMaster where Status = 1 and AgencyID=" + Data.AgencyID + ") as Draft, " +
                          " (select count(ID)  from NVO_ChargeCorrectorMaster where Status = 2 and AgencyID=" + Data.AgencyID + ") as Confirm, " +
                          " (select count(ID) from NVO_ChargeCorrectorMaster where Status = 3 and AgencyID=" + Data.AgencyID + ") as Cancel";
                return GetViewData(_Query, "");
            }
        }


        public List<ChargeCorrectorInsert> SlotCorrectorCountRecordValues(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetSlotCorrectorCountRecordValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {

                    Draft = dt.Rows[i]["Draft"].ToString(),
                    Cancelled = dt.Rows[i]["Cancel"].ToString(),
                    Confirm = dt.Rows[i]["Confirm"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetSlotCorrectorCountRecordValues(ChargeCorrectorInsert Data)
        {
            if (Data.AgencyID.ToString() == "2")
            {
                string _Query = " select  " +
                            " (select count(ID) from NVO_SLOTCorrector where intStatus = 1 ) as Draft, " +
                            " (select count(ID) from NVO_SLOTCorrector where intStatus = 2 ) as Confirm, " +
                            " (select count(ID) from NVO_SLOTCorrector where intStatus = 3 ) as Cancel";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = " select  " +
                          " (select count(ID) from NVO_SLOTCorrector where intStatus = 1 and AgentID=" + Data.AgencyID + ") as Draft, " +
                          " (select count(ID)  from NVO_SLOTCorrector where intStatus = 2 and AgentID=" + Data.AgencyID + ") as Confirm, " +
                          " (select count(ID) from NVO_SLOTCorrector where intStatus = 3 and AgentID=" + Data.AgencyID + ") as Cancel";
                return GetViewData(_Query, "");
            }
        }

        public List<MYBOL> BOLCustomerPartyDelete(MYBOL Data)
        {

            int result = 0;
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

                    Cmd.CommandText = "delete NVO_BOLCustomerDetails where BCID=@BCID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BCID", Data.ID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    MyBOLList.Add(new MYBOL { RRNo = Data.RRNo, Message = "Customer Party Deleted sucessfully" });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    MyBOLList.Add(new MYBOL { Message = ex.Message });
                    return MyBOLList;
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


        public string GetMaxseqNumber(string Prefix, string GeoLocId, string SessionFinYear)
        {
            DbConnection con = null;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                DbCommand cmd = _dbFactory.GetCommand();
                cmd.Connection = con;

                int sno = 0;
                string Seqno = "0";

                cmd.CommandText = "select Max(ISNULL(" + Prefix + ",0)) from NVO_SeqNo where GeoLocId=" + GeoLocId + " and intYear=" + SessionFinYear;
                Seqno = cmd.ExecuteScalar().ToString();
                if (Seqno == "")
                {
                    sno = int.Parse("1");
                    Seqno = "1";
                }
                else if (Seqno == "0")
                    sno = int.Parse("1");
                else if (Seqno != "0")
                    sno = int.Parse(Seqno) + 1;

                cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_SeqNo WHERE GeoLocId=" + GeoLocId + " and intYear = " + SessionFinYear + ")<=0)" +
                                   " BEGIN  " +
                                   " INSERT INTO NVO_SeqNo(GeoLocId," + Prefix + ",intYear)Values(" + GeoLocId + "," + sno.ToString() + ", " + SessionFinYear + ") " +
                                   " END " +
                                   " ELSE " +
                                   " UPDATE NVO_SeqNo SET " + Prefix + "=" + sno.ToString() + " where GeoLocId=" + GeoLocId + " and intYear = " + SessionFinYear;
                int result = cmd.ExecuteNonQuery();

                return Seqno.ToString();
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


        public static int ExcelColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }
    }
}

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
using System.Globalization;

namespace DataManager
{
   public class ExpTraffMaster
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ExpTraffMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion




        public List<MyRRRate> ExpTarfiiExisting(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetTariffExisting(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCode"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentMode"].ToString(),
                    CurrencyID = dt.Rows[i]["Currency"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    BillAmt = dt.Rows[i]["BillAmt"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvID = dt.Rows[i]["InvID"].ToString(),


                });
            }

            return ViewList;
        }

        public DataTable GetTariffExisting(MyRRRate Data)
        {
            //string _Query = " Select TariffID as  RCID,CntrType, (select top(1) Size from NVO_tblCntrTypes where ID =CntrType) as CntrTypes, " +
            //                " ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode, " +
            //                " CurrencyID, (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)  as Currency, " +
            //                " PaymentModeID, (select top(1) GeneralName from NVO_GeneralMaster where ID = PaymentModeID) as PaymentMode, " +
            //                " ReqRate,ManifRate,CustomerRate,RateDiff, " +
            //                " Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end as Qty " +
            //                " from NVO_RatesheetCharges " +
            //                " inner join NVO_Booking on NVO_Booking.RRID = NVO_RatesheetCharges.RRId " +
            //                " where NVO_Booking.ID = " + Data.ID + " and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;

            string _Query = " Select TariffID as  RCID,CntrType, (select top(1) Size from NVO_tblCntrTypes where ID =CntrType) as CntrTypes, " +
                 " ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode, " +
                 " CurrencyID, (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)  as Currency, " +
                 " PaymentModeID, (select top(1) GeneralName from NVO_GeneralMaster where ID = PaymentModeID) as PaymentMode, " +
                 " ReqRate,ManifRate,CustomerRate,RateDiff, " +
                 " Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end as Qty, " +
                 " ((Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end) * CustomerRate) as BillAmt, " +
                 " (select (select top(1) FinalInvoice from NVO_InvoiceCusBilling where Id =InvCusBillingID ) from NVO_InvoiceCusBillingdtls where BLInvID =NVO_BLCharges.ID) as InvoiceNo, " +
                 " (select(select top(1) ID from NVO_InvoiceCusBilling where Id = InvCusBillingID ) from NVO_InvoiceCusBillingdtls where BLInvID = NVO_BLCharges.ID) as InvID " +
                 " from NVO_BLCharges " +
                 " inner join NVO_Booking on NVO_Booking.ID = NVO_BLCharges.BkgID " +
                 " where NVO_Booking.ID = " + Data.BkgID + " and NVO_BLCharges.BLID= "+ Data.BLID + " and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;
            return GetViewData(_Query, "");
        }

        public List<MyRRRate> ExpSlotCostExisting(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetTariffSlotCost(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCode"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentMode"].ToString(),
                    CurrencyID = dt.Rows[i]["Currency"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    VendorName = dt.Rows[i]["VendorName"].ToString(),
                    VendorID = dt.Rows[i]["VendorID"].ToString()


                }) ;
            }

            return ViewList;
        }
        public DataTable GetTariffSlotCost(MyRRRate Data)
        {
            string _Query = " select SID as RCID,ChargeID as ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where Id = ChargeID) as ChargeCode,SizeID as CntrType, " +
                            " (select top(1) size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_SLOTDDtls.SizeID) as CntrTypes, CurrencyID, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID) as Currency,19 as PaymentModeID, 'COLLECT' as PaymentMode, " +
                            " Amount as ReqRate,Amount as ManifRate,Amount as CustomerRate,'' RateDiff, " +
                            " Case when SizeID = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = SizeID) end as Qty, " +
                            " ((select top(1) (CustomerName + '-' + Branch) from NVO_CustomerMaster inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID=NVO_CustomerMaster.ID  where CID = SlotOperatorID)) as VendorName,SlotOperatorID as VendorID " +
                            " from NVO_SLOTDDtls " +
                            " inner join NVO_Booking on NVO_Booking.SlotContractID = NVO_SLOTDDtls.SLID " +
                            " inner join NVO_BookingCntrTypes on NVO_BookingCntrTypes.BKgID =NVO_Booking.ID and NVO_BookingCntrTypes.CntrTypes = NVO_SLOTDDtls.SizeID " +
                            " inner join NVO_BOL on NVO_BOL.BkgID=NVO_Booking.ID "+
                            " where NVO_Booking.ID = " + Data.BkgID + "  and  NVO_BOL.ID="+ Data.BLID +  " and Commodity in ((select CommodityType from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID))";
            return GetViewData(_Query, "");
        }

        public List<MyRRRate> ExpTariffCostExisting(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetTariffBookingCost(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCode"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentMode"].ToString(),
                    CurrencyID = dt.Rows[i]["Currency"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),
                    VendorName = dt.Rows[i]["VendorName"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString()

                });
            }

            return ViewList;
        }

        public DataTable GetTariffBookingCost(MyRRRate Data)
        {
            string _Query = " Select TariffID as  RCID,CntrType, (select top(1) Size from NVO_tblCntrTypes where ID =CntrType) as CntrTypes, " +
             " ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode, " +
             " CurrencyID, (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)  as Currency, " +
             " PaymentModeID, (select top(1) GeneralName from NVO_GeneralMaster where ID = PaymentModeID) as PaymentMode, " +
             " ReqRate,ManifRate,CustomerRate,RateDiff, " +
             " Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end as Qty, " +
             " ((Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end) * CustomerRate) as BillAmt, '' as InvoiceNo, " +
             " (select top(1) AgentID from  NVO_BLVenChargesAgentName where TariffTypeID=TariffID and BkgId = NVO_Booking.ID ) as VendorID, " +
             " (select top(1) AgentName from NVO_BLVenChargesAgentName where TariffTypeID = TariffID and BkgId = NVO_Booking.ID) as VendorName " +
             " from NVO_BLVenCharges " +
             " inner join NVO_Booking on NVO_Booking.ID = NVO_BLVenCharges.BkgID " +
             " where NVO_Booking.ID = " + Data.BkgID + " and NVO_BLVenCharges.BLID = "+ Data.BLID +" and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;

            return GetViewData(_Query, "");
        }

        public List<MyRRRate> ExpTariffCommisionCostExisting(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetTariffBookingCommisionCost(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCode"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentMode"].ToString(),
                    CurrencyID = dt.Rows[i]["Currency"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),
                    VendorName = dt.Rows[i]["VendorName"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString()

                });
            }

            return ViewList;
        }


        public DataTable GetTariffBookingCommisionCost(MyRRRate Data)
        {

            //string _Query = " select distinct '1'AS RCID, NVO_BLVenCharges.CntrType,(select top(1) Qty from NVO_BookingCntrTypes where BKgID = Bkg.ID) as Qty,(select top(1) Size from NVO_tblCntrTypes where ID = NVO_BLVenCharges.CntrType) as CntrTypes,  " +
            //                " 32 as ChargeCodeID , 'EXPORT COMMISSION' as ChargeCode, 146 as CurrencyID, 'USD' as Currency, " +
            //                " (select case when FixedRate <= (select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
            //                " from NVO_Booking where NVO_Booking.Id = Bkg.ID) then((CommPercentage * ((select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
            //                " from NVO_Booking where NVO_Booking.Id = Bkg.ID))) / 100)  else FixedRate end from NVO_CommissionContract where AgencyID = Bkg.AgentID and ShipmentType = 1) as FixedRate,'' as RateDiff,  " +
            //                " TranshipmetAgentID as VendorID,(select top(1) AgencyName from NVO_AgencyMaster where Id = Bkg.AgentID) as VendorName " +
            //                " from NVO_BLVenCharges " +
            //                " inner join NVO_RatesheetCharges on NVO_RatesheetCharges.RRID = NVO_BLVenCharges.RRID " +
            //                " inner join NVO_Booking Bkg on Bkg.RRID = NVO_RatesheetCharges.RRID " +
            //                " inner join NVO_Ratesheet on NVO_Ratesheet.ID = NVO_RatesheetCharges.RRID " +
            //                " where ChargeTypeID = 1 and NVO_RatesheetCharges.ChargeCodeID = 1 and NVO_BLVenCharges.BkgID = " + Data.ID +
            //                " union " +
            //                " select distinct '2'AS RCID, NVO_BLVenCharges.CntrType,(select top(1) Qty from NVO_BookingCntrTypes where BKgID = Bkg.ID) as Qty,(select top(1) Size from NVO_tblCntrTypes where ID = NVO_BLVenCharges.CntrType) as CntrTypes, " +
            //                " 33 as ChargeCodeID , 'IMPORT COMMISSION' as ChargeCode, 146 as CurrencyID, 'USD' as Currency, " +
            //                " (select case when FixedRate <= (select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
            //                " from NVO_Booking where NVO_Booking.Id = Bkg.ID) then((CommPercentage * ((select(select ManifRate from NVO_RatesheetCharges where ChargeCodeID = 1 and NVO_RatesheetCharges.RRID = NVO_Booking.RRID) " +
            //                " from NVO_Booking where NVO_Booking.Id = Bkg.ID))) / 100)  else FixedRate end from NVO_CommissionContract where AgencyID = Bkg.DestinationAgentID and ShipmentType = 2) as FixedRate,'' as RateDiff,  " +
            //                " TranshipmetAgentID as VendorID,(select top(1) AgencyName from NVO_AgencyMaster where Id = Bkg.DestinationAgentID) as VendorName " +
            //                " from NVO_BLVenCharges " +
            //                " inner join NVO_RatesheetCharges on NVO_RatesheetCharges.RRID = NVO_BLVenCharges.RRID " +
            //                " inner join NVO_Booking Bkg on Bkg.RRID = NVO_RatesheetCharges.RRID " +
            //                " inner join NVO_Ratesheet on NVO_Ratesheet.ID = NVO_RatesheetCharges.RRID " +
            //                " where ChargeTypeID = 1 and NVO_RatesheetCharges.ChargeCodeID = 1 and NVO_BLVenCharges.BkgID = " + Data.ID +
            //                " union " +
            //                " select distinct '3'AS RCID, NVO_BLVenCharges.CntrType,(select top(1) Qty from NVO_BookingCntrTypes where BKgID = Bkg.ID) as Qty,(select top(1) Size from NVO_tblCntrTypes where ID = NVO_BLVenCharges.CntrType) as CntrTypes,  " +
            //                " 34 as ChargeCodeID , 'TRANSHIPMENT COMMISSION' as ChargeCode, 146 as CurrencyID, 'USD' as Currency, " +
            //                " (select top(1) FixedRate from NVO_CommissionContract where AgencyID= Bkg.AgentID and ShipmentType= 179)  as FixedRate, '' as RateDiff,  " +
            //                " TranshipmetAgentID as VendorID,(select top(1) AgencyName from NVO_AgencyMaster where Id = Bkg.TranshipmetAgentID) as VendorName " +
            //                " from NVO_BLVenCharges " +
            //                " inner join NVO_RatesheetCharges on NVO_RatesheetCharges.RRID = NVO_BLVenCharges.RRID" +
            //                " inner join NVO_Booking Bkg on Bkg.RRID = NVO_RatesheetCharges.RRID" +
            //                " inner join NVO_Ratesheet on NVO_Ratesheet.ID = NVO_RatesheetCharges.RRID" +
            //                " where ChargeTypeID = 1 and NVO_RatesheetCharges.ChargeCodeID = 1 and NVO_BLVenCharges.BkgID = " + Data.ID;


            string _Query = " Select TariffID as  RCID,CntrType, (select top(1) Size from NVO_tblCntrTypes where ID =CntrType) as CntrTypes, " +
            " ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode, " +
            " CurrencyID, (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)  as Currency, " +
            " PaymentModeID, (select top(1) GeneralName from NVO_GeneralMaster where ID = PaymentModeID) as PaymentMode, " +
            " ReqRate,ManifRate,CustomerRate,RateDiff, " +
            " Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end as Qty, " +
            " ((Case when CntrType = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_Booking.ID and CntrTypes = CntrType)  end) * CustomerRate) as BillAmt, '' as InvoiceNo, " +
            " (select top(1) AgentID from  NVO_BLVenChargesAgentName where TariffTypeID=TariffID and BkgId = NVO_Booking.ID ) as VendorID, " +
            " (select top(1) AgentName from NVO_BLVenChargesAgentName where TariffTypeID = TariffID and BkgId = NVO_Booking.ID) as VendorName " +
            " from NVO_BLVenCharges " +
            " inner join NVO_Booking on NVO_Booking.ID = NVO_BLVenCharges.BkgID " +
            " where ChargeCodeID in (32,33,34) and NVO_Booking.ID = " + Data.BkgID + " and NVO_BLVenCharges.BLID=" + Data.BLID;

            return GetViewData(_Query, "");
        }



        public List<MyRRRate> VendorCostInsert(MyRRRate Data)
        {
            List<MyRRRate> MyList = new List<MyRRRate>();

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
                   
                    string[] Array = Data.ItemsSlotv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BLVenChargesAgentName where BkgID=@BkgID and TariffTypeID=@TariffTypeID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLVenChargesAgentName(BkgId,AgentName,AgentID,TariffTypeID,ChType) " +
                                     " values (@BkgId,@AgentName,@AgentID,@TariffTypeID,@ChType) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLVenChargesAgentName SET BkgID=@BkgID,AgentName=@AgentName,AgentID=@AgentID,TariffTypeID=@TariffTypeID,ChType=@ChType where BkgID=@BkgID and TariffTypeID=@TariffTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                    
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChType","SL"));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array1 = Data.ItemsTermainalv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BLVenChargesAgentName where BkgID=@BkgID and TariffTypeID=@TariffTypeID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_BLVenChargesAgentName(BkgId,AgentName,AgentID,TariffTypeID,ChType) " +
                                    " values (@BkgId,@AgentName,@AgentID,@TariffTypeID,@ChType) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_BLVenChargesAgentName SET BkgID=@BkgID,AgentName=@AgentName,AgentID=@AgentID,TariffTypeID=@TariffTypeID,ChType=@ChType where BkgID=@BkgID and TariffTypeID=@TariffTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChType", "TH"));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array2 = Data.ItemsLocalCostv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array2.Length; i++)
                    {
                        var CharSplit = Array2[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BLVenChargesAgentName where BkgID=@BkgID and TariffTypeID=@TariffTypeID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_BLVenChargesAgentName(BkgId,AgentName,AgentID,TariffTypeID,ChType) " +
                                    " values (@BkgId,@AgentName,@AgentID,@TariffTypeID,@ChType) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_BLVenChargesAgentName SET BkgID=@BkgID,AgentName=@AgentName,AgentID=@AgentID,TariffTypeID=@TariffTypeID,ChType=@ChType where BkgID=@BkgID and TariffTypeID=@TariffTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChType", "LC"));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array3 = Data.ItemsCommissionv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array3.Length; i++)
                    {
                        var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BLVenChargesAgentName where BkgID=@BkgID and TariffTypeID=@TariffTypeID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_BLVenChargesAgentName(BkgId,AgentName,AgentID,TariffTypeID,ChType) " +
                                    " values (@BkgId,@AgentName,@AgentID,@TariffTypeID,@ChType) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_BLVenChargesAgentName SET BkgID=@BkgID,AgentName=@AgentName,AgentID=@AgentID,TariffTypeID=@TariffTypeID,ChType=@ChType where BkgID=@BkgID and TariffTypeID=@TariffTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChType", "CM"));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();
                    MyList.Add(new MyRRRate { ID = Data.ID });
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



        public List<MyRRRate> InsertOffLineImportTariffCharges(MyRRRate Data)
        {
            List<MyRRRate> MyList = new List<MyRRRate>();

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

                    DataTable dt = GetImportBookingValue(Data.BkgID);
                    if (dt.Rows.Count > 0)
                    {

                        string CntrTypeID = "";
                        DataTable dtCntTypes = GetImportCntrIdValue(Data.BkgID);
                        for (int q = 0; q < dtCntTypes.Rows.Count; q++)
                            CntrTypeID += dtCntTypes.Rows[q]["TypeID"].ToString() + ",";

                        DataTable _dtRR = GetTariffLocalCharges(dt.Rows[0]["PODID"].ToString(), dt.Rows[0]["CommodityTypeID"].ToString(), CntrTypeID.Remove(CntrTypeID.Length - 1, 1), "1");
                        if (_dtRR.Rows.Count > 0)
                        {
                            for (int j = 0; j < _dtRR.Rows.Count; j++)
                            {


                                Cmd.CommandText = " IF((select count(*) from NVO_BLCharges where  BkgID=@BkgID and ChargeCodeID=@ChargeCodeID and TariffTypeID=@TariffTypeID and BLID=@BLID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO  NVO_BLCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                             " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                             " END  " +
                                             " ELSE " +
                                             " UPDATE NVO_BLCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                             " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID,BLID=@BLID where BkgID=@BkgID and ChargeCodeID=@ChargeCodeID and TariffTypeID=@TariffTypeID and BLID=@BLID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", 0));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", 0));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtRR.Rows[j]["TariffTypeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtRR.Rows[j]["CntrType"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtRR.Rows[j]["ChargeCodeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtRR.Rows[j]["CurrencyID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtRR.Rows[j]["CollectionModeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtRR.Rows[j]["Amount"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtRR.Rows[j]["ManifestRate"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtRR.Rows[j]["CustomeRate"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtRR.Rows[j]["RateDiffernt"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtRR.Rows[j]["TariffID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }
                        }

                        DataTable _dtRR1 = GetTariffLocalCharges(dt.Rows[0]["PODID"].ToString(), dt.Rows[0]["CommodityTypeID"].ToString(), CntrTypeID.Remove(CntrTypeID.Length - 1, 1), "2");
                        if (_dtRR1.Rows.Count > 0)
                        {
                            for (int k = 0; k < _dtRR1.Rows.Count; k++)
                            {


                                Cmd.CommandText = " IF((select count(*) from NVO_BLVenCharges where  BkgID=@BkgID and ChargeCodeID=@ChargeCodeID and TariffTypeID=@TariffTypeID and BLID=@BLID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO  NVO_BLVenCharges(RTID,RRID,BkgID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID,BLID) " +
                                             " values (@RTID,@RRID,@BkgID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID,@BLID) " +
                                             " END  " +
                                             " ELSE " +
                                             " UPDATE NVO_BLVenCharges SET RTID=@RTID,RRID=@RRID,BkgID=@BkgID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID," +
                                             " ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID,BLID=@BLID where BkgID=@BkgID and ChargeCodeID=@ChargeCodeID and TariffTypeID=@TariffTypeID and BLID=@BLID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", 0));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RTID", 0));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtRR1.Rows[k]["TariffTypeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtRR1.Rows[k]["CntrType"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtRR1.Rows[k]["ChargeCodeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtRR1.Rows[k]["CurrencyID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtRR1.Rows[k]["CollectionModeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtRR1.Rows[k]["Amount"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtRR1.Rows[k]["ManifestRate"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtRR1.Rows[k]["CustomeRate"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtRR1.Rows[k]["RateDiffernt"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtRR1.Rows[k]["TariffID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }
                        }

                    }

                    trans.Commit();
                    MyList.Add(new MyRRRate { AlertMessage = "Tariff Fetched sucessfully" });
                    return MyList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    MyList.Add(new MyRRRate { AlertMessage =ex.Message });
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


        public DataTable GetImportBookingValue(string BkgId)
        {
            string _Query = "select * from NVO_Booking where Id=" + BkgId;
            return GetViewData(_Query, "");
        }

        public DataTable GetImportCntrIdValue(string BkgId)
        {
            string _Query = "select (select top(1)TypeID from NVO_Containers where NVO_Containers.ID=NVO_BOLCntrDetails.CntrID) as TypeID from NVO_BOLCntrDetails where BkgId=" + BkgId;
            return GetViewData(_Query, "");
        }


        public DataTable GetTariffLocalCntrType(string CntrID)
        {
            string _Query = "select TypeID from NVO_Containers where Id in (" + CntrID + ")";
            return GetViewData(_Query, "");
        }

        public DataTable GetTariffLocalCharges(string PortID, string CommodityID, string CntrTypeID, string ChargeTypeID)
        {
            string _Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID as TariffID, CntrID as CntrType, ChargeCodeID, TraiffRegular as TariffTypeID,CurrencyID, CollectionModeID, " +
                            " Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt,CommodityTypeID,ChargeTypeID,CntrID " +
                            " from NVO_PortTariffMaster " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where(PortLocationID = " + PortID + ") and TraiffRegular in (136, 137, 138) and CollectionModeID = 19  and CommodityTypeID = " + CommodityID + " and CntrID in (" + CntrTypeID + ") and ChargeTypeID=" + ChargeTypeID;
            return GetViewData(_Query, "");
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
    }
}

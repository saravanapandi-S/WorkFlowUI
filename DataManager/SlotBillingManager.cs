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
    public class SlotBillingManager
    {
        #region Constructor Method
        public SlotBillingManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion


        #region SlotBilling
        public List<MySlotBill> SlotBillingByVesVoy(MySlotBill Data)
        {
            List<MySlotBill> ViewList = new List<MySlotBill>();
            DataTable dt = GetSlotBillingByVesVoy(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MySlotBill
                {
                    BkgID = dt.Rows[i]["BkgID"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    SlotContract = dt.Rows[i]["SlotContract"].ToString(),
                    SlotOperatorID = dt.Rows[i]["SlotOperatorID"].ToString(),
                    SlotContractID = dt.Rows[i]["SlotContractID"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    ROE = dt.Rows[i]["ROE"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    LocalAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetSlotBillingByVesVoy(MySlotBill Data)
        {
            string _Query = "Select Distinct NVO_Booking.ID as BkgID,RRID,BookingNo,NVO_BOL.ID as BLID,(select top 1  SlotRef from NVO_SLOTMaster Where ID = SlotContractID) As SlotContract, (select top 1  CustomerName from NVO_CustomerMaster Where ID = SlotOperatorID) As SlotOperator, SlotOperatorID, SlotContractID, (select top 1  Qty from NVO_BookingCntrTypes Where BKgID = NVO_Booking.ID) As Qty,VesVoy,VesVoyID, " +
            
         " (select top 1  Size from NVO_BookingCntrTypes inner join NVO_tblCntrTypes ct ON ct.ID = NVO_BookingCntrTypes.CntrTypes Where BKgID = NVO_Booking.ID) As Size," +
         " (select top 1  ct.ID from NVO_BookingCntrTypes inner join NVO_tblCntrTypes ct ON ct.ID = NVO_BookingCntrTypes.CntrTypes Where BKgID = NVO_Booking.ID) As CntrTypeID," +
         " CTQ20, CTQ40, SlotAmt20, SlotAmt40, (SlotAmt20+SlotAmt40) * (select top 1  Qty from NVO_BookingCntrTypes Where BKgID = NVO_Booking.ID) as Amount," +
        
         " case when NVO_SLOTDDtls.CurrencyID = 1 then 1 else (select top(1) Rate from NVO_ExRate where FromCurrency = NVO_SLOTDDtls.CurrencyID  order by Date desc) end as ROE, " +

        " (select top 1  CurrencyCode from NVO_SLOTDDtls inner join NVO_CurrencyMaster cm on cm.ID = NVO_SLOTDDtls.CurrencyID Where SlotContractID = SlotContractID) As Currency, " +

        " (select top 1  cm.ID from NVO_SLOTDDtls inner join NVO_CurrencyMaster cm on cm.ID = NVO_SLOTDDtls.CurrencyID Where SlotContractID = SlotContractID) As CurrencyID, " +

        " cast((SlotAmt20+SlotAmt40) * (select top 1  Qty from NVO_BookingCntrTypes  Where BKgID = NVO_Booking.ID) * (case when NVO_SLOTDDtls.CurrencyID = 1 then 1 else (select top(1) Rate from NVO_ExRate where FromCurrency = NVO_SLOTDDtls.CurrencyID   order by Date desc) end) AS DECIMAL(10,2)) as LocalAmount , "+

        " (select top 1  FileName from NVO_SlotBillAttachments Where BLID=NVO_BOL.ID) As FileName from NVO_Booking inner join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID " +
        " inner join NVO_SLOTMaster on NVO_SLOTMaster.ID = NVO_Booking.SlotContractID  inner join NVO_SLOTDDtls on NVO_SLOTDDtls.SLID = NVO_SLOTMaster.ID "+
        " where NVO_Booking.SlotOperatorID =" + Data.SlotOperatorID + " and NVO_Booking.VesVoyID =" + Data.VesVoyID + " and NVO_BOL.Status = 2 and ISNULL(NVO_BOL.IsSlotBill,0) != 1 ";


            return GetViewData(_Query, "");
        }

        public List<MySlotBill> InsertSlotBillAttachments(MySlotBill Data)
        {
            List<MySlotBill> ViewList = new List<MySlotBill>();
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
                    string[] Array = Data.ItemsBLIDs.TrimEnd(',').Split(',');

                    for (int i = 0; i < Array.Length; i++)
                    {

                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = "INSERT INTO  NVO_SlotBillAttachments(BLID,FileName,UploadedOn,UploadedBy,AgencyID) " + " values (@BLID,@FileName,@UploadedOn,@UploadedBy,@AgencyID)";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BKGID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", Data.FileName));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", Data.UploadedBy));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ViewList;
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


        public List<MySlotBill> VendorInvoiceSlotBillingInsert(MySlotBill Data)
        {
            List<MySlotBill> List = new List<MySlotBill>();

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


                    string AutoGen = "";
                    if (Data.VendorInvTypes == "1")
                    {
                        AutoGen = GetMaxseqNumber("SlotBill", Data.GeoLocID.ToString(), Data.SessionFinYear);

                        Cmd.CommandText = "select 'SVIN' + ('" + Data.SessionFinYear + "') + '0000' + convert(varchar(10), " + AutoGen + ")'" + Data.AgentCode + "'";
                     
                        Data.VendorInvNo = Cmd.ExecuteScalar().ToString();

                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_InvoiceVenBilling where  ID=@ID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_InvoiceVenBilling(InvoiceNo,InvDate,InvTypes,InvTax,InvAmount,InvTotal,TotalAmountUSD,LocalTotalAmount,GeoLocID,IsActive,CurrencyID,CurrentDate,UserID,AgentId,AgentCode,SessionFinYear,PartyID,PartyName,IsApproved) " +
                                 " values(@InvoiceNo,@InvDate,@InvTypes,@InvTax,@InvAmount,@InvTotal,@TotalAmountUSD,@LocalTotalAmount,@GeoLocID,@IsActive,@CurrencyID,@CurrentDate,@UserID,@AgentId,@AgentCode,@SessionFinYear,@PartyID,@PartyName,@IsApproved)  " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_InvoiceVenBilling SET InvoiceNo=@InvoiceNo,InvDate=@InvDate,InvTax=@InvTax,InvTypes=@InvTypes,InvTotal=@InvTotal,InvAmount=@InvAmount,TotalAmountUSD=@TotalAmountUSD,LocalTotalAmount=@LocalTotalAmount,GeoLocID=@GeoLocID,IsActive=@IsActive,CurrentDate=@CurrentDate,UserID=@UserID,CurrencyID=@CurrencyID,AgentId=@AgentId,AgentCode=@AgentCode,SessionFinYear=@SessionFinYear,PartyID=@PartyID,PartyName=@PartyName,IsApproved=@IsApproved where ID=@ID";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvoiceNo", Data.VendorInvNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDate", System.DateTime.Now.Date));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTypes", Data.VendorInvTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTax", "0.00"));
                     Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", Data.CurrencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.SlotOperatorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvAmount", Data.LocalTotalAmount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", Data.SlotOperator));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTotal", Data.LocalTotalAmount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalAmountUSD", Data.TotalAmountUSD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalTotalAmount", Data.LocalTotalAmount));
                      Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsActive", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentCode", Data.AgentCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SessionFinYear", Data.SessionFinYear));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsApproved", 23));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select Ident_current('NVO_InvoiceVenBilling')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    }

                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                      
                      
                        Cmd.CommandText = " IF((select count(*) from NVO_InvoiceVenBillingdtls where InvCusBillingID=@InvCusBillingID  AND BLInvID =@BLInvID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_InvoiceVenBillingdtls(InvCusBillingID,BLInvID,BkgID,SlotOperatorID,SlotOperator,SlotContractID,SlotContract,BookingNo,VoyageID,VesVoy,CurrencyID,Currency,ROE,CntrTypeID,CntrType,Qty,Amount,LocalAmount,FileName) " +
                                     " values (@InvCusBillingID,@BLInvID,@BkgID,@SlotOperatorID,@SlotOperator,@SlotContractID,@SlotContract,@BookingNo,@VoyageID,@VesVoy,@CurrencyID,@Currency,@ROE,@CntrTypeID,@CntrType,@Qty,@Amount,@LocalAmount,@FileName) " +

                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_InvoiceVenBillingdtls SET InvCusBillingID=@InvCusBillingID,BLInvID=@BLInvID,BkgID=@BkgID,SlotOperatorID=@SlotOperatorID,SlotOperator=@SlotOperator, " +
                                     " SlotContractID=@SlotContractID,SlotContract=@SlotContract,BookingNo=@BookingNo,VoyageID=@VoyageID,VesVoy=@VesVoy,CurrencyID=@CurrencyID,Currency=@Currency,ROE=@ROE,CntrTypeID=@CntrTypeID,CntrType=@CntrType,Qty=@Qty,Amount=@Amount,LocalAmount=@LocalAmount,FileName=@FileName  where InvCusBillingID=@InvCusBillingID AND BLInvID =@BLInvID";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLInvID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperatorID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperator", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotContractID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotContract", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingNo", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ROE", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[13]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[14]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[15]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", CharSplit[16]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", CharSplit[17]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        Cmd.CommandText =  " UPDATE NVO_BOL SET IsSlotBill=@IsSlotBill  where ID =@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSlotBill", 1));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                        trans.Commit();

                    List.Add(new MySlotBill
                    {
                        BLID = Data.BLID,

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        public List<MySlotBill> SlotBillingView(MySlotBill Data)
        {
            List<MySlotBill> List = new List<MySlotBill>();
            DataTable dt = GetSlotBillingvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                List.Add(new MySlotBill
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VendorInvNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    SlotContract = dt.Rows[i]["SlotContract"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    TotalAmountUSD = dt.Rows[i]["TotalAmountUSD"].ToString(),
                });
            }
            return List;
        }

        public DataTable GetSlotBillingvalues(MySlotBill Data)
        {
          string _Query = "Select VI.ID,VI.InvoiceNo,(select top 1 SlotContract From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID) As SlotContract,(select top 1 VesVoy From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) As VesVoy ,"+ 
       " (select top 1 SlotOperator From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) As SlotOperator," +
        " (select top 1 Currency From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) As Currency, VI.TotalAmountUSD from NVO_InvoiceVenBilling VI WHERE VI.InvTypes=1 ";
          

            string strWhere = "";

            if (Data.VendorInvNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and VI.InVoiceNo like '%" + Data.VendorInvNo + "%'";
                else
                    strWhere += " and VI.InVoiceNo like '%" + Data.VendorInvNo + "%'";

            if (Data.VesVoyID != "" && Data.VesVoyID != "0" && Data.VesVoyID != null && Data.VesVoyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and (select top 1 VoyageID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) =" + Data.VesVoyID;
                else
                    strWhere += " and (select top 1 VoyageID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) =" + Data.VesVoyID;

            if (Data.SlotOperatorID != "" && Data.SlotOperatorID != "0" && Data.SlotOperatorID != null && Data.SlotOperatorID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and (select top 1 SlotOperatorID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID )=" + Data.SlotOperatorID;
                else
                    strWhere += " and (select top 1 SlotOperatorID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID )  =" + Data.SlotOperatorID;

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != "2" && Data.AgencyID.ToString() != "undefined" && Data.AgencyID.ToString() != null)

                if (strWhere == "")
                    strWhere += _Query + " and VI.AgentID = " + Data.AgencyID.ToString();
                else
                    strWhere += " and VI.AgentID = " + Data.AgencyID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }
        #endregion

        #region  PortBilling
        public List<MyPortBill> PortBillingBySearch(MyPortBill Data)
        {
            List<MyPortBill> ViewList = new List<MyPortBill>();
            DataTable dt = GetPortBillingBySearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPortBill
                {
                    BkgID = dt.Rows[i]["BkgID"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                   // Qty = dt.Rows[i]["Qty"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    ROE = dt.Rows[i]["ROE"].ToString(),
                   // Size = dt.Rows[i]["Size"].ToString(),
                    Amount = dt.Rows[i]["LocalAmount"].ToString(),
                    LocalAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    TaxPercentage = dt.Rows[i]["TaxPercentage"].ToString(),
                    NetAmount = dt.Rows[i]["NetAmount"].ToString(),
                    TaxAmount = dt.Rows[i]["TaxAmt"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetPortBillingBySearch(MyPortBill Data)
        {
           
            string _Query = "Select NVO_Booking.ID as BkgID,NVO_Booking.RRID,BookingNo,NVO_BOL.ID as BLID,NVO_Booking.BkgPartyID, (select top 1  CurrencyCode from NVO_CurrencyMaster Where ID = NVO_BLVenCharges.CurrencyID) As Currency,(select top 1  ID from NVO_CurrencyMaster Where ID = NVO_BLVenCharges.CurrencyID) As CurrencyID , " +
          " C.CntrNo, " +
          " (case when(select ExemptFromTax from NVO_FinCustomerCreditControl  where PartyID = (select top 1 AgentID From NVO_BLVenChargesAgentName where BkgID = NVO_Booking.ID) ) = 1 then  0 else  isnull((select top(1) TaxPercentage from NVO_ChargeTaxEngineDtls join NVO_ChgTaxDeclaration on NVO_ChgTaxDeclaration.Id = "+ 
          " NVO_ChargeTaxEngineDtls.TaxPercentageID where NVO_ChargeTaxEngineDtls.ChargeTBID = NVO_BLVenCharges.ChargeCodeID),0) end) as TaxPercentage,"+
        " (select top 1  Qty from NVO_BookingCntrTypes Where BKgID = NVO_Booking.ID) As Qty, NVO_Booking.VesVoy, NVO_Booking.VesVoyID,(select top 1  Size from NVO_BookingCntrTypes " +
        " inner join NVO_tblCntrTypes ct ON ct.ID = NVO_BookingCntrTypes.CntrTypes Where BKgID = NVO_Booking.ID) As Size,(select top 1  ct.ID from NVO_BookingCntrTypes "+
            " inner join NVO_tblCntrTypes ct ON ct.ID = NVO_BookingCntrTypes.CntrTypes Where BKgID = NVO_Booking.ID) As CntrTypeID, ISNULL(ReqRate, 0) AS LocalAmount, "+

       " CAST(ROUND(((((case when(select ExemptFromTax from NVO_FinCustomerCreditControl  where PartyID = 2733) = 1 then  0 else isnull((select top(1) TaxPercentage from NVO_ChargeTaxEngineDtls inner join NVO_ChgTaxDeclaration on NVO_ChgTaxDeclaration.Id = NVO_ChargeTaxEngineDtls.TaxPercentageID  where NVO_ChargeTaxEngineDtls.ChargeTBID = NVO_BLVenCharges.ChargeCodeID),0) end)) *((Case when cntrtype = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes "+
       "  where BKgID = NVO_BLVenCharges.BkgID and CntrTypes = CntrType) end) *ReqRate * ((case when CurrencyID = 1 then 1 else (select top(1) Rate from NVO_ExRate where ToCurrency = NVO_BLVenCharges.CurrencyID order by Date desc) end)))) / 100), 2) AS DECIMAL(10,2))   as TaxAmt, " +

       " (ISNULL(ReqRate, 0) + CAST(ROUND(((((case when(select ExemptFromTax from NVO_FinCustomerCreditControl  where PartyID = 2733) = 1 then  0 else isnull((select top(1) TaxPercentage from NVO_ChargeTaxEngineDtls inner join NVO_ChgTaxDeclaration on NVO_ChgTaxDeclaration.Id = NVO_ChargeTaxEngineDtls.TaxPercentageID  where "+
       " NVO_ChargeTaxEngineDtls.ChargeTBID = NVO_BLVenCharges.ChargeCodeID),0) end)) *((Case when cntrtype = 17 then 1 else (select top(1) Qty from NVO_BookingCntrTypes where BKgID = NVO_BLVenCharges.BkgID and CntrTypes = CntrType) end) * ReqRate * ((case when CurrencyID = 1 then 1 else (select top(1) Rate from NVO_ExRate where ToCurrency = NVO_BLVenCharges.CurrencyID order by Date desc) end)))) / 100), 2) AS DECIMAL(10,2))) as NetAmount, " +
      " (select top 1  CurrencyCode from NVO_CurrencyMaster Where ID = NVO_BLVenCharges.CurrencyID) As Currency, case when CurrencyID = NVO_BLVenCharges.CurrencyID then 1 else (select top(1) Rate from NVO_ExRate where ToCurrency = NVO_BLVenCharges.CurrencyID order by Date desc) end as ROE, "+

        " ChargeCodeID, (select top 1  ChgDesc from NVO_ChargeTB Where ID = NVO_BLVenCharges.ChargeCodeID) As ChargeCode,ISNULL((select top 1  FileName from NVO_PORTBillAttachments Where BLID = NVO_BOL.ID and ChargeCodeID=NVO_BLVenCharges.ChargeCodeID AND CntrNO= C.CntrNo),'') As FileName from NVO_Booking inner join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID inner join NVO_BLVenCharges on NVO_BLVenCharges.BkgID = NVO_Booking.ID  inner join  NVO_BOLCntrDetails BC ON BC.BkgId =NVO_Booking.ID inner join  NVO_Containers C ON C.ID = BC.CNTRID where ISNULL(NVO_BLVenCharges.IsPortBill,0) != 1  ";


            string strWhere = "";

            if (Data.VesVoyID != "" && Data.VesVoyID != "0" && Data.VesVoyID != null && Data.VesVoyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and NVO_Booking.VesVoyID =" + Data.VesVoyID;
                else
                    strWhere += " and NVO_Booking.VesVoyID =" + Data.VesVoyID;
            
            if (Data.VendorID != "" && Data.VendorID != "0" && Data.VendorID != null && Data.VendorID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and (select top 1 AgentID From NVO_BLVenChargesAgentName where BkgID = NVO_Booking.ID ) =" + Data.VendorID;
                else
                    strWhere += " and (select top 1 AgentID From NVO_BLVenChargesAgentName where BkgID = NVO_Booking.ID ) =" + Data.VendorID;

            if (Data.ChargeCodeID != "" && Data.ChargeCodeID != "0" && Data.ChargeCodeID != null && Data.ChargeCodeID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and ChargeCodeID =" + Data.ChargeCodeID;
                else
                    strWhere += " and ChargeCodeID =" + Data.ChargeCodeID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }


        public List<MyPortBill> InsertPortBillAttachments(MyPortBill Data)
        {
            List<MyPortBill> ViewList = new List<MyPortBill>();
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
                    string[] Array = Data.ItemsBLIDs.TrimEnd(',').Split(',');

                    for (int i = 0; i < Array.Length; i++)
                    {

                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = "INSERT INTO  NVO_PortBillAttachments(BLID,FileName,UploadedOn,UploadedBy,AgencyID) " + " values (@BLID,@FileName,@UploadedOn,@UploadedBy,@AgencyID)";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@BKGID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", Data.FileName));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", Data.UploadedBy));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ViewList;
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

        public List<MyPortBill> VendorInvoicePortBillingInsert(MyPortBill Data)
        {
            List<MyPortBill> List = new List<MyPortBill>();

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


                    string AutoGen = "";
                    if (Data.VendorInvTypes == "2")
                    {
                        AutoGen = GetMaxseqNumber("PortBill", Data.GeoLocID.ToString(), Data.SessionFinYear);

                        Cmd.CommandText = "select 'PVIN' + ('" + Data.SessionFinYear + "') + '0000' + convert(varchar(10), " + AutoGen + ")'" + Data.AgentCode + "'";

                        Data.VendorInvNo = Cmd.ExecuteScalar().ToString();

                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_InvoiceVenBilling where  ID=@ID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_InvoiceVenBilling(InvoiceNo,InvDate,InvTypes,InvTax,InvAmount,InvTotal,GeoLocID,IsActive,CurrentDate,UserID,AgentId,AgentCode,SessionFinYear,PartyID,PartyName,IsApproved) " +
                                 " values(@InvoiceNo,@InvDate,@InvTypes,@InvTax,@InvAmount,@InvTotal,@GeoLocID,@IsActive,@CurrentDate,@UserID,@AgentId,@AgentCode,@SessionFinYear,@PartyID,@PartyName,@IsApproved)  " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_InvoiceVenBilling SET InvoiceNo=@InvoiceNo,InvDate=@InvDate,InvTax=@InvTax,InvTypes=@InvTypes,InvTotal=@InvTotal,InvAmount=@InvAmount,GeoLocID=@GeoLocID,IsActive=@IsActive,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,AgentCode=@AgentCode,SessionFinYear=@SessionFinYear,PartyID=@PartyID,PartyName=@PartyName,IsApproved=@IsApproved where ID=@ID";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvoiceNo", Data.VendorInvNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDate", System.DateTime.Now.Date));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTypes", Data.VendorInvTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTax", Data.TaxAmount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvAmount", Data.InvoiceAmount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTotal", Data.NetAmount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.VendorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", Data.Vendor));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsActive", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentCode", Data.AgentCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SessionFinYear", Data.SessionFinYear));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsApproved", 23));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select Ident_current('NVO_InvoiceVenBilling')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    }

                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_InvoiceVenBillingdtls where InvCusBillingID=@InvCusBillingID  AND NarrationID =@NarrationID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_InvoiceVenBillingdtls(InvCusBillingID,BLInvID,BkgID,BookingNo,VoyageID,VesVoy,CurrencyID,Currency,NarrationID,NarrationDescription,ROE,RatePerUnit,Amount,LocalAmount,TaxAmt,PaxPCT,FileName) " +
                                     " values (@InvCusBillingID,@BLInvID,@BkgID,@BookingNo,@VoyageID,@VesVoy,@CurrencyID,@Currency,@NarrationID,@NarrationDescription,@ROE,@RatePerUnit,@Amount,@LocalAmount,@TaxAmt,@PaxPCT,@FileName) " +

                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_InvoiceVenBillingdtls SET InvCusBillingID=@InvCusBillingID,BLInvID=@BLInvID,BkgID=@BkgID,BookingNo=@BookingNo,VoyageID=@VoyageID,VesVoy=@VesVoy,CurrencyID=@CurrencyID,Currency=@Currency,NarrationID=@NarrationID,NarrationDescription=@NarrationDescription,ROE=@ROE,RatePerUnit=@RatePerUnit,Amount=@Amount,LocalAmount=@LocalAmount,TaxAmt=@TaxAmt,PaxPCT=@PaxPCT,FileName=@FileName  where InvCusBillingID=@InvCusBillingID AND NarrationID =@NarrationID";

                       
                        //data[key].ROE,
                        //data[key].Amount,
                        //data[key].LocalAmount,
                        //data[key].TaxPercentage,
                        //data[key].TaxAmount,
                        //data[key].NetAmount,
                        //data[key].FileName,

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLInvID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", CharSplit[1]));
                        
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingNo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerNo", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NarrationID", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NarrationDescription", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ROE", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RatePerUnit", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaxPCT", CharSplit[13]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxAmt", CharSplit[14]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", CharSplit[15]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

             
                   
                        Cmd.CommandText = " UPDATE NVO_BLVenCharges SET IsPortBill=@IsPortBill  where   ChargeCodeID =@ChargeCodeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsPortBill", 1));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    trans.Commit();

                    List.Add(new MyPortBill
                    {
                        BLID = Data.BLID,

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        public List<MyPortBill> PortBillingView(MyPortBill Data)
        {
            List<MyPortBill> List = new List<MyPortBill>();
            DataTable dt = GetPortBillingViewvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                List.Add(new MyPortBill
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VendorInvNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    Vendor = dt.Rows[i]["Vendor"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    NetAmount = dt.Rows[i]["NetAmount"].ToString(),
                });
            }
            return List;
        }

        public DataTable GetPortBillingViewvalues(MyPortBill Data)
        {
            string _Query = "Select VI.ID,VI.InvoiceNo,VI.PartyName as Vendor,(select top 1 VesVoy From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) As VesVoy ," +
         " (select top 1 NarrationDescription From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) As ChargeCode," +
          " (select top 1 Currency From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) As Currency, VI.InvTotal as NetAmount from NVO_InvoiceVenBilling VI WHERE VI.InvTypes=2 ";


            string strWhere = "";

            if (Data.VendorInvNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and VI.InVoiceNo like '%" + Data.VendorInvNo + "%'";
                else
                    strWhere += " and VI.InVoiceNo like '%" + Data.VendorInvNo + "%'";

            if (Data.VesVoyID != "" && Data.VesVoyID != "0" && Data.VesVoyID != null && Data.VesVoyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and (select top 1 VoyageID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) =" + Data.VesVoyID;
                else
                    strWhere += " and (select top 1 VoyageID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) =" + Data.VesVoyID;

            if (Data.ChargeCodeID != "" && Data.ChargeCodeID != "0" && Data.ChargeCodeID != null && Data.ChargeCodeID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and (select top 1 NarrationID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) =" + Data.ChargeCodeID;
                else
                    strWhere += " and (select top 1 NarrationID From NVO_InvoicevenBillingdtls where InvCusBillingID = VI.ID ) =" + Data.ChargeCodeID;

            if (Data.VendorID != "" && Data.VendorID != "0" && Data.VendorID != null && Data.VendorID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and VI.PartyID=" + Data.VendorID;
                else
                    strWhere += " and VI.PartyID  =" + Data.VendorID;

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != "2" && Data.AgencyID.ToString() != "undefined" && Data.AgencyID.ToString() != null)

                if (strWhere == "")
                    strWhere += _Query + " and VI.AgentID = " + Data.AgencyID.ToString();
                else
                    strWhere += " and VI.AgentID = " + Data.AgencyID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }


        public List<MyPortBill> ViewUploadPortBilling(MyPortBill Data)
        {
            List<MyPortBill> ViewList = new List<MyPortBill>();
            DataTable dt = GetViewUploadPortBilling(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPortBill
                {
                    BkgID = dt.Rows[i]["BkgID"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    CntrNo = dt.Rows[i]["ContainerNo"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    BookingNo = dt.Rows[i]["BLNo"].ToString(),
                    ChargeCode = dt.Rows[i]["Charges"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    ROE = dt.Rows[i]["ROE"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    LocalAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    TaxPercentage = dt.Rows[i]["TaxPercentage"].ToString(),
                    NetAmount = dt.Rows[i]["NetAmount"].ToString(),
                    TaxAmount = dt.Rows[i]["TaxAmount"].ToString(),
                   
                });
            }
            return ViewList;
        }

        public DataTable GetViewUploadPortBilling(MyPortBill Data)
        {

            string _Query = "Select * from NVO_TempPortBillUpload";

            return GetViewData(_Query, "");
        }

        #endregion

        #region Vendor Invoice Approval
        public List<MyPortBill> ViewBindVendorInvNoList(MyPortBill Data)
        {
            List<MyPortBill> ViewList = new List<MyPortBill>();
            DataTable dt = GetViewBindVendorInvNoList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPortBill
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VendorInvNo= dt.Rows[i]["InvoiceNo"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetViewBindVendorInvNoList(MyPortBill Data)
        {

            string _Query = "Select * from NVO_InvoicevenBilling";

            return GetViewData(_Query, "");
        }

        public List<MyPortBill> ViewVendorInvRecordsList(MyPortBill Data)
        {
            List<MyPortBill> ViewList = new List<MyPortBill>();
            DataTable dt = GetVendorInvRecordsSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPortBill
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VendorInvNo = dt.Rows[i]["InvoiceNo"].ToString(),
                     Agency = dt.Rows[i]["Agency"].ToString(),
                    Customer = dt.Rows[i]["Customer"].ToString(),
                    InvDate = dt.Rows[i]["InvDate"].ToString(),
                    Amount = dt.Rows[i]["InvAmount"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ApprovedOn = dt.Rows[i]["ApprovedOn"].ToString(),
                    ApprovedBy = dt.Rows[i]["ApprovedBy"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetVendorInvRecordsSearch(MyPortBill Data)
        {

            string _Query = " select VI.ID,VI.InvoiceNo,isnull((select top 1 AgencyName from NVO_AgencyMaster where ID = VI.AgentId) ,'')as Agency,VI.PartyName as Customer,Isnull(convert(varchar, VI.INVDATE, 103), '') as INVDATE, isnull((select top 1 CurrencyCode from NVO_CurrencyMaster where ID = VI.CurrencyID),'') as Currency, "+
          " VI.InvAmount,VI.InvTotal,Case When VI.IsApproved = 23 then 'PENDING' Else 'APPROVED' end Status, Isnull(convert(varchar, VI.ApprovedOn, 103), '') As ApprovedOn,  isnull((select top 1 UserName from NVO_UserDetails where ID = VI.ApprovedBy) ,'') as ApprovedBy  from NVO_InvoicevenBilling VI ";


            string strWhere = "";

            if (Data.VendorInvNo != "" && Data.VendorInvNo != "0" && Data.VendorInvNo != null && Data.VendorInvNo != "?")
                if (strWhere == "")
                    strWhere += _Query + " where VI.ID =" + Data.VendorInvNo;
                else
                    strWhere += " and VI.ID =" + Data.VendorInvNo;

            if (Data.VendorID != "" && Data.VendorID != "0" && Data.VendorID != null && Data.VendorID != "?")
                if (strWhere == "")
                    strWhere += _Query + " where VI.PartyID = " + Data.VendorID;
                else
                    strWhere += " and VI.PartyID  =" + Data.VendorID;

                if (Data.FromDate != "" && Data.ToDate != "")
                if (strWhere == "")
                    strWhere += _Query + " Where  VI.InVDate between '" + Data.FromDate + "' and '" + Data.ToDate + "' ";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where VI.AgentId = " + Data.AgencyID;
                else
                    strWhere += " and VI.AgentId = " + Data.AgencyID;

            if (Data.Status != "" && Data.Status != "0" && Data.Status != "?" && Data.Status != null)

                if (strWhere == "")
                    strWhere += _Query + " where VI.IsApproved = " + Data.Status;
                else
                    strWhere += " and VI.IsApproved = " + Data.Status;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }
        public List<MyPortBill> UpdateVendorInvoiceApproval(MyPortBill Data)
        {
            List<MyPortBill> List = new List<MyPortBill>();

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

                    Cmd.CommandText = " Update NVO_InvoicevenBilling Set IsApproved=24 where ID in ("+Data.Items+") ";

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                
                    trans.Commit();

                    List.Add(new MyPortBill
                    {
                        BLID = Data.BLID,

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        #endregion
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
    }
}

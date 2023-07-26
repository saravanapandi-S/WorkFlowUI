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
    public class AccountMaster
    {
        #region Constructor Method
        public AccountMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion


        public List<MyAccount> BankMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = BindBankName(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BankName = dt.Rows[i]["BankCode"].ToString()
                });
            }
            return ViewList;
        }

        public List<MyAccount> PayModeMaster()
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = BindPayMode();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PayMode = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable BindBankName(MyAccount Data)
        {
            string _Query = "select ID,BankCode from NVO_FinBankMasterDtls inner join NVO_FinBankMaster on NVO_FinBankMaster.ID = NVO_FinBankMasterDtls.BMID " +
                            " where AgencyID=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }

        public DataTable BindPayMode()
        {
            string _Query = "  SELECT * FROM NVO_GeneralMaster where Seqno =59";
            return GetViewData(_Query, "");
        }

        public List<MyAccount> ReceiptTDSMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetReceiptTDS(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Desc = dt.Rows[i]["GLDesc"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetReceiptTDS(MyAccount Data)
        {
            string _Query = " select NVO_GLMaster.ID, GLCode +'-'+ GLDesc GLDesc from NVO_ControlParameter inner join NVO_GLMaster on NVO_GLMaster.GLCode = NVO_ControlParameter.Value " +
                            " where ModuleID = 9 and NVO_ControlParameter.AgencyID=" + Data.AgencyID+ " and  NVO_ControlParameter.Parameter='TDS_RECEIPT'";
            return GetViewData(_Query, "");
        }

        public List<MyAccount> InvoiceDetailsMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvoiceDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvID = dt.Rows[i]["InvID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["TotalReceived"].ToString(),
                    TotalDue = dt.Rows[i]["TotalDue"].ToString(),
                    ReceiptAMT = dt.Rows[i]["ReceiptAMT"].ToString(),
                    TDSAMT = dt.Rows[i]["TDSAMT"].ToString(),
                    IsCheck = bool.Parse(dt.Rows[i]["IsCheck"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    ExcessAmt = dt.Rows[i]["ExcessAmt"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetInvoiceDetails(MyAccount Data)
        {

            string _Query = " SELECT DISTINCT CS.Id as InvID,FinalInvoice as InvoiceNo,(select  top(1) CurrencyCode from NVO_CurrencyMaster where Id = CurrencyID) as Currency, BLTypes,InvTypes, PartyId AS CusID, InvTotal AS InvTotal,CS.ID AS CusInvID, '2' AS CrDrType, '' as ReceiptAMT, '' as TDSAMT, " +
            " GeoLocID, isnull((SELECT SUM(ISNULL(Amount, 0)) FROM NVO_ReceiptBL WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID " +
          " AND ReceiptID  IN(SELECT R.ID FROM NVO_Receipts R WHERE  partyId =" + Data.PartyID + "  and R.ReceiptStatus = 1)),0) AS TotalReceived, isnull((ROUND(InvTotal, 0)), 0) -isnull((SELECT SUM(ISNULL(Amount, 0)) FROM NVO_ReceiptBL WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID " +
      " AND ReceiptID  IN(SELECT R.ID FROM NVO_Receipts R WHERE  partyId =" + Data.PartyID + "  and R.ReceiptStatus = 1)),0) as TotalDue,'false' as IsCheck,   (select top 1 BLNumber from NVO_BOL Where ID = CS.BLID) AS BLNumber, " +
      " CS.BLID, '0.00' as ExcessAmt FROM NVO_InvoiceCusBilling CS WHERE CS.InvoiceNo != 'NULL'  and isFinal = 1  AND PartyID =" + Data.PartyID + "  and ABS((SELECT dnd.InvTotal FROM NVO_InvoiceCusBilling dnd WHERE dnd.ID = CS.ID) -ISNULL((SELECT SUM(ISNULL(Amount, 0)) FROM v_ReceiptSetOffDR WHERE  v_ReceiptSetOffDR.InvID = CS.ID and ReceiptStatus = 1),0)) > 1  AND AgentId =" + Data.AgencyID + " ";

            return GetViewData(_Query, "");
        }

        public List<MyAccount> InvoiceSearchFromReceiptValues(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvoiceSearchFromReceiptValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvID = dt.Rows[i]["InvID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["TotalReceived"].ToString(),
                    TotalDue = dt.Rows[i]["TotalDue"].ToString(),
                    ReceiptAMT = dt.Rows[i]["ReceiptAMT"].ToString(),
                    TDSAMT = dt.Rows[i]["TDSAMT"].ToString(),
                    IsCheck = bool.Parse(dt.Rows[i]["IsCheck"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    ExcessAmt = dt.Rows[i]["ExcessAmt"].ToString(),

                });
            }
            return ViewList;
        }


        public DataTable GetInvoiceSearchFromReceiptValues(MyAccount Data)
        {

            string strWhere = "";
            string InvSearch = "";

            if (Data.InvoiceNo != "")
            {
                string[] InvNov = Data.InvoiceNo.Split(new Char[] { ',' });
                for (int i = 0; i < InvNov.Length; i++)
                    InvSearch += " FinalInvoice In  ( '" + InvNov[i] + "' )";

                //int RowsID = InvSearch.Length;
                //InvSearch = InvSearch.Remove(RowsID - 2);
            }
            string _Query = "  SELECT DISTINCT CS.Id as InvID,FinalInvoice as InvoiceNo,(select  top(1) CurrencyCode from NVO_CurrencyMaster where Id = CurrencyID) as Currency, BLTypes, InvTypes, PartyId AS CusID,(select top(1)(InvTotal - isnull((select top(1) InvTotal from NVO_InvoiceCusBilling Crinv " +
           " where Crinv.DrId = Drinv.ID), 0)) from NVO_InvoiceCusBilling Drinv  where InvTypes = 1  and Drinv.Id = CS.ID) as InvTotal, CS.ID AS CusInvID, '2' AS CrDrType, '' as ReceiptAMT,'' as TDSAMT,   GeoLocID, isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_ReceiptBL " +
           " WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID  AND ReceiptID NOT IN(SELECT R.ID FROM NVO_Receipts R WHERE partyId =" + Data.PartyID + "  and R.ReceiptStatus not in (0))),0) AS TotalReceived, isnull((ROUND((select top(1)(InvTotal - isnull((select top(1) InvTotal from NVO_InvoiceCusBilling Crinv  where Crinv.DrId = Drinv.ID), 0)) from NVO_InvoiceCusBilling Drinv  where InvTypes = 1  and Drinv.Id = CS.ID), 0)), 0) -isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_ReceiptBL WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID " +
           " AND ReceiptID NOT IN(SELECT R.ID FROM NVO_Receipts R WHERE  partyId =" + Data.PartyID + " and R.ReceiptStatus not in (0))),0) as TotalDue, 'false' as IsCheck,  (select top 1 BLNumber from NVO_BOL Where ID = CS.BLID) AS BLNumber, CS.BLID, '0.00' as ExcessAmt FROM NVO_InvoiceCusBilling CS  WHERE CS.ISFinal = 1  and InvTypes = 1  AND PartyID =" + Data.PartyID + "  and ABS(((select top(1) (InvTotal - isnull((select top(1) InvTotal from NVO_InvoiceCusBilling Crinv  where Crinv.DrId = Drinv.ID), 0))  from NVO_InvoiceCusBilling Drinv  where InvTypes = 1  and Drinv.Id = CS.ID)) -ISNULL((SELECT SUM(ISNULL(Amount, 0)) FROM v_ReceiptSetOffDR  WHERE  v_ReceiptSetOffDR.InvID = CS.ID),0)) > 1 " +
          " and  isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_ReceiptBL WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID  AND ReceiptID NOT IN(SELECT R.ID FROM NVO_Receipts R ";

            strWhere += _Query + "WHERE PartyID =" + Data.PartyID + " and R.ReceiptStatus not in (0))),0) > 1  AND AgentId =" + Data.AgencyID + " ";


            if (InvSearch != "")
                if (strWhere == "")
                    strWhere += _Query + " and " + InvSearch;
                else
                    strWhere += " and " + InvSearch;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }
        public List<MyAccount> ReceiptInvoiceOutstanding(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetReceiptInvoiceOutstanding(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["RecAmt"].ToString(),
                    TotalDue = dt.Rows[i]["OutStading"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetReceiptInvoiceOutstanding(MyAccount Data)
        {
            string _Query = "select sum(InvTotal) as InvTotal , sum(RecAmt) as RecAmt, (sum(InvTotal) - sum(RecAmt)) as OutStading  from NVO_ReceiptInvoiceOutStaingView where PartyID=" + Data.PartyID;


            return GetViewData(_Query, "");
        }
        public List<MYReceipts> InsertReceipt(MYReceipts Data)
        {
            List<MYReceipts> List = new List<MYReceipts>();
            int r1 = 0;
            int r2 = 0;
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
                        string AutoGen = GetMaxseqNumber("Receipt", Data.GeoLocID.ToString(), Data.SessionFinYear);

                        Cmd.CommandText = "select ('RV')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)+'" + Data.AgentCode + "'";
                        //Cmd.CommandText = "select (select ShortName from NV_TblGeoLocations where Id = " + Data.Office + ")+('RV') + right('000' + convert(varchar(3)," + AutoGen + "), 3) + '/' + ('" + Data.SessionFinYear + "')";
                        Data.ReceiptNo = Cmd.ExecuteScalar().ToString();
                    }
                    //  Data.ReceiptNo = "DRAFT";
                    Cmd.CommandText = " IF((select count(*) from NVO_Receipts where ReceiptNo=@ReceiptNo)<=0) " +
                 " BEGIN " +
                 " INSERT INTO  NVO_Receipts(ReceiptNo,DtReceipt,GeoLocID,PartyID,PartyName,ReceiptTypes,ReceiptStatus,Remarks,Is3rdParty,IsTDS,IsBankRec,ThirdPartyID,ThirdPartyName,PaymentTypes,Bank,BankName,Currency,ExRate,Amount,LocalAmount,PaymentDate,Reference,DrawerBank,DrawerBankBranch,RoundOffTypeID,GLCodeID,ExcessTariffAmt,ExcessLocalAmt,UserID,AgencyID) " +
                 " values(@ReceiptNo,@DtReceipt,@GeoLocID,@PartyID,@PartyName,@ReceiptTypes,@ReceiptStatus,@Remarks,@Is3rdParty,@IsTDS,@IsBankRec,@ThirdPartyID,@ThirdPartyName,@PaymentTypes,@Bank,@BankName,@Currency,@ExRate,@Amount,@LocalAmount,@PaymentDate,@Reference,@DrawerBank,@DrawerBankBranch,@RoundOffTypeID,@GLCodeID,@ExcessTariffAmt,@ExcessLocalAmt,@UserID,@AgencyID)  " +
                 " END  " +
                 " ELSE " +
                 " UPDATE NVO_Receipts SET ReceiptNo=@ReceiptNo,DtReceipt=@DtReceipt,GeoLocID=@GeoLocID," +
                 " PartyID=@PartyID,PartyName=@PartyName,ReceiptTypes=@ReceiptTypes,ReceiptStatus=@ReceiptStatus,Remarks=@Remarks,Is3rdParty=@Is3rdParty,IsTDS=@IsTDS,IsBankRec=@IsBankRec,ThirdPartyID=@ThirdPartyID,ThirdPartyName=@ThirdPartyName,PaymentTypes=@PaymentTypes,Bank=@Bank,BankName=@BankName,Currency=@Currency,ExRate=@ExRate,Amount=@Amount,LocalAmount=@LocalAmount,PaymentDate=@PaymentDate,Reference=@Reference,DrawerBank=@DrawerBank,DrawerBankBranch=@DrawerBankBranch,RoundOffTypeID=@RoundOffTypeID,GLCodeID=@GLCodeID,ExcessTariffAmt=@ExcessTariffAmt,ExcessLocalAmt=@ExcessLocalAmt,UserID=@UserID,AgencyID=@AgencyID where ReceiptNo=@ReceiptNo";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("ReceiptNo", Data.ReceiptNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtReceipt", Data.DtReceipt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.PartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", Data.PartyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptTypes", Data.ReceiptTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptStatus", Data.ReceiptStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Is3rdParty", Data.Is3rdParty));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsTDS", Data.IsTDS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBankRec", Data.IsBankRec));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ThirdPartyID", Data.ThirdPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ThirdPartyName", Data.ThirdPartyName));

                    //----Collection Details---
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTypes", Data.PaymentTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Bank", Data.Bank));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BankName", Data.BankName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", Data.Currency));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", Data.ExRate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", Data.Amount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", Data.LocAmount));
                    if (Data.PaymentDate != DateTime.MinValue.ToString())
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentDate", Data.PaymentDate));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentDate", DBNull.Value));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reference", Data.Reference));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DrawerBank", Data.DrawerBank));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DrawerBankBranch", Data.DrawerBranch));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoundOffTypeID", Data.RoundOffTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLCodeID", Data.RoundOffGLCodeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExcessTariffAmt", Data.RoundOffTariffAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExcessLocalAmt", Data.RoundOffLocAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    //----end -----

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Receipts')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    if (Data.ReceiptTypes == "194")
                    {
                        string[] Array = Data.InvItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_ReceiptBL WHERE ReceiptID=@ReceiptID and InvCusBillingID=@InvCusBillingID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO NVO_ReceiptBL (ReceiptID,InvCusBillingID,Amount,TDSAmt,BLID,TDS)" +
                                             " values (@ReceiptID,@InvCusBillingID,@Amount,@TDSAmt,@BLID,@TDS) " +
                                             " END " +
                                             " ELSE " +
                                             " UPDATE NVO_ReceiptBL SET ReceiptID=@ReceiptID,InvCusBillingID=@InvCusBillingID,Amount=@Amount,TDSAmt=@TDSAmt,BLID=@BLID,TDS=@TDS " +
                                             " WHERE ReceiptID=@ReceiptID and InvCusBillingID=@InvCusBillingID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TDSAmt", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TDS", CharSplit[4]));
                           
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }

                    }

                    Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_ReceiptWirteoff WHERE ReceiptID=@ReceiptID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO NVO_ReceiptWirteoff (ReceiptID,AccountName,PayTypes,DeffAmount)" +
                                 " values (@ReceiptID,@AccountName,@PayTypes,@DeffAmount) " +
                                 " END " +
                                 " ELSE " +
                                 " UPDATE NVO_ReceiptWirteoff SET ReceiptID=@ReceiptID,AccountName=@AccountName,PayTypes=@PayTypes,DeffAmount=@DeffAmount WHERE ReceiptID=@ReceiptID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AccountName", Data.AccountName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PayTypes", Data.PaymentTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeffAmount", Data.DeffRoundoff));

                    Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    //string[] Array1 = Data.InvCollItems.Split(new[] { "Insert:" }, StringSplitOptions.None);

                    //for (int i = 1; i < Array1.Length; i++)
                    //{
                    //    var CharSplit1 = Array1[i].ToString().TrimEnd(',').Split(',');

                    //    Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_ReceiptDtls WHERE ReceiptID=@ReceiptID)<=0) " +
                    //                     " BEGIN " +
                    //                     " INSERT INTO NVO_ReceiptDtls (ReceiptID,PaymentType,PaymentTypeID,UTRReference,ClearanceDate,BankName,BankID,Currency,CurrencyID,ExRate,CollectionAmt,LocalAmount)" +
                    //                     " values (@ReceiptID,@PaymentType,@PaymentTypeID,@UTRReference,@ClearanceDate,@BankName,@BankID,@Currency,@CurrencyID,@ExRate,@CollectionAmt,@LocalAmount) " +
                    //                     " END " +
                    //                     " ELSE " +
                    //                     " UPDATE NVO_ReceiptDtls SET ReceiptID=@ReceiptID,PaymentType=@PaymentType,PaymentTypeID=@PaymentTypeID,UTRReference=@UTRReference,ClearanceDate=@ClearanceDate,BankName=@BankName,BankID=@BankID,Currency=@Currency,CurrencyID=@CurrencyID,ExRate=@ExRate,CollectionAmt=@CollectionAmt,LocalAmount=@LocalAmount " +
                    //                     " WHERE ReceiptID=@ReceiptID ";
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptID", Data.ID));
                    //   // Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", CharSplit1[0]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentType", CharSplit1[0]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTypeID", CharSplit1[1]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@UTRReference", CharSplit1[2]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@ClearanceDate", DateTimeOffset.ParseExact(CharSplit1[3], "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(India Standard Time)'", CultureInfo.InvariantCulture)));

                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@BankName", CharSplit1[4]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@BankID", CharSplit1[5]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", CharSplit1[6]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit1[7]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", CharSplit1[8]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAmt", CharSplit1[9]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", CharSplit1[10]));
                    //    result = Cmd.ExecuteNonQuery();
                    //    Cmd.Parameters.Clear();

                    //}

                   

                    trans.Commit();

                    List.Add(new MYReceipts
                    {
                        ID = Data.ID,

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

        public List<MYReceipts> ReceiptsSearch(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetReceiptDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    DtReceipt = dt.Rows[i]["RecDate"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    LocAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    PaymentTypes = dt.Rows[i]["PaymentType"].ToString()
               

                });
            }
            return ViewList;
        }

        public DataTable GetReceiptDetails(MYReceipts Data)
        {

            string strWhere = "";
            string _Query = " Select ID,ReceiptNo, convert(varchar, DtReceipt, 103) as RecDate,PartyName, " +
                            " case when ReceiptCatgory = 1 then 'LOCAL' else 'OVERSEAS'  end as RecTypes ,case when ReceiptTypes = 193 then 'ON ACCOUNT'  when ReceiptTypes = 194 then 'BILL PAYMENT'  else 'UN DEPOSIT ACCOUNT' end as PaymentType,LocalAmount " +
                            " from NVO_Receipts";

            strWhere += _Query + " where ReceiptStatus in (1)";
            if (Data.ReceiptNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and ReceiptNo like '%" + Data.ReceiptNo + "%'";
                else
                    strWhere += " and ReceiptNo like '%" + Data.ReceiptNo + "%'";

            if (Data.PartyID != "" && Data.PartyID  != "0" && Data.PartyID  != null && Data.PartyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and PartyID = " + Data.PartyID;
                else
                    strWhere += " and  PartyID = " + Data.PartyID;

            if (Data.ReceiptTypes != "" && Data.ReceiptTypes != "0" && Data.ReceiptTypes != null && Data.ReceiptTypes != "?")
                if (strWhere == "")
                    strWhere += _Query + " and ReceiptTypes = " + Data.ReceiptTypes;
                else
                    strWhere += " and  ReceiptTypes = " + Data.ReceiptTypes;

            if (Data.DtReceipt != "")
                if (strWhere == "")
                    strWhere += _Query + " and DtReceipt <= ' " + Data.DtReceipt + "'";
                else
                    strWhere += " and DtReceipt  <= ' " + Data.DtReceipt + "'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where AgencyID = " + Data.AgencyID;
                else
                    strWhere += " and AgencyID = " + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");
        }

        public List<MYReceipts> Receiptsvalues(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetReceiptValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    DtReceipt = dt.Rows[i]["DtReceipt"].ToString(),
                    Office = dt.Rows[i]["Office"].ToString(),
                    ReceiptTypes = dt.Rows[i]["ReceiptTypes"].ToString(),
                    Payment = dt.Rows[i]["Payment"].ToString(),
                    PaymentTypes = dt.Rows[i]["PaymentTypes"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),
                    LocAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    PaymentDate = dt.Rows[i]["PaymentDate"].ToString(),
                    PartyID = dt.Rows[i]["PartyID"].ToString(),
                    Reference = dt.Rows[i]["Reference"].ToString(),
                    BankName = dt.Rows[i]["BankName"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetReceiptValue(MYReceipts Data)
        {

            string _Query = " Select * from NVO_Receipts where ID=" + Data.ID;

           
            return GetViewData(_Query, "");
        }


        public List<MyAccount> ReceiptAmuntDetails(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetReceiptAmountValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvID = dt.Rows[i]["InvID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["TotalReceived"].ToString(),
                    TotalDue = dt.Rows[i]["TotalDue"].ToString(),
                    ReceiptAMT = dt.Rows[i]["ReceiptAMT"].ToString(),
                    TDSAMT = dt.Rows[i]["TDSAMT"].ToString(),
                    IsCheck = bool.Parse(dt.Rows[i]["IsCheck"].ToString())
                });
            }
            return ViewList;
        }


        public DataTable GetReceiptAmountValue(MyAccount Data)
        {

            string _Query = " Select InvCusBillingId as InvID, (select InvoiceNo from NVO_InvoiceCusBilling where Id = InvCusBillingId) as InvoiceNo,  " +
                            "  (select InvTotal from NVO_InvoiceCusBilling where Id = InvCusBillingId) as InvTotal, Amount as TotalReceived,  " +
                            " Amount as ReceiptAMT, TDSAMT,'' TotalDue,'true' as IsCheck from  NVO_ReceiptBL where ReceiptID = " + Data.ID;


            return GetViewData(_Query, "");
        }

        public List<MyAccount> ReceiptPartyTanNoDetails(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetReceiptPartyTanNoDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    TanNo = dt.Rows[i]["TanNumber"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetReceiptPartyTanNoDetails(MyAccount Data)
        {

            string _Query = " Select  CID,Isnull(TanNo,'') As TanNumber from  NVO_CusBranchLocation where CID = " + Data.ID;


            return GetViewData(_Query, "");
        }

        public List<MyAccount> RoundOffDetailsData(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetRoundOffDetailsData(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRoundOffDetailsData(MyAccount Data)
        {

            string _Query = "SELECT NVO_GLMaster.ID,(GLCODE +'-'+ GLDESC ) AS GLCode from NVO_ControlParameter CP INNER JOIN NVO_GLMaster ON NVO_GLMaster.ID = CP.GLCodeID where CP.AgencyID = " + Data.AgencyID + " AND CP.Parameter =  '" + Data.RoundOffParameter + "' ";



            return GetViewData(_Query, "");
        }

        public List<MyAccount> RoundOffGLCodeMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetRoundOffGLCodeMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRoundOffGLCodeMaster(MyAccount Data)
        {

            string _Query = "SELECT NVO_GLMaster.ID,(GLCODE +'-'+ GLDESC ) AS GLCode from NVO_ControlParameter CP INNER JOIN NVO_GLMaster ON NVO_GLMaster.ID = CP.GLCodeID where CP.AgencyID = " + Data.AgencyID + " AND  CP.Parameter in ( 'RCT_ST_ROUND_OFF','RCT_EX_ROUND_OFF') ";



            return GetViewData(_Query, "");
        }
        public List<MyAccount> RoundOffGenMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetRoundOffGenMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RoundOffParameter = dt.Rows[i]["GeneralName"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRoundOffGenMaster(MyAccount Data)
        {

          string _Query = "select * from NVO_GeneralMaster WHERE SEQNO=53";



            return GetViewData(_Query, "");
        }

        public List<MyAccount> ExRateByAgencyMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetExRateByAgencyMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ExRate = dt.Rows[i]["Rate"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetExRateByAgencyMaster(MyAccount Data)
        {

            string _Query = "select TOP 1 ID,isnull(Rate,0.00) as Rate from NVO_ExRate where AgencyID ="+Data.AgencyID+ " AND FromCurrency=" + Data.Currency + "  and Date <= GETDATE() ORDER BY ID DESC ";



            return GetViewData(_Query, "");
        }
        public List<MyAccount> InvSetoffDR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvoiceSetOffDr(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    VoucherType = dt.Rows[i]["VoucherType"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    AmountLocal = dt.Rows[i]["AmountLocal"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjustmentAmt"].ToString(),
                    ReceivedAmt = dt.Rows[i]["ReceivedAmt"].ToString(),
                    DRIsFinal = dt.Rows[i]["DRIsFinal"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    AvailableAmt = dt.Rows[i]["AdjustmentAmt"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetInvoiceSetOffDr(MyAccount Data)
        {
            //string _Query = " select ID,finalInvoice as VoucherNo, 'InvoiceNo' as VoucherType,(select top(1) CurrencyCode from NVO_CurrencyMaster where Id= CurrencyID) as Currency,InvTotal as Amount, InvTotal as AmountLocal, '' as AdjustmentAmt, 'false' as DRIsFinal from NVO_InvoiceCusBilling " +
            //                " where PartyID = "+ Data.PartyID +" and Id not in(select InvCusBillingId from NVO_Receipts " +
            //                " inner join NVO_ReceiptBL on NVO_ReceiptBL.ReceiptID = NVO_Receipts.ID  where ReceiptStatus = 1 and PartyID = " + Data.PartyID + ") " +
            //                " and Id not in (select VoucherID from NVO_financeInvoiceSetOff " +
            //                " inner join NVO_financeInvoiceSetOffDR on NVO_financeInvoiceSetOffDR.InvID = NVO_financeInvoiceSetOff.Id where IntAccountID = " + Data.PartyID + "  and Isactive = 0)";

            string _Query = " select ID, finalInvoice as VoucherNo, 'InvoiceNo' as VoucherType, InvTotal as Amount, InvTotal as AmountLocal,isnull((select sum(Amount) from v_ReceiptSetOffDR where InvID = NVO_InvoiceCusBilling.id),0) as ReceivedAmt,  " +
                            " isnull(InvTotal, 0) - isnull((select sum(Amount) from v_ReceiptSetOffDR where InvID = NVO_InvoiceCusBilling.id and v_ReceiptSetOffDR.VoucherTypesDR = 1),0) as AdjustmentAmtv,'' as AdjustmentAmt, " +
                            " 1 as VoucherTypesDR,'0' as DRIsFinal,(select top(1) CurrencyCode from NVO_CurrencyMaster where Id= CurrencyID) as Currency  from NVO_InvoiceCusBilling where PartyID = " + Data.PartyID + "  and IsFinal = 1 and ABS((SELECT dnd.InvTotal FROM NVO_InvoiceCusBilling dnd WHERE dnd.ID = NVO_InvoiceCusBilling.ID) -ISNULL((SELECT SUM(ISNULL(Amount, 0)) FROM v_ReceiptSetOffDR " +
                            " WHERE  v_ReceiptSetOffDR.InvID = NVO_InvoiceCusBilling.ID),0)) > 1";

            return GetViewData(_Query, "");
        }

        public List<MyAccount> InvSetoffCR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvoiceSetOffCr(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    VoucherType = dt.Rows[i]["VoucherType"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["ReceivedAmt"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjAmount"].ToString(),
                    CRIsFinal = dt.Rows[i]["CRIsFinal"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    AvailableAmt = dt.Rows[i]["AdjAmount"].ToString(),

                });
            }
            return ViewList;
        }
        public DataTable GetInvoiceSetOffCr(MyAccount Data)
        {
            string _Query = " select ID, 'RECEIPTS' as VoucherType, VoucherNo, Currency,Amount, (isnull(AdjAmount, 0)) as ReceivedAmt,(Amount - (isnull(AdjAmount, 0))) as AdjAmountv,'' as AdjAmount,'0' as CRIsFinal " +
                            " from V_SetOffReceiptValue where  (Amount - (isnull(AdjAmount, 0))) > 5  and PartyID =" + Data.PartyID;

            return GetViewData(_Query, "");
        }




        public List<MyAccount> InsertFinanceInvoiceSet(MyAccount Data)
        {
            List<MyAccount> List = new List<MyAccount>();
            int r1 = 0;
            int r2 = 0;
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
                        string AutoGen = GetMaxseqNumber("InvSetoff", Data.GeoLocID.ToString(), Data.SessionFinYear);

                        Cmd.CommandText = "select ('ISO')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.ReferenceNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_financeInvoiceSetOff where ID=@ID)<=0) " +
                    " BEGIN " +
                    " INSERT INTO  NVO_financeInvoiceSetOff(IntAccountID,StrAccount,Reference,VoucherDate,TotalDR,TotalCR,IsActive) " +
                    " values(@IntAccountID,@StrAccount,@Reference,@VoucherDate,@TotalDR,@TotalCR,@IsActive)  " +
                    " END  " +
                    " ELSE " +
                    " UPDATE NVO_financeInvoiceSetOff  SET IntAccountID=@IntAccountID,StrAccount=@StrAccount,Reference=@Reference,VoucherDate=@VoucherDate,TotalDR=@TotalDR,TotalCR=@TotalCR,IsActive=@IsActive where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IntAccountID", Data.AccountNameID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StrAccount", Data.AccountName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reference", Data.ReferenceNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherDate", Data.VoucherDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalDR", Data.TotalDR));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalCR", Data.TotalCR));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsActive", Data.IsActive));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_financeInvoiceSetOff')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    string[] Array = Data.DRItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_financeInvoiceSetOffDR WHERE InvID=@InvID and VoucherID=@VoucherID)<=0) " +
                                                               " BEGIN " +
                                                               " INSERT INTO NVO_financeInvoiceSetOffDR(InvID,VoucherNo,VoucherID,Amount,AmountLocal,AdjustmentAmt)" +
                                                               " values (@InvID,@VoucherNo,@VoucherID,@Amount,@AmountLocal,@AdjustmentAmt) " +
                                                               " END " +
                                                               " ELSE " +
                                                               " UPDATE NVO_financeInvoiceSetOffDR SET InvID=@InvID,VoucherNo=@VoucherNo,VoucherID=@VoucherID,Amount=@Amount,AmountLocal=@AmountLocal,AdjustmentAmt=@AdjustmentAmt WHERE InvID=@InvID and VoucherID=@VoucherID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AmountLocal", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AdjustmentAmt", CharSplit[4]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayCr = Data.CRItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayCr.Length; i++)
                    {
                        var CharSplit = ArrayCr[i].ToString().TrimEnd(',').Split(',');



                        Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_financeInvoiceSetOffCR WHERE InvID=@InvID and VoucherID=@VoucherID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO NVO_financeInvoiceSetOffCR(InvID,VoucherNo,VoucherID,Amount,AmountLocal,AdjAmount)" +
                                        " values (@InvID,@VoucherNo,@VoucherID,@Amount,@AmountLocal,@AdjAmount) " +
                                        " END " +
                                        " ELSE " +
                                        " UPDATE NVO_financeInvoiceSetOffCR SET InvID=@InvID,VoucherNo=@VoucherNo,VoucherID=@VoucherID,Amount=@Amount,AmountLocal=@AmountLocal,AdjAmount=@AdjAmount WHERE InvID=@InvID and VoucherID=@VoucherID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AmountLocal", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AdjAmount", CharSplit[4]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();

                    List.Add(new MyAccount
                    {
                        ID = Data.ID,

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



        public List<MyAccount> InsertFinanceUnmatching(MyAccount Data)
        {
            List<MyAccount> List = new List<MyAccount>();
            int r1 = 0;
            int r2 = 0;
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

                    string AutoGen = GetMaxseqNumber("InvSetoffUnMatching", Data.GeoLocID.ToString(), Data.SessionFinYear);
                    Cmd.CommandText = "select ('UNISO')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                    Data.ReferenceNo = Cmd.ExecuteScalar().ToString();
                    Cmd.CommandText = " UPDATE NVO_financeInvoiceSetOff  SET UnMatchReference=@UnMatchReference,UnMatchDate=@UnMatchDate,IsActive=@IsActive where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UnMatchReference", Data.ReferenceNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UnMatchDate", Data.VoucherDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsActive", Data.IsActive));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    List.Add(new MyAccount
                    {
                        ID = Data.ID,

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




        public List<MyAccount> InvoiceSetOffSearch(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvSetOffSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountName = dt.Rows[i]["StrAccount"].ToString(),
                    ReferenceNo = dt.Rows[i]["Reference"].ToString(),
                    VoucherDate = dt.Rows[i]["VoucherDate"].ToString()
                
                });
            }
            return ViewList;
        }

        public DataTable GetInvSetOffSearch(MyAccount Data)
        {
            string strWhere = "";
            string _Query = " select Id, StrAccount, Reference, convert(varchar, VoucherDate, 103) as VoucherDate from NVO_financeInvoiceSetOff";
            strWhere += _Query + " where Isactive=0";

            if (Data.VoucherNo.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where StrAccount like '%" + Data.VoucherNo.Trim() + "%'";
                else
                    strWhere += " and StrAccount like '%" + Data.VoucherNo.Trim() + "%'";

            if (Data.ReferenceNo.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where Reference like '%" + Data.ReferenceNo.Trim() + "%'";
                else
                    strWhere += " and Reference like '%" + Data.ReferenceNo.Trim() + "%'";

            if (Data.VoucherDate.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where VoucherDate= '" + DateTime.Parse((Data.VoucherDate)).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and VoucherDate= '" + DateTime.Parse((Data.VoucherDate)).ToString("MM/dd/yyyy") + "'";



            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere + " order by Id desc", "");
        }



        public List<MyAccount> InvoiceSetOffUnmatchedSearch(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvSetOffUnMatchedSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountName = dt.Rows[i]["StrAccount"].ToString(),
                    ReferenceNo = dt.Rows[i]["Reference"].ToString(),
                    VoucherDate = dt.Rows[i]["VoucherDate"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetInvSetOffUnMatchedSearch(MyAccount Data)
        {
            string strWhere = "";
            string _Query = " select Id, StrAccount, UnMatchReference as Reference, convert(varchar, UnMatchDate, 103) as VoucherDate from NVO_financeInvoiceSetOff";
            strWhere += _Query + " where Isactive=1";

            if (Data.VoucherNo.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where StrAccount like '%" + Data.VoucherNo.Trim() + "%'";
                else
                    strWhere += " and StrAccount like '%" + Data.VoucherNo.Trim() + "%'";

            if (Data.ReferenceNo.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where UnMatchReference like '%" + Data.ReferenceNo.Trim() + "%'";
                else
                    strWhere += " and UnMatchReference like '%" + Data.ReferenceNo.Trim() + "%'";

            if (Data.VoucherDate.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where UnMatchDate= '" + DateTime.Parse((Data.VoucherDate)).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and UnMatchDate= '" + DateTime.Parse((Data.VoucherDate)).ToString("MM/dd/yyyy") + "'";



            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere + " order by Id desc", "");
        }


        public List<MyAccount> InvoiceSetOffExisting(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvSetOffExistingValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountNameID = dt.Rows[i]["IntAccountID"].ToString(),
                    ReferenceNo = dt.Rows[i]["Reference"].ToString(),
                    VoucherDate = dt.Rows[i]["VoucherDate"].ToString(),
                    TotalDR = dt.Rows[i]["TotalDR"].ToString(),
                    TotalCR = dt.Rows[i]["TotalCR"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetInvSetOffExistingValue(MyAccount Data)
        {
            string _Query = "select Id,IntAccountID, Reference,convert(varchar,VoucherDate, 23) as VoucherDate,TotalDR,TotalCR from NVO_financeInvoiceSetOff where Id =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyAccount> InvoiceSetOffUnmatchedExisting(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvSetOffUnMatchedExistingValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountNameID = dt.Rows[i]["IntAccountID"].ToString(),
                    ReferenceNo = dt.Rows[i]["Reference"].ToString(),
                    VoucherDate = dt.Rows[i]["VoucherDate"].ToString(),
                    TotalDR = dt.Rows[i]["TotalDR"].ToString(),
                    TotalCR = dt.Rows[i]["TotalCR"].ToString(),
                    UnMatchReference = dt.Rows[i]["UnMatchReference"].ToString(),
                    UnMatchDate = dt.Rows[i]["UnMatchDate"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetInvSetOffUnMatchedExistingValue(MyAccount Data)
        {
            string _Query = "select Id,IntAccountID, Reference,UnMatchReference,convert(varchar,VoucherDate, 23) as VoucherDate, convert(varchar,UnMatchDate, 23) as UnMatchDate,TotalDR,TotalCR from NVO_financeInvoiceSetOff where Id =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyAccount> InvSetoffExistingDR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvSetOffExistingDR(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["InvID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    AmountLocal = dt.Rows[i]["AmountLocal"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjustmentAmt"].ToString(),
                    VoucherType = dt.Rows[i]["VoucherType"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    ReceivedAmt = dt.Rows[i]["ReceivedAmt"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetInvSetOffExistingDR(MyAccount Data)
        {
            string _Query = "select FDR.ID,InvID,VoucherNo,FDR.Amount,'INVOICE' as VoucherType,(Select top 1 CurrencyCode from NVO_CurrencyMaster WHERE ID = NVO_InvoiceCusBilling.CurrencyID) Currency, "+
                " (isnull(FDR.AdjustmentAmt, 0)) as AdjustmentAmt,AmountLocal,isnull(Amount,0) - isnull(AdjustmentAmt, 0) as ReceivedAmt,(((isnull(Amount,0) - isnull(AdjustmentAmt, 0)) + (isnull(AdjustmentAmt, 0))) - (isnull(Amount,0))) as DueAmount from NVO_financeInvoiceSetOffDR FDR INNER JOIN NVO_InvoiceCusBilling ON NVO_InvoiceCusBilling.FinalInvoice = FDR.VoucherNo where InvID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyAccount> InvSetoffExsitingCR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetInvSetOffExistingCR(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["InvID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["ReceivedAmt"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjAmount"].ToString(),
                    // CRIsFinal = dt.Rows[i]["AdjAmount"].ToString()
                   VoucherType = dt.Rows[i]["VoucherType"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetInvSetOffExistingCR(MyAccount Data)
        {
            string _Query = " select FCR.ID,InvID,VoucherNo,FCR.Amount,'RECEIPTS' as VoucherType,(Select top 1 CurrencyCode from NVO_CurrencyMaster WHERE ID = NVO_Receipts.Currency) Currency, (isnull(AdjAmount, 0)) as AdjAmount,isnull(FCR.Amount,0) - isnull(FCR.AdjAmount, 0) as ReceivedAmt,(((isnull(FCR.Amount,0) - isnull(FCR.AdjAmount, 0)) + (isnull(FCR.AdjAmount, 0))) - (isnull(FCR.Amount,0))) as DueAmount  " +
                            " from NVO_financeInvoiceSetOffCR FCR INNER JOIN NVO_Receipts ON NVO_Receipts.ReceiptNo = FCR.VoucherNo where InvID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyAccount> VendorInvoiceDetailsMaster(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorInvoiceDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvID = dt.Rows[i]["InvID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["TotalReceived"].ToString(),
                    TotalDue = dt.Rows[i]["TotalDue"].ToString(),
                    ReceiptAMT = dt.Rows[i]["ReceiptAMT"].ToString(),
                    TDSAMT = dt.Rows[i]["TDSAMT"].ToString(),
                    IsCheck = bool.Parse(dt.Rows[i]["IsCheck"].ToString())
                });
            }
            return ViewList;
        }


        public DataTable GetVendorInvoiceDetails(MyAccount Data)
        {

            string _Query = " SELECT DISTINCT CS.Id as InvID,InvoiceNo, BLTypes, PartyId AS CusID,  InvTotal AS InvTotal, CS.ID AS CusInvID, '2' AS CrDrType, " +
                            " '' as ReceiptAMT, '' as TDSAMT,   GeoLocID, isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_PaymentBL " +
                            " WHERE NVO_PaymentBL.InvCusBillingID = CS.ID  AND ReceiptID NOT IN(SELECT R.ID FROM NVO_Payments R WHERE  partyId = " + Data.PartyID  +
                            " and R.ReceiptStatus not in (0))),0) AS TotalReceived,isnull((ROUND(InvTotal, 0)), 0) -isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_PaymentBL " +
                            " WHERE NVO_PaymentBL.InvCusBillingID = CS.ID  AND ReceiptID NOT IN(SELECT R.ID FROM NVO_Payments R WHERE  partyId = " + Data.PartyID + " and R.ReceiptStatus not in (0))),0) as TotalDue, 'false' as IsCheck  FROM NVO_InvoiceVenBilling CS " +
                            " WHERE CS.InvoiceNo != 'NULL' and OB in(1, 2) AND PartyID = " + Data.PartyID + " and ABS((SELECT dnd.InvTotal FROM NVO_InvoiceVenBilling dnd WHERE dnd.ID = CS.ID) -ISNULL((SELECT SUM(ISNULL(Amount, 0)) FROM v_PaymentSetOffDR " +
                            " WHERE  v_PaymentSetOffDR.InvID = CS.ID),0)) > 0";

            return GetViewData(_Query, "");
        }


        public List<MYReceipts> Paymentvalues(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetPaymentValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    DtReceipt = dt.Rows[i]["DtReceipt"].ToString(),
                    Office = dt.Rows[i]["Office"].ToString(),
                    ReceiptTypes = dt.Rows[i]["ReceiptTypes"].ToString(),
                    Payment = dt.Rows[i]["Payment"].ToString(),
                    PaymentTypes = dt.Rows[i]["PaymentTypes"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),
                    LocAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    PaymentDate = dt.Rows[i]["PaymentDate"].ToString(),
                    PartyID = dt.Rows[i]["PartyID"].ToString(),
                    Reference = dt.Rows[i]["Reference"].ToString(),
                    BankName = dt.Rows[i]["BankName"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetPaymentValue(MYReceipts Data)
        {
            string _Query = " Select * from NVO_Payments where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyAccount> PaymentAmountDetails(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetPaymentAmountValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvID = dt.Rows[i]["InvID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["TotalReceived"].ToString(),
                    TotalDue = dt.Rows[i]["TotalDue"].ToString(),
                    ReceiptAMT = dt.Rows[i]["ReceiptAMT"].ToString(),
                    TDSAMT = dt.Rows[i]["TDSAMT"].ToString(),
                    IsCheck = bool.Parse(dt.Rows[i]["IsCheck"].ToString())
                });
            }
            return ViewList;
        }


        public DataTable GetPaymentAmountValue(MyAccount Data)
        {

            string _Query = " Select InvCusBillingId as InvID, (select InvoiceNo from NVO_InvoiceVenBilling where Id = InvCusBillingId) as InvoiceNo,  " +
                            "  (select InvTotal from NVO_InvoiceVenBilling where Id = InvCusBillingId) as InvTotal, Amount as TotalReceived,  " +
                            " Amount as ReceiptAMT, TDSAMT,'' TotalDue,'true' as IsCheck from  NVO_PaymentBL where ReceiptID = " + Data.ID;


            return GetViewData(_Query, "");
        }

        public List<MyAccount> PaymentInvoiceOutstanding(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetPaymentInvoiceOutstanding(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["RecAmt"].ToString(),
                    TotalDue = dt.Rows[i]["OutStading"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetPaymentInvoiceOutstanding(MyAccount Data)
        {
            string _Query = "select sum(InvTotal) as InvTotal , sum(RecAmt) as RecAmt, (sum(InvTotal) - sum(RecAmt)) as OutStading  from NVO_PaymentInvoiceOutStaingView where PartyID=" + Data.PartyID;


            return GetViewData(_Query, "");
        }


        public List<MyAccount> VendorSetOffSearch(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorSetOffSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountName = dt.Rows[i]["StrAccount"].ToString(),
                    ReferenceNo = dt.Rows[i]["Reference"].ToString(),
                    VoucherDate = dt.Rows[i]["VoucherDate"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetVendorSetOffSearch(MyAccount Data)
        {
            string strWhere = "";
            string _Query = " select Id, StrAccount, Reference, convert(varchar, VoucherDate, 103) as VoucherDate from NVO_VenfinanceInvoiceSetOff";
            strWhere += _Query + " where Isactive=0";

            if (Data.VoucherNo.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where StrAccount like '%" + Data.VoucherNo.Trim() + "%'";
                else
                    strWhere += " and StrAccount like '%" + Data.VoucherNo.Trim() + "%'";

            if (Data.ReferenceNo.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where Reference like '%" + Data.ReferenceNo.Trim() + "%'";
                else
                    strWhere += " and Reference like '%" + Data.ReferenceNo.Trim() + "%'";

            if (Data.VoucherDate.Trim() != "")
                if (strWhere == "")
                    strWhere += _Query + " where VoucherDate= '" + DateTime.Parse((Data.VoucherDate)).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and VoucherDate= '" + DateTime.Parse((Data.VoucherDate)).ToString("MM/dd/yyyy") + "'";



            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere + " order by Id desc", "");
        }


        public List<MyAccount> VendorSetoffDR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorSetOffDr(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    AmountLocal = dt.Rows[i]["AmountLocal"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjustmentAmt"].ToString(),
                    DRIsFinal = dt.Rows[i]["AdjustmentAmt"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetVendorSetOffDr(MyAccount Data)
        {
            string _Query = " select ID,InvoiceNo as VoucherNo, InvTotal as Amount, InvTotal as AmountLocal, '' as AdjustmentAmt, '' as DRIsFinal from NVO_InvoiceVenBilling " +
                            " where PartyID = " + Data.PartyID + " and Id not in(select InvCusBillingId from NVO_Payments " +
                            " inner join NVO_PaymentBL on NVO_PaymentBL.ReceiptID = NVO_Payments.ID  where ReceiptStatus = 0 and PartyID = " + Data.PartyID + ") " +
                            " and Id not in (select VoucherID from NVO_VenfinanceInvoiceSetOff " +
                            " inner join NVO_VenfinanceInvoiceSetOffDR on NVO_VenfinanceInvoiceSetOffDR.InvID = NVO_VenfinanceInvoiceSetOff.Id where IntAccountID = " + Data.PartyID + "  and Isactive = 0)";


            return GetViewData(_Query, "");
        }

        public List<MyAccount> VendorSetoffCR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorSetOffCr(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["ReceivedAmt"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjAmount"].ToString(),
                    CRIsFinal = dt.Rows[i]["AdjAmount"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetVendorSetOffCr(MyAccount Data)
        {
            string _Query = " select ID, VoucherNo, Amount, (isnull(AdjAmount, 0)) as ReceivedAmt,(Amount - (isnull(AdjAmount, 0))) as AdjAmount,'' as CRIsFinal " +
                            " from V_SetOffPaymentValue where ReceiptTypes = 1 and(Amount - (isnull(AdjAmount, 0))) > 5  and PartyID =" + Data.PartyID;

            return GetViewData(_Query, "");
        }


        public List<MyAccount> InsertFinanceVendorSet(MyAccount Data)
        {
            List<MyAccount> List = new List<MyAccount>();
            int r1 = 0;
            int r2 = 0;
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
                        string AutoGen = GetMaxseqNumber("VenSetoff", Data.GeoLocID.ToString(), Data.SessionFinYear);

                        Cmd.CommandText = "select ('ISO')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.ReferenceNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_VenfinanceInvoiceSetOff where ID=@ID)<=0) " +
                    " BEGIN " +
                    " INSERT INTO  NVO_VenfinanceInvoiceSetOff(IntAccountID,StrAccount,Reference,VoucherDate,TotalDR,TotalCR,IsActive) " +
                    " values(@IntAccountID,@StrAccount,@Reference,@VoucherDate,@TotalDR,@TotalCR,@IsActive)  " +
                    " END  " +
                    " ELSE " +
                    " UPDATE NVO_VenfinanceInvoiceSetOff  SET IntAccountID=@IntAccountID,StrAccount=@StrAccount,Reference=@Reference,VoucherDate=@VoucherDate,TotalDR=@TotalDR,TotalCR=@TotalCR,IsActive=@IsActive where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IntAccountID", Data.AccountNameID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StrAccount", Data.AccountName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reference", Data.ReferenceNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherDate", Data.VoucherDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalDR", Data.TotalDR));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalCR", Data.TotalCR));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsActive", Data.IsActive));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_VenfinanceInvoiceSetOff')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    string[] Array = Data.DRItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_VenfinanceInvoiceSetOffDR WHERE InvID=@InvID and VoucherID=@VoucherID)<=0) " +
                                                               " BEGIN " +
                                                               " INSERT INTO NVO_VenfinanceInvoiceSetOffDR(InvID,VoucherNo,VoucherID,Amount,AmountLocal,AdjustmentAmt)" +
                                                               " values (@InvID,@VoucherNo,@VoucherID,@Amount,@AmountLocal,@AdjustmentAmt) " +
                                                               " END " +
                                                               " ELSE " +
                                                               " UPDATE NVO_VenfinanceInvoiceSetOffDR SET InvID=@InvID,VoucherNo=@VoucherNo,VoucherID=@VoucherID,Amount=@Amount,AmountLocal=@AmountLocal,AdjustmentAmt=@AdjustmentAmt WHERE InvID=@InvID and VoucherID=@VoucherID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AmountLocal", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AdjustmentAmt", CharSplit[4]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayCr = Data.CRItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayCr.Length; i++)
                    {
                        var CharSplit = ArrayCr[i].ToString().TrimEnd(',').Split(',');



                        Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_VenfinanceInvoiceSetOffCR WHERE InvID=@InvID and VoucherID=@VoucherID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO NVO_VenfinanceInvoiceSetOffCR(InvID,VoucherNo,VoucherID,Amount,AmountLocal,AdjAmount)" +
                                        " values (@InvID,@VoucherNo,@VoucherID,@Amount,@AmountLocal,@AdjAmount) " +
                                        " END " +
                                        " ELSE " +
                                        " UPDATE NVO_VenfinanceInvoiceSetOffCR SET InvID=@InvID,VoucherNo=@VoucherNo,VoucherID=@VoucherID,Amount=@Amount,AmountLocal=@AmountLocal,AdjAmount=@AdjAmount WHERE InvID=@InvID and VoucherID=@VoucherID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoucherNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AmountLocal", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AdjAmount", CharSplit[4]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();

                    List.Add(new MyAccount
                    {
                        ID = Data.ID,

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
        public List<MyAccount> VendorSetOffExisting(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorSetOffExistingValue(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountNameID = dt.Rows[i]["IntAccountID"].ToString(),
                    ReferenceNo = dt.Rows[i]["Reference"].ToString(),
                    VoucherDate = dt.Rows[i]["VoucherDate"].ToString(),
                    TotalDR = dt.Rows[i]["TotalDR"].ToString(),
                    TotalCR = dt.Rows[i]["TotalCR"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetVendorSetOffExistingValue(MyAccount Data)
        {
            string _Query = "select Id,IntAccountID, Reference,convert(varchar,VoucherDate, 23) as VoucherDate,TotalDR,TotalCR from NVO_VenfinanceInvoiceSetOff where Id =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyAccount> VendorSetoffExsitingCR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorSetOffExistingCR(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["InvID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["ReceivedAmt"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjAmount"].ToString()
                    // CRIsFinal = dt.Rows[i]["AdjAmount"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetVendorSetOffExistingCR(MyAccount Data)
        {
            string _Query = "select ID,InvID,VoucherNo,Amount, (isnull(AdjAmount,0)) as ReceivedAmt,(Amount - (isnull(AdjAmount,0))) as AdjAmount from NVO_VenfinanceInvoiceSetOffCR where InvID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyAccount> VendorSetoffExistingDR(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetVendorSetOffExistingDR(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["InvID"].ToString()),
                    VoucherNo = dt.Rows[i]["VoucherNo"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    AmountLocal = dt.Rows[i]["AmountLocal"].ToString(),
                    AdjustmentAmt = dt.Rows[i]["AdjustmentAmt"].ToString()


                });
            }
            return ViewList;
        }
        public DataTable GetVendorSetOffExistingDR(MyAccount Data)
        {
            string _Query = "select * from NVO_VanfinanceInvoiceSetOffDR where InvID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYReceipts> BindReceiptTypevalues(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetBindReceiptTypevalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptTypes = dt.Rows[i]["GeneralName"].ToString(),
               
                });
            }
            return ViewList;
        }
        public DataTable GetBindReceiptTypevalues(MYReceipts Data)
        {

            string _Query = "select * from NVO_GeneralMaster WHERE SEQNO=52";


            return GetViewData(_Query, "");
        }

        #region ReceiptCancel

        public List<MYReceipts> BindReceiptsNovalues(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetBindReceiptsNovalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),

                });
            }
            return ViewList;
        }
        public DataTable GetBindReceiptsNovalues(MYReceipts Data)
        {

            string _Query = "select * from NVO_Receipts WHERE ReceiptStatus != 2 and AgencyID=" + Data.AgencyID;


            return GetViewData(_Query, "");
        }
        public List<MYReceipts> BindReceiptDetails(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetBindReceiptDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    DtReceipt = dt.Rows[i]["DtReceipt"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    ReceiptTypes = dt.Rows[i]["ReceiptTypes"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                });
            }
            return ViewList;
        }
        public DataTable GetBindReceiptDetails(MYReceipts Data)
        {

            string _Query = "select ID,ReceiptNo,convert(varchar, DtReceipt, 23) as DtReceipt,Amount,PartyName,Case when ReceiptTypes=194 Then 'BILL PAYMENT' when ReceiptTypes=193 Then 'ON ACCOUNT' END ReceiptTypes,(Select Top 1 CurrencyCode From NVO_CurrencyMaster Where ID=Currency) Currency from NVO_Receipts WHERE ID=" + Data.ReceiptNo;


            return GetViewData(_Query, "");
        }
        public List<MYReceipts> InsertReceiptCancellation(MYReceipts Data)
        {
            List<MYReceipts> List = new List<MYReceipts>();
            int r1 = 0;
            int r2 = 0;
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



                    Cmd.CommandText = " Update NVO_Receipts Set ReceiptStatus=2 where ID=" + Data.ID;
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_ReceiptCancellationLog WHERE ReceiptID=@ReceiptID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO NVO_ReceiptCancellationLog (ReceiptID,LogRemarks,CancelledOn,CancelledBy,AgencyID)" +
                                 " values (@ReceiptID,@LogRemarks,@CancelledOn,@CancelledBy,@AgencyID) " +
                                 " END " +
                                 " ELSE " +
                                 " UPDATE NVO_ReceiptCancellationLog SET ReceiptID=@ReceiptID,LogRemarks=@LogRemarks,CancelledOn=@CancelledOn,CancelledBy=@CancelledBy,AgencyID=@AgencyID WHERE ReceiptID=@ReceiptID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptID", Data.ID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@LogReference", Data.Reference));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LogRemarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledOn", Data.CancelledOn));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();

                    List.Add(new MYReceipts
                    {
                        ID = Data.ID,

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
        public List<MYReceipts> ReceiptCancelSearch(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetReceiptCancelSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    DtReceipt = dt.Rows[i]["RecDate"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    ReceiptTypes = dt.Rows[i]["PaymentType"].ToString(),
                    LocAmount = dt.Rows[i]["Amount"].ToString(),
                    CancelledOn = dt.Rows[i]["CancelledOn"].ToString(),
                    CancelledBy = dt.Rows[i]["CancelledBy"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetReceiptCancelSearch(MYReceipts Data)
        {

            string strWhere = "";
            string _Query = "   select R.ID,R.ReceiptNo,convert(varchar, R.DtReceipt, 103) as RecDate,R.PartyName,  case when R.ReceiptTypes = 193 then 'ON ACCOUNT'  when ReceiptTypes = 194 then 'BILL PAYMENT' else 'UN DEPOSIT ACCOUNT' end as PaymentType,Amount ,convert(varchar, RL.CancelledOn, 103) as CancelledOn, " +
            " (select top 1 UserName from NVO_UserDetails Where ID = CancelledBy)  CancelledBy from NVO_ReceiptCancellationLog RL  INNER JOIN NVO_Receipts R on R.ID = RL.ReceiptID ";

            strWhere += _Query + " where R.ReceiptStatus in (2)";
            if (Data.ReceiptNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and R.ReceiptNo like '%" + Data.ReceiptNo + "%'";
                else
                    strWhere += " and R.ReceiptNo like '%" + Data.ReceiptNo + "%'";

            if (Data.PartyID != "" && Data.PartyID != "0" && Data.PartyID != null && Data.PartyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and R.PartyID = " + Data.PartyID;
                else
                    strWhere += " and  R.PartyID = " + Data.PartyID;

            if (Data.ReceiptTypes != "" && Data.ReceiptTypes != "0" && Data.ReceiptTypes != null && Data.ReceiptTypes != "?")
                if (strWhere == "")
                    strWhere += _Query + " and R.ReceiptTypes = " + Data.ReceiptTypes;
                else
                    strWhere += " and  R.ReceiptTypes = " + Data.ReceiptTypes;

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where RL.AgencyID = " + Data.AgencyID;
                else
                    strWhere += " and RL.AgencyID = " + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");
        }

        #endregion

        #region payment
        public List<MYReceipts> InsertPayments(MYReceipts Data)
        {
            List<MYReceipts> List = new List<MYReceipts>();
            int r1 = 0;
            int r2 = 0;
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
                        string AutoGen = GetMaxseqNumber("Payment", Data.GeoLocID.ToString(), Data.SessionFinYear);

                        Cmd.CommandText = "select ('PV')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)+'" + Data.AgentCode + "'";
                        //Cmd.CommandText = "select (select ShortName from NV_TblGeoLocations where Id = " + Data.Office + ")+('RV') + right('000' + convert(varchar(3)," + AutoGen + "), 3) + '/' + ('" + Data.SessionFinYear + "')";
                        Data.ReceiptNo = Cmd.ExecuteScalar().ToString();
                    }
                    //  Data.ReceiptNo = "DRAFT";
                    Cmd.CommandText = " IF((select count(*) from NVO_Payments where ReceiptNo=@ReceiptNo)<=0) " +
                 " BEGIN " +
                 " INSERT INTO  NVO_Payments(ReceiptNo,DtReceipt,GeoLocID,PartyID,PartyName,ReceiptTypes,ReceiptStatus,Remarks,Is3rdParty,IsTDS,IsBankRec,ThirdPartyID,ThirdPartyName,PaymentTypes,Bank,BankName,Currency,ExRate,Amount,LocalAmount,PaymentDate,Reference,DrawerBank,DrawerBankBranch,RoundOffTypeID,GLCodeID,ExcessTariffAmt,ExcessLocalAmt,UserID,AgencyID) " +
                 " values(@ReceiptNo,@DtReceipt,@GeoLocID,@PartyID,@PartyName,@ReceiptTypes,@ReceiptStatus,@Remarks,@Is3rdParty,@IsTDS,@IsBankRec,@ThirdPartyID,@ThirdPartyName,@PaymentTypes,@Bank,@BankName,@Currency,@ExRate,@Amount,@LocalAmount,@PaymentDate,@Reference,@DrawerBank,@DrawerBankBranch,@RoundOffTypeID,@GLCodeID,@ExcessTariffAmt,@ExcessLocalAmt,@UserID,@AgencyID)  " +
                 " END  " +
                 " ELSE " +
                 " UPDATE NVO_Payments SET ReceiptNo=@ReceiptNo,DtReceipt=@DtReceipt,GeoLocID=@GeoLocID," +
                 " PartyID=@PartyID,PartyName=@PartyName,ReceiptTypes=@ReceiptTypes,ReceiptStatus=@ReceiptStatus,Remarks=@Remarks,Is3rdParty=@Is3rdParty,IsTDS=@IsTDS,IsBankRec=@IsBankRec,ThirdPartyID=@ThirdPartyID,ThirdPartyName=@ThirdPartyName,PaymentTypes=@PaymentTypes,Bank=@Bank,BankName=@BankName,Currency=@Currency,ExRate=@ExRate,Amount=@Amount,LocalAmount=@LocalAmount,PaymentDate=@PaymentDate,Reference=@Reference,DrawerBank=@DrawerBank,DrawerBankBranch=@DrawerBankBranch,RoundOffTypeID=@RoundOffTypeID,GLCodeID=@GLCodeID,ExcessTariffAmt=@ExcessTariffAmt,ExcessLocalAmt=@ExcessLocalAmt,UserID=@UserID,AgencyID=@AgencyID where ReceiptNo=@ReceiptNo";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("ReceiptNo", Data.ReceiptNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtReceipt", Data.DtReceipt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.PartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", Data.PartyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptTypes", Data.ReceiptTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptStatus", Data.ReceiptStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Is3rdParty", Data.Is3rdParty));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsTDS", Data.IsTDS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBankRec", Data.IsBankRec));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ThirdPartyID", Data.ThirdPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ThirdPartyName", Data.ThirdPartyName));

                    //----Collection Details---
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTypes", Data.PaymentTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Bank", Data.Bank));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BankName", Data.BankName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", Data.Currency));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", Data.ExRate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", Data.Amount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", Data.LocAmount));
                    if (Data.PaymentDate != DateTime.MinValue.ToString())
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentDate", Data.PaymentDate));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentDate", DBNull.Value));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reference", Data.Reference));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DrawerBank", Data.DrawerBank));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DrawerBankBranch", Data.DrawerBranch));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoundOffTypeID", Data.RoundOffTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLCodeID", Data.RoundOffGLCodeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExcessTariffAmt", Data.RoundOffTariffAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExcessLocalAmt", Data.RoundOffLocAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    //----end -----

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Payments')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    if (Data.ReceiptTypes == "194")
                    {
                        string[] Array = Data.InvItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_PaymentBL WHERE ReceiptID=@ReceiptID and InvCusBillingID=@InvCusBillingID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO NVO_PaymentBL (ReceiptID,InvCusBillingID,Amount,TDSAmt,BLID,TDS)" +
                                             " values (@ReceiptID,@InvCusBillingID,@Amount,@TDSAmt,@BLID,@TDS) " +
                                             " END " +
                                             " ELSE " +
                                             " UPDATE NVO_PaymentBL SET ReceiptID=@ReceiptID,InvCusBillingID=@InvCusBillingID,Amount=@Amount,TDSAmt=@TDSAmt,BLID=@BLID,TDS=@TDS " +
                                             " WHERE ReceiptID=@ReceiptID and InvCusBillingID=@InvCusBillingID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TDSAmt", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TDS", CharSplit[4]));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }

                    }

                    //Cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_PaymentWirteoff WHERE ReceiptID=@ReceiptID)<=0) " +
                    //             " BEGIN " +
                    //             " INSERT INTO NVO_PaymentWirteoff (ReceiptID,AccountName,PayTypes,DeffAmount)" +
                    //             " values (@ReceiptID,@AccountName,@PayTypes,@DeffAmount) " +
                    //             " END " +
                    //             " ELSE " +
                    //             " UPDATE NVO_PaymentWirteoff SET ReceiptID=@ReceiptID,AccountName=@AccountName,PayTypes=@PayTypes,DeffAmount=@DeffAmount WHERE ReceiptID=@ReceiptID";
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ReceiptID", Data.ID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@AccountName", Data.AccountName));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@PayTypes", Data.PaymentTypes));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@DeffAmount", Data.DeffRoundoff));

                    //Cmd.ExecuteNonQuery();
                    //Cmd.Parameters.Clear();

                    trans.Commit();

                    List.Add(new MYReceipts
                    {
                        ID = Data.ID,

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


        public List<MyAccount> PaymentVenInvoiceDetls(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetPaymentVenInvoiceDetls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    InvID = dt.Rows[i]["InvID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    TotalReceived = dt.Rows[i]["TotalReceived"].ToString(),
                    TotalDue = dt.Rows[i]["TotalDue"].ToString(),
                    ReceiptAMT = dt.Rows[i]["ReceiptAMT"].ToString(),
                    TDSAMT = dt.Rows[i]["TDSAMT"].ToString(),
                    IsCheck = bool.Parse(dt.Rows[i]["IsCheck"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    ExcessAmt = dt.Rows[i]["ExcessAmt"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetPaymentVenInvoiceDetls(MyAccount Data)
        {

            string _Query = " SELECT DISTINCT CS.Id as InvID,InvoiceNo,(select  top(1) CurrencyCode from NVO_CurrencyMaster where Id = CurrencyID) as Currency, BLTypes,InvTypes, PartyId AS CusID, InvTotal AS InvTotal,CS.ID AS CusInvID, '2' AS CrDrType, '' as ReceiptAMT, '' as TDSAMT, " +
            " GeoLocID, isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_ReceiptBL WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID " +
          " AND ReceiptID  IN(SELECT R.ID FROM NVO_Receipts R WHERE  partyId =" + Data.PartyID + "  and R.ReceiptStatus = 1)),0) AS TotalReceived, isnull((ROUND(InvTotal, 0)), 0) -isnull((SELECT SUM(ISNULL(Amount + TdsAmt + ExDeffAmt, 0)) FROM NVO_ReceiptBL WHERE NVO_ReceiptBL.InvCusBillingID = CS.ID " +
      " AND ReceiptID  IN(SELECT R.ID FROM NVO_Receipts R WHERE  partyId =" + Data.PartyID + "  and R.ReceiptStatus = 1)),0) as TotalDue,'false' as IsCheck,   (select top 1 BLNumber from NVO_BOL Where ID = CS.BLID) AS BLNumber, " +
      " CS.BLID, '0.00' as ExcessAmt FROM NVO_InvoiceVenBilling CS WHERE CS.InvoiceNo != 'NULL'  and IsApproved =24  AND PartyID =" + Data.PartyID + "  and ABS((SELECT dnd.InvTotal FROM NVO_InvoiceVenBilling dnd WHERE dnd.ID = CS.ID) -ISNULL((SELECT SUM(ISNULL(Amount, 0)) FROM v_PaymentSetOffDR WHERE  v_PaymentSetOffDR.InvID = CS.ID and ReceiptStatus = 1),0)) > 0  AND AgentId =" + Data.AgencyID + " ";


            return GetViewData(_Query, "");
        }

        public List<MYReceipts> PaymentSearch(MYReceipts Data)
        {
            List<MYReceipts> ViewList = new List<MYReceipts>();
            DataTable dt = GetPaymentSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYReceipts
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    DtReceipt = dt.Rows[i]["RecDate"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    LocAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    PaymentTypes = dt.Rows[i]["PaymentType"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetPaymentSearch(MYReceipts Data)
        {

            string strWhere = "";
            string _Query = " Select ID,ReceiptNo, convert(varchar, DtReceipt, 103) as RecDate,PartyName, " +
                            " case when ReceiptCatgory = 1 then 'LOCAL' else 'OVERSEAS'  end as RecTypes ,case when ReceiptTypes = 193 then 'ON ACCOUNT'  when ReceiptTypes = 194 then 'BILL PAYMENT'  else 'UN DEPOSIT ACCOUNT' end as PaymentType,LocalAmount " +
                            " from NVO_Payments";

            strWhere += _Query + " where ReceiptStatus in (1)";
            if (Data.ReceiptNo != "")
                if (strWhere == "")
                    strWhere += _Query + " and ReceiptNo like '%" + Data.ReceiptNo + "%'";
                else
                    strWhere += " and ReceiptNo like '%" + Data.ReceiptNo + "%'";

            if (Data.PartyID != "" && Data.PartyID != "0" && Data.PartyID != null && Data.PartyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and PartyID = " + Data.PartyID;
                else
                    strWhere += " and  PartyID = " + Data.PartyID;

            if (Data.ReceiptTypes != "" && Data.ReceiptTypes != "0" && Data.ReceiptTypes != null && Data.ReceiptTypes != "?")
                if (strWhere == "")
                    strWhere += _Query + " and ReceiptTypes = " + Data.ReceiptTypes;
                else
                    strWhere += " and  ReceiptTypes = " + Data.ReceiptTypes;

            if (Data.DtReceipt != "")
                if (strWhere == "")
                    strWhere += _Query + " and DtReceipt <= ' " + Data.DtReceipt + "'";
                else
                    strWhere += " and DtReceipt  <= ' " + Data.DtReceipt + "'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where AgencyID = " + Data.AgencyID;
                else
                    strWhere += " and AgencyID = " + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");
        }
        #endregion payment

        #region RECEIPT UNMATCH
        public List<MyAccount> BindMatchingSeqNoByParty(MyAccount Data)
        {
            List<MyAccount> ViewList = new List<MyAccount>();
            DataTable dt = GetBindMatchingSeqNoByParty(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAccount
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoucherNo = dt.Rows[i]["Reference"].ToString(),
                   
                });
            }
            return ViewList;
        }
        public DataTable GetBindMatchingSeqNoByParty(MyAccount Data)
        {
            string _Query = "select * from NVO_financeInvoiceSetOff where IntAccountID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

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
    }

}

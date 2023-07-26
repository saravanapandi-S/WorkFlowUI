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
    public class RateApprovalManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public RateApprovalManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region PRINCIPLE RATE REQUEST
        List<MyRateApproval> ListRateApproval = new List<MyRateApproval>();
        public List<MyRateApproval> BindPrinciplesList(MyRateApproval Data)
        {
            DataTable dt = GetBindPrinciples(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LineName = dt.Rows[i]["PrincipalName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindPrinciples(MyRateApproval Data)
        {
            string _Query = "select ID,(LineCode +'-'+ LineName) as PrincipalName from NVO_Principalmaster where Status=1 order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyRateApproval> BindRouteTypeList(MyRateApproval Data)
        {
            DataTable dt = GetBindRouteTypeList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RouteType = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindRouteTypeList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_GeneralMaster where Status=1 and SeqNo=49 order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyRateApproval> BindDeliveryTermsList(MyRateApproval Data)
        {
            DataTable dt = GetBindDeliveryTermsList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DeliveryTerms = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindDeliveryTermsList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_GeneralMaster where Status=1 and SeqNo=75 order by ID ";
            return GetViewData(_Query, "");
        }


        public List<MyRateApproval> BindEnquiryList(MyRateApproval Data)
        {
            DataTable dt = GetBindEnquiryList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindEnquiryList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_Enquiry ";
            return GetViewData(_Query, "");
        }



        public List<MyRateApproval> BindEnquiryByofficeList(MyRateApproval Data)
        {
            DataTable dt = GetBindEnquiryByofficeList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindEnquiryByofficeList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_Enquiry where OfficeCode =" + Data.OfficeLocID;
            return GetViewData(_Query, "");
        }

        public List<MyRateApproval> BindSalesPersonList(MyRateApproval Data)
        {
            DataTable dt = GetBindSalesPersonList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SalesPerson = dt.Rows[i]["UserName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindSalesPersonList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_UserDetails";
            return GetViewData(_Query, "");
        }
        public List<MyRateApproval> BindCargoTypesList(MyRateApproval Data)
        {
            DataTable dt = GetBindCargoTypesList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CargoTypes = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindCargoTypesList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_GeneralMaster where SeqNo=2";
            return GetViewData(_Query, "");
        }

        public List<MyRateApproval> ExistEnquiryDetailsList(MyRateApproval Data)
        {
            DataTable dt = GetExistEnquiryDetailsList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    EnquiryID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DeliveryTermID = Int32.Parse(dt.Rows[i]["DeliveryTermsID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["DestinationID"].ToString()),
                    OriginID = Int32.Parse(dt.Rows[i]["OriginID"].ToString()),
                    PrincipleID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["LoadPortID"].ToString()),
                    DischargePortID = Int32.Parse(dt.Rows[i]["DischargePortID"].ToString()),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    RouteTypeID = Int32.Parse(dt.Rows[i]["RouteID"].ToString()),
                    FreeDaysOrigin = Int32.Parse(dt.Rows[i]["FreeDaysOrigin"].ToString()),
                    FreeDaysDest = Int32.Parse(dt.Rows[i]["FreeDaysDest"].ToString()),
                    DamageScheme = Int32.Parse(dt.Rows[i]["DamageScheme"].ToString()),
                    BOLReq = Int32.Parse(dt.Rows[i]["BOLReq"].ToString()),
                    SecurityDeposit = Int32.Parse(dt.Rows[i]["SecurityDeposit"].ToString()),
                    FreeDaysOrgValue = dt.Rows[i]["FreeDaysOrgValue"].ToString(),
                    FreeDaysDestValue = dt.Rows[i]["FreeDaysDestValue"].ToString(),
                    DamageSchemeValue = dt.Rows[i]["DamageSchemeValue"].ToString(),
                    BOLReqDesc = dt.Rows[i]["BOLReqDesc"].ToString(),
                    SecurityDepositDesc = dt.Rows[i]["SecurityDepositDesc"].ToString(),
                });
            }
            return ListRateApproval;
        }

        public DataTable GetExistEnquiryDetailsList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_Enquiry where ID=" + Data.EnquiryID;
            return GetViewData(_Query, "");
        }
        public List<MyRateApprovalCharges> ExistEnquiryChargesBindList(MyRateApprovalCharges Data)
        {
            DataTable dt = GetExistEnquiryChargesBindList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRRChg.Add(new MyRateApprovalCharges
                {

                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CargoTypeID = Int32.Parse(dt.Rows[i]["CargoID"].ToString()),
                    FrieghtAmount = dt.Rows[i]["FrieghtAmount"].ToString(),
                    FrtCurrID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    SlotAmount = dt.Rows[i]["SlotAmount"].ToString(),
                    StdSplVID = Int32.Parse(dt.Rows[i]["ChargeOPT"].ToString()),
                    StdSplVAmount = dt.Rows[i]["PODAmount"].ToString(),
                    //StdSplVCurrID = Int32.Parse(dt.Rows[i]["StdSplVCurrID"].ToString()),

                });
            }
            return ListRRChg;
        }

        public DataTable GetExistEnquiryChargesBindList(MyRateApprovalCharges Data)
        {
            string _Query = "select EFR.EnqID,EFR.CntrTypeID,EFR.Nos,EFR.CargoID,EFR.CurrencyID,isnull(ManifestAmt,0.00) AS FrieghtAmount, isnull((select sum(ManifestPerAmount) from NVO_EnquirySlotRate ES where ES.EnqID = EFR.EnqID),0.00)  SlotAmount, isnull((select top 1 ChargeOPT from NVO_EnquiryShimpmentPOD EPOD where EPOD.EnqID = EFR.EnqID),0) AS ChargeOPT, " +
            " (select sum(Amount1 + Amount3) from NVO_EnquiryShimpmentPOD EPOD where EPOD.EnqID = EFR.EnqID) AS PODAmount from NVO_EnquiryFreightRate EFR  WHERE EFR.EnqID = " + Data.EnquiryID;
            return GetViewData(_Query, "");
        }
        public List<MyRateApproval> InsertRateApproval(MyRateApproval Data)
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
                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("RRNO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'RR' + ('NAV')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RequestNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_PrincipalRateRequest where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_PrincipalRateRequest(PrincipalID,RequestNo,EnquiryID,RequestDate,	StatusID,SalesPersonID,ValidTillDt,OrginID,LoadPortID,DisPortID,DestinationID,DeliveryTermID,RouteID,DtCreated,Createdby,Remarks,FreeDaysOrigin,FreeDaysOrgValue,FreeDaysDest,FreeDaysDestValue,	SecurityDeposit,SecurityDepositDesc,BOLReq,BOLReqDesc,DamageScheme,DamageSchemeValue,OfficeLocID) " +
                                     " values (@PrincipalID,@RequestNo,@EnquiryID,@RequestDate,	@StatusID,@SalesPersonID,@ValidTillDt,@OrginID,@LoadPortID,@DisPortID,@DestinationID,@DeliveryTermID,@RouteID,@DtCreated,@Createdby,@Remarks,@FreeDaysOrigin,@FreeDaysOrgValue,@FreeDaysDest,@FreeDaysDestValue,@SecurityDeposit,@SecurityDepositDesc,@BOLReq,@BOLReqDesc,@DamageScheme,@DamageSchemeValue,@OfficeLocID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_PrincipalRateRequest SET PrincipalID=@PrincipalID,RequestNo=@RequestNo,EnquiryID=@EnquiryID,RequestDate=@RequestDate,StatusID=@StatusID,SalesPersonID=@SalesPersonID,ValidTillDt=@ValidTillDt,OrginID=@OrginID,LoadPortID=@LoadPortID,DisPortID=@DisPortID,DestinationID=@DestinationID,DeliveryTermID=@DeliveryTermID,RouteID=@RouteID,Remarks=@Remarks,FreeDaysOrigin=@FreeDaysOrigin," +
                                     " FreeDaysOrgValue=@FreeDaysOrgValue,FreeDaysDest=@FreeDaysDest,FreeDaysDestValue=@FreeDaysDestValue,SecurityDeposit=@SecurityDeposit,SecurityDepositDesc=@SecurityDepositDesc,DamageScheme=@DamageScheme,DamageSchemeValue=@DamageSchemeValue,BOLReq=@BOLReq,BOLReqDesc=@BOLReqDesc,DtModifiedOn=@DtModifiedOn,ModifiedBy=@ModifiedBy,OfficeLocID=@OfficeLocID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincipleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestNo", Data.RequestNo));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@StateName", ""));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquiryID", Data.EnquiryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestDate", Data.RequestDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTillDt", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OrginID", Data.OriginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPortID", Data.LoadPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DisPortID", Data.DischargePortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationID", Data.DestinationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryTermID", Data.DeliveryTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RouteID", Data.RouteTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysOrigin", Data.FreeDaysOrigin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysOrgValue", Data.FreeDaysOrgValue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysDest", Data.FreeDaysDest));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysDestValue", Data.FreeDaysDestValue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SecurityDeposit", Data.SecurityDeposit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SecurityDepositDesc", Data.SecurityDepositDesc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageScheme", Data.DamageScheme));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageSchemeValue", Data.DamageSchemeValue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BOLReqDesc", Data.BOLReqDesc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BOLReq", Data.BOLReq));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreated", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModifiedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocID", Data.OfficeLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Createdby", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedBy", 1));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_PrincipalRateRequest')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PrincipleRRCharges where RRID=@RRID and PID=@PID )<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_PrincipleRRCharges(RRID,CntrTypeID,Nos,CargoTypeID,FrieghtAmount,FrtCurrID,SlotAmount,StdSplVID,StdSplVAmount) " +
                             " values(@RRID,@CntrTypeID,@Nos,@CargoTypeID,@FrieghtAmount,@FrtCurrID,@SlotAmount,@StdSplVID,@StdSplVAmount)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_PrincipleRRCharges SET RRID=@RRID,CntrTypeID=@CntrTypeID,Nos=@Nos,CargoTypeID=@CargoTypeID,FrieghtAmount=@FrieghtAmount,FrtCurrID=@FrtCurrID,SlotAmount=@SlotAmount,StdSplVID=@StdSplVID,StdSplVAmount=@StdSplVAmount where RRID=@RRID and PID=@PID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoTypeID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FrtCurrID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FrieghtAmount", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmount", CharSplit[6]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotCurrID", CharSplit[7]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@StdSplID", CharSplit[8]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@StdSplAmount", CharSplit[9]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@StdSplCurrID", CharSplit[10]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StdSplVID", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StdSplVAmount", CharSplit[8]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@StdSplVCurrID", CharSplit[13]));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }



                    if (Data.ItemsAttach != null)
                    {
                        string[] ArrayAt = Data.ItemsAttach.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayAt.Length; i++)
                        {
                            var CharSplitAt = ArrayAt[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PrincipleRRAttachments where RRID=@RRID and AID=@AID )<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_PrincipleRRAttachments(RRID,AttachName,AttachFile,UploadedOn,UploadedBy) " +
                             " values(@RRID,@AttachName,@AttachFile,@UploadedOn,@UploadedBy)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_PrincipleRRAttachments SET RRID=@RRID,AttachName=@AttachName,AttachFile=@AttachFile,UploadedOn=@UploadedOn,UploadedBy=@UploadedBy where RRID=@RRID and AID=@AID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AID", CharSplitAt[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachName", CharSplitAt[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", CharSplitAt[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", 1));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();

                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListRateApproval;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRateApproval;
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

        public List<MyRateApproval> InsertSubmitCopyRR(MyRateApproval Data)
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
                    string AutoGen = GetMaxseqNumber("RRNO", "1", Data.SessionFinYear);

                    var IDTID = 0;
                    Cmd.CommandText = "insert into NVO_PrincipalRateRequest (PrincipalID,RequestNo,EnquiryID,RequestDate,	StatusID,SalesPersonID,ValidTillDt,OrginID,LoadPortID,DisPortID,DestinationID,DeliveryTermID,RouteID,DtCreated,Createdby,Remarks,FreeDaysOrigin,FreeDaysOrgValue,FreeDaysDest,FreeDaysDestValue,	SecurityDeposit,SecurityDepositDesc,BOLReq,BOLReqDesc,DamageScheme,DamageSchemeValue) " +
                                      " select PrincipalID,(select 'RR' + ('NAV')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4), " + AutoGen + "), 4)) as RequestNo, " +
                                      " EnquiryID,RequestDate,	StatusID,SalesPersonID,ValidTillDt,OrginID,LoadPortID,DisPortID,DestinationID,DeliveryTermID,RouteID,DtCreated,Createdby,Remarks,FreeDaysOrigin,FreeDaysOrgValue,FreeDaysDest,FreeDaysDestValue,	SecurityDeposit,SecurityDepositDesc,BOLReq,BOLReqDesc,DamageScheme,DamageSchemeValue from NVO_PrincipalRateRequest where ID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    Cmd.CommandText = "select ident_current('NVO_PrincipalRateRequest')";
                    IDTID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "insert into NVO_PrincipleRRCharges(RRID,CntrTypeID,Nos,CargoTypeID,FrieghtAmount,FrtCurrID,SlotAmount,StdSplVID,StdSplVAmount) " +
                                      " select " + IDTID + ",CntrTypeID,Nos,CargoTypeID,FrieghtAmount,FrtCurrID,SlotAmount,StdSplVID,StdSplVAmount from NVO_PrincipleRRCharges " +
                                      " where RRID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();

                    Cmd.Parameters.Clear();

                    trans.Commit();

                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListRateApproval;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRateApproval;
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
        public List<MyRateApproval> RateApprovalViewList(MyRateApproval Data)
        {
            DataTable dt = GetRateApprovalVieValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListRateApproval.Add(new MyRateApproval
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Principle = dt.Rows[i]["Principle"].ToString(),
                    PrincipleN = dt.Rows[i]["PrincipleN"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POLN = dt.Rows[i]["POLN"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    PODN = dt.Rows[i]["PODN"].ToString(),
                    FPODN = dt.Rows[i]["FPODN"].ToString(),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                    RequestDate = dt.Rows[i]["RequestDateV"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ValidStatus = dt.Rows[i]["ValidStatus"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    OpenCount = Int32.Parse(dt.Rows[i]["OpenCount"].ToString()),
                });
            }


            return ListRateApproval;
        }
        public DataTable GetRateApprovalVieValues(MyRateApproval Data)
        {
            string strWhere = "";
            string ReqDateFrom = "";
            string ReqDateTill = "";


            //if (Data.RequestFrom != "")
            //    ReqDateFrom = DateTime.Parse(Data.RequestFrom).ToString("dd/MM/yyyy");

            //if (Data.RequestTo != "")
            //    ReqDateTill = DateTime.Parse(Data.RequestTo).ToString("dd/MM/yyyy");

            //string _Query = "select PR.ID,PR.RequestNo,(select top 1 (LineCode +'-'+ LineName) from NVO_PrincipalMaster where ID=PR.PrincipalID ) AS Principle, " +
            // " (select top 1(PortCode + '-' + PortName) from NVO_PortMaster where ID = PR.LoadPortID )  as POL, " +
            //" (select top 1(PortCode + '-' + PortName) from NVO_PortMaster where ID = PR.DestinationID )  as POD, " +
            //" (select top 1(PortCode + '-' + PortName) from NVO_PortMaster where ID = PR.DisPortID )  as FPOD, " +
            // " CASE WHEN PR.StatusID = 1 THEN 'ACTIVE' WHEN PR.StatusID = 2 THEN 'APPROVED' WHEN PR.StatusID = 3 THEN 'REJECTED' WHEN PR.StatusID = 4 THEN 'CANCELLED'  END AS Status,convert(varchar, pr.RequestDate, 105) As RequestDate from NVO_PrincipalRateRequest PR ";

            string _Query = "Select Left(Principle,17)as PrincipleN,Left(POL,15)as POLN,Left(POD,17)as PODN,Left(FPOD,15)as FPODN,StatusID,ValidStatusID, * from RateApprovalV ";

            if (Data.RequestNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where RequestNo like '%" + Data.RequestNo.ToString().Trim() + "%'";
                else
                    strWhere += " and RequestNo like '%" + Data.RequestNo.ToString().Trim() + "%'";

            if (Data.OfficeLocID.ToString() != "0" && Data.OfficeLocID.ToString() != null)
                if (strWhere == "")
                    strWhere += _Query + " where OfficeLocID = " + Data.OfficeLocID;
                else
                    strWhere += " and OfficeLocID = " + Data.OfficeLocID;


            if (Data.PrincipleID.ToString() != "" && Data.PrincipleID.ToString() != null && Data.PrincipleID.ToString() != "0" && Data.PrincipleID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PrincipalID =" + Data.PrincipleID.ToString() + "";
                else
                    strWhere += " and PrincipalID =" + Data.PrincipleID.ToString() + "";

            if (Data.LoadPortID.ToString() != "" && Data.LoadPortID.ToString() != null && Data.LoadPortID.ToString() != "0" && Data.LoadPortID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where LoadPortID =" + Data.LoadPortID.ToString() + "";
                else
                    strWhere += " and LoadPortID =" + Data.LoadPortID.ToString() + "";

            if (Data.DischargePortID.ToString() != "" && Data.DischargePortID.ToString() != null && Data.DischargePortID.ToString() != "0" && Data.DischargePortID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where DisPortID =" + Data.DischargePortID.ToString() + "";
                else
                    strWhere += " and DisPortID =" + Data.DischargePortID.ToString() + "";

            if (Data.DestinationID.ToString() != "" && Data.DestinationID.ToString() != null && Data.DestinationID.ToString() != "0" && Data.DestinationID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where DestinationID =" + Data.DestinationID.ToString() + "";
                else
                    strWhere += " and DestinationID =" + Data.DestinationID.ToString() + "";

            if (Data.RequestFrom != "" && Data.RequestFrom != null)
                if (strWhere == "")
                    strWhere += _Query + " where RequestDate >= '" + DateTime.Parse(Data.RequestFrom).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and RequestDate >= '" + DateTime.Parse(Data.RequestFrom).ToString("MM/dd/yyyy") + "'";

            if (Data.RequestTo != "" && Data.RequestTo != null)
                if (strWhere == "")
                    strWhere += _Query + " where RequestDate <= '" + DateTime.Parse(Data.RequestTo).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and RequestDate <= '" + DateTime.Parse(Data.RequestTo).ToString("MM/dd/yyyy") + "'";

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where StatusID =" + Data.StatusID.ToString() + "";
                else
                    strWhere += " and StatusID =" + Data.StatusID.ToString() + "";

            if (Data.ValidStatusID.ToString() != "" && Data.ValidStatusID.ToString() != null && Data.ValidStatusID.ToString() != "0" && Data.ValidStatusID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where ValidStatusID =" + Data.ValidStatusID.ToString();
                else
                    strWhere += " and ValidStatusID =" + Data.ValidStatusID.ToString();


            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " ORDER BY RequestDate desc ", "");

        }

        public List<MyRateApproval> RateApprovalEditList(MyRateApproval Data)
        {
            DataTable dt = GetRateApprovalEditList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                    DeliveryTermID = Int32.Parse(dt.Rows[i]["DeliveryTermID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["DestinationID"].ToString()),
                    OriginID = Int32.Parse(dt.Rows[i]["OrginID"].ToString()),
                    PrincipleID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["LoadPortID"].ToString()),
                    DischargePortID = Int32.Parse(dt.Rows[i]["DisPortID"].ToString()),
                    RequestDate = dt.Rows[i]["RequestDt"].ToString(),
                    RouteTypeID = Int32.Parse(dt.Rows[i]["RouteID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    EnquiryID = Int32.Parse(dt.Rows[i]["EnquiryID"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    FreeDaysOrigin = Int32.Parse(dt.Rows[i]["FreeDaysOrigin"].ToString()),
                    FreeDaysDest = Int32.Parse(dt.Rows[i]["FreeDaysDest"].ToString()),
                    DamageScheme = Int32.Parse(dt.Rows[i]["DamageScheme"].ToString()),
                    BOLReq = Int32.Parse(dt.Rows[i]["BOLReq"].ToString()),
                    SecurityDeposit = Int32.Parse(dt.Rows[i]["SecurityDeposit"].ToString()),
                    FreeDaysOrgValue = dt.Rows[i]["FreeDaysOrgValue"].ToString(),
                    FreeDaysDestValue = dt.Rows[i]["FreeDaysDestValue"].ToString(),
                    DamageSchemeValue = dt.Rows[i]["DamageSchemeValue"].ToString(),
                    BOLReqDesc = dt.Rows[i]["BOLReqDesc"].ToString(),
                    SecurityDepositDesc = dt.Rows[i]["SecurityDepositDesc"].ToString(),
                    CancelRemarks = dt.Rows[i]["OtherRemarks"].ToString(),
                    Reason = dt.Rows[i]["Reason"].ToString(),
                    OfficeLocID = Int32.Parse(dt.Rows[i]["OfficeLocID"].ToString()),
                });
            }
            return ListRateApproval;
        }

        public DataTable GetRateApprovalEditList(MyRateApproval Data)
        {
            string _Query = "select convert(varchar, ValidTillDt, 23) as ValidTill,convert(varchar, RequestDate, 23) as RequestDt," +
                " isnull((select top 1 GeneralName from NVO_GeneralMaster WHERE ID =NVO_PrincipalRateRequest.CancelRejectType),'') AS Reason, * from NVO_PrincipalRateRequest where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        List<MyRateApprovalCharges> ListRRChg = new List<MyRateApprovalCharges>();
        public List<MyRateApprovalCharges> RateApprovalChargesEdit(MyRateApprovalCharges Data)
        {
            DataTable dt = GetRateApprovalChargesEdit(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRRChg.Add(new MyRateApprovalCharges
                {

                    PID = Int32.Parse(dt.Rows[i]["PID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CargoTypeID = Int32.Parse(dt.Rows[i]["CargoTypeID"].ToString()),
                    FrieghtAmount = dt.Rows[i]["FrieghtAmount"].ToString(),
                    FrtCurrID = Int32.Parse(dt.Rows[i]["FrtCurrID"].ToString()),
                    SlotAmount = dt.Rows[i]["SlotAmount"].ToString(),
                    // SlotCurrID = Int32.Parse(dt.Rows[i]["SlotCurrID"].ToString()),
                    // StdSplID = Int32.Parse(dt.Rows[i]["StdSplID"].ToString()),
                    // StdSplAmount = dt.Rows[i]["StdSplAmount"].ToString(),
                    //StdSplCurrID = Int32.Parse(dt.Rows[i]["StdSplCurrID"].ToString()),
                    StdSplVID = Int32.Parse(dt.Rows[i]["StdSplVID"].ToString()),
                    StdSplVAmount = dt.Rows[i]["StdSplVAmount"].ToString(),
                    //StdSplVCurrID = Int32.Parse(dt.Rows[i]["StdSplVCurrID"].ToString()),

                });
            }
            return ListRRChg;
        }

        public DataTable GetRateApprovalChargesEdit(MyRateApprovalCharges Data)
        {
            string _Query = "select * from NVO_PrincipleRRCharges where RRID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyRateApprovalCharges> RateApprovalAttachmentView(MyRateApprovalCharges Data)
        {
            DataTable dt = GetRateApprovalAttachmentView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRRChg.Add(new MyRateApprovalCharges
                {

                    AID = Int32.Parse(dt.Rows[i]["AID"].ToString()),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    AttachName = dt.Rows[i]["AttachName"].ToString(),


                });
            }
            return ListRRChg;
        }

        public DataTable GetRateApprovalAttachmentView(MyRateApprovalCharges Data)
        {
            string _Query = "select * from NVO_PrincipleRRAttachments where RRID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyRateApproval> InsertSubmitRateApproval(MyRateApproval Data)
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

                    Cmd.CommandText = "UPDATE NVO_PrincipalRateRequest SET ApprovedOn=@ApprovedOn,ApprovedBy=@ApprovedBy,StatusID=@StatusID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedBy", 1));
                    int result = Cmd.ExecuteNonQuery();

                    trans.Commit();

                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Approved Successfully"
                    });
                    return ListRateApproval;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRateApproval;
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

        public List<MyRateApproval> InsertRejectRateApproval(MyRateApproval Data)
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

                    Cmd.CommandText = "UPDATE NVO_PrincipalRateRequest SET RejectedOn=@RejectedOn,RejectedBy=@RejectedBy,StatusID=@StatusID,OtherRemarks=@OtherRemarks,CancelRejectType=@CancelRejectType where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 3));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectedBy", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelRejectType", Data.RejectReasonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherRemarks", Data.RejectRemarks));
                    int result = Cmd.ExecuteNonQuery();
                    trans.Commit();

                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Rejected Successfully"
                    });
                    return ListRateApproval;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRateApproval;
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
        public List<MyRateApproval> InsertCancelRateApproval(MyRateApproval Data)
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

                    Cmd.CommandText = "UPDATE NVO_PrincipalRateRequest SET CancelledOn=@CancelledOn,CancelledBy=@CancelledBy,StatusID=@StatusID,OtherRemarks=@OtherRemarks,CancelRejectType=@CancelRejectType where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 4));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledBy", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelRejectType", Data.CancelReasonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherRemarks", Data.CancelRemarks));
                    int result = Cmd.ExecuteNonQuery();

                    trans.Commit();

                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Cancelled Successfully"
                    });
                    return ListRateApproval;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRateApproval;
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

        public List<MyRateApproval> RRAttachDeleteMaster(MyRateApproval Data)
        {

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

                    Cmd.CommandText = "Delete from NVO_PrincipleRRAttachments where AID=" + Data.AID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListRateApproval;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRateApproval.Add(new MyRateApproval
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRateApproval;
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

        public List<MyRateApproval> BindDDRejectList(MyRateApproval Data)
        {
            DataTable dt = GetBindDDRejectList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindDDRejectList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_GeneralMaster where SeqNo=78 ";
            return GetViewData(_Query, "");
        }

        public List<MyRateApproval> BindDDCancelList(MyRateApproval Data)
        {
            DataTable dt = GetBindDDCancelList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRateApproval.Add(new MyRateApproval
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListRateApproval;
        }

        public DataTable GetBindDDCancelList(MyRateApproval Data)
        {
            string _Query = "select * from NVO_GeneralMaster where SeqNo=79 ";
            return GetViewData(_Query, "");
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

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
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DataManager
{
    public class CustomerContractManager
    {
        List<MyCustomerContract> ListContract = new List<MyCustomerContract>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CustomerContractManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyCustomerContract> InsertCustomerContractMaster(MyCustomerContract Data)
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

                    StringWriter stringwriter = new System.IO.StringWriter();
                    var serializer = new XmlSerializer(Data.GetType());
                    serializer.Serialize(stringwriter, Data);
                    Data.TextValues = stringwriter.ToString();

                    var SeqID = 0;

                    if (Data.ID == 0)
                    {
                        SeqID = 1;
                        string AutoGen = GetMaxseqNumber("CCNo", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'CC' + '-'  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.ContractNo = Cmd.ExecuteScalar().ToString();
                    }
                    else
                        SeqID = 2;

                    Cmd.CommandText = " IF((select count(*) from NVO_CustomerContract where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CustomerContract(CustomerID,PrincipalID,ContractNo,ContractDate,SalesPersonID,ValidTill,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,Remarks,Status,FreeDaysOriginType,FreeDaysOrigin,FreeDaysDestinationType,FreeDaysDestination,DamageSchemeType,DamageScheme,SecDepositType,SecDeposit,BOLReqType,BOLReq,RRID,OfficeLocation) " +
                                     " values (@CustomerID,@PrincipalID,@ContractNo,@ContractDate,@SalesPersonID,@ValidTill,@OriginID,@LoadPortID,@DischargePortID,@DestinationID,@RouteID,@DeliveryTermsID,@Remarks,@Status,@FreeDaysOriginType,@FreeDaysOrigin,@FreeDaysDestinationType,@FreeDaysDestination,@DamageSchemeType,@DamageScheme,@SecDepositType,@SecDeposit,@BOLReqType,@BOLReq,@RRID,@OfficeLocation) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CustomerContract SET CustomerID=@CustomerID,PrincipalID=@PrincipalID,ContractNo=@ContractNo,ContractDate=@ContractDate,SalesPersonID=@SalesPersonID,ValidTill=@ValidTill,OriginID=@OriginID,LoadPortID=@LoadPortID,DischargePortID=@DischargePortID,DestinationID=@DestinationID,RouteID=@RouteID,DeliveryTermsID=@DeliveryTermsID,Remarks=@Remarks,Status=@Status,FreeDaysOriginType=@FreeDaysOriginType,FreeDaysOrigin=@FreeDaysOrigin,FreeDaysDestinationType=@FreeDaysDestinationType,FreeDaysDestination=@FreeDaysDestination,DamageSchemeType=@DamageSchemeType,DamageScheme=@DamageScheme,SecDepositType=@SecDepositType,SecDeposit=@SecDeposit,BOLReqType=@BOLReqType,BOLReq=@BOLReq,RRID=@RRID,OfficeLocation=@OfficeLocation where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincipalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContractNo", Data.ContractNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContractDate", Data.ContractDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OriginID", Data.OriginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPortID", Data.LoadPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DischargePortID", Data.DischargePortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationID", Data.DestinationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RouteID", Data.RouteID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryTermsID", Data.DeliveryTermsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysOriginType", Data.FreeDaysOriginType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysOrigin", Data.FreeDaysOrigin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysDestinationType", Data.FreeDaysDestinationType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysDestination", Data.FreeDaysDestination));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageSchemeType", Data.DamageSchemeType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageScheme", Data.DamageScheme));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SecDepositType", Data.SecDepositType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SecDeposit", Data.SecDeposit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BOLReqType", Data.BOLReqType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BOLReq", Data.BOLReq));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocation", Data.OfficeLocation));


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_CustomerContract')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_CusContractContDtls where CID=@CID and CCID=@CCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CusContractContDtls(CCID,ContainerTypeID,Nos,CargoTypeID,OceanAmount,OceanCurrencyID,SlotAmount,PODStdID,PODAmount) " +
                                     " values (@CCID,@ContainerTypeID,@Nos,@CargoTypeID,@OceanAmount,@OceanCurrencyID,@SlotAmount,@PODStdID,@PODAmount) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CusContractContDtls SET CCID=@CCID,ContainerTypeID=@ContainerTypeID,Nos=@Nos,CargoTypeID=@CargoTypeID,OceanAmount=@OceanAmount,OceanCurrencyID=@OceanCurrencyID,PODStdID=@PODStdID,PODAmount=@PODAmount where CID=@CID and CCID=@CCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CCID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoTypeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OceanAmount", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OceanCurrencyID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmount", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PODStdID", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PODAmount", CharSplit[8]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array1 = Data.ItemsAttach.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit1 = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_CusContAttachments where AID=@AID and CCID=@CCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CusContAttachments(CCID,AttachName,AttachFile,UploadedOn,UploadedBy) " +
                                     " values (@CCID,@AttachName,@AttachFile,@UploadedOn,@UploadedBy) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CusContAttachments SET CCID=@CCID,AttachName=@AttachName,AttachFile=@AttachFile,UploadedOn=@UploadedOn,UploadedBy=@UploadedBy where AID=@AID and CCID=@CCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CCID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AID", CharSplit1[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachName", CharSplit1[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", CharSplit1[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    Cmd.CommandText = "INSERT INTO  NVO_LogDetails(PageName,CreatedOn,CreatedBy,SeqNo,LogInID,TextValues) " +
                                " values (@PageName,@CreatedOn,@CreatedBy,@SeqNo,@LogInID,@TextValues)";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PageName", Data.PageName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", (DateTime.Parse(System.DateTime.Now.Date.ToString()))));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SeqNo", SeqID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LogInID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TextValues", Data.TextValues));
                    result = Cmd.ExecuteNonQuery();

                    trans.Commit();
                    ListContract.Add(new MyCustomerContract
                    {
                        ID = Data.ID,
                    });
                    return ListContract;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContract;
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


        public List<MyCustomerContract> InsertCopyCustomerContractMaster(MyCustomerContract Data)
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
                string AutoGen = GetMaxseqNumber("CCNo", "1", Data.SessionFinYear);
                try
                {
                    var IDTID = 0;
                    Cmd.CommandText = "insert into NVO_CustomerContract (CustomerID,PrincipalID,ContractNo,ContractDate,SalesPersonID,ValidTill,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID, " +
                                      " DeliveryTermsID,Remarks,Status,FreeDaysOriginType,FreeDaysOrigin,FreeDaysDestinationType,FreeDaysDestination,DamageSchemeType,DamageScheme,SecDepositType,SecDeposit,BOLReqType,BOLReq,RRID) " +
                                      " select CustomerID,PrincipalID,(select 'CC' + '-' + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4), " + AutoGen + "), 4))as ContractNo, " +
                                      " ContractDate,SalesPersonID,ValidTill,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,Remarks,Status,FreeDaysOriginType,FreeDaysOrigin,FreeDaysDestinationType,FreeDaysDestination,DamageSchemeType,DamageScheme,SecDepositType,SecDeposit, " +
                                      " BOLReqType,BOLReq,RRID from NVO_CustomerContract where ID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();



                    Cmd.CommandText = "select ident_current('NVO_CustomerContract')";
                    IDTID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "insert into NVO_CusContractContDtls(CCID,ContainerTypeID,Nos,CargoTypeID,OceanAmount,OceanCurrencyID,SlotAmount,PODStdID,PODAmount) " +
                                      " select " + IDTID + ",ContainerTypeID, Nos, CargoTypeID, OceanAmount, OceanCurrencyID, SlotAmount,PODStdID,PODAmount from NVO_CusContractContDtls " +
                                      " where CCID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();


                    Cmd.Parameters.Clear();

                    trans.Commit();
                    ListContract.Add(new MyCustomerContract
                    {
                        ID = Data.ID,
                    });
                    return ListContract;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContract;
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


        public DataTable GetExistingCustomerContract(MyCustomerContract Data)
        {
            string _Query = "Select * from NVO_CustomerContract where (ID not in(" + Data.ID + ")) and (CustomerID ='" + Data.CustomerID + "' AND PrincipalID='" + Data.PrincipalID + "')";
            return GetViewData(_Query, "");
        }
        public List<MyCustomer> GetCustDropDownMaster(MyCustomer Data)
        {
            List<MyCustomer> ListCustomer = new List<MyCustomer>();
            DataTable dt = GetCustDropDownValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                });

            }
            return ListCustomer;
        }

        public DataTable GetCustDropDownValues(MyCustomer Data)
        {
            string _Query = "Select * from NVO_CustomerMaster";
            return GetViewData(_Query, "");
        }
        public List<MyPortAgency> PrincipalList(MyPortAgency Data)
        {
            List<MyPortAgency> ListAgencyPort = new List<MyPortAgency>();
            DataTable dt = GetPrincipalList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgencyPort.Add(new MyPortAgency

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PrincipalName = dt.Rows[i]["PrincipalName"].ToString()
                });
            }
            return ListAgencyPort;
        }
        public DataTable GetPrincipalList(MyPortAgency Data)
        {
            string _Query = "select ID,(LineCode +'-'+ LineName) as PrincipalName from NVO_Principalmaster where Status=1 order by ID ";
            return GetViewData(_Query, "");
        }
        public List<MyGeneralMaster> RouteMaster(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneral = new List<MyGeneralMaster>();
            DataTable dt = GetRouteValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyGeneralMaster

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListGeneral;
        }
        public DataTable GetRouteValues(MyGeneralMaster Data)
        {
            string _Query = "select ID,GeneralName  from NVO_GeneralMaster where SeqNo=49";
            return GetViewData(_Query, "");
        }

        public List<MyGeneralMaster> DeliveryTermsMaster(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneral = new List<MyGeneralMaster>();
            DataTable dt = GetDeliveryTermsValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyGeneralMaster

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListGeneral;
        }
        public DataTable GetDeliveryTermsValues(MyGeneralMaster Data)
        {
            string _Query = "select ID,GeneralName  from NVO_GeneralMaster where SeqNo=75";
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> SalesPersonMaster(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListUser = new List<MyCustomerContract>();
            DataTable dt = GetUserDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyCustomerContract

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString()
                });
            }
            return ListUser;
        }
        public DataTable GetUserDetails(MyCustomerContract Data)
        {
            string _Query = "select ID,UserName  from NVO_UserDetails";
            return GetViewData(_Query, "");
        }


        public List<MyCustomerContract> CustomerContractMasterView(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListUser = new List<MyCustomerContract>();
            DataTable dt = GetCustomerContractValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyCustomerContract

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CustomerN = dt.Rows[i]["CustomerN"].ToString(),
                    Principal = dt.Rows[i]["Principal"].ToString(),
                    PrincipalN = dt.Rows[i]["PrincipalN"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    ContractDateV = dt.Rows[i]["ContractDateV"].ToString(),
                    ContractNo = dt.Rows[i]["ContractNo"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    ValidStatus = dt.Rows[i]["ValidStatus"].ToString(),
                    ValidStatusID = Int32.Parse(dt.Rows[i]["ValidStatusID"].ToString()),
                    OpenCount = Int32.Parse(dt.Rows[i]["OpenCount"].ToString()),
                });
            }
            return ListUser;
        }
        public DataTable GetCustomerContractValues(MyCustomerContract Data)
        {
            string CntrDate = "";
            string CntrDateTill = "";


            //if (Data.ContractDate != "")
            //    CntrDate = DateTime.Parse(Data.ContractDate).ToString("dd/MM/yyyy");

            //if (Data.ContractDateTill != "")
            //    CntrDateTill = DateTime.Parse(Data.ContractDateTill).ToString("dd/MM/yyyy");



            string strWhere = "";

            //string _Query = "select ID, " +
            //                " (Select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_CustomerContract.CustomerID) as CustomerName,Status, " +
            //                " (select(LineCode + '-' + LineName) as PrincipalName from NVO_Principalmaster where NVO_PrincipalMaster.ID = NVO_CustomerContract.PrincipalID)as Principal, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_CustomerContract.LoadPortID)as POL, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_CustomerContract.DestinationID)as POD, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_CustomerContract.DischargePortID)as FPOD, " +
            //                " convert(varchar, NVO_CustomerContract.ContractDate, 103) as ContractDate,ContractNo,Case when Status = 1 then 'ACTIVE' else Case when Status=2 then 'APPROVED' else case when Status=3 then 'REJECTED' else case when Status=4 then 'CANCELLED' end end end end as StatusV " +
            //                " from NVO_CustomerContract";

            string _Query = "Select Left(CustomerName,17)as CustomerN,Left(Principal,17)as PrincipalN,Status,ValidStatusID, * from CusContractV";

            if (Data.OfficeLocation.ToString() != "0" && Data.OfficeLocation.ToString() != null)
                if (strWhere == "")
                    strWhere += _Query + " where OfficeLocation = " + Data.OfficeLocation;
                else
                    strWhere += " and OfficeLocation = " + Data.OfficeLocation;

            if (Data.CustomerID.ToString() != "" && Data.CustomerID.ToString() != null && Data.CustomerID.ToString() != "0" && Data.CustomerID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where CustomerID =" + Data.CustomerID.ToString();
                else
                    strWhere += " and CustomerID =" + Data.CustomerID.ToString();

            if (Data.PrincipalID.ToString() != "" && Data.PrincipalID.ToString() != null && Data.PrincipalID.ToString() != "0" && Data.PrincipalID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where PrincipalID =" + Data.PrincipalID.ToString();
                else
                    strWhere += " and PrincipalID =" + Data.PrincipalID.ToString();

            if (Data.LoadPortID.ToString() != "" && Data.LoadPortID.ToString() != null && Data.LoadPortID.ToString() != "0" && Data.LoadPortID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where LoadPortID =" + Data.LoadPortID.ToString();
                else
                    strWhere += " and LoadPortID =" + Data.LoadPortID.ToString();

            //if (Data.DestinationID.ToString() != "" && Data.DestinationID.ToString() != null && Data.DestinationID.ToString() != "0" && Data.DestinationID.ToString() != "?")

            //    if (strWhere == "")
            //        strWhere += _Query + " where DestinationID =" + Data.DestinationID.ToString();
            //    else
            //        strWhere += " and DestinationID =" + Data.DestinationID.ToString();

            if (Data.DischargePortID.ToString() != "" && Data.DischargePortID.ToString() != null && Data.DischargePortID.ToString() != "0" && Data.DischargePortID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where DischargePortID =" + Data.DischargePortID.ToString();
                else
                    strWhere += " and DischargePortID =" + Data.DischargePortID.ToString();


            if (Data.ContractNo != "" && Data.ContractNo != null)
                if (strWhere == "")
                    strWhere += _Query + " where ContractNo like '%" + Data.ContractNo + "%'";
                else
                    strWhere += " and ContractNo like '%" + Data.ContractNo + "%'";

            //if (Data.ContractDate != "")
            //    if (strWhere == "")
            //        strWhere += _Query + " where ContractDate='" + CntrDate + "'";
            //    else
            //        strWhere += " and ContractDate='" + CntrDate + "'";


            if (Data.ContractDate != "" && Data.ContractDate != null)
                if (strWhere == "")
                    strWhere += _Query + " where ContractDate >= '" + DateTime.Parse(Data.ContractDate.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ContractDate >= '" + DateTime.Parse(Data.ContractDate.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.ContractDateTill != "" && Data.ContractDateTill != null)
                if (strWhere == "")
                    strWhere += _Query + " where ContractDate <= '" + DateTime.Parse(Data.ContractDateTill.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ContractDate <= '" + DateTime.Parse(Data.ContractDateTill.ToString()).ToString("MM/dd/yyyy") + "'";


            if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();
                else
                    strWhere += " and Status =" + Data.Status.ToString();

            if (Data.ValidStatusID.ToString() != "" && Data.ValidStatusID.ToString() != null && Data.ValidStatusID.ToString() != "0" && Data.ValidStatusID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where ValidStatusID =" + Data.ValidStatusID.ToString();
                else
                    strWhere += " and ValidStatusID =" + Data.ValidStatusID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " ORDER BY ContractDate desc ", "");

        }

        public List<MyCustomerContract> GetCustomerContractRecord(MyCustomerContract Data)
        {
            DataTable dt = GetCustomerContractEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContract.Add(new MyCustomerContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    PrincipalID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    ContractNo = dt.Rows[i]["ContractNo"].ToString(),
                    ContractDate = dt.Rows[i]["ContractDate"].ToString(),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    OriginID = Int32.Parse(dt.Rows[i]["OriginID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["LoadPortID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["DestinationID"].ToString()),
                    DischargePortID = Int32.Parse(dt.Rows[i]["DischargePortID"].ToString()),
                    RouteID = Int32.Parse(dt.Rows[i]["RouteID"].ToString()),
                    DeliveryTermsID = Int32.Parse(dt.Rows[i]["DeliveryTermsID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    FreeDaysOriginType = Int32.Parse(dt.Rows[i]["FreeDaysOriginType"].ToString()),
                    FreeDaysOrigin = dt.Rows[i]["FreeDaysOrigin"].ToString(),
                    FreeDaysDestinationType = Int32.Parse(dt.Rows[i]["FreeDaysDestinationType"].ToString()),
                    FreeDaysDestination = dt.Rows[i]["FreeDaysDestination"].ToString(),
                    DamageSchemeType = Int32.Parse(dt.Rows[i]["DamageSchemeType"].ToString()),
                    DamageScheme = dt.Rows[i]["DamageScheme"].ToString(),
                    SecDepositType = Int32.Parse(dt.Rows[i]["SecDepositType"].ToString()),
                    SecDeposit = dt.Rows[i]["SecDeposit"].ToString(),
                    BOLReqType = Int32.Parse(dt.Rows[i]["BOLReqType"].ToString()),
                    BOLReq = dt.Rows[i]["BOLReq"].ToString(),
                    Reason = dt.Rows[i]["Reason"].ToString(),
                    CancelReasonValue = dt.Rows[i]["CancelReasonValue"].ToString(),
                    RejectReason = dt.Rows[i]["RejectReason"].ToString(),
                    RejectReasonValue = dt.Rows[i]["RejectReasonValue"].ToString(),
                    OfficeLocation = Int32.Parse(dt.Rows[i]["OfficeLocation"].ToString()),
                });
            }
            return ListContract;
        }
        public DataTable GetCustomerContractEditValues(MyCustomerContract Data)
        {
            string _Query = "Select convert(varchar, NVO_CustomerContract.ContractDate, 23) as ContractDate,convert(varchar, NVO_CustomerContract.ValidTill, 23) as ValidTill, " +
                            " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_CustomerContract.CancelReasonID) as CancelReasonValue,Reason, " +
                            " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_CustomerContract.RejectReasonID) as RejectReasonValue,RejectReason, " +
                            " * from NVO_CustomerContract where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyGeneralMaster> CargoTypeMaster(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneral = new List<MyGeneralMaster>();
            DataTable dt = GetCargoTypeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyGeneralMaster

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListGeneral;
        }
        public DataTable GetCargoTypeValues(MyGeneralMaster Data)
        {
            string _Query = "select ID,GeneralName  from NVO_GeneralMaster where SeqNo=8";
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> RateReqDropDown(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListRR = new List<MyCustomerContract>();
            DataTable dt = GetRRValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRR.Add(new MyCustomerContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                });
            }
            return ListRR;
        }
        public DataTable GetRRValues(MyCustomerContract Data)
        {
            string _Query = "select ID,RequestNo  from NVO_PrincipalRateRequest";
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> ContainerMaster(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListUser = new List<MyCustomerContract>();
            DataTable dt = GetContainerDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyCustomerContract

                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    ContainerTypeID = Int32.Parse(dt.Rows[i]["ContainerTypeID"].ToString()),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CargoTypeID = Int32.Parse(dt.Rows[i]["CargoTypeID"].ToString()),
                    OceanAmount = decimal.Parse(dt.Rows[i]["OceanAmount"].ToString()),
                    OceanCurrencyID = Int32.Parse(dt.Rows[i]["OceanCurrencyID"].ToString()),
                    SlotAmount = decimal.Parse(dt.Rows[i]["SlotAmount"].ToString()),
                    PODStdID = Int32.Parse(dt.Rows[i]["PODStdID"].ToString()),
                    PODAmount = decimal.Parse(dt.Rows[i]["PODAmount"].ToString()),
                });
            }
            return ListUser;
        }
        public DataTable GetContainerDtls(MyCustomerContract Data)
        {
            string _Query = "select *  from NVO_CusContractContDtls where CCID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> RateReqChange(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListContract = new List<MyCustomerContract>();
            DataTable dt = GetCustomerContractDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContract.Add(new MyCustomerContract

                {
                    RRID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PrincipalID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["Createdby"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTillDt"].ToString(),
                    OriginID = Int32.Parse(dt.Rows[i]["OrginID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["LoadPortID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["DestinationID"].ToString()),
                    DischargePortID = Int32.Parse(dt.Rows[i]["DisPortID"].ToString()),
                    RouteID = Int32.Parse(dt.Rows[i]["RouteID"].ToString()),
                    DeliveryTermsID = Int32.Parse(dt.Rows[i]["DeliveryTermID"].ToString()),
                    FreeDaysOriginType = Int32.Parse(dt.Rows[i]["FreeDaysOrigin"].ToString()),
                    FreeDaysOrigin = dt.Rows[i]["FreeDaysOrgValue"].ToString(),
                    FreeDaysDestinationType = Int32.Parse(dt.Rows[i]["FreeDaysDest"].ToString()),
                    FreeDaysDestination = dt.Rows[i]["FreeDaysDestValue"].ToString(),
                    DamageSchemeType = Int32.Parse(dt.Rows[i]["DamageScheme"].ToString()),
                    DamageScheme = dt.Rows[i]["DamageSchemeValue"].ToString(),
                    SecDepositType = Int32.Parse(dt.Rows[i]["SecurityDeposit"].ToString()),
                    SecDeposit = dt.Rows[i]["SecurityDepositDesc"].ToString(),
                    BOLReqType = Int32.Parse(dt.Rows[i]["BOLReq"].ToString()),
                    BOLReq = dt.Rows[i]["BOLReqDesc"].ToString()
                });
            }
            return ListContract;
        }

        public DataTable GetCustomerContractDtls(MyCustomerContract Data)
        {
            string _Query = "select * from NVO_PrincipalRateRequest where ID =" + Data.RRID;
            return GetViewData(_Query, "");
        }


        public List<MyCustomerContract> ExContainerMaster(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListUser = new List<MyCustomerContract>();
            DataTable dt = GetExContainerDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyCustomerContract
                {
                    //CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    ContainerTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CargoTypeID = Int32.Parse(dt.Rows[i]["CargoTypeID"].ToString()),
                    OceanAmount = decimal.Parse(dt.Rows[i]["FrieghtAmount"].ToString()),
                    OceanCurrencyID = Int32.Parse(dt.Rows[i]["FrtCurrID"].ToString()),
                    SlotAmount = decimal.Parse(dt.Rows[i]["SlotAmount"].ToString()),
                    PODStdID = Int32.Parse(dt.Rows[i]["StdSplVID"].ToString()),
                    PODAmount = decimal.Parse(dt.Rows[i]["StdSplVAmount"].ToString()),
                });
            }
            return ListUser;
        }
        public DataTable GetExContainerDtls(MyCustomerContract Data)
        {
            string _Query = "select *  from NVO_PrincipleRRCharges where RRID =" + Data.RRID;
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> GetCustomerContractCopy(MyCustomerContract Data)
        {
            DataTable dt = GetCopyContractDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContract.Add(new MyCustomerContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    PrincipalID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    ContractNo = dt.Rows[i]["ContractNo"].ToString(),
                    ContractDate = dt.Rows[i]["ContractDate"].ToString(),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    OriginID = Int32.Parse(dt.Rows[i]["OriginID"].ToString()),
                    LoadPortID = Int32.Parse(dt.Rows[i]["LoadPortID"].ToString()),
                    DestinationID = Int32.Parse(dt.Rows[i]["DestinationID"].ToString()),
                    DischargePortID = Int32.Parse(dt.Rows[i]["DischargePortID"].ToString()),
                    RouteID = Int32.Parse(dt.Rows[i]["RouteID"].ToString()),
                    DeliveryTermsID = Int32.Parse(dt.Rows[i]["DeliveryTermsID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    FreeDaysOriginType = Int32.Parse(dt.Rows[i]["FreeDaysOriginType"].ToString()),
                    FreeDaysOrigin = dt.Rows[i]["FreeDaysOrigin"].ToString(),
                    FreeDaysDestinationType = Int32.Parse(dt.Rows[i]["FreeDaysDestinationType"].ToString()),
                    FreeDaysDestination = dt.Rows[i]["FreeDaysDestination"].ToString(),
                    DamageSchemeType = Int32.Parse(dt.Rows[i]["DamageSchemeType"].ToString()),
                    DamageScheme = dt.Rows[i]["DamageScheme"].ToString(),
                    SecDepositType = Int32.Parse(dt.Rows[i]["SecDepositType"].ToString()),
                    SecDeposit = dt.Rows[i]["SecDeposit"].ToString(),
                    BOLReqType = Int32.Parse(dt.Rows[i]["BOLReqType"].ToString()),
                    BOLReq = dt.Rows[i]["BOLReq"].ToString(),
                });
            }
            return ListContract;
        }
        public DataTable GetCopyContractDtls(MyCustomerContract Data)
        {
            string _Query = "select *  from NVO_CustomerContract where ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> AttachmentView(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListContract = new List<MyCustomerContract>();
            DataTable dt = GetCusContAttachDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContract.Add(new MyCustomerContract
                {
                    AID = Int32.Parse(dt.Rows[i]["AID"].ToString()),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    AttachName = dt.Rows[i]["AttachName"].ToString(),
                });

            }
            return ListContract;
        }

        public DataTable GetCusContAttachDtls(MyCustomerContract Data)
        {
            string _Query = "Select * from NVO_CusContAttachments where CCID=" + Data.ID;
            return GetViewData(_Query, "");
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



        public List<MyCustomerContract> UpdateApprovalStatus(MyCustomerContract Data)
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

                    Cmd.CommandText = "Update NVO_CustomerContract Set Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListContract.Add(new MyCustomerContract
                    {
                        ID = Data.ID,
                    });
                    return ListContract;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContract;
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

        public List<MyCustomerContract> UpdateRejectStatus(MyCustomerContract Data)
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

                    Cmd.CommandText = "Update NVO_CustomerContract Set Status=@Status,RejectReason=@RejectReason,RejectReasonID=@RejectReasonID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectReason", Data.RejectReason));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectReasonID", Data.RejectReasonID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListContract.Add(new MyCustomerContract
                    {
                        ID = Data.ID,
                    });
                    return ListContract;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContract;
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

        public List<MyCustomerContract> UpdateCancelStatus(MyCustomerContract Data)
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

                    Cmd.CommandText = "Update NVO_CustomerContract Set Status=@Status,Reason=@Reason,CancelReasonID=@CancelReasonID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reason", Data.Reason));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelReasonID", Data.CancelReasonID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListContract.Add(new MyCustomerContract
                    {
                        ID = Data.ID,
                    });
                    return ListContract;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContract;
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

        public List<MyCustomerContract> AttachDelete(MyCustomerContract Data)
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

                    Cmd.CommandText = "Delete NVO_CusContAttachments where AID=" + Data.AID;

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListContract.Add(new MyCustomerContract
                    {
                        ID = Data.ID,
                    });
                    return ListContract;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContract;
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

        public List<MyGeneralMaster> RejectReason(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneral = new List<MyGeneralMaster>();
            DataTable dt = GetRejectReason(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyGeneralMaster

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListGeneral;
        }
        public DataTable GetRejectReason(MyGeneralMaster Data)
        {
            string _Query = "select ID,GeneralName  from NVO_GeneralMaster where SeqNo=78";
            return GetViewData(_Query, "");
        }

        public List<MyGeneralMaster> CancelReason(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneral = new List<MyGeneralMaster>();
            DataTable dt = GetCancelReason(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyGeneralMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListGeneral;
        }
        public DataTable GetCancelReason(MyGeneralMaster Data)
        {
            string _Query = "select ID,GeneralName  from NVO_GeneralMaster where SeqNo=79";
            return GetViewData(_Query, "");
        }

        public List<MyCustomerContract> DeleteContractDtls(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListGeneral = new List<MyCustomerContract>();
            DataTable dt = ContainerDeleteValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyCustomerContract
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),

                });
            }
            return ListGeneral;
        }
        public DataTable ContainerDeleteValues(MyCustomerContract Data)
        {
            string _Query = "Delete from NVO_CusContractContDtls where CID=" + Data.CID;
            return GetViewData(_Query, "");
        }
        public List<MyCustomerContract> GetBindCustContractByoffice(MyCustomerContract Data)
        {
            List<MyCustomerContract> ListRR = new List<MyCustomerContract>();
            DataTable dt = GetBindCustContractByofficeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRR.Add(new MyCustomerContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                });
            }
            return ListRR;
        }
        public DataTable GetBindCustContractByofficeValues(MyCustomerContract Data)
        {
            string _Query = "select ID,RequestNo  from NVO_PrincipalRateRequest where OfficeLocID=" + Data.OfficeLocID;
            return GetViewData(_Query, "");
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

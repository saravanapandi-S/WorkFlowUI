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
using System.Collections;
using System.Globalization;
namespace DataManager
{
    public class ContainerManager
    {
        List<MyContainerData> ListCntr = new List<MyContainerData>();
        List<MyLease> ListLease = new List<MyLease>();
        List<MyOnHire> ListOnHire = new List<MyOnHire>();
        List<MyOffHire> ListOffHire = new List<MyOffHire>();
        List<MyLeaseDetails> ListLeaseDtls = new List<MyLeaseDetails>();
        List<MyCntrMoveMent> ListCntrMv = new List<MyCntrMoveMent>();
        List<MyContainerRent> ListContRent = new List<MyContainerRent>();
        List<MyContainer> ListView = new List<MyContainer>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ContainerManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region GetView
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

        #region Ganesh

        #region Container master
        public List<MyContainerData> ListCntrTypeSize(MyContainerData Data)
        {
            DataTable dt = GetTypeSize();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    ID = Int32.Parse(dt.Rows[i]["TypeID"].ToString()),
                    Size = dt.Rows[i]["Size"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetTypeSize()
        {
            string _Query = "Select ID AS TypeID, Size  from NVO_tblCntrTypes order by ID";
            return GetViewData(_Query, "");
        }
        public List<MyContainerData> ModuleBindListValues(MyContainerData Data)
        {
            DataTable dt = GetModuleBindListValues();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetModuleBindListValues()
        {
            string _Query = "select * from NVO_GeneralMaster WHERE SeqNo=69";
            return GetViewData(_Query, "");
        }

        public List<MyContainerData> PrincipalMasterBindValues(MyContainerData Data)
        {
            DataTable dt = GetPrincipalMasterBindValues();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LineName = dt.Rows[i]["LineName"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetPrincipalMasterBindValues()
        {
            string _Query = "select ID,(LineCode +'-'+ LineName) AS LineName from NVO_Principalmaster";
            return GetViewData(_Query, "");
        }


        public List<MyContainerData> ISOCodeBindByType(MyContainerData Data)
        {
            DataTable dt = GetISOCodeBindByType(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    //ISOCodeID = Int32.Parse(dt.Rows[i]["ISOCodeID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetISOCodeBindByType(MyContainerData Data)
        {
            string _Query = "Select ISOCode  from NVO_tblCntrTypes where ID=" + Data.TypeID;
            return GetViewData(_Query, "");
        }
        public List<MyContainerData> ListISOCodes(MyContainerData Data)
        {
            DataTable dt = GetISOCodes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    ISOCodeID = Int32.Parse(dt.Rows[i]["ISOCodeID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetISOCodes()
        {
            string _Query = "Select ID AS ISOCodeID,ISOCode  from NVO_tblCntrTypes  order by ID";
            return GetViewData(_Query, "");
        }
        public List<MyContainerData> ListGrade(MyContainerData Data)
        {
            DataTable dt = GetListGrade();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    GradeID = Int32.Parse(dt.Rows[i]["GradeID"].ToString()),
                    Grade = dt.Rows[i]["Grade"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetListGrade()
        {
            string _Query = "Select ID AS GradeID, Generalname AS Grade  from NVO_GeneralMaster WHERE SEQNO = 12 ORDER BY Generalname";
            return GetViewData(_Query, "");
        }

        public List<MyContainerData> ListContainerStatus(MyContainerData Data)
        {
            DataTable dt = GetContainerStatus();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    Status = dt.Rows[i]["Status"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetContainerStatus()
        {
            string _Query = "Select ID AS StatusID, Generalname AS Status  from NVO_GeneralMaster WHERE SEQNO = 14 ORDER BY Generalname";
            return GetViewData(_Query, "");
        }
        public List<MyContainerData> ListLeaseTerm(MyContainerData Data)
        {
            DataTable dt = GetListLeaseTerm();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    LeaseTermID = Int32.Parse(dt.Rows[i]["LeaseTermID"].ToString()),
                    LeaseTerm = dt.Rows[i]["LeaseTerm"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetListLeaseTerm()
        {
            string _Query = "Select ID AS LeaseTermID, Generalname AS LeaseTerm  from NVO_GeneralMaster WHERE SEQNO = 13 ORDER BY Generalname";
            return GetViewData(_Query, "");
        }

        public List<MyContainerData> ListBoxOwner(MyContainerData Data)
        {
            DataTable dt = GetBoxOwner();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    BoxOwnerID = Int32.Parse(dt.Rows[i]["BoxOwnerID"].ToString()),
                    BoxOwner = dt.Rows[i]["BoxOwner"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetBoxOwner()
        {
            string _Query = "Select Id as BoxOwnerID, CustomerName as BoxOwner from NVO_CustomerMaster ORDER BY CustomerName ";
            return GetViewData(_Query, "");
        }

        public List<MyContainerData> ListLeasingPartner(MyContainerData Data)
        {
            DataTable dt = GetLeasingPartner();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    LeasingPartnerID = Int32.Parse(dt.Rows[i]["LeasingPartnerID"].ToString()),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString()
                });
            }
            return ListCntr;
        }

        public DataTable GetLeasingPartner()
        {
            string _Query = "Select Id as LeasingPartnerID, CustomerName as LeasingPartner from NVO_CustomerMaster ORDER BY CustomerName";
            return GetViewData(_Query, "");
        }
        public List<MyContainerData> InsertContainerMaster(MyContainerData Data)
        {

            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GetExistingContainers(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListCntr.Add(new MyContainerData
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Agency Name Already Exists"

                    }); ;
                    return ListCntr;
                }
            }
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

                    Cmd.CommandText = " IF((select count(*) from NVO_Containers where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Containers(CntrNo,TypeID,ISOCode,ModuleID,BoxOwnerID,StatusID,Remarks,IsPickUp,IsDropOff,PickUpLocID,DropOffLocID,PickUpDate,DropOffDate,PickUpRef,DropOffRef,UserID,AgencyID,StatusCode) " +
                                     " values (@CntrNo,@TypeID,@ISOCode,@ModuleID,@BoxOwnerID,@StatusID,@Remarks,@IsPickUp,@IsDropOff,@PickUpLocID,@DropOffLocID,@PickUpDate,@DropOffDate,@PickUpRef,@DropOffRef,@UserID,@AgencyID,@StatusCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Containers SET CntrNo=@CntrNo,TypeID=@TypeID,ISOCode=@ISOCode,ModuleID=@ModuleID,BoxOwnerID=@BoxOwnerID,StatusID=@StatusID,Remarks=@Remarks,IsPickUp=@IsPickUp, IsDropOff=@IsDropOff,PickUpLocID=@PickUpLocID,DropOffLocID=@DropOffLocID,PickUpDate=@PickUpDate,DropOffDate=@DropOffDate,PickUpRef=@PickUpRef,DropOffRef=@DropOffRef,UserID=@UserID,AgencyID=@AgencyID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", Data.CntrNo.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TypeID", Data.TypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", Data.ISOCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModuleID", Data.ModuleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BoxOwnerID", Data.LineID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsPickUp", Data.IsPickUp));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsDropOff", Data.IsDropOff));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpLocID", Data.PickUpLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffLocID", Data.DropOffLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDate", Data.PickUpDate));
                    if (Data.DropOffDate != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDate", Data.DropOffDate));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDate", DBNull.Value));
                    }
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpRef", Data.PickUpRef));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffRef", Data.DropOffRef));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", 1));
                    if (Data.StatusID == 1)
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "OH"));

                    }
                    if (Data.StatusID == 2)
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "OF"));

                    }


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    if (Data.ID == 0 && Data.StatusID == 1)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Containers')";
                        if (Data.ID == 0)
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        else
                            Data.ID = Data.ID;

                        string NewTxnsID = "0";
                        if (Data.ID == 1)
                        {
                            Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns')";
                        }
                        else
                        {
                            Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns')+1";
                        }
                        NewTxnsID = Cmd.ExecuteScalar().ToString();


                        Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,StatusCode,LocationID,DtMovement,NextPortID,DepotID,AgencyID,UserID) " +
                                     " values (@ContainerID,@StatusCode,@LocationID,@DtMovement,@NextPortID,@DepotID,@AgencyID,@UserID) ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", Data.PickUpDate));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.PickUpLocID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.PickUpLocID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", 1));
                        if (Data.StatusID == 1)
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "OH"));

                        }
                        if (Data.StatusID == 2)
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "OF"));

                        }

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        Cmd.CommandText = "Update NVO_Containers SET LastMoveMentID=@LastMoveMentID where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();

                    ListCntr.Add(new MyContainerData
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCntr;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCntr.Add(new MyContainerData
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListCntr;
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

        public DataTable GetExistingContainers(MyContainerData Data)
        {
            string _Query = "Select * from NVO_Containers where (ID not in(" + Data.ID + ")) and (CntrNo ='" + Data.CntrNo + "')";
            return GetViewData(_Query, "");
        }

        public List<MyContainerData> ContainersValidation(MyContainerData Data)
        {
            DataTable dt = GetContainersValidation(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListCntr.Add(new MyContainerData
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),

                });
            }
            return ListCntr;
        }

        public DataTable GetContainersValidation(MyContainerData Data)
        {
            string _Query = "Select * from NVO_Containers where CntrNo='" + Data.CntrNo + "'";

            return GetViewData(_Query, "");


        }

        public List<MyContainerData> ContainersMaster(MyContainerData Data)
        {
            DataTable dt = GetContainervalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListCntr.Add(new MyContainerData
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ModuleType = dt.Rows[i]["ModuleType"].ToString(),
                    LineName = dt.Rows[i]["OwningLine"].ToString(),

                });
            }
            return ListCntr;
        }

        public DataTable GetContainervalues(MyContainerData Data)
        {
            string _Query = "Select CN.ID,CN.CntrNo,(select top 1 SIZE from NVO_tblCntrTypes where ID = TypeID) as Size, " +
                             " Case when StatusID =1 then 'ACTIVE' WHEN StatusID=2 THEN 'IN-ACTIVE' END as Status, " +
                             " (select top 1(LineCode + '-' + LineName) as LineName from NVO_PrincipalMaster where ID = BoxOwnerID) as OwningLine, (select top 1 GeneralName from NVO_generalMaster where ID = ModuleID) as ModuleType from NVO_Containers CN ";

            string strWhere = "";

            if (Data.CntrNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where CN.CntrNo like '%" + Data.CntrNo + "%'";
                else
                    strWhere += " and CN.CntrNo like '%" + Data.CntrNo + "%'";

            if (Data.TypeID.ToString() != "" && Data.TypeID.ToString() != "0" && Data.TypeID.ToString() != null && Data.TypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where CN.TypeID=" + Data.TypeID.ToString();
                else
                    strWhere += " and CN.TypeID =" + Data.TypeID.ToString();

            if (Data.LineID.ToString() != "" && Data.LineID.ToString() != "0" && Data.LineID.ToString() != null && Data.LineID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where CN.BoxOwnerID=" + Data.LineID.ToString();
                else
                    strWhere += " and CN.BoxOwnerID =" + Data.LineID.ToString();

            if (Data.ModuleID.ToString() != "" && Data.ModuleID.ToString() != "0" && Data.ModuleID.ToString() != null && Data.ModuleID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where CN.LeasingPartnerID=" + Data.ModuleID.ToString();
                else
                    strWhere += " and CN.LeasingPartnerID =" + Data.ModuleID.ToString();

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where CN.StatusID=" + Data.StatusID.ToString();
                else
                    strWhere += " and CN.StatusID =" + Data.StatusID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyContainerData> GetContainerMasterRecord(MyContainerData Data)
        {
            DataTable dt = GetContainerRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCntr.Add(new MyContainerData
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    TypeID = Int32.Parse(dt.Rows[i]["TypeID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    LineID = Int32.Parse(dt.Rows[i]["BoxOwnerID"].ToString()),
                    ModuleID = Int32.Parse(dt.Rows[i]["ModuleID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    PickUpLocID = Int32.Parse(dt.Rows[i]["PickUpLocID"].ToString()),
                    DropOffLocID = Int32.Parse(dt.Rows[i]["DropOffLocID"].ToString()),
                    PickUpDate = dt.Rows[i]["PickUpDt"].ToString(),
                    DropOffDate = dt.Rows[i]["DropOffDt"].ToString(),
                    DropOffRef = dt.Rows[i]["DropOffRef"].ToString(),
                    PickUpRef = dt.Rows[i]["PickUpRef"].ToString(),
                    IsDropOff = Int32.Parse(dt.Rows[i]["IsDropOff"].ToString()),
                    IsPickUp = Int32.Parse(dt.Rows[i]["IsPickUp"].ToString()),
                });
            }
            return ListCntr;
        }
        public DataTable GetContainerRecord(MyContainerData Data)
        {
            string _Query = "select *,convert(varchar, PickUpDate, 23) as PickUpDt,convert(varchar, DropOffDate, 23) as DropOffDt,(Select top 1 ContractRefNO from nvo_leasecontract Where ID=PickUpRefID) as PickUpRef  from NVO_Containers where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Lease Contract
        public List<MyLease> ListPickUpCriteria(MyLease Data)
        {
            DataTable dt = GetPickUpCriteria();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    PickupCriteriaID = Int32.Parse(dt.Rows[i]["PickupCriteriaID"].ToString()),
                    PickupCriteria = dt.Rows[i]["PickupCriteria"].ToString()
                });
            }
            return ListLease;
        }

        public DataTable GetPickUpCriteria()
        {
            string _Query = "Select ID AS PickupCriteriaID, Generalname AS PickupCriteria  from NVO_GeneralMaster WHERE SEQNO = 15 ORDER BY Generalname";
            return GetViewData(_Query, "");
        }

        public List<MyLease> DepotMaster()
        {
            List<MyLease> ChargeList = new List<MyLease>();
            DataTable dt = GetDepotMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepotName = dt.Rows[i]["DepName"].ToString()
                });
            }
            return ListLease;
        }

        public DataTable GetDepotMaster()
        {
            string _Query = "select * from NVO_DepotMaster";
            return GetViewData(_Query, "");
        }
        public List<MyLease> DepotByPortMaster(MyLease Data)
        {
            List<MyLease> ChargeList = new List<MyLease>();
            DataTable dt = GetDepotByPortMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepotName = dt.Rows[i]["DepName"].ToString()
                });
            }
            return ListLease;
        }

        public DataTable GetDepotByPortMaster(MyLease Data)
        {
            string _Query = "select D.ID,DepName from NVO_DepotMasterPortDtls DP inner join NVO_DepotMaster D ON D.ID = DP.DepotID where DP.PortID = " + Data.ID;
            return GetViewData(_Query, "");

        }
        public List<MyLease> CityMaster()
        {
            List<MyLease> ChargeList = new List<MyLease>();
            DataTable dt = GetCityMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString()
                });
            }
            return ListLease;
        }

        public DataTable GetCityMaster()
        {
            string _Query = "select * from NVO_CityMaster order By CityName";
            return GetViewData(_Query, "");
        }

        public List<MyLease> InsertLeasingContractMaster(MyLease Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_LeaseContract where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LeaseContract(ContractRefNo,DtContract,DtContractFrom,DtContractTill,Description,LeasingPartnerID,LeaseTermID,PickupCriteriaID,Status,Remarks,CntrValue,CntrValueCurrID) " +
                                     " values (@ContractRefNo,@DtContract,@DtContractFrom,@DtContractTill,@Description,@LeasingPartnerID,@LeaseTermID,@PickupCriteriaID,@Status,@Remarks,@CntrValue,@CntrValueCurrID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LeaseContract SET ContractRefNo=@ContractRefNo,DtContract=@DtContract,DtContractFrom=@DtContractFrom,DtContractTill=@DtContractTill,Description=@Description,LeasingPartnerID=@LeasingPartnerID,LeaseTermID=@LeaseTermID,PickupCriteriaID=@PickupCriteriaID,Status=@Status,Remarks=@Remarks,CntrValue=@CntrValue,CntrValueCurrID=@CntrValueCurrID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContractRefNo", Data.ContractRefNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtContract", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtContractFrom", DateTime.ParseExact(Data.DtContractFrom, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtContractTill", DateTime.ParseExact(Data.DtContractTill, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingPartnerID", Data.LeasingPartnerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseTermID", Data.LeaseTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickupCriteriaID", Data.PickupCriteriaID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrValue", Data.CntrValue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrValueCurrID", Data.CntrValueCurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_LeaseContract')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);

                    Object[] ObjArray = Array1;

                    string[] StrArray = Array.ConvertAll(ObjArray, Convert.ToString);
                    for (int i = 1; i < StrArray.Length; i++)
                    {

                        ///Array = Array.Where(s => !String.IsNullOrEmpty(s)).ToArray();
                        var CharSplit = StrArray[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_LeaseDetails where LeaseContractID=@LeaseContractID and LID=@LID)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_LeaseDetails(LeaseContractID,CntrTypeID,CntrType,Qty,PickUpPortID,PickUpPort,PickUpTariffAmt,PickUpCurrID,PickUpCurr,PickUpDebitID,PickUpDebit,PickUpDepotID,PickUpDepot,PerDiemAmt,PerDiemCurrID,PerDiemCurr,FreeDays,DPPAmt,DPPCurrID,DPPCurr,DropOffPortID,DropOffPort,DropOffTariffAmt,DropOffCurrID,DropOffCurr,DropOffDebitID,DropOffDebit,DtAdded,HDIF,HDIFCurrID,HDIFCurr,HDOF,HDOFCurrID,HDOFCurr,DropOffDepotID,DropOffDepot) " +
                                       " values (@LeaseContractID,@CntrTypeID,@CntrType,@Qty,@PickUpPortID,@PickUpPort,@PickUpTariffAmt,@PickUpCurrID,@PickUpCurr,@PickUpDebitID,@PickUpDebit,@PickUpDepotID,@PickUpDepot,@PerDiemAmt,@PerDiemCurrID,@PerDiemCurr,@FreeDays,@DPPAmt,@DPPCurrID,@DPPCurr,@DropOffPortID,@DropOffPort,@DropOffTariffAmt,@DropOffCurrID,@DropOffCurr,@DropOffDebitID,@DropOffDebit,@DtAdded,@HDIF,@HDIFCurrID,@HDIFCurr,@HDOF,@HDOFCurrID,@HDOFCurr,@DropOffDepotID,@DropOffDepot) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_LeaseDetails SET LeaseContractID=@LeaseContractID,CntrTypeID=@CntrTypeID,CntrType=@CntrType,Qty=@Qty,PickUpPortID=@PickUpPortID,PickUpPort=@PickUpPort,PickUpTariffAmt=@PickUpTariffAmt,PickUpCurrID=@PickUpCurrID,PickUpCurr=@PickUpCurr,PickUpDebitID=@PickUpDebitID,PickUpDebit=@PickUpDebit,PickUpDepotID=@PickUpDepotID,PickUpDepot=@PickUpDepot,PerDiemAmt=@PerDiemAmt,PerDiemCurrID=@PerDiemCurrID,PerDiemCurr=@PerDiemCurr,FreeDays=@FreeDays,DPPAmt=@DPPAmt,DPPCurrID=@DPPCurrID,DPPCurr=@DPPCurr,DropOffPortID=@DropOffPortID,DropOffPort=@DropOffPort,DropOffTariffAmt=@DropOffTariffAmt,DropOffCurrID=@DropOffCurrID,DropOffCurr=@DropOffCurr,DropOffDebitID=@DropOffDebitID,DropOffDebit=@DropOffDebit,DtModified=@DtModified,HDIF=@HDIF,HDIFCurrID=@HDIFCurrID,HDIFCurr=@HDIFCurr,HDOF=@HDOF,HDOFCurrID=@HDOFCurrID,HDOFCurr=@HDOFCurr,DropOffDepotID=@DropOffDepotID,DropOffDepot=@DropOffDepot where LID=@LID and LeaseContractID=@LeaseContractID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PerDiemAmt", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PerDiemCurrID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PerDiemCurr", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DPPAmt", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DPPCurrID", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DPPCurr", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDebitID", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDebit", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HDIF", CharSplit[13]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HDIFCurrID", CharSplit[14]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HDIFCurr", CharSplit[15]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpTariffAmt", CharSplit[16]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpCurrID", CharSplit[17]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpCurr", CharSplit[18]));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpPortID", CharSplit[19]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpPort", CharSplit[20]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDepotID", CharSplit[21]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDepot", CharSplit[22]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDebitID", CharSplit[23]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDebit", CharSplit[24]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HDOF", CharSplit[25]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HDOFCurrID", CharSplit[26]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HDOFCurr", CharSplit[27]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffTariffAmt", CharSplit[28]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffCurrID", CharSplit[29]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffCurr", CharSplit[30]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffPortID", CharSplit[31]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffPort", CharSplit[32]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDepotID", CharSplit[33]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDepot", CharSplit[34]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseContractID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListLease.Add(new MyLease { ID = Data.ID });
                    return ListLease;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListLease;
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

        public List<MyLeaseDetails> InsertLeaseDetails(MyLeaseDetails Data)
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
                    Cmd.CommandText = "select ident_current('NVO_LeaseContract')";
                    if (Data.LeaseContractID == 0)
                        Data.LeaseContractID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.LeaseContractID = Data.LeaseContractID;

                    Cmd.CommandText = " IF((select count(*) from NVO_LeaseDetails where LID=@LID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LeaseDetails(LeaseContractID,CntrTypeID,Qty,PickUpPortID,PickUpTariffAmt,PickUpCurrID,IsPickUpDebit,PickUpDepotID,PerDiemAmt,PerDiemCurrID,FreeDays,InsAmt,InsCurrID,DPPAmt,DPPCurrID,DropOffPortID,DropOffTariffAmt,DropOffCurrID,IsDropOffDebit,Remarks,DtAdded) " +
                                     " values (@LeaseContractID,@CntrTypeID,@Qty,@PickUpPortID,@PickUpTariffAmt,@PickUpCurrID,@IsPickUpDebit,@PickUpDepotID,@PerDiemAmt,@PerDiemCurrID,@FreeDays,@InsAmt,@InsCurrID,@DPPAmt,@DPPCurrID,@DropOffPortID,@DropOffTariffAmt,@DropOffCurrID,@IsDropOffDebit,@Remarks,@DtAdded) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LeaseDetails SET LeaseContractID=@LeaseContractID,CntrTypeID=@CntrTypeID,Qty=@Qty,PickUpPortID=@PickUpPortID,PickUpTariffAmt=@PickUpTariffAmt,PickUpCurrID=@PickUpCurrID,IsPickUpDebit=@IsPickUpDebit,PickUpDepotID=@PickUpDepotID,PerDiemAmt=@PerDiemAmt,PerDiemCurrID=@PerDiemCurrID,FreeDays=@FreeDays,InsAmt=@InsAmt,InsCurrID=@InsCurrID,DPPAmt=@DPPAmt,DPPCurrID=@DPPCurrID,DropOffPortID=@DropOffPortID,DropOffTariffAmt=@DropOffTariffAmt,DropOffCurrID=@DropOffCurrID,IsDropOffDebit=@IsDropOffDebit,Remarks=@Remarks,DtModified=@DtModified where LID=@LID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LID", Data.LID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseContractID", Data.LeaseContractID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", Data.CntrTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", Data.Qty));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpPortID", Data.PickUpPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpTariffAmt", Data.PickUpTariffAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpCurrID", Data.PickUpCurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDebitID", Data.PickUpDebitID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDepotID", Data.PickUpDepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PerDiemAmt", Data.PerDiemAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PerDiemCurrID", Data.PerDiemCurrID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", Data.FreeDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InsAmt", Data.InsAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InsCurrID", Data.InsCurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DPPAmt", Data.DPPAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DPPCurrID", Data.DPPCurrID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffPortID", Data.DropOffPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffTariffAmt", Data.DropOffTariffAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffCurrID", Data.DropOffCurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDebitID", Data.DropOffDebitID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();

                    trans.Commit();
                    return ListLeaseDtls;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListLeaseDtls;
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
        public List<MyLease> LeaseContractMaster(MyLease Data)
        {
            DataTable dt = GetLeaseContractvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListLease.Add(new MyLease
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),
                    PickupCriteria = dt.Rows[i]["PickupCriteria"].ToString(),
                    DtContractFrom = dt.Rows[i]["DtContractFrom"].ToString(),
                    DtContractTill = dt.Rows[i]["DtContractTill"].ToString(),

                });
            }
            return ListLease;
        }

        public DataTable GetLeaseContractvalues(MyLease Data)
        {
            string _Query = "Select LC.ID,LC.ContractRefNo,CM.CustomerName as LeasingPartner,GM.GeneralName as PickupCriteria,convert(varchar,LC.DtContractFrom, 106) As DtContractFrom,convert(varchar,LC.DtContractTill, 106) As DtContractTill from NVO_LeaseContract LC " +
           " LEFT OUTER JOIN NVO_CustomerMaster CM ON CM.id = LC.LeasingPartnerID " +
           " LEFT OUTER JOIN NVO_GeneralMaster GM ON GM.id = LC.PickupCriteriaID AND GM.SeqNo = 15 ";

            string strWhere = "";

            if (Data.ContractRefNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where LC.ContractRefNo like '%" + Data.ContractRefNo + "%'";
                else
                    strWhere += " and LC.ContractRefNo like '%" + Data.ContractRefNo + "%'";

            if (Data.LeasingPartnerID.ToString() != "" && Data.LeasingPartnerID.ToString() != "0" && Data.LeasingPartnerID.ToString() != null && Data.LeasingPartnerID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where LC.LeasingPartnerID=" + Data.LeasingPartnerID.ToString();
                else
                    strWhere += " and LC.LeasingPartnerID =" + Data.LeasingPartnerID.ToString();

            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")
                if (strWhere == "")
                    strWhere += _Query + " where LC.Status =" + Data.Status.ToString();
                else
                    strWhere += " and LC.Status  =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyLease> GetLeaseContractRecord(MyLease Data)
        {
            DataTable dt = GetLeaseContract(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }

                ListLease.Add(new MyLease
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartnerID = Int32.Parse(dt.Rows[i]["LeasingPartnerID"].ToString()),
                    LeaseTermID = Int32.Parse(dt.Rows[i]["LeaseTermID"].ToString()),
                    PickupCriteriaID = Int32.Parse(dt.Rows[i]["PickupCriteriaID"].ToString()),
                    Description = dt.Rows[i]["Description"].ToString(),
                    DtContractFrom = dt.Rows[i]["DtContFrom"].ToString(),
                    DtContractTill = dt.Rows[i]["DtContTill"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    CntrValue = dt.Rows[i]["CntrValue"].ToString(),
                    CntrValueCurrID = Int32.Parse(dt.Rows[i]["CntrValueCurrID"].ToString()),
                    Status = St.ToString(),
                });
            }
            return ListLease;
        }
        public DataTable GetLeaseContract(MyLease Data)
        {
            string _Query = "select *,convert(varchar, DtContractFrom, 103) as DtContFrom," +
                " convert(varchar, DtContractTill, 103) as DtContTill  from NVO_LeaseContract where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyLeaseDetails> LeaseDetails(MyLeaseDetails Data)
        {
            DataTable dt = GetLeaseDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListLeaseDtls.Add(new MyLeaseDetails
                {

                    LID = Int32.Parse(dt.Rows[i]["LID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Qty = Int32.Parse(dt.Rows[i]["Qty"].ToString()),
                    FreeDays = Int32.Parse(dt.Rows[i]["FreeDays"].ToString()),
                    PerDiemAmt = Decimal.Parse(dt.Rows[i]["PerDiemAmt"].ToString()),
                    PerDiemCurrID = Int32.Parse(dt.Rows[i]["PerDiemCurrID"].ToString()),
                    PerDiemCurr = dt.Rows[i]["PerDiemCurr"].ToString(),
                    DPPAmt = Decimal.Parse(dt.Rows[i]["DPPAmt"].ToString()),
                    DPPCurrID = Int32.Parse(dt.Rows[i]["DPPCurrID"].ToString()),
                    DPPCurr = dt.Rows[i]["DPPCurr"].ToString(),
                    PickUpDebitID = Int32.Parse(dt.Rows[i]["PickUpDebitID"].ToString()),
                    PickUpDebit = dt.Rows[i]["PickUpDebit"].ToString(),
                    HDIF = Decimal.Parse(dt.Rows[i]["HDIF"].ToString()),
                    HDIFCurrID = Int32.Parse(dt.Rows[i]["HDIFCurrID"].ToString()),
                    HDIFCurr = dt.Rows[i]["HDIFCurr"].ToString(),
                    PickUpTariffAmt = Decimal.Parse(dt.Rows[i]["PickUpTariffAmt"].ToString()),
                    PickUpCurrID = Int32.Parse(dt.Rows[i]["PickUpCurrID"].ToString()),
                    PickUpCurr = dt.Rows[i]["PickUpCurr"].ToString(),
                    PickUpPortID = Int32.Parse(dt.Rows[i]["PickUpPortID"].ToString()),
                    PickUpPort = dt.Rows[i]["PickUpPort"].ToString(),
                    PickUpDepotID = Int32.Parse(dt.Rows[i]["PickUpDepotID"].ToString()),
                    PickUpDepot = dt.Rows[i]["PickUpDepot"].ToString(),
                    DropOffDebitID = Int32.Parse(dt.Rows[i]["DropOffDebitID"].ToString()),
                    DropOffDebit = dt.Rows[i]["DropOffDebit"].ToString(),
                    HDOF = Decimal.Parse(dt.Rows[i]["HDOF"].ToString()),
                    HDOFCurrID = Int32.Parse(dt.Rows[i]["HDOFCurrID"].ToString()),
                    HDOFCurr = dt.Rows[i]["HDOFCurr"].ToString(),
                    DropOffTariffAmt = Decimal.Parse(dt.Rows[i]["DropOffTariffAmt"].ToString()),
                    DropOffCurrID = Int32.Parse(dt.Rows[i]["DropOffCurrID"].ToString()),
                    DropOffCurr = dt.Rows[i]["DropOffCurr"].ToString(),
                    DropOffPortID = Int32.Parse(dt.Rows[i]["DropOffPortID"].ToString()),
                    DropOffPort = dt.Rows[i]["DropOffPort"].ToString(),
                    DropOffDepotID = Int32.Parse(dt.Rows[i]["DropOffDepotID"].ToString()),
                    DropOffDepot = dt.Rows[i]["DropOffDepot"].ToString(),

                });
            }
            return ListLeaseDtls;
        }

        public DataTable GetLeaseDetails(MyLeaseDetails Data)
        {
            string _Query = "select * from NVO_LeaseDetails where LeaseContractID = " + Data.LeaseContractID;

            string strWhere = "";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }


        public List<MyLeaseDetails> GetLeaseDetailsEdit(MyLeaseDetails Data)
        {
            DataTable dt = LeaseDetailsEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListLeaseDtls.Add(new MyLeaseDetails
                {
                    ID = Int32.Parse(dt.Rows[i]["LID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Qty = Int32.Parse(dt.Rows[i]["Qty"].ToString()),
                    PickUpPortID = Int32.Parse(dt.Rows[i]["PickUpPortID"].ToString()),
                    PickUpTariffAmt = Decimal.Parse(dt.Rows[i]["PickUpTariffAmt"].ToString()),
                    PickUpCurrID = Int32.Parse(dt.Rows[i]["PickUpCurrID"].ToString()),
                    PickUpDebitID = Int32.Parse(dt.Rows[i]["PickUpDebitID"].ToString()),

                    PickUpDepotID = Int32.Parse(dt.Rows[i]["PickUpDepotID"].ToString()),
                    PerDiemAmt = Decimal.Parse(dt.Rows[i]["PerDiemAmt"].ToString()),
                    PerDiemCurrID = Int32.Parse(dt.Rows[i]["PickUpCurrID"].ToString()),
                    FreeDays = Int32.Parse(dt.Rows[i]["FreeDays"].ToString()),
                    InsCurrID = Int32.Parse(dt.Rows[i]["InsCurrID"].ToString()),
                    InsAmt = Decimal.Parse(dt.Rows[i]["InsAmt"].ToString()),
                    DPPAmt = Decimal.Parse(dt.Rows[i]["DPPAmt"].ToString()),
                    DPPCurrID = Int32.Parse(dt.Rows[i]["DPPCurrID"].ToString()),
                    DropOffTariffAmt = Decimal.Parse(dt.Rows[i]["DropOffTariffAmt"].ToString()),
                    DropOffCurrID = Int32.Parse(dt.Rows[i]["DropOffCurrID"].ToString()),
                    DropOffPortID = Int32.Parse(dt.Rows[i]["DropOffPortID"].ToString()),
                    DropOffDebitID = Int32.Parse(dt.Rows[i]["DropOffDebitID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                });
            }
            return ListLeaseDtls;

        }
        public DataTable LeaseDetailsEdit(MyLeaseDetails Data)
        {
            string _Query = "select * from NVO_LeaseDetails where LID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable DeleteLeaseDetails(MyLeaseDetails Data)
        {

            string _Query = " Delete NVO_LeaseDetails where LID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyLease> GetLeasePickUpDtls(string LeaseID)
        {
            DataTable dt = GetLeasePickUpDtlsValues(LeaseID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    PID = Int32.Parse(dt.Rows[i]["PID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Quantity = Int32.Parse(dt.Rows[i]["Qty"].ToString()),
                    PerDiemAmt = Decimal.Parse(dt.Rows[i]["PerDiemAmt"].ToString()),
                    PerDiemAmountCurr = Int32.Parse(dt.Rows[i]["PerDiemAmountCurr"].ToString()),
                    FreeDays = Int32.Parse(dt.Rows[i]["FreeDays"].ToString()),
                    InsuranceAmt = Decimal.Parse(dt.Rows[i]["InsuranceAmt"].ToString()),
                    InsuranceAmtCurr = Int32.Parse(dt.Rows[i]["PerDiemAmountCurr"].ToString()),
                    PickUpLocID = Int32.Parse(dt.Rows[i]["PickUpLocID"].ToString()),
                    PickUpTariffAmt = Decimal.Parse(dt.Rows[i]["PickUpTariffAmt"].ToString()),
                    PickUpCurrID = Int32.Parse(dt.Rows[i]["PickUpCurrID"].ToString()),
                    DebitCredit = Int32.Parse(dt.Rows[i]["DebitCredit"].ToString()),
                    PickUpDepotID = Int32.Parse(dt.Rows[i]["PickUpDepotID"].ToString()),
                });
            }
            return ListLease;
        }
        public DataTable GetLeasePickUpDtlsValues(string LeaseID)
        {
            string _Query = "Select * from NVO_LeasePickUpdtls where LeaseContractID=" + LeaseID;
            return GetViewData(_Query, "");
        }

        public List<MyLease> GetLeaseDropUpDtls(string LeaseID)
        {
            DataTable dt = GetLeaseDropUpDtlsValues(LeaseID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    DID = Int32.Parse(dt.Rows[i]["DID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Quantity = Int32.Parse(dt.Rows[i]["Qty"].ToString()),
                    PerDiemAmt = Decimal.Parse(dt.Rows[i]["PerDiemAmt"].ToString()),
                    PerDiemAmountCurr = Int32.Parse(dt.Rows[i]["PerDiemAmountCurr"].ToString()),
                    FreeDays = Int32.Parse(dt.Rows[i]["FreeDays"].ToString()),
                    InsuranceAmt = Decimal.Parse(dt.Rows[i]["InsuranceAmt"].ToString()),
                    InsuranceAmtCurr = Int32.Parse(dt.Rows[i]["PerDiemAmountCurr"].ToString()),
                    DropUpLocID = Int32.Parse(dt.Rows[i]["DropUpLocID"].ToString()),
                    DropUpTariffAmt = Decimal.Parse(dt.Rows[i]["DropUpTariffAmt"].ToString()),
                    DropUpCurrID = Int32.Parse(dt.Rows[i]["DropUpCurrID"].ToString()),
                    DebitCredit = Int32.Parse(dt.Rows[i]["DebitCredit"].ToString()),
                    DropUpDepotID = Int32.Parse(dt.Rows[i]["DropUpDepotID"].ToString()),
                });
            }
            return ListLease;
        }
        public DataTable GetLeaseDropUpDtlsValues(string LeaseID)
        {
            string _Query = "Select * from NVO_LeaseDropUpdtls where LeaseContractID=" + LeaseID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region ON-HIRE
        public List<MyOnHire> ListPickUpReference(MyOnHire Data)
        {
            DataTable dt = GetPickUpReference();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOnHire.Add(new MyOnHire
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString()
                });
            }
            return ListOnHire;
        }
        public DataTable GetPickUpReference()
        {
            string _Query = "Select * FROM NVO_LeaseContract Order by ContractRefNo";
            return GetViewData(_Query, "");
        }

        public List<MyLease> GetCntrTypesFromPickUp(string LeaseID)
        {
            DataTable dt = GetCntrTypesFromPickUpDtls(LeaseID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLease.Add(new MyLease
                {
                    // LeaseContractID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    TypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Quantity = Int32.Parse(dt.Rows[i]["Qty"].ToString()),
                    Cntrcount = Int32.Parse(dt.Rows[i]["Cntrcount"].ToString()),
                    LeaseTermID = Int32.Parse(dt.Rows[i]["LeaseTermID"].ToString()),
                    LeasingPartnerID = Int32.Parse(dt.Rows[i]["LeasingPartnerID"].ToString()),
                    LeaseTerm = dt.Rows[i]["LeaseTerm"].ToString(),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),

                });
            }
            return ListLease;
        }
        public DataTable GetCntrTypesFromPickUpDtls(string LeaseID)
        {
            string _Query = "Select LC.ID as LeaseContractID, CntrTypeID,Size,Qty,A.Cntrcount as Cntrcount,LC.LeaseTermID,LC.LeasingPartnerID,GM.GENERALNAME AS LeaseTerm,CM.CustomerName AS LeasingPartner from NVO_LeaseDetails LP Inner Join NVO_tblCntrTypes TC on TC.ID = LP.CntrTypeID " +
              " Inner Join NVO_LeaseContract LC on LC.ID = LP.LeaseContractID " +
              "  Inner Join NVO_Generalmaster GM on GM.ID = LC.LeaseTermID AND GM.SEQNO = 13 " +
         " Inner Join NVO_CustomerMaster CM on CM.ID = LC.LeasingPartnerID " +
            "outer apply(Select count(CntrNo) as Cntrcount from NVO_Containers " +
           " inner join NVO_LeaseDetails LP1 on LP1.LeaseContractID = NVO_Containers.PickUpRefID where NVO_Containers.PickUpRefID = " + LeaseID + "  ) A " +
           " where LeaseContractID = " + LeaseID;
            return GetViewData(_Query, "");
        }

        public List<MyOnHire> InsertOnHireRequestMaster(MyOnHire Data)
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
                    if (Data.RequestNo == "")
                    {
                        string AutoGen = GetMaxseqNumber("OnHireNo", "1");
                        Cmd.CommandText = "select 'OHR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RequestNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_ContainerOnHire where LeasePickUpRefID=@LeasePickUpRefID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ContainerOnHire(RequestNo,LeasePickUpRefID,OnHireLeasingPartnerID,OnHireBoxOwnerID,DtCreated,Status,Remarks,LeasingTermID,IsApproved) " +
                                     " values (@RequestNo,@LeasePickUpRefID,@OnHireLeasingPartnerID,@OnHireBoxOwnerID,@DtCreated,@Status,@Remarks,@LeasingTermID,@IsApproved) " +
                                     " END  " +
                                     " ELSE " +
                                  " UPDATE NVO_ContainerOnHire SET RequestNo=@RequestNo,LeasePickUpRefID=@LeasePickUpRefID,OnHireLeasingPartnerID=@OnHireLeasingPartnerID,OnHireBoxOwnerID=@OnHireBoxOwnerID,Status=@Status,Remarks=@Remarks,LeasingTermID=@LeasingTermID,IsApproved=@IsApproved where LeasePickUpRefID=@LeasePickUpRefID";

                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@HID", Data.HID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestNo", Data.RequestNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasePickUpRefID", Data.PickUpRefID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OnHireLeasingPartnerID", Data.LeasingPartnerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OnHireBoxOwnerID", Data.BoxOwnerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreated", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingTermID", Data.LeasingTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsApproved", 0));
                    int result = Cmd.ExecuteNonQuery();



                    string[] Array = Data.ItemsCntrs.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        Data.CntrID = 0;
                        Cmd.CommandText = "Select PickUpPortID from nvo_leasedetails WHERE LeaseContractID= " + Data.PickUpRefID;
                        Data.PortID = Cmd.ExecuteScalar().ToString();

                        Cmd.CommandText = "Select PickUpDepotID from nvo_leasedetails WHERE LeaseContractID= " + Data.PickUpRefID;

                        Data.DepotID = Cmd.ExecuteScalar().ToString();

                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_Containers where ID=@ID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_Containers(CntrNo,TypeID,ISOCodeID,GradeID,CubicCapacity,DtManufacture,GrWtx100,NtWtx100,TareWtx100,DtOnHire,LeaseTermID,PickUpRefID,BoxOwnerID,LeasingPartnerID,statusID,ApplicableAtID,Statuscode,CurrentPortID,DepotID) " +
                                         " values (@CntrNo,@TypeID,@ISOCodeID,@GradeID,@CubicCapacity,@DtManufacture,@GrWtx100,@NtWtx100,@TareWtx100,@DtOnHire,@LeaseTermID,@PickUpRefID,@BoxOwnerID,@LeasingPartnerID,@statusID,@ApplicableAtID,@Statuscode,@CurrentPortID,@DepotID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_Containers SET CntrNo=@CntrNo,TypeID=@TypeID,ISOCodeID=@ISOCodeID,GradeID=@GradeID,DtManufacture=@DtManufacture,GrWtx100=@GrWtx100,NtWtx100=@NtWtx100, TareWtx100=@TareWtx100,DtOnHire=@DtOnHire,LeaseTermID=@LeaseTermID,PickUpRefID=@PickUpRefID,BoxOwnerID=@BoxOwnerID,LeasingPartnerID=@LeasingPartnerID,statusID=@statusID,ApplicableAtID=@ApplicableAtID,Statuscode=@Statuscode,CurrentPortID=@CurrentPortID,DepotID=@DepotID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCodeID", CharSplit[3]));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GradeID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CubicCapacity", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrWtx100", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWtx100", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TareWtx100", CharSplit[8]));

                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@DtManufacture", CharSplit[9], "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(British Summer Time)'", CultureInfo.InvariantCulture));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtManufacture", DateTimeOffset.ParseExact(CharSplit[9], "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(India Standard Time)'", CultureInfo.InvariantCulture)));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtOnHire", DateTimeOffset.ParseExact(CharSplit[11], "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(India Standard Time)'", CultureInfo.InvariantCulture)));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ApplicableAtID", CharSplit[10]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@DtOnHire", System.DateTime.Now));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 31));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BoxOwnerID", Data.BoxOwnerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingPartnerID", Data.LeasingPartnerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseTermID", Data.LeasingTermID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpRefID", Data.PickUpRefID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Statuscode", "OH"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.PortID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (CharSplit[0] == "")
                        {
                            Cmd.CommandText = "SELECT Ident_current('NVO_Containers')";
                            Data.CntrID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                            string NewTxnsID = "0";
                            Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                            NewTxnsID = Cmd.ExecuteScalar().ToString();


                            Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,StatusCode,LocationID,DtMovement,NextPortID,DepotID,AgencyID,UserID) " +
                                         " values (@ContainerID,@StatusCode,@LocationID,@DtMovement,@NextPortID,@DepotID,@AgencyID,@UserID) ";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.CntrID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.PortID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", "160"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Statuscode", "OH"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                            Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();


                            Cmd.CommandText = "Update NVO_Containers SET LastMoveMentID=@LastMoveMentID where ID=@ID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CntrID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    trans.Commit();
                    return ListOnHire;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListOnHire;
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
        public List<MyOnHire> ListApplicableAtList(MyOnHire Data)
        {
            DataTable dt = GetApplicableAt();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOnHire.Add(new MyOnHire
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return ListOnHire;
        }

        public DataTable GetApplicableAt()
        {
            string _Query = "Select Id, CustomerName  from NVO_CustomerMaster ORDER BY CustomerName ";
            return GetViewData(_Query, "");
        }


        public List<MyOnHire> OnHireRequest(MyOnHire Data)
        {
            DataTable dt = GetOnHireRequest(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListOnHire.Add(new MyOnHire
                {

                    LeaseContractID = Int32.Parse(dt.Rows[i]["LeaseContractID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),
                    LeaseTerm = dt.Rows[i]["LeaseTerm"].ToString(),


                });
            }
            return ListOnHire;
        }

        public DataTable GetOnHireRequest(MyOnHire Data)
        {
            string _Query = "select LC.ID AS LeaseContractID,RequestNo,LC.ContractRefNo,cm.CustomerName as LeasingPartner,GM.GeneralName As LeaseTerm from NVO_ContainerOnHire OH " +
             " inner join NVO_LeaseContract LC on LC.ID = OH.LeasePickUpRefID " +
            " inner join NVO_CustomerMaster CM on CM.ID = OH.OnHireLeasingPartnerID " +
           " inner join NVO_GeneralMaster GM on GM.ID = OH.LeasingTermID  and GM.SeqNo = 13 ";

            string strWhere = "";


            if (Data.LeaseContractID.ToString() != "" && Data.LeaseContractID.ToString() != "0" && Data.LeaseContractID.ToString() != null && Data.LeaseContractID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where LC.ID=" + Data.LeaseContractID.ToString();
                else
                    strWhere += " and LC.ID =" + Data.LeaseContractID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyOnHire> OnHireRequestEditValues(MyOnHire Data)
        {
            DataTable dt = GetOnHireRequestValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListOnHire.Add(new MyOnHire
                {
                    //ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                    PickUpRefID = Int32.Parse(dt.Rows[i]["LeasePickUpRefID"].ToString()),
                    LeasingPartnerID = Int32.Parse(dt.Rows[i]["OnHireLeasingPartnerID"].ToString()),
                    BoxOwnerID = Int32.Parse(dt.Rows[i]["OnHireBoxOwnerID"].ToString()),
                    LeasingTermID = Int32.Parse(dt.Rows[i]["LeasingTermID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Status = St
                });
            }
            return ListOnHire;
        }

        public DataTable GetOnHireRequestValues(MyOnHire Data)
        {
            string _Query = "select * from NVO_ContainerOnHire WHERE LeasePickUpRefID =" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyContainerData> LeaseExistingContainersValues(MyContainerData Data)
        {
            DataTable dt = GetLeaseExistingContainers(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntr.Add(new MyContainerData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    TypeID = Int32.Parse(dt.Rows[i]["TypeID"].ToString()),
                    GradeID = Int32.Parse(dt.Rows[i]["GradeID"].ToString()),
                    ISOCodeID = Int32.Parse(dt.Rows[i]["ISOCodeID"].ToString()),
                    CubicCapacity = dt.Rows[i]["CubicCapacity"].ToString(),
                    GrWtx100 = Int32.Parse(dt.Rows[i]["GrWtx100"].ToString()),
                    NtWtx100 = Int32.Parse(dt.Rows[i]["NtWtx100"].ToString()),
                    TareWtx100 = Int32.Parse(dt.Rows[i]["TareWtx100"].ToString()),
                    DtManufacture = dt.Rows[i]["DtMf"].ToString(),
                    ApplicableAtID = Int32.Parse(dt.Rows[i]["ApplicableAtID"].ToString()),
                    DtOnHire = dt.Rows[i]["DtOnhr"].ToString(),
                });
            }
            return ListCntr;
        }

        public DataTable GetLeaseExistingContainers(MyContainerData Data)
        {
            string _Query = "select ID, CntrNo,TypeID,ISOCodeID,GradeID,CubicCapacity,GrWtx100,NtWtx100,TareWtx100, convert(varchar, DtManufacture, 23) as DtMf,ApplicableAtID, convert(varchar, DtOnHire, 23) as DtOnhr from NVO_Containers WHERE PickUpRefID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable ApproveOnHire(MyOnHire Data)
        {

            string _Query = " update NVO_ContainerOnHire set IsApproved=1 where LeasePickUpRefID=" + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyOnHire> CheckISApproveOnHire(MyOnHire Data)
        {
            DataTable dt = GetCheckISApproveOnHire(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOnHire.Add(new MyOnHire
                {
                    Isapproved = Int32.Parse(dt.Rows[i]["Isapproved"].ToString()),

                });
            }
            return ListOnHire;
        }

        public DataTable GetCheckISApproveOnHire(MyOnHire Data)
        {
            string _Query = "select Isapproved from NVO_ContainerOnHire where LeasePickUpRefID = " + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region OFF-HIRE
        public List<MyOffHire> ListBindCntrNos(MyOffHire Data)
        {
            DataTable dt = GetBindCntrNos();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOffHire.Add(new MyOffHire
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),

                });
            }
            return ListOffHire;
        }
        public DataTable GetBindCntrNos()
        {
            string _Query = "select ID,TypeID,PickUpRefID,CntrNo from NVO_Containers order by CntrNo ";
            return GetViewData(_Query, "");
        }
        public List<MyOffHire> ListBindOffHireCntrValues(MyOffHire Data)
        {
            DataTable dt = GetOffHireCntrValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOffHire.Add(new MyOffHire
                {
                    SizeTypeID = Int32.Parse(dt.Rows[i]["SizeTypeID"].ToString()),
                    Size = dt.Rows[i]["Size"].ToString(),
                    PickUpRefID = Int32.Parse(dt.Rows[i]["PickUpRefID"].ToString()),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartnerID = Int32.Parse(dt.Rows[i]["LeasingPartnerID"].ToString()),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),
                    LeasingTermID = Int32.Parse(dt.Rows[i]["LeasingTermID"].ToString()),
                    LeasingTerm = dt.Rows[i]["LeasingTerm"].ToString()

                }); ;
            }
            return ListOffHire;
        }

        public DataTable GetOffHireCntrValues(MyOffHire Data)
        {
            string _Query = " Select LC.ID AS PickupRefID, ContractRefNo ,CT.ID AS SizeTypeID,Ct.Size,CM.ID as LeasingPartnerID,CM.CustomerName as LeasingPartner,GM.ID As LeasingTermID, GM.GeneralName as LeasingTerm from  NVO_Containers C inner join NVO_LeaseContract LC on LC.ID = C.PickUpRefID inner join NVO_tblCntrTypes CT on CT.ID = C.TypeID " +
              " inner join NVO_CustomerMaster CM on CM.ID =C.LeasingPartnerID inner join NVO_GeneralMaster GM on GM.ID = C.LeaseTermID  and GM.SeqNo = 13 where C.ID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyOffHire> ListBindDropOffCurrAmtFromLease(MyOffHire Data)
        {
            DataTable dt = GetDropOffCurrAmtFromLease(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOffHire.Add(new MyOffHire
                {
                    DropOffTariffCurrID = Int32.Parse(dt.Rows[i]["DropOffCurrID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    DropOffTariff = Decimal.Parse(dt.Rows[i]["DropOffTariffAmt"].ToString()),
                });
            }
            return ListOffHire;
        }

        public DataTable GetDropOffCurrAmtFromLease(MyOffHire Data)
        {
            string _Query = "select LD.DropOffCurrID,cm.CurrencyCode,LD.DropOffTariffAmt from NVO_LeaseDetails LD inner join NVO_CurrencyMaster CM on CM.ID = LD.DropOffCurrID where LD.LeaseContractID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyOffHire> InsertOffHireRequest(MyOffHire Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ContainerOffHire where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ContainerOffHire(CntrID,SizeTypeID,LeasingPartnerID,LeasingTermID,PickupRefID,DropOffTariff,DropOffTariffCurrID,OffHirePortID,OffHireDepotID,DtOffHire,ResponseAgencyID,Remarks,CurrentDate) " +
                                     " values (@CntrID,@SizeTypeID,@LeasingPartnerID,@LeasingTermID,@PickupRefID,@DropOffTariff,@DropOffTariffCurrID,@OffHirePortID,@OffHireDepotID,@DtOffHire,@ResponseAgencyID,@Remarks,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ContainerOffHire SET CntrID=@CntrID,SizeTypeID=@SizeTypeID,LeasingTermID=@LeasingTermID,PickupRefID=@PickupRefID,DropOffTariff=@DropOffTariff,DropOffTariffCurrID=@DropOffTariffCurrID,OffHirePortID=@OffHirePortID, OffHireDepotID=@OffHireDepotID,DtOffHire=@DtOffHire,ResponseAgencyID=@ResponseAgencyID,Remarks=@Remarks,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SizeTypeID", Data.SizeTypeID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickupRefID", Data.PickUpRefID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingTermID", Data.LeasingTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingPartnerID", Data.LeasingPartnerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffTariff", Data.DropOffTariff));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffTariffCurrID", Data.DropOffTariffCurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OffHirePortID", Data.OffHirePortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OffHireDepotID", Data.OffHireDepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtOffHire", DateTime.ParseExact(Data.DtOffHire, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ResponseAgencyID", Data.ResponseAgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ContainerOffHire')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    Cmd.CommandText = "Update NVO_Containers SET DtOffHire= '" + DateTime.ParseExact(Data.DtOffHire, "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "' , StatusID=32 Where ID=" + Data.CntrID;
                    result = Cmd.ExecuteNonQuery();

                    Cmd.Parameters.Clear();
                    trans.Commit();
                    return ListOffHire;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListOffHire;
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

        public List<MyOffHire> OffHireRequest(MyOffHire Data)
        {
            DataTable dt = GetOffHireRequests(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListOffHire.Add(new MyOffHire
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),
                    LeasingTerm = dt.Rows[i]["LeasingTerm"].ToString(),
                    OffHireDepot = dt.Rows[i]["OffHireDepot"].ToString(),
                    OffHirePort = dt.Rows[i]["OffHirePort"].ToString(),
                    DtOffHire = dt.Rows[i]["DtOffHire"].ToString(),

                });
            }
            return ListOffHire;
        }

        public DataTable GetOffHireRequests(MyOffHire Data)
        {
            string _Query = " Select OH.ID,c.CntrNo,LC.ContractRefNo,CM.CustomerName As LeasingPartner,GM.GeneralName as LeasingTerm, " +
             " DM.DepName As OffHireDepot,PM.PortName AS OffHirePort,convert(varchar, OH.DtOffHire, 106) As DtOffHire from NVO_ContainerOffHire OH " +
            " inner join NVO_Containers C on C.ID = OH.CntrID inner join NVO_LeaseContract LC on LC.ID = OH.PickUpRefID " +
              " inner join NVO_CustomerMaster CM on CM.ID = OH.LeasingPartnerID " +
            " inner join NVO_GeneralMaster GM on GM.ID = OH.LeasingTermID  and GM.SeqNo = 13 " +
         " inner join NVO_DepotMaster DM on DM.ID = OH.OffHireDepotID " +
         " inner join NVO_PortMaster PM on PM.ID = OH.OffHirePortID";

            string strWhere = "";


            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where C.ID=" + Data.CntrID.ToString();
                else
                    strWhere += " and C.ID =" + Data.CntrID.ToString();

            if (Data.LeasingPartnerID.ToString() != "" && Data.LeasingPartnerID.ToString() != "0" && Data.LeasingPartnerID.ToString() != null && Data.LeasingPartnerID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OH.LeasingPartnerID=" + Data.LeasingPartnerID.ToString();
                else
                    strWhere += " and OH.LeasingPartnerID =" + Data.LeasingPartnerID.ToString();

            if (Data.LeasingTermID.ToString() != "" && Data.LeasingTermID.ToString() != "0" && Data.LeasingTermID.ToString() != null && Data.LeasingTermID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OH.LeasingTermID =" + Data.LeasingTermID.ToString();
                else
                    strWhere += " and OH.LeasingTermID =" + Data.LeasingTermID.ToString();

            if (Data.OffHireDepotID.ToString() != "" && Data.OffHireDepotID.ToString() != "0" && Data.OffHireDepotID.ToString() != null && Data.OffHireDepotID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OH.OffHireDepotID =" + Data.OffHireDepotID.ToString();
                else
                    strWhere += " and OH.OffHireDepotID =" + Data.OffHireDepotID.ToString();
            if (Data.OffHirePortID.ToString() != "" && Data.OffHirePortID.ToString() != "0" && Data.OffHirePortID.ToString() != null && Data.OffHirePortID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OH.OffHirePortID =" + Data.OffHirePortID.ToString();
                else
                    strWhere += " and OH.OffHirePortID =" + Data.OffHirePortID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyOffHire> GetOffHireRecord(MyOffHire Data)
        {
            DataTable dt = GetOffHireRecords(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListOffHire.Add(new MyOffHire
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    SizeTypeID = Int32.Parse(dt.Rows[i]["SizeTypeID"].ToString()),

                    LeasingPartnerID = Int32.Parse(dt.Rows[i]["LeasingPartnerID"].ToString()),
                    LeasingTermID = Int32.Parse(dt.Rows[i]["LeasingTermID"].ToString()),
                    PickUpRefID = Int32.Parse(dt.Rows[i]["PickUpRefID"].ToString()),
                    DropOffTariff = Decimal.Parse(dt.Rows[i]["DropOffTariff"].ToString()),
                    DropOffTariffCurrID = Int32.Parse(dt.Rows[i]["DropOffTariffCurrID"].ToString()),
                    OffHireDepotID = Int32.Parse(dt.Rows[i]["OffHireDepotID"].ToString()),
                    OffHirePortID = Int32.Parse(dt.Rows[i]["OffHirePortID"].ToString()),
                    ResponseAgencyID = Int32.Parse(dt.Rows[i]["ResponseAgencyID"].ToString()),
                    DtOffHire = dt.Rows[i]["OffHireDate"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                });
            }
            return ListOffHire;
        }
        public DataTable GetOffHireRecords(MyOffHire Data)
        {
            string _Query = "select *,convert(varchar, DtOffHire, 103) as OffHireDate  from NVO_ContainerOffHire where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Cntr Movement Entry

        public List<MyCntrMoveMent> ListDepotByGeoLocValus(MyCntrMoveMent Data)
        {
            DataTable dt = GetListDepotByGeoLocValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                    Depot = dt.Rows[i]["Depot"].ToString()
                });
            }
            return ListCntrMv;
        }

        public DataTable GetListDepotByGeoLocValus(MyCntrMoveMent Data)
        {
            string _Query = "select DepotID,Depot from NVO_GeoLocationDeportDtls where GeoLocID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyCntrMoveMent> BookingBLList(MyCntrMoveMent Data)
        {
            DataTable dt = GetBookingBLList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString()
                });
            }
            return ListCntrMv;
        }

        public DataTable GetBookingBLList()
        {
            string _Query = "select * from NVO_Booking order by ID";
            return GetViewData(_Query, "");
        }
        public List<MyCntrMoveMent> ListCntrStatusCodes(MyCntrMoveMent Data)
        {
            DataTable dt = GetStatusCodes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString()
                });
            }
            return ListCntrMv;
        }

        public DataTable GetStatusCodes()
        {
            string _Query = "Select ID,StatusCode from NVO_ContainerStatusCodes order by ID";
            return GetViewData(_Query, "");
        }

        public List<MyCntrMoveMent> ListTransitModes(MyCntrMoveMent Data)
        {
            DataTable dt = GetTransitModes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCntrMv;
        }
        public List<MyCntrMoveMent> CustomerMaster()
        {
            List<MyCreditControl> CustomerList = new List<MyCreditControl>();
            DataTable dt = GetCustomerMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return ListCntrMv;
        }

        public DataTable GetCustomerMaster()
        {
            string _Query = "select * from NVO_view_CustomerDetails";

            return GetViewData(_Query, "");
        }

        public DataTable GetTransitModes()
        {
            string _Query = "select  * from NVO_GeneralMaster where Seqno=31";
            return GetViewData(_Query, "");
        }
        public List<MyCntrMoveMent> ListCntrStatusCodesPossibleMoves(MyCntrMoveMent Data)
        {
            DataTable dt = GetCntrStatusCodesPossibleMoves(Data);


            ArrayList list = new ArrayList();

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                //string[] TST = dt.Rows[r]["PossibleMoves"].ToString().Split(',');
                //for (int r1 = 0; r1 < TST.Length; r1++)
                //{
                //    list.Add(TST[r1]);
                //    ListCntrMv.Add(new MyCntrMoveMent
                //    {
                //        ItemsStatusCodes = TST[r1]
                //    });
                //}
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    ToStatus = dt.Rows[r]["ToStatus"].ToString()
                });
            }

            return ListCntrMv;
        }

        public DataTable GetCntrStatusCodesPossibleMoves(MyCntrMoveMent Data)
        {
            string _Query = "select ToStatus FROM NVO_ContainerStatusPossibleMoves WHERE FromStatus='" + Data.StatusCode + "'";
            return GetViewData(_Query, "");
        }

        public List<MyCntrMoveMent> InsertContainerTxnsData(MyCntrMoveMent Data)
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
                    string NewTxnsID = "0";
                    string NewTxnsID1 = "0";

                    if (Data.StatusCode == "MA")
                    {


                        string[] Array = Data.ItemsCntrIDs.TrimEnd(',').Split(',');

                        for (int i = 0; i < Array.Length; i++)
                        {
                            Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                            NewTxnsID = Cmd.ExecuteScalar().ToString();


                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = "INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,NextPortID,ModeOfTransportID,DepotID,BLNumber,CustomerID,UserID,AgencyID) " +
                                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@NextPortID,@ModeOfTransportID,@DepotID,@BLNumber,@CustomerID,@UserID,@AgencyID) ";

                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt")));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.NextPortID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.ModeOfTransportID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                            Cmd.ExecuteNonQuery();


                            Cmd.CommandText = "Update NVO_Containers set StatusCode=@StatusCode,CurrentPortID=@CurrentPortID,LastMoveMentID=@LastMoveMentID,UserID=@UserID,DtModified=@DtModified,VesVoyID=@VesVoyID,ModeOfTransportID=@ModeOfTransportID,DepotID=@DepotID,CustomerID=@CustomerID,AgencyID=@AgencyID where ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.NextPortID));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                            int result = Cmd.ExecuteNonQuery();


                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }




                        string[] Array1 = Data.ItemsCntrIDs.TrimEnd(',').Split(',');

                        for (int i = 0; i < Array1.Length; i++)
                        {

                            //da dtmovement =DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt");

                            //DateTime dt2 = dtmovement.AddMinutes(1);

                            Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                            NewTxnsID1 = Cmd.ExecuteScalar().ToString();


                            var CharSplit1 = Array1[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = "INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,NextPortID,ModeOfTransportID,DepotID,BLNumber,CustomerID,UserID,AgencyID) " +
                                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@NextPortID,@ModeOfTransportID,@DepotID,@BLNumber,@CustomerID,@UserID,@AgencyID) ";

                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit1[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "DL"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt")));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.NextPortID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.ModeOfTransportID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                            Cmd.ExecuteNonQuery();


                            Cmd.CommandText = "Update NVO_Containers set StatusCode=@StatusCode,CurrentPortID=@CurrentPortID,LastMoveMentID=@LastMoveMentID,UserID=@UserID,DtModified=@DtModified,VesVoyID=@VesVoyID,ModeOfTransportID=@ModeOfTransportID,DepotID=@DepotID,CustomerID=@CustomerID,AgencyID=@AgencyID where ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit1[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.NextPortID));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                            int result = Cmd.ExecuteNonQuery();

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }
                    else
                    {
                        string[] Array = Data.ItemsCntrIDs.TrimEnd(',').Split(',');

                        for (int i = 0; i < Array.Length; i++)
                        {
                            Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                            NewTxnsID = Cmd.ExecuteScalar().ToString();


                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = "INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,NextPortID,ModeOfTransportID,DepotID,BLNumber,CustomerID,UserID,AgencyID) " +
                                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@NextPortID,@ModeOfTransportID,@DepotID,@BLNumber,@CustomerID,@UserID,@AgencyID) ";

                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt")));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.NextPortID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.ModeOfTransportID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                            Cmd.ExecuteNonQuery();


                            Cmd.CommandText = " Update NVO_Containers set StatusCode=@StatusCode,CurrentPortID=@CurrentPortID,LastMoveMentID=@LastMoveMentID,UserID=@UserID,DtModified=@DtModified,VesVoyID=@VesVoyID,ModeOfTransportID=@ModeOfTransportID,DepotID=@DepotID,CustomerID=@CustomerID,AgencyID=@AgencyID where ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.NextPortID));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                            int result = Cmd.ExecuteNonQuery();

                            if (Data.StatusCode == "OF")
                            {
                                Cmd.CommandText = "Update NVO_Containers set StatusID=@StatusID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 32));
                            }
                            if (Data.StatusCode == "OH")
                            {
                                Cmd.CommandText = "Update NVO_Containers set StatusID=@StatusID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 31));
                            }

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }




                    }


                    trans.Commit();

                    ListCntrMv.Add(new MyCntrMoveMent { ID = Int32.Parse(NewTxnsID.ToString()) });

                    return ListCntrMv;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCntrMv;
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

        public List<MyCntrMoveMent> ContainersTxnsViewValues(MyCntrMoveMent Data)
        {
            DataTable dt = GetContainersTxnsRec(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    FromPortID = Int32.Parse(dt.Rows[i]["CurrentPortID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Size = dt.Rows[i]["SIZE"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    VesVoy = dt.Rows[i]["VESVOY"].ToString(),
                    FromPort = dt.Rows[i]["FromPort"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    TransitMode = dt.Rows[i]["TransitMode"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    ChkFlag = dt.Rows[i]["ChkFlag"].ToString(),
                });
            }
            return ListCntrMv;
        }

        public DataTable GetContainersTxnsRec(MyCntrMoveMent Data)
        {
            string _Query = "Select DISTINCT C.ID As CntrID, '0' as ChkFlag, C.CntrNo,C.StatusCode,isnull((C.CurrentPortID),0) as CurrentPortID, ISNULL(C.AgencyID,0) AS AgencyID,  " +
           " (select top(1) A.AgencyName from NVO_AgencyMaster A WHERE A.ID = C.AgencyID) AS AgencyName, C.DtModified AS DtMovement, " +
           //--(select top(1) DtMovement from NVO_ContainerTxns CT where ContainerID = C.ID  order by DtMovement desc)
           //--AS DtMovement ,  
           " (select top(1) BL.BookingNo from NVO_Booking BL Inner join NVO_ContainerTxns CT ON CT.BLNumber = BL.ID  WHERE CT.ContainerID = C.ID ORDER BY CT.DtMovement DESC  ) AS BLNumber, " +
          " (select top(1) Size   from NVO_tblCntrTypes where ID = C.TypeID) AS Size, " +
         " (select top(1) PortName   from NVO_PortMaster WHERE NVO_PortMaster.ID = CurrentPortID) AS FromPort, " +
        " (select top(1) G.GeneralName from NVO_GeneralMaster G WHERE G.ID = C.ModeOfTransportID)  AS TransitMode, " +
        " ( select top(1) D.DepName   from NVO_DepotMaster D WHERE D.ID = C.DepotID ) AS Depot, (select top(1) CustomerName from NVO_view_CustomerDetails CV Inner JOIN NVO_ContainerTxns " +
         " ON NVO_ContainerTxns.CustomerID = CV.CID where ContainerID = C.ID  Order by DtMovement desc) AS CustomerName, " +
        " (Select top 1(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V  Inner JOIN NVO_ContainerTxns " +
         " ON NVO_ContainerTxns.VesVoyID = V.ID where ContainerID = C.ID  Order by DtMovement desc)  As VESVOY from NVO_Containers C ";
            string strWhere = "";


            //if (Data.StatusCode != "")
            //    if (strWhere == "")
            //        strWhere += _Query + " where (select top(1) StatusCode   from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc) like '%" + Data.StatusCode + "%'";
            //    else
            //        strWhere += " and (select top(1) StatusCode   from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc) like '%" + Data.StatusCode + "%'";

            if (Data.StatusCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where C.StatusCode like '%" + Data.StatusCode + "%'";
                else
                    strWhere += " and C.StatusCode like '%" + Data.StatusCode + "%'";

            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where C.ID=" + Data.CntrID.ToString();
                else
                    strWhere += " and C.ID =" + Data.CntrID.ToString();


            if (Data.CntrTypeID.ToString() != "" && Data.CntrTypeID.ToString() != "0" && Data.CntrTypeID.ToString() != null && Data.CntrTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where C.TypeID=" + Data.CntrTypeID.ToString();
                else
                    strWhere += " and C.TypeID =" + Data.CntrTypeID.ToString();

            if (Data.LocationID.ToString() != "" && Data.LocationID.ToString() != "0" && Data.LocationID.ToString() != null && Data.LocationID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where C.CurrentPortID =" + Data.LocationID.ToString();
                else
                    strWhere += " and C.CurrentPortID =" + Data.LocationID.ToString();

            if (Data.VesVoyID.ToString() != "" && Data.VesVoyID.ToString() != "0" && Data.VesVoyID.ToString() != null && Data.VesVoyID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where C.VesVoyID=" + Data.VesVoyID.ToString();
                else
                    strWhere += " and C.VesVoyID =" + Data.VesVoyID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyCntrMoveMent> ContainersTxnEntryViewValues(MyCntrMoveMent Data)
        {
            DataTable dt = GetContainersTxnEntryViewRec(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["SIZE"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    VesVoy = dt.Rows[i]["VESVOY"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    FromPort = dt.Rows[i]["FromPort"].ToString(),
                    TransitMode = dt.Rows[i]["TransitMode"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ListCntrMv;
        }

        public DataTable GetContainersTxnEntryViewRec(MyCntrMoveMent Data)
        {
            string _Query = "select Distinct C.ID As CntrID,C.CntrNo,T.SIZE,C.StatusCode,C.DtModified as DtMovement,Isnull(C.AgencyID,0) as AgencyID, " +
         "(select top(1) PortName   from NVO_PortMaster  where NVO_PortMaster.ID = C.CurrentPortID) AS FromPort, " +
        " (select top(1) A.AgencyName from NVO_AgencyMaster A  WHERE A.ID = C.AgencyID ) AS AgencyName, (select top(1) PortName   from NVO_PortMaster  where NVO_PortMaster.ID = C.CurrentPortID) NextPort , " +
        " (select top 1 GeneralName from NVO_GeneralMaster WHERE NVO_GeneralMaster.ID = C.ModeOfTransportID ) TransitMode, " +
        " (select top 1 DepName from NVO_DepotMaster where ID = C.DepotID ) Depot, (select top(1) CustomerName from NVO_view_CustomerDetails  Inner join NVO_ContainerTxns ON NVO_ContainerTxns.CustomerID = NVO_view_CustomerDetails.CID where ContainerID = C.ID  Order by DtMovement desc) CustomerName,  (Select top 1(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID)  " +
          " from NVO_Voyage V  Inner JOIN NVO_ContainerTxns ON NVO_ContainerTxns.VesVoyID = V.ID where ContainerID = C.ID  Order by DtMovement desc)  As VESVOY,  (select top(1) BookingNo from NVO_Booking " +
        " Inner join NVO_ContainerTxns ON NVO_ContainerTxns.BLNumber = NVO_Booking.ID  where C.ID = ContainerID) as BLNumber from NVO_Containers C Inner join NVO_tblCntrTypes T ON T.ID = C.TypeID " +
      " where C.ID IN(" + Data.ItemsCntrIDs + ") ";
            return GetViewData(_Query, "");
        }

        public List<MyStatusCode> GetCheckStatusCodeValidation(MyStatusCode Data)
        {
            DataTable dt = GetCheckStatusCodeValidationlist(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListStCode.Add(new MyStatusCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ValidVslVoy = Int32.Parse(dt.Rows[i]["ValidVslVoy"].ToString()),
                    ValidNextLoc = Int32.Parse(dt.Rows[i]["ValidNextLoc"].ToString()),
                    ValidTransMode = Int32.Parse(dt.Rows[i]["ValidTransMode"].ToString()),
                    ValidDepot = Int32.Parse(dt.Rows[i]["ValidDepot"].ToString()),
                    ValidBL = Int32.Parse(dt.Rows[i]["ValidBL"].ToString()),
                    ValidCustomer = Int32.Parse(dt.Rows[i]["ValidCustomer"].ToString()),
                });
            }
            return ListStCode;
        }
        public DataTable GetCheckStatusCodeValidationlist(MyStatusCode Data)
        {
            string _Query = "select * from NVO_ContainerStatusCodes" +
                     " where Statuscode='" + Data.Status + "'";
            return GetViewData(_Query, "");
        }

        #endregion

        #region ContainersTracking
        public List<MyCntrMoveMent> ContainersTrackingViewValues(MyCntrMoveMent Data)
        {
            DataTable dt = GetContainersTrackingViewRec(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    TxnsID = Int32.Parse(dt.Rows[i]["TxnsID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    FromPortID = Int32.Parse(dt.Rows[i]["CurrentPortID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Size = dt.Rows[i]["SIZE"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    VesVoy = dt.Rows[i]["VESVOY"].ToString(),
                    FromPort = dt.Rows[i]["FromPort"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    TransitMode = dt.Rows[i]["TransitMode"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ListCntrMv;
        }

        public DataTable GetContainersTrackingViewRec(MyCntrMoveMent Data)
        {
            string _Query = " select DISTINCT CT.ID As TxnsID,C.ID As CntrID,C.CntrNo,Isnull(CT.AgencyID,0) as AgencyID, " +
     " (select top(1) AgencyName from NVO_AgencyMaster where ID = CT.AgencyID) AS AgencyName, " +
     " ISNULL((select top(1) LocationID   from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc),0) AS CurrentPortID ," +
       " (select top(1) Size   from NVO_tblCntrTypes where ID = C.TypeID) AS SIZE, CT.Statuscode,CT.DtMovement, " +
       " (select top(1) PortName from NVO_PortMaster where ID = CT.LocationID order by CT.DtMovement desc ) as FromPort, " +
          " ( select top(1) PortName from NVO_PortMaster where ID = CT.LocationID order by CT.DtMovement desc ) as NextPort, " +
       " (select top(1) GeneralName from NVO_GeneralMaster where ID = CT.ModeOfTransportID AND SeqNo = 31 order by CT.DtMovement desc ) as TransitMode," +
        " (select top(1) DepName from NVO_DepotMaster where ID = CT.DepotID order by CT.DtMovement desc ) as Depot," +
         " (select top(1) BookingNo from NVO_Booking where ID = CT.BLNumber order by CT.DtMovement desc ) as BLNumber," +
       " (select top(1) CustomerName from NVO_view_CustomerDetails where CID = CT.CustomerID order by CT.DtMovement desc ) as CustomerName,(Select top 1(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where CT.ContainerID = C.ID and CT.VesVoyID = V.ID Order by DtMovement desc)  As VESVOY from NVO_ContainerTxns CT " +
     " INNER join NVO_Containers C ON C.ID = CT.ContainerID where CT.StatusCode not IN ('PENDING') ";



            string strWhere = "";


            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " AND C.ID=" + Data.CntrID.ToString();
                else
                    strWhere += " and C.ID =" + Data.CntrID.ToString();


            if (Data.CntrTypeID.ToString() != "" && Data.CntrTypeID.ToString() != "0" && Data.CntrTypeID.ToString() != null && Data.CntrTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " AND C.TypeID=" + Data.CntrTypeID.ToString();
                else
                    strWhere += " and C.TypeID =" + Data.CntrTypeID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by CT.ID desc ", "");

        }


        public List<MyCntrMoveMent> InvAmendmentEditValues(MyCntrMoveMent Data)
        {
            DataTable dt = GetInvAmendmentEditValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    VesVoyID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    //LocationID = Int32.Parse(dt.Rows[i]["LocationID"].ToString()),
                    NextPortID = Int32.Parse(dt.Rows[i]["NextPortID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    ModeOfTransportID = Int32.Parse(dt.Rows[i]["ModeOfTransportID"].ToString()),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLNumber"].ToString()),
                    CustomerID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                });
            }
            return ListCntrMv;
        }

        public DataTable GetInvAmendmentEditValues(MyCntrMoveMent Data)
        {
            string _Query = " Select  FORMAT(DtMovement, 'yyyy-MM-ddTHH:mm:ss') as DtMovement,isnull(VesVoyID,0) as VesVoyID,ISNULL(LocationID,0) AS NextPortID,ISNULL(ModeOfTransportID, 0) AS ModeOfTransportID,ISNULL(DepotID, 0) AS DepotID, ISNULL(BLNumber, 0) AS BLNumber, ISNULL(CustomerID, 0) AS CustomerID,ISNULL(AgencyID,0) AS AgencyID,StatusCode from NVO_ContainerTxns where ID=" + Data.ID;

            return GetViewData(_Query, "");

        }


        public List<MyCntrMoveMent> InventoryValidateAgencyLastMove(MyCntrMoveMent Data)
        {
            DataTable dt = GetValidateAgencyLastMove(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    UserID = Int32.Parse(dt.Rows[i]["UserID"].ToString()),

                });
            }
            return ListCntrMv;
        }

        public DataTable GetValidateAgencyLastMove(MyCntrMoveMent Data)
        {
            string _Query = "Select TOP 1 isnull(AgencyID,0) as AgencyID,isnull(UserID,0)  as UserID   from  NVO_ContainerTxns where ContainerID=" + Data.CntrID + " and StatusCode NOT in ('PENDING') Order By DtMovement Desc ";

            return GetViewData(_Query, "");

        }

        public List<MyCntrMoveMent> InventoryAmendmentUpdateCntrTxns(MyCntrMoveMent Data)
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

                    Cmd.CommandText = "Update NVO_ContainerTxns set DtMovement =@DtMovement,VesVoyID=@VesVoyID,LocationID=@LocationID,NextPortID=@NextPortID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,DepotID=@DepotID,CustomerID=@CustomerID,BLNumber=@BLNumber,AgencyID=@AgencyID where ID=@ID";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.NextPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.NextPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.ModeOfTransportID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTxnsID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAmended", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "INSERT INTO NVO_CntrTrackAmendLog (ContainerID,CntrTxnsID,UserID,DtAmended) VALUES (@ContainerID,@CntrTxnsID,@UserID,@DtAmended)";

                    result = Cmd.ExecuteNonQuery();

                    trans.Commit();

                    return ListCntrMv;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCntrMv;
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

        public List<MyCntrMoveMent> LastMoveRemoveandUpdate(MyCntrMoveMent Data)
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
                string StatusCode = "0", Dtmodified = "", LastMovementID = "0", LastAgencyID = "0", LastDepotID = "0", LastPortID = "0", LastTransitID = "0";
                try
                {


                    Cmd.CommandText = "Delete From NVO_ContainerTxns where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "SELECT  top 1 StatusCode From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + " AND StatusCode NOT IN ('PENDING') order by Dtmovement Desc,StatusCode Asc";

                    StatusCode = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "SELECT TOP 1 Dtmovement From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + " AND StatusCode NOT IN ('PENDING') order by Dtmovement Desc,StatusCode Asc";

                    Dtmodified = Cmd.ExecuteScalar().ToString();
                    string timet = DateTime.Parse(Dtmodified).ToString("MM/dd/yyyy HH:mm:ss");

                    Cmd.CommandText = "SELECT top 1 ID From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + " AND StatusCode NOT IN ('PENDING')  order by Dtmovement Desc,StatusCode Asc";

                    LastMovementID = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "SELECT top 1 AgencyID From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + " AND StatusCode NOT IN ('PENDING') order by Dtmovement Desc,StatusCode Asc";

                    LastAgencyID = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "SELECT top 1 DepotID From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + "  AND StatusCode NOT IN ('PENDING') order by Dtmovement Desc,StatusCode Asc";

                    LastDepotID = Cmd.ExecuteScalar().ToString();


                    Cmd.CommandText = "SELECT top 1 LocationID From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + " AND StatusCode NOT IN ('PENDING') order by Dtmovement Desc,StatusCode Asc";

                    LastPortID = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "SELECT top 1 ModeOfTransportID From NVO_ContainerTxns WHERE ContainerID=" + Data.CntrID + " AND StatusCode NOT IN ('PENDING') order by Dtmovement Desc,StatusCode Asc";

                    LastTransitID = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "Update NVO_Containers set StatusCode =@StatusCode,DtModified=@DtModified,LastMovementID=@LastMovementID,DepotID=@DepotID,AgencyID=@AgencyID,CurrentPortID=@CurrentPortID,ModeOfTransportID=@ModeOfTransportID where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", StatusCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", timet));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMovementID", LastMovementID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", LastDepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", LastAgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", LastPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", LastTransitID));
                    result = Cmd.ExecuteNonQuery();


                    Cmd.CommandText = "INSERT INTO NVO_CntrTrackDeleteLog (ContainerID,CntrTxnsID,UserID,DtDeleted,DeltetedStatusCode) VALUES (@ContainerID,@CntrTxnsID,@UserID,@DtDeleted,@DeltetedStatusCode)";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeltetedStatusCode", Data.StatusCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTxnsID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDeleted", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));

                    result = Cmd.ExecuteNonQuery();

                    trans.Commit();

                    return ListCntrMv;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCntrMv;
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

        #region Inventory statuscode

        public List<MyStatusCode> GetStatusCodeList(MyStatusCode Data)
        {
            DataTable dt = GetStatusCodeListRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListStCode.Add(new MyStatusCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Status = dt.Rows[i]["StatusDescription"].ToString(),

                });
            }
            return ListStCode;
        }
        public DataTable GetStatusCodeListRecord(MyStatusCode Data)
        {
            string _Query = "select * from NVO_ContainerStatusCodes";
            return GetViewData(_Query, "");
        }

        public List<MyStatusCode> GetStatusDescriptionByStatusCode(MyStatusCode Data)
        {
            DataTable dt = GetStatusDescriptionByStatusCodeRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListStCode.Add(new MyStatusCode
                {

                    StatusDescription = dt.Rows[i]["StatusDescription"].ToString(),

                });
            }
            return ListStCode;
        }
        public DataTable GetStatusDescriptionByStatusCodeRecord(MyStatusCode Data)
        {
            string _Query = "select * from NVO_ContainerStatusCodes where ID=" + Data.StatusCodeID;
            return GetViewData(_Query, "");
        }

        List<MyStatusCode> ListStCode = new List<MyStatusCode>();
        public List<MyStatusCode> ViewInventoryStatusCodes(MyStatusCode Data)
        {
            DataTable dt = GetInventoryStatusCodes(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListStCode.Add(new MyStatusCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Status = dt.Rows[i]["StatusCode"].ToString(),
                    StatusDescription = dt.Rows[i]["StatusDescription"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });
            }
            return ListStCode;
        }

        public DataTable GetInventoryStatusCodes(MyStatusCode Data)
        {
            string _Query = "select ID,StatusCode,StatusDescription, case when status = 1 then 'Active' when status = 2 then 'Inactive' ELSE '' END as StatusResult  from NVO_ContainerStatusCodes";

            string strWhere = "";

            if (Data.Status != "")
                if (strWhere == "")
                    strWhere += _Query + " where StatusDescription like '%" + Data.Status + "%'";
                else
                    strWhere += " and StatusDescription like '%" + Data.Status + "%'";

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where status=" + Data.StatusID.ToString();
                else
                    strWhere += " and status =" + Data.StatusID.ToString();



            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }
        public List<MyStatusCode> GetStatusValidationDropdown(MyStatusCode Data)
        {
            DataTable dt = GetStatusValidationDropdownRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListStCode.Add(new MyStatusCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListStCode;
        }
        public DataTable GetStatusValidationDropdownRecord(MyStatusCode Data)
        {
            string _Query = "select * from NVO_GeneralMaster where seqno=70";
            return GetViewData(_Query, "");
        }
        public List<MyStatusCode> GetStatusCodesEdit(MyStatusCode Data)
        {
            DataTable dt = GetStatusCodesRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 2;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 2;
                }
                ListStCode.Add(new MyStatusCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Status = dt.Rows[i]["StatusCode"].ToString(),
                    StatusDescription = dt.Rows[i]["StatusDescription"].ToString(),
                    StatusID = St,
                    ValidVslVoy = Int32.Parse(dt.Rows[i]["ValidVslVoy"].ToString()),
                    ValidNextLoc = Int32.Parse(dt.Rows[i]["ValidNextLoc"].ToString()),
                    ValidTransMode = Int32.Parse(dt.Rows[i]["ValidTransMode"].ToString()),
                    ValidDepot = Int32.Parse(dt.Rows[i]["ValidDepot"].ToString()),
                    ValidBL = Int32.Parse(dt.Rows[i]["ValidBL"].ToString()),
                    ValidCustomer = Int32.Parse(dt.Rows[i]["ValidCustomer"].ToString()),
                    ValidTerminal = Int32.Parse(dt.Rows[i]["ValidTerminal"].ToString()),
                });
            }
            return ListStCode;
        }
        public DataTable GetStatusCodesRecord(MyStatusCode Data)
        {
            string _Query = "select * from NVO_ContainerStatusCodes where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyStatusCode> GetBindStatusCodePossiblemoves(MyStatusCode Data)
        {
            DataTable dt = GetStatusCodePossiblemoves(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListStCode.Add(new MyStatusCode
                {

                    SID = Int32.Parse(dt.Rows[i]["SID"].ToString()),
                    ToStatusID = Int32.Parse(dt.Rows[i]["ToStatusID"].ToString()),
                    ToStatus = dt.Rows[i]["ToStatusDescription"].ToString(),
                    //ToStatusDescription = dt.Rows[i]["ToStatusDescription"].ToString(),

                });
            }
            return ListStCode;
        }
        public DataTable GetStatusCodePossiblemoves(MyStatusCode Data)
        {
            string _Query = "select * from NVO_ContainerStatusPossibleMoves where StatusCodeID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyStatusCode> InsertContainerStatusCreation(MyStatusCode Data)
        {

            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GetExistingStatusCodes(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListStCode.Add(new MyStatusCode
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Statuscode Already Exists"

                    }); ;
                    return ListStCode;
                }
            }

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

                    Cmd.CommandText = " IF((select count(*) from NVO_ContainerStatusCodes where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ContainerStatusCodes(StatusCode,StatusDescription,Status,ValidVslVoy,ValidNextLoc,ValidTransMode,ValidDepot,ValidBL,ValidCustomer,ValidTerminal) " +
                                     " values (@StatusCode,@StatusDescription,@Status,@ValidVslVoy,@ValidNextLoc,@ValidTransMode,@ValidDepot,@ValidBL,@ValidCustomer,@ValidTerminal) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ContainerStatusCodes SET StatusCode=@StatusCode,StatusDescription=@StatusDescription,Status=@Status,ValidVslVoy=@ValidVslVoy,ValidNextLoc=@ValidNextLoc,ValidTransMode=@ValidTransMode,ValidDepot=@ValidDepot,ValidBL=@ValidBL,ValidCustomer=@ValidCustomer,ValidTerminal=@ValidTerminal where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.Status.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusDescription", Data.StatusDescription.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidVslVoy", Data.ValidVslVoy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidNextLoc", Data.ValidNextLoc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTransMode", Data.ValidTransMode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidDepot", Data.ValidDepot));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidBL", Data.ValidBL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidCustomer", Data.ValidCustomer));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTerminal", Data.ValidTerminal));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_ContainerStatusCodes')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    if (Array.Length != 1)
                    {
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_ContainerStatusPossibleMoves where StatusCodeID=@StatusCodeID and SID=@SID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_ContainerStatusPossibleMoves(StatusCodeID,ToStatusID,ToStatusDescription,FromStatus) " +
                                         " values (@StatusCodeID,@ToStatusID,@ToStatusDescription,@FromStatus) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_ContainerStatusPossibleMoves SET StatusCodeID=@StatusCodeID,ToStatusID=@ToStatusID,ToStatusDescription=@ToStatusDescription,FromStatus=@FromStatus where StatusCodeID=@StatusCodeID and SID=@SID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ToStatusID", CharSplit[1]));
                            ///Cmd.Parameters.Add(_dbFactory.GetParameter("@ToStatus", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ToStatusDescription", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCodeID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FromStatus", Data.Status));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();


                    ListStCode.Add(new MyStatusCode
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListStCode;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListStCode.Add(new MyStatusCode
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListStCode;
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

        public DataTable GetExistingStatusCodes(MyStatusCode Data)
        {
            string _Query = "Select * from NVO_ContainerStatusCodes where  StatusCode ='" + Data.Status + "' or StatusDescription ='" + Data.StatusDescription + "' ";
            return GetViewData(_Query, "");
        }
        public List<MyStatusCode> PossiblemovesDeleteMaster(MyStatusCode Data)
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

                    Cmd.CommandText = "Delete from NVO_ContainerStatusPossibleMoves where SID=" + Data.SID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListStCode.Add(new MyStatusCode
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListStCode;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListStCode.Add(new MyStatusCode
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListStCode;
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

        #region Single Movement History


        public List<MyCntrMoveMent> SingleContainersTrackingViewValues(MyCntrMoveMent Data)
        {
            DataTable dt = GetSingleContainersTrackingViewRec(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrMv.Add(new MyCntrMoveMent
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    TxnsID = Int32.Parse(dt.Rows[i]["TxnsID"].ToString()),
                    FromPortID = Int32.Parse(dt.Rows[i]["CurrentPortID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Size = dt.Rows[i]["SIZE"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    VesVoy = dt.Rows[i]["VESVOY"].ToString(),
                    FromPort = dt.Rows[i]["FromPort"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    TransitMode = dt.Rows[i]["TransitMode"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                    ModeOfTransportID = Int32.Parse(dt.Rows[i]["ModeOfTransportID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    CustomerID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    VesVoyID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                });
            }
            return ListCntrMv;
        }

        public DataTable GetSingleContainersTrackingViewRec(MyCntrMoveMent Data)
        {
            //       string _Query = " select DISTINCT CT.ID As TxnsID,C.ID As CntrID,C.CntrNo, " +
            //" (select top(1) AgencyName from NVO_AgencyMaster where ID = CT.AgencyID) AS AgencyName, " +
            //" ISNULL((select top(1) NextPortID   from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc),0) AS CurrentPortID ," +
            //  " (select top(1) Size   from NVO_tblCntrTypes where ID = C.TypeID) AS SIZE, C.Statuscode,CT.DtMovement, " +
            //  " (select top(1) PortName from NVO_PortMaster where ID = CT.LocationID order by CT.DtMovement desc ) as FromPort, " +
            //     " ( select top(1) PortName from NVO_PortMaster where ID = CT.NextPortID order by CT.DtMovement desc ) as NextPort, " +
            //  " (select top(1) GeneralName from NVO_GeneralMaster where ID = CT.ModeOfTransportID AND SeqNo = 31 order by CT.DtMovement desc ) as TransitMode," +
            //   " (select top(1) DepName from NVO_DepotMaster where ID = CT.DepotID order by CT.DtMovement desc ) as Depot," +
            //    " (select top(1) BookingNo from NVO_Booking where ID = CT.BLNumber order by CT.DtMovement desc ) as BLNumber," +
            //  " (select top(1) CustomerName from NVO_CustomerMaster where ID = CT.CustomerID order by CT.DtMovement desc ) as CustomerName,(Select top 1(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where CT.ContainerID = C.ID and CT.VesVoyID = V.ID Order by DtMovement desc)  As VESVOY from NVO_ContainerTxns CT " +
            //" INNER join NVO_Containers C ON C.ID = CT.ContainerID ";

            string _Query = " select DISTINCT isnull(CT.ID,0 )As TxnsID,CT.ID ,C.ID As CntrID,C.CntrNo,isnull(CT.AgencyID,0) as AgencyID, " +
     " (select top(1) AgencyName from NVO_AgencyMaster where ID = CT.AgencyID) AS AgencyName, " +
     " C.CurrentPortID ," +
       " (select top(1) Size   from NVO_tblCntrTypes where ID = C.TypeID) AS SIZE, CT.Statuscode,CT.DtMovement, " +
       " (select top(1) PortName from NVO_PortMaster  where ID = CT.LocationID order by CT.DtMovement desc ) as FromPort, " +
          " ( select top(1) PortName from NVO_PortMaster where ID = CT.LocationID order by CT.DtMovement desc ) as NextPort, " +
       " (select top(1) GeneralName from NVO_GeneralMaster where ID = CT.ModeOfTransportID AND SeqNo = 31 order by CT.DtMovement desc ) as TransitMode," +
          " ISNULL((select top(1) NVO_GeneralMaster.ID from NVO_GeneralMaster where ID = CT.ModeOfTransportID AND SeqNo = 31 order by CT.DtMovement desc ),0) as ModeOfTransportID," +
        " (select top(1) DepName from NVO_DepotMaster where ID = CT.DepotID order by CT.DtMovement desc ) as Depot," +
         "ISNULL( (select top(1) NVO_DepotMaster.ID from NVO_DepotMaster where ID = CT.DepotID order by CT.DtMovement desc ),0 ) as DepotID," +
         " (select top(1) BookingNo from NVO_Booking where ID = CT.BLNumber order by CT.DtMovement desc ) as BLNumber," +
         " ISNULL((select top(1) NVO_Booking.ID from NVO_Booking where ID = CT.BLNumber order by CT.DtMovement desc ) ,0) as BLID," +
       " (select top(1) CustomerName from NVO_view_CustomerDetails where CID = CT.CustomerID order by CT.DtMovement desc ) as CustomerName,ISNULL((select top(1) CustomerName from NVO_view_CustomerDetails where CID = CT.CustomerID order by CT.DtMovement desc ),0) as CustomerID,(Select top 1(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where CT.ContainerID = C.ID and CT.VesVoyID = V.ID Order by DtMovement desc)  As VESVOY," +
       " isnull((Select top 1 V.ID from NVO_Voyage V where CT.ContainerID = C.ID and CT.VesVoyID = V.ID Order by DtMovement desc) ,0) As VesVoyID " +
       "  from NVO_Containers C left outer  join NVO_ContainerTxns CT ON CT.ContainerID = C.ID  where CT.StatusCode not IN ('PENDING') ";



            string strWhere = "";


            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and C.ID=" + Data.CntrID.ToString();
                else
                    strWhere += " and C.ID =" + Data.CntrID.ToString();


            if (Data.CntrTypeID.ToString() != "" && Data.CntrTypeID.ToString() != "0" && Data.CntrTypeID.ToString() != null && Data.CntrTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and C.TypeID=" + Data.CntrTypeID.ToString();
                else
                    strWhere += " and C.TypeID =" + Data.CntrTypeID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + "order by CT.ID desc", "");

        }

        public List<MyCntrMoveMent> CntrStatusandTypeByCntrNo(MyCntrMoveMent Data)
        {
            DataTable dt = GetCntrStatusandTypeByCntrNo(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCntrMv.Add(new MyCntrMoveMent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["TypeID"].ToString()),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString()


                });
            }
            return ListCntrMv;
        }
        public DataTable GetCntrStatusandTypeByCntrNo(MyCntrMoveMent Data)
        {
            //string _Query = "select C.ID,C.TypeID,(Select top 1 StatusCode from NVO_ContainerTxns CT where ContainerID=C.ID Order By CT.DtMovement desc) As StatusCode from NVO_Containers C Where C.ID =" + Data.ID;
            string _Query = "select C.ID,C.TypeID,StatusCode from NVO_Containers C Where C.ID =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyCntrMoveMent> CntrDtMovementValidation(MyCntrMoveMent Data)
        {
            DataTable dt = GetCntrDtMovementValidation(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCntrMv.Add(new MyCntrMoveMent
                {

                    DateValidation = dt.Rows[i]["DateValidation"].ToString()

                });
            }
            return ListCntrMv;
        }
        public DataTable GetCntrDtMovementValidation(MyCntrMoveMent Data)
        {
            string _Query = " Select (SELECT COUNT(DtMovement) FROM NVO_ContainerTxns WHERE ContainerID IN(" + Data.ItemsCntrIDs + ") AND StatusCode NOT IN ('PENDING') AND (SELECT Max(DtMovement) FROM NVO_ContainerTxns WHERE   ContainerID IN(" + Data.ItemsCntrIDs + ")  AND StatusCode NOT IN ('PENDING') ) >= '" + DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt") + "')  as DateValidation ";
            return GetViewData(_Query, "");
        }
        #endregion
        public string GetMaxseqNumber(string Prefix, string GeoLocId)
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

                cmd.CommandText = "select Max(ISNULL(" + Prefix + ",0)) from NVO_SeqNo where GeoLocId=" + GeoLocId;
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


                cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_SeqNo WHERE GeoLocId=" + GeoLocId + ")<=0)" +
                                   " BEGIN  " +
                                   " INSERT INTO NVO_SeqNo(GeoLocId," + Prefix + ")Values(" + GeoLocId + "," + sno.ToString() + ") " +
                                   " END " +
                                   " ELSE " +
                                   " UPDATE NVO_SeqNo SET " + Prefix + "=" + sno.ToString() + " where GeoLocId=" + GeoLocId;
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



        #endregion

        #region anand
        public List<MyContainerRent> InsertContainerRentContract(MyContainerRent Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ContRentContract where ID=@ID)<=0) " +
                                     " BEGIN " +
                                      " INSERT INTO  NVO_ContRentContract(TariffTypeID,ContainerType,ChargeTypeID,ChargesID,ChargeOwnerID,ShipmentTypeID,PortID,CustomerID,TerminalID,DepotID,StartingMove,EndingMove,AutoRunTypeID,ValidFrom,ValidTill,Status,UserID,AgencyID) " +
                                     " values (@TariffTypeID,@ContainerType,@ChargeTypeID,@ChargesID,@ChargeOwnerID,@ShipmentTypeID,@PortID,@CustomerID,@TerminalID,@DepotID,@StartingMove,@EndingMove,@AutoRunTypeID,@ValidFrom,@ValidTill,@Status,@UserID,@AgencyID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ContRentContract SET TariffTypeID=@TariffTypeID,ContainerType=@ContainerType,ChargeTypeID=@ChargeTypeID,ChargesID=@ChargesID,ChargeOwnerID=@ChargeOwnerID,ShipmentTypeID=@ShipmentTypeID,PortID=@PortID,CustomerID=@CustomerID,TerminalID=@TerminalID,DepotID=@DepotID,StartingMove=@StartingMove,EndingMove=@EndingMove,AutoRunTypeID=@AutoRunTypeID,ValidFrom=@ValidFrom,ValidTill=@ValidTill,Status=@Status,AgencyID=@AgencyID,UserID=@UserID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", Data.TariffTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerType", Data.ContainerType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", Data.ChargeTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargesID", Data.ChargesID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOwnerID", Data.ChargeOwnerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", Data.ShipmentTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", Data.TerminalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StartingMove", Data.StartingMove));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EndingMove", Data.EndingMove));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AutoRunTypeID", Data.AutoRunTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", Data.ValidFrom));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ContRentContract')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;



                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContRentTariffDtls where CID=@CID and RentID=@RentID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_ContRentTariffDtls(RentID,SlabFrom,SlabTo,CurrencyID,Amount) " +
                                    " values (@RentID,@SlabFrom,@SlabTo,@CurrencyID,@Amount) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_ContRentTariffDtls SET RentID=@RentID,SlabFrom=@SlabFrom,SlabTo=@SlabTo,CurrencyID=@CurrencyID,Amount=@Amount where CID=@CID and RentID=@RentID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RentID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabFrom", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabTo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[4]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    ListContRent.Add(new MyContainerRent { ID = Data.ID });
                    return ListContRent;


                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListContRent;
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

        public List<MyContainerRent> ContainerRentViewMaster(MyContainerRent Data)
        {
            DataTable dt = GetContainerRentView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListContRent.Add(new MyContainerRent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    //CustomerV = dt.Rows[i]["CustomerName"].ToString(),
                    TariffTypeV = dt.Rows[i]["TariffTypeV"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    ShipmentTypeV = dt.Rows[i]["ShipmentTypeV"].ToString(),
                    ChargeOwnerIDV = dt.Rows[i]["ChargeOwnerIDV"].ToString(),
                    ValidFrom = dt.Rows[i]["ValidFrom"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Charges = dt.Rows[i]["Charges"].ToString(),
                    ChargeType = dt.Rows[i]["ChargeType"].ToString(),
                });
            }
            return ListContRent;
        }

        public DataTable GetContainerRentView(MyContainerRent Data)
        {
            string _Query = "select NVO_ContRentContract.ID,(Select top 1 GeneralName  from NVO_GeneralMaster where ID = TariffTypeID ) AS TariffTypeV,(Select top 1 Size  from NVO_tblCntrTypes where ID = ContainerType ) AS Size,  convert(varchar, ValidFrom, 103) as ValidFrom,convert(varchar, ValidTill, 103) as ValidTill,(Select top 1 GeneralName from NVO_GeneralMaster where ID = ShipmentTypeID ) AS ShipmentTypeV,(Select top 1 GeneralName  from NVO_GeneralMaster where ID = ChargeOwnerID ) AS ChargeOwnerIDV,(Select top 1 GeneralName  from NVO_GeneralMaster where ID = ChargeTypeID ) AS ChargeType,(Select top 1 (ChgCode +' - '+ ChgDesc) from NVO_ChargeTB where ID = ChargesID ) AS Charges  from NVO_ContRentContract ";

            string strWhere = "";

            if (Data.ShipmentTypeID.ToString() != "" && Data.ShipmentTypeID.ToString() != "0" && Data.ShipmentTypeID.ToString() != null && Data.ShipmentTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where ShipmentTypeID =" + Data.ShipmentTypeID.ToString();
                else
                    strWhere += " and ShipmentTypeID =" + Data.ShipmentTypeID.ToString();

            if (Data.TariffTypeID.ToString() != "" && Data.TariffTypeID.ToString() != "0" && Data.TariffTypeID.ToString() != null && Data.TariffTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where TariffTypeID=" + Data.TariffTypeID.ToString();
                else
                    strWhere += " and TariffTypeID =" + Data.TariffTypeID.ToString();

            if (Data.ContainerType.ToString() != "" && Data.ContainerType.ToString() != "0" && Data.ContainerType.ToString() != null && Data.ContainerType.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where ContainerType =" + Data.ContainerType.ToString();
                else
                    strWhere += " and ContainerType =" + Data.ContainerType.ToString();

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != null && Data.AgencyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where AgencyID=" + Data.AgencyID;
                else
                    strWhere += " and AgencyID =" + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyContainerRent> GetContainerRentRecordMaster(string ID)
        {
            DataTable dt = GetContainerRentRecord(ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContRent.Add(new MyContainerRent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TariffTypeID = Int32.Parse(dt.Rows[i]["TariffTypeID"].ToString()),
                    ContainerType = Int32.Parse(dt.Rows[i]["ContainerType"].ToString()),
                    ChargeTypeID = Int32.Parse(dt.Rows[i]["ChargeTypeID"].ToString()),
                    ChargesID = Int32.Parse(dt.Rows[i]["ChargesID"].ToString()),
                    ChargeOwnerID = Int32.Parse(dt.Rows[i]["ChargeOwnerID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    CustomerID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                    StartingMove = Int32.Parse(dt.Rows[i]["StartingMove"].ToString()),
                    EndingMove = Int32.Parse(dt.Rows[i]["EndingMove"].ToString()),
                    AutoRunTypeID = Int32.Parse(dt.Rows[i]["AutoRunTypeID"].ToString()),
                    ValidFrom = dt.Rows[i]["ValidFrom"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString())

                });

            }
            return ListContRent;
        }

        public DataTable GetContainerRentRecord(string ID)
        {
            string _Query = "select convert(varchar, ValidFrom, 23) as ValidFrom,convert(varchar, ValidTill, 23) as ValidTill, * from NVO_ContRentContract where ID=" + ID;
            return GetViewData(_Query, "");
        }

        public List<MyContainerRent> GetContainerRentTariffRecordMaster(MyContainerRent Data)
        {
            DataTable dt = GetContainerRentTariffRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContRent.Add(new MyContainerRent
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    RentID = Int32.Parse(dt.Rows[i]["RentID"].ToString()),
                    SlabFrom = Int32.Parse(dt.Rows[i]["SlabFrom"].ToString()),
                    SlabTo = Int32.Parse(dt.Rows[i]["SlabTo"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = dt.Rows[i]["Amount"].ToString()
                });

            }
            return ListContRent;
        }

        public DataTable GetContainerRentTariffRecord(MyContainerRent Data)
        {
            string _Query = "select CID,RentID,SlabFrom,SlabTo,CurrencyCode as Currency,CurrencyID,Amount from NVO_ContRentTariffDtls " +
                            " inner join NVO_CurrencyMaster ON NVO_CurrencyMaster.ID = NVO_ContRentTariffDtls.CurrencyID where RentID=" + Data.RentID;
            return GetViewData(_Query, "");
        }

        public List<MyContainerRent> GetRentTariffDelete(MyContainerRent Data)
        {
            DataTable dt = RentTariffDelete(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListContRent.Add(new MyContainerRent
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    RentID = Int32.Parse(dt.Rows[i]["RentID"].ToString()),
                    SlabFrom = Int32.Parse(dt.Rows[i]["SlabFrom"].ToString()),
                    SlabTo = Int32.Parse(dt.Rows[i]["SlabFrom"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = dt.Rows[i]["Amount"].ToString()
                });

            }
            return ListContRent;
        }

        public DataTable RentTariffDelete(MyContainerRent Data)
        {
            string _Query = "Delete NVO_ContRentTariffDtls where CID=" + Data.CID;
            return GetViewData(_Query, "");
        }

        #endregion


        #region Muthu

        public List<MyContainer> BkgContainerALLDetails(MyContainer Data)
        {
            DataTable dt = GetContainerALLDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListView.Add(new MyContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    PickupDate = dt.Rows[i]["PickupDate"].ToString(),
                    GateInDate = dt.Rows[i]["GateInDate"].ToString(),
                    BLNo = dt.Rows[i]["BLNumber"].ToString() + dt.Rows[i]["BLNumber1"].ToString(),
                    OPT = 0,
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    PartBL = Int32.Parse(dt.Rows[i]["PartBL"].ToString()),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),

                });

            }
            return ListView;
        }


        public DataTable GetContainerALLDetails(MyContainer Data)
        {
            string _Query = " select NVO_Containers.Id,CntrNo, (select top(1) Size from NVO_tblCntrTypes  where ID = NVO_Containers.TypeID) as Size,'N/A'  as GateInDate, " +
                            " (select top(1) Type from NVO_tblCntrTypes  where ID = NVO_Containers.TypeID) as Type, convert(varchar, Pickupdate, 103) as PickupDate, " +
                            " isnull((select top(1) OPT from NVO_BLContainer  where NVO_BLContainer.CntrID=NVO_Containers.Id),0) as OPT," +
                            " (select top(1) BLNumber from NVO_BL inner join NVO_BLContainer on NVO_BLContainer.BLID=NVO_BL.Id where NVO_BLContainer.CntrID=NVO_Containers.Id) as BLNumber," +
                            " (select top(1) BLNumber from NVO_V_MultiplePartBL where  NVO_V_MultiplePartBL.CntrID=NVO_Containers.ID) as BLNumber1," +
                            " isnull((select top(1) NVO_BL.ID from NVO_BL inner join NVO_BLContainer on NVO_BLContainer.BLID=NVO_BL.Id where NVO_BLContainer.CntrID=NVO_Containers.Id),0) as BLID, " +
                            " isnull((select case when BLNumber != '' then 1 else 0 end from NVO_V_MultiplePartBL where  NVO_V_MultiplePartBL.CntrID=NVO_Containers.ID),0) as PartBL, " +
                            " case when (select count(ID) from NVO_BLCargo where BkgID= NVO_ContainerTxns.BLNumber and NVO_BLCargo.CntrID = NVO_ContainerTxns.ContainerID)= 0 then 'Pending' else 'Updated' end Status, " +
                            " case when (select top(1) HazarOpt from NVO_BLCargo  where BkgID = NVO_ContainerTxns.BLNumber and CntrID=NVO_Containers.ID) = 2 then 'HAZARDOUS' ELSE 'GENERAL' END as Commodity   " +
                            " from NVO_Containers " +
                            " inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                            " where BLNumber =" + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MyContainer> BkgContainerDetails(MyContainer Data)
        {
            DataTable dt = GetContainerDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListView.Add(new MyContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    PickupDate = dt.Rows[i]["PickupDate"].ToString(),
                    GateInDate = dt.Rows[i]["GateInDate"].ToString(),
                    BLNo = dt.Rows[i]["BLNumber"].ToString() + dt.Rows[i]["BLNumber1"].ToString(),
                    OPT = 0,
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    PartBL = Int32.Parse(dt.Rows[i]["PartBL"].ToString()),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),

                });

            }
            return ListView;
        }

        public DataTable GetContainerDetails(MyContainer Data)
        {
            string _Query = " select NVO_Containers.Id,CntrNo, (select top(1) Size from NVO_tblCntrTypes  where ID = NVO_Containers.TypeID) as Size,'N/A'  as GateInDate, " +
                            " (select top(1) Type from NVO_tblCntrTypes  where ID = NVO_Containers.TypeID) as Type, convert(varchar, Pickupdate, 103) as PickupDate, " +
                            " isnull((select top(1) OPT from NVO_BLContainer  where NVO_BLContainer.CntrID=NVO_Containers.Id),0) as OPT," +
                            " (select top(1) BLNumber from NVO_BL inner join NVO_BLContainer on NVO_BLContainer.BLID=NVO_BL.Id where NVO_BLContainer.CntrID=NVO_Containers.Id) as BLNumber," +
                            " (select top(1) BLNumber from NVO_V_MultiplePartBL where  NVO_V_MultiplePartBL.CntrID=NVO_Containers.ID) as BLNumber1," +
                            " isnull((select top(1) NVO_BL.ID from NVO_BL inner join NVO_BLContainer on NVO_BLContainer.BLID=NVO_BL.Id where NVO_BLContainer.CntrID=NVO_Containers.Id),0) as BLID, " +
                            " isnull((select case when BLNumber != '' then 1 else 0 end from NVO_V_MultiplePartBL where  NVO_V_MultiplePartBL.CntrID=NVO_Containers.ID),0) as PartBL, " +
                            " case when (select count(ID) from NVO_BLCargo where BkgID= NVO_ContainerTxns.BLNumber and NVO_BLCargo.CntrID = NVO_ContainerTxns.ContainerID)= 0 then 'Pending' else 'Update' end Status, " +
                            " case when (select top(1) HazarOpt from NVO_BLCargo  where BkgID = NVO_ContainerTxns.BLNumber and CntrID=NVO_Containers.ID) = 2 then 'HAZARDOUS' ELSE 'GENERAL' END as Commodity " +
                            " from NVO_Containers " +
                            " inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                            " where BLNumber =" + Data.BkgID + " and NVO_Containers.Id not in (select CntrID from NVO_BLContainer  where BkgID = NVO_ContainerTxns.BLNumber and CntrID = NVO_Containers.Id)";
            return GetViewData(_Query, "");
        }
        List<MyBL> ListBL = new List<MyBL>();

        public List<MyBL> CurrenctDatetime(MyBL Data)
        {
            DataTable dt = GetCurrenctdatetime(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyBL
                {
                    DateTime = dt.Rows[i]["Datetime"].ToString(),
                });

            }
            return ListBL;
        }

        public DataTable GetCurrenctdatetime(MyBL Data)
        {
            string _Query = " Select CONVERT(varchar,getdate(),106) as Datetime";
            return GetViewData(_Query, "");
        }
        public List<MyContainer> BkgContainerListDetails(MyContainer Data)
        {
            DataTable dt = GetContainerListDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListView.Add(new MyContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    PickupDate = dt.Rows[i]["PickupDate"].ToString(),
                    GateInDate = dt.Rows[i]["GateInDate"].ToString(),
                    BLNo = dt.Rows[i]["BLNumber"].ToString() + dt.Rows[i]["BLNumber1"].ToString(),
                    OPT = 0,
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    PartBL = Int32.Parse(dt.Rows[i]["PartBL"].ToString()),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),

                });

            }
            return ListView;
        }


        public DataTable GetContainerListDetails(MyContainer Data)
        {
            string _Query = " select NVO_Containers.Id,CntrNo, (select top(1) Size from NVO_tblCntrTypes  where ID= NVO_Containers.TypeID) as Size, " +
                            " (select top(1) Type from NVO_tblCntrTypes  where ID= NVO_Containers.TypeID) as Type, convert(varchar, Pickupdate, 103) as PickupDate,'N/A'  as GateInDate, " +
                            " isnull((select top(1) OPT from NVO_BLContainer  where NVO_BLContainer.CntrID=NVO_Containers.Id),0) as OPT," +
                            " (select top(1) BLNumber from NVO_BL inner join NVO_BLContainer on NVO_BLContainer.BLID=NVO_BL.Id where NVO_BLContainer.CntrID=NVO_Containers.Id) as BLNumber," +
                            " (select top(1) BLNumber from NVO_V_MultiplePartBL where  NVO_V_MultiplePartBL.CntrID=NVO_Containers.ID) as BLNumber1," +
                            " isnull((select top(1) NVO_BL.ID from NVO_BL inner join NVO_BLContainer on NVO_BLContainer.BLID=NVO_BL.Id where NVO_BLContainer.CntrID=NVO_Containers.Id),0) as BLID, " +
                            " isnull((select case when BLNumber != '' then 1 else 0 end from NVO_V_MultiplePartBL where  NVO_V_MultiplePartBL.CntrID=NVO_Containers.ID),0) as PartBL, " +
                            " case when (select count(ID) from NVO_BLCargo where BkgID= NVO_ContainerTxns.BLNumber and NVO_BLCargo.CntrID = NVO_ContainerTxns.ContainerID)= 0 then 'Pending' else 'Update' end Status, " +
                            " case when(select top(1) HazarOpt from NVO_BLCargo  where BkgID = NVO_ContainerTxns.BLNumber and CntrID = NVO_Containers.ID) = 2 then 'HAZARDOUS' ELSE 'GENERAL' END as Commodity  " +
                            " from NVO_Containers " +
                            " inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                            " where BLNumber =" + Data.BkgID + " and NVO_Containers.Id in (select CntrID from NVO_BLContainer where BkgID = NVO_ContainerTxns.BLNumber and CntrID = NVO_Containers.Id and NVO_BLContainer.BLID=" + Data.BLID + ")";
            return GetViewData(_Query, "");
        }


        public List<MyBL> BLNumberListDetails(MyBL Data)
        {
            List<MyBL> Listv = new List<MyBL>();
            DataTable dt = GetBLNumberDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Listv.Add(new MyBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),


                });

            }
            return Listv;
        }

        public DataTable GetBLNumberDetails(MyBL Data)
        {
            string _Query = "select ID, BLNumber from NVO_BL where BkgId=" + Data.BkgID;
            return GetViewData(_Query, "");
        }
        public List<MyBL> InsertBLMaster(MyBL Data)
        {
            List<MyBL> ListBLView = new List<MyBL>();
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
                    if (Data.NoofBL == 0)
                    {
                        if (Data.ID == 0)
                        {
                            string AutoGen = GetMaxseqNumber("BL", "1", Data.SessionFinYear);
                            Cmd.CommandText = "select 'NAV' + (select (select top(1) RIGHT(PortCode, 3) from NVO_PortMaster where ID =LoadPortID) + (select top(1) PortCode from NVO_PortMaster where ID =DischargePortID) from NVO_Booking where Id =" + Data.BkgID + ")   + right('00000' + convert(varchar(5)," + AutoGen + "), 5)";
                            Data.BLNumber = Cmd.ExecuteScalar().ToString();
                        }

                        Cmd.CommandText = " IF((select count(*) from NVO_BL where ID=@ID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_BL(BLNumber,BkgID,CurrentDate,PartBL) " +
                                         " values (@BLNumber,@BkgID,@CurrentDate,@PartBL) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_BL SET BLNumber=@BLNumber,BkgID=@BkgID,CurrentDate=@CurrentDate,PartBL=@PartBL  where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartBL", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));




                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select ident_current('NVO_BL')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }
                        else
                            Data.ID = Data.ID;


                        if (Data.ItemsCntr != null)
                        {
                            string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                            for (int i = 1; i < Array.Length; i++)
                            {
                                var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                                Cmd.CommandText = " IF((select count(*) from NVO_BLContainer where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO  NVO_BLContainer(BLID,BkgID,CntrID,OPT) " +
                                             " values (@BLID,@BkgID,@CntrID,@OPT) " +
                                             " END  " +
                                             " ELSE " +
                                             " UPDATE NVO_BLContainer SET BLID=@BLID,BkgID=@BkgID,CntrID=@CntrID,OPT=@OPT where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OPT", 1));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                            }
                        }
                    }
                    else
                    {
                        for (int x = 0; x < Data.NoofBL; x++)
                        {
                            int Row = x;
                            if (Data.ID == 0)
                            {
                                string AutoGen = GetMaxseqNumber("BL", "1", Data.SessionFinYear);
                                Cmd.CommandText = "select 'NAV' + (select (select top(1) PortCode from NVO_PortMaster where ID =LoadPortID) + (select top(1) PortCode from NVO_PortMaster where ID =DischargePortID) from NVO_Booking where Id =" + Data.BkgID + ")   + right('00000' + convert(varchar(5)," + AutoGen + "), 5)";
                                Data.BLNumber = Cmd.ExecuteScalar().ToString();
                            }

                            Cmd.CommandText = " IF((select count(*) from NVO_BL where ID=@ID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO  NVO_BL(BLNumber,BkgID,CurrentDate,PartBL) " +
                                             " values (@BLNumber,@BkgID,@CurrentDate,@PartBL) " +
                                             " END  " +
                                             " ELSE " +
                                             " UPDATE NVO_BL SET BLNumber=@BLNumber,BkgID=@BkgID,CurrentDate=@CurrentDate,PartBL=@PartBL  where ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartBL", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));




                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            if (Data.ID == 0)
                            {
                                Cmd.CommandText = "select ident_current('NVO_BL')";
                                Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                            }
                            else
                                Data.ID = Data.ID;


                            if (Data.ItemsCntr != null)
                            {
                                string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                                for (int i = 1; i < Array.Length; i++)
                                {
                                    var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                                    Cmd.CommandText = " IF((select count(*) from NVO_BLContainer where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID)<=0) " +
                                                 " BEGIN " +
                                                 " INSERT INTO  NVO_BLContainer(BLID,BkgID,CntrID,OPT) " +
                                                 " values (@BLID,@BkgID,@CntrID,@OPT) " +
                                                 " END  " +
                                                 " ELSE " +
                                                 " UPDATE NVO_BLContainer SET BLID=@BLID,BkgID=@BkgID,CntrID=@CntrID,OPT=@OPT where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID";
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OPT", 1));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                                    result = Cmd.ExecuteNonQuery();
                                    Cmd.Parameters.Clear();

                                }
                            }
                            Data.ID = 0;
                        }
                    }
                    trans.Commit();
                    ListBLView.Add(new MyBL
                    {
                        ID = Data.ID,
                        AlertMessage = "Record Saved sucessfully " + Data.BLNumber,
                        BLNumber = Data.BLNumber

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyBL { AlertMessage = ex.Message });
                    return ListBLView;
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


        public List<MyBL> BLCntrRemovedMaster(MyBL Data)
        {
            List<MyBL> ListBLView = new List<MyBL>();
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

                    Cmd.CommandText = " Delete from NVO_BLContainer where BLID=@BLID and BkgID=@BkgID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "Delete from NVO_BL where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    ListBLView.Add(new MyBL
                    {
                        AlertMessage = "BL Removed for this Container Sucessfully"
                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyBL { AlertMessage = ex.Message });
                    return ListBLView;
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


        public List<MyBL> InsertBLAddCntrMaster(MyBL Data)
        {
            List<MyBL> ListBLView = new List<MyBL>();
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
                    if (Data.ItemsCntr != null)
                    {
                        string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_BLContainer where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_BLContainer(BLID,BkgID,CntrID,OPT) " +
                                         " values (@BLID,@BkgID,@CntrID,@OPT) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_BLContainer SET BLID=@BLID,BkgID=@BkgID,CntrID=@CntrID,OPT=@OPT where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OPT", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }





                    trans.Commit();
                    ListBLView.Add(new MyBL
                    {
                        ID = Data.ID,
                        AlertMessage = "BL Added for this Particular Contaner Sucessfully " + Data.BLNumber,
                        BLNumber = Data.BLNumber

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyBL { AlertMessage = ex.Message });
                    return ListBLView;
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


        public List<MyBL> InsertPartBLMaster(MyBL Data)
        {
            List<MyBL> ListBLView = new List<MyBL>();
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
                    Cmd.CommandText = " IF((select count(*) from NVO_BL where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BL(BLNumber,BkgID,CurrentDate,PartBL) " +
                                     " values (@BLNumber,@BkgID,@CurrentDate,@PartBL) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BL SET BLNumber=@BLNumber,BkgID=@BkgID,CurrentDate=@CurrentDate,PartBL=@PartBL  where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber + 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartBL", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_BL')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    DataTable _dtBLCntr = GetPartBLDetails(Data.BLID, Data.CntrID);
                    for (int i = 0; i < _dtBLCntr.Rows.Count; i++)
                    {

                        Cmd.CommandText = " IF((select count(*) from NVO_BLContainer where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLContainer(BLID,BkgID,CntrID,OPT) " +
                                     " values (@BLID,@BkgID,@CntrID,@OPT) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLContainer SET BLID=@BLID,BkgID=@BkgID,CntrID=@CntrID,OPT=@OPT where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OPT", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", _dtBLCntr.Rows[i]["CntrID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();
                    ListBLView.Add(new MyBL
                    {
                        ID = Data.ID,
                        AlertMessage = "Part BL Created Saved sucessfully " + Data.BLNumber,
                        BLNumber = Data.BLNumber

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyBL { AlertMessage = ex.Message });
                    return ListBLView;
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


        public DataTable GetPartBLDetails(string BLID, int CntrID)
        {
            string _Query = " select * from NVO_BLContainer where BLID=" + BLID + " and CntrID=" + CntrID;
            return GetViewData(_Query, "");
        }

        public List<MyBL> BLContainerValues(MyBL Data)
        {
            List<MyBL> ListViewBL = new List<MyBL>();
            DataTable dt = GetBLContainerValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListViewBL.Add(new MyBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLID = dt.Rows[i]["ID"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    CustomerSeal = dt.Rows[i]["CustomerSeal"].ToString(),
                    KGSWeight = dt.Rows[i]["KGSWeight"].ToString(),
                    NetWeight = dt.Rows[i]["NetWeight"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    Humidity = dt.Rows[i]["Humidity"].ToString(),
                    Ventilation = dt.Rows[i]["Ventilation"].ToString(),

                    CBMVolume = dt.Rows[i]["CBMVolume"].ToString(),
                    NoofPkgs = dt.Rows[i]["NoofPkgs"].ToString(),
                    PakageType = dt.Rows[i]["PakageType"].ToString(),
                    HAZClass = dt.Rows[i]["HAZClass"].ToString(),
                    IMCOCode = dt.Rows[i]["IMCOCode"].ToString(),
                    Lenght = dt.Rows[i]["Lenght"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    Height = dt.Rows[i]["Height"].ToString(),
                    HazarOpt = Int32.Parse(dt.Rows[i]["HazarOpt"].ToString()),
                    OOGOpt = Int32.Parse(dt.Rows[i]["OOGOpt"].ToString()),
                    RefferOpt = Int32.Parse(dt.Rows[i]["RefferOpt"].ToString()),
                    OdoRad = Int32.Parse(dt.Rows[i]["DoorOpenOPT"].ToString()),




                });

            }
            return ListViewBL;
        }
        public DataTable GetBLContainerValues(MyBL Data)
        {
            string _Query = " Select NVO_Containers.Id,NVO_Containers.CntrNo,isnull(NVO_BLCargo.BLID,0) as BLID,(select top(1) Size from NVO_tblCntrTypes  where SizeID= SizeID) as Size,  " +
                            " (select top(1) Type from NVO_tblCntrTypes  where SizeID = SizeID) as Type,SealNo,CustomerSeal,KGSWeight,NetWeight, " +
                            " Temperature,Humidity,Ventilation,isnull(DoorOpenOPT,1) as DoorOpenOPT ,CurrentDate,CBMVolume,isnull(OOGOpt,1) as OOGOpt,isnull(HazarOpt,1) as HazarOpt,NoofPkgs,PakageType,HAZClass,IMCOCode,Lenght,Width,Height,isnull(RefferOpt, 1) as RefferOpt from NVO_Containers " +
                            " inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                            " LEFT OUTER JOIN NVO_BLCargo on NVO_BLCargo.CntrID=NVO_Containers.ID  and  NVO_ContainerTxns.BLNumber= NVO_BLCargo.BkgID " +
                            " where NVO_ContainerTxns.BLNumber = " + Data.BkgID + " and NVO_Containers.Id=" + Data.CntrID;
            return GetViewData(_Query, "");
        }

        public List<MyContainer> BLCntrwisedropdown(MyContainer Data)
        {
            DataTable dt = GetCntrBLDrodownValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListView.Add(new MyContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNo = dt.Rows[i]["BLNumber"].ToString(),
                });

            }
            return ListView;
        }

        public DataTable GetCntrBLDrodownValues(MyContainer Data)
        {
            string _Query = " Select BLID as ID,(select top(1) BLNumber from NVO_BL where ID =NVO_BLContainer.BLID) as BLNumber " +
                            " from NVO_BLContainer where CntrID=" + Data.CntrID;
            return GetViewData(_Query, "");
        }



        public List<MyBL> InsertBLCargoMaster(MyBL Data)
        {
            List<MyBL> ListBLView = new List<MyBL>();
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
                    Cmd.CommandText = " IF((select count(*) from NVO_BLCargo where CntrID=@CntrID and BkgID=@BkgID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLCargo(BLID,BkgID,CntrID,CntrNo,CntrType,BLNumber,SealNo,CustomerSeal,KGSWeight,NetWeight,CBMVolume,NoofPkgs,PakageType,HazarOpt,HAZClass,IMCOCode,OOGOpt,Lenght,Width,Height,RefferOpt,Temperature,Humidity,Ventilation,DoorOpenOPT,CurrentDate) " +
                                     " values (@BLID,@BkgID,@CntrID,@CntrNo,@CntrType,@BLNumber,@SealNo,@CustomerSeal,@KGSWeight,@NetWeight,@CBMVolume,@NoofPkgs,@PakageType,@HazarOpt,@HAZClass,@IMCOCode,@OOGOpt,@Lenght,@Width,@Height,@RefferOpt,@Temperature,@Humidity,@Ventilation,@DoorOpenOPT,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLCargo SET BLID=@BLID,BkgID=@BkgID,CntrID=@CntrID,CntrNO=@CntrNO,CntrType=@CntrType,BLNumber=@BLNumber,SealNo=@SealNo,CustomerSeal=@CustomerSeal,KGSWeight=@KGSWeight,NetWeight=@NetWeight,CBMVolume=@CBMVolume,NoofPkgs=@NoofPkgs,PakageType=@PakageType,HazarOpt=@HazarOpt," +
                                     " HAZClass=@HAZClass,IMCOCode=@IMCOCode,OOGOpt=@OOGOpt,Lenght=@Lenght,Width=@Width,Height=@Height,RefferOpt=@RefferOpt,Temperature=@Temperature,Humidity=@Humidity,Ventilation=@Ventilation,DoorOpenOPT=@DoorOpenOPT,CurrentDate=@CurrentDate  where CntrID=@CntrID and BkgID=@BkgID";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", Data.CntrNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", Data.CntrType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", Data.SealNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerSeal", Data.CustomerSeal));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@KGSWeight", Data.KGSWeight));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NetWeight", Data.NetWeight));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CBMVolume", Data.CBMVolume));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofPkgs", Data.NoofPkgs));
                    if (Data.PakageType != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakageType", Data.PakageType));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakageType", 0));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HazarOpt", Data.HazarOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HAZClass", Data.HAZClass));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IMCOCode", Data.IMCOCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OOGOpt", Data.OOGOpt));
                    if (Data.Lenght != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Lenght", Data.Lenght));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Lenght", 0));
                    if (Data.Width != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", Data.Width));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", 0));
                    if (Data.Height != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Height", Data.Height));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Height", 0));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RefferOpt", Data.RefferOpt));
                    if (Data.Temperature != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Temperature", Data.Temperature));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Temperature", 0));
                    if (Data.Humidity != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Humidity", Data.Humidity));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Humidity", 0));

                    if (Data.Ventilation != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Ventilation", Data.Ventilation));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Ventilation", 0));
                    if (Data.DoorOpenOPT != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DoorOpenOPT", Data.DoorOpenOPT));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DoorOpenOPT", 0));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    ListBLView.Add(new MyBL
                    {
                        ID = Data.ID,
                        AlertMessage = "Record Saved sucessfully " + Data.BLNumber,
                        BLNumber = Data.BLNumber

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyBL { AlertMessage = ex.Message });
                    return ListBLView;
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


        public List<MyContainer> BLNoDisplayList(MyContainer Data)
        {
            DataTable dt = GetBLNoValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListView.Add(new MyContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNo = dt.Rows[i]["BLNumber"].ToString(),
                    OPT = 0,
                });

            }
            return ListView;
        }

        public DataTable GetBLNoValues(MyContainer Data)
        {
            string _Query = "select ID,BLNumber from NVO_BL where PartBL=0 and BkgID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MyContainer> BLContainerAssignList(MyContainer Data)
        {
            DataTable dt = GetBLCntrNoValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListView.Add(new MyContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    OPT = 0,
                });

            }
            return ListView;
        }

        public DataTable GetBLCntrNoValues(MyContainer Data)
        {
            string _Query = " select NVO_Containers.ID,CntrNo from NVO_Containers inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                            " where BLNumber = " + Data.BkgID + " and NVO_Containers.ID not in (select CntrID from NVO_BLContainer where  BkgID = " + Data.BkgID + ")";
            return GetViewData(_Query, "");
        }

        public List<MyBL> ExcelInsertBLCargoMaster(MyBL Data)
        {
            List<MyBL> ListBLView = new List<MyBL>();
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
                    if (Data.ItemsCntr != null)
                    {
                        var Validation = "";
                        var ValidationTest = "";
                        string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            ValidationTest = "";
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " select top(1) NVO_Containers.ID from NVO_Containers INNER JOIN NVO_Containertxns on  NVO_Containertxns.ContainerID=NVO_Containers.ID where BLNumber=" + Data.BkgID + " and CntrNo='" + CharSplit[0] + "'";
                            int CntrID = 0;
                            CntrID = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (CntrID == 0)
                            {
                                Validation += "invalid Container No:" + CharSplit[0];
                                ValidationTest += "invalid Container No:" + CharSplit[0];
                            }

                            Cmd.CommandText = " select (select top(1) Size from NVO_tblCntrTypes where NVO_tblCntrTypes.Id = NVO_Containers.TypeID) from NVO_Containers where CntrNo='" + CharSplit[0] + "'";
                            object Type = 0;
                            Type = Cmd.ExecuteScalar();

                            Cmd.CommandText = " select ID from NVO_CargoPkgMaster where PkgDescription='" + CharSplit[6] + "'";
                            int PakageTypes = 0;
                            PakageTypes = Convert.ToInt32(Cmd.ExecuteScalar());


                            if (PakageTypes == 0)
                            {
                                Validation += "invalid CommodityName:" + CharSplit[6];
                                ValidationTest += "invalid CommodityName:" + CharSplit[6];
                            }
                            ListBLView.Add(new MyBL { Rows = i, AlertMessage = ValidationTest, UploadStatusID = "File Read Successfully" });

                        }
                        if (Validation != "")
                        {
                            ListBLView.Add(new MyBL { UploadStatusID = "File Read Successfully" });
                            return ListBLView;
                        }
                    }

                    if (Data.ItemsCntr != null)
                    {
                        string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var Validation = "";
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " select top(1) NVO_Containers.ID from NVO_Containers INNER JOIN NVO_Containertxns on  NVO_Containertxns.ContainerID=NVO_Containers.ID where BLNumber=" + Data.BkgID + " and CntrNo='" + CharSplit[0] + "'";
                            int CntrID = 0;
                            CntrID = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (CntrID == 0)
                            {
                                Validation += "Invalid Container No:" + CharSplit[0];
                            }

                            Cmd.CommandText = " select (select top(1) Size from NVO_tblCntrTypes where NVO_tblCntrTypes.Id = NVO_Containers.TypeID) from NVO_Containers where CntrNo='" + CharSplit[0] + "'";
                            object Type = 0;
                            Type = Cmd.ExecuteScalar();

                            Cmd.CommandText = " select ID from NVO_CargoPkgMaster where PkgDescription='" + CharSplit[6] + "'";
                            int PakageTypes = 0;
                            PakageTypes = Convert.ToInt32(Cmd.ExecuteScalar());


                            if (PakageTypes == 0)
                            {
                                Validation += "Invalid CommodityName:" + CharSplit[6];
                            }

                            if (Validation != "")
                            {
                                ListBLView.Add(new MyBL { Rows = i, AlertMessage = Validation, UploadStatusID = "Uploaded file has error" });
                                return ListBLView;
                            }

                            Cmd.CommandText = " IF((select count(*) from NVO_BLCargo where BkgID=@BkgID and CntrID=@CntrID )<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLCargo(BLID,BkgID,CntrID,CntrNo,CntrType,BLNumber,SealNo,CustomerSeal,KGSWeight,NetWeight,CBMVolume,NoofPkgs,PakageType,HazarOpt,HAZClass,IMCOCode,OOGOpt,Lenght,Width,Height,RefferOpt,Temperature,Humidity,Ventilation,DoorOpenOPT,CurrentDate) " +
                                     " values (@BLID,@BkgID,@CntrID,@CntrNo,@CntrType,@BLNumber,@SealNo,@CustomerSeal,@KGSWeight,@NetWeight,@CBMVolume,@NoofPkgs,@PakageType,@HazarOpt,@HAZClass,@IMCOCode,@OOGOpt,@Lenght,@Width,@Height,@RefferOpt,@Temperature,@Humidity,@Ventilation,@DoorOpenOPT,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLCargo SET BLID=@BLID,BkgID=@BkgID,CntrID=@CntrID,CntrNO=@CntrNO,CntrType=@CntrType,BLNumber=@BLNumber,SealNo=@SealNo,CustomerSeal=@CustomerSeal,KGSWeight=@KGSWeight,NetWeight=@NetWeight,CBMVolume=@CBMVolume,NoofPkgs=@NoofPkgs,PakageType=@PakageType,HazarOpt=@HazarOpt," +
                                     " HAZClass=@HAZClass,IMCOCode=@IMCOCode,OOGOpt=@OOGOpt,Lenght=@Lenght,Width=@Width,Height=@Height,RefferOpt=@RefferOpt,Temperature=@Temperature,Humidity=@Humidity,Ventilation=@Ventilation,DoorOpenOPT=@DoorOpenOPT,CurrentDate=@CurrentDate  where BkgID=@BkgID and CntrID=@CntrID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CntrID));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", Type));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerSeal", CharSplit[2]));
                 

                            if (CharSplit[3] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@KGSWeight", CharSplit[3]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@KGSWeight", 0));

                            if (CharSplit[4] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NetWeight", CharSplit[4]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NetWeight", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CBMVolume", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofPkgs", CharSplit[5]));
                            if (PakageTypes != 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PakageType", PakageTypes));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PakageType", 0));
                            if (CharSplit[7] == "Yes" || CharSplit[7] == "YES" || CharSplit[7] == "yes")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@HazarOpt", 2));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@HazarOpt", 1));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@HAZClass", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IMCOCode", CharSplit[9]));
                            if (CharSplit[10] == "Yes" || CharSplit[10] == "YES" || CharSplit[10] == "yes")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OOGOpt", 2));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OOGOpt", 1));
                            if (CharSplit[11] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Lenght", CharSplit[11]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Lenght", 0));
                            if (CharSplit[12] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", CharSplit[12]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", 0));
                            if (CharSplit[13] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Height", CharSplit[13]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Height", 0));

                            if (CharSplit[14] == "Yes" || CharSplit[14] == "YES" || CharSplit[14] == "yes")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RefferOpt", 2));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RefferOpt", 1));

                            if (CharSplit[15] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Temperature", CharSplit[15]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Temperature", 0));
                            if (CharSplit[16] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Humidity", CharSplit[16]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Humidity", 0));

                            if (CharSplit[17] != "")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Ventilation", CharSplit[17]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Ventilation", 0));

                            if (CharSplit[18] == "Yes" || CharSplit[18] == "YES" || CharSplit[18] == "yes")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DoorOpenOPT", 2));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DoorOpenOPT", 1));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }




                    trans.Commit();
                    ListBLView.Add(new MyBL
                    {
                        ID = Data.ID,
                        AlertMessage = "Record Saved sucessfully " + Data.BLNumber,
                        BLNumber = Data.BLNumber,
                        UploadStatusID = "File Read Successfully"

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyBL { AlertMessage = ex.Message, UploadStatusID = "Uploaded file has error" });
                    return ListBLView;
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


        public List<MyExportBooking> ExistingBooking(MyExportBooking Data)
        {
            List<MyExportBooking> ListExpBooking = new List<MyExportBooking>();
            DataTable dt = GetBookingValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExpBooking.Add(new MyExportBooking
                {
                    //ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BookingParty = dt.Rows[i]["BkgParty"].ToString(),
                    BookingDate = dt.Rows[i]["BkgDate"].ToString(),
                    BookingStatus = dt.Rows[i]["BookingStatus"].ToString(),
                    BookingCommission = dt.Rows[i]["BkgCommission"].ToString(),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                    Source = dt.Rows[i]["Source"].ToString(),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    Origin = dt.Rows[i]["Origin"].ToString(),
                    DischargePort = dt.Rows[i]["DisChargePort"].ToString(),
                    LoadPort = dt.Rows[i]["LoadPort"].ToString(),
                    Destination = dt.Rows[i]["Destination"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString().ToUpper(),

                });

            }
            return ListExpBooking;
        }
        public DataTable GetBookingValues(MyExportBooking Data)
        {
            string _Query = "select NVO_Booking.ID,NVO_Booking.VesselID,NVO_Booking.VoyageID,(select Customername from NVO_view_CustomerDetails where NVO_view_CustomerDetails.CID = NVO_Booking.CustomerID)as BkgParty, " +
                            " case when intStatus = 2 then 'Confirm' else 'Draft' end as BookingStatus,BookingNo,convert(varchar, EnquiryDate, 103) as BkgDate, " +
                            " case when bookingcommissionID = 1 then 'Yes' else 'No' end as BkgCommission,(select top(1) EnquiryNo from NVO_Enquiry where Id = EnquiryID) as EnquiryNo, " +
                            " case when enquirySourceID = 1 then 'Local' else 'Nomination' end as Source,(select username from NVO_UserDetails where NVO_UserDetails.ID = NVO_Booking.SalesPersonID)as SalesPerson, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.OriginID)as Origin, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.LoadPortID)as LoadPort, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DischargePortID)as DisChargePort, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DestinationID)as Destination, " +
                            " (select GeneralName from NVO_GeneralMaster where SeqNo = 49 and ID = RouteID)as Route, " +
                            " (select GeneralName from NVO_GeneralMaster where SeqNo = 75 and ID = DeliveryTermsID)as DeliveryTerms,CargoID as Commodity,  " +
                            //" (select CommodityName from NVO_CommodityMaster where NVO_CommodityMaster.ID = NVO_Booking.CargoID)as Commodity," +
                            "CargoWeight,HSCode,intHazardous,intReefer,intOOG,Case When PaymentTermsID=1 then 'Prepaid' else 'Collect' end as PaymentTerms, " +
                            " (select vesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID)as VesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.POLTerminalID)as POLTerminal, " +
                            " (select vesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.TSVesselID)as TsVesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.TSVoyageID)as TSVoyageNo, " +
                            " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID)as Principal, " +
                            " (select RequestNo  from NVO_PrincipalRateRequest where NVO_PrincipalRateRequest.ID = NVO_Booking.LineContractID)as LinerContractNo, " +
                            " (select ContractNo from NVO_CustomerContract where NVO_CustomerContract.ID = NVO_Booking.CustomerContractID)as CusContractNo, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.PODAgentID)as PODAgent, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.FPODAgentID)as FPODAgent, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.TSportAgentID)as TSPortAgent1, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.TSportTwoAgentID)as TSPortAgent2, " +
                            " (select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_Booking.SlotOperatorID)as SlotOperator, " +
                            " case when OwnershipID = 1 then 'COC' else 'SOC' end as Ownership, " +
                            " case when FixedID = 1 then 'Yes' else 'No' end as Fixed,case when FreeDaysOrigin=1 then 'Standard' else 'Special' end as FreeDaysOrg,FreeDaysOrgValue, " +
                            " case when FreeDaysDest = 1 then 'Standard' else 'Special' end as FreeDaysDes,FreeDaysDestValue, " +
                            " case when DamageScheme = 1 then 'Standard' else 'Special' end as DamageScheme,DamageSchemeValue, " +
                            " case when SecurityDeposit = 1 then 'Standard' else 'Special' end as SecurityDeposit,SecurityDepositDesc, " +
                            " case when BOLReq = 1 then 'Standard' else 'Special' end as BOLReq,BOLReqDesc, " +
                            " * from NVO_Booking where NVO_Booking.ID =" + Data.BkgID;
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

        #endregion 
    }
}


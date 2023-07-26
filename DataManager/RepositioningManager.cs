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
    public class RepositioningManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public RepositioningManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        List<MyRepositioning> ListRepositioning = new List<MyRepositioning>();

        public List<MyRepositioning> GetSaveRepositioning(MyRepositioning Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            //DataTable dtchk = GetRepositioningValues(Data);
            //if (Data.ID == 0)
            //{
            //    if (dtchk.Rows.Count >= 1)
            //    {

            //        ListRepositioning.Add(new MyRepositioning
            //        {
            //            ID = Data.ID,

            //            AlertMegId = "1",
            //            AlertMessage = "Storage Locatin Type Already Exists"
            //        });
            //        return ListRepositioning;

            //    }
            //}

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

                        string AutoGen = GetMaxseqNumber("REPONO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'REP'  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RequestNo = Cmd.ExecuteScalar().ToString();

                    }


                    Cmd.CommandText = " IF((select count(*) from NVO_CntrPickDrop where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Repositioning(RequestNo,RepoType,ReqDate,RepoStatus,OriginID,POLID,PODID,PrincipleID,POLAgentID,PODAgentID,Transporter,AttachFile,VesselID,VoyageID,Remarks,UserID,CreatedOn,OfficeID) " +
                                     " values (@RequestNo,@RepoType,@ReqDate,@RepoStatus,@OriginID,@POLID,@PODID,@PrincipleID,@POLAgentID,@PODAgentID,@Transporter,@AttachFile,@VesselID,@VoyageID,@Remarks,@UserID,@CreatedOn,@OfficeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Repositioning SET RequestNo=@RequestNo,RepoType=@RepoType,ReqDate=@ReqDate,RepoStatus=@RepoStatus,OriginID=@OriginID,POLID=@POLID,PODID=@PODID,PrincipleID=@PrincipleID,POLAgentID=@POLAgentID,PODAgentID=@PODAgentID,Transporter=@Transporter,AttachFile=@AttachFile,VesselID=@VesselID,VoyageID=@VoyageID,Remarks=@Remarks,UserID=@UserID,CreatedOn=@CreatedOn,OfficeID=@OfficeID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestNo", Data.RequestNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RepoType", Data.RepoType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqDate", Data.ReqDate));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OriginID", Data.OriginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipleID", Data.PrincipleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLAgentID", Data.POLAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODAgentID", Data.PODAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Transporter", Data.Transporter));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.AttachFile));
                    if (Data.VesselID != 0)
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepoStatus", 2));

                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepoStatus", Data.RepoStatus));
                    }
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.VoyageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeID", Data.OfficeLocation));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_Repositioning')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;


                    string[] Array2 = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array2.Length; i++)
                    {

                        var CharSplit = Array2[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RepositioningDtls where RID=@RID AND RepoID=@RepoID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RepositioningDtls(RepoID,CntrTypeID,CntrType,Nos,StorageLocID,StorageLoc) " +
                                     " values (@RepoID,@CntrTypeID,@CntrType,@Nos,@StorageLocID,@StorageLoc) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RepositioningDtls SET RepoID=@RepoID,CntrTypeID=@CntrTypeID,CntrType=@CntrType,Nos=@Nos,StorageLocID=@StorageLocID,StorageLoc=@StorageLoc where RID=@RID and RepoID=@RepoID";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepoID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StorageLocID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StorageLoc", CharSplit[5]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                    ListRepositioning.Add(new MyRepositioning
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListRepositioning;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRepositioning.Add(new MyRepositioning
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRepositioning;
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



        public List<MyRepositioning> SaveRepositioningCntrsValues(MyRepositioning Data)
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


                    string[] Array2 = Data.Itemsvc.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array2.Length; i++)
                    {

                        var CharSplit = Array2[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RepoCntrDtls where  RepoID=@RepoID AND CntrID=@CntrID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RepoCntrDtls(RepoID,CntrID,CntrNo,CntrTypeID,CntrType,ISOCode) " +
                                     " values (@RepoID,@CntrID,@CntrNo,@CntrTypeID,@CntrType,@ISOCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RepoCntrDtls SET RepoID=@RepoID,CntrTypeID=@CntrTypeID,CntrType=@CntrType,CntrID=@CntrID,CntrNo=@CntrNo," +
                                     " ISOCode=@ISOCode where RepoID=@RepoID AND CntrID=@CntrID ";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepoID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[4]));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                    ListRepositioning.Add(new MyRepositioning
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListRepositioning;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListRepositioning.Add(new MyRepositioning
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListRepositioning;
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

        public List<MyRepositioning> GetRepositioningList(MyRepositioning Data)
        {
            DataTable dt = GetRepositioningListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListRepositioning.Add(new MyRepositioning
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                    ReqDatev = dt.Rows[i]["ReqDatev"].ToString(),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    OriginName = dt.Rows[i]["OriginName"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    RepoTypeName = dt.Rows[i]["RepoTypeName"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    RepoStatusName = dt.Rows[i]["RepoStatusName"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                });

            }
            return ListRepositioning;
        }
        public DataTable GetRepositioningListValues(MyRepositioning Data)
        {
            string strWhere = "";

            string _Query = " select ID,RequestNo,convert(varchar, ReqDate, 103) as ReqDatev, " +
                            " (select  LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID =NVO_Repositioning.PrincipleID) as PrincipleName , " +
                            " (select PortCode +'-'+ PortName from NVO_PortMaster where NVO_PortMaster.ID=NVO_Repositioning.OriginID) as OriginName, " +
                            " (select PortCode +'-'+ PortName from NVO_PortMaster where NVO_PortMaster.ID=NVO_Repositioning.POLID) as POLName, " +
                            " (select PortCode +'-'+ PortName from NVO_PortMaster where NVO_PortMaster.ID=NVO_Repositioning.PODID) as PODName, " +
                            " (select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID=NVO_Repositioning.VesselID) as VesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID=NVO_Repositioning.VoyageID) as VoyageName, " +
                            " (select sum(Nos) from NVO_RepositioningDtls where RepoID=NVO_Repositioning.ID) as Nos, " +
                            " case when NVO_Repositioning.RepoStatus = 1 then 'Planning' when NVO_Repositioning.RepoStatus = 2 then 'In progress' when NVO_Repositioning.RepoStatus = 3  then 'Complete' ELSE '' END as RepoStatusName, " +
                            " case when NVO_Repositioning.RepoType = 1 then 'OUT' when NVO_Repositioning.RepoType = 2 then 'IN' ELSE '' END as RepoTypeName " +
                            "  from NVO_Repositioning ";


            if (Data.RepoStatus.ToString() != "" && Data.RepoStatus.ToString() != "0" && Data.RepoStatus.ToString() != null && Data.RepoStatus.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Repositioning.RepoStatus = " + Data.RepoStatus.ToString();
                else
                    strWhere += " and NVO_Repositioning.RepoStatus = " + Data.RepoStatus.ToString();

            if (Data.RepoType.ToString() != "" && Data.RepoType.ToString() != "0" && Data.RepoType.ToString() != null && Data.RepoType.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Repositioning.RepoType = " + Data.RepoType.ToString();
                else
                    strWhere += " and NVO_Repositioning.RepoType = " + Data.RepoType.ToString();

            if (Data.PrincipleID.ToString() != "" && Data.PrincipleID.ToString() != "0" && Data.PrincipleID.ToString() != null && Data.PrincipleID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Repositioning.PrincipleID = " + Data.PrincipleID.ToString();
                else
                    strWhere += " and NVO_Repositioning.PrincipleID = " + Data.PrincipleID.ToString();

            if (Data.PODID.ToString() != "" && Data.PODID.ToString() != "0" && Data.PODID.ToString() != null && Data.PODID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Repositioning.PODID = " + Data.PODID.ToString();
                else
                    strWhere += " and NVO_Repositioning.PODID = " + Data.PODID.ToString();

            if (Data.VesselID.ToString() != "" && Data.VesselID.ToString() != null && Data.VesselID.ToString() != "0" && Data.VesselID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE VesselID =" + Data.VesselID.ToString() + "";
                else
                    strWhere += " and VesselID =" + Data.VesselID.ToString() + "";

            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE VoyageID =" + Data.VoyageID + "";
                else
                    strWhere += " and VoyageID =" + Data.VoyageID + "";

            if (Data.OfficeLocation.ToString() != "" && Data.OfficeLocation.ToString() != null && Data.OfficeLocation.ToString() != "0" && Data.OfficeLocation.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE OfficeID =" + Data.OfficeLocation + "";
                else
                    strWhere += " and OfficeID =" + Data.OfficeLocation + "";

            if (Data.StorageLocID.ToString() != "" && Data.StorageLocID.ToString() != null && Data.StorageLocID.ToString() != "0" && Data.StorageLocID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE (select top 1 StorageLocID from NVO_RepositioningDtls where RepoID=NVO_Repositioning.ID) =" + Data.StorageLocID + "";
                else
                    strWhere += " and (select top 1 StorageLocID from NVO_RepositioningDtls where RepoID=NVO_Repositioning.ID) =" + Data.StorageLocID + "";


            if (Data.RequestNo != "" && Data.RequestNo != null)
                if (strWhere == "")
                    strWhere += _Query + " where RequestNo like '%" + Data.RequestNo + "%'";
                else
                    strWhere += " and RequestNo like '%" + Data.RequestNo + "%'";

            if (Data.DtFrom != "" && Data.DtFrom != null)
                if (strWhere == "")
                    strWhere += _Query + " where ReqDate >= '" + DateTime.Parse(Data.DtFrom).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ReqDate >= '" + DateTime.Parse(Data.DtFrom).ToString("MM/dd/yyyy") + "'";

            if (Data.DtTo != "" && Data.DtTo != null)
                if (strWhere == "")
                    strWhere += _Query + " where ReqDate <= '" + DateTime.Parse(Data.DtTo).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ReqDate <= '" + DateTime.Parse(Data.DtTo).ToString("MM/dd/yyyy") + "'";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyRepositioning> GetRepositioningEdit(MyRepositioning Data)
        {
            DataTable dt = GetRepositioningEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListRepositioning.Add(new MyRepositioning
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),
                    RepoType = Int32.Parse(dt.Rows[i]["RepoType"].ToString()),
                    ReqDate = dt.Rows[i]["ReqDate"].ToString(),
                    RepoStatus = Int32.Parse(dt.Rows[i]["RepoStatus"].ToString()),
                    OriginID = Int32.Parse(dt.Rows[i]["OriginID"].ToString()),
                    POLID = Int32.Parse(dt.Rows[i]["POLID"].ToString()),
                    PODID = Int32.Parse(dt.Rows[i]["PODID"].ToString()),
                    PrincipleID = Int32.Parse(dt.Rows[i]["PrincipleID"].ToString()),
                    Transporter = dt.Rows[i]["Transporter"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    OfficeLocation = Int32.Parse(dt.Rows[i]["OfficeID"].ToString()),
                    POLAgentID = Int32.Parse(dt.Rows[i]["POLAgentID"].ToString()),
                    PODAgentID = Int32.Parse(dt.Rows[i]["PODAgentID"].ToString()),
                });
            }


            return ListRepositioning;
        }

        public DataTable GetRepositioningEditValues(MyRepositioning Data)
        {
            string _Query = "Select convert(varchar, ReqDate, 23) as ReqDate, * from NVO_Repositioning where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyRepositioning> GetRepositioningCntrsEdit(MyRepositioning Data)
        {
            DataTable dt = GETCntrsEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListRepositioning.Add(new MyRepositioning
                {

                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    StorageLocID = Int32.Parse(dt.Rows[i]["StorageLocID"].ToString()),
                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                });
            }


            return ListRepositioning;
        }

        public DataTable GETCntrsEditValues(MyRepositioning Data)
        {
            string _Query = "select * from NVO_RepositioningDtls where RID=" + Data.ID;
            return GetViewData(_Query, "");
        }



        public List<MyRepositioning> BindValidContainerNos(MyRepositioning Data)
        {
            List<MyRepositioning> ListView = new List<MyRepositioning>();


            string[] CntrSplit = new string[] { "\n" };
            string[] CntrNos = Data.ContainerNos.Split(CntrSplit, StringSplitOptions.None);
            for (int i = 0; i < CntrNos.Length; i++)
            {

                DataTable _dt = GetCheckCntrNo(CntrNos[i].ToString());
                if (_dt.Rows.Count > 0)
                {
                    ListView.Add(new MyRepositioning
                    {
                        ID = Int32.Parse(_dt.Rows[0]["ID"].ToString()),
                        CntrNo = _dt.Rows[0]["CntrNo"].ToString(),
                        CntrType = _dt.Rows[0]["CntrType"].ToString(),
                        CntrTypeID = Int32.Parse(_dt.Rows[0]["CntrTypeID"].ToString()),
                        ISOCode = _dt.Rows[0]["ISOCode"].ToString(),
                        //Status = _dt.Rows[0]["Status"].ToString(),


                    });
                }
                else
                {
                    ListView.Add(new MyRepositioning
                    {

                        CntrNo = CntrNos[i],
                        CntrType = "",
                        ISOCode = "",
                        Status = "No Container Failed",

                    });
                }

            }
            return ListView;
        }
        public DataTable GetCheckCntrNo(string CntrNos)
        {
            //string _Query = " SELECT ID,StatusCode,CntrNo,ID,(select top(1) convert(varchar,DtMovement, 103) from NVO_ContainerTxns where ContainerID=NVO_Containers.ID) as dtMovement, " +
            //                " isnull((select top(1)(select top(1) StorageCode from NVO_StorageLocationMaster where Id = NVO_ContainerTxns.LocationID) " +
            //                " from NVO_ContainerTxns where ContainerID = NVO_Containers.ID), 'NA') as Location FROM NVO_Containers where CntrNo='" + CntrNos + "'";

            //string _Query = " Select top(1) NVO_Containers.ID,CntrNo,NVO_Containers.StatusCode,NVO_ContainerTxns.StatusCode,convert(varchar,NVO_ContainerTxns.DtMovement, 103)  as dtMovement, " +
            //                " case  when NVO_ContainerTxns.StatusCodeID in (select ToStatusID from NVO_ContainerStatusPossibleMoves where StatusCodeID = 5) then 'Completed' else 'Pending' end Status, " +
            //                " isnull((select top(1)(select top(1) StorageCode from NVO_StorageLocationMaster where Id = NVO_ContainerTxns.LocationID) from NVO_ContainerTxns where ContainerID = NVO_Containers.ID), 'NA') as Location " +
            //                " from NVO_ContainerTxns " +
            //                " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
            //                " where NVO_Containers.CntrNo='" + CntrNos + "'";

            String _Query = " select ID,CntrNo,TypeID As CntrTypeID,(Select top 1 Size from NVO_tblCntrTypes WHERE ID =TypeID) As CntrType," +
                " (Select top 1 ISOCode from NVO_tblCntrTypes WHERE ID =TypeID) As ISOCode " +
                " from NVO_Containers " +
                " where StatusCodeID in (3,4,7 )  and NVO_Containers.CntrNo='" + CntrNos + "'";
            return GetViewData(_Query, "");
        }



        public List<MyRepositioning> BindRepositioningCntrsTabView(MyRepositioning Data)
        {
            List<MyRepositioning> ListView = new List<MyRepositioning>();

            DataTable _dt = GETRepositioningCntrsTab(Data);

            for (int i = 0; i < _dt.Rows.Count; i++)
            {


                ListView.Add(new MyRepositioning
                {
                    ID = Int32.Parse(_dt.Rows[0]["CntrID"].ToString()),
                    CntrNo = _dt.Rows[0]["CntrNo"].ToString(),
                    CntrType = _dt.Rows[0]["CntrType"].ToString(),
                    CntrTypeID = Int32.Parse(_dt.Rows[0]["CntrTypeID"].ToString()),
                    ISOCode = _dt.Rows[0]["ISOCode"].ToString(),
                    //Status = _dt.Rows[0]["Status"].ToString(),


                });


            }
            return ListView;
        }
        public DataTable GETRepositioningCntrsTab(MyRepositioning Data)
        {
     
            String _Query = " select * from NVO_RepoCntrDtls where RepoID= "+Data.ID;
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



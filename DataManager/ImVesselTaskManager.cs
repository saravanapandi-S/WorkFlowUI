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
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using System.Reflection;

namespace DataManager
{
    public class ImVesselTaskManager

    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImVesselTaskManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion


        List<MyImVesselTask> VesselTaskList = new List<MyImVesselTask>();
        public List<MyImVesselTask> GetVesselTaskList(MyImVesselTask Data)
        {
            DataTable dt = GetVesselTaskListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    DischargedNo = dt.Rows[i]["DischargedNo"].ToString(),
                    DischargeList = dt.Rows[i]["DischargeList"].ToString(),
                    Manifest = dt.Rows[i]["Manifest"].ToString(),
                    DischargeConfirm = dt.Rows[i]["DischargeConfirm"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetVesselTaskListValues(MyImVesselTask Data)
        {
            string strWhere = "";

            string _Query = " select distinct VesselName, NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID,(select top(1) VoyageNo from NVO_Voyage where ID =NVO_ImpBL.VoyageID) as VoyageNo, " +
                            " (select top(1) convert(varchar, ETA,103) from NVO_Voyage where ID =NVO_ImpBL.VoyageID) as ETA, " +
                            " (select Count(ID) from  Nvo_ImpBL BL where BL.VesselID =NVO_ImpBL.VesselID  and  BL.VoyageID=NVO_ImpBL.VoyageID) as BLCount, " +
                            " (select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls " +
                            " inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID =NVO_ImpBL.VesselID  and  BL.VoyageID=NVO_ImpBL.VoyageID) as CntrCount, " +
                            " 'N/A' as DischargedNo,'N/A' as DischargeList,'N/A' as Manifest, 'N/A' as DischargeConfirm, 'N/A' as Status,OfficeID " +
                            " from NVO_VesselMaster inner join NVO_ImpBL on NVO_ImpBL.VesselID=NVO_VesselMaster.ID ";


            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where OfficeID = " + Data.OfficeID + "";
                else
                    strWhere += " and OfficeID = " + Data.OfficeID + "";


            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE NVO_ImpBL.VoyageID =" + Data.VoyageID + "";
                else
                    strWhere += " and NVO_ImpBL.VoyageID =" + Data.VoyageID + "";

            if (Data.ETAFrom != "" && Data.ETAFrom != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select TOP 1 ETA from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) >= '" + DateTime.Parse(Data.ETAFrom.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and (select TOP 1 ETA from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) >= '" + DateTime.Parse(Data.ETAFrom.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.ETATo != "" && Data.ETATo != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select TOP 1 ETA from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) <= '" + DateTime.Parse(Data.ETATo.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and (select TOP 1 ETA from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) <= '" + DateTime.Parse(Data.ETATo.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where Nvo_ImpBL.BLNumber like '%" + Data.BLNumber + "%'";
                else
                    strWhere += " and Nvo_ImpBL.BLNumber like '%" + Data.BLNumber + "%'";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyImVesselTask> GetVesselFormList(MyImVesselTask Data)
        {
            DataTable dt = GetVesselFormListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {

                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    DisListOpen = dt.Rows[i]["DisListOpen"].ToString(),
                    DisListComplete = dt.Rows[i]["DisListComplete"].ToString(),
                    ImManiFestOpen = dt.Rows[i]["ImManiFestOpen"].ToString(),
                    ImManiFestComplete = dt.Rows[i]["ImManiFestComplete"].ToString(),
                    DisConfinOpen = dt.Rows[i]["DisConfinOpen"].ToString(),
                    DisConfinComplete = dt.Rows[i]["DisConfinComplete"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetVesselFormListValues(MyImVesselTask Data)
        {
            string strWhere = "";

            string _Query = " select distinct VesselName, NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID as VoyageID, (select top(1) VoyageNo from NVO_Voyage where ID =NVO_ImpBL.VoyageID) as VoyageNo, " +
                            " (select top(1) convert(varchar, ETA,103) from NVO_Voyage where ID =NVO_ImpBL.VoyageID) as ETA, " +
                            " (select Count(ID) from  Nvo_ImpBL BL where BL.VesselID =NVO_ImpBL.VesselID  and  BL.VoyageID=NVO_ImpBL.VoyageID) as BLCount, " +
                            " (select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls " +
                            " inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID =NVO_ImpBL.VesselID  and  BL.VoyageID=NVO_ImpBL.VoyageID) as CntrCount, " +
                            " 'N/A' as DisListOpen,'N/A' as DisListComplete,'N/A' as ImManiFestOpen,'N/A' as ImManiFestComplete,'N/A' as DisConfinOpen,'N/A' as DisConfinComplete, 'N/A' as Status,OfficeID " +
                            " from NVO_VesselMaster inner join NVO_ImpBL on NVO_ImpBL.VesselID=NVO_VesselMaster.ID ";





            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyImVesselTask> GetDischargeStatusList(MyImVesselTask Data)
        {
            DataTable dt = GetDischargeStatusListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    //ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    Slot = dt.Rows[i]["Slot"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetDischargeStatusListValues(MyImVesselTask Data)
        {
            string _Query = " select 'TBD' as Slot, Count(ID) as BLCount,NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID as VoyageID, " +
                "(select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls " +
                "inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID = NVO_ImpBL.VesselID  and  BL.VoyageID = NVO_ImpBL.VoyageID) CntrCount, " +
                "(select sum(TEUS) from NVO_tblCntrTypes " +
                "inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.CntrType = NVO_tblCntrTypes.ID " +
                "inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as Tues " +
                "from NVO_ImpBL where VesselID = 816 and VoyageID = 10 and NVO_ImpBL.Id not in (select BLID from NVO_ImpDischargeList) group by VoyageID,VesselID " +
                "union " +
                "select(select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperator) as Slot,Count(BLID) as BLCount, NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID as VoyageID, " +
                "Count(NVO_ImpDischargeList.CntrID) as CntrCount, " +
                "(select sum(TEUS) from NVO_tblCntrTypes " +
                "inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.CntrType = NVO_tblCntrTypes.ID " +
                "inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID " +
                "inner join NVO_ImpDischargeList on NVO_ImpDischargeList.BLID=BL.ID and NVO_ImpDischargeList.CntrID=NVO_ImpBLContainerDtls.ID " +
                "where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as Tues " +
                "from NVO_ImpDischargeList inner join NVO_ImpBL on NVO_ImpBL.Id = NVO_ImpDischargeList.BLID group by SlotOperator,VoyageID,VesselID ";


            return GetViewData(_Query, "");

        }


        public List<MyImVesselTask> GetDischargeList(MyImVesselTask Data)
        {
            DataTable dt = GetDischargeListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    //Slot = dt.Rows[i]["Slot"].ToString(),
                    CntrNO = dt.Rows[i]["CntrNO"].ToString(),
                    //BLCount = dt.Rows[i]["BLCount"].ToString(),
                    //CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["TEUS"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Orgin = dt.Rows[i]["Orgin"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    Principal = dt.Rows[i]["Principal"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetDischargeListValues(MyImVesselTask Data)
        {
            string _Query = " select NVO_ImpBL.ID,NVO_ImpBL.BLNumber,NVO_ImpBL.ID as BLID,CntrNO, NVO_ImpBLContainerDtls.ID as CntrID, " +
                "(select top(1) Size from NVO_tblCntrTypes where ID = NVO_ImpBLContainerDtls.ID) as Size, CntrType, " +
                "(select top(1) TEUS from NVO_tblCntrTypes where ID = NVO_ImpBLContainerDtls.ID) as TEUS, " +
                "(select top(1) PortName from NVO_PortMaster where ID = NVO_ImpBL.POOID) as Orgin, " +
                "(select top(1) PortName from NVO_PortMaster where ID = NVO_ImpBL.PODID) as POD, " +
                "(select top(1) PortName from NVO_PortMaster where ID = NVO_ImpBL.FPODID) as FPOD, " +
                "(select top(1) LineName from NVO_PrincipalMaster where ID = NVO_ImpBL.PrincipalID) as Principal from NVO_ImpBL " +
                "inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.BLID = NVO_ImpBL.ID where VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " ";



            return GetViewData(_Query, "");

        }


        public List<MyImVesselTask> ImpDischargeListInsert(MyImVesselTask Data)
        {
            List<MyImVesselTask> ListBL = new List<MyImVesselTask>();
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
                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ImpDischargeList where BLID=@BLID and CntrID=@CntrID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_ImpDischargeList(BLID,SlotOperator,DischargeStack,CntrID,CntrType) " +
                                        " values (@BLID,@SlotOperator,@DischargeStack,@CntrID,@CntrType) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_ImpDischargeList SET BLID=@BLID,SlotOperator=@SlotOperator,DischargeStack=@DischargeStack,CntrID=@CntrID,CntrType=@CntrType where BLID=@BLID and CntrID=@CntrID";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperator", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DischargeStack", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[4]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    ListBL.Add(new MyImVesselTask
                    {
                        AlertMessage = "Record Saved Successfully"
                    }); ;
                    return ListBL;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBL.Add(new MyImVesselTask
                    {
                        AlertMessage = ex.Message
                    }); ;
                    return ListBL;
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



        public List<MyImVesselTask> GetImportManifestStsList(MyImVesselTask Data)
        {
            DataTable dt = GetImportManifestStsValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    Slot = dt.Rows[i]["Slot"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    Gen20 = dt.Rows[i]["Gen20"].ToString(),
                    Gen40 = dt.Rows[i]["Gen40"].ToString(),
                    Haz20 = dt.Rows[i]["Haz20"].ToString(),
                    Haz40 = dt.Rows[i]["Haz40"].ToString(),
                    OOG20 = dt.Rows[i]["OOG20"].ToString(),
                    OOG40 = dt.Rows[i]["OOG40"].ToString(),
                    REF20 = dt.Rows[i]["REF20"].ToString(),
                    REF40 = dt.Rows[i]["REF40"].ToString(),
                    OT20 = dt.Rows[i]["OT20"].ToString(),
                    OT40 = dt.Rows[i]["OT40"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetImportManifestStsValues(MyImVesselTask Data)
        {


            string _Query = " select(select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperator) as Slot, " +
                "(select sum(TEUS) from NVO_tblCntrTypes inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.CntrType = NVO_tblCntrTypes.ID " +
                "inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID " +
                "inner join NVO_ImpDischargeList on NVO_ImpDischargeList.BLID=BL.ID and NVO_ImpDischargeList.CntrID=NVO_ImpBLContainerDtls.ID " +
                "where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as Tues," +
                "Count(NVO_ImpDischargeList.CntrID) as CntrCount,Count(BLID) as BLCount,0 as MT, NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =0  and EQTypeID = 279),0) as Gen20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =0  and EQTypeID = 280),0) as Gen40, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =2 and EQTypeID = 279),0) as Haz20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =2 and EQTypeID = 280),0) as Haz40, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =2 and EQTypeID = 279),0) as OOG20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =2 and EQTypeID = 280),0) as OOG40, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.RefferOpt =2 and EQTypeID = 279),0) as REF20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.RefferOpt =2 and EQTypeID = 280),0) as REF40, " +
                "0 as OT20, 0 as OT40 " +
                "from NVO_ImpDischargeList " +
                "inner join NVO_ImpBL on NVO_ImpBL.Id = NVO_ImpDischargeList.BLID group by SlotOperator,VoyageID,VesselID ";


            return GetViewData(_Query, "");

        }

        public List<MyImVesselTask> GetImportManifestStsTabList(MyImVesselTask Data)
        {
            DataTable dt = GetImportManifestStsTabValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    Slot = dt.Rows[i]["Slot"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetImportManifestStsTabValues(MyImVesselTask Data)
        {


            string _Query = " select(select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperator) as Slot, " +
                "(select sum(TEUS) from NVO_tblCntrTypes " +
                "inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.CntrType = NVO_tblCntrTypes.ID " +
                "inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID " +
                "inner join NVO_ImpDischargeList on NVO_ImpDischargeList.BLID = BL.ID and NVO_ImpDischargeList.CntrID = NVO_ImpBLContainerDtls.ID " +
                "where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as Tues, " +
                "Count(NVO_ImpDischargeList.CntrID) as CntrCount, Count(BLID) as BLCount, " +
                "NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID " +
                "from NVO_ImpDischargeList " +
                "inner join NVO_ImpBL on NVO_ImpBL.Id = NVO_ImpDischargeList.BLID group by SlotOperator,VoyageID,VesselID";


            return GetViewData(_Query, "");

        }

        public List<MyImVesselTask> GetImportManifestList(MyImVesselTask Data)
        {
            DataTable dt = GetImportManifestValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    Slot = dt.Rows[i]["Slot"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    Gen20 = dt.Rows[i]["Gen20"].ToString(),
                    Gen40 = dt.Rows[i]["Gen40"].ToString(),
                    Haz20 = dt.Rows[i]["Haz20"].ToString(),
                    Haz40 = dt.Rows[i]["Haz40"].ToString(),
                    OOG20 = dt.Rows[i]["OOG20"].ToString(),
                    OOG40 = dt.Rows[i]["OOG40"].ToString(),
                    REF20 = dt.Rows[i]["REF20"].ToString(),
                    REF40 = dt.Rows[i]["REF40"].ToString(),
                    OT20 = dt.Rows[i]["OT20"].ToString(),
                    OT40 = dt.Rows[i]["OT40"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetImportManifestValues(MyImVesselTask Data)
        {


            string _Query = " select BLNumber, (select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperator) as Slot, " +
                "(select sum(TEUS) from NVO_tblCntrTypes inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.CntrType = NVO_tblCntrTypes.ID " +
                "inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID " +
                "inner join NVO_ImpDischargeList on NVO_ImpDischargeList.BLID=BL.ID and NVO_ImpDischargeList.CntrID=NVO_ImpBLContainerDtls.ID " +
                "where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as Tues," +
                "Count(NVO_ImpDischargeList.CntrID) as CntrCount,Count(BLID) as BLCount,0 as MT, NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =0  and EQTypeID = 279),0) as Gen20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =0  and EQTypeID = 280),0) as Gen40, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =2 and EQTypeID = 279),0) as Haz20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.HazarOpt =2 and EQTypeID = 280),0) as Haz40, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =2 and EQTypeID = 279),0) as OOG20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =2 and EQTypeID = 280),0) as OOG40, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.RefferOpt =2 and EQTypeID = 279),0) as REF20, " +
                "isnull((select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType " +
                "where NVO_ImpBLContainerDtls.RefferOpt =0 and NVO_ImpBLContainerDtls.OOGOpt =0 and NVO_ImpBLContainerDtls.RefferOpt =2 and EQTypeID = 280),0) as REF40, " +
                "0 as OT20, 0 as OT40 " +
                "from NVO_ImpDischargeList " +
                "inner join NVO_ImpBL on NVO_ImpBL.Id = NVO_ImpDischargeList.BLID group by SlotOperator,VoyageID,VesselID,BLNumber ";


            return GetViewData(_Query, "");

        }

        public List<MyImVesselTask> GetImportArrivalList(MyImVesselTask Data)
        {
            DataTable dt = GetImportArrivalValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BkgNo = dt.Rows[i]["BkgNo"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    ShipperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetImportArrivalValues(MyImVesselTask Data)
        {


            string _Query = " select NVO_ImpBL.Id as ID, Shipper, BLNumber, BLNumber as  BkgNo, " +
                "NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID, " +
                "(select count(CntrNO) from NVO_ImpBLContainerDtls where BLID =NVO_ImpBL.ID)  as CntrCount, " +
                "(select sum(TEUS) from NVO_ImpBLContainerDtls " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType where BLID = NVO_ImpBL.ID ) as Tues, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.PODID) as POD, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.FPODID) as FPOD, ShipperEmail, '' as Status " +
                "from NVO_ImpBL ";


            return GetViewData(_Query, "");

        }

        public List<MyImVesselTask> GetImportDischargeCnfrmStsList(MyImVesselTask Data)
        {
            DataTable dt = GetImportDischargeCnfrmStsValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {

                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    Slot = dt.Rows[i]["Slot"].ToString(),
                    DisCntrCount = dt.Rows[i]["DisCntrCount"].ToString(),
                    DisTues = dt.Rows[i]["DisTues"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetImportDischargeCnfrmStsValues(MyImVesselTask Data)
        {


            string _Query = " select  (select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperator) as Slot, " +
                "NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID, " +
                "(select count(CntrNO) from NVO_ImpBLContainerDtls where BLID = NVO_ImpBL.ID)  as CntrCount, " +
                "(select sum(TEUS) from NVO_ImpBLContainerDtls inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType where BLID = NVO_ImpBL.ID ) as Tues, " +
                "(select count(CntrID)  from NVO_ImpDischargeConfirm where SlotOperatorID = SlotOperator) as DisCntrCount, " +
                "isnull((select sum(TEUS)  from NVO_tblCntrTypes inner join NVO_ImpDischargeList on NVO_ImpDischargeList.CntrType = NVO_tblCntrTypes.ID " +
                "inner join NVO_ImpDischargeConfirm on NVO_ImpDischargeConfirm.CntrID = NVO_ImpDischargeList.CntrID where SlotOperator = SlotOperatorID),0) as DisTues " +
                "from NVO_ImpBL " +
                "inner join NVO_ImpDischargeList on NVO_ImpDischargeList.BLID = NVO_ImpBL.ID ";


            return GetViewData(_Query, "");

        }


        public List<MyImVesselTask> GetImportDischargeCnfrmList(MyImVesselTask Data)
        {
            DataTable dt = GetImportDischargeCnfrmValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {

                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    SlotOperatorID = Int32.Parse(dt.Rows[i]["SlotOperatorID"].ToString()),
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    size = dt.Rows[i]["size"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    InventoryType = dt.Rows[i]["InventoryType"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    Principal = dt.Rows[i]["Principal"].ToString(),
                    Slot = dt.Rows[i]["Slot"].ToString(),
                    LoadStatus = dt.Rows[i]["LoadStatus"].ToString(),

                });

            }
            return VesselTaskList;
        }
        public DataTable GetImportDischargeCnfrmValues(MyImVesselTask Data)
        {


            string _Query = " select NVO_ImpBL.ID as BLID,NVO_ImpBL.BLNumber as BLNumber, " +
                "(select top(1) CID from NVO_view_CustomerDetails where CID = SlotOperator) as SlotOperatorID, " +
                "'Import' as InventoryType,CntrNo,NVO_ImpBLContainerDtls.ID as CntrID, " +
                "(select top(1) Size from NVO_ImpBLContainerDtls " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType where BLID = NVO_ImpBL.ID ) as size, " +
                "(select sum(TEUS) from NVO_ImpBLContainerDtls " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType where BLID = NVO_ImpBL.ID ) as Tues, " +
                "Case when RefferOpt = 0 and OOGOpt = 0 and HazarOpt = 0 then 'GENTER' ELSE case when RefferOpt = 2 or OOGOpt = 0 or HazarOpt = 0 " +
                "then 'Reffer' else case when RefferOpt = 0 or OOGOpt = 2 or HazarOpt = 0 then 'OOG' else " +
                "case when RefferOpt = 0 or OOGOpt = 0 or HazarOpt = 0 then 'Hazar' end end end end as CargoType, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.POOID) as POO, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.PODID) as POD, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.FPODID) as FPOD, " +
                "(select count(CntrNO) from NVO_ImpBLContainerDtls where BLID = NVO_ImpBL.ID)  as CntrCount, " +
                "'' as Principal,'' as LoadStatus, " +
                "(select top(1) CustomerName from NVO_view_CustomerDetails where CID = SlotOperator) as Slot, " +
                "NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID " +
                "from NVO_ImpBL " +
                "inner Join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.BLID = NVO_ImpBL.Id " +
                "inner join NVO_ImpDischargeList on NVO_ImpDischargeList.BLID = NVO_ImpBL.ID ";


            return GetViewData(_Query, "");

        }


        public List<MyImVesselTask> ImpDischargeConfirmInsert(MyImVesselTask Data)
        {
            List<MyImVesselTask> ListBL = new List<MyImVesselTask>();
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
                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ImpDischargeConfirm where BLID=@BLID and CntrID=@CntrID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_ImpDischargeConfirm(BLID,DischargeStatus,CntrID,SlotOperatorID) " +
                                        " values (@BLID,@DischargeStatus,@CntrID,@SlotOperatorID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_ImpDischargeConfirm SET BLID=@BLID,DischargeStatus=@DischargeStatus,CntrID=@CntrID,SlotOperatorID=@SlotOperatorID where BLID=@BLID and CntrID=@CntrID";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DischargeStatus", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperatorID", CharSplit[3]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    ListBL.Add(new MyImVesselTask
                    {
                        AlertMessage = "Record Saved Successfully"
                    }); ;
                    return ListBL;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBL.Add(new MyImVesselTask
                    {
                        AlertMessage = ex.Message
                    }); ;
                    return ListBL;
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
        #region udhaya tab values 

        public List<MyImVesselTask> GetIMVesselValues(MyImVesselTask Data)
        {
            DataTable dt = GetIMVesselValuesList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                VesselTaskList.Add(new MyImVesselTask

                {
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    ATD = dt.Rows[i]["ATD"].ToString(),


                });
            }


            return VesselTaskList;
        }

        public DataTable GetIMVesselValuesList(MyImVesselTask Data)
        {
            string _Query = " select (select top(1) VesselName from NVO_VesselMaster  where ID =Nvo_ImpBL.VesselID) as VesselName," +
                            " (select top(1) VoyageNo from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as VoyageNo," +
                            " (select top(1) convert(varchar, ETD, 106) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ETD," +
                            " (select top(1) convert(varchar, ATD, 113) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ATD" +
                            " from Nvo_ImpBL where VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " ";

            return GetViewData(_Query, "");
        }


        #endregion


        #region send maill & save 

        public List<MyImVesselTask> BindEmailViewList(MyImVesselTask Data)
        {
            DataTable dt = BindEmailViewListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VesselTaskList.Add(new MyImVesselTask
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BkgNo = dt.Rows[i]["BkgNo"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    ShipperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    EmailID = Int32.Parse(dt.Rows[i]["EmailID"].ToString()),
                });

            }
            return VesselTaskList;
        }
        public DataTable BindEmailViewListValues(MyImVesselTask Data)
        {


            string _Query = " select NVO_ImpBL.Id as ID, 0 as EmailID,Shipper, BLNumber, BLNumber as  BkgNo, " +
                "NVO_ImpBL.VesselID as VesselID,NVO_ImpBL.VoyageID as VoyageID, " +
                "(select count(CntrNO) from NVO_ImpBLContainerDtls where BLID =NVO_ImpBL.ID)  as CntrCount, " +
                "(select sum(TEUS) from NVO_ImpBLContainerDtls " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.Id = NVO_ImpBLContainerDtls.CntrType where BLID = NVO_ImpBL.ID ) as Tues, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.PODID) as POD, " +
                "(select top(1) PortName from NVO_PortMaster where Id = NVO_ImpBL.FPODID) as FPOD, ShipperEmail, " +
                "(select top(1) status  from NVO_ArrivalNotice where NVO_ArrivalNotice.BLID =NVO_ImpBL.ID) as Status " +
                "from NVO_ImpBL ";


            return GetViewData(_Query, "");

        }

        public List<MyImVesselTask> ImSaveArrivalValues(MyImVesselTask Data)
        {
            List<MyImVesselTask> ListBL = new List<MyImVesselTask>();
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
                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText =
                                        " INSERT INTO  NVO_ArrivalNotice(BLID,Status,Shipper,ArrivalSendtDate) " +
                                        " values (@BLID,@Status,@Shipper,@ArrivalSendtDate) ";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", "EmailSent"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ArrivalSendtDate", System.DateTime.Now));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    ListBL.Add(new MyImVesselTask
                    {
                        AlertMessage = "Record Saved Successfully"
                    });
                    return ListBL;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBL.Add(new MyImVesselTask
                    {
                        AlertMessage = ex.Message
                    }); ;
                    return ListBL;
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


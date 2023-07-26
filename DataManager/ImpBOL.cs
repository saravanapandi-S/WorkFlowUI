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
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace DataManager
{
    public class ImpBOL
    {

        List<MyImpBOL> ListImp = new List<MyImpBOL>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImpBOL()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion


        public List<MyImpBOL> ImportBOLView(MyImpBOL Data)
        {
            List<MyImpBOL> ListImp = new List<MyImpBOL>();
            DataTable dt = GetImportBOLView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImp.Add(new MyImpBOL
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BOLUpdateOpen = dt.Rows[i]["BOLUpdateOpen"].ToString(),
                    BOLUpdateComplete = dt.Rows[i]["BOLUpdateComplete"].ToString(),
                    FreeDayOpen = dt.Rows[i]["FreeDayOpen"].ToString(),
                    FreeDayComplete = dt.Rows[i]["FreeDayComplete"].ToString(),
                    FreManifestOpen = dt.Rows[i]["FreManifestOpen"].ToString(),
                    FreManifestComplete = dt.Rows[i]["FreManifestComplete"].ToString(),
                    ArrivalOpen = dt.Rows[i]["ArrivalOpen"].ToString(),
                    ArrivalComplete = dt.Rows[i]["ArrivalComplete"].ToString(),
                    DOReleaseOpen = dt.Rows[i]["DOReleaseOpen"].ToString(),
                    DOReleaseComplete = dt.Rows[i]["DOReleaseComplete"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });
            }
            return ListImp;
        }
        public DataTable GetImportBOLView(MyImpBOL Data)


        {
            string strWhere = "";

            string _Query = " select distinct VesselName, NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID as VoyageID, " +
                            " (select top(1) VoyageNo from NVO_Voyage where ID = NVO_ImpBL.VoyageID) as VoyageNo," +
                            " (select top(1) convert(varchar, ETA, 103) from NVO_Voyage where ID = NVO_ImpBL.VoyageID) as ETA," +
                            " (select Count(ID) from Nvo_ImpBL BL where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as BLCount," +
                            " (select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls" +
                            " inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as CntrCount," +
                            " 'NA' as BOLUpdateOpen,'NA' as BOLUpdateComplete, 'NA' as FreeDayOpen, 'NA' as FreeDayComplete, 'NA' as FreManifestOpen, 'NA' as FreManifestComplete, " +
                            " 'NA' as ArrivalOpen, 'NA' as ArrivalComplete, 'NA' as DOReleaseOpen, 'NA' as DOReleaseComplete, 'NA' as Status " +
                            "  from NVO_VesselMaster inner join NVO_ImpBL on NVO_ImpBL.VesselID = NVO_VesselMaster.ID ";

            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where NVO_VesselMaster.VesselName like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and NVO_VesselMaster.VesselName '%" + Data.SearchValue.ToString().Trim() + "%'";

            }


            if (Data.SearchID == 2)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where (select top(1) VoyageNo from NVO_Voyage where ID = NVO_ImpBL.VoyageID) like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (select top(1) VoyageNo from NVO_Voyage where ID = NVO_ImpBL.VoyageID) '%" + Data.SearchValue.ToString().Trim() + "%'";

            }

            if (Data.SearchID == 3)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where NVO_ImpBL.BLNumber like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and NVO_ImpBL.BLNumber '%" + Data.SearchValue.ToString().Trim() + "%'";

            }


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }



        public List<MyImpBOL> ImportBOLVsDisplay(MyImpBOL Data)
        {
            List<MyImpBOL> ListImp = new List<MyImpBOL>();
            DataTable dt = GetImportBOLVsDisplay(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImp.Add(new MyImpBOL
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BOLUpdateOpen = dt.Rows[i]["BOLUpdateOpen"].ToString(),
                    BOLUpdateComplete = dt.Rows[i]["BOLUpdateComplete"].ToString(),
                    FreeDayOpen = dt.Rows[i]["FreeDayOpen"].ToString(),
                    FreeDayComplete = dt.Rows[i]["FreeDayComplete"].ToString(),
                    FreManifestOpen = dt.Rows[i]["FreManifestOpen"].ToString(),
                    FreManifestComplete = dt.Rows[i]["FreManifestComplete"].ToString(),
                    ArrivalOpen = dt.Rows[i]["ArrivalOpen"].ToString(),
                    ArrivalComplete = dt.Rows[i]["ArrivalComplete"].ToString(),
                    DOReleaseOpen = dt.Rows[i]["DOReleaseOpen"].ToString(),
                    DOReleaseComplete = dt.Rows[i]["DOReleaseComplete"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });
            }
            return ListImp;
        }
        public DataTable GetImportBOLVsDisplay(MyImpBOL Data)


        {
            string strWhere = "";

            string _Query = " select distinct VesselName, NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID as VoyageID , (select top(1) VoyageNo from NVO_Voyage where ID = NVO_ImpBL.VoyageID) as VoyageNo," +
                            " (select top(1) convert(varchar, ETA, 103) from NVO_Voyage where ID = NVO_ImpBL.VoyageID) as ETA," +
                            " (select Count(ID) from Nvo_ImpBL BL where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as BLCount," +
                            " (select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls" +
                            " inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as CntrCount," +
                            " 'NA' as BOLUpdateOpen,'NA' as BOLUpdateComplete, 'NA' as FreeDayOpen, 'NA' as FreeDayComplete, 'NA' as FreManifestOpen, 'NA' as FreManifestComplete, " +
                            " 'NA' as ArrivalOpen, 'NA' as ArrivalComplete, 'NA' as DOReleaseOpen, 'NA' as DOReleaseComplete, 'NA' as Status " +
                            "  from NVO_VesselMaster inner join NVO_ImpBL on NVO_ImpBL.VesselID = NVO_VesselMaster.ID ";

            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where NVO_VesselMaster.VesselName like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and NVO_VesselMaster.VesselName '%" + Data.SearchValue.ToString().Trim() + "%'";

            }


            //if (Data.SearchID == 2)
            //{
            //    if (Data.SearchValue != "")
            //        if (strWhere == "")
            //            strWhere += _Query + " where (select top(1) VoyageNo from NVO_Voyage where ID = NVO_ImpBL.VoyageID) like '%" + Data.SearchValue.ToString().Trim() + "%'";
            //        else
            //            strWhere += " and (select top(1) VoyageNo from NVO_Voyage where ID = NVO_ImpBL.VoyageID) '%" + Data.SearchValue.ToString().Trim() + "%'";

            //}

            //if (Data.SearchID == 3)
            //{
            //    if (Data.SearchValue != "")
            //        if (strWhere == "")
            //            strWhere += _Query + " where NVO_ImpBL.BLNumber like '%" + Data.SearchValue.ToString().Trim() + "%'";
            //        else
            //            strWhere += " and NVO_ImpBL.BLNumber '%" + Data.SearchValue.ToString().Trim() + "%'";

            //}


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }


        public List<MyImpBOL> ImportBOLStatusView(MyImpBOL Data)
        {
            List<MyImpBOL> ListImp = new List<MyImpBOL>();
            DataTable dt = GetImportBOLStatusView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImp.Add(new MyImpBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    POOName = dt.Rows[i]["POOName"].ToString(),
                    POLAgent = dt.Rows[i]["POLAgent"].ToString(),
                    Principal = dt.Rows[i]["Principal"].ToString(),
                    DOStatus = dt.Rows[i]["DOStatus"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),

                });
            }
            return ListImp;
        }
        public DataTable GetImportBOLStatusView(MyImpBOL Data)
        {
            string strWhere = "";
            string _Query = " select ID, VesselID, VoyageID, BLNumber, Consignee, " +
                " ISNULL((select top(1) VesselName from NVO_VesselMaster where ID = Nvo_ImpBL.VesselID), 'NA') as VesselName, " +
                " ISNULL((select top(1) VoyageNo from NVO_Voyage where ID = Nvo_ImpBL.VoyageID), 'NA') as VoyageName, " +
                " ISNULL(convert(varchar, (select TOP 1 ETA from NVO_Voyage where ID = Nvo_ImpBL.VoyageID), 105), 'NA') as ETA, " +
                " ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.POLID), 'NA') as POLName, " +
                " ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.PODID), 'NA') as PODName, " +
                " ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.FPODID), 'NA') as FPODName, " +
                " ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.POOID), 'NA') as POOName, " +
                " ISNULL((select top(1) AgencyName from NVO_AgencyMaster where ID = Nvo_ImpBL.POLAgentID), 'NA') as POLAgent, " +
                " ISNULL((select top(1) LineName from NVO_PrincipalMaster where ID = Nvo_ImpBL.PrincipalID), 'NA') as Principal, " +
                " (select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls " +
                " inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID =NVO_ImpBL.VesselID  and  BL.VoyageID=NVO_ImpBL.VoyageID) as CntrCount, " +
                " 'NA' as DOStatus " +
                "from Nvo_ImpBL";


            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where NVO_ImpBL.BLNumber like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and NVO_ImpBL.BLNumber '%" + Data.SearchValue.ToString().Trim() + "%'";

            }



            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyImpBOL> ImportBOLSearchView(MyImpBOL Data)
        {
            List<MyImpBOL> ListImp = new List<MyImpBOL>();
            DataTable dt = GetImportBOLSearchView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImp.Add(new MyImpBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    POLAgent = dt.Rows[i]["POLAgent"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),

                });
            }
            return ListImp;
        }
        public DataTable GetImportBOLSearchView(MyImpBOL Data)


        {
            string strWhere = "";

            string _Query = " select ID, VesselID, VoyageID, BLNumber, Consignee, " +
                "ISNULL((select top(1) VesselName from NVO_VesselMaster where ID = Nvo_ImpBL.VesselID), 'NA') as VesselName, " +
                "ISNULL((select top(1) VoyageNo from NVO_Voyage where ID = Nvo_ImpBL.VoyageID), 'NA') as VoyageName, " +
                "ISNULL(convert(varchar, (select TOP 1 ETA from NVO_Voyage where ID = Nvo_ImpBL.VoyageID), 105), 'NA') as ETA, " +
                "ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.POLID), 'NA') as POLName, " +
                "ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.FPODID), 'NA') as FPODName, " +
                "ISNULL((select top(1) AgencyName from NVO_AgencyMaster where ID = Nvo_ImpBL.POLAgentID), 'NA') as POLAgent,OfficeID, " +
                " (select top 1 count(CntrNO) from NVO_ImpBLContainerDtls where NVO_ImpBLContainerDtls.BLID = Nvo_ImpBL.ID)as CntrCount " +
                "from Nvo_ImpBL";



            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where Nvo_ImpBL.OfficeID = " + Data.OfficeID + "";
                else
                    strWhere += " and Nvo_ImpBL.OfficeID = " + Data.OfficeID + "";

            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where Nvo_ImpBL.BLNumber like '%" + Data.BLNumber + "%'";
                else
                    strWhere += " and Nvo_ImpBL.BLNumber like '%" + Data.BLNumber + "%'";


            if (Data.POLID.ToString() != "" && Data.POLID.ToString() != "0" && Data.POLID.ToString() != null && Data.POLID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Nvo_ImpBL.POLID = " + Data.POLID.ToString();
                else
                    strWhere += " and Nvo_ImpBL.POLID = " + Data.POLID.ToString();


            if (Data.FPODID.ToString() != "" && Data.FPODID.ToString() != "0" && Data.FPODID.ToString() != null && Data.FPODID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Nvo_ImpBL.FPODID = " + Data.FPODID.ToString();
                else
                    strWhere += " and Nvo_ImpBL.FPODID = " + Data.FPODID.ToString();


            if (Data.POLAgentID.ToString() != "" && Data.POLAgentID.ToString() != "0" && Data.POLAgentID.ToString() != null && Data.POLAgentID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Nvo_ImpBL.POLAgentID = " + Data.POLAgentID.ToString();
                else
                    strWhere += " and Nvo_ImpBL.POLAgentID = " + Data.POLAgentID.ToString();

            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE Nvo_ImpBL.VoyageID =" + Data.VoyageID + "";
                else
                    strWhere += " and Nvo_ImpBL.VoyageID =" + Data.VoyageID + "";

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



            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere, "");
        }


        public List<MyImpBOL> ImportBOLContainerView(MyImpBOL Data)
        {
            List<MyImpBOL> ListImp = new List<MyImpBOL>();
            DataTable dt = GetImportBOLContainerView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImp.Add(new MyImpBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    Principal = dt.Rows[i]["Principal"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    CntrSize = dt.Rows[i]["CntrSize"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),

                });
            }
            return ListImp;
        }
        public DataTable GetImportBOLContainerView(MyImpBOL Data)
        {
            string _Query = " select Nvo_ImpBL.ID, VesselID, VoyageID, Nvo_ImpBL.BLNumber, ISNULL((select top(1) LineName from NVO_PrincipalMaster where ID = Nvo_ImpBL.PrincipalID), 'NA') as Principal," +
                            " ISNULL((select top(1) PortName from NVO_PortMaster where ID = Nvo_ImpBL.FPODID), 'NA') as FPODName, CntrNo," +
                            " (select top(1) Type from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_ImpBLContainerDtls.CntrType) as CntrType, " +
                            " (select top(1) Size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_ImpBLContainerDtls.CntrType) as CntrSize " +
                            " from Nvo_ImpBL " +
                            " inner join NVO_ImpBLContainerDtls  on NVO_ImpBLContainerDtls.BLID=Nvo_ImpBL.ID " +
                            " where Nvo_ImpBL.ID=" + Data.BLID;

            return GetViewData(_Query, "");
        }




        public List<MyImpBOL> InsertImpDeliveryDetailsValues(MyImpBOL Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_tblCntrTypes where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_tblCntrTypes(Size,Type,ISOCode,SizeID,EQTypeID,Height,Length,Width,TareWeight,MaxPayload,TEUS,REMARKS) " +
                                     " values (@Size,@Type,@ISOCode,@SizeID,@EQTypeID,@Height,@Length,@Width,@TareWeight,@MaxPayload,@TEUS,@REMARKS) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_tblCntrTypes SET Size=@Size,Type=@Type,ISOCode=@ISOCode,SizeID=@SizeID,EQTypeID=@EQTypeID,Height=@Height,Length=@Length,Width=@Width,TareWeight=@TareWeight,MaxPayload=@MaxPayload,TEUS=@TEUS,REMARKS=@REMARKS where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_tblCntrTypes')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListImp.Add(new MyImpBOL
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListImp;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListImp.Add(new MyImpBOL
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListImp;
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

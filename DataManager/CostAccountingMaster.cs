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
using Org.BouncyCastle.Asn1.X509;

namespace DataManager
{
    public class CostAccountingMaster
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CostAccountingMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        List<myCostAccounting> ListCostAccounting = new List<myCostAccounting>();

        public List<myCostAccounting> IMCostAccountingListView(myCostAccounting Data)
        {
            DataTable dt = GetIMCostAccountingListViewtValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCostAccounting.Add(new myCostAccounting
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    PortTermail = dt.Rows[i]["PortTermail"].ToString(),
                    Discharged = dt.Rows[i]["Discharged"].ToString(),
                    BlCount = dt.Rows[i]["BlCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    CostBookedBOL = dt.Rows[i]["CostBookedBOL"].ToString(),
                    CostBookedContr = dt.Rows[i]["CostBookedContr"].ToString(),
                    CostBookedInvoice = dt.Rows[i]["CostBookedInvoice"].ToString(),
                    CostBookingPendingBOl = dt.Rows[i]["CostBookingPendingBOl"].ToString(),
                    CostBookingPendingContr = dt.Rows[i]["CostBookingPendingContr"].ToString(),

                });

            }
            return ListCostAccounting;
        }
        public DataTable GetIMCostAccountingListViewtValues(myCostAccounting Data)
        {
            string strWhere = "";

            string _Query = " select distinct VesselName, NVO_ImpBL.VesselID as VesselID, NVO_ImpBL.VoyageID," +
                            " (select top(1) VoyageNo from NVO_Voyage where ID =NVO_ImpBL.VoyageID) as VoyageNo," +
                            " (select Count(ID) from Nvo_ImpBL BL where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as BlCount," +
                            " (select Count(NVO_ImpBLContainerDtls.ID) from NVO_ImpBLContainerDtls inner join NVO_ImpBL BL on BL.Id = NVO_ImpBLContainerDtls.BLID where BL.VesselID = NVO_ImpBL.VesselID  and BL.VoyageID = NVO_ImpBL.VoyageID) as CntrCount, " +
                            " '0' as PortTermail,'0' as Discharged," +
                            " '0' as CostBookedBOL,'0' as CostBookedContr, '0' as CostBookedInvoice," +
                            " '0' as CostBookingPendingBOl , '0' as CostBookingPendingContr" +
                            " from NVO_VesselMaster inner join NVO_ImpBL on NVO_ImpBL.VesselID=NVO_VesselMaster.ID ";



            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and NVO_VesselMaster.VesselName like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and NVO_VesselMaster.VesselName like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 2)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and (select top(1) VoyageNo from NVO_Voyage where ID =NVO_ImpBL.VoyageID) like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (select top(1) VoyageNo from NVO_Voyage where ID =NVO_ImpBL.VoyageID) like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }




            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<myCostAccounting> EXportCostAccountingListView(myCostAccounting Data)
        {
            DataTable dt = GetEXportCostAccountingListViewValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCostAccounting.Add(new myCostAccounting
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VessleName = dt.Rows[i]["VessleName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    PortTermail = dt.Rows[i]["PortTermail"].ToString(),
                    Discharged = dt.Rows[i]["Discharged"].ToString(),
                    BlCount = dt.Rows[i]["BlCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    CostBookedBOL = dt.Rows[i]["CostBookedBOL"].ToString(),
                    CostBookedContr = dt.Rows[i]["CostBookedContr"].ToString(),
                    CostBookedInvoice = dt.Rows[i]["CostBookedInvoice"].ToString(),
                    CostBookingPendingBOl = dt.Rows[i]["CostBookingPendingBOl"].ToString(),
                    CostBookingPendingContr = dt.Rows[i]["CostBookingPendingContr"].ToString(),

                });

            }
            return ListCostAccounting;
        }
        public DataTable GetEXportCostAccountingListViewValues(myCostAccounting Data)
        {
            string strWhere = "";

            string _Query = " select distinct VesselID,VoyageID,VessleName,VoyageName,BLCount,CntrCount," +
                            " '0' as PortTermail,'0' as Discharged,'0' as CostBookedBOL,'0' as CostBookedContr," +
                            " '0' as CostBookedInvoice,'0' as CostBookingPendingBOl , '0' as CostBookingPendingContr " +
                            " from NVO_View_VesselTaskBookingCount VsCount ";



            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where VessleName like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and VessleName like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 2)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where VoyageName like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and VoyageName like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }




            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " group by VesselID,VoyageID,VessleName,VoyageName,BLCount,CntrCount ", "");

        }



        public List<myCostAccounting> IMCostAccountingDrillDownListView(myCostAccounting Data)
        {
            DataTable dt = GetIMCostAccountingDrillDownListView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCostAccounting.Add(new myCostAccounting
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    PortTermail = dt.Rows[i]["PortTermail"].ToString(),
                    Discharged = dt.Rows[i]["Discharged"].ToString(),
                    cntrno = dt.Rows[i]["cntrno"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrTypeandSize = dt.Rows[i]["CntrTypeandSize"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    Vendor = dt.Rows[i]["Vendor"].ToString(),
                    ChargeHead = dt.Rows[i]["ChargeHead"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                });

            }
            return ListCostAccounting;
        }
        public DataTable GetIMCostAccountingDrillDownListView(myCostAccounting Data)
        {
            string strWhere = "";

            string _Query = " select distinct vesselID,voyageID,Nvo_ImpBL.BLNumber,(select top 1 VesselName from NVO_VesselMaster where NVO_VesselMaster.ID=Nvo_ImpBL.VesselID) as VesselName," +
                            " (select top 1 VoyageNo from NVO_Voyage where NVO_Voyage.ID=Nvo_ImpBL.VoyageID) as VoyageNo, " +
                            " cntrno, " +
                            " (select size +'-'+Type from NVO_tblCntrTypes where NVO_tblCntrTypes.ID= NVO_ImpBLContainerDtls.CntrType) as CntrTypeandSize,'0' as PortTermail," +
                            " '0' as Discharged,'0' as CargoType,'0' as Vendor, '0' as ChargeHead,'0' as Amount," +
                            " '0' as Currency from Nvo_ImpBL inner join NVO_ImpBLContainerDtls on NVO_ImpBLContainerDtls.BLID =Nvo_ImpBL.ID " +
                            " where VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " " ;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<myCostAccounting> ExportCostAccountingDrillDownList(myCostAccounting Data)
        {
            DataTable dt = ExportCostAccountingDrillDownListView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCostAccounting.Add(new myCostAccounting
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VessleName = dt.Rows[i]["VessleName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    PortTermail = dt.Rows[i]["PortTermail"].ToString(),
                    Discharged = dt.Rows[i]["Discharged"].ToString(),
                    CntrNumber = dt.Rows[i]["CntrNumber"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrTypeandSize = dt.Rows[i]["CntrTypeandSize"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    Vendor = dt.Rows[i]["Vendor"].ToString(),
                    ChargeHead = dt.Rows[i]["ChargeHead"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),

                });

            }
            return ListCostAccounting;
        }
        public DataTable ExportCostAccountingDrillDownListView(myCostAccounting Data)
        {
            string strWhere = "";

            string _Query = " select VesselID,VoyageID,VessleName,VoyageName,'0' as CntrNumber,'0' as PortTermail,'0' as Discharged,'0' as CntrTypeandSize,'0' as CargoType,'0' as Vendor, '0' as ChargeHead," +
                            " '0' as Amount, '0' as Currency,'0' as BLNumber from NVO_View_VesselTaskBookingCount VsCount " +
                             " where VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";




            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " group by VesselID,VoyageID,VessleName,VoyageName", "");

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

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
   public class DashboardManager
    {
        List<MyDashboarData> ListDashboard = new List<MyDashboarData>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public DashboardManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        
        public List<MyDashboarData> GeoLocationDtls(MyDashboarData Data)
        {
            List<MyDashboarData> ViewList = new List<MyDashboarData>();
            DataTable dt = GetGeoLocation(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyDashboarData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString(),
                 
                });
            }
            return ViewList;
        }
        public DataTable GetGeoLocation(MyDashboarData Data)
        {
            string _Query = "select ID,GeoLocation from NVO_GeoLocations";
            return GetViewData(_Query, "");
        }

        #region Inventory Dashboard

        public List<MyDashboarData> DashboardInventoryCount(MyDashboarData Data)
        {
            List<MyDashboarData> ViewList = new List<MyDashboarData>();
            DataTable dt = GetDashboardInventoryCount(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyDashboarData
                {
                    
                    MAStatus = dt.Rows[i]["MAStatus"].ToString(),
                    FVStatus = dt.Rows[i]["FVStatus"].ToString(),
                    DLStatus = dt.Rows[i]["DLStatus"].ToString(),
                    AVStatus = dt.Rows[i]["AVStatus"].ToString(),
                    FLStatus = dt.Rows[i]["FLStatus"].ToString(),
                    MSStatus = dt.Rows[i]["MSStatus"].ToString(),
                    FIStatus = dt.Rows[i]["FIStatus"].ToString(),


                });
            }
            return ViewList;
        }
        public DataTable GetDashboardInventoryCount(MyDashboarData Data)
        {
            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != null && Data.AgencyID.ToString() != "?")
            {
                string _Query = "select  distinct (select COUNT (distinct ID) from NVO_Containers WHERE StatusCode='MA' AND AgencyID =" + Data.AgencyID + ")  as  MAStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'FV' AND AgencyID = " + Data.AgencyID+ ") as FVStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'DL' AND AgencyID = " + Data.AgencyID + ") as DLStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'AV' AND AgencyID = " + Data.AgencyID + ") as AVStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'FL' AND AgencyID = " + Data.AgencyID + ") as FLStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'MS' AND AgencyID = " + Data.AgencyID + ") as MSStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'FI' AND AgencyID = " + Data.AgencyID + ") as FIStatus FROM NVO_Containers";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = "select  distinct (select COUNT (distinct ID ) from NVO_Containers WHERE StatusCode='MA' )  as MAStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'FV' ) as FVStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'DL' ) as DLStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'AV' ) as AVStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'FL' ) as FLStatus,(select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'MS' ) as MSStatus, (select COUNT(distinct ID) from NVO_Containers WHERE StatusCode = 'FI') as FIStatus FROM NVO_Containers ";
                return GetViewData(_Query, "");
            }
            
        }

        public List<MyDashboarData> AgencyWiseBL(MyDashboarData Data)
        {
            List<MyDashboarData> ViewList = new List<MyDashboarData>();
            DataTable dt = GetAgencyWiseBL(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyDashboarData
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString(),
                 

                });
            }
            return ViewList;
        }
        public DataTable GetAgencyWiseBL(MyDashboarData Data)
        {
           
                string _Query = "select  * from NVO_Booking Where AgentID="+Data.AgencyID;
                return GetViewData(_Query, "");
            
           

        }

        public List<MyDashboarData> DashboardInventorySearch(MyDashboarData Data)
        {
            List<MyDashboarData> ViewList = new List<MyDashboarData>();
            DataTable dt = GetDashboardInventorySearch(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ViewList.Add(new MyDashboarData
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    Transitmode = dt.Rows[i]["Transitmode"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    Customer = dt.Rows[i]["Customer"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    VesVoy = dt.Rows[i]["VESVOY"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetDashboardInventorySearch(MyDashboarData Data)
        {
            string _Query = "select Distinct NVO_Containers.ID,CntrNo,NVO_Containers.StatusCode,(select top 1(TYPE + '-' + SIZE) as TypeSize  from NVO_tblCntrTypes Where ID = TypeID) As Size, isnull((select top 1 PortName  from NVO_PortMaster Where ID = NVO_Containers.CurrentPortID ) ,'') As Location, "+
     " isnull((select top 1 generalname  from NVO_GeneralMaster Where ID = NVO_Containers.ModeOfTransportID) ,'') As Transitmode,  isnull((select top 1 DepName  from NVO_DepotMaster Where ID = NVO_Containers.DepotID ) ,'') As Depot, "+
    "   isnull((select top 1 CustomerName  from NVO_CustomerMaster Where ID = NVO_Containers.CustomerID ) ,'') As Customer,  isnull((select top 1 BookingNo  from NVO_Booking inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.id  Where NVO_Booking.ID = NVO_ContainerTxns.BLNumber ) ,'') As BLNumber, "+
     " isnull((Select top 1(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V "+
" Inner JOIN NVO_ContainerTxns ON NVO_ContainerTxns.VesVoyID = V.ID where ContainerID = NVO_Containers.ID  Order by DtMovement desc),'')  As VESVOY from NVO_Containers WHERE NVO_Containers.StatusCode in ('MA', 'FV', 'DL', 'AV', 'FI', 'FL', 'MS') ";
            //" LEFT OUTER JOIN NVO_GeneralMaster GM ON GM.id = CN.StatusID AND GM.SeqNo = 14 ";

            string strWhere = "";

           

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != null && Data.AgencyID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and  NVO_Containers.AgencyID=" + Data.AgencyID.ToString();
                else
                    strWhere += " and  NVO_Containers.AgencyID =" + Data.AgencyID.ToString();

            //if (Data.BLNumber != "" && Data.BLNumber != "0" && Data.BLNumber != null && Data.BLNumber != "?")
            //    if (strWhere == "")
            //        strWhere += _Query + " Where CN.BoxOwnerID=" + Data.BoxOwnerID.ToString();
            //    else
            //        strWhere += " and CN.BoxOwnerID =" + Data.BoxOwnerID.ToString();

            //if (Data.VesVoy != "" && Data.VesVoy != "0" && Data.VesVoy != null && Data.VesVoy != "?")
            //    if (strWhere == "")
            //        strWhere += _Query + " Where NVO_Containers.VesVoyID=" + Data.VesVoy.ToString();
            //    else
            //        strWhere += " and NVO_Containers.VesVoyID =" + Data.VesVoy.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


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
    }
}

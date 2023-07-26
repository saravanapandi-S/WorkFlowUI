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
    public class InventoryManger
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public InventoryManger()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        List<MyInventory> ListInventory = new List<MyInventory>();

        public List<MyInventory> GetEmtyCntrStatusViewlistr(MyInventory Data)
        {
            DataTable dt = GetEmtyCntrStatusViewlistrValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListInventory.Add(new MyInventory
                {

                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    AV20 = dt.Rows[i]["AV20"].ToString(),
                    AV40 = dt.Rows[i]["AV40"].ToString(),
                    DL20 = dt.Rows[i]["DL20"].ToString(),
                    DL40 = dt.Rows[i]["DL40"].ToString(),
                    UR20 = dt.Rows[i]["UR20"].ToString(),
                    UR40 = dt.Rows[i]["UR40"].ToString(),
                    Total20 = dt.Rows[i]["Total20"].ToString(),
                    Total40 = dt.Rows[i]["Total40"].ToString(),
                    CROT20 = dt.Rows[i]["CROT20"].ToString(),
                    CROT40 = dt.Rows[i]["CROT40"].ToString(),
                });

            }
            return ListInventory;
        }
        public DataTable GetEmtyCntrStatusViewlistrValues(MyInventory Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_View_EmptyCntrStatus ";

            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != "null" && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OfficeID=" + Data.OfficeID.ToString();
                else
                    strWhere += " and OfficeID =" + Data.OfficeID.ToString();

            //if (Data.PrincipleID.ToString() != "" && Data.PrincipleID.ToString() != "0" && Data.PrincipleID.ToString() != "null" && Data.PrincipleID.ToString() != "?")
            //    if (strWhere == "")
            //        strWhere += _Query + " Where PrincipleID=" + Data.PrincipleID.ToString();
            //    else
            //        strWhere += " and PrincipleID =" + Data.PrincipleID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyInventory> GetEmtyIdlingViewlist(MyInventory Data)
        {
            DataTable dt = GetEmtyIdlingViewlistValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListInventory.Add(new MyInventory
                {

                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    ID20GB = dt.Rows[i]["ID20GB"].ToString(),
                    ID40HC = dt.Rows[i]["ID40HC"].ToString(),
                    ID20RF = dt.Rows[i]["ID20RF"].ToString(),
                    ID40RF = dt.Rows[i]["ID40RF"].ToString(),
                    ID20OT = dt.Rows[i]["ID20OT"].ToString(),
                    ID40OT = dt.Rows[i]["ID40OT"].ToString(),
                    ID20FR = dt.Rows[i]["ID20FR"].ToString(),
                    ID40FR = dt.Rows[i]["ID40FR"].ToString(),
                    IDTotal = dt.Rows[i]["IDTotal"].ToString(),
                    Others = dt.Rows[i]["Others"].ToString(),
                    Day1yo10 = dt.Rows[i]["Day1yo10"].ToString(),
                    Day11to20 = dt.Rows[i]["Day11to20"].ToString(),
                    Day21to30 = dt.Rows[i]["Day21to30"].ToString(),
                    Day31to60 = dt.Rows[i]["Day31to60"].ToString(),
                    Day60 = dt.Rows[i]["Day60"].ToString(),
                    DaysTotal = dt.Rows[i]["DaysTotal"].ToString(),
                });

            }
            return ListInventory;
        }
        public DataTable GetEmtyIdlingViewlistValues(MyInventory Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_View_EmptyIdling ";

            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OfficeID=" + Data.OfficeID.ToString();
                else
                    strWhere += " and OfficeID =" + Data.OfficeID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public List<MyInventory> GetContainerStockViewlist(MyInventory Data)
        {
            DataTable dt = GetContainerStockViewlistValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListInventory.Add(new MyInventory
                {

                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    DC20 = dt.Rows[i]["DC20"].ToString(),
                    DC40 = dt.Rows[i]["DC40"].ToString(),
                    WC20 = dt.Rows[i]["WC20"].ToString(),
                    WC40 = dt.Rows[i]["WC40"].ToString(),
                    EM20 = dt.Rows[i]["EM20"].ToString(),
                    EM40 = dt.Rows[i]["EM40"].ToString(),
                    WE20 = dt.Rows[i]["WE20"].ToString(),
                    WE40 = dt.Rows[i]["WE40"].ToString(),
                    RFL20 = dt.Rows[i]["RFL20"].ToString(),
                    RFL40 = dt.Rows[i]["RFL40"].ToString(),
                    TotalCS20 = dt.Rows[i]["TotalCS20"].ToString(),
                    TotalCS40 = dt.Rows[i]["TotalCS40"].ToString(),


                });

            }
            return ListInventory;
        }
        public DataTable GetContainerStockViewlistValues(MyInventory Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_View_ContainerStock ";


            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OfficeID=" + Data.OfficeID.ToString();
                else
                    strWhere += " and OfficeID =" + Data.OfficeID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyInventory> GetViewLongIdlingWithConsigViewlist(MyInventory Data)
        {
            DataTable dt = GetViewLongIdlingWithConsigViewlistValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListInventory.Add(new MyInventory
                {

                    Principal = dt.Rows[i]["Principal"].ToString(),
                    IDC20GB = dt.Rows[i]["IDC20GB"].ToString(),
                    IDC40HC = dt.Rows[i]["IDC40HC"].ToString(),
                    IDC20RF = dt.Rows[i]["IDC20RF"].ToString(),
                    IDC40RF = dt.Rows[i]["IDC40RF"].ToString(),
                    IDC20OT = dt.Rows[i]["IDC20OT"].ToString(),
                    IDC40OT = dt.Rows[i]["IDC40OT"].ToString(),
                    IDC20FR = dt.Rows[i]["IDC20FR"].ToString(),
                    IDC40FR = dt.Rows[i]["IDC40FR"].ToString(),
                    LICother = dt.Rows[i]["LICother"].ToString(),
                    LICTotal = dt.Rows[i]["LICTotal"].ToString(),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),

                });

            }
            return ListInventory;
        }
        public DataTable GetViewLongIdlingWithConsigViewlistValues(MyInventory Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_View_LongIdling ";


            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and OfficeID=" + Data.OfficeID.ToString();
                else
                    strWhere += " and OfficeID =" + Data.OfficeID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyInventory> GetViewLongIdlingWithShipper(MyInventory Data)
        {
            DataTable dt = GetViewLongIdlingWithShipperValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListInventory.Add(new MyInventory
                {

                    Principal = dt.Rows[i]["Principal"].ToString(),
                    IDS20GB = dt.Rows[i]["IDS20GB"].ToString(),
                    IDS40HC = dt.Rows[i]["IDS40HC"].ToString(),
                    IDS20RF = dt.Rows[i]["IDS20RF"].ToString(),
                    IDS40RF = dt.Rows[i]["IDS40RF"].ToString(),
                    IDS20OT = dt.Rows[i]["IDS20OT"].ToString(),
                    IDS40OT = dt.Rows[i]["IDS40OT"].ToString(),
                    IDS20FR = dt.Rows[i]["IDS20FR"].ToString(),
                    IDS40FR = dt.Rows[i]["IDS40FR"].ToString(),
                    LIWSother = dt.Rows[i]["LIWSother"].ToString(),
                    LIWSTotal = dt.Rows[i]["LIWSTotal"].ToString(),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),

                });

            }
            return ListInventory;
        }
        public DataTable GetViewLongIdlingWithShipperValues(MyInventory Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_View_LongIdlingWithShipper  ";


            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and OfficeID=" + Data.OfficeID.ToString();
                else
                    strWhere += " and OfficeID =" + Data.OfficeID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyInventory> GetMixUpCntrStatusViewlist(MyInventory Data)
        {
            DataTable dt = GetMixUpCntrStatusViewlistValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListInventory.Add(new MyInventory
                {

                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    statuscode = dt.Rows[i]["statuscode"].ToString(),
                    OwnLinePrincipal = dt.Rows[i]["OwnLinePrincipal"].ToString(),
                    OperatingLinePrincipal = dt.Rows[i]["OperatingLinePrincipal"].ToString(),
                    StorageLocation = dt.Rows[i]["StorageLocation"].ToString(),
                    CntrSize = dt.Rows[i]["CntrSize"].ToString(),

                });

            }
            return ListInventory;
        }
        public DataTable GetMixUpCntrStatusViewlistValues(MyInventory Data)
        {
            string strWhere = "";

            string _Query = " select * from NVO_View_MixupContainersStatus ";

            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OfficeID=" + Data.OfficeID.ToString();
                else
                    strWhere += " and OfficeID =" + Data.OfficeID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

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

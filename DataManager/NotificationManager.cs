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
using System.Net;
using System.Net.Mail;

namespace DataManager
{
    public class NotificationManager
    {
        List<MyNotification> ListV = new List<MyNotification>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public NotificationManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion


        public List<MyNotification> ExemptionNotificationRecordView(MyNotification Data)
        {
            List<MyNotification> ViewList = new List<MyNotification>();
            DataTable dt = GetExemptNotificationView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyNotification
                {
                    ID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentTypes"].ToString(),
                    CustomerName = dt.Rows[i]["BkgParty"].ToString(),
                    PODStr = dt.Rows[i]["POD"].ToString(),
                    POLStr = dt.Rows[i]["POL"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetExemptNotificationView(MyNotification Data)
        {
            string strWhere = "";
            string _Query = " select BLNumber,BkgID,case when NVO_BOL.ShipmentTypeID= 1 then 'Export' else 'Import' end as ShipmentTypes,BkgParty, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = NVO_BOL.POLID) as POL,NVO_BOL.POLID, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = NVO_BOL.PODID) as POD,NVO_BOL.PODID,NVO_BOL.ShipmentTypeID " +
                            " from NVO_BOL " +
                            " inner join NVO_Booking on NVO_Booking.ID = NVO_BOL.BkgID";

            //strWhere += _Query + " where RSStatus = 1";

            //if (Data.RRNumber != "")
            //    if (strWhere == "")
            //        strWhere += _Query + " where RatesheetNo like'%" + Data.RRNumber + "%'";
            //    else
            //        strWhere += " and RatesheetNo like'%" + Data.RRNumber + "%'";

            //if (Data.PortofLoading != null)
            //    if (strWhere == "")
            //        strWhere += _Query + " where PortOfLoading=" + Data.PortofLoading;
            //    else
            //        strWhere += " and PortOfLoading=" + Data.PortofLoading;

            //if (Data.PortofDischarge != "")
            //    if (strWhere == "")
            //        strWhere += _Query + " where PlaceofDischargeId=" + Data.PortofDischarge;
            //    else
            //        strWhere += " and PlaceofDischargeId=" + Data.PortofDischarge;


            //if (Data.BookingParty != "")
            //    if (strWhere == "")
            //        strWhere += _Query + " where (select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) like'%" + Data.BookingParty + "%'";
            //    else
            //        strWhere += " and (select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) like'%" + Data.BookingParty + "%'";

            //if (Data.Status != null)
            //    if (strWhere == "")
            //        strWhere += _Query + " where RSStatus=" + Data.PortofDischarge;
            //    else
            //        strWhere += " and RSStatus=" + Data.PortofDischarge;
            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }


        public List<MyNotification> ExemptionNotificationValue(MyNotification Data)
        {
            List<MyNotification> ViewList = new List<MyNotification>();
            DataTable dt = GetExemptNotificationValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyNotification
                {
                    ID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentTypes"].ToString(),
                    CustomerName = dt.Rows[i]["BkgParty"].ToString(),
                    PODStr = dt.Rows[i]["POD"].ToString(),
                    POLStr = dt.Rows[i]["POL"].ToString(),
                    PORStr = dt.Rows[i]["POO"].ToString(),
                    FPODStr = dt.Rows[i]["FPOD"].ToString(),


                });
            }
            return ViewList;
        }

        public DataTable GetExemptNotificationValues(MyNotification Data)
        {
            string _Query = " select BLNumber,BkgID,case when NVO_BOL.ShipmentTypeID= 1 then 'Export' else 'Import' end as ShipmentTypes,BkgParty, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = NVO_BOL.POLID) as POL,NVO_BOL.POLID, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = NVO_BOL.PODID) as POD,NVO_BOL.PODID, "+
                            " (select top(1) PortName from NVO_PortMaster where ID = NVO_BOL.POOID) as POO, "+
                            " (select top(1) PortName from NVO_PortMaster where ID = NVO_BOL.FPODID) as FPOD, "+
                            " NVO_BOL.ShipmentTypeID " +
                            " from NVO_BOL " +
                            " inner join NVO_Booking on NVO_Booking.ID = NVO_BOL.BkgID where BkgID= " + Data.ID;


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
    }
}

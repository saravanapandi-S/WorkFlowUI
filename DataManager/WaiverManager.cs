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
  public  class WaiverManager
    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public WaiverManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion


        public List<MyWaiver>WaiverBLNumber()
        {
            List<MyWaiver> ViewList = new List<MyWaiver>();
            DataTable dt = GetBLNumber();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyWaiver
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetBLNumber()
        {
            string _Query = "select * from NVO_Booking";
            return GetViewData(_Query,"");
        }
        public List<MyWaiver> WaiverBkgCntrNo(MyWaiver Data)
        {
            List<MyWaiver> ViewList = new List<MyWaiver>();
            DataTable dt = GetBkgCntrNo(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyWaiver
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNO"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetBkgCntrNo(MyWaiver Data)
        {
            string _Query = "select CntrID as ID,(select top(1) CntrNo from NVO_Containers where Id =CntrID)  as CntrNO from NVO_BOLCntrDetails where BkgId=" + Data.BkgID;
            return GetViewData(_Query, "");
        }


        public List<MyWaiver> InsertWaiverMaster(MyWaiver Data)
        {
            List<MyWaiver> RateList = new List<MyWaiver>();
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
                        
                        string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_WaiverDetails where BookingID=@BookingID and ContainerID=@ContainerID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_WaiverDetails(RequestTypeID,TransTypeID,BookingID,CntrTypeID,ContainerID,Freedays,WaiverAmt,Waiver,Remarks,RequestBy,AgentID,Country,AttachFile,ChargeType) " +
                                     " values (@RequestTypeID,@TransTypeID,@BookingID,@CntrTypeID,@ContainerID,@Freedays,@WaiverAmt,@Waiver,@Remarks,@RequestBy,@AgentID,@Country,@AttachFile,@ChargeType) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_WaiverDetails SET RequestTypeID=@RequestTypeID,TransTypeID=@TransTypeID,BookingID=@BookingID,CntrTypeID=@CntrTypeID,ContainerID=@ContainerID,Freedays=@Freedays," +
                                     " WaiverAmt=@WaiverAmt,Waiver=@Waiver,Remarks=@Remarks,RequestBy=@RequestBy,AgentID=@AgentID,Country=@Country,AttachFile=@AttachFile,ChargeType=@ChargeType where BookingID=@BookingID and ContainerID=@ContainerID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestTypeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TransTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Freedays", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@WaiverAmt", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Waiver", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeType", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestBy", Data.RequestBy));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID",1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Country", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.WaiverAttach));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                  
                    RateList.Add(new MyWaiver { BkgID = Data.BkgID});
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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


        public List<MyWaiver> WaiverView(MyWaiver Data)
        {
            List<MyWaiver> ViewList = new List<MyWaiver>();
            DataTable dt = GetWaiverView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyWaiver
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestType = dt.Rows[i]["RequestTypes"].ToString(),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString(),
                    Freedays = dt.Rows[i]["Freedays"].ToString(),
                    WaiverAmt = dt.Rows[i]["WaiverAmt"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetWaiverView(MyWaiver Data)
        {
            string strWhere = "";
            string _Query = " select distinct BookingID as ID,(select top(1) GeneralName from NVO_GeneralMaster where Id = RequestTypeID) as RequestTypes, " +
                            " (select top(1) BookingNo from NVO_Booking where Id = BookingID) as BookingNo, Freedays, WaiverAmt,'' Status " +
                            " from NVO_WaiverDetails ";

            if (Data.RequestTypeID != null)
                if (strWhere == "")
                    strWhere += _Query + " where RequestTypeID=" + Data.RequestTypeID;
                else
                    strWhere += " and RequestTypeID=" + Data.RequestTypeID;

            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top(1) BookingNo from NVO_Booking where Id = BookingID)  like'%" + Data.BLNumber + "%'";
                else
                    strWhere += " and (select top(1) BookingNo from NVO_Booking where Id = BookingID) like'%" + Data.BLNumber + "%'";

            if (Data.WaiverAmt != "")
                if (strWhere == "")
                    strWhere += _Query + " where WaiverAmt=" + Data.WaiverAmt;
                else
                    strWhere += " and WaiverAmt=" + Data.WaiverAmt;

            if (Data.Freedays != "")
                if (strWhere == "")
                    strWhere += _Query + " where Freedays=" + Data.Freedays;
                else
                    strWhere += " and Freedays=" + Data.Freedays;

            if (strWhere == "")
                strWhere = _Query;



            return GetViewData(_Query, "");
        }


        public List<MyWaiver> WaiverViewValues(MyWaiver Data)
        {
            List<MyWaiver> ViewList = new List<MyWaiver>();
            DataTable dt = GetWaiverViewValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyWaiver
                {
                   
                    RequestType = dt.Rows[i]["RequestType"].ToString(),
                    RequestTypeID = dt.Rows[i]["RequestTypeID"].ToString(),
                    TransType = dt.Rows[i]["TransType"].ToString(),
                    TransTypeID = dt.Rows[i]["TransTypeID"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BookingID = dt.Rows[i]["BookingID"].ToString(),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    ContainerNo = dt.Rows[i]["ContainerNo"].ToString(),
                    ContainerID = dt.Rows[i]["ContainerID"].ToString(),
                    Freedays = dt.Rows[i]["Freedays"].ToString(),
                    WaiverAmt = dt.Rows[i]["WaiverAmt"].ToString(),
                    Waiver = dt.Rows[i]["Waiver"].ToString(),
                    ChargeType = dt.Rows[i]["ChargeTypeName"].ToString(),
                    ChargeTypeID = dt.Rows[i]["ChargeType"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    RequestBy = dt.Rows[i]["RequestBy"].ToString(),
                    WaiverAttach = dt.Rows[i]["AttachFile"].ToString()


                });
            }
            return ViewList;
        }


        public DataTable GetWaiverViewValues(MyWaiver Data)
        {
            string _Query = " select distinct BookingID as ID,RequestTypeID,(select top(1) GeneralName from NVO_GeneralMaster where Id = RequestTypeID) as RequestType, " +
                            " TransTypeID, case when TransTypeID = 1 then 'Agency Export' else 'Agency Import' end as TransType,BookingID, " +
                            " (select top(1) BookingNo from NVO_Booking where Id = BookingID) as BookingNo,CntrTypeID, " +
                            " (select top(1) Size from NVO_tblCntrTypes where ID = CntrTypeID) as CntrTypes,ContainerID, " +
                            " (select top(1) ChgDesc from NVO_ChargeTB where ID= NVO_WaiverDetails.ChargeType)as ChargeTypeName,ChargeType, " +
                            " (select top(1) CntrNo from NVO_Containers where Id = ContainerID) as ContainerNo,Freedays,WaiverAmt,Waiver,Remarks,RequestBy,AttachFile " +
                            " from NVO_WaiverDetails where BookingID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyWaiver> ChargCodeList(MyWaiver Data)
        {
            List<MyWaiver> ViewList = new List<MyWaiver>();
            DataTable dt = GetChargeCodeDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyWaiver
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChgDesc = dt.Rows[i]["ChgDesc"].ToString(),

                });
            }
            return ViewList;
        }
        public DataTable GetChargeCodeDtls(MyWaiver Data)
        {
            string _Query = " select ID,ChgDesc from NVO_ChargeTB where ID IN(28,29,30)";
            return GetViewData(_Query, "");
        }

        #region GetView
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
        #endregion
    }
}

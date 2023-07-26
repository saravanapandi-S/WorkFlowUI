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
    public class ImpArrivalManager
    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImpArrivalManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        List<MyImpArrival> ListImpArrival = new List<MyImpArrival>();

        public List<MyImpArrival> GetImportArrivalList(MyImpArrival Data)
        {
            DataTable dt = GetImportArrivalListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListImpArrival.Add(new MyImpArrival
                {
                    
                    ShipperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    ConsigneeEmail = dt.Rows[i]["ConsigneeEmail"].ToString(),
                    NotifyEmail = dt.Rows[i]["NotifyEmail"].ToString(),
                    Notify2Email = dt.Rows[i]["Notify2Email"].ToString(),


                });
            }


            return ListImpArrival;
        }

        public DataTable GetImportArrivalListValues(MyImpArrival Data)
        {
            string _Query = "select ShipperEmail,ConsigneeEmail,NotifyEmail,Notify2Email from Nvo_ImpBL where ID=" +Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MyImpArrival> GetSaveArrival(MyImpArrival Data)
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
                    Cmd.CommandText = " IF((select count(*) from NVO_IMPArrivalNoticeDtls where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_IMPArrivalNoticeDtls(BLID,RevisedID,ChargesID,ShipperEmail,ConsigneeEmail,NotifyEmail,Notify2Email,OtherPartyEmail,Status) " +
                                     " values (@BLID,@RevisedID,@ChargesID,@ShipperEmail,@ConsigneeEmail,@NotifyEmail,@Notify2Email,@OtherPartyEmail,Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_IMPArrivalNoticeDtls SET BLID=@BLID,RevisedID=@RevisedID,ChargesID=@ChargesID,ShipperEmail=@ShipperEmail,ConsigneeEmail=@ConsigneeEmail,NotifyEmail=@NotifyEmail,Notify2Email=@Notify2Email,OtherPartyEmail=@OtherPartyEmail,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RevisedID", Data.RevisedID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargesID", Data.ChargesID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperEmail", Data.ShipperEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeEmail", Data.ConsigneeEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyEmail", Data.NotifyEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Email", Data.Notify2Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherPartyEmail", Data.OtherPartyEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", System.DateTime.Now));                    
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_IMPArrivalNoticeDtls')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListImpArrival.Add(new MyImpArrival
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListImpArrival;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListImpArrival.Add(new MyImpArrival
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListImpArrival;
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


        public List<MyImpArrival> GetImpArrivalEdit(MyImpArrival Data)
        {
            DataTable dt = GetImpArrivalEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListImpArrival.Add(new MyImpArrival
                {
                    RevisedID = Int32.Parse(dt.Rows[i]["RevisedID"].ToString()),
                    ChargesID = Int32.Parse(dt.Rows[i]["ChargesID"].ToString()),
                    ShipperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    ConsigneeEmail = dt.Rows[i]["ConsigneeEmail"].ToString(),
                    NotifyEmail = dt.Rows[i]["NotifyEmail"].ToString(),
                    Notify2Email = dt.Rows[i]["Notify2Email"].ToString(),
                    OtherPartyEmail = dt.Rows[i]["OtherPartyEmail"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                });
            }


            return ListImpArrival;
        }

        public DataTable GetImpArrivalEditValues(MyImpArrival Data)
        {
            string _Query = "select convert(varchar, Status, 103) as Status,* from NVO_IMPArrivalNoticeDtls where BLID=" + Data.BLID;
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

    }
}

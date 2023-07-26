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
    public class ImdeliveryDetailsManager
    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImdeliveryDetailsManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        List<ImdeliveryDetails> ListDeliveryDetails = new List<ImdeliveryDetails>();
        public List<ImdeliveryDetails> GetSaveDeliverydetails(ImdeliveryDetails Data)
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
                    Cmd.CommandText = " IF((select count(*) from NVO_ImpDeliveryDetails where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpDeliveryDetails(CntrServiceID,DeliveryLocID,CFS,ICD,Transporter,CHA,BondNo,ItemTypeID,DPDID,CargoTypeID,LineCode,SubLineCode,IGMNo,IGMDate,BLID) " +
                                     " values (@CntrServiceID,@DeliveryLocID,@CFS,@ICD,@Transporter,@CHA,@BondNo,@ItemTypeID,@DPDID,@CargoTypeID,@LineCode,@SubLineCode,@IGMNo,@IGMDate,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpDeliveryDetails SET CntrServiceID=@CntrServiceID,DeliveryLocID=@DeliveryLocID,CFS=@CFS,ICD=@ICD,Transporter=@Transporter,CHA=@CHA,BondNo=@BondNo,ItemTypeID=@ItemTypeID,DPDID=@DPDID,CargoTypeID=@CargoTypeID,LineCode=@LineCode,SubLineCode=@SubLineCode,IGMNo=@IGMNo,IGMDate=@IGMDate,BLID=@BLID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrServiceID", Data.CntrServiceID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryLocID", Data.DeliveryLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CFS", Data.CFS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ICD", Data.ICD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Transporter", Data.Transporter));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CHA", Data.CHA));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BondNo", Data.BondNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ItemTypeID", Data.ItemTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DPDID", Data.DPDID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoTypeID", Data.CargoTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LineCode", Data.LineCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SubLineCode", Data.SubLineCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMNo", Data.IGMNo));
                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", Data.IGMDate));
                    if (Data.IGMDate != null)
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", Data.IGMDate));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", DBNull.Value));
                    }
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ImpDeliveryDetails')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListDeliveryDetails.Add(new ImdeliveryDetails
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListDeliveryDetails;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListDeliveryDetails.Add(new ImdeliveryDetails
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListDeliveryDetails;
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


        public List<ImdeliveryDetails> GetDeliverydetailsEdit(ImdeliveryDetails Data)
        {
            DataTable dt = GetDeliverydetailsEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDeliveryDetails.Add(new ImdeliveryDetails

                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrServiceID = Int32.Parse(dt.Rows[i]["CntrServiceID"].ToString()),
                    DeliveryLocID = Int32.Parse(dt.Rows[i]["DeliveryLocID"].ToString()),
                    CFS = dt.Rows[i]["CFS"].ToString(),
                    ICD = dt.Rows[i]["ICD"].ToString(),
                    Transporter = dt.Rows[i]["Transporter"].ToString(),
                    CHA = dt.Rows[i]["CHA"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    ItemTypeID = Int32.Parse(dt.Rows[i]["ItemTypeID"].ToString()),
                    DPDID = Int32.Parse(dt.Rows[i]["DPDID"].ToString()),
                    CargoTypeID = Int32.Parse(dt.Rows[i]["CargoTypeID"].ToString()),
                    LineCode = dt.Rows[i]["LineCode"].ToString(),
                    SubLineCode = dt.Rows[i]["SubLineCode"].ToString(),
                    IGMNo = dt.Rows[i]["IGMNo"].ToString(),
                    IGMDate = dt.Rows[i]["IGMDate"].ToString(),
                    // BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    // UserID = Int32.Parse(dt.Rows[i]["UserID"].ToString()),

                });
            }


            return ListDeliveryDetails;
        }

        public DataTable GetDeliverydetailsEditValues(ImdeliveryDetails Data)
        {
            string _Query = "Select convert(varchar, IGMDate, 23) as IGMDate,* from NVO_ImpDeliveryDetails where BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }




        public List<ImdeliveryDetails> GetIMVesselValues(ImdeliveryDetails Data)
        {
            DataTable dt = GetIMVesselValuesList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDeliveryDetails.Add(new ImdeliveryDetails

                {
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    ATD = dt.Rows[i]["ATD"].ToString(),


                });
            }


            return ListDeliveryDetails;
        }

        public DataTable GetIMVesselValuesList(ImdeliveryDetails Data)
        {
            string _Query = " select BLNumber,(select top(1) VesselName from NVO_VesselMaster  where ID =Nvo_ImpBL.VesselID) as VesselName," +
                            " (select top(1) VoyageNo from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as VoyageNo," +
                            " (select top(1) convert(varchar, ETD, 106) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ETD," +
                            " (select top(1) convert(varchar, ATD, 113) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ATD" +
                            " from Nvo_ImpBL where ID =" + Data.BLID;

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

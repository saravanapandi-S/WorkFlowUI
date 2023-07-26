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
    public class CROManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CROManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region CRO
        List<MyCRO> ListCro = new List<MyCRO>();
        public List<MyCRO> BindStufflist(MyCRO Data)
        {
            DataTable dt = GetBindStufflist(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCro.Add(new MyCRO
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StuffName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCro;
        }

        public DataTable GetBindStufflist(MyCRO Data)
        {
            string _Query = "select * from NVO_GeneralMaster where Status=1 and SeqNo=76 order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyCRO> BindDepolist(MyCRO Data)
        {
            DataTable dt = GetBindDepolist(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCro.Add(new MyCRO
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Depot = dt.Rows[i]["DepName"].ToString()
                });
            }
            return ListCro;
        }

        public DataTable GetBindDepolist(MyCRO Data)
        {
            string _Query = "select * from NVO_DepotMaster where Status=1  order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyCROCntrTypes> BkgCntrTypesExistingValus(MyCROCntrTypes Data)
        {
            List<MyCROCntrTypes> ViewcroList = new List<MyCROCntrTypes>();
            DataTable dt = GetBkgCntrTypesExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewcroList.Add(new MyCROCntrTypes
                {
                    BID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    BookingQty = dt.Rows[i]["BookingQty"].ToString(),
                });
            }
            return ViewcroList;
        }

        public DataTable GetBkgCntrTypesExistingValus(MyCROCntrTypes Data)
        {
            string _Query = "select NVO_BookingCntrType.ID,NVO_BookingCntrType.CntrTypeID,NVO_BookingCntrType.BkgID,(SUM(NVO_BookingCntrType.Nos) - ISNULL((select sum(ReqQty)  from NVO_CROMaster inner join " +
              " NVO_CRODetails on NVO_CRODetails.CROID = NVO_CROMaster.ID where NVO_CROMaster.BkgID = NVO_BookingCntrType.BkgID and NVO_CRODetails.CntrTypeID = NVO_BookingCntrType.CntrTypeID ), 0)) AS BookingQty " +
              " from NVO_BookingCntrType where NVO_BookingCntrType.BkgID = " + Data.BkgID + " GROUP BY NVO_BookingCntrType.ID,NVO_BookingCntrType.CntrTypeID,NVO_BookingCntrType.BkgID ";
            return GetViewData(_Query, "");
        }


        public List<MyCRO> InsertCRO(MyCRO Data)
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
                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("CRO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'CRO' + ('NAV')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.CRONo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_CROMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CROMaster(ReleaseOrderNo,Date,BkgID,ValidTill,PickDepoID,Surveyor,Remarks,YardRemarks,YardID,CROStatus,UserID,ReleaseToID) values (@ReleaseOrderNo,@Date,@BkgID,@ValidTill,@PickDepoID,@Surveyor,@Remarks,@YardRemarks,@YardID,@CROStatus,@UserID,@ReleaseToID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CROMaster SET ReleaseOrderNo=@ReleaseOrderNo,Date=@Date,BkgID=@BkgID,ValidTill=@ValidTill,PickDepoID=@PickDepoID,Surveyor=@Surveyor,Remarks=@Remarks,YardRemarks=@YardRemarks,YardID=@YardID,CROStatus=@CROStatus,UserID=@UserID,ReleaseToID=@ReleaseToID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReleaseOrderNo", Data.CRONo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReleaseToID", Data.ReleaseToID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@StateName", ""));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickDepoID", Data.PickUpDepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Surveyor", Data.SurveyorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.CusRemarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@YardRemarks", Data.YardRemarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@YardID", Data.StuffID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CROStatus", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CROMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_CRODetails where CID=@CID and CROID=@CROID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_CRODetails(CROID,CntrTypeID,Qty,ReqQty) " +
                                         " values (@CROID,@CntrTypeID,@Qty,@ReqQty) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_CRODetails SET CROID=@CROID,CntrTypeID=@CntrTypeID,Qty=@Qty,ReqQty=@ReqQty where CID=@CID and CROID=@CROID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CROID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqQty", CharSplit[3]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@PenQty", CharSplit[4]));


                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }




                    trans.Commit();

                    ListCro.Add(new MyCRO
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Record Saved sucessfully " + Data.CRONo,
                        CRONo = Data.CRONo
                    });
                    return ListCro;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCro.Add(new MyCRO
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCro;
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

        public List<MyCRO> CROViewRecordData(MyCRO Data)
        {
            DataTable dt = GetCROViewRecordData(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCro.Add(new MyCRO
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CRONo = dt.Rows[i]["ReleaseOrderNo"].ToString(),
                    ReleaseTo = dt.Rows[i]["ReleaseTo"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    CROStatus = dt.Rows[i]["CROSTATUS"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString()
                });
            }
            return ListCro;
        }

        public DataTable GetCROViewRecordData(MyCRO Data)
        {
            string _Query = "SELECT ID,ReleaseOrderNo,BkgID, (select top 1 CustomerName from NVO_view_CustomerDetails where CID = ReleaseToID) as ReleaseTo, " +
              " (select top 1 DepName from NVO_Depotmaster where ID = PickDepoID) as Depot,convert(varchar, ValidTill, 105) as ValidTill,Case when CROStatus = 1 then 'ACTIVE' " +
               " Else 'INACTIVE' END AS CROSTATUS FROM NVO_CROMaster where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCRO> CROEditRecordData(MyCRO Data)
        {
            DataTable dt = GetCROEditRecordData(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCro.Add(new MyCRO
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    CRONo = dt.Rows[i]["ReleaseOrderNo"].ToString(),
                    ReleaseToID = Int32.Parse(dt.Rows[i]["ReleaseToID"].ToString()),
                    StuffID = Int32.Parse(dt.Rows[i]["YardID"].ToString()),
                    PickUpDepotID = Int32.Parse(dt.Rows[i]["PickDepoID"].ToString()),
                    SurveyorID = Int32.Parse(dt.Rows[i]["Surveyor"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTillDt"].ToString(),
                    CusRemarks = dt.Rows[i]["Remarks"].ToString(),
                    YardRemarks = dt.Rows[i]["YardRemarks"].ToString(),
                });
            }
            return ListCro;
        }

        public DataTable GetCROEditRecordData(MyCRO Data)
        {
            string _Query = "SELECT convert(varchar, ValidTill, 23) as ValidTillDt,* FROM NVO_CROMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCROCntrTypes> ExistCROCntrTypesNosValus(MyCROCntrTypes Data)
        {
            List<MyCROCntrTypes> ViewcroList = new List<MyCROCntrTypes>();
            DataTable dt = GetExistCROCntrTypesNosValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewcroList.Add(new MyCROCntrTypes
                {
                    BID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    BookingQty = dt.Rows[i]["Qty"].ToString(),
                    RequiredQty = dt.Rows[i]["ReqQty"].ToString(),
                });
            }
            return ViewcroList;
        }

        public DataTable GetExistCROCntrTypesNosValus(MyCROCntrTypes Data)
        {
            string _Query = "SELECT * FROM NVO_CRODetails where CROID= " + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyCRO> CROValidationsData(MyCRO Data)
        {
            DataTable dt = GetCROValidationsDataa(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCro.Add(new MyCRO
                {
                    CheckCRO = Int32.Parse(dt.Rows[i]["CheckCRO"].ToString()),

                });
            }
            return ListCro;
        }

        public DataTable GetCROValidationsDataa(MyCRO Data)
        {

            string _Query = " select ISNULL(((select sum(Nos) from NVO_BookingCntrType where NVO_BookingCntrType.BkgId = " + Data.ID + ")  - isnull(sum(ReqQty),0)),0) as CheckCRO " +
             " from NVO_CROMaster  LEFT OUTER join NVO_CRODetails on NVO_CRODetails.CROID = NVO_CROMaster.ID where BkgID  = " + Data.ID + " AND CROStatus = 1 ";
            return GetViewData(_Query, "");
        }

        public List<MyCRO> CheckCroAvailable(MyCRO Data)
        {
            DataTable dt = GetCheckCroAvailable(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCro.Add(new MyCRO
                {
                    CheckCRO = Int32.Parse(dt.Rows[i]["CheckCRO"].ToString()),

                });
            }
            return ListCro;
        }

        public DataTable GetCheckCroAvailable(MyCRO Data)
        {

            string _Query = " select count(ID) AS CheckCRO From NVO_CROMaster where BkgID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

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

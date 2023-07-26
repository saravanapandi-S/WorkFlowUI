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
    public class FinanceUploadManager
    {
        #region Constructor Method
        public FinanceUploadManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public DataTable InsertGLmasterExcelUploading(DataTable dtv)
        {
            string ChargeTB = "0";
            string SlotTerms = "0";
            string POL = "0";
            string POD = "0";
            string ServiceName = "";

            DataTable dt = new DataTable();
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
                string varv = "";
                try
                {
                    DataView dts = new DataView(dtv);


                    dt = dts.ToTable(true, "ID", "CODE", "GLDESCRIPTION", "COMPANY", "MAINACCOUNT", "NATURE", "CATEGORY", "GLMATCHING", "GLSTATUS", "PRODUCTTYPE", "RESULT", "STATUS");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_GLMaster where ID=@ID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_GLMaster(GLCode,CompanyID,MainAccType,GLNature,Category,GLMatching,ProductType,GLDesc,UserID,LocID,AgencyID,CurrentDate,StatusID) " +
                                        " values (@GLCode,@CompanyID,@MainAccType,@GLNature,@Category,@GLMatching,@ProductType,@GLDesc,@UserID,@LocID,@AgencyID,@CurrentDate,@StatusID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_GLMaster SET GLCode=@GLCode,CompanyID=@CompanyID,MainAccType=@MainAccType,GLNature=@GLNature,Category=@Category,GLMatching=@GLMatching,ProductType=@ProductType,GLDesc=@GLDesc,UserID=@UserID,LocID=@LocID,AgencyID=@AgencyID,CurrentDate=@CurrentDate,StatusID=@StatusID where ID=@ID";

                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "GL Master has been Created";
                            }
                            else
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_GLMaster where ID=@ID)<=0) " +
                                      " BEGIN " +
                                      " INSERT INTO  NVO_GLMaster(GLCode,CompanyID,MainAccType,GLNature,Category,GLMatching,ProductType,GLDesc,UserID,LocID,AgencyID,CurrentDate,StatusID) " +
                                      " values (@GLCode,@CompanyID,@MainAccType,@GLNature,@Category,@GLMatching,@ProductType,@GLDesc,@UserID,@LocID,@AgencyID,@CurrentDate,@StatusID) " +
                                      " END  " +
                                      " ELSE " +
                                      " UPDATE NVO_GLMaster SET GLCode=@GLCode,CompanyID=@CompanyID,MainAccType=@MainAccType,GLNature=@GLNature,Category=@Category,GLMatching=@GLMatching,ProductType=@ProductType,GLDesc=@GLDesc,UserID=@UserID,LocID=@LocID,AgencyID=@AgencyID,CurrentDate=@CurrentDate,StatusID=@StatusID where ID=@ID";


                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "GL Master has been Updated";
                            }
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyID", dt.Rows[i]["COMPANY"].ToString()));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@MainAccType", dt.Rows[i]["MAINACCOUNT"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GLNature", dt.Rows[i]["NATURE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Category", dt.Rows[i]["CATEGORY"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ProductType", dt.Rows[i]["PRODUCTTYPE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GLMatching", dt.Rows[i]["GLMATCHING"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", dt.Rows[i]["GLSTATUS"].ToString()));
                            Cmd.Parameters.Clear();

                            DataTable _dtCompany = GetAgency(dt.Rows[i]["COMPANY"].ToString());
                            if (_dtCompany.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyID", _dtCompany.Rows[0]["ID"].ToString()));
                                //ChargeTB = _dtChg.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyID", 0));

                            DataTable _dtMA = GetMainAcc(dt.Rows[i]["MAINACCOUNT"].ToString());
                            if (_dtMA.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@MainAccType", _dtMA.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@MainAccType", 0));

                            DataTable _dtNature = GetGLNature(dt.Rows[i]["NATURE"].ToString());
                            if (_dtNature.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GLNature", _dtNature.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GLNature", 0));
                            DataTable _dtCategory = GetCategory(dt.Rows[i]["CATEGORY"].ToString());
                            if (_dtCategory.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Category", _dtCategory.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Category", 0));

                            DataTable _dtPt = GetProductType(dt.Rows[i]["PRODUCTTYPE"].ToString());
                            if (_dtPt.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ProductType", _dtPt.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ProductType", 0));
                            DataTable _dtGLM = GetGLMatching(dt.Rows[i]["GLMATCHING"].ToString());
                            if (_dtGLM.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GLMatching", _dtGLM.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GLMatching", 0));
                            //if (dt.Rows[i]["GLSTATUS"].ToString() == "ACTIVE")
                            //{
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 1));
                            //}
                            //if (dt.Rows[i]["GLSTATUS"].ToString() == "INACTIVE")
                            //{
                            //    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 2));
                            //}

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GLCODE", dt.Rows[i]["CODE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GLDesc", dt.Rows[i]["GLDESCRIPTION"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                            Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();


                        }
                    }
                    trans.Commit();
                    result = 1;
                    return dt;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return dt;
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

        public DataTable GetAgency(string Name)
        {
            string _Query = "select * from NVO_AgencyMaster where AgencyCode like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetMainAcc(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =20 and GeneralName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetGLNature(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =21 and GeneralName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCategory(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =22 and GeneralName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetGLMatching(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =23 and GeneralName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetProductType(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =24 and GeneralName like  '" + Name + "'";
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

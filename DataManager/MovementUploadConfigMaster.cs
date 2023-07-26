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
    public class MovementUploadConfigMaster
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public MovementUploadConfigMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        List<MyMovementUploadConfig> ListMovementUploadConfig = new List<MyMovementUploadConfig>();
        public List<MyMovementUploadConfig> SaveMovementUploadValue(MyMovementUploadConfig Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetSaveMovementUploadValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListMovementUploadConfig.Add(new MyMovementUploadConfig
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "This Type Already Exists"
                    });
                    return ListMovementUploadConfig;

                }
            }

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
                    Cmd.CommandText = " IF((select count(*) from NVO_MVUploadConfig where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MVUploadConfig(OfficeID,EffectiveDate,SourceTypeID,TemplateID,SourceID,FileType,UploadTypeID) " +
                                     " values (@OfficeID,@EffectiveDate,@SourceTypeID,@TemplateID,@SourceID,@FileType,@UploadTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MVUploadConfig SET OfficeID=@OfficeID,EffectiveDate=@EffectiveDate,SourceTypeID=@SourceTypeID,TemplateID=@TemplateID,SourceID=@SourceID,FileType=@FileType,UploadTypeID=@UploadTypeID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeID", Data.OfficeID));

                    if (Data.EffectiveDate != null)
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EffectiveDate", Data.EffectiveDate));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EffectiveDate", DBNull.Value));
                    }                    
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SourceTypeID", Data.SourceTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TemplateID", Data.TemplateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SourceID", Data.SourceID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FileType", Data.FileType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadTypeID", Data.UploadTypeID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_MVUploadConfig')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListMovementUploadConfig.Add(new MyMovementUploadConfig
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListMovementUploadConfig;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListMovementUploadConfig.Add(new MyMovementUploadConfig
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListMovementUploadConfig;
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
        public DataTable GetSaveMovementUploadValues(MyMovementUploadConfig Data)
        {


            string _Query = "select * from NVO_MVUploadConfig where ID = '" + Data.ID + "'";
            return GetViewData(_Query, "");
        }

        public List<MyMovementUploadConfig> GetMovementUploadList(MyMovementUploadConfig Data)
        {
            DataTable dt = GetMovementUploadListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMovementUploadConfig.Add(new MyMovementUploadConfig
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OfficeID = Int32.Parse(dt.Rows[i]["OfficeID"].ToString()),
                    SourceTypeName = dt.Rows[i]["SourceTypeName"].ToString(),
                    SourceName = dt.Rows[i]["SourceName"].ToString(),
                    TemplateName = dt.Rows[i]["TemplateName"].ToString(),                   
                    FileType = dt.Rows[i]["FileType"].ToString(),
                    UpdateTypeName = dt.Rows[i]["UpdateTypeName"].ToString(),
                    EffectiveDate = dt.Rows[i]["EffectiveDate"].ToString()             
                    
                });

            }
            return ListMovementUploadConfig;
        }
        public DataTable GetMovementUploadListValues(MyMovementUploadConfig Data)
        {
            string strWhere = "";

            string _Query = " select ID,OfficeID, case when NVO_MVUploadConfig.SourceTypeID =1 then 'Terminal' when NVO_MVUploadConfig.SourceTypeID =2 then 'Yard' when NVO_MVUploadConfig.SourceTypeID =3 then 'CFS' ELSE '' END as SourceTypeName, " +
                            " case when NVO_MVUploadConfig.TemplateID = 1 then 'Codeco' when NVO_MVUploadConfig.TemplateID = 2 then 'Coarri' when NVO_MVUploadConfig.TemplateID = 3 then 'TemplateA' " +
                            " when NVO_MVUploadConfig.TemplateID = 4 then 'TerminalB' when NVO_MVUploadConfig.TemplateID = 5 then 'TerminalA' when NVO_MVUploadConfig.TemplateID = 6 then 'TerminalB'  ELSE '' END AS TemplateName, " +
                            " FileType,case when NVO_MVUploadConfig.UploadTypeID = 1 then 'Manual' when NVO_MVUploadConfig.UploadTypeID = 2 then 'Job' Else '' end as UpdateTypeName,convert(varchar, EffectiveDate, 103) as EffectiveDate, " +
                            " (select PortCode   +'-' +  PortName from NVO_PortMaster where ID = SourceID) as SourceName " +
                            " from NVO_MVUploadConfig ";

            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.OfficeID = " + Data.OfficeID + "";
                else
                    strWhere += " and NVO_MVUploadConfig.OfficeID = " + Data.OfficeID + "";

            if (Data.SourceTypeID.ToString() != "" && Data.SourceTypeID.ToString() != "0" && Data.SourceTypeID.ToString() != null && Data.SourceTypeID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.SourceTypeID = " + Data.SourceTypeID.ToString();
                else
                    strWhere += " and NVO_MVUploadConfig.SLTypeID = " + Data.SourceTypeID.ToString();

            if (Data.SourceID.ToString() != "" && Data.SourceID.ToString() != "0" && Data.SourceID.ToString() != null && Data.SourceID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.SourceID = " + Data.SourceID.ToString();
                else
                    strWhere += " and NVO_MVUploadConfig.SourceID = " + Data.SourceID.ToString();

            if (Data.TemplateID.ToString() != "" && Data.TemplateID.ToString() != "0" && Data.TemplateID.ToString() != null && Data.TemplateID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.TemplateID = " + Data.TemplateID.ToString();
                else
                    strWhere += " and NVO_MVUploadConfig.TemplateID = " + Data.TemplateID.ToString();

            if (Data.FileType != "")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.FileType like '%" + Data.FileType + "%'";
                else
                    strWhere += " and NVO_MVUploadConfig.FileType like '%" + Data.FileType + "%'";


            if (Data.EffectiveDate != "" && Data.EffectiveDate != null)
                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.EffectiveDate >= '" + DateTime.Parse(Data.EffectiveDate.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and NVO_MVUploadConfig.EffectiveDate >= '" + DateTime.Parse(Data.EffectiveDate.ToString()).ToString("MM/dd/yyyy") + "'";


            if (Data.UploadTypeID.ToString() != "" && Data.UploadTypeID.ToString() != "0" && Data.UploadTypeID.ToString() != null && Data.UploadTypeID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_MVUploadConfig.UploadTypeID = " + Data.UploadTypeID.ToString();
                else
                    strWhere += " and NVO_MVUploadConfig.UploadTypeID = " + Data.UploadTypeID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyMovementUploadConfig> GetMovementUploadEdit(MyMovementUploadConfig Data)
        {
            DataTable dt = GetMovementUploadEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMovementUploadConfig.Add(new MyMovementUploadConfig
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),                  
                    OfficeID = Int32.Parse(dt.Rows[i]["OfficeID"].ToString()),
                    EffectiveDate = dt.Rows[i]["EffectiveDate"].ToString(),
                    SourceTypeID = Int32.Parse(dt.Rows[i]["SourceTypeID"].ToString()),
                    SourceID = Int32.Parse(dt.Rows[i]["SourceID"].ToString()),
                    TemplateID = Int32.Parse(dt.Rows[i]["TemplateID"].ToString()),
                    FileType = dt.Rows[i]["FileType"].ToString(),
                    UploadTypeID = Int32.Parse(dt.Rows[i]["UploadTypeID"].ToString()),                  

                });
            }


            return ListMovementUploadConfig;
        }

        public DataTable GetMovementUploadEditValues(MyMovementUploadConfig Data)
        {
            string _Query = "Select convert(varchar, EffectiveDate, 23) as EffectiveDate,* from NVO_MVUploadConfig where ID=" + Data.ID;
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

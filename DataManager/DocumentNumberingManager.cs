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
using System.Globalization;

namespace DataManager
{
   public class DocumentNumberingManager
    {

        #region Constructor Method
        public DocumentNumberingManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion



        public List<MyDOCNumbering> BLNoLogicsInsert(MyDOCNumbering Data)
        {

            List<MyDOCNumbering> ViewList = new List<MyDOCNumbering>();
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

                    Cmd.CommandText = " IF((select count(*) from NVO_DOCNumberingNoLogics where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_DOCNumberingNoLogics(LinerCode,LinerID,ModuleID,ProgramID,StatusID,BLNoLogicID) " +
                                     " values (@LinerCode,@LinerID,@ModuleID,@ProgramID,@StatusID,@BLNoLogicID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_DOCNumberingNoLogics SET LinerCode=@LinerCode,LinerID=@LinerID,ModuleID=@ModuleID,ProgramID=@ProgramID,StatusID=@StatusID,BLNoLogicID=@BLNoLogicID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModuleID", Data.ModuleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ProgramID", Data.ProgramID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerCode", Data.LinerCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerID", Data.LinerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNoLogicID", Data.BLNoLogicID));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_LinerBLNoLogics')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ViewList;
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


        public List<MyDOCNumbering> BLLogicsViewRecordValues(MyDOCNumbering Data)
        {
            List<MyDOCNumbering> ViewList = new List<MyDOCNumbering>();
            DataTable dt = GetBLLogicsViewRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyDOCNumbering
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LinerName = dt.Rows[i]["LinerName"].ToString(),
                    LinerCode = dt.Rows[i]["LinerCode"].ToString(),
                    BLNoLogic = dt.Rows[i]["BLNoLogic"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Module = dt.Rows[i]["Module"].ToString(),
                    Program = dt.Rows[i]["Program"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBLLogicsViewRecord(MyDOCNumbering Data)
        {
            string strWhere = "";
            string _Query = " Select ID,LinerCode,  " +
                            " (select top(1) GeneralName  from NVO_GeneralMaster where ID = LBL.ModuleID) AS Module, " +
                            " (select top(1) GeneralName  from NVO_GeneralMaster where ID = LBL.ProgramID) AS Program, " +
                            " (select top(1) Descriptions  from NVO_DOCNumbering where ID = LBL.BLNoLogicID) AS BLNoLogic, " +
                            " (select top(1) CustomerName from NVO_CustomerMaster inner join NVO_CusBusinessTypes on NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID and BussTypes in (7) where NVO_CustomerMaster.ID = LBL.LinerID) AS LinerName, " +
                            " case when LBL.StatusID = 1 then 'Active' when LBL.StatusID = 2 then 'Inactive' ELSE '' END as StatusResult from NVO_DOCNumberingNoLogics LBL ";

            if (Data.LinerID.ToString() != "" && Data.LinerID.ToString() != "0" && Data.LinerID.ToString() != null && Data.LinerID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where LinerID = " + Data.LinerID.ToString();
                else
                    strWhere += " and LinerID = " + Data.LinerID.ToString();

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where LBL.StatusID = " + Data.Status.ToString();
                else
                    strWhere += " and LBL.StatusID = " + Data.Status.ToString();



            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }


        public List<MyDOCNumbering> BLNoLogicsEditValues(MyDOCNumbering Data)
        {
            List<MyDOCNumbering> ViewList = new List<MyDOCNumbering>();
            DataTable dt = GetBLNoLogicsEditRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyDOCNumbering
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LinerID = Int32.Parse(dt.Rows[i]["LinerID"].ToString()),
                    BLNoLogicID = Int32.Parse(dt.Rows[i]["BLNoLogicID"].ToString()),
                    LinerCode = dt.Rows[i]["LinerCode"].ToString(),
                    ModuleID = Int32.Parse(dt.Rows[i]["ModuleID"].ToString()),
                    ProgramID = Int32.Parse(dt.Rows[i]["ProgramID"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString())
            });
            }
            return ViewList;
        }

        public DataTable GetBLNoLogicsEditRecord(MyDOCNumbering Data)
        {

            string _Query = "Select * from NVO_DOCNumberingNoLogics where ID=" + Data.ID;



            return GetViewData(_Query, "");
        }
        public DataTable BindBankName(MyAccount Data)
        {
            string _Query = "select ID,BankCode from NVO_FinBankMasterDtls inner join NVO_FinBankMaster on NVO_FinBankMaster.ID = NVO_FinBankMasterDtls.BMID " +
                            " where AgencyID=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }


        public List<MyDOCNumbering> BLNoLogicsValues(string id)
        {
            List<MyDOCNumbering> ViewList = new List<MyDOCNumbering>();
            DataTable dt = GetBLNoLogicsValues(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyDOCNumbering
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNoLogic = dt.Rows[i]["Descriptions"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBLNoLogicsValues(string id)
        {

            string _Query = "Select * from NVO_DOCNumbering where ProID =" + id;


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

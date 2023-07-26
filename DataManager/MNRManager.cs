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
    public class MNRManager
    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public MNRManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region GetView
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

        public DataSet GetData(string[,] Query, int Count)
        {
            DbConnection con = null;
            DataSet Ds = null;
            try
            {
                con = _dbFactory.GetConnection();
                con.Open();

                DbCommand cmd = _dbFactory.GetCommand();
                cmd.Connection = con;

                DbDataAdapter adapter = _dbFactory.GetAdapter();
                adapter.SelectCommand = cmd;

                Ds = new DataSet();
                for (int i = 0; i < Count; i++)
                {
                    cmd.CommandText = Query[i, 0].Trim();
                    adapter.Fill(Ds, Query[i, 1].Trim());
                }

                return Ds;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();
            }
        }
        #endregion

        #region  MNR MASTERS(GANESH)

        #region DAMAGE
        List<MyDamage> ListDamage = new List<MyDamage>();
        public List<MyDamage> InsertDamageMaster(MyDamage Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_MNRDamageMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRDamageMaster(DamageCode,DamageDescription,Status) " +
                                     " values (@DamageCode,@DamageDescription,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRDamageMaster SET DamageCode=@DamageCode,DamageDescription=@DamageDescription,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageCode", Data.DamageCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageDescription", Data.DamageDescription));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_MNRDamageMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListDamage;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListDamage;
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

        public List<MyDamage> GetDamageMaster(MyDamage Data)
        {
            DataTable dt = GetDamageValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListDamage.Add(new MyDamage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DamageCode = dt.Rows[i]["DamageCode"].ToString(),
                    DamageDescription = dt.Rows[i]["DamageDescription"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Status = St
                });
            }
            return ListDamage;
        }

        public DataTable GetDamageValues(MyDamage Data)
        {
            string strWhere = "";

            string _Query = " select Id,DamageCode,DamageDescription,status, " +
                " case when status = 1 then 'Active' when status = 0 then 'Inactive' ELSE '' END as StatusResult  from NVO_MNRDamageMaster ";

            if (Data.DamageCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where DamageCode like '%" + Data.DamageCode + "%'";
                else
                    strWhere += " and DamageCode like '%" + Data.DamageCode + "%'";

            if (Data.DamageDescription != "")
                if (strWhere == "")
                    strWhere += _Query + " where DamageDescription like '%" + Data.DamageDescription + "%'";
                else
                    strWhere += " and DamageDescription like '%" + Data.DamageDescription + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyDamage> GetDamageRecord(MyDamage Data)
        {
            DataTable dt = GetDamageRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListDamage.Add(new MyDamage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DamageCode = dt.Rows[i]["DamageCode"].ToString(),
                    DamageDescription = dt.Rows[i]["DamageDescription"].ToString(),
                    Status = St
                });
            }
            return ListDamage;
        }

        public DataTable GetDamageRecordValues(MyDamage Data)
        {
            string _Query = "select * from NVO_MNRDamageMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Repair
        List<MyRepair> ListRepair = new List<MyRepair>();
        public List<MyRepair> InsertRepairMaster(MyRepair Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_MNRRepairMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRRepairMaster(RepairCode,RepairDescription,Status) " +
                                     " values (@RepairCode,@RepairDescription,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRRepairMaster SET RepairCode=@RepairCode,RepairDescription=@RepairDescription,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairCode", Data.RepairCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairDescription", Data.RepairDescription));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_MNRRepairMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListRepair;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListRepair;
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

        public List<MyRepair> GetRepairMaster(MyRepair Data)
        {
            DataTable dt = GetRepairValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListRepair.Add(new MyRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RepairCode = dt.Rows[i]["RepairCode"].ToString(),
                    RepairDescription = dt.Rows[i]["RepairDescription"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Status = St
                });
            }
            return ListRepair;
        }

        public DataTable GetRepairValues(MyRepair Data)
        {
            string strWhere = "";

            string _Query = " select Id,RepairCode,RepairDescription,status, " +
                " case when status = 1 then 'Active' when status = 0 then 'Inactive' ELSE '' END as StatusResult  from NVO_MNRRepairMaster ";

            if (Data.RepairCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where RepairCode like '%" + Data.RepairCode + "%'";
                else
                    strWhere += " and RepairCode like '%" + Data.RepairCode + "%'";

            if (Data.RepairDescription != "")
                if (strWhere == "")
                    strWhere += _Query + " where RepairDescription like '%" + Data.RepairDescription + "%'";
                else
                    strWhere += " and RepairDescription like '%" + Data.RepairDescription + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyRepair> GetRepairRecord(MyRepair Data)
        {
            DataTable dt = GetRepairRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListRepair.Add(new MyRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RepairCode = dt.Rows[i]["RepairCode"].ToString(),
                    RepairDescription = dt.Rows[i]["RepairDescription"].ToString(),
                    Status = St
                });
            }
            return ListRepair;
        }

        public DataTable GetRepairRecordValues(MyRepair Data)
        {
            string _Query = "select * from NVO_MNRRepairMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Location
        List<MyMNRLoc> ListMNRLoc = new List<MyMNRLoc>();
        public List<MyMNRLoc> InsertMNRLocMaster(MyMNRLoc Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_MNRLocationMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRLocationMaster(LocationCode,Description,Status) " +
                                     " values (@LocationCode,@Description,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRLocationMaster SET LocationCode=@LocationCode,Description=@Description,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationCode", Data.LocationCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_MNRLocationMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListMNRLoc;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRLoc;
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

        public List<MyMNRLoc> MNRLocationMaster(MyMNRLoc Data)
        {
            DataTable dt = GetLocationValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListMNRLoc.Add(new MyMNRLoc
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Status = St
                });
            }
            return ListMNRLoc;
        }

        public DataTable GetLocationValues(MyMNRLoc Data)
        {
            string strWhere = "";

            string _Query = " select Id,LocationCode,Description,status, " +
                " case when status = 1 then 'Active' when status = 0 then 'Inactive' ELSE '' END as StatusResult  from NVO_MNRLocationMaster ";

            if (Data.LocationCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where LocationCode like '%" + Data.LocationCode + "%'";
                else
                    strWhere += " and LocationCode like '%" + Data.LocationCode + "%'";

            if (Data.Description != "")
                if (strWhere == "")
                    strWhere += _Query + " where Description like '%" + Data.Description + "%'";
                else
                    strWhere += " and Description like '%" + Data.Description + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyMNRLoc> GetMNRLocationRecord(MyMNRLoc Data)
        {
            DataTable dt = GetMNRLocationRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListMNRLoc.Add(new MyMNRLoc
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    Status = St
                });
            }
            return ListMNRLoc;
        }

        public DataTable GetMNRLocationRecordValues(MyMNRLoc Data)
        {
            string _Query = "select * from NVO_MNRLocationMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region COMPONENT

        List<MyComponent> ListComponent = new List<MyComponent>();
        public List<MyComponent> GetBindAssembly(MyComponent Data)
        {
            DataTable dt = GetBindAssemblyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListComponent.Add(new MyComponent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Assembly = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListComponent;
        }

        public DataTable GetBindAssemblyValues(MyComponent Data)
        {
            string _Query = "select * from NVO_GeneralMaster where SEQNO=35";
            return GetViewData(_Query, "");
        }

        public List<MyComponent> InsertMNRComponentMaster(MyComponent Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_MNRComponentMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRComponentMaster(ComponentCode,ComponentDescription,AssemblyID,Status) " +
                                     " values (@ComponentCode,@ComponentDescription,@AssemblyID,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRComponentMaster SET ComponentCode=@ComponentCode,ComponentDescription=@ComponentDescription,AssemblyID=@AssemblyID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ComponentCode", Data.ComponentCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ComponentDescription", Data.ComponentDescription));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AssemblyID", Data.AssemblyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_MNRComponentMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListComponent;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListComponent;
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



        public List<MyComponent> MNRComponentMaster(MyComponent Data)
        {
            DataTable dt = GetComponentValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListComponent.Add(new MyComponent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ComponentCode = dt.Rows[i]["ComponentCode"].ToString(),
                    ComponentDescription = dt.Rows[i]["ComponentDescription"].ToString(),
                    Assembly = dt.Rows[i]["Assembly"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Status = St
                });
            }
            return ListComponent;
        }

        public DataTable GetComponentValues(MyComponent Data)
        {
            string strWhere = "";

            string _Query = " select NVO_MNRComponentMaster.Id,ComponentCode,ComponentDescription,NVO_MNRComponentMaster.status,NVO_GeneralMaster.Generalname as Assembly, " +
                " case when NVO_MNRComponentMaster.status = 1 then 'Active' when NVO_MNRComponentMaster.status = 0 then 'Inactive' ELSE '' END as StatusResult  from NVO_MNRComponentMaster " +
                " Inner Join NVO_GeneralMaster on NVO_GeneralMaster.ID =NVO_MNRComponentMaster.AssemblyID and Seqno=35 ";

            if (Data.ComponentCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where ComponentCode like '%" + Data.ComponentCode + "%'";
                else
                    strWhere += " and ComponentCode like '%" + Data.ComponentCode + "%'";

            if (Data.ComponentDescription != "")
                if (strWhere == "")
                    strWhere += _Query + " where ComponentDescription like '%" + Data.ComponentDescription + "%'";
                else
                    strWhere += " and ComponentDescription like '%" + Data.ComponentDescription + "%'";


            if (Data.AssemblyID.ToString() != "" && Data.AssemblyID.ToString() != "0" && Data.AssemblyID.ToString() != null && Data.AssemblyID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where AssemblyID=" + Data.AssemblyID.ToString();
                else
                    strWhere += " and AssemblyID =" + Data.AssemblyID.ToString();

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_MNRComponentMaster.Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public List<MyComponent> GetMNRComponentRecord(MyComponent Data)
        {
            DataTable dt = GetMNRComponentRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ListComponent.Add(new MyComponent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ComponentCode = dt.Rows[i]["ComponentCode"].ToString(),
                    ComponentDescription = dt.Rows[i]["ComponentDescription"].ToString(),
                    AssemblyID = Int32.Parse(dt.Rows[i]["AssemblyID"].ToString()),
                    Status = St
                });
            }
            return ListComponent;
        }

        public DataTable GetMNRComponentRecordValues(MyComponent Data)
        {
            string _Query = "select * from NVO_MNRComponentMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #endregion

        #region MNR Tariff

        List<MyMNRTariff> ListTariff = new List<MyMNRTariff>();
        public List<MyMNRTariff> MyMNRTariffMaster(MyMNRTariff Data)
        {
            DataTable dt = GetMNRTariffValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //int St = 0;
                //if (dt.Rows[i]["Status"].ToString() != "")
                //{
                //    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                //}
                //else
                //{
                //    St = 0;
                //}
                ListTariff.Add(new MyMNRTariff
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Vendor = dt.Rows[i]["Vendor"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    DtValidFrom = dt.Rows[i]["DtValidFrom"].ToString(),
                    DtValidTill = dt.Rows[i]["DtValidTill"].ToString(),
                    //Status = St
                });
            }
            return ListTariff;
        }

        public DataTable GetMNRTariffValues(MyMNRTariff Data)
        {
            string strWhere = "";

            string _Query = "select MT.ID,CM.CustomerName As Vendor,DM.DepName As Depot,CYM.CurrencyCode As Currency,replace(convert(NVARCHAR, DtValidFrom, 103), ' ', '-') as DtValidFrom,replace(convert(NVARCHAR, DtValidTill, 103), ' ', '-') as DtValidTill from NVO_MNRTariff MT inner join NVO_CustomerMaster CM ON CM.ID = MT.VendorID inner join NVO_DepotMaster DM ON DM.ID = MT.DepotID inner join NVO_CurrencyMaster CYM ON CYM.ID = MT.CurrencyID ";

            if (Data.DepotID.ToString() != "" && Data.DepotID.ToString() != "0" && Data.DepotID.ToString() != null && Data.DepotID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where MT.DepotID=" + Data.DepotID.ToString();
                else
                    strWhere += " and MT.DepotID =" + Data.DepotID.ToString();

            if (Data.VendorID.ToString() != "" && Data.VendorID.ToString() != "0" && Data.VendorID.ToString() != null && Data.VendorID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where MT.VendorID=" + Data.VendorID.ToString();
                else
                    strWhere += " and MT.VendorID =" + Data.VendorID.ToString();


            //if (Data.Status.ToString() == "1")
            //    if (strWhere == "")
            //        strWhere += _Query + " where NVO_MNRComponentMaster.Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public List<MyMNRTariff> GetVendorValues(MyMNRTariff Data)
        {
            DataTable dt = GetVendorListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTariff.Add(new MyMNRTariff
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Vendor = dt.Rows[i]["CustomerName"].ToString(),

                });
            }
            return ListTariff;
        }

        public DataTable GetVendorListValues(MyMNRTariff Data)
        {
            string _Query = "select * from NVO_CustomerMaster where CustomerType=44";
            return GetViewData(_Query, "");
        }




        public List<MyMNRTariff> InsertMNRTariff(MyMNRTariff Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_MNRTariff where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRTariff              (VendorID,DepotID,CurrencyID,DtValidFrom,DtValidTill,UserID) " +
                                     " values (@VendorID,@DepotID,@CurrencyID,@DtValidFrom,@DtValidTill,@UserID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRTariff SET VendorID=@VendorID,DepotID=@DepotID,CurrencyID=@CurrencyID,DtValidFrom=@DtValidFrom, DtValidTill=@DtValidTill,UserID=@UserID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorID", Data.VendorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", Data.CurrencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtValidFrom", DateTime.ParseExact(Data.DtValidFrom, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtValidTill", DateTime.ParseExact(Data.DtValidTill, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_MNRTariff')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_MNRTariffDtls where TID=@TID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRTariffDtls(TariffID,DamageDescription,DamageID,RepairID,LocationID,ComponentID,Length,Width,LabourHrs,LabourCostx100,MaterialCostx100) " +
                                     " values (@TariffID,@DamageDescription,@DamageID,@RepairID,@LocationID,@ComponentID,@Length,@Width,@LabourHrs,@LabourCostx100,@MaterialCostx100) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRTariffDtls SET TariffID=@TariffID,DamageDescription=@DamageDescription,DamageID=@DamageID,RepairID=@RepairID,LocationID=@LocationID,ComponentID=@ComponentID,Length=@Length," +
                                     "Width=@Width,LabourHrs=@LabourHrs,LabourCostx100=@LabourCostx100,MaterialCostx100=@MaterialCostx100 where TariffID=@TariffID and TID=@TID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageDescription", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ComponentID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Length", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LabourHrs", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LabourCostx100", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MaterialCostx100", CharSplit[10]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    ListTariff.Add(new MyMNRTariff { ID = Data.ID });
                    return ListTariff;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListTariff;
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

        public List<MyMNRTariff> GetMNRTariffValuesData(MyMNRTariff Data)
        {
            DataTable dt = GetMNRTariffListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTariff.Add(new MyMNRTariff
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VendorID = Int32.Parse(dt.Rows[i]["VendorID"].ToString()),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    DtValidFrom = dt.Rows[i]["DtValidFrm"].ToString(),
                    DtValidTill = dt.Rows[i]["DtValidTil"].ToString(),

                });
            }
            return ListTariff;
        }

        public DataTable GetMNRTariffListValues(MyMNRTariff Data)
        {
            string _Query = "select replace(convert(NVARCHAR, DtValidFrom, 103), ' ', '-') as DtValidFrm,replace(convert(NVARCHAR, DtValidTill, 103), ' ', '-') as DtValidTil, * from NVO_MNRTariff where ID=" + Data.ID + "";
            return GetViewData(_Query, "");
        }

        public List<MyMNRTariff> GetMNRTariffDtls(MyMNRTariff Data)
        {
            DataTable dt = GetMNRTariffDtlsValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTariff.Add(new MyMNRTariff
                {

                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    DamageID = Int32.Parse(dt.Rows[i]["DamageID"].ToString()),
                    DamageDescription = dt.Rows[i]["DamageDescription"].ToString(),
                    RepairID = Int32.Parse(dt.Rows[i]["RepairID"].ToString()),
                    LocationID = Int32.Parse(dt.Rows[i]["LocationID"].ToString()),
                    ComponentID = Int32.Parse(dt.Rows[i]["ComponentID"].ToString()),
                    Length = dt.Rows[i]["Length"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    LabourHrs = dt.Rows[i]["LabourHrs"].ToString(),
                    LabourCostx100 = dt.Rows[i]["LabourCostx100"].ToString(),
                    MaterialCostx100 = dt.Rows[i]["MaterialCostx100"].ToString(),
                });
            }
            return ListTariff;
        }

        public DataTable GetMNRTariffDtlsValues(MyMNRTariff Data)
        {
            string _Query = "select * from  NVO_MNRTariffDtls where TariffID=" + Data.ID + "";
            return GetViewData(_Query, "");
        }

        public List<MyMNRTariff> MNRTariffDtlsSearchData(MyMNRTariff Data)
        {
            DataTable dt = GetMNRTariffDtlsSearch(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTariff.Add(new MyMNRTariff
                {

                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    DamageID = Int32.Parse(dt.Rows[i]["DamageID"].ToString()),
                    DamageDescription = dt.Rows[i]["DamageDescription"].ToString(),
                    RepairID = Int32.Parse(dt.Rows[i]["RepairID"].ToString()),
                    LocationID = Int32.Parse(dt.Rows[i]["LocationID"].ToString()),
                    ComponentID = Int32.Parse(dt.Rows[i]["ComponentID"].ToString()),
                    Length = dt.Rows[i]["Length"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    LabourHrs = dt.Rows[i]["LabourHrs"].ToString(),
                    LabourCostx100 = dt.Rows[i]["LabourCostx100"].ToString(),
                    MaterialCostx100 = dt.Rows[i]["MaterialCostx100"].ToString(),
                    //Status = St
                });
            }
            return ListTariff;
        }

        public DataTable GetMNRTariffDtlsSearch(MyMNRTariff Data)
        {
            string strWhere = "";

            string _Query = "select* from  NVO_MNRTariffDtls ";

            if (Data.DamageID.ToString() != "" && Data.DamageID.ToString() != "0" && Data.DamageID.ToString() != null && Data.DamageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where DamageID=" + Data.DamageID.ToString();
                else
                    strWhere += " and DamageID =" + Data.DamageID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        #endregion


        #region MNR CONTAINER Maintainence Repair

        List<MyMNRRepair> ListMNRRepair = new List<MyMNRRepair>();
        public List<MyDamage> GetDepotDropDownByCity(MyDamage Data)
        {
            DataTable dt = GetDepotDropDownByCityValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDamage.Add(new MyDamage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepName = dt.Rows[i]["DepName"].ToString(),

                });
            }
            return ListDamage;
        }

        public DataTable GetDepotDropDownByCityValues(MyDamage Data)
        {
            string _Query = " select * from NVO_DepotMaster where DepCity=" + Data.ID + " order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyComponent> GetMNRStatus(MyComponent Data)
        {
            DataTable dt = GeMNRStatusValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListComponent.Add(new MyComponent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListComponent;
        }

        public DataTable GeMNRStatusValues(MyComponent Data)
        {
            string _Query = "select * from NVO_GeneralMaster where SEQNO=36";
            return GetViewData(_Query, "");
        }

        public List<MyDamage> GetDamageList(MyDamage Data)
        {
            DataTable dt = GetDamageListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDamage.Add(new MyDamage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DamageCode = dt.Rows[i]["DamageCode"].ToString(),

                });
            }
            return ListDamage;
        }

        public DataTable GetDamageListValues(MyDamage Data)
        {
            string _Query = " select * from NVO_MNRDamageMaster order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyRepair> GetRepairList(MyRepair Data)
        {
            DataTable dt = GetRepairListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListRepair.Add(new MyRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RepairCode = dt.Rows[i]["RepairCode"].ToString(),

                });
            }
            return ListRepair;
        }

        public DataTable GetRepairListValues(MyRepair Data)
        {
            string _Query = " select * from NVO_MNRRepairMaster order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyComponent> GetComponentList(MyComponent Data)
        {
            DataTable dt = GetComponentListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListComponent.Add(new MyComponent
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ComponentCode = dt.Rows[i]["ComponentCode"].ToString(),

                });
            }
            return ListComponent;
        }

        public DataTable GetComponentListValues(MyComponent Data)
        {
            string _Query = " select * from NVO_MNRComponentMaster order by ID ";
            return GetViewData(_Query, "");
        }
        public List<MyMNRLoc> GetMNRLocationList(MyMNRLoc Data)
        {
            DataTable dt = GetMNRLocationValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRLoc.Add(new MyMNRLoc
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),

                });
            }
            return ListMNRLoc;
        }

        public DataTable GetMNRLocationValues(MyMNRLoc Data)
        {
            string _Query = " select * from NVO_MNRLocationMaster order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyDamage> GetDamageDescriptionByCode(MyDamage Data)
        {
            DataTable dt = GetDamageDescriptionByCodeList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDamage.Add(new MyDamage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DamageDescription = dt.Rows[i]["DamageDescription"].ToString(),

                });
            }
            return ListDamage;
        }

        public DataTable GetDamageDescriptionByCodeList(MyDamage Data)
        {
            string _Query = " select * from NVO_MNRDamageMaster where ID =" + Data.ID + "";
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> GetBindDLCntrNos(MyMNRRepair Data)
        {
            DataTable dt = GetBindDLCntrNosList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetBindDLCntrNosList(MyMNRRepair Data)
        {
            string _Query = "select C.ID,C.CntrNo from  NVO_Containers C WHERE C.StatusCodE = 'DL' and C.ID NOT In ( select CntrID FROM NVO_MNRCntrRepairReq) ";
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> GetCostTo(MyMNRRepair Data)
        {
            DataTable dt = GetCostToList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CostTo = dt.Rows[i]["CostTo"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetCostToList(MyMNRRepair Data)
        {
            string _Query = "select ID,GeneralName As CostTo from NVO_GeneralMaster where SeqNo=38";
            return GetViewData(_Query, "");
        }
        public List<MyMNRRepair> GetApproveReject(MyMNRRepair Data)
        {
            DataTable dt = GetApproveRejectList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ApproveReject = dt.Rows[i]["ApproveReject"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetApproveRejectList(MyMNRRepair Data)
        {
            string _Query = "select ID,GeneralName As ApproveReject from NVO_GeneralMaster where SeqNo=36 and ID IN (117,119)";
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> GetCurrencyByVendorValues(MyMNRRepair Data)
        {
            DataTable dt = GetCurrencyByVendorValuesList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {


                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetCurrencyByVendorValuesList(MyMNRRepair Data)
        {
            string _Query = "select * from NVO_MNRTariff WHERE VendorID=" + Data.VendorID + "";

            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> GetCntrNoOnChangeValues(MyMNRRepair Data)
        {
            DataTable dt = GetCntrNoOnChangeValuesList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TypeSize = dt.Rows[i]["TypeSize"].ToString(),
                    MtyDate = dt.Rows[i]["MtyDate"].ToString(),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CommodityID = Int32.Parse(dt.Rows[i]["CommodityID"].ToString()),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    LocationID = Int32.Parse(dt.Rows[i]["LocationID"].ToString()),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                });
            }
            return ListMNRRepair;
        }

        public DataTable GetCntrNoOnChangeValuesList(MyMNRRepair Data)
        {
            string _Query = "select Distinct C.ID, TYPE +'-' +SIZE as TypeSize,replace(convert(NVARCHAR, c.DtModified, 103), ' ', '-') as MtyDate, " +
           " isnull((select top 1 PortName from NVO_ContainerTxns CT inner join NVO_PortMaster on NVO_PortMaster.ID = ct.LocationID WHERE CT.ContainerID = C.ID AND  CT.StatusCodE = 'DL' ORDER BY CT.DTMovement desc),'') as Location, " +

        " isnull((select top 1 LocationID from NVO_ContainerTxns CT WHERE CT.ContainerID = C.ID AND  CT.StatusCodE = 'DL' ORDER BY CT.DTMovement desc),0) as LocationID,  isnull((select top 1 DepotID from " +
        "  NVO_ContainerTxns CT WHERE CT.ContainerID = C.ID AND CT.StatusCodE = 'DL' ORDER BY CT.DTMovement desc) ,0)as DepotID, " +
       " isnull((select top 1 DepName from NVO_ContainerTxns CT inner join NVO_DepotMaster on NVO_DepotMaster.ID = ct.DepotID WHERE CT.ContainerID = C.ID AND CT.StatusCodE = 'DL' ORDER BY CT.DTMovement desc) ,'')as Depot," +
     " isnull ((select top 1 NVO_BOOKING.ID FROM NVO_BOOKING INNER JOIN NVO_ContainerTxns CT ON CT.BLNUMBER = NVO_BOOKING.ID where   CT.StatusCode = 'FV' and CT.ContainerID = C.ID order by DtMovement),0) AS BLID, " +
       " isnull  ((select top 1 NVO_BOOKING.BookingNo FROM NVO_BOOKING INNER JOIN NVO_ContainerTxns CT ON CT.BLNUMBER  = NVO_BOOKING.ID where CT.StatusCode = 'FV' AND CT.ContainerID = C.ID  order by DtMovement),0 ) AS BLNumber," +
     " isnull((select top 1 CommodityType from NVO_BOOKING Inner join NVO_BOL on NVO_BOL.BKGID = NVO_BOOKING.ID INNER JOIN NVO_ContainerTxns CT ON CT.BLNUMBER = NVO_BOL.ID where NVO_BOL.ID = CT.BLNUMBER and CT.ContainerID = C.ID),'' ) AS Commodity, isnull((select top 1 CommodityTypeID from NVO_BOOKING Inner join NVO_BOL on NVO_BOL.BKGID = NVO_BOOKING.ID " +
      " INNER JOIN NVO_ContainerTxns CT ON CT.BLNUMBER = NVO_BOOKING.ID where NVO_BOOKING.ID = CT.BLNUMBER and CT.ContainerID  = C.ID) ,0) AS CommodityID from NVO_Containers C  Inner join NVO_tblCntrTypes T ON T.ID = C.TypeID WHERE C.ID =" + Data.ID + " AND C.StatusCodE = 'DL' ";
            return GetViewData(_Query, "");
        }

        public List<MyMNRTariff> GetMNRTariffDtlsValuesByDepot(MyMNRTariff Data)
        {
            DataTable dt = GetMNRTariffDtlsValuesList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTariff.Add(new MyMNRTariff
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Length = dt.Rows[i]["Length"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    LabourCostx100 = dt.Rows[i]["LabourCostx100"].ToString(),
                    LabourHrs = dt.Rows[i]["LabourHrs"].ToString(),
                    MaterialCostx100 = dt.Rows[i]["MaterialCostx100"].ToString(),
                    TotalCost = dt.Rows[i]["TotalCost"].ToString(),
                });
            }
            return ListTariff;
        }

        public DataTable GetMNRTariffDtlsValuesList(MyMNRTariff Data)
        {
            string _Query =
                " select T.ID,TD.Length,TD.Width,TD.LabourHrs,TD.LabourCostx100,TD.MaterialCostx100,TD.LabourCostx100  + TD.MaterialCostx100 AS TotalCost from  NVO_MNRTariff T INNER JOIN NVO_MNRTariffdtls TD ON TD.TariffID = T.ID WHERE T.DepotID =" + Data.DepotID + " and DamageID=" + Data.DamageID + " and RepairID=" + Data.RepairID + "  and ComponentID =" + Data.ComponentID + " and LocationID =" + Data.LocationID + "  and DtValidTill > GETDATE() ";
            return GetViewData(_Query, "");
        }

        public List<MyMNRTariff> CheckMNRTariffValues(MyMNRTariff Data)
        {
            DataTable dt = GetCheckMNRTariff(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTariff.Add(new MyMNRTariff
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                });
            }
            return ListTariff;
        }

        public DataTable GetCheckMNRTariff(MyMNRTariff Data)
        {
            string _Query = " select * from  NVO_MNRTariff WHERE DepotID =" + Data.DepotID + "  and DtValidTill > GETDATE() ";
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> InsertMNRRepairReq(MyMNRRepair Data)
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
                        string AutoGen = GetMaxseqNumber("RepairReqNo", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'CMR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RequestNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReq where ID=@ID)<=0) " +
                           " BEGIN " +
                           " INSERT INTO  NVO_MNRCntrRepairReq              (ReqRefNo,DtRequest,Status,CntrID,CurrID,VendorID,DepotID,RequestedByID,SurveyorID,DtSvrReq,DtSvrComplete,CommodityID,BLID,MovedToAV,ISVendor) " +
                           " values (@ReqRefNo,@DtRequest,@Status,@CntrID,@CurrID,@VendorID,@DepotID,@RequestedByID,@SurveyorID,@DtSvrReq,@DtSvrComplete,@CommodityID,@BLID,@MovedToAV,@ISVendor) " +
                           " END  " +
                           " ELSE " +
                           " UPDATE NVO_MNRCntrRepairReq SET ReqRefNo=@ReqRefNo,DtRequest=@DtRequest,Status=@Status,CntrID=@CntrID, CurrID=@CurrID,VendorID=@VendorID,DepotID=@DepotID,RequestedByID=@RequestedByID,SurveyorID=@SurveyorID,DtSvrReq=@DtSvrReq,DtSvrComplete=@DtSvrComplete,CommodityID=@CommodityID,BLID=@BLID,MovedToAV=@MovedToAV,ISVendor=@ISVendor where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRefNo", Data.RequestNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtRequest", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrID", Data.CurrencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorID", Data.VendorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RequestedByID", Data.RequestedByID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SurveyorID", Data.SurveyorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtSvrReq", Data.DtSvrReq));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtSvrComplete", Data.DtSvrComplete));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", Data.CommodityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MovedToAV", 0));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ISVendor", 0));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_MNRCntrRepairReq')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReqDtls where DID=@DID and RepairReqID=@RepairReqID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRCntrRepairReqDtls(RepairReqID,DamageDescription,DamageTypeID,RepairTypeID,LocCodeID,ComponentID,Measurement,MeasureUnit,LabourHrs,LabourCostx100,MaterialCostx100,TotalCostx100,Qty,TotalLabourCostx100,TotalMatCostx100,EstTotalCostX100,Description) " +
                                     " values (@RepairReqID,@DamageDescription,@DamageTypeID,@RepairTypeID,@LocCodeID,@ComponentID,@Measurement,@MeasureUnit,@LabourHrs,@LabourCostx100,@MaterialCostx100,@TotalCostx100,@Qty,@TotalLabourCostx100,@TotalMatCostx100,@EstTotalCostX100,@Description) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRCntrRepairReqDtls SET RepairReqID=@RepairReqID,DamageDescription=@DamageDescription,DamageTypeID=@DamageTypeID,RepairTypeID=@RepairTypeID,LocCodeID=@LocCodeID,ComponentID=@ComponentID,Measurement=@Measurement," +
                                     "MeasureUnit=@MeasureUnit,LabourHrs=@LabourHrs,LabourCostx100=@LabourCostx100,MaterialCostx100=@MaterialCostx100,TotalCostx100=@TotalCostx100,Qty=@Qty,TotalLabourCostx100=@TotalLabourCostx100,TotalMatCostx100=@TotalMatCostx100,EstTotalCostX100=@EstTotalCostX100,Description=@Description where RepairReqID=@RepairReqID and DID=@DID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairReqID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageDescription", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairTypeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ComponentID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocCodeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Measurement", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MeasureUnit", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LabourHrs", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LabourCostx100", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MaterialCostx100", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalCostx100", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalLabourCostx100", CharSplit[13]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalMatCostx100", CharSplit[14]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EstTotalCostX100", CharSplit[15]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", CharSplit[16]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    Cmd.CommandText = "INSERT INTO NVO_MNRCntrRepAttachments(RepairReqID,AttachTypeID,FileName,UploadedOn,UploadedBy,DepotID) " + " values (@RepairReqID,@AttachTypeID,@FileName,@UploadedOn,@UploadedBy,@DepotID)";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairReqID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachTypeID", Data.AttachTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", Data.FileName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", Data.UploadedBy));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListMNRRepair.Add(new MyMNRRepair { ID = Data.ID });
                    return ListMNRRepair;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRRepair;
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

        public List<MyMNRRepair> MNRRepairReqViewData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRRepairReqViewData(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["ReqRefNo"].ToString(),
                    DtRequest = dt.Rows[i]["DtReq"].ToString(),
                    DtApproved = dt.Rows[i]["DtApprv"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    TypeSize = dt.Rows[i]["TypeSize"].ToString(),
                    RequestedBy = dt.Rows[i]["RequestedBy"].ToString(),
                    MNRStatus = dt.Rows[i]["Status"].ToString(),
                    LabCost = dt.Rows[i]["LabCost"].ToString(),
                    MatCost = dt.Rows[i]["MatCost"].ToString(),
                    EstTotalCost = dt.Rows[i]["EstTotalCost"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRRepairReqViewData(MyMNRRepair Data)
        {
            string strWhere = "";

            string _Query = "Select DISTINCT R.ID,R.ReqRefNo,replace(convert(NVARCHAR, R.DtRequest, 103), ' ', '-') as DtReq,replace(convert(NVARCHAR, R.DtApproved, 103), ' ', '-') as DtApprv, " +
     " (Select top 1 CntrNo from NVO_Containers where ID = R.CntrID ) CntrNo,(Select top 1  TYPE + '-' + SIZE from NVO_tblCntrTypes Inner join NVO_Containers ON NVO_Containers.ID = R.CntrID where NVO_tblCntrTypes.ID = NVO_Containers.TypeID  ) TypeSize, " +
    " (SELECT cast(round(Sum(MaterialCostx100 / 100.00), 2, 0) as decimal(18, 2)) from NVO_MNRCntrRepairReqdtls where RepairReqID = R.ID ) AS MatCost, " +
     " (SELECT cast(round(Sum(TotalLabourCostx100 / 100.00), 2, 0) as decimal(18, 2)) from NVO_MNRCntrRepairReqdtls where RepairReqID = R.ID) AS LabCost, " +
      "  (SELECT cast(round(Sum(MaterialCostx100 / 100.00) + Sum(TotalLabourCostx100 / 100.00), 2, 0) as decimal(18, 2)) from NVO_MNRCntrRepairReqdtls where RepairReqID = R.ID) as EstTotalCost,case when  R.IsVendor=0 then  (select top 1 AgencyName from NVO_AgencyMaster where ID =R.RequestedByID) ELSE (select top 1 CustomerName from NVO_CustomerMaster where ID = R.RequestedByID AND CustomerType = 44) END AS RequestedBy, " +
    " (Select top 1 GeneralName from NVO_GeneralMaster where ID = R.Status) Status from NVO_MNRCntrRepairReq R ";

            if (Data.ReqRefNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where R.ReqRefNo like '%" + Data.ReqRefNo + "%'";
                else
                    strWhere += " and R.ReqRefNo like '%" + Data.ReqRefNo + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where R.Status=" + Data.Status.ToString();
                else
                    strWhere += " and R.Status =" + Data.Status.ToString();

            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where R.CntrID=" + Data.CntrID.ToString();
                else
                    strWhere += " and R.CntrID =" + Data.Status.ToString();

            if (Data.DepotID.ToString() != "" && Data.DepotID.ToString() != "0" && Data.DepotID.ToString() != null && Data.DepotID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where R.DepotID=" + Data.DepotID.ToString();
                else
                    strWhere += " and R.DepotID =" + Data.DepotID.ToString();

            switch (Data.Status.ToString())
            {
                case "120":
                    if (Data.DtFrom != "")
                        strWhere += _Query + " where R.DtRepaired >='" + Data.DtFrom + "'";
                    if (Data.DtTo != "")
                        strWhere += " and R.DtRepaired <='" + Data.DtTo + "'";
                    break;
                case "117":
                case "119":
                    if (Data.DtFrom != "")
                        strWhere += _Query + "where R.DtApproved >='" + Data.DtFrom + "'";
                    if (Data.DtTo != "")
                        strWhere += " and R.DtApproved <='" + Data.DtTo + "'";
                    break;
                default:
                    if (Data.DtFrom != "")
                        strWhere += _Query + " where R.DtRequest >='" + Data.DtFrom + "'";
                    if (Data.DtTo != "")
                        strWhere += " and R.DtRequest <='" + Data.DtTo + "'";
                    break;
            }

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyMNRRepair> MNRRepairReqPreviewGrid1Data(MyMNRRepair Data)
        {
            DataTable dt = GetMNRRepairReqPreviewGrid1(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    Location = dt.Rows[i]["Location"].ToString(),
                    RequestNo = dt.Rows[i]["ReqRefNo"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    TypeSize = dt.Rows[i]["TypeSize"].ToString(),
                    DtRequest = dt.Rows[i]["DtReq"].ToString(),
                    DtModified = dt.Rows[i]["DtMdf"].ToString(),
                    Currency = dt.Rows[i]["CurrencyCode"].ToString(),
                    MNRStatus = dt.Rows[i]["Statusv"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    MovedToAV = dt.Rows[i]["MovedToAV"].ToString(),
                    IsVendor = Int32.Parse(dt.Rows[i]["IsVendor"].ToString()),
                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRRepairReqPreviewGrid1(MyMNRRepair Data)
        {
            string _Query =
                " Select R.ID,R.CntrID,R.ReqRefNo,replace(convert(NVARCHAR, R.DtRequest, 103), ' ', '-') as DtReq,(select top(1) DepName from NVO_DepotMaster where ID = R.DepotID) As Depot," +
                " (select top(1) CityName from NVO_CityMaster inner join NVO_DepotMaster on NVO_DepotMaster.DepCity = NVO_CityMaster.ID where NVO_DepotMaster.ID = C.DepotID) As Location," +
                " C.CntrNo,TYPE + '-' + SIZE as TypeSize,replace(convert(NVARCHAR, c.DtModified, 103), ' ', '-') as DtMdf,  (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = R.CurrID) As CurrencyCode,CASE WHEN R.Status = 118 THEN 'PENDING' WHEN R.Status = 117 THEN 'APPROVED' WHEN R.Status = 119 THEN 'REJECTED' WHEN R.Status = 120 THEN 'REPAIRED' END as Statusv,(select top(1) BLNumber from NVO_BOL where ID = R.BLID) As BLNumber," +
                " (select top(1) GeneralName from NVO_GeneralMaster where ID = R.CommodityID AND SEQNO =2 ) As Commodity,MovedToAV,IsVendor from NVO_MNRCntrRepairReq R  Inner join NVO_Containers C ON C.ID = R.CntrID Inner join NVO_tblCntrTypes T ON T.ID = C.TypeID  where R.ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> MNRRepairReqPreviewCostDtlsData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRRepairReqPreviewCost(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    DID = Int32.Parse(dt.Rows[i]["DID"].ToString()),
                    DamageCode = dt.Rows[i]["DamageCode"].ToString(),
                    DamageID = Int32.Parse(dt.Rows[i]["DamageTypeID"].ToString()),
                    DamageDescription = dt.Rows[i]["DamageDescription"].ToString(),
                    RepairCode = dt.Rows[i]["RepairCode"].ToString(),
                    RepairID = Int32.Parse(dt.Rows[i]["RepairTypeID"].ToString()),
                    ComponentCode = dt.Rows[i]["ComponentCode"].ToString(),
                    ComponentID = Int32.Parse(dt.Rows[i]["ComponentID"].ToString()),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    LocationID = Int32.Parse(dt.Rows[i]["LocCodeID"].ToString()),
                    Measurement = dt.Rows[i]["Measurement"].ToString(),
                    MeasureUnit = dt.Rows[i]["MeasureUnit"].ToString(),
                    LabHrs = dt.Rows[i]["LabourHrs"].ToString(),
                    LabCost = dt.Rows[i]["LabourCostx100"].ToString(),
                    MatCost = dt.Rows[i]["MaterialCostx100"].ToString(),
                    TotalCost = dt.Rows[i]["TotalCostX100"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    TotalLabCost = dt.Rows[i]["TotalLabourCostx100"].ToString(),
                    TotalMatCost = dt.Rows[i]["TotalMatCostx100"].ToString(),
                    EstTotalCost = dt.Rows[i]["EstTotalCostX100"].ToString(),
                    VendorRemarks = dt.Rows[i]["Description"].ToString(),
                    ApprLabHrs = dt.Rows[i]["AppvdLabHr"].ToString(),
                    ApprLabCost = dt.Rows[i]["AppvdLabCostx100"].ToString(),
                    ApprMatCost = dt.Rows[i]["AppvdMaterialCostx100"].ToString(),
                    ApprTotalCost = dt.Rows[i]["TotalAppCostX100"].ToString(),
                    ApprTotalLabCost = dt.Rows[i]["AppvdTotalLabCostx100"].ToString(),
                    ApprTotalMatCost = dt.Rows[i]["AppvdTotalMatCostx100"].ToString(),
                    TotalApprCost = dt.Rows[i]["AppvdTotalCostx100"].ToString(),
                    CostTo = dt.Rows[i]["CostTo"].ToString(),
                    ApproveReject = dt.Rows[i]["ApproveReject"].ToString(),
                    ApproverRemarks = dt.Rows[i]["ApproverRemarks"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRRepairReqPreviewCost(MyMNRRepair Data)
        {
            string _Query =
                " select RD.DID,RD.DamageTypeID, RD.RepairTypeID, RD.ComponentID, RD.LocCodeID, DM.DamageCode,DM.DamageDescription,RM.RepairCode,CM.ComponentCode,LM.LocationCode,rd.Measurement,RD.MeasureUnit,RD.LabourHrs,RD.LabourCostx100,RD.MaterialCostx100,RD.TotalCostX100,RD.Qty,RD.TotalLabourCostx100,RD.TotalMatCostx100,RD.EstTotalCostX100,RD.Description,RD.AppvdLabHr,RD.AppvdLabCostx100,RD.AppvdMaterialCostx100,RD.AppvdTotalLabCostx100,RD.AppvdTotalMatCostx100,RD.TotalAppCostX100,RD.AppvdTotalCostx100,(select top 1 GeneralName from NVO_GeneralMaster where ID =RD.CostToID and SeqNo=38 ) as CostTo, (select top 1 GeneralName from NVO_GeneralMaster where ID = RD.ApprovedRejectedID and SeqNo = 36) as ApproveReject, AppDescription  as ApproverRemarks from  NVO_MNRCntrRepairReqDtls RD Inner join  NVO_MNRDamageMaster DM ON DM.ID = RD.DamageTypeID Inner join  NVO_MNRRepairMaster RM ON RM.ID = RD.RepairTypeID Inner join  NVO_MNRComponentMaster CM ON CM.ID = RD.ComponentID Inner join  NVO_MNRLocationMaster LM ON LM.ID = RD.LocCodeID where RD.RepairReqID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyMNRRepair> InsertMNRAttachments(MyMNRRepair Data)
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

                    Cmd.CommandText = "INSERT INTO  NVO_MNRCntrRepAttachments(RepairReqID,AttachTypeID,FileName,UploadedOn,UploadedBy) " + " values (@RepairReqID,@AttachTypeID,@FileName,@UploadedOn,@UploadedBy)";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairReqID", Data.RepairID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachTypeID", Data.AttachTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", Data.FileName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", Data.UploadedBy));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    return ListMNRRepair;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRRepair;
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

        public List<MyMNRRepair> InsertMNRRepairReqApprovCostDtls(MyMNRRepair Data)
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

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReqDtls where DID=@DID and RepairReqID=@RepairReqID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRCntrRepairReqDtls(RepairReqID,CostToID,ApprovedRejectedID,AppDescription) " +
                                     " values (@RepairReqID,@CostToID,@ApprovedRejectedID,@AppDescription) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRCntrRepairReqDtls SET RepairReqID=@RepairReqID,CostToID=@CostToID,ApprovedRejectedID=@ApprovedRejectedID,AppDescription=@AppDescription where RepairReqID=@RepairReqID and DID=@DID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairReqID", Data.ID));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CostToID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedRejectedID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AppDescription", CharSplit[3]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    ListMNRRepair.Add(new MyMNRRepair { ID = Data.ID });
                    return ListMNRRepair;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRRepair;
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

        public List<MyMNRRepair> MNREstApprTotalViewData(MyMNRRepair Data)
        {
            DataTable dt = GetMNREstApprTotalViewData(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {


                    EstTotalCost = dt.Rows[i]["EstTotalCost"].ToString(),
                    ApprTotalCost = dt.Rows[i]["ApprTotalCost"].ToString(),
                    CostTo = dt.Rows[i]["CostTo"].ToString(),


                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNREstApprTotalViewData(MyMNRRepair Data)
        {
            string _Query = "  Select DISTINCT cast(round(Sum(TotalMatCostx100) + Sum(TotalLabourCostx100), 2, 0) as decimal(18, 2)) as EstTotalCost,cast(round(Sum(AppvdTotalMatCostx100) + Sum(AppvdTotalLabCostx100), 2, 0) as decimal(18, 2)) as ApprTotalCost,(select top 1 GeneralName from NVO_GeneralMaster GM where ID = R.CostToID AND SeqNo = 38) AS CostTo from NVO_MNRCntrRepairReqDtls R WHERE RepairReqID =" + Data.ID + " group BY CostToID ";
            ;
            return GetViewData(_Query, "");
        }
        public List<MyMNRRepair> GetMNRAttachType(MyMNRRepair Data)
        {
            DataTable dt = GetMNRAttachTypeList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    MNRAttachType = dt.Rows[i]["MNRAttachType"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRAttachTypeList(MyMNRRepair Data)
        {
            string _Query = "select ID,GeneralName As MNRAttachType from NVO_GeneralMaster where SeqNo=39 ";
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> GetMNRAttachmentsView(MyMNRRepair Data)
        {
            DataTable dt = GetMNRAttachmentsViewList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["AID"].ToString()),
                    MNRAttachType = dt.Rows[i]["MNRAttachType"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRAttachmentsViewList(MyMNRRepair Data)
        {
            string _Query = "select A.AID,GM.GeneralName as MNRAttachType,A.FileName from NVO_MNRCntrRepAttachments A " +
                " Inner join NVO_GeneralMaster GM ON GM.ID = A.AttachTypeID " +
                " where RepairReqID =" + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> GetMNRApprovedDtlsView(MyMNRRepair Data)
        {
            DataTable dt = GetMNRApprovedDtlsViewList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ApprovalNo = dt.Rows[i]["ApprovalNo"].ToString(),
                    DtApproved = dt.Rows[i]["DtAppr"].ToString(),
                    AppliedAt = dt.Rows[i]["AppliedAt"].ToString(),
                    ApprovedBy = dt.Rows[i]["ApprovedBy"].ToString(),
                    DtRepaired = dt.Rows[i]["DtRep"].ToString(),
                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRApprovedDtlsViewList(MyMNRRepair Data)
        {
            string _Query = "select R.ID,ApprovalNo,replace(convert(NVARCHAR,DtApproved, 103), ' ', '-') as DtAppr,ApprovedAt,CM.UserName as ApprovedBy,VM.CustomerName as AppliedAt,replace(convert(NVARCHAR, DtRepaired, 103), ' ', '-') as DtRep from NVO_MNRCntrRepairReq R left outer join NVO_UserDetails CM on CM.ID = R.ApprovedByID  left outer join NVO_CustomerMaster VM on VM.ID = R.VendorID AND VM.CustomerType = 44 where R.ID = " + Data.ID;

            return GetViewData(_Query, "");
        }

        public DataTable UpdateMNREORConfirmApprDtls(MyMNRRepair Data)
        {

            string _Query = "UPDATE NVO_MNRCntrRepairReqDtls SET AppvdLabHr = " +
                         " LabourHrs,AppvdLabCostx100=LabourCostx100,AppvdMaterialCostx100=MaterialCostx100,AppvdTotalLabCostx100=TotalLabourCostx100,AppvdTotalMatCostx100=TotalMatCostx100,TotalAppCostX100=TotalCostX100,AppvdTotalCostx100=EstTotalCostX100  FROM NVO_MNRCntrRepairReqDtls WHERE NVO_MNRCntrRepairReqDtls.RepairReqID = " + Data.RepairID;
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> UpdateMNRApprove(MyMNRRepair Data)
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

                    string AutoGen = GetMaxseqNumber("MNRApprovalNo", "1", Data.SessionFinYear);
                    Cmd.CommandText = "select 'APP' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                    Data.ApprovalNo = Cmd.ExecuteScalar().ToString();


                    Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReq where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRCntrRepairReq(ApprovalNo,Status,DtApproved,ApprovedAt,ApprovedByID) " +
                                     " values (@ApprovalNo,@Status,@DtApproved,@ApprovedAt,@ApprovedByID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRCntrRepairReq SET ApprovalNo=@ApprovalNo,Status=@Status,DtApproved=@DtApproved,ApprovedAt=@ApprovedAt,ApprovedByID=@ApprovedByID where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovalNo", Data.ApprovalNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 117));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtApproved", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedAt", Data.ApprovedAtID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedByID", Data.ApprovedByID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReqDtls where DID=@DID and RepairReqID=@RepairReqID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRCntrRepairReqDtls(RepairReqID,CostToID,ApprovedRejectedID,AppDescription) " +
                                     " values (@RepairReqID,@CostToID,@ApprovedRejectedID,@AppDescription) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRCntrRepairReqDtls SET RepairReqID=@RepairReqID,CostToID=@CostToID,ApprovedRejectedID=@ApprovedRejectedID,AppDescription=@AppDescription where RepairReqID=@RepairReqID and DID=@DID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairReqID", Data.ID));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CostToID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedRejectedID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AppDescription", CharSplit[3]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    return ListMNRRepair;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRRepair;
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

        public List<MyMNRRepair> MNRApprovedBLCargoDetailsData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRApprovedBLCargoDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    POLCode = dt.Rows[i]["POLCode"].ToString(),
                    PODCode = dt.Rows[i]["PODCode"].ToString(),
                    CargoDescription = dt.Rows[i]["CagoDescription"].ToString(),
                    NoofPackages = dt.Rows[i]["NoofPackages"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    PackageTypes = dt.Rows[i]["PackageTypes"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRApprovedBLCargoDetails(MyMNRRepair Data)
        {
            string _Query =
                "  Select BL.ID, BL.CagoDescription,(Select Top 1 PORTCODE From NVO_PortMaster WHERE ID = BL.POLID) AS POLCode, (Select Top 1 PORTCODE From NVO_PortMaster WHERE ID = BL.PODID) AS PODCode,(Select Top 1 NoOfPkg From NVO_BOLCntrDetails WHERE BLID = BL.ID) AS NoofPackages,  (Select Top 1 GrsWt From NVO_BOLCntrDetails WHERE BLID = BL.ID) AS GrsWt, (Select Top 1 PkgDescription From NVO_CargoPkgMaster CP inner join NVO_BOLCntrDetails on NVO_BOLCntrDetails.PakgType = CP.ID WHERE BLID = BL.ID) AS PackageTypes from NVO_BOL BL inner join NVO_MNRCntrRepairReq on NVO_MNRCntrRepairReq.BLID = BL.ID where NVO_MNRCntrRepairReq.ID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> MNRSurveyorViewData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRSurveyorViewData(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DtSvrReq = dt.Rows[i]["DtSvReq"].ToString(),
                    DtSvrComplete = dt.Rows[i]["DtSvrComp"].ToString(),
                    Surveyor = dt.Rows[i]["Surveyor"].ToString(),
                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRSurveyorViewData(MyMNRRepair Data)
        {
            string _Query =
                " Select R.ID,replace(convert(NVARCHAR, R.DtSvrReq, 103), ' ', '-')  as DtSvReq,replace(convert(NVARCHAR, R.DtSvrComplete, 103), ' ', '-')  as DtSvrComp ," +
                " (select top(1) CustomerName from NVO_CustomerMaster where ID = R.SurveyorID) As Surveyor  from NVO_MNRCntrRepairReq R where R.ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> MNRCntrRepairHistoryDetailsData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRCntrRepairHistoryDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ReqRefNo = dt.Rows[i]["ReqRefNo"].ToString(),
                    DtApproved = dt.Rows[i]["DtAppr"].ToString(),
                    ApprovalNo = dt.Rows[i]["ApprovalNo"].ToString(),
                    ApprovedAt = dt.Rows[i]["ApprovedAt"].ToString(),
                    Vendor = dt.Rows[i]["Vendor"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    ApprovedBy = dt.Rows[i]["ApprovedBy"].ToString(),
                    ApprTotalCost = dt.Rows[i]["ApprTotalCost"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRCntrRepairHistoryDetails(MyMNRRepair Data)
        {
            string _Query =
                "    Select ID,ReqRefNo,ApprovalNo,replace(convert(NVARCHAR, DtApproved, 103), ' ', '-')  as DtAppr, (select top 1 Depname from NVO_DepotMaster where ID = DepotID) As Depot,(select top 1 AgencyName from NVO_AgencyMaster where ID = ApprovedAt) As ApprovedAt,(select top 1 CustomerName from NVO_CustomerMaster where ID = RequestedByID) As Vendor, (select top 1 UserName from NVO_UserDetails where ID = ApprovedByID) As ApprovedBy,   (select top 1 cast(round(Sum(AppvdTotalMatCostx100) + Sum(AppvdTotalLabCostx100), 2, 0) as decimal(18, 2)) from  NVO_MNRCntrRepairReqDtls where RepairReqID = ID) AS ApprTotalCost from NVO_MNRCntrRepairReq where CntrID = " + Data.CntrID;
            return GetViewData(_Query, "");
        }
        public List<MyMNRRepair> MNRCntrCurrentStatusViewData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRCntrCurrentStatusDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    DtModified = dt.Rows[i]["DtModified"].ToString(),

                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRCntrCurrentStatusDtls(MyMNRRepair Data)
        {
            string _Query = " select ID,StatusCode,DtModified from   NVO_Containers WHERE ID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> MNRDashBoardCountData(MyMNRRepair Data)
        {
            DataTable dt = GetMNRDashBoardCountData(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListMNRRepair.Add(new MyMNRRepair
                {

                    EORCntrs = dt.Rows[i]["EORCntrs"].ToString(),
                    Repaired = dt.Rows[i]["Repaired"].ToString(),
                    Approved = dt.Rows[i]["Approved"].ToString(),
                    OpenedEOR = dt.Rows[i]["OpenedEOR"].ToString(),
                    Rejected = dt.Rows[i]["Rejected"].ToString(),
                });
            }
            return ListMNRRepair;
        }

        public DataTable GetMNRDashBoardCountData(MyMNRRepair Data)
        {
            string _Query = " Select   DISTINCT (select count(CntrNO) from NVO_Containers WHERE StatusCode = 'DL' and ID not in (Select CntrID from NVO_MNRCntrRepairReq)) as EORCntrs, (select count(ReqRefNo) from NVO_MNRCntrRepairReq where Status = 120 and MovedToAV <> 1) as Repaired, (select count(ReqRefNo) from NVO_MNRCntrRepairReq where Status = 117) as Approved, (select count(ReqRefNo) from NVO_MNRCntrRepairReq where Status = 118 ) as OpenedEOR, (select count(ReqRefNo) from NVO_MNRCntrRepairReq where Status = 119) as Rejected FROM NVO_MNRCntrRepairReq ";
            return GetViewData(_Query, "");
        }

        public List<MyMNRRepair> UpdateMNRStatusChangeToAV(MyMNRRepair Data)
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
                    Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReq where ID=@ID)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_MNRCntrRepairReq(MovedToAV) " +
                                   " values (@MovedToAV) " +
                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_MNRCntrRepairReq SET MovedToAV=@MovedToAV where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MovedToAV", 1));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    string NewTxnsID = "0";

                    Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                    NewTxnsID = Cmd.ExecuteScalar().ToString();


                    Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,StatusCode,DtMovement,DepotID,VendorID,LocationID,AgencyID) " +
                                 " values (@ContainerID,@StatusCode,@DtMovement,@DepotID,@VendorID,@LocationID,@AgencyID) ";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorID", Data.VendorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.ExecuteNonQuery();


                    Cmd.CommandText = "Update NVO_Containers set StatusCode=@StatusCode,LastMoveMentID=@LastMoveMentID,DtModified=@DtModified,DepotID=@DepotID where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", DateTime.Parse(Data.DtMovement).ToString("yyyy-MM-dd h:mm tt")));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    return ListMNRRepair;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRRepair;
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
        public List<MyMNRRepair> UpdateMNRRepair(MyMNRRepair Data)
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


                    Cmd.CommandText = " IF((select count(*) from NVO_MNRCntrRepairReq where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MNRCntrRepairReq(Status,DtRepaired) " +
                                     " values (@Status,@DtRepaired) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MNRCntrRepairReq SET Status=@Status,DtRepaired=@DtRepaired where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 120));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtRepaired", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    string NewTxnsID = "0";

                    Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                    NewTxnsID = Cmd.ExecuteScalar().ToString();


                    Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,StatusCode,DtMovement,DepotID,VendorID,LocationID,AgencyID) " +
                                 " values (@ContainerID,@StatusCode,@DtMovement,@DepotID,@VendorID,@LocationID,@AgencyID) ";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorID", Data.VendorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.ExecuteNonQuery();


                    Cmd.CommandText = "Update NVO_Containers set StatusCode=@StatusCode,LastMoveMentID=@LastMoveMentID,DtModified=@DtModified,DepotID=@DepotID where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CntrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();



                    trans.Commit();
                    return ListMNRRepair;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListMNRRepair;
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
        #endregion

        #region SEQNO
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



        #endregion
    }
}

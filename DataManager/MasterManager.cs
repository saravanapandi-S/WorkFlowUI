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
    public class MasterManager
    {
        List<MyCountry> ListCountry = new List<MyCountry>();
        List<MyCurrency> ListCurrency = new List<MyCurrency>();
        List<MyDepot> ListDepot = new List<MyDepot>();
        List<MyTerminal> ListTerminal = new List<MyTerminal>();
        List<MyPort> ListPortv = new List<MyPort>();
        List<MyState> ListStatev = new List<MyState>();

        List<MyCity> ListCity = new List<MyCity>();
        List<countryDD> ListCtry = new List<countryDD>();
        List<MyPort> ListPort = new List<MyPort>();
        List<MyCargo> ListCargo = new List<MyCargo>();
        List<MyCommodity> ListCommodity = new List<MyCommodity>();
        List<MyExRate> ListExRate = new List<MyExRate>();
        List<CurrencyDD> ListCurr = new List<CurrencyDD>();
        List<cityDD> ListCityloc = new List<cityDD>();
        List<StateDD> ListState = new List<StateDD>();
        List<MyVessel> ListVessel = new List<MyVessel>();
        List<MyVoyage> ListVoyage = new List<MyVoyage>();
        List<MyVoyageDetails> ListVoyageDtls = new List<MyVoyageDetails>();
        List<MyNotes> ListNotes = new List<MyNotes>();
        List<MyServiceSetup> ListService = new List<MyServiceSetup>();
        List<MyVoyageDetails> ListVoyNotes = new List<MyVoyageDetails>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public MasterManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region anand
        #region Country Master
        public List<MyCountry> GetCountryMaster(MyCountry Data)
        {
            DataTable dt = GetCountryValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCountry.Add(new MyCountry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryCode = dt.Rows[i]["CountryCode"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString()
                });

            }
            return ListCountry;
        }
        public List<MyCountry> GetCountryMasterRecord(MyCountry Data)
        {
            DataTable dt = GetCountryRecord(Data);

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
                ListCountry.Add(new MyCountry
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryCode = dt.Rows[i]["CountryCode"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    Status = St
                });
            }


            return ListCountry;
        }
        public List<MyCountry> InsertCountryMaster(MyCountry Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetCountryExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["CountryCode"].ToString().ToUpper() == Data.CountryCode.ToUpper() && dtchk.Rows[0]["CountryName"].ToString().ToUpper() == Data.CountryName.ToUpper())
                    {
                        ListCountry.Add(new MyCountry
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Country Code/Name Already Exists"
                        });
                        return ListCountry;
                    }
                    if (dtchk.Rows[0]["CountryCode"].ToString().ToUpper() == Data.CountryCode.ToUpper())
                    {
                        ListCountry.Add(new MyCountry
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Country Code Already Exists"
                        });
                        return ListCountry;
                    }
                    if (dtchk.Rows[0]["CountryName"].ToString().ToUpper() == Data.CountryName.ToUpper())
                    {
                        ListCountry.Add(new MyCountry
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Country Name Already Exists"
                        });
                        return ListCountry;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.CountryMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.CountryMaster(CountryCode,CountryName,Status) " +
                                     " values (@CountryCode,@CountryName,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.CountryMaster SET CountryCode=@CountryCode,CountryName=@CountryName,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryCode", Data.CountryCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryName", Data.CountryName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.CountryMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListCountry.Add(new MyCountry
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCountry;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCountry.Add(new MyCountry
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListCountry;
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

        public DataTable GetCountryExValues(MyCountry Data)
        {
            //string _Query = "select * from NVO_CountryMaster where CountryCode='" + Data.CountryCode + "' OR CountryName='" + Data.CountryName + "';
            //return GetViewData(_Query, "");

            string _Query = "select * from SA.CountryMaster where (ID not in(" + Data.ID + ")) and (CountryCode='" + Data.CountryCode + "' OR CountryName='" + Data.CountryName + "')";
            return GetViewData(_Query, "");
        }
        public DataTable GetCountryValues(MyCountry Data)
        {
            string strWhere = "";

            string _Query = " select case when Status=1 then 'Yes' else case when Status=2 then 'No' end end as StatusV, * from SA.CountryMaster";

            if (Data.CountryCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where CountryCode like '%" + Data.CountryCode + "%'";
                else
                    strWhere += " and CountryCode like '%" + Data.CountryCode + "%'";

            if (Data.CountryName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CountryName like '%" + Data.CountryName + "%'";
                else
                    strWhere += " and CountryName like '%" + Data.CountryName + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();
                else
                    strWhere += " and Status =" + Data.Status.ToString();



            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public DataTable GetCountryRecord(MyCountry Data)
        {
            string _Query = "Select * from SA.CountryMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCountry> GetCommonCountryMaster()
        {
            DataTable dt = GetCommonCountryValues();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCountry.Add(new MyCountry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),

                });

            }
            return ListCountry;
        }

        public DataTable GetCommonCountryValues()
        {

            string _Query = "Select * from SA.CountryMaster";
            return GetViewData(_Query, "");
        }
        #endregion


        #region Depot Master
        public List<MyDepot> InsertDepotMaster(MyDepot Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_DepotMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_DepotMaster(DepName,DepAddress,DepCountry,DepCity,Status) " +
                                     " values (@DepName,@DepAddress,@DepCountry,@DepCity,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_DepotMaster SET DepName=@DepName,DepAddress=@DepAddress,DepCountry=@DepCountry,DepCity=@DepCity,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepName", Data.DepName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepAddress", Data.DepAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepCountry", Data.DepCountry));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepCity", Data.DepCity));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_DepotMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_DepotMasterPortDtls where DepotID=@DepotID and PID=@PID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_DepotMasterPortDtls(PortID,Port,DepotID) " +
                                     " values (@PortID,@Port,@DepotID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_DepotMasterPortDtls SET PortID=@PortID,Port=@Port,DepotID=@DepotID where DepotID=@DepotID and PID=@PID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Port", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.ID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListDepot.Add(new MyDepot { ID = Data.ID });

                    return ListDepot;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListDepot;
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

        public List<MyDepot> GetDepotMaster(MyDepot Data)
        {
            DataTable dt = GetDepotSearchValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDepot.Add(new MyDepot
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepName = dt.Rows[i]["DepName"].ToString(),
                    DepCountryName = dt.Rows[i]["CountryV"].ToString(),
                    DepCityName = dt.Rows[i]["CityV"].ToString(),
                    StatusName = dt.Rows[i]["StatusV"].ToString()
                });


            }
            return ListDepot;


        }

        public List<MyDepot> GetDepotMasterRecord(MyDepot Data)
        {
            DataTable dt = GetDepotMasterRecordValues(Data);

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
                ListDepot.Add(new MyDepot
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepName = dt.Rows[i]["DepName"].ToString(),
                    DepAddress = dt.Rows[i]["DepAddress"].ToString(),
                    DepCountry = Int32.Parse(dt.Rows[i]["DepCountry"].ToString()),
                    DepCity = Int32.Parse(dt.Rows[i]["DepCity"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }


            return ListDepot;
        }
        public DataTable GetDepotMasterRecordValues(MyDepot Data)
        {
            string _Query = "select *  from NVO_DepotMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyDepot> GetDepoMasterPortDtls(MyDepot Data)
        {
            DataTable dt = GetDepoMasterPortRec(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListDepot.Add(new MyDepot
                {

                    PID = Int32.Parse(dt.Rows[i]["PID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString()

                });
            }


            return ListDepot;
        }
        public DataTable GetDepoMasterPortRec(MyDepot Data)
        {
            string _Query = "select *  from NVO_DepotMasterPortDtls where DepotID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyDepot> DepotApplicablePortDelete(MyDepot Data)
        {
            DataTable dt = DeleteApplicablePortValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDepot.Add(new MyDepot
                {
                    PID = Int32.Parse(dt.Rows[i]["PID"].ToString()),

                });

            }
            return ListDepot;
        }
        public DataTable DeleteApplicablePortValues(MyDepot Data)
        {

            string _Query = "Delete FROM NVO_DepotMasterPortDtls where PID=" + Data.PID;


            return GetViewData(_Query, "");
        }
        public DataTable GetDepotSearchValues(MyDepot Data)
        {
            string strWhere = "";

            string _Query = " Select ID,DepName,(select CountryName from NVO_CountryMaster where ID= DepCountry) as CountryV, " +
                            " (select CityName from NVO_CityMaster where ID = DepCity) as CityV, " +
                            " Case when Status =1 then 'Active' else 'InActive' end as StatusV " +
                            " from NVO_DepotMaster";

            if (Data.DepName != "")
                if (strWhere == "")
                    strWhere += _Query + " where DepName like '%" + Data.DepName + "%'";
                else
                    strWhere += " and DepName like '%" + Data.DepName + "%'";

            if (Data.DepCountry.ToString() != "" && Data.DepCountry.ToString() != "0" && Data.DepCountry.ToString() != null && Data.DepCountry.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where DepCountry = " + Data.DepCountry.ToString();
                else
                    strWhere += " and DepCountry = " + Data.DepCountry.ToString();

            if (Data.DepCity.ToString() != "" && Data.DepCity.ToString() != "0" && Data.DepCity.ToString() != null && Data.DepCity.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where DepCity = " + Data.DepCity.ToString();
                else
                    strWhere += " and DepCity = " + Data.DepCity.ToString();

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Status = " + Data.Status.ToString();
                else
                    strWhere += " and Status = " + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyDepot> GetPortByCountry(string id)
        {
            DataTable dt = GetPortByCountryValues(id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDepot.Add(new MyDepot
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString(),

                });

            }
            return ListDepot;
        }

        public DataTable GetPortByCountryValues(string id)
        {

            string _Query = "Select * from NVO_PortMaster where CountryID=" + id;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Terminal Master
        public List<MyTerminal> InsertTerminalMaster(MyTerminal Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            DataTable dtchk = GetTerminalExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["TerminalCode"].ToString().ToUpper() == Data.TerminalCode.ToUpper() && dtchk.Rows[0]["TerminalName"].ToString().ToUpper() == Data.TerminalName.ToUpper())
                    {
                        ListTerminal.Add(new MyTerminal
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Terminal Code/Name Already Exists"
                        });
                        return ListTerminal;
                    }
                    if (dtchk.Rows[0]["TerminalCode"].ToString().ToUpper() == Data.TerminalCode.ToUpper())
                    {
                        ListTerminal.Add(new MyTerminal
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Terminal Code Already Exists"
                        });
                        return ListTerminal;
                    }
                    if (dtchk.Rows[0]["TerminalName"].ToString().ToUpper() == Data.TerminalName.ToUpper())
                    {
                        ListTerminal.Add(new MyTerminal
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Terminal Name Already Exists"
                        });
                        return ListTerminal;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.TerminalMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.TerminalMaster(TerminalCode,TerminalName,PortID,Status) " +
                                     " values (@TerminalCode,@TerminalName,@PortID,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.TerminalMaster SET TerminalCode=@TerminalCode,TerminalName=@TerminalName,PortID=@PortID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalCode", Data.TerminalCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalName", Data.TerminalName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.TerminalMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    ListTerminal.Add(new MyTerminal
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListTerminal;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListTerminal.Add(new MyTerminal
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListTerminal;
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


        public DataTable GetTerminalExValues(MyTerminal Data)
        {
            string _Query = "select * from SA.TerminalMaster where (ID not in(" + Data.ID + ")) and (TerminalCode ='" + Data.TerminalCode + "' OR TerminalName='" + Data.TerminalName + "')";
            return GetViewData(_Query, "");
        }
        public List<MyPort> GetCommonPortMaster()
        {
            DataTable dt = GetCommonPortValues();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPortv.Add(new MyPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                });

            }
            return ListPortv;
        }

        public DataTable GetCommonPortValues()
        {
            string _Query = "select ID, PortCode   +'-' +  PortName as PortName from SA.PortMaster order by PortCode asc";
            return GetViewData(_Query, "");
        }
        public List<MyTerminal> GetTerminalMaster(MyTerminal Data)
        {
            DataTable dt = GetTerminalSearchValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTerminal.Add(new MyTerminal
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalCode = dt.Rows[i]["TerminalCode"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    PortName = dt.Rows[i]["PortV"].ToString(),
                    StatusName = dt.Rows[i]["StatusV"].ToString()
                });


            }
            return ListTerminal;


        }

        public List<MyTerminal> GetTerminalMasterRecord(MyTerminal Data)
        {
            DataTable dt = GetTerminalMasterRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListTerminal.Add(new MyTerminal
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalCode = dt.Rows[i]["TerminalCode"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }


            return ListTerminal;
        }
        public DataTable GetTerminalMasterRecordValues(MyTerminal Data)
        {
            string _Query = "select *  from SA.TerminalMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public DataTable GetTerminalSearchValues(MyTerminal Data)
        {
            string strWhere = "";

            string _Query = " select SA.TerminalMaster.ID, TerminalCode, TerminalName,PortName,(select PortCode   +'-' +  PortName from SA.PortMaster where ID = PortID)as PortV, " +
                            " Case when SA.TerminalMaster.Status = 1 then 'YES' else  'NO' end as StatusV from SA.TerminalMaster" +
                            " inner join SA.portmaster on  SA.portmaster.ID= SA.TerminalMaster.PortID";

            if (Data.TerminalCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where TerminalCode like '%" + Data.TerminalCode + "%'";
                else
                    strWhere += " and TerminalCode like '%" + Data.TerminalCode + "%'";

            if (Data.TerminalName != "")
                if (strWhere == "")
                    strWhere += _Query + " where TerminalName like '%" + Data.TerminalName + "%'";
                else
                    strWhere += " and TerminalName like '%" + Data.TerminalName + "%'";

            if (Data.PortName != "")
                if (strWhere == "")
                    strWhere += _Query + " where PortCode   +'-' +  PortName like '%" + Data.PortName + "%'";
                else
                    strWhere += " and PortCode   +'-' +  PortName like '%" + Data.PortName + "%'";



            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " Where SA.TerminalMaster.Status =" + Data.Status.ToString();
                else
                    strWhere += " and SA.TerminalMaster.Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public List<MyTerminal> GetTerminalDropDownMaster(MyTerminal Data)
        {
            DataTable dt = GetTerminalDropDownValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListTerminal.Add(new MyTerminal
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString()
                });
            }
            return ListTerminal;
        }
        public DataTable GetTerminalDropDownValues(MyTerminal Data)
        {
            string _Query = "select *  from SA.TerminalMaster where PortID=" + Data.ID + "";
            return GetViewData(_Query, "");
        }
        #endregion

        #region City Master
        public List<MyCity> GetCommonCityMaster(MyCity Data)
        {
            DataTable dt = GetCommonCityValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCity.Add(new MyCity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString(),

                });

            }
            return ListCity;
        }
        public DataTable GetCommonCityValues(MyCity Data)
        {

            string _Query = "Select * from NVO_CityMaster";
            return GetViewData(_Query, "");
        }
        #endregion

        #region State Master
        public List<MyState> GetStateMaster(MyState Data)
        {
            DataTable dt = GetStateValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStatev.Add(new MyState
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateCode = dt.Rows[i]["StateCode"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                });

            }
            return ListStatev;
        }
        public List<MyState> GetStateMasterRecord(MyState Data)
        {
            DataTable dt = GetStateRecord(Data);

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
                ListStatev.Add(new MyState
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateCode = dt.Rows[i]["StateCode"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),

                });
            }


            return ListStatev;
        }
        public List<MyState> InsertStateMaster(MyState Data)
        {

            DbConnection con = null;
            DbTransaction trans;

            DataTable dtchk = GetStateExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["StateCode"].ToString().ToUpper() == Data.StateCode.ToUpper() && dtchk.Rows[0]["StateName"].ToString().ToUpper() == Data.StateName.ToUpper())
                    {
                        ListStatev.Add(new MyState
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "State Code/Name Already Exists"
                        });
                        return ListStatev;
                    }
                    if (dtchk.Rows[0]["StateCode"].ToString().ToUpper() == Data.StateCode.ToUpper())
                    {
                        ListStatev.Add(new MyState
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "State Code Already Exists"
                        });
                        return ListStatev;
                    }
                    if (dtchk.Rows[0]["StateName"].ToString().ToUpper() == Data.StateName.ToUpper())
                    {
                        ListStatev.Add(new MyState
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "State Name Already Exists"
                        });
                        return ListStatev;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.StateMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.StateMaster(StateCode,StateName,Status,CountryID) " +
                                     " values (@StateCode,@StateName,@Status,@CountryID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.StateMaster SET StateCode=@StateCode,StateName=@StateName,Status=@Status,CountryID=@CountryID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateCode", Data.StateCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateName", Data.StateName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.StateMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListStatev.Add(new MyState
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListStatev;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListStatev.Add(new MyState
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListStatev;
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

        public DataTable GetStateExValues(MyState Data)
        {
            string _Query = "select * from SA.StateMaster where (ID not in(" + Data.ID + ")) and (StateCode='" + Data.StateCode + "' OR StateName='" + Data.StateName + "') and CountryID="+Data.CountryID;
            return GetViewData(_Query, "");
        }
        public DataTable GetStateValues(MyState Data)
        {
            string strWhere = "";

            string _Query = " select SA.StateMaster.Id,StateCode,StateName,SA.StateMaster.status, (select top 1 CountryName from SA.CountryMaster WHERE id = SA.StateMaster.countryid) as Country,CountryName, " +
                            " case when SA.StateMaster.status = 1 then 'Yes' when SA.StateMaster.status = 2 then 'No' ELSE '' END as StatusResult  from SA.StateMaster " +
                            " inner join SA.CountryMaster on SA.CountryMaster.ID = SA.StateMaster.CountryID";

            //string _Query = " select NVO_CountryMaster.Id,StateCode,StateName,status, (select top 1 CountryName from NVO_CountryMaster WHERE id = NVO_StateMaster.countryid) as Country,CountryName" +
            //    " case when status = 1 then 'Active' when status = 2 then 'Inactive' ELSE '' END as StatusResult  from NVO_StateMaster inner join  NVO_CountryMaster on NVO_CountryMaster.ID= NVO_StateMaster.CountryID";


            //string _Query = " select * from NVO_StateMaster";

            if (Data.Country != "")
                if (strWhere == "")
                    strWhere += _Query + " where SA.CountryMaster.CountryName like '%" + Data.Country + "%'";
                else
                    strWhere += " and SA.CountryMaster.CountryName like '%" + Data.Country + "%'";

            if (Data.StateCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where StateCode like '%" + Data.StateCode + "%'";
                else
                    strWhere += " and StateCode like '%" + Data.StateCode + "%'";

            if (Data.StateName != "")
                if (strWhere == "")
                    strWhere += _Query + " where StateName like '%" + Data.StateName + "%'";
                else
                    strWhere += " and StateName like '%" + Data.StateName + "%'";


            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where SA.StateMaster.Status = " + Data.Status.ToString();
                else
                    strWhere += " and SA.StateMaster.Status = " + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public DataTable GetStateRecord(MyState Data)
        {
            string _Query = "Select * from SA.StateMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyState> GetCommonStateMaster(MyState Data)
        {
            DataTable dt = GetCommonStateValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStatev.Add(new MyState
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString(),

                });

            }
            return ListStatev;
        }

        public DataTable GetCommonStateValues(MyState Data)
        {

            string _Query = " Select * from SA.StateMaster ";
            return GetViewData(_Query, "");
        }


        #endregion

        #region Vessel Master
        public List<MyVessel> InsertVesselMaster(MyVessel Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetVesselExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    if (dtchk.Rows[0]["VesselName"].ToString().ToUpper() == Data.VesselName.ToUpper())
                    {
                        ListVessel.Add(new MyVessel
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "VesselName Already Exists"
                        });
                        return ListVessel;
                    }


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

                    Cmd.CommandText = " IF((select count(*) from NVO_VesselMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VesselMaster(VesselName,VesselCallSign,IMONumber,MMSI,Flag,VesselID,VesselOwner,CurrentDate,Status) " +
                                     " values (@VesselName,@VesselCallSign,@IMONumber,@MMSI,@Flag,@VesselID,@VesselOwner,@CurrentDate,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VesselMaster SET VesselName=@VesselName,VesselCallSign=@VesselCallSign,IMONumber=@IMONumber,MMSI=@MMSI,Flag=@Flag,VesselID=@VesselID,VesselOwner=@VesselOwner,CurrentDate=@CurrentDate,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselCallSign", Data.VesselCallSign));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselName", Data.VesselName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IMONumber", Data.IMONumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MMSI", Data.MMSI));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Flag", Data.Flag));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselOwner", Data.VesselOwner.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_VesselMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListVessel.Add(new MyVessel
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListVessel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListVessel.Add(new MyVessel
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListVessel;
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

        public DataTable GetVesselExValues(MyVessel Data)
        {

            string _Query = "select * from NVO_VesselMaster where (ID not in(" + Data.ID + ")) and (VesselName='" + Data.VesselName + "')";
            return GetViewData(_Query, "");
        }
        public List<MyVessel> GetVesselMaster(MyVessel Data)
        {
            DataTable dt = GetVesselValues(Data);

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
                ListVessel.Add(new MyVessel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Status = St

                });

            }
            return ListVessel;
        }
        public List<MyVessel> GetVesselMasterRecord(MyVessel Data)
        {
            DataTable dt = GetVesselRecord(Data);

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
                ListVessel.Add(new MyVessel
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    //VesselCode = dt.Rows[i]["VesselCode"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VesselCallSign = dt.Rows[i]["VesselCallSign"].ToString(),
                    IMONumber = dt.Rows[i]["IMONumber"].ToString(),
                    MMSI = dt.Rows[i]["MMSI"].ToString(),
                    Flag = dt.Rows[i]["Flag"].ToString(),
                    VesselID = dt.Rows[i]["VesselID"].ToString(),
                    VesselOwner = dt.Rows[i]["VesselOwner"].ToString(),
                    Status = St

                });
            }


            return ListVessel;
        }

        public DataTable GetVesselValues(MyVessel Data)
        {
            string strWhere = "";

            string _Query = " select ID,VesselName,Status, " +
                " case when status = 1 then 'Active' when status = 2 then 'Inactive' ELSE '' END as StatusResult from NVO_VesselMaster ";



            if (Data.VesselName != "")
                if (strWhere == "")
                    strWhere += _Query + " where VesselName like '%" + Data.VesselName + "%'";
                else
                    strWhere += " and VesselName like '%" + Data.VesselName + "%'";


            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " Where NVO_VesselMaster.Status =" + Data.Status.ToString();
                else
                    strWhere += " and NVO_VesselMaster.Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        public DataTable GetVesselRecord(MyVessel Data)
        {
            string _Query = "Select * from NVO_VesselMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyVessel> GetVesselMasterDropDown(MyVessel Data)
        {
            DataTable dt = GetVesselDropDownValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVessel.Add(new MyVessel
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString()

                });
            }


            return ListVessel;
        }
        public DataTable GetVesselDropDownValues(MyVessel Data)
        {
            string _Query = "Select ID,VesselName from NVO_VesselMaster";
            return GetViewData(_Query, "");
        }
        #endregion

        #region Voyage Master

        public List<MyVoyage> InsertVoyageMaster(MyVoyage Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_VoyageMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageMaster(VesID,Voyage,RotationNo,Status,CurrentDate) " +
                                     " values (@VesID,@Voyage,@RotationNo,@Status,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageMaster SET VesID=@VesID,Voyage=@Voyage,RotationNo=@RotationNo,Status=@Status,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesID", Data.VesID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Voyage", Data.Voyage));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RotationNo", Data.RotationNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_VoyageMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListVoyage;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyage;
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

        public List<MyVoyageDetails> InsertVoyageDetails(MyVoyageDetails Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_VoyageDetails where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageDetails(VesID,VoyageNo,RotationNo,ETA,ETD,ATA,ATD,CutOff,CurrentPortID,LoadingTerminalID,SCNNo,Remarks,Status,FinalPortID) " +
                                     " values (@VesID,@VoyageNo,@RotationNo,@ETA,@ETD,@ATA,@ATD,@CutOff,@CurrentPortID,@LoadingTerminalID,@SCNNo,@Remarks,@Status,@FinalPortID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageDetails SET VesID=@VesID,VoyageNo=@VoyageNo,RotationNo=@RotationNo,ETA=@ETA,ETD=@ETD,ATA=@ATA,ATD=@ATD,CutOff=@CutOff,CurrentPortID=@CurrentPortID,LoadingTerminalID=@LoadingTerminalID,SCNNo=@SCNNo,Remarks=@Remarks,Status=@Status,FinalPortID=@FinalPortID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesID", Data.VesVID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageNo", Data.VoyageNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RotationNo", Data.RotationNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA",
                        DateTime.ParseExact(Data.ETA, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", DateTime.ParseExact(Data.ETD, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ATA", DateTime.ParseExact(Data.ATA, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ATD", DateTime.ParseExact(Data.ATD, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CutOff", DateTime.ParseExact(Data.CutOff, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.CurrentPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadingTerminalID", Data.LoadingTerminalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SCNNo", Data.SCNNo));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date.ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FinalPortID", Data.FinalPortID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_VoyageDetails')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_VoyPortDtls where VoydtID=@VoydtID and VID=@VID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyPortDtls(VoydtID,VesOperatorID,VesOperator,NextPortID,NextPort,TerminalID,Terminal,NextPortETA) " +
                                     " values (@VoydtID,@VesOperatorID,@VesOperator,@NextPortID,@NextPort,@TerminalID,@Terminal,@NextPortETA) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyPortDtls SET VoydtID=@VoydtID,VesOperatorID=@VesOperatorID,VesOperator=@VesOperator,NextPortID=@NextPortID,NextPort=@NextPort,TerminalID=@TerminalID,Terminal=@Terminal,NextPortETA=@NextPortETA where VoydtID=@VoydtID and VID=@VID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesOperatorID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesOperator", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPort", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Terminal", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortETA",
                            DateTime.ParseExact(CharSplit[7], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoydtID", Data.ID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date.ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListVoyageDtls.Add(new MyVoyageDetails { ID = Data.ID });
                    return ListVoyageDtls;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyageDtls;
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
        public List<MyVoyage> GetVoyageMaster(MyVoyage Data)
        {
            DataTable dt = GetVoyageMasterValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new MyVoyage
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString()
                });

            }
            return ListVoyage;
        }
        public DataTable GetVoyageMasterValues(MyVoyage Data)
        {

            string strWhere = "";

            string _Query = " Select NVO_VoyageMaster.ID,VesselName,Voyage,RotationNo, " +
                            " Case When Status = 1 then 'Active' else 'InActive' end as StatusV " +
                            " from NVO_VoyageMaster " +
                            " Left Outer join NVO_VesselMaster On NVO_VesselMaster.ID = NVO_VoyageMaster.VesID";

            if (Data.VesselName != "")
                if (strWhere == "")
                    strWhere += _Query + " where VesselName like '%" + Data.VesselName + "%'";
                else
                    strWhere += " and VesselName like '%" + Data.VesselName + "%'";

            if (Data.Voyage != "")
                if (strWhere == "")
                    strWhere += _Query + " where Voyage like '%" + Data.Voyage + "%'";
                else
                    strWhere += " and Voyage like '%" + Data.Voyage + "%'";

            if (Data.RotationNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where RotationNo like '%" + Data.RotationNo + "%'";
                else
                    strWhere += " and RotationNo like '%" + Data.RotationNo + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }
        public List<MyVoyage> GetVoyageMasterRecord(MyVoyage Data)
        {
            DataTable dt = GetVoyageRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyage.Add(new MyVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesID = Int32.Parse(dt.Rows[i]["VesID"].ToString()),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }


            return ListVoyage;
        }
        public DataTable GetVoyageRecordValues(MyVoyage Data)
        {
            string _Query = "Select * from NVO_VoyageMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyVoyage> GetVoyageMasterDropDown(MyVoyage Data)
        {
            DataTable dt = GetVoyageDropDownValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyage.Add(new MyVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Voyage = dt.Rows[i]["Voyage"].ToString()

                });
            }


            return ListVoyage;
        }
        public DataTable GetVoyageDropDownValues(MyVoyage Data)
        {
            string _Query = "Select ID,Voyage from NVO_VoyageMaster";
            return GetViewData(_Query, "");
        }
        public List<MyVoyage> GetRotNoMasterDropDown(MyVoyage Data)
        {
            DataTable dt = GetRotNoDropDownValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new MyVoyage
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString()
                });
            }
            return ListVoyage;
        }
        public DataTable GetRotNoDropDownValues(MyVoyage Data)
        {
            string _Query = "Select ID,RotationNo from NVO_VoyageMaster";
            return GetViewData(_Query, "");
        }
        public List<MyVoyage> GetVoyDropDownChangeMaster(MyVoyage Data)
        {
            DataTable dt = GetVoyDropDownChangeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new MyVoyage
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesID = Int32.Parse(dt.Rows[i]["VesID"].ToString()),
                    Voyage = dt.Rows[i]["Voyage"].ToString()
                });
            }
            return ListVoyage;
        }

        public List<MyVoyage> GetRotNoDropDownChangeMaster(MyVoyage Data)
        {
            DataTable dt = GetVoyDropDownChangeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new MyVoyage
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesID = Int32.Parse(dt.Rows[i]["VesID"].ToString()),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString()
                });
            }
            return ListVoyage;
        }
        public DataTable GetVoyDropDownChangeValues(MyVoyage Data)
        {
            string _Query = "select * from NVO_VoyageMaster where  VesID = " + Data.VesID;
            return GetViewData(_Query, "");
        }
        public List<MyVoyageDetails> GetVoyDtlsViewMaster(MyVoyageDetails Data)
        {
            DataTable dt = GetVoyDetailsView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyageDtls.Add(new MyVoyageDetails
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString()
                });
            }
            return ListVoyageDtls;
        }
        public DataTable GetVoyDetailsView(MyVoyageDetails Data)
        {
            string strWhere = "";

            string _Query = " Select NVO_VoyageDetails.ID,VesselName,VoyageNo,RotationNo,replace(convert(NVARCHAR, ETA, 106), ' ', '-') as ETA from NVO_VoyageDetails " +
                           " inner join NVO_VesselMaster on NVO_VesselMaster.ID = NVO_VoyageDetails.VesID ";

            if (Data.VesselName != "")
                if (strWhere == "")
                    strWhere += _Query + " where VesselName like '%" + Data.VesselName + "%'";
                else
                    strWhere += " and VesselName like '%" + Data.VesselName + "%'";

            if (Data.VoyageNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where VoyageNo like '%" + Data.VoyageNo + "%'";
                else
                    strWhere += " and VoyageNo like '%" + Data.VoyageNo + "%'";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyVoyageDetails> GetVoyDtlsPartRecordMaster(string VoydtIDv)
        {
            DataTable dt = GetVoyDetailsRecordValues(VoydtIDv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyageDtls.Add(new MyVoyageDetails
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVID = Int32.Parse(dt.Rows[i]["VesID"].ToString()),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    ATA = dt.Rows[i]["ATA"].ToString(),
                    ATD = dt.Rows[i]["ATD"].ToString(),
                    CutOff = dt.Rows[i]["CutOff"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    CurrentPortID = Int32.Parse(dt.Rows[i]["CurrentPortID"].ToString()),
                    LoadingTerminalID = Int32.Parse(dt.Rows[i]["LoadingTerminalID"].ToString()),
                    SCNNo = dt.Rows[i]["SCNNo"].ToString(),
                    FinalPortID = Int32.Parse(dt.Rows[i]["FinalPortID"].ToString()),
                });
            }
            return ListVoyageDtls;
        }

        public DataTable GetVoyDetailsRecordValues(string VoydtIDv)
        {
            string _Query = "Select replace(convert(NVARCHAR, ETA, 103), ' ', '-') as ETA,replace(convert(NVARCHAR, ETD, 103), ' ', '-') as ETD,replace(convert(NVARCHAR, ATA, 103), ' ', '-') as ATA,replace(convert(NVARCHAR, ATD, 103), ' ', '-') as ATD,replace(convert(NVARCHAR, CutOff, 103), ' ', '-') as CutOff, * from NVO_VoyageDetails where ID=" + VoydtIDv;
            return GetViewData(_Query, "");
        }
        public List<MyVoyageDetails> GetVoyPortDtlsMaster(string VoydtIDv)
        {
            DataTable dt = GetVoyPortDtlsValues(VoydtIDv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyageDtls.Add(new MyVoyageDetails
                {
                    VID = Int32.Parse(dt.Rows[i]["VID"].ToString()),
                    VesOpID = Int32.Parse(dt.Rows[i]["VesOperatorID"].ToString()),
                    NextPortID = Int32.Parse(dt.Rows[i]["NextPortID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    NextPortETA = dt.Rows[i]["NextPortETA"].ToString(),
                    VesOperator = dt.Rows[i]["VesOperator"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    Terminal = dt.Rows[i]["Terminal"].ToString()
                });
            }
            return ListVoyageDtls;
        }
        public DataTable GetVoyPortDtlsValues(string VoydtIDv)
        {
            string _Query = "Select replace(convert(NVARCHAR, NextPortETA, 103), ' ', '-') as NextPortETA, * from NVO_VoyPortDtls where VoyDtID=" + VoydtIDv;
            return GetViewData(_Query, "");
        }
        #endregion

        #endregion

        #region Ganesh (CITY,PORT,CARGO,COMMODITY,EXRATE)

        #region City
        public List<MyCity> InsertCityMaster(MyCity Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetCityExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["CityCode"].ToString().ToUpper() == Data.CityCode.ToUpper() && dtchk.Rows[0]["CityName"].ToString().ToUpper() == Data.CityName.ToUpper())
                    {
                        ListCity.Add(new MyCity
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "City Code/Name Already Exists"
                        });
                        return ListCity;
                    }
                    if (dtchk.Rows[0]["CityCode"].ToString().ToUpper() == Data.CityCode.ToUpper())
                    {
                        ListCity.Add(new MyCity
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "City Code Already Exists"
                        });
                        return ListCity;
                    }
                    if (dtchk.Rows[0]["CityName"].ToString().ToUpper() == Data.CityName.ToUpper())
                    {
                        ListCity.Add(new MyCity
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "City Name Already Exists"
                        });
                        return ListCity;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.CityMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO   SA.CityMaster(CityCode,CityName,CountryId,Status,StateID) " +
                                     " values (@CityCode,@CityName,@CountryId,@Status,@StateID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE  SA.CityMaster SET CityCode=@CityCode,CityName=@CityName,CountryId=@CountryId,Status=@Status,StateID=@StateID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityCode", Data.CityCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityName", Data.CityName.ToUpper()));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@StateName", ""));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryId", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.CityMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    ListCity.Add(new MyCity
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCity;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCity.Add(new MyCity
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCity;
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

        public DataTable GetCityExValues(MyCity Data)
        {
            string _Query = "select * from  SA.CityMaster where (ID not in(" + Data.ID + ")) and (CityCode ='" + Data.CityCode + "' or CityName='" + Data.CityName + "')";
            return GetViewData(_Query, "");
        }
        public DataTable GetCountry()
        {
            string _Query = "SELECT id,countryname from SA.CountryMaster order by countryname ";
            return GetViewData(_Query, "");
        }

        public List<countryDD> Listcountry()
        {
            DataTable dt = GetCountry();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCtry.Add(new countryDD
                {
                    CountryID = Int32.Parse(dt.Rows[i]["id"].ToString()),
                    CountryName = dt.Rows[i]["countryname"].ToString()
                });
            }
            return ListCtry;
        }

        public List<cityDD> ListCities(string id)
        {
            DataTable dt = GetCity(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCityloc.Add(new cityDD
                {
                    ID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    CityName = dt.Rows[i]["cityname"].ToString()
                });
            }
            return ListCityloc;
        }
        public DataTable GetCity(string id)
        {
            string _Query = "select ID AS CityID ,CityName from SA.CityMaster" +
                " where countryid =" + id + " order by CityName";

            return GetViewData(_Query, "");
        }

        public List<StateDD> ListStates()
        {
            DataTable dt = GetState();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListState.Add(new StateDD
                {
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString()
                });
            }
            return ListState;
        }

        public DataTable GetState(/*string ID*/)
        {
            string _Query = "select ID AS stateID,StateName from SA.stateMaster order by StateName ";
            return GetViewData(_Query, "");
        }
        public List<MyCity> GetCityMaster(MyCity Data)
        {
            DataTable dt = GetCityValues(Data);

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
                ListCity.Add(new MyCity
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityCode = dt.Rows[i]["CityCode"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    CountryCode = dt.Rows[i]["countryCode"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    //CountryID = Int32.Parse(dt.Rows[i]["countryID"].ToString()),
                    Status = St
                });
            }


            return ListCity;
        }

        public List<MyCity> GetCityMasterRecord(MyCity Data)
        {
            DataTable dt = GetCityRecord(Data);

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
                ListCity.Add(new MyCity
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityCode = dt.Rows[i]["CityCode"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    //StateName = dt.Rows[i]["StateName"].ToString(),
                    CountryCode = dt.Rows[i]["countryCode"].ToString(),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),
                    StateID = dt.Rows[i]["StateID"].ToString(),
                    Status = St
                });
            }


            return ListCity;
        }
        public DataTable GetCityRecord(MyCity Data)
        {
            string _Query = "select CTM.id,CTM.CityCode,CTM.CityName,cm.CountryCode,CTM.Status,CTM.Statename,cm.id as countryID,CTM.StateID  from SA.CityMaster CTM  inner join SA.CountryMaster cm on cm.ID= CTM.countryid" +
                   " where CTM.ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public DataTable GetCityValues(MyCity Data)
        {
            string strWhere = "";

            string _Query = " select CTM.id,CTM.CityCode,CTM.CityName,cm.countryCode,CTM.status,CTM.Statename,cm.ID as countryID, " +
                " case when CTM.status=1 then 'Yes' when CTM.status=2 then 'No' ELSE '' END as StatusResult " +
                " from SA.CityMaster CTM " +
                " inner join SA.CountryMaster cm on cm.ID= CTM.countryid";

            if (Data.CityCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where CTM.CityCode like '%" + Data.CityCode + "%'";
                else
                    strWhere += " and CTM.CityCode like '%" + Data.CityCode + "%'";

            if (Data.CountryCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where cm.CountryCode like '%" + Data.CountryCode + "%'";
                else
                    strWhere += " and cm.CountryCode like '%" + Data.CountryCode + "%'";


            if (Data.CityName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CTM.CityName like '%" + Data.CityName + "%'";
                else
                    strWhere += " and CTM.CityName like '%" + Data.CityName + "%'";


            if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where CTM.Status =" + Data.Status.ToString();
                else
                    strWhere += " and CTM.Status =" + Data.Status.ToString();




            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, "");

        }
        #endregion

        #region Port
        public List<MyPort> InsertPortMaster(MyPort Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetPortExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["PortCode"].ToString().ToUpper() == Data.PortCode.ToUpper() && dtchk.Rows[0]["PortName"].ToString().ToUpper() == Data.PortName.ToUpper())
                    {
                        ListPort.Add(new MyPort
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Port Code/Name Already Exists"
                        });
                        return ListPort;
                    }
                    if (dtchk.Rows[0]["PortCode"].ToString().ToUpper() == Data.PortCode.ToUpper())
                    {
                        ListPort.Add(new MyPort
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Port Code Already Exists"
                        });
                        return ListPort;
                    }
                    if (dtchk.Rows[0]["PortName"].ToString().ToUpper() == Data.PortName.ToUpper())
                    {
                        ListPort.Add(new MyPort
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Port Name Already Exists"
                        });
                        return ListPort;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.PortMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.PortMaster(PortCode,PortName,CountryId,Status,GeoLocID,IsICDPort,IsSeaPort,MainPortID,IsAirPort) " +
                                     " values (@PortCode,@PortName,@CountryId,@Status,@GeoLocID,@IsICDPort,@IsSeaPort,@MainPortID,@IsAirPort) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.PortMaster SET PortCode=@PortCode,PortName=@PortName,CountryId=@CountryId,Status=@Status,GeoLocID=@GeoLocID,IsICDPort=@IsICDPort,IsSeaPort=@IsSeaPort," +
                                     " MainPortID=@MainPortID,IsAirPort=@IsAirPort where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortCode", Data.PortCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortName", Data.PortName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryId", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MainPortID", Data.MainPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsICDPort", Data.IsICDPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSeaPort", Data.IsSeaPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsAirPort", Data.IsAirPort));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.PortMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    ListPort.Add(new MyPort
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListPort;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListPort.Add(new MyPort
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListPort;
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

        public DataTable GetPortExValues(MyPort Data)
        {
            string _Query = "select * from SA.PortMaster where (ID not in(" + Data.ID + ")) and (PortCode ='" + Data.PortCode + "' OR PortName='" + Data.PortName + "')";
            return GetViewData(_Query, "");
        }
        public List<MyPort> GetPortMaster(MyPort Data)
        {
            DataTable dt = GetPortValues(Data);

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
                ListPort.Add(new MyPort
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    CountryCode = dt.Rows[i]["countryCode"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    SeaPort = dt.Rows[i]["SeaPort"].ToString(),
                    AirPort = dt.Rows[i]["AirPort"].ToString(),
                    ICDPort = dt.Rows[i]["ICDPort"].ToString(),
                    Status = St,
                    MainPort = dt.Rows[i]["MainPort"].ToString(),
                });
            }
            return ListPort;
        }

        public List<MyPort> GetPortMasterRecord(MyPort Data)
        {
            DataTable dt = GetPortRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListPort.Add(new MyPort
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    CountryCode = dt.Rows[i]["countryCode"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    GeoLocID = Int32.Parse(dt.Rows[i]["GeoLocID"].ToString()),
                    MainPortID = Int32.Parse(dt.Rows[i]["MainPortID"].ToString()),
                    IsSeaPort = Int32.Parse(dt.Rows[i]["IsSeaPort"].ToString()),
                    IsICDPort = Int32.Parse(dt.Rows[i]["IsICDPort"].ToString()),
                    IsAirPort = Int32.Parse(dt.Rows[i]["IsAirPort"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }
            return ListPort;
        }


        public DataTable GetPortRecord(MyPort Data)
        {
            string _Query = "select PTM.id,PTM.PortCode,PTM.PortName,cm.countryCode,PTM.status,cm.id as countryid,GeoLocID,IsSeaPort,IsICDPort,MainPortID,IsAirPort from SA.PortMaster PTM  inner join SA.CountryMaster cm on cm.ID= PTM.countryid " +
                    " where PTM.ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable GetPortValues(MyPort Data)
        {
            string strWhere = "";

            string _Query = "select PTM.id,PTM.PortCode,PTM.PortName,cm.countryCode,PTM.status,cm.id as countryid," +
                " case when PTM.IsICDPort = 1 then  'YES' when PTM.IsICDPort = 0 then 'NO' ELSE '' END as ICDPort," +
                "  case when PTM.IsSeaPort = 1 then 'YES' when PTM.IsSeaPort = 0 then 'NO' ELSE '' END as SeaPort, " +
                "  case when PTM.IsAirPort = 1 then 'YES' when PTM.IsAirPort = 0 then 'NO' ELSE '' END as AirPort, " +
                "  case when PTM.status = 1 then 'YES' when PTM.status = 2 then 'NO' ELSE '' END as StatusResult," +
                " (SELECT Top 1 PortName from NVO_PortMainMaster Where ID=MainPortID) As MainPort  from SA.PortMaster " +
                " PTM inner join SA.CountryMaster cm on cm.ID = PTM.countryid";

            if (Data.PortCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where PortCode like '%" + Data.PortCode + "%'";
                else
                    strWhere += " and PortCode like '%" + Data.PortCode + "%'";

            if (Data.CountryCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where cm.countryCode like '%" + Data.CountryCode + "%'";
                else
                    strWhere += " and cm.countryCode like '%" + Data.CountryCode + "%'";

            if (Data.PortName != "")
                if (strWhere == "")
                    strWhere += _Query + " where PortName like '%" + Data.PortName + "%'";
                else
                    strWhere += " and PortName like '%" + Data.PortName + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "undefined" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where PTM.Status =" + Data.Status.ToString();
                else
                    strWhere += " and PTM.Status =" + Data.Status.ToString();

            if (Data.SeaPort != "" && Data.SeaPort != "undefined" && Data.SeaPort != null && Data.SeaPort != "?" && Data.SeaPort != "0")

                if (strWhere == "")
                    strWhere += _Query + " where PTM.IsSeaPort =" + Data.SeaPort;
                else
                    strWhere += " and  PTM.IsSeaPort =" + Data.SeaPort;


            if (Data.ICDPort != "" && Data.ICDPort!= "undefined" && Data.ICDPort != null && Data.ICDPort != "?" && Data.ICDPort != "0")
                if (strWhere == "")
                    strWhere += _Query + " where PTM.IsICDPort =" + Data.ICDPort;
                else
                    strWhere += " and  PTM.IsICDPort =" + Data.ICDPort;

            if (Data.AirPort != "" && Data.AirPort != "undefined" && Data.AirPort != null && Data.AirPort != "?" && Data.AirPort != "0")
               
                if (strWhere == "")
                    strWhere += _Query + " where PTM.IsAirPort =" + Data.AirPort;
                else
                    strWhere += " and  PTM.IsAirPort =" + Data.AirPort;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyPort> GetGeoLocByCountry(MyPort Data)
        {
            DataTable dt = GetGeoLocByCountryRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListPort.Add(new MyPort
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString(),


                });
            }
            return ListPort;
        }


        public DataTable GetGeoLocByCountryRecord(MyPort Data)
        {
            string _Query = "select * from NVO_GEOLOCATIONS where CountryID=" + Data.CountryID;
            return GetViewData(_Query, "");
        }
        public List<MyPort> GetMainPortMaster(MyPort Data)
        {
            DataTable dt = GetMAINPortValues(Data);

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
                ListPort.Add(new MyPort
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    CountryCode = dt.Rows[i]["countryCode"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    SeaPort = dt.Rows[i]["SeaPort"].ToString(),
                    AirPort = dt.Rows[i]["AirPort"].ToString(),
                    Status = St,

                });
            }
            return ListPort;
        }

        public DataTable GetMAINPortValues(MyPort Data)
        {
            string strWhere = "";

            string _Query = "select PTM.id,PTM.PortCode,PTM.PortName,cm.countryCode,PTM.status,cm.id as countryid,case when PTM.IsICDPort = 1 then 'ICDPort' when PTM.IsICDPort = 0 then '' ELSE '' END as AirPort, case when PTM.IsSeaPort = 1 then 'SeaPort' when PTM.IsSeaPort = 0 then '' ELSE '' END as SeaPort, case when PTM.status = 1 then 'Active' when PTM.status = 2 then 'Inactive' ELSE '' END as StatusResult  from NVO_PortMainMaster PTM inner join NVO_CountryMaster cm on cm.ID = PTM.countryid ";

            if (Data.PortCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where PortCode like '%" + Data.PortCode + "%'";
                else
                    strWhere += " and PortCode like '%" + Data.PortCode + "%'";

            if (Data.PortName != "")
                if (strWhere == "")
                    strWhere += _Query + " where PortName like '%" + Data.PortName + "%'";
                else
                    strWhere += " and PortName like '%" + Data.PortName + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where PTM.Status=" + Data.Status.ToString();
                else
                    strWhere += " and PTM.Status =" + Data.Status.ToString();



            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyPort> GetMainPortRecord(MyPort Data)
        {
            DataTable dt = GetMainPortRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListPort.Add(new MyPort
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    CountryCode = dt.Rows[i]["countryCode"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    GeoLocID = Int32.Parse(dt.Rows[i]["GeoLocID"].ToString()),
                    IsSeaPort = Int32.Parse(dt.Rows[i]["IsSeaPort"].ToString()),
                    IsICDPort = Int32.Parse(dt.Rows[i]["IsICDPort"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }
            return ListPort;
        }


        public DataTable GetMainPortRecordValues(MyPort Data)
        {
            string _Query = "select PTM.id,PTM.PortCode,PTM.PortName,cm.countryCode,PTM.status,cm.id as countryid,GeoLocID,IsSeaPort,IsICDPort from NVO_PortMainMaster PTM  inner join NVO_CountryMaster cm on cm.ID= PTM.countryid" +
                    " where PTM.ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyPort> InsertMainPortMaster(MyPort Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_PortMainMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_PortMaster(PortCode,PortName,CountryId,Status,GeoLocID) " +
                                     " values (@PortCode,@PortName,@CountryId,@Status,@GeoLocID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_PortMainMaster SET PortCode=@PortCode,PortName=@PortName,CountryId=@CountryId,Status=@Status,GeoLocID=@GeoLocID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortCode", Data.PortCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortName", Data.PortName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryId", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@MainPortID", Data.MainPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsICDPort", Data.IsICDPort));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSeaPort", Data.IsSeaPort));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_PortMainMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListPort;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListPort;
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
        public List<MyPort> GetPortDropDownMaster(MyPort Data)
        {
            DataTable dt = GetPortDropDownValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MyPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString()
                });
            }
            return ListPort;
        }
        public DataTable GetPortDropDownValues(MyPort Data)
        {
            string _Query = "select * from NVO_PortMaster";
            return GetViewData(_Query, "");
        }

        #endregion

        #region Cargo
        public List<MyCargo> InsertCargoMaster(MyCargo Data)
        {

            DataTable dtchk = GetCargoExValues(Data);
            DbConnection con = null;
            DbTransaction trans;
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["PkgCode"].ToString().ToUpper() == Data.PkgCode.ToUpper() && dtchk.Rows[0]["PkgDescription"].ToString().ToUpper() == Data.PkgDescription.ToUpper())
                    {
                        ListCargo.Add(new MyCargo
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Package Code/Description Already Exists"
                        });
                        return ListCargo;
                    }
                    if (dtchk.Rows[0]["PkgCode"].ToString().ToUpper() == Data.PkgCode.ToUpper())
                    {
                        ListCargo.Add(new MyCargo
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Package Code Already Exists"
                        });
                        return ListCargo;
                    }
                    if (dtchk.Rows[0]["PkgDescription"].ToString().ToUpper() == Data.PkgDescription.ToUpper())
                    {
                        ListCargo.Add(new MyCargo
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Package Description Already Exists"
                        });
                        return ListCargo;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.CargoPkgMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.CargoPkgMaster(PkgCode,PkgDescription,Status) " +
                                     " values (@PkgCode,@PkgDescription,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE  SA.CargoPkgMaster SET PkgCode=@PkgCode,PkgDescription=@PkgDescription,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PkgCode", Data.PkgCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PkgDescription", Data.PkgDescription.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.CargoPkgMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListCargo.Add(new MyCargo
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCargo;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCargo.Add(new MyCargo
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCargo;
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

        public DataTable GetCargoExValues(MyCargo Data)
        {
            string _Query = "select * from SA.CargoPkgMaster where (ID not in(" + Data.ID + ")) and (PkgCode ='" + Data.PkgCode + "' OR PkgDescription='" + Data.PkgDescription + "')";
            return GetViewData(_Query, "");
        }
        public List<MyCargo> GetCargoPkgMaster(MyCargo Data)
        {
            DataTable dt = GetCargoPkgValues(Data);

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
                ListCargo.Add(new MyCargo
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PkgCode = dt.Rows[i]["PkgCode"].ToString(),
                    PkgDescription = dt.Rows[i]["PkgDescription"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    Status = St
                });
            }
            return ListCargo;
        }

        public DataTable GetCargoPkgValues(MyCargo Data)
        {
            string strWhere = "";

            string _Query = " select Id,PkgCode,PkgDescription,status, " +
                " case when status = 1 then 'YES' when status = 2 then 'NO' ELSE '' END as StatusResult  from SA.CargoPkgMaster ";

            if (Data.PkgCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where PkgCode like '%" + Data.PkgCode + "%'";
                else
                    strWhere += " and PkgCode like '%" + Data.PkgCode + "%'";

            if (Data.PkgDescription != "")
                if (strWhere == "")
                    strWhere += _Query + " where PkgDescription like '%" + Data.PkgDescription + "%'";
                else
                    strWhere += " and PkgDescription like '%" + Data.PkgDescription + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " Where Status =" + Data.Status.ToString();
                else
                    strWhere += " and Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyCargo> GetCargoPkgMasterRecord(MyCargo Data)
        {
            DataTable dt = GetCargoPkgRecord(Data);

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
                ListCargo.Add(new MyCargo
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PkgCode = dt.Rows[i]["PkgCode"].ToString(),
                    PkgDescription = dt.Rows[i]["PkgDescription"].ToString(),
                    Status = St
                });
            }
            return ListCargo;
        }

        public DataTable GetCargoPkgRecord(MyCargo Data)
        {
            string _Query = "select * from SA.CargoPkgMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Commodity
        public List<MyCommodityTypes> CommodityTypeValues()
        {
            List<MyCommodityTypes> ChargeList = new List<MyCommodityTypes>();
            DataTable dt = GetCommodityTypes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommodityTypes
                {
                    CommodityType = Int32.Parse(dt.Rows[i]["CommodityType"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ChargeList;
        }
        public DataTable GetCommodityTypes()
        {
            string _Query = "select Id as CommodityType,GeneralName  from SA.GeneralMaster where seqno=1 ";
            return GetViewData(_Query, "");
        }
        public List<MyCommodity> InsertCommodityMaster(MyCommodity Data)
        {


            DbConnection con = null;
            DbTransaction trans;

            DataTable dtchk = GetCommodityExValues(Data);

            if (dtchk.Rows.Count >= 1)
            {
                if (dtchk.Rows[0]["CommodityUnCode"].ToString().ToUpper() == Data.CommodityUnCode.ToUpper() || dtchk.Rows[0]["CommodityName"].ToString().ToUpper() == Data.CommodityName.ToUpper() || dtchk.Rows[0]["HSCode"].ToString().ToUpper() == Data.HSCode.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "CommodityUnCode/CommodityName/HSCode Already Exists"
                    });
                    return ListCommodity;
                }

                if (dtchk.Rows[0]["CommodityUnCode"].ToString().ToUpper() == Data.CommodityUnCode.ToUpper() || dtchk.Rows[0]["HSCode"].ToString().ToUpper() == Data.HSCode.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "CommodityUnCode/HSCode Already Exists"
                    });
                    return ListCommodity;
                }
                if (dtchk.Rows[0]["CommodityName"].ToString().ToUpper() == Data.CommodityName.ToUpper() || dtchk.Rows[0]["HSCode"].ToString().ToUpper() == Data.HSCode.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "CommodityName/HSCode Already Exists"
                    });
                    return ListCommodity;
                }
                if (dtchk.Rows[0]["CommodityUnCode"].ToString().ToUpper() == Data.CommodityUnCode.ToUpper() || dtchk.Rows[0]["CommodityName"].ToString().ToUpper() == Data.CommodityName.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Commodity UNCode/Commodity Name Already Exists"
                    });
                    return ListCommodity;
                }
                if (dtchk.Rows[0]["CommodityUnCode"].ToString().ToUpper() == Data.CommodityUnCode.ToUpper() || dtchk.Rows[0]["CommodityName"].ToString().ToUpper() == Data.CommodityName.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "CommodityUnCode/CommodityName/HSCode Already Exists"
                    });
                    return ListCommodity;
                }
                if (dtchk.Rows[0]["CommodityUnCode"].ToString().ToUpper() == Data.CommodityUnCode.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Commodity UnCode Already Exists"
                    });
                    return ListCommodity;
                }
                if (dtchk.Rows[0]["CommodityName"].ToString().ToUpper() == Data.CommodityName.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Commodity Name Already Exists"
                    });
                    return ListCommodity;
                }

                if (dtchk.Rows[0]["HSCode"].ToString().ToUpper() == Data.HSCode.ToUpper())
                {
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "HSCode Already Exists"
                    });
                    return ListCommodity;
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

                    Cmd.CommandText = " IF((select count(*) from SA.CommodityMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.CommodityMaster(CommodityUnCode,CommodityName,HSCode,DangerousFlag,CommodityType,Remarks,Status) " +
                                     " values (@CommodityUnCode,@CommodityName,@HSCode,@DangerousFlag,@CommodityType,@Remarks,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.CommodityMaster SET CommodityUnCode=@CommodityUnCode,CommodityName=@CommodityName,HSCode=@HSCode,DangerousFlag=@DangerousFlag,CommodityType=@CommodityType,Remarks=@Remarks,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityUnCode", Data.CommodityUnCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityName", Data.CommodityName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HSCode", Data.HSCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DangerousFlag", Data.DangerousFlag));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityType", Data.CommodityType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.CommodityMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCommodity;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCommodity.Add(new MyCommodity
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCommodity;
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

        public DataTable GetCommodityExValues(MyCommodity Data)
        {
            string _Query = "select * from SA.CommodityMaster where (ID not in(" + Data.ID + ")) and (CommodityUnCode ='" + Data.CommodityUnCode + "' OR CommodityName='" + Data.CommodityName + "' OR HSCode='" + Data.HSCode + "')";
            return GetViewData(_Query, "");
        }
        public List<MyCommodity> GetCommodityMasterRecord(MyCommodity Data)
        {
            DataTable dt = GetCommodityRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCommodity.Add(new MyCommodity
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),                   
                    CommodityUnCode = dt.Rows[i]["CommodityUnCode"].ToString(),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString(),
                    HSCode = dt.Rows[i]["HScode"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    DangerousFlag = dt.Rows[i]["DangerousFlag"].ToString(),
                    CommodityType = dt.Rows[i]["CommodityType"].ToString(),
                    //Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    Status = dt.Rows[i]["Status"].ToString(),
                });
            }
            return ListCommodity;
        }
        public DataTable GetCommodityRecord(MyCommodity Data)
        {
            string _Query = "select * from SA.CommodityMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyCommodity> GetCommodityMaster(MyCommodity Data)
        {
            DataTable dt = GetCommodityvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCommodity.Add(new MyCommodity
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityUnCode = dt.Rows[i]["CommodityUnCode"].ToString(),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString(),
                    HSCode = dt.Rows[i]["HSCode"].ToString(),
                    DangerousFlag = dt.Rows[i]["DangerousFlag"].ToString(),
                    CommodityType = dt.Rows[i]["CommodityType"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),                   

                });
            }
            return ListCommodity;
        }

        public DataTable GetCommodityvalues(MyCommodity Data)
        {
            string strWhere = "";

            string _Query = " select CM.ID,CM.CommodityUnCode,GM.GeneralName,CM.CommodityName,CM.HScode,CM.Remarks,GM.GeneralName as CommodityType," +
                     " case when CM.DangerousFlag =1 then 'Yes' else 'No' end as DangerousFlag,  " +
                     " case when CM.Status = 1 then 'YES' when CM.Status = 2 then 'NO' else '' end as StatusResult " +
                     //" case when CommodityType =1 then 'General' when  CommodityType =2 then 'Hazardous' else '' end CommodityType " +
                     " from SA.CommodityMaster CM" +
                     " LEFT OUTER JOIN SA.generalMaster GM  ON GM.id=CM.CommodityType AND GM.SeqNo=1 ";


            if (Data.DangerousFlag.ToString() != "" && Data.DangerousFlag.ToString() != "0" && Data.DangerousFlag.ToString() != "undefined" && Data.DangerousFlag.ToString() != null)
                if (strWhere == "")
                    strWhere += _Query + " Where DangerousFlag=" + Data.DangerousFlag.ToString();
                else
                    strWhere += " and DangerousFlag =" + Data.DangerousFlag.ToString();


            if (Data.CommodityUnCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where CommodityUnCode like '%" + Data.CommodityUnCode + "%'";
                else
                    strWhere += " and CommodityUnCode like '%" + Data.CommodityUnCode + "%'";


            if (Data.CommodityName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CommodityName like '%" + Data.CommodityName + "%'";
                else
                    strWhere += " and CommodityName like '%" + Data.CommodityName + "%'";


            if (Data.HSCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where HScode like '%" + Data.HSCode + "%'";
                else
                    strWhere += " and HScode like '%" + Data.HSCode + "%'";

            if (Data.CommodityTypeID.ToString() != "" && Data.CommodityTypeID.ToString() != "0" && Data.CommodityTypeID.ToString() != "undefined" && Data.CommodityTypeID.ToString() != null)

                if (strWhere == "")
                    strWhere += _Query + " Where CommodityType=" + Data.CommodityTypeID.ToString();
                else
                    strWhere += " and CommodityType =" + Data.CommodityTypeID.ToString();



            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != "undefined" && Data.Status.ToString() != null)

                if (strWhere == "")
                    strWhere += _Query + " Where CM.Status=" + Data.Status.ToString();
                else
                    strWhere += " and CM.Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }
        #endregion

        #region ExchangeRate
        public List<MyExRate> InsertExRateMaster(MyExRate Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ExRate where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ExRate(Date,FromCurrency,ToCurrency,Rate,AgencyID,CreatedOn,CreatedByID) " +
                                     " values (@Date,@FromCurrency,@ToCurrency,@Rate,@AgencyID,@CreatedOn,@CreatedByID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ExRate SET Date=@Date,FromCurrency=@FromCurrency,ToCurrency=@ToCurrency,Rate=@Rate,ModifiedOn=@ModifiedOn,ModifiedByID=@ModifiedByID,AgencyID=@AgencyID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", Data.Date));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ToCurrency", Data.ToCurrency));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FromCurrency", Data.FromCurrency));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Rate", Data.Rate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedByID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedByID", Data.UserID));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ExRate')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListExRate;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListExRate;
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


        public DataTable GetCurrency()
        {
            string _Query = "SELECT id as currencyid,currencycode from NVO_CurrencyMaster";
            return GetViewData(_Query, "");
        }

        public List<CurrencyDD> ListFromCurrencyDD()
        {
            DataTable dt = GetCurrency();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurr.Add(new CurrencyDD
                {
                    FromCurrency = Int32.Parse(dt.Rows[i]["currencyid"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString()
                });
            }
            return ListCurr;
        }
        public List<CurrencyDD> ListToCurrencyDD()
        {
            DataTable dt = GetCurrency();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurr.Add(new CurrencyDD
                {
                    ToCurrency = Int32.Parse(dt.Rows[i]["currencyid"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString()
                });
            }
            return ListCurr;
        }

        public List<MyExRate> ExRateMaster(MyExRate Data)
        {
            DataTable dt = GetExRatevalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListExRate.Add(new MyExRate
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    FromCurrency = dt.Rows[i]["FromCurrency"].ToString(),
                    ToCurrency = dt.Rows[i]["ToCurrency"].ToString(),
                    Rate = dt.Rows[i]["Rate"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),


                });
            }
            return ListExRate;
        }

        public DataTable GetExRatevalues(MyExRate Data)
        {
            string _Query = "select Ex.ID,convert(varchar, Ex.Date, 106) As Date ,cm1.CurrencyCode AS FromCurrency,Cm2.CurrencyCode AS ToCurrency,Ex.Rate from NVO_ExRate Ex " +
                " inner join NVO_CurrencyMaster cm1 on cm1.id =Ex.FromCurrency " +
                " inner join NVO_CurrencyMaster cm2 on cm2.id =Ex.ToCurrency";

            string strWhere = "";

            if (Data.Date != "")
                if (strWhere == "")
                    strWhere += _Query + " Where Ex.Date <= ' " + Data.Date + "'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != "2" && Data.AgencyID != "undefined" && Data.AgencyID != null)

                if (strWhere == "")
                    strWhere += _Query + " where Ex.AgencyID = " + Data.AgencyID;
                else
                    strWhere += " and Ex.AgencyID = " + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyExRate> GetExRateMasterRecord(MyExRate Data)
        {
            DataTable dt = GetExRateRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListExRate.Add(new MyExRate
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Date = dt.Rows[i]["Date"].ToString(),
                    FromCurrency = dt.Rows[i]["FromCurrency"].ToString(),
                    ToCurrency = dt.Rows[i]["ToCurrency"].ToString(),
                    Rate = dt.Rows[i]["Rate"].ToString(),
                });
            }
            return ListExRate;
        }
        public DataTable GetExRateRecord(MyExRate Data)
        {
            string _Query = "select Id,convert(varchar, Date, 23) as Date,FromCurrency,ToCurrency,Rate from NVO_ExRate where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        #endregion

        #region voyage allocation

        List<MyVoyageAllocation> ListVoyAlloc = new List<MyVoyageAllocation>();
        public List<MyVoyageAllocation> ListVoyageTypes(MyVoyageAllocation Data)
        {
            DataTable dt = GetListVoyageTypes(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoyageTypes = dt.Rows[i]["VoyageTypes"].ToString(),
                });
            }
            return ListVoyAlloc;
        }
        public DataTable GetListVoyageTypes(MyVoyageAllocation Data)
        {
            string _Query = "select ID,GeneralName as VoyageTypes from NVO_GeneralMaster where seqno=27 and ID IN (79,80)";
            return GetViewData(_Query, "");
        }


        public List<MyVoyageAllocation> ListLegInfoTypes(MyVoyageAllocation Data)
        {
            DataTable dt = GetListLegInfoTypes(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LegInformation = dt.Rows[i]["LegInformation"].ToString(),
                });
            }
            return ListVoyAlloc;
        }
        public DataTable GetListLegInfoTypes(MyVoyageAllocation Data)
        {
            string _Query = "select ID,GeneralName as LegInformation from NVO_GeneralMaster where seqno=26 and ID IN (75,76)";
            return GetViewData(_Query, "");
        }

        public List<MyVoyageAllocation> ListBLListAgentwise(MyVoyageAllocation Data)
        {
            DataTable dt = GetListBLListAgentwise(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                });
            }
            return ListVoyAlloc;
        }
        public DataTable GetListBLListAgentwise(MyVoyageAllocation Data)
        {
            string _Query = "Select case when NVO_BOL.ID is null  then 0 else NVO_BOL.ID end as ID,BookingNo as BLNumber from NVO_Booking left outer join NVO_BOL on NVO_BOL.BkgID = NVO_Booking.ID where Status = 2 and NVO_Booking.AgentID = " + Data.AgencyID;
            return GetViewData(_Query, "");
        }
        public List<MyVoyageAllocation> ListEXPandTSBLListAgentwise(MyVoyageAllocation Data)
        {
            DataTable dt = GetListEXPandTSBLListAgentwise(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                });
            }
            return ListVoyAlloc;
        }
        public DataTable GetListEXPandTSBLListAgentwise(MyVoyageAllocation Data)
        {
            string _Query = "  SELECT NVO_BOL.ID,NVO_BOL.BLNumber FROM NVO_BOL  INNER JOIN  NVO_Booking ON NVO_Booking.ID = NVO_BOL.BkgID WHERE NVO_Booking.AgentID =" + Data.AgencyID + " OR NVO_Booking.TranshipmEtAgentID  =" + Data.AgencyID + " AND NVO_BOL.IsBLLocked = 1";
            return GetViewData(_Query, "");
        }

        public List<MyVoyageAllocation> InsertVoyageAllocation(MyVoyageAllocation Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_VoyageAllocation where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageAllocation(VesVoyID,VoyageTypes,LegInformation,UserID,AgencyID) " +
                                     " values (@VesVoyID,@VoyageTypes,@LegInformation,@UserID,@AgencyID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageAllocation SET VesVoyID=@VesVoyID,VoyageTypes=@VoyageTypes,LegInformation=@LegInformation,UserID=@UserID,AgencyID=@AgencyID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageTypes", Data.VoyageTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LegInformation", Data.LegInformationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_VoyageAllocation')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_VoyageAllocationDtls where VoyAllocID=@VoyAllocID and VID=@VID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageAllocationDtls(BLID,BLNumber,Dtadded,VoyAllocID) " +
                                     " values (@BLID,@BLNumber,@Dtadded,@VoyAllocID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageAllocationDtls SET BLID=@BLID,BLNumber=@BLNumber,Dtadded=@Dtadded,VoyAllocID=@VoyAllocID where VoyAllocID=@VoyAllocID and VID=@VID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyAllocID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Dtadded", System.DateTime.Now.Date.ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListVoyAlloc.Add(new MyVoyageAllocation { ID = Data.ID });
                    return ListVoyAlloc;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyAlloc;
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

        public List<MyVoyageAllocation> ListBindLegVslVoyDetails(MyVoyageAllocation Data)
        {
            DataTable dt = GetLegVslVoyDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    TSPORT = dt.Rows[i]["TSPORT"].ToString(),
                    VesVoy1 = dt.Rows[i]["VesVoy1"].ToString(),
                    // VesVoy2 = dt.Rows[i]["VesVoy2"].ToString(),
                });
            }
            return ListVoyAlloc;
        }
        public DataTable GetLegVslVoyDetails(MyVoyageAllocation Data)
        {
            string _Query = "  select DISTINCT BL.ID,BL.bkgid,BL.BLNumber,(select top(1) PortName from NVO_PortMaster where ID = BL.POLID) As POL, (select top(1) PortName from NVO_PortMaster where ID = BL.PODID) As POD,(select top(1) PortName from NVO_PortMaster where ID = B.TSPORTID) As TSPORT,(Select top 1 (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where V.ID = NVO_BOLVoyageDetails.VesVoyID )as VesVoy1 from NVO_BOL BL  LEFT OUTER join NVO_BOLVoyageDetails ON NVO_BOLVoyageDetails.BLID = BL.ID LEFT OUTER join NVO_Booking B ON B.ID = BL.BKGID WHERE BL.ID=" + Data.ID + " ";
            return GetViewData(_Query, "");
        }

        public List<MyVoyageAllocation> ListVoyAllocationView(MyVoyageAllocation Data)
        {
            DataTable dt = GetVoyAllocationDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy2 = dt.Rows[i]["VesVoy"].ToString(),
                    VoyageTypes = dt.Rows[i]["VoyageTypes"].ToString(),
                    LegInformation = dt.Rows[i]["LegInformation"].ToString(),

                });
            }
            return ListVoyAlloc;
        }
        public DataTable GetVoyAllocationDetails(MyVoyageAllocation Data)
        {
            string strWhere = "";
            string _Query = "select  VA.ID,  (Select top 1 (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where V.ID = VA.VesVoyID )as VesVoy, GM.GeneralName as VoyageTypes,GM1.GeneralName as LegInformation  from NVO_VoyageAllocation VA " +
           " inner join NVO_GeneralMaster GM ON GM.ID = VA.VoyageTypes and GM.SeqNo = 27 " +
         " inner join NVO_GeneralMaster GM1 ON GM1.ID = VA.leginformation and GM1.SeqNo = 26 ";

            if (Data.VesVoyID.ToString() != "" && Data.VesVoyID.ToString() != "0" && Data.VesVoyID.ToString() != null && Data.VesVoyID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where VA.VesvoyID = " + Data.VesVoyID.ToString();
                else
                    strWhere += " and VA.VesvoyID = " + Data.VesVoyID.ToString();

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != null && Data.AgencyID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where VA.AgencyID = " + Data.AgencyID.ToString();
                else
                    strWhere += " and VA.AgencyID = " + Data.AgencyID.ToString();

            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere, "");
        }

        public List<MyVoyageAllocation> BindVoyAllocationEditValues(MyVoyageAllocation Data)
        {
            DataTable dt = GetVoyAllocation(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoyID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    VoyageTypeID = Int32.Parse(dt.Rows[i]["VoyageTypes"].ToString()),
                    LegInformationID = Int32.Parse(dt.Rows[i]["LegInformation"].ToString()),

                });
            }
            return ListVoyAlloc;
        }

        public DataTable GetVoyAllocation(MyVoyageAllocation Data)
        {
            string _Query = "select * from NVO_VoyageAllocation where ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyVoyageAllocation> BindVoyAllocationDtlsEditValues(MyVoyageAllocation Data)
        {
            DataTable dt = GetVoyAllocationDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyAlloc.Add(new MyVoyageAllocation
                {

                    VID = Int32.Parse(dt.Rows[i]["VID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    TSPORT = dt.Rows[i]["TSPORT"].ToString(),
                    VesVoy1 = dt.Rows[i]["VesVoy1"].ToString(),
                    VesVoy2 = dt.Rows[i]["VesVoyAlloc"].ToString(),

                });
            }
            return ListVoyAlloc;
        }

        public DataTable GetVoyAllocationDtls(MyVoyageAllocation Data)
        {
            string _Query = " select DISTINCT VAD.VID, BL.ID AS BLID,BL.bkgid,BL.BLNumber,(select top(1) PortName from NVO_PortMaster where ID = BL.POLID) As POL,(select top(1) PortName from NVO_PortMaster where ID = BL.PODID) As POD,(select top(1) PortName from NVO_PortMaster where ID = B.TSPORTID) As TSPORT,(Select top 1 (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where V.ID = NVO_BOLVoyageDetails.VesVoyID )as VesVoy1," +
                "  (Select top 1 (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID)  + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where V.ID = NVO_VoyageAllocation.VesVoyID )as VesVoyAlloc from NVO_BOL BL  left outer join NVO_BOLVoyageDetails ON NVO_BOLVoyageDetails.BLID = BL.ID  left outer join NVO_Booking B ON B.ID = BL.BKGID  left outer join NVO_VoyageAllocationDtls VAD ON VAD.BLID = BL.ID " +
                " left outer join NVO_VoyageAllocation on NVO_VoyageAllocation.ID =VAD.VoyAllocID WHERE VAD.VoyAllocID  =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable BLVoyAllocationDelete(MyVoyageAllocation Data)
        {

            string _Query = " Delete NVO_VoyageAllocationDtls where VID=" + Data.VID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region GEO-Location
        List<MyGeoLocation> ListGeoLoc = new List<MyGeoLocation>();
        public List<MyGeoLocation> InsertGeoLocationMaster(MyGeoLocation Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_GeoLocations where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_GeoLocations(GeoLocation,CountryID,Status) " +
                                     " values (@GeoLocation,@CountryID,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_GeoLocations SET  GeoLocation=@GeoLocation,CountryID=@CountryID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocation", Data.GeoLocation));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_GeoLocations')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_GeoLocationDeportDtls where GeoLocID=@GeoLocID and DID=@DID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_GeoLocationDeportDtls(DepotID,Depot,GeoLocID) " +
                                     " values (@DepotID,@Depot,@GeoLocID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_GeoLocationDeportDtls SET DepotID=@DepotID,Depot=@Depot,GeoLocID=@GeoLocID where GeoLocID=@GeoLocID and DID=@DID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Depot", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.ID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();
                    return ListGeoLoc;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListGeoLoc;
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

        public List<MyGeoLocation> GeoLocationViewMaster(MyGeoLocation Data)
        {
            DataTable dt = GetGeoLocationValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListGeoLoc.Add(new MyGeoLocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString(),
                    Country = dt.Rows[i]["CountryName"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });
            }


            return ListGeoLoc;
        }


        public DataTable GetGeoLocationValues(MyGeoLocation Data)
        {
            string strWhere = "";

            string _Query = " select G.ID,G.GeoLocation,CM.CountryName,case when G.Status = 1 then 'Active' when G.Status = 0 then 'Inactive' ELSE '' END as StatusResult from NVO_GeoLocations G Inner Join NVO_CountryMaster CM ON CM.ID =G.CountryID ";

            if (Data.GeoLocation != "")
                if (strWhere == "")
                    strWhere += _Query + " where G.GeoLocation like '%" + Data.GeoLocation + "%'";
                else
                    strWhere += " and G.GeoLocation like '%" + Data.GeoLocation + "%'";

            if (Data.CountryID.ToString() != "" && Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where G.CountryID = " + Data.CountryID.ToString();
                else
                    strWhere += " and G.CountryID = " + Data.CountryID.ToString();

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, "");

        }

        public List<MyGeoLocation> GeoLocationEditMaster(MyGeoLocation Data)
        {
            DataTable dt = GetGeoLocationEditValues(Data);

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

                ListGeoLoc.Add(new MyGeoLocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    Status = St

                });
            }


            return ListGeoLoc;
        }


        public DataTable GetGeoLocationEditValues(MyGeoLocation Data)
        {

            string _Query = " select * from NVO_GeoLocations where ID=" + Data.ID;

            return GetViewData(_Query, "");

        }

        public List<MyGeoLocation> BindGeoLocDepotDtls(MyGeoLocation Data)
        {
            DataTable dt = GetBindGeoLocDepotDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeoLoc.Add(new MyGeoLocation
                {

                    DID = Int32.Parse(dt.Rows[i]["DID"].ToString()),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),


                });
            }


            return ListGeoLoc;
        }


        public DataTable GetBindGeoLocDepotDtls(MyGeoLocation Data)
        {

            string _Query = " select * from NVO_GeoLocationDeportDtls where GeoLocID=" + Data.ID;

            return GetViewData(_Query, "");

        }

        public List<MyGeoLocation> GeoLocApplicableDepotDelete(MyGeoLocation Data)
        {
            DataTable dt = ApplicableDepotDelete(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeoLoc.Add(new MyGeoLocation
                {
                    DID = Int32.Parse(dt.Rows[i]["DID"].ToString()),

                });

            }
            return ListGeoLoc;
        }
        public DataTable ApplicableDepotDelete(MyGeoLocation Data)
        {

            string _Query = "Delete FROM NVO_GeoLocationDeportDtls where DID=" + Data.DID;


            return GetViewData(_Query, "");
        }
        #endregion

        #region ServiceSetup

        List<MyServiceSetup> ListSS = new List<MyServiceSetup>();
        public List<MyServiceSetup> ListSlotOperatorByServices(MyServiceSetup Data)
        {
            DataTable dt = GetSlotOperatorByServices(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSS.Add(new MyServiceSetup
                {

                    ID = Int32.Parse(dt.Rows[i]["OperatorID"].ToString()),
                    Operator = dt.Rows[i]["Operator"].ToString(),

                });
            }

            return ListSS;
        }


        public DataTable GetSlotOperatorByServices(MyServiceSetup Data)
        {

            string _Query = " select * from NVO_ServiceOpertaors where ServicesID=" + Data.ServiceID;

            return GetViewData(_Query, "");

        }


        public List<MyServiceSetup> ListSlotRefByOperator(MyServiceSetup Data)
        {
            DataTable dt = GetSlotRefByOperatorValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSS.Add(new MyServiceSetup
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SlotRefCode = dt.Rows[i]["SlotRef"].ToString(),

                });
            }

            return ListSS;
        }


        public DataTable GetSlotRefByOperatorValues(MyServiceSetup Data)
        {

            string _Query = " select * from NVO_SLOTMaster where SlotOperator=" + Data.ID;

            return GetViewData(_Query, "");

        }
        public List<MyServiceSetup> ExistServiceValidation(MyServiceSetup Data)
        {
            DataTable dt = GetExistServiceValidations(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSS.Add(new MyServiceSetup
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ServiceName = dt.Rows[i]["ServiceName"].ToString(),

                });
            }
            return ListSS;
        }

        public DataTable GetExistServiceValidations(MyServiceSetup Data)
        {
            string _Query = " select * from NVO_Services where ServiceName ='" + Data.ServiceName + "'";
            return GetViewData(_Query, "");
        }
        public List<MyServiceSetup> InsertServiceSetup(MyServiceSetup Data)
        {
            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetServiceExValues(Data);
            if (Data.StatusID != 1 || Data.StatusID != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["ServiceName"].ToString().ToUpper() == Data.ServiceName.ToUpper())
                    {
                        ListService.Add(new MyServiceSetup
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Service Name Already Exists"
                        });
                        return ListService;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from NVO_Services where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Services(ServiceName,DtEffective,UserID,OffLocID,StatusID) " +
                                     " values (@ServiceName,@DtEffective,@UserID,@OffLocID,@StatusID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Services SET ServiceName=@ServiceName,DtEffective=@DtEffective,UserID=@UserID,OffLocID=@OffLocID,StatusID=@StatusID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceName", Data.ServiceName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtEffective", Data.DtEffective));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OffLocID", Data.OffLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_Services')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.ItemsRoute.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    int TrTmHH = 0, intTrTmHH = 0;
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        int.TryParse(CharSplit[2], out TrTmHH);
                        intTrTmHH = TrTmHH * 100;

                        Cmd.CommandText = " IF((select count(*) from NVO_ServiceRoute where ServicesID=@ServicesID and RID=@RID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ServiceRoute(ServicesID,PortID,TmTransitTime) " +
                                     " values (@ServicesID,@PortID,@TmTransitTime) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ServiceRoute SET ServicesID=@ServicesID,PortID=@PortID,TmTransitTime=@TmTransitTime where ServicesID=@ServicesID and RID=@RID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TmTransitTime", intTrTmHH));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ServicesID", Data.ID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayOpr = Data.ItemsOpr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    if (ArrayOpr.Length != 1)
                    {
                        for (int i = 1; i < ArrayOpr.Length; i++)
                        {
                            var CharSplit = ArrayOpr[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_ServiceOpertaors where ServicesID=@ServicesID and OID=@OID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_ServiceOpertaors(ServicesID,OperatorID,Operator,SlotRefID,SlotRef) " +
                                         " values (@ServicesID,@OperatorID,@Operator,@SlotRefID,@SlotRef) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_ServiceOpertaors SET ServicesID=@ServicesID,OperatorID=@OperatorID,Operator=@Operator,SlotRefID=@SlotRefID,SlotRef=@SlotRef where ServicesID=@ServicesID and OID=@OID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OperatorID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Operator", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRefID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRef", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ServicesID", Data.ID));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    //string[] Array = Data.ItemsRoute.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    //int outTrTmInt = 0, intTrTm = 0, outTmWComInt = 0, intTmWCom = 0, outTmWCloInt = 0, intTmWClo = 0, outTmPS = 0, intoutTmPS = 0;
                    //for (int i = 1; i < Array.Length; i++)
                    //{
                    //    var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');




                    //    int.TryParse(CharSplit[2], out outTrTmInt);
                    //    intTrTm = outTrTmInt * 100;

                    //    int.TryParse(CharSplit[5], out outTmWComInt);
                    //    intTmWCom = outTmWComInt * 100;

                    //    int.TryParse(CharSplit[8], out outTmWCloInt);
                    //    intTmWClo = outTmWCloInt * 100;

                    //    int.TryParse(CharSplit[12], out outTmPS);
                    //    intoutTmPS = outTmPS * 100;

                    //    Cmd.CommandText = " IF((select count(*) from NVO_ServiceRoute where ServicesID=@ServicesID and RID=@RID)<=0) " +
                    //                 " BEGIN " +
                    //                 " INSERT INTO  NVO_ServiceRoute(ServicesID,PortID,TmTransitTime,DayWindowCommence,TmWindowCommence,DayWindowClose,TmWindowClose,DayPortStay,TmPortStay) " +
                    //                 " values (@ServicesID,@PortID,@TmTransitTime,@DayWindowCommence,@TmWindowCommence,@DayWindowClose,@TmWindowClose,@DayPortStay,@TmPortStay) " +
                    //                 " END  " +
                    //                 " ELSE " +
                    //                 " UPDATE NVO_ServiceRoute SET ServicesID=@ServicesID,PortID=@PortID,TmTransitTime=@TmTransitTime,DayWindowCommence=@DayWindowCommence,TmWindowCommence=@TmWindowCommence,DayWindowClose=@DayWindowClose,TmWindowClose=@TmWindowClose,DayPortStay=@DayPortStay,TmPortStay=@TmPortStay where ServicesID=@ServicesID and RID=@RID";
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplit[0]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[1]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@TmTransitTime", intTrTm));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@DayWindowCommence", CharSplit[4]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@TmWindowCommence", intTmWCom));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@DayWindowClose", CharSplit[7]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@TmWindowClose", intTmWClo));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@DayPortStay", CharSplit[10]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@TmPortStay", intoutTmPS));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServicesID", Data.ID));
                    //    //Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.Date.ToString()));
                    //    result = Cmd.ExecuteNonQuery();
                    //    Cmd.Parameters.Clear();

                    //}

                    //string[] ArrayOpr = Data.ItemsOpr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    //if (ArrayOpr.Length != 1)
                    //{
                    //    for (int i = 1; i < ArrayOpr.Length; i++)
                    //    {
                    //        var CharSplit = ArrayOpr[i].ToString().TrimEnd(',').Split(',');

                    //        Cmd.CommandText = " IF((select count(*) from NVO_ServiceOpertaors where ServicesID=@ServicesID and OID=@OID)<=0) " +
                    //                     " BEGIN " +
                    //                     " INSERT INTO  NVO_ServiceOpertaors(ServicesID,OperatorID,Operator,SlotRefID,SlotRef) " +
                    //                     " values (@ServicesID,@OperatorID,@Operator,@SlotRefID,@SlotRef) " +
                    //                     " END  " +
                    //                     " ELSE " +
                    //                     " UPDATE NVO_ServiceOpertaors SET ServicesID=@ServicesID,OperatorID=@OperatorID,Operator=@Operator,SlotRefID=@SlotRefID,SlotRef=@SlotRef where ServicesID=@ServicesID and OID=@OID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@OID", CharSplit[0]));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@OperatorID", CharSplit[1]));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@Operator", CharSplit[2]));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRefID", CharSplit[3]));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRef", CharSplit[4]));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ServicesID", Data.ID));

                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}
                    trans.Commit();

                    ListService.Add(new MyServiceSetup
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListService;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListService.Add(new MyServiceSetup
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListService;

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
        public DataTable GetServiceExValues(MyServiceSetup Data)
        {
            string _Query = "select * from NVO_Services where (ID not in(" + Data.ID + ")) and (ServiceName='" + Data.ServiceName + "')";
            return GetViewData(_Query, "");
        }
        public List<MyServiceSetup> ServiceSetupViewMaster(MyServiceSetup Data)
        {
            DataTable dt = GetServiceSetupValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ServiceName = dt.Rows[i]["ServiceName"].ToString(),
                    DtEffective = dt.Rows[i]["DtEffective"].ToString(),
                    GeoLoc = dt.Rows[i]["GeoLoc"].ToString(),
                });
            }


            return ListSS;
        }


        public DataTable GetServiceSetupValues(MyServiceSetup Data)
        {
            string strWhere = "";

            //string _Query = " select Id,ServiceName," +
            //    " (Select top 1 GeoLocation from NVO_GeoLocations where ID= GeoLocID) As GeoLoc," +
            //    " convert(varchar,DtEffective, 106) As DtEffective  from NVO_Services ";

            string _Query = " select Id,ServiceName," +
               " (Select top 1 OfficeLoc from NVO_OfficeMaster where ID= OffLocID) As GeoLoc," +
               " convert(varchar,DtEffective, 106) As DtEffective  from NVO_Services ";

            if (Data.ServiceName != "")
                if (strWhere == "")
                    strWhere += _Query + " where ServiceName like '%" + Data.ServiceName + "%'";
                else
                    strWhere += " and ServiceName like '%" + Data.ServiceName + "%'";

            if (Data.OffLocID.ToString() != "" && Data.OffLocID.ToString() != "0" && Data.OffLocID.ToString() != null && Data.OffLocID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where OffLocID=" + Data.OffLocID.ToString();
                else
                    strWhere += " and OffLocID =" + Data.OffLocID.ToString();

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, " Order By ID");

        }

        public List<MyServiceSetup> ServiceSetupEditMaster(MyServiceSetup Data)
        {
            DataTable dt = GetServiceSetupEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ServiceName = dt.Rows[i]["ServiceName"].ToString(),
                    DtEffective = dt.Rows[i]["DtEff"].ToString(),
                    OffLocID = Int32.Parse(dt.Rows[i]["OffLocID"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                });
            }


            return ListSS;
        }


        public DataTable GetServiceSetupEditValues(MyServiceSetup Data)
        {

            string _Query = " select convert(varchar, DtEffective, 23) as DtEff,* from NVO_Services where ID =" + Data.ID;


            return GetViewData(_Query, "");

        }

        public List<MyServiceSetup> ServiceRouteEditMaster(MyServiceSetup Data)
        {
            DataTable dt = GetServiceRouteValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    TTHH = Int32.Parse(dt.Rows[i]["TTHH"].ToString()),
                    TTMM = Int32.Parse(dt.Rows[i]["TTMM"].ToString()),
                    //DayWindowCommence = Int32.Parse(dt.Rows[i]["DayWindowCommence"].ToString()),
                    //WComHH = Int32.Parse(dt.Rows[i]["WComHH"].ToString()),
                    //WComMM = Int32.Parse(dt.Rows[i]["WComMM"].ToString()),
                    //DayWindowClose = Int32.Parse(dt.Rows[i]["DayWindowClose"].ToString()),
                    //WCloseHH = Int32.Parse(dt.Rows[i]["WCloseHH"].ToString()),
                    //WCloseMM = Int32.Parse(dt.Rows[i]["WCloseMM"].ToString()),
                    //DayPortStay = Int32.Parse(dt.Rows[i]["DayPortStay"].ToString()),
                    //PortStayHH = Int32.Parse(dt.Rows[i]["PortStayHH"].ToString()),
                    //PortStayMM = Int32.Parse(dt.Rows[i]["PortStayMM"].ToString()),

                });
            }


            return ListSS;
        }


        public DataTable GetServiceRouteValues(MyServiceSetup Data)
        {

            string _Query = "select RID,ServicesID,PORTID,TmTransitTime/100 as TTHH,'00'  as TTMM,DayWindowCommence,TmWindowCommence / 100 as WComHH,'00' AS WComMM,DayWindowClose, TmWindowClose/ 100 as WCloseHH,'00' AS WCloseMM, DayPortStay, TmPortStay/ 100 as PortStayHH,'00' AS PortStayMM from NVO_ServiceRoute where ServicesID=" + Data.ID;


            return GetViewData(_Query, "");

        }

        public List<MyServiceSetup> ServiceOperatorsEditMaster(MyServiceSetup Data)
        {
            DataTable dt = GetServiceOperatorValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    OID = Int32.Parse(dt.Rows[i]["OID"].ToString()),
                    OperatorID = Int32.Parse(dt.Rows[i]["OperatorID"].ToString()),
                    Operator = dt.Rows[i]["Operator"].ToString(),
                    SlotRefID = Int32.Parse(dt.Rows[i]["SlotRefID"].ToString()),
                    SlotRef = dt.Rows[i]["SlotRef"].ToString(),

                });
            }


            return ListSS;
        }


        public DataTable GetServiceOperatorValues(MyServiceSetup Data)
        {

            string _Query = "select * from NVO_ServiceOpertaors where ServicesID=" + Data.ID;


            return GetViewData(_Query, "");

        }
        public List<MyServiceSetup> ServiceRouteDeleteValues(MyServiceSetup Data)
        {
            DataTable dt = GetServiceRouteDeleteValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),


                });
            }


            return ListSS;
        }


        public DataTable GetServiceRouteDeleteValues(MyServiceSetup Data)
        {

            string _Query = "Delete from NVO_ServiceRoute where RID=" + Data.RID;


            return GetViewData(_Query, "");

        }
        public List<MyServiceSetup> ServiceOperatorsDeleteValues(MyServiceSetup Data)
        {
            DataTable dt = GetServiceOperatorsDeleteValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    OID = Int32.Parse(dt.Rows[i]["OID"].ToString()),


                });
            }


            return ListSS;
        }


        public DataTable GetServiceOperatorsDeleteValues(MyServiceSetup Data)
        {

            string _Query = "Delete from NVO_ServiceOpertaors where OID=" + Data.OID;


            return GetViewData(_Query, "");

        }
        #endregion

        #region Voyage NEW

        public List<MyServiceSetup> BindServicesMaster(MyServiceSetup Data)
        {
            DataTable dt = GetBindServiceValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ServiceName = dt.Rows[i]["ServiceName"].ToString(),

                });
            }


            return ListSS;
        }


        public DataTable GetBindServiceValues(MyServiceSetup Data)
        {

            //string _Query = "select * from NVO_Services where GeoLocID=" + Data.ID + " Order By ServiceName ";
            //return GetViewData(_Query, "");

            string _Query = "select * from NVO_Services Order By ServiceName";
            return GetViewData(_Query, "");

        }

        public List<MyCommonAccess> TerminalMasterByPort(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetTerminalMasterByPort(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetTerminalMasterByPort(MyCommonAccess Data)
        {
            string _Query = "SELECT NVO_TerminalMaster.ID,TerminalName  FROM  NVO_TerminalMaster inner Join NVO_PortMaster on NVO_PortMaster.ID = NVO_TerminalMaster.PortID WHERE NVO_PortMaster.ID = " + Data.PortIDv;
            return GetViewData(_Query, "");
        }
        public List<MyServiceSetup> BindServiceScheduleMaster(MyServiceSetup Data)
        {
            DataTable dt = GetServiceSchedule(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    ETA = dt.Rows[i]["ETA"].ToString(),

                });
            }


            return ListSS;
        }


        public DataTable GetServiceSchedule(MyServiceSetup Data)
        {

            string _Query = "select RID,ServicesID,PortID,TmTransitTime/100 As TransmitTime,GETDATE() as CurrentDate,convert(varchar, dateadd(hour, TmTransitTime / 100, '" + Data.ETA + "'), 23) as ETA from NVO_ServiceRoute where ServicesID =" + Data.ServiceID;


            return GetViewData(_Query, "");

        }

        public List<MyServiceSetup> VoyageOperatorsEditMaster(MyServiceSetup Data)
        {
            DataTable dt = GetVoyageOperatorValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    OID = Int32.Parse(dt.Rows[i]["OID"].ToString()),
                    OperatorID = Int32.Parse(dt.Rows[i]["OperatorID"].ToString()),
                    Operator = dt.Rows[i]["Operator"].ToString(),
                    SlotRefID = Int32.Parse(dt.Rows[i]["SlotRefID"].ToString()),
                    SlotRef = dt.Rows[i]["SlotRef"].ToString(),

                });
            }


            return ListSS;
        }


        public DataTable GetVoyageOperatorValues(MyServiceSetup Data)
        {

            string _Query = "SELECT * FROM NVO_VoyageOpertaors WHERE VoyageID  =" + Data.ID;


            return GetViewData(_Query, "");

        }
        public List<MyVoyageDetails> InsertVoyageFirstTab(MyVoyageDetails Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_Voyage where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Voyage(ServiceID,VesselID,ETA,RIN,UserID,GeoLocID,IsExpImp,IsTransferred,AgencyID) " +
                                     " values (@ServiceID,@VesselID,@ETA,@RIN,@UserID,@GeoLocID,@IsExpImp,@IsTransferred,@AgencyID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Voyage SET ServiceID=@ServiceID,VesselID=@VesselID,ETA=@ETA,RIN=@RIN,UserID=@UserID,GeoLocID=@GeoLocID,IsTransferred=@IsTransferred,IsExpImp=@IsExpImp,AgencyID=@AgencyID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceID", Data.ServiceID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", Data.ETA));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RIN", Data.RotationNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", "1"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", "1"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", "1"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsExpImp", 0));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsTransferred", 0));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_Voyage')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.ItemsSchedule.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    string ETA = "", ETD = "", ATA = "", ATD = "", ETAMM = "", ETDMM = "", ATAMM = "", ATDMM = "";
                    int intETATm = 0, outETAInt = 0, intETDTm = 0, outETDInt = 0; int intATATm = 0, outATAInt = 0, intATDTm = 0, outATDInt = 0;
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        int.TryParse(CharSplit[6], out outETAInt);
                        intETATm = outETAInt * 100;

                        int.TryParse(CharSplit[9], out outETDInt);
                        intETDTm = outETDInt * 100;

                        int.TryParse(CharSplit[12], out outATAInt);
                        intATATm = outATAInt * 100;

                        int.TryParse(CharSplit[15], out outATDInt);
                        intATDTm = outATDInt * 100;

                        ETA = CharSplit[5];
                        ETD = CharSplit[8];
                        ATA = CharSplit[11];
                        ATD = CharSplit[14];

                        if (CharSplit[7] == "")
                        {
                            ETAMM = "0";
                        }
                        if (CharSplit[10] == "")
                        {
                            ETDMM = "0";
                        }
                        if (CharSplit[13] == "")
                        {
                            ATAMM = "0";
                        }
                        if (CharSplit[16] == "")
                        {
                            ATDMM = "0";
                        }


                        Cmd.CommandText = " IF((select count(*) from NVO_VoyageRoute where VoyageID=@VoyageID and RID=@RID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageRoute(VoyageID,ExportVoyageCd,ImportVoyageCd,PortID,TerminalID,ETA,TmETA,ETD,TmETD,ATA,TmATA,ATD,TmATD) " +
                                     " values (@VoyageID,@ExportVoyageCd,@ImportVoyageCd,@PortID,@TerminalID,@ETA,@TmETA,@ETD,@TmETD,@ATA,@TmATA,@ATD,@TmATD) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageRoute SET VoyageID=@VoyageID,PortID=@PortID,ExportVoyageCd=@ExportVoyageCd,ImportVoyageCd=@ImportVoyageCd,TerminalID=@TerminalID,ETA=@ETA,TmETA=@TmETA,ETD=@ETD,TmETD=@TmETD,ATA=@ATA,TmATA=@TmATA,ATD=@ATD,TmATD=@TmATD where VoyageID=@VoyageID and RID=@RID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExportVoyageCd", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportVoyageCd", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", ETA));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TmETA", intETATm));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", ETD));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TmETD", intETDTm));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ATA", ATA));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TmATA", intATATm));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ATD", ATD));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TmATD", intATDTm));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.ID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                    ListVoyageDtls.Add(new MyVoyageDetails { ID = Data.ID });
                    return ListVoyageDtls;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyageDtls;
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
        public List<MyVoyageDetails> VoyageDetailsView(MyVoyageDetails Data)
        {
            DataTable dt = GetVoyageDetailsView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["Vessel"].ToString(),
                    Service = dt.Rows[i]["Service"].ToString(),
                    RotationNo = dt.Rows[i]["RIN"].ToString(),
                    OBVoyNo = dt.Rows[i]["OBVoyNo"].ToString(),

                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetVoyageDetailsView(MyVoyageDetails Data)
        {
            string strWhere = "";
            string _Query = "Select V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) as Vessel,(select top(1) ServiceName from NVO_Services where ID = V.ServiceID) as Service,(select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as OBVoyNo,RIN from  NVO_Voyage V";

            if (Data.VesselName != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID )  like '%" + Data.VesselName + "%'";
                else
                    strWhere += " and (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID ) like '%" + Data.VesselName + "%'";

            if (Data.VoyageNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) like '%" + Data.VoyageNo + "%'";
                else
                    strWhere += " and (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) like '%" + Data.VoyageNo + "%'";

            ////if (Data.GeoLocID.ToString() != "" && Data.GeoLocID.ToString() != "0" && Data.GeoLocID.ToString() != "undefined")

            ////    if (strWhere == "")
            ////        strWhere += _Query + " V.GeoLocID = " + Data.GeoLocID.ToString() + "";
            ////    else
            ////        strWhere += " and V.GeoLocID = " + Data.GeoLocID.ToString() + "";

            //if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != "undefined")

            //    if (strWhere == "")
            //        strWhere += _Query + "   V.AgencyID = " + Data.AgencyID.ToString() + "";
            //    else
            //        strWhere += " and  V.AgencyID = " + Data.AgencyID.ToString() + "";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }


        public List<MyVoyageDetails> VoyageDetailsEditMaster(MyVoyageDetails Data)
        {
            DataTable dt = GetVoyageDetailsEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    ServiceID = Int32.Parse(dt.Rows[i]["ServiceID"].ToString()),
                    RotationNo = dt.Rows[i]["RIN"].ToString(),
                    ETA = dt.Rows[i]["DtETA"].ToString(),

                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetVoyageDetailsEdit(MyVoyageDetails Data)
        {

            string _Query = "Select convert(varchar, ETA, 23) as DtETA, * from NVO_Voyage where ID=" + Data.ID;

            return GetViewData(_Query, "");


        }

        public List<MyVoyageDetails> VoyageSailingDetailsEditMaster(MyVoyageDetails Data)
        {
            DataTable dt = GetVoyageSailingDetailsEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ExportVoyageCd = dt.Rows[i]["ExportVoyageCd"].ToString(),
                    ImportVoyageCd = dt.Rows[i]["ImportVoyageCd"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    ArrivalETA = dt.Rows[i]["ArrivalETA"].ToString(),
                    TmETA = Int32.Parse(dt.Rows[i]["TMETAr"].ToString()),
                    DepETD = dt.Rows[i]["DepETA"].ToString(),
                    TmETD = Int32.Parse(dt.Rows[i]["TMETDep"].ToString()),
                    ATA = dt.Rows[i]["ATA"].ToString(),
                    TmATA = Int32.Parse(dt.Rows[i]["TMATA"].ToString()),
                    ATD = dt.Rows[i]["ATD"].ToString(),
                    TmATD = Int32.Parse(dt.Rows[i]["TMATD"].ToString()),

                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetVoyageSailingDetailsEdit(MyVoyageDetails Data)
        {

            string _Query = "Select RID,ExportVoyageCd,ImportVoyageCd,PortID,TerminalID,convert(varchar, ETA, 23) as ArrivalETA,TmETA/100 as TMETAr,DayETA,convert(varchar, ETD, 23) as DepETA,TmETD/100 as TMETDep,DayETD,convert(varchar, ATA, 23) as ATA,convert(varchar, ATD, 23) as ATD,TmATA/100 as TMATA,TmATD/100 as TMATD from NVO_VoyageRoute Where VoyageID = " + Data.ID;

            return GetViewData(_Query, "");


        }


        public List<MyVoyageDetails> InsertOperatorServiceValues(MyVoyageDetails Data)
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

                    string[] ArrayOpr = Data.ItemsOpr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    if (ArrayOpr.Length != 1)
                    {
                        for (int i = 1; i < ArrayOpr.Length; i++)
                        {
                            var CharSplit = ArrayOpr[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_VoyageOpertaors where VoyageID=@VoyageID and OID=@OID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_VoyageOpertaors(ServicesID,OperatorID,Operator,SlotRefID,SlotRef,VoyageID) " +
                                         " values (@ServicesID,@OperatorID,@Operator,@SlotRefID,@SlotRef,@VoyageID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_VoyageOpertaors SET ServicesID=@ServicesID,OperatorID=@OperatorID,Operator=@Operator,SlotRefID=@SlotRefID,SlotRef=@SlotRef,VoyageID=@VoyageID where VoyageID=@VoyageID and OID=@OID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OperatorID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Operator", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRefID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRef", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ServicesID", Data.ServiceID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.ID));

                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }
                    trans.Commit();

                    ListSS.Add(new MyServiceSetup { ID = Data.ID });
                    return ListVoyageDtls;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyageDtls;
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
        public List<MyServiceSetup> VoyageOperatorsDeleteValues(MyServiceSetup Data)
        {
            DataTable dt = GetVoyageOperatorsDeleteValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSS.Add(new MyServiceSetup
                {

                    OID = Int32.Parse(dt.Rows[i]["OID"].ToString()),


                });
            }


            return ListSS;
        }


        public DataTable GetVoyageOperatorsDeleteValues(MyServiceSetup Data)
        {

            string _Query = "Delete from NVO_VoyageOpertaors where OID=" + Data.OID;

            return GetViewData(_Query, "");


        }


        public List<MyVoyageDetails> BerthingPortDropdownList(MyVoyageDetails Data)
        {
            DataTable dt = GetBerthingPortDropdown(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Name = dt.Rows[i]["Name"].ToString(),

                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetBerthingPortDropdown(MyVoyageDetails Data)
        {

            string _Query = "  select Top 1 NVO_VoyageRoute.RID AS ID, NVO_PortMaster.PortName+'-'+convert(varchar,NVo_VoyageRoute.ETA,103) as Name from NVo_VoyageRoute Inner join NVO_Voyage on NVO_Voyage.ID = VoyageID inner join NVO_PortMaster on NVo_VoyageRoute.PortID = NVO_PortMaster.ID  where VoyageID = " + Data.ID + " order By RID ASC ";

            return GetViewData(_Query, "");


        }

        public List<MyVoyageDetails> InsertBerthingDtlsValues(MyVoyageDetails Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_VoyageBerthingDtls where VoyageRouteID=@VoyageRouteID and VoyageID=@VoyageID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageBerthingDtls(VoyageRouteID,DtArrival,DtDeparture,DtPilotOnBoard1,DtVesselBerth,DtDischargedCommenced,DtDischargedCompleted,DtLoadingCommenced,DtLoadingCompleted,DtPilotOnBoard2,DtGeneralCutOff,VCNNumber,PortClearance,VoyageID) " +
                                     " values (@VoyageRouteID,@DtArrival,@DtDeparture,@DtPilotOnBoard1,@DtVesselBerth,@DtDischargedCommenced,@DtDischargedCompleted,@DtLoadingCommenced,@DtLoadingCompleted,@DtPilotOnBoard2,@DtGeneralCutOff,@VCNNumber,@PortClearance,@VoyageID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageBerthingDtls SET VoyageRouteID=@VoyageRouteID,DtArrival=@DtArrival,DtDeparture=@DtDeparture,DtPilotOnBoard1=@DtPilotOnBoard1,DtVesselBerth=@DtVesselBerth,DtDischargedCommenced=@DtDischargedCommenced,DtDischargedCompleted=@DtDischargedCompleted,DtLoadingCommenced=@DtLoadingCommenced,DtLoadingCompleted=@DtLoadingCompleted,DtPilotOnBoard2=@DtPilotOnBoard2,DtGeneralCutOff=@DtGeneralCutOff,VCNNumber=@VCNNumber,PortClearance=@PortClearance,VoyageID=@VoyageID where VoyageRouteID=@VoyageRouteID";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageRouteID", Data.VoyageRouteID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.ID));
                    if (Data.DtArrival != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtArrival", DateTime.Parse(Data.DtArrival).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtArrival", DBNull.Value));

                    if (Data.DtDeparture != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDeparture", DateTime.Parse(Data.DtDeparture).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDeparture", DBNull.Value));


                    if (Data.DtPilotOnBoard1 != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPilotOnBoard1", DateTime.Parse(Data.DtPilotOnBoard1).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPilotOnBoard1", DBNull.Value));

                    if (Data.DtVesselBerth != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtVesselBerth", DateTime.Parse(Data.DtVesselBerth).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtVesselBerth", DBNull.Value));

                    if (Data.DtDischargedCommenced != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDischargedCommenced", DateTime.Parse(Data.DtDischargedCommenced).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDischargedCommenced", DBNull.Value));

                    if (Data.DtDischargedCompleted != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDischargedCompleted", DateTime.Parse(Data.DtDischargedCompleted).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtDischargedCompleted", DBNull.Value));


                    if (Data.DtLoadingCommenced != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtLoadingCommenced", DateTime.Parse(Data.DtLoadingCommenced).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtLoadingCommenced", DBNull.Value));

                    if (Data.DtLoadingCompleted != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtLoadingCompleted", DateTime.Parse(Data.DtLoadingCompleted).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtLoadingCompleted", DBNull.Value));

                    if (Data.DtPilotOnBoard2 != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPilotOnBoard2", DateTime.Parse(Data.DtPilotOnBoard2).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPilotOnBoard2", DBNull.Value));

                    if (Data.DtGeneralCutOff != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtGeneralCutOff", DateTime.Parse(Data.DtGeneralCutOff).ToString("yyyy-MM-dd h:mm tt")));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtGeneralCutOff", DBNull.Value));


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VCNNumber", Data.VCNNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortClearance", Data.PortClearance));


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    trans.Commit();

                    ListVoyageDtls.Add(new MyVoyageDetails { VoyageRouteID = Data.VoyageRouteID });
                    return ListVoyageDtls;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyageDtls;
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

        public List<MyVoyageDetails> BindBerthingDetailsValues(MyVoyageDetails Data)
        {
            DataTable dt = GetBindBerthingDetail(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    VoyageRouteID = Int32.Parse(dt.Rows[i]["VoyageRouteID"].ToString()),
                    DtArrival = dt.Rows[i]["DtArrival"].ToString(),
                    DtVesselBerth = dt.Rows[i]["DtVesselBerth"].ToString(),
                    DtDeparture = dt.Rows[i]["DtDeparture"].ToString(),
                    DtDischargedCommenced = dt.Rows[i]["DtDischargedCommenced"].ToString(),
                    DtLoadingCommenced = dt.Rows[i]["DtLoadingCommenced"].ToString(),
                    DtPilotOnBoard1 = dt.Rows[i]["DtPilotOnBoard1"].ToString(),
                    DtDischargedCompleted = dt.Rows[i]["DtDischargedCompleted"].ToString(),
                    DtLoadingCompleted = dt.Rows[i]["DtLoadingCompleted"].ToString(),
                    DtPilotOnBoard2 = dt.Rows[i]["DtPilotOnBoard2"].ToString(),
                    DtGeneralCutOff = dt.Rows[i]["DtGeneralCutOff"].ToString(),
                    VCNNumber = dt.Rows[i]["VCNNumber"].ToString(),
                    PortClearance = dt.Rows[i]["PortClearance"].ToString(),
                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetBindBerthingDetail(MyVoyageDetails Data)
        {

            string _Query = " Select VoyageRouteID, FORMAT(DtArrival, 'yyyy-MM-ddTHH:mm:ss') as  DtArrival, FORMAT(DtDeparture, 'yyyy-MM-ddTHH:mm:ss') as DtDeparture,  FORMAT(DtDischargedCommenced, 'yyyy-MM-ddTHH:mm:ss') as DtDischargedCommenced, FORMAT(DtDischargedCompleted, 'yyyy-MM-ddTHH:mm:ss') as DtDischargedCompleted,   FORMAT(DtGeneralCutOff, 'yyyy-MM-ddTHH:mm:ss') as DtGeneralCutOff, FORMAT(DtLoadingCommenced, 'yyyy-MM-ddTHH:mm:ss') as DtLoadingCommenced,FORMAT(DtLoadingCompleted, 'yyyy-MM-ddTHH:mm:ss') as DtLoadingCompleted, FORMAT(DtPilotOnBoard1, 'yyyy-MM-ddTHH:mm:ss') as DtPilotOnBoard1,  FORMAT(DtPilotOnBoard2, 'yyyy-MM-ddTHH:mm:ss') as DtPilotOnBoard2,  FORMAT(DtVesselBerth, 'yyyy-MM-ddTHH:mm:ss') as DtVesselBerth,VCNNumber,PortClearance from NVO_VoyageBerthingDtls where  VoyageID =" + Data.ID;

            return GetViewData(_Query, "");


        }


        public List<MyVoyageDetails> InsertManifestDtlsValues(MyVoyageDetails Data)
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

                        Cmd.CommandText = " IF((select count(*) from NVO_VoyageManifestDtls where VoyageID=@VoyageID and MID=@MID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageManifestDtls(VoyageID,EGMNo,EGMDate,IGMNo,IGMDate) " +
                                     " values (@VoyageID,@EGMNo,@EGMDate,@IGMNo,@IGMDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageManifestDtls SET VoyageID=@VoyageID,EGMNo=@EGMNo,EGMDate=@EGMDate,IGMNo=@IGMNo,IGMDate=@IGMDate where VoyageID=@VoyageID and MID=@MID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMNo", CharSplit[1]));

                        if (CharSplit[2] != "")
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMDate", CharSplit[2]));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMDate", DBNull.Value));
                        }

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMNo", CharSplit[3]));

                        if (CharSplit[4] != "")
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", CharSplit[4]));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", DBNull.Value));
                        }

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.ID));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListSS.Add(new MyServiceSetup { ID = Data.ID });
                    return ListVoyageDtls;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyageDtls;
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

        public List<MyVoyageDetails> ViewManifestDtlsValues(MyVoyageDetails Data)
        {
            DataTable dt = GetViewManifestDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    MID = Int32.Parse(dt.Rows[i]["MID"].ToString()),
                    EGMNo = dt.Rows[i]["EGMNo"].ToString(),
                    EGMDate = dt.Rows[i]["EGMDt"].ToString(),
                    IGMNo = dt.Rows[i]["IGMNo"].ToString(),
                    IGMDate = dt.Rows[i]["IGMDt"].ToString(),

                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetViewManifestDtls(MyVoyageDetails Data)
        {

            string _Query = "Select replace(convert(NVARCHAR, EGMDate, 23), ' ', '-') as EGMDt,replace(convert(NVARCHAR, IGMDate, 23), ' ', '-') as IGMDt, *  from  NVO_VoyageManifestDtls where  VoyageID =" + Data.ID;

            return GetViewData(_Query, "");


        }





        public List<MyVoyageDetails> BkgVoyageOperatorValidation(MyVoyageDetails Data)
        {
            DataTable dt = GetBkgVoyageOperatorValidation(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    VesOperator = dt.Rows[i]["SlotOperatorID"].ToString()
                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetBkgVoyageOperatorValidation(MyVoyageDetails Data)
        {

            string _Query = "Select * from NVO_Booking where  BkgStatus=1 and vesvoyID=" + Data.ID;

            return GetViewData(_Query, "");


        }
        public List<MyVoyageDetails> SendEmailPopUpVoyDtls(MyVoyageDetails Data)
        {
            DataTable dt = GetSendEmailPopUpVoyDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["Vessel"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyNo"].ToString(),

                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetSendEmailPopUpVoyDtls(MyVoyageDetails Data)
        {

            string _Query = "select ID,(select top 1 VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) Vessel, (select top 1 ExportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID) VoyNo from NVO_Voyage where ID = " + Data.ID;

            return GetViewData(_Query, "");


        }
        public List<MyVoyageDetails> VoyBookingPartyEmailDtls(MyVoyageDetails Data)
        {
            DataTable dt = GetVoyBookingPartyEmailDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyageDtls.Add(new MyVoyageDetails
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString()
                });
            }


            return ListVoyageDtls;
        }


        public DataTable GetVoyBookingPartyEmailDtls(MyVoyageDetails Data)
        {

            string _Query = "select ID,BookingNo,BkgParty,BkgPartyID,VesVoy,(select top 1 EmailID from NVO_CusBranchLocation where CID = BkgPartyID) Email from NVO_Booking where VesvoyID = " + Data.ID;

            return GetViewData(_Query, "");


        }


        public List<MyVoyageDetails> InsertVoyageNotes(MyVoyageDetails Data)
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

                        Cmd.CommandText = " IF((select count(*) from NVO_VoyageNotes where VoyageID=@VoyageID and NID=@NID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyageNotes(VoyageID,VoyageTypeID,Notes,VoyageType) " +
                                     " values (@VoyageID,@VoyageTypeID,@Notes,@VoyageType) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyageNotes SET VoyageID=@VoyageID,VoyageTypeID=@VoyageTypeID,Notes=@Notes,VoyageType=@VoyageType where VoyageID=@VoyageID and NID=@NID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageType", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.ID));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListSS.Add(new MyServiceSetup { ID = Data.ID });
                    return ListVoyageDtls;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyageDtls;
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

        public List<MyGeneralMaster> VoyageTypsDtls(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneral = new List<MyGeneralMaster>();
            DataTable dt = GetVoyageTypesValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyGeneralMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),
                });
            }


            return ListGeneral;
        }
        public DataTable GetVoyageTypesValues(MyGeneralMaster Data)
        {
            string _Query = "select ID,GeneralName from NVO_GeneralMaster where Seqno =73";
            return GetViewData(_Query, "");
        }
        public List<MyVoyageDetails> VoyageNotesDtls(MyVoyageDetails Data)
        {

            DataTable dt = GetVoyageNotesValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyNotes.Add(new MyVoyageDetails
                {
                    NID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    VoyageTypeID = Int32.Parse(dt.Rows[i]["VoyageTypeID"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    VoyageType = dt.Rows[i]["VoyageType"].ToString(),
                });
            }


            return ListVoyNotes;
        }
        public DataTable GetVoyageNotesValues(MyVoyageDetails Data)
        {
            string _Query = "select * from NVO_VoyageNotes";
            return GetViewData(_Query, "");
        }
        public List<MyVoyageDetails> VoyageNotesDeleteDtls(MyVoyageDetails Data)
        {
            DataTable dt = GetServiceOperatorsDeleteValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyNotes.Add(new MyVoyageDetails
                {
                    NID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                });
            }
            return ListVoyNotes;
        }

        public DataTable GetServiceOperatorsDeleteValues(MyVoyageDetails Data)
        {
            string _Query = "Delete from NVO_VoyageNotes where NID=" + Data.NID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Voyage Opening
        List<MyVoyageOpening> ListVoyOpen = new List<MyVoyageOpening>();
        public List<MyVoyageOpening> ListVoyageOpening(MyVoyageOpening Data)
        {
            DataTable dt = GetListVoyageOpening(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Voyage = dt.Rows[i]["VesVoy"].ToString(),
                    LoadPort = dt.Rows[i]["LoadPort"].ToString(),
                    OpenID = Int32.Parse(dt.Rows[i]["OpenID"].ToString()),
                    OpenStatus = dt.Rows[i]["OpenStatus"].ToString(),
                });
            }


            return ListVoyOpen;
        }


        public DataTable GetListVoyageOpening(MyVoyageOpening Data)
        {
            string strWhere = "";

            string _Query = "  Select Distinct V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as VesVoy,(select top(1) PortName from NVO_PortMainMaster inner join NVO_VoyageRoute on NVO_VoyageRoute.PortID = NVO_PortMainMaster.ID where NVO_VoyageRoute.VoyageID = V.ID  ORDER BY RID ASC) as LoadPort," +
              "  isnull((select top(1) VID from NVO_VoyageOpen where PrevVoyageID = V.ID),0) as OpenID, CASE WHEN  isnull((select top(1) VID from NVO_VoyageOpen where PrevVoyageID = V.ID),0) = '0' Then 'Not Opened' Else 'Already Opened' End OpenStatus " +
                " from NVO_Voyage V inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = V.ID inner join NVO_V_VoyLockStatusMain on NVO_V_VoyLockStatusMain.VesVoyId = V.ID inner join NVO_V_VoyLockStatus on NVO_V_VoyLockStatus.VesVoyId = V.ID inner join NVO_Booking on NVO_Booking.ID = NVO_V_VoyLockStatus.ID where NVO_Booking.DestinationAgentID =" + Data.AgencyID + " or  NVO_Booking.TranshipmetAgentID =" + Data.AgencyID;

            /*     " NVO_V_VoyLockStatusMain.IsBLLocked = NVO_V_VoyLockStatusMain.DD and */
            //WHERE V.IsTransferred = 0 AND  (select top(1) PortID from NVO_VoyageRoute where VoyageID = V.ID order by RID Desc ) in (" + Data.ItemPortIDs +") and IsExpImp = 0 ";

            //if (Data.Voyage != "")
            //    if (strWhere == "")
            //        strWhere += _Query + " where G.GeoLocation like '%" + Data.GeoLocation + "%'";
            //    else
            //        strWhere += " and G.GeoLocation like '%" + Data.GeoLocation + "%'";

            //if (Data.CountryID.ToString() != "" && Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "?")

            //    if (strWhere == "")
            //        strWhere += _Query + " where G.CountryID = " + Data.CountryID.ToString();
            //    else
            //        strWhere += " and G.CountryID = " + Data.CountryID.ToString();

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, "");

        }

        public List<MyVoyageOpening> ListVoyageOpeningEdit(MyVoyageOpening Data)
        {
            DataTable dt = GetVoyageOpeningEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VesselName = dt.Rows[i]["Vessel"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    OpenStatus = dt.Rows[i]["OpenStatus"].ToString(),
                    OpenedETA = dt.Rows[i]["OpenedETA"].ToString(),
                    DisChargeVoyNo = dt.Rows[i]["DisVoyageNo"].ToString(),
                    DiscTerminalID = Int32.Parse(dt.Rows[i]["DiscTerminalID"].ToString()),
                    OpenID = Int32.Parse(dt.Rows[i]["OpenID"].ToString()),
                    OpenedVoyID = Int32.Parse(dt.Rows[i]["OpenedVoyID"].ToString()),
                });
            }


            return ListVoyOpen;
        }


        public DataTable GetVoyageOpeningEdit(MyVoyageOpening Data)
        {
            string _Query = "select NVO_Voyage.ID,NVO_Voyage.VesselID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) as Vessel,  replace(convert(NVARCHAR, ETA, 103), ' ', '-') as ETA, (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID) as VoyageNo,(select top(1) PortName from NVO_PortMaster " +
         " inner join NVO_VoyageRoute on NVO_VoyageRoute.PortID = NVO_PortMaster.ID  where ID = NVO_VoyageRoute.PortID ) as LoadPort,CASE WHEN  isnull((select top(1) VID from NVO_VoyageOpen where PrevVoyageID = NVO_Voyage.ID),0) = '0' Then 'Not Opened' Else 'Already Opened' End OpenStatus, " +
          " isnull((select top(1) VID from NVO_VoyageOpen where PrevVoyageID = NVO_Voyage.ID),0) as OpenID," +
          "  isnull(convert(varchar, (select top(1) ETA from NVO_VoyageOpen where PrevVoyageID = NVO_Voyage.ID), 23),'') as OpenedETA, " +
        " isnull((select top(1) DisVoyageNo from NVO_VoyageOpen where PrevVoyageID = NVO_Voyage.ID),'') as DisVoyageNo,  " +
        "  isnull((select top(1) VoyageID from NVO_VoyageOpen where PrevVoyageID = NVO_Voyage.ID),'') as OpenedVoyID, " +
       " isnull((select top(1) TM.ID from NVO_VoyageOpen inner join NVO_TerminalMaster TM ON TM.ID = NVO_VoyageOpen.TerminalID where PrevVoyageID = NVO_Voyage.ID) ,0) as DiscTerminalID from NVO_Voyage  where NVO_Voyage.ID = " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> PortByGeoLoc(MyVoyageOpening Data)
        {
            DataTable dt = GetPortByGeoLoc(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString(),


                });
            }


            return ListVoyOpen;
        }


        public DataTable GetPortByGeoLoc(MyVoyageOpening Data)
        {
            string _Query = "select ID,PortName from NVO_PortMaster WHERE GeoLocID = " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> TerminalDropDownByPortGeoLoc(MyVoyageOpening Data)
        {
            DataTable dt = GetTerminalDropDownByPort(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Terminal = dt.Rows[i]["TerminalName"].ToString(),


                });
            }


            return ListVoyOpen;
        }


        public DataTable GetTerminalDropDownByPort(MyVoyageOpening Data)
        {
            string _Query = "select TM.ID,TerminalName from NVO_TerminalMaster TM INNER JOIN NVO_PortMaster PM ON PM.ID = TM.PortID WHERE PM.GeoLocID = " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> VoyageOpeningEditBLDetails(MyVoyageOpening Data)
        {
            DataTable dt = GetVoyageOpeningEditBLDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {
                    ID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    TSPort = dt.Rows[i]["TSPORT"].ToString(),
                    CntrStatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),

                });
            }


            return ListVoyOpen;
        }


        public DataTable GetVoyageOpeningEditBLDetails(MyVoyageOpening Data)
        {
            string _Query = " select DISTINCT  BL.ID AS BLID,BL.bkgid,BL.BLNumber,(select top(1) PortName from NVO_PortMaster where ID = BL.POLID) As POL, " +
         " (select top(1) PortName from NVO_PortMaster where ID = BL.PODID) As POD,(select top(1) PortName from NVO_PortMaster where ID = B.TSPORTID) As TSPORT, " +
         "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + CntrNo  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS CntrNo FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as CntrNo, " +
         "  (select top(1) case when Type IN(1,11) THEN 'BL NOT RELEASED' ELSE 'RELEASED' END  from NVO_BLPrintLog where BKGID = B.ID order by ID desc) As BLStatus ," +
         "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + StatusCode  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID   FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS StatusCode FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as Statuscode  from NVO_BOL BL" +
          //" inner join NVO_BOLVoyageDetails ON NVO_BOLVoyageDetails.BLID = BL.ID " +
          " inner join NVO_Booking B ON B.ID = BL.BKGID inner join NVO_BOLCNTRDetails BC ON BC.BLID = BL.ID   LEFT OUTER join NVO_VoyageOpenBLdtls OP ON OP.BLID = BL.ID Where BL.BLVesVoyID = " + Data.ID + " OR OP.VoyageID = " + Data.ID + " and ISNULL(BL.IsBLLocked,0) = 1   ";


            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> VoyageUnOpenedBLDetails(MyVoyageOpening Data)
        {
            DataTable dt = GetVoyageUnOpenedBLDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {
                    ID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    TSPort = dt.Rows[i]["TSPORT"].ToString(),
                    CntrStatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),

                });
            }


            return ListVoyOpen;
        }


        public DataTable GetVoyageUnOpenedBLDetails(MyVoyageOpening Data)
        {
            string _Query = " select DISTINCT  BL.ID AS BLID,BL.bkgid,BL.BLNumber,(select top(1) PortName from NVO_PortMaster where ID = BL.POLID) As POL, " +
         " (select top(1) PortName from NVO_PortMaster where ID = BL.PODID) As POD,(select top(1) PortName from NVO_PortMaster where ID = B.TSPORTID) As TSPORT, " +
         "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + CntrNo  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS CntrNo FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as CntrNo, " +
         "  (select top(1) case when Type IN(1,11) THEN 'BL NOT RELEASED' ELSE 'RELEASED' END  from NVO_BLPrintLog where BKGID = B.ID order by ID desc) As BLStatus ," +
         "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + StatusCode  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID   FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS StatusCode FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as Statuscode  from NVO_BOL BL" +
          //" inner join NVO_BOLVoyageDetails ON NVO_BOLVoyageDetails.BLID = BL.ID " +
          " inner join NVO_Booking B ON B.ID = BL.BKGID inner join NVO_BOLCNTRDetails BC ON BC.BLID = BL.ID Where BL.BLVesVoyID = " + Data.ID + " and ISNULL(BL.IsBLLocked,0) = 1 and BL.ID  not IN (select BLID from NVO_VoyageOpenBLdtls ) ";


            return GetViewData(_Query, "");
        }
        public List<MyVoyageOpening> InsertVoyageOpening(MyVoyageOpening Data)
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
                string NewVoyID = "0";
                int r, ct;
                try
                {
                    if (Data.OpenedVoyID.ToString() == "0")
                    {

                        Cmd.CommandText = "INSERT INTO NVO_Voyage (ServiceID,VesselID,ETA,RIN,UserID,GeoLocID,IsExpImp,AgencyID,IsTransferred) " +
                             " SELECT ServiceID,VesselID,'" + Data.ETA + "',''," + Data.UserID + "," + Data.GeoLocID + ",1," + Data.AgencyID + ",0 FROM NVO_Voyage WHERE ID=" + Data.ID + "";

                        Cmd.ExecuteNonQuery();

                        Cmd.CommandText = "SELECT Ident_current('NVO_Voyage')";
                        NewVoyID = Cmd.ExecuteScalar().ToString();

                        Cmd.CommandText = "INSERT INTO  NVO_VoyageRoute(VoyageID,ExportVoyageCd,ImportVoyageCd,PortID,TerminalID,ETA,DayETA,TmETA,ETD,DayETD,TmETD) " +
                          " SELECT Top 1 " + NewVoyID + ", '" + Data.VoyageNo + "','" + Data.VoyageNo + "',PortID,TerminalID,ETA,DayETA,TmETA,ETD,DayETD,TmETD from  NVO_VoyageRoute WHERE VoyageID=" + Data.ID + " ORDER By NVO_VoyageRoute.RID DESC ";
                        Cmd.ExecuteNonQuery();
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.ID));
                        // Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID",99));

                        Cmd.CommandText = "Update NVO_Voyage set IsTransferred =1 where ID=" + Data.ID + "";
                        Cmd.ExecuteNonQuery();

                        Cmd.CommandText = " IF((select count(*) from NVO_VoyageOpen where VoyageID=@VoyageID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_VoyageOpen(VoyageID,VesselID,DisVoyageNo,ETA,TerminalID,PrevVoyageID,AgencyID,UserID) " +
                                         " values (@VoyageID,@VesselID,@DisVoyageNo,@ETA,@TerminalID,@PrevVoyageID,@AgencyID,@UserID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_VoyageOpen SET VoyageID=@VoyageID,VesselID=@VesselID,DisVoyageNo=@DisVoyageNo,ETA=@ETA,TerminalID=@TerminalID,PrevVoyageID=@PrevVoyageID,AgencyID=@AgencyID,UserID=@UserID where VoyageID=@VoyageID";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DisVoyageNo", Data.VoyageNo));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", Data.ETA));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", Data.TerminalID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Int32.Parse(NewVoyID)));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrevVoyageID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);

                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = "INSERT INTO  NVO_VoyageOpenBLdtls(BLID,VoyageID) values (@BLID,@VoyageID)";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Int32.Parse(NewVoyID)));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }


                        ListVoyOpen.Add(new MyVoyageOpening
                        {
                            ID = Int32.Parse(NewVoyID.ToString())

                        });



                        if (Data.TerminalID.ToString() != "")
                        {
                            Cmd.CommandText = "Update  NVO_VoyageRoute set TerminalID = " + Data.TerminalID + " WHERE RID In (Select top (1) RID  from NVO_VoyageRoute where VoyageID=" + NewVoyID + "  ORDER BY RID DESC) ";

                            Cmd.ExecuteNonQuery();

                        }

                        Cmd.CommandText = "Update  NVO_VoyageRoute set ETA = '" + Data.ETA + "', ETD = '" + Data.ETA + "' WHERE RID In (Select top (1) RID  from NVO_VoyageRoute " +
                            " where VoyageID=" + NewVoyID + "  ORDER BY RID DESC) ";
                        Cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);

                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = "INSERT INTO  NVO_VoyageOpenBLdtls(BLID,VoyageID) values (@BLID,@VoyageID)";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.OpenedVoyID));
                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }

                    }
                    trans.Commit();

                    return ListVoyOpen;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListVoyOpen;
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

        #region Voyage Locking

        public List<MyVoyageOpening> VoyageLockingRecView(MyVoyageOpening Data)
        {
            List<MyVoyageOpening> ViewList = new List<MyVoyageOpening>();
            DataTable dt = GetVoyageLockingRecView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyVoyageOpening
                {
                    ID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    CurrentPort = dt.Rows[i]["CurrentPort"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    StatusV = dt.Rows[i]["Status"].ToString(),
                });
            }
            return ViewList;
        }
        public DataTable GetVoyageLockingRecView(MyVoyageOpening Data)
        {
            string strWhere = "";
            string _Query = " Select  Distinct  V.ID As VoyageID,(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = V.VesselID ) + '-' + " +
             " (select top(1) VR.ExportVoyageCd from NVO_VoyageRoute VR where VR.VoyageID = V.ID order by VR.RID asc) as VesVoy,(Select Top 1 PORTNAME from NVO_PortMainMaster " +
         " where NVO_PortMainMaster.ID = (select top(1) PortID from NVO_VoyageRoute VR where VR.VoyageID = V.ID order by VR.RID asc)) AS CurrentPort, " +
         " (Select Top 1 PORTNAME from NVO_PortMainMaster where NVO_PortMainMaster.ID = (select top(1) PortID from NVO_VoyageRoute VR " +
        " where VR.VoyageID = V.ID order by Vr.RID desc)) AS NextPort," +
        "     case when  (select Case when dd <= isBLLocked  then 'Locked' else 'Partially Locked'  end from NVO_V_VoyLockStatusMain where NVO_V_VoyLockStatusMain.VesVoyID = V.ID) != 'NULL' then   (select Case when dd <= isBLLocked  then 'Locked' else 'Partially Locked'  end from NVO_V_VoyLockStatusMain where NVO_V_VoyLockStatusMain.VesVoyID = V.ID) else 'Pending' end AS Status from NVO_Voyage V where IsExpImp=0 and ";


            if (Data.VesVoy != "" && Data.VesVoy != "0" && Data.VesVoy != "undefined" && Data.VesVoy != null)

                if (strWhere == "")
                    strWhere += _Query + "  V.ID  = " + Data.VesVoy.ToString() + "";
                else
                    strWhere += " and  V.ID = " + Data.VesVoy.ToString() + "";

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != "undefined" && Data.AgencyID.ToString() != null)

                if (strWhere == "")
                    strWhere += _Query + "   V.AgencyID = " + Data.AgencyID.ToString() + "";
                else
                    strWhere += " and  V.AgencyID = " + Data.AgencyID.ToString() + "";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyVoyageOpening> VoyageLockingDetailsEdit(MyVoyageOpening Data)
        {
            List<MyVoyageOpening> ViewList = new List<MyVoyageOpening>();
            DataTable dt = GetVoyageLockingDetailsEdit(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyVoyageOpening
                {
                    ID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    StatusV = dt.Rows[i]["Status"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                });
            }
            return ViewList;
        }
        public DataTable GetVoyageLockingDetailsEdit(MyVoyageOpening Data)
        {
            string _Query = "    select ID As VoyageID,convert(varchar, (select top(1)ETD from NVO_VoyageRoute VR where VR.VoyageID = NVO_Voyage.ID order by VR.RID asc),23)as ETD,    case when  (select Case when dd <= isBLLocked  then 'Locked' else 'Partially Locked'  end from NVO_V_VoyLockStatusMain where NVO_V_VoyLockStatusMain.VesVoyID = " + Data.ID + ") != 'NULL' then (select Case when dd <= isBLLocked  then 'Locked' else 'Partially Locked'  end from NVO_V_VoyLockStatusMain where NVO_V_VoyLockStatusMain.VesVoyID = " + Data.ID + ")  else 'Pending' end AS Status from NVO_Voyage WHERE ID = " + Data.ID + "";
            return GetViewData(_Query, "");
        }
        public List<MyVoyageOpening> VesVoyMaster(MyVoyageOpening Data)
        {
            List<MyVoyageOpening> ViewList = new List<MyVoyageOpening>();
            DataTable dt = GetVesselVoyageMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyVoyageOpening
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetVesselVoyageMaster(MyVoyageOpening Data)
        {
            string _Query = "Select V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as VesVoy from NVO_Voyage V WHERE V.ISExpImp=0 and V.AgencyID=" + Data.AgencyID + "";
            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> VoyageLockingBLDetails(MyVoyageOpening Data)
        {
            DataTable dt = GetVoyageLockingBLDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {

                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    TSPort = dt.Rows[i]["TSPORT"].ToString(),
                    CntrStatusCodev = dt.Rows[i]["StatusCode"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    StatusV = dt.Rows[i]["BLStatus"].ToString(),
                });
            }


            return ListVoyOpen;
        }


        public DataTable GetVoyageLockingBLDetails(MyVoyageOpening Data)
        {
            string _Query = " select DISTINCT  BL.ID AS BLID,BL.bkgid,BL.BLNumber,(select top(1) PortName from NVO_PortMaster where ID = BL.POLID) As POL, " +
          " (select top(1) PortName from NVO_PortMaster where ID = BL.PODID) As POD,(select top(1) PortName from NVO_PortMaster where ID = B.TSPORTID) As TSPORT, " +
          "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + CntrNo  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS CntrNo FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as CntrNo, " +
          "  (select top(1) case when Type IN(1,11) THEN 'BL NOT RELEASED' ELSE 'RELEASED' END  from NVO_BLPrintLog where BKGID = B.ID order by ID desc) As BLStatus ," +
          "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + StatusCode  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID   FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS StatusCode FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as Statuscode  from NVO_BOL BL " +
           //" inner join NVO_BOLVoyageDetails ON NVO_BOLVoyageDetails.BLID = BL.ID " +
           " inner join NVO_Booking B ON B.ID = BL.BKGID inner join NVO_BOLCNTRDetails BC ON BC.BLID = BL.ID Where BL.blvesvoyid = " + Data.ID + " and ISNULL(BL.IsBLLocked,0) <> 1 and ISNULL(BL.BLDirect,0) = 1 ";

            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> VoyageLockedBLDetails(MyVoyageOpening Data)
        {
            DataTable dt = GetVoyageLockedBLDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyOpen.Add(new MyVoyageOpening
                {

                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    TSPort = dt.Rows[i]["TSPORT"].ToString(),
                    CntrStatusCodev = dt.Rows[i]["StatusCode"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    StatusV = dt.Rows[i]["BLStatus"].ToString(),
                });
            }


            return ListVoyOpen;
        }


        public DataTable GetVoyageLockedBLDetails(MyVoyageOpening Data)
        {
            string _Query = " select DISTINCT  BL.ID AS BLID,BL.bkgid,BL.BLNumber,(select top(1) PortName from NVO_PortMaster where ID = BL.POLID) As POL, " +
          " (select top(1) PortName from NVO_PortMaster where ID = BL.PODID) As POD,(select top(1) PortName from NVO_PortMaster where ID = B.TSPORTID) As TSPORT, " +
          "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + CntrNo  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS CntrNo FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as CntrNo, " +
          "  (select top(1) case when Type IN(1,11) THEN 'BL NOT RELEASED' ELSE 'RELEASED' END  from NVO_BLPrintLog where BKGID = B.ID order by ID desc) As BLStatus ," +
          "  (SELECT top(1)  STUFF((SELECT CAST(',' AS varchar(max)) + StatusCode  FROM NVO_V_CntrMultipleBL as bb  WHERE bb.BkgId = a.BkgId and bb.BkgId = B.ID   FOR XML PATH(''), TYPE).value('.', 'varchar(max)'),1, 1,'') AS StatusCode FROM(SELECT DISTINCT BkgId FROM NVO_V_CntrMultipleBL  where NVO_V_CntrMultipleBL.BkgId = B.ID) AS a) as Statuscode  from NVO_BOL BL " +
           //"inner join NVO_BOLVoyageDetails ON NVO_BOLVoyageDetails.BLID = BL.ID " +
           " inner join NVO_Booking B ON B.ID = BL.BKGID inner join NVO_BOLCNTRDetails BC ON BC.BLID = BL.ID Where BL.blvesvoyid = " + Data.ID + "  and ISNULL(BL.IsBLLocked,0) = 1  and ISNULL(BL.BLDirect,0) = 1 ";

            return GetViewData(_Query, "");
        }

        public List<MyVoyageOpening> VoyageLockingUpdate(MyVoyageOpening Data)
        {
            List<MyVoyageOpening> ViewList = new List<MyVoyageOpening>();

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
                    string[] Array = Data.GridBLID.TrimEnd(',').Split(',');

                    for (int i = 0; i < Array.Length; i++)
                    {

                        Cmd.CommandText = " Update NVO_BOL set IsBLLocked=@IsBLLocked where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Array[i]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBLLocked", 1));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    ViewList.Add(new MyVoyageOpening
                    {
                        BLID = Data.BLID

                    });
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

        #endregion

        #region NotesandClauses

        public List<MyNotes> NotesandClausesMaster(MyNotes Data)
        {

            List<MyNotes> ViewList = new List<MyNotes>();

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

                        var Des = "";
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        for (int x = 1; x < CharSplit.Length; x++)
                        {
                            Des += CharSplit[x].ToString() + ",";
                        }

                        Cmd.CommandText = " IF((select count(*) from NVO_BLNotesClauses where DocID=@DocID and NID=@NID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BLNotesClauses(Notes,DocID) " +
                                     " values (@Notes,@DocID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BLNotesClauses SET Notes=@Notes,DocID=@DocID where DocID=@DocID and NID=@NID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", Des));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DocID", Data.DocID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        Cmd.CommandText = "select ident_current('NVO_BLNotesClauses')";
                        if (Data.ID == 0)
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        else
                            Data.ID = Data.ID;

                    }
                    trans.Commit();

                    ViewList.Add(new MyNotes { ID = Data.ID });

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

        public List<MyNotes> NotesandClausesView(MyNotes Data)
        {
            List<MyNotes> GeneralList = new List<MyNotes>();
            DataTable dt = GetGeneralMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyNotes
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return GeneralList;
        }

        public DataTable GetGeneralMaster(MyNotes Data)
        {
            string strWhere = "";
            string _Query = "select * from NVO_GeneralMaster where SeqNo =64";

            if (Data.GeneralName != "")
                if (strWhere == "")
                    strWhere += _Query + " and GeneralName like '%" + Data.GeneralName + "%'";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyNotes> NotesandClausesDetails(MyNotes Data)
        {
            List<MyNotes> GeneralList = new List<MyNotes>();
            DataTable dt = GetNotesValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyNotes
                {
                    ID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    DocID = dt.Rows[i]["DocID"].ToString()
                });
            }
            return GeneralList;
        }
        public DataTable GetNotesValues(MyNotes Data)
        {
            string _Query = "select * from NVO_BLNotesClauses where DocID=" + Data.DocID;
            return GetViewData(_Query, "");
        }
        public List<MyNotes> DocumentTypeValues(MyNotes Data)
        {
            List<MyNotes> GeneralList = new List<MyNotes>();
            DataTable dt = GetDocumentDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyNotes
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return GeneralList;
        }
        public DataTable GetDocumentDtls(MyNotes Data)
        {
            string _Query = "select ID, GeneralName  from NVO_GeneralMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyNotes> NotesandClausesDelete(MyNotes Data)
        {
            List<MyNotes> GeneralList = new List<MyNotes>();
            DataTable dt = GetNotesDeleteValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyNotes
                {
                    ID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    DocID = dt.Rows[i]["DocID"].ToString()
                });
            }
            return GeneralList;
        }
        public DataTable GetNotesDeleteValues(MyNotes Data)
        {
            string _Query = "Delete NVO_BLNotesClauses where NID=" + Data.ID + " and DOCID=" + Data.DocID;
            return GetViewData(_Query, "");
        }
        #endregion

        #endregion

        #region UOM MASTER

        List<MyUOM> ListUOM = new List<MyUOM>();

        public List<MyUOM> InsertUOMMaster(MyUOM Data)
        {

            DbConnection con = null;
            DbTransaction trans;

            DataTable dtchk = GetUOMExValues(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (dtchk.Rows.Count >= 1)
                {
                    if (dtchk.Rows[0]["UOMCode"].ToString().ToUpper() == Data.UOMCode.ToUpper() && dtchk.Rows[0]["UOMDesc"].ToString().ToUpper() == Data.UOMDesc.ToUpper())
                    {
                        ListUOM.Add(new MyUOM
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "UOM Code/Description Already Exists"
                        });
                        return ListUOM;
                    }
                    if (dtchk.Rows[0]["UOMCode"].ToString().ToUpper() == Data.UOMCode.ToUpper())
                    {
                        ListUOM.Add(new MyUOM
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "UOM Code Already Exists"
                        });
                        return ListUOM;
                    }
                    if (dtchk.Rows[0]["UOMDesc"].ToString().ToUpper() == Data.UOMDesc.ToUpper())
                    {
                        ListUOM.Add(new MyUOM
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "UOM Description Already Exists"
                        });
                        return ListUOM;
                    }

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

                    Cmd.CommandText = " IF((select count(*) from SA.UOMMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.UOMMaster(UOMCode,UOMDesc,Status,UOMType) " +
                                     " values (@UOMCode,@UOMDesc,@Status,@UOMType) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.UOMMaster SET UOMCode=@UOMCode,UOMDesc=@UOMDesc,Status=@Status,UOMType=@UOMType where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UOMCode", Data.UOMCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UOMDesc", Data.UOMDesc.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UOMType", Data.UOMType));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.UOMMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListUOM.Add(new MyUOM
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListUOM;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListUOM.Add(new MyUOM
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListUOM;
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
        public DataTable GetUOMExValues(MyUOM Data)
        {
            string _Query = "select * from SA.UOMMaster where (ID not in(" + Data.ID + ")) and (UOMCode ='" + Data.UOMCode + "' OR UOMDesc='" + Data.UOMDesc + "')";
            return GetViewData(_Query, "");
        }

        public List<MyUOM> GetUOMMaster(MyUOM Data)
        {
            DataTable dt = GetUOMValues(Data);

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
                int UOM = 0;
                if (dt.Rows[i]["UOMType"].ToString() != "")
                {
                    UOM = Int32.Parse(dt.Rows[i]["UOMType"].ToString());
                }
                else
                {
                    UOM = 0;
                }
                ListUOM.Add(new MyUOM
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMCode = dt.Rows[i]["UOMCode"].ToString(),
                    UOMDesc = dt.Rows[i]["UOMDesc"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                    UOMTypeResult = dt.Rows[i]["UOMTypeResult"].ToString(),
                    Status = St,
                    UOMType = UOM
                });
            }
            return ListUOM;
        }

        public DataTable GetUOMValues(MyUOM Data)
        {
            string strWhere = "";

            string _Query = " select Id,UOMCode,UOMDesc,status,UOMType, " +
                " case when status = 1 then 'YES' when status = 2 then 'NO' ELSE '' END as StatusResult, " +
                " (select top 1 GeneralName from SA.GeneralMaster where ID=UOMType) as UOMTypeResult  from SA.UOMMaster ";

            if (Data.UOMCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where UOMCode like '%" + Data.UOMCode + "%'";
                else
                    strWhere += " and UOMCode like '%" + Data.UOMCode + "%'";

            if (Data.UOMDesc != "")
                if (strWhere == "")
                    strWhere += _Query + " where UOMDesc like '%" + Data.UOMDesc + "%'";
                else
                    strWhere += " and UOMDesc like '%" + Data.UOMDesc + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " Where SA.UOMMaster.Status =" + Data.Status.ToString();
                else
                    strWhere += " and SA.UOMMaster.Status =" + Data.Status.ToString();

            if (Data.UOMType.ToString() != "" && Data.UOMType.ToString() != "0" && Data.UOMType.ToString() != null && Data.UOMType.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " Where SA.UOMMaster.UOMType =" + Data.UOMType.ToString();
                else
                    strWhere += " and SA.UOMMaster.UOMType =" + Data.UOMType.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyUOM> GetUOMMasterRecord(MyUOM Data)
        {
            DataTable dt = GetUOMRecord(Data);

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

                int UOM = 0;
                if (dt.Rows[i]["UOMType"].ToString() != "")
                {
                    UOM = Int32.Parse(dt.Rows[i]["UOMType"].ToString());
                }
                else
                {
                    UOM = 0;
                }
                ListUOM.Add(new MyUOM
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMCode = dt.Rows[i]["UOMCode"].ToString(),
                    UOMDesc = dt.Rows[i]["UOMDesc"].ToString(),
                   // UOMType = Int32.Parse(dt.Rows[i]["UOMType"].ToString()),
                    Status = St,
                    UOMType = UOM

                });
            }
            return ListUOM;
        }

        public DataTable GetUOMRecord(MyUOM Data)
        {
            string _Query = "select * from SA.UOMMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyUOM> GetUOMTypesRecord(MyUOM Data)
        {
            DataTable dt = GetUOMTypesValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
               
                ListUOM.Add(new MyUOM
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMTypes = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListUOM;
        }

        public DataTable GetUOMTypesValues(MyUOM Data)
        {
            string _Query = " select * from sa.GeneralMaster where seqno=3 ";
            return GetViewData(_Query, "");
        }

        public List<MyUOM> GetUOMActionsRecord(MyUOM Data)
        {
            DataTable dt = GetUOMActionsValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;

                ListUOM.Add(new MyUOM
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMActions = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListUOM;
        }

        public DataTable GetUOMActionsValues(MyUOM Data)
        {
            string _Query = " select * from sa.GeneralMaster where seqno=4 ";
            return GetViewData(_Query, "");
        }

        #endregion

        #region Container Type MASTER

        List<MyContType> ListConType = new List<MyContType>();

        public List<MyContType> InsertConTypeMaster(MyContType Data)
        {

            DbConnection con = null;
            DbTransaction trans;

            DataTable dtchk = GetContTypeExValues(Data);

            if (dtchk.Rows.Count >= 1)
            {
                //if (dtchk.Rows[0]["SizeID"].ToString() == Data.SizeID.ToString() && dtchk.Rows[0]["EQTypeID"].ToString() == Data.EQTypeID.ToString())
                //{
                //    ListConType.Add(new MyContType
                //    {
                //        ID = Data.ID,

                //        AlertMegId = "1",
                //        AlertMessage = "Container Type/Equipment Size Already Exists"
                //    });
                //    return ListConType;
                //}
                if (dtchk.Rows[0]["SizeID"].ToString() == Data.SizeID.ToString())
                {
                    ListConType.Add(new MyContType
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Equipment Size Already Exists"
                    });
                    return ListConType;
                }
                //if (dtchk.Rows[0]["EQTypeID"].ToString() == Data.EQTypeID.ToString())
                //{
                //    ListConType.Add(new MyContType
                //    {
                //        ID = Data.ID,

                //        AlertMegId = "1",
                //        AlertMessage = "Container Type Already Exists"
                //    });
                //    return ListConType;
                //}
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

                    Cmd.CommandText = " IF((select count(*) from SA.CntrTypes where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  SA.CntrTypes(Size,Type,ISOCode,SizeID,EQTypeID,Height,Length,Width,TareWeight,MaxPayload,TEUS,REMARKS,groupID,status,CntrTypeDesc) " +
                                     " values (@Size,@Type,@ISOCode,@SizeID,@EQTypeID,@Height,@Length,@Width,@TareWeight,@MaxPayload,@TEUS,@REMARKS,@groupID,@status,@CntrTypeDesc) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE SA.CntrTypes SET Size=@Size,Type=@Type,ISOCode=@ISOCode,SizeID=@SizeID,EQTypeID=@EQTypeID,Height=@Height,Length=@Length,Width=@Width,TareWeight=@TareWeight,MaxPayload=@MaxPayload," +
                                     " TEUS=@TEUS,REMARKS=@REMARKS,groupID=@groupID,status=@status,CntrTypeDesc=@CntrTypeDesc where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Size", Data.Size));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SizeID", Data.SizeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", Data.Type));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EQTypeID", Data.EQTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", Data.ISOCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Height", Data.Height));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Length", Data.Length));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", Data.Width));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TareWeight", Data.TareWeight));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MaxPayload", Data.MaxPayload));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TEUS", Data.TEUS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@groupID", Data.groupID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@status", Data.status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeDesc", Data.CntrTypeDesc));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.CntrTypes')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListConType.Add(new MyContType
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListConType;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListConType.Add(new MyContType
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListConType;
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
        public DataTable GetContTypeExValues(MyContType Data)
        {
            string _Query = "select * from SA.CntrTypes where(ID not in(" + Data.ID + ")) and (SizeID ='" + Data.SizeID + "')";
            return GetViewData(_Query, "");
        }

        public List<MyContType> GetContTypeMaster(MyContType Data)
        {
            DataTable dt = GetContTypeValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListConType.Add(new MyContType
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                });
            }
            return ListConType;
        }

        public DataTable GetContTypeValues(MyContType Data)
        {
            string strWhere = "";

            string _Query = " select Id,Size,Type,ISOCode , Case When SA.CntrTypes.status =1 then 'YES' when SA.CntrTypes.status =2 then 'NO' ELSE '' END as StatusResult  from SA.CntrTypes ";

            if (Data.Size != "")
                if (strWhere == "")
                    strWhere += _Query + " where Size like '%" + Data.Size + "%'";
                else
                    strWhere += " and Size like '%" + Data.Size + "%'";

            if (Data.Type != "")
                if (strWhere == "")
                    strWhere += _Query + " where Type like '%" + Data.Type + "%'";
                else
                    strWhere += " and Type like '%" + Data.Type + "%'";

            if (Data.ISOCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where ISOCode like '%" + Data.ISOCode + "%'";
                else
                    strWhere += " and Type ISOCode '%" + Data.ISOCode + "%'";

            if (Data.status.ToString() != "" && Data.status.ToString() != "0" && Data.status.ToString() != null && Data.status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.CntrTypes.status = " + Data.status.ToString();
                else
                    strWhere += " and sa.CntrTypes.status = " + Data.status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyContType> GetContTypeMasterRecord(MyContType Data)
        {
            DataTable dt = GetContTypeRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListConType.Add(new MyContType
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SizeID = Int32.Parse(dt.Rows[i]["SizeID"].ToString()),
                    EQTypeID = Int32.Parse(dt.Rows[i]["EQTypeID"].ToString()),
                    TEUS = Int32.Parse(dt.Rows[i]["TEUS"].ToString()),
                    Width =dt.Rows[i]["Width"].ToString(),
                    Length = dt.Rows[i]["Length"].ToString(),
                    TareWeight = dt.Rows[i]["TareWeight"].ToString(),
                    MaxPayload = dt.Rows[i]["MaxPayload"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    SeqNo = dt.Rows[i]["SeqNo"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Height = dt.Rows[i]["Height"].ToString(),
                    groupID = Int32.Parse(dt.Rows[i]["groupID"].ToString()),
                    CntrTypeDesc = dt.Rows[i]["CntrTypeDesc"].ToString(),
                    status = Int32.Parse(dt.Rows[i]["status"].ToString()),                   
                });
            }
            return ListConType;
        }

        public DataTable GetContTypeRecord(MyContType Data)
        {
            string _Query = "select * from SA.CntrTypes where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<ContainerType> ContainerTypeValues(ContainerType Data)
        {
            List<ContainerType> ChargeList = new List<ContainerType>();
            DataTable dt = GetContainerType(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new ContainerType
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),
                });
            }
            return ChargeList;
        }
        public DataTable GetContainerType(ContainerType Data)
        {
            string _Query = "select id,GeneralName from SA.GeneralMaster where SeqNo=5 AND Status=1";
            return GetViewData(_Query, "");
        }

        public List<ContainerSizes> ContainerSizeValues(ContainerSizes Data)
        {
            List<ContainerSizes> ChargeList = new List<ContainerSizes>();
            DataTable dt = GetContainerSize(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new ContainerSizes
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),
                });
            }
            return ChargeList;
        }
        public DataTable GetContainerSize(ContainerSizes Data)
        {
            string _Query = "select id,GeneralName from SA.GeneralMaster where SeqNo=6  AND Status=1";
            return GetViewData(_Query, "");
        }

        public List<ContainerSizes> ContainerGroupValues(ContainerSizes Data)
        {
            List<ContainerSizes> ChargeList = new List<ContainerSizes>();
            DataTable dt = GetContainerGroupValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new ContainerSizes
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),
                });
            }
            return ChargeList;
        }
        public DataTable GetContainerGroupValues(ContainerSizes Data)
        {
            string _Query = "select id,GeneralName from SA.GeneralMaster where SeqNo=2  AND Status=1";
            return GetViewData(_Query, "");
        }


        #endregion

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


        #region udhaya country,City


        public List<MyCountry> countryListvalues(MyCountry Data)
        {
            DataTable dt = countryListvalue(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCountry.Add(new MyCountry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),

                });

            }
            return ListCountry;
        }

        public DataTable countryListvalue(MyCountry Data)
        {

            string _Query = "Select * from sa.CountryMaster";
            return GetViewData(_Query, "");
        }


        public List<MyCity> Citylistvalues(MyCity Data)
        {
            DataTable dt = CitylistvaluesRecoards(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCity.Add(new MyCity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString(),

                });

            }
            return ListCity;
        }

        public DataTable CitylistvaluesRecoards(MyCity Data)
        {

            string _Query = "Select * from sa.CityMaster";
            return GetViewData(_Query, "");
        }

        List<myshipmentlocation> ListShipment = new List<myshipmentlocation>();
        public List<myshipmentlocation> InsertShipmentValues(myshipmentlocation Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = ShipmentValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListShipment.Add(new myshipmentlocation
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Location Name Type Already Exists"
                    });
                    return ListShipment;

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
                    Cmd.CommandText = " IF((select count(*) from sa.ShipmentLocation where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  sa.ShipmentLocation(LocationCode,Location,CityID,CountryID,status) " +
                                     " values (@LocationCode,@Location,@CityID,@CountryID,@status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE sa.ShipmentLocation SET LocationCode=@LocationCode,Location=@Location,CityID=@CityID,CountryID=@CountryID,status=@status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationCode", Data.LocationCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Location", Data.Location.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@status", Data.status));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('sa.ShipmentLocation')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListShipment.Add(new myshipmentlocation
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListShipment;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListShipment.Add(new myshipmentlocation
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListShipment;
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
        public DataTable ShipmentValues(myshipmentlocation Data)
        {


            string _Query = "select * from sa.ShipmentLocation where Location = '" + Data.Location + "'";
            return GetViewData(_Query, "");
        }


        public List<myshipmentlocation> ShipmentLocationListValues(myshipmentlocation Data)
        {
            DataTable dt = GetShipmentLocationListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListShipment.Add(new myshipmentlocation
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });

            }
            return ListShipment;
        }
        public DataTable GetShipmentLocationListValues(myshipmentlocation Data)
        {
            string strWhere = "";

            string _Query = " select ID,LocationCode,Location,case when ShipmentLocation.status =1 then 'YES' when ShipmentLocation.status =2 then 'NO' ELSE '' END  as StatusResult from sa.ShipmentLocation";




            if (Data.LocationCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.ShipmentLocation.LocationCode like '%" + Data.LocationCode + "%'";
                else
                    strWhere += " and sa.ShipmentLocation.LocationCode like '%" + Data.LocationCode + "%'";

            if (Data.Location != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.ShipmentLocation.Location like '%" + Data.Location + "%'";
                else
                    strWhere += " and sa.ShipmentLocation.Location like '%" + Data.Location + "%'";

            if (Data.status.ToString() != "" && Data.status.ToString() != "0" && Data.status.ToString() != null && Data.status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.ShipmentLocation.status = " + Data.status.ToString();
                else
                    strWhere += " and sa.ShipmentLocation.status = " + Data.status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<myshipmentlocation> ShipmentLocationEditValues(myshipmentlocation Data)
        {
            DataTable dt = GetShipmentLocationEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListShipment.Add(new myshipmentlocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    status = Int32.Parse(dt.Rows[i]["status"].ToString()),

                });
            }


            return ListShipment;
        }

        public DataTable GetShipmentLocationEditValues(myshipmentlocation Data)
        {
            string _Query = "Select * from sa.ShipmentLocation where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        List<myHazardous> ListHazardous = new List<myHazardous>();
        public List<myHazardous> InsertHazardousClassesValues(myHazardous Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = HazardousClassesValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListHazardous.Add(new myHazardous
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Hazardous Classes Type Already Exists"
                    });
                    return ListHazardous;

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
                    Cmd.CommandText = " IF((select count(*) from sa.HazardousClasses where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  sa.HazardousClasses(ClassDesc,DivisionDesc,Status) " +
                                     " values (@ClassDesc,@DivisionDesc,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE sa.HazardousClasses SET ClassDesc=@ClassDesc,DivisionDesc=@DivisionDesc,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ClassDesc", Data.ClassDesc.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DivisionDesc", Data.DivisionDesc.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('sa.ShipmentLocation')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListHazardous.Add(new myHazardous
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListHazardous;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListHazardous.Add(new myHazardous
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListHazardous;
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

        public DataTable HazardousClassesValues(myHazardous Data)
        {


            string _Query = "select * from sa.HazardousClasses where DivisionDesc = '" + Data.DivisionDesc + "'";
            return GetViewData(_Query, "");
        }


        public List<myHazardous> HazardousEditValues(myHazardous Data)
        {
            DataTable dt = HazardousEditValuesRecords(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListHazardous.Add(new myHazardous
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ClassDesc = dt.Rows[i]["ClassDesc"].ToString(),
                    DivisionDesc = dt.Rows[i]["DivisionDesc"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }
            return ListHazardous;
        }

        public DataTable HazardousEditValuesRecords(myHazardous Data)
        {
            string _Query = "Select * from sa.HazardousClasses where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<myHazardous> HazardousClassesListValues(myHazardous Data)
        {
            DataTable dt = GetHazardousClassesListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListHazardous.Add(new myHazardous
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ClassDesc = dt.Rows[i]["ClassDesc"].ToString(),
                    DivisionDesc = dt.Rows[i]["DivisionDesc"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });

            }
            return ListHazardous;
        }
        public DataTable GetHazardousClassesListValues(myHazardous Data)
        {
            string strWhere = "";

            string _Query = " select ID,ClassDesc,DivisionDesc,case when sa.HazardousClasses.Status =1 then 'YES' " +
                             " when sa.HazardousClasses.Status =2 then 'NO' ELSE '' END  as StatusResult from sa.HazardousClasses";



            if (Data.ClassDesc != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.HazardousClasses.ClassDesc like '%" + Data.ClassDesc + "%'";
                else
                    strWhere += " and sa.HazardousClasses.ClassDesc like '%" + Data.ClassDesc + "%'";

            if (Data.DivisionDesc != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.HazardousClasses.DivisionDesc like '%" + Data.DivisionDesc + "%'";
                else
                    strWhere += " and sa.HazardousClasses.DivisionDesc like '%" + Data.DivisionDesc + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.HazardousClasses.Status = " + Data.Status.ToString();
                else
                    strWhere += " and sa.HazardousClasses.Status = " + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<myUOMConversions> UOMFromValues(myUOMConversions Data)
        {
            DataTable dt = UOMFromValuesRecords(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListUOMConversions.Add(new myUOMConversions
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMCode = dt.Rows[i]["UOMCode"].ToString(),
                 

                });
            }
            return ListUOMConversions;
        }

        public DataTable UOMFromValuesRecords(myUOMConversions Data)
        {
            string _Query = "Select ID,UOMCode +' - '+ UOMDesc as  UOMCode from sa.UOMMaster where status=1";
            return GetViewData(_Query, "");
        }


        List<myUOMConversions> ListUOMConversions = new List<myUOMConversions>();
        public List<myUOMConversions> InsertUOMConversionsValues(myUOMConversions Data)
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
                    Cmd.CommandText = " IF((select count(*) from sa.UOMConversions where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  sa.UOMConversions(UOMFrom,UOMTo,Action,Factor,Status) " +
                                     " values (@UOMFrom,@UOMTo,@Action,@Factor,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE sa.UOMConversions SET UOMFrom=@UOMFrom,UOMTo=@UOMTo,Action=@Action,Factor=@Factor,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UOMFrom", Data.UOMFrom));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UOMTo", Data.UOMTo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Action", Data.Action));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Factor", Data.Factor));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('sa.UOMConversions')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListUOMConversions.Add(new myUOMConversions
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListUOMConversions;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListUOMConversions.Add(new myUOMConversions
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListUOMConversions;
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

        public List<myUOMConversions> UOMConversionsEditValues(myUOMConversions Data)
        {
            DataTable dt = UOMConversionsEditValuesRecords(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListUOMConversions.Add(new myUOMConversions
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMFrom = dt.Rows[i]["UOMFrom"].ToString(),
                    UOMTo = dt.Rows[i]["UOMTo"].ToString(),
                    Action = Int32.Parse(dt.Rows[i]["Action"].ToString()),
                    Factor = dt.Rows[i]["Factor"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),

                });
            }
            return ListUOMConversions;
        }

        public DataTable UOMConversionsEditValuesRecords(myUOMConversions Data)
        {
            string _Query = "Select * from sa.UOMConversions  where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<myUOMConversions> UOMConversionsListValues(myUOMConversions Data)
        {
            DataTable dt = GetUOMConversionsListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUOMConversions.Add(new myUOMConversions
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMFrom = dt.Rows[i]["UOMFromv"].ToString(),
                    UOMTo = dt.Rows[i]["UOMTov"].ToString(),
                    Factor = dt.Rows[i]["Factor"].ToString(),
                    ActionResult = dt.Rows[i]["ActionResult"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),


                });

            }
            return ListUOMConversions;
        }
        public DataTable GetUOMConversionsListValues(myUOMConversions Data)
        {
            string strWhere = "";

            string _Query = " select ID, (select  top (1) UOMCode +' - '+ UOMDesc as  UOMCode from SA.UOMMaster WHERE ID =UOMFrom) as UOMFromv, " +
                               "  (select top (1) UOMCode +' - '+ UOMDesc as  UOMCode from SA.UOMMaster WHERE ID =UOMTo) as UOMTov, Factor," +
                               " (select top 1 GeneralName from SA.GeneralMaster where Seqno=4 and ID=Action) as ActionResult, " +
                            " CASE WHEN sa.UOMConversions.Status = 1 THEN 'YES' WHEN sa.UOMConversions.Status = 2 THEN 'NO' ELSE '' END as StatusResult " +
                            " from sa.UOMConversions ";

            if (Data.UOMFrom != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.UOMConversions.UOMFrom like '%" + Data.UOMFrom + "%'";
                else
                    strWhere += " and sa.UOMConversions.UOMFrom like '%" + Data.UOMFrom + "%'";

            if (Data.UOMTo != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.UOMConversions.UOMTo like '%" + Data.UOMTo + "%'";
                else
                    strWhere += " and sa.UOMConversions.UOMTo like '%" + Data.UOMTo + "%'";

            if (Data.Action.ToString() != "" && Data.Action.ToString() != "0" && Data.Action.ToString() != null && Data.Action.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.UOMConversions.Action = " + Data.Action.ToString();
                else
                    strWhere += " and sa.UOMConversions.Action = " + Data.Action.ToString();

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.UOMConversions.Status = " + Data.Status.ToString();
                else
                    strWhere += " and sa.UOMConversions.Status = " + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }



        #endregion



        #region Currency Master
        public List<MyCurrency> saveCurrencyValues(MyCurrency Data)
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

                    Cmd.CommandText = " IF((select count(*) from sa.CurrencyMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  sa.CurrencyMaster(CurrencyCode,CurrencyName,Symbol,Status,CountryID) " +
                                     " values (@CurrencyCode,@CurrencyName,@Symbol,@Status,@CountryID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE sa.CurrencyMaster SET CurrencyCode=@CurrencyCode,CurrencyName=@CurrencyName,Status=@Status,CountryID=@CountryID,Symbol=@Symbol where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyCode", Data.CurrencyCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyName", Data.CurrencyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Symbol", Data.Symbol));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('sa.CurrencyMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListCurrency;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCurrency;
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

        public List<MyCurrency> getCurrencyListValues(MyCurrency Data)
        {
            DataTable dt = GetCurrencyList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurrency.Add(new MyCurrency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyName = dt.Rows[i]["CurrencyName"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),
                });

            }
            return ListCurrency;
        }


        public DataTable GetCurrencyList(MyCurrency Data)
        {
            string strWhere = "";

            string _Query = " select ID,CurrencyCode,CurrencyName, CASE WHEN sa.CurrencyMaster.Status=1 THEN 'YES' WHEN sa.CurrencyMaster.Status=2 THEN 'NO' ELSE '' END AS StatusResult, (select top 1 CountryName from sa.CountryMaster where  sa.CountryMaster.ID=sa.CurrencyMaster.CountryID) as Country from sa.CurrencyMaster";

            if (Data.CurrencyCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.CurrencyMaster.CurrencyCode like '%" + Data.CurrencyCode + "%'";
                else
                    strWhere += " and sa.CurrencyMaster.CurrencyCode like '%" + Data.CurrencyCode + "%'";

            if (Data.CurrencyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where sa.CurrencyMaster.CurrencyName like '%" + Data.CurrencyName + "%'";
                else
                    strWhere += " and sa.CurrencyMaster.CurrencyName like '%" + Data.CurrencyName + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != "0" && Data.Status.ToString() != null && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.CurrencyMaster.Status = " + Data.Status.ToString();
                else
                    strWhere += " and sa.CurrencyMaster.Status = " + Data.Status.ToString();

            if (Data.CountryID.ToString() != "" && Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where sa.CurrencyMaster.CountryID = " + Data.CountryID.ToString();
                else
                    strWhere += " and sa.CurrencyMaster.CountryID = " + Data.CountryID.ToString();



            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyCurrency> Currencyeditvalues(MyCurrency Data)
        {
            DataTable dt = GetCurrencyeditvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurrency.Add(new MyCurrency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyName = dt.Rows[i]["CurrencyName"].ToString(),
                    Symbol = dt.Rows[i]["Symbol"].ToString(),                  
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                });
            }


            return ListCurrency;
        }
      
        public DataTable GetCurrencyeditvalues(MyCurrency Data)
        {
            string _Query = "Select * from sa.CurrencyMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

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

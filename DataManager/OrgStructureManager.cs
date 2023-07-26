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
    public class OrgStructureManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public OrgStructureManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region REGION MASTER
        List<MyRegion> ListReg = new List<MyRegion>();
        public List<MyRegion> GetRegionMaster(MyRegion Data)
        {
            DataTable dt = GetRegionValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListReg.Add(new MyRegion
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RegionName = dt.Rows[i]["RegionName"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString(),
                });

            }
            return ListReg;
        }
        public DataTable GetRegionValues(MyRegion Data)
        {
            string strWhere = "";

            string _Query = " select case when Status=1 then 'Active' else case when Status=2 then 'Inactive' end end as StatusV, * from NVO_RegionMaster";

            if (Data.RegionName != "")
                if (strWhere == "")
                    strWhere += _Query + " where RegionName like '%" + Data.RegionName + "%'";
                else
                    strWhere += " and RegionName like '%" + Data.RegionName + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();
            //else
            //    strWhere += " and Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyRegion> GetRegionValuesEdit(MyRegion Data)
        {
            DataTable dt = GetRegionValuesEd(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListReg.Add(new MyRegion
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RegionName = dt.Rows[i]["RegionName"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                });

            }
            return ListReg;
        }
        public DataTable GetRegionValuesEd(MyRegion Data)
        {

            string _Query = " select * from NVO_RegionMaster where ID=" + Data.ID;

            return GetViewData(_Query, "");

        }

        public List<MyRegion> InsertRegionMaster(MyRegion Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GeExistingRegion(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListReg.Add(new MyRegion
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Region Name Already Exists"

                    }); ;
                    return ListReg;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_RegionMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RegionMaster(RegionName,Status) " +
                                     " values (@RegionName,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RegionMaster SET RegionName=@RegionName,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RegionName", Data.RegionName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_RegionMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    ListReg.Add(new MyRegion
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListReg;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListReg.Add(new MyRegion
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListReg;
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

        public DataTable GeExistingRegion(MyRegion Data)
        {
            string Strwhere = "select * from NVO_RegionMaster Where (ID not in(" + Data.ID + ")) and (RegionName = '" + Data.RegionName + "')";
            return GetViewData(Strwhere, "");
        }
        #endregion

        #region  OFFICE MASTER

        List<MyOffice> ListOff = new List<MyOffice>();
        List<cityDD> ListCityloc = new List<cityDD>();
        List<MyState> ListStatev = new List<MyState>();
        public List<cityDD> ListBindCitiesByCountry(cityDD Data)
        {
            DataTable dt = GetBindCitiesByCountry(Data);
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
        public DataTable GetBindCitiesByCountry(cityDD Data)
        {
            string _Query = "select ID AS CityID ,CityName from NVO_CityMaster" +
                " where countryid =" + Data.CountryID + " order by CityName";

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

            string _Query = "Select * from NVO_StateMaster Where CountryID=" + Data.CountryID;
            return GetViewData(_Query, "");
        }
        public List<MyOffice> InserOfficeMaster(MyOffice Data)
        {


            DbConnection con = null;
            DbTransaction trans;

            DataTable ChckExist = GeExistingCompany(Data);

            if (ChckExist.Rows.Count >= 1)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Data.ID,
                    AlertMegId = "1",
                    AlertMessage = "Company Name Already Exists"
                }); ;
                return ListOff;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_OfficeMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_OfficeMaster(OfficeLoc,CompanyName,CountryID,CityID,StateID,Pincode,TaxGSTNo,TelNo,FaxNo,Address,StatusID,LocationCode) " +
                                     " values (@OfficeLoc,@CompanyName,@CountryID,@CityID,@StateID,@Pincode,@TaxGSTNo,@TelNo,@FaxNo,@Address,@StatusID,@LocationCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_OfficeMaster SET OfficeLoc=@OfficeLoc,CompanyName=@CompanyName,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,Pincode=@Pincode,TaxGSTNo=@TaxGSTNo,TelNo=@TelNo,FaxNo=@FaxNo,Address=@Address,StatusID=@StatusID,LocationCode=@LocationCode where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLoc", Data.OfficeLoc.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyName", Data.CompanyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Pincode", Data.Pincode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGSTNo", Data.TaxGSTNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FaxNo", Data.FaxNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", Data.TelNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationCode", Data.LocationCode));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_OfficeMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListOff.Add(new MyOffice
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListOff;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListOff.Add(new MyOffice
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListOff;
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

        public DataTable GeExistingCompany(MyOffice Data)
        {
            string Strwhere = "select * from NVO_OfficeMaster Where (ID not in (" + Data.ID + ")) and(CompanyName = '" + Data.CompanyName + "')";
            return GetViewData(Strwhere, "");
        }


        public List<MyOffice> GetOfficeViewList(MyOffice Data)
        {
            DataTable dt = GetGetOfficeViewList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString(),
                });

            }
            return ListOff;
        }
        public DataTable GetGetOfficeViewList(MyOffice Data)
        {
            string strWhere = "";

            string _Query = " select case when StatusID=1 then 'Active' else 'Inactive' end as StatusV, * from NVO_OfficeMaster";

            if (Data.CompanyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CompanyName like '%" + Data.CompanyName + "%'";
                else
                    strWhere += " and CompanyName like '%" + Data.CompanyName + "%'";

            if (Data.OfficeLoc != "")
                if (strWhere == "")
                    strWhere += _Query + " where OfficeLoc like '%" + Data.OfficeLoc + "%'";
                else
                    strWhere += " and OfficeLoc like '%" + Data.OfficeLoc + "%'";

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where StatusID =" + Data.StatusID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyOffice> GetOfficeEditList(MyOffice Data)
        {
            DataTable dt = GetOfficeEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    FaxNo = dt.Rows[i]["FaxNo"].ToString(),
                    TelNo = dt.Rows[i]["FaxNo"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Pincode = dt.Rows[i]["Pincode"].ToString(),
                    TaxGSTNo = dt.Rows[i]["TaxGSTNo"].ToString(),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),

                });

            }
            return ListOff;
        }
        public DataTable GetOfficeEditValues(MyOffice Data)
        {

            string _Query = "select * from NVO_OfficeMaster Where ID=" + Data.ID;
            return GetViewData(_Query, "");

        }


        public List<MyOffice> GetOffLocation(MyOffice Data)
        {
            DataTable dt = GetOffLocValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                });

            }
            return ListOff;
        }

        public DataTable GetOffLocValues(MyOffice Data)
        {

            string _Query = "select ID,OfficeLoc  from NVO_OfficeMaster where CountryID=" + Data.CountryID;
            return GetViewData(_Query, "");

        }

        public List<MyOffice> GetOffLocationBind(MyOffice Data)
        {
            DataTable dt = GetAllOffLocValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                });

            }
            return ListOff;
        }

        public DataTable GetAllOffLocValues(MyOffice Data)
        {

            string _Query = "select ID,OfficeLoc from NVO_OfficeMaster";
            return GetViewData(_Query, "");

        }

        #endregion

        #region Sales Office


        public List<MyOffice> GetOfficeLocBind(MyOffice Data)
        {
            DataTable dt = GetOfficeLocBindValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                });

            }
            return ListOff;
        }
        public DataTable GetOfficeLocBindValues(MyOffice Data)
        {

            string _Query = "select * from NVO_OfficeMaster";
            return GetViewData(_Query, "");

        }

        public List<MyOffice> GetOfficeByLoc(string id)
        {
            DataTable dt = GetOfficeByLocValues(id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                });

            }
            return ListOff;
        }
        public DataTable GetOfficeByLocValues(string id)
        {

            string _Query = "select * from NVO_OfficeMaster where ID=" + id;
            return GetViewData(_Query, "");

        }
        public List<MyOffice> GetOfficeByLocsValues(MyOffice Data)
        {
            DataTable dt = GetGetOfficeByLocsBind(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOff.Add(new MyOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                });

            }
            return ListOff;
        }
        public DataTable GetGetOfficeByLocsBind(MyOffice Data)
        {

            string _Query = "select * from NVO_OfficeMaster where ID=" + Data.OfficeLocID;
            return GetViewData(_Query, "");

        }
        List<MySalesOffice> ListSalesOff = new List<MySalesOffice>();
        public List<MySalesOffice> SalesOfficeInsertMaster(MySalesOffice Data)
        {


            DbConnection con = null;
            DbTransaction trans;

            DataTable ChckExist = GetExistingSalesOffice(Data);
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListSalesOff.Add(new MySalesOffice
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Sales Office Already Exists"
                    }); ;
                    return ListSalesOff;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_SalesOfficeMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_SalesOfficeMaster(SalesOffLoc,OfficeLocID,OfficeID,Status) " +
                                     " values (@SalesOffLoc,@OfficeLocID,@OfficeID,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_SalesOfficeMaster SET SalesOffLoc=@SalesOffLoc,OfficeLocID=@OfficeLocID,OfficeID=@OfficeID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesOffLoc", Data.SalesOffLoc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocID", Data.OfficeLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeID", Data.OfficeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_SalesOfficeMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;
                    trans.Commit();

                    ListSalesOff.Add(new MySalesOffice
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListSalesOff;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListSalesOff.Add(new MySalesOffice
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListSalesOff;
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
        public DataTable GetExistingSalesOffice(MySalesOffice Data)
        {
            string Strwhere = "select * from NVO_SalesOfficeMaster Where (ID not in (" + Data.ID + ")) and(SalesOffLoc = '" + Data.SalesOffLoc + "')";
            return GetViewData(Strwhere, "");
        }

        public List<MySalesOffice> SalesOfficeViewMaster(MySalesOffice Data)
        {
            DataTable dt = GetSalesOfficeViewMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSalesOff.Add(new MySalesOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SalesOffLoc = dt.Rows[i]["SalesOffLoc"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString(),

                });

            }
            return ListSalesOff;
        }
        public DataTable GetSalesOfficeViewMaster(MySalesOffice Data)
        {


            string strWhere = "";

            string _Query = "select  case when Status=1 then 'Active' else 'Inactive' end as StatusV, * from NVO_SalesOfficeMaster";

            if (Data.SalesOffLoc != "")
                if (strWhere == "")
                    strWhere += _Query + " where SalesOffLoc like '%" + Data.SalesOffLoc + "%'";
                else
                    strWhere += " and SalesOffLoc like '%" + Data.SalesOffLoc + "%'";

            if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();
                else
                    strWhere += " and Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MySalesOffice> SalesOfficeEditMaster(MySalesOffice Data)
        {
            DataTable dt = GetSalesOfficeEditMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSalesOff.Add(new MySalesOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SalesOffLoc = dt.Rows[i]["SalesOffLoc"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    OfficeID = Int32.Parse(dt.Rows[i]["OfficeID"].ToString()),
                    OfficeLocID = Int32.Parse(dt.Rows[i]["OfficeLocID"].ToString()),

                });

            }
            return ListSalesOff;
        }
        public DataTable GetSalesOfficeEditMaster(MySalesOffice Data)
        {

            string _Query = "select * from NVO_SalesOfficeMaster where ID=" + Data.ID;

            return GetViewData(_Query, "");

        }

        #endregion



        #region   Org MASTER

        List<MyOrg> ListOrg = new List<MyOrg>();
        public List<MyOrg> OrgInsertDataMaster(MyOrg Data)
        {

            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GeExistingOrg(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListOrg.Add(new MyOrg
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Organization Already Exists"
                    }); ;
                    return ListOrg;
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

                    Cmd.CommandText = " IF((select count(*) from NVO_OrgMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_OrgMaster(OrgName,CountryID,CityID,StateID,Pincode,TaxGSTNo,StatusID,	IsLiner,IsFF,IsTransport,Address) " +
                                     " values (@OrgName,@CountryID,@CityID,@StateID,@Pincode,@TaxGSTNo,@StatusID,	@IsLiner,@IsFF,@IsTransport,@Address) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_OrgMaster SET OrgName=@OrgName,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,Pincode=@Pincode,TaxGSTNo=@TaxGSTNo,StatusID=@StatusID,IsLiner=@IsLiner,IsFF=@IsFF,IsTransport=@IsTransport,Address=@Address where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OrgName", Data.OrgName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Pincode", Data.Pincode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGSTNo", Data.TaxGSTNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsLiner", Data.IsLiner));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsFF", Data.IsFF));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsTransport", Data.IsTransport));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_OrgMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.DivisionDetails.TrimEnd(',').Split(',');

                    Cmd.CommandText = "delete from NVO_OrgDivisionTypes where OrgID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();

                    for (int i = 0; i < Array.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_OrgDivisionTypes where OrgID=@OrgID and DivisionID=@DivisionID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_OrgDivisionTypes(OrgID,DivisionID) " +
                                    " values (@OrgID,@DivisionID) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_OrgDivisionTypes SET OrgID=@OrgID,DivisionID=@DivisionID where OrgID=@OrgID and DivisionID=@DivisionID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OrgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DivisionID", Array[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //for (int i = 0; i < Array.Length; i++)
                    //{
                    //    Cmd.CommandText = " IF((select count(*) from NVO_CusBusinessTypes where CustomerID=@CustomerID and BussTypes=@BussTypes)<=0) " +
                    //                " BEGIN " +
                    //                " INSERT INTO  NVO_CusBusinessTypes(CustomerID,BussTypes) " +
                    //                " values (@CustomerID,@BussTypes) " +
                    //                " END  " +
                    //                " ELSE " +
                    //                " UPDATE NVO_CusBusinessTypes SET CustomerID=@CustomerID,BussTypes=@BussTypes where CustomerID=@CustomerID and BussTypes=@BussTypes";
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@BussTypes", Array[i]));
                    //    result = Cmd.ExecuteNonQuery();
                    //    Cmd.Parameters.Clear();

                    //}


                    string[] Array1 = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_OrgOfficeDtls where OrgID=@OrgID and ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_OrgOfficeDtls(RegionID,OfficeLoc,SalesOffLocID,CreatedBy,CreatedOn,OrgID) " +
                                     " values (@RegionID,@OfficeLoc,@SalesOffLocID,@CreatedBy,@CreatedOn,@OrgID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_OrgOfficeDtls SET RegionID=@RegionID,OfficeLoc=@OfficeLoc,SalesOffLocID=@SalesOffLocID," +
                                     " ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn,OrgID=@OrgID where OrgID=@OrgID and ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RegionID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLoc", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesOffLocID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OrgID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedOn", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedBy", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();
                    ListOrg.Add(new MyOrg
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListOrg;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListOrg.Add(new MyOrg
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListOrg;
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
        public DataTable GeExistingOrg(MyOrg Data)
        {
            string _Query = "select * from NVO_OrgMaster Where OrgName = '" + Data.OrgName + "'";
            return GetViewData(_Query, "");

        }
        public List<MyRegion> GetRegionBindList(MyRegion Data)
        {
            DataTable dt = GetRegionBindListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListReg.Add(new MyRegion
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RegionName = dt.Rows[i]["RegionName"].ToString(),
                });

            }
            return ListReg;
        }

        public DataTable GetRegionBindListValues(MyRegion Data)
        {

            string _Query = "select * from NVO_RegionMaster where Status=1";
            return GetViewData(_Query, "");

        }

        public List<MyOrg> OrgViewMaster(MyOrg Data)
        {
            DataTable dt = GetOrgViewMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOrg.Add(new MyOrg
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OrgName = dt.Rows[i]["OrgName"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                });

            }
            return ListOrg;
        }
        public DataTable GetOrgViewMaster(MyOrg Data)
        {


            string strWhere = "";

            string _Query = "select  case when StatusID=1 then 'Active' else 'Inactive' end as StatusV," +
                " (select top 1 CountryName from  NVO_CountryMaster where ID =CountryID) As Country, " +
                " * from NVO_OrgMaster";

            if (Data.OrgName != "")
                if (strWhere == "")
                    strWhere += _Query + " where OrgName like '%" + Data.OrgName + "%'";
                else
                    strWhere += " and OrgName like '%" + Data.OrgName + "%'";

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where StatusID =" + Data.StatusID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyOrg> OrgEditMaster(MyOrg Data)
        {
            DataTable dt = GetOrgEditMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOrg.Add(new MyOrg
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OrgName = dt.Rows[i]["OrgName"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Pincode = dt.Rows[i]["Pincode"].ToString(),
                    TaxGSTNo = dt.Rows[i]["TaxGSTNo"].ToString(),
                    IsFF = Int32.Parse(dt.Rows[i]["IsFF"].ToString()),
                    IsLiner = Int32.Parse(dt.Rows[i]["IsLiner"].ToString()),
                    IsTransport = Int32.Parse(dt.Rows[i]["IsTransport"].ToString()),
                });

            }
            return ListOrg;
        }
        public DataTable GetOrgEditMaster(MyOrg Data)
        {

            string _Query = "select * from NVO_OrgMaster where ID=" + Data.ID;

            return GetViewData(_Query, "");

        }
        List<MyOrgGrid> ListOrgGrid = new List<MyOrgGrid>();
        public List<MyOrgGrid> OrgDetailsEditMaster(MyOrgGrid Data)
        {
            DataTable dt = GetOrgDetailsEditMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOrgGrid.Add(new MyOrgGrid
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RegionID = Int32.Parse(dt.Rows[i]["RegionID"].ToString()),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                    SalesOffLocID = Int32.Parse(dt.Rows[i]["SalesOffLocID"].ToString()),

                });

            }
            return ListOrgGrid;
        }
        public DataTable GetOrgDetailsEditMaster(MyOrgGrid Data)
        {

            string _Query = "select * from NVO_OrgOfficeDtls where OrgID=" + Data.ID;

            return GetViewData(_Query, "");

        }

        public List<MySalesOffice> GetSalesOfficeByOfficeLoc(MySalesOffice Data)
        {
            DataTable dt = GetSalesOfficeByOfficeLocValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSalesOff.Add(new MySalesOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SalesOffLoc = dt.Rows[i]["SalesOffLoc"].ToString(),
                });

            }
            return ListSalesOff;
        }
        public DataTable GetSalesOfficeByOfficeLocValues(MySalesOffice Data)
        {

            string _Query = "select * from NVO_SalesOfficeMaster where ID=" + Data.OfficeLocID;
            return GetViewData(_Query, "");

        }

        public List<MySalesOffice> SalesLocBindValues(MySalesOffice Data)
        {
            DataTable dt = GetSalesLocBindValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSalesOff.Add(new MySalesOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SalesOffLoc = dt.Rows[i]["SalesOffLoc"].ToString(),
                });

            }
            return ListSalesOff;
        }
        public DataTable GetSalesLocBindValues(MySalesOffice Data)
        {

            string _Query = "select * from NVO_SalesOfficeMaster";
            return GetViewData(_Query, "");

        }

        public List<MySalesOffice> OfficeLocBySalesOfficeValues(MySalesOffice Data)
        {
            DataTable dt = GetOfficeLocBySalesOfficeValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSalesOff.Add(new MySalesOffice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    OfficeLoc = dt.Rows[i]["officeLoc"].ToString(),
                });

            }
            return ListSalesOff;
        }
        public DataTable GetOfficeLocBySalesOfficeValues(MySalesOffice Data)
        {

            string _Query = "select OM.ID, (OM.OfficeLoc +'-'+OM.CompanyName) AS officeLoc from NVO_SalesOfficeMaster SM inner join NVO_OfficeMaster OM ON OM.ID = SM.OfficeLocID WHERE SM.ID =" + Data.OfficeLocID;
            return GetViewData(_Query, "");

        }

        public List<MyOrg> OrgOfficeDtlsDeleteMaster(MyOrg Data)
        {

            int r1 = 0;
            int r2 = 0;
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

                    Cmd.CommandText = "Delete from NVO_OrgOfficeDtls where ID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListOrg.Add(new MyOrg
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListOrg;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListOrg.Add(new MyOrg
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListOrg;
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

        public List<MyOrg> DivisionsBindMaster(MyOrg Data)
        {
            DataTable dt = GetDivisionsBindMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOrg.Add(new MyOrg
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Division = dt.Rows[i]["GeneralName"].ToString(),
                });

            }
            return ListOrg;
        }
        public DataTable GetDivisionsBindMaster(MyOrg Data)
        {

            string _Query = " select * from NVO_GeneralMaster WHERE SeqNo =56";
            return GetViewData(_Query, "");

        }

        public List<MyOrg> OrgExistingDivisionTypesMaster(MyOrg Data)
        {

            DataTable dt = GetOrgExistingDivisionValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListOrg.Add(new MyOrg
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Division = dt.Rows[i]["GeneralName"].ToString(),
                    IsTrue = Int32.Parse(dt.Rows[i]["IsTrue"].ToString()),

                });

            }
            return ListOrg;
        }
        public DataTable GetOrgExistingDivisionValues(MyOrg Data)
        {
            string _Query = "select ID, GeneralName, case when(select top(1) DivisionID from NVO_OrgDivisionTypes where DivisionID = NVO_GeneralMaster.ID and OrgID = " + Data.ID + ") > 0 then 1 else 0 end as IsTrue from NVO_GeneralMaster where SeqNo=56 ";
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

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
    public class PrincipalTariffManager
    {
        #region Constructor Method
        public PrincipalTariffManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion


        public List<MyPrincibalTariff> InsertPrincipalTariffMaster(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> List = new List<MyPrincibalTariff>();
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



                    Cmd.CommandText = " IF((select count(*) from NVO_PrincipalMaster where ID=@ID)<=0) " +
                 " BEGIN " +
                 " INSERT INTO  NVO_PrincipalMaster(LineCode,LineName,CountryID,CityID,StateID,TaxGST,PinCode,EmailID,TelNo,Status,Address,Note,DtCreated,DtCreatedby) " +
                 " values(@LineCode,@LineName,@CountryID,@CityID,@StateID,@TaxGST,@PinCode,@EmailID,@TelNo,@Status,@Address,@Note,@DtCreated,@DtCreatedby)  " +
                 " END  " +
                 " ELSE " +
                 " UPDATE NVO_PrincipalMaster SET LineCode=@LineCode,LineName=@LineName,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,TaxGST=@TaxGST," +
                 " PinCode=@PinCode,EmailID=@EmailID,TelNo=@TelNo,Status=@Status,Address=@Address,Note=@Note,DtCreated=@DtCreated,DtCreatedby=@DtCreatedby where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("LineCode", Data.LineCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LineName", Data.LineName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGST", Data.TaxGST));
                    if (Data.PinCode != null)
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PinCode", Data.PinCode));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PinCode", DBNull.Value));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.Email));
                    if (Data.TelNo != "")
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", Data.TelNo));
                    else
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", DBNull.Value));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Note", Data.Note));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreated", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreatedby", 1));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_PrincipalMaster')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    trans.Commit();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMessage = "Record Saved Sucessfully"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMessage = ex.Message
                    });
                    return List;
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


        public List<MyPrincibalTariff> InsertPrincipalTariffMasterdtls(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> List = new List<MyPrincibalTariff>();
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


                    if (Data.Items != null)
                    {
                        string[] Array3 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array3.Length; i++)
                        {
                            var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PrincipalMasterdtls where SID=@SID and PID=@PID )<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_PrincipalMasterdtls(PID,AgreementTypeID,CommissionTypeID,ShipmentTypeID,ChargeID,PortID,TerminalID,CurrencyID,CntrTypeID,Amount,CollectionAmt,CostAmt,DifferentAmt,DiffRemittanceAmt,TariffType,DtCreated,DtCreatedby) " +
                             " values(@PID,@AgreementTypeID,@CommissionTypeID,@ShipmentTypeID,@ChargeID,@PortID,@TerminalID,@CurrencyID,@CntrTypeID,@Amount,@CollectionAmt,@CostAmt,@DifferentAmt,@DiffRemittanceAmt,@TariffType,@DtCreated,@DtCreatedby)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_PrincipalMasterdtls SET PID=@PID,AgreementTypeID=@AgreementTypeID,CommissionTypeID=@CommissionTypeID,ShipmentTypeID=@ShipmentTypeID,ChargeID=@ChargeID,PortID=@PortID,TerminalID=@TerminalID,CurrencyID=@CurrencyID," +
                             " CntrTypeID=@CntrTypeID,Amount=@Amount,CollectionAmt=@CollectionAmt,CostAmt=@CostAmt,DifferentAmt=@DifferentAmt,DiffRemittanceAmt=@DiffRemittanceAmt,TariffType=@TariffType,DtCreated=@DtCreated,DtCreatedby=@DtCreatedby where SID=@SID and PID=@PID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgreementTypeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommissionTypeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[9]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAmt", CharSplit[10]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CostAmt", CharSplit[11]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DifferentAmt", CharSplit[12]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DiffRemittanceAmt", CharSplit[13]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffType", CharSplit[14]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreated", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreatedby", 1));
                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved Sucessfully"

                    }); ;
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return List;
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

        public List<MyPrincibalTariff> ViewPrincipalTraiffMaster(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> ViewList = new List<MyPrincibalTariff>();
            DataTable dt = GetPrincipalTraiffMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPrincibalTariff
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LineName = dt.Rows[i]["LineName"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString()

                });

            }
            return ViewList;
        }

        public DataTable GetPrincipalTraiffMaster(MyPrincibalTariff Data)
        {
            string strWhere = "";
            string _Query = "select ID,upper(LineName) as LineName, (select top(1) CountryName from NVO_CountryMaster where ID =CountryID) as CountryName from NVO_PrincipalMaster";


            if (Data.LineName != "" && Data.LineName != null)
                if (strWhere == "")
                    strWhere += _Query + " Where LineName='" + Data.LineName + "'";
                else
                    strWhere += " and LineName ='" + Data.LineName + "'";


            if (Data.CountryID != "" && Data.CountryID != "0" && Data.CountryID != null && Data.CountryID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where CountryID=" + Data.CountryID;
                else
                    strWhere += " and CountryID =" + Data.CountryID;

            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")

                if (strWhere == "")
                    strWhere += _Query + " where  Status = " + Data.Status;
                else
                    strWhere += " and Status = " + Data.Status;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyPrincibalTariff> EditPrincipalTraiffMaster(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> ViewList = new List<MyPrincibalTariff>();
            DataTable dt = GetEditPrincipalTraiffMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPrincibalTariff
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LineCode = dt.Rows[i]["LineCode"].ToString(),
                    LineName = dt.Rows[i]["LineName"].ToString(),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),
                    CityID = dt.Rows[i]["CityID"].ToString(),
                    StateID = dt.Rows[i]["StateID"].ToString(),
                    TaxGST = dt.Rows[i]["TaxGST"].ToString(),
                    PinCode = dt.Rows[i]["PinCode"].ToString(),
                    Email = dt.Rows[i]["EmailID"].ToString(),
                    TelNo = dt.Rows[i]["TelNo"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Note = dt.Rows[i]["Note"].ToString()
                });

            }
            return ViewList;
        }

        public DataTable GetEditPrincipalTraiffMaster(MyPrincibalTariff Data)
        {

            string _Query = "select * from NVO_PrincipalMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");

        }

        public List<MyPrincibalTariff> PrincipalTraiffPortMaster(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> ViewList = new List<MyPrincibalTariff>();
            DataTable dt = GetPrincipalTraiffPortMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPrincibalTariff
                {
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString()
                });

            }
            return ViewList;
        }


        public DataTable GetPrincipalTraiffPortMaster(MyPrincibalTariff Data)
        {
            string _Query = " select " +
                            " (select top(1) AgencyName from NVO_AgencyMaster where ID = AgencyID) as AgencyName, " +
                            " (select top(1) PortName from NVO_AgencyPortDtls where NVO_AgencyPortDtls.AgencyID = NVO_AgencyPrincipalDtls.AgencyID) as PortName " +
                            " from NVO_AgencyPrincipalDtls where PrincipalID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyPrincibalTariff> ViewPrincipalTraiffAgrementMaster(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> ViewList = new List<MyPrincibalTariff>();
            DataTable dt = GetPrincipalTraiffAgreement(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPrincibalTariff
                {
                    SID = Int32.Parse(dt.Rows[i]["SID"].ToString()),
                    PID = Int32.Parse(dt.Rows[i]["PID"].ToString()),
                    AgreementTypeID = dt.Rows[i]["AgreementTypeID"].ToString(),
                    CommissionTypeID = dt.Rows[i]["CommissionTypeID"].ToString(),
                    ShipmentTypeID = dt.Rows[i]["ShipmentTypeID"].ToString(),
                    ChargeTypeID = dt.Rows[i]["ChargeID"].ToString(),
                    PortID = dt.Rows[i]["PortID"].ToString(),
                    TerminalID = dt.Rows[i]["TerminalID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    CollectionAmt = dt.Rows[i]["CollectionAmt"].ToString(),
                    CostAmt = dt.Rows[i]["CostAmt"].ToString(),
                    DifferentAmt = dt.Rows[i]["DifferentAmt"].ToString(),
                    DiffRemittanceAmt = dt.Rows[i]["DiffRemittanceAmt"].ToString(),
                    TariffType = dt.Rows[i]["TariffType"].ToString()



                });

            }
            return ViewList;
        }

        public DataTable GetPrincipalTraiffAgreement(MyPrincibalTariff Data)
        {
            string _Query = "select SID,PID,AgreementTypeID,CommissionTypeID,ShipmentTypeID,ChargeID,PortID,TerminalID,CurrencyID,CntrTypeID,Amount,CollectionAmt,CostAmt,DifferentAmt," +
                            " DiffRemittanceAmt,TariffType from NVO_PrincipalMasterdtls where PID=" + Data.ID + " and TariffType=" + Data.TariffType;
            return GetViewData(_Query, "");
        }

        public List<MyPrincibalTariff> DeletePrincipalTariffRecord(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> List = new List<MyPrincibalTariff>();

            int r1 = 0;
            int r2 = 0;
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
                    Cmd.CommandText = " delete from NVO_PrincipalMasterdtls where SID=@SID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SID", Data.SID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Principal Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        public List<MyPrincibalTariff> InsertPrincipalTariffAlertEmail(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> List = new List<MyPrincibalTariff>();
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


                    if (Data.Items != null)
                    {
                        string[] Array3 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array3.Length; i++)
                        {
                            var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PrincipalEmailAlert where AlertTypeID=@AlertTypeID and PID=@PID and EmailID=@EmailID )<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_PrincipalEmailAlert(PID,AlertTypeID,EmailID) " +
                             " values(@PID,@AlertTypeID,@EmailID)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_PrincipalEmailAlert SET PID=@PID,AlertTypeID=@AlertTypeID,EmailID=@EmailID where AlertTypeID=@AlertTypeID and PID=@PID and EmailID=@EmailID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AlertTypeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", CharSplit[2]));
                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved Sucessfully"

                    }); ;
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    List.Add(new MyPrincibalTariff
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return List;
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


        public List<MyPrincibalTariff> ExistingPrincipalEmailAlert(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> ViewList = new List<MyPrincibalTariff>();
            DataTable dt = getExistingPrincipalEmailAlert(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPrincibalTariff
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AlertTypeID = dt.Rows[i]["AlertTypeID"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString()

                });

            }
            return ViewList;
        }

        public DataTable getExistingPrincipalEmailAlert(MyPrincibalTariff Data)
        {
            string _Query = " Select ID,PID,AlertTypeID,EmailID from NVO_PrincipalEmailAlert where PID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyPrincibalTariff> ViewPrincipalTraiffAgrementMasterView(MyPrincibalTariff Data)
        {
            List<MyPrincibalTariff> ViewList = new List<MyPrincibalTariff>();
            DataTable dt = GetPrincipalTraiffAgreementView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyPrincibalTariff
                {

                    AgreementType = dt.Rows[i]["AgreementType"].ToString(),
                    TariffType = dt.Rows[i]["TariffTypes"].ToString(),
                    CommissionType = dt.Rows[i]["CommissionType"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentTypes"].ToString(),
                    ChargeType = dt.Rows[i]["ChargeCode"].ToString(),
                    Currency = dt.Rows[i]["CurrencyName"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypes"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                });

            }
            return ViewList;
        }



        public DataTable GetPrincipalTraiffAgreementView(MyPrincibalTariff Data)
        {
            string _Query = " select SID, PID,( select top(1) GeneralName from NVO_GeneralMaster where Id = AgreementTypeID) as AgreementType, " +
                            " case when TariffType = 1 then 'Freight' else case when TariffType = 2 then 'Terminal' else case when TariffType = 3 then 'Detention' else " +
                            " case when TariffType = 4 then 'Landside Charges' end end end end   as TariffTypes, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = shipmentTypeID) as ShipmentTypes, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = CommissionTypeID) as CommissionType, " +
                            " (select top(1) ChgDesc from NVO_ChargeTB where Id = ChargeID) as ChargeCode, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where Id = CurrencyID) as CurrencyName, " +
                            " (select top(1) Size from NVO_tblCntrTypes where Id = CntrTypeID) as CntrTypes,Amount, " +
                            " AgreementTypeID,CommissionTypeID,ShipmentTypeID,ChargeID,PortID,TerminalID,CurrencyID,CntrTypeID, " +
                            " CollectionAmt,CostAmt,DifferentAmt,DiffRemittanceAmt,TariffType " +
                            " from NVO_PrincipalMasterdtls " +
                            " inner join NVO_PrincipalMaster on NVO_PrincipalMaster.ID = NVO_PrincipalMasterdtls.PID " +
                            " where NVO_PrincipalMaster.Id = 3";
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
                    cmd.CommandTimeout = 180;
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

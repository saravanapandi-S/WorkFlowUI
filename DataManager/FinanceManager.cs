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
    public class FinanceManager
    {
        List<MyChargeCode> ListChgCode = new List<MyChargeCode>();
        List<MyGLMapping> ListGLMap = new List<MyGLMapping>();
        List<MYGLMaster> ListGLMaster = new List<MYGLMaster>();
        List<MyCreditControl> ListCC = new List<MyCreditControl>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public FinanceManager()
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
        #endregion

        #region ganesh (finance- chargecode,taxdecl,taxengine)

        #region chargecode
        public List<MyChargeCode> ChargeCodeMaster(MyChargeCode Data)
        {
            DataTable dt = GetChargeCodevalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListChgCode.Add(new MyChargeCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChgCode = dt.Rows[i]["ChgCode"].ToString(),
                    ChgDesc = dt.Rows[i]["ChgDesc"].ToString(),
                    SACCode = dt.Rows[i]["SacCode"].ToString(),
                    //DtValidTill = dt.Rows[i]["DtValidTill"].ToString(),
                   // DtValidFrom = dt.Rows[i]["DtValidFrom"].ToString(),
                    ChargeGroup = dt.Rows[i]["ChargeGroup"].ToString(),
                    Basis = dt.Rows[i]["Basis"].ToString(),
                    Ownership = dt.Rows[i]["Ownership"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });
            }
            return ListChgCode;
        }

        public DataTable GetChargeCodevalues(MyChargeCode Data)
        {
            string _Query = " select Chg.ID,Chg.ChgCode,Chg.ChgDesc,SacCode,(select top 1 GeneralName from NVO_generalMaster where ID = ChargeGroupID) as ChargeGroup,( select top 1 GeneralName from NVO_generalMaster where ID = BasisID) as Basis,(select top 1 GeneralName from NVO_generalMaster where ID = ownershipID) as Ownership, case when Chg.status = 1 then 'Active' when Chg.status = 0 then 'Inactive' ELSE '' END as StatusResult  from NVO_ChargeTB Chg  ";

            string strWhere = "";

            if (Data.ChgCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where Chg.ChgCode like '%" + Data.ChgCode + "%'";
                else
                    strWhere += " and Chg.ChgCode like '%" + Data.ChgCode + "%'";

            if (Data.ChgDesc != "")
                if (strWhere == "")
                    strWhere += _Query + " where Chg.ChgDesc like '%" + Data.ChgDesc + "%'";
                else
                    strWhere += " and Chg.ChgDesc like '%" + Data.ChgDesc + "%'";

            if (Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != "" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where Chg.Status =" + Data.StatusID;
                else
                    strWhere += " and Chg.Status =" + Data.StatusID;

            if (Data.OwnershipID.ToString() != "0" && Data.OwnershipID.ToString() != "" && Data.OwnershipID.ToString() != null && Data.OwnershipID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where Chg.OwnershipID =" + Data.OwnershipID;
                else
                    strWhere += " and Chg.OwnershipID =" + Data.OwnershipID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyChargeCode> ListChargeGrouping()
        {
            DataTable dt = GetChargeGrouping();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ChargeGroupID = Int32.Parse(dt.Rows[i]["ChargeGroupID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetChargeGrouping()
        {
            string _Query = "select Id as ChargeGroupID,GeneralName  from NVO_GeneralMaster where seqno=10 ";
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> ListBasis()
        {
            DataTable dt = GetBasislist();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    BasisID = Int32.Parse(dt.Rows[i]["BasisID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetBasislist()
        {
            string _Query = "select Id as BasisID,GeneralName from NVO_GeneralMaster where seqno=5 ";
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> ListOwnership()
        {
            DataTable dt = GetOwnershiplist();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    OwnershipID = Int32.Parse(dt.Rows[i]["OwnershipID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetOwnershiplist()
        {
            string _Query = "select Id as OwnershipID,GeneralName from NVO_GeneralMaster where seqno=11 ";
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> GetChargeCodeMasterRecord(MyChargeCode Data)
        {
            DataTable dt = GetChgCodeRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListChgCode.Add(new MyChargeCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChgCode = dt.Rows[i]["ChgCode"].ToString(),
                    ChgDesc = dt.Rows[i]["ChgDesc"].ToString(),
                    SACCode = dt.Rows[i]["SACCode"].ToString(),
                    //DtValidFrom = dt.Rows[i]["DtFrom"].ToString(),
                   // DtValidTill = dt.Rows[i]["DtTill"].ToString(),
                    ChargeGroupID = Int32.Parse(dt.Rows[i]["ChargeGroupID"].ToString()),
                    BasisID = Int32.Parse(dt.Rows[i]["BasisID"].ToString()),
                    OwnershipID = Int32.Parse(dt.Rows[i]["OwnershipID"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    IsNVOCC = Int32.Parse(dt.Rows[i]["IsNVOCC"].ToString()),
                    IsForwarding = Int32.Parse(dt.Rows[i]["IsForwarding"].ToString()),
                    IsDeposit = Int32.Parse(dt.Rows[i]["IsDeposit"].ToString()),
                    IsRevenue = Int32.Parse(dt.Rows[i]["IsRevenue"].ToString()),
                    IsBreakUp = Int32.Parse(dt.Rows[i]["Breakup"].ToString()),
                });
            }
            return ListChgCode;
        }
        public DataTable GetChgCodeRecord(MyChargeCode Data)
        {
            string _Query = " select * from NVO_ChargeTB where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> InsertChgCodeMaster(MyChargeCode Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ChargeTB where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ChargeTB(ChgCode,ChgDesc,ChargeGroupID,IsRevenue,BasisID,SACCode,OwnershipID,Status,IsNVOCC,IsForwarding,IsDeposit,Breakup) " +
                                     " values (@ChgCode,@ChgDesc,@ChargeGroupID,@IsRevenue,@BasisID,@SACCode,@OwnershipID,@Status,@IsNVOCC,@IsForwarding,@IsDeposit,@Breakup) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ChargeTB SET ChgCode=@ChgCode,ChgDesc=@ChgDesc,ChargeGroupID=@ChargeGroupID,IsRevenue=@IsRevenue,BasisID=@BasisID,SACCode=@SACCode,OwnershipID=@OwnershipID,Status=@Status,IsNVOCC=@IsNVOCC,IsForwarding=@IsForwarding,IsDeposit=@IsDeposit,Breakup=@Breakup where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChgCode", Data.ChgCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChgDesc", Data.ChgDesc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeGroupID", Data.ChargeGroupID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsRevenue", Data.IsRevenue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BasisID", Data.BasisID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SACCode", Data.SACCode));



                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnershipID", Data.OwnershipID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsNVOCC", Data.IsNVOCC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsForwarding", Data.IsForwarding));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsDeposit", Data.IsDeposit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Breakup", Data.IsBreakUp));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ChargeTB')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListChgCode;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListChgCode;
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

        #region Taxengine and Tax declaration

        public List<MyChargeCode> InsertChgTaxDeclaration(MyChargeCode Data)
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


                    Cmd.CommandText = " IF((select count(*) from NVO_ChgTaxDeclaration where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ChgTaxDeclaration(TaxPercentage,TaxName,CountryID,StatusID,DtCreated) " +
                                     " values (@TaxPercentage,@TaxName,@CountryID,@StatusID,@DtCreated) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ChgTaxDeclaration SET TaxPercentage=@TaxPercentage,TaxName=@TaxName,DtModified=@DtModified,CountryID=@CountryID,StatusID=@StatusID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPercentage", Data.TaxPercentage));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxName", Data.TaxName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreated", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));


                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ChgTaxDeclaration')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ChgTaxDeclarationDtls where ChgDeclID=@ChgDeclID and TID=@TID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ChgTaxDeclarationDtls(ChgDeclID,TaxCodeID,TaxCode,TaxDescription,Percentage,TaxGLID,TaxGL,DtAdded) " +
                                     " values (@ChgDeclID,@TaxCodeID,@TaxCode,@TaxDescription,@Percentage,@TaxGLID,@TaxGL,@DtAdded) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ChgTaxDeclarationDtls SET ChgDeclID=@ChgDeclID,TaxCodeID=@TaxCodeID,TaxCode=@TaxCode,TaxDescription=@TaxDescription,Percentage=@Percentage,TaxGLID=@TaxGLID,TaxGL=@TaxGL,DateModified=@DateModified where ChgDeclID=@ChgDeclID and TID=@TID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxCodeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxCode", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxDescription", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Percentage", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGLID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGL", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DateModified", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChgDeclID", Data.ID));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();

                    ListChgCode.Add(new MyChargeCode { ID = Data.ID });
                    return ListChgCode;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListChgCode;
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

        public List<MyChargeCode> ExistingChargeCodesValid(MyChargeCode Data)
        {
            DataTable dt = GetExistingChargeCodesValid(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChgCode = dt.Rows[i]["ChgCode"].ToString(),

                });
            }
            return ListChgCode;
        }

        public DataTable GetExistingChargeCodesValid(MyChargeCode Data)
        {
            string _Query = "select * from NVO_ChargeTB where ChgCode ='" + Data.ChgCode + "' OR ChgDesc ='" + Data.ChgDesc + "' and OwnershipID =" + Data.OwnershipID + " ";
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> TaxDeclarationViewRec(MyChargeCode Data)
        {
            DataTable dt = GetTaxDeclarationValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxName = dt.Rows[i]["TaxName"].ToString(),
                    TaxPercentage = dt.Rows[i]["TaxPercentage"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString()
                });

            }
            return ListChgCode;
        }

        public DataTable GetTaxDeclarationValues(MyChargeCode Data)
        {
            string strWhere = "";
            string _Query = " Select CT.ID,CT.TaxName,CT.TaxPercentage,CM.CountryName,case when CT.StatusID=1 THEN 'ACTIVE' WHEN CT.StatusID=2 THEN 'INACTIVE' END StatusV from NVO_ChgTaxDeclaration CT Inner join NVO_CountryMaster CM ON CM.ID = CT.CountryID ";


            if (Data.TaxName != "")
                if (strWhere == "")
                    strWhere += _Query + " where CT.TaxName like '%" + Data.TaxName + "%'";
                else
                    strWhere += " and CT.TaxName like '%" + Data.TaxName + "%'";


            if (Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "?" && Data.CountryID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where CT.CountryID=" + Data.CountryID;
                else
                    strWhere += " and CT.CountryID =" + Data.CountryID;

            if (Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != "" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where CT.StatusID =" + Data.StatusID;
                else
                    strWhere += " and StatusID =" + Data.StatusID;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }
        public List<MyChargeCode> ChargeTaxDeclEdit(MyChargeCode Data)
        {
            DataTable dt = GetChargeTaxDecl(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),

                    TaxPercentage = dt.Rows[i]["TaxPercentage"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    TaxCode1 = dt.Rows[i]["TaxCode1"].ToString(),
                    TaxCode2 = dt.Rows[i]["TaxCode2"].ToString(),
                    TaxGL1 = dt.Rows[i]["TaxGL1"].ToString(),
                    TaxGL2 = dt.Rows[i]["TaxGL2"].ToString(),
                    TaxCodePercentage1 = Decimal.Parse(dt.Rows[i]["TaxCodePercentage1"].ToString()),
                    TaxCodePercentage2 = Decimal.Parse(dt.Rows[i]["TaxCodePercentage2"].ToString()),


                }); ;
            }
            return ListChgCode;
        }


        public DataTable GetChargeTaxDecl(MyChargeCode Data)
        {
            string _Query = "Select * from NVO_ChargeTaxDeclDtls where ID = " + Data.ID + " ";
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> ListTaxDecl(MyChargeCode Data)
        {
            DataTable dt = GetTaxDeclDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListChgCode.Add(new MyChargeCode
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxPercentage = dt.Rows[i]["TaxPercentage"].ToString(),
                    TaxName = dt.Rows[i]["TaxName"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),

                }); ;
            }
            return ListChgCode;
        }
        public DataTable GetTaxDeclDtls(MyChargeCode Data)
        {
            string _Query = " Select * from NVO_ChgTaxDeclaration where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> GetGridTaxDeclDtls(MyChargeCode Data)
        {
            DataTable dt = GetTaxDeclDtlsValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    TaxCodeID = Int32.Parse(dt.Rows[i]["TaxCodeID"].ToString()),
                    TaxCode = dt.Rows[i]["TaxCode"].ToString(),
                    TaxDescription = dt.Rows[i]["TaxDescription"].ToString(),
                    Percentage = dt.Rows[i]["Percentage"].ToString(),
                    TaxGLID = Int32.Parse(dt.Rows[i]["TaxGLID"].ToString()),
                    TaxGL = dt.Rows[i]["TaxGL"].ToString()
                });
            }
            return ListChgCode;
        }
        public DataTable GetTaxDeclDtlsValues(MyChargeCode Data)
        {
            string _Query = "Select * from NVO_ChgTaxDeclarationDtls where ChgDeclID=" + Data.ID + "";
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> ListShipmentTypes(MyChargeCode Data)
        {
            DataTable dt = GetShipmentTypes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetShipmentTypes()
        {
            string _Query = "select Id as ShipmentTypeID,GeneralName from NVO_GeneralMaster where seqno=1 ";
            return GetViewData(_Query, "");
        }


        public List<MyChargeCode> ListTaxNames(MyChargeCode Data)
        {
            DataTable dt = GetTaxNames(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxCode = dt.Rows[i]["TaxCode"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetTaxNames(MyChargeCode Data)
        {
            string _Query = "select ID,TaxCode from NVO_FinanceTaxNames Where CountryID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> ListTaxDescByTaxName(MyChargeCode Data)
        {
            DataTable dt = GetTaxDescByTaxName(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxDescription = dt.Rows[i]["TaxDescription"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetTaxDescByTaxName(MyChargeCode Data)
        {
            string _Query = "select ID,TaxDescription from NVO_FinanceTaxNames where ID =" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> ListTaxGLTypes(MyChargeCode Data)
        {
            DataTable dt = GetTaxGLTypes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable GetTaxGLTypes()
        {
            string _Query = " Select ID,GLCode from NVO_GLMaster order by id";
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> ListChargeCodes(MyChargeCode Data)
        {
            DataTable dt = ChargeCodes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ChargeTBID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChgCode = dt.Rows[i]["ChgCode"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable ChargeCodes()
        {
            string _Query = "select Id,ChgCode from NVO_ChargeTB order by ChgDesc";
            return GetViewData(_Query, "");
        }
        public List<StateDD> ListStates()
        {
            List<StateDD> ListState = new List<StateDD>();
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
            string _Query = "select ID AS stateID,StateName from NVO_stateMaster order by StateName ";
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> ListTaxPercentage(MyChargeCode Data)
        {
            DataTable dt = TaxPercentages(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxName = dt.Rows[i]["TaxName"].ToString()
                });
            }
            return ListChgCode;
        }

        public DataTable TaxPercentages(MyChargeCode Data)
        {
            string _Query = "select ID,TaxName from NVO_ChgTaxDeclaration where CountryID=" + Data.CountryID;
            return GetViewData(_Query, "");
        }
        public List<MyChargeCode> InsertTaxEngineDtls(MyChargeCode Data)
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


                    Cmd.CommandText = " IF((select count(*) from NVO_ChargeTaxEngineDtls where  ID=@ID )<=0 ) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ChargeTaxEngineDtls(TaxPercentageID,ChargeTBID,SACCode,ShipmentTypeID,DtAdded) " +
                                     " values (@TaxPercentageID,@ChargeTBID,@SACCode,@ShipmentTypeID,@DtAdded) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ChargeTaxEngineDtls SET TaxPercentageID=@TaxPercentageID,ChargeTBID=@ChargeTBID,SACCode=@SACCode,ShipmentTypeID=@ShipmentTypeID,DtModified=@DtModified where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPercentageID", Data.TaxPercentageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTBID", Data.ChargeTBID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SACCode", Data.SACCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", Data.ShipmentTypeID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ChargeTaxEngineDtls')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    Cmd.CommandText = "INSERT INTO NVO_ChargeTaxEngineLog (ChargeTBID,AgencyID,DtAdded,UserID,DtModified) VALUES (@ChargeTBID,@AgencyID,@DtAdded,@UserID,@DtModified)";

                    result = Cmd.ExecuteNonQuery();

                    trans.Commit();
                    return ListChgCode;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListChgCode;
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

        public List<MyChargeCode> TaxEngineViewDtls(MyChargeCode Data)
        {
            DataTable dt = GetTaxEngineViewDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {


                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    // ChargeTBID= Int32.Parse(dt.Rows[i]["ChargeTBID"].ToString()),
                    ChgCode = dt.Rows[i]["ChgCode"].ToString(),
                    TaxName = dt.Rows[i]["TaxName"].ToString(),
                    SACCode = dt.Rows[i]["SACCode"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),

                });
            }
            return ListChgCode;
        }
        public List<MyChargeCode> BindSACCodeByChgCodeValues(MyChargeCode Data)
        {
            DataTable dt = GetSACCodeByChgCode(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SACCode = dt.Rows[i]["SACCode"].ToString(),

                });
            }
            return ListChgCode;
        }
        public DataTable GetSACCodeByChgCode(MyChargeCode Data)
        {
            string _Query = "select ID,SACCode from NVO_ChargeTB where ID= " + Data.ID;
            return GetViewData(_Query, "");
        }
        public DataTable GetTaxEngineViewDtls(MyChargeCode Data)
        {
            string strWhere = "";
            string _Query = " select TE.ID,( select top 1 GeneralName from NVO_generalMaster where ID=ShipmentTypeID)  ShipmentType,TE.SACCODE,  (select top 1 ChgCode from NVO_ChargeTB where ID = ChargeTBID ) ChgCode,(select top 1 TaxName from NVO_ChgTaxDeclaration where ID = TaxPercentageID ) TaxName From  NVO_ChargeTaxEngineDtls TE ";


            if (Data.ChargeTBID.ToString() != "0" && Data.ChargeTBID.ToString() != null && Data.ChargeTBID.ToString() != "?" && Data.ChargeTBID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where TE.ChargeTBID=" + Data.ChargeTBID;
                else
                    strWhere += " and TE.ChargeTBID =" + Data.ChargeTBID;

            if (Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "?" && Data.CountryID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where (select top 1 countryID from NVO_ChgTaxDeclaration where ID = TaxPercentageID )=" + Data.CountryID;
                else
                    strWhere += " and (select top 1 countryID from NVO_ChgTaxDeclaration where ID = TaxPercentageID ) =" + Data.CountryID;


            if (Data.TaxPercentageID.ToString() != "0" && Data.TaxPercentageID.ToString() != null && Data.TaxPercentageID.ToString() != "?" && Data.TaxPercentageID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where TE.TaxPercentageID=" + Data.TaxPercentageID.ToString();
                else
                    strWhere += " and TE.TaxPercentageID =" + Data.TaxPercentageID.ToString();


            if (Data.ShipmentTypeID.ToString() != "0" && Data.ShipmentTypeID.ToString() != null && Data.ShipmentTypeID.ToString() != "?" && Data.ShipmentTypeID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where TE.ShipmentTypeID=" + Data.ShipmentTypeID.ToString();
                else
                    strWhere += " and TE.ShipmentTypeID =" + Data.ShipmentTypeID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyChargeCode> TaxEngineViewEdit(MyChargeCode Data)
        {
            DataTable dt = GetTaxEngineViewEdit(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeTBID = Int32.Parse(dt.Rows[i]["ChargeTBID"].ToString()),
                    TaxPercentageID = Int32.Parse(dt.Rows[i]["TaxPercentageID"].ToString()),
                    SACCode = dt.Rows[i]["SACCode"].ToString(),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString())

                });
            }
            return ListChgCode;
        }

        public DataTable GetTaxEngineViewEdit(MyChargeCode Data)
        {
            string _Query = "select * from NVO_ChargeTaxEngineDtls where ID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> ExistingTaxEngineDtls(MyChargeCode Data)
        {
            DataTable dt = GetExistingTaxEngineDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeTBID = Int32.Parse(dt.Rows[i]["ChargeTBID"].ToString()),

                });
            }
            return ListChgCode;
        }

        public DataTable GetExistingTaxEngineDtls(MyChargeCode Data)
        {
            string _Query = " select * from NVO_ChargeTaxEnginedtls " +
                            " inner join NVO_ChgTaxDeclaration on NVO_ChgTaxDeclaration.ID = NVO_ChargeTaxEnginedtls.TaxPercentageID " +
                           " inner join NVO_CountryMaster on NVO_CountryMaster.ID = NVO_ChgTaxDeclaration.CountryID " +
                          " where ChargeTBID =" + Data.ChargeTBID + " and NVO_ChgTaxDeclaration.CountryID = " + Data.CountryID + " and TaxPercentageID =" + Data.TaxPercentageID + " and ShipmentTypeID = " + Data.ShipmentTypeID;
            return GetViewData(_Query, "");
        }

        public DataTable DeleteTaxEngineDtls(MyChargeCode Data)
        {

            string _Query = " Delete NVO_ChargeTaxEngineDtls where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Tax Names
        public List<MyChargeCode> TaxNamesviewRec(MyChargeCode Data)
        {
            DataTable dt = GetTaxNamesviewValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxCode = dt.Rows[i]["TaxCode"].ToString(),
                    TaxDescription = dt.Rows[i]["TaxDescription"].ToString(),
                    CountryName = dt.Rows[i]["Country"].ToString(),

                });

            }
            return ListChgCode;
        }

        public DataTable GetTaxNamesviewValues(MyChargeCode Data)
        {
            string strWhere = "";
            string _Query = "select ID,TaxCode,TaxDescription,CountryID,Country  from NVO_FinanceTaxNames ";


            if (Data.TaxCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where TaxCode like '%" + Data.TaxCode + "%'";
                else
                    strWhere += " and TaxCode like '%" + Data.TaxCode + "%'";


            if (Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "?" && Data.CountryID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where CountryID=" + Data.CountryID;
                else
                    strWhere += " and CountryID =" + Data.CountryID;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyChargeCode> TaxNameVieweditRec(MyChargeCode Data)
        {
            DataTable dt = GetTaxNameVieweditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListChgCode.Add(new MyChargeCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxCode = dt.Rows[i]["TaxCode"].ToString(),
                    TaxDescription = dt.Rows[i]["TaxDescription"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),

                });

            }
            return ListChgCode;
        }

        public DataTable GetTaxNameVieweditValues(MyChargeCode Data)
        {

            string _Query = "select * from NVO_FinanceTaxNames  where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyChargeCode> InsertTaxNamesMaster(MyChargeCode Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_FinanceTaxNames where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_FinanceTaxNames(TaxCode,TaxDescription,CountryID,Country) " +
                                     " values (@TaxCode,@TaxDescription,@CountryID,@Country) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_FinanceTaxNames SET TaxCode=@TaxCode,TaxDescription=@TaxDescription,CountryID=@CountryID,Country=@Country where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxCode", Data.TaxCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxDescription", Data.TaxDescription));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Country", Data.CountryName));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_FinanceTaxNames')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListChgCode;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListChgCode;
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

        #region customercontrol
        public List<MyCreditControl> CustomerMaster()
        {
            List<MyCreditControl> CustomerList = new List<MyCreditControl>();
            DataTable dt = GetCustomerMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    ID = Int32.Parse(dt.Rows[i]["Id"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return ListCC;
        }

        public DataTable GetCustomerMaster()
        {
            string _Query = "select * from NVO_CustomerMaster";

            return GetViewData(_Query, "");
        }

        public List<MyCreditControl> PartyTypesByCustomer(MyCreditControl Data)
        {
            List<MyCreditControl> CustomerList = new List<MyCreditControl>();
            DataTable dt = GetPartyTypesByCustomer(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCC;
        }

        public DataTable GetPartyTypesByCustomer(MyCreditControl Data)
        {
            string _Query = "select NVO_GeneralMaster.ID,NVO_GeneralMaster.GeneralName from NVO_CustomerMaster inner join NVO_GeneralMaster on NVO_GeneralMaster.ID = NVO_CustomerMaster.CustomerType AND SeqNo = 18 inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.ID where NVO_CusBranchLocation.CID = " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyCreditControl> InsertCreditControlData(MyCreditControl Data)
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


                    Cmd.CommandText = " IF((select count(*) from NVO_FinCustomerCreditControl where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_FinCustomerCreditControl(PartyID,PartyType,ExemptFromTax,Remarks,CusCreditDays,CusCreditLimit,CusEmailAlert,VendorCreditDays,VendorCreditLimit,VendorEmailAlert,VendorInvApproval,VendorPaymentApproval,AgencyID,UserID,CusSunDryAccID,VenSunDryAccID) " +
                                     " values (@PartyID,@PartyType,@ExemptFromTax,@Remarks,@CusCreditDays,@CusCreditLimit,@CusEmailAlert,@VendorCreditDays,@VendorCreditLimit,@VendorEmailAlert,@VendorInvApproval,@VendorPaymentApproval,@AgencyID,@UserID,@CusSunDryAccID,@VenSunDryAccID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_FinCustomerCreditControl SET PartyID=@PartyID,PartyType=@PartyType,ExemptFromTax=@ExemptFromTax,Remarks=@Remarks,CusCreditDays=@CusCreditDays,CusCreditLimit=@CusCreditLimit,CusEmailAlert=@CusEmailAlert,VendorCreditDays=@VendorCreditDays,VendorCreditLimit=@VendorCreditLimit,VendorEmailAlert=@VendorEmailAlert,VendorInvApproval=@VendorInvApproval,VendorPaymentApproval=@VendorPaymentApproval,AgencyID=@AgencyID,UserID=@UserID,CusSunDryAccID=@CusSunDryAccID,VenSunDryAccID=@VenSunDryAccID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.PartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyType", Data.PartyType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExemptFromTax", Data.ExemptFromTax));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CusCreditDays", Data.CusCreditDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CusCreditLimit", Data.CusCreditLimit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CusEmailAlert", Data.CusEmailAlert));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorCreditDays", Data.VendorCreditDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorCreditLimit", Data.VendorCreditLimit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorEmailAlert", Data.VendorEmailAlert));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorInvApproval", Data.VendorInvApproval));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CusSunDryAccID", Data.CusSunDryAcc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VenSunDryAccID", Data.VenSunDryAcc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VendorPaymentApproval", Data.VendorPaymentApproval));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_FinCustomerCreditControl')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    if (Data.PartyType.ToString() == "49")
                    {
                        string[] Array = Data.ItemsC.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_FinCustomerCrCtrlDtls where CrCtrlID=@CrCtrlID and CCID=@CCID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_FinCustomerCrCtrlDtls(CrCtrlID,CurrencyID,Currency,DefaultID,DefaultC,StatusID,Status) " +
                                         " values (@CrCtrlID,@CurrencyID,@Currency,@DefaultID,@DefaultC,@StatusID,@Status) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_FinCustomerCrCtrlDtls SET CrCtrlID=@CrCtrlID,CurrencyID=@CurrencyID,Currency=@Currency,DefaultID=@DefaultID,DefaultC=@DefaultC,StatusID=@StatusID,Status=@Status where CrCtrlID=@CrCtrlID and CCID=@CCID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CCID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultC", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CrCtrlID", Data.ID));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }

                        string[] Array1 = Data.ItemsV.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplitV = Array1[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_FinVendorCrCtrlDtls where CrCtrlID=@CrCtrlID and VCID=@VCID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_FinVendorCrCtrlDtls(CrCtrlID,CurrencyVID,CurrencyV,DefaultVID,DefaultV,StatusVID,StatusV) " +
                                         " values (@CrCtrlID,@CurrencyVID,@CurrencyV,@DefaultVID,@DefaultV,@StatusVID,@StatusV) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_FinVendorCrCtrlDtls SET CrCtrlID=@CrCtrlID,CurrencyVID=@CurrencyVID,CurrencyV=@CurrencyV,DefaultVID=@DefaultVID,DefaultV=@DefaultV,StatusVID=@StatusVID,StatusV=@StatusV where CrCtrlID=@CrCtrlID and VCID=@VCID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VCID", CharSplitV[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyVID", CharSplitV[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyV", CharSplitV[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultVID", CharSplitV[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultV", CharSplitV[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusVID", CharSplitV[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusV", CharSplitV[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CrCtrlID", Data.ID));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.PartyType.ToString() == "44")
                    {

                        string[] Array1 = Data.ItemsV.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplitV = Array1[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_FinVendorCrCtrlDtls where CrCtrlID=@CrCtrlID and VCID=@VCID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_FinVendorCrCtrlDtls(CrCtrlID,CurrencyVID,CurrencyV,DefaultVID,DefaultV,StatusVID,StatusV) " +
                                        " values (@CrCtrlID,@CurrencyVID,@CurrencyV,@DefaultVID,@DefaultV,@StatusVID,@StatusV) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_FinVendorCrCtrlDtls SET CrCtrlID=@CrCtrlID,CurrencyVID=@CurrencyVID,CurrencyV=@CurrencyV,DefaultVID=@DefaultVID,DefaultV=@DefaultV,StatusVID=@StatusVID,StatusV=@StatusV where CrCtrlID=@CrCtrlID and VCID=@VCID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VCID", CharSplitV[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyVID", CharSplitV[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyV", CharSplitV[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultVID", CharSplitV[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultV", CharSplitV[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusVID", CharSplitV[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusV", CharSplitV[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CrCtrlID", Data.ID));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.PartyType.ToString() == "45")
                    {
                        string[] Array = Data.ItemsC.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_FinCustomerCrCtrlDtls where CrCtrlID=@CrCtrlID and CCID=@CCID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_FinCustomerCrCtrlDtls(CrCtrlID,CurrencyID,Currency,DefaultID,DefaultC,StatusID,Status) " +
                                         " values (@CrCtrlID,@CurrencyID,@Currency,@DefaultID,@DefaultC,@StatusID,@Status) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_FinCustomerCrCtrlDtls SET CrCtrlID=@CrCtrlID,CurrencyID=@CurrencyID,Currency=@Currency,DefaultID=@DefaultID,DefaultC=@DefaultC,StatusID=@StatusID,Status=@Status where CrCtrlID=@CrCtrlID and CCID=@CCID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CCID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DefaultC", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", CharSplit[6]));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CrCtrlID", Data.ID));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }


                    }

                    trans.Commit();

                    ListCC.Add(new MyCreditControl { ID = Data.ID });
                    return ListCC;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCC;
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

        public List<MyCreditControl> CreditControlViewRec(MyCreditControl Data)
        {
            DataTable dt = GetCreditControlValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    PartyTypes = dt.Rows[i]["PartyType"].ToString(),
                    TaxExempt = dt.Rows[i]["TaxExempt"].ToString(),

                });

            }
            return ListCC;
        }

        public DataTable GetCreditControlValues(MyCreditControl Data)
        {
            string strWhere = "";
            string _Query = "select FCC.ID," +
                 " (select top 1  upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id where NVO_CusBranchLocation.CID =FCC.PartyID ) as  " +

                " CustomerName,GM.GeneralName As PartyType,case when FCC.ExemptFromTax =1 THEN 'YES' when FCC.ExemptFromTax =2 THEN 'NO' END TaxExempt from NVO_FinCustomerCreditControl FCC " +
                          //" inner join NVO_CusBranchLocation CB on CB.CID = FCC.PartyID "+
                          // " inner join  NVO_CustomerMaster CM ON CM.ID = FCC.PartyID " +
                          " inner join  NVO_GeneralMaster GM ON GM.ID = FCC.PartyType  AND GM.SeqNo = 18 ";



            if (Data.PartyID.ToString() != "0" && Data.PartyID.ToString() != null && Data.PartyID.ToString() != "?" && Data.PartyID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where FCC.PartyID=" + Data.PartyID;
                else
                    strWhere += " and FCC.PartyID =" + Data.PartyID;

            if (Data.PartyType.ToString() != "0" && Data.PartyType.ToString() != null && Data.PartyType.ToString() != "?" && Data.PartyType.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where FCC.PartyType=" + Data.PartyType;
                else
                    strWhere += " and FCC.PartyType =" + Data.PartyType;


            if (Data.ExemptFromTax.ToString() != "0" && Data.ExemptFromTax.ToString() != null && Data.ExemptFromTax.ToString() != "?" && Data.ExemptFromTax.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where FCC.ExemptFromTax=" + Data.ExemptFromTax;
                else
                    strWhere += " and FCC.ExemptFromTax =" + Data.ExemptFromTax;

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != null && Data.AgencyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " and FCC.AgencyID= " + Data.AgencyID;
                else
                    strWhere += " and FCC.AgencyID= " + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }
        public List<MyCreditControl> ViewCreditControlEditRec(MyCreditControl Data)
        {
            DataTable dt = GetCreditControlValuesEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyType = Int32.Parse(dt.Rows[i]["PartyType"].ToString()),
                    ExemptFromTax = Int32.Parse(dt.Rows[i]["ExemptFromTax"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    CusCreditDays = dt.Rows[i]["CusCreditDays"].ToString(),
                    CusCreditLimit = dt.Rows[i]["CusCreditLimit"].ToString(),
                    CusEmailAlert = Int32.Parse(dt.Rows[i]["CusEmailAlert"].ToString()),
                    VendorCreditDays = dt.Rows[i]["VendorCreditDays"].ToString(),
                    VendorCreditLimit = dt.Rows[i]["VendorCreditLimit"].ToString(),
                    VendorEmailAlert = Int32.Parse(dt.Rows[i]["VendorEmailAlert"].ToString()),
                    VendorInvApproval = Int32.Parse(dt.Rows[i]["VendorInvApproval"].ToString()),
                    VendorPaymentApproval = Int32.Parse(dt.Rows[i]["VendorPaymentApproval"].ToString()),
                    VenSunDryAcc = dt.Rows[i]["VenSunDryAccID"].ToString(),
                    CusSunDryAcc = dt.Rows[i]["CusSunDryAccID"].ToString(),
                });

            }
            return ListCC;
        }

        public DataTable GetCreditControlValuesEdit(MyCreditControl Data)
        {

            string _Query = "select * from NVO_FinCustomerCreditControl  where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCreditControl> GetCreditCustomerLimitDtls(MyCreditControl Data)
        {
            DataTable dt = GetCreditCusLimitValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    CCID = Int32.Parse(dt.Rows[i]["CCID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    DefaultID = Int32.Parse(dt.Rows[i]["DefaultID"].ToString()),
                    DefaultC = dt.Rows[i]["DefaultC"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    Status = dt.Rows[i]["Status"].ToString()
                });
            }
            return ListCC;
        }
        public DataTable GetCreditCusLimitValues(MyCreditControl Data)
        {
            string _Query = "Select * from NVO_FinCustomerCrCtrlDtls where CrCtrlID=" + Data.ID + "";
            return GetViewData(_Query, "");
        }


        public List<MyCreditControl> GetCreditVendorLimitDtls(MyCreditControl Data)
        {
            DataTable dt = GetCreditVenLimitValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    VCID = Int32.Parse(dt.Rows[i]["VCID"].ToString()),
                    CurrencyVID = Int32.Parse(dt.Rows[i]["CurrencyVID"].ToString()),
                    CurrencyV = dt.Rows[i]["CurrencyV"].ToString(),
                    DefaultVID = Int32.Parse(dt.Rows[i]["DefaultVID"].ToString()),
                    DefaultV = dt.Rows[i]["DefaultV"].ToString(),
                    StatusVID = Int32.Parse(dt.Rows[i]["StatusVID"].ToString()),
                    StatusV = dt.Rows[i]["StatusV"].ToString()
                });
            }
            return ListCC;
        }
        public DataTable GetCreditVenLimitValues(MyCreditControl Data)
        {
            string _Query = "Select * from NVO_FinVendorCrCtrlDtls where CrCtrlID=" + Data.ID + "";
            return GetViewData(_Query, "");
        }

        public List<MyCreditControl> GetSunDryAccs(MyCreditControl Data)
        {
            DataTable dt = GetSunDryAccsValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCC.Add(new MyCreditControl
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SunDryAcc = dt.Rows[i]["SunDryAcc"].ToString()
                });
            }
            return ListCC;
        }
        public DataTable GetSunDryAccsValues(MyCreditControl Data)
        {
            string _Query = "select ID,GLCODE +'-' + GLDesc as SunDryAcc from NVO_GLMaster where ID IN (32,80)";
            return GetViewData(_Query, "");
        }
        #endregion

        #region BANK MASTER
        List<MyBankMaster> ListBM = new List<MyBankMaster>();
        public List<MyBankMaster> BankModeValuesData(MyBankMaster Data)
        {

            DataTable dt = GetBankModeValuesData(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBM.Add(new MyBankMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BankMasterMode = dt.Rows[i]["GeneralName"].ToString(),


                });

            }
            return ListBM;
        }

        public DataTable GetBankModeValuesData(MyBankMaster Data)
        {

            string _Query = "select * from NVO_GeneralMaster WHERE SeqNo=43";
            return GetViewData(_Query, "");
        }

        public List<MyBankMaster> InsertBankMaster(MyBankMaster Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_FinBankMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_FinBankMaster(BankCode,BankName,AccountNo,ModeID,CurrID,GLCodeID,StatusID,SwiftCode,BranchName,IFSCCode,BranchAddress,UserID,DtAdded) " +
                                     " values (@BankCode,@BankName,@AccountNo,@ModeID,@CurrID,@GLCodeID,@StatusID,@SwiftCode,@BranchName,@IFSCCode,@BranchAddress,@UserID,@DtAdded) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_FinBankMaster SET BankCode=@BankCode,BankName=@BankName,AccountNo=@AccountNo,ModeID=@ModeID,CurrID=@CurrID,GLCodeID=@GLCodeID,StatusID=@StatusID,SwiftCode=@SwiftCode,BranchName=@BranchName,IFSCCode=@IFSCCode,BranchAddress=@BranchAddress,UserID=@UserID,DtModified=@DtModified where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BankCode", Data.BankCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BankName", Data.BankName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AccountNo", Data.AccountNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeID", Data.ModeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrID", Data.CurrencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLCodeID", Data.GLCodeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SwiftCode", Data.SwiftCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchName", Data.BranchName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IFSCCode", Data.IFSCCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchAddress", Data.BranchAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_FinBankMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_FinBankMasterDtls where BMID=@BMID and BID=@BID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_FinBankMasterDtls(AgencyID,Agency,BMID) " +
                                     " values (@AgencyID,@Agency,@BMID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_FinBankMasterDtls SET AgencyID=@AgencyID,Agency=@Agency,BMID=@BMID where BMID=@BMID and BID=@BID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Agency", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BMID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Dtadded", System.DateTime.Now.Date.ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array1 = Data.ItemsDoc.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit1 = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_FinBankMasterAttachments where BMID=@BMID and AID=@AID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_FinBankMasterAttachments(FileName,AttachFile,BMID,UploadedOn,UploadedBy) " +
                                     " values (@FileName,@AttachFile,@BMID,@UploadedOn,@UploadedBy) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_FinBankMasterAttachments SET FileName=@FileName,AttachFile=@AttachFile,BMID=@BMID,ModifiedBy=@ModifiedBy, ModifiedOn=@ModifiedOn where BMID=@BMID and AID=@AID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AID", CharSplit1[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", CharSplit1[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", CharSplit1[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BMID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedOn", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                    ListBM.Add(new MyBankMaster { ID = Data.ID });
                    return ListBM;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListBM;
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

        public List<MyBankMaster> BankMasterViewData(MyBankMaster Data)
        {
            DataTable dt = GetBankMasterViewValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListBM.Add(new MyBankMaster
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AccountNo = dt.Rows[i]["AccountNo"].ToString(),
                    BankName = dt.Rows[i]["BankName"].ToString(),
                    BankCode = dt.Rows[i]["BankCode"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });
            }
            return ListBM;
        }

        public DataTable GetBankMasterViewValues(MyBankMaster Data)
        {
            string _Query = "SELECT ID,AccountNo,BankName,BankCode, case when StatusID = 1 then 'Active' when StatusID = 0 then 'Inactive' ELSE '' END as Status FROM NVO_FinBankMaster";
            string strWhere = "";

            if (Data.AccountNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where AccountNo like '%" + Data.AccountNo + "%'";
                else
                    strWhere += " and AccountNo like '%" + Data.AccountNo + "%'";

            if (Data.BankName != "")
                if (strWhere == "")
                    strWhere += _Query + " where BankName like '%" + Data.BankName + "%'";
                else
                    strWhere += " and BankName  like '%" + Data.BankName + "%'";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyBankMaster> BankMasterEditData(MyBankMaster Data)
        {
            DataTable dt = GetBankMasterEditDataValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBM.Add(new MyBankMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCodeID = Int32.Parse(dt.Rows[i]["GLCodeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrID"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    ModeID = Int32.Parse(dt.Rows[i]["ModeID"].ToString()),
                    BankName = dt.Rows[i]["BankName"].ToString(),
                    BankCode = dt.Rows[i]["BankCode"].ToString(),
                    AccountNo = dt.Rows[i]["AccountNo"].ToString(),
                    IFSCCode = dt.Rows[i]["IFSCCode"].ToString(),
                    SwiftCode = dt.Rows[i]["SwiftCode"].ToString(),
                    BranchAddress = dt.Rows[i]["BranchAddress"].ToString(),
                    BranchName = dt.Rows[i]["BranchName"].ToString(),
                });
            }
            return ListBM;
        }

        public DataTable GetBankMasterEditDataValues(MyBankMaster Data)
        {
            string _Query = "SELECT * FROM NVO_FinBankMaster Where ID =" + Data.ID;

            return GetViewData(_Query, "");


        }

        public List<MyBankMaster> BindBankMasterDtlsData(MyBankMaster Data)
        {
            DataTable dt = GetBankMasterDtlsData(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBM.Add(new MyBankMaster
                {
                    BID = Int32.Parse(dt.Rows[i]["BID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    Agency = dt.Rows[i]["Agency"].ToString(),


                });
            }
            return ListBM;
        }

        public DataTable GetBankMasterDtlsData(MyBankMaster Data)
        {
            string _Query = "SELECT * FROM NVO_FinBankMasterDtls Where BMID =" + Data.ID;

            return GetViewData(_Query, "");


        }

        public List<MyBankMaster> BindBankMasterAttachDtls(MyBankMaster Data)
        {
            DataTable dt = GetBindBankMasterAttachDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBM.Add(new MyBankMaster
                {
                    AID = Int32.Parse(dt.Rows[i]["AID"].ToString()),
                    File = dt.Rows[i]["FileName"].ToString(),
                    FileName = dt.Rows[i]["AttachFile"].ToString(),


                });
            }
            return ListBM;
        }

        public DataTable GetBindBankMasterAttachDtls(MyBankMaster Data)
        {
            string _Query = "SELECT * FROM NVO_FinBankMasterAttachments Where BMID =" + Data.ID;

            return GetViewData(_Query, "");


        }

        public List<MyBankMaster> BankAttachmentsDelete(MyBankMaster Data)
        {
            DataTable dt = GetBankAttachmentsDelete(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBM.Add(new MyBankMaster
                {
                    AID = Int32.Parse(dt.Rows[i]["AID"].ToString()),

                });
            }
            return ListBM;
        }

        public DataTable GetBankAttachmentsDelete(MyBankMaster Data)
        {
            string _Query = "Delete FROM NVO_FinBankMasterAttachments Where AID =" + Data.AID;

            return GetViewData(_Query, "");


        }
        #endregion

        #endregion

        #region anand
        public List<MyGLMapping> InsertGLMapping(MyGLMapping Data)
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
                    int result;
                    if (Data.ID != 0)
                    {
                        Cmd.CommandText = " Insert into NVO_GLMappingLog(GLMapID,ChargeCode,ProductType,ShipmentType,PrincipalExpGL,PrincipalRevGL,Agency,ValidFrom,CreatedOn,CreatedBy) select ID AS GLMapID, isnull((select top 1(ChgCode + ' - ' + chgDesc) from NVO_ChargeTB where ID = ChargeCodeID),'') As ChargeCode,isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = ProductTypeID),'') As ProductType, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = ShipmentTypeID),'') As ShipmentType,  isnull((select top 1 GLCode from NVO_GLMaster where ID = PrincipalExpGL),'') As PrincipalExpGL,isnull((select top 1 GLCode from NVO_GLMaster where ID = PrincipalRevGL),'') As PrincipalRevGL,isnull((select top 1 AgencyName from NVO_AgencyMaster where ID = UserID),'') As Agency, replace(convert(NVARCHAR, ValidFrom, 23), ' ', '-'), CurrentDate, isnull((select top 1 UserName from NVO_UserDetails where ID = NVO_GLMapping.UserID),'') As UserName FROM NVO_GLMapping  WHERE ID = " + Data.ID;
                        result = Cmd.ExecuteNonQuery();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_GLMapping where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_GLMapping(ChargeCodeID,ProductTypeID,ShipmentTypeID,PrincipalRevGL,PrincipalExpGL,AgencyRevGL,AgencyExpGL,ValidFrom,UserID,LocID,AgencyID,CurrentDate) " +
                                     " values (@ChargeCodeID,@ProductTypeID,@ShipmentTypeID,@PrincipalRevGL,@PrincipalExpGL,@AgencyRevGL,@AgencyExpGL,@ValidFrom,@UserID,@LocID,@AgencyID,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_GLMapping SET ChargeCodeID=@ChargeCodeID,ProductTypeID=@ProductTypeID,ShipmentTypeID=@ShipmentTypeID,PrincipalRevGL=@PrincipalRevGL,PrincipalExpGL=@PrincipalExpGL,AgencyRevGL=@AgencyRevGL,AgencyExpGL=@AgencyExpGL,ValidFrom=@ValidFrom,UserID=@UserID,LocID=@LocID,AgencyID=@AgencyID,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", Data.ChargeCodeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ProductTypeID", Data.ProductTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", Data.ShipmentTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalRevGL", Data.PrincipalRevGL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalExpGL", Data.PrincipalExpGL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyRevGL", Data.AgencyRevGL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyExpGL", Data.AgencyExpGL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", Data.ValidFrom));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocID", 0));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


                    result = Cmd.ExecuteNonQuery();



                    if (Data.ID != 0)
                    {
                        Cmd.CommandText = " Insert into NVO_GLMappingLog(GLMapID,ChargeCode,ProductType,ShipmentType,PrincipalExpGL,PrincipalRevGL,Agency,ValidFrom,ModifiedOn,ModifiedBy) select ID AS GLMapID, isnull((select top 1(ChgCode + ' - ' + chgDesc) from NVO_ChargeTB where ID = " + Data.ChargeCodeID + "),'') As ChargeCode,isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = " + Data.ProductTypeID + "),'') As ProductType, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = " + Data.ShipmentTypeID + "),'') As ShipmentType,  isnull((select top 1 GLCode from NVO_GLMaster where ID = " + Data.PrincipalExpGL + "),'') As PrincipalExpGL,isnull((select top 1 GLCode from NVO_GLMaster where ID = " + Data.PrincipalRevGL + "),'') As PrincipalRevGL,isnull((select top 1 AgencyName from NVO_AgencyMaster where ID = " + Data.AgencyID + "),'') As Agency, '" + Data.ValidFrom + "', getdate(), isnull((select top 1 UserName from NVO_UserDetails where ID = " + Data.UserID + "),'') As UserName FROM NVO_GLMapping  WHERE ID = " + Data.ID;

                        result = Cmd.ExecuteNonQuery();

                    }

                    Cmd.CommandText = "select ident_current('NVO_GLMapping')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListGLMap;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListGLMap;
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

        public List<MyGLMapping> GLMappingMasterView(MyGLMapping Data)
        {
            DataTable dt = GetGLMappingValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMap.Add(new MyGLMapping
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCodeV = dt.Rows[i]["ChgCode"].ToString(),
                    ProductTypeV = dt.Rows[i]["ProductTypeV"].ToString(),
                    ShipmentTypeV = dt.Rows[i]["ShipmentTypeV"].ToString(),
                    ProductTypeID = Int32.Parse(dt.Rows[i]["ProductTypeID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),

                    ValidFrom = dt.Rows[i]["ValidFromV"].ToString()

                });

            }
            return ListGLMap;
        }

        public DataTable GetGLMappingValues(MyGLMapping Data)
        {
            string strWhere = "";
            string _Query = " select NVO_GLMapping.ID,ProductTypeID,ShipmentTypeID,Case when ProductTypeID=14 then 'LINER AGENCIES(SOC)' WHEN ProductTypeID=15 then 'NVOCC(COC)' WHEN ProductTypeID=200 then 'FORWARDING' WHEN ProductTypeID=201 Then 'TRANSPORT' WHEN ProductTypeID=202 Then 'WAREHOUSE' end as ProductTypeV, (select top 1 (ChgCode +' - '+ chgDesc)  from NVO_ChargeTB where ID = ChargeCodeID ) ChgCode,Case When ShipmentTypeID = 1 then 'EXPORT' else 'IMPORT' end as ShipmentTypeV, replace(convert(NVARCHAR, ValidFrom, 106), ' ', '-') as ValidFromV from NVO_GLMapping ";



            if (Data.ChargeCodeV != "" && Data.ChargeCodeV != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 ChgCode +' - '+ ChgDesc from NVO_ChargeTB where ID=ChargeCodeID ) like '%" + Data.ChargeCodeV + "%'";
                else
                    strWhere += " and (select top 1 ChgCode +' - '+ ChgDesc from NVO_ChargeTB where ID=ChargeCodeID ) like '%" + Data.ChargeCodeV + "%'";


            if (Data.ProductTypeID.ToString() != "0" && Data.ProductTypeID.ToString() != null && Data.ProductTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where ProductTypeID=" + Data.ProductTypeID;
                else
                    strWhere += " and ProductTypeID =" + Data.ProductTypeID;

            if (Data.ShipmentTypeID.ToString() != "0" && Data.ShipmentTypeID.ToString() != "" && Data.ShipmentTypeID.ToString() != null && Data.ShipmentTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where ShipmentTypeID =" + Data.ShipmentTypeID;
                else
                    strWhere += " and ShipmentTypeID =" + Data.ShipmentTypeID;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyGLMapping> GLMappingMasterRecord(string ID)
        {
            DataTable dt = GetGLMappingRecordValues(ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMap.Add(new MyGLMapping
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    ProductTypeID = Int32.Parse(dt.Rows[i]["ProductTypeID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    PrincipalRevGL = Int32.Parse(dt.Rows[i]["PrincipalRevGL"].ToString()),
                    PrincipalExpGL = Int32.Parse(dt.Rows[i]["PrincipalExpGL"].ToString()),
                    AgencyRevGL = Int32.Parse(dt.Rows[i]["AgencyRevGL"].ToString()),
                    AgencyExpGL = Int32.Parse(dt.Rows[i]["AgencyExpGL"].ToString()),
                    ValidFrom = dt.Rows[i]["ValidFromV"].ToString()

                });

            }
            return ListGLMap;
        }

        public DataTable GetGLMappingRecordValues(string ID)
        {
            //string strWhere = "";

            string _Query = "Select replace(convert(NVARCHAR, ValidFrom, 23), ' ', '-') as ValidFromV, * from NVO_GLMapping where ID=" + ID;
            return GetViewData(_Query, "");

        }

        public List<MyGLMapping> GLMappingLogRecord(string ID)
        {
            DataTable dt = GetGLMappingLogRecordValues(ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMap.Add(new MyGLMapping
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLMapID = Int32.Parse(dt.Rows[i]["GLMapID"].ToString()),
                    ChargeCodeV = dt.Rows[i]["ChargeCode"].ToString(),
                    ProductTypeV = dt.Rows[i]["ProductType"].ToString(),
                    ShipmentTypeV = dt.Rows[i]["ShipmentType"].ToString(),
                    PrincipalRevGLV = dt.Rows[i]["PrincipalRevGL"].ToString(),
                    PrincipalExpGLV = dt.Rows[i]["PrincipalExpGL"].ToString(),
                    Agency = dt.Rows[i]["Agency"].ToString(),
                    ValidFrom = dt.Rows[i]["ValidFromV"].ToString(),
                    CreatedOn = dt.Rows[i]["CreatedOn"].ToString(),
                    CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                    ModifiedOn = dt.Rows[i]["ModifiedOn"].ToString(),
                    ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString(),
                });

            }
            return ListGLMap;
        }

        public DataTable GetGLMappingLogRecordValues(string ID)
        {
            //string strWhere = "";

            string _Query = "Select replace(convert(NVARCHAR, ValidFrom, 106), ' ', '-') as ValidFromV, * from NVO_GLMappingLog where GLMapID=" + ID;
            return GetViewData(_Query, "");

        }

        public List<MYGLMaster> InsertGLMaster(MYGLMaster Data)
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
                    int result;
                    if (Data.ID != 0)
                    {
                        Cmd.CommandText = "Insert into NVO_GLMasterlog (GLID,GLCODE,GLDesc,GLNature,MainAccType,Category,GLMatching,Company,Status,CreatedOn,CreatedBy)select ID AS GLID, GLCODE, GLDesc,isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = GLNature),'') As GLNature, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = MainAccType),'') As MainAccType, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = Category),'') As Category, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = GLMatching),'') As GLMatching,  isnull((select top 1 AgencyName from NVO_AgencyMaster where ID = CompanyID),'') As Company, Case when StatusID = 1 Then 'ACTIVE' WHEN StatusID = 2 Then 'INACTIVE' End as Status,CurrentDate,isnull((select top 1 UserName from NVO_UserDetails where ID = UserID),'') As UserName from NVO_GLMaster WHERE ID = " + Data.ID;
                        result = Cmd.ExecuteNonQuery();
                    }

                    Cmd.CommandText = " IF((select count(*) from NVO_GLMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_GLMaster(GLCode,CompanyID,MainAccType,GLNature,Category,GLMatching,ProductType,GLDesc,UserID,LocID,AgencyID,CurrentDate,StatusID) " +
                                     " values (@GLCode,@CompanyID,@MainAccType,@GLNature,@Category,@GLMatching,@ProductType,@GLDesc,@UserID,@LocID,@AgencyID,@CurrentDate,@StatusID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_GLMaster SET GLCode=@GLCode,CompanyID=@CompanyID,MainAccType=@MainAccType,GLNature=@GLNature,Category=@Category,GLMatching=@GLMatching,ProductType=@ProductType,GLDesc=@GLDesc,ModifiedBy=@ModifiedBy,LocID=@LocID,AgencyID=@AgencyID,ModifiedOn=@ModifiedOn,StatusID=@StatusID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLCode", Data.GLCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyID", Data.CompanyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MainAccType", Data.MainAccType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLNature", Data.GLNature));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Category", Data.Category));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLMatching", Data.GLMatching));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ProductType", Data.ProductType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLDesc", Data.GLDesc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocID", 0));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedOn", System.DateTime.Now));

                    result = Cmd.ExecuteNonQuery();



                    if (Data.ID != 0)
                    {
                        Cmd.CommandText = "Insert into NVO_GLMasterlog (GLID,GLCODE,GLDesc,GLNature,MainAccType,Category,GLMatching,Company,Status,ModifiedOn,ModifiedBy)select ID AS GLID,  '" + Data.GLCode + "',  '" + Data.GLDesc + "',isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = " + Data.GLNature + "),'') As GLNature, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = " + Data.MainAccType + "),'') As MainAccType, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = " + Data.Category + "),'') As Category, isnull((select top 1 GeneralName from NVO_GeneralMaster where ID = " + Data.GLMatching + "),'') As GLMatching,  isnull((select top 1 AgencyName from NVO_AgencyMaster where ID = " + Data.CompanyID + "),'') As Company, Case when StatusID = " + Data.StatusID + " Then 'ACTIVE' WHEN StatusID = " + Data.StatusID + " Then 'INACTIVE' End as Status,getDate(),isnull((select top 1 UserName from NVO_UserDetails where ID = " + Data.UserID + "),'') As UserName from NVO_GLMaster WHERE ID = " + Data.ID;
                        result = Cmd.ExecuteNonQuery();

                    }

                    Cmd.CommandText = "select ident_current('NVO_GLMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListGLMaster;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListGLMaster;
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

        public List<MYGLMaster> GLMasterViewDtls(MYGLMaster Data)
        {
            DataTable dt = GetGLMasterView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMaster.Add(new MYGLMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString(),
                    GLDesc = dt.Rows[i]["GLDesc"].ToString(),
                    CategoryV = dt.Rows[i]["Category"].ToString(),
                    MainAccTypeV = dt.Rows[i]["MainAccType"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),

                });

            }
            return ListGLMaster;
        }
        public DataTable GetGLMasterView(MYGLMaster Data)
        {
            string strWhere = "";
            string _Query = "select ID,GLCode,GLDesc,(Select top 1 AgencyName from NVO_AgencyMaster where ID = companyID) Agency,(Select top 1 GeneralName from NVO_GeneralMaster where ID = MainAccType) MainAccType,(Select top 1 GeneralName from NVO_GeneralMaster where ID = GLNature) GLNature,(Select top 1 GeneralName from NVO_GeneralMaster where ID = Category) Category,(Select top 1 GeneralName from NVO_GeneralMaster where ID = GLMatching) GLMatching,(Select top 1 GeneralName from NVO_GeneralMaster where ID = ProductType) ProductType,Case when StatusID = 1 Then 'ACTIVE' WHEN StatusID = 2 Then 'INACTIVE' End as Status from NVO_GLMaster ";


            if (Data.GLCode != "" && Data.GLCode != null)
                if (strWhere == "")
                    strWhere += _Query + " where GLCode like '%" + Data.GLCode + "%'";
                else
                    strWhere += " and GLCode like '%" + Data.GLCode + "%'";


            if (Data.GLDesc != "" && Data.GLDesc != null)
                if (strWhere == "")
                    strWhere += _Query + " where GLDesc like '%" + Data.GLDesc + "%'";
                else
                    strWhere += " and GLDesc like '%" + Data.GLDesc + "%'";

            if (Data.Category.ToString() != "0" && Data.Category.ToString() != "" && Data.Category.ToString() != null && Data.Category.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where Category =" + Data.Category;
                else
                    strWhere += " and Category =" + Data.Category;

            if (Data.MainAccType.ToString() != "0" && Data.MainAccType.ToString() != "" && Data.MainAccType.ToString() != null && Data.MainAccType.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where MainAccType =" + Data.MainAccType;
                else
                    strWhere += " and MainAccType =" + Data.MainAccType;

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, "");
        }

        public List<MYGLMaster> GLMasterRecordDtls(string ID)
        {
            DataTable dt = GetGLMasterRecordValues(ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMaster.Add(new MYGLMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString(),
                    CompanyID = Int32.Parse(dt.Rows[i]["CompanyID"].ToString()),
                    MainAccType = Int32.Parse(dt.Rows[i]["MainAccType"].ToString()),
                    GLNature = Int32.Parse(dt.Rows[i]["GLNature"].ToString()),
                    Category = Int32.Parse(dt.Rows[i]["Category"].ToString()),
                    GLMatching = Int32.Parse(dt.Rows[i]["GLMatching"].ToString()),
                    ProductType = Int32.Parse(dt.Rows[i]["ProductType"].ToString()),
                    GLDesc = dt.Rows[i]["GLDesc"].ToString(),
                    StatusID = dt.Rows[i]["StatusID"].ToString()

                });

            }
            return ListGLMaster;
        }

        public DataTable GetGLMasterRecordValues(string ID)
        {
            //string strWhere = "";

            string _Query = "Select * from NVO_GLMaster where ID=" + ID;
            return GetViewData(_Query, "");

        }

        public List<MYGLMaster> GLCodeMaster(MYGLMaster Data)
        {
            DataTable dt = GetGLCodeMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMaster.Add(new MYGLMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString()

                });

            }
            return ListGLMaster;
        }
        public DataTable GetGLCodeMaster(MYGLMaster Data)
        {

            string _Query = "Select ID,(GLCODE +'-'+ GLDESC ) AS GLCode from NVO_GLMaster";
            return GetViewData(_Query, "");

        }
        public List<MYGLMaster> GLMasterLogRecord(MYGLMaster Data)
        {
            DataTable dt = GETGLMasterLogRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMaster.Add(new MYGLMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GLID = Int32.Parse(dt.Rows[i]["GLID"].ToString()),
                    GLCode = dt.Rows[i]["GLCode"].ToString(),
                    GLDesc = dt.Rows[i]["GLDesc"].ToString(),
                    GLNatureV = dt.Rows[i]["GLNature"].ToString(),
                    GLMatchingV = dt.Rows[i]["GLMatching"].ToString(),
                    CategoryV = dt.Rows[i]["Category"].ToString(),
                    Company = dt.Rows[i]["Company"].ToString(),
                    MainAccTypeV = dt.Rows[i]["MainAccType"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    CreatedOn = dt.Rows[i]["CreatedOn"].ToString(),
                    CreatedBy = dt.Rows[i]["CreatedBy"].ToString(),
                    ModifiedOn = dt.Rows[i]["ModifiedOn"].ToString(),
                    ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString(),
                });

            }
            return ListGLMaster;
        }
        public DataTable GETGLMasterLogRecord(MYGLMaster Data)
        {

            string _Query = "Select * from NVO_GLMasterlog where GLID=" + Data.ID;
            return GetViewData(_Query, "");

        }
        public List<MYGLMaster> GLMasterCodeNewEntry(MYGLMaster Data)
        {
            DataTable dt = GETGLMasterCodeNewEntry(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGLMaster.Add(new MYGLMaster
                {

                    GLCode = dt.Rows[i]["GLCode"].ToString(),

                });

            }
            return ListGLMaster;
        }
        public DataTable GETGLMasterCodeNewEntry(MYGLMaster Data)
        {

            string _Query = "select TOP 1 GLCODE+1 AS GLCode from  NVO_GLMaster  ORDER BY ID DESC";
            return GetViewData(_Query, "");

        }
        #endregion
    }
}
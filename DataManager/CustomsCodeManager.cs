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
   public class CustomsCodeManager
    {
        List<MyAgentCode> AgentList = new List<MyAgentCode>();
        List<MyPortCode> PortList = new List<MyPortCode>();
        List<MyCarrierCode> CarrierList = new List<MyCarrierCode>();
        List<MyTerminalCode> TerminalList = new List<MyTerminalCode>();
        List<MYCFS> CFSList = new List<MYCFS>();
        List<MYPackageCode> PackList = new List<MYPackageCode>();
        List<MYTransporter> TransporterList = new List<MYTransporter>();
        List<MYISOCode> ISOList = new List<MYISOCode>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CustomsCodeManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region AgentCode
        public List<MyAgentCode> InsertCustoms_Agent(MyAgentCode Data)
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
                    string[] Array = Data.AgentItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_AgentCode where PortID=@PortID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_AgentCode(PortID,LineCode,AgentCode,SOCode,PanNo) " +
                                     " values (@PortID,@LineCode,@AgentCode,@SOCode,@PanNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_AgentCode SET PortID=@PortID,LineCode=@LineCode,AgentCode=@AgentCode,SOCode=@SOCode,PanNo=@PanNo where PortID=@PortID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LineCode", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentCode", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SOCode", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PanNo", CharSplit[4]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                  

                    trans.Commit();

                    AgentList.Add(new MyAgentCode
                    {
                        ID = Data.ID,
                       
                    });
                    return AgentList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return AgentList;
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

        public List<MyAgentCode> GetCustomsAgenctCode(MyAgentCode Data)
        {
            List<MyAgentCode> ViewList = new List<MyAgentCode>();
            DataTable dt = GetAgentCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyAgentCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    LineCode = dt.Rows[i]["LineCode"].ToString(),
                    AgentCode = dt.Rows[i]["AgentCode"].ToString(),
                    SOCode = dt.Rows[i]["SOCode"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString(),
                });
            }
            return ViewList;
        }
        public DataTable GetAgentCodeValues(MyAgentCode Data)
        {
            string _Query = "Select * from NVO_Customs_AgentCode";
            return GetViewData(_Query, "");
        }
        public List<MyAgentCode> CustomsAgentDeleteMaster(MyAgentCode Data)
        {
            DataTable dt = DeleteAgentCodeValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgentList.Add(new MyAgentCode
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    PortName = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    LineCode = dt.Rows[i]["LineCode"].ToString(),
                    AgentCode = dt.Rows[i]["AgentCode"].ToString(),
                    SOCode = dt.Rows[i]["SOCode"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString()
                });

            }
            return AgentList;
        }
        public DataTable DeleteAgentCodeValues(MyAgentCode Data)
        {

            string _Query = "Delete NVO_Customs_AgentCode where ID=" + Data.ID;


            return GetViewData(_Query, "");
        }
        #endregion

        #region PortCode
        public List<MyPortCode> InsertCustoms_Port(MyPortCode Data)
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
                    string[] Array = Data.PortItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_PortCode where PortID=@PortID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_PortCode(PortID,UNCode,FloppyCode) " +
                                     " values (@PortID,@UNCode,@FloppyCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_PortCode SET PortID=@PortID,UNCode=@UNCode,FloppyCode=@FloppyCode where PortID=@PortID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UNCode", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FloppyCode", CharSplit[2]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    PortList.Add(new MyPortCode
                    {
                        ID = Data.ID,

                    });
                    return PortList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return PortList;
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

        public List<MyPortCode> GetCustomsPortCode(MyPortCode Data)
        {
            List<MyPortCode> PortList = new List<MyPortCode>();
            DataTable dt = GetPortCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PortList.Add(new MyPortCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    UNCode = dt.Rows[i]["UNCode"].ToString(),
                    FloppyCode = dt.Rows[i]["FloppyCode"].ToString()
                });
            }
            return PortList;
        }
        public DataTable GetPortCodeValues(MyPortCode Data)
        {
            string _Query = "Select * from NVO_Customs_PortCode";
            return GetViewData(_Query, "");
        }

        public List<MyPortCode> CustomsPortDeleteMaster(MyPortCode Data)
        {
            DataTable dt = DeletePortCodeValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PortList.Add(new MyPortCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    UNCode = dt.Rows[i]["UNCode"].ToString(),
                    FloppyCode = dt.Rows[i]["FloppyCode"].ToString()
                });
            }
            return PortList;
        }
        public DataTable DeletePortCodeValues(MyPortCode Data)
        {

            string _Query = "Delete NVO_Customs_PortCode where ID=" + Data.ID;


            return GetViewData(_Query, "");
        }
        #endregion

        #region CarrierCode
        public List<MyCarrierCode> InsertCustoms_Carrier(MyCarrierCode Data)
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
                    string[] Array = Data.CarrierItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_CarrierCode where CarrierID=@CarrierID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_CarrierCode(CarrierID,Code,BondNo,PanNo) " +
                                     " values (@CarrierID,@Code,@BondNo,@PanNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_CarrierCode SET CarrierID=@CarrierID,Code=@Code,BondNo=@BondNo,PanNo=@PanNo where CarrierID=@CarrierID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CarrierID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Code", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BondNo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PanNo", CharSplit[3]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    CarrierList.Add(new MyCarrierCode
                    {
                        ID = Data.ID,

                    });
                    return CarrierList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return CarrierList;
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

        public List<MyCarrierCode> GetCustomsCarrierCode(MyCarrierCode Data)
        {
            List<MyCarrierCode> CarrierList = new List<MyCarrierCode>();
            DataTable dt = GetCarrierCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CarrierList.Add(new MyCarrierCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CarrierID = Int32.Parse(dt.Rows[i]["CarrierID"].ToString()),
                    Code = dt.Rows[i]["Code"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString()
                });
            }
            return CarrierList;
        }
        public DataTable GetCarrierCodeValues(MyCarrierCode Data)
        {
            string _Query = "Select * from NVO_Customs_CarrierCode";
            return GetViewData(_Query, "");
        }

        public List<MyCarrierCode> CustomsCarrierDeleteMaster(MyCarrierCode Data)
        {
            List<MyCarrierCode> CarrierList = new List<MyCarrierCode>();
            DataTable dt = DeleteCarrierCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CarrierList.Add(new MyCarrierCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CarrierID = Int32.Parse(dt.Rows[i]["CarrierID"].ToString()),
                    Code = dt.Rows[i]["Code"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString()
                });
            }
            return CarrierList;
        }
        public DataTable DeleteCarrierCodeValues(MyCarrierCode Data)
        {
            string _Query = "Delete NVO_Customs_CarrierCode where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region TerminalCode
        public List<MyTerminalCode> InsertCustoms_Terminal(MyTerminalCode Data)
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
                    string[] Array = Data.TerminalItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_TerminalCode where TerminalID=@TerminalID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_TerminalCode(TerminalID,PortID,MappingCode) " +
                                     " values (@TerminalID,@PortID,@MappingCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_TerminalCode SET TerminalID=@TerminalID,PortID=@PortID,MappingCode=@MappingCode where TerminalID=@TerminalID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MappingCode", CharSplit[2]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    TerminalList.Add(new MyTerminalCode
                    {
                        ID = Data.ID,

                    });
                    return TerminalList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return TerminalList;
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

        public List<MyTerminalCode> GetCustomsTerminalCode(MyTerminalCode Data)
        {
            List<MyTerminalCode> TerminalList = new List<MyTerminalCode>();
            DataTable dt = GetTerminalCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TerminalList.Add(new MyTerminalCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    MappingCode = dt.Rows[i]["MappingCode"].ToString()
                });
            }
            return TerminalList;
        }
        public DataTable GetTerminalCodeValues(MyTerminalCode Data)
        {
            string _Query = "Select * from NVO_Customs_TerminalCode";
            return GetViewData(_Query, "");
        }

        public List<MyTerminalCode> CustomsTerminalDeleteMaster(MyTerminalCode Data)
        {
            List<MyTerminalCode> TerminalList = new List<MyTerminalCode>();
            DataTable dt = DeleteTerminalCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TerminalList.Add(new MyTerminalCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    MappingCode = dt.Rows[i]["MappingCode"].ToString()
                });
            }
            return TerminalList;
        }
        public DataTable DeleteTerminalCodeValues(MyTerminalCode Data)
        {
            string _Query = "Delete NVO_Customs_TerminalCode where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region CFS
        public List<MYCFS> GetCustomsCFSName(MYCFS Data)
        {
            List<MYCFS> CFSList = new List<MYCFS>();
            DataTable dt = GetCFSNameValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CFSList.Add(new MYCFS
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CFSName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CFSList;
        }
        public DataTable GetCFSNameValues(MYCFS Data)
        {
            string _Query = "select NVO_CustomerMaster.ID,CustomerName  from NVO_CustomerMaster " +
                            " inner join NVO_CusBusinessTypes ON NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID " +
                            " where BussTypes = 5";
            return GetViewData(_Query, "");
        }

        public List<MYCFS> InsertCustoms_CFS(MYCFS Data)
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
                    string[] Array = Data.CFSItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_CFS where CFSID=@CFSID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_CFS(CFSID,Code,BondNo,IALCode) " +
                                     " values (@CFSID,@Code,@BondNo,@IALCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_CFS SET CFSID=@CFSID,Code=@Code,BondNo=@BondNo,IALCode=@IALCode where CFSID=@CFSID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CFSID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Code", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BondNo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IALCode", CharSplit[3]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    CFSList.Add(new MYCFS
                    {
                        ID = Data.ID,

                    });
                    return CFSList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return CFSList;
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

        public List<MYCFS> GetCustomsCFS(MYCFS Data)
        {
            List<MYCFS> CFSList = new List<MYCFS>();
            DataTable dt = GetCFSValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CFSList.Add(new MYCFS
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CFSID = Int32.Parse(dt.Rows[i]["CFSID"].ToString()),
                    CFSCode = dt.Rows[i]["Code"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    IALCode = dt.Rows[i]["IALCode"].ToString()
                });
            }
            return CFSList;
        }
        public DataTable GetCFSValues(MYCFS Data)
        {
            string _Query = "Select * from NVO_Customs_CFS";
            return GetViewData(_Query, "");
        }
        public List<MYCFS> CustomsCFSDeleteMaster(MYCFS Data)
        {
            List<MYCFS> CFSList = new List<MYCFS>();
            DataTable dt = DeleteTerminalCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CFSList.Add(new MYCFS
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CFSID = Int32.Parse(dt.Rows[i]["CFSID"].ToString()),
                    CFSCode = dt.Rows[i]["Code"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    IALCode = dt.Rows[i]["IALCode"].ToString()
                });
            }
            return CFSList;
        }
        public DataTable DeleteTerminalCodeValues(MYCFS Data)
        {
            string _Query = "Delete NVO_Customs_CFS where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Package Code
        public List<MYPackageCode> GetPackageLocation(MYPackageCode Data)
        {
            List<MYPackageCode> PackageList = new List<MYPackageCode>();
            DataTable dt = GetPackLocationValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackageList.Add(new MYPackageCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString()
                });
            }
            return PackageList;
        }
        public DataTable GetPackLocationValues(MYPackageCode Data)
        {
            string _Query = "select ID,GeoLocation from NVO_GeoLocations";
            return GetViewData(_Query, "");
        }

        public List<MYPackageCode> InsertCustoms_PackageCode(MYPackageCode Data)
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
                    string[] Array = Data.PackageItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_PackageCode where PackDescription=@PackDescription and LocID=@LocID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_PackageCode(LocID,PackDescription,GenCode,MappingCode) " +
                                     " values (@LocID,@PackDescription,@GenCode,@MappingCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_PackageCode SET LocID=@LocID,PackDescription=@PackDescription,GenCode=@GenCode,MappingCode=@MappingCode where PackDescription=@PackDescription and LocID=@LocID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocID", Data.LocID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PackDescription", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GenCode", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MappingCode", CharSplit[2]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    PackList.Add(new MYPackageCode
                    {
                        ID = Data.ID,

                    });
                    return PackList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return PackList;
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

        public List<MYPackageCode> GetCustomsPackage(string LocID)
        {
            List<MYPackageCode> PackList = new List<MYPackageCode>();
            DataTable dt = GetPackageCodeValues(LocID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackList.Add(new MYPackageCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocID = Int32.Parse(dt.Rows[i]["LocID"].ToString()),
                    PackDescription = dt.Rows[i]["PackDescription"].ToString(),
                    GenCode = dt.Rows[i]["GenCode"].ToString(),
                    MappingCode = dt.Rows[i]["MappingCode"].ToString()
                });
            }
            return PackList;
        }
        public DataTable GetPackageCodeValues(string LocID)
        {
            string _Query = "Select * from NVO_Customs_PackageCode where LocID=" + LocID;
            return GetViewData(_Query, "");
        }

        public List<MYPackageCode> CustomsPackageCodeDeleteMaster(MYPackageCode Data)
        {
            List<MYPackageCode> PackList = new List<MYPackageCode>();
            DataTable dt = DeletePackageCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackList.Add(new MYPackageCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LocID = Int32.Parse(dt.Rows[i]["LocID"].ToString()),
                    PackDescription = dt.Rows[i]["PackDescription"].ToString(),
                    GenCode = dt.Rows[i]["GenCode"].ToString(),
                    MappingCode = dt.Rows[i]["MappingCode"].ToString()
                });
            }
            return PackList;
        }
        public DataTable DeletePackageCodeValues(MYPackageCode Data)
        {
            string _Query = "Delete NVO_Customs_PackageCode where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Transporter
        public List<MYTransporter> GetCustomsTransporterName(MYTransporter Data)
        {
            List<MYTransporter> TransporterList = new List<MYTransporter>();
            DataTable dt = GetTransporterNameValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TransporterList.Add(new MYTransporter
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TransporterName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return TransporterList;
        }
        public DataTable GetTransporterNameValues(MYTransporter Data)
        {
            string _Query = "select NVO_CustomerMaster.ID,CustomerName  from NVO_CustomerMaster " +
                            " inner join NVO_CusBusinessTypes ON NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID " +
                            " where BussTypes = 6";
            return GetViewData(_Query, "");
        }

        public List<MYTransporter> InsertCustoms_Transporter(MYTransporter Data)
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
                    string[] Array = Data.TransporterItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_Transporter where TRID=@TRID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_Transporter(TRID,Code,BondNo,PanNo) " +
                                     " values (@TRID,@Code,@BondNo,@PanNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_Transporter SET TRID=@TRID,Code=@Code,BondNo=@BondNo,PanNo=@PanNo where TRID=@TRID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TRID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Code", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BondNo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PanNo", CharSplit[3]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    TransporterList.Add(new MYTransporter
                    {
                        ID = Data.ID,

                    });
                    return TransporterList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return TransporterList;
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

        public List<MYTransporter> GetCustomsTransporter(MYTransporter Data)
        {
            List<MYTransporter> TransporterList = new List<MYTransporter>();
            DataTable dt = GetTransporterValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TransporterList.Add(new MYTransporter
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TransporterID = Int32.Parse(dt.Rows[i]["TRID"].ToString()),
                    Code = dt.Rows[i]["Code"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString()
                });
            }
            return TransporterList;
        }
        public DataTable GetTransporterValues(MYTransporter Data)
        {
            string _Query = "Select * from NVO_Customs_Transporter";
            return GetViewData(_Query, "");
        }

        public List<MYTransporter> CustomsTransporterDeleteMaster(MYTransporter Data)
        {
            List<MYTransporter> TransporterList = new List<MYTransporter>();
            DataTable dt = DeleteTransporerValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TransporterList.Add(new MYTransporter
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TransporterID = Int32.Parse(dt.Rows[i]["TRID"].ToString()),
                    Code = dt.Rows[i]["Code"].ToString(),
                    BondNo = dt.Rows[i]["BondNo"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString()
                });
            }
            return TransporterList;
        }
        public DataTable DeleteTransporerValues(MYTransporter Data)
        {
            string _Query = "Delete NVO_Customs_Transporter where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region ISO Code
        public List<MYISOCode> GetCustomsEqTypeName(MYISOCode Data)
        {
            List<MYISOCode> ISOList = new List<MYISOCode>();
            DataTable dt = GetTransporterNameValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ISOList.Add(new MYISOCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EqType = dt.Rows[i]["EqType"].ToString()
                });
            }
            return ISOList;
        }
        public DataTable GetTransporterNameValues(MYISOCode Data)
        {
            string _Query = "select ID, Type + '-' + Size as EqType from NVO_tblCntrTypes";
            return GetViewData(_Query, "");
        }
        public List<MYISOCode> InsertCustoms_ISOCode(MYISOCode Data)
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
                    string[] Array = Data.ISOItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_Customs_ISOCode where EqTypeID=@EqTypeID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Customs_ISOCode(EqTypeID,ISOCode) " +
                                     " values (@EqTypeID,@ISOCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Customs_ISOCode SET EqTypeID=@EqTypeID,ISOCode=@ISOCode where EqTypeID=@EqTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EqTypeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[1]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();

                    ISOList.Add(new MYISOCode
                    {
                        ID = Data.ID,

                    });
                    return ISOList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ISOList;
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

        public List<MYISOCode> GetCustomsISOCode(MYISOCode Data)
        {
            List<MYISOCode> ISOList = new List<MYISOCode>();
            DataTable dt = GetISOCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ISOList.Add(new MYISOCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EqTypeID = Int32.Parse(dt.Rows[i]["EqTypeID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString()
                });
            }
            return ISOList;
        }
        public DataTable GetISOCodeValues(MYISOCode Data)
        {
            string _Query = "Select * from NVO_Customs_ISOCode";
            return GetViewData(_Query, "");
        }

        public List<MYISOCode> CustomsISOCodeDeleteMaster(MYISOCode Data)
        {
            List<MYISOCode> ISOList = new List<MYISOCode>();
            DataTable dt = DeleteISOCodeValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ISOList.Add(new MYISOCode
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EqTypeID = Int32.Parse(dt.Rows[i]["EqTypeID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString()
                });
            }
            return ISOList;
        }
        public DataTable DeleteISOCodeValues(MYISOCode Data)
        {
            string _Query = "Delete NVO_Customs_ISOCode where ID=" + Data.ID;
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
    }
}

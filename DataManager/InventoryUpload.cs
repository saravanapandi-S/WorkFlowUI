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
    public class InventoryUpload
    {
        #region Constructor Method
        public InventoryUpload()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public DataTable InsertCntrMasterExcelUploading(DataTable dtv,string UserID)
        {
            string ChargeTB = "0";

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
                    dt = dts.ToTable(true, "ID", "CNTRNO", "CNTRSIZETYPE", "ISOCODE", "GRADE", "CUBICCAPACITY", "GRWEIGHT", "NETWEIGHT", "TAREWEIGHT", "MFGDATE", "BOXOWNER", "LEASEPARTNER", "LEASETERM", "REFERENCE", "CNTRSTATUS", "RESULT", "STATUS");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_Containers where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Containers(CntrNo,TypeID,ISOCodeID,GradeID,CubicCapacity,DtManufacture,GrWtx100,NtWtx100,TareWtx100,LeaseTermID,BoxOwnerID,LeasingPartnerID,statusID,Reference,PickUpRefID,StatusCode,UserID) " +
                                     " values (@CntrNo,@TypeID,@ISOCodeID,@GradeID,@CubicCapacity,@DtManufacture,@GrWtx100,@NtWtx100,@TareWtx100,@LeaseTermID,@BoxOwnerID,@LeasingPartnerID,@statusID,@Reference,@PickUpRefID,@StatusCode,@UserID) " +

                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Containers SET CntrNo=@CntrNo,TypeID=@TypeID,ISOCodeID=@ISOCodeID,GradeID=@GradeID,DtManufacture=@DtManufacture,GrWtx100=@GrWtx100,NtWtx100=@NtWtx100, TareWtx100=@TareWtx100,LeaseTermID=@LeaseTermID,BoxOwnerID=@BoxOwnerID,LeasingPartnerID=@LeasingPartnerID,statusID=@statusID,Reference=@Reference,PickUpRefID=@PickUpRefID,StatusCode=@StatusCode,UserID=@UserID where ID=@ID";


                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "Cntr Master has been Created";
                            }
                            else
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_Containers where ID=@ID)<=0) " +
                    " BEGIN " +
                   " INSERT INTO  NVO_Containers(CntrNo,TypeID,ISOCodeID,GradeID,CubicCapacity,DtManufacture,GrWtx100,NtWtx100,TareWtx100,LeaseTermID,BoxOwnerID,LeasingPartnerID,statusID,Reference,PickUpRefID,StatusCode,UserID) " +
                   " values (@CntrNo,@TypeID,@ISOCodeID,@GradeID,@CubicCapacity,@DtManufacture,@GrWtx100,@NtWtx100,@TareWtx100,@LeaseTermID,@BoxOwnerID,@LeasingPartnerID,@statusID,@Reference,@PickUpRefID,@StatusCode,@UserID) " +

                    " END  " +
                    " ELSE " +
                   " UPDATE NVO_Containers SET CntrNo=@CntrNo,TypeID=@TypeID,ISOCodeID=@ISOCodeID,GradeID=@GradeID,CubicCapacity=@CubicCapacity,DtManufacture=@DtManufacture,GrWtx100=@GrWtx100,NtWtx100=@NtWtx100, TareWtx100=@TareWtx100,LeaseTermID=@LeaseTermID,BoxOwnerID=@BoxOwnerID,LeasingPartnerID=@LeasingPartnerID,statusID=@statusID,Reference=@Reference,PickUpRefID=@PickUpRefID,StatusCode=@StatusCode,UserID=@UserID where ID=@ID";


                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "Cntr Master has been Updated";
                            }
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TypeID", dt.Rows[i]["CNTRSIZETYPE"].ToString()));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCodeID", dt.Rows[i]["ISOCODE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GradeID", dt.Rows[i]["GRADE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseTermID", dt.Rows[i]["LEASETERM"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BoxOwnerID", dt.Rows[i]["BOXOWNER"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingPartnerID", dt.Rows[i]["LEASEPARTNER"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@statusID", dt.Rows[i]["CNTRSTATUS"].ToString()));
                            Cmd.Parameters.Clear();

                            DataTable _dtChg = GetCntrType(dt.Rows[i]["CNTRSIZETYPE"].ToString());
                            if (_dtChg.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TypeID", _dtChg.Rows[0]["ID"].ToString()));
                                //ChargeTB = _dtChg.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TypeID", 0));

                            DataTable _dtISO = GetISOCodes(dt.Rows[i]["ISOCODE"].ToString());
                            if (_dtISO.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCodeID", _dtISO.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCodeID", 0));

                            DataTable _dtGrade = GetGradeValues(dt.Rows[i]["GRADE"].ToString());
                            if (_dtGrade.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GRADEID", _dtGrade.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GRADEID", 0));
                            DataTable _dtLT = GetLeaseTerm(dt.Rows[i]["LEASETERM"].ToString());
                            if (_dtLT.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseTermID", _dtLT.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LeaseTermID", 0));

                            DataTable _dtBO = GetCustomers(dt.Rows[i]["BOXOWNER"].ToString());
                            if (_dtBO.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BoxOwnerID", _dtBO.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BoxOwnerID", 0));

                            DataTable _dtLP = GetCustomersWithBranch(dt.Rows[i]["LEASEPARTNER"].ToString());
                            if (_dtLP.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingPartnerID", _dtLP.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LeasingPartnerID", 0));

                            DataTable _dtCS = GetCntrStatus(dt.Rows[i]["CNTRSTATUS"].ToString());
                            if (_dtCS.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@statusID", _dtCS.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@statusID", 0));


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", dt.Rows[i]["CNTRNO"].ToString()));
                            if (dt.Rows[i]["MFGDATE"].ToString() != "")
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DtManufacture", DateTime.ParseExact(dt.Rows[i]["MFGDATE"].ToString(), "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                            }
                            else
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DtManufacture", DBNull.Value));
                            }
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CubicCapacity", dt.Rows[i]["CUBICCAPACITY"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GrWtx100", dt.Rows[i]["GRWEIGHT"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWtx100", dt.Rows[i]["NETWEIGHT"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TareWtx100", dt.Rows[i]["TAREWEIGHT"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Reference", dt.Rows[i]["REFERENCE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpRefID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "PENDING"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", UserID));
                            
                            Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {

                                Cmd.CommandText = "select ident_current('NVO_Containers')";
                                if (dt.Rows[i]["ID"].ToString() == "0")
                                    dt.Rows[i]["ID"] = Int32.Parse(Cmd.ExecuteScalar().ToString());
                                else
                                    dt.Rows[i]["ID"] = dt.Rows[i]["ID"];

                                string NewTxnsID = "0";
                                Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                                NewTxnsID = Cmd.ExecuteScalar().ToString();


                                Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,StatusCode,LocationID,DtMovement,NextPortID,DepotID,AgencyID,UserID) " +
                                             " values (@ContainerID,@StatusCode,@LocationID,@DtMovement,@NextPortID,@DepotID,@AgencyID,@UserID) ";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", dt.Rows[i]["ID"]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", System.DateTime.Now));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", "0"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", "0"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", 0));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "PENDING"));

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", 0));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", UserID));
                                Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();


                                Cmd.CommandText = "Update NVO_Containers SET LastMoveMentID=@LastMoveMentID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));

                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }

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

        public DataTable InsertCntMovementExcelUploading(DataTable dtv,string UserID)
        {
            string ChargeTB = "0";

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
                    dt = dts.ToTable(true, "ID", "CNTRNO", "STATUSCODE", "LOCATION", "VESSELVOYAGE", "TRANSITMODE", "DEPOT", "AGENCY", "CUSTOMER", "BLNUMBER", "RESULT", "STATUS");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {
                            string NewTxnsID = "0";

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = "SELECT Ident_current('NVO_ContainerTxns') +1";
                                NewTxnsID = Cmd.ExecuteScalar().ToString();

                                Cmd.CommandText = "INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,NextPortID,ModeOfTransportID,DepotID,BLNumber,CustomerID,AgencyID,UserID) " +
                                             " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@NextPortID,@ModeOfTransportID,@DepotID,@BLNumber,@CustomerID,@AgencyID,@UserID) ";


                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "Cntr Movement has been Updated";
                            }

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", dt.Rows[i]["CNTRNO"].ToString()));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", dt.Rows[i]["LOCATION"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", dt.Rows[i]["LOCATION"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", dt.Rows[i]["VESSELVOYAGE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", dt.Rows[i]["TRANSITMODE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", dt.Rows[i]["DEPOT"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", dt.Rows[i]["AGENCY"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", dt.Rows[i]["CUSTOMER"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", dt.Rows[i]["BLNUMBER"].ToString()));
                         Cmd.Parameters.Clear();

                            DataTable _dtCtrNo = GetCntrNo(dt.Rows[i]["CNTRNO"].ToString());
                            if (_dtCtrNo.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", _dtCtrNo.Rows[0]["ID"].ToString()));
                                //ChargeTB = _dtChg.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", 0));

                            DataTable _dtFrmLoc = GetPorts(dt.Rows[i]["LOCATION"].ToString());
                            if (_dtFrmLoc.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", _dtFrmLoc.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", 0));

                            DataTable _dtNextLoc = GetPorts(dt.Rows[i]["LOCATION"].ToString());
                            if (_dtNextLoc.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", _dtNextLoc.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", 0));

                            DataTable _dtTM = GetTransitmode(dt.Rows[i]["TRANSITMODE"].ToString());
                            if (_dtTM.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", _dtTM.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));

                            DataTable _dtDepo = GetDepots(dt.Rows[i]["DEPOT"].ToString());
                            if (_dtDepo.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", _dtDepo.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", 0));

                            DataTable _dtAg = GetAgency(dt.Rows[i]["AGENCY"].ToString());
                            if (_dtAg.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", _dtAg.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", 0));

                            DataTable _dtCS = GetCustomers(dt.Rows[i]["CUSTOMER"].ToString());
                            if (_dtCS.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", _dtCS.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 0));

                            DataTable _dtBL = GetBLS(dt.Rows[i]["BLNUMBER"].ToString());
                            if (_dtBL.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", _dtBL.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", 0));
                            DataTable _dtVslVoy = GetVslVoy(dt.Rows[i]["VESSELVOYAGE"].ToString());
                            if (_dtVslVoy.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", _dtVslVoy.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", dt.Rows[i]["STATUSCODE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", System.DateTime.Now));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", UserID));

                            Cmd.ExecuteNonQuery();

                            Cmd.CommandText = "Update NVO_Containers set StatusCode=@StatusCode,CurrentPortID=@CurrentPortID,LastMoveMentID=@LastMoveMentID,UserID=@UserID,DtModified=@DtModified,VesVoyID=@VesVoyID,ModeOfTransportID=@ModeOfTransportID,DepotID=@DepotID,CustomerID=@CustomerID,AgencyID=@AgencyID where ID=@ID";
                         
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", _dtCtrNo.Rows[0]["ID"].ToString()));
                       
                            if (_dtNextLoc.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", _dtNextLoc.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", 0));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LastMoveMentID", NewTxnsID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));

                             result = Cmd.ExecuteNonQuery();

                            if (dt.Rows[i]["STATUSCODE"].ToString() == "OF")
                            {
                                Cmd.CommandText = "Update NVO_Containers set StatusID=@StatusID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 32));
                            }
                            if (dt.Rows[i]["STATUSCODE"].ToString() == "OH")
                            {
                                Cmd.CommandText = "Update NVO_Containers set StatusID=@StatusID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 31));
                            }
                           
                            result = Cmd.ExecuteNonQuery();
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

        public DataTable GetCntrType(string Name)
        {
            string _Query = "select * from NVO_tblCntrTypes where Size like '" + Name + "'";
            return GetViewData(_Query, "");
        }

        public DataTable GetISOCodes(string Name)
        {
            string _Query = "select * from NVO_tblCntrTypes where ISOCode like '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetGradeValues(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =12 and GeneralName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetLeaseTerm(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =13 and GeneralName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCustomers(string Name)
        {
            string _Query = "select * from NVO_CustomerMaster where  CustomerName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCustomersWithBranch(string Name)
        {
            string _Query = "select NVO_CusBranchLocation.CId as ID,upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id WHERE upper(CustomerName +'-' + Branch) like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCntrStatus(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =14 and GeneralName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCntrNo(string Name)
        {
            string _Query = "select * from NVO_Containers where  CntrNo like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetPorts(string Name)
        {
            string _Query = "select * from NVO_PortMaster where  PortName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetTransitmode(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =31 and GeneralName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }

        public DataTable GetDepots(string Name)
        {
            string _Query = "select * from NVO_DepotMaster where  DepName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetAgency(string Name)
        {
            string _Query = "select * from NVO_AgencyMaster where  AgencyName like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetBLS(string Name)
        {
            string _Query = "select * from NVO_Booking where BookingNo like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetVslVoy(string Name)
        {
            string _Query = "Select V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as VesVoy from NVO_Voyage V WHERE (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID)  like  '" + Name + "'";
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

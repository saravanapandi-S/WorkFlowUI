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
    public class ContainerPickupManager
    {

        #region Constructor Method
        public ContainerPickupManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion


        public List<MyCntrPickup>BkgPickupContainers(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetPickupCntrTypes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickup
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    TypeID = dt.Rows[i]["TypeID"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    AgentName = dt.Rows[i]["AgencyName"].ToString(),
                    CurrentPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    CntrDepo = dt.Rows[i]["CntrDepo"].ToString(),
                    DepotID  = dt.Rows[i]["DepotID"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    IsTrue = "0"
                }) ;
            }
            return ViewList;
        }

        public DataTable GetPickupCntrTypes(MyCntrPickup Data)
        {
            string vrs = Data.LocationID;
            string _Query = " select NVO_Containers.ID,CntrNo,(Select top(1) Size from NVO_tblCntrTypes where ID = TypeID) as Size,TypeID, " +
                            " (select PortName from NVO_PortMaster where Id = CurrentPortID) as Location,CurrentPortID, " +
                             " (select top(1) AgencyName from NVO_AgencyMaster where Id = AgencyID) as AgencyName ," +
                            " (select top(1) DepName from NVO_DepotMaster where Id = DepotID) as CntrDepo,StatusCode,* from NVO_Containers " +
                            " inner join NVO_PortMaster on NVO_PortMaster.ID=NVO_Containers.CurrentPortID " +
                            " where NVO_Containers.StatusCode in ('AV','OH') and GeoLocID= " + Data.LocationID + " and TypeId in (" + Data.CntrTypes + ")";
            // ----geolocation table----//
            //string _Query = " select NVO_Containers.ID,CntrNo,(Select top(1) Size from NVO_tblCntrTypes where ID = TypeID) as Size,TypeID, " +
            //                " (select GeoLocation from NVO_GeoLocations where Id = CurrentPortID) as Location,CurrentPortID, " +
            //                 " (select top(1) AgencyName from NVO_AgencyMaster where Id = AgencyID) as AgencyName ," +
            //                " (select top(1) DepName from NVO_DepotMaster where Id = DepotID) as CntrDepo,StatusCode,* from NVO_Containers " +

            //                " where NVO_Containers.StatusCode in ('AV','OH') and NVO_Containers.CurrentPortID= " + Data.LocationID + " and TypeId in (" + Data.CntrTypes + ")";
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickup> BkgPickupContainersSearch(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetPickupCntrTypesSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickup
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    TypeID = dt.Rows[i]["TypeID"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    AgentName = dt.Rows[i]["AgencyName"].ToString(),
                    CurrentPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    CntrDepo = dt.Rows[i]["CntrDepo"].ToString(),
                    DepotID = dt.Rows[i]["DepotID"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    IsTrue = "0"
                });
            }
            return ViewList;
        }

        public DataTable GetPickupCntrTypesSearch(MyCntrPickup Data)
        {
            string strWhere = "";
            string CntrvSerach = "";
            if (Data.CntrNo != "")
            {
                string[] CntrNov = Data.CntrNo.Split(new Char[] { ',' });
                for (int i = 0; i < CntrNov.Length; i++)
                    CntrvSerach += " CntrNo like  '" + CntrNov[i] + "%' or";

                int RowsID = CntrvSerach.Length;
                CntrvSerach = CntrvSerach.Remove(RowsID - 2);
            }

            string _Query = " select NVO_Containers.ID,CntrNo,(Select top(1) Size from NVO_tblCntrTypes where ID = TypeID) as Size,TypeID, " +
                        " (select PortName from NVO_PortMaster where Id = CurrentPortID) as Location,CurrentPortID, " +
                           " (select top(1) AgencyName from NVO_AgencyMaster where Id = AgencyID) as AgencyName ," +
                        " (select top(1) DepName from NVO_DepotMaster where Id = DepotID) as CntrDepo,StatusCode,* from NVO_Containers  inner join NVO_PortMaster on NVO_PortMaster.ID = NVO_Containers.CurrentPortID ";

            strWhere += _Query + " where NVO_Containers.StatusCode in ('AV','OH') and GeoLocID= " + Data.LocationID + "";

            if (Data.TypeID != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " and TypeID= " + Data.TypeID;

                else
                    strWhere += " and TypeID= " + Data.TypeID;
            }
            else
            {
                strWhere += " and TypeId in (" + Data.CntrTypes + ") ";
            }
            if (CntrvSerach != "")
                if (strWhere == "")
                    strWhere += _Query + " and " + CntrvSerach;
                else
                    strWhere += " and " + CntrvSerach;

            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere, "");
        }
        public List<MyCntrPickup> BkgCROReleaseOrderNo(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetBkgCROReleaseOrderNo(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickup
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CROReleaseOrder = dt.Rows[i]["ReleaseOrderNo"].ToString()
                   
                });
            }
            return ViewList;
        }

        public DataTable GetBkgCROReleaseOrderNo(MyCntrPickup Data)
        {
            string _Query = " select Id,ReleaseOrderNo from NVO_CROMaster where BkgId = " + Data.BkgID;
            return GetViewData(_Query, "");
        }
        public List<MyCntrPickup> BookingCntrTypesValues(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetBookingCntrTypes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickup
                {
                    Size = dt.Rows[i]["Size"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    TypeID = dt.Rows[i]["CntrTypes"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetBookingCntrTypes(MyCntrPickup Data)
        {
            string _Query = " select(select top(1) size from NVO_tblCntrTypes where Id = CntrTypes) as Size, Qty,CntrTypes from NVO_BookingCntrTypes where BKgID = " + Data.BkgID;
            return GetViewData(_Query, "");
        }


        public List<MyCntrPickup> BookingDtlsValues(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetBookingdtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickup
                {
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    CustomerID = dt.Rows[i]["BkgPartyID"].ToString(),
                    VesVoyID = dt.Rows[i]["VesVoyID"].ToString(),
                    POOID = dt.Rows[i]["POOID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetBookingdtls(MyCntrPickup Data)
        {
            string _Query = " select * from NVO_Booking where ID = " + Data.BkgID;
            return GetViewData(_Query, "");
        }



        public List<MyCntrPickup> InsertCntrPickup(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_BOLCntrPickup where BkgId=@BkgId and CntrID=@CntrID and VoyageID=@VoyageID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BOLCntrPickup(CntrNo,CntrID,CntrType,BkgId,LocationID,Location,AgentID,AgentName,CurrentDepotID,CurrentDepot,Status,VoyageID,PickupDate) " +
                                     " values (@CntrNo,@CntrID,@CntrType,@BkgId,@LocationID,@Location,@AgentID,@AgentName,@CurrentDepotID,@CurrentDepot,@Status,@VoyageID,@PickupDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BOLCntrPickup SET CntrNo=@CntrNo,CntrID=@CntrID,CntrType=@CntrType,BkgId=@BkgId,LocationID=@LocationID,Location=@Location,AgentID=@AgentID,"+
                                     " AgentName=@AgentName,CurrentDepotID=@CurrentDepotID,CurrentDepot=@CurrentDepot,Status=@Status,VoyageID=@VoyageID,PickupDate=@PickupDate  where BkgId=@BkgId and CntrID=@CntrID and VoyageID=@VoyageID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentName", Data.AgentName));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PickupDate", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDepotID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDepot", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Location", CharSplit[7]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                                          " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";      
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "MS"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            //Cmd.CommandText = "select ID from NVO_ContainerTxns where ContainerID=" + CharSplit[0] + " and VesVoyID=" + Data.VoyageID + " and StatusCode='" + CharSplit[5] + "'";
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "MS"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID",Data.ID));
                      

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCntrPortIN(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FL"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FL"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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

        public List<MyCntrPickup> InsertCntrRoadToPort(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FI"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.ModeOfTransportID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FI"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCntrRailToPort(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FC"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FC"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCntrDepaturePort(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FB"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FB"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    Cmd.CommandText = " Update NVO_BLRelease set SOBDate=@SOBDate where BLID =" + Data.BLID;
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SOBDate", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                    r2 = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickupdtls> ExtPickcntrBooking(MyCntrPickupdtls Data)
        {
            List<MyCntrPickupdtls> ViewList = new List<MyCntrPickupdtls>();
            DataTable dt = GetExtPickCntrBookingdtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickupdtls
                {
                    ID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    //MSDate = dt.Rows[i]["MSDate"].ToString(),
                    //ERDate = dt.Rows[i]["ERDate"].ToString(),
                    //EODate = dt.Rows[i]["EODate"].ToString(),
                    //GIDate = dt.Rows[i]["GIDate"].ToString(),
                    //VDDate = dt.Rows[i]["VDDate"].ToString(),
                    //TADate = dt.Rows[i]["TADate"].ToString(),
                    //TDDate = dt.Rows[i]["TDDate"].ToString(),
                    //VADate = dt.Rows[i]["VADate"].ToString(),
                    //GODate = dt.Rows[i]["GODate"].ToString(),
                    //IRDate = dt.Rows[i]["IRDate"].ToString(),
                    //IODate = dt.Rows[i]["IODate"].ToString(),
                    //LIDate = dt.Rows[i]["LIDate"].ToString(),
                    //LODate = dt.Rows[i]["LODate"].ToString(),

                    MSDate = dt.Rows[i]["MSDate"].ToString(),
                    MSDateF = dt.Rows[i]["MSDateF"].ToString(),
                    FCDate = dt.Rows[i]["FCDate"].ToString(),
                    ExpFIDate = dt.Rows[i]["ExpFIDate"].ToString(),
                    FLDate = dt.Rows[i]["FLDate"].ToString(),
                    FBDate = dt.Rows[i]["FBDate"].ToString(),
                    TZDate = dt.Rows[i]["TZDate"].ToString(),
                    TZFBDate = dt.Rows[i]["TZFBDate"].ToString(),
                    FVDate = dt.Rows[i]["FVDate"].ToString(),
                    ImpFIDate= dt.Rows[i]["ImpFIDate"].ToString(),
                    FVICDDate= dt.Rows[i]["FVICDDate"].ToString(),
                    FUDate = dt.Rows[i]["FUDate"].ToString(),
                    MADate= dt.Rows[i]["MADate"].ToString(),
                    MRDate = dt.Rows[i]["MRDate"].ToString(),
                    FLDateF = dt.Rows[i]["FLDateF"].ToString(),
                    PLDate = dt.Rows[i]["PLDate"].ToString(),
                    FLICDDate = dt.Rows[i]["FLICDDate"].ToString(),
                    CurrentDepotID = dt.Rows[i]["CurrentDepotID"].ToString(),
                    LocationID = dt.Rows[i]["LocationID"].ToString(),
                    IsTrue = "0"

                });
            }
            return ViewList;
        }

        public DataTable GetExtPickCntrBookingdtls(MyCntrPickupdtls Data)
        {
            //08/March/2022 Removed Location Values
            //LocationID
            string _Query = " select distinct NVO_Containers.ID as CntrID,0 as LocationID,CntrNo,(select top(1) size from NVO_tblCntrTypes where Id = TypeID) as Size,NVO_ContainerTxns.DepotId as CurrentDepotID,  " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MS' order by DtMovement desc) as MSDate,  " +
                             " (select top(1) convert(varchar, DtMovement, 101) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MS' order by DtMovement desc) as MSDateF,  " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FC' order by DtMovement desc) as FCDate,   " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FI'  order by DtMovement desc) as ExpFIDate, " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FL'  order by DtMovement desc) as FLDate,   " +
                              " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'PL'  order by DtMovement desc) as PLDate,   " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FB'  order by DtMovement desc) as FBDate,  " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'TZ'  order by DtMovement desc) as TZDate,   " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'TZFB' order by DtMovement desc) as TZFBDate, " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FV'  order by DtMovement desc) as FVDate,  " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FI'  order by DtMovement desc) as ImpFIDate, " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FVICD'  order by DtMovement desc) as FVICDDate,  " +
                              " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FLICD'  order by DtMovement desc) as FLICDDate,  " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FU'  order by DtMovement desc) as FUDate, " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MA' order by DtMovement desc) as MADate,  " +
                             " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MR' order by DtMovement desc) as MRDate, " +
                             " (select top(1) convert(varchar, DtMovement, 101) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FL'  order by DtMovement desc) as FLDateF  " +
                             " from NVO_ContainerTxns  Inner join NVO_Containers on NVO_Containers.Id = NVO_ContainerTxns.ContainerID where BLNumber = " + Data.BkgID;

            return GetViewData(_Query, "");
        }


        public List<MyCntrPickup> DeleteCntrPickup(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array = Data.Items.Split(new[] { "Delete:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = "delete from NVO_BOLCntrPickup where BkgId=@BkgID and CntrID=@CntrID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        Cmd.CommandText = "Delete from  NVO_ContainerTxns where ContainerID=@CntrID and VesVoyID=@VesVoyID and StatusCode= 'MS'";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        Cmd.CommandText = "select  top(1) * from NVO_ContainerTxns where ContainerID=@CntrID order by NVO_ContainerTxns.ID Desc";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        DbDataAdapter adapter = _dbFactory.GetAdapter();
                        adapter.SelectCommand = Cmd;
                        DataTable DT = new DataTable();
                        adapter.Fill(DT);
                        Cmd.Parameters.Clear();


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", DT.Rows[0]["ContainerID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", DT.Rows[0]["LocationID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "AV"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", DT.Rows[0]["DepotID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", DT.Rows[0]["AgencyID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", DT.Rows[0]["ID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();




                    }

                


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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



        public List<MyCntrPickup> InsertCMTransitFI(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                                          " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FI"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FI"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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

        public List<MyCntrPickup> InsertCMTransitFV(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                                          " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FV"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FV"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCMPortOutFU(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                                          " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FU"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FU"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCMDepoInMA(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                                          " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "MA"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "MA"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCMDischargeFV(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                        " BEGIN " +
                        " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                        " END  " +
                        " ELSE " +
                        " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                        " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FV"));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 93));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 1));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));



                        //int result = Cmd.ExecuteNonQuery();
                        //Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCntrLastMovment(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                        " BEGIN " +
                        " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                        " END  " +
                        " ELSE " +
                        " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                        " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.TransitMode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                       
                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID,ModeOfTransportID=@ModeOfTransportID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", Data.TransitMode));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCntrLastMovmentMADL(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                        " BEGIN " +
                        " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                        " END  " +
                        " ELSE " +
                        " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                        " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    string[] ArrayDL = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayDL.Length; i++)
                    {
                        var CharSplit = ArrayDL[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                        " BEGIN " +
                        " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                        " END  " +
                        " ELSE " +
                        " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                        " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode","DL"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "DL"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> DtImpLastMovment(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetDtMovementLastdtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickup
                {
                    DtMovement = dt.Rows[i]["DtMovement"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetDtMovementLastdtls(MyCntrPickup Data)
        {
            //string _Query = "select top(1) convert(varchar,DtMovement, 101) as DtMovement  from NVO_ContainerTxns where ContainerID in (" + Data.CntrID + ") and VesVoyID= " + Data.VesVoyID + " and BLNumber=" + Data.BkgID + " order by DtMovement desc";
            //return GetViewData(_Query, "");

            string _Query = "select top(1) convert(varchar,DtMovement, 101) as DtMovement  from NVO_ContainerTxns where ContainerID in (" + Data.CntrID + ") and  BLNumber=" + Data.BkgID + " order by DtMovement desc";
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickup> InsertFLICDMovement(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FLICD"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FC"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertCntrPLMovement(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "PL"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "FC"));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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



        public List<MyCntrPickup> InsertFVCFSMovement(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID",Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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


        public List<MyCntrPickup> InsertDVMovement(MyCntrPickup Data)
        {
            List<MyCntrPickup> List = new List<MyCntrPickup>();
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


                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');


                        Cmd.CommandText = " IF((select count(*) from NVO_ContainerTxns where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                         " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber) " +
                         " END  " +
                         " ELSE " +
                         " UPDATE NVO_ContainerTxns SET ContainerID=@ContainerID,LocationID=@LocationID,StatusCode=@StatusCode,DtMovement=@DtMovement,VesVoyID=@VesVoyID,UserID=@UserID,ModeOfTransportID=@ModeOfTransportID,NextPortID=@NextPortID,DepotID=@DepotID," +
                         " CustomerID=@CustomerID,AgencyID=@AgencyID,BLNumber=@BLNumber where ContainerID=@ContainerID and VesVoyID=@VesVoyID and StatusCode=@StatusCode and BLNumber=@BLNumber";

                        //Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber) " +
                        //                  " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber)";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", DateTime.Parse(Data.PickupDate).ToString("yyyy-MM-dd h:mm tt")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BkgID));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        if (Data.ID == 0)
                        {
                            Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }


                        Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID where ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.LocationID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.StatusCode));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VoyageID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    List.Add(new MyCntrPickup
                    {
                        BkgID = Data.BkgID,

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
    }
}

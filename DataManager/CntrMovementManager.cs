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
    public class CntrMovementManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CntrMovementManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyCntrMoveMent> BindCntrMovementStatusCode(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable dt = GetMovementStatusCode(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StatusCode = dt.Rows[i]["StatusDescription"].ToString()
                });
            }
            return ListView;
        }

        public DataTable GetMovementStatusCode(MyCntrMoveMent Data)
        {
            string _Query = "select ID,StatusDescription from NVO_ContainerStatusCodes order by rowno ";
            return GetViewData(_Query, "");
        }


        public List<MyCntrMoveMent> BindStorageLocation(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable dt = GetStorageLocation(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StorageCode = dt.Rows[i]["StorageCode"].ToString()
                });
            }
            return ListView;
        }




        public DataTable GetStorageLocation(MyCntrMoveMent Data)
        {
            string _Query = "select ID,StorageCode from NVO_StorageLocationMaster where OffIceId=" + Data.OfficeLocation;
            return GetViewData(_Query, "");
        }

        public List<MyCntrMoveMent> BindBookingNo(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable dt = GetBookingNo(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString()
                });
            }
            return ListView;
        }

        public DataTable GetBookingNo(MyCntrMoveMent Data)
        {
            string _Query = "select ID, BookingNo from NVO_Booking where intStatus= 2 and OfficeCode=" + Data.OfficeLocation;
            return GetViewData(_Query, "");
        }


        public List<MyCntrMoveMent> BindValidContainerNos(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();


            string[] CntrSplit = new string[] { "\n" };
            string[] CntrNos = Data.ContainerNos.Split(CntrSplit, StringSplitOptions.None);
            for (int i = 0; i < CntrNos.Length; i++)
            {

                DataTable _dt = GetCheckCntrNo(CntrNos[i].ToString(), Data.MovementTypeID, Data.CurrentLocationID);
                if (_dt.Rows.Count > 0)
                {
                    ListView.Add(new MyCntrMoveMent
                    {
                        ID = Int32.Parse(_dt.Rows[0]["ID"].ToString()),
                        CntrNo = _dt.Rows[0]["CntrNo"].ToString(),
                        StatusCode = _dt.Rows[0]["StatusCode"].ToString(),
                        DtMovement = _dt.Rows[0]["dtMovement"].ToString(),
                        Location = _dt.Rows[0]["Location"].ToString(),
                        Status = _dt.Rows[0]["Status"].ToString(),
                        StatuID = _dt.Rows[0]["StatuID"].ToString(),

                    });
                }
                else
                {
                    ListView.Add(new MyCntrMoveMent
                    {

                        CntrNo = CntrNos[i],
                        StatusCode = "",
                        DtMovement = "",
                        Location = "",
                        StatuID = "2",
                        Status = "No Container Failed",

                    });
                }

            }
            return ListView;
        }
        public DataTable GetCheckCntrNo(string CntrNos, string MovementID, string CurrLocationID)
        {
            //string _Query = " SELECT ID,StatusCode,CntrNo,ID,(select top(1) convert(varchar,DtMovement, 103) from NVO_ContainerTxns where ContainerID=NVO_Containers.ID) as dtMovement, " +
            //                " isnull((select top(1)(select top(1) StorageCode from NVO_StorageLocationMaster where Id = NVO_ContainerTxns.LocationID) " +
            //                " from NVO_ContainerTxns where ContainerID = NVO_Containers.ID), 'NA') as Location FROM NVO_Containers where CntrNo='" + CntrNos + "'";

            //string _Query = " Select top(1) NVO_Containers.ID,CntrNo,NVO_Containers.StatusCode,NVO_ContainerTxns.StatusCode,convert(varchar,NVO_ContainerTxns.DtMovement, 103)  as dtMovement, " +
            //                " case  when NVO_ContainerTxns.StatusCodeID in (select ToStatusID from NVO_ContainerStatusPossibleMoves where StatusCodeID = 5) then 'Completed' else 'Pending' end Status, " +
            //                " isnull((select top(1)(select top(1) StorageCode from NVO_StorageLocationMaster where Id = NVO_ContainerTxns.LocationID) from NVO_ContainerTxns where ContainerID = NVO_Containers.ID), 'NA') as Location " +
            //                " from NVO_ContainerTxns " +
            //                " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
            //                " where NVO_Containers.CntrNo='" + CntrNos + "'";

            String _Query = " select ID,CntrNo,NVO_Containers.StatusCode,StatusCodeID, " +
                            " (select top(1) convert(varchar, DtMovement, 103)  from NVO_ContainerTxns where ContainerID = NVO_Containers.ID " +
                            " and NVO_ContainerTxns.StatusCodeID = NVO_Containers.StatusCodeID) as DTMovement, " +
                            " case  when NVO_Containers.StatusCodeID in (select ToStatusID from NVO_ContainerStatusPossibleMoves where StatusCodeID = " + MovementID + " and CurrentOfficeLocID= " + CurrLocationID + ")  " +
                            " then 'Completed' else 'Pending' end Status, " +
                             " case  when NVO_Containers.StatusCodeID in (select ToStatusID from NVO_ContainerStatusPossibleMoves where StatusCodeID = " + MovementID + " and CurrentOfficeLocID= " + CurrLocationID + ")  " +
                            " then '1' else '0' end StatuID, " +
                            " isnull((select top(1)(select top(1) StorageCode from NVO_StorageLocationMaster where Id = NVO_ContainerTxns.LocationID) " +
                            " from NVO_ContainerTxns where ContainerID = NVO_Containers.ID), 'NA') as Location " +
                            " from NVO_Containers where NVO_Containers.CntrNo='" + CntrNos + "'";
            return GetViewData(_Query, "");
        }


        public List<MyCntrMoveMent> InsertContainerMovement(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListBLView = new List<MyCntrMoveMent>();
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
                    Cmd.CommandText = " select count(NVO_Containers.ID) from NVO_Containers inner join NVO_ContainerTxns on  NVO_ContainerTxns.ContainerID=NVO_Containers.ID where NVO_ContainerTxns.StatusCodeID=" + Data.MovementTypeID + " and BLNumber = " + Data.BookingID;
                    int MVQtyCount = Int32.Parse(Cmd.ExecuteScalar().ToString());



                    Cmd.CommandText = " select sum(Nos) from NVO_BookingCntrType where BKgID= " + Data.BookingID;
                    int QtyCount = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    if (QtyCount <= MVQtyCount)
                    {
                        ListBLView.Add(new MyCntrMoveMent
                        {
                            Message = "Container Movement already exist"

                        });
                        return ListBLView;
                    }
                    int CntrCount = 0;
                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            CntrCount++;
                        }
                    }

                    if (QtyCount <= MVQtyCount)
                    {
                        ListBLView.Add(new MyCntrMoveMent
                        {
                            Message = "Booking Qty & Container uploaded Qty not matched"

                        });
                        return ListBLView;
                    }


                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("MOV", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'MOV'  + '" + Data.SessionFinYear + "' +  right('0000000' + convert(varchar(8)," + AutoGen + "), 8)";
                        Data.RefFNo = Cmd.ExecuteScalar().ToString();
                    }

                    Cmd.CommandText = "select VoyageID  from NVO_Booking where Id =" + Data.BookingID;
                    Data.VesVoyID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    Cmd.CommandText = " IF((select count(*) from NVO_ContainerMovement where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ContainerMovement(RefFNo,OfficeID,MovementDate,MovementTypeID,CurrentStorageLocationID,NewStorageLocationID,BkgID,CurrentDate,UpdateStatus) " +
                                     " values (@RefFNo,@OfficeID,@MovementDate,@MovementTypeID,@CurrentStorageLocationID,@NewStorageLocationID,@BkgID,@CurrentDate,@UpdateStatus) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ContainerMovement SET RefFNo=@RefFNo,OfficeID=@OfficeID,MovementDate=@MovementDate,MovementTypeID=@MovementTypeID,CurrentStorageLocationID=@CurrentStorageLocationID,NewStorageLocationID=@NewStorageLocationID,BkgID=@BkgID,UpdateStatus=@UpdateStatus  where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RefFNo", Data.RefFNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeID", Data.OfficeLocation));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MovementDate", Data.MovementDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MovementTypeID", Data.MovementTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentStorageLocationID", Data.CurrentLocationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NewStorageLocationID", Data.NewStorageLocationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UpdateStatus", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BookingID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_ContainerMovement')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            if (CharSplit[4] != "2")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_ContainerMovementDtls where RefID=@RefID and CntrID=@CntrID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO  NVO_ContainerMovementDtls(RefID,CntrID,PreviousStatus,PreviousMovementDate,CurrenctLocation,UplodStatus) " +
                                             " values (@RefID,@CntrID,@PreviousStatus,@PreviousMovementDate,@CurrenctLocation,@UplodStatus) " +
                                             " END  " +
                                             " ELSE " +
                                             " UPDATE NVO_ContainerMovementDtls SET RefID=@RefID,CntrID=@CntrID,PreviousStatus=@PreviousStatus,PreviousMovementDate=@PreviousMovementDate,CurrenctLocation=@CurrenctLocation,UplodStatus=@UplodStatus where RefID=@RefID and CntrID=@CntrID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@RefID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PreviousStatus", CharSplit[1]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PreviousMovementDate", DateTime.ParseExact(CharSplit[2], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrenctLocation", CharSplit[3]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@UplodStatus", CharSplit[4]));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                if (CharSplit[4] == "1")
                                {
                                    Cmd.CommandText = " INSERT INTO  NVO_ContainerTxns(ContainerID,LocationID,StatusCode,DtMovement,VesVoyID,UserID,ModeOfTransportID,NextPortID,DepotID,CustomerID,AgencyID,BLNumber,StatusCodeID,OfficeLocationID,ReferenceID) " +
                                                " values (@ContainerID,@LocationID,@StatusCode,@DtMovement,@VesVoyID,@UserID,@ModeOfTransportID,@NextPortID,@DepotID,@CustomerID,@AgencyID,@BLNumber,@StatusCodeID,@OfficeLocationID,@ReferenceID)";
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CharSplit[0]));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.NewStorageLocationID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.MovementType));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", Data.MovementDate));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeOfTransportID", 0));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", Data.NewStorageLocationID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.NewStorageLocationID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BookingID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCodeID", Data.MovementTypeID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocationID", Data.OfficeLocation));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReferenceID", Data.ID));
                                    result = Cmd.ExecuteNonQuery();
                                    Cmd.Parameters.Clear();

                                    Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                                    var LastMovementID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                                    Cmd.CommandText = "UPDATE NVO_Containers SET CurrentPortID=@CurrentPortID,StatusCode=@StatusCode,VesVoyID=@VesVoyID,DepotID=@DepotID,AgencyID=@AgencyID,LastmovementID=@LastmovementID, " +
                                        " StatusCodeID=@StatusCodeID,CurrentOfficeLocID=@CurrentOfficeLocID,CurrentDtMovement=@CurrentDtMovement where ID=@ID";
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.NewStorageLocationID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", Data.MovementType));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.NewStorageLocationID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCodeID", Data.MovementTypeID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", LastMovementID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentOfficeLocID", Data.OfficeLocation));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDtMovement", Data.MovementDate));

                                    result = Cmd.ExecuteNonQuery();
                                    Cmd.Parameters.Clear();
                                }
                            }

                        }
                    }
                    trans.Commit();
                    ListBLView.Add(new MyCntrMoveMent
                    {
                        ID = Data.ID,
                        Message = "Record Saved sucessfully " + Data.RefFNo,
                        BLNumber = Data.BLNumber

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyCntrMoveMent { Message = ex.Message });
                    return ListBLView;
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



        public List<MyCntrMoveMent> ListContainerSearch(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable _dt = GetContainerMovSearch(Data);
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(_dt.Rows[i]["ID"].ToString()),
                    RefFNo = _dt.Rows[i]["RefFNo"].ToString(),
                    DtMovement = _dt.Rows[i]["MovDate"].ToString(),
                    StatusCode = _dt.Rows[i]["StatusCode"].ToString(),
                    UnitCount = _dt.Rows[i]["Unit"].ToString(),
                    UplodStatus = _dt.Rows[i]["UplodStatus"].ToString(),
                    Status = _dt.Rows[i]["Status"].ToString(),
                    StorageLocation = _dt.Rows[i]["StorageLocation"].ToString(),
                    TransationStatusV = _dt.Rows[i]["TransactionStatus"].ToString(),
                });

            }


            return ListView;
        }

        public DataTable GetContainerMovSearch(MyCntrMoveMent Data)
        {
            string strWhere = "";
            string _Query = " select distinct NVO_ContainerMovement.ID, RefFNo, convert(varchar, MovementDate, 103) as MovDate, " +
                            " (select top(1) StatusDescription from NVO_ContainerStatusCodes where ID = NVO_ContainerMovement.MovementTypeID) as StatusCode," +
                            " Case When NVO_ContainerMovement.UpdateStatus=1 then 'Update' when NVO_ContainerMovement.UpdateStatus=2 then 'Upload' else '' end as TransactionStatus, " +
                            " (select count(CntrID) from NVO_ContainerMovementDtls where RefID = NVO_ContainerMovement.ID) as Unit, " +
                            " (select top(1) StorageLoc  from NVO_StorageLocationMaster where ID=NVO_ContainerMovement.NewStorageLocationID) as StorageLocation," +
                            " ((select count(CntrID) from NVO_ContainerMovementDtls where RefID= NVO_ContainerMovement.ID) - (select sum(UplodStatus) from NVO_ContainerMovementDtls where RefID = NVO_ContainerMovement.ID)) as UplodStatus, " +
                            " case when ((select count(CntrID) from NVO_ContainerMovementDtls where RefID= NVO_ContainerMovement.ID) - (select sum(UplodStatus) from NVO_ContainerMovementDtls where RefID = NVO_ContainerMovement.ID))=0 then 'Completed' else 'Pending' end as Status " +
                            " from NVO_ContainerMovement  inner join NVO_ContainerMovementDtls on NVO_ContainerMovementDtls.RefID=NVO_ContainerMovement.ID";

            //if (Data.OfficeLocation != "0" && Data.OfficeLocation != null)
            //    if (strWhere == "")
            //        strWhere += _Query + " where SalesPersonID=" + Data.OfficeLocation;
            //    else
            //        strWhere += " and SalesPersonID=" + Data.OfficeLocation;


            if (Data.RefFNo != "" && Data.RefFNo != null)
                if (strWhere == "")
                    strWhere += _Query + " where RefFNo like '%" + Data.RefFNo + "%'";
                else
                    strWhere += " and RefFNo like '%" + Data.RefFNo + "%'";

            if (Data.ContainerID.ToString() != "" && Data.ContainerID.ToString() != null && Data.ContainerID.ToString() != "0" && Data.ContainerID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where CntrID=" + Data.ContainerID.ToString();
                else
                    strWhere += " and CntrID=" + Data.ContainerID.ToString();

            if (Data.OfficeLocation.ToString() != "" && Data.OfficeLocation.ToString() != null && Data.OfficeLocation.ToString() != "0" && Data.OfficeLocation.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where OfficeID =" + Data.OfficeLocation.ToString() + "";
                else
                    strWhere += " and OfficeID =" + Data.OfficeLocation.ToString() + "";


            if (Data.Date != "" && Data.Date != null)
                if (strWhere == "")
                    strWhere += _Query + " where MovementDate >= '" + DateTime.Parse(Data.Date.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and MovementDate >= '" + DateTime.Parse(Data.Date.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.Dateto != "" && Data.Dateto != null)
                if (strWhere == "")
                    strWhere += _Query + " where MovementDate <= '" + DateTime.Parse(Data.Dateto.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and MovementDate <= '" + DateTime.Parse(Data.Dateto.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.TransationStatus.ToString() != "" && Data.TransationStatus.ToString() != null && Data.TransationStatus.ToString() != "0" && Data.TransationStatus.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where UpdateStatus=" + Data.TransationStatus.ToString();
                else
                    strWhere += " and UpdateStatus=" + Data.TransationStatus.ToString();

            if (Data.Source.ToString() != "" && Data.Source.ToString() != null && Data.Source.ToString() != "0" && Data.Source.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where NewStorageLocationID=" + Data.Source.ToString();
                else
                    strWhere += " and NewStorageLocationID=" + Data.Source.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " Order By NVO_ContainerMovement.ID Desc ", "");
        }


        public List<MyCntrMoveMent> ExistingContainerList(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable _dt = ExsitngContainerMovList(Data);
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(_dt.Rows[0]["ID"].ToString()),
                    RefFNo = _dt.Rows[0]["RefFNo"].ToString(),
                    OfficeLocation = _dt.Rows[0]["OfficeID"].ToString(),
                    MovementDate = _dt.Rows[0]["MovementDatev"].ToString(),
                    MovementTypeID = _dt.Rows[0]["MovementTypeID"].ToString(),
                    CurrentLocationID = _dt.Rows[0]["CurrentStorageLocationID"].ToString(),
                    NewStorageLocationID = _dt.Rows[0]["NewStorageLocationID"].ToString(),
                    BookingID = _dt.Rows[0]["BkgID"].ToString(),
                    TransationStatus = Int32.Parse(_dt.Rows[0]["UpdateStatus"].ToString()),
                });

            }


            return ListView;
        }

        public DataTable ExsitngContainerMovList(MyCntrMoveMent Data)
        {
            string _Query = " select convert(varchar, MovementDate, 23) as MovementDatev, * from NVO_ContainerMovement where Id=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyCntrMoveMent> ExistingContainerListDtls(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable _dt = ExsitngContainerMovListDtls(Data);
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(_dt.Rows[i]["ID"].ToString()),
                    CntrNo = _dt.Rows[i]["CntrNo"].ToString(),
                    StatusCode = _dt.Rows[i]["PreviousStatus"].ToString(),
                    DtMovement = _dt.Rows[i]["PreviousMovementDate"].ToString(),
                    Location = _dt.Rows[i]["CurrenctLocation"].ToString(),
                    Status = _dt.Rows[i]["Status"].ToString()

                });

            }


            return ListView;
        }


        public DataTable ExsitngContainerMovListDtls(MyCntrMoveMent Data)
        {
            string _Query = " select ID,CntrID,(select top(1) CntrNo from NVO_Containers where NVO_Containers.ID = NVO_ContainerMovementDtls.CntrID) as CntrNo, " +
                            " PreviousStatus, PreviousMovementDate, CurrenctLocation, case  when UplodStatus= 1 then 'Completed' else 'Pending' end Status from NVO_ContainerMovementDtls where RefID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCntrMoveMent> SearchContainerList(MyCntrMoveMent Data)
        {
            List<MyCntrMoveMent> ListView = new List<MyCntrMoveMent>();
            DataTable _dt = SearchCntrList(Data);
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                ListView.Add(new MyCntrMoveMent
                {
                    ID = Int32.Parse(_dt.Rows[i]["ID"].ToString()),
                    CntrNo = _dt.Rows[i]["CntrNo"].ToString(),


                });

            }


            return ListView;
        }

        public DataTable SearchCntrList(MyCntrMoveMent Data)
        {
            string _Query = " SELECT CntrID as ID, (select top(1) CntrNo from NVO_Containers where ID =NVO_ContainerMovementDtls.CntrID) as CntrNo FROM NVO_ContainerMovementDtls";
            return GetViewData(_Query, "");
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
        #region get values
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
    }
}

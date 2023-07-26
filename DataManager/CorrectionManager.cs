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
    public class CorrectionManager
    {
        List<MYBOL> MyBOLList = new List<MYBOL>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CorrectionManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MYBOL> ListBLListAgentwise(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetListBLListAgentwise(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ViewList.Add(new MYBOL
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                });
            }
            return ViewList;
        }
        public DataTable GetListBLListAgentwise(MYBOL Data)
        {
            string _Query = "  SELECT ID,BLNumber,BkgID FROM NVO_BOL WHERE AgencyID  =" + Data.AgentId + " ";
            return GetViewData(_Query, "");
        }
        public List<MYBOL> ListBookingIDByBL(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetListBookingIDBYBL(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ViewList.Add(new MYBOL
                {

                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                });
            }
            return ViewList;
        }
        public DataTable GetListBookingIDBYBL(MYBOL Data)
        {
            string _Query = "  SELECT BkgID FROM NVO_BOL WHERE ID  =" + Data.BLID + " ";
            return GetViewData(_Query, "");
        }
        public List<MYCorrMemo> BOLPartyDetailsRecord(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetBOLShipperRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {
                    ShipperOldID = dt.Rows[i]["ShiperID"].ToString(),
                    ShipperOLdAddress = dt.Rows[i]["ShiperAddress"].ToString(),
                    ConsigneeOldID = dt.Rows[i]["ConsigID"].ToString(),
                    ConsigneeOldAddress = dt.Rows[i]["ConsigAddress"].ToString(),
                    NotifyOldID = dt.Rows[i]["NotifyID"].ToString(),
                    NotifyOldAddress = dt.Rows[i]["NotifyAddress"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBOLShipperRecord(MYCorrMemo Data)
        {
            string _Query = "select  (select top(1) PartID from NVO_BOLCustomerDetails where PartyTypeID = 1 and NVO_BOLCustomerDetails.BLID = NVO_BOL.ID)  as ShiperID, "+
             " (select top(1) PartyAddress from NVO_BOLCustomerDetails where PartyTypeID = 1 and NVO_BOLCustomerDetails.BLID = NVO_BOL.ID) as ShiperAddress, "+
            " (select top(1) PartID from NVO_BOLCustomerDetails where PartyTypeID = 2 and NVO_BOLCustomerDetails.BLID = NVO_BOL.ID) as ConsigID, "+
            " (select top(1) PartyAddress from NVO_BOLCustomerDetails where PartyTypeID = 2 and NVO_BOLCustomerDetails.BLID = NVO_BOL.ID) as ConsigAddress, "+
           " (select top(1) PartID from NVO_BOLCustomerDetails where PartyTypeID = 3 and NVO_BOLCustomerDetails.BLID = NVO_BOL.ID) as NotifyID, "+
           " (select top(1) PartyAddress from NVO_BOLCustomerDetails where PartyTypeID = 3 and NVO_BOLCustomerDetails.BLID = NVO_BOL.ID) as NotifyAddress from NVO_BOL where NVO_BOL.ID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BOLConsigneeRecord(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLConsigneeRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    BCID = Int32.Parse(dt.Rows[i]["BCID"].ToString()),
                    PartyTypeID = Int32.Parse(dt.Rows[i]["PartyTypeID"].ToString()),
                    PartyID = Int32.Parse(dt.Rows[i]["PartID"].ToString()),
                    Address = dt.Rows[i]["PartyAddress"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLConsigneeRecord(MYBOL Data)
        {
            string _Query = "select * from NVO_BOLCustomerDetails where  PartyTypeID=2 And BLID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYBOL> BOLNotifyRecord(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetBOLNotifyRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    BCID = Int32.Parse(dt.Rows[i]["BCID"].ToString()),
                    PartyTypeID = Int32.Parse(dt.Rows[i]["PartyTypeID"].ToString()),
                    PartyID = Int32.Parse(dt.Rows[i]["PartID"].ToString()),
                    Address = dt.Rows[i]["PartyAddress"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLNotifyRecord(MYBOL Data)
        {
            string _Query = "select * from NVO_BOLCustomerDetails where  PartyTypeID=3 And BLID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYCorrMemo> BOLCntrExistingValus(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetBOLCntrExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {
                    BCNID = Int32.Parse(dt.Rows[i]["BCNID"].ToString()),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    PakgType = dt.Rows[i]["PakgTypeName"].ToString(),
                    PakgTypeID = dt.Rows[i]["PakgType"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    NtWt = dt.Rows[i]["NtWt"].ToString(),
                    VGM = dt.Rows[i]["VGM"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLCntrExistingValus(MYCorrMemo Data)
        {
         

            string _Query = "  select distinct 0 as BCNID,NVO_Containers.CntrNo,NVO_Containers.Id as CntrID,TypeID,(select top(1) ISOCode  from NVO_tblCntrTypes where ID = TypeID) as ISOCode, " +
                            " (select top(1) Size  from NVO_tblCntrTypes where ID = TypeID) as Size, " +
                            " (select top(1) SealNo from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as SealNo, " +
                            " (select top(1) NoOfPkg from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as NoOfPkg,  " +
                            " (select top(1) PkgDescription from NVO_BOLCntrDetails  inner Join NVO_CargoPkgMaster on NVO_CargoPkgMaster.ID = NVO_BOLCntrDetails.PakgType where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as PakgTypeName, " +
                            " (select top(1) PakgType from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as PakgType, " +
                            " (select top(1) GrsWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as GrsWt," +
                            " (select top(1) NtWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as NtWt,  " +
                            " (select top(1) VGM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as VGM, " +
                            " (select top(1) CBM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BkgId = NVO_ContainerTxns.BLNumber and BLID=" + Data.BLID + " and NVO_ContainerTxns.ContainerID=NVO_BOLCntrDetails.CntrID) as CBM " +
                            " from NVO_ContainerTxns " +
                            " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
                            " where BLNumber = " + Data.BkgID;

            return GetViewData(_Query, "");
        }


        public List<MYCorrMemo> PartyByAddress(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetPartyByAddress(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {
                    Address = dt.Rows[i]["Address"].ToString(),


                });
            }
            return ViewList;
        }

        public DataTable GetPartyByAddress(MYCorrMemo Data)
        {
           

            string _Query = "  select * FROM NVO_CusBranchLocation  where CID = " + Data.PartyID;

            return GetViewData(_Query, "");
        }

        public List<MYCorrMemo> CorrectionMemoInsert(MYCorrMemo Data)
        {
            List<MYCorrMemo> MYCorrMemo = new List<MYCorrMemo>();
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

                    Cmd.CommandText = " IF((select count(*) from NVO_CorrectionMemo where ID=@ID and BLID=@BLID)<=0) " +
                                  " BEGIN " +
                                  " INSERT INTO  NVO_CorrectionMemo(BLNumber,BLID,CorrectionNo,Status,AgencyID,CreatedBy,CreatedOn,ShipperOldID,ShipperOLdAddress,ShipperNewID,ShipperNewAddress,ConsigneeOldID,ConsigneeOldAddress,ConsigneeNewID,ConsigneeNewAddress,NotifyOldID,NotifyOldAddress,NotifyNewID,NotifNewAddress,OldMarksNo,NewMarksNo,OldCargoDesc,NewCargoDesc,CurrentDate,BkgID) " +
                                  " values (@BLNumber,@BLID,@CorrectionNo,@Status,@AgencyID,@CreatedBy,@CreatedOn,@ShipperOldID,@ShipperOLdAddress,@ShipperNewID,@ShipperNewAddress,@ConsigneeOldID,@ConsigneeOldAddress,@ConsigneeNewID,@ConsigneeNewAddress,@NotifyOldID,@NotifyOldAddress,@NotifyNewID,@NotifNewAddress,@OldMarksNo,@NewMarksNo,@OldCargoDesc,@NewCargoDesc,@CurrentDate,@BkgID) " +
                                  " END  " +
                                  " ELSE " +
                                  " UPDATE NVO_CorrectionMemo SET BLID=@BLID,BLNumber=@BLNumber,CorrectionNo=@CorrectionNo,Status=@Status,CurrentDate=@CurrentDate,AgencyID=@AgencyID,CreatedBy=@CreatedBy,CreatedOn=@CreatedOn,ShipperOldID=@ShipperOldID,ShipperOLdAddress=@ShipperOLdAddress,ShipperNewID=@ShipperNewID,ShipperNewAddress=@ShipperNewAddress,ConsigneeOldID=@ConsigneeOldID,ConsigneeOldAddress=@ConsigneeOldAddress,ConsigneeNewID=@ConsigneeNewID,ConsigneeNewAddress=@ConsigneeNewAddress,NotifyOldID=@NotifyOldID,NotifyOldAddress=@NotifyOldAddress,NotifyNewID=@NotifyNewID,NotifNewAddress=@NotifNewAddress,OldMarksNo=@OldMarksNo,NewMarksNo=@NewMarksNo,OldCargoDesc=@OldCargoDesc,NewCargoDesc=@NewCargoDesc,BkgID=@BkgID where ID=@ID and BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CorrectionNo", Data.CorrectionNo + "-1"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperOldID", Data.ShipperOldID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperOLdAddress", Data.ShipperOLdAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperNewAddress", Data.ShipperNewAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperNewID", Data.ShipperNewID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeOldID", Data.ConsigneeOldID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeOldAddress", Data.ConsigneeOldAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeNewID", Data.ConsigneeNewID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeNewAddress", Data.ConsigneeNewAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyOldID", Data.NotifyOldID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyOldAddress", Data.NotifyOldAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyNewID", Data.NotifyNewID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifNewAddress", Data.NotifNewAddress));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OldMarksNo", Data.OldMarksNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NewMarksNo", Data.NewMarksNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OldCargoDesc", Data.OldCargoDesc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NewCargoDesc", Data.NewCargoDesc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_CorrectionMemo')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }


                    string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_CorrectionMemoCntrDtls where CorrrectionID=@CorrrectionID and BLID=@BLID AND CntrID=@CntrID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CorrectionMemoCntrDtls(BLID,CorrrectionID,CntrID,SealNo,NoOfPkg,PakgType,PakgTypeName,GrsWt,NtWt,VGM,CBM) " +
                                     " values (@BLID,@CorrrectionID,@CntrID,@SealNo,@NoOfPkg,@PakgType,@PakgTypeName,@GrsWt,@NtWt,@VGM,@CBM) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CorrectionMemoCntrDtls SET  BLID=@BLID,CorrrectionID=@CorrrectionID,CntrID=@CntrID,SealNo=@SealNo,NoOfPkg=@NoOfPkg,PakgType=@PakgType,PakgTypeName=@PakgTypeName,GrsWt=@GrsWt,NtWt=@NtWt," +
                                     " VGM=@VGM,CBM=@CBM where CorrrectionID=@CorrrectionID and BLID=@BLID AND CntrID=@CntrID";
                   
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CorrrectionID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkg", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgType", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgTypeName", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWt", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", CharSplit[8]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    MYCorrMemo.Add(new MYCorrMemo { ID = Data.ID });
                    return MYCorrMemo;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MYCorrMemo;
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

        public List<MYCorrMemo> CorrectionMemoViewValues(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetCorrectionMemoViewValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectionNo"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    CurrentDatev = dt.Rows[i]["CurrentDate"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetCorrectionMemoViewValues(MYCorrMemo Data)
        {
            string strWhere = "";
            string _Query = " select ID,BLNumber,CorrectionNo,convert(varchar,CurrentDate, 103) as CurrentDate,case when Status= 1 then 'PENDING' when Status= 2 then 'APPROVED' when Status= 3 then 'CANCELLED' end as Status,BLID " +
                            " from NVO_CorrectionMemo";

            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where BLNumber like '%" + Data.BLNumber + "%'";
                else
                    strWhere += " and BLNumber like '%" + Data.BLNumber + "%'";

            if (Data.CorrectionNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where CorrectionNo like '%" + Data.CorrectionNo + "%'";
                else
                    strWhere += " and CorrectionNo like '%" + Data.CorrectionNo + "%'";

            if (Data.AgentId != "" && Data.AgentId != "0" && Data.AgentId != "2" && Data.AgentId != "undefined" && Data.AgentId != null)

                if (strWhere == "")
                    strWhere += _Query + " where AgencyID = " + Data.AgentId;
                else
                    strWhere += " and AgencyID = " + Data.AgentId;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<ChargeCorrectorInsert> CorrectionMemoCountRecord(ChargeCorrectorInsert Data)
        {
            List<ChargeCorrectorInsert> ViewList = new List<ChargeCorrectorInsert>();
            DataTable dt = GetCorrectionMemoCountRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new ChargeCorrectorInsert
                {

                    Draft = dt.Rows[i]["Draft"].ToString(),
                    Cancelled = dt.Rows[i]["Cancel"].ToString(),
                    Confirm = dt.Rows[i]["Confirm"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetCorrectionMemoCountRecord(ChargeCorrectorInsert Data)
        {
            if (Data.AgencyID.ToString() == "2")
            {
                string _Query = " select  " +
                            " (select count(ID) from NVO_CorrectionMemo where Status = 1 ) as Draft, " +
                            " (select count(ID) from NVO_CorrectionMemo where Status = 2 ) as Confirm, " +
                            " (select count(ID) from NVO_CorrectionMemo where Status = 3 ) as Cancel";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = " select  " +
                          " (select count(ID) from NVO_CorrectionMemo where Status = 1 and AgencyID=" + Data.AgencyID + ") as Draft, " +
                          " (select count(ID)  from NVO_CorrectionMemo where Status = 2 and AgencyID=" + Data.AgencyID + ") as Confirm, " +
                          " (select count(ID) from NVO_CorrectionMemo where Status = 3 and AgencyID=" + Data.AgencyID + ") as Cancel";
                return GetViewData(_Query, "");
            }
        }
        public List<MYCorrMemo> CorrectionMemoExistingValues(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetCorrectionMemoExistingValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CorrectionNo = dt.Rows[i]["CorrectionNo"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    CurrentDatev = dt.Rows[i]["CurrentDate"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    ShipperOldID = dt.Rows[i]["ShipperOldID"].ToString(),
                    ShipperOLdAddress = dt.Rows[i]["ShipperOLdAddress"].ToString(),
                    ShipperNewID = dt.Rows[i]["ShipperNewID"].ToString(),
                    ShipperNewAddress = dt.Rows[i]["ShipperNewAddress"].ToString(),
                    ConsigneeNewID = dt.Rows[i]["ConsigneeNewID"].ToString(),
                    ConsigneeOldID = dt.Rows[i]["ConsigneeOldID"].ToString(),
                    ConsigneeOldAddress = dt.Rows[i]["ConsigneeOldAddress"].ToString(),
                    ConsigneeNewAddress = dt.Rows[i]["ConsigneeNewAddress"].ToString(),
                    NotifyNewID = dt.Rows[i]["NotifyNewID"].ToString(),
                    NotifyOldID = dt.Rows[i]["NotifyOldID"].ToString(),
                    NotifNewAddress = dt.Rows[i]["NotifNewAddress"].ToString(),
                    NotifyOldAddress = dt.Rows[i]["NotifyOldAddress"].ToString(),
                    OldCargoDesc = dt.Rows[i]["OldCargoDesc"].ToString(),
                    NewCargoDesc = dt.Rows[i]["NewCargoDesc"].ToString(),
                    NewMarksNo = dt.Rows[i]["NewMarksNo"].ToString(),
                    OldMarksNo = dt.Rows[i]["OldMarksNo"].ToString(),
                });
            }
            return ViewList;
        }
        public DataTable GetCorrectionMemoExistingValues(MYCorrMemo Data)
        {
           
                string _Query = " select * from NVO_CorrectionMemo Where ID =" +Data.ID;
                return GetViewData(_Query, "");
            
        }

        public List<MYCorrMemo> CorrectionMemoCntrExistingValues(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetCorrectionMemoCntrExistingValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {
                  
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    PakgType = dt.Rows[i]["PakgTypeName"].ToString(),
                    PakgTypeID = dt.Rows[i]["PakgType"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    NtWt = dt.Rows[i]["NtWt"].ToString(),
                    VGM = dt.Rows[i]["VGM"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetCorrectionMemoCntrExistingValues(MYCorrMemo Data)
        {


            string _Query = "  select (select top 1 CntrNo from NVO_Containers WHERE ID =CntrID) As CntrNo ,* from NVO_CorrectionMemoCntrDtls  where CorrrectionID = " + Data.ID;

            return GetViewData(_Query, "");
        }
        public List<MYCorrMemo> BOLReleaseExistingViewRecord(MYCorrMemo Data)
        {
            List<MYCorrMemo> ViewList = new List<MYCorrMemo>();
            DataTable dt = GetBOLReleaseExistingViewRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYCorrMemo
                {

                    BLID = dt.Rows[i]["BLID"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperOLdAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    ShipperContactNo = dt.Rows[i]["shiperContactNo"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeOldAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    ConsigneeContactNo = dt.Rows[i]["ConsigneeContactNo"].ToString(),
                    NotifyOldAddress = dt.Rows[i]["Notify1Address"].ToString(),
                    Notify = dt.Rows[i]["Notify1"].ToString(),
                    NotifyContactNo = dt.Rows[i]["Notify1ContactNo"].ToString(),
                    MarkNo =dt.Rows[i]["Marks"].ToString(),
                    OldCargoDesc = dt.Rows[i]["Description"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetBOLReleaseExistingViewRecord(MYCorrMemo Data)
        {


            string _Query = "  select * from NVO_BLRelease where BLID= " + Data.BLID;

            return GetViewData(_Query, "");
        }


        public List<MYCorrMemo> CorrectionMemoupdate(MYCorrMemo Data)
        {
            List<MYCorrMemo> MYCorrMemo = new List<MYCorrMemo>();
            int result = 0;
            DbConnection con = null;
            DbTransaction trans;
            con = _dbFactory.GetConnection();
            con.Open();
            trans = _dbFactory.GetTransaction(con);
            DbCommand Cmd = _dbFactory.GetCommand();
            Cmd.Connection = con;
            Cmd.Transaction = trans;
            DataTable _dtc = GetCorrectionMemoRecord(Data);
            DataTable _dtd = GetCorrectionCntrID(Data);
            if (_dtc.Rows.Count > 0)
            {
                
                try
                {


                    Cmd.CommandText = " UPDATE NVO_CorrectionMemo SET Status=@Status where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID",Data.ID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    Cmd.CommandText = " UPDATE NVO_Booking SET ShipperID=@ShipperID,Shipper=@Shipper where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", _dtc.Rows[0]["ShipperNewID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", _dtc.Rows[0]["Shipper"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", _dtc.Rows[0]["BkgID"].ToString()));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " UPDATE NVO_BOL SET MarkNo=@MarkNo,CagoDescription=@CagoDescription where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MarkNo", _dtc.Rows[0]["NewMarksNo"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CagoDescription", _dtc.Rows[0]["NewCargoDesc"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", _dtc.Rows[0]["BkgID"].ToString()));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " UPDATE NVO_BOLCustomerDetails SET PartID=@PartID,PartyName=@PartyName,PartyAddress=@PartyAddress where BLID=@BLID and PartyTypeID=@PartyTypeID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", _dtc.Rows[0]["ShipperNewID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", _dtc.Rows[0]["Shipper"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyAddress", _dtc.Rows[0]["ShipperNewAddress"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", _dtc.Rows[0]["BLID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 1));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " UPDATE NVO_BOLCustomerDetails SET PartID=@PartID,PartyName=@PartyName,PartyAddress=@PartyAddress where BLID=@BLID and PartyTypeID=@PartyTypeID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", _dtc.Rows[0]["ConsigneeNewID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", _dtc.Rows[0]["Consignee"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyAddress", _dtc.Rows[0]["ConsigneeNewAddress"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", _dtc.Rows[0]["BLID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 2));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " UPDATE NVO_BOLCustomerDetails SET PartID=@PartID,PartyName=@PartyName,PartyAddress=@PartyAddress where BLID=@BLID and PartyTypeID=@PartyTypeID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", _dtc.Rows[0]["NotifyNewID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", _dtc.Rows[0]["Notify"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyAddress", _dtc.Rows[0]["NotifNewAddress"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", _dtc.Rows[0]["BLID"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", 3));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " UPDATE NVO_BLRelease SET Shipper=@Shipper,ShipperAddress=@ShipperAddress,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,Notify1=@Notify1,Notify1Address=@Notify1Address,Marks=@Marks,Description=@Description  where BLID=@BLID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", _dtc.Rows[0]["Shipper"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", _dtc.Rows[0]["ShipperNewAddress"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", _dtc.Rows[0]["Consignee"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", _dtc.Rows[0]["ConsigneeNewAddress"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1", _dtc.Rows[0]["Notify"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1Address", _dtc.Rows[0]["NotifNewAddress"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Marks", _dtc.Rows[0]["NewMarksNo"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", _dtc.Rows[0]["NewCargoDesc"].ToString()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", _dtc.Rows[0]["BLID"].ToString()));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    for (int i = 0; i < _dtd.Rows.Count; i++)
                    {
                        Cmd.CommandText = " UPDATE NVO_BOLCntrDetails SET SealNo=@SealNo,NoOfPkg=@NoOfPkg,PakgType=@PakgType,CBM=@CBM,VGM=@VGM,NtWt=@NtWt,GrsWt=@GrsWt where BLID=@BLID and CntrID=@CntrID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", _dtd.Rows[i]["SealNo"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkg", _dtd.Rows[i]["NoOfPkg"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgType", _dtd.Rows[0]["PakgType"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", _dtd.Rows[0]["CBM"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", _dtd.Rows[0]["VGM"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWt", _dtd.Rows[0]["NtWt"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", _dtd.Rows[0]["GrsWt"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", _dtd.Rows[0]["BLID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", _dtd.Rows[i]["CntrID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                }
                catch (Exception ex)
                {
                    MYCorrMemo.Add(new MYCorrMemo { Message = ex.ToString() });
                    return MYCorrMemo;
                }

            }
            trans.Commit();
            MYCorrMemo.Add(new MYCorrMemo { Message = "Approved sucessfully" });
            return MYCorrMemo;



        }


        public DataTable GetCorrectionMemoRecord(MYCorrMemo Data)
        {
            string _Query = " select ShipperNewID,(select top(1) CustomerName from NVO_view_CustomerDetails where CID= ShipperNewID) as Shipper, "+
                            " ShipperNewAddress,ConsigneeNewID,(select top(1) CustomerName from NVO_view_CustomerDetails where CID = ConsigneeNewID) as Consignee, "+
                            " ConsigneeNewAddress,NotifyNewID,(select top(1) CustomerName from NVO_view_CustomerDetails where CID = NotifyNewID) as Notify, "+
                            " NotifNewAddress,NewMarksNo,NewCargoDesc,BLID,BkgID from NVO_CorrectionMemo where Id =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable GetCorrectionCntrID(MYCorrMemo Data)
        {
            string _Query = "select * from NVO_CorrectionMemoCntrDtls where Id =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYCorrMemo> CorrectionMemoReject(MYCorrMemo Data)
        {
            List<MYCorrMemo> MYCorrMemo = new List<MYCorrMemo>();
            int result = 0;
            DbConnection con = null;
            DbTransaction trans;
            con = _dbFactory.GetConnection();
            con.Open();
            trans = _dbFactory.GetTransaction(con);
            DbCommand Cmd = _dbFactory.GetCommand();
            Cmd.Connection = con;
            Cmd.Transaction = trans;
         

                try
                {

                    Cmd.CommandText = " UPDATE NVO_CorrectionMemo SET Status=@Status where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 3));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                }
                catch (Exception ex)
                {
                    MYCorrMemo.Add(new MYCorrMemo { Message = ex.ToString() });
                    return MYCorrMemo;
                }

           
            trans.Commit();
            MYCorrMemo.Add(new MYCorrMemo { Message = "Rejected sucessfully" });
            return MYCorrMemo;



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

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
   public class ImportManager
    {
        List<MyImport> ListImport = new List<MyImport>();
        List<MyImpBooking> ListImpBooking = new List<MyImpBooking>();
        List<MyImpCAN> ListImpCAN = new List<MyImpCAN>();
        List<MYImpDeliveryOrder> ListImpDO = new List<MYImpDeliveryOrder>();
        List<MYImpDDG> List = new List<MYImpDDG>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Anand
        public List<MyImport> GetImportMaster(MyImport Data)
        {
            DataTable dt = GetImportDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BkgID = dt.Rows[i]["BkgID"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    VesVoy = dt.Rows[i]["BLVesVoy"].ToString(),
                    CommodityType = dt.Rows[i]["CommodityType"].ToString(),
                    Mode = dt.Rows[i]["BlDirect"].ToString().ToUpper(),
                    BLType = dt.Rows[i]["BLType"].ToString(),

                });

            }
            return ListImport;
        }
        public DataTable GetImportDtls(MyImport Data)
        {
            string strWhere = "";
            //string _Query = "select NVO_Booking.ID, BookingNo,POO,POL,POD,FPOD, " +
            //                " VesVoy,CommodityType from NVO_Booking " +
            //                " inner join NVO_BOL on NVO_BOL.BkgID= NVO_Booking.ID inner join NVO_VoyageOpenBLdtls on NVO_VoyageOpenBLdtls.BLID = NVO_BOL.ID " +
            //                " inner join NVO_Voyage on NVO_Voyage.ID = NVO_VoyageOpenBLdtls.VoyageID";
            string _Query = "select ID,BLNumber,BkgID,POO,POL,POD,FPOD,BLVesVoy,CommodityType,BlDirect,BLType from NVO_v_ImportBLView";

           strWhere = _Query += " where AgencyID=" + Data.AgencyID;

            if (Data.BookingNo != null && Data.BookingNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where BLNumber like'%" + Data.BookingNo + "%'";
                else
                    strWhere += " and BLNumber like'%" + Data.BookingNo + "%'";

            if (Data.POL != null && Data.POL != "?")
                if (strWhere == "")
                    strWhere += _Query + " where POLID=" + Data.POL;
                else
                    strWhere += " and POLID=" + Data.POL;

            if (Data.POD != null && Data.POD != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PODID=" + Data.POD;
                else
                    strWhere += " and PODID=" + Data.POD;
            if (Data.VesVoy != null && Data.VesVoy != "?")
                if (strWhere == "")
                    strWhere += _Query + " where VesVoyID=" + Data.VesVoy;
                else
                    strWhere += " and VesVoyID=" + Data.VesVoy;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");

        }

        public List<MyImport> BindBookingNo(MyImport Data)
        {
            DataTable dt = GetBookingNo(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                  
                });

            }
            return ListImport;
        }

        public DataTable GetBookingNo(MyImport Data)
        {
            string _Query = "select ID, BookingNo from NVO_Booking";
            return GetViewData(_Query, "");
        }

        public List<MyImport> BindBookingValues(MyImport Data)
        {
            DataTable dt = GetBookingDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    BookingNo = dt.Rows[i]["BLNumber"].ToString(),
                    //BkgParty = dt.Rows[i]["BkgParty"].ToString()
                    BkgPartyID = Int32.Parse(dt.Rows[i]["BLBkgPartyID"].ToString()),
                    POOID = dt.Rows[i]["POOID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),
                    CommodityTypeID = dt.Rows[i]["BLCommodityTypeID"].ToString(),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    SurrenderID = dt.Rows[i]["SurrenderID"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    Notify = dt.Rows[i]["Notify"].ToString(),
                    DirectImport = dt.Rows[i]["BLDirectImport"].ToString(),
                    HBLNo = dt.Rows[i]["HBLNo"].ToString(),
                    HBLDate = dt.Rows[i]["HBLDate"].ToString(),
                    DeliveryType = dt.Rows[i]["DeliveryType"].ToString(),
                    CFS = dt.Rows[i]["CFS"].ToString(),
                    ImportIHC = dt.Rows[i]["ImportIHC"].ToString(),
                    LineNumber = dt.Rows[i]["LineNumber"].ToString(),
                    NominationCFS = dt.Rows[i]["NominationCFS"].ToString(),

                   // SurrenderID = dt.Rows[i]["SurrenderID"].ToString(),
                    Freedays = dt.Rows[i]["Freedays"].ToString(),
                    VesVoyID = dt.Rows[i]["ImpBLVesVoyID"].ToString(),
                    BLDirectImport = dt.Rows[i]["BLDirectImport"].ToString(),
                    BLType = dt.Rows[i]["BLTypes"].ToString(),
                    BLDirect = dt.Rows[i]["BLDirect"].ToString(),
                    ParentBLID = dt.Rows[i]["ParentBLID"].ToString(),
                    MBLNumber = dt.Rows[i]["MBLNumber"].ToString(),
                    BLVesVoyID = dt.Rows[i]["BLVesVoyID"].ToString(),
                    BLVesVoy = dt.Rows[i]["BLVesVoy"].ToString(),
                    PrincipalID = dt.Rows[i]["PrincipalID"].ToString()





                });
            }
            return ListImport;
        }
        public DataTable GetBookingDetails(MyImport Data)
        {

            //string _Query = " Select NVO_Booking.ID, RRNo, NVO_Booking.DestinationAgentID, (select top(1) SurrenderStatus from NVO_BOL where BkgID = NVO_Booking.ID) as SurrenderStatus,  " +
            //                " (select top(1) FreeDays from NVO_BOL where BkgID = NVO_Booking.ID) as FreeDays, " +
            //                " (select top(1) PartID from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID and PartyTypeID = 1) as Shipper,  " +
            //                " isnull((select top(1) PartID from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID and PartyTypeID = 2),0) as Consignee, " +
            //                " isnull((select top(1) PartID from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID and PartyTypeID = 3),0) as Notify,POLID,PODID, " +
            //                " case when DirectImport = 1 then (select top(1) POOID from NVO_BOL where BkgID = NVO_Booking.ID) else POOID end as POOID,  " +
            //                " case when DirectImport = 1 then (select top(1) POOID from NVO_BOL where BkgID = NVO_Booking.ID) else  FPODID end as FPODID,BookingNo,BkgPartyID,CommodityTypeID,DirectImport " +
            //                " from NVO_Booking  where NVO_Booking.ID=" + Data.ID;

            //string _Query = " Select NVO_Booking.ID, RRNo, NVO_Booking.DestinationAgentID, (select top(1) SurrenderStatus from NVO_BOL where BkgID = NVO_Booking.ID) as SurrenderStatus,   " +
            //                " (select top(1) FreeDays from NVO_BOL where BkgID = NVO_Booking.ID) as FreeDays, " +
            //                " case when DirectImport = 1 then(select top(1) PartID from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID and PartyTypeID = 1) else NVO_ImpBooking.ShipperID end as Shipper,  " +
            //                " case when DirectImport = 1 then isnull((select top(1) PartID from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID and PartyTypeID = 2),0) else NVO_ImpBooking.ConsigneeID end as Consignee, " +
            //                " case when DirectImport = 1 then isnull((select top(1) PartID from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID and PartyTypeID = 3),0) else NVO_ImpBooking.NotifyID end as Notify, " +
            //                " POLID,PODID, " +
            //                " case when DirectImport = 1 then(select top(1) POOID from NVO_BOL where BkgID = NVO_Booking.ID) else POOID end as POOID,    " +
            //                " case when DirectImport = 1 then(select top(1) POOID from NVO_BOL where BkgID = NVO_Booking.ID) else FPODID end as FPODID, " +
            //                " BookingNo,BkgPartyID,CommodityTypeID,DirectImport,HBLNo, convert(varchar,HBLDate, 23) as HBLDate,DeliveryType, CFS,ImportIHC,LineNumber, " +
            //                " NominationCFS,NVO_ImpBooking.DestinationAgentID,SurrenderID,Freedays,NVO_ImpBooking.VesVoyID " +
            //                " from NVO_Booking " +
            //                " left outer join NVO_ImpBooking on NVO_ImpBooking.ExpID = NVO_Booking.ID " +
            //                " where NVO_Booking.ID=" + Data.ID;

            string _Query = "  select NVO_BOL.Id, BLNumber,(select top(1) RRNo from NVO_Booking where ID = BkgId) as RRNo,BLBkgPartyID,SurrenderStatus as SurrenderID, " +
                            " (select ( select top(1) ImpFreeDays from NVO_RatesheetMode where NVO_RatesheetMode.RRID=NVO_Booking.RRID) from NVO_Booking where NVO_Booking.ID = BkgId) as FreeDays," +
                            " (select top(1) PartID from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 1) as Shipper, " +
                            " (select top(1) PartID from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 2) as Consignee, " +
                            " (select top(1) PartID from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 3) as Notify, " +
                            " POOID,POLID,PODID,FPODID,BLCommodityTypeID,BLDirectImport,Freedays, ImpBLVesVoyID,case when BLDirectImport = 1 then (select top(1) ImportIHC from NVO_Ratesheet inner join NVO_Booking on NVO_Booking.RRID=NVO_Ratesheet.ID and NVO_Booking.ID = BkgId) else ImportIHC end as ImportIHC, " +
                            " HBLNo,convert(varchar,HBLDate, 23) as HBLDate,DeliveryType, CFS,LineNumber,NominationCFS,DesAgentID as DestinationAgentID,BLDirectImport,BLTypes,BLDirect,ParentBLID,(select top(1) BLNumber from NVO_BOL BOL where BOL.ID= NVO_BOL.ParentBLID) as MBLNumber,BLVesVoyID,BLVesVoy,PrincipalID " +
                            " from NVO_BOL where Id = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MYBOL> ImpBOLCntrExistingValus(MYBOL Data)
        {
            List<MYBOL> ViewList = new List<MYBOL>();
            DataTable dt = GetImpBOLCntrExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYBOL
                {
                    BCNID = Int32.Parse(dt.Rows[i]["BCNID"].ToString()),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    PakgType = dt.Rows[i]["PakgType"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    NtWt = dt.Rows[i]["NtWt"].ToString(),
                    VGM = dt.Rows[i]["VGM"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString()



                });
            }
            return ViewList;
        }



        public DataTable GetImpBOLCntrExistingValus(MYBOL Data)
        {

            string _Query = "  select distinct 0 as BCNID,NVO_Containers.Id as CntrID,TypeID,(select top(1) ISOCode  from NVO_tblCntrTypes where ID = TypeID) as ISOCode, " +
                            " (select top(1) Size  from NVO_tblCntrTypes where ID = TypeID) as Size, " +
                            " (select top(1) SealNo from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as SealNo, " +
                            " (select top(1) NoOfPkg from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as NoOfPkg,  " +
                            " (select top(1) PakgType from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as PakgType, " +
                            " (select top(1) PakgTypeName from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as PakgTypeName, " +
                            " (select top(1) GrsWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as GrsWt," +
                            " (select top(1) NtWt from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as NtWt,  " +
                            " (select top(1) VGM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as VGM, " +
                            " (select top(1) CBM from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_ContainerTxns.BLNumber) as CBM " +
                            " from NVO_ContainerTxns " +
                            " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
                            " where BLNumber = " + Data.BkgID;

            //string _Query = " select distinct 0 as BCNID, CntrID,(select top(1) TypeID from NVO_Containers where ID = CntrID)  as TypeID, " +
            //                " (select top(1) CntrNo from NVO_Containers where ID = CntrID)  as CntrNo,(select (select  top(1) Size from NVO_tblCntrTypes where ID=TypeID) from NVO_Containers where Id =CntrID) as Size,ISOCode,CntrID,SealNo,NoOfPkg, " +
            //                " PakgType,PakgTypeName,GrsWt,NtWt,VGM,CBM from NVO_BOLCntrDetails where BLID = " + Data.BLID;

            return GetViewData(_Query, "");
        }



        public List<MyImport> BindVesVoyMaster(MyImport Data)
        {
            DataTable dt = GetVesVoyDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["VID"].ToString()),
                    VoyTypesV = dt.Rows[i]["VoyageTypes"].ToString(),
                    //BkgParty = dt.Rows[i]["BkgParty"].ToString()
                    LegV = dt.Rows[i]["LegInformation"].ToString(),
                    VesVoy = dt.Rows[i]["VoyageID"].ToString(),
                    LoadPortv = dt.Rows[i]["LoadPort"].ToString(),
                    NextPortv = dt.Rows[i]["NextPort"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()

                });
            }
            return ListImport;
        }
        public DataTable GetVesVoyDetails(MyImport Data)
        {


            //string _Query = " select distinct NVO_Voyage.Id,NVO_BOLVoyageDetails.VID, vt.GeneralName as VoyageTypesv,Leg.GeneralName as LegInformationv, " +
            //                " VoyageTypes,LegInformation,ImpVesVoyId,LoadPort,NextPort," +
            //                " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) + ' -' + ImportVoyageCd as VesVoy, " +
            //                " (select PortName from NVO_PortMaster where ID = NVO_BOLVoyageDetails.LoadPort) as LoadPort,   " +
            //                " (select PortName from NVO_PortMaster where ID = NVO_BOLVoyageDetails.NextPort) as NextPort,  " +
            //                " convert(varchar, NVO_BOLVoyageDetails.ETA, 103) as ETA,convert(varchar, NVO_BOLVoyageDetails.ETD, 103) as ETD " +
            //                " from NVO_BOLVoyageDetails " +
            //                " inner join NVO_GeneralMaster Vt On Vt.ID = NVO_BOLVoyageDetails.VoyageTypes " +
            //                " inner join NVO_GeneralMaster Leg On Leg.ID = NVO_BOLVoyageDetails.LegInformation " +
            //                " inner join NVO_Voyage On NVO_Voyage.ID = NVO_BOLVoyageDetails.VesVoyID " +
            //                " inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = NVO_Voyage.ID " +
            //                " where NVO_BOLVoyageDetails.BLID = " + Data.ID;

            //string _Query = " select distinct NVO_Voyage.Id,NVO_BOLVoyageDetails.VID, vt.GeneralName as VoyageTypesv,Leg.GeneralName as LegInformationv,  " +
            //                " VoyageTypes,LegInformation,NVO_VoyageOpenBLdtls.VoyageID,LoadPort,NextPort, " +
            //                " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) +' -' + (select top(1) ImportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as VesVoy, " +
            //                " (select PortName from NVO_PortMaster where ID = NVO_BOLVoyageDetails.LoadPort) as LoadPort,(select PortName from NVO_PortMaster where ID = NVO_BOLVoyageDetails.NextPort) as NextPort,  " +
            //                " convert(varchar, NVO_BOLVoyageDetails.ETA, 103) as ETA,convert(varchar, NVO_BOLVoyageDetails.ETD, 103) as ETD " +
            //                " from NVO_BOLVoyageDetails " +
            //                " inner join NVO_GeneralMaster Vt On Vt.ID = NVO_BOLVoyageDetails.VoyageTypes " +
            //                " inner join NVO_GeneralMaster Leg On Leg.ID = NVO_BOLVoyageDetails.LegInformation " +
            //                " inner join NVO_VoyageOpenBLdtls on NVO_VoyageOpenBLdtls.BLID = NVO_BOLVoyageDetails.BLID " +
            //                " inner join NVO_Voyage On NVO_Voyage.ID = NVO_BOLVoyageDetails.VesVoyID " +
            //                " where NVO_BOLVoyageDetails.BLID =" + Data.ID;


            string _Query = " select distinct NVO_Voyage.Id,NVO_BOLVoyageDetails.VID, vt.GeneralName as VoyageTypesv,Leg.GeneralName as LegInformationv,  " +
                            " VoyageTypes,LegInformation, LoadPort,NextPort,   " +
                            " case when(select top(1) BLDirectImport from NVO_BOL where Id = BLID) = 1 then (select top(1) VoyageID from NVO_VoyageOpenBLdtls where BLID = NVO_BOLVoyageDetails.BLID) else VesVoyID end as VoyageID, " +
                            " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) +' -' + (select top(1) ImportVoyageCd from NVO_VoyageRoute where VoyageID =  case when(select top(1) BLDirectImport from NVO_BOL where Id = BLID) = 1 then(select top(1) VoyageID from NVO_VoyageOpenBLdtls where BLID = NVO_BOLVoyageDetails.BLID) else VesVoyID end) as VesVoy,  " +
                            " (select PortName from NVO_PortMaster where ID = NVO_BOLVoyageDetails.LoadPort) as LoadPort, " +
                            " (select PortName from NVO_PortMaster where ID = NVO_BOLVoyageDetails.NextPort) as NextPort,   convert(varchar, NVO_BOLVoyageDetails.ETA, 103) as ETA, " +
                            " convert(varchar, NVO_BOLVoyageDetails.ETD, 103) as ETD  from NVO_BOLVoyageDetails " +
                            " inner join NVO_GeneralMaster Vt On Vt.ID = NVO_BOLVoyageDetails.VoyageTypes " +
                            " inner join NVO_GeneralMaster Leg On Leg.ID = NVO_BOLVoyageDetails.LegInformation " +
                            " inner join NVO_Voyage On NVO_Voyage.ID = NVO_BOLVoyageDetails.VesVoyID  where NVO_BOLVoyageDetails.BkgID=" + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyImport> BindImpCntrMaster(MyImport Data)
        {
            DataTable dt = GetImpCntrDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString()
                  
                });
            }
            return ListImport;
        }
        public DataTable GetImpCntrDetails(MyImport Data)
        {
            string _Query = "select ID,CntrNo,(select top(1) Size  from  NVO_tblCntrTypes where ID = CntrType) as Size from NVO_BOLCntrPickup where BkgId=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyImport> BindCntrMaster(MyImport Data)
        {
            DataTable dt = GetCntrDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    PakgType = dt.Rows[i]["PakgTypeName"].ToString(),
                    PakgTypeName = dt.Rows[i]["PakgTypeName"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    NtWt = dt.Rows[i]["NtWt"].ToString(),
                    VGM = dt.Rows[i]["VGM"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString()
                });
            }
            return ListImport;
        }

        public DataTable GetCntrDetails(MyImport Data)
        {
            string _Query = " select(select top(1) CntrNo from NVO_Containers where ID = CntrID) as CntrNo, CntrID, Size, ISOCode, SealNo, NoOfPkg, PakgTypeName, "+
                            " GrsWt, NtWt, VGM, CBM from NVO_BOLCntrDetails where BkgId="+ Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickupdtls> ImpPickcntrBooking(MyCntrPickupdtls Data)
        {
            List<MyCntrPickupdtls> ViewList = new List<MyCntrPickupdtls>();
            DataTable dt = GetImpPickCntrBookingdtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCntrPickupdtls
                {
                    ID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                   
                    MSDate = dt.Rows[i]["MSDate"].ToString(),
                    FCDate = dt.Rows[i]["FCDate"].ToString(),
                    ExpFIDate = dt.Rows[i]["ExpFIDate"].ToString(),
                    FLDate = dt.Rows[i]["FLDate"].ToString(),
                    FBDate = dt.Rows[i]["FBDate"].ToString(),
                    TZDate = dt.Rows[i]["TZDate"].ToString(),
                    TZFBDate = dt.Rows[i]["TZFBDate"].ToString(),
                    FVDate = dt.Rows[i]["FVDate"].ToString(),
                    ImpFIDate = dt.Rows[i]["ImpFIDate"].ToString(),
                    FVICDDate = dt.Rows[i]["FVICDDate"].ToString(),
                    FUDate = dt.Rows[i]["FUDate"].ToString(),
                    MADate = dt.Rows[i]["MADate"].ToString(),
                    MRDate = dt.Rows[i]["MRDate"].ToString(),
                    FVCFSDate = dt.Rows[i]["FVCFSDate"].ToString(),
                    DVDate = dt.Rows[i]["DVDate"].ToString(),
                    CurrentDepotID = dt.Rows[i]["CurrentDepotID"].ToString(),
                   // LocationID = dt.Rows[i]["LocationID"].ToString(),
                    IsTrue = "0"

                });
            }
            return ViewList;
        }

        public DataTable GetImpPickCntrBookingdtls(MyCntrPickupdtls Data)
        {
            //string _Query = " select CntrID,CntrNo,(select top(1) size from NVO_tblCntrTypes where Id = CntrType) as Size,CurrentDepotID,LocationID, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MS' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MSDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'ER' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as ERDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'ED' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as EODate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'GI' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as GIDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'VD' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as VDDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'TA' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as TADate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'TD' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as TDDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'VA' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as VADate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'GO' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as GODate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'IR' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as IRDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'IO' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as IODate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'LI' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as LIDate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'LO' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as LODate, " +
            //                "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MR' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MRDate " +
            //                "from NVO_BOLCntrPickup where CntrID=" + Data.CntrID;


            //string _Query = " select CntrID,CntrNo,(select top(1) size from NVO_tblCntrTypes where Id = CntrType) as Size,CurrentDepotID,LocationID,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MS' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MSDate, " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FC' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as FCDate,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FI' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as ExpFIDate, " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FL' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as FLDate,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FB' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as FBDate, " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'TZ' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as TZDate,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'TZFB' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as TZFBDate,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FV' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as FVDate, " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FI' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as ImpFIDate,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FVICD' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as FVICDDate, " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'FU' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as FUDate, " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MA' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MADate,  " +
            //               " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MR' and NVO_BOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MRDate " +
            //               " from NVO_BOLCntrPickup where BkgID=" + Data.ID;
            ///Notes: Location ID Remove SQL Select Query (LocationID )

            string _Query = " select distinct NVO_Containers.ID as CntrID,CntrNo,(select top(1) size from NVO_tblCntrTypes where Id = TypeID) as Size, NVO_Containers.DepotID  as CurrentDepotID,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MS' order by DtMovement desc) as MSDate,  " +
                           " (select top(1) convert(varchar, DtMovement, 101) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MS' order by DtMovement desc) as MSDateF,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FC' order by DtMovement desc) as FCDate,   " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FI'  order by DtMovement desc) as ExpFIDate, " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FL'  order by DtMovement desc) as FLDate,   " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FB'  order by DtMovement desc) as FBDate,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'TZ'  order by DtMovement desc) as TZDate,   " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'TZFB' order by DtMovement desc) as TZFBDate, " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FV'  order by DtMovement desc) as FVDate,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FI'  order by DtMovement desc) as ImpFIDate, " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FVCFS'  order by DtMovement desc) as FVCFSDate,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'DV'  order by DtMovement desc) as DVDate,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FVICD'  order by DtMovement desc) as FVICDDate,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'FU'  order by DtMovement desc) as FUDate, " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MA' order by DtMovement desc) as MADate,  " +
                           " (select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns c where c.containerID = NVO_Containers.ID and StatusCode = 'MR' order by DtMovement desc) as MRDate " +
                           " from NVO_ContainerTxns  Inner join NVO_Containers on NVO_Containers.Id = NVO_ContainerTxns.ContainerID where BLNumber = " + Data.BkgID;


            return GetViewData(_Query, "");
        }



        public List<MyImport> BindPreAlertMaster(MyImport Data)
        {
            DataTable dt = GetPreAlertDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    SurrenderStatusV = dt.Rows[i]["SurrenderStatus"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    BkgPartyID = Int32.Parse(dt.Rows[i]["BkgPartyID"].ToString())
                });
            }
            return ListImport;
        }
        public DataTable GetPreAlertDetails(MyImport Data)
        {
            string _Query = "select NVO_Booking.ID, NVO_Booking.BookingNo, NVO_Booking.DestinationAgentID,NVO_BOL.SurrenderStatus,POLID,PODID, " +
                            " convert(varchar, NVO_BOLVoyageDetails.ETA, 103) as ETA,convert(varchar, NVO_BOLVoyageDetails.ETD, 103) as ETD, " +
                            " VesVoy,BkgPartyID,* from NVO_Booking " +
                            " inner join NVO_BOLCustomerDetails ON NVO_BOLCustomerDetails.BCID = NVO_Booking.ID " +
                            " inner join NVO_BOL On NVO_BOL.ID = NVO_Booking.ID " +
                            " inner join NVO_BOLVoyageDetails On NVO_BOLVoyageDetails.BLID = NVO_Booking.ID " +
                             " where NVO_Booking.ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyImport> BindCANMaster(MyImport Data)
        {
            DataTable dt = GetCANDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BLNumber"].ToString(),
                    //DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    //SurrenderStatusV =dt.Rows[i]["SurrenderStatus"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    //ETD = dt.Rows[i]["ETD"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    //VesVoyID = dt.Rows[i]["BLVesVoyID"].ToString(),
                   // BkgPartyID = Int32.Parse(dt.Rows[i]["BkgPartyID"].ToString()),
                    HBLNo = dt.Rows[i]["HBLNo"].ToString(),
                    HBLDate = dt.Rows[i]["HBLDate"].ToString(),
                    ReleaseTo= dt.Rows[i]["ReleaseTo"].ToString(),
                    IGMNo = dt.Rows[i]["IGMNo"].ToString(),
                    IGMDate = dt.Rows[i]["IGMDate"].ToString(),
                    LineNumber = dt.Rows[i]["LineNumber"].ToString(),
                    SignAsAgent = dt.Rows[i]["SignAsAgent"].ToString(),
                    //ImpID = dt.Rows[i]["ImpID"].ToString()
                });
            }
            return ListImport;
        }
        public DataTable GetCANDetails(MyImport Data)
        {
            //string _Query = " Select distinct NVO_ImpBooking.Id as ImpID,NVO_Booking.ID, NVO_Booking.BookingNo, NVO_Booking.DestinationAgentID,NVO_BOL.SurrenderStatus,NVO_BOL.POLID,NVO_BOL.PODID,   " +
            //                " convert(varchar, NVO_BOLVoyageDetails.ETA, 23) as ETA,convert(varchar, NVO_BOLVoyageDetails.ETD, 23) as ETD,  VesVoy,NVO_Booking.VesVoyID,BkgPartyID, " +
            //                " HBLNo, convert(varchar, HBLDate, 23) as HBLDate, HBLNo from NVO_Booking " +
            //                " inner join NVO_BOLCustomerDetails ON NVO_BOLCustomerDetails.BCID = NVO_Booking.ID " +
            //                " inner join NVO_BOL On NVO_BOL.BkgID = NVO_Booking.ID " +
            //                " inner join NVO_BOLVoyageDetails On NVO_BOLVoyageDetails.BkgID = NVO_Booking.ID " +
            //                " Left outer join NVO_ImpBooking on NVO_ImpBooking.ExpID = NVO_Booking.ID " +
            //                " Where NVO_Booking.ID = " + Data.ID;

            //string _Query = "  select NVO_Booking.Id,NVO_ImpBooking.Id as ImpID, NVO_Booking.BookingNo,VesVoy,NVO_Booking.VesVoyID,PODID,POLID,HBLNo, convert(varchar, HBLDate, 23) as HBLDate, " +
            //                 " (select convert(varchar, ETD, 23) as ETD from NVO_VoyageRoute where VoyageID = NVO_Booking.VesVoyID and PortID = PODID) as ETA, "+
            //              " (select top(1) IGMNo from NVO_VoyageManifestDtls where VoyageID = NVO_Booking.VesVoyID) as IGMNo, "+
            //              " (select top(1) convert(varchar, IGMDate, 23) as ETD from NVO_VoyageManifestDtls where VoyageID = NVO_Booking.VesVoyID) as IGMDate, "+
            //                " (select  top(1) ReleaseTo from NVO_ImpCAN where ExpID = NVO_Booking.Id) as ReleaseTo, " +
            //                " (select  top(1) LineNumber from NVO_ImpCAN where ExpID = NVO_Booking.Id) as LineNumber " +
            //                " from NVO_Booking " +
            //                " inner join NVO_ImpBooking on NVO_ImpBooking.ExpID = NVO_Booking.ID " +
            //                " Where NVO_Booking.ID =" + Data.ID;

            string _Query = " select NVO_BOL.Id,BkgId,BLNumber,BLVesVoyID,PODID,POLID,HBLNo,  convert(varchar, HBLDate, 23) as HBLDate ,   " +
                            " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) +' -' + (select top(1) ImportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as VesVoy,   " +
                            " (select top(1) convert(varchar, ETA, 23) from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as ETA,    " +
                            " (select top(1) IGMNo from NVO_VoyageManifestDtls where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as IGMNo,  " +
                            " (select top(1) convert(varchar, IGMDate, 23)  from NVO_VoyageManifestDtls where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as IGMDate,  " +
                            " (select  top(1) ReleaseTo from NVO_ImpCAN where NVO_ImpCAN.BLID = NVO_BOL.Id) as ReleaseTo,   " +
                            " (select  top(1) LineNumber from NVO_ImpCAN where NVO_ImpCAN.BLID = NVO_BOL.Id) as LineNumber,   " +
                            " (select  top(1) SignAsAgent from NVO_ImpCAN where NVO_ImpCAN.BLID = NVO_BOL.Id) as SignAsAgent " +
                            " from NVO_BOL " +
                            " inner join NVO_VoyageOpenBLdtls on NVO_VoyageOpenBLdtls.BLID = NVO_BOL.ID " +
                            " inner join NVO_Voyage on NVO_Voyage.ID = NVO_VoyageOpenBLdtls.VoyageID  where NVO_BOL.Id = " + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyImport> BindDeliveryOrderMaster(MyImport Data)
        {
            DataTable dt = GetDeliveryOrderDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BLNumber"].ToString(),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    SurrenderStatusV = dt.Rows[i]["SurrenderStatus"].ToString(),
                    POOID = dt.Rows[i]["POOID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    //BkgPartyID = Int32.Parse(dt.Rows[i]["BkgPartyID"].ToString()),
                    HBLDate = dt.Rows[i]["HBLDate"].ToString(),
                    HBLNo = dt.Rows[i]["HBLNo"].ToString(),
                    IGMNo = dt.Rows[i]["IGMNo"].ToString(),
                    IGMDate = dt.Rows[i]["IGMDate"].ToString(),
                    LineNumber = dt.Rows[i]["LineNumber"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ValidityDate = dt.Rows[i]["ValidityDate"].ToString(),
                    SignAsAgent = dt.Rows[i]["SignAsAgent"].ToString(),
                    BLDirectImport = dt.Rows[i]["BLDirectImport"].ToString()


                });
            }
            return ListImport;
        }
        public DataTable GetDeliveryOrderDetails(MyImport Data)
        {
            
            string _Query = " select NVO_BOL.Id,BLNumber, DesAgentID as DestinationAgentID,SurrenderStatus,POOID,FPODID,POLID,PODID, HBLNo, (select top(1) convert(varchar,BLDate, 23) from NVO_BLRelease where BLID=NVO_BOL.ID) as HBLDate," +
                  " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) +' -' + (select top(1) ImportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as VesVoy, " +
                  " (select top(1) convert(varchar,ETA,103) from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as ETA, " +
                  " (select top(1) convert(varchar,ETD,103) from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as ETD, " +
                  " (select top(1) convert(varchar,ETA + 14,23) from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as ValidityDateOld," +
                  " (select convert(varchar,(DtMovement+14),23) from NVO_ContainerTxns where  StatusCode= 'FV' and BLNumber= NVO_BOL.BkgID) as ValidityDate, "+
                  " (select top(1) VoyageID from NVO_VoyageOpenBLdtls where BLID = NVO_BOL.ID) as VoyageID, " +
                  " isnull((select top(1) PartID from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 1),0) as Shipper, " +
                  " isnull((select top(1) PartID from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 2),0) as Consignee, " +
                  " isnull((select top(1) PartID from NVO_BOLCustomerDetails where BLID = NVO_BOL.ID and PartyTypeID = 3),0) as Notify, " +
                  " (select top(1) IGMNo from NVO_VoyageManifestDtls where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as IGMNo,  " +
                  " (select top(1) convert(varchar, IGMDate, 23)  from NVO_VoyageManifestDtls where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as IGMDate, " +
                  " NVO_ImpCAN.LineNumber,NVO_ImpCAN.SignAsAgent,BLDirectImport " +
                  " from NVO_BOL " +
                  " LEFT OUTER JOIN  NVO_ImpCAN on NVO_ImpCAN.BLID = NVO_BOL.ID " +
                  " inner join NVO_VoyageOpenBLdtls on NVO_VoyageOpenBLdtls.BLID = NVO_BOL.ID " +
                  " inner join NVO_Voyage on NVO_Voyage.ID = NVO_VoyageOpenBLdtls.VoyageID " +
                  " where NVO_BOL.ID= " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyImpBooking> InsertImpBooking(MyImpBooking Data)
        {
           



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

                    if (Data.DirectImport == "1")
                    {
                        if (Data.BLTypes == "40")
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_BOL where ID=@ID)<=0) " +
                                  " BEGIN " +
                                  " INSERT INTO  NVO_BOL(DeliveryType,CFS,ImportIHC,NominationCFS,BLTypes,BLDirect,PrincipalID,ImpFreeDays) " +
                                  " values (@DeliveryType,@CFS,@ImportIHC,@NominationCFS,@BLTypes,@BLDirect,@PrincipalID,@ImpFreeDays) " +
                                  " END  " +
                                  " ELSE " +
                                  " UPDATE NVO_BOL SET DeliveryType=@DeliveryType,CFS=@CFS,ImportIHC=@ImportIHC,NominationCFS=@NominationCFS,BLTypes=@BLTypes,BLDirect=@BLDirect,PrincipalID=@PrincipalID,ImpFreeDays=@ImpFreeDays where  ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryType", Data.DeliveryType));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CFS", Data.CFS));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportIHC", Data.ImportIHC));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NominationCFS", Data.NominationCFS));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypes", Data.BLTypes));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirect", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincipalID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpFreeDays", Data.Freedays));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }

                        if (Data.BLTypes == "42")
                        {
                            DataTable _dtAddColum = new DataTable();
                            _dtAddColum.Columns.Add("PartyID");
                            _dtAddColum.Columns.Add("PartyTypeID");


                            _dtAddColum.Rows.Add(_dtAddColum.NewRow());
                            _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyID"] = Data.ShipperID;
                            _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyTypeID"] = 1;
                            _dtAddColum.Rows.Add(_dtAddColum.NewRow());
                            _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyID"] = Data.ConsigneeID;
                            _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyTypeID"] = 2;
                            _dtAddColum.Rows.Add(_dtAddColum.NewRow());
                            _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyID"] = Data.NotifyID;
                            _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyTypeID"] = 3;


                            Cmd.CommandText = " IF((select count(*) from NVO_BOL where ID=@ID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_BOL(BLNumber,BkgID,DesAgentID,SurrenderStatus,BLTypes,MotherBL,ImpFreeDays,FreightPaymentID,CurrentDate, " +
                                                          " POOID,POLID,PODID,FPODID,ShipmentTypeID, " +
                                                          " AgencyID,BLCommodityTypeID,BLDirectImport,BLBkgPartyID,DeliveryType, " +
                                                          " CFS,ImportIHC,NominationCFS,ImpBLVesVoyID,Status,ParentBLID,BLVesVoy,BLVesVoyID,BLDirect,PrincipalID) " +
                                    " values (@BLNumber,@BkgID,@DesAgentID,@SurrenderStatus,@BLTypes,@MotherBL,@ImpFreeDays,@FreightPaymentID,@CurrentDate, " +
                                                          " @POOID,@POLID,@PODID,@FPODID,@ShipmentTypeID, " +
                                                          " @AgencyID,@BLCommodityTypeID,@BLDirectImport,@BLBkgPartyID,@DeliveryType, " +
                                                          " @CFS,@ImportIHC,@NominationCFS,@ImpBLVesVoyID,@Status,@ParentBLID,@BLVesVoy,@BLVesVoyID,@BLDirect,@PrincipalID) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_BOL SET BLNumber=@BLNumber,BkgID=@BkgID,DesAgentID=@DesAgentID,SurrenderStatus=@SurrenderStatus,BLTypes=@BLTypes,MotherBL=@MotherBL,ImpFreeDays=@ImpFreeDays,FreightPaymentID=@FreightPaymentID,CurrentDate=@CurrentDate, " +
                                                          " POOID=@POOID,POLID=@POLID,PODID=@PODID,FPODID=@FPODID,ShipmentTypeID=@ShipmentTypeID, " +
                                                          " AgencyID=@AgencyID,BLCommodityTypeID=@BLCommodityTypeID,BLDirectImport=@BLDirectImport,BLBkgPartyID=@BLBkgPartyID,DeliveryType=@DeliveryType, " +
                                                          " CFS=@CFS,ImportIHC=@ImportIHC,NominationCFS=@NominationCFS,ImpBLVesVoyID=@ImpBLVesVoyID,Status=@Status,ParentBLID=@ParentBLID,BLVesVoy=@BLVesVoy,BLVesVoyID=@BLVesVoyID,BLDirect=@BLDirect,PrincipalID=@PrincipalID where  ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BookingNo));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DesAgentID", Data.DestinationAgentID));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofOriginal", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SurrenderStatus", Data.SurrenderID));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@MarkNo", ""));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@CagoDescription", ""));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypes", Data.BLTypes));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@MotherBL", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpFreeDays", Data.Freedays));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPaymentID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks",""));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", 1));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@ReasonDescription", ""));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoReleaseStatus",0));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedBy", Data.NominationCFS));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledBy", Data.NominationCFS));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledOn", Data.NominationCFS));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@confirmedOn", Data.NominationCFS));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBLLocked", Data.NominationCFS));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSlotBill", Data.NominationCFS));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoyID", Data.VesVoyID));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoy", Data.NominationCFS));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLCommodityTypeID", Data.CommodityTypeID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirectImport", 2));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLBkgPartyID", Data.BkgPartyID));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@HBLNo", Data.HBLNo));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@HBLDate", Data.HBLDate));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryType", Data.DeliveryType));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CFS", Data.CFS));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportIHC", Data.ImportIHC));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NominationCFS", Data.NominationCFS));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpBLVesVoyID", Data.VesVoyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ParentBLID", Data.ParentBLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoyID", Data.BLVesVoyID)); 
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoy", Data.BLVesVoy));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirect", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("PrincipalID", Data.PrincipalID));


                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            Cmd.CommandText = "select ident_current('NVO_BOL')";
                            if (Data.ID == 0)
                                Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                            else
                                Data.ID = Data.ID;

                            for (int z = 0; z < _dtAddColum.Rows.Count; z++)
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_BOLCustomerDetails where BLID=@BLID and PartyTypeID=@PartyTypeID and BkgId=@BkgId)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_BOLCustomerDetails(BLID,PartyTypeID,PartID,BkgId) " +
                                   " values (@BLID,@PartyTypeID,@PartID,@BkgId) " +
                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_BOLCustomerDetails SET BLID=@BLID,PartyTypeID=@PartyTypeID,PartID=@PartID,BkgId=@BkgId where BLID=@BLID and PartyTypeID=@PartyTypeID and BkgId=@BkgId";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", _dtAddColum.Rows[z]["PartyTypeID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", _dtAddColum.Rows[z]["PartyID"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));

                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }

                            string[] ArrayCntr = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                            for (int i = 1; i < ArrayCntr.Length; i++)
                            {
                                var CharSplit = ArrayCntr[i].ToString().TrimEnd(',').Split(',');
                                Cmd.CommandText = " IF((select count(*) from NVO_BOLCntrDetails where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID)<=0) " +
                                             " BEGIN " +
                                             " INSERT INTO  NVO_BOLCntrDetails(BLID,CntrNo,CntrID,Size,ISOCode,SealNo,NoOfPkg,PakgType,PakgTypeName,GrsWt,NtWt,VGM,CBM,BkgId) " +
                                             " values (@BLID,@CntrNo,@CntrID,@Size,@ISOCode,@SealNo,@NoOfPkg,@PakgType,@PakgTypeName,@GrsWt,@NtWt,@VGM,@CBM,@BkgId) " +
                                             " END  " +
                                             " ELSE " +
                                             " UPDATE NVO_BOLCntrDetails SET BLID=@BLID,CntrNo=@CntrNo,CntrID=@CntrID,Size=@Size,ISOCode=@ISOCode,SealNo=@SealNo,NoOfPkg=@NoOfPkg,PakgType=@PakgType" +
                                             " ,PakgTypeName=@PakgTypeName,GrsWt=@GrsWt,NtWt=@NtWt,VGM=@VGM,CBM=@CBM,BkgId=@BkgId where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BCNID", CharSplit[0]));

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[2]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Size", CharSplit[3]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[4]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[5]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkg", CharSplit[6]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgType", CharSplit[7]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgTypeName", CharSplit[8]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", CharSplit[9]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWt", CharSplit[10]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[11]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", CharSplit[12]));

                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }

                        }

                    }
                    else
                    {
                        if (Data.BkgID == 0)
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_Booking where ID=@ID)<=0) " +
                                      " BEGIN " +
                                      " INSERT INTO  NVO_Booking(BookingNo,BkgDate,BkgPartyID,BkgParty,POOID,POO,POLID,POL,FPODID,FPOD,PODID,POD, " +
                                      " CommodityTypeID,CommodityType,VesVoyID,VesVoy,ShipperID,Shipper,AgentID,UserID,CurrentDate, DestinationAgent, DestinationAgentID,DirectImport,BkgStatus) " +
                                      " values (@BookingNo,@BkgDate,@BkgPartyID,@BkgParty,@POOID,@POO,@POLID,@POL,@FPODID,@FPOD,@PODID,@POD, " +
                                      " @CommodityTypeID,@CommodityType,@VesVoyID,@VesVoy,@ShipperID,@Shipper,@AgentID, @UserID,@CurrentDate,@DestinationAgent,@DestinationAgentID,@DirectImport,@BkgStatus) " +
                                      " END  " +
                                      " ELSE " +
                                      " UPDATE NVO_Booking SET BookingNo=@BookingNo,BkgDate=@BkgDate,BkgPartyID=@BkgPartyID,BkgParty=@BkgParty,POOID=@POOID,POO=@POO,POLID=@POLID,POL=@POL,FPODID=@FPODID,FPOD=@FPOD,PODID=@PODID,POD=@POD," +
                                      " CommodityTypeID=@CommodityTypeID,CommodityType=@CommodityType,VesVoyID=@VesVoyID,VesVoy=@VesVoy,ShipperID=@ShipperID,Shipper=@Shipper,AgentID=@AgentID, UserID=@UserID,CurrentDate=@CurrentDate," +
                                      " DestinationAgent=@DestinationAgent,DestinationAgentID=@DestinationAgentID,DirectImport=@DirectImport,BkgStatus=@BkgStatus where  ID=@ID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingNo", Data.BookingNo));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgDate", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgPartyID", Data.BkgPartyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgParty", Data.BkgParty));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POO", Data.POO));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", Data.POL));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", Data.POD));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FPOD", Data.FPOD));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", Data.CommodityTypeID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityType", Data.CommodityType));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", Data.ShipperID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.Shipper));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", Data.AgentID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationAgent", Data.DestinationAgent));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationAgentID", Data.DestinationAgentID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DirectImport", 2));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgStatus", 1));


                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                            if (Data.BkgID == 0)
                            {
                                Cmd.CommandText = "select ident_current('NVO_Booking')";
                                Data.BkgID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                                Cmd.CommandText = "select DirectImport from NVO_Booking where ID=" + Data.BkgID;
                                Data.DirectImport = Cmd.ExecuteScalar().ToString();
                            }
                            else
                                Data.BkgID = Data.BkgID;
                        }
                        DataTable _dtAddColum = new DataTable();
                        _dtAddColum.Columns.Add("PartyID");
                        _dtAddColum.Columns.Add("PartyTypeID");


                        _dtAddColum.Rows.Add(_dtAddColum.NewRow());
                        _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyID"] = Data.ShipperID;
                        _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyTypeID"] = 1;
                        _dtAddColum.Rows.Add(_dtAddColum.NewRow());
                        _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyID"] = Data.ConsigneeID;
                        _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyTypeID"] = 2;
                        _dtAddColum.Rows.Add(_dtAddColum.NewRow());
                        _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyID"] = Data.NotifyID;
                        _dtAddColum.Rows[_dtAddColum.Rows.Count - 1]["PartyTypeID"] = 3;


                        Cmd.CommandText = " IF((select count(*) from NVO_BOL where ID=@ID)<=0) " +
                                " BEGIN " +
                                " INSERT INTO  NVO_BOL(BLNumber,BkgID,DesAgentID,SurrenderStatus,BLTypes,MotherBL,ImpFreeDays,FreightPaymentID,CurrentDate, " +
                                                      " POOID,POLID,PODID,FPODID,ShipmentTypeID, " +
                                                      " AgencyID,BLCommodityTypeID,BLDirectImport,BLBkgPartyID,DeliveryType, " +
                                                      " CFS,ImportIHC,NominationCFS,ImpBLVesVoyID,Status,BLDirect,BLVesVoyID,BLVesVoy,PrincipalID) " +
                                " values (@BLNumber,@BkgID,@DesAgentID,@SurrenderStatus,@BLTypes,@MotherBL,@ImpFreeDays,@FreightPaymentID,@CurrentDate, " +
                                                      " @POOID,@POLID,@PODID,@FPODID,@ShipmentTypeID, " +
                                                      " @AgencyID,@BLCommodityTypeID,@BLDirectImport,@BLBkgPartyID,@DeliveryType, " +
                                                      " @CFS,@ImportIHC,@NominationCFS,@ImpBLVesVoyID,@Status,@BLDirect,@BLVesVoyID,@BLVesVoy,@PrincipalID) " +
                                " END  " +
                                " ELSE " +
                                " UPDATE NVO_BOL SET BLNumber=@BLNumber,BkgID=@BkgID,DesAgentID=@DesAgentID,SurrenderStatus=@SurrenderStatus,BLTypes=@BLTypes,MotherBL=@MotherBL,ImpFreeDays=@ImpFreeDays,FreightPaymentID=@FreightPaymentID,CurrentDate=@CurrentDate, " +
                                                      " POOID=@POOID,POLID=@POLID,PODID=@PODID,FPODID=@FPODID,ShipmentTypeID=@ShipmentTypeID, " +
                                                      " AgencyID=@AgencyID,BLCommodityTypeID=@BLCommodityTypeID,BLDirectImport=@BLDirectImport,BLBkgPartyID=@BLBkgPartyID,DeliveryType=@DeliveryType, " +
                                                      " CFS=@CFS,ImportIHC=@ImportIHC,NominationCFS=@NominationCFS,ImpBLVesVoyID=@ImpBLVesVoyID,Status=@Status,BLDirect=@BLDirect,BLVesVoyID=@BLVesVoyID,BLVesVoy=@BLVesVoy,PrincipalID=@PrincipalID where  ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BookingNo));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DesAgentID", Data.DestinationAgentID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofOriginal", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SurrenderStatus", Data.SurrenderID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@MarkNo", ""));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@CagoDescription", ""));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypes", Data.BLTypes));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MotherBL", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpFreeDays", Data.Freedays));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPaymentID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks",""));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", 1));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@ReasonDescription", ""));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoReleaseStatus",0));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@ConfirmedBy", Data.NominationCFS));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledBy", Data.NominationCFS));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelledOn", Data.NominationCFS));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@confirmedOn", Data.NominationCFS));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBLLocked", Data.NominationCFS));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSlotBill", Data.NominationCFS));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoyID", Data.VesVoyID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoy", Data.NominationCFS));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLCommodityTypeID", Data.CommodityTypeID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirectImport", 2));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLBkgPartyID", Data.BkgPartyID));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@HBLNo", Data.HBLNo));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@HBLDate", Data.HBLDate));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryType", Data.DeliveryType));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CFS", Data.CFS));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportIHC", Data.ImportIHC));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NominationCFS", Data.NominationCFS));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpBLVesVoyID", Data.VesVoyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoyID", Data.VesVoyID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLVesVoy", Data.VesVoy));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDirect", 2));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincipalID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        Cmd.CommandText = "select ident_current('NVO_BOL')";
                        if (Data.ID == 0)
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        else
                            Data.ID = Data.ID;

                        for (int z = 0; z < _dtAddColum.Rows.Count; z++)
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_BOLCustomerDetails where BLID=@BLID and PartyTypeID=@PartyTypeID)<=0) " +
                               " BEGIN " +
                               " INSERT INTO  NVO_BOLCustomerDetails(BLID,PartyTypeID,PartID,BkgId) " +
                               " values (@BLID,@PartyTypeID,@PartID,@BkgId) " +
                               " END  " +
                               " ELSE " +
                               " UPDATE NVO_BOLCustomerDetails SET BLID=@BLID,PartyTypeID=@PartyTypeID,PartID=@PartID,BkgId=@BkgId where BLID=@BLID and PartyTypeID=@PartyTypeID";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", _dtAddColum.Rows[z]["PartyTypeID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", _dtAddColum.Rows[z]["PartyID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }

                        string[] ArrayCntr = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayCntr.Length; i++)
                        {
                            var CharSplit = ArrayCntr[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_BOLCntrDetails where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_BOLCntrDetails(BLID,CntrNo,CntrID,Size,ISOCode,SealNo,NoOfPkg,PakgType,PakgTypeName,GrsWt,NtWt,VGM,CBM,BkgId) " +
                                         " values (@BLID,@CntrNo,@CntrID,@Size,@ISOCode,@SealNo,@NoOfPkg,@PakgType,@PakgTypeName,@GrsWt,@NtWt,@VGM,@CBM,@BkgId) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_BOLCntrDetails SET BLID=@BLID,CntrNo=@CntrNo,CntrID=@CntrID,Size=@Size,ISOCode=@ISOCode,SealNo=@SealNo,NoOfPkg=@NoOfPkg,PakgType=@PakgType" +
                                         " ,PakgTypeName=@PakgTypeName,GrsWt=@GrsWt,NtWt=@NtWt,VGM=@VGM,CBM=@CBM,BkgId=@BkgId where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BCNID", CharSplit[0]));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Size", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkg", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgType", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgTypeName", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", CharSplit[9]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWt", CharSplit[10]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[11]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", CharSplit[12]));
                           
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }

                        string[] ArrayVs = Data.ItemsVS.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int y = 1; y < ArrayVs.Length; y++)
                        {
                            var CharSplit1 = ArrayVs[y].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_BOLVoyageDetails where BkgID=@BkgID and LegInformation=@LegInformation)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_BOLVoyageDetails(VoyageTypes,LegInformation,VesVoyID,LoadPort,NextPort,ETA,ETD,BkgID) " +
                                         " values (@VoyageTypes,@LegInformation,@VesVoyID,@LoadPort,@NextPort,@ETA,@ETD,@BkgID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_BOLVoyageDetails SET VoyageTypes=@VoyageTypes,LegInformation=@LegInformation,VesVoyID=@VesVoyID,LoadPort=@LoadPort," +
                                         " NextPort=@NextPort,ETA=@ETA,ETD=@ETD,BkgID=@BkgID where  BkgID=@BkgID and LegInformation=@LegInformation";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                            if (CharSplit1[0] != "undefined")
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@VID", CharSplit1[0]));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@VID", 0));


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageTypes", CharSplit1[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LegInformation", CharSplit1[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", CharSplit1[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPort", CharSplit1[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPort", CharSplit1[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", DateTime.ParseExact(CharSplit1[6], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", DateTime.ParseExact(CharSplit1[7], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }
                  
                    trans.Commit();
                    ListImpBooking.Add(new MyImpBooking
                    {
                        RecordStatus = "Import Booking Successfully Created"
                    });
                    return ListImpBooking;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListImpBooking.Add(new MyImpBooking
                    {
                        RecordStatus = ex.Message
                    });
                    return ListImpBooking;
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

      



        public List<MyImpBooking> BindImpBooking(MyImpBooking Data)
        {
            DataTable dt = GetImpBookingDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpBooking.Add(new MyImpBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ExpID = Int32.Parse(dt.Rows[i]["ExpID"].ToString()),
                    HBLNo = dt.Rows[i]["HBLNo"].ToString(),
                    HBLDate = dt.Rows[i]["HBLDate"].ToString(),
                    DeliveryType = Int32.Parse(dt.Rows[i]["DeliveryType"].ToString()),
                    CFS = dt.Rows[i]["CFS"].ToString(),
                    ImportIHC = dt.Rows[i]["ImportIHC"].ToString(),
                    LineNumber = dt.Rows[i]["LineNumber"].ToString(),
                    NominationCFS= dt.Rows[i]["NominationCFS"].ToString(),
                    ShipperID = dt.Rows[i]["ShipperID"].ToString(),
                    ConsigneeID = dt.Rows[i]["ConsigneeID"].ToString(),
                    NotifyID = dt.Rows[i]["NotifyID"].ToString(),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    SurrenderID = dt.Rows[i]["SurrenderID"].ToString(),
                    Freedays =  dt.Rows[i]["Freedays"].ToString(),
                    VesVoyID = dt.Rows[i]["Freedays"].ToString(),


                });
            }
            return ListImpBooking;
        }
        public DataTable GetImpBookingDtls(MyImpBooking Data)
        {
            string _Query = "select ID, ExpID, HBLNo, convert(varchar,HBLDate, 23) as HBLDate,DeliveryType, " +
                            " CFS,ImportIHC,LineNumber,NominationCFS,ShipperID,ConsigneeID,NotifyID,DestinationAgentID,SurrenderID,Freedays,VesVoyID from NVO_ImpBooking where ExpID = " + Data.ExpID;
            return GetViewData(_Query, "");
        }


        public List<MyImpBooking> BOLVesselVoyageValus(MyImpBooking Data)
        {
            List<MyImpBooking> ViewList = new List<MyImpBooking>();
            DataTable dt = GetImpExtVesVoyageDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyImpBooking
                {
                    VoyageTypes = "77",
                    LegInformation = "74",
                    VesVoy = dt.Rows[i]["ID"].ToString(),
                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()

                }) ;
            }
            return ViewList;
        }

        public DataTable GetImpExtVesVoyageDtls(MyImpBooking Data)
        {
            string _Query = " select NVO_VoyageDetails.ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID) +' -' + VoyageNo as VesVoy,  " +
                            " CurrentPortID,(select top(1) NextPortID from NVO_VoyPortDtls where VoydtID = NVO_VoyageDetails.Id) as NextPortID, " +
                            " convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD from NVO_VoyageDetails " +
                            " inner join NVO_ImpBooking on NVO_ImpBooking.vesVoyID = NVO_VoyageDetails.ID " +
                            " where NVO_ImpBooking.ExpID =" + Data.ExpID;
            return GetViewData(_Query, "");
        }




        public List<MyImpBooking> ExistingDOGirdBooking(MyImpBooking Data)
        {
            DataTable dt = GetExistingDOgridBookingDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpBooking.Add(new MyImpBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DONumber = dt.Rows[i]["DONo"].ToString(),
                    BookingNo = dt.Rows[i]["BLNumber"].ToString(),
                    ReleaseTo = dt.Rows[i]["Release"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    //CFS = dt.Rows[i]["CFS"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    IssueDate = dt.Rows[i]["IssueDate"].ToString(),
                   // ValidityDate = dt.Rows[i]["ValidityDate"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString()


                });
            }
            return ListImpBooking;
        }

        public DataTable GetExistingDOgridBookingDtls(MyImpBooking Data)
        {
            //string _Query = " select ID, DONo,(select top(1) BookingNo from NVO_Booking where Id = BkgID) as Booking, " +
            //                " (select top(1) CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = ReleaseTo) as ReleaseTo, " +
            //                " (select top(1) VesVoy from NVO_Booking where ID = BkgID) as VesVoy,convert(varchar, ETA, 103) as ETA, " +
            //                " (select top(1) CFS from NVO_ImpBooking where ExpID = BkgID) as CFS, " +
            //                " convert(varchar, IssueDate, 103) as IssueDate ,convert(varchar, ValidityDate, 103) as ValidityDate, " +
            //                " case  when StatusID = 1 then 'Final' else 'DRAFT' end Status, '' as UserName " +
            //                " from NVO_ImpDeliveryOrder where BLID = " + Data.ExpID;

            string _Query = "  select NVO_ImpDeliveryOrder.ID, DONo,BLNumber, ReleaseTo,(select top(1) CustomerName from NVO_CustomerMaster where ID = ReleaseTo) as Release, " +
                            " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) +' -' + (select top(1) ImportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_VoyageOpenBLdtls.VoyageID) as VesVoy,  " +
                            " convert(varchar, NVO_ImpDeliveryOrder.ETA, 23) as ETA,  convert(varchar, IssueDate, 103) as IssueDate , " +
                            " case  when StatusID = 1 then 'Active' else 'Cancelled' end Status, '' as UserName " +
                            " from NVO_ImpDeliveryOrder " +
                            " inner join NVO_BOL on NVO_BOL.ID = NVO_ImpDeliveryOrder.BLID " +
                            " inner join NVO_VoyageOpenBLdtls on NVO_VoyageOpenBLdtls.BLID = NVO_BOL.ID " +
                            " inner join NVO_Voyage on NVO_Voyage.ID = NVO_VoyageOpenBLdtls.VoyageID  where NVO_BOL.ID=" + Data.ExpID;
            return GetViewData(_Query, "");
        }


        public List<MYImpDeliveryOrder> ExisImpDOvalues(MYImpDeliveryOrder Data)
        {
            DataTable dt = GetExistDODtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpDO.Add(new MYImpDeliveryOrder
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DONo = dt.Rows[i]["DONo"].ToString(),
                    IssueDate = dt.Rows[i]["IssueDate"].ToString(),
                    //ValidityDate = dt.Rows[i]["ValidityDate"].ToString(),
                    CHAImport = dt.Rows[i]["CHAImport"].ToString(),
                    ReturnDepo = dt.Rows[i]["ReturnDepo"].ToString(),
                    ReleaseTo = dt.Rows[i]["ReleaseTo"].ToString(),
                    ConsigneeID = dt.Rows[i]["ConsigneeID"].ToString(),
                    ForwarderID = dt.Rows[i]["ForwarderID"].ToString(),
                    SurveyorID = dt.Rows[i]["SurveyorID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    StatusID  = dt.Rows[i]["StatusID"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString()

                });
            }
            return ListImpDO;
        }

        public DataTable GetExistDODtls(MYImpDeliveryOrder Data)
        {
            string _Query = " Select ID,DONo,convert(varchar, IssueDate, 23) as IssueDate,CHAImport,ReturnDepo," +
                           " Remarks,ReleaseTo,ConsigneeID,SurveyorID,ForwarderID,StatusID,convert(varchar, ETA, 23) as ETA,Remarks from NVO_ImpDeliveryOrder where ID=" + Data.ID + " and BLID=" + Data.ExpID;
            return GetViewData(_Query, "");
        }

        public List<MyImpCAN> InsertImpCAN(MyImpCAN Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ImpCAN where BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpCAN(IGMNo,IGMDate,SignAsAgent,ReleaseTo,LineNumber,BkgID,BLID) " +
                                     " values (@IGMNo,@IGMDate,@SignAsAgent,@ReleaseTo,@LineNumber,@BkgID,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpCAN SET IGMNo=@IGMNo,IGMDate=@IGMDate,SignAsAgent=@SignAsAgent,ReleaseTo=@ReleaseTo,LineNumber=@LineNumber,BkgID=@BkgID,BLID=@BLID where BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMNo", Data.IGMNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", Data.IGMDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SignAsAgent", Data.SignAsAgent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReleaseTo", Data.ReleaseTo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LineNumber", Data.LineNumber));
                    r1 = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    ListImpCAN.Add(new MyImpCAN
                    {
                        BLID = Data.BLID,
                        Message = "Import CAN Successfully"
                    });
                    return ListImpCAN;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListImpCAN.Add(new MyImpCAN
                    {
                        Message = ex.Message
                    });
                    return ListImpCAN;
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

        public List<MyImpCAN> BindImpCAN(MyImpCAN Data)
        {
            DataTable dt = GetImpCANDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpCAN.Add(new MyImpCAN
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ExpID = Int32.Parse(dt.Rows[i]["ExpID"].ToString()),
                    IGMNo = dt.Rows[i]["IGMNo"].ToString(),
                    IGMDate = dt.Rows[i]["IGMDate"].ToString(),
                    SignAsAgent = dt.Rows[i]["SignAsAgent"].ToString(),
                    ReleaseTo = dt.Rows[i]["ReleaseTo"].ToString(),
                    ContainerNos = dt.Rows[i]["ContainerNos"].ToString(),
                    LineNumber= dt.Rows[i]["LineNumber"].ToString()

                });
            }
            return ListImpCAN;
        }
        public DataTable GetImpCANDtls(MyImpCAN Data)
        {
            string _Query = "select ID,ExpID,IGMNo,convert(varchar, IGMDate, 23) as IGMDate,SignAsAgent,ReleaseTo,ContainerNos,LineNumber from NVO_ImpCAN where ExpID = " + Data.ExpID;
            return GetViewData(_Query, "");
        }

        public List<MyImpCAN> BindImpContainerDetails(MyImpCAN Data)
        {
            DataTable dt = GetImpContainerDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpCAN.Add(new MyImpCAN
                {

                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["Size"].ToString(),


                });
            }
            return ListImpCAN;
        }

        public DataTable GetImpContainerDetails(MyImpCAN Data)
        {
            //string _Query = " select distinct  CntrNo, (select Type + '-' + Size as CntrTypes from NVO_tblCntrTypes where ID = TypeID)  as CntrTypes from NVO_ContainerTxns  " +
            //                " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
            //                " where BLNumber = " + Data.ExpID + " and NVO_ContainerTxns.VesVoyID = " + Data.VesVoyID;
            //string _Query = " select distinct  CntrNo, (select Type + '-' + Size as CntrTypes from NVO_tblCntrTypes where ID = TypeID)  as CntrTypes from NVO_ContainerTxns  " +
            //              " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
            //              " where BLNumber = " + Data.ExpID;

            string _Query = "select (select top(1) CntrNo from NVO_Containers where ID = CntrID) as CntrNo,Size  from NVO_BOLCntrDetails where BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MyImpCAN> BindImpDOContainerDetails(MyImpCAN Data)
        {
            DataTable dt = GetImpDOContainerDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpCAN.Add(new MyImpCAN
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypes"].ToString(),
                    IsTrue = dt.Rows[i]["IsTrue"].ToString(),
                    IsFinal = dt.Rows[i]["IsFinal"].ToString(),
                    DONumber = dt.Rows[i]["DONo"].ToString(),
                    DOID = dt.Rows[i]["DOID"].ToString(),
                    ValidityDate = dt.Rows[i]["ValidityDate"].ToString()

                });
            }
            return ListImpCAN;
        }

        public DataTable GetImpDOContainerDetails(MyImpCAN Data)
        {
      
            string _Query = " select CntrID as ID, (select top(1) CntrNo from NVO_Containers where ID = CntrID) as CntrNo, " +
                            " (select top(1) DONo from NVO_ImpDeliveryOrder " +
                            " inner join NVO_BOLDOCntrdtls on NVO_BOLDOCntrdtls.DoID = NVO_ImpDeliveryOrder.ID where NVO_BOLDOCntrdtls.CntrID = NVO_BOLCntrDetails.CntrID " +
                            " and NVO_BOLDOCntrdtls.BLID = NVO_BOLCntrDetails.BLID and NVO_ImpDeliveryOrder.StatusID=1) as DONo, " +
                            " (select top(1) convert(varchar,ValidityDate, 103) from NVO_ImpDeliveryOrder " +
                            " inner join NVO_BOLDOCntrdtls on NVO_BOLDOCntrdtls.DoID = NVO_ImpDeliveryOrder.ID where NVO_BOLDOCntrdtls.CntrID = NVO_BOLCntrDetails.CntrID " +
                            " and NVO_BOLDOCntrdtls.BLID = NVO_BOLCntrDetails.BLID) as ValidityDate1, " +
                            " (select top(1) convert(varchar, (DtMovement + 14), 23) from NVO_ContainerTxns where ContainerID= NVO_BOLCntrDetails.CntrID and StatusCode = 'FV' and BLNumber = NVO_BOLCntrDetails.BkgId) as ValidityDate," +
                            " case when(select top(1) DoID from NVO_viewImpDOCntrDetails where NVO_viewImpDOCntrDetails.CntrID = NVO_BOLCntrDetails.CntrID and NVO_viewImpDOCntrDetails.BLID = NVO_BOLCntrDetails.BLID and NVO_viewImpDOCntrDetails.StatusID=1) != '' then 'true' else 'false' end IsFinal, " +
                            " (select top(1) DoID from NVO_BOLDOCntrdtls where NVO_BOLDOCntrdtls.CntrID = NVO_BOLCntrDetails.CntrID and NVO_BOLDOCntrdtls.BLID = NVO_BOLCntrDetails.BLID) as DOID,  " +
                            " case when(select top(1) CntrID from NVO_viewImpDOCntrDetails where NVO_viewImpDOCntrDetails.CntrID = NVO_BOLCntrDetails.CntrID and NVO_viewImpDOCntrDetails.BLID = NVO_BOLCntrDetails.BLID and NVO_viewImpDOCntrDetails.StatusID=1) != '' then 1 else 0 end as IsTrue, " +
                            " (select(select  top(1) Type + '-' + Size as CntrTypes from NVO_tblCntrTypes where ID = TypeID) from NVO_Containers where ID = NVO_BOLCntrDetails.CntrID) as CntrTypes " +
                            " from NVO_BOLCntrDetails " +
                            " where NVO_BOLCntrDetails.BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MyImpCAN> BindImpExistDOContainerDetails(MyImpCAN Data)
        {
            DataTable dt = GetImpExistDOContainerDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpCAN.Add(new MyImpCAN
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypes"].ToString(),
                    IsTrue = dt.Rows[i]["IsTrue"].ToString(),
                    IsFinal = dt.Rows[i]["IsFinal"].ToString(),
                    DONumber = dt.Rows[i]["DONo"].ToString(),
                    ValidityDate= dt.Rows[i]["ValidityDate"].ToString()



                });
            }
            return ListImpCAN;
        }

        public DataTable GetImpExistDOContainerDetails(MyImpCAN Data)
        {

            string _Query = " select CntrID as ID, (select top(1) CntrNo from NVO_Containers where ID = NVO_BOLDOCntrdtls.CntrID) as CntrNo, " +
                            " (select top(1) DONo from NVO_ImpDeliveryOrder " +
                            " inner join NVO_BOLDOCntrdtls on NVO_BOLDOCntrdtls.DoID = NVO_ImpDeliveryOrder.ID) as DONo," +
                            " (select top(1) convert(varchar,ValidityDate, 23) from NVO_ImpDeliveryOrder " +
                            " inner join NVO_BOLDOCntrdtls on NVO_BOLDOCntrdtls.DoID = NVO_ImpDeliveryOrder.ID) as ValidityDate," +
                            " 'true' as IsFinal,DOID,1 as IsTrue, " +
                            " (select(select  top(1) Type + '-' + Size as CntrTypes from NVO_tblCntrTypes where ID = TypeID) from NVO_Containers " +
                            " where ID = NVO_BOLDOCntrdtls.CntrID) as CntrTypes from NVO_BOLDOCntrdtls where BLID=" + Data.BLID + " and DoID=" + Data.DOID;

            return GetViewData(_Query, "");
        }

        public List<MYImpDeliveryOrder> InsertImpDO(MYImpDeliveryOrder Data)
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

                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("ImpDO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'DO' +  ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)" + "+''+" + "('" + Data.AgentCode + "')";
                        Data.DONo = Cmd.ExecuteScalar().ToString();
                    }


                    Cmd.CommandText = " IF((select count(*) from NVO_ImpDeliveryOrder where ID=@ID and BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpDeliveryOrder(BkgID,DONo,IssueDate,CHAImport,ReturnDepo,Remarks,ReleaseTo,ConsigneeID,SurveyorID,ForwarderID,StatusID,ETA,BLID) " +
                                     " values (@BkgID,@DONo,@IssueDate,@CHAImport,@ReturnDepo,@Remarks,@ReleaseTo,@ConsigneeID,@SurveyorID,@ForwarderID,@StatusID,@ETA,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpDeliveryOrder SET BkgID=@BkgID,DONo=@DONo,IssueDate=@IssueDate,CHAImport=@CHAImport,ReturnDepo=@ReturnDepo,Remarks=@Remarks,ReleaseTo=@ReleaseTo," +
                                     " ConsigneeID=@ConsigneeID,SurveyorID=@SurveyorID,ForwarderID=@ForwarderID,StatusID=@StatusID,ETA=@ETA,BLID=@BLID where ID=@ID and BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DoNo", Data.DONo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IssueDate", Data.IssueDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CHAImport", Data.CHAImport));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReturnDepo", Data.ReturnDepo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ReleaseTo", Data.ReleaseTo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeID", Data.ConsigneeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SurveyorID", Data.SurveyorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ForwarderID", Data.ForwarderID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", DateTime.ParseExact(Data.ETA, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@DoStatus", 1));


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "select ident_current('NVO_ImpDeliveryOrder')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_BOLDOCntrdtls where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID and DOID=@DOID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_BOLDOCntrdtls(CntrID,BLID,BkgId,DOID,ValidityDate) " +
                                     " values (@CntrID,@BLID,@BkgId,@DOID,@ValidityDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_BOLDOCntrdtls SET CntrID=@CntrID,BLID=@BLID,BkgId=@BkgId,DOID=@DOID,ValidityDate=@ValidityDate where CntrID=@CntrID and BLID=@BLID and BkgID=@BkgID and DOID=@DOID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidityDate", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DOID", Data.ID));
                       

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }





                    trans.Commit();
                    ListImpDO.Add(new MYImpDeliveryOrder
                    {
                        StatusAlery = "DO Number Create Successfully"
                    }) ;
                  
                    return ListImpDO;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListImpDO.Add(new MYImpDeliveryOrder
                    {
                        StatusAlery =ex.Message
                    });
                    return ListImpDO;
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


        public List<MYImpDeliveryOrder> UpdateDOExistingImpDO(MYImpDeliveryOrder Data)
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

                    Cmd.CommandText = "update NVO_ImpDeliveryOrder set StatusID=@StatusID where ID=@ID"; 
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    ListImpDO.Add(new MYImpDeliveryOrder
                    {
                        StatusAlery = "Do Cancelled Cucessfully"
                    }); ;

                    return ListImpDO;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListImpDO.Add(new MYImpDeliveryOrder
                    {
                        StatusAlery = ex.Message
                    });
                    return ListImpDO;
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

        public List<MYImpDeliveryOrder> BindImpDO(MYImpDeliveryOrder Data)
        {
            DataTable dt = GetImpDODtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImpDO.Add(new MYImpDeliveryOrder
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ExpID = Int32.Parse(dt.Rows[i]["ExpID"].ToString()),
                    DONo = dt.Rows[i]["DONo"].ToString(),
                    IssueDate = dt.Rows[i]["IssueDate"].ToString(),
                    ValidityDate = dt.Rows[i]["ValidityDate"].ToString(),
                    CHAImport = dt.Rows[i]["CHAImport"].ToString(),
                    ReturnDepo = dt.Rows[i]["ReturnDepo"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    ATA = dt.Rows[i]["ATA"].ToString()

                });
            }
            return ListImpDO;
        }
        public DataTable GetImpDODtls(MYImpDeliveryOrder Data)
        {
            string _Query = "select * " +
                            " from NVO_ImpDeliveryOrder where ExpID = " + Data.ExpID;
            return GetViewData(_Query, "");
        }


        public List<MYImpDeliveryOrder> ExisingDOCheckBeforeInsert(MYImpDeliveryOrder Data)
        {
            DataTable dt = GetImpDOCheckExstingVlueDtls(Data);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CntrID"].ToString() != "0")
                {
                    ListImpDO.Add(new MYImpDeliveryOrder
                    {
                        StatusAlery = "Existing"

                    });
                }
                else
                {
                    ListImpDO.Add(new MYImpDeliveryOrder
                    {
                        StatusAlery = "New"

                    });
                }
            }
            else
            {
                ListImpDO.Add(new MYImpDeliveryOrder
                {
                    StatusAlery = "New"

                });
            }
            return ListImpDO;
        }


        public DataTable GetImpDOCheckExstingVlueDtls(MYImpDeliveryOrder Data)
        {
            string _Query = " select count(CntrID) as CntrID from NVO_BOLDOCntrdtls inner join NVO_ImpDeliveryOrder on NVO_ImpDeliveryOrder.ID = NVO_BOLDOCntrdtls.DoID " +
                            " where StatusID = 1 and CntrID in (" + Data.CntrID + ") and  StatusID= 1 and NVO_ImpDeliveryOrder.BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }

        public List<MYDETCalculation> ImpDETContainer(MYDETCalculation Data)
        {
            List<MYDETCalculation> ViewList = new List<MYDETCalculation>();
            DataTable dt = GetImpDETContainer(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYDETCalculation
                {
                    ID = dt.Rows[i]["ContID"].ToString(),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    BLNo = dt.Rows[i]["BLNo"].ToString(),
                    SizeType = dt.Rows[i]["size"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    StartMove = dt.Rows[i]["STMove"].ToString(),
                    StartDate = dt.Rows[i]["STDate"].ToString(),
                    EndMove = dt.Rows[i]["EDMove"].ToString(),
                    EndDate = dt.Rows[i]["EDDate"].ToString(),
                    TillDate = dt.Rows[i]["TillDate"].ToString(),
                    Days = dt.Rows[i]["Age"].ToString(),
                    FreeDay = dt.Rows[i]["FreeDays"].ToString(),
                    PortFreeDay = dt.Rows[i]["PortFreeDay"].ToString(),
                    ChargebleDays = dt.Rows[i]["ChargebleDays"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetImpDETContainer(MYDETCalculation Data)
        {

            string _Query = " select BkgId,CntrID,BLNo,CntrNo,size,ContID,ChargeCode,STMove,STDate,EDMove,EDDate,case when EDDate != ''  then null else TillDate end as TillDate,PortFreeDay,isnull(Age+1,0)as Age,FreeDays,Currency, " +
                            " (isnull(Age+1, 0) - isnull(PortFreeDay, 0) - FreeDays) as ChargebleDays,ExRate " +
                            " from NVO_V_CntrDetentionCalculation where AgencyID= "+ Data.AgencyID + " and ShipmentTypeID =" + Data.ShipmentTypeID + " and BkgId=" + Data.BkgID + " and BLID=" + Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MYDETCalculation> ImpDETContainerSearch(MYDETCalculation Data)
        {
            string TillDatev = "";
            List<MYDETCalculation> ViewList = new List<MYDETCalculation>();
            DataTable dt = GetImpDETContainerSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Data.TillDate != "")
                {
                    if (dt.Rows[i]["EDDate"].ToString() == "")
                        TillDatev = DateTime.Parse(Data.TillDate).ToString("dd/MM/yyyy");
                    else
                        TillDatev = dt.Rows[i]["TillDate"].ToString();
                }
                else
                {
                    TillDatev = dt.Rows[i]["TillDate"].ToString();
                }

                ViewList.Add(new MYDETCalculation
                {
                    ID = dt.Rows[i]["ContID"].ToString(),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    BLNo = dt.Rows[i]["BLNo"].ToString(),
                    SizeType = dt.Rows[i]["size"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    StartMove = dt.Rows[i]["STMove"].ToString(),
                    StartDate = dt.Rows[i]["STDate"].ToString(),
                    EndMove = dt.Rows[i]["EDMove"].ToString(),
                    EndDate = dt.Rows[i]["EDDate"].ToString(),
                    TillDate = TillDatev,
                    Days = dt.Rows[i]["Age"].ToString(),
                    FreeDay = dt.Rows[i]["FreeDays"].ToString(),
                    ImpFreeDays = dt.Rows[i]["ImpFreeDays"].ToString(),

                    PortFreeDay = dt.Rows[i]["PortFreeDay"].ToString(),
                    ChargebleDays = dt.Rows[i]["ChargebleDays"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),
                    IsTrue = dt.Rows[i]["IsTrue"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    ChargebleAmt = dt.Rows[i]["ChargebleAmt"].ToString(),
                    WaiverAmt = dt.Rows[i]["WaiverAmt"].ToString(),
                    AccountableAmt = dt.Rows[i]["WaiverAmt"].ToString(),
                    ImpChargebleDays = dt.Rows[i]["ImpChargebleDays"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetImpDETContainerSearch(MYDETCalculation Data)
        {
            string strWhere = "";
            string _Query = " select BkgId,CntrID,BLNo,CntrNo,size,ContID,ChargeCode,STMove,STDate,EDMove,EDDate,case when EDDate != ''  then null else TillDate end as TillDate,PortFreeDay,isnull(Age+1,0)as Age,FreeDays,ImpFreeDays, " +
                            " (isnull(Age+1, 0) - isnull(PortFreeDay, 0) - FreeDays) as ChargebleDays,(isnull(Age+1, 0) - isnull(PortFreeDay, 0) - ImpFreeDays) as ImpChargebleDays,ExRate,IsTrue,Currency, 0 as ChargebleAmt,0 as WaiverAmt,0 as AccountableAmt " +
                            " from NVO_V_CntrDetentionCalculation";

            strWhere += _Query + " where AgencyID= " + Data.AgencyID + " and  ShipmentTypeID=" + Data.ShipmentTypeID + " and BkgId=" + Data.BkgID + " and BLID =" + Data.BLID;

            //if (Data.CntrID != "?")
            //    if (strWhere == "")
            //        strWhere += _Query + " where CntrID=" + Data.CntrID;
            //    else
            //        strWhere += " and CntrID=" + Data.CntrID;

            if (Data.ChargeCodeID != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " where ChargesID=" + Data.ChargeCodeID;
                else
                    strWhere += " and ChargesID=" + Data.ChargeCodeID;
            }

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

           
        }

        public List<MYDETCalculation> ImpDETCalculationSlab(MYDETCalculation Data)
        {
            DateTime IncreamentalFromDt, FromDt;
            DateTime IncrementalToDt, ToDt;
            string ID = "";
            string LLimit = "";
            string ULimit = "";
            string Currency = "";
            string Amount = "";
            string FDatev = "";
            string TDatev = "";
            int Days = 0, _FreeDays = 0;
            decimal ExRate = 0;
            TimeSpan TMS; bool IsexceedFreedays = false; string WaiverQty = "0";
            List<MYDETCalculation> ViewList = new List<MYDETCalculation>();
            DataTable dt1 = GetDetSlabewiseDate(Data);
            if (dt1.Rows.Count > 0)
            {
                for (int y = 0; y < dt1.Rows.Count; y++)
                {
                    DateTime.TryParse(dt1.Rows[y]["STDate"].ToString(), out IncreamentalFromDt);
                    DateTime.TryParse(dt1.Rows[y]["STDate"].ToString(), out FromDt);
                    // DateTime.TryParse(dt1.Rows[y]["EDDate"].ToString(), out ToDt);
                    if (Data.TillDate == "")
                        DateTime.TryParse(dt1.Rows[0]["EDDate"].ToString(), out ToDt);
                    else
                        DateTime.TryParse(Data.TillDate, out ToDt);


                    ExRate = decimal.Parse(dt1.Rows[y]["ExRate"].ToString());
                    WaiverQty = dt1.Rows[y]["FreeDays"].ToString();
                    int.TryParse(WaiverQty, out _FreeDays);

                    DataTable dt = GetImpDetCalcuationSlabe(Data);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                      
                        ID = dt.Rows[i]["CID"].ToString();
                        LLimit = dt.Rows[i]["SlabFrom"].ToString();
                        ULimit = dt.Rows[i]["SlabTo"].ToString();
                        Currency = dt.Rows[i]["Currency"].ToString();
                        Amount = dt.Rows[i]["Amount"].ToString();
                        FDatev = IncreamentalFromDt.ToShortDateString();
                        IncrementalToDt = FromDt.AddDays(float.Parse(dt.Rows[i]["SlabTo"].ToString()) - 1);
                        TDatev = IncrementalToDt.ToShortDateString();
                        //TMS = IncrementalToDt.Subtract(IncreamentalFromDt);
                        //muthu

                        if (IncrementalToDt >= ToDt || IncrementalToDt < FromDt)
                        {
                            TDatev = ToDt.ToShortDateString();
                            TMS = ToDt.Subtract(IncreamentalFromDt);
                            Days = (int)((TMS.TotalDays + 1));

                            if (!IsexceedFreedays)
                            {
                                TMS = ToDt.Subtract(FromDt);
                                Days = (int)((TMS.TotalDays + 1));
                                Days = Days - _FreeDays;
                                if (Days < 0)
                                    Days = 0;
                                else
                                    IsexceedFreedays = true;
                            }
                            else
                            {
                                TMS = ToDt.Subtract(IncreamentalFromDt);
                                Days = (int)((TMS.TotalDays + 1));
                            }
                        }
                        else
                        {
                            if (!IsexceedFreedays)
                            {
                                TMS = IncrementalToDt.Subtract(FromDt);
                                Days = (int)((TMS.TotalDays + 1));
                                Days = Days - _FreeDays;
                                if (Days < 0)
                                    Days = 0;
                                else
                                    IsexceedFreedays = true;
                            }
                            else
                            {
                                TMS = IncrementalToDt.Subtract(IncreamentalFromDt);
                                Days = (int)((TMS.TotalDays + 1));

                            }
                        }
                        IncreamentalFromDt = IncrementalToDt.AddDays(1);
                        ViewList.Add(new MYDETCalculation
                        {
                            CntrNo = dt1.Rows[y]["CntrNo"].ToString(),
                            ID = dt.Rows[i]["CID"].ToString(),
                            LLimit = dt.Rows[i]["SlabFrom"].ToString(),
                            ULimit = dt.Rows[i]["SlabTo"].ToString(),
                            Currency = dt.Rows[i]["Currency"].ToString(),
                            Amount = dt.Rows[i]["Amount"].ToString(),
                            FDatev = FDatev,
                            TDatev = TDatev,
                            Days = Days.ToString(),
                            Rate = (decimal.Parse(Amount) * decimal.Parse(Days.ToString())).ToString(),
                            TotalAmt = (decimal.Parse(Amount) * decimal.Parse(Days.ToString()) * decimal.Parse(ExRate.ToString())).ToString()

                        });
                        if (DateTime.Parse(TDatev) >= DateTime.Parse((ToDt.ToString("dd/MM/yyyy"))))
                        {
                            break;
                           
                        }
                    }

                }
            }
            return ViewList;
        }

        public DataTable GetDetSlabewiseDate(MYDETCalculation Data)
        {
            //string _Query = "select CntrNo, STDate, EDDate, ContID,FreeDays,(select top(1) Rate from NVO_ExRate order by Id desc) as ExRate from NVO_V_CntrDetentionCalculation where CntrID = " + Data.CntrID;
            //return GetViewData(_Query, "");

            string _Query = "select CntrNo, STDate, EDDate, ContID,FreeDays,(select top(1) Rate from NVO_ExRate order by Id desc) as ExRate from NVO_V_CntrDetentionCalculation where BLID = "+ Data.BLID +" and CntrID in (" + Data.CntrID.Remove(Data.CntrID.Length - 1) + ")";
            return GetViewData(_Query, "");
        }
        public DataTable GetImpDetCalcuationSlabe(MYDETCalculation Data)
        {
            string _Query = "select CID,SlabFrom,SlabTo,CurrencyID, 'USD' as Currency,Amount from NVO_ContRentTariffDtls where RentID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public DataTable GetDetSlabewiseDateInsert(string BkgID, string CntrNos, string AgencyID, string  ShipmentTypeID)
        {
            string _Query = "select BKGId,CntrID,TypeID,CntrNo, STDate, EDDate,TillDate, ContID,FreeDays,ImpFreeDays,ChargesID,(select top(1) Rate from NVO_ExRate order by Id desc) as ExRate from NVO_V_CntrDetentionCalculation where AgencyID= " + AgencyID + " and  ShipmentTypeID=" + ShipmentTypeID + " and BkgID=" + BkgID + " and CntrID in(" + CntrNos + ")";
            return GetViewData(_Query, "");
        } 

        public DataTable GetImpDetCalcuationSlabeInsert(string ContrID)
        {
            string _Query = "select CID,SlabFrom,SlabTo,CurrencyID, 'USD' as Currency,Amount from NVO_ContRentTariffDtls where RentID=" + ContrID;
            return GetViewData(_Query, "");
        }


        public List<MYImpDDG>ImportDDGInsert(MYImpDDG Data)
        {
            MYImpDDG listDG = new MYImpDDG();

            DataTable _dtColum = new DataTable();
            _dtColum.Columns.Add("BkgID");
            _dtColum.Columns.Add("CntrID");
            _dtColum.Columns.Add("CntrTypeID");
            _dtColum.Columns.Add("LLimitDt");
            _dtColum.Columns.Add("ULimitDt");
            _dtColum.Columns.Add("LLimit");
            _dtColum.Columns.Add("ULimit");
            _dtColum.Columns.Add("Amount", typeof(decimal));
            _dtColum.Columns.Add("Days");
            _dtColum.Columns.Add("Rate");
            _dtColum.Columns.Add("Total");
            _dtColum.Columns.Add("Currency");
            _dtColum.Columns.Add("ExRate");
            _dtColum.Columns.Add("DtCalFrom");
            _dtColum.Columns.Add("DtPaidUpto");
            _dtColum.Columns.Add("ChargeID");

            decimal TotaAmountv = 0;

          

            var BkgId = Data.BkgID;
            var CntrNos = Data.CntrIDs.Remove(Data.CntrIDs.Length - 1);
            string FDatev = "";
            string TDatev = "";
            DataTable dtx = GetDetSlabewiseDateInsert(BkgId, CntrNos,Data.AgencyID, Data.ShipmentTypeID);
            for (int i = 0; i < dtx.Rows.Count; i++)
            {
                DateTime IncreamentalFromDt, FromDt;
                DateTime IncrementalToDt, ToDt;
                string ID = "";
                string LLimit = "";
                string ULimit = "";
                string Currency = "";
                string Amount = "";
                FDatev = "";
                TDatev = "";
                int Days = 0, _FreeDays = 0;
                decimal ExRate = 0;
                TimeSpan TMS; bool IsexceedFreedays = false; string WaiverQty = "0";

                DateTime.TryParse(dtx.Rows[0]["STDate"].ToString(), out IncreamentalFromDt);
                DateTime.TryParse(dtx.Rows[0]["STDate"].ToString(), out FromDt);

                //if (Data.TillDate == "")
                //    DateTime.TryParse(dtx.Rows[0]["EDDate"].ToString(), out ToDt);
                //else
                //    DateTime.TryParse(Data.TillDate, out ToDt);
                if (dtx.Rows[0]["EDDate"].ToString() != "")
                    DateTime.TryParse(dtx.Rows[0]["EDDate"].ToString(), out ToDt);
                else
                    DateTime.TryParse(dtx.Rows[0]["TillDate"].ToString(), out ToDt);


                ExRate = decimal.Parse(dtx.Rows[0]["ExRate"].ToString());
                WaiverQty = dtx.Rows[0]["FreeDays"].ToString();
                int.TryParse(WaiverQty, out _FreeDays);

                DataTable dt = GetImpDetCalcuationSlabeInsert(dtx.Rows[i]["ContId"].ToString());
                for (int y = 0; y < dt.Rows.Count; y++)
                {

                    ID = dt.Rows[y]["CID"].ToString();
                    LLimit = dt.Rows[y]["SlabFrom"].ToString();
                    ULimit = dt.Rows[y]["SlabTo"].ToString();
                    Currency = dt.Rows[y]["Currency"].ToString();
                    Amount = dt.Rows[y]["Amount"].ToString();
                    FDatev = IncreamentalFromDt.ToShortDateString();
                    IncrementalToDt = FromDt.AddDays(float.Parse(dt.Rows[y]["SlabTo"].ToString()) - 1);
                    TDatev = IncrementalToDt.ToShortDateString();
                    //TMS = IncrementalToDt.Subtract(IncreamentalFromDt);


                    if (IncrementalToDt >= ToDt || IncrementalToDt < FromDt)
                    {
                        TDatev = ToDt.ToShortDateString();
                        TMS = ToDt.Subtract(IncreamentalFromDt);
                        Days = (int)((TMS.TotalDays + 1));

                        if (!IsexceedFreedays)
                        {
                            TMS = ToDt.Subtract(FromDt);
                            Days = (int)((TMS.TotalDays + 1));
                            Days = Days - _FreeDays;
                            if (Days < 0)
                                Days = 0;
                            else
                                IsexceedFreedays = true;
                        }
                        else
                        {
                            TMS = ToDt.Subtract(IncreamentalFromDt);
                            Days = (int)((TMS.TotalDays + 1));
                        }
                    }
                    else
                    {
                        if (!IsexceedFreedays)
                        {
                            TMS = IncrementalToDt.Subtract(FromDt);
                            Days = (int)((TMS.TotalDays + 1));
                            Days = Days - _FreeDays;
                            if (Days < 0)
                                Days = 0;
                            else
                                IsexceedFreedays = true;
                        }
                        else
                        {
                            TMS = IncrementalToDt.Subtract(IncreamentalFromDt);
                            Days = (int)((TMS.TotalDays + 1));

                        }
                    }
                    IncreamentalFromDt = IncrementalToDt.AddDays(1);

                    _dtColum.Rows.Add(_dtColum.NewRow());
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["BkgID"] = dtx.Rows[i]["BKGId"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["CntrID"] = dtx.Rows[i]["CntrID"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["CntrTypeID"] = dtx.Rows[i]["TypeID"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ChargeID"] = Data.ChargeID;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["DtCalFrom"] = dtx.Rows[i]["STDate"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["DtPaidUpto"] = ToDt;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ExRate"] = dtx.Rows[i]["ExRate"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Currency"] = dt.Rows[i]["Currency"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["LLimit"] = dt.Rows[y]["SlabFrom"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ULimit"] = dt.Rows[y]["SlabTo"].ToString();

                    _dtColum.Rows[_dtColum.Rows.Count - 1]["LLimitDt"] = FDatev;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ULimitDt"] = TDatev;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Amount"] = decimal.Parse(dt.Rows[y]["Amount"].ToString());
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Days"] = Days.ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Rate"] = (decimal.Parse(Amount) * decimal.Parse(Days.ToString())).ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Total"] = (decimal.Parse(Amount) * decimal.Parse(Days.ToString()) * decimal.Parse(ExRate.ToString())).ToString();

                    TotaAmountv += (decimal.Parse(Amount) * decimal.Parse(Days.ToString()) * decimal.Parse(ExRate.ToString()));
                    if (DateTime.Parse(TDatev) >= DateTime.Parse((ToDt.ToString("dd/MM/yyyy"))))
                    {
                        break;

                    }
                }

            }
            


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
                    DataView view1 = new DataView(_dtColum);
                    DataTable disBL = view1.ToTable(true, "BkgID", "CntrID", "ExRate", "DtCalFrom", "DtPaidUpto", "ChargeID", "CntrTypeID");

                    for (int z = 0; z < disBL.Rows.Count; z++)
                    {

                        Cmd.CommandText = " IF((select count(*) from NVO_ImpBLDDGCharges where CntrID=@CntrID and BkgID=@BkgID and ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpBLDDGCharges(BKgID,CntrID,DtCalFrom,DtPaidUpto,TotalAmount,ExRate,ChargeID,CntrTypeID,BLID,InclHolidays,DtnAmtx,DemAmtx,GrdAmtx,InvDtnAmtx,InvDemAmtx,InvGrdAmtx) " +
                                     " values (@BKgID,@CntrID,@DtCalFrom,@DtPaidUpto,@TotalAmount,@ExRate,@ChargeID,@CntrTypeID,@BLID,@InclHolidays,@DtnAmtx,@DemAmtx,@GrdAmtx,@InvDtnAmtx,@InvDemAmtx,@InvGrdAmtx) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpBLDDGCharges SET BKgID=@BKgID,CntrID=@CntrID,DtCalFrom=@DtCalFrom,DtPaidUpto=@DtPaidUpto," +
                                     " TotalAmount=@TotalAmount,ExRate=@ExRate,ChargeID=@ChargeID,CntrTypeID=@CntrTypeID,BLID=@BLID,InclHolidays=@InclHolidays,DtnAmtx=@DtnAmtx,DemAmtx=@DemAmtx,GrdAmtx=@GrdAmtx,InvDtnAmtx=@InvDtnAmtx,InvDemAmtx=@InvDemAmtx,InvGrdAmtx=@InvGrdAmtx where CntrID=@CntrID and BkgID=@BkgID and ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BKgID", disBL.Rows[z]["BkgID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", disBL.Rows[z]["CntrID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", disBL.Rows[z]["ChargeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", disBL.Rows[z]["CntrTypeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCalFrom", DateTime.Parse(disBL.Rows[z]["DtCalFrom"].ToString()).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidUpto", DateTime.Parse(disBL.Rows[z]["DtPaidUpto"].ToString()).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalAmount", TotaAmountv));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", disBL.Rows[z]["ExRate"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", disBL.Rows[z]["BkgID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InclHolidays", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtnAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DemAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrdAmtx", 0));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDtnAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDemAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@invGrdAmtx", 0));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        Cmd.CommandText = "select ident_current('NVO_ImpBLDDGCharges')";
                        if (Data.ID == 0)
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        else
                            Data.ID = Data.ID;

                        DataTable _dtx = _dtColum.Select("BKgID=" + disBL.Rows[z]["BkgID"].ToString() + " and CntrID=" + disBL.Rows[z]["CntrID"].ToString()).CopyToDataTable();
                        for (int k = 0; k < _dtx.Rows.Count; k++)
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_ImpBLDDGChargedtls where CntrID=@CntrID and BkgID=@BkgID and DDGID=@DDGID and LLimit=@LLimit)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpBLDDGChargedtls(DDGID,BKgID,CntrID,CntrTypeID,LLimitDt,ULimitDt,LLimit,ULimit,Rate,CurrID,Days,Amount,Total,ExRate) " +
                                     " values (@DDGID,@BKgID,@CntrID,@CntrTypeID,@LLimitDt,@ULimitDt,@LLimit,@ULimit,@Rate,@CurrID,@Days,@Amount,@Total,@ExRate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpBLDDGChargedtls SET DDGID=@DDGID,BKgID=@BKgID,CntrID=@CntrID,CntrTypeID=@CntrTypeID,LLimitDt=@LLimitDt,ULimitDt=@ULimitDt,LLimit=@LLimit,ULimit=@ULimit,Rate=@Rate,CurrID=@CurrID,Days=@Days,Amount=@Amount,Total=@Total,ExRate=@ExRate " +
                                     " Where CntrID=@CntrID and BkgID=@BkgID and DDGID=@DDGID and LLimit=@LLimit";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DDGID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BKgID", _dtx.Rows[k]["BkgID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", _dtx.Rows[k]["CntrID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", _dtx.Rows[k]["CntrTypeID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LLimitDt", DateTime.Parse(_dtx.Rows[k]["LLimitDt"].ToString()).ToString("MM/dd/yyyy")));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ULimitDt", DateTime.Parse(_dtx.Rows[k]["ULimitDt"].ToString()).ToString("MM/dd/yyyy")));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LLimit", decimal.Parse(_dtx.Rows[k]["LLimit"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ULimit", decimal.Parse(_dtx.Rows[k]["ULimit"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Rate", decimal.Parse(_dtx.Rows[k]["Rate"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Days", _dtx.Rows[k]["Days"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", decimal.Parse(_dtx.Rows[k]["Amount"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Total", decimal.Parse(_dtx.Rows[k]["Total"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", decimal.Parse(_dtx.Rows[k]["ExRate"].ToString())));
                           
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrID", 146));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                            
                           
                        }
                    }
                   
                  
                    trans.Commit();
                    List.Add(new MYImpDDG
                    {
                        StatusAlery = "Save"
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


        public List<MYImpDDG> ImportCalculationDDGInsert(MYImpDDG Data)
        {
            MYImpDDG listDG = new MYImpDDG();

            DataTable _dtColum = new DataTable();
            _dtColum.Columns.Add("BkgID");
            _dtColum.Columns.Add("CntrID");
            _dtColum.Columns.Add("CntrTypeID");
            _dtColum.Columns.Add("LLimitDt");
            _dtColum.Columns.Add("ULimitDt");
            _dtColum.Columns.Add("LLimit");
            _dtColum.Columns.Add("ULimit");
            _dtColum.Columns.Add("Amount", typeof(decimal));
            _dtColum.Columns.Add("Days");
            _dtColum.Columns.Add("Rate");
            _dtColum.Columns.Add("Total");
            _dtColum.Columns.Add("Currency");
            _dtColum.Columns.Add("ExRate");
            _dtColum.Columns.Add("DtCalFrom");
            _dtColum.Columns.Add("DtPaidUpto");
            _dtColum.Columns.Add("ChargeID");

            decimal TotaAmountv = 0;



            var BkgId = Data.BkgID;
            var CntrNos = Data.CntrIDs.Remove(Data.CntrIDs.Length - 1);
            string FDatev = "";
            string TDatev = "";
            DataTable dtx = GetDetSlabewiseDateInsert(BkgId, CntrNos, Data.AgencyID, Data.ShipmentTypeID);
            for (int i = 0; i < dtx.Rows.Count; i++)
            {
                DateTime IncreamentalFromDt, FromDt;
                DateTime IncrementalToDt, ToDt;
                string ID = "";
                string LLimit = "";
                string ULimit = "";
                string Currency = "";
                string Amount = "";
                FDatev = "";
                TDatev = "";
                int Days = 0, _FreeDays = 0;
                decimal ExRate = 0;
                TimeSpan TMS; bool IsexceedFreedays = false; string WaiverQty = "0";

                DateTime.TryParse(dtx.Rows[0]["STDate"].ToString(), out IncreamentalFromDt);
                DateTime.TryParse(dtx.Rows[0]["STDate"].ToString(), out FromDt);

                //if (Data.TillDate == "")
                //    DateTime.TryParse(dtx.Rows[0]["EDDate"].ToString(), out ToDt);
                //else
                //    DateTime.TryParse(Data.TillDate, out ToDt);
                if (dtx.Rows[0]["EDDate"].ToString() != "")
                    DateTime.TryParse(dtx.Rows[0]["EDDate"].ToString(), out ToDt);
                else
                    DateTime.TryParse(dtx.Rows[0]["TillDate"].ToString(), out ToDt);


                ExRate = decimal.Parse(dtx.Rows[0]["ExRate"].ToString());
                WaiverQty = dtx.Rows[0]["ImpFreeDays"].ToString();
                int.TryParse(WaiverQty, out _FreeDays);

                DataTable dt = GetImpDetCalcuationSlabeInsert(dtx.Rows[i]["ContId"].ToString());
                for (int y = 0; y < dt.Rows.Count; y++)
                {

                    ID = dt.Rows[y]["CID"].ToString();
                    LLimit = dt.Rows[y]["SlabFrom"].ToString();
                    ULimit = dt.Rows[y]["SlabTo"].ToString();
                    Currency = dt.Rows[y]["Currency"].ToString();
                    Amount = dt.Rows[y]["Amount"].ToString();
                    FDatev = IncreamentalFromDt.ToShortDateString();
                    IncrementalToDt = FromDt.AddDays(float.Parse(dt.Rows[y]["SlabTo"].ToString()) - 1);
                    TDatev = IncrementalToDt.ToShortDateString();
                    //TMS = IncrementalToDt.Subtract(IncreamentalFromDt);


                    if (IncrementalToDt >= ToDt || IncrementalToDt < FromDt)
                    {
                        TDatev = ToDt.ToShortDateString();
                        TMS = ToDt.Subtract(IncreamentalFromDt);
                        Days = (int)((TMS.TotalDays + 1));

                        if (!IsexceedFreedays)
                        {
                            TMS = ToDt.Subtract(FromDt);
                            Days = (int)((TMS.TotalDays + 1));
                            Days = Days - _FreeDays;
                            if (Days < 0)
                                Days = 0;
                            else
                                IsexceedFreedays = true;
                        }
                        else
                        {
                            TMS = ToDt.Subtract(IncreamentalFromDt);
                            Days = (int)((TMS.TotalDays + 1));
                        }
                    }
                    else
                    {
                        if (!IsexceedFreedays)
                        {
                            TMS = IncrementalToDt.Subtract(FromDt);
                            Days = (int)((TMS.TotalDays + 1));
                            Days = Days - _FreeDays;
                            if (Days < 0)
                                Days = 0;
                            else
                                IsexceedFreedays = true;
                        }
                        else
                        {
                            TMS = IncrementalToDt.Subtract(IncreamentalFromDt);
                            Days = (int)((TMS.TotalDays + 1));

                        }
                    }
                    IncreamentalFromDt = IncrementalToDt.AddDays(1);

                    _dtColum.Rows.Add(_dtColum.NewRow());
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["BkgID"] = dtx.Rows[i]["BKGId"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["CntrID"] = dtx.Rows[i]["CntrID"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["CntrTypeID"] = dtx.Rows[i]["TypeID"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ChargeID"] = Data.ChargeID;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["DtCalFrom"] = dtx.Rows[i]["STDate"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["DtPaidUpto"] = ToDt;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ExRate"] = dtx.Rows[i]["ExRate"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Currency"] = dt.Rows[i]["Currency"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["LLimit"] = dt.Rows[y]["SlabFrom"].ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ULimit"] = dt.Rows[y]["SlabTo"].ToString();

                    _dtColum.Rows[_dtColum.Rows.Count - 1]["LLimitDt"] = FDatev;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["ULimitDt"] = TDatev;
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Amount"] = decimal.Parse(dt.Rows[y]["Amount"].ToString());
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Days"] = Days.ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Rate"] = (decimal.Parse(Amount) * decimal.Parse(Days.ToString())).ToString();
                    _dtColum.Rows[_dtColum.Rows.Count - 1]["Total"] = (decimal.Parse(Amount) * decimal.Parse(Days.ToString()) * decimal.Parse(ExRate.ToString())).ToString();

                    TotaAmountv += (decimal.Parse(Amount) * decimal.Parse(Days.ToString()) * decimal.Parse(ExRate.ToString()));
                    if (DateTime.Parse(TDatev) >= DateTime.Parse((ToDt.ToString("dd/MM/yyyy"))))
                    {
                        break;

                    }
                }

            }



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
                    DataView view1 = new DataView(_dtColum);
                    DataTable disBL = view1.ToTable(true, "BkgID", "CntrID", "ExRate", "DtCalFrom", "DtPaidUpto", "ChargeID", "CntrTypeID");

                    for (int z = 0; z < disBL.Rows.Count; z++)
                    {

                        Cmd.CommandText = " IF((select count(*) from NVO_ImpBLDDGCharges where CntrID=@CntrID and BkgID=@BkgID and ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpBLDDGCharges(BKgID,CntrID,DtCalFrom,DtPaidUpto,TotalAmount,ExRate,ChargeID,CntrTypeID,BLID,InclHolidays,DtnAmtx,DemAmtx,GrdAmtx,InvDtnAmtx,InvDemAmtx,InvGrdAmtx) " +
                                     " values (@BKgID,@CntrID,@DtCalFrom,@DtPaidUpto,@TotalAmount,@ExRate,@ChargeID,@CntrTypeID,@BLID,@InclHolidays,@DtnAmtx,@DemAmtx,@GrdAmtx,@InvDtnAmtx,@InvDemAmtx,@InvGrdAmtx) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpBLDDGCharges SET BKgID=@BKgID,CntrID=@CntrID,DtCalFrom=@DtCalFrom,DtPaidUpto=@DtPaidUpto," +
                                     " TotalAmount=@TotalAmount,ExRate=@ExRate,ChargeID=@ChargeID,CntrTypeID=@CntrTypeID,BLID=@BLID,InclHolidays=@InclHolidays,DtnAmtx=@DtnAmtx,DemAmtx=@DemAmtx,GrdAmtx=@GrdAmtx,InvDtnAmtx=@InvDtnAmtx,InvDemAmtx=@InvDemAmtx,InvGrdAmtx=@InvGrdAmtx where CntrID=@CntrID and BkgID=@BkgID and ID=@ID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BKgID", disBL.Rows[z]["BkgID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", disBL.Rows[z]["CntrID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", disBL.Rows[z]["ChargeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", disBL.Rows[z]["CntrTypeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCalFrom", DateTime.Parse(disBL.Rows[z]["DtCalFrom"].ToString()).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidUpto", DateTime.Parse(disBL.Rows[z]["DtPaidUpto"].ToString()).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalAmount", TotaAmountv));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", disBL.Rows[z]["ExRate"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", disBL.Rows[z]["BkgID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InclHolidays", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtnAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DemAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrdAmtx", 0));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDtnAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDemAmtx", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@invGrdAmtx", 0));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        Cmd.CommandText = "select ident_current('NVO_ImpBLDDGCharges')";
                        if (Data.ID == 0)
                            Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        else
                            Data.ID = Data.ID;

                        DataTable _dtx = _dtColum.Select("BKgID=" + disBL.Rows[z]["BkgID"].ToString() + " and CntrID=" + disBL.Rows[z]["CntrID"].ToString()).CopyToDataTable();
                        for (int k = 0; k < _dtx.Rows.Count; k++)
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_ImpBLDDGChargedtls where CntrID=@CntrID and BkgID=@BkgID and DDGID=@DDGID and LLimit=@LLimit)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpBLDDGChargedtls(DDGID,BKgID,CntrID,CntrTypeID,LLimitDt,ULimitDt,LLimit,ULimit,Rate,CurrID,Days,Amount,Total,ExRate) " +
                                     " values (@DDGID,@BKgID,@CntrID,@CntrTypeID,@LLimitDt,@ULimitDt,@LLimit,@ULimit,@Rate,@CurrID,@Days,@Amount,@Total,@ExRate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpBLDDGChargedtls SET DDGID=@DDGID,BKgID=@BKgID,CntrID=@CntrID,CntrTypeID=@CntrTypeID,LLimitDt=@LLimitDt,ULimitDt=@ULimitDt,LLimit=@LLimit,ULimit=@ULimit,Rate=@Rate,CurrID=@CurrID,Days=@Days,Amount=@Amount,Total=@Total,ExRate=@ExRate " +
                                     " Where CntrID=@CntrID and BkgID=@BkgID and DDGID=@DDGID and LLimit=@LLimit";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DDGID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BKgID", _dtx.Rows[k]["BkgID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", _dtx.Rows[k]["CntrID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", _dtx.Rows[k]["CntrTypeID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LLimitDt", DateTime.Parse(_dtx.Rows[k]["LLimitDt"].ToString()).ToString("MM/dd/yyyy")));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ULimitDt", DateTime.Parse(_dtx.Rows[k]["ULimitDt"].ToString()).ToString("MM/dd/yyyy")));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LLimit", decimal.Parse(_dtx.Rows[k]["LLimit"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ULimit", decimal.Parse(_dtx.Rows[k]["ULimit"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Rate", decimal.Parse(_dtx.Rows[k]["Rate"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Days", _dtx.Rows[k]["Days"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", decimal.Parse(_dtx.Rows[k]["Amount"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Total", decimal.Parse(_dtx.Rows[k]["Total"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", decimal.Parse(_dtx.Rows[k]["ExRate"].ToString())));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrID", 146));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();


                        }
                    }


                    trans.Commit();
                    List.Add(new MYImpDDG
                    {
                        StatusAlery = "Save"
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


        public List<MYImpDDG> ImportInsertDTValueInvoice(MYImpDDG Data)
        {
            MYImpDDG listDG = new MYImpDDG();

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
                    DataTable _dtInv = GetImpDDGGetCharge(Data.BkgID);
                    for (int q = 0; q < _dtInv.Rows.Count; q++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_BLCharges where BkgID=@BkgID and ChargeCodeID=@ChargeCodeID and IsMiscCharge=@IsMiscCharge)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_BLCharges(BkgID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,IntBLTypes,IsMiscCharge,BasicID) " +
                                    " values (@BkgID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@IntBLTypes,@IsMiscCharge,@BasicID) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_BLCharges SET BkgID=@BkgID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate," +
                                    " ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,IntBLTypes=@IntBLTypes,IsMiscCharge=@IsMiscCharge,BasicID=@BasicID where BkgID=@BkgID and ChargeCodeID=@ChargeCodeID and IsMiscCharge=@IsMiscCharge";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BKgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtInv.Rows[q]["CntrTypeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtInv.Rows[q]["ChargeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", 146));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtInv.Rows[q]["TotalAmount"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtInv.Rows[q]["TotalAmount"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtInv.Rows[q]["TotalAmount"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", 0.00));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IntBLTypes", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IsMiscCharge", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", 2));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    List.Add(new MYImpDDG
                    {
                        StatusAlery = "Save"
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


        //public List<MYImpDDG> InsertExpDetDmmGrd(MYImpDDG Data)
        //{
        //    List<MYImpDDG> ViewAll = new List<MYImpDDG>();

        //    int r1 = 0;
        //    int r2 = 0;
        //    DbConnection con = null;
        //    DbTransaction trans;

        //    try
        //    {
        //        con = _dbFactory.GetConnection();
        //        con.Open();
        //        trans = _dbFactory.GetTransaction(con);
        //        DbCommand Cmd = _dbFactory.GetCommand();
        //        Cmd.Connection = con;
        //        Cmd.Transaction = trans;

        //        try
        //        {

        //            Cmd.CommandText = " IF((select count(*) from NVO_ImpBLDDGCharges where ID=@ID)<=0) " +
        //                             " BEGIN " +
        //                             " INSERT INTO  NVO_ImpBLDDGCharges(BLID,InclHolidays,DtCalFrom,DtPaidUpto,DtPaidUptoDtn,DtPaidUptoDem,DtPaidUptoGrd,DtnAmtx,DemAmtx,GrdAmtx,InvDtnAmtx,InvDemAmtx,InvGrdAmtx,ExRatex,AdvDtnx,AdvDemx,AdvGrdx,CurrentDate) " +
        //                             " values (@BLID,@InclHolidays,@DtCalFrom,@DtPaidUpto,@DtPaidUptoDtn,@DtPaidUptoDem,@DtPaidUptoGrd,@DtnAmtx,@DemAmtx,@GrdAmtx,@InvDtnAmtx,@InvDemAmtx,@InvGrdAmtx,@ExRatex,@AdvDtnx,@AdvDemx,@AdvGrdx,@CurrentDate) " +
        //                             " END  " +
        //                             " ELSE " +
        //                             " UPDATE NVO_ImpBLDDGCharges SET BLID=@BLID,InclHolidays=@InclHolidays,DtCalFrom=@DtCalFrom,DtPaidUpto=@DtPaidUpto,DtPaidUptoDtn=@DtPaidUptoDtn,DtPaidUptoDem=@DtPaidUptoDem,DtPaidUptoGrd=@DtPaidUptoGrd,DtnAmtx=@DtnAmtx," +
        //                             " DemAmtx=@DemAmtx,GrdAmtx=@GrdAmtx,InvDtnAmtx=@InvDtnAmtx,InvDemAmtx=@InvDemAmtx,InvGrdAmtx=@InvGrdAmtx,ExRatex=@ExRatex,AdvDtnx=@AdvDtnx,AdvDemx=@AdvDemx,AdvGrdx=@AdvGrdx,CurrentDate=@CurrentDate where ID=@ID";

        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@InclHolidays", Data.InclHolidays));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCalFrom", Data.DtCalFrom));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidUpto", Data.DtPaidUpto));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidUptoDtn", Data.DtPaidUptoDtn));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidUptoDem", Data.DtPaidUptoDem));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidUptoGrd", Data.DtPaidUptoGrd));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtnAmtx", Data.DtnAmtx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@DemAmtx", Data.DemAmtx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@GrdAmtx", Data.GrdAmtx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDtnAmtx", Data.InvDtnAmtx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDemAmtx", Data.InvDemAmtx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@InvGrdAmtx", Data.InvGrdAmtx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRatex", Data.ExRatex));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@AdvDtnx", Data.AdvDtnx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@AdvDemx", Data.AdvDemx));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@AdvGrdx", Data.AdvGrdx));

        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgentId));
        //            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


        //            int result = Cmd.ExecuteNonQuery();
        //            Cmd.Parameters.Clear();

        //            if (Data.ID == 0)
        //            {
        //                Cmd.CommandText = "select ident_current('NVO_ImpBLDDGCharges')";
        //                Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
        //            }
        //            //TsPort
        //            if (Data.Items != "Insert:undefined")
        //            {
        //                string[] ArrayTs = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
        //                for (int i = 1; i < ArrayTs.Length; i++)
        //                {
        //                    var CharSplit = ArrayTs[i].ToString().TrimEnd(',').Split(',');

        //                    Cmd.CommandText = " IF((select count(*) from NVO_ImpBLDDGCntrs where BLDDGID=@BLDDGID and CntrID=@CntrID)<=0) " +
        //                                 " BEGIN " +
        //                                 " INSERT INTO  NVO_ImpBLDDGCntrs(BLDDGID,CntrID,PerCntrDtnAmtx,PerCntrDemAmtx,PerCntrGrdAmtx,FV,FU,MA,DtPaidFromDtn,DtPaidFromDem,DtPaidFromGrd,dtpaidfromdtnPrev,dtpaidfromdtnNew,PCAdvDtnx,PCAdvDemx,PCAdvGrdx) " +
        //                                 " values (@BLDDGID,@CntrID,@PerCntrDtnAmtx,@PerCntrDemAmtx,@PerCntrGrdAmtx,@FV,@FU,@MA,@DtPaidFromDtn,@DtPaidFromDem,@DtPaidFromGrd,@dtpaidfromdtnPrev,@dtpaidfromdtnNew,@PCAdvDtnx,@PCAdvDemx,@PCAdvGrdx) " +
        //                                 " END  " +
        //                                 " ELSE " +
        //                                 " UPDATE NVO_ImpBLDDGCntrs SET BLDDGID=@BLDDGID,CntrID=@CntrID,PerCntrDtnAmtx=@PerCntrDtnAmtx,PerCntrDemAmtx=@PerCntrDemAmtx,PerCntrGrdAmtx=@PerCntrGrdAmtx,FV=@FV,FU=@FU,MA=@MA,DtPaidFromDtn=@DtPaidFromDtn," +
        //                                 " DtPaidFromDem=@DtPaidFromDem,DtPaidFromGrd=@DtPaidFromGrd,dtpaidfromdtnPrev=@dtpaidfromdtnPrev,dtpaidfromdtnNew=@dtpaidfromdtnNew,PCAdvDtnx=@PCAdvDtnx,PCAdvDemx=@PCAdvDemx,PCAdvGrdx=@PCAdvGrdx where BLDDGID=@BLDDGID and CntrID=@CntrID";
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDDGID", Data.ID));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PerCntrDtnAmtx", CharSplit[1]));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PerCntrDemAmtx", CharSplit[2]));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PerCntrGrdAmtx", CharSplit[3]));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FV", ""));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FU", ""));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MA", ""));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidFromDtn", CharSplit[4]));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidFromDem", CharSplit[5]));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtPaidFromGrd", CharSplit[6]));

        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@dtpaidfromdtnPrev", 0));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@dtpaidfromdtnNew", 0));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PCAdvDtnx", 0));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PCAdvDemx", 0));
        //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PCAdvGrdx", 0));
        //                    result = Cmd.ExecuteNonQuery();
        //                    Cmd.Parameters.Clear();

        //                }
        //            }

        //            trans.Commit();

        //            ViewAll.Add(new MYImpDDG
        //            {
        //                ID = Data.ID

        //            });
        //            return ViewAll;

        //        }
        //        catch (Exception ex)
        //        {
        //            string ss = ex.ToString();
        //            trans.Rollback();
        //            return ViewAll;
        //        }

        //    }


        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    finally
        //    {
        //        if (con != null && con.State != ConnectionState.Closed)
        //            con.Close();

        //    }
        //}





        public List<MYDETCalculation> ImpDDGBillingAmount(MYDETCalculation Data)
        {
            List<MYDETCalculation> ViewList = new List<MYDETCalculation>();
            DataTable dt = GetImpDDGBiiledAmount(Data.BkgID, Data.CntrID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYDETCalculation
                {
                    ID = dt.Rows[i]["ContID"].ToString(),
                    BilledAmount = dt.Rows[i]["BillAmount"].ToString(),
                   

                });
            }
            return ViewList;
        }


        public DataTable GetImpDDGGetCharge(string BkgID)
        {
            string _Query = " Select ChargeID,CntrTypeID, sum(TotalAmount) as TotalAmount from NVO_ImpBLDDGCharges where BKgID = " + BkgID + " group by ChargeID,CntrTypeID";
            return GetViewData(_Query, "");
        }


        public DataTable GetImpDDGBiiledAmount(string BkgID, string CntrID)
        {
            string _Query = "select * from NVO_V_CntrDetentionCalculation where BkgId = " + BkgID + " and CntrId in (" + CntrID.Remove(CntrID.Length - 1) + ")";
            return GetViewData(_Query, "");
        }


        public List<MYImpDDG> ExportExistingEstimatedisplay(MYImpDDG Data)
        {
            List<MYImpDDG> ViewList = new List<MYImpDDG>();
            DataTable dt = GetExistingExtimatevalues(Data.BkgID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYImpDDG
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DtCalFrom = dt.Rows[i]["DtCalFrom"].ToString(),
                    CntrIDs = dt.Rows[i]["Cntrno"].ToString(),
                    DtPaidUptoDtn = dt.Rows[i]["DetDate"].ToString(),
                    DtnAmtx = dt.Rows[i]["DetAmt"].ToString(),
                    DtPaidUptoDem = dt.Rows[i]["DMMDate"].ToString(),
                    DemAmtx = dt.Rows[i]["DMMAmt"].ToString(),
                    DtPaidUptoGrd = dt.Rows[i]["GRDDate"].ToString(),
                    GrdAmtx = dt.Rows[i]["GRDAmt"].ToString(),
                    ExRatex = dt.Rows[i]["ExRate"].ToString(),
                    ESTNo = dt.Rows[i]["ESTNo"].ToString(),
                    ChargeID= dt.Rows[i]["ChargeID"].ToString(),
                    IsTrue = false
                });
            }
            return ViewList;
        }

        public DataTable GetExistingExtimatevalues(string BkgID)
        {
            string _Query = " select ID, convert (varchar,DtCalFrom, 103) as DtCalFrom,ChargeID, " +
                            " (select top(1) CntrNo from NVO_Containers where ID = NVO_ImpBLDDGCharges.CntrID) as Cntrno, " +
                            " case when ChargeID = 28 then convert(varchar, DtPaidUpto, 103) else '' end as DetDate, " +
                            " case when ChargeID = 28 then TotalAmount else '0' end as DetAmt, " +
                            " case when ChargeID = 29 then convert(varchar, DtPaidUpto, 103) else '' end as DMMDate, " +
                            " case when ChargeID = 29 then TotalAmount else '0' end as DMMAmt, " +
                            " case when ChargeID = 30 then convert(varchar, DtPaidUpto, 103) else '' end as GRDDate, " +
                            " case when ChargeID = 30 then TotalAmount else '0' end as GRDAmt,TotalAmount,ExRate, '' as ESTNo " +
                            " from NVO_ImpBLDDGCharges where BKgId = " + BkgID;
            return GetViewData(_Query, "");
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
            string _Query = "select top(1) convert(varchar,DtMovement, 101) as DtMovement  from NVO_ContainerTxns where ContainerID in (" + Data.CntrID + ") order by ID desc";
            return GetViewData(_Query, "");
        }


        public List<MyCntrPickup> InsertImpCntrLastMovment(MyCntrPickup Data)
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
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPortID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", 0));
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
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgentID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", Data.ID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    Cmd.CommandText = "UPDATE NVO_BOLCntrDetails SET CntrID = OtherTable.ID,size = OtherTable.size, ISOCode=OtherTable.ISOCode FROM(select ID, size, ISOCode, BLNumber from NVO_View_ContainerTrans) as OtherTable WHERE OtherTable.BLNumber=@BkgID and NVO_BOLCntrDetails.BkgId=@BkgID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId",Data.BkgID));
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


        public DataTable GetDtMovementUpdateBkgwise(MyCntrPickup Data)
        {
            string _Query = " UPDATE NVO_BOLCntrDetails  " +
                            " SET CntrID = OtherTable.ID, size = OtherTable.size, ISOCode = OtherTable.ISOCode " +
                            " FROM(select ID, size, ISOCode, BLNumber from NVO_View_ContainerTrans) as OtherTable WHERE OtherTable.BLNumber = " + Data.BkgID + " and NVO_BOLCntrDetails.BkgId =" + Data.BkgID;
            return GetViewData(_Query, "");
        }



        public List<MYDETCalculation> DisplayExistingEstimateValues(MYDETCalculation Data)
        {
            List<MYDETCalculation> ViewList = new List<MYDETCalculation>();
            DataTable dt = GetDisplayEstimateExisting(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYDETCalculation
                {

                    FDatev = dt.Rows[i]["LLimitDt"].ToString(),
                    TDatev = dt.Rows[i]["ULimitDt"].ToString(),
                    ULimit = dt.Rows[i]["ULimit"].ToString(),
                    LLimit = dt.Rows[i]["LLimit"].ToString(),
                    Days = dt.Rows[i]["Days"].ToString(),
                    Rate = dt.Rows[i]["Rate"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    TotalAmt = dt.Rows[i]["Total"].ToString(),
                    TotalAmount = dt.Rows[i]["TotalAmount"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),

                });
            }
            return ViewList;
        }


        public DataTable GetDisplayEstimateExisting(MYDETCalculation Data)
        {
            string _Query = " select convert(varchar,LLimitDt, 103) as LLimitDt,convert(varchar,ULimitDt, 103) as ULimitDt,LLimit,ULimit,Rate,CurrID,Days,Amount,Total,NVO_ImpBLDDGCharges.ExRate,TotalAmount" +
                            " from NVO_ImpBLDDGChargedtls "+
                            " inner join NVO_ImpBLDDGCharges on NVO_ImpBLDDGCharges.ID=NVO_ImpBLDDGChargedtls.DDGID"+
                            " where DDGID = " + Data.ID;
            return GetViewData(_Query, "");
        }



        public List<MYImpDDG> ImportDDGDelete(MYImpDDG Data)
        {
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
                    int BkgID = 0;
                    int ChargeID = 0;
                    int InvID = 0;
                    DataTable _dtD = GetCheckDetentionDelete(Data);
                    if (_dtD.Rows.Count > 0)
                    {
                        BkgID = Int32.Parse(_dtD.Rows[0]["BkgID"].ToString());
                        ChargeID = Int32.Parse(_dtD.Rows[0]["ChargeID"].ToString());


                        DataTable _dtx = GetCheckDeleteDetentionInvoice(BkgID, ChargeID);
                        if (_dtx.Rows.Count > 0)
                        {
                            InvID = Int32.Parse(_dtx.Rows[0]["InvID"].ToString());
                            if (_dtx.Rows[0]["InvID"].ToString() == "0")
                            {
                                Cmd.CommandText = "delete from NVO_ImpBLDDGCharges where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "delete from NVO_ImpBLDDGChargedtls where DDGID=@DDGID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DDGID", Data.ID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "delete from NVO_BLCharges where BkgID= @BkgID and ChargeCodeID= @ChargeCodeID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", BkgID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", ChargeID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "delete from NVO_InvoiceCusBilling where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", InvID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "delete from NVO_InvoiceCusBillingdtls where InvCusBillingID=@InvCusBillingID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", InvID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "delete from NVO_InvoiceCusBillingTaxdtls where InvCusBillingID=@InvCusBillingID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", InvID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                List.Add(new MYImpDDG
                                {
                                    StatusAlery = "Deleted"
                                });
                                trans.Commit();
                            }
                            else
                            {
                                List.Add(new MYImpDDG
                                {
                                    StatusAlery = "Invoice as Created check admin"
                                });
                            }

                        }
                        else
                        {
                            Cmd.CommandText = "delete from NVO_ImpBLDDGCharges where ID=@ID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            Cmd.CommandText = "delete from NVO_ImpBLDDGChargedtls where DDGID=@DDGID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DDGID", Data.ID));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            Cmd.CommandText = "delete from NVO_BLCharges where BkgID= @BkgID and ChargeCodeID= @ChargeCodeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", BkgID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", ChargeID));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            List.Add(new MYImpDDG
                            {
                                StatusAlery = "Deleted"
                            });
                            trans.Commit();
                        }
                    }
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

        public DataTable GetCheckDetentionDelete(MYImpDDG Data)
        {
            string _Query = "select * from NVO_ImpBLDDGCharges where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable GetCheckDeleteDetentionInvoice(int BkgID, int ChargeType)
        {
            string _Query = " select isnull((select (select top(1) ID from NVO_InvoiceCusBilling where NVO_InvoiceCusBilling.ID =NVO_InvoiceCusBillingdtls.InvCusBillingID)  " +
                            " from NVO_InvoiceCusBillingdtls where BLInvID = NVO_BLCharges.ID),0) as InvID,  " +
                            " isnull((select(select top(1) IsFinal from NVO_InvoiceCusBilling where NVO_InvoiceCusBilling.ID = NVO_InvoiceCusBillingdtls.InvCusBillingID) " +
                            " from NVO_InvoiceCusBillingdtls where BLInvID = NVO_BLCharges.ID),0) as InvFinal " +
                            " from NVO_BLCharges where BkgID = " + BkgID + " and ChargeCodeID = " + ChargeType;
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

        #region Ganesh
        public List<MyImport> BindNominationCFSValues(MyImport Data)
        {
            DataTable dt = GetNominationCFSValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),

                });

            }
            return ListImport;
        }

        public DataTable GetNominationCFSValues(MyImport Data)
        {
            string _Query = "select * from NVO_GeneralMaster where SeqNo = 44";
            return GetViewData(_Query, "");
        }

        #endregion


        public List<MyRRRate> ImpDestinationExisting(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetImpDestinationExisting(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCode"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentMode"].ToString(),
                    CurrencyID = dt.Rows[i]["Currency"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),

                });
            }

            return ViewList;
        }

        public DataTable GetImpDestinationExisting(MyRRRate Data)
        {
            string _Query = " Select TariffID as  RCID,CntrType, (select top(1) Size from NVO_tblCntrTypes where ID =CntrType) as CntrTypes, "+
                            " ChargeCodeID,(select top(1) ChgDesc from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode, "+
                            " CurrencyID, (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID)  as Currency, "+
                            " PaymentModeID, (select top(1) GeneralName from NVO_GeneralMaster where ID = PaymentModeID) as PaymentMode, "+
                            " ReqRate,ManifRate,CustomerRate,RateDiff "+
                            " from NVO_RatesheetCharges "+
                            " inner join NVO_Booking on NVO_Booking.RRID = NVO_RatesheetCharges.RRId "+
                            " where NVO_Booking.ID = "+ Data.ID + " and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;
            return GetViewData(_Query, "");
        }


        public List<MyImport> BindCustomerCFSValues(MyImport Data)
        {
            DataTable dt = GetCustomerCFSValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListImport.Add(new MyImport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),

                });

            }
            return ListImport;
        }



        public DataTable GetCustomerCFSValues(MyImport Data)
        {
            string _Query = " select NVO_CustomerMaster.ID,CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBusinessTypes on NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID " +
                            " where BussTypes = 5";

            return GetViewData(_Query, "");
        }



        public List<MyCntrPickup> ImpBkgPickupContainers(MyCntrPickup Data)
        {
            List<MyCntrPickup> ViewList = new List<MyCntrPickup>();
            DataTable dt = GetImpPickupCntrTypes(Data);
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
                    CurrentPortID = dt.Rows[i]["LocationID"].ToString(),
                    CntrDepo = dt.Rows[i]["CntrDepo"].ToString(),
                    DepotID = dt.Rows[i]["DepotID"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    IsTrue = "0"
                });
            }
            return ViewList;
        }

        public DataTable GetImpPickupCntrTypes(MyCntrPickup Data)
        {
            //string _Query = " select NVO_Containers.ID,CntrNo,(Select top(1) Size from NVO_tblCntrTypes where ID = TypeID) as Size,TypeID, " +
            //                " (select PortName from NVO_PortMaster where Id = CurrentPortID) as Location,CurrentPortID, " +
            //                 " (select top(1) AgencyName from NVO_AgencyMaster where Id = AgencyID) as AgencyName ," +
            //                " (select top(1) DepName from NVO_DepotMaster where Id = DepotID) as CntrDepo,StatusCode,* from NVO_Containers " +
            //                " inner join NVO_PortMaster on NVO_PortMaster.ID=NVO_Containers.CurrentPortID " +
            //                " where NVO_Containers.StatusCode in ('FB') and  LocationID=" + Data.POL;

            string _Query = " select NVO_Containers.ID,CntrNo,(Select top(1) Size from NVO_tblCntrTypes where ID = TypeID) as Size,TypeID, " +
                            " (select PortName from NVO_PortMaster where Id = LocationID) as Location,LocationID,   " +
                            " (select top(1) AgencyName from NVO_AgencyMaster where Id = NVO_ContainerTxns.AgencyID) as AgencyName, " +
                            " (select top(1) DepName from NVO_DepotMaster where Id = NVO_ContainerTxns.DepotID) as CntrDepo,NVO_ContainerTxns.DepotID,NVO_ContainerTxns.StatusCode " +
                            " from NVO_ContainerTxns " +
                            " inner join NVO_Containers on NVO_Containers.ID = NVO_ContainerTxns.ContainerID " +
                            " where NVO_ContainerTxns.StatusCode in ('FB')";
            //and LocationID = " + Data.POL;
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


    }
}

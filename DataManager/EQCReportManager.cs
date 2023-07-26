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

namespace DataManager
{
    public class EQCReportManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public EQCReportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyEQCReport> LongStayReportView(MyEQCReport Data)
        {
            List<MyEQCReport> ListExReport = new List<MyEQCReport>();
            DataTable dt = GetLongStayExcelReport(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyEQCReport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    Days = dt.Rows[i]["Days"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    GeoLoc = dt.Rows[i]["GeoLoc"].ToString(),
                    Location = dt.Rows[i]["CurrentPort"].ToString(),

                });
            }
            return ListExReport;
        }


        public DataTable GetLongStayExcelReport(MyEQCReport Data)
        {
            var symbol = "";

            if (Data.DaysV == "1")
                symbol = "<";
            if (Data.DaysV == "2")
                symbol = ">";
            if (Data.DaysV == "3")
                symbol = "=";

            string _Query = " Select DISTINCT C.ID,C.CntrNo,CT.Type +'-'+ CT.Size as CntrType, Datediff(d, (select top(1) DtMovement   from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc),GETDATE()) Days, isnull((select top 1 GeoLocation from NVO_GeoLocations Where id = NVO_AgencyMaster.GeoLocationID) ,'')AS GeoLoc, " +
           " isnull((select top(1) StatusCode from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc),'') StatusCode,isnull((select top(1) DtMovement from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc),'') DtMovement,BookingNo,BkgDate,POD,POL,isnull((select top 1 IGMNo from NVO_VoyageManifestDtls WHERE VoyageID = NVO_Booking.VesVoyID),'') As IGMNo, " +
          "convert(varchar, (select top 1 IGMDate from NVO_VoyageManifestDtls WHERE VoyageID = NVO_Booking.VesVoyID),103)  As IGMDate, ISNULL((select top 1 upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id INNER JOIN NVO_BOLCustomerDetails ON NVO_BOLCustomerDetails.BkgID " +
           " = NVO_Booking.ID  WHERE  NVO_CusBranchLocation.CID = NVO_BOLCustomerDetails.PartID  AND PartyTypeID = 1   ),'') As Shipper," +
          "ISNULL((select top 1 upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id INNER JOIN NVO_BOLCustomerDetails ON NVO_BOLCustomerDetails.BkgID  = NVO_Booking.ID  WHERE  NVO_CusBranchLocation.CID = NVO_BOLCustomerDetails.PartID  AND PartyTypeID = 2   ),'') As Consignee, " +
        "ISNULL((select top 1 upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster inner join NVO_CusBranchLocation  on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id INNER JOIN NVO_BOLCustomerDetails ON NVO_BOLCustomerDetails.BkgID   = NVO_Booking.ID  WHERE  NVO_CusBranchLocation.CID = NVO_BOLCustomerDetails.PartID  AND PartyTypeID = 3   ),'') As Notify, " +
       " isnull((select top 1 PARTYADDRESS   from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID AND PartyTypeID = 2),'') AS ConsigneeAddress, isnull((select top 1 PARTYADDRESS   from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID AND PartyTypeID = 1),'') AS ShipperAddress, " +
        "isnull((select top 1 PARTYADDRESS   from NVO_BOLCustomerDetails where BkgId = NVO_Booking.ID AND PartyTypeID = 3),'') AS NotifyAddress, isnull((select top 1 PortName   from NVO_PortMaster where ID = C.CurrentPortID ),'') AS CurrentPort " +
        " FROM NVO_Containers C INNER JOIN NVO_tblCntrTypes CT ON CT.ID = C.TypeID  left outer join NVO_AgencyMaster on NVO_AgencyMaster.ID = C.AgencyID left outer join NVO_Booking on NVO_Booking.ID = isnull((select top(1) BLNumber from NVO_ContainerTxns INNER JOIN NVO_Booking on NVO_Booking.ID = NVO_ContainerTxns.BLNumber where  ContainerID = C.ID order by DtMovement desc),0) WHERE (select top(1) StatusCode  from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc)  NOT IN('PENDING') ";

            string strWhere = "";

            if (Data.DaysV != "" && Data.DaysV != "0" && Data.DaysV != null && Data.DaysV != "?" || Data.Days != "" && Data.Days != "undefined")

                if (strWhere == "")
                    strWhere += _Query + " and  Datediff(d, (select top(1) DtMovement from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc), GETDATE()) " + symbol + "" + Data.Days;
                else
                    strWhere += " and  Datediff(d, (select top(1) DtMovement from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc), GETDATE())  " + symbol + "" + Data.Days;


            if (Data.StatusCode != "" && Data.StatusCode != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " and (select top(1) StatusCode from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc) ='" + Data.StatusCode + "'";
                else
                    strWhere += " and (select top(1) StatusCode from NVO_ContainerTxns where ContainerID = C.ID order by DtMovement desc) ='" + Data.StatusCode + "'";



            if (Data.Location != "" && Data.Location != "0" && Data.Location != null && Data.Location != "?")
                if (strWhere == "")
                    strWhere += _Query + " and CurrentPortID=" + Data.Location;
                else
                    strWhere += " and CurrentPortID =" + Data.Location;

            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere, "");
        }


        public List<MyEQCReport> CntrTurnAroundStatusList(MyEQCReport Data)
        {
            List<MyEQCReport> ListExReport = new List<MyEQCReport>();
            DataTable dt = GetCntrTurnAroundStatusList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyEQCReport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StatusCode = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListExReport;
        }
        public DataTable GetCntrTurnAroundStatusList(MyEQCReport Data)
        {


            string _Query = " Select * from NVO_GeneralMaster where SeqNo=60";

            return GetViewData(_Query, "");
        }


        public List<MyEQCReport> CntrTurnAroundView(MyEQCReport Data)
        {
            List<MyEQCReport> ListExReport = new List<MyEQCReport>();
            DataTable dt = GetCntrTurnAroundView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyEQCReport
                {


                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["Size"].ToString(),
                    FromStatus = dt.Rows[i]["FromStatus"].ToString(),
                    FromLocation = dt.Rows[i]["FromLocation"].ToString(),
                    FromGeoLocation = dt.Rows[i]["FromGeoLocation"].ToString(),
                    FromDate = dt.Rows[i]["FromDate"].ToString(),
                    ToStatus = dt.Rows[i]["ToStatus"].ToString(),
                    ToLocation = dt.Rows[i]["ToLocation"].ToString(),
                    ToGeoLocation = dt.Rows[i]["ToGeoLocation"].ToString(),
                    ToDate = dt.Rows[i]["ToDate"].ToString(),
                    Days = dt.Rows[i]["NDays"].ToString(),

                });
            }
            return ListExReport;
        }


        public DataTable GetCntrTurnAroundView(MyEQCReport Data)
        {
            string FromStatus = "", ToStatus = "", ToStatus2 = "", WC = "";
            //PortTypeID = " tbllocs.PortTypeID IN(1,5) AND ";

            string strWhere = "";

            switch (Data.StatusCode)
            {
                //--CASE 1---
                case "238":
                    FromStatus = "'FV'";
                    ToStatus = "'FU'";
                    break;
                //--CASE 2---
                case "243":
                    FromStatus = "'FV'";
                    ToStatus = "'MA'";
                    break;
                //--CASE 3---
                case "239":
                    FromStatus = "'FU'";
                    ToStatus = "'MA'";
                    // PortTypeID = "";
                    break;
                //--CASE 4---
                case "244":
                    FromStatus = "'FV'";
                    ToStatus = "'DL'";
                    break;
                //--CASE 5---
                case "245":
                    FromStatus = "'MA'";
                    ToStatus = "'FB'";
                    //  PortTypeID = "";
                    WC += " AND CTTO.ID NOT IN (SELECT TOP 1 ID FROM NVO_Containertxns D WHERE D.ContainerID=CTTO.ContainerID AND D.Statuscode IN('ST','FB')  AND D.ID>(SELECT TOP 1 ID FROM NVO_Containertxns B WHERE B.Statuscode IN('TZ') AND B.ContainerID=CTTO.ContainerID) ORDER BY D.DtMovement) ";
                    break;
                //--CASE 6---
                case "246":
                    FromStatus = "'MA'";
                    ToStatus = "'MB'";
                    break;
                //--CASE 7---
                case "241":
                    FromStatus = "'MA'";
                    ToStatus = "'MS'";
                    // PortTypeID = "";
                    break;
                //--CASE 8---
                case "242":
                    FromStatus = "'MS'";
                    ToStatus = "'FL'";
                    //PortTypeID = "";//To
                    break;
                //--CASE 9---
                case "247":
                    FromStatus = "'FL'";
                    ToStatus = "'FB'";
                    // PortTypeID = "A.PortTypeID=5 AND ";
                    WC += " AND CTTO.ID NOT IN (SELECT TOP 1 ID FROM NVO_Containertxns D WHERE D.ContainerID=CTTO.ContainerID AND D.Statuscode IN ('ST','FB')  AND D.ID>(SELECT TOP 1 ID FROM NVO_Containertxns B WHERE B.Statuscode IN('TZ') AND B.ContainerID=CTTO.ContainerID) ORDER BY D.DtMovement) ";
                    break;
                //--CASE 10---
                case "10":
                    FromStatus = "'MB'";
                    ToStatus = "'MA'";
                    /// PortTypeID = "A.PortTypeID=5 AND ";
                    break;
                //--CASE 11---
                case "11":
                    FromStatus = "'FV'";
                    ToStatus = "'FI'";
                    break;
                //--CASE 12---
                case "12":
                    FromStatus = "'MA'";
                    ToStatus = "'MI'";
                    //   PortTypeID = "";
                    break;
                //--CASE 13---
                case "13":
                    FromStatus = "'MS'";
                    ToStatus = "'MA'";
                    // PortTypeID = "";
                    break;
                //--CASE 14---
                case "14":
                    FromStatus = "'FB'";
                    ToStatus = "'FV'";
                    //PortTypeID = "A.PortTypeID=5 AND ";
                    break;
                //--CASE 15---
                case "15":
                    FromStatus = "'FV'";
                    ToStatus = "'RC'";
                    //   PortTypeID = "A.PortTypeID=5 AND ";
                    // PortTypeID = "";

                    break;
                //--CASE 16---
                case "16":
                    FromStatus = "'RC'";
                    ToStatus = "'ST','FB'";
                    // PortTypeID = "";
                    ///  PortTypeID = "A.PortTypeID=5 AND ";
                    break;
                //--CASE 17---
                case "17":
                    FromStatus = "'MS'";
                    ToStatus = "'FB'";
                    ToStatus2 = "'MA'";
                    // PortTypeID = "";
                    WC += " AND CTTO.ID NOT IN (SELECT TOP 1 ID FROM NVO_Containertxns D WHERE D.ContainerID=CTTO.ContainerID AND D.Statuscode IN ('ST','FB')  AND D.ID>(SELECT TOP 1 ID FROM NVO_Containertxns B WHERE B.Statuscode IN('TZ') AND B.ContainerID=CTTO.ContainerID) ORDER BY D.DtMovement) ";
                    break;
                //--CASE 18---
                case "240":
                    FromStatus = "'DL'";
                    ToStatus = "'MA'";
                    //   PortTypeID = "A.PortTypeID=5 AND ";
                    // PortTypeID = "";
                    break;
            }

            string Qr = "  SELECT DISTINCT C.CntrNo,NVO_tblCntrTypes.Size, FmMove.StatusCode FromStatus, FmMove.DtMovement FromDate, " +
            " FLoc.PortName as FromLocation, FLoc.GeoLocation as FromGeoLocation,  CTTO.Statuscode ToStatus, CTTO.Dtmovement ToDate, " +
            " DateDiff(dd, FmMove.DtMovement, CTTO.Dtmovement)+1 NDays, t1.PortName as ToLocation, togl.GeoLocation as ToGeoLocation  FROM NVO_Containers C " +
            " INNER JOIN NVO_tblCntrTypes ON NVO_tblCntrTypes.ID = C.TypeID INNER JOIN NVO_ContainerTxns CTTO ON CTTO.ContainerID = C.ID " +
            " INNER JOIN NVO_PortMaster t1 ON t1.ID = CTTO.LocationID INNER JOIN NVO_GeoLocations togl on togl.ID = t1.GeoLocID OUTER APPLY(SELECT TOP 1 NVO_PortMaster.PortName, gl.GeoLocation FROM NVO_ContainerTxns A " +
            " INNER JOIN NVO_PortMaster ON NVO_PortMaster.ID = A.LocationID INNER JOIN NVO_GeoLocations gl on gl.ID = NVO_PortMaster.GeoLocID WHERE " +
            " A.StatusCode IN (" + FromStatus + ")  AND A.ContainerID = C.ID  AND A.DtMovement <= CTTO.DtMovement AND NVO_PortMaster.CountryID = t1.CountryID ORDER BY A.DtMovement Desc ) as FLoc " +
            " OUTER APPLY (SELECT TOP 1 DtMovement, StatusCode FROM NVO_ContainerTxns A INNER JOIN NVO_PortMaster ON NVO_PortMaster.ID = A.LocationID WHERE A.StatusCode IN (" + FromStatus + ")  AND A.ContainerID = C.ID " +
            " AND A.DtMovement <= CTTO.DtMovement AND NVO_PortMaster.CountryID = t1.CountryID ORDER BY  A.DtMovement Desc ) as FmMove  WHERE CTTO.StatusCode IN (" + ToStatus + ")  ";


            if (Data.GeoLoc != "" && Data.GeoLoc != "0" && Data.GeoLoc != null && Data.GeoLoc != "?")
                if (strWhere == "")
                    strWhere += Qr + " and togl.ID=" + Data.GeoLoc;
                else
                    strWhere += " and togl.ID =" + Data.GeoLoc;

            if (Data.FromDt != "" && Data.FromDt != "undefined" || Data.ToDt != "" && Data.ToDt != "undefined")
                if (strWhere == "")
                    strWhere += Qr + " and CTTO.DtMovement between '" + Data.FromDt + "' AND '" + Data.ToDt + "' " + WC +
                        " ORDER BY 6,4 ";
                else
                    strWhere += " and CTTO.DtMovement between '" + Data.FromDt + "' AND '" + Data.ToDt + "' " + WC +
                        " ORDER BY 6,4 ";

            string stat = Data.StatusCode;

            if (stat == "239" || stat == "242" || stat == "247" || stat == "10" || stat == "14" || stat == "16")
            {
                Qr = " SELECT DISTINCT C.CntrNo,NVO_tblCntrTypes.Size,  CTTO.Statuscode FromStatus, " +
                   " CTTO.Dtmovement FromDate, t1.PortName as FromLocation, togl.GeoLocation as FromGeoLocation,  " +
                 " ToMove.StatusCode ToStatus, ToMove.DtMovement ToDate, ToMove.Name as ToLocation,ToMove.GeoLocation as ToGeoLocation,  DateDiff(dd, CTTO.Dtmovement, ToMove.DtMovement) + 1 NDays " +
                " FROM NVO_Containers C INNER JOIN NVO_tblCntrTypes ON NVO_tblCntrTypes.ID = C.TypeID  INNER JOIN NVO_ContainerTxns CTTO ON CTTO.ContainerID = C.ID " +
               " INNER JOIN NVO_PortMaster t1 ON t1.ID = CTTO.LocationID INNER JOIN NVO_GeoLocations togl on togl.ID = t1.GeoLocID " +
              " OUTER APPLY(SELECT TOP 1 DtMovement,StatusCode, PortName as Name, GeoLocation FROM NVO_ContainerTxns A  WHERE A.StatusCode IN " +
               " (" + ToStatus + ") AND A.ContainerID = C.ID  AND A.DtMovement >= CTTO.DtMovement  ORDER BY A.DtMovement)  as ToMove  WHERE CTTO.StatusCode IN(" + FromStatus + ") ";



                if (Data.GeoLoc != "" && Data.GeoLoc != "0" && Data.GeoLoc != null && Data.GeoLoc != "?")
                    if (strWhere == "")
                        strWhere += Qr + " and togl.ID=" + Data.GeoLoc;
                    else
                        strWhere += " and togl.ID =" + Data.GeoLoc;


                if (Data.FromDt != "" && Data.FromDt != "undefined" || Data.ToDt != "" && Data.ToDt != "undefined")
                    if (strWhere == "")
                        strWhere += Qr + " and CTTO.DtMovement between '" + Data.FromDt + "' AND '" + Data.ToDt + "' " + WC +
                            " ORDER BY 6,4 ";
                    else
                        strWhere += " and CTTO.DtMovement between '" + Data.FromDt + "' AND '" + Data.ToDt + "' " + WC +
                            " ORDER BY 6,4 ";
            }
            //else if (stat == "17")
            //{
            //    Qr = "SELECT DISTINCT C.CntrNo,tblCntrTypes.Size, " +
            //        " CTTO.Statuscode FromStatus, CTTO.Dtmovement FromDate, " +
            //        " t1.Name as FromLocation, togl.LocDesc as FromGeoLocation, " +
            //        " ToMove.StatusCode ToStatus, ToMove.DtMovement ToDate, " +
            //        " ToMove.Name as ToLocation, ToMove.LocDesc as ToGeoLocation, " +
            //        " DateDiff(dd, CTTO.Dtmovement, ToMove.DtMovement) + 1 NDays " +
            //        " FROM Containers C " +
            //        " INNER JOIN tblCntrTypes ON tblCntrTypes.ID = C.TypeID " +
            //        " INNER JOIN ContainerTxns CTTO ON CTTO.ContainerID = C.ID " +
            //        " INNER JOIN tblLocs t1 ON t1.ID = CTTO.LocationID " +
            //        " INNER JOIN tblGeoLocations togl on togl.ID = t1.GeoLocID " +
            //        " OUTER APPLY " +
            //        " (SELECT TOP 1 DtMovement, StatusCode, Location as Name, LocDesc FROM vContainerTxns A " +
            //        " WHERE " + PortTypeID + " A.StatusCode IN (" + ToStatus + ") AND A.ContainerID = C.ID  AND A.DtMovement >= CTTO.DtMovement " +
            //        //--AND tblLocs.CtryID = t1.CtryID " +
            //        " ORDER BY A.DtMovement) as ToMove " +
            //        " OUTER APPLY " +
            //        " (SELECT TOP 1 DtMovement, StatusCode, Location as Name, LocDesc FROM vContainerTxns B " +
            //        " WHERE " + PortTypeID + " B.StatusCode IN (" + ToStatus2 + ") AND B.ContainerID = C.ID  AND B.DtMovement >= CTTO.DtMovement " +
            //        " ORDER BY B.DtMovement) as ToMove2 " +
            //        " WHERE CTTO.StatusCode IN (" + FromStatus + ") AND ToMove.DtMovement between '" + DtFrom + "' AND '" + DtTo + "' " + WC +
            //        " ORDER BY 6,4";
            //}





            if (strWhere == "")
                strWhere = Qr;


            return GetViewData(strWhere, "");
        }


        public List<MyEQCReport> CntrStatusWiseReportView(MyEQCReport Data)
        {
            List<MyEQCReport> ListExReport = new List<MyEQCReport>();
            DataTable dt = GetCntrStatusWiseReportView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyEQCReport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["cntrno"].ToString(),
                    CntrType = dt.Rows[i]["typesize"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),
                    //GeoLoc = dt.Rows[i]["location"].ToString(),
                    Location = dt.Rows[i]["location"].ToString(),
                    Agency = dt.Rows[i]["Agency"].ToString(),
                });
            }
            return ListExReport;
        }


        public DataTable GetCntrStatusWiseReportView(MyEQCReport Data)
        {
            string strWhere = "";

            string _Query = "select cmd1.ID, ContainerID, (select c.cntrno from NVO_Containers c where c.ID = cmd1.ContainerID) as cntrno, " +
         " (select c.TypeID from NVO_Containers c where c.ID = cmd1.ContainerID) as typeid,cmd1.DtMovement,cmd1.StatusCode, " +
      " NVO_PortMaster.PortName as location,(select typ.Type + '-' + typ.Size from NVO_Containers c inner join NVO_tblcntrtypes typ on typ.id = c.typeid where c.ID = cmd1.ContainerID) as typesize," +
        " isnull((Select top 1 AgencyName from NVO_AgencyMaster where ID = cmd1.agencyID ),'') As Agency," +
         "isnull((Select top 1 GeneralName from NVO_GeneralMaster where ID = cmd1.ModeOfTransportID),'' ) As Transitmode, " +
        " isnull((Select top 1 BookingNo from NVO_Booking where ID = cmd1.BLNumber),'' ) As BLNumber," +
        " isnull((Select top 1 DepName from NVO_DepotMaster where ID = cmd1.DepotID),'' ) As Depot , " +
        " isnull(( Select top 1 (select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) from NVO_Voyage V where cmd1.VesVoyID = V.ID Order by DtMovement desc)  ,'')As VESVOY " +
        " from NVO_ContainerTxns cmd1 inner join NVO_PortMaster on NVO_PortMaster.ID = cmd1.locationid ";



            if (Data.Location != "undefined" && Data.Location != "" && Data.Location != "0" && Data.Location != "null" && Data.Location != "?")

                if (strWhere == "")
                    strWhere += _Query + " WHERE cmd1.locationid=" + Data.Location;
                else
                    strWhere += " and cmd1.locationid = " + Data.Location;


            if (Data.StatusCode != "" && Data.StatusCode != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " WHERE cmd1.StatusCode ='" + Data.StatusCode + "'";
                else
                    strWhere += " and cmd1.StatusCode ='" + Data.StatusCode + "'";



            if (Data.FromDt != "" && Data.FromDt != "undefined" || Data.ToDt != "" && Data.ToDt != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " WHERE cmd1.DtMovement between '" + Data.FromDt + "' and '" + Data.ToDt + "'";
                else
                    strWhere += "  and cmd1.DtMovement between '" + Data.FromDt + "' and '" + Data.ToDt + "'";

            if (strWhere == "")
                strWhere = _Query;


            return GetViewData(strWhere, "");
        }

        public List<MyEQCDCMR> DCMRGlobalReportView(MyEQCDCMR Data)
        {
            List<MyEQCDCMR> ListExReport = new List<MyEQCDCMR>();
            DataTable dt = GetDCMRGlobalReportView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyEQCDCMR
                {
                    Agency = dt.Rows[i]["AgencyName"].ToString(),
                    GeoLoc = dt.Rows[i]["GeoLocation"].ToString(),

                    ImpFull20GP = dt.Rows[i]["ImpFull20GP"].ToString(),
                    ImpFull20HC = dt.Rows[i]["ImpFull20HC"].ToString(),
                    ImpFull40HC = dt.Rows[i]["ImpFull40HC"].ToString(),
                    ImpFull40RF = dt.Rows[i]["ImpFull40RF"].ToString(),

                    DeStuff20GP = dt.Rows[i]["DeStuff20GP"].ToString(),
                    DeStuff40HC = dt.Rows[i]["DeStuff40HC"].ToString(),

                    MtyReturn20GP = dt.Rows[i]["MtyReturn20GP"].ToString(),
                    MtyReturn20HC = dt.Rows[i]["MtyReturn20HC"].ToString(),
                    MtyReturn40HC = dt.Rows[i]["MtyReturn40HC"].ToString(),
                    MtyReturn40OT = dt.Rows[i]["MtyReturn40OT"].ToString(),

                    DmgUr20GP = dt.Rows[i]["DmgUr20GP"].ToString(),
                    DmgUr20HC = dt.Rows[i]["DmgUr20HC"].ToString(),
                    DmgUr40HC = dt.Rows[i]["DmgUr40HC"].ToString(),
                    DmgUr40OT = dt.Rows[i]["DmgUr40OT"].ToString(),

                    Avail20GP = dt.Rows[i]["Avail20GP"].ToString(),
                    Avail20HC = dt.Rows[i]["Avail20HC"].ToString(),
                    Avail20RF = dt.Rows[i]["Avail20RF"].ToString(),
                    Avail20FR = dt.Rows[i]["Avail20FR"].ToString(),
                    Avail40GP = dt.Rows[i]["Avail40GP"].ToString(),
                    Avail40HC = dt.Rows[i]["Avail40HC"].ToString(),
                    Avail40RF = dt.Rows[i]["Avail40RF"].ToString(),

                    OutTo20GP = dt.Rows[i]["OutTo20GP"].ToString(),
                    OutTo40HC = dt.Rows[i]["OutTo40HC"].ToString(),

                    ExpFull20GP = dt.Rows[i]["ExpFull20GP"].ToString(),
                    ExpFull20HC = dt.Rows[i]["ExpFull20HC"].ToString(),
                    ExpFull40GP = dt.Rows[i]["ExpFull40GP"].ToString(),
                    ExpFull40OT = dt.Rows[i]["ExpFull40OT"].ToString(),
                    ExpFull40HC = dt.Rows[i]["ExpFull40HC"].ToString(),
                    ExpFull40RF = dt.Rows[i]["ExpFull40RF"].ToString(),

                    MtyRepo20GP = dt.Rows[i]["MtyRepo20GP"].ToString(),
                    MtyReturn20OT = dt.Rows[i]["MtyReturn20OT"].ToString(),
                    MtyRepo40HC = dt.Rows[i]["MtyRepo40HC"].ToString(),

                    Trans20GP = dt.Rows[i]["Trans20GP"].ToString(),
                    Trans20OT = dt.Rows[i]["Trans20OT"].ToString(),
                    Trans40HC = dt.Rows[i]["Trans40HC"].ToString(),

                });
            }
            return ListExReport;
        }
        public DataTable GetDCMRGlobalReportView(MyEQCDCMR Data)
        {


            string _Query = " select * from NVO_V_DCMRGlobalView";

            return GetViewData(_Query, "");
        }

        public List<MyEQCDCMR> DCMRLocationWiseReportView(MyEQCDCMR Data)
        {
            List<MyEQCDCMR> ViewList = new List<MyEQCDCMR>();
            DataTable dt = GetDCMRLocationWiseReportView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEQCDCMR
                {
                    Description = dt.Rows[i]["Description"].ToString(),
                    DCMRLoc20GP = dt.Rows[i]["DCMRLoc20GP"].ToString(),
                    DCMRLoc20HC = dt.Rows[i]["DCMRLoc20HC"].ToString(),
                    DCMRLoc40GP = dt.Rows[i]["DCMRLoc40GP"].ToString(),
                    DCMRLoc40HC = dt.Rows[i]["DCMRLoc40HC"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetDCMRLocationWiseReportView(MyEQCDCMR Data)
        {
            if (Data.GeoLoc == "?" || Data.GeoLoc == null)
            {
                string _Query = " select Description,(select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 1 ) as DCMRLoc20GP, " +
                " (select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 10  ) as DCMRLoc20HC, " +
               " (select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 2 ) as DCMRLoc40GP, " +
             " (select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 3  )  as DCMRLoc40HC from NVO_DCMRLocwiseColumn DC ";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = "select Description,(select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 1 AND(select top 1 ID from NVO_GeoLocations where Id = A.GeolocationID) = " + Data.GeoLoc + ") as DCMRLoc20GP, " +
               " (select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 10 AND(select top 1 ID from NVO_GeoLocations where Id = A.GeolocationID) = " + Data.GeoLoc + " )    as DCMRLoc20HC, " +
               " (select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 2 AND(select top 1 ID from NVO_GeoLocations where Id = A.GeolocationID) = " + Data.GeoLoc + ") as DCMRLoc40GP, " +
              " (select COUNT(distinct C.ID) from NVO_Containers C INNER Join NVO_AgencyMaster  A on  A.ID = C.AgencyID WHERE StatusCode IN(DC.Statuscode,DC.Statuscode2,DC.Statuscode3) and TypeID = 3 AND(select top 1 ID from NVO_GeoLocations where Id = A.GeolocationID) = " + Data.GeoLoc + ") as DCMRLoc40HC from NVO_DCMRLocwiseColumn DC";
                return GetViewData(_Query, "");
            }

        }

        public List<MyEQCStock> EQCStockReport(MyEQCStock Data)
        {
            List<MyEQCStock> ViewList = new List<MyEQCStock>();
            DataTable dt = GetEQCStockReport(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEQCStock
                {
                    Country = dt.Rows[i]["Country"].ToString(),
                    Ports = dt.Rows[i]["Ports"].ToString(),

                    OFFDRY20GP = dt.Rows[i]["OFFDRY20GP"].ToString(),
                    OFFDRY40GP = dt.Rows[i]["OFFDRY40GP"].ToString(),
                    OFFREF20GP = dt.Rows[i]["OFFREF20GP"].ToString(),
                    OFFREF40GP = dt.Rows[i]["OFFREF40GP"].ToString(),
                    OFFFLAT20GP = dt.Rows[i]["OFFFLAT20GP"].ToString(),
                    OFFFLAT40GP = dt.Rows[i]["OFFFLAT40GP"].ToString(),
                    OFFOT20GP = dt.Rows[i]["OFFOT20GP"].ToString(),
                    OFFOT40GP = dt.Rows[i]["OFFOT40GP"].ToString(),

                    ACTDRY20GP = dt.Rows[i]["ACTDRY20GP"].ToString(),
                    ACTDRY40GP = dt.Rows[i]["ACTDRY40GP"].ToString(),
                    ACTREF20GP = dt.Rows[i]["ACTREF20GP"].ToString(),
                    ACTREF40GP = dt.Rows[i]["ACTREF40GP"].ToString(),
                    ACTFLAT20GP = dt.Rows[i]["ACTFLAT20GP"].ToString(),
                    ACTFLAT40GP = dt.Rows[i]["ACTFLAT40GP"].ToString(),
                    ACTOT20GP = dt.Rows[i]["ACTOT20GP"].ToString(),
                    ACTOT40GP = dt.Rows[i]["ACTOT40GP"].ToString(),



                });
            }
            return ViewList;
        }

        public DataTable GetEQCStockReport(MyEQCStock Data)
        {

            string _Query = " Select * from NVO_V_STOCKReport ";
            return GetViewData(_Query, "");


        }

        public List<MyEQCAgewise> EQCAgewiseReportView(MyEQCAgewise Data)
        {
            List<MyEQCAgewise> ViewList = new List<MyEQCAgewise>();
            DataTable dt = GetEQCAgewiseReportView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEQCAgewise
                {
                    Country = dt.Rows[i]["CountryName"].ToString(),
                    Ports = dt.Rows[i]["CurrentPort"].ToString(),
                    GeoLoc = dt.Rows[i]["GeoLocName"].ToString(),
                    StatusCode = dt.Rows[i]["StatusCode"].ToString(),

                    Dry20L7 = dt.Rows[i]["Dry20L7"].ToString(),
                    Dry40L7 = dt.Rows[i]["Dry40L7"].ToString(),
                    DryHQL7 = dt.Rows[i]["DryHQL7"].ToString(),
                    Dry20HQL7 = dt.Rows[i]["Dry20HQL7"].ToString(),
                    Dry208To14 = dt.Rows[i]["Dry208To14"].ToString(),
                    Dry408To14 = dt.Rows[i]["Dry408To14"].ToString(),
                    DryHQ8To14 = dt.Rows[i]["DryHQ8To14"].ToString(),
                    Dry20HQ8To14 = dt.Rows[i]["Dry20HQ8To14"].ToString(),
                    Dry2015To29 = dt.Rows[i]["Dry2015To29"].ToString(),
                    Dry4015To29 = dt.Rows[i]["Dry4015To29"].ToString(),
                    DryHQ15To29 = dt.Rows[i]["DryHQ15To29"].ToString(),
                    Dry20HQ15To29 = dt.Rows[i]["Dry20HQ15To29"].ToString(),
                    Dry2030To59 = dt.Rows[i]["Dry2030To59"].ToString(),
                    Dry4030To59 = dt.Rows[i]["Dry4030To59"].ToString(),
                    DryHQ30To59 = dt.Rows[i]["DryHQ30To59"].ToString(),
                    Dry20HQ30To59 = dt.Rows[i]["Dry20HQ30To59"].ToString(),
                    Dry20G59 = dt.Rows[i]["Dry20G59"].ToString(),
                    Dry40G59 = dt.Rows[i]["Dry40G59"].ToString(),
                    DryHQG59 = dt.Rows[i]["DryHQG59"].ToString(),
                    Dry20HQG59 = dt.Rows[i]["Dry20HQG59"].ToString(),


                    FlRack20L7 = dt.Rows[i]["FlRack20L7"].ToString(),
                    FlRack40L7 = dt.Rows[i]["FlRack40L7"].ToString(),
                    FlRackHQL7 = dt.Rows[i]["FlRackHQL7"].ToString(),
                    FlRack208To14 = dt.Rows[i]["FlRack208To14"].ToString(),
                    FlRack408To14 = dt.Rows[i]["FlRack408To14"].ToString(),
                    FlRackHQ8To14 = dt.Rows[i]["FlRackHQ8To14"].ToString(),
                    FlRack2015To29 = dt.Rows[i]["FlRack2015To29"].ToString(),
                    FlRack4015To29 = dt.Rows[i]["FlRack4015To29"].ToString(),
                    FlRackHQ15To29 = dt.Rows[i]["FlRackHQ15To29"].ToString(),
                    FlRack2030To59 = dt.Rows[i]["FlRack2030To59"].ToString(),
                    FlRack4030To59 = dt.Rows[i]["FlRack4030To59"].ToString(),
                    FlRackHQ30To59 = dt.Rows[i]["FlRackHQ30To59"].ToString(),
                    FlRack20G59 = dt.Rows[i]["FlRack20G59"].ToString(),
                    FlRack40G59 = dt.Rows[i]["FlRack40G59"].ToString(),
                    FlRackHQG59 = dt.Rows[i]["FlRackHQG59"].ToString(),


                    OpTop20L7 = dt.Rows[i]["OpTop20L7"].ToString(),
                    OpTop40L7 = dt.Rows[i]["OpTop40L7"].ToString(),
                    OpTopHQL7 = dt.Rows[i]["OpTopHQL7"].ToString(),
                    OpTop208To14 = dt.Rows[i]["OpTop208To14"].ToString(),
                    OpTop408To14 = dt.Rows[i]["OpTop408To14"].ToString(),
                    OpTopHQ8To14 = dt.Rows[i]["OpTopHQ8To14"].ToString(),
                    OpTop2015To29 = dt.Rows[i]["OpTop2015To29"].ToString(),
                    OpTop4015To29 = dt.Rows[i]["OpTop4015To29"].ToString(),
                    OpTopHQ15To29 = dt.Rows[i]["OpTopHQ15To29"].ToString(),
                    OpTop2030To59 = dt.Rows[i]["OpTop2030To59"].ToString(),
                    OpTop4030To59 = dt.Rows[i]["OpTop4030To59"].ToString(),
                    OpTopHQ30To59 = dt.Rows[i]["OpTopHQ30To59"].ToString(),
                    OpTop20G59 = dt.Rows[i]["OpTop20G59"].ToString(),
                    OpTop40G59 = dt.Rows[i]["OpTop40G59"].ToString(),
                    OpTopHQG59 = dt.Rows[i]["OpTopHQG59"].ToString(),

                    RF20L7 = dt.Rows[i]["RF20L7"].ToString(),
                    RF40L7 = dt.Rows[i]["RF40L7"].ToString(),
                    RFHQL7 = dt.Rows[i]["RFHQL7"].ToString(),
                    RF208To14 = dt.Rows[i]["RF208To14"].ToString(),
                    RF408To14 = dt.Rows[i]["RF408To14"].ToString(),
                    RFHQ8To14 = dt.Rows[i]["RFHQ8To14"].ToString(),
                    RF2015To29 = dt.Rows[i]["RF2015To29"].ToString(),
                    RF4015To29 = dt.Rows[i]["RF4015To29"].ToString(),
                    RFHQ15To29 = dt.Rows[i]["RFHQ15To29"].ToString(),
                    RF2030To59 = dt.Rows[i]["RF2030To59"].ToString(),
                    RF4030To59 = dt.Rows[i]["RF4030To59"].ToString(),
                    RFHQ30To59 = dt.Rows[i]["RFHQ30To59"].ToString(),
                    RF20G59 = dt.Rows[i]["RF20G59"].ToString(),
                    RF40G59 = dt.Rows[i]["RF40G59"].ToString(),
                    RFHQG59 = dt.Rows[i]["RFHQG59"].ToString(),

                    Tank20L7 = dt.Rows[i]["Tank20L7"].ToString(),
                    Tank40L7 = dt.Rows[i]["Tank40L7"].ToString(),
                    TankHQL7 = dt.Rows[i]["TankHQL7"].ToString(),
                    Tank208To14 = dt.Rows[i]["Tank208To14"].ToString(),
                    TankHQ8To14 = dt.Rows[i]["TankHQ8To14"].ToString(),
                    Tank2015To29 = dt.Rows[i]["Tank2015To29"].ToString(),
                    Tank4015To29 = dt.Rows[i]["Tank4015To29"].ToString(),
                    TankHQ15To29 = dt.Rows[i]["TankHQ15To29"].ToString(),
                    Tank2030To59 = dt.Rows[i]["Tank2030To59"].ToString(),
                    Tank4030To59 = dt.Rows[i]["Tank4030To59"].ToString(),
                    TankHQ30To59 = dt.Rows[i]["TankHQ30To59"].ToString(),
                    Tank20G59 = dt.Rows[i]["Tank20G59"].ToString(),
                    Tank40G59 = dt.Rows[i]["Tank40G59"].ToString(),
                    TankHQG59 = dt.Rows[i]["TankHQG59"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetEQCAgewiseReportView(MyEQCAgewise Data)
        {
            string strWhere = "";
            string _Query = " select * from VInvSnShotFinal ";

            if (Data.StatusCode != "" && Data.StatusCode != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " WHERE StatusCode ='" + Data.StatusCode + "'";
                else
                    strWhere += " and StatusCode ='" + Data.StatusCode + "'";



            if (Data.GeoLoc != "" && Data.GeoLoc != "0" && Data.GeoLoc != null && Data.GeoLoc != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE GeoLocID=" + Data.GeoLoc;
                else
                    strWhere += " and GeoLocID =" + Data.GeoLoc;

            if (Data.Country != "" && Data.Country != "0" && Data.Country != null && Data.Country != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE CtryID=" + Data.Country;
                else
                    strWhere += " and CtryID =" + Data.Country;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }
        public List<MyEQCAgewise> GeoLocByCountry(MyEQCAgewise Data)
        {
            List<MyEQCAgewise> ViewList = new List<MyEQCAgewise>();
            DataTable dt = GetGeoLocByCountry(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEQCAgewise
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLoc = dt.Rows[i]["GeoLocation"].ToString(),
                   

                });
            }
            return ViewList;
        }

        public DataTable GetGeoLocByCountry(MyEQCAgewise Data)
        {

            string _Query = " select * from NVO_Geolocations Where CountryID= "+Data.ID;
            return GetViewData(_Query, "");


        }

        #region getview
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

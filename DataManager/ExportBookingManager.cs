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
   public class ExportBookingManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ExportBookingManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        public List<MyExportBooking> ExistingBooking(MyExportBooking Data)
        {
            List<MyExportBooking> ListExpBooking = new List<MyExportBooking>();
            DataTable dt = GetBookingValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExpBooking.Add(new MyExportBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BookingPartyID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    BookingParty = dt.Rows[i]["BkgParty"].ToString(),
                    BookingDate = dt.Rows[i]["BkgDate"].ToString(),
                    BookingStatus = dt.Rows[i]["BookingStatus"].ToString(),
                    BookingCommission = dt.Rows[i]["BkgCommission"].ToString(),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                    Source = dt.Rows[i]["Source"].ToString(),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    Agent = dt.Rows[i]["Agent"].ToString(),
                    Origin = dt.Rows[i]["Origin"].ToString(),
                    DischargePort = dt.Rows[i]["DisChargePort"].ToString(),
                    LoadPort = dt.Rows[i]["LoadPort"].ToString(),
                    Destination = dt.Rows[i]["Destination"].ToString(),
                    Route = dt.Rows[i]["Route"].ToString(),
                    DeliveryTerms = dt.Rows[i]["DeliveryTerms"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    CargoWeight = dt.Rows[i]["CargoWeight"].ToString(),
                    HsCode = dt.Rows[i]["HSCode"].ToString(),
                    HazarOpt = Int32.Parse(dt.Rows[i]["intHazardous"].ToString()),
                    ReeferOpt = Int32.Parse(dt.Rows[i]["intReefer"].ToString()),
                    OOGOpt = Int32.Parse(dt.Rows[i]["intOOG"].ToString()),
                    PaymentTerms = dt.Rows[i]["PaymentTerms"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString().ToUpper(),
                    POLTerminal = dt.Rows[i]["POLTerminal"].ToString(),
                    TsVesselName = dt.Rows[i]["TsVesselName"].ToString(),
                    TsVoyageNo = dt.Rows[i]["TSVoyageNo"].ToString(),
                    Principal = dt.Rows[i]["Principal"].ToString(),
                    CusContractNo = dt.Rows[i]["CusContractNo"].ToString(),
                    LinerContractNo = dt.Rows[i]["LinerContractNo"].ToString(),
                    PODAgent = dt.Rows[i]["PODAgent"].ToString(),
                    FPODAgent = dt.Rows[i]["FPODAgent"].ToString(),
                    TSPortAgent1 = dt.Rows[i]["TSPortAgent1"].ToString(),
                    TSPortAgent2 = dt.Rows[i]["TSPortAgent2"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    Ownership = dt.Rows[i]["Ownership"].ToString(),
                    Fixed = dt.Rows[i]["Fixed"].ToString(),
                    FreeDaysOrignValue = dt.Rows[i]["FreeDaysOrgValue"].ToString(),
                    FreeDaysDesValue = dt.Rows[i]["FreeDaysDestValue"].ToString(),
                    DamageSchemeValue = dt.Rows[i]["DamageSchemeValue"].ToString(),
                    SecurityDepositValue = dt.Rows[i]["SecurityDepositDesc"].ToString(),
                    BolReqValue = dt.Rows[i]["BOLReqDesc"].ToString(),
                    VesselID = dt.Rows[i]["VesselID"].ToString(),
                    VoyageID = dt.Rows[i]["VoyageID"].ToString(),
                    OfficeCode = dt.Rows[i]["OfficeCode"].ToString(),
                    FreeDayOrigin = Int32.Parse(dt.Rows[i]["FreeDaysOrigin"].ToString()),
                    FreeDayDestination = Int32.Parse(dt.Rows[i]["FreeDaysDest"].ToString()),
                    DamageScheme = Int32.Parse(dt.Rows[i]["DamageScheme"].ToString()),
                    SecurityDeposit = Int32.Parse(dt.Rows[i]["SecurityDeposit"].ToString()),
                    BOLRequirement = Int32.Parse(dt.Rows[i]["BOLReq"].ToString()),
                    PaymentCenter = dt.Rows[i]["PaymentCenter"].ToString(),
                    SlotUpto = dt.Rows[i]["SlotUpto"].ToString(),
                });

            }
            return ListExpBooking;
        }
        public DataTable GetBookingValues(MyExportBooking Data)
        {
            string _Query = "select NVO_Booking.ID,NVO_Booking.VesselID,NVO_Booking.VoyageID,(select OfficeLoc from NVO_OfficeMaster where NVO_OfficeMaster.ID = NVO_Booking.OfficeCode)as OfficeCode,(select Customername from NVO_view_CustomerDetails where NVO_view_CustomerDetails.CID = NVO_Booking.CustomerID)as BkgParty, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_Booking.PaymentCenterID)as PaymentCenter,(select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.SlotUptoID)as SlotUpto, " +
                            " case when intStatus = 2 then 'Confirm' else 'Draft' end as BookingStatus,BookingNo,convert(varchar, EnquiryDate, 103) as BkgDate, " +
                            " case when bookingcommissionID = 1 then 'Yes' else 'No' end as BkgCommission,(select top(1) EnquiryNo from NVO_Enquiry where Id = EnquiryID) as EnquiryNo, " +
                            " case when enquirySourceID = 1 then 'Local' else 'Nomination' end as Source,(select Top(1) username from NVO_UserDetails where NVO_UserDetails.ID = NVO_Booking.SalesPersonID)as SalesPerson, " +
                            " (select Top(1) AgencyName from NVO_AgencyMaster where ID = NVO_Booking.SalesPersonID)as Agent, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.OriginID)as Origin, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.LoadPortID)as LoadPort, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DischargePortID)as DisChargePort, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DestinationID)as Destination, " +
                            " (select GeneralName from NVO_GeneralMaster where SeqNo = 49 and ID = RouteID)as Route, " +
                            " (select GeneralName from NVO_GeneralMaster where SeqNo = 75 and ID = DeliveryTermsID)as DeliveryTerms,CargoID as Commodity, " +                            
                            "CargoWeight,HSCode,intHazardous,intReefer,intOOG,Case When PaymentTermsID=1 then 'Prepaid' else case when PaymentTermsID=2 then 'Collect' end end as PaymentTerms, " +
                            " (select vesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID)as VesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                            " (select PortCode + '-' + PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.POLTerminalID)as POLTerminal, " +
                            " (select vesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.TSVesselID)as TsVesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.TSVoyageID)as TSVoyageNo, " +
                            " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID)as Principal, " +
                            " (select RequestNo  from NVO_PrincipalRateRequest where NVO_PrincipalRateRequest.ID = NVO_Booking.LineContractID)as LinerContractNo, " +
                            " (select ContractNo from NVO_CustomerContract where NVO_CustomerContract.ID = NVO_Booking.CustomerContractID)as CusContractNo, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.PODAgentID)as PODAgent, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.FPODAgentID)as FPODAgent, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.TSportAgentID)as TSPortAgent1, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.TSportTwoAgentID)as TSPortAgent2, " +
                            " (select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_Booking.SlotOperatorID)as SlotOperator, " +
                            " case when OwnershipID = 1 then 'COC' else 'SOC' end as Ownership, " +
                            " case when FixedID = 1 then 'Yes' else 'No' end as Fixed,FreeDaysOrigin,FreeDaysDest,DamageScheme,SecurityDeposit,BOLReq,case when FreeDaysOrigin=1 then 'Standard' else 'Special' end as FreeDaysOrg,FreeDaysOrgValue, " +
                            " case when FreeDaysDest = 1 then 'Standard' else 'Special' end as FreeDaysDes,FreeDaysDestValue, " +
                            " case when DamageScheme = 1 then 'Standard' else 'Special' end as DamageScheme,DamageSchemeValue, " +
                            " case when SecurityDeposit = 1 then 'Standard' else 'Special' end as SecurityDeposit,SecurityDepositDesc, " +
                            " case when BOLReq = 1 then 'Standard' else 'Special' end as BOLReq,BOLReqDesc, " +
                            " * from NVO_Booking where NVO_Booking.ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgContainer> ExistingBookingCntrBind(MyExpBkgContainer Data)
        {
            List<MyExpBkgContainer> ListEnq = new List<MyExpBkgContainer>();
            DataTable dt = GetExistingCntrTypeBookingRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgContainer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                });
            }
            return ListEnq;
        }
        public DataTable GetExistingCntrTypeBookingRecord(MyExpBkgContainer Data)
        {
            string _Query = " select NVO_BookingCntrType.ID,(select Size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_BookingCntrType.CntrTypeID)as CntrType,Nos from NVO_BookingCntrType where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgHaz> ExistingHazardous(MyExpBkgHaz Data)
        {
            List<MyExpBkgHaz> ListEnq = new List<MyExpBkgHaz>();
            DataTable dt = GetExisHazardous(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgHaz
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString(),
                    HazardousClass = dt.Rows[i]["HazardousClass"].ToString(),
                    MCONumber = dt.Rows[i]["MCONumber"].ToString(),
                });
            }
            return ListEnq;
        }
        public DataTable GetExisHazardous(MyExpBkgHaz Data)
        {
            string _Query = "select NVO_BookingHazardous.ID,NVO_BookingHazardous.BkgID,(select CommodityName from NVO_CommodityMaster where NVO_CommodityMaster.ID = NVO_BookingHazardous.CommodityID)as CommodityName,HazardousClass,MCONumber " +
                            " from NVO_BookingHazardous where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgReefer> ExistingReefer(MyExpBkgReefer Data)
        {
            List<MyExpBkgReefer> ListEnq = new List<MyExpBkgReefer>();
            DataTable dt = GetExistingReefer(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgReefer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    Ventilation = dt.Rows[i]["Ventilation"].ToString(),
                    Humidity = dt.Rows[i]["Humidity"].ToString(),
                });
            }
            return ListEnq;
        }
        public DataTable GetExistingReefer(MyExpBkgReefer Data)
        {
            string _Query = "select NVO_BookingReffer.ID,NVO_BookingReffer.BkgID, " +
                            " (select CommodityName from NVO_CommodityMaster where NVO_CommodityMaster.ID = NVO_BookingReffer.CommodityID) as CommodityName, " +
                            " Temperature, Ventilation, Humidity from NVO_BookingReffer where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgOutGauge> ExistingOutGauge(MyExpBkgOutGauge Data)
        {
            List<MyExpBkgOutGauge> ListEnq = new List<MyExpBkgOutGauge>();
            DataTable dt = GetExistingOutGauges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgOutGauge
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString(),
                    CargoLenght = dt.Rows[i]["CargoLength"].ToString(),
                    CargoWidth = dt.Rows[i]["CargoWidth"].ToString(),
                    CargoHeight = dt.Rows[i]["CargoHeight"].ToString(),
                });
            }
            return ListEnq;
        }
        public DataTable GetExistingOutGauges(MyExpBkgOutGauge Data)
        {
            string _Query = " select NVO_BookingOutGaugesCargo.ID,NVO_BookingOutGaugesCargo.BkgID,NVO_BookingOutGaugesCargo.CargoLength,NVO_BookingOutGaugesCargo.CargoWidth, " +
                            " NVO_BookingOutGaugesCargo.CargoHeight,(select CommodityName from NVO_CommodityMaster where NVO_CommodityMaster.ID = NVO_BookingOutGaugesCargo.CommodityID)as CommodityName " +
                            " from NVO_BookingOutGaugesCargo where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgOceanFrtCharges> ExistingOceanFrtCharges(MyExpBkgOceanFrtCharges Data)
        {
            List<MyExpBkgOceanFrtCharges> ListEnq = new List<MyExpBkgOceanFrtCharges>();
            DataTable dt = GetExistingOceanFreightCharges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgOceanFrtCharges
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityName = dt.Rows[i]["Commodity"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    FrtChargePerAmt = dt.Rows[i]["FrtChargePerAmt"].ToString(),
                    ManifestAmt = dt.Rows[i]["ManifestAmt"].ToString(),
                    CommissionPerAmt = dt.Rows[i]["CommissionPerAmt"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                });
            }
            return ListEnq;
        }


        public DataTable GetExistingOceanFreightCharges(MyExpBkgOceanFrtCharges Data)
        {
            string _Query = " select NVO_BookingFreightRate.ID, " +
                            " (select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_BookingFreightRate.CargoID) as Commodity, " +
                            " (select top(1) Size from NVO_tblCntrTypes where Id = NVO_BookingFreightRate.CntrTypeID) as CntrType, " +
                            " (select CurrencyCode from NVO_CurrencyMaster where Id = NVO_BookingFreightRate.CurrencyID) as Currency,FrtChargePerAmt,ManifestAmt,CommissionPerAmt,Nos " +
                            " from NVO_BookingFreightRate where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyExpBkgOceanFrtCharges> ExistingSlotFrtCharges(MyExpBkgOceanFrtCharges Data)
        {
            List<MyExpBkgOceanFrtCharges> ListEnq = new List<MyExpBkgOceanFrtCharges>();
            DataTable dt = GetExistingSlotFreightCharges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgOceanFrtCharges
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityName = dt.Rows[i]["Commodity"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    FrtChargePerAmt = dt.Rows[i]["PerAmount"].ToString(),
                    FrtChargePerAmtTotal = dt.Rows[i]["TotalAmount"].ToString(),
                    ManifestAmt = dt.Rows[i]["ManifestPerAmount"].ToString(),
                    ManifestAmtTotal = dt.Rows[i]["ManifestTotalAmount"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                });
            }
            return ListEnq;
        }

        public DataTable GetExistingSlotFreightCharges(MyExpBkgOceanFrtCharges Data)
        {
            string _Query = " select NVO_BookingSlotRate.ID, " +
                            " (select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_BookingSlotRate.CommodityID) as Commodity, " +
                            " (select top(1) Size from NVO_tblCntrTypes where Id = NVO_BookingSlotRate.CntrTypeID) as CntrType, " +
                            " (select CurrencyCode from NVO_CurrencyMaster where Id = NVO_BookingSlotRate.CurrencyID) as Currency,Nos,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount " +
                            " from NVO_BookingSlotRate where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgShipmentTerms> ExistingPOL(MyExpBkgShipmentTerms Data)
        {
            List<MyExpBkgShipmentTerms> ListEnq = new List<MyExpBkgShipmentTerms>();
            DataTable dt = GetExistingBkgPOLDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgShipmentTerms
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    PolCharges = dt.Rows[i]["PolCharges"].ToString(),
                    Amount2 = dt.Rows[i]["Amount2"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                });
            }
            return ListEnq;
        }
        public DataTable GetExistingBkgPOLDtls(MyExpBkgShipmentTerms Data)
        {
            string _Query = " select NVO_BookingShimpmentPOL.ID,(select top(1) Size from NVO_tblCntrTypes where Id = NVO_BookingShimpmentPOL.CntrTypeID) as CntrType, " +
                            " case when ChargeOPT = 1 then 'Standard' else 'Special' end as PolCharges, " +
                            " (select CurrencyCode from NVO_CurrencyMaster where Id = NVO_BookingShimpmentPOL.CurrencyID) as Currency,Amount2,Remarks " +
                            " from NVO_BookingShimpmentPOL where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExpBkgShipmentTerms> ExistingPOD(MyExpBkgShipmentTerms Data)
        {
            List<MyExpBkgShipmentTerms> ListEnq = new List<MyExpBkgShipmentTerms>();
            DataTable dt = GetExistingBkgPODDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyExpBkgShipmentTerms
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    PolCharges = dt.Rows[i]["PolCharges"].ToString(),
                    Amount2 = dt.Rows[i]["Amount2"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                });
            }
            return ListEnq;
        }
        public DataTable GetExistingBkgPODDtls(MyExpBkgShipmentTerms Data)
        {
            string _Query = " select NVO_BookingShimpmentPOD.ID,(select top(1) Size from NVO_tblCntrTypes where Id = NVO_BookingShimpmentPOD.CntrTypeID) as CntrType, " +
                            " case when ChargeOPT = 1 then 'Standard' else 'Special' end as PolCharges, " +
                            " (select CurrencyCode from NVO_CurrencyMaster where Id = NVO_BookingShimpmentPOD.CurrencyID) as Currency,Amount2,Remarks " +
                            " from NVO_BookingShimpmentPOD where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
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

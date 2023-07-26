using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataManager;
using DataTier;
using Microsoft.Extensions.Configuration;
using nvocc.FunServices;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesApiController : ControllerBase
    {
        #region Muthu

        [HttpPost("SalesMRGInsert")]
        public List<MyMRG> SalesMRGInsert(MyMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyMRG> st = cm.InsertMRGMaster(Data);
            return st;
        }

        [HttpPost("MRGViewRecord")]
        public List<MyMRG> MRGViewRecord(MyMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyMRG> st = cm.MRGRecordView(Data);
            return st;
        }

        [HttpPost("MRGExistingMasterRecord")]
        public List<MyMRG> MRGExistingMasterRecord(MyMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyMRG> st = cm.MRGExistingMasterRecordView(Data.ID.ToString());
            return st;
        }


        [HttpPost("SalesSLOTInsert")]
        public List<MySLOT> SalesSLOTInsert(MySLOT Data)
        {
            SalesManager cm = new SalesManager();
            List<MySLOT> st = cm.InsertSLOTMaster(Data);
            return st;
        }

        [HttpPost("SLOTViewRecord")]
        public List<MySLOT> SLOTViewRecord(MySLOT Data)
        {
            SalesManager cm = new SalesManager();
            List<MySLOT> st = cm.SLOTRecordView(Data);
            return st;
        }
        [HttpPost("SLOTExistingRecord")]
        public List<MySLOT> SLOTExistingRecord(MySLOT Data)
        {
            SalesManager cm = new SalesManager();
            List<MySLOT> st = cm.SLOTExistingRecordView(Data.ID.ToString());
            return st;
        }

        [HttpPost("SLOTExistingMasterRecord")]
        public List<MySLOT> SLOTExistingMasterRecord(MySLOT Data)
        {
            SalesManager cm = new SalesManager();
            List<MySLOT> st = cm.SLOTExistingMasterRecordView(Data.ID.ToString());
            return st;
        }

        [HttpPost("CheckTariffValidation")]
        public List<MYPortTariffMaster> CheckTariffValidation(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.ExistTariffValidation(Data);
            return st;
        }

        [HttpPost("SalesPortTariffInsert")]
        public List<MYPortTariffMaster> SalesPortTariffInsert(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.InsertPortTariffMaster(Data);
            return st;
        }


        [HttpPost("SalesPortTariffRevenuDOChargesInsert")]
        public List<MYPortTariffMaster> SalesPortTariffRevenuDOChargesInsert(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.InsertPortTariffRevenuDOChargesMaster(Data);
            return st;
        }

        [HttpPost("InsertPortTariffTHCChargesMaster")]
        public List<MYPortTariffMaster> InsertPortTariffTHCChargesMaster(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.InsertPortTariffTHCChargesMaster(Data);
            return st;
        }

        [HttpPost("InsertPortTariffIHCBrackupChargesMaster")]
        public List<MYPortTariffMaster> InsertPortTariffIHCBrackupChargesMaster(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.InsertPortTariffIHCBrackupChargesMaster(Data);
            return st;
        }



        [HttpPost("InsertPortTariffChargeInsert")]
        public List<MYPortTariffMaster> InsertPortTariffChargeInsert(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.InsertPortTariffChargeMaster(Data);
            return st;
        }

        [HttpPost("InsertPortTariffIHCChargeInsert")]
        public List<MYPortTariffMaster> InsertPortTariffIHCChargeInsert(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.InsertPortTariffIHCChargeMaster(Data);
            return st;
        }



        [HttpPost("PortTariffChargeViewRecord")]
        public List<MYPortTariffMaster> PortTariffChargeViewRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTariffChargeExistingRecordView(Data);
            return st;
        }

        [HttpPost("PortTariffIHCChargeViewRecord")]
        public List<MYPortTariffMaster> PortTariffIHCChargeViewRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTariffIHCChargeExistingRecordView(Data);
            return st;
        }



        [HttpPost("PortTariffViewRecord")]
        public List<MYPortTariffMaster> PortTariffViewRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTariffRecordView(Data);
            return st;
        }


        [HttpPost("PortTariffExistingMasterRecord")]
        public List<MYPortTariffMaster> PortTariffExistingMasterRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTariffExistingMasterRecordView(Data.ID.ToString());
            return st;
        }

        [HttpPost("PortTariffExistingRecord")]
        public List<MYPortTariffMaster> PortTariffExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffDtlsExistingView(Data);
            return st;
        }


        [HttpPost("PortTariffSlabExistingRecord")]
        public List<MYPortTariffMaster> PortTariffSlabExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffSlabExistingView(Data);
            return st;
        }


        [HttpPost("PortTariffStorageExistingRecord")]
        public List<MYPortTariffMaster> PortTariffStorageExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffStorageExistingView(Data);
            return st;
        }





        [HttpPost("PortTariffRevenuDOChargesExistingRecord")]
        public List<MYPortTariffMaster> PortTariffRevenuDOChargesExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffRevenuDOChargesExistingView(Data);
            return st;
        }

        [HttpPost("PortTariffTHCChargesBrackupExistingRecord")]
        public List<MYPortTariffMaster> PortTariffTHCChargesBrackupExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffTHCBrackupChargesExistingView(Data);
            return st;
        }

        [HttpPost("PortTariffIHCChargesBrackupExistingRecord")]
        public List<MYPortTariffMaster> PortTariffIHCChargesBrackupExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffIHCBrackupChargesExistingView(Data);
            return st;
        }



        [HttpPost("PortTariffIHCExistingRecord")]
        public List<MYPortTariffMaster> PortTariffIHCExistingRecord(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTraiffIHCExistingView(Data);
            return st;
        }



        [HttpPost("PortTariffDelete")]
        public List<MYPortTariffMaster> PortTariffDelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.PortTariffDelete(Data);
            return st;
        }

        [HttpPost("PortTariffBrackupDelete")]
        public List<MYPortTariffMaster> PortTariffBrackupDelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffBrackupRecord(Data);
            return st;
        }


        #region Ratesheet

        [HttpPost("RatesheetInsert")]
        public List<MyRatesheet> RatesheetInsert(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetMaster(Data);
            return st;
        }

        [HttpPost("RatesheetInsertNew")]
        public List<MyRatesheet> RatesheetInsertNew(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetMasterNew(Data);
            return st;
        }

        [HttpPost("RatesheetValidityInsert")]
        public List<MyRatesheet> RatesheetValidityInsert(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetMasterNewvalidity(Data);
            return st;
        }
        public List<MyRatesheet> RatesheetCastInsertNew(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetCastMasterNew(Data);
            return st;
        }

        [HttpPost("RRForeExpire")]
        public List<MyRatesheet> RRForeExpire(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RRForeExpirevalues(Data);
            return st;
        }

        [HttpPost("RateSheetViewRecord")]
        public List<MyRatesheet> RateSheetViewRecord(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetRecordView(Data);
            return st;
        }


        [HttpPost("RateSheetExistingMasterRecord")]
        public List<MyRatesheet> RateSheetExistingMasterRecord(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetExistingMasterRecordView(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RateSheetBookingCntrTypes")]
        public List<MyRatesheet> RateSheetBookingCntrTypes(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetBkgCntrTypes(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RateSheetDashBordExisting")]
        public List<MyRatesheet> RateSheetDashBordExisting(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetExistingDashBoard(Data.RRID.ToString());
            return st;
        }


        [HttpPost("SalesRatesheetContainerInsert")]
        public List<MyRatesheet> SalesRatesheetContainerInsert(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetContainerMaster(Data);
            return st;
        }

        [HttpPost("RateSheetContainerExsisting")]
        public List<MyRatesheet> RateSheetContainerExsisting(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetContainerExistingView(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RateSheetModeExsisting")]
        public List<MyRatesheet> RateSheetModeExsisting(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetModeExistingView(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RateSheetTsPortExsisting")]
        public List<MyRatesheet> RateSheetTsPortExsisting(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetTsPortExistingView(Data.RRID.ToString());
            return st;
        }


        [HttpPost("SalesRatesheetChargesInsert")]
        public List<MyRatesheet> SalesRatesheetChargesInsert(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetRateChargeMaster(Data);
            return st;
        }


        [HttpPost("RateSheetRevRateExsisting")]
        public List<MyRatesheetRates> RateSheetRevRateExsisting(MyRatesheetRates Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheetRates> st = cm.RatesheetRevRateExistingView(Data);
            return st;
        }


        [HttpPost("RateSheetCostRateExsisting")]
        public List<MyRatesheetRates> RateSheetCostRateExsisting(MyRatesheetRates Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheetRates> st = cm.RatesheetCostRateExistingView(Data);
            return st;
        }

        [HttpPost("RateSheetCostRateTransExsisting")]
        public List<MyRatesheetRates> RateSheetCostRateTransExsisting(MyRatesheetRates Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheetRates> st = cm.RatesheetCostRateTransExistingView(Data);
            return st;
        }


        [HttpPost("RateSheetMRG")]
        public List<MyRRMRG> RateSheetMRG(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.RatesheetMRGView(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RateSheetSLOTView")]
        public List<MyRRMRG> RateSheetSLOTView(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.RatesheetSLOTView(Data.RRID.ToString());
            return st;
        }
        [HttpPost("RateSheetSLOTDtlsView")]
        public List<MyRRMRG> RateSheetSLOTDtlsView(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.RatesheetSLOTDtlsView(Data.RRID.ToString());
            return st;
        }


        [HttpPost("SalesRatesheetSLTMRGInsert")]
        public List<MyRRMRG> SalesRatesheetSLTMRGInsert(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.InsertRatesheetMRGSLOTMaster(Data);
            return st;
        }

        [HttpPost("SalesRatesheetMRGSelect")]
        public List<MyRRMRG> SalesRatesheetMRGSelect(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.RatesheetMRGSelectView(Data);
            return st;
        }

        [HttpPost("SalesRatesheetSLOTSelect")]
        public List<MyRRMRG> SalesRatesheetSLOTSelect(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.RatesheetSLOTSelectView(Data);
            return st;
        }

        [HttpPost("SalesRatesheetSLOTDtlSelect")]
        public List<MyRRMRG> SalesRatesheetSLOTDtlSelect(MyRRMRG Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRMRG> st = cm.RatesheetSLOTDtlsSelectView(Data);
            return st;
        }


        [HttpPost("RateSheetCheckTariffRateRevPOLExsisting")]
        public List<MyRatesheetRates> RateSheetCheckTariffRateRevPOLExsisting(MyRatesheetRates Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheetRates> st = cm.RatesheetCeckTariffRevRateExistingView(Data);
            return st;
        }


        [HttpPost("SalesRatesheetRebateInsert")]
        public List<MyRatesheet> SalesRatesheetRebateInsert(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.InsertRatesheetRebateMaster(Data);
            return st;
        }


        [HttpPost("RateSheetRebateExsisting")]
        public List<MyRatesheetRates> RateSheetRebateExsisting(MyRatesheetRates Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheetRates> st = cm.RatesheetRebateExistingView(Data);
            return st;
        }
        #endregion

        [HttpPost("SalesRRSendApproval")]
        public List<MyRatesheet> SalesRRSendApproval(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.SendingApproval(Data);
            return st;
        }

        [HttpPost("RateSheetNotification")]
        public List<MyRatesheet> RateSheetNotification(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RRNotificationRecordView(Data);
            return st;
        }

        [HttpPost("SalesRRFinalSubmitCheck")]
        public List<MyRatesheet> SalesRRFinalSubmitCheck(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RRFinalSubmitCheckRecordView(Data);
            return st;
        }

        [HttpPost("RRDashBordCount")]
        public List<MyRatesheet> RRDashBordCount(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RRDashBordCountRecordView(Data);
            return st;
        }


        [HttpPost("RRFreighTariff")]
        public List<MyRRRate> RRFreighTariff(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.RRFreighTariff(Data);
            return st;
        }

        [HttpPost("RRFreighTariffLocalAmt")]
        public List<MyRRRate> RRFreighTariffLocalAmt(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.RRFreighTariffLocalAmt(Data);
            return st;
        }


        [HttpPost("ExistRateFreightLocalChargeAmt")]
        public List<MyRRRate> ExistRateFreightLocalChargeAmt(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.ExistingRateSheetFreighTariffLocalAmt(Data);
            return st;
        }

        [HttpPost("RRTariffExistingValues")]
        public List<MyRRRate> RRTariffExistingValues(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.RRTariffExisting(Data);
            return st;
        }
        [HttpPost("RRTariffLocalExistingValues")]
        public List<MyRRRate> RRTariffLocalExistingValues(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.RRTariffExistingLocalcharge(Data);
            return st;
        }

        [HttpPost("RRBkgPartSales")]
        public List<MyRRRate> RRBkgPartSales(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.RRBkgPartSales(Data);
            return st;
        }

        [HttpPost("ListUsers")]
        public List<MyRRRate> RRListUsers(MyRRRate Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRRRate> st = cm.RRListUsers(Data);
            return st;
        }
        #endregion

        #region ganesh RR NOTIFICATION//Commission Contract //IHC TARIFF


        [HttpPost("RateSheetNotificationPopup")]
        public List<MyRatesheet> RateSheetNotificationPopup(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RatesheetNotificationValues(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RateSheetNotificationTHCandIHC")]
        public List<MyRatesheet> RateSheetNotificationTHCandIHC(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RateSheetNotificationTHCandIHCValues(Data.RRID.ToString());
            return st;
        }

        [HttpPost("RRNotificationChargewiseRates")]
        public List<MyRatesheet> RRNotificationChargewiseRates(MyRatesheet Data)
        {
            SalesManager cm = new SalesManager();
            List<MyRatesheet> st = cm.RRNotificationChargewiseRates(Data.RRID.ToString());
            return st;
        }

        [HttpPost("CommissionCharges")]
        public List<MyCommContract> CommissionCharges(MyCommContract Data)
        {
            SalesManager cm = new SalesManager();
            List<MyCommContract> st = cm.CommissionChargesValues(Data.ChargeCommTypes.ToString());
            return st;
        }

        [HttpPost("ShipmentTypes")]
        public List<MyCommContract> ShipmentTypes(MyCommContract Data)
        {
            SalesManager cm = new SalesManager();
            List<MyCommContract> st = cm.ShipmentTypesValues(Data.ShipmentTypes.ToString());
            return st;
        }

        [HttpPost("InsertCommissionContract")]
        public List<MyCommContract> InsertCommissionContract(MyCommContract Data)
        {
            SalesManager cm = new SalesManager();
            List<MyCommContract> st = cm.InsertCommissionContract(Data);
            return st;
        }
        [HttpPost("CommContractView")]
        public List<MyCommContract> CommContractViewValues(MyCommContract Data)
        {
            SalesManager cm = new SalesManager();
            List<MyCommContract> st = cm.GetCommContractView(Data);
            return st;
        }

        [HttpPost("CommContractEdit")]
        public List<MyCommContract> CommContractEdit(MyCommContract Data)
        {
            SalesManager cm = new SalesManager();
            List<MyCommContract> st = cm.CommContractEditValues(Data);
            return st;
        }

        [HttpPost("CheckCCValidation")]
        public List<MyCommContract> CheckCCValidation(MyCommContract Data)
        {
            SalesManager cm = new SalesManager();
            List<MyCommContract> st = cm.ExistCheckCCValidation(Data);
            return st;
        }

        [HttpPost("InsertIHCTariffMaster")]
        public List<MyIHCTariff> InsertIHCTariffMaster(MyIHCTariff Data)
        {
            SalesManager cm = new SalesManager();
            List<MyIHCTariff> st = cm.InsertIHCTariffMaster(Data);
            return st;
        }

        [HttpPost("IHCHaulageTariffViewRecord")]
        public List<MyIHCTariff> IHCHaulageTariffViewValues(MyIHCTariff Data)
        {
            SalesManager cm = new SalesManager();
            List<MyIHCTariff> st = cm.IHCHaulageTariffViewValues(Data);
            return st;
        }

        [HttpPost("IHCHaulageTariffVEdit")]
        public List<MyIHCTariff> IHCHaulageTariffVEdit(MyIHCTariff Data)
        {
            SalesManager cm = new SalesManager();
            List<MyIHCTariff> st = cm.IHCHaulageTariffVEditValues(Data);
            return st;
        }
        [HttpPost("IHCHaulageTariffDtlsEdit")]
        public List<MyIHCTariff> IHCHaulageTariffDtlsEdit(MyIHCTariff Data)
        {
            SalesManager cm = new SalesManager();
            List<MyIHCTariff> st = cm.IHCHaulageTariffDtlsEditValues(Data);
            return st;
        }
        [HttpPost("IHCHaulageTariffDtlsDelete")]
        public List<MyIHCTariff> IHCHaulageTariffDtlsDelete(MyIHCTariff Data)
        {
            SalesManager cm = new SalesManager();
            List<MyIHCTariff> st = cm.GetIHCHaulageTariffDtlsDelete(Data);
            return st;
        }
        [HttpPost("IHCHaulageTariffValidation")]
        public List<MyIHCTariff> IHCHaulageTariffValidation(MyIHCTariff Data)
        {
            SalesManager cm = new SalesManager();
            List<MyIHCTariff> st = cm.IHCHaulageTariffValidation(Data);
            return st;
        }
        #endregion


        #region Ganesh Empty Yardc cntr Cost

        [HttpPost("GeoLocByCountry")]
        public List<MyEmptyYard> GeoLocByCountry(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.GeoLocByCountry(Data);
            return st;
        }

        [HttpPost("InsertEmptyYardCosts")]
        public List<MyEmptyYard> InsertEmptyYardCosts(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.InsertEmptyYardCosts(Data);
            return st;
        }
        [HttpPost("EmptyYardTariffViewRecord")]
        public List<MyEmptyYard> EmptyYardTariffViewRecord(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.EmptyYardTariffViewRecord(Data);
            return st;
        }
        [HttpPost("EmptyYardTariffEdit")]
        public List<MyEmptyYard> EmptyYardTariffEdit(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.EmptyYardTariffEditValues(Data);
            return st;
        }

        [HttpPost("EmptyYardTariffSlabEdit")]
        public List<MyEmptyYard> EmptyYardTariffSlabEdit(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.EmptyYardTariffSlabEdit(Data);
            return st;
        }
        [HttpPost("EmptyYardTariffPortCostEdit")]
        public List<MyEmptyYard> EmptyYardTariffPortCostEdit(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.EmptyYardTariffPortCostEdit(Data);
            return st;
        }

        [HttpPost("EmptyYardTariffValidation")]
        public List<MyEmptyYard> EmptyYardTariffValidation(MyEmptyYard Data)
        {
            SalesManager cm = new SalesManager();
            List<MyEmptyYard> st = cm.EmptyYardTariffValidation(Data);
            return st;
        }
        #endregion




        [HttpPost("PortTariffChargedelete")]
        public List<MYPortTariffMaster> PortTariffChargedelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffChargesRecord(Data);
            return st;
        }


        [HttpPost("PortTariffDetentionExpdelete")]
        public List<MYPortTariffMaster> PortTariffDetentionExpdelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffDetentionExpRecord(Data);
            return st;
        }

        [HttpPost("PortTariffStorageExpdelete")]
        public List<MYPortTariffMaster> PortTariffStorageExpdelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffStorageExpRecord(Data);
            return st;
        }

        [HttpPost("PortTariffIHCdelete")]
        public List<MYPortTariffMaster> PortTariffIHCdelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffIHCRecord(Data);
            return st;
        }


        [HttpPost("PortTariffDOChargesdelete")]
        public List<MYPortTariffMaster> PortTariffDOChargesdelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffDochargesRecord(Data);
            return st;
        }


        [HttpPost("PortTariffTHCBrackupChargesdelete")]
        public List<MYPortTariffMaster> PortTariffTHCBrackupChargesdelete(MYPortTariffMaster Data)
        {
            SalesManager cm = new SalesManager();
            List<MYPortTariffMaster> st = cm.DeleteTariffTHCBrackupchargesRecord(Data);
            return st;
        }

    }
}

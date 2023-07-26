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
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace DataManager
{
    public class EnquiryMaster
    {
        List<MyEnquiry> ListView = new List<MyEnquiry>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public EnquiryMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyEnquiry> PriciblePortList(MyEnquiry Data)
        {
            DataTable dt = GetPriciblePortList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString()
                });
            }
            return ListView;
        }
        public DataTable GetPriciblePortList(MyEnquiry Data)
        {
            string _Query = " select NVO_AgencyMaster.ID,AgencyName from NVO_AgencyPrincipalDtls " +
                            " inner join NVO_AgencyMaster on NVO_AgencyMaster.ID = NVO_AgencyPrincipalDtls.AgencyID " +
                            " where PrincipalID = " + Data.PrincibalID + " order by Id asc";
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> EnquiryOccenFreightCharges(MyEnquiry Data)
        {
            DataTable dt = GetEnquiryOccenFreightCharges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["EquipmentTypeID"].ToString(),
                    CntrType = dt.Rows[i]["Size"].ToString(),
                    Nos = dt.Rows[i]["Countv"].ToString(),
                    PerAmount = dt.Rows[i]["PerAmount"].ToString(),
                    TotalAmount = dt.Rows[i]["Amount"].ToString(),
                    Currency = dt.Rows[i]["Curr"].ToString(),
                    ManifestPerAmount = dt.Rows[i]["PerManifestAmount"].ToString(),
                    ManifestTotalAmount = dt.Rows[i]["ManifestAmount"].ToString(),
                    CommPerAmount = dt.Rows[i]["CommperAmt"].ToString(),
                    CommTotal = dt.Rows[i]["CommTotal"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),

                });
            }
            return ListView;
        }


        public DataTable GetEnquiryOccenFreightCharges(MyEnquiry Data)
        {
            string _Query = " select distinct 0 as ID,EquipmentTypeID, (select top(1) Type from NVO_tblCntrTypes where Id = NVO_PortTariffMaster.EquipmentTypeID) as Size, " +
                            " (select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) as Countv, sum(Amount) as PerAmount, " +
                            " ((select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) *sum(Amount)) as Amount, " +
                            " (select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) as Countv, sum(Amount) as PerManifestAmount, " +
                            " ((select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) *sum(Amount)) as ManifestAmount, " +
                            " (select  top(1) Amount from NVO_PrincipalMasterdtls inner join NVO_PrincipalMaster on NVO_PrincipalMaster.ID = NVO_PrincipalMasterdtls.PID " +
                            " where TariffType = 1 and NVO_PrincipalMaster.Id = NVO_PortTariffMaster.PrincibleID) as CommperAmt, " +
                            " ((select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) * " +
                            " (select  top(1) Amount from NVO_PrincipalMasterdtls inner join NVO_PrincipalMaster on NVO_PrincipalMaster.ID = NVO_PrincipalMasterdtls.PID " +
                            " where TariffType = 1 and NVO_PrincipalMaster.Id = NVO_PortTariffMaster.PrincibleID)) CommTotal, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = NVO_PortTariffdtls.CurrencyID) as Curr,CurrencyID," +
                            " (select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_PortTariffdtls.CommodityID) as Commodity,CommodityID " +
                            " from NVO_PortTariffMaster " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.Id " +
                            " where PrincibleID = 13  and PortTariffTypeID = 1  and EffectiveDate <= getdate() " +
                            " group by EquipmentTypeID,NVO_PortTariffMaster.ID,CurrencyID,CommodityID,PrincibleID";
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> EnquiryRevenuCostCharges(MyEnquiry Data)
        {
            DataTable dt = GetEnquiryLandRevenuCostcharges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    //ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["EquipmentTypeID"].ToString(),
                    CntrType = dt.Rows[i]["Size"].ToString(),
                    Nos = dt.Rows[i]["Countv"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                    UOM = dt.Rows[i]["UOM"].ToString(),
                    BasicID = dt.Rows[i]["BasicID"].ToString(),
                    TotalAmount = dt.Rows[i]["TotalAmount"].ToString(),
                    Currency = dt.Rows[i]["Curr"].ToString(),
                    PaymentTerms = dt.Rows[i]["PaymentTerms"].ToString(),
                    CostAmount = dt.Rows[i]["CostAmount"].ToString(),
                    TotalCostAmount = dt.Rows[i]["TotalCostAmount"].ToString(),
                    PaymentTermID = dt.Rows[i]["PaymentTermID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    ExRate = "0"

                });
            }
            return ListView;
        }

        public DataTable GetEnquiryLandRevenuCostcharges(MyEnquiry Data)
        {
            string _Query = " select distinct EquipmentTypeID, (select top(1) Type from NVO_tblCntrTypes where Id = NVO_PortTariffMaster.EquipmentTypeID) as Size, " +
                            " (select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_PortTariffdtls.CommodityID) as Commodity, CommodityID, " +
                            " (select top(1) ChgCode from NVO_ChargeTB where Id = ChargeCodeID) as ChargeCode,ChargeCodeID,Amount, " +
                            " case when BasicID = 1 then 'BL' else 'CNTR' end as UOM,BasicID, " +
                            " (select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) as Countv, " +
                            " ((select Count(EquipmentTypeID) from NVO_PortTariffMaster PTM where PTM.ID = NVO_PortTariffMaster.ID) *Amount) as TotalAmount, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where NVO_CurrencyMaster.ID = NVO_PortTariffdtls.CurrencyID) as Curr,CurrencyID, " +
                            " case when ShipmentTypeID = 1 then 'Prepaid' else 'Collect' end as PaymentTerms, ShipmentTypeID as PaymentTermID," +
                            " isnull((select top(1) Amount from NVO_PortTariffMaster TerCost " +
                            " inner join NVO_PortTariffdtls TerCostdtls on TerCostdtls.PTID = TerCost.Id " +
                            " where TerCost.PrincibleID = NVO_PortTariffMaster.PrincibleID  and TerCostdtls.PortTariffTypeID = 3 and TerCostdtls.ChargeCodeID = NVO_PortTariffdtls.ChargeCodeID " +
                            " and EffectiveDate <= getdate()),0) as CostAmount, " +
                            " isnull((select top(1) Amount from NVO_PortTariffMaster TerCost " +
                            " inner join NVO_PortTariffdtls TerCostdtls on TerCostdtls.PTID = TerCost.Id " +
                            " where TerCost.PrincibleID = NVO_PortTariffMaster.PrincibleID  and TerCostdtls.PortTariffTypeID = 3 and TerCostdtls.ChargeCodeID = NVO_PortTariffdtls.ChargeCodeID " +
                            " and EffectiveDate <= getdate()),0) as TotalCostAmount " +
                            " from NVO_PortTariffMaster " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.Id " +
                            " where PrincibleID = 13  and PortTariffTypeID = 1  and EffectiveDate <= getdate()";
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> InsertenquiryMaster(MyEnquiry Data)
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
                    StringWriter stringwriter = new System.IO.StringWriter();
                    var serializer = new XmlSerializer(Data.GetType());
                    serializer.Serialize(stringwriter, Data);
                    Data.TextValues = stringwriter.ToString();

                    var SeqID = 0;
                    if (Data.ID == 0)
                    {
                        SeqID = 1;
                        string AutoGen = GetMaxseqNumber("EnqNo", Data.OfficeCode, Data.SessionFinYear);
                        Cmd.CommandText = "select 'INQ' + (select LocationCode from NVO_OfficeMaster where ID = " + Data.OfficeCode + ")  +right('00000' + convert(varchar(5), " + AutoGen + "), 5) + '/'+ (select top(1) FinYears from NVO_FinancialYear where YearID = " + Data.SessionFinYear + ")";
                        Data.EnquiryNo = Cmd.ExecuteScalar().ToString();
                    }
                    else
                        SeqID = 2;

                    Cmd.CommandText = " IF((select count(*) from NVO_Enquiry where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Enquiry(CustomerID,BkgPartyChk,ShipperChk,EnquiryNo,EnquiryDate,EnquirySourceID,BookingCommissionID,EnquiryStatusID,ValidTillDate,SalesPersonID,Nos,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,CargoWeight,HSCode,ShipperID,VesselID,VoyagID,TranshipmentPortID,POLTerminalID,PrincipalID,intHazardous,intReefer,intOOG,PaymentTermsID,FreeDaysOrigin,FreeDaysOrgValue,FreeDaysDest,FreeDaysDestValue,SecurityDeposit,SecurityDepositDesc,BOLReq,BOLReqDesc,DamageScheme,DamageSchemeValue,LineContractID,CustomerContractID,OfficeCode,Commodity) " +
                                     " values (@CustomerID,@BkgPartyChk,@ShipperChk,@EnquiryNo,@EnquiryDate,@EnquirySourceID,@BookingCommissionID,@EnquiryStatusID,@ValidTillDate,@SalesPersonID,@Nos,@OriginID,@LoadPortID,@DischargePortID,@DestinationID,@RouteID,@DeliveryTermsID,@CargoWeight,@HSCode,@ShipperID,@VesselID,@VoyagID,@TranshipmentPortID,@POLTerminalID,@PrincipalID,@intHazardous,@intReefer,@intOOG,@PaymentTermsID,@FreeDaysOrigin,@FreeDaysOrgValue,@FreeDaysDest,@FreeDaysDestValue,@SecurityDeposit,@SecurityDepositDesc,@BOLReq,@BOLReqDesc,@DamageScheme,@DamageSchemeValue,@LineContractID,@CustomerContractID,@OfficeCode,@Commodity) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Enquiry SET CustomerID=@CustomerID,BkgPartyChk=@BkgPartyChk,ShipperChk=@ShipperChk,EnquiryNo=@EnquiryNo,EnquiryDate=@EnquiryDate,EnquirySourceID=@EnquirySourceID,BookingCommissionID=@BookingCommissionID,EnquiryStatusID=@EnquiryStatusID,ValidTillDate=@ValidTillDate," +
                                     " SalesPersonID=@SalesPersonID,Nos=@Nos,OriginID=@OriginID,LoadPortID=@LoadPortID,DischargePortID=@DischargePortID,DestinationID=@DestinationID,RouteID=@RouteID,DeliveryTermsID=@DeliveryTermsID,CargoWeight=@CargoWeight,HSCode=@HSCode,ShipperID=@ShipperID,VesselID=@VesselID,VoyagID=@VoyagID," +
                                     " TranshipmentPortID=@TranshipmentPortID,POLTerminalID=@POLTerminalID,PrincipalID=@PrincipalID,intHazardous=@intHazardous,intReefer=@intReefer,intOOG=@intOOG,PaymentTermsID=@PaymentTermsID,FreeDaysOrigin=@FreeDaysOrigin,FreeDaysOrgValue=@FreeDaysOrgValue,FreeDaysDest=@FreeDaysDest," +
                                     " FreeDaysDestValue=@FreeDaysDestValue,SecurityDeposit=@SecurityDeposit,SecurityDepositDesc=@SecurityDepositDesc,BOLReq=@BOLReq,BOLReqDesc=@BOLReqDesc,DamageScheme=@DamageScheme,DamageSchemeValue=@DamageSchemeValue,LineContractID=@LineContractID,CustomerContractID=@CustomerContractID,OfficeCode=@OfficeCode where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgPartyChk", Data.BkgPartyChk));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperChk", Data.ShipperChk));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquiryNo", Data.EnquiryNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquiryDate", Data.EnquiryDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquirySourceID", Data.EnquirySourceID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingCommissionID", Data.BookingCommissionID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquiryStatusID", Data.EnquiryStatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTillDate", Data.ValidTillDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", Data.Nos));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OriginID", Data.OriginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPortID", Data.LoadPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DischargePortID", Data.DischargePortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestinationID", Data.DestinationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RouteID", Data.RouteID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DeliveryTermsID", Data.DeliveryTermsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoID", Data.CargoID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoWeight", Data.CargoWeight));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HSCode", Data.HSCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", Data.ShipperID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyagID", Data.VoyagID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLTerminalID", Data.POLTerminalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TranshipmentPortID", Data.TranshipmentPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincibalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@intHazardous", Data.HazarOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@intReefer", Data.ReeferOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@intOOG", Data.OOGOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTermsID", Data.PayTermsID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysOrigin", Data.FreeDayOrigin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysOrgValue", Data.NumberOfDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysDest", Data.FreeDayDestination));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDaysDestValue", Data.NumberOfDaysDestin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SecurityDeposit", Data.SecurityDeposit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SecurityDepositDesc", Data.txtSecurityDeposit));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BOLReq", Data.BOLRequirement));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BOLReqDesc", Data.txtBOLRequirement));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageScheme", Data.DamageScheme));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageSchemeValue", Data.txtDamageScheme));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LineContractID", Data.LineContractID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerContractID", Data.CustomerContractID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeCode", Data.OfficeCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", Data.Commodity));




                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Enquiry')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    if (Data.ItemsCntr != null)
                    {
                        string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryCntrType where EnqID=@EnqID and CntrTypeID=@CntrTypeID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_EnquiryCntrType(EnqID,CntrTypeID,Nos) " +
                                         " values (@EnqID,@CntrTypeID,@Nos) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_EnquiryCntrType SET EnqID=@EnqID,CntrTypeID=@CntrTypeID,Nos=@Nos where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", CharSplit[1]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.ItemsHarz != null)
                    {
                        string[] Array1 = Data.ItemsHarz.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryHazardous where EnqID=@EnqID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryHazardous(EnqID,CommodityID,HazardousClass,MCONumber) " +
                                        " values (@EnqID,@CommodityID,@HazardousClass,@MCONumber) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryHazardous SET EnqID=@EnqID,CommodityID=@CommodityID,HazardousClass=@HazardousClass,MCONumber=@MCONumber " +
                                        " where EnqID=@EnqID and HazardousClass=@HazardousClass";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@HazardousClass", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@MCONumber", CharSplit[2]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }



                    if (Data.ItemsOutGaugeCargo != null)
                    {
                        string[] Array1 = Data.ItemsOutGaugeCargo.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryOutGaugesCargo where EnqID=@EnqID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryOutGaugesCargo(EnqID,CommodityID,CargoLength,CargoWidth,CargoHeight) " +
                                        " values (@EnqID,@CommodityID,@CargoLength,@CargoWidth,@CargoHeight) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryOutGaugesCargo SET EnqID=@EnqID,CommodityID=@CommodityID,CargoLength=@CargoLength,CargoWidth=@CargoWidth,CargoHeight=@CargoHeight " +
                                        " where EnqID=@EnqID and CommodityID=@CommodityID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoLength", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoWidth", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoHeight", CharSplit[3]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }


                    if (Data.ItemsReeferGrid != null)
                    {
                        string[] Array1 = Data.ItemsReeferGrid.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryReffer where EnqID=@EnqID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryReffer(EnqID,CommodityID,Temperature,Ventilation,Humidity) " +
                                        " values (@EnqID,@CommodityID,@Temperature,@Ventilation,@Humidity) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryReffer SET EnqID=@EnqID,CommodityID=@CommodityID,Temperature=@Temperature,Ventilation=@Ventilation,Humidity=@Humidity " +
                                        " where EnqID=@EnqID and CommodityID=@CommodityID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Temperature", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Ventilation", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Humidity", CharSplit[3]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    if (Data.ItemShimpmentPOL != null)
                    {
                        string[] Array1 = Data.ItemShimpmentPOL.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryShimpmentPOL where EnqID=@EnqID and CntrTypeID=@CntrTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryShimpmentPOL(EnqID,CntrTypeID,ChargeOPT,Amount2,Remarks,CurrencyID) " +
                                        " values (@EnqID,@CntrTypeID,@ChargeOPT,@Amount2,@Remarks,@CurrencyID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryShimpmentPOL SET EnqID=@EnqID,CntrTypeID=@CntrTypeID,ChargeOPT=@ChargeOPT,Amount2=@Amount2,Remarks=@Remarks,CurrencyID=@CurrencyID " +
                                        " where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOPT", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount2", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    if (Data.ItemShimpmentPOD != null)
                    {
                        string[] Array1 = Data.ItemShimpmentPOD.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryShimpmentPOD where EnqID=@EnqID and CntrTypeID=@CntrTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryShimpmentPOD(EnqID,CntrTypeID,ChargeOPT,Amount2,Remarks,CurrencyID) " +
                                        " values (@EnqID,@CntrTypeID,@ChargeOPT,@Amount2,@Remarks,@CurrencyID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryShimpmentPOD SET EnqID=@EnqID,CntrTypeID=@CntrTypeID,ChargeOPT=@ChargeOPT,Amount2=@Amount2,Remarks=@Remarks,CurrencyID=@CurrencyID " +
                                        " where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOPT", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount2", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    if (Data.ItemFreightRate != null)
                    {
                        string[] Array1 = Data.ItemFreightRate.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryFreightRate where EnqID=@EnqID and CntrTypeID=@CntrTypeID and CargoID=@CargoID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryFreightRate(EnqID,CntrTypeID,Nos,CargoID,FrtChargePerAmt,ManifestAmt,CommissionPerAmt,CurrencyID) " +
                                        " values (@EnqID,@CntrTypeID,@Nos,@CargoID,@FrtChargePerAmt,@ManifestAmt,@CommissionPerAmt,@CurrencyID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryFreightRate SET EnqID=@EnqID,CntrTypeID=@CntrTypeID,Nos=@Nos,CargoID=@CargoID,FrtChargePerAmt=@FrtChargePerAmt,ManifestAmt=@ManifestAmt," +
                                        " CommissionPerAmt=@CommissionPerAmt,CurrencyID=@CurrencyID " +
                                        " where EnqID=@EnqID and CntrTypeID=@CntrTypeID and CargoID=@CargoID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FrtChargePerAmt", CharSplit[3]));
                            // Cmd.Parameters.Add(_dbFactory.GetParameter("@FrtChargePerAmtTotal", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifestAmt", CharSplit[4]));
                            // Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifestTotalAmt", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommissionPerAmt", CharSplit[5]));
                            // Cmd.Parameters.Add(_dbFactory.GetParameter("@CommissionTotal", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[6]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }


                    if (Data.ItemSlotRate != null)
                    {
                        string[] Array1 = Data.ItemSlotRate.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquirySlotRate where EnqID=@EnqID and CntrTypeID=@CntrTypeID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquirySlotRate(EnqID,CntrTypeID,Nos,CommodityID,CurrencyID,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount) " +
                                        " values (@EnqID,@CntrTypeID,@Nos,@CommodityID,@CurrencyID,@PerAmount,@TotalAmount,@ManifestPerAmount,@ManifestTotalAmount) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquirySlotRate SET EnqID=@EnqID,CntrTypeID=@CntrTypeID,Nos=@Nos,CommodityID=@CommodityID,CurrencyID=@CurrencyID,PerAmount=@PerAmount," +
                                            " TotalAmount=@TotalAmount,ManifestPerAmount=@ManifestPerAmount,ManifestTotalAmount=@ManifestTotalAmount where EnqID=@EnqID and CntrTypeID=@CntrTypeID and CommodityID=@CommodityID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Nos", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PerAmount", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TotalAmount", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifestPerAmount", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifestTotalAmount", CharSplit[7]));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }


                    if (Data.ItemAttach != null)
                    {
                        string[] Array1 = Data.ItemAttach.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryAttached where EnqID=@EnqID and AttachName=@AttachName)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_EnquiryAttached(EnqID,AttachName,AttachFile) " +
                                        " values (@EnqID,@AttachName,@AttachFile) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_EnquiryAttached SET EnqID=@EnqID,AttachName=@AttachName,AttachFile=@AttachFile where EnqID=@EnqID and AttachName=@AttachName";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachName", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", CharSplit[2]));


                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }


                    if (Data.ItemFreightBrackup != null)
                    {
                        string[] Array = Data.ItemFreightBrackup.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryFreightBrakup where EnqID=@EnqID and ChargeCodeID=@ChargeCodeID and Type=@Type)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_EnquiryFreightBrakup(EnqID,ChargeCodeID,CurrencyID,Amount,Type) " +
                                         " values (@EnqID,@ChargeCodeID,@CurrencyID,@Amount,@Type) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_EnquiryFreightBrakup SET EnqID=@EnqID,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,Amount=@Amount,Type=@Type " +
                                         " where EnqID=@EnqID and ChargeCodeID=@ChargeCodeID and Type=@Type";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[2]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    Cmd.CommandText = "INSERT INTO  NVO_LogDetails(PageName,CreatedOn,CreatedBy,SeqNo,LogInID,TextValues) " +
                             " values (@PageName,@CreatedOn,@CreatedBy,@SeqNo,@LogInID,@TextValues)";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PageName", Data.PageName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", (DateTime.Parse(System.DateTime.Now.Date.ToString()))));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SeqNo", SeqID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LogInID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TextValues", Data.TextValues));
                    result = Cmd.ExecuteNonQuery();

                    trans.Commit();
                    ListView.Add(new MyEnquiry
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved sucessfully " + Data.EnquiryNo,
                        EnquiryNo = Data.EnquiryNo

                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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

        public List<MyEnquiry> InsertEnquiryBrackupMaster(MyEnquiry Data)
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


                    if (Data.ItemFreightBrackup != null)
                    {
                        string[] Array = Data.ItemFreightBrackup.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_EnquiryFreightBrakup where EnqID=@EnqID and ChargeCodeID=@ChargeCodeID and Type=@Type)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_EnquiryFreightBrakup(EnqID,ChargeCodeID,CurrencyID,Amount,Type) " +
                                         " values (@EnqID,@ChargeCodeID,@CurrencyID,@Amount,@Type) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_EnquiryFreightBrakup SET EnqID=@EnqID,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,Amount=@Amount,Type=@Type " +
                                         " where EnqID=@EnqID and ChargeCodeID=@ChargeCodeID and Type=@Type";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", Data.Type));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[2]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();
                    ListView.Add(new MyEnquiry
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved sucessfully"


                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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


        public List<MyEnquiry> ExistingEnquiryvalues(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiry(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompnayName = dt.Rows[i]["CustomerName"].ToString(),
                    CompanyNameV = dt.Rows[i]["CustomerNameN"].ToString(),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                    EnquiryDate = dt.Rows[i]["EnquiryDatev"].ToString(),
                    EnquiryStatusID = dt.Rows[i]["Status"].ToString(),
                    ValidStatus = dt.Rows[i]["ValidStatus"].ToString(),
                    ValidStatusID = Int32.Parse(dt.Rows[i]["ValidStatusID"].ToString()),
                    OpenCount = Int32.Parse(dt.Rows[i]["OpenCount"].ToString())
                });
            }
            return ListView;
        }
        public DataTable GetExistingEnquiry(MyEnquiry Data)
        {
            string strWhere = "";

            string _Query = "select Left(CustomerName,17)as CustomerNameN,EnquiryStatusID,ValidStatusID, * from EnquieryViewV";

            if (Data.CustomerID != "0" && Data.CustomerID != null)
                if (strWhere == "")
                    strWhere += _Query + " where CustomerID=" + Data.CustomerID;
                else
                    strWhere += " and CustomerID=" + Data.CustomerID;

            if (Data.DestinationID != "0" && Data.DestinationID != null)
                if (strWhere == "")
                    strWhere += _Query + " where LoadPortID=" + Data.DestinationID;
                else
                    strWhere += " and LoadPortID=" + Data.DestinationID;


            if (Data.DischargeID != "0" && Data.DischargeID != null)
                if (strWhere == "")
                    strWhere += _Query + " where DestinationID=" + Data.DischargeID;
                else
                    strWhere += " and DestinationID=" + Data.DischargeID;


            if (Data.Status != "0" && Data.Status != null)
                if (strWhere == "")
                    strWhere += _Query + " where EnquiryStatusID=" + Data.Status;
                else
                    strWhere += " and EnquiryStatusID=" + Data.Status;

            if (Data.OfficeCode != "0" && Data.OfficeCode != null)
                if (strWhere == "")
                    strWhere += _Query + " where OfficeCode=" + Data.OfficeCode;
                else
                    strWhere += " and OfficeCode=" + Data.OfficeCode;

            if (Data.SalesPersonID != "0" && Data.SalesPersonID != null)
                if (strWhere == "")
                    strWhere += _Query + " where SalesPersonID=" + Data.SalesPersonID;
                else
                    strWhere += " and SalesPersonID=" + Data.SalesPersonID;

            if (Data.ValidStatusID.ToString() != "" && Data.ValidStatusID.ToString() != null && Data.ValidStatusID.ToString() != "0" && Data.ValidStatusID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where ValidStatusID =" + Data.ValidStatusID.ToString() + "";
                else
                    strWhere += " and ValidStatusID =" + Data.ValidStatusID.ToString() + "";

            if (Data.EnquiryNo != "" && Data.EnquiryNo != null)
                if (strWhere == "")
                    strWhere += _Query + " where EnquiryNo like '%" + Data.EnquiryNo + "%'";
                else
                    strWhere += " and EnquiryNo like '%" + Data.EnquiryNo + "%'";

            if (Data.EnquiryDate != "" && Data.EnquiryDate != null)
                if (strWhere == "")
                    strWhere += _Query + " where EnquiryDate >= '" + DateTime.Parse(Data.EnquiryDate.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and EnquiryDate >= '" + DateTime.Parse(Data.EnquiryDate.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.EnquiryDateto != "" && Data.EnquiryDateto != null)
                if (strWhere == "")
                    strWhere += _Query + " where EnquiryDate <= '" + DateTime.Parse(Data.EnquiryDateto.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and EnquiryDate <= '" + DateTime.Parse(Data.EnquiryDateto.ToString()).ToString("MM/dd/yyyy") + "'";


            //if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

            //    if (strWhere == "")
            //        strWhere += _Query + " where Status =" + Data.Status.ToString();
            //    else
            //        strWhere += " and Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;



            return GetViewData(strWhere + " ORDER BY ID desc ", "");
        }


        public DataTable GetOfficeLocation(string ID)
        {
            string _Query = " select * from NVO_OfficeMaster where ID=" + ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryFreightBrackupvalues(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryFreightBrackup(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    // ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                });
            }
            return ListView;
        }

        public DataTable GetExistingEnquiryFreightBrackup(MyEnquiry Data)
        {
            string _Query = " select ID as ChargeCodeID,ChgDesc,isnull((select top(1) Amount from NVO_EnquiryFreightBrakup where ChargeCodeID = NVO_ChargeTB.Id and EnqID = " + Data.ID + " and Type = " + Data.Type + "),0) as Amount, " +
                            " 146 as CurrencyID from NVO_ChargeTB where ChargeGroupID = 21";
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryBkgFreightBrackupvalues(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryBkgFreightBrackup(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    // ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString(),
                });
            }
            return ListView;
        }

        public DataTable GetExistingEnquiryBkgFreightBrackup(MyEnquiry Data)
        {
            string _Query = " select ID as ChargeCodeID,ChgDesc,isnull((select top(1) Amount from NVO_EnquiryFreightBrakup where ChargeCodeID = NVO_ChargeTB.Id and EnqID = " + Data.EnqID + " and Type = " + Data.Type + "),0) as Amount, " +
                            " 146 as CurrencyID from NVO_ChargeTB where ChargeGroupID = 21";
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerID = dt.Rows[i]["CustomerID"].ToString(),
                    ShipperID = dt.Rows[i]["ShipperID"].ToString(),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                    EnquiryDate = dt.Rows[i]["EnquiryDatev"].ToString(),
                    EnquirySourceID = dt.Rows[i]["EnquirySourceID"].ToString(),
                    BookingCommissionID = dt.Rows[i]["BookingCommissionID"].ToString(),
                    EnquiryStatusID = dt.Rows[i]["EnquiryStatusID"].ToString(),
                    ValidTillDate = dt.Rows[i]["ValidTillDatev"].ToString(),
                    SalesPersonID = dt.Rows[i]["SalesPersonID"].ToString(),
                    NominationID = dt.Rows[i]["SalesPersonID"].ToString(),

                    OriginID = dt.Rows[i]["OriginID"].ToString(),
                    LoadPortID = dt.Rows[i]["LoadPortID"].ToString(),
                    DischargePortID = dt.Rows[i]["DischargePortID"].ToString(),
                    DestinationID = dt.Rows[i]["DestinationID"].ToString(),

                    RouteID = dt.Rows[i]["RouteID"].ToString(),
                    DeliveryTermsID = dt.Rows[i]["DeliveryTermsID"].ToString(),
                    CargoID = dt.Rows[i]["CargoID"].ToString(),
                    CargoWeight = dt.Rows[i]["CargoWeight"].ToString(),
                    HSCode = dt.Rows[i]["HSCode"].ToString(),
                    VesselID = dt.Rows[i]["VesselID"].ToString(),
                    VoyagID = dt.Rows[i]["VoyagID"].ToString(),
                    POLTerminalID = dt.Rows[i]["POLTerminalID"].ToString(),
                    TranshipmentPortID = dt.Rows[i]["TranshipmentPortID"].ToString(),
                    PrincibalID = dt.Rows[i]["PrincipalID"].ToString(),
                    HazarOpt = Int32.Parse(dt.Rows[i]["intHazardous"].ToString()),
                    ReeferOpt = Int32.Parse(dt.Rows[i]["intReefer"].ToString()),
                    OOGOpt = Int32.Parse(dt.Rows[i]["intOOG"].ToString()),

                    FreeDayOrigin = Int32.Parse(dt.Rows[i]["FreeDaysOrigin"].ToString()),
                    FreeDayDestination = Int32.Parse(dt.Rows[i]["FreeDaysDest"].ToString()),
                    DamageScheme = Int32.Parse(dt.Rows[i]["DamageScheme"].ToString()),
                    SecurityDeposit = Int32.Parse(dt.Rows[i]["SecurityDeposit"].ToString()),
                    BOLRequirement = Int32.Parse(dt.Rows[i]["BOLReq"].ToString()),

                    PayTermsID = Int32.Parse(dt.Rows[i]["PaymentTermsID"].ToString()),
                    NumberOfDays = dt.Rows[i]["FreeDaysOrgValue"].ToString(),
                    NumberOfDaysDestin = dt.Rows[i]["FreeDaysDestValue"].ToString(),
                    txtDamageScheme = dt.Rows[i]["DamageSchemeValue"].ToString(),
                    txtSecurityDeposit = dt.Rows[i]["SecurityDepositDesc"].ToString(),
                    txtBOLRequirement = dt.Rows[i]["BOLReqDesc"].ToString(),
                    LineContractID = dt.Rows[i]["LineContractID"].ToString(),
                    CustomerContractID = dt.Rows[i]["CustomerContractID"].ToString(),
                    OfficeCode = dt.Rows[i]["OfficeCode"].ToString(),
                    ValidStatusID = Int32.Parse(dt.Rows[i]["ValidStatusID"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    Reason = dt.Rows[i]["Reason"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),


                });

            }
            return ListView;
        }
        public DataTable GetExistingEnquiryRecord(MyEnquiry Data)
        {
            string _Query = " select convert(varchar,EnquiryDate,23) as EnquiryDatev,convert(varchar,ValidTillDate,23) as ValidTillDatev,Case when ValidTillDate>Convert(varchar,DateAdd(day, -1,GetDate()),101) then 1 ELSE 2 End as ValidStatusID, " +
              " case when CancelReasonID != '' then(select top(1) GeneralName from NVO_GeneralMaster where Id = CancelReasonID) else " +
              " (select top(1) GeneralName from NVO_GeneralMaster where Id = RejectReasonID) end as Reason, " +
              " case when CancelReasonID != '' then CancelReason else RejectReason end as Remarks,Commodity, " +
              " * from NVO_Enquiry where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> BindCommodityHSCode(MyEnquiry Data)
        {
            DataTable dt = GetCommodityHSCode(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    HSCode = dt.Rows[i]["HSCode"].ToString(),

                });

            }
            return ListView;
        }

        public DataTable GetCommodityHSCode(MyEnquiry Data)
        {
            string _Query = "select Id, CommodityName, HSCode,* from NVO_CommodityMaster where ID=" + Data.CommodityID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryCntrTypeBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingCntrTypeEnquiryRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CntrTypes = dt.Rows[i]["CntrType"].ToString(),


                });
            }
            return ListView;
        }
        public DataTable GetExistingCntrTypeEnquiryRecord(MyEnquiry Data)
        {
            string _Query = " select Id,(select top(1) Size from NVO_tblCntrTypes where ID =CntrTypeID) as CntrType,CntrTypeID,Nos from NVO_EnquiryCntrType where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryAttahced(MyEnquiry Data)
        {
            DataTable dt = GetExistingAttahcedEnquiryRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    AID = dt.Rows[i]["ID"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    AttachName = dt.Rows[i]["AttachName"].ToString(),


                });
            }
            return ListView;
        }

        public DataTable GetExistingAttahcedEnquiryRecord(MyEnquiry Data)
        {
            string _Query = " select ID,AttachFile,AttachName from NVO_EnquiryAttached where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingEnquiryHazardousBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingHazardousEnquiryRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    HazarClass = dt.Rows[i]["HazardousClass"].ToString(),
                    HazarMCONo = dt.Rows[i]["MCONumber"].ToString(),


                });
            }
            return ListView;
        }

        public DataTable GetExistingHazardousEnquiryRecord(MyEnquiry Data)
        {
            string _Query = "  select* from NVO_EnquiryHazardous where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryOutGaugesBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingOutGaugesEnquiryRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    Length = dt.Rows[i]["CargoLength"].ToString(),
                    Width = dt.Rows[i]["CargoWidth"].ToString(),
                    Height = dt.Rows[i]["CargoHeight"].ToString(),


                });
            }
            return ListView;
        }
        public DataTable GetExistingOutGaugesEnquiryRecord(MyEnquiry Data)
        {
            string _Query = "  select * from NVO_EnquiryOutGaugesCargo where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingEnquiryRefferBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingRefferEnquiryRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    Ventilation = dt.Rows[i]["Ventilation"].ToString(),
                    Humidity = dt.Rows[i]["Humidity"].ToString(),
                });
            }
            return ListView;
        }

        public DataTable GetExistingRefferEnquiryRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_EnquiryReffer where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingEnquiryShimpmentPOLBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryShimpmentPOLRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    ChargeOPT = Int32.Parse(dt.Rows[i]["ChargeOPT"].ToString()),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),

                    Amount2 = dt.Rows[i]["Amount2"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                });
            }
            return ListView;
        }


        public DataTable GetExistingEnquiryShimpmentPOLRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_EnquiryShimpmentPOL where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingEnquiryShimpmentPODBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryShimpmentPODRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    ChargeOPT = Int32.Parse(dt.Rows[i]["ChargeOPT"].ToString()),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    Amount2 = dt.Rows[i]["Amount2"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                });
            }
            return ListView;
        }


        public DataTable GetExistingEnquiryShimpmentPODRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_EnquiryShimpmentPOD where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingEnquiryFreightRateBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryFreightRateRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CommodityID = dt.Rows[i]["CargoID"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    PerAmount = dt.Rows[i]["FrtChargePerAmt"].ToString(),
                    TotalAmount = dt.Rows[i]["FrtChargePerAmtTotal"].ToString(),
                    ManifestPerAmount = dt.Rows[i]["ManifestAmt"].ToString(),
                    ManifestTotalAmount = dt.Rows[i]["ManifestTotalAmt"].ToString(),
                    CommPerAmount = dt.Rows[i]["CommissionPerAmt"].ToString(),
                    CommTotal = dt.Rows[i]["CommissionTotal"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),

                });
            }
            return ListView;
        }

        public DataTable GetExistingEnquiryFreightRateRecord(MyEnquiry Data)
        {
            string _Query = " select (select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_EnquiryFreightRate.CargoID) as Commodity, " +
                            " (select top(1) Type from NVO_tblCntrTypes where Id = NVO_EnquiryFreightRate.CntrTypeID) as CntrType,* from NVO_EnquiryFreightRate where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingEnquirySlotRateBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquirySlotRateRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    PerAmount = dt.Rows[i]["PerAmount"].ToString(),
                    TotalAmount = dt.Rows[i]["TotalAmount"].ToString(),
                    ManifestPerAmount = dt.Rows[i]["ManifestPerAmount"].ToString(),
                    ManifestTotalAmount = dt.Rows[i]["ManifestTotalAmount"].ToString()
                });
            }
            return ListView;
        }

        public DataTable GetExistingEnquirySlotRateRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_EnquirySlotRate where EnqID=" + Data.ID;
            return GetViewData(_Query, "");
        }




        public List<MyEnquiry> ExistingEnquiryRevenuRateBind(MyEnquiry Data)
        {
            DataTable dt = GetExistingEnquiryRevenueRateRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),
                    UOM = dt.Rows[i]["Uomv"].ToString(),
                    PaymentTerms = dt.Rows[i]["PaymentTerms"].ToString(),
                    CostAmount = dt.Rows[i]["CostRate"].ToString(),
                    TotalAmount = dt.Rows[i]["Total"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    Amount = dt.Rows[i]["Rate"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    PaymentTermID = dt.Rows[i]["PaymentTypeID"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),
                    TotalCostAmount = dt.Rows[i]["CostRateTotal"].ToString(),
                    BasicID = dt.Rows[i]["BasicID"].ToString(),

                });
            }
            return ListView;
        }


        public DataTable GetExistingEnquiryRevenueRateRecord(MyEnquiry Data)
        {
            string _Query = " select(select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_EnquiryRevenueRate.CargoID) as Commodity, CargoID as CommodityID, " +
                            " (select top(1) Type from NVO_tblCntrTypes where Id = NVO_EnquiryRevenueRate.CntrTypeID) as CntrType,Case when BasicID = 1 " +
                            " then 'CNTR' else 'BL' end as Uomv,(select top(1) ChgCode from NVO_ChargeTB where ID = ChargeCodeID) as ChargeCode, " +
                            " case when PaymentTypeID = 1 then 'Prepaid' else 'Collect' end as PaymentTerms, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where NVO_CurrencyMaster.ID = NVO_EnquiryRevenueRate.CurrencyID) as Currency," +
                            " * from NVO_EnquiryRevenueRate " +
                            " where EnqID =" + Data.ID;
            return GetViewData(_Query, "");
        }



        public List<MyEnquiry> BindLinerMaster(MyEnquiry Data)
        {
            DataTable dt = GetLinerMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RequestNo = dt.Rows[i]["RequestNo"].ToString(),

                });

            }
            return ListView;
        }

        public DataTable GetLinerMaster()
        {
            string _Query = "select ID,RequestNo from NVO_PrincipalRateRequest";
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> BindCustomerContractMaster(MyEnquiry Data)
        {
            DataTable dt = GetCustomerContractMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListView.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContractNo = dt.Rows[i]["ContractNo"].ToString(),

                });

            }
            return ListView;
        }

        public DataTable GetCustomerContractMaster()
        {
            string _Query = "select Id,ContractNo from NVO_CustomerContract";
            return GetViewData(_Query, "");
        }




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

        //aravind

        public List<MyEnquiry> InsertDirectEnqBooking(MyEnquiry Data)
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

                    //string AutoGen = GetMaxseqNumber("BkgNo", "1", Data.SessionFinYear);
                    //Cmd.CommandText = "select 'BKG' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                    //Data.BookingNo = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = " insert into NVO_Booking (EnquiryID,CustomerID,BkgPartyChk,ShipperChk,BookingNo,EnquiryDate,EnquirySourceID,BookingCommissionID,EnquiryStatusID,ValidTillDate,SalesPersonID,Nos,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,CargoWeight,HSCode,ShipperID,VesselID,VoyageID,POLTerminalID,TranshipmentPortID,intStatus,PrincipalID,intHazardous,intReefer,intOOG,FreeDaysOrigin,FreeDaysDest,SecurityDeposit,DamageScheme,BOLReq,FreeDaysOrgValue,FreeDaysDestValue,SecurityDepositDesc,DamageSchemeValue,BOLReqDesc,PaymentTermsID, CustomerContractID, LineContractID,OfficeCode,CargoID) " +
                        "select ID,CustomerID,BkgPartyChk,ShipperChk,'" + Data.BookingNo + "',EnquiryDate,EnquirySourceID,BookingCommissionID,EnquiryStatusID,ValidTillDate,SalesPersonID,Nos,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,CargoWeight,HSCode,ShipperID,VesselID,VoyagID,POLTerminalID,TranshipmentPortID,intStatus,PrincipalID,intHazardous,intReefer,intOOG,FreeDaysOrigin,FreeDaysDest,SecurityDeposit,DamageScheme,BOLReq,FreeDaysOrgValue,FreeDaysDestValue,SecurityDepositDesc,DamageSchemeValue,BOLReqDesc,PaymentTermsID, CustomerContractID, LineContractID,OfficeCode,Commodity from NVO_Enquiry where id = @ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    var NewBkgID = 0;
                    Cmd.CommandText = "select ident_current('NVO_Booking')";
                    NewBkgID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "insert into NVO_BookingCntrType(BkgID,EnqID,CntrTypeID,Nos) " +
                                      " select " + NewBkgID + "," + NewBkgID + ",CntrTypeID,Nos from NVO_EnquiryCntrType " +
                                      " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingFreightRate(BkgID,EnqID,CntrTypeID,Nos,CargoID,FrtChargePerAmt,	FrtChargePerAmtTotal,ManifestAmt,CommissionPerAmt,CommissionTotal,CurrencyID,ManifestTotalAmt) " +
                                      " select " + NewBkgID + "," + Data.ID + ",CntrTypeID,Nos,CargoID,FrtChargePerAmt,	FrtChargePerAmtTotal,ManifestAmt,CommissionPerAmt,CommissionTotal,CurrencyID,ManifestTotalAmt from NVO_EnquiryFreightRate " +
                                      " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingFreightBrakup(BkgID,EnqID,ChargeCodeID,CurrencyID,Amount,Type) " +
                        " select " + NewBkgID + "," + Data.ID + ",ChargeCodeID,CurrencyID,Amount,Type from NVO_EnquiryFreightBrakup " +
                        " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    Cmd.CommandText = "insert into NVO_BookingHazardous(BkgID,EnqID,Hazardous,HazardousClass,MCONumber,CommodityID) " +
                        " select " + NewBkgID + "," + Data.ID + ",Hazardous,HazardousClass,MCONumber,CommodityID from NVO_EnquiryHazardous " +
                        " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingOutGaugesCargo(BkgID,EnqID,OutGaugeCargo,CargoLength,CargoWidth,CargoHeight,CommodityID) " +
                  " select " + NewBkgID + "," + Data.ID + ",OutGaugeCargo,CargoLength,CargoWidth,CargoHeight,CommodityID from NVO_EnquiryOutGaugesCargo " +
                  " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingReffer(BkgID,EnqID,Reefer,Temperature,Ventilation,Humidity,CommodityID) " +
               " select " + NewBkgID + "," + Data.ID + ",Reefer,Temperature,Ventilation,Humidity,CommodityID from NVO_EnquiryReffer " +
               " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingRevenueRate(BkgID,EnqID,CntrTypeID,Nos,CargoID,Rate,UOM,Total,CurrencyID,ExRate,PaymentTypeID,CostRate,CostRateTotal,ChargeCodeID,BasicID) " +
             " select " + NewBkgID + "," + Data.ID + ",CntrTypeID,Nos,CargoID,Rate,UOM,Total,CurrencyID,ExRate,PaymentTypeID,CostRate,CostRateTotal,ChargeCodeID,BasicID from NVO_EnquiryRevenueRate " +
             " where EnqID=" + Data.ID;

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingShimpmentPOD(BkgID,EnqID,CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID) " +
         " select " + NewBkgID + "," + Data.ID + ",CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID from NVO_EnquiryShimpmentPOD " +
         " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingShimpmentPOL(BkgID,EnqID,CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID) " +
      " select " + NewBkgID + "," + Data.ID + ",CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID from NVO_EnquiryShimpmentPOL " +
      " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_BookingSlotRate(BkgID,EnqID,CntrTypeID,Nos,CommodityID,CurrencyID,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount) " + " select " + NewBkgID + "," + Data.ID + ",CntrTypeID,Nos,CommodityID,CurrencyID,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount from NVO_EnquirySlotRate  where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    trans.Commit();
                    ListView.Add(new MyEnquiry
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Booking Created Sucessfully",
                        BkgId = NewBkgID.ToString()

                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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


        public List<MyEnquiry> InsertCopyEnquiry(MyEnquiry Data)
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

                    string AutoGen = GetMaxseqNumber("EnqNo", "1", Data.SessionFinYear);
                    Cmd.CommandText = "select 'ENQ' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('00000' + convert(varchar(4)," + AutoGen + "), 4)";
                    Data.EnquiryNo = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = " insert into NVO_Enquiry (CustomerID,BkgPartyChk,ShipperChk,EnquiryNo,EnquiryDate,EnquirySourceID,BookingCommissionID,EnquiryStatusID,ValidTillDate,SalesPersonID,Nos,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,CargoID,CargoWeight,HSCode,ShipperID,VesselID,VoyagID,TranshipmentPortID,POLTerminalID,PrincipalID,intHazardous,intReefer,intOOG,PaymentTermsID,FreeDaysOrigin,FreeDaysOrgValue,FreeDaysDest,FreeDaysDestValue,SecurityDeposit,SecurityDepositDesc,BOLReq,BOLReqDesc,DamageScheme,DamageSchemeValue,LineContractID,CustomerContractID) " +
                        "select  CustomerID,BkgPartyChk,ShipperChk,'" + Data.EnquiryNo + "',EnquiryDate,EnquirySourceID,BookingCommissionID,EnquiryStatusID,ValidTillDate,SalesPersonID,Nos,OriginID,LoadPortID,DischargePortID,DestinationID,RouteID,DeliveryTermsID,CargoID,CargoWeight,HSCode,ShipperID,VesselID,VoyagID,TranshipmentPortID,POLTerminalID,PrincipalID,intHazardous,intReefer,intOOG,PaymentTermsID,FreeDaysOrigin,FreeDaysOrgValue,FreeDaysDest,FreeDaysDestValue,SecurityDeposit,SecurityDepositDesc,BOLReq,BOLReqDesc,DamageScheme,DamageSchemeValue,LineContractID,CustomerContractID from NVO_Enquiry where id = @ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    var NewBkgID = 0;
                    Cmd.CommandText = "select ident_current('NVO_Enquiry')";
                    NewBkgID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "insert into NVO_EnquiryCntrType(EnqID,CntrTypeID,Nos) " +
                                      " select " + NewBkgID + ",CntrTypeID,Nos from NVO_EnquiryCntrType " +
                                      " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryFreightRate(EnqID,CntrTypeID,Nos,CargoID,FrtChargePerAmt,	FrtChargePerAmtTotal,ManifestAmt,CommissionPerAmt,CommissionTotal,CurrencyID,ManifestTotalAmt) " +
                                      " select " + NewBkgID + ",CntrTypeID,Nos,CargoID,FrtChargePerAmt,	FrtChargePerAmtTotal,ManifestAmt,CommissionPerAmt,CommissionTotal,CurrencyID,ManifestTotalAmt from NVO_EnquiryFreightRate " +
                                      " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryFreightBrakup(EnqID,ChargeCodeID,CurrencyID,Amount,Type) " +
                        " select " + NewBkgID + ",ChargeCodeID,CurrencyID,Amount,Type from NVO_EnquiryFreightBrakup " +
                        " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    Cmd.CommandText = "insert into NVO_EnquiryHazardous(EnqID,Hazardous,HazardousClass,MCONumber,CommodityID) " +
                        " select " + NewBkgID + ",Hazardous,HazardousClass,MCONumber,CommodityID from NVO_EnquiryHazardous " +
                        " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryOutGaugesCargo(EnqID,OutGaugeCargo,CargoLength,CargoWidth,CargoHeight,CommodityID) " +
                  " select " + NewBkgID + ",OutGaugeCargo,CargoLength,CargoWidth,CargoHeight,CommodityID from NVO_EnquiryOutGaugesCargo " +
                  " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryReffer(EnqID,Reefer,Temperature,Ventilation,Humidity,CommodityID) " +
               " select " + NewBkgID + ",Reefer,Temperature,Ventilation,Humidity,CommodityID from NVO_EnquiryReffer " +
               " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryRevenueRate(EnqID,CntrTypeID,Nos,CargoID,Rate,UOM,Total,CurrencyID,ExRate,PaymentTypeID,CostRate,CostRateTotal,ChargeCodeID,BasicID) " +
             " select " + NewBkgID + ",CntrTypeID,Nos,CargoID,Rate,UOM,Total,CurrencyID,ExRate,PaymentTypeID,CostRate,CostRateTotal,ChargeCodeID,BasicID from NVO_EnquiryRevenueRate " +
             " where EnqID=" + Data.ID;

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryShimpmentPOD(EnqID,CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID) " +
         " select " + NewBkgID + ",CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID from NVO_EnquiryShimpmentPOD " +
         " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquiryShimpmentPOL(EnqID,CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID) " +
      " select " + NewBkgID + ",CntrTypeID,ChargeOPT,Amount1,Amount2,Amount3,CurrencyID from NVO_EnquiryShimpmentPOL " +
      " where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = "insert into NVO_EnquirySlotRate(EnqID,CntrTypeID,Nos,CommodityID,CurrencyID,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount) " +
                        " select " + NewBkgID + ",CntrTypeID,Nos,CommodityID,CurrencyID,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount from NVO_EnquirySlotRate  where EnqID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    trans.Commit();
                    ListView.Add(new MyEnquiry
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Enquery Copy Created Sucessfully"
                    }); ;
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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



        public List<MyEnquiry> InsertStatusUpdate(MyEnquiry Data)
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

                    Cmd.CommandText =
                                 " UPDATE NVO_Enquiry SET EnquiryStatusID=@EnquiryStatusID,CancelReasonID=@CancelReasonID,CancelReason=@CancelReason,RejectReasonID=@RejectReasonID,RejectReason=@RejectReason where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquiryStatusID", Data.EnquiryStatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelReasonID", Data.CancelReasonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CancelReason", Data.CancelReason));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectReasonID", Data.RejectReasonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectReason", Data.RejectReason));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    ListView.Add(new MyEnquiry
                    {
                        AlertMessage = "Update Status",
                        AlertMegId = "1"


                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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


        public List<MyEnquiry> EnqDeleteCntrTypes(MyEnquiry Data)
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
                    DataTable _dtExt = GetEnquiryCntrTypes(Data.ID.ToString(), Data.EnqCntrID);
                    if (_dtExt.Rows.Count > 0)
                    {
                        Cmd.CommandText = " Delete NVO_EnquiryCntrType where EnqID=@EnqID and ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.EnqCntrID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        Cmd.CommandText = " Delete NVO_EnquiryFreightRate where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", _dtExt.Rows[0]["CntrTypeID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                        Cmd.CommandText = " Delete NVO_EnquirySlotRate where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", _dtExt.Rows[0]["CntrTypeID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        Cmd.CommandText = " Delete NVO_EnquiryShimpmentPOD where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", _dtExt.Rows[0]["CntrTypeID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                        Cmd.CommandText = " Delete NVO_EnquiryShimpmentPOL where EnqID=@EnqID and CntrTypeID=@CntrTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", _dtExt.Rows[0]["CntrTypeID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();


                    }

                    trans.Commit();
                    ListView.Add(new MyEnquiry
                    {
                        AlertMessage = "Container Types",
                        AlertMegId = "1"


                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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


        public DataTable GetEnquiryCntrTypes(string EnqID, string EnqCntrID)
        {
            string _Query = "select * from NVO_EnquiryCntrType where EnqID= " + EnqID + " and Id = " + EnqCntrID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> EnqAttahcedDeletd(MyEnquiry Data)
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
                    Cmd.CommandText = " Delete NVO_EnquiryAttached where EnqID=@EnqID and ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.AID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.ID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();


                    ListView.Add(new MyEnquiry
                    {
                        AlertMessage = "Container Types",
                        AlertMegId = "1"


                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListView;
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

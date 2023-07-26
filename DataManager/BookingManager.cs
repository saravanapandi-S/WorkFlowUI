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
    public class BookingManager
    {
        List<MyMergeBooking> ListMerge = new List<MyMergeBooking>();
        List<MySplitBooking> ListSplit = new List<MySplitBooking>();
        List<MyBookingSource> Booking = new List<MyBookingSource>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public BookingManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

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

        #region Booking

        public List<MyBookingSource> EnquiryNumber(MyBookingSource Data)
        {
            List<MyBookingSource> ListGeneral = new List<MyBookingSource>();
            DataTable dt = GetEnquiryNumberValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneral.Add(new MyBookingSource

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                });
            }
            return ListGeneral;
        }
        public DataTable GetEnquiryNumberValues(MyBookingSource Data)
        {
            string _Query = "select ID,EnquiryNo  from NVO_Enquiry";
            return GetViewData(_Query, "");
        }

        public List<MyBookingSource> ExistingBookingvalues(MyBookingSource Data)
        {
            DataTable dt = GetExistingBooking(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Booking.Add(new MyBookingSource
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                    BookingDate = dt.Rows[i]["BookingDate"].ToString(),
                    Satusv = dt.Rows[i]["Status"].ToString(),

                }); ;
            }
            return Booking;
        }
        public DataTable GetExistingBooking(MyBookingSource Data)
        {
            string strWhere = "";

            string _Query = "select NVO_Booking.Id,(select top(1)  CustomerName from NVO_view_CustomerDetails where CId = customerID) as CustomerName, " +
                "(select top(1) PortCode from NVO_PortMaster where Id = LoadPortID) as POD," +
                "(select top(1) PortCode from NVO_PortMaster where Id = DestinationID) as FPOD,(select top(1) EnquiryNo from NVO_Enquiry where Id = EnquiryID) as EnquiryNo,BookingNo, convert(varchar, EnquiryDate, 103) as BookingDate, " +
                " Case when intStatus = 2 then 'Confirmed' else case when intStatus=3 then 'Cancelled' else 'Open' end end as Status from NVO_Booking";
            strWhere += _Query + " where NVO_Booking.BookingNo != ''";


            if (Data.OfficeCode.ToString() != "0" && Data.OfficeCode.ToString() != null)
                if (strWhere == "")
                    strWhere += _Query + " where OfficeCode = " + Data.OfficeCode;
                else
                    strWhere += " and OfficeCode = " + Data.OfficeCode;

            if (Data.CustomerID.ToString() != "" && Data.CustomerID.ToString() != null && Data.CustomerID.ToString() != "0" && Data.CustomerID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.CustomerID =" + Data.CustomerID.ToString();
                else
                    strWhere += " and NVO_Booking.CustomerID  =" + Data.CustomerID.ToString();

            if (Data.POL.ToString() != "" && Data.POL.ToString() != null && Data.POL.ToString() != "0" && Data.POL.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.LoadPortID =" + Data.POL.ToString();
                else
                    strWhere += " and NVO_Booking.LoadPortID  =" + Data.POL.ToString();


            if (Data.FPOD.ToString() != "" && Data.FPOD.ToString() != null && Data.FPOD.ToString() != "0" && Data.FPOD.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.DestinationID =" + Data.FPOD.ToString();
                else
                    strWhere += " and NVO_Booking.DestinationID  =" + Data.FPOD.ToString();

            if (Data.VesselID.ToString() != "" && Data.VesselID.ToString() != null && Data.VesselID.ToString() != "0" && Data.VesselID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.VesselID =" + Data.VesselID.ToString();
                else
                    strWhere += " and NVO_Booking.VesselID  =" + Data.VesselID.ToString();

            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.VoyageID =" + Data.VoyageID.ToString();
                else
                    strWhere += " and NVO_Booking.VoyageID  =" + Data.VoyageID.ToString();


            if (Data.EnquiryNo.ToString() != "" && Data.EnquiryNo.ToString() != null && Data.EnquiryNo.ToString() != "0" && Data.EnquiryNo.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where (select top(1) EnquiryNo from NVO_Enquiry where Id = EnquiryID) like '%" + Data.EnquiryNo + "%'";
                else
                    strWhere += " and (select top(1) EnquiryNo from NVO_Enquiry where Id = EnquiryID) like '%" + Data.EnquiryNo + "%'";



            if (Data.BookingNo.ToString() != "" && Data.BookingNo.ToString() != null && Data.BookingNo.ToString() != "0" && Data.BookingNo.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.BookingNo like '%" + Data.BookingNo + "%'";
                else
                    strWhere += " and NVO_Booking.BookingNo like '%" + Data.BookingNo + "%'";

            if (Data.BookingDate != "" && Data.BookingDate != null)
                if (strWhere == "")
                    strWhere += _Query + " where BkgDate >= '" + DateTime.Parse(Data.BookingDate.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and BkgDate >= '" + DateTime.Parse(Data.BookingDate.ToString()).ToString("MM/dd/yyyy") + "'";

            if (Data.BookingDateto != "" && Data.BookingDateto != null)
                if (strWhere == "")
                    strWhere += _Query + " where BkgDate <= '" + DateTime.Parse(Data.BookingDateto.ToString()).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and BkgDate <= '" + DateTime.Parse(Data.BookingDateto.ToString()).ToString("MM/dd/yyyy") + "'";


            if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where isnull(NVO_Booking.intStatus,1) =" + Data.Status.ToString();
                else
                    strWhere += " and isnull(NVO_Booking.intStatus,1)  =" + Data.Status.ToString();


            if (Data.SalesPersonID.ToString() != "" && Data.SalesPersonID.ToString() != null && Data.SalesPersonID.ToString() != "0" && Data.SalesPersonID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_Booking.SalesPersonID =" + Data.SalesPersonID.ToString();
                else
                    strWhere += " and NVO_Booking.SalesPersonID  =" + Data.SalesPersonID.ToString();

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " ORDER BY NVO_Booking.ID desc ", "");
        }

        public List<MyBookingSource> BookingEditView(MyBookingSource Data)
        {
            DataTable dt = BookingEditViewRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Booking.Add(new MyBookingSource
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),

                });
            }
            return Booking;
        }
        public DataTable BookingEditViewRecord(MyBookingSource Data)
        {
            string _Query = "";
            return GetViewData(_Query, "");
        }


        public List<MYBookingNew> ExistingBookingEditView(MYBookingNew Data)
        {
            List<MYBookingNew> ListEnq = new List<MYBookingNew>();
            DataTable dt = GetExistingBookingViewRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int OwnershipIDv = 1;
                int FixedIDv = 1;
                if (dt.Rows[i]["OwnershipID"].ToString() != "")
                    OwnershipIDv = Int32.Parse(dt.Rows[i]["OwnershipID"].ToString());

                ListEnq.Add(new MYBookingNew
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EnqID = dt.Rows[i]["EnquiryID"].ToString(),
                    CustomerID = dt.Rows[i]["CustomerID"].ToString(),
                    ShipperID = dt.Rows[i]["ShipperID"].ToString(),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),
                    EnquiryDate = dt.Rows[i]["BkgDatev"].ToString(),
                    EnquirySourceID = dt.Rows[i]["EnquirySourceID"].ToString(),
                    BookingCommissionID = dt.Rows[i]["BookingCommissionID"].ToString(),
                    EnquiryStatusID = dt.Rows[i]["EnquiryStatusID"].ToString(),
                    ValidTillDate = dt.Rows[i]["ValidTillDatev"].ToString(),
                    SalesPersonID = dt.Rows[i]["SalesPersonID"].ToString(),
                    NominationID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
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
                    VoyageID = dt.Rows[i]["VoyageID"].ToString(),
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
                    PrincipalID = dt.Rows[i]["PrincipalID"].ToString(),
                    PODAgentID = dt.Rows[i]["PODAgentID"].ToString(),
                    FPODAgentID = dt.Rows[i]["FPODAgentID"].ToString(),
                    TSAgentID = dt.Rows[i]["TSportAgentID"].ToString(),
                    TSTwoAgentID = dt.Rows[i]["TSportTwoAgentID"].ToString(),
                    SlotOperatorID = dt.Rows[i]["SlotOperatorID"].ToString(),
                    OwnershipID = OwnershipIDv,
                    FixedID = FixedIDv,
                    TSVesselID = dt.Rows[i]["TSVesselID"].ToString(),
                    TSVoyageID = dt.Rows[i]["TSVoyageID"].ToString(),
                    BookingStatus = dt.Rows[i]["BookingStatus"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    OfficeCode = dt.Rows[i]["OfficeCode"].ToString(),
                    PaymentCenterID = Int32.Parse(dt.Rows[i]["PaymentCenterIDv"].ToString()),
                    SlotUptoID = Int32.Parse(dt.Rows[i]["SlotUptoIDv"].ToString()),
                    intStatus = dt.Rows[i]["intStatus"].ToString(),
                });

            }
            return ListEnq;
        }
        public DataTable GetExistingBookingViewRecord(MYBookingNew Data)
        {
            string _Query = " select (select top(1) EnquiryNo from NVO_Enquiry where Id = EnquiryID) as EnquiryNo,convert(varchar,BkgDate,23) as BkgDatev,convert(varchar,ValidTillDate,23) as ValidTillDatev,case when intStatus = 2 then 'CONFIRM' else 'DRAFT' end as BookingStatus," +
                " isnull(PaymentCenterID,0) as PaymentCenterIDv,isnull(SlotUptoID,0) as SlotUptoIDv,* from NVO_Booking where ID= " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingBookingCntrTypeBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingCntrTypeBookingRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    Nos = dt.Rows[i]["Nos"].ToString(),


                });
            }
            return ListEnq;
        }
        public DataTable GetExistingCntrTypeBookingRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_BookingCntrType where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingBookingHazardousBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingHazardousBookingRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    HazarClass = dt.Rows[i]["HazardousClass"].ToString(),
                    HazarMCONo = dt.Rows[i]["MCONumber"].ToString(),


                });
            }
            return ListEnq;
        }

        public DataTable GetExistingHazardousBookingRecord(MyEnquiry Data)
        {
            string _Query = "  select* from NVO_BookingHazardous where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion


        public List<MyEnquiry> ExistingBookingOutGaugesBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingOutGaugesBookingRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    Length = dt.Rows[i]["CargoLength"].ToString(),
                    Width = dt.Rows[i]["CargoWidth"].ToString(),
                    Height = dt.Rows[i]["CargoHeight"].ToString(),


                });
            }
            return ListEnq;
        }
        public DataTable GetExistingOutGaugesBookingRecord(MyEnquiry Data)
        {
            string _Query = "  select * from NVO_BookingOutGaugesCargo where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingBookingRefferBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingBookingRefferRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityID = dt.Rows[i]["CommodityID"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    Ventilation = dt.Rows[i]["Ventilation"].ToString(),
                    Humidity = dt.Rows[i]["Humidity"].ToString(),
                });
            }
            return ListEnq;
        }

        public DataTable GetExistingBookingRefferRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_BookingReffer where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> ExistingBookingFreightRateBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingBookingFreightRateRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
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
            return ListEnq;
        }

        public DataTable GetExistingBookingFreightRateRecord(MyEnquiry Data)
        {
            string _Query = " select (select  top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_BookingFreightRate.CargoID) as Commodity, " +
                            " (select top(1) Type from NVO_tblCntrTypes where Id = NVO_BookingFreightRate.CntrTypeID) as CntrType,* from NVO_BookingFreightRate where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingBookingSlotRateBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingEnquirySlotRateRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
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
            return ListEnq;
        }

        public DataTable GetExistingEnquirySlotRateRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_BookingSlotRate where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }



        public List<MyEnquiry> ExistingBookingShimpmentPOLBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingBookingShimpmentPOLRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    ChargeOPT = Int32.Parse(dt.Rows[i]["ChargeOPT"].ToString()),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    Amount1 = dt.Rows[i]["Amount1"].ToString(),
                    Amount2 = dt.Rows[i]["Amount2"].ToString(),
                    Amount3 = dt.Rows[i]["Amount3"].ToString(),
                });
            }
            return ListEnq;
        }


        public DataTable GetExistingBookingShimpmentPOLRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_BookingShimpmentPOL where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEnquiry> ExistingBookingShimpmentPODBind(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            DataTable dt = GetExistingBookingShimpmentPODRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEnq.Add(new MyEnquiry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    ChargeOPT = Int32.Parse(dt.Rows[i]["ChargeOPT"].ToString()),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    Amount1 = dt.Rows[i]["Amount1"].ToString(),
                    Amount2 = dt.Rows[i]["Amount2"].ToString(),
                    Amount3 = dt.Rows[i]["Amount3"].ToString(),
                });
            }
            return ListEnq;
        }


        public DataTable GetExistingBookingShimpmentPODRecord(MyEnquiry Data)
        {
            string _Query = " select * from NVO_BookingShimpmentPOD where BkgID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyEnquiry> InsertBookingMaster(MyEnquiry Data)
        {
            List<MyEnquiry> ListEnq = new List<MyEnquiry>();
            int r1 = 0;
            int r2 = 0;
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                StringWriter stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(Data.GetType());
                serializer.Serialize(stringwriter, Data);
                Data.TextValues = stringwriter.ToString();

                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {
                    var SeqID = 0;
                    if (Data.BookingNo == "")
                        SeqID = 1;
                    else
                        SeqID = 2;

                    if (SeqID == 1)
                    {
                        string AutoGen = GetMaxseqNumber("BkgNo", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'BKG' + (select LocationCode from NVO_OfficeMaster where ID = " + Data.OfficeCode + ")  +right('0000' + convert(varchar(4), " + AutoGen + "), 4) + '/'+ (select top(1) FinYears from NVO_FinancialYear where YearID = " + Data.SessionFinYear + ")";
                        Data.BookingNo = Cmd.ExecuteScalar().ToString();
                    }


                    Cmd.CommandText = " UPDATE NVO_Booking SET BookingNo=@BookingNo,PODAgentID=@PODAgentID,FPODAgentID=@FPODAgentID,TSportAgentID=@TSportAgentID,TSportTwoAgentID=@TSportTwoAgentID,SlotOperatorID=@SlotOperatorID," +
                                      " OwnershipID=@OwnershipID,FixedID=@FixedID,VesselID=@VesselID,VoyageID=@VoyageID,TSVesselID=@TSVesselID,TSVoyageID=@TSVoyageID,OfficeCode=@OfficeCode,BkgDate=@BkgDate,CargoID=@CargoID," +
                                      " PaymentCenterID=@PaymentCenterID,SlotUptoID=@SlotUptoID,PrincipalID=@PrincipalID,EnquiryDate=@EnquiryDate where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingNo", Data.BookingNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODAgentID", Data.PODAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODAgentID", Data.FPODAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSportAgentID", Data.TSAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSportTwoAgentID", Data.TSTwoAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperatorID", Data.SlotOperatorID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnershipID", Data.OwnershipID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FixedID", Data.FixedID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.VoyageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSVesselID", Data.TSVesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSVoyageID", Data.TSVoyageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeCode", Data.OfficeCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgDate", Data.EnquiryDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CargoID", Data.CargoID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentCenterID", Data.PaymentCenterID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotUptoID", Data.SlotUptoID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincibalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnquiryDate", Data.EnquiryDate));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ItemsHarz != null)
                    {
                        string[] Array1 = Data.ItemsHarz.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingHazardous where BkgID=@BkgID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingHazardous(EnqID,BkgID,CommodityID,HazardousClass,MCONumber) " +
                                        " values (@EnqID,@BkgID,@CommodityID,@HazardousClass,@MCONumber) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingHazardous SET EnqID=@EnqID,BkgID=@BkgID,CommodityID=@CommodityID,HazardousClass=@HazardousClass,MCONumber=@MCONumber " +
                                        " where BkgID=@BkgID and HazardousClass=@HazardousClass";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
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
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingOutGaugesCargo where BkgID=@BkgID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingOutGaugesCargo(EnqID,BkgID,CommodityID,CargoLength,CargoWidth,CargoHeight) " +
                                        " values (@EnqID,@BkgID,@CommodityID,@CargoLength,@CargoWidth,@CargoHeight) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingOutGaugesCargo SET EnqID=@EnqID,BkgID=@BkgID,CommodityID=@CommodityID,CargoLength=@CargoLength,CargoWidth=@CargoWidth,CargoHeight=@CargoHeight " +
                                        " where BkgID=@BkgID and CommodityID=@CommodityID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("BkgID", Data.ID));
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
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingReffer where BkgID=@BkgID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingReffer(EnqID,BkgID,CommodityID,Temperature,Ventilation,Humidity) " +
                                        " values (@EnqID,@BkgID,@CommodityID,@Temperature,@Ventilation,@Humidity) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingReffer SET EnqID=@EnqID,BkgID=@BkgID,CommodityID=@CommodityID,Temperature=@Temperature,Ventilation=@Ventilation,Humidity=@Humidity " +
                                        " where BkgID=@BkgID and CommodityID=@CommodityID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
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
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingShimpmentPOL where BkgID=@BkgID and CntrTypeID=@CntrTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingShimpmentPOL(EnqID,BkgID,CntrTypeID,ChargeOPT,Amount2,Remarks,CurrencyID) " +
                                        " values (@EnqID,@BkgID,@CntrTypeID,@ChargeOPT,@Amount2,@Remarks,@CurrencyID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingShimpmentPOL SET EnqID=@EnqID,BkgID=@BkgID,CntrTypeID=@CntrTypeID,ChargeOPT=@ChargeOPT,Amount2=@Amount2,Remarks=@Remarks,CurrencyID=@CurrencyID " +
                                        " where BkgID=@BkgID and CntrTypeID=@CntrTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
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
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingShimpmentPOD where BkgID=@BkgID and CntrTypeID=@CntrTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingShimpmentPOD(EnqID,BkgID,CntrTypeID,ChargeOPT,Amount2,Remarks,CurrencyID) " +
                                        " values (@EnqID,@BkgID,@CntrTypeID,@ChargeOPT,@Amount2,@Remarks,@CurrencyID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingShimpmentPOD SET EnqID=@EnqID,BkgID=@BkgID,CntrTypeID=@CntrTypeID,ChargeOPT=@ChargeOPT,Amount2=@Amount2,Remarks=@Remarks,CurrencyID=@CurrencyID " +
                                        " where BkgID=@BkgID and CntrTypeID=@CntrTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
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
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingFreightRate where BkgID=@BkgID and CntrTypeID=@CntrTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingFreightRate(EnqID,BkgID,CntrTypeID,Nos,CargoID,FrtChargePerAmt,ManifestAmt,CommissionPerAmt,CurrencyID) " +
                                        " values (@EnqID,@BkgID,@CntrTypeID,@Nos,@CargoID,@FrtChargePerAmt,@ManifestAmt,@CommissionPerAmt,@CurrencyID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingFreightRate SET EnqID=@EnqID,BkgID=@BkgID,CntrTypeID=@CntrTypeID,Nos=@Nos,CargoID=@CargoID,FrtChargePerAmt=@FrtChargePerAmt,ManifestAmt=@ManifestAmt," +
                                        " CommissionPerAmt=@CommissionPerAmt,CurrencyID=@CurrencyID " +
                                        " where BkgID=@BkgID and CntrTypeID=@CntrTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
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
                            Cmd.CommandText = " IF((select count(*) from NVO_BookingSlotRate where BkgID=@BkgID and CntrTypeID=@CntrTypeID and CommodityID=@CommodityID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_BookingSlotRate(EnqID,BkgID,CntrTypeID,Nos,CommodityID,CurrencyID,PerAmount,TotalAmount,ManifestPerAmount,ManifestTotalAmount) " +
                                        " values (@EnqID,@BkgID,@CntrTypeID,@Nos,@CommodityID,@CurrencyID,@PerAmount,@TotalAmount,@ManifestPerAmount,@ManifestTotalAmount) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_BookingSlotRate SET EnqID=@EnqID,BkgID=@BkgID,CntrTypeID=@CntrTypeID,Nos=@Nos,CommodityID=@CommodityID,CurrencyID=@CurrencyID,PerAmount=@PerAmount," +
                                            " TotalAmount=@TotalAmount,ManifestPerAmount=@ManifestPerAmount,ManifestTotalAmount=@ManifestTotalAmount where BkgID=@BkgID and CntrTypeID=@CntrTypeID and CommodityID=@CommodityID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.ID));
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
                    ListEnq.Add(new MyEnquiry
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Booking Details Updated Successfully" + Data.BookingNo,
                        BookingNo = Data.BookingNo


                    });
                    return ListEnq;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListEnq.Add(new MyEnquiry { AlertMessage = ex.Message, AlertMegId = "2" });
                    return ListEnq;
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


        public List<MYBookingNew> InsertBkgStatusUpdate(MYBookingNew Data)
        {
            List<MYBookingNew> ListView = new List<MYBookingNew>();
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
                                 " UPDATE NVO_Booking SET intStatus=@intStatus where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@intStatus", 2));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    ListView.Add(new MYBookingNew
                    {
                        AlertMessage = "Status Confirm",
                        AlertMegId = "1"


                    });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListView.Add(new MYBookingNew { AlertMessage = ex.Message, AlertMegId = "2" });
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

        public List<MYBookingNew> PaymentCenterBindData(MYBookingNew Data)
        {
            List<MYBookingNew> Lisbq = new List<MYBookingNew>();
            DataTable dt = GetPaymentCenterBindData(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Lisbq.Add(new MYBookingNew
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return Lisbq;
        }


        public DataTable GetPaymentCenterBindData(MYBookingNew Data)
        {
            string _Query = " select * from NVO_GeneralMaster where Seqno=83 ";
            return GetViewData(_Query, "");
        }

        #region bookinglevel


        public List<MyBookingSource> ExistingBookinglevelvalues(MyBookingSource Data)
        {
            DataTable dt = GetExistingBookinglevel(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Booking.Add(new MyBookingSource
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    BkgCount = dt.Rows[i]["BkgCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),


                }); ;
            }
            return Booking;
        }
        public DataTable GetExistingBookinglevel(MyBookingSource Data)
        {
            string strWhere = "";

            string _Query = "select top(10) NVO_VesselMaster.Id,VesselName, (select top(1)ExportVoyageCd from NVO_Voyage " +
                "inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = NVO_Voyage.ID and VesselID = NVO_VesselMaster.ID)  as VoyageName, " +
                "(select top(1) NVO_Voyage.ETD from NVO_Voyage inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = NVO_Voyage.ID and VesselID = NVO_VesselMaster.ID)  as ETD, " +
                "(select  count(ID) from NVO_Booking where VesselID = NVO_VesselMaster.ID) as BkgCount, (select count(ContainerID) " +
                "from NVO_ContainerTxns inner join NVO_Booking on NVO_Booking.ID = NVO_ContainerTxns.BLNumber where NVO_Booking.VesselID = NVO_VesselMaster.ID) as CntrCount,* from NVO_VesselMaster";

            //string _Query = "select top(10) NVO_VesselMaster.Id,VesselName, (select top(1)ExportVoyageCd from NVO_Voyage " +
            //  "inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = NVO_Voyage.ID and VesselID = NVO_VesselMaster.ID)  as VoyageName, " +
            //  "(select top(1) NVO_Voyage.ETD from NVO_Voyage inner join NVO_VoyageRoute on NVO_VoyageRoute.VoyageID = NVO_Voyage.ID and VesselID = NVO_VesselMaster.ID)  as ETD, " +
            //  "(select  count(ID) from NVO_Booking where VesselID = NVO_VesselMaster.ID) as BkgCount, * from NVO_VesselMaster";




            //if (strWhere == "")
            //    strWhere = _Query;
            //return GetViewData(strWhere, "");
            return GetViewData(_Query, "");

        }

        #endregion

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

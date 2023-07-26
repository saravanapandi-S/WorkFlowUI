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
    public class CommonAccessManager
    {


        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CommonAccessManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion


        #region PortMaster Drodown
        public List<MyCommonAccess> PortMaster()
        {
            List<MyCommonAccess> PortList = new List<MyCommonAccess>();
            DataTable dt = GetPortMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PortList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString()
                });
            }
            return PortList;
        }

        public DataTable GetPortMaster()
        {
            string _Query = "select Id,PortCode +'-'+ PortName as PortName from NVO_PortMaster";
            return GetViewData(_Query, "");
        }

        #endregion

        #region CntrTypes
        public List<MyCommonAccess> CntrTypesMaster()
        {
            List<MyCommonAccess> CntrTypesList = new List<MyCommonAccess>();
            DataTable dt = GetCntrTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrTypesList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypes = dt.Rows[i]["Size"].ToString(),
                    Basic = dt.Rows[i]["IntBasic"].ToString(),
                });
            }
            return CntrTypesList;
        }

        public DataTable GetCntrTypesMaster()
        {
            string _Query = " select * from NVO_tblCntrTypes";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> BookingCntrTypesMaster(MyCommonAccess Data)
        {
            List<MyCommonAccess> CntrTypesList = new List<MyCommonAccess>();
            DataTable dt = GetBookingCntrTypesMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrTypesList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypes = dt.Rows[i]["Size"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),

                });
            }
            return CntrTypesList;
        }

        public DataTable GetBookingCntrTypesMaster(MyCommonAccess Data)
        {
            string _Query = " Select ID, Size, NVO_BookingCntrTypes.Qty - isnull((select sum(ReqQty) from NVO_CRODetails inner join NVO_CROMaster on NVO_CROMaster.ID = NVO_CRODetails.CROID " +
                            " where NVO_CROMaster.BkgID = NVO_BookingCntrTypes.BKgID and NVO_CROMaster.CROStatus = 0 group by NVO_CROMaster.BkgID),0) as Qty from NVO_tblCntrTypes " +
                            " inner join NVO_BookingCntrTypes on NVO_BookingCntrTypes.CntrTypes = NVO_tblCntrTypes.ID where BKgID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> BookingCntrQtyTypesMaster(MyCommonAccess Data)
        {
            List<MyCommonAccess> CntrTypesList = new List<MyCommonAccess>();
            DataTable dt = GetBookingCntrQtyTypesMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrTypesList.Add(new MyCommonAccess
                {
                    Qty = dt.Rows[i]["Qty"].ToString()

                });
            }
            return CntrTypesList;
        }

        public DataTable GetBookingCntrQtyTypesMaster(MyCommonAccess Data)
        {
            string _Query = " select * from NVO_BookingCntrTypes where CntrTypes = " + Data.CntrTypes + " and BKgID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }
        public List<MyCommonAccess> CntrTypesMasterValuePass(MyCommonAccess Data)
        {
            List<MyCommonAccess> CntrTypesList = new List<MyCommonAccess>();
            DataTable dt = GetCntrTypesMasterValuePass(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrTypesList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrTypes = dt.Rows[i]["Size"].ToString()
                });
            }
            return CntrTypesList;
        }

        public DataTable GetCntrTypesMasterValuePass(MyCommonAccess Data)
        {
            string _Query = " select* from NVO_tblCntrTypes where IntBasic=" + Data.ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Commodity
        public List<MyCommonAccess> CommodityMaster()
        {
            List<MyCommonAccess> CommodityList = new List<MyCommonAccess>();
            DataTable dt = GeCommodityMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CommodityList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString()
                });
            }
            return CommodityList;
        }

        public DataTable GeCommodityMaster()
        {
            string _Query = " select * from NVO_CommodityMaster";
            return GetViewData(_Query, "");
        }

        #endregion

        #region ServiceTypes
        public List<MyCommonAccess> ServiceTypesMaster()
        {
            List<MyCommonAccess> ServiceTypesList = new List<MyCommonAccess>();
            DataTable dt = GeServiceTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ServiceTypesList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ServiceTypesName = dt.Rows[i]["Description"].ToString()
                });
            }
            return ServiceTypesList;
        }

        public DataTable GeServiceTypesMaster()
        {
            string _Query = " select * from NVO_tblDLValues where SeqNo = 1";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> SlotTermsMaster()
        {
            List<MyCommonAccess> SlotList = new List<MyCommonAccess>();
            DataTable dt = GetSlotTermsMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SlotList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SlotTerm = dt.Rows[i]["Description"].ToString()
                });
            }
            return SlotList;
        }

        public DataTable GetSlotTermsMaster()
        {
            string _Query = " select * from NVO_tblDLValues where SeqNo = 2";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> CntrMovementMaster()
        {
            List<MyCommonAccess> List = new List<MyCommonAccess>();
            DataTable dt = GetCntrMovement();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrStatus = dt.Rows[i]["StatusCode"].ToString()
                });
            }
            return List;
        }

        public DataTable GetCntrMovement()
        {
            string _Query = "select ID, StatusCode from NVO_ContainerStatusCodes";
            return GetViewData(_Query, "");
        }


        #endregion

        #region CurrencyMaster

        public List<MyCommonAccess> CurrencyMaster()
        {
            List<MyCommonAccess> CurrencyList = new List<MyCommonAccess>();
            DataTable dt = GetCurrencyMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CurrencyList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Currency = dt.Rows[i]["CurrencyCode"].ToString()
                });
            }
            return CurrencyList;
        }

        public DataTable GetCurrencyMaster()
        {
            string _Query = " select * from NVO_CurrencyMaster";
            return GetViewData(_Query, "");
        }

        #endregion

        #region ChargeCode

        public List<MyCommonAccess> ChargecodeMaster()
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetChargecodeMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }

        public List<MyCommonAccess> ChargeCodeMasterBind()
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetChargecodeMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }

        public DataTable GetChargecodeMaster()
        {
            string _Query = "select ID,ChgCode +' - '+ chgDesc as ChargeCode from NVO_ChargeTB";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> ChargeCodeAgentMaster()
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetChargecodeAgentMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }

        public DataTable GetChargecodeAgentMaster()
        {
            string _Query = "select ID,ChgCode +' - '+ chgDesc as ChargeCode from NVO_ChargeTB where OwnershipID=24";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> ChargecodeMasterTypes(MyCommonAccess Data)
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetChargecodeMasterTypes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }

        public DataTable GetChargecodeMasterTypes(MyCommonAccess Data)
        {
            string _Query = "select ID,ChgCode +' - '+ chgDesc as ChargeCode from NVO_ChargeTB where IsRevenue=3 or IsRevenue= " + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyCommonAccess> MUCChargecodeMasterTypes(MyCommonAccess Data)
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetMUCChargecodeMasterTypes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }

        public DataTable GetMUCChargecodeMasterTypes(MyCommonAccess Data)
        {
            string _Query = "select ID,ChgCode +' - '+ chgDesc as ChargeCode from NVO_ChargeTB where IsRevenue != 1  and Breakup=1";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> IFSChargecodeMasterTypes(MyCommonAccess Data)
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetIFSChargecodeMasterTypes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }

        public DataTable GetIFSChargecodeMasterTypes(MyCommonAccess Data)
        {
            string _Query = "select ID,ChgCode +' - '+ chgDesc as ChargeCode from NVO_ChargeTB where Id in(73,74,11,2,75,66,76)";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> Generalmaster(string IDv)
        {
            List<MyCommonAccess> GeneralList = new List<MyCommonAccess>();
            DataTable dt = GetGeneralMaster(IDv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return GeneralList;
        }

        public DataTable GetGeneralMaster(string ID)
        {
            string _Query = "select * from NVO_GeneralMaster where SeqNo = " + ID;
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> TariffMasterGeneralmaster(string IDv)
        {
            List<MyCommonAccess> GeneralList = new List<MyCommonAccess>();
            DataTable dt = GetTraiffMastGeneralMaster(IDv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return GeneralList;
        }

        public DataTable GetTraiffMastGeneralMaster(string ID)
        {
            string _Query = "select * from NVO_GeneralMaster where Id != 137 and SeqNo = " + ID;
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> AgencyMaster()
        {
            List<MyCommonAccess> AgencyList = new List<MyCommonAccess>();
            DataTable dt = GetAgencyMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString()
                });
            }
            return AgencyList;
        }

        public DataTable GetAgencyMaster()
        {
            string _Query = "select ID,AgencyName from NVO_AgencyMaster";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> PortAgencyMaster(MyCommonAccess Data)
        {
            List<MyCommonAccess> AgencyList = new List<MyCommonAccess>();
            DataTable dt = GetPortAgencyMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString()
                });
            }
            return AgencyList;
        }

        public DataTable GetPortAgencyMaster(MyCommonAccess Data)
        {
            string _Query = " select NVO_AgencyMaster.ID,AgencyName from NVO_AgencyPortDtls inner join NVO_AgencyMaster on NVO_AgencyMaster.ID = NVO_AgencyPortDtls.AgencyID where PortId =" + Data.PortID;
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> CustomerMaster()
        {
            List<MyCommonAccess> CustomerList = new List<MyCommonAccess>();
            DataTable dt = GetCustomerMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CustomerList;
        }



        public DataTable GetCustomerMaster()
        {
            string _Query = " select NVO_CusBranchLocation.CId,upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id " +
                            " order by NVO_CustomerMaster.CustomerName ";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> PrincipleCustomerMaster()
        {
            List<MyCommonAccess> CustomerList = new List<MyCommonAccess>();
            DataTable dt = GetPrincipalMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["LineName"].ToString().ToUpper()
                });
            }
            return CustomerList;
        }

        public DataTable GetPrincipalMaster()
        {
            string _Query = "select ID,LineName from NVO_PrincipalMaster";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> CustomerMasterValuesPass(MyCommonAccess Data)
        {
            List<MyCommonAccess> CustomerList = new List<MyCommonAccess>();
            DataTable dt = GetCustomerMasterParameterPass(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerMasterParameterPass(MyCommonAccess Data)
        {
            string _Query = " select NVO_CusBranchLocation.CId,upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id " +
                            " inner join NVO_CusBusinessTypes on NVO_CusBusinessTypes.CustomerID=NVO_CustomerMaster.ID" +
                            " where NVO_CusBusinessTypes.BussTypes=" + Data.BussTypes +
                            " order by NVO_CustomerMaster.CustomerName ";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> VendorMaster()
        {
            List<MyCommonAccess> CustomerList = new List<MyCommonAccess>();
            DataTable dt = GetVendorMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    VendorName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CustomerList;
        }

        public DataTable GetVendorMaster()
        {
            string _Query = " select NVO_CusBranchLocation.CId,upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id where CustomerType =44 " +
                            " order by NVO_CustomerMaster.CustomerName ";
            return GetViewData(_Query, "");
        }
        public List<MyCommonAccessNew> CustomerMasterNew()
        {
            List<MyCommonAccessNew> CustomerList = new List<MyCommonAccessNew>();
            DataTable dt = GetCustomerMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccessNew
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CustomerList;
        }
        public List<MyCommonAccessNew> CustomerMasterNewEx(string Party)
        {

            List<MyCommonAccessNew> CustomerList = new List<MyCommonAccessNew>();
            DataTable dt = GetSearchCustomerMaster(Party);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccessNew
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CustomerList;
        }

        public DataTable GetSearchCustomerMaster(string Party)
        {
            string _Query = " select top(20) NVO_CusBranchLocation.CId,upper(CustomerName + '-' + Branch) as CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.Id " +
                            " where CustomerName like '%" + Party + "%'";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> CountryMaster()
        {
            List<MyCommonAccess> CountryList = new List<MyCommonAccess>();
            DataTable dt = CountryMasster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CountryList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryName = dt.Rows[i]["CountryName"].ToString()
                });
            }
            return CountryList;
        }

        public DataTable CountryMasster()
        {
            string _Query = "select ID,CountryName from NVO_CountryMaster";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> UserMaster()
        {
            List<MyCommonAccess> UserList = new List<MyCommonAccess>();
            DataTable dt = GetUserMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString()
                });
            }
            return UserList;
        }

        public DataTable GetUserMaster()
        {
            string _Query = "select * from NVO_UserDetails";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> RRNumberMaster()
        {
            List<MyCommonAccess> RRList = new List<MyCommonAccess>();
            DataTable dt = GetURRMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RRList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString()
                });
            }
            return RRList;
        }

        public DataTable GetURRMaster()
        {
            string _Query = "select * from NVO_Ratesheet";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> DepotMaster()
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetDepotMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DepName = dt.Rows[i]["DepName"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetDepotMaster()
        {
            string _Query = "select Id,DepName from NVO_DepotMaster";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> TerminalMaster()
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetTerminalMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetTerminalMaster()
        {
            string _Query = "select Id,TerminalName from NVO_TerminalMaster";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> VesselMaster()
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetVesselMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetVesselMaster()
        {
            string _Query = "select Id,VesselName from NVO_VesselMaster";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> VesVoyMaster()
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetVesselVoyageMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetVesselVoyageMaster()
        {
            string _Query = "Select V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as VesVoy from NVO_Voyage V WHERE V.ISExpImp=0 ";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> VesVoyAgencywiseMaster(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetVesselVoyageAgencyMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetVesselVoyageAgencyMaster(MyCommonAccess Data)
        {
            string _Query = "Select V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as VesVoy from NVO_Voyage V WHERE V.ISExpImp=" + Data.Status + " and AgencyID=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> BookingMaster()
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetBookingMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString()
                });
            }
            return ViewList;
        }


        public DataTable GetBookingMaster()
        {
            string _Query = "select Id,BookingNo from NVO_Booking";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> BLMaster()
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetBLMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetBLMaster()
        {
            string _Query = "select Id,BLNumber from NVO_BOL";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> CntrNoMaster()
        {
            List<MyCommonAccess> CntrNoList = new List<MyCommonAccess>();
            DataTable dt = GetCntrNosMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrNoList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString()
                });
            }
            return CntrNoList;
        }

        public DataTable GetCntrNosMaster()
        {
            string _Query = " select* from NVO_Containers";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> BusinessTypesMaster()
        {
            List<MyCommonAccess> BussList = new List<MyCommonAccess>();
            DataTable dt = GetBusinessTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BussList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BusinessTypes = dt.Rows[i]["BusinessType"].ToString()
                });
            }
            return BussList;
        }

        public DataTable GetBusinessTypesMaster()
        {
            string _Query = " select * from NVO_BusinessTypes";
            return GetViewData(_Query, "");
        }



        public List<MyCommonAccess> CustomerAddress(string IDv)
        {
            List<MyCommonAccess> CustomerList = new List<MyCommonAccess>();
            DataTable dt = GetCustomerAddress(IDv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccess
                {
                    CustomerAddress = dt.Rows[i]["Address"].ToString()
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerAddress(string ID)
        {
            string _Query = "select Address from NVO_CusBranchLocation where CustomerID=" + ID;
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> CargoTypesMaster()
        {
            List<MyCommonAccess> BussList = new List<MyCommonAccess>();
            DataTable dt = GetCargoTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BussList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CargoName = dt.Rows[i]["PkgDescription"].ToString()
                });
            }
            return BussList;
        }

        public DataTable GetCargoTypesMaster()
        {
            string _Query = "select ID,PkgDescription from NVO_CargoPkgMaster";
            return GetViewData(_Query, "");
        }



        public List<MyCommonAccess> CustomerBussTypesmaster(MyCommonAccess Data)
        {
            List<MyCommonAccess> List = new List<MyCommonAccess>();
            DataTable dt = GetCustomerBussTypessMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return List;
        }

        public DataTable GetCustomerBussTypessMaster(MyCommonAccess Data)
        {
            string _Query = " select distinct NVO_CusBranchLocation.CID as ID,(CustomerName  + '-' + Branch) as CustomerName from NVO_CustomerMaster CM inner join NVO_CusBusinessTypes on NVO_CusBusinessTypes.CustomerID = CM.ID inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = CM.Id " +
                            " where BussTypes in (7,8,13)";
            return GetViewData(_Query, "");
        }
        #endregion

        public List<MyCommonAccess> ChargeCodeDetentionMasterBind()
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetChargecodeDetentionMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString()
                });
            }
            return ChargeList;
        }


        public DataTable GetChargecodeDetentionMaster()
        {
            string _Query = "select ID,ChgCode +' - '+ chgDesc as ChargeCode from NVO_ChargeTB where Id in (28,29,30)";
            return GetViewData(_Query, "");
        }

        #region StatusMaster

        public List<MyCommonAccess> StatusMaster()
        {
            List<MyCommonAccess> CurrencyList = new List<MyCommonAccess>();
            DataTable dt = GetStatusDtls();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CurrencyList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Status = dt.Rows[i]["Description"].ToString()
                });
            }
            return CurrencyList;
        }

        public DataTable GetStatusDtls()
        {
            string _Query = " select ID,Description from NVO_tblDLValues where seqNo=3";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> VesVoyByAgency(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetVesselVoyageAgency(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetVesselVoyageAgency(MyCommonAccess Data)
        {
            string _Query = "Select V.ID,(select top(1) VesselName from NVO_VesselMaster where ID = V.VesselID) + ' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = V.ID) as VesVoy from NVO_Voyage V WHERE V.ISExpImp=0 and AgencyID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> BindMonthsList(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetBindMonthsList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Months = dt.Rows[i]["Months"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetBindMonthsList(MyCommonAccess Data)
        {
            string _Query = "Select * from NVO_MonthList";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> BindYearList(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetBindYearList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Years = dt.Rows[i]["YearID"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetBindYearList(MyCommonAccess Data)
        {
            string _Query = "Select * from NVO_FinancialYear";
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> BindMainPortsList(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetBindMainPorts(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortName = dt.Rows[i]["PortName"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetBindMainPorts(MyCommonAccess Data)
        {
            string _Query = "Select * from NVO_PortMainMaster ";
            return GetViewData(_Query, "");
        }
        public List<MyCommonAccess> BindAlertTypesAgency(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetBindAlertTypesAgency(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetBindAlertTypesAgency(MyCommonAccess Data)
        {
            string _Query = "select * from NVO_GeneralMaster WHERE SeqNo=55";
            return GetViewData(_Query, "");
        }


        public List<MyCommonAccess> BindNotsclauses(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetNotsclauses(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetNotsclauses(MyCommonAccess Data)
        {
            string _Query = "   select * from NVO_BLNotesClauses where DocID=" + Data.DocID;
            return GetViewData(_Query, "");
        }

        #endregion

        public List<MyCommonAccess> TerminalPortMaster(MyCommonAccess Data)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetTerminalPortMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString()
                });
            }
            return ViewList;
        }


        public DataTable GetTerminalPortMaster(MyCommonAccess Data)
        {
            string _Query = "select Id,TerminalName from NVO_TerminalMaster where PortID=" + Data.PortID;
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> newVesVoyMaster(string VesselID)
        {
            List<MyCommonAccess> ViewList = new List<MyCommonAccess>();
            DataTable dt = GetVesVoyageMaster(VesselID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString()
                });
            }
            return ViewList;
        }
        public DataTable GetVesVoyageMaster(string VesselID)
        {
            string _Query = "select Id,VoyageNo from NVO_Voyage where VesselID=" + VesselID;
            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> OfficeLocationMaster()
        {
            List<MyCommonAccess> CustomerList = new List<MyCommonAccess>();
            DataTable dt = GetLocationMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["OfficeLoc"].ToString().ToUpper()
                });
            }
            return CustomerList;
        }

        public DataTable GetLocationMaster()
        {
            string _Query = " select * from NVO_OfficeMaster";
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


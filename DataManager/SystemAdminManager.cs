using DataBaseFactory;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace DataManager
{
    public class SystemAdminManager
    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public SystemAdminManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region GetData

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

        #endregion
        #region Common List

        List<MySystem> ListCmn = new List<MySystem>();
        List<MySACountry> ListCtry = new List<MySACountry>();
        List<MySACity> ListCity = new List<MySACity>();
        List<MySAState> ListState = new List<MySAState>();
        List<MySAPort> ListPort = new List<MySAPort>();
        List<MySATerminal> ListTerminal = new List<MySATerminal>();
        List<MySAShipmentLocation> ListSL = new List<MySAShipmentLocation>();
        List<MySACommodity> ListCommodity = new List<MySACommodity>();
        List<MySAPackageType> ListPkgType = new List<MySAPackageType>();
        List<MySAContainerType> ListCntrType = new List<MySAContainerType>();
        List<MySAHazClass> ListHazClass = new List<MySAHazClass>();
        List<MyCompany> ListCompany = new List<MyCompany>();
        List<MyCommodity> ListCmdity = new List<MyCommodity>();
        List<MyConfig> ListConfig = new List<MyConfig>();
        List<MySAContainerGroup> ListCntrGroups = new List<MySAContainerGroup>();
        List<MySACurrency> ListCurrency = new List<MySACurrency>();
        List<MySAContainerTypeDetails> ListCTDetails = new List<MySAContainerTypeDetails>();
        List<MySAUOM> ListUom = new List<MySAUOM>();
        List<MySAEmailConfig> ListEmailConfig = new List<MySAEmailConfig>();
        List<MySAUOMTypes> ListUOMTypes = new List<MySAUOMTypes>();


        #endregion

        #region CommonApi


        public List<MySACountry> GetCountries()
        {

            DataTable dt = GetCountriesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCtry.Add(new MySACountry
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryCode = dt.Rows[i]["CountryCode"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString()
                });
            }
            return ListCtry;
        }


        public DataTable GetCountriesMaster()
        {
            string _Query = " select  ID,(CountryCode +' - '+ CountryName) as  Country,CountryName,CountryCode from SA.CountryMaster WHERE Status =1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAState> GetStates()
        {

            DataTable dt = GetStatesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListState.Add(new MySAState
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    StateCode = dt.Rows[i]["StateCode"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListState;
        }


        public DataTable GetStatesMaster()
        {
            string _Query = "  select ID,(StateCode +' - '+ StateName) as  State,StateName,StateCode,CountryID from SA.StateMaster WHERE Status =1  ";
            return GetViewData(_Query, "");
        }

        public List<MySAState> GetStatesByCountry(MySAState Data)
        {

            DataTable dt = GetStatesByCountryMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListState.Add(new MySAState
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    StateCode = dt.Rows[i]["StateCode"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListState;
        }


        public DataTable GetStatesByCountryMaster(MySAState Data)
        {
            string _Query = " select ID,(StateCode +' - '+ StateName) as  State,StateName,StateCode,CountryID from SA.StateMaster WHERE Status =1 and CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }

        public List<MySACity> GetCity()
        {

            DataTable dt = GetCityMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCity.Add(new MySACity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    CityCode = dt.Rows[i]["CityCode"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                });
            }
            return ListCity;
        }


        public DataTable GetCityMaster()
        {
            string _Query = " select ID,(CityCode +' - '+ CityName) as  City,CityCode,CityName,CountryID,StateID from SA.CityMaster WHERE Status =1  ";
            return GetViewData(_Query, "");
        }


        public List<MySACity> GetCities(MySACity Data)
        {
            DataTable dt = GetCitiesValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCity.Add(new MySACity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    CityCode = dt.Rows[i]["CityCode"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),

                });

            }
            return ListCity;
        }
        public DataTable GetCitiesValues(MySACity Data)
        {
            string strWhere = "";

            string _Query = " select ID,(CityCode +' - '+ CityName) as  City,CityCode,CityName,CountryID,StateID from SA.CityMaster WHERE Status =1  ";

            if (Data.CountryID.ToString() != "" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " AND SA.CityMaster.CountryID = " + Data.CountryID.ToString() + "";
                else
                    strWhere += " and SA.CityMaster.CountryID = " + Data.CountryID.ToString() + "";

            if (Data.StateID.ToString() != "" && Data.StateID.ToString() != "0" && Data.StateID.ToString() != null && Data.StateID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " AND SA.CityMaster.StateID = " + Data.StateID.ToString();
                else
                    strWhere += " and SA.CityMaster.StateID = " + Data.StateID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");



        }

        public List<MySAPort> GetPort()
        {

            DataTable dt = GetPortMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),

                });
            }
            return ListPort;
        }


        public DataTable GetPortMaster()
        {
            string _Query = " select ID,PortCode +' - '+ PortName as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                "  from SA.PortMaster WHERE Status =1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAPort> GetPorts(MySAPort Data)
        {

            DataTable dt = GetPortsMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GetPortsMaster(MySAPort Data)
        {
            string _Query = " select ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                " from SA.PortMaster WHERE Status =1 AND CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }


        public List<MySAPort> GetICDPortsByCountry(MySAPort Data)
        {

            DataTable dt = GetICDPortsByCountryMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GetICDPortsByCountryMaster(MySAPort Data)
        {
            string _Query = " select ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                 " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                "  from SA.PortMaster WHERE Status =1 and IsICDPort=1 AND CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }

        public List<MySAPort> GetSeaPortsByCountry(MySAPort Data)
        {

            DataTable dt = GetSeaPortsByCountryMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GetSeaPortsByCountryMaster(MySAPort Data)
        {
            string _Query = " select ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                "  from SA.PortMaster WHERE Status =1 and IsSeaPort=1 AND CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }
        public List<MySAPort> GetAirPortsByCountry(MySAPort Data)
        {

            DataTable dt = GGetAirPortsByCountryMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GGetAirPortsByCountryMaster(MySAPort Data)
        {
            string _Query = " select ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                  " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                  "  from SA.PortMaster WHERE Status =1 and IsAirPort=1 AND CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }



        public List<MySAPort> GetSeaPorts()
        {

            DataTable dt = GetSeaPortsMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GetSeaPortsMaster()
        {
            string _Query = " select  ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                  " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                "  from SA.PortMaster WHERE Status =1 and IsSeaPort=1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAPort> GetICDPorts()
        {

            DataTable dt = GetICDPortsMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GetICDPortsMaster()
        {
            string _Query = " select  ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                  " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                "  from SA.PortMaster WHERE Status =1 and IsICDPort=1 ";

            return GetViewData(_Query, "");
        }


        public List<MySAPort> GetAirPorts()
        {

            DataTable dt = GetAirPortsMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPort.Add(new MySAPort
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Port = dt.Rows[i]["Port"].ToString(),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortType = dt.Rows[i]["PortType"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListPort;
        }


        public DataTable GetAirPortsMaster()
        {
            string _Query = " select  ID,(PortCode +' - '+ PortName) as  Port,PortName,PortCode,CountryID,'' as OfficeLocation," +
                 " Case when IsSeaPort=1 THEN 'SEAPORT' when IsAirPort=1 THEN 'AIRPORT' when IsICDPort=1 THEN 'ICDPORT' END AS PortType " +
                " from SA.PortMaster WHERE Status =1 and IsAirPort=1 ";
            return GetViewData(_Query, "");
        }


        public List<MySATerminal> GetTerminalByPort(MySATerminal Data)
        {

            DataTable dt = GetTerminalByPortMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListTerminal.Add(new MySATerminal
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Terminal = dt.Rows[i]["Terminal"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    TerminalCode = dt.Rows[i]["TerminalCode"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                });
            }
            return ListTerminal;
        }


        public DataTable GetTerminalByPortMaster(MySATerminal Data)
        {
            string _Query = " select  ID,(TerminalCode +' - '+ TerminalName) as  Terminal,TerminalName,TerminalCode,PortID from SA.TerminalMaster WHERE Status = 1 and PortID= " + Data.PortID;
            return GetViewData(_Query, "");
        }

        public List<MySAShipmentLocation> GetShipmentLocations()
        {

            DataTable dt = GetShipmentLocationsMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSL.Add(new MySAShipmentLocation
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipmentLocation = dt.Rows[i]["ShipmentLocation"].ToString(),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    LocationName = dt.Rows[i]["Location"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListSL;
        }


        public DataTable GetShipmentLocationsMaster()
        {
            string _Query = " select ID,(LocationCode +' - '+ Location) as ShipmentLocation,LocationCode,Location,CountryID from SA.ShipmentLocation WHERE Status =1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAShipmentLocation> GetShipmentLocationsByCountry(MySAShipmentLocation Data)
        {

            DataTable dt = GetShipmentLocationsByCountryMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSL.Add(new MySAShipmentLocation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipmentLocation = dt.Rows[i]["ShipmentLocation"].ToString(),
                    LocationCode = dt.Rows[i]["LocationCode"].ToString(),
                    LocationName = dt.Rows[i]["Location"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListSL;
        }


        public DataTable GetShipmentLocationsByCountryMaster(MySAShipmentLocation Data)
        {
            string _Query = " select ID,(LocationCode +' - '+ Location) as ShipmentLocation,LocationCode,Location,CountryID from SA.ShipmentLocation WHERE Status = 1 and CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }

        public List<MySACommodity> GetCommodities()
        {

            DataTable dt = GetCommoditiesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCommodity.Add(new MySACommodity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    CommodityCode = dt.Rows[i]["CommodityUnCode"].ToString(),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString()

                });
            }
            return ListCommodity;
        }


        public DataTable GetCommoditiesMaster()
        {
            string _Query = " select  ID,(CommodityUnCode +' - '+ CommodityName) as Commodity,CommodityUnCode,CommodityName from SA.CommodityMaster WHERE Status =1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAPackageType> GetPackageTypes()
        {

            DataTable dt = GetPackageTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPkgType.Add(new MySAPackageType
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PackageType = dt.Rows[i]["PackageType"].ToString(),
                    PackageCode = dt.Rows[i]["PkgCode"].ToString(),
                    PackageDescription = dt.Rows[i]["PkgDescription"].ToString(),
                });
            }
            return ListPkgType;
        }


        public DataTable GetPackageTypesMaster()
        {
            string _Query = " select ID,PkgCode +' - '+ PkgDescription as  PackageType,PkgCode,PkgDescription from SA.CargoPkgMaster WHERE Status =1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAContainerType> GetContainerTypes()
        {

            DataTable dt = GetContainerTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrType.Add(new MySAContainerType
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContainerSize = dt.Rows[i]["Size"].ToString(),
                    ContainerDescription = dt.Rows[i]["CntrTypeDesc"].ToString(),
                    ContainerType = dt.Rows[i]["ContainerSize"].ToString(),

                });
            }
            return ListCntrType;
        }


        public DataTable GetContainerTypesMaster()
        {
            string _Query = " select ID,(Size +' - '+ CntrTypeDesc) ContainerSize,Size,CntrTypeDesc  from SA.CntrTypes WHERE Status =1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAContainerTypeDetails> GetContainerTypeDetails(MySAContainerTypeDetails Data)
        {

            DataTable dt = GetContainerTypeDetailsValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCTDetails.Add(new MySAContainerTypeDetails
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContainerSize = dt.Rows[i]["Size"].ToString(),
                    ContainerDescription = dt.Rows[i]["CntrTypeDesc"].ToString(),
                    ContainerType = dt.Rows[i]["ContainerSize"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    Height = dt.Rows[i]["Height"].ToString(),
                    Length = dt.Rows[i]["Length"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    TareWeight = dt.Rows[i]["TareWeight"].ToString(),
                    Teus = dt.Rows[i]["Teus"].ToString(),
                    MaxPayLoad = dt.Rows[i]["MaxPayLoad"].ToString(),
                    Group = dt.Rows[i]["GroupV"].ToString(),
                    GroupID = Int32.Parse(dt.Rows[i]["GroupID"].ToString()),
                });
            }
            return ListCTDetails;
        }


        public DataTable GetContainerTypeDetailsValues(MySAContainerTypeDetails Data)
        {
            string _Query = " select (select TOP (1) GeneralName from sa.GeneralMaster where ID=GroupID) As GroupV," +
                "  (Size +' - '+ CntrTypeDesc) ContainerSize, *  from SA.CntrTypes WHERE ID= " + Data.ContainerTypeID;
            return GetViewData(_Query, "");
        }


        public List<MySAContainerTypeDetails> GetCntrTypeDetailsByGroup(MySAContainerTypeDetails Data)
        {

            DataTable dt = GetCntrTypeDetailsByGroupValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCTDetails.Add(new MySAContainerTypeDetails
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContainerSize = dt.Rows[i]["Size"].ToString(),
                    ContainerDescription = dt.Rows[i]["CntrTypeDesc"].ToString(),
                    ContainerType = dt.Rows[i]["ContainerSize"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    Height = dt.Rows[i]["Height"].ToString(),
                    Length = dt.Rows[i]["Length"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    TareWeight = dt.Rows[i]["TareWeight"].ToString(),
                    Teus = dt.Rows[i]["Teus"].ToString(),
                    MaxPayLoad = dt.Rows[i]["MaxPayLoad"].ToString(),
                    Group = dt.Rows[i]["GroupV"].ToString(),
                    GroupID = Int32.Parse(dt.Rows[i]["GroupID"].ToString()),
                });
            }
            return ListCTDetails;
        }


        public DataTable GetCntrTypeDetailsByGroupValues(MySAContainerTypeDetails Data)
        {
            string _Query = " select (select TOP (1) GeneralName from sa.GeneralMaster where ID=GroupID)As GroupV," +
                " (Size +' - '+ CntrTypeDesc) ContainerSize,*  from SA.CntrTypes WHERE GroupID= " + Data.GroupID;
            return GetViewData(_Query, "");
        }

        public List<MySAHazClass> GetHazClasses()
        {

            DataTable dt = GetHazClassesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListHazClass.Add(new MySAHazClass
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    HazClass = dt.Rows[i]["DivisionDesc"].ToString(),
                    HazDescription = dt.Rows[i]["ClassDesc"].ToString()
                });
            }
            return ListHazClass;
        }


        public DataTable GetHazClassesMaster()
        {
            string _Query = " select * from SA.HazardousClasses WHERE Status =1";
            return GetViewData(_Query, "");
        }


        public List<MyCompany> GetCompanyDetails()
        {
            DataTable dt = GetCompanyDetailsValues();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCompany.Add(new MyCompany
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyCode = dt.Rows[i]["CompanyCode"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    POBox = dt.Rows[i]["POBox"].ToString(),
                    ZipCode = dt.Rows[i]["ZipCode"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    TelePhone1 = dt.Rows[i]["TelePhone1"].ToString(),
                    TelePhone2 = dt.Rows[i]["TelePhone2"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    ContactEmailID = dt.Rows[i]["ContactEmailID"].ToString(),
                    ContactName = dt.Rows[i]["ContactName"].ToString(),
                    URL = dt.Rows[i]["URL"].ToString(),
                    MobileNo = dt.Rows[i]["MobileNo"].ToString(),
                    Designation = dt.Rows[i]["Designation"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    LogoFileName = dt.Rows[i]["LogoFileName"].ToString(),
                });
            }
            return ListCompany;
        }
        public DataTable GetCompanyDetailsValues()
        {

            string _Query = "select  (select top 1 CountryName from SA.CountryMaster where ID =CountryID) as Country," +
                " (select top 1 cityname from SA.CityMaster where ID =CityID) as City,* from sa.CompanyDetails ";
            return GetViewData(_Query, "");

        }

        public List<MyCommodity> GetCommodityDetails(MyCommodity Data)
        {
            DataTable dt = GetCommodityDetailsRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCmdity.Add(new MyCommodity
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CommodityUnCode = dt.Rows[i]["CommodityUnCode"].ToString(),
                    CommodityName = dt.Rows[i]["CommodityName"].ToString(),
                    HSCode = dt.Rows[i]["HScode"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    DangerousFlag = dt.Rows[i]["DngFlag"].ToString(),
                    CommodityType = dt.Rows[i]["CmdtyType"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                });
            }
            return ListCmdity;
        }


        public DataTable GetCommodityDetailsRecord(MyCommodity Data)
        {
            string strWhere = "";


            string _Query = " select case when CM.DangerousFlag =1 then 'Yes' else 'No' end as DngFlag," +
                " (select top 1 GeneralName from SA.GeneralMaster where ID =CommodityType) as CmdtyType,* from SA.CommodityMaster CM ";

            if (Data.CommodityTypeID.ToString() != "" && Data.CommodityTypeID.ToString() != null && Data.CommodityTypeID.ToString() != "0" && Data.CommodityTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE CM.ID = " + Data.CommodityTypeID.ToString() + "";
                else
                    strWhere += " and CM.ID = " + Data.CommodityTypeID.ToString() + "";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MySAContainerGroup> GetContainerGroups()
        {

            DataTable dt = GetContainerGroupsMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrGroups.Add(new MySAContainerGroup
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContainerGroup = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCntrGroups;
        }


        public DataTable GetContainerGroupsMaster()
        {
            string _Query = " select * from sa.GeneralMaster where Status=1 and SeqNo=2 ";
            return GetViewData(_Query, "");
        }

        public List<MySACurrency> GetCurrency()
        {

            DataTable dt = GetCurrencyMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurrency.Add(new MySACurrency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyName = dt.Rows[i]["CurrencyName"].ToString(),
                    Symbol = dt.Rows[i]["Symbol"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),

                });
            }
            return ListCurrency;
        }


        public DataTable GetCurrencyMaster()
        {
            string _Query = " select ID,(CurrencyCode +' - '+ CurrencyName) as Currency,CurrencyCode,Symbol,CurrencyName,CountryID from sa.CurrencyMaster where Status=1 ";
            return GetViewData(_Query, "");
        }

        public List<MySACurrency> GetCurrencies(MySACurrency Data)
        {

            DataTable dt = GetCurrenciesMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCurrency.Add(new MySACurrency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyName = dt.Rows[i]["CurrencyName"].ToString(),
                    Symbol = dt.Rows[i]["Symbol"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                });
            }
            return ListCurrency;
        }


        public DataTable GetCurrenciesMaster(MySACurrency Data)
        {
            string _Query = " select ID,(CurrencyCode +' - '+ CurrencyName) as Currency,CurrencyCode,CurrencyName,CountryID,Symbol From sa.CurrencyMaster where Status=1 AND CountryID= " + Data.CountryID;
            return GetViewData(_Query, "");
        }

        public List<MySAUOM> GetUOM()
        {

            DataTable dt = GetUOMMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUom.Add(new MySAUOM
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOM = dt.Rows[i]["UOM"].ToString(),
                    UOMCode = dt.Rows[i]["UOMCode"].ToString(),
                    UOMDescription = dt.Rows[i]["UOMDesc"].ToString(),
                    UOMTypeID = Int32.Parse(dt.Rows[i]["UOMType"].ToString()),

                });
            }
            return ListUom;
        }


        public DataTable GetUOMMaster()
        {
            string _Query = " select ID,(UOMCode +' - '+UOMDesc) AS UOM,UOMCode,UOMDesc,UOMType from SA.UOMMaster where Status=1 ";
            return GetViewData(_Query, "");
        }

        public List<MySAUOM> GetUOMByType(MySAUOM Data)
        {

            DataTable dt = GetUOMByTypeMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUom.Add(new MySAUOM
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOM = dt.Rows[i]["UOM"].ToString(),
                    UOMCode = dt.Rows[i]["UOMCode"].ToString(),
                    UOMDescription = dt.Rows[i]["UOMDesc"].ToString(),
                    UOMTypeID = Int32.Parse(dt.Rows[i]["UOMType"].ToString()),

                });
            }
            return ListUom;
        }


        public DataTable GetUOMByTypeMaster(MySAUOM Data)
        {
            string _Query = " select ID,(UOMCode +' - '+UOMDesc) AS UOM,UOMCode,UOMDesc,UOMType from SA.UOMMaster where Status=1 AND UOMType= " + Data.UOMTypeID;
            return GetViewData(_Query, "");
        }

        public List<MySAEmailConfig> GetEmailConfiguration()
        {

            DataTable dt = GetEmailConfigurationValues();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListEmailConfig.Add(new MySAEmailConfig
                {
                    ID = Int32.Parse(dt.Rows[i]["CompanyID"].ToString()),
                    HostName = dt.Rows[i]["HostName"].ToString(),
                    IPPort = Int32.Parse(dt.Rows[i]["IPPort"].ToString()),
                    SenderID = dt.Rows[i]["SenderID"].ToString(),
                    MBSize = dt.Rows[i]["MBSize"].ToString(),
                    MaxNoAttachs = dt.Rows[i]["MaxNoAttachs"].ToString(),
                    MaxSizeAllAttachs = dt.Rows[i]["MaxSizeAllAttachs"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    Protocol = dt.Rows[i]["Protocol"].ToString(),
                    SecurityMode = dt.Rows[i]["SecurityMode"].ToString(),
                });
            }
            return ListEmailConfig;
        }


        public DataTable GetEmailConfigurationValues()
        {
            string _Query = " select Case when IsSMTPS=1 then 'SMTP' ELSE 'SMTPS' END AS Protocol,Case when IsSSLTLS=1 then 'SSL' ELSE 'TLS' END AS SecurityMode, * from SA.CompanyConfig ";
            return GetViewData(_Query, "");
        }

        public List<MySAUOMTypes> GetUOMTypes()
        {

            DataTable dt = GetUOMTypesMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUOMTypes.Add(new MySAUOMTypes
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UOMType = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListUOMTypes;
        }


        public DataTable GetUOMTypesMaster()
        {
            string _Query = " select * from sa.GeneralMaster where Status=1 and SeqNo=3 ";
            return GetViewData(_Query, "");
        }
        #endregion

        #region InstanceProfile
        public List<MyCompany> InsertCompanyMaster(MyCompany Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GetExistingCompany(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListCompany.Add(new MyCompany
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Company Name Already Exists"

                    }); ;
                    return ListCompany;
                }
            }

            if (ChckExist.Rows.Count >= 1)
            {
                if (ChckExist.Rows[0]["CompanyCode"].ToString().ToUpper() == Data.CompanyName.ToUpper() && ChckExist.Rows[0]["CompanyName"].ToString().ToUpper() == Data.CompanyName.ToUpper())
                {
                    ListCompany.Add(new MyCompany
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Company Code/Name Already Exists"
                    });
                    return ListCompany;
                }
                if (ChckExist.Rows[0]["CompanyCode"].ToString().ToUpper() == Data.CompanyCode.ToUpper())
                {
                    ListCompany.Add(new MyCompany
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Company Code Already Exists"
                    });
                    return ListCompany;
                }
                if (ChckExist.Rows[0]["CompanyName"].ToString().ToUpper() == Data.CompanyName.ToUpper())
                {
                    ListCompany.Add(new MyCompany
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Company Name Already Exists"
                    });
                    return ListCompany;
                }

            }


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

                    Cmd.CommandText = " IF((select count(*) from sa.CompanyDetails where ID=@ID)<=0) " +
                                     " BEGIN " +
                          " INSERT INTO  sa.CompanyDetails(CompanyName,CompanyCode,CountryID,CityID,Address,LogoFileName,ZipCode,POBox,Telephone1,Telephone2,EmailID,URL,ContactName,Designation,ContactEmailID,MobileNo) " +
                                     " values (@CompanyName,@CompanyCode,@CountryID,@CityID,@Address,@LogoFileName,@ZipCode,@POBox,@Telephone1,@Telephone2,@EmailID,@URL,@ContactName,@Designation,@ContactEmailID,@MobileNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE sa.CompanyDetails SET CompanyName=@CompanyName,CompanyCode=@CompanyCode,CountryID=@CountryID,CityID=@CityID,Address=@Address,LogoFileName=@LogoFileName,ZipCode=@ZipCode,POBox=@POBox,Telephone1=@Telephone1,Telephone2=@Telephone2," +
                                     " EmailID=@EmailID,URL=@URL,ContactName=@ContactName,Designation=@Designation,ContactEmailID=@ContactEmailID,MobileNo=@MobileNo where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyName", Data.CompanyName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyCode", Data.CompanyCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LogoFileName", Data.LogoFileName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ZipCode", Data.ZipCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POBox", Data.POBox));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Telephone1", Data.TelePhone1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Telephone2", Data.TelePhone2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.EmailID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@URL", Data.URL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContactName", Data.ContactName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Designation", Data.Designation));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContactEmailID", Data.ContactEmailID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MobileNo", Data.MobileNo));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('SA.CompanyDetails')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListCompany.Add(new MyCompany
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCompany;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCompany.Add(new MyCompany
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListCompany;
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
        public DataTable GetExistingCompany(MyCompany Data)
        {
            string _Query = "Select * from SA.CompanyDetails where (ID not in(" + Data.ID + ")) and (CompanyName ='" + Data.CompanyName + "' AND CompanyCode='" + Data.CompanyCode + "')";
            return GetViewData(_Query, "");
        }

        public List<MyCompany> GetCompanyView(MyCompany Data)
        {
            DataTable dt = GetAgencyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCompany.Add(new MyCompany
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyCode = dt.Rows[i]["CompanyCode"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),

                });
            }
            return ListCompany;
        }
        public DataTable GetAgencyValues(MyCompany Data)
        {
            string strWhere = "";

            string _Query = "select cm.id,cm.CompanyCode,cm.CompanyName , " +
                "  (select top 1 CountryName from SA.CountryMaster where ID =cm.CountryID) as Country,Address," +
                "  (select top 1 cityname from SA.CityMaster where ID =cm.CityID) as City " +
                   " from sa.CompanyDetails cm ";



            if (Data.CompanyCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where cm.CompanyCode like '%" + Data.CompanyCode + "%'";
                else
                    strWhere += " and cm.CompanyCode like '%" + Data.CompanyCode + "%'";

            if (Data.CompanyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where cm.CompanyName like '%" + Data.CompanyName + "%'";
                else
                    strWhere += " and cm.CompanyName like '%" + Data.CompanyName + "%'";

            if (strWhere == "")
                strWhere = _Query + " order by cm.ID desc "; ;

            return GetViewData(strWhere, "");

        }

        public List<MyCompany> GetCompanyEdit(MyCompany Data)
        {
            DataTable dt = GetCompanyEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCompany.Add(new MyCompany
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyCode = dt.Rows[i]["CompanyCode"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    POBox = dt.Rows[i]["POBox"].ToString(),
                    ZipCode = dt.Rows[i]["ZipCode"].ToString(),
                    TelePhone1 = dt.Rows[i]["TelePhone1"].ToString(),
                    TelePhone2 = dt.Rows[i]["TelePhone2"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    ContactEmailID = dt.Rows[i]["ContactEmailID"].ToString(),
                    ContactName = dt.Rows[i]["ContactName"].ToString(),
                    URL = dt.Rows[i]["URL"].ToString(),
                    MobileNo = dt.Rows[i]["MobileNo"].ToString(),
                    Designation = dt.Rows[i]["Designation"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    LogoFileName = dt.Rows[i]["LogoFileName"].ToString(),
                });
            }
            return ListCompany;
        }
        public DataTable GetCompanyEditValues(MyCompany Data)
        {

            string _Query = "select * from sa.CompanyDetails where ID =" + Data.ID;
            return GetViewData(_Query, "");

        }

        public List<MyConfig> InsertSaveConfig(MyConfig Data)
        {


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

                    Cmd.CommandText = " IF((select count(*) from SA.CompanyConfig where CompanyID=@CompanyID)<=0) " +
                                     " BEGIN " +
                          " INSERT INTO  sa.CompanyConfig(CompanyID,HostName,IPPort,IsSMTPS,IsSSLTLS,SenderID,MBSize,MaxNoAttachs,MaxSizeAllAttachs,Password) " +
                                     " values (@CompanyID,@HostName,@IPPort,@IsSMTPS,@IsSSLTLS,@SenderID,@MBSize,@MaxNoAttachs,@MaxSizeAllAttachs,@Password) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE sa.CompanyConfig SET CompanyID=@CompanyID,HostName=@HostName,IPPort=@IPPort,IsSMTPS=@IsSMTPS,IsSSLTLS=@IsSSLTLS,SenderID=@SenderID,MBSize=@MBSize,MaxNoAttachs=@MaxNoAttachs," +
                                     " MaxSizeAllAttachs=@MaxSizeAllAttachs,Password=@Password where CompanyID=@CompanyID ";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CompanyID", Data.CompanyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HostName", Data.HostName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IPPort", Data.IPPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSMTPS", Data.IsSMTPS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsSSLTLS", Data.IsSSLTLS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SenderID", Data.SenderID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MBSize", Data.MBSize));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MaxNoAttachs", Data.MaxNoAttachs));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MaxSizeAllAttachs", Data.MaxSizeAllAttachs));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('sa.CompanyConfig')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    return ListConfig;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListConfig.Add(new MyConfig
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListConfig;
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


        public List<MyConfig> GetConfigEdit(MyConfig Data)
        {
            DataTable dt = GetConfigEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListConfig.Add(new MyConfig
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyID = Int32.Parse(dt.Rows[i]["CompanyID"].ToString()),
                    HostName = dt.Rows[i]["HostName"].ToString(),
                    IPPort = Int32.Parse(dt.Rows[i]["IPPort"].ToString()),
                    SenderID = dt.Rows[i]["SenderID"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    IsSMTPS = Int32.Parse(dt.Rows[i]["IsSMTPS"].ToString()),
                    IsSSLTLS = Int32.Parse(dt.Rows[i]["IsSSLTLS"].ToString()),
                    MaxSizeAllAttachs = dt.Rows[i]["MaxSizeAllAttachs"].ToString(),
                    MBSize = dt.Rows[i]["MBSize"].ToString(),
                    MaxNoAttachs = dt.Rows[i]["MaxNoAttachs"].ToString(),
                });
            }
            return ListConfig;
        }
        public DataTable GetConfigEditValues(MyConfig Data)
        {

            string _Query = "select * from SA.CompanyConfig where CompanyID =" + Data.CompanyID;
            return GetViewData(_Query, "");

        }
        #endregion
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyCustomsCode
    {

    }

    public class MyAgentCode
    {
        public int ID = 0;
        public int PortName = 0;
        public string LineCode = "";
        public string AgentCode = "";
        public string SOCode = "";
        public string PanNo = "";
        public string AgentItems = "";
    }
    public class MyPortCode
    {
        public int ID = 0;
        public int PortID = 0;
        public string UNCode = "";
        public string FloppyCode = "";
        public string PortItems = "";
    }

    public class MyCarrierCode
    {
        public int ID = 0;
        public int CarrierID = 0;
        public string Code = "";
        public string BondNo = "";
        public string PanNo = "";
        public string CarrierItems = "";
    }

    public class MyTerminalCode
    {
        public int ID = 0;
        public int TerminalID = 0;
        public int PortID = 0;
        public string MappingCode = "";
        public string TerminalItems = "";
    }

    public class MYCFS
    {
        public int ID = 0;
        public string CFSName = "";
        public int CFSID = 0;
        public string CFSCode = "";
        public string BondNo = "";
        public string IALCode = "";
        public string CFSItems = "";
    }

    public class MYPackageCode
    {
        public int ID = 0;
        public int LocID = 0;
        public string GeoLocation = "";
        public string PackDescription = "";
        public string GenCode = "";
        public string MappingCode = "";
        public string PackageItems = "";
    }

    public class MYTransporter
    {
        public int ID = 0;
        public int TransporterID = 0;
        public string TransporterName = "";
        public string Code = "";
        public string BondNo = "";
        public string PanNo = "";
        public string TransporterItems = "";
    }
    public class MYISOCode
    {
        public int ID = 0;
        public int EqTypeID = 0;
        public string EqType = "";
        public string ISOCode = "";
        public string ISOItems = "";
    }
}

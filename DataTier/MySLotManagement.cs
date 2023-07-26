using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{

    public class MySLotManagement
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _VesselName = string.Empty;
        public string VesselName { get { return _VesselName; } set { _VesselName = value; } }

        private String _Voyage = string.Empty;
        public string Voyage { get { return _Voyage; } set { _Voyage = value; } }

        private string _POD = string.Empty;
        public string POD { get { return _POD; } set { _POD = value; } }

        private string _ETA = string.Empty;
        public string ETA { get { return _ETA; } set { _ETA = value; } }

        private string _ETAfrom = string.Empty;
        public string ETAfrom { get { return _ETAfrom; } set { _ETAfrom = value; } }

        private string _ETAto = string.Empty;
        public string ETAto { get { return _ETAto; } set { _ETAto = value; } }

        private string _ETD = string.Empty;
        public string ETD { get { return _ETD; } set { _ETD = value; } }

        private string _ETDfrom = string.Empty;
        public string ETDfrom { get { return _ETDfrom; } set { _ETDfrom = value; } }

        private string _ETDto = string.Empty;
        public string ETDto { get { return _ETDto; } set { _ETDto = value; } }

        private string _Sailing = string.Empty;
        public string Sailing { get { return _Sailing; } set { _Sailing = value; } }

        private string _Teus = string.Empty;
        public string Teus { get { return _Teus; } set { _Teus = value; } }

        private string _VOA = string.Empty;
        public string VOA { get { return _VOA; } set { _VOA = value; } }

        private string _MT = string.Empty;
        public string MT { get { return _MT; } set { _MT = value; } }


        private string _Booking = string.Empty;
        public string Booking { get { return _Booking; } set { _Booking = value; } }

        private string _Pickup = string.Empty;
        public string Pickup { get { return _Pickup; } set { _Pickup = value; } }


        private string _GateIn = string.Empty;
        public string GateIn { get { return _GateIn; } set { _GateIn = value; } }


        private string _LoadOut = string.Empty;
        public string LoadOut { get { return _LoadOut; } set { _LoadOut = value; } }
        public int VoyageID;
        public int PODID;
        public int VOAID;
        public int SID;
        public string Notes;
        public string AlertMegId = "";
        public string AlertMessage = "";
        public string Attachfile = "";
        public string FileName = "";

    }
    public class MyVOA
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _VOA = string.Empty;
        public string VOA { get { return _VOA; } set { _VOA = value; } }

    }
    public class MySlotAttach
    {


        public int Chkbox;
        public string Itemsv1;
        public string Itemsv2;

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _filenam = string.Empty;
        public string filenam { get { return _filenam; } set { _filenam = value; } }
    }

    public class MySlotRecords

    {


        public string AlertMegId = "";
        public string AlertMessage = "";
        public string Items = "";

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _VesselName = string.Empty;
        public string VesselName { get { return _VesselName; } set { _VesselName = value; } }

        private String _Voyage = string.Empty;
        public string Voyage { get { return _Voyage; } set { _Voyage = value; } }

        private string _VOA = string.Empty;
        public string VOA { get { return _VOA; } set { _VOA = value; } }

        private string _Tues = string.Empty;
        public string Tues { get { return _Tues; } set { _Tues = value; } }

        private string _MT = string.Empty;
        public string MT { get { return _MT; } set { _MT = value; } }

        private String _Notes = string.Empty;
        public string Notes { get { return _Notes; } set { Notes = value; } }

        private String _Filenam = string.Empty;
        public string Filenam { get { return _Filenam; } set { Filenam = value; } }
        public int VesID;
        public int VoyageID;
    }
    public class LoadSlotInit
    {
        public int ID = 0;
        public string VesselName = "";
        public string Voyage = "";
        public string VOA = "";
        public string Tues = "";
        public string MT = "";
        public string Notes = "";
        public string Filenam = "";
        public string Items = "";
        public string AlertMessage = "";
        public string AlertMegId = "";
    }
}

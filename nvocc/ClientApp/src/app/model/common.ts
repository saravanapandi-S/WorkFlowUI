export class Country {
    ID = 0;
    CountryCode = '';
    CountryName = '';
    Status = '';
   
}

export class State {
    ID = 0;
    StateName = '';

}
export class City {
    ID = 0;
    CityCode = '';
    CountryCode = '';
    CityName = '';
    Status = '';
    StateName = '';
    CountryID = 0;
    StateID = 0;
}
export class Port {

    ID = 0;
    PortName = '';
    PortCode = '';
    CountryCode = '';
    MainPort = '';
    SeaPort = '';
    ICDPort = '';
    AirPort = '';
    Status = '';
    CountryID = 0;
    OffLocID = 0;
    IsSeaPort = 0;
    IsICDPort = 0;
    IsAirPort = 0;
}
export class Cargo {
    ID = 0;
    UOMType = 0;
    PkgCode = '';
    PkgDescription = '';
    StatusResult = '';
    Status = '';

}

export class UOMMaster {
    ID = 0;
    //UOMType = 0;
    UOMCode = '';
    UOMDesc = '';
    StatusResult = '';
    Status = '';
    UOMType = '';

}

export class StateMaster {
    ID = 0;
    Country = '';
    StateCode = '';
    StateName = '';
    StatusResult = '';
    Status = 0;
    CountryID = 0;

}

export class Depot {
    ID = 0;
    DepName = '';
    DepCountry = 0;
    DepCity = 0;
    DepCountryName = '';
    DepCityName = '';
    StatusName = '';
    Status = 0;
    CountryName = '';
    CountryCode = 0;
    CityName = '';
    CityCode = 0;
    PortName = '';
    PID = 0;
    PortID = 0;
    Port = '';
}
export class MyAgency {
    ID: 0;
    GeoLocation: '';
}
export class Login {
    ID: 0;
    Username: '';
    Password: '';
    AgencyName: '';
    AgencyID: 0;
    GeoLocationID: 0;
    GeoLocation: '';
    CountryID: '';
    Country: '';
    DocumentSuffix: '';
    SessionFinYear: '';
    SessionKey: '';
    Sessioniv: '';
    TaxGST: '';
    Token: '';

}

export class Terminal {
    ID = 0;
    TerminalCode = '';
    TerminalName = '';
    PortID = '';
    Status = '';
    PortName = '';
    StatusName = '';
}

export class Commodity {
    ID = 0;
    CommodityUnCode = '';
    CommodityName = '';
    HSCode = '';
    DangerousFlag = '';
    CommodityType =0;
    CommodityTypeID = 0;
    Status = 0;
    Remarks = '';
}

export class LinerName {
    ID = 0;
    CustomerName = '';
}

export class GeneralMaster {
    ID = 0;
    GeneralName = '';
    Program = '';
}
export class DynamicGrid {
    PortID = 0;
    PID = 0;
    Port = '';
}

export class NotesGrid {
    ID = 0;
/*    LocAddress = '';*/
    Notes = '';
}

export class DamageMaster {
    ID = 0;
    DamageCode = '';
    DamageDescription = '';
    StatusResult = '';
    Status = '';

}

export class RepairMaster {
    ID = 0;
    RepairCode = '';
    RepairDescription = '';
    StatusResult = '';
    Status = '';

}

export class ContLocationMaster {
    ID = 0;
    LocationCode = '';
    Description = '';
    StatusResult = '';
    Status = '';

}

export class Assembly {
    ID = 0;
    GeneralName = '';
    Assembly = '';
}
export class ComponentMaster {
    ID = 0;
    ComponentCode = '';
    ComponentDescription = '';
    StatusResult = '';
    Status = '';
    AssemblyID = 0;
    Assembly = '';
    GeneralName = '';

}
export class Notes {
    ID = 0;
    Notes = '';
    LocAddress = '';
    Itemsv = '';
    GeneralName = '';
    DocID = '';
}
export class ContainerType {
    ID = 0;
    Type = '';
    EQTypeID = 0;
    Size = '';
    SizeID = 0;
    groupID = 0;
    status = 0;
    ISOCode = '';
    Height = '';
    TEUS = '';
    SeqNo = '';
    IsSealReqd = '';
    IntBasic = '';
    GeneralName = '';
    Width = '';
    Length = '';
    TareWeight = '';
    MaxPayload = '';
    Remarks = '';
    CntrTypeDesc = '';
}

export class CTTypes {
    ID = 0;
    GeneralName = '';
}

export class CTSizes {
    ID = 0;
    GeneralName = '';
}
export class CTGroups {
    ID = 0;
    GeneralName = '';
}
export class UOMtypes {
    ID = 0;
    GeneralName = '';
}

export class ChargeTBMaster {
    ID = 0;
    ChargeCode = '';
}
export class BasicMaster {
    ID: string;
    name: string;
}
export class CurrencyMaster {

    ID: 0;
    Currency: "";
}
export class UOMValues {
    ID = 0;
    UOMCode = '';
}
export class Vessel {

    ID: 0;
    VesselCode: "";
    VesselCallSign: "";
    VesselName: "";
    IMONumber: "";
    MMSI: "";
    Flag: "";
    VesselID: "";
    VesselOwner: "";
    CurrentDate: "";
    Status: 0;
    StatusResult: "";
}
export class ServiceSetup {

    ID: 0;
    OfficeLocID: 0;
    SlotRefCode: "";
    ServiceName: "";
    DtEffective: "";
    UserID: 0;
    GeoLocID: 0;
    OID: 0;
    OperatorID: 0;
    SlotRefID: 0;
    Operator: "";
    SlotRef: "";
    ItemsRoute: "";
    ItemsOpr: "";
    RID: 0;
    PortID: 0;
    TTHH: 0;
    TTMM: 0;
    DayWindowCommence: 0;
    WComHH: 0;
    WComMM: 0;
    DayWindowClose: 0;
    WCloseMM: 0;
    WCloseHH: 0;
    DayPortStay: 0;
    PortStayHH: 0;
    PortStayMM: 0;
    ServiceID: 0;
    ETA: "";
    GeoLoc: "";
    StatusID: 0;
    AlertMessage: "";
    OffLocID: 0;

}
export class DynamicGridService {

    ID: 0;
    PortID: 0;
    HH: 0;
    MM: 0;
}
export class DynamicGridOperator {
    OID: 0;
    OperatorID: 0;
    Operator: "";
    SlotRefID: 0;
    SlotRef: "";
}
export class SlotOperator {
    ID: 0;
    CustomerName: "";
}

export class VoyageDetails {
    RID: 0;
    ID: 0;
    PID: 0;
    VoyDtID: 0;
    VesID: 0;
    VoyID: 0;
    VoyageNo: '';
    Name: '';
    RotationNo: '';
    VesOperator: '';
    ServiceID: 0;
    VesselID: 0;
    VesselName: '';
    Service: '';
    VoyNo: '';
    ItemsSchedule: '';
    Itemsv: '';
}
export class DynamicGridSchedule {
    RID: 0;
    PortID: 0;
    ImportVoyageCd: '';
    ExportVoyageCd: '';
    TerminalID: 0;
    ArrivalETA: '';
    TmETA: '';
    ETAMM: '';
    DepETD: '';
    TmETD: '';
    ETDMM: '';
    ATA: '';
    TmATA: '';
    ATAMM: '';
    ATD: '';
    TmATD: '';
    ATDMM: '';

}
export class DynamicGridManifest {
    MID: 0;
    EGMNo: '';
    EGMDate: '';
    IGMNo: '';
    IGMDate: '';
    
}
export class DynamicGridNotes {
    NID: 0;
    VoyageTypeID: 0;
    VoyageType: '';
    Notes: '';
}
export class DynamicPDF1 {
    aclFilename = '';
}
export class drodownVeslVoyage {
    ID = 0;
    VesselName = "";
}
//shipmentLocations udhaya


export class shipmentLocations {
    ID = 0;
    CityID = 0;
    CountryID = 0;
    status = 0;
    LocationCode = "";
    Location = "";
    AlertMessage = "";
    AlertMegId = 0;

}

export class Hazardous {
    ID = 0;
    Status = 0;
    ClassDesc = "";
    DivisionDesc = "";
    AlertMessage = "";
    AlertMegId = 0;
}

export class UOMConversions {
    ID = 0;
    Status = 0;
    UOMFrom = "";
    UOMTo = "";
    Factor = "";
    ActionResult = "";
    AlertMessage = "";
    Action = 0;
    AlertMegId = 0;
}

export class CurrencyName {
    ID = 0;   
    CurrencyCode = "";
    CurrencyName = "";
    Symbol = "";
    Factor = "";
    StatusResult = "";
    AlertMessage = "";
    Status = 0;
    CountryID = 0;
    AlertMegId =0;
}



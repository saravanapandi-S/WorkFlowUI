export class BOL {
    ID = 0;
    MainID = 0;
    ShipperName = "";
    ShipperAddress = "";
    Consignee = "";
    ConsigneeAddress = "";
    Notify = "";
    NotifyAddress = "";
    NotifyAlso = "";
    NotifyAlsoAddress = "";
    SeqNo = "";
    BLID = 0;
    BkgID = 0;
    ShipperType = "";
    ConsigneeType = "";
    NotifyType = "";
    NotifyAlsoType = "";
    BLNumberID = 0;
    Origin = "";
    LoadPort = "";
    Discharge = "";
    Destination = "";   
    BLTypeID = 0;
    OriginID = 0;
    LoadPortID = 0;
    DischargeID = 0;
    DestinationID = 0;
    DeliveryAgent = 0;
    DeliveryAgentAddress = "";
    MarksNos = "";
    Packages = "";
    Description = "";
    Weight = "";
    FreightTermsID = "";
    FreightPayableAt = "";
    NoOfOriginal = "";
    RFLBol = 0;
    BLIssueDate = "";
    PlaceOfIssue = "";
    ShipOnboardDate = "";
    PrintWt = 0;
    PrintNetWt = 0;
    NotPrint = 0;
    AttachShippingBill = "";
    AttachCustomerApproval = "";
    BLStatus = 0;
    ChkBLID = 0;
    BLNumber = "";
    PaymentTermsID = 0;
    ItemsBLNotes = "";
    BLTempID = 0;
    TemplateName = "";
    PartyID = 0;
    PartyName = "";
    SOBDate = "";
    

}
export class BLNo {
    ID = 0;
    BLNumber = "";
    BkgId = "";
    MainID = 0;

    
}
export class BLTypes {
    ID = 0;
    BLType = "";
}
export class BLContainer {
    ID = 0;
   
    //BLID = "";
    //BkgID = "";
    ContainerNo = "";
    ContrType = "";
    AgentSealNo = "";
    CustomerSealNo = "";
    GrsWt = "";
    NetWt = "";
    NoOfPkgs = "";
    Volume = ""

}
export class DynamicGridAttach {
    AID = 0;
    AttachName = "";
    AttachFile = "";
    AttachCount = 0;
}
export class PortVessel {
    ID = 0;
    PortName = "";
}

export class DynamicNavioPDF {
    navioFilename = '';
    id = '';
    printvalue = '';
}

export class BLCargoDtls {
    ID = 0;
    ContainerNo = "";
    ContrType = "";
    AgentSealNo = "";
    CustomerSealNo = "";
    GrsWt = "";
    NetWt = "";
    NoOfPkgs = "";
    Volume = "";
    Itemsv1 = "";
}

export class BLNotes {
    ID = 0;
    NID = 0;
    Notes = "";
    IsTrue = 0;
}

export class dynamicgridSurrenderAttach {
    ID = 0;
    AttachSurrenderFile = "";
    BLNumber = "";
    
    RadBLID = 0;
    SurrenderDate = "";
    IssuedBy = "";
    Remarks = "";
}



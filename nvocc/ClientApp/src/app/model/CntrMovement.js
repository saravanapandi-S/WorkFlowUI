"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CntrMovementDynamicGrid = exports.CntrMovementMaster = void 0;
var CntrMovementMaster = /** @class */ (function () {
    function CntrMovementMaster() {
        this.ID = 0;
        this.StatusCode = 0;
        this.StorageCode = 0;
        this.BookingNo = "";
        this.ContainerNos = "";
        this.OfficeLocation = 0;
        this.MovementTypeID = 0;
        this.CurrentLocationID = 0;
        this.NewStorageLocationID = 0;
        this.BookingID = 0;
        this.Message = '';
    }
    return CntrMovementMaster;
}());
exports.CntrMovementMaster = CntrMovementMaster;
var CntrMovementDynamicGrid = /** @class */ (function () {
    function CntrMovementDynamicGrid() {
        this.ID = 0;
        this.CntrNo = "";
        this.StatusCode = "";
        this.DtMovement = "";
        this.Location = "";
        this.Status = "";
        this.StatuID = "";
    }
    return CntrMovementDynamicGrid;
}());
exports.CntrMovementDynamicGrid = CntrMovementDynamicGrid;
//# sourceMappingURL=CntrMovement.js.map
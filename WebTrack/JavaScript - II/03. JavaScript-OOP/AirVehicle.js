AirVehicle = function (nozzlesPower) {
    var propulsionType = new Nozzels(100);
    Vehicle.call(this, propulsionType);
}

AirVehicle.inherit(Vehicle);

AirVehicle.prototype.switchOnNozzlesAfterBurner = function () {
    this.propulsionDevice.isAfterBurnOn = true;
}
AirVehicle.prototype.switchOffNozzlesAfterBurner = function () {
    this.propulsionDevice.isAfterBurnOn = false;
}



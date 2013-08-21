WaterVehicle = function (numberOfPropellers, numberOfFinsPerPropeller) {
    var propulsionType = new Propellers(numberOfPropellers, numberOfFinsPerPropeller);
    Vehicle.call(this, propulsionType);
}

WaterVehicle.inherit(Vehicle);

WaterVehicle.prototype.goForward = function () {
    this.propulsionDevice.isDirectionClockwise = true;
}
WaterVehicle.prototype.goBackwards = function () {
    this.propulsionDevice.isDirectionClockwise = false;
}


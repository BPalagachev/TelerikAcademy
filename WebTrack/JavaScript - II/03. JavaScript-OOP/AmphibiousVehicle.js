AmphibiousVehicle = function (numberOfPropellers, numberOfFinsPerPropeller, wheelRadius) {
    this.onWaterPropulsionType = new Propellers(numberOfPropellers, numberOfFinsPerPropeller);
    this.onLandPropulsionType = new Wheels(wheelRadius);

    this.isOnLand = true;
    Vehicle.call(this, this.onLandPropulsionType);
}

AmphibiousVehicle.inherit(Vehicle);

AmphibiousVehicle.prototype.switchToLandMode = function () {
    this.isOnLand = true;
    this.propulsionDevice = this.onLandPropulsionType;
}
AmphibiousVehicle.prototype.switchToWaterMode = function () {
    this.isOnLand = false;
    this.propulsionDevice = this.onWaterPropulsionType;
}
AmphibiousVehicle.prototype.goForwardOnWater = function () {
    this.propulsionDevice.isDirectionClockwise = true;
}
AmphibiousVehicle.prototype.goBackwardsOnWater = function () {
    this.propulsionDevice.isDirectionClockwise = false;
}
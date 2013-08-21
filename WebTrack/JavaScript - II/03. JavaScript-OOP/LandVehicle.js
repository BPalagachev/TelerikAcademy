LandVehicle = function (wheelRadius) {
    var propulsionType = new Wheels(wheelRadius); 
    Vehicle.call(this, propulsionType);
}

LandVehicle.inherit(Vehicle);
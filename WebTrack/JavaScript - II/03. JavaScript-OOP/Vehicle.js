Vehicle = function (propulsionDevice) {
    var initialSpeed = 0;

    this.propulsionDevice = propulsionDevice;
    this.currentSpeed = initialSpeed;
}
Vehicle.prototype = {
    accelerate: function () {
        this.currentSpeed += this.propulsionDevice.getAcceleration();
    }
}


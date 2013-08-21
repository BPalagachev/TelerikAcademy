Wheels = function (wheelRadius) {
    PropulsionDevice.call(this, 0);
    this.radius = wheelRadius;
}

Wheels.inherit(PropulsionDevice);

Wheels.prototype = {
    getAcceleration: function () {
        var perimeter = this.radius * Math.PI * 2;
        return perimeter;
    }
}
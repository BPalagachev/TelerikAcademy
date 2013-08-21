Nozzels = function (nozzelsPower) {
    PropulsionDevice.call(this, 1);
    this.power = nozzelsPower;
    this.isAfterBurnOn = false;
}

Nozzels.inherit(PropulsionDevice);

Nozzels.prototype = {
    getAcceleration: function () {
        var acceleration = this.power;
        if (this.isAfterBurnOn) {
            acceleration *= 2;
        }
        return acceleration;
    }
}

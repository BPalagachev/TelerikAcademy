Propellers = function (numberOfPropellers, numberOfFinsPerPropeller) {
    PropulsionDevice.call(this, numberOfPropellers);
    this.numberOfFinsPerPropeller = numberOfFinsPerPropeller;
    this.isDirectionClockwise = true; // clockwise - forward, counter clockwise - backwards
}

Propellers.inherit(PropulsionDevice);

Propellers.prototype = {
    getAcceleration: function () {
        var acceleration = this.numberOfPropulsionUnits * this.numberOfFinsPerPropeller;
        if (!this.isDirectionClockwise) {
            acceleration *= -1;
        }
        return acceleration;
    }
}
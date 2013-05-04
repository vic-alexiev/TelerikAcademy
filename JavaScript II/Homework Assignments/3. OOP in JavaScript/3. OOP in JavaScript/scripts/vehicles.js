var vehicles = (function () {

    // enumerations
    var AfterburnerState = Object.freeze({
        "ACTIVATED": 1,
        "DEACTIVATED": 2
    });

    var RotationDirection = Object.freeze({
        "CLOCKWISE": 1,
        "COUNTERCLOCKWISE": 2
    });

    var AmphibianMode = Object.freeze({
        "LAND": 1,
        "WATER": 2
    });

    Function.prototype.inherits = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = this;
    };

    Function.prototype.extends = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }

        return this;
    }

    // Represents a propulsion unit.
    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Function not implemented in 'PropulsionUnit' prototype.");
    }

    // Wheel inherits from PropulsionUnit.
    function Wheel(radius) {
        this.radius = radius;
    }

    Wheel.inherits(PropulsionUnit);

    Wheel.prototype.getAcceleration = function () {
        return parseInt(2 * Math.PI * this.radius);
    }

    // PropellingNozzle inherits from PropulsionUnit.
    function PropellingNozzle(power, afterburnerState) {
        this.power = power;
        this.afterburnerState = afterburnerState;
    }

    PropellingNozzle.inherits(PropulsionUnit);

    PropellingNozzle.prototype.getAcceleration = function () {
        if (this.afterburnerState === AfterburnerState.ACTIVATED) {
            return 2 * this.power;
        } else {
            return this.power;
        }
    }

    // Propeller inherits from PropulsionUnit.
    function Propeller(bladesNumber, rotationDirection) {
        this.bladesNumber = bladesNumber;
        this.rotationDirection = rotationDirection;
    }

    Propeller.inherits(PropulsionUnit);

    Propeller.prototype.getAcceleration = function () {
        if (this.rotationDirection === RotationDirection.CLOCKWISE) {
            return this.bladesNumber;
        } else {
            return -this.bladesNumber;
        }
    }

    // Represents a vehicle.
    function Vehicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    // LandVehicle inherits from Vehicle.
    function LandVehicle(speed, wheels) {
        Vehicle.apply(this, arguments);
    }

    LandVehicle.inherits(Vehicle);

    // Aircraft inherits from Vehicle.
    function Aircraft(speed, propellingNozzles) {
        Vehicle.apply(this, arguments);
    }

    Aircraft.inherits(Vehicle);

    Aircraft.prototype.switchAfterburners = function (afterburnerState) {
        for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                this.propulsionUnits[i].afterburnerState = afterburnerState;
            }
        }
    }

    // Watercraft inherits from Vehicle.
    function Watercraft(speed, propellers) {
        Vehicle.apply(this, arguments);
    }

    Watercraft.inherits(Vehicle);

    Watercraft.prototype.setPropellersRotationDirection = function (rotationDirection) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].rotationDirection = rotationDirection;
            }
        }
    }

    // Amphibian inherits from Vehicle and extends Watercraft.
    function Amphibian(speed, propellers, wheels, mode) {

        var propulsionUnits = [];
        for (var i = 0; i < propellers.length; i++) {
            propulsionUnits.push(propellers[i]);
        }

        for (var j = 0; j < wheels.length; j++) {
            propulsionUnits.push(wheels[i]);
        }

        Vehicle.call(this, speed, propulsionUnits);
        this.mode = mode;
    }

    Amphibian.inherits(Vehicle);
    Amphibian.extends(Watercraft, "setPropellersRotationDirection");

    Amphibian.prototype.accelerate = function () {
        if (this.mode === AmphibianMode.LAND) {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    }

    return {
        AfterburnerState: AfterburnerState,
        RotationDirection: RotationDirection,
        AmphibianMode: AmphibianMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        Aircraft: Aircraft,
        Watercraft: Watercraft,
        Amphibian: Amphibian
    };
})();
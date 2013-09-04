/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

var PrimeNumbersCalculator = WinJS.Class.define(function () {
    this.numberOfWorkers = 3;
    this.freeWorkers = this._initializeWebWorkers(this.numberOfWorkers);
},
{
    _initializeWebWorkers: function initializeWebWorkers(numberOfWebWorkers) {
        var webWorkers = [];

        for (var i = 0; i < numberOfWebWorkers; i++) {
            var newWorker = new Worker("/js/primesWebWorker.js");
            webWorkers.push(newWorker);
        }

        return webWorkers;
    },
    _isPrime: function (number) {
        for (var i = 2; i < number; i++) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    },
    _calculatePrimesInInterval: function (fromNumber, toNumber) {
        var primesList = [];
        var isPrime = true;

        for (var num = fromNumber; num <= toNumber; num++) {

            for (var i = 2; i < num; i++) {
                if (num % i == 0) {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) {
                primesList.push(num);
            }
            isPrime = true;
        }

        return primesList;
    },
    _calculateFirstPrimeNumbers: function (numberOfPrimersToCalculate) {
        var primesList = [];
        var isPrime = true;

        for (var num = 0; primesList.length < numberOfPrimersToCalculate; num++) {
            for (var i = 2; i < num; i++) {
                if (num % i == 0) {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) {
                primesList.push(num);
            }

            isPrime = true;
        }

        return primesList;
    },
    calculatePrimersInIntervalAsync: function (fromNumber, toNumber) {
        var self = this;
        var functionArguments = [fromNumber, toNumber];
        var argumentsNames = ["fromNumber", "toNumber"];
        // extract the body of a function you want to execute in separate thread in order it can be recontructed
        var functionStr = self._calculatePrimesInInterval.toString();
        var index = functionStr.indexOf('{');
        var functionBody = functionStr.substring(index);

        var promise = new WinJS.Promise(function (success, error) {
            var isWorkersAvaiable = self.freeWorkers.length > 0;

            if (isWorkersAvaiable) {
                var worker = self.freeWorkers.pop();
                var result;
                worker.onmessage = function (event) {
                    result = event.data;
                    self.freeWorkers.push(worker);
                    success(result);
                };

                worker.postMessage({
                    functionBody: functionBody,
                    parameters: functionArguments,
                    parameterNames: argumentsNames
                });
            }
            else {
                error("You can only have up to " + self.numberOfWorkers + " running calculations at a time");
            }
        });

        return promise;
    },
    calculateFirstPrimeNumbersAsync: function (number) {
        var self = this;
        var functionArguments = [number];
        var argumentsNames = ["numberOfPrimersToCalculate"];
        // extract the body of a function you want to execute in separate thread in order it can be recontructed
        var functionStr = self._calculateFirstPrimeNumbers.toString();
        var index = functionStr.indexOf('{');
        var functionBody = functionStr.substring(index);

        var promise = new WinJS.Promise(function (seccess, error) {
            var isWorkerAvaiable = self.freeWorkers.length > 0;
            if (isWorkerAvaiable) {
                var worker = self.freeWorkers.pop();
                var result;
                worker.onmessage = function (event) {
                    result = event.data;
                    self.freeWorkers.push(worker);
                    seccess(result);
                }

                worker.postMessage({
                    functionBody: functionBody,
                    parameters: functionArguments,
                    parameterNames: argumentsNames
                });
            }
            else {
                error("You can only have up to " + self.numberOfWorkers + " running calculations at a time");
            }

        });

        return promise;
    },
    calculatePrimesUpToNumberAsync: function (number) {
        return this.calculatePrimersInIntervalAsync(0, number);
    }
},
{
});
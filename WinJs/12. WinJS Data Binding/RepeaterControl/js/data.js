(function () {
    var computer = {
        name: "",
        imageUrl: "",
        price: 0,
        rating: 3,
        processor: {
            modelName: "",
            frequencyGHz: 0
        }
    }

    var ObservableComputer = WinJS.Binding.define(computer);

    WinJS.Namespace.define("Data", {
        getComputer: function (name, imageUrl, price, rating, processorName, processorGHz) {
            return new ObservableComputer({
                name: name,
                imageUrl: imageUrl,
                price: price,
                rating: rating,
                processor: {
                    modelName: processorName,
                    frequencyGHz: processorGHz
                }
            });
        }
    });
}())
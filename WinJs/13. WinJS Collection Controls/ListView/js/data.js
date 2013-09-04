/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
(function () {
    var getComputer = function (name, price, imageUrl, manufacturer, processorName, processorGHz) {
        var newComputer = {
            name: name,
            imageUrl: imageUrl,
            price: price,
            manufacturer: manufacturer,
            processor: {
                modelName: processorName,
                frequencyGHz: processorGHz
            }
        };
        return newComputer;
    }

    var computerList = new WinJS.Binding.List([]);

    computerList.push(getComputer("Dell Studio 1535", 2000, "/images/studio-1535.png", "spiro spirta", "Core i5", 2.0));
    computerList.push(getComputer("HP 650", 1500, "/images/hp-650.jpg", "spiro spirta", "Intel 1000M", 1.8));

    groupedComputers = computerList.createGrouped(getGroupKey, getGroupData, compareGroups);

    WinJS.Namespace.define("Data", {
        computers: computerList,
        groupedComputerList: groupedComputers,
        getComputer: getComputer
    });



    // Sorts the groups
    function compareGroups(leftKey, rightKey) {
        var result = leftKey == rightKey ? 0 : leftKey > rightKey ? 1 : -1;
        return result;
    }

    // Returns the group key that an item belongs to
    function getGroupKey(dataItem) {
        return dataItem.manufacturer
    }

    // Returns the title for a group
    function getGroupData(dataItem) {
        return {
            title: dataItem.manufacturer
        };
    }
}())
/// <reference group="Dedicated Worker" />

onmessage = function (event) {
    var toExecute = new Function(event.data.parameterNames, event.data.functionBody);

    var result = toExecute.apply(null, event.data.parameters);
    postMessage(result);
}

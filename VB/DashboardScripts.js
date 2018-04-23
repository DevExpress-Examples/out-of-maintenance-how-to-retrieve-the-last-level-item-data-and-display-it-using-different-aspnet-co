function GetDashboardItemData(viewer, itemName) {
    var itemData = viewer.GetItemData(itemName),
                axes = [],
                measures = itemData.GetMeasures(),
                rows = [],
                dimensionNames = [],
                measureNames = [];


    $.each(itemData.GetAxisNames(), function (_, name) {
        if (name == "Sparkline") { return true; }
        var axis = itemData.GetAxis(name);
        axes.push(axis)
        $.each(axis.GetDimensions(), function (_, dimension) {
            dimensionNames.push({ Id: dimension.Id, Name: dimension.Name });
        });
    });
    $.each(measures, function (_, measure) {
        measureNames.push({ Id: measure.Id, Name: measure.Name });
    });

    var rowData = [];
    GetDataRecursive(itemData, axes, measures, rows, rowData);
    return { I: 'gridDashboardItem1', D: dimensionNames, M: measureNames, R: rows };


}
function GetDataRecursive(itemData, axes, measures, rows, rowData) {
    var currentAxis = axes[0],
        nestedAxes = axes.slice(0),
        dimensions = currentAxis.GetDimensions();
        nestedAxes.splice(0, 1)
    $.each(currentAxis.GetPoints(), function (_, axisPoint) {
        var currentRowData = rowData.slice(0);
        $.each(dimensions, function (_, dimension) {
            var dimensionValue = axisPoint.GetDimensionValue(dimension.Id);
            currentRowData.push(dimensionValue.GetDisplayText());
        });
        var dataSlice = itemData.GetSlice(axisPoint);
        if (nestedAxes.length == 0) {
            $.each(measures, function (_, measure) {
                var measureValue = dataSlice.GetMeasureValue(measure.Id);
                currentRowData.push(measureValue.GetValue());
            });
            rows.push({ RD: currentRowData });
        }
        else {
            GetDataRecursive(dataSlice, nestedAxes, measures, rows, currentRowData)
        }
    });
}
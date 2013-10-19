function Solve(params) {
    var size = parseInt(params[0]);

    var array = [];
    var nonDecreasingCount = 0;

    for (var index = 0; index < size; index++) {
        array[index] = parseInt(params[index + 1]);

        if (index > 0 && array[index] < array[index - 1]) {
            nonDecreasingCount++;
        }
    }

    return ++nonDecreasingCount;
}
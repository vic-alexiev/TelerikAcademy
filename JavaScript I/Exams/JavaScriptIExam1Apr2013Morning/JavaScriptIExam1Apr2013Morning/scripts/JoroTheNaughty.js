function Solve(args) {
    var limits = args[0].split(" ");

    var rows = parseInt(limits[0]);
    var cols = parseInt(limits[1]);
    var jumps = parseInt(limits[2]);

    var startPosition = args[1].split(" ");
    var startRow = parseInt(startPosition[0]);
    var startCol = parseInt(startPosition[1]);

    var jumpRows = [];
    var jumpCols = [];
    var jump;

    for (var j = 0; j < jumps; j++) {
        jump = args[j + 2].split(" ");
        jumpRows[j] = parseInt(jump[0]);
        jumpCols[j] = parseInt(jump[1]);
    }

    var field = [];
    var visited = [];
    var counter = 1;

    for (var row = 0; row < rows; row++) {
        field[row] = [];
        visited[row] = [];
        for (var col = 0; col < cols; col++) {
            field[row][col] = counter++;
            visited[row][col] = false;
        }
    }

    var currentJumpRow = startRow;
    var currentJumpCol = startCol;
    var points = 0;
    var jumpIndex = 0;
    var jumpsCount = 0;

    while (currentJumpRow >= 0 && currentJumpRow < rows
        && currentJumpCol >= 0 && currentJumpCol < cols) {

        if (visited[currentJumpRow][currentJumpCol]) {
            return "caught " + jumpsCount;
        }

        visited[currentJumpRow][currentJumpCol] = true;
        points += field[currentJumpRow][currentJumpCol];

        currentJumpRow = currentJumpRow + jumpRows[jumpIndex];
        currentJumpCol = currentJumpCol + jumpCols[jumpIndex];

        jumpsCount++;

        jumpIndex++;

        if (jumpIndex == jumps) {
            jumpIndex = 0;
        }
    }

    return "escaped " + points;
}
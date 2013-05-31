internal class Cell
{
    public int Row { get; private set; }
    public int Col { get; private set; }
    public int Generation { get; private set; }

    public Cell(int row, int col, int generation)
    {
        this.Row = row;
        this.Col = col;
        this.Generation = generation;
    }
}

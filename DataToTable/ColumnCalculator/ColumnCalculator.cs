namespace DataToTable;

public class ColumnCalculator<TEntity> : IColumnCalculator<TEntity>
{
    public ColumnData CalculateColumn(
        string columnName
        , List<int> rowLengths)
    {
        var headerSize = columnName.Length;
        var colSize = rowLengths.Max();
        int leftFill;
        int rightFill;
        if (colSize < headerSize)
        {
            leftFill = 0;
            rightFill = headerSize - colSize;
            return new ColumnData(columnName, headerSize, leftFill, rightFill);
        }
        else
        {
            leftFill = (colSize - headerSize) / 2;
            rightFill = colSize - headerSize - leftFill;
            return new ColumnData(columnName, colSize, leftFill, rightFill);
        }
    }
}
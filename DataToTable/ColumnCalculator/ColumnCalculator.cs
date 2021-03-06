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
        }
        else
        {
            leftFill = (colSize - headerSize) / 2;
            rightFill = colSize - headerSize - leftFill;
            headerSize = colSize;
        }
        return new ColumnData(
            columnName
            , headerSize
            , leftFill
            , rightFill);
    }
}
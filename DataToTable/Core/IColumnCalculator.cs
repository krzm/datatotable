namespace DataToTable;

public interface IColumnCalculator<TEntity>
{
	ColumnData CalculateColumn( 
		string columnName
		, List<int> rowLengths);
}
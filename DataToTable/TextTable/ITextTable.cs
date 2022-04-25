namespace DataToTable;

public interface ITextTable
{
	Dictionary<string, ColumnData> GetTable();
}
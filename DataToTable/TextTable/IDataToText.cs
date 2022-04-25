namespace DataToTable;

public interface IDataToText<TEntity>
{
	string GetText(List<TEntity> items);
}
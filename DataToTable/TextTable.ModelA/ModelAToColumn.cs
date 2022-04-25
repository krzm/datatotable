using ModelHelper;

namespace DataToTable;

public abstract class ModelAToColumn<TEntity> 
	: ModelAToText<TEntity>
	where TEntity : IModelA
{
	protected ModelAToColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<TEntity> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
	{}

    protected List<int> GetIdsLength(List<TEntity> models)
	{
		var rows = models.Select(m => GetId(m).Length).ToList();
		rows.Insert(0, IdKey.Length);
		return rows;
	}

	protected List<int> GetNamesLength(List<TEntity> models)
	{
		var rows = models.Select(m => GetName(m).Length).ToList();
		rows.Insert(0, NameKey.Length);
		return rows;
	}

	protected List<int> GetDescsLength(List<TEntity> models)
	{
		var rows = models.Select(m => GetDescription(m).Length).ToList();
		rows.Insert(0, DescKey.Length);
		return rows;
	}
}
using ModelHelper;

namespace DataToTable;

public class ModelATable<TEntity> : TextTable<TEntity>
	where TEntity : IModelA
{
	public ModelATable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<TEntity> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
	{}

	protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(IModelA.Id)));
		Editor.AddColumn(GetColumnData(nameof(IModelA.Name)));
		Editor.AddColumn(GetColumnData(nameof(IModelA.Description)));
	}

	protected override void CreateTableRow(TEntity model)
	{
		Editor.AddValue(GetColumnData(nameof(IModelA.Id)), model.Id.ToString());
		Editor.AddValue(GetColumnData(nameof(IModelA.Name)), model.Name);
		Editor.AddValue(GetColumnData(nameof(IModelA.Description)), model.Description);
	}

	protected override void SetColumnsSize(List<TEntity> models)
	{
		SetColumn(nameof(IModelA.Id), ModelATable<TEntity>.GetIdsLength(models));
		SetColumn(nameof(IModelA.Name), ModelATable<TEntity>.GetNamesLength(models));
		SetColumn(nameof(IModelA.Description), ModelATable<TEntity>.GetDescsLength(models));
	}

	private static List<int> GetIdsLength(List<TEntity> models)
	{
		var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(IModelA.Id).Length);
		return rows;
	}

	private static List<int> GetNamesLength(List<TEntity> models)
	{
		var rows = models.Select(e => e.Name.Length).ToList();
		rows.Insert(0, nameof(IModelA.Name).Length);
		return rows;
	}

	private static List<int> GetDescsLength(List<TEntity> models)
	{
		var rows = models.Select(e => e.Description.Length).ToList();
		rows.Insert(0, nameof(IModelA.Description).Length);
		return rows;
	}
}
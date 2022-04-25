using ModelHelper;

namespace DataToTable;

public class ModelATable<TEntity> 
	: ModelAToColumn<TEntity>
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
		Editor.AddColumn(GetColumnData(IdKey));
		Editor.AddColumn(GetColumnData(NameKey));
		Editor.AddColumn(GetColumnData(DescKey));
	}

	protected override void CreateTableRow(TEntity m)
	{
		Editor.AddValue(GetColumnData(IdKey), GetId(m));
		Editor.AddValue(GetColumnData(NameKey), GetName(m));
		Editor.AddValue(GetColumnData(DescKey), GetDescription(m));
	}

	protected override void SetColumnsSize(List<TEntity> m)
	{
		SetColumn(IdKey, GetIdsLength(m));
		SetColumn(NameKey, GetNamesLength(m));
		SetColumn(DescKey, GetDescsLength(m));
	}
}
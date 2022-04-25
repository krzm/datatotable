namespace DataToTable;

public abstract class TextTable<TEntity> : 
	IDataToText<TEntity>
	, ITextTable
{
	private readonly Dictionary<string, ColumnData> sizes = new();
    protected readonly ITableTextEditor Editor;
    private readonly IColumnCalculator<TEntity> columnCalculator;

	public TextTable(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<TEntity> columnCalculator
	)
	{
        this.Editor = tableTextEditor;
        this.columnCalculator = columnCalculator;
	}

	public string GetText(
		List<TEntity> items)
	{
		Reset();
		CalculateColumnsSize(items);
		CreateTableHeader();
		Editor.AddNewLine();
		CreateRowLayout(items);
		return Editor.GetTableText();
	}

	protected virtual void CreateRowLayout(List<TEntity> items)
	{
		SetOneRowLayout(items);
	}

	protected void SetOneRowLayout(List<TEntity> items)
	{
		for (int i = 0; i < items.Count; i++)
		{
			CreateTableRow(items[i]);
			Editor.AddNewLine();
		}
	}

	protected void SetTwoRowLayout(List<TEntity> items)
	{
		var j = GetRowIndex(items);
		for (int i = 0; i < GetRowIndex(items); i++)
		{
			CreateTableRow(items[i]);
			CreateTableRow(items[j]);
			Editor.AddNewLine();
			j++;
		}
	}

	private static int GetRowIndex(List<TEntity> items)
	{
		return items.Count / 2 == 0 ? 1 : items.Count / 2;
	}

	private void CalculateColumnsSize(List<TEntity> items)
	{
		sizes.Clear();
		SetColumnsSize(items);
	}

	protected abstract void SetColumnsSize(List<TEntity> items);

	protected void SetColumn(
		string columnName
		, List<int> rowLengths)
	{
		sizes[columnName] = columnCalculator.CalculateColumn(columnName, rowLengths);
	}

	private void Reset()
	{
		Editor.Reset();
	}

	protected ColumnData GetColumnData(string columnName)
	{
		return sizes[columnName];
	}

	protected abstract void CreateTableHeader();

	protected abstract void CreateTableRow(TEntity e);

	public Dictionary<string, ColumnData> GetTable()
	{
		return sizes;
	}
}
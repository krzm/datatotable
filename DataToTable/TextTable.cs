using System.Text;

namespace DataToTable;

public abstract class TextTable<TEntity> : 
	IDataToText<TEntity>
	, ITextTable
{
	private readonly StringBuilder buffer;
	private readonly Dictionary<string, ColumnData> sizes = new();
	private readonly IColumnCalculator<TEntity> columnCalculator;

	public TextTable(
		IColumnCalculator<TEntity> columnCalculator
	)
	{
		this.columnCalculator = columnCalculator;
		buffer = new StringBuilder();
	}

	public string GetText(
		List<TEntity> items)
	{
		Reset();
		CalculateColumnsSize(items);
		CreateTableHeader();
		AddNewLine();
		CreateRowLayout(items);
		return buffer.ToString();
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
			AddNewLine();
		}
	}

	protected void SetTwoRowLayout(List<TEntity> items)
	{
		var j = GetRowIndex(items);
		for (int i = 0; i < GetRowIndex(items); i++)
		{
			CreateTableRow(items[i]);
			CreateTableRow(items[j]);
			AddNewLine();
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
		buffer.Clear();
	}

	protected ColumnData GetColumnData(string columnName)
	{
		return sizes[columnName];
	}

	protected abstract void CreateTableHeader();

	protected void AddColumn(ColumnData data)
	{
		AddSpace(data.Left);
		AddColumnName(data.Name);
		AddSpace(data.Right);
		buffer.Append('|');
	}

	private void AddSpace(int count)
	{
		for (int i = 1; i <= count; i++)
		{
			buffer.Append(' ');
		}
	}

	private void AddColumnName(string name)
	{
		buffer.Append(name);
	}

	protected void AddNewLine()
	{
		buffer.Append(Environment.NewLine);
	}

	protected abstract void CreateTableRow(TEntity e);

	protected void AddValue(
		ColumnData data
		, string value)
	{
		buffer.Append(value);
		AddSpace(data.Size - value.Length);
		buffer.Append('|');
	}

	public Dictionary<string, ColumnData> GetTable()
	{
		return sizes;
	}
}
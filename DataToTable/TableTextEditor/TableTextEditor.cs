using System.Text;

namespace DataToTable;

public class TableTextEditor 
    : ITableTextEditor
{
    private readonly StringBuilder tableText;

    public TableTextEditor() =>
        tableText = new();

    public void Reset() =>
        tableText.Clear();

    public void AddNewLine() =>
        tableText.Append(Environment.NewLine);

    public void AddColumn(ColumnData data)
	{
        AddSpace(data.Left);
        AddSpace(data.Padding);
		AddColumnName(data.Name);
        AddSpace(data.Padding);
		AddSpace(data.Right);
		AddColumnSeparator();
	}

    public void AddSpace(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            tableText.Append(' ');
        }
    }

    private void AddColumnName(string name) =>
        tableText.Append(name);
    
    private void AddColumnSeparator() =>
        tableText.Append('|');

    public void AddValue(
		ColumnData data
		, string value)
	{
        AddSpace(data.Padding);
		AddValue(value);
        AddSpace(data.Padding);
		AddSpace(data.Size - value.Length);
		AddColumnSeparator();
	}

    private void AddValue(string value) =>
        tableText.Append(value);
    
    public string GetTableText() =>
        tableText.ToString();
}
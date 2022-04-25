namespace DataToTable;

public interface ITableTextEditor
{
    void Reset();
    void AddNewLine();
    void AddSpace(int count);
    void AddColumn(ColumnData data);
    void AddValue(ColumnData data, string value);
    string GetTableText();
}
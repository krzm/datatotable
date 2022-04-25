namespace DataToTable;

public record ColumnData(
	string Name
	, int Size
	, int Left
	, int Right
    , int Padding = 1);
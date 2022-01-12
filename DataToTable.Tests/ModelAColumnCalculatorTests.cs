using Core.Lib;
using Core.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataToTable.Tests;

public class ModelAColumnCalculatorTests
{
	[Theory]
	[InlineData(
		1
		, 2
		, 0
		, 0)]
	[InlineData(
		11
		, 2
		, 0
		, 0)]
	[InlineData(
		111
		, 3
		, 0
		, 1)]
	public void Test_Column_Id_Calculation(
		int id
		, int size
		, int left
		, int right)
	{
		var data = new List<ModelA>
		{
			new ModelA
			{
				Id = id
			}
		};
		var columnCalculator = new ColumnCalculator<ModelA>();
		
		var table = columnCalculator.CalculateColumn(nameof(IModelA.Id), GetIdsLength(data));
		
		Assert.Equal(
			new ColumnData(
				nameof(IModelA.Id)
				, size
				, left
				, right)
			, table);
	}

	private List<int> GetIdsLength(List<ModelA> models)
	{
		var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(IModelA.Id).Length);
		return rows;
	}
}
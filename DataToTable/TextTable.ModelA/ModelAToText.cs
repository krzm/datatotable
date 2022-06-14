using ModelHelper;

namespace DataToTable;

public abstract class ModelAToText<TEntity> 
	: TextTable<TEntity>
	where TEntity : IModelA
{

    protected string IdKey => nameof(IModelA.Id);
    protected string NameKey => nameof(IModelA.Name);
    protected string DescKey => nameof(IModelA.Description);

	protected ModelAToText(
        ITableTextEditor tableTextEditor
        , IColumnCalculator<TEntity> columnCalculator) 
            : base(tableTextEditor, columnCalculator)
	{
    }

    protected string GetId(IModelA m) => 
		m.Id.ToString();

    protected string GetName(IModelA m)
    {
        ArgumentNullException.ThrowIfNull(m.Name);
        return m.Name;
    }

    protected string GetDescription(IModelA m)
    {
        ArgumentNullException.ThrowIfNull(m.Description);
        return m.Description;
    } 
}
using DIHelper.MicrosoftDI;
using Microsoft.Extensions.DependencyInjection;

namespace DataToTable.MDI;

public class DataToTableSet 
	: MDIDependencySet
{
	public DataToTableSet(
		IServiceCollection container)
		: base(container)
	{
	}

	public override void Register()
	{
		RegisterColumnCalculators();
		RegisterTableProviders();
	}

	protected virtual void RegisterColumnCalculators() { }

	protected virtual void RegisterTableProviders() { }
}
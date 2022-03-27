using DIHelper.MicrosoftDI;
using Microsoft.Extensions.DependencyInjection;

namespace DataToTable.MDI;

public abstract class DataToTableSet 
	: MDIDependencySet
{
	protected DataToTableSet(
		IServiceCollection container)
		: base(container)
	{
	}

	public override void Register()
	{
		RegisterColumnCalculators();
		RegisterTableProviders();
	}

	protected abstract void RegisterColumnCalculators();

	protected abstract void RegisterTableProviders();
}
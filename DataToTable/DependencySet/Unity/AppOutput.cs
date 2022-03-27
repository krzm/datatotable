using DIHelper.Unity;
using Unity;

namespace DataToTable.Unity;

public class DataToTableSet 
    : UnityDependencySet
{
    public DataToTableSet(
        IUnityContainer container)
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
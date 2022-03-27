using DIHelper.Unity;
using Unity;

namespace DataToTable.Unity;

public abstract class DataToTableSet 
    : UnityDependencySet
{
    protected DataToTableSet(
        IUnityContainer container)
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
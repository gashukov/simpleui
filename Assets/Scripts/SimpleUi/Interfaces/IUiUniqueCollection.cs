namespace SimpleUi.Interfaces
{
	public interface IUiUniqueCollection<TKey, TView> : IUiCollection
	{
		TView Create(TKey key);
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TView> : IUiCollection
	{
		TView Create(TKey key, TParam1 param1);
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TView> : IUiCollection
	{
		TView Create(TKey key, TParam1 param1, TParam2 param2);
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TView> : IUiCollection
	{
		TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3);
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView> : IUiCollection
	{
		TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView> : IUiCollection
	{
		TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
	}

	public interface
		IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> : IUiCollection
	{
		TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6);
	}
}
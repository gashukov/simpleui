namespace SimpleUi.Interfaces
{
	public interface IUiCollection
	{
		int Count();
		void Clear();
	}

	public interface IUiCollection<TView> : IUiCollection
	{
		TView Create();
	}
	
	public interface IUiCollection<TParam1, TView> : IUiCollection
	{
		TView Create(TParam1 param1);
	}
	
	public interface IUiCollection<TParam1, TParam2, TView> : IUiCollection
	{
		TView Create(TParam1 param1, TParam2 param2);
	}
	
	public interface IUiCollection<TParam1, TParam2, TParam3, TView> : IUiCollection
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3);
	}
	
	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TView> : IUiCollection
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
	}
	
	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> : IUiCollection
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
	}
	
	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> : IUiCollection
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);
	}
	
	public interface IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> : IUiCollection
	{
		TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);
	}
}
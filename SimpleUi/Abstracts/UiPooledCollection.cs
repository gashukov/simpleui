using System.Collections.Generic;
using SimpleUi.Interfaces;

namespace SimpleUi.Abstracts
{
	public abstract class UiPooledCollectionBase<TView> : UiCollectionBase<TView>, IUiPooledCollectionBase<TView>
		where TView : UiView, IUiView
	{
		private readonly List<TView> _views = new List<TView>();

		protected TView GetFromPool()
		{
			if (_views.Count == 0)
				return null;
			var view = _views[0];
			_views.RemoveAt(0);
			return view;
		}

		public override void Clear() => _views.Clear();

		public override int Count() => _views.Count;

		public void Despawn(TView view)
		{
			view.Hide();
			OnDespawn(view);
			_views.Add(view);
		}

		protected virtual void OnDespawn(TView view)
		{
		}

		public override IEnumerator<TView> GetEnumerator() => _views.GetEnumerator();
	}

	public abstract class UiPooledCollection<TView> : UiPooledCollectionBase<TView>, IUiPooledCollection<TView>
		where TView : UiView
	{
		public TView Create()
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TView>
		where TView : UiView, IParametrizedView<TParam1>
	{
		public TView Create(TParam1 param1)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2>
	{
		public TView Create(TParam1 param1, TParam2 param2)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TView> : UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> :
		UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> :
		UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> :
		UiPooledCollectionBase<TView>,
		IUiPooledCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6,
			TParam7 param7)
		{
			var view = GetFromPool() ?? Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6, param7);
			OnCreated(view);
			return view;
		}
	}
}
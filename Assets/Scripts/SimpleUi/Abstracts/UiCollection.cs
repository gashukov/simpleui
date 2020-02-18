using System.Collections;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi.Abstracts
{
	public abstract class UiCollectionBase<TView> : MonoBehaviour, IUiCollectionBase<TView>
		where TView : UiView, IUiView
	{
		[SerializeField] protected TView prefab;
		[SerializeField] protected Transform collectionRoot;

		[Inject] protected DiContainer Container;

		protected virtual void OnCreated(TView view)
		{
			view.SetParent(collectionRoot);
			view.Show();
		}

		public abstract void Clear();

		public abstract int Count();

		public abstract IEnumerator<TView> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public abstract class UiCollection<TView> : UiCollectionBase<TView>, IUiCollection<TView>
		where TView : UiView
	{
		public TView Create()
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TView> : UiCollectionBase<TView>, IUiCollection<TParam1, TView>
		where TView : UiView, IParametrizedView<TParam1>
	{
		public TView Create(TParam1 param1)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TView> : UiCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2>
	{
		public TView Create(TParam1 param1, TParam2 param2)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TView> : UiCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TView> : UiCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView> : UiCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> :
		UiCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6);
			OnCreated(view);
			return view;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> :
		UiCollectionBase<TView>,
		IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : UiView, IParametrizedView<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>
	{
		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6,
			TParam7 param7)
		{
			var view = Container.InstantiatePrefabForComponent<TView>(prefab);
			view.Parametrize(param1, param2, param3, param4, param5, param6, param7);
			OnCreated(view);
			return view;
		}
	}
}
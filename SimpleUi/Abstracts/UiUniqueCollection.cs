using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi.Abstracts
{
	public abstract class UiUniqueCollectionBase<TKey, TView> : MonoBehaviour, IUiCollection where TView : IUiView
	{
		[SerializeField] private Transform _collectionRoot;

		private readonly Dictionary<TKey, TView> _items = new Dictionary<TKey, TView>();

		protected void OnCreated(TKey key, TView view)
		{
			view.SetParent(_collectionRoot);
			view.Show();
			_items.Add(key, view);
		}

		public Dictionary<TKey, TView>.ValueCollection GetItems()
		{
			return _items.Values;
		}

		public TView GetItem(TKey key)
		{
			return _items[key];
		}

		public void RemoveItem(TKey key)
		{
			var view = _items[key];
			view.Destroy();
		}

		public void Clear()
		{
			foreach (var item in _items.Values)
				item.Destroy();
			_items.Clear();
		}

		public int Count()
		{
			return _items.Count;
		}
	}

	public abstract class UiUniqueCollection<TKey, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TView> _factory;

		public TView Create(TKey key)
		{
			var view = _factory.Create(key);
			OnCreated(key, view);
			return view;
		}
	}

	public abstract class UiUniqueCollection<TKey, TParam1, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TParam1, TView> _factory;

		public TView Create(TKey key, TParam1 param1)
		{
			var view = _factory.Create(key, param1);
			OnCreated(key, view);
			return view;
		}
	}

	public abstract class UiUniqueCollection<TKey, TParam1, TParam2, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TParam1, TParam2, TView> _factory;

		public TView Create(TKey key, TParam1 param1, TParam2 param2)
		{
			var view = _factory.Create(key, param1, param2);
			OnCreated(key, view);
			return view;
		}
	}

	public abstract class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TParam1, TParam2, TParam3, TView> _factory;

		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var view = _factory.Create(key, param1, param2, param3);
			OnCreated(key, view);
			return view;
		}
	}

	public abstract class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TParam1, TParam2, TParam3, TParam4, TView> _factory;

		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var view = _factory.Create(key, param1, param2, param3, param4);
			OnCreated(key, view);
			return view;
		}
	}

	public abstract class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TView> _factory;

		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var view = _factory.Create(key, param1, param2, param3, param4, param5);
			OnCreated(key, view);
			return view;
		}
	}

	public abstract class UiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		: UiUniqueCollectionBase<TKey, TView>,
			IUiUniqueCollection<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TKey, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> _factory;

		public TView Create(TKey key, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var view = _factory.Create(key, param1, param2, param3, param4, param5, param6);
			OnCreated(key, view);
			return view;
		}
	}
}
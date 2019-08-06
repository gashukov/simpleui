using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi.Abstracts
{
	public abstract class UiCollectionBase<TView> : MonoBehaviour, IUiCollection where TView : IUiView
	{
		[SerializeField] private Transform _collectionRoot;

		private readonly List<TView> _items = new List<TView>();

		protected void OnCreated(TView view)
		{
			view.SetParent(_collectionRoot);
			view.Show();
			_items.Add(view);
		}

		public List<TView> GetItems() => _items;

		public void RemoveItem(TView view)
		{
			_items.Remove(view);
			view.Destroy();
		}

		public void Clear()
		{
			foreach (var item in _items)
				item.Destroy();
			_items.Clear();
		}

		public int Count() => _items.Count;
	}

	public abstract class UiCollection<TView> 
		: UiCollectionBase<TView>, 
			IUiCollection<TView> 
		where TView : IUiView
	{
		[Inject] private IFactory<TView> _factory;

		public TView Create()
		{
			var item = _factory.Create();
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TView> _factory;

		public TView Create(TParam1 param1)
		{
			var item = _factory.Create(param1);
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TParam2, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TParam2, TView> _factory;

		public TView Create(TParam1 param1, TParam2 param2)
		{
			var item = _factory.Create(param1, param2);
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TParam2, TParam3, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TParam2, TParam3, TView> _factory;

		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3)
		{
			var item = _factory.Create(param1, param2, param3);
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TParam2, TParam3, TParam4, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TParam2, TParam3, TParam4, TView> _factory;

		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			var item = _factory.Create(param1, param2, param3, param4);
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TView> _factory;

		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			var item = _factory.Create(param1, param2, param3, param4, param5);
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TView> _factory;

		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6)
		{
			var item = _factory.Create(param1, param2, param3, param4, param5, param6);
			OnCreated(item);
			return item;
		}
	}

	public abstract class UiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		: UiCollectionBase<TView>,
			IUiCollection<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView>
		where TView : IUiView
	{
		[Inject] private IFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TView> _factory;

		public TView Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5,
			TParam6 param6, TParam7 param7)
		{
			var item = _factory.Create(param1, param2, param3, param4, param5, param6, param7);
			OnCreated(item);
			return item;
		}
	}
}
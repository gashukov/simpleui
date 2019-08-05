using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi.Abstracts
{
	public abstract class UiCollection<TView> : MonoBehaviour, IUiCollection where TView : IUiView
	{
		[SerializeField] private Transform _collectionRoot;
		[Inject] private IFactory<TView> _factory;

		private readonly List<TView> _items = new List<TView>();

		public TView AddItem()
		{
			var item = _factory.Create();
			item.SetParent(_collectionRoot);
			item.Show();
			_items.Add(item);
			return item;
		}

		public List<TView> GetItems()
		{
			return _items;
		}

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

		public int Count()
		{
			return _items.Count;
		}
	}

	public abstract class UiCollection<TKey, TView> : MonoBehaviour, IUiCollection where TView : IUiView
	{
		[SerializeField] private Transform _collectionRoot;
		[Inject] private IFactory<TKey, TView> _factory;

		private readonly Dictionary<TKey, TView> _items = new Dictionary<TKey, TView>();

		public TView AddItem(TKey key)
		{
			var item = _factory.Create(key);
			item.SetParent(_collectionRoot);
			item.Show();
			_items.Add(key, item);
			return item;
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
}
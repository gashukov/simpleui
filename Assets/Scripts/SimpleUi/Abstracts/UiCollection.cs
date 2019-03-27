using System.Collections.Generic;
using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi.Abstracts {
	public abstract class UiCollection<TView> : MonoBehaviour, IUiCollection where TView : UiView {
		[SerializeField] private Transform _collectionRoot;
		[Inject] private IFactory<TView> _factory;

		private readonly List<TView> _items = new List<TView>();

		public TView AddItem() {
			var item = _factory.Create();
			item.transform.SetParent(_collectionRoot, false);
			item.Show();
			_items.Add(item);
			return item;
		}

		public List<TView> GetItems() => _items;
		
		public void RemoveItem(TView view) {
			_items.Remove(view);
			Destroy(view.gameObject);
		}

		public void Clear() {
			foreach (var item in _items)
				Destroy(item.gameObject);
			_items.Clear();
		}

		public int Count() => _items.Count;
	}
	
	public abstract class UiCollection<TKey, TView> : MonoBehaviour, IUiCollection where TView : UiView {
		[SerializeField] private Transform _collectionRoot;
		[Inject] private IFactory<TKey, TView> _factory;

		private readonly Dictionary<TKey, TView> _items = new Dictionary<TKey, TView>();

		public TView AddItem(TKey key) {
			var item = _factory.Create(key);
			item.transform.SetParent(_collectionRoot, false);
			item.Show();
			_items.Add(key, item);
			return item;
		}

		public Dictionary<TKey, TView>.ValueCollection GetItems() => _items.Values;

		public void Clear() {
			foreach (var item in _items.Values)
				Destroy(item.gameObject);
			_items.Clear();
		}

		public int Count() => _items.Count;
	}
}
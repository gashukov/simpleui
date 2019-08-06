using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public class UiMonoCollection<TView> : UiCollectionBase<TView>, IUiCollection<TView> where TView : UiView
	{
		[SerializeField] private TView _prefab;
		
		public TView Create()
		{
			var view = Instantiate(_prefab);
			OnCreated(view);
			return view;
		}
	}
}
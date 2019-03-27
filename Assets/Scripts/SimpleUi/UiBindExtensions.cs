using SimpleUi.Abstracts;
using UnityEngine;
using Zenject;

namespace SimpleUi {
	public static class UiBindExtensions {
		public static void BindUiView<T, TU>(this DiContainer container, TU viewPrefab, Transform parent)
			where TU : UiView
			where T : UiController<TU> {
			container.BindInterfacesAndSelfTo<T>().AsSingle();
			container.BindInterfacesAndSelfTo<TU>()
				.FromComponentInNewPrefab(viewPrefab)
				.UnderTransform(parent).AsSingle()
				.OnInstantiated((context, o) => ((UiView) o).gameObject.SetActive(false));
		}
	}
}

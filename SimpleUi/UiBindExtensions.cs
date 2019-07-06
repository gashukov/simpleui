using SimpleUi.Interfaces;
using UnityEngine;
using Zenject;

namespace SimpleUi {
	public static class UiBindExtensions {
		public static void BindUiView<T, TU>(this DiContainer container, Object viewPrefab, Transform parent)
			where TU : IUiView
			where T : IUiController {
			container.BindInterfacesAndSelfTo<T>().AsSingle();
			container.BindInterfacesAndSelfTo<TU>()
				.FromComponentInNewPrefab(viewPrefab)
				.UnderTransform(parent).AsSingle()
				.OnInstantiated((context, o) => ((MonoBehaviour) o).gameObject.SetActive(false));
		}
	}
}

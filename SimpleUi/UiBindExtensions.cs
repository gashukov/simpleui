using SimpleUi.Interfaces;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace SimpleUi
{
	public static class UiBindExtensions
	{
		public static void BindUiView<T, TU>(this DiContainer container, Object viewPrefab, Transform parent)
			where TU : IUiView
			where T : IUiController
		{
			container.BindInterfacesAndSelfTo<T>().AsSingle();
			container.BindInterfacesAndSelfTo<TU>()
				.FromComponentInNewPrefab(viewPrefab)
				.UnderTransform(parent).AsSingle()
				.OnInstantiated((context, o) => ((MonoBehaviour) o).gameObject.SetActive(false));
		}

		public static void BindUiSignals(this DiContainer container)
		{
			container.DeclareSignal<SignalOpenWindow>();
			container.DeclareSignal<SignalOpenRootWindow>();
			container.DeclareSignal<SignalBackWindow>();
			container.DeclareSignal<SignalActiveWindow>().OptionalSubscriber();
			container.DeclareSignal<SignalFocusWindow>().OptionalSubscriber();
			container.DeclareSignal<SignalCloseWindow>().OptionalSubscriber();
		}
		
		public static void BindWindowsController<T>(this DiContainer container)
			where T : IWindowsController, IInitializable
		{
			container.BindInitializableExecutionOrder<T>(-1000);
			container.BindInterfacesTo<T>().AsSingle().NonLazy();
		}
	}
}
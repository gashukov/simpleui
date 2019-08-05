using SimpleUi;
using SimpleUi.Managers;
using SimpleUi.Signals;
using Zenject;

namespace Example
{
	public class TestUiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);

			Container.DeclareSignal<SignalOpenWindow>();
			Container.DeclareSignal<SignalBackWindow>();
			Container.DeclareSignal<SignalActiveWindow>().OptionalSubscriber();
			Container.DeclareSignal<SignalFocusWindow>().OptionalSubscriber();
			Container.DeclareSignal<SignalCloseWindow>().OptionalSubscriber();

			Container.BindInterfacesAndSelfTo<FirstWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<SecondWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<ThirdWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<FourthWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<FifthWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<FirstPopUpWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<SecondPopUpWindow>().AsSingle();

			Container.BindInterfacesTo<WindowController>().AsSingle();
			Container.BindInterfacesAndSelfTo<UiFilterManager>().AsSingle();
			Container.BindInterfacesAndSelfTo<UiMapperManager>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<TestManager>().AsSingle().NonLazy();
		}
	}
}
using SimpleUi;
using SimpleUi.Managers;
using Zenject;

namespace Example
{
	public class TestUiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);

			Container.BindUiSignals();
			

			Container.BindInterfacesAndSelfTo<FirstWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<SecondWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<ThirdWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<FourthWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<FifthWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<FirstPopUpWindow>().AsSingle();
			Container.BindInterfacesAndSelfTo<SecondPopUpWindow>().AsSingle();

			Container.BindInterfacesAndSelfTo<UiFilterManager>().AsSingle();
			Container.BindInterfacesAndSelfTo<UiMapperManager>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<TestManager>().AsSingle().NonLazy();
			
			Container.BindWindowsController<WindowsController>();
		}
	}
}
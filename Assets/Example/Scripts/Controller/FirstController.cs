using Example.Views;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Example.Controller
{
	public class FirstController : UiController<FirstView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FirstController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.Fire(SignalOpenWindow.Build<SecondWindow>()))
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}

	public class SecondController : UiController<SecondView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public SecondController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.Fire(SignalOpenWindow.Build<ThirdWindow>()))
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}

	public class ThirdController : UiController<ThirdView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public ThirdController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.Fire(SignalOpenWindow.Build<FirstPopUpWindow>()))
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}

	public class FirstPopUpController : UiController<FirstPopUpView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FirstPopUpController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.Fire(SignalOpenWindow.Build<SecondPopUpWindow>()))
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}

	public class SecondPopUpController : UiController<SecondPopUpView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public SecondPopUpController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.Fire(SignalOpenWindow.Build<FourthWindow>()))
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}

	public class FourthController : UiController<FourthView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FourthController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Next.OnClickAsObservable()
				.Subscribe(s => _signalBus.Fire(SignalOpenWindow.Build<FifthWindow>()))
				.AddTo(View.Next);
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}

	public class FifthController : UiController<FifthView>, IInitializable
	{
		private readonly SignalBus _signalBus;

		public FifthController(SignalBus signalBus)
		{
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			View.Back.OnClickAsObservable().Subscribe(s => _signalBus.Fire<SignalBackWindow>()).AddTo(View.Back);
		}
	}
}
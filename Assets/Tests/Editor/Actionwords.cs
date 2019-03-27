using System;
using NUnit.Framework;
using SimpleUi.Interfaces;
using SimpleUi.Signals;
using Zenject;

namespace SimpleUi {
	public class Actionwords {
		[Inject] private FirstController _firstController;
		[Inject] private SecondController _secondController;
		[Inject] private ThirdController _thirdController;
		[Inject] private PopUpFirstController _popUpFirst;
		[Inject] private PopUpSecondController _popUpSecond;
		[Inject] private SignalBus _signalBus;

		public void OpenFirstIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(FirstWindow)));
			
			AssertController(State.Open, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenSecondIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(SecondWindow)));
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenThirdIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(ThirdWindow)));
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Open, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenPopUpFirstIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(FirstPopUpWindow)));
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Open, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenPopUpSecondIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(SecondPopUpWindow)));
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Open, _popUpSecond);
		}

		public void BackPopUpSecondClosed() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Open, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenTwoControllerWindowFirstSecondIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(WindowTwoControllers)));
			
			AssertController(State.Open, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenThreeControllerWindowFirstSecondThirdIsActive() {
			_signalBus.Fire(new SignalOpenWindow(typeof(WindowThreeControllers)));
			
			AssertController(State.Open, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Open, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackThreeControllerWindowThirdClosed() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Open, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackTwoControllerWindowSecondClosedPopUpFirstIsActive() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Open, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackPopUpFirstPopUpFirstClosedThirdIsActive() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Open, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackThirdThirdClosedSecondIsActive() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Closed, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackSecondSecondClosedFirstIsActive() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Open, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackFirstFirstIsActive() {
			_signalBus.Fire<SignalBackWindow>();
			
			AssertController(State.Open, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}
		
		private void AssertController(State state, IUiController controller) {
			switch (state) {
				case State.Open:
					Assert.AreEqual(true, controller.IsActive);
					Assert.AreEqual(true, controller.InFocus);
					break;
				case State.Closed:
					Assert.AreEqual(false, controller.IsActive);
					Assert.AreEqual(false, controller.InFocus);
					break;
				case State.Background:
					Assert.AreEqual(true, controller.IsActive);
					Assert.AreEqual(false, controller.InFocus);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(state), state, null);
			}
			
		}
		
		private enum State {
			Open,
			Closed,
			Background
		}
	}
}

using System;
using NUnit.Framework;
using SimpleUi.Interfaces;
using SimpleUi.Signals;
using Zenject;

namespace SimpleUi
{
	public class Actionwords
	{
		[Inject] private FirstController _firstController;
		[Inject] private SecondController _secondController;
		[Inject] private ThirdController _thirdController;
		[Inject] private PopUpFirstController _popUpFirst;
		[Inject] private PopUpSecondController _popUpSecond;
		[Inject] private SignalBus _signalBus;

		public void OpenFirstIsActive()
		{
			_signalBus.OpenWindow<FirstWindow>();

			AssertController(State.Open, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenSecondIsActive()
		{
			_signalBus.OpenWindow<SecondWindow>();

			AssertController(State.Closed, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenThirdIsActive()
		{
			_signalBus.OpenWindow<ThirdWindow>();

			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Open, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenPopUpFirstIsActive()
		{
			_signalBus.OpenWindow<FirstPopUpWindow>();

			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Open, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenPopUpSecondIsActive()
		{
			_signalBus.OpenWindow<SecondPopUpWindow>();

			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Open, _popUpSecond);
		}

		public void BackPopUpSecondClosed()
		{
			_signalBus.BackWindow();

			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Open, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenTwoControllerWindowFirstSecondIsActive()
		{
			_signalBus.OpenWindow<WindowTwoControllers>();

			AssertController(State.Open, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void OpenThreeControllerWindowFirstSecondThirdIsActive()
		{
			_signalBus.OpenWindow<WindowThreeControllers>();

			AssertController(State.Open, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Open, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackThreeControllerWindowThirdClosed()
		{
			_signalBus.BackWindow();

			AssertController(State.Open, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackTwoControllerWindowSecondClosedPopUpFirstIsActive()
		{
			_signalBus.BackWindow();

			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Background, _thirdController);
			AssertController(State.Open, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackPopUpFirstPopUpFirstClosedThirdIsActive()
		{
			_signalBus.BackWindow();

			AssertController(State.Closed, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Open, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackThirdThirdClosedSecondIsActive()
		{
			_signalBus.BackWindow();

			AssertController(State.Closed, _firstController);
			AssertController(State.Open, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackSecondSecondClosedFirstIsActive()
		{
			_signalBus.BackWindow();

			AssertController(State.Open, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		public void BackFirstFirstIsActive()
		{
			_signalBus.BackWindow();

			AssertController(State.Open, _firstController);
			AssertController(State.Closed, _secondController);
			AssertController(State.Closed, _thirdController);
			AssertController(State.Closed, _popUpFirst);
			AssertController(State.Closed, _popUpSecond);
		}

		private void AssertController(State state, IUiController controller)
		{
			switch (state)
			{
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

		private enum State
		{
			Open,
			Closed,
			Background
		}
	}
}
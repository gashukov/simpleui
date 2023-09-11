using System;
using System.Linq;
using NUnit.Framework;
using SimpleUi.Abstracts;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using UnityEngine;
using Zenject;

namespace SimpleUi
{
	public class UiControllerStateTest
	{
		private static readonly UiWindowState[] States =
		{
			UiWindowState.IsActiveAndFocus,
			UiWindowState.IsActiveNotFocus,
			UiWindowState.NotActiveNotFocus,
		};

		private UiControllerSpy _uiController;

		[SetUp]
		public void SetUp()
		{
			var container = new DiContainer();
			container.Bind<UiControllerSpy>().AsSingle();
			container.Bind<UiViewSpy>().AsSingle();
			_uiController = container.Resolve<UiControllerSpy>();
		}

		[Test]
		public void ControllerStatePipeline()
		{
			var previousState = UiWindowState.NotActiveNotFocus;
			foreach (var state in States)
			{
				_uiController.SetState(new UiControllerState(state.IsActive, state.InFocus, 0));
				_uiController.ProcessState();
				AssertControllerState(previousState, state);
				previousState = state;
				_uiController.ClearSpyStats();
			}

			var reversedStates = States.SkipLast(1).Reverse().ToList();
			reversedStates.Add(UiWindowState.NotActiveNotFocus);

			foreach (var state in reversedStates)
			{
				_uiController.Back();
				_uiController.ProcessState();
				AssertControllerState(previousState, state);
				previousState = state;
				_uiController.ClearSpyStats();
			}
		}

		private void AssertControllerState(UiWindowState previousState, UiWindowState nextState)
		{
			var onShowExpectedCount = !previousState.IsActive && nextState.IsActive ? 1 : 0;
			var onHideExpectedCount = previousState.IsActive && !nextState.IsActive ? 1 : 0;
			var onFocusExpectedCount = previousState.InFocus != nextState.InFocus ? 1 : 0;

			Assert.AreEqual(
				onShowExpectedCount,
				_uiController.OnShowCallCount,
				$"OnShow executions previous '{previousState}' next '{nextState}'"
			);
			Assert.AreEqual(
				onHideExpectedCount,
				_uiController.OnHideCallCount,
				$"OnHide executions previous '{previousState}' next '{nextState}'"
			);
			Assert.AreEqual(
				onFocusExpectedCount,
				_uiController.OnFocusCallCount,
				$"OnFocus executions previous '{previousState}' next '{nextState}'"
			);
		}

		public class UiControllerSpy : UiController<UiViewSpy>
		{
			public int OnShowCallCount { get; private set; }
			public int OnHideCallCount { get; private set; }
			public int OnFocusCallCount { get; private set; }

			public override void OnShow() => OnShowCallCount++;

			public override void OnHide() => OnHideCallCount++;

			public override void OnHasFocus(bool inFocus) => OnFocusCallCount++;

			public void ClearSpyStats()
			{
				OnShowCallCount = 0;
				OnHideCallCount = 0;
				OnFocusCallCount = 0;
			}
		}

		public class UiViewSpy : IUiView
		{
			public bool IsShow { get; set; }
			
			public void Show()
			{
			}

			public void Hide()
			{
			}

			public IUiElement[] GetUiElements() => Array.Empty<IUiElement>();

			public void SetOrder(int index)
			{
			}

			public void SetParent(Transform parent)
			{
			}

			public void Destroy()
			{
			}
		}
	}
}
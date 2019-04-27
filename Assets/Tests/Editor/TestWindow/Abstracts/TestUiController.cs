using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;

namespace SimpleUi.Abstracts {
	public abstract class TestUiController : IUiController {
		private readonly UiControllerState _defaultState = new UiControllerState(false, false, 0);
		private readonly Stack<UiControllerState> _states = new Stack<UiControllerState>();
		
		public bool IsActive { get; private set; }
		public bool InFocus { get; private set; }

		public void SetState(UiControllerState state) {
			IsActive = state.IsActive;
			InFocus = state.InFocus;
		}

		public void Back() {
			if (_states.Count == 0) {
				SetState(_defaultState);
				return;
			}
			SetState(_states.Pop());
		}

		public IUiElement[] GetUiElements() => null;
	}
}

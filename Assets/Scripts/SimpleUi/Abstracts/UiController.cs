using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using Zenject;

namespace SimpleUi.Abstracts {
	public abstract class UiController<T> : IUiController where T : IUiView {
		private readonly Stack<UiControllerState> _states = new Stack<UiControllerState>();
		private readonly UiControllerState _defaultState = new UiControllerState(false, false, 0);

		[Inject] protected readonly T View;
		public bool IsActive { get; private set; }
		public bool InFocus { get; private set; }

		public void SetState(UiControllerState state) {
			if (IsActive != state.IsActive) {
				IsActive = state.IsActive;
				if(state.IsActive)
					Show();
				else
					Hide();
			}
			if (InFocus != state.InFocus) {
				InFocus = state.InFocus;
				OnHasFocus(state.InFocus);
			}
			if(state.IsActive)
				SetOrder(state.Order);
		}

		public void Back() {
			if (_states.Count == 0) {
				SetState(_defaultState);
				_states.Clear();
				return;
			}
			SetState(_states.Pop());
		}

		public IUiElement[] GetUiElements() => View.GetUiElements();

		protected virtual void Show() => View.Show();

		protected virtual void Hide() => View.Hide();

		protected virtual void OnHasFocus(bool inFocus) { }

		private void SetOrder(int index) => View.SetOrder(index);
	}
}

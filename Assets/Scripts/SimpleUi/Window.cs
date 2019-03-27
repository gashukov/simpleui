using System.Collections.Generic;
using System.Linq;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using Zenject;

namespace SimpleUi {
	public abstract class Window : IWindow {
		public abstract string Name { get; }
		public abstract void SetState(UiWindowState state);
		public abstract void Back();
		public abstract IUiElement[] GetUiElements();
	}

	public abstract class Window<T> : Window where T : IUiController {
		private IUiController _controller;

		[Inject]
		public void Construct(T w1) { _controller = w1; }

		public override void SetState(UiWindowState state) {
			_controller.SetState(new UiControllerState(state.IsActive, state.InFocus, 0));
		}

		public override void Back() => _controller.Back();

		public override IUiElement[] GetUiElements() => _controller.GetUiElements();
	}

	public abstract class Window<T1, T2> : Window where T1 : IUiController where T2 : IUiController {
		private List<IUiController> _controllers = new List<IUiController>();

		[Inject]
		public void Construct(T1 w1, T2 w2) {
			_controllers.Add(w1);
			_controllers.Add(w2);
			_controllers = _controllers.OrderBy(f => f.Order).ToList();
		}

		public override void SetState(UiWindowState state) {
			for (var i = 0; i < _controllers.Count; i++) {
				var controller = _controllers[i];
				controller.SetState(new UiControllerState(state.IsActive, state.InFocus, i));
			}
		}

		public override void Back() {
			foreach (var controller in _controllers)
				controller.Back();
		}

		public override IUiElement[] GetUiElements() {
			var list = new List<IUiElement>();
			foreach (var controller in _controllers) 
				list.AddRange(controller.GetUiElements());
			return list.ToArray();
		}
	}

	public abstract class Window<T1, T2, T3> : Window
		where T1 : IUiController where T2 : IUiController where T3 : IUiController {
		private List<IUiController> _controllers = new List<IUiController>();

		[Inject]
		public void Construct(T1 w1, T2 w2, T3 w3) {
			_controllers.Add(w1);
			_controllers.Add(w2);
			_controllers.Add(w3);
			_controllers = _controllers.OrderBy(f => f.Order).ToList();
		}

		public override void SetState(UiWindowState state) {
			for (var i = 0; i < _controllers.Count; i++) {
				var controller = _controllers[i];
				controller.SetState(new UiControllerState(state.IsActive, state.InFocus, i));
			}
		}

		public override void Back() {
			foreach (var controller in _controllers)
				controller.Back();
		}
		
		public override IUiElement[] GetUiElements() {
			var list = new List<IUiElement>();
			foreach (var controller in _controllers) 
				list.AddRange(controller.GetUiElements());
			return list.ToArray();
		}
	}

	public abstract class Window<T1, T2, T3, T4> : Window
		where T1 : IUiController
		where T2 : IUiController
		where T3 : IUiController
		where T4 : IUiController {
		private List<IUiController> _controllers = new List<IUiController>();

		[Inject]
		public void Construct(T1 w1, T2 w2, T3 w3, T4 w4) {
			_controllers.Add(w1);
			_controllers.Add(w2);
			_controllers.Add(w3);
			_controllers.Add(w4);
			_controllers = _controllers.OrderBy(f => f.Order).ToList();
		}

		public override void SetState(UiWindowState state) {
			for (var i = 0; i < _controllers.Count; i++) {
				var controller = _controllers[i];
				controller.SetState(new UiControllerState(state.IsActive, state.InFocus, i));
			}
		}

		public override void Back() {
			foreach (var controller in _controllers)
				controller.Back();
		}
		
		public override IUiElement[] GetUiElements() {
			var list = new List<IUiElement>();
			foreach (var controller in _controllers) 
				list.AddRange(controller.GetUiElements());
			return list.ToArray();
		}
	}
	
	public abstract class Window<T1, T2, T3, T4, T5> : Window
		where T1 : IUiController
		where T2 : IUiController
		where T3 : IUiController
		where T4 : IUiController
		where T5 : IUiController {
		private List<IUiController> _controllers = new List<IUiController>();

		[Inject]
		public void Construct(T1 w1, T2 w2, T3 w3, T4 w4, T5 w5) {
			_controllers.Add(w1);
			_controllers.Add(w2);
			_controllers.Add(w3);
			_controllers.Add(w4);
			_controllers.Add(w5);
			_controllers = _controllers.OrderBy(f => f.Order).ToList();
		}

		public override void SetState(UiWindowState state) {
			for (var i = 0; i < _controllers.Count; i++) {
				var controller = _controllers[i];
				controller.SetState(new UiControllerState(state.IsActive, state.InFocus, i));
			}
		}

		public override void Back() {
			foreach (var controller in _controllers)
				controller.Back();
		}
		
		public override IUiElement[] GetUiElements() {
			var list = new List<IUiElement>();
			foreach (var controller in _controllers) 
				list.AddRange(controller.GetUiElements());
			return list.ToArray();
		}
	}
}

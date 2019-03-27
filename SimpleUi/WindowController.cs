using System;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace SimpleUi {
	public class WindowController : IInitializable, IDisposable {
		private readonly DiContainer _container;
		private readonly SignalBus _signalBus;
		private readonly List<IWindow> _windows;
		private readonly Stack<IWindow> _windowsStack = new Stack<IWindow>();
		private readonly UiWindowState _activeAndFocus = new UiWindowState(true, true);
		private readonly UiWindowState _activeNoFocus = new UiWindowState(true, false);
		private readonly UiWindowState _notActive = new UiWindowState(false, false);

		private IWindow _window;
		public IWindow Window => _window;

		private CompositeDisposable _disposable = new CompositeDisposable();

		public WindowController(DiContainer container, SignalBus signalBus, List<IWindow> windows) {
			_container = container;
			_signalBus = signalBus;
			_windows = windows;
		}

		public void Initialize() {
			_signalBus.GetStream<SignalOpenWindow>().Subscribe(OnOpen).AddTo(_disposable);
			_signalBus.GetStream<SignalBackWindow>().Subscribe(s => Back()).AddTo(_disposable);
		}

		public void Dispose() => _disposable.Dispose();

		private void OnOpen(SignalOpenWindow signal) {
			IWindow window;
			if (signal.Type != null)
				window = _container.Resolve(signal.Type) as IWindow;
			else
				window = _windows.Find(f => f.Name == signal.Name);
			Open(window);
		}

		private void Open(IWindow window) {
			var isPopUp = window is IPopUp;
			var first = _windowsStack.Count > 0 ? _windowsStack.Peek() : null;
			if (first != null) {
				if (first is IPopUp)
					first.Back();
				if (isPopUp)
					_window?.SetState(_activeNoFocus);
				else {
					_window?.SetState(_notActive);
					first.Back();
				}
			}

			_windowsStack.Push(window);
			ActiveAndFocus(window, isPopUp);
		}

		private void Back() {
			if (_windowsStack.Count == 1)
				return;
			var window = _windowsStack.Pop();
			window.Back();
			_signalBus.Fire(new SignalCloseWindow(window));
			var peek = _windowsStack.Peek();
			var isPopUp = peek is IPopUp;
			if (isPopUp && !(window is IPopUp)) {
				_window = GetFirstWindow();
				_window?.SetState(_activeNoFocus);
			}

			ActiveAndFocus(peek, isPopUp);
		}

		private void ActiveAndFocus(IWindow window, bool isPopUp) {
			if (!isPopUp)
				_window = window;
			window.SetState(_activeAndFocus);
			_signalBus.Fire(new SignalActiveWindow(window));
			_signalBus.Fire(new SignalFocusWindow(window));
		}

		private IWindow GetFirstWindow() {
			foreach (var element in _windowsStack) {
				if (element is IPopUp)
					continue;
				return element;
			}

			return null;
		}
	}
}

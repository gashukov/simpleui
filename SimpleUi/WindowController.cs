using System;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace SimpleUi
{
	public class WindowController : IInitializable, IDisposable
	{
		private readonly DiContainer _container;
		private readonly SignalBus _signalBus;
		private readonly List<IWindow> _windows;
		private readonly Stack<IWindow> _windowsStack = new Stack<IWindow>();
		private readonly CompositeDisposable _disposable = new CompositeDisposable();

		private IWindow _window;

		public WindowController(DiContainer container, SignalBus signalBus, List<IWindow> windows)
		{
			_container = container;
			_signalBus = signalBus;
			_windows = windows;
		}

		public void Initialize()
		{
			_signalBus.GetStream<SignalOpenWindow>().Subscribe(OnOpen).AddTo(_disposable);
			_signalBus.GetStream<SignalBackWindow>().Subscribe(s => Back()).AddTo(_disposable);
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}

		private void OnOpen(SignalOpenWindow signal)
		{
			IWindow window;
			if (signal.Type != null)
				window = _container.Resolve(signal.Type) as IWindow;
			else
				window = _windows.Find(f => f.Name == signal.Name);
			Open(window);
		}

		private void Open(IWindow window)
		{
			var isNextWindowPopUp = window is IPopUp;
			var currentWindow = _windowsStack.Count > 0 ? _windowsStack.Peek() : null;
			if (currentWindow != null)
			{
				var isCurrentWindowPopUp = currentWindow is IPopUp;
				if (isCurrentWindowPopUp)
				{
					currentWindow.SetState(UiWindowState.NotActiveNotFocus);
					if (!isNextWindowPopUp)
						_window?.SetState(UiWindowState.NotActiveNotFocus);
				}
				else if (isNextWindowPopUp)
					_window?.SetState(UiWindowState.IsActiveNotFocus);
				else
					_window?.SetState(UiWindowState.NotActiveNotFocus);
			}

			_windowsStack.Push(window);
			window.SetState(UiWindowState.IsActiveAndFocus);
			ActiveAndFocus(window, isNextWindowPopUp);
		}

		private void Back()
		{
			if (_windowsStack.Count == 1)
				return;
			var currentWindow = _windowsStack.Pop();
			currentWindow.Back();
			_signalBus.Fire(new SignalCloseWindow(currentWindow));

			var previousWindow = _windowsStack.Peek();
			var isPreviousWindowPopUp = previousWindow is IPopUp;
			if (isPreviousWindowPopUp)
			{
				var firstWindow = GetFirstWindow();
				if (firstWindow != _window)
				{
					_window = firstWindow;
					_window.Back();
				}
			}

			previousWindow.Back();
			ActiveAndFocus(previousWindow, isPreviousWindowPopUp);
		}

		private void ActiveAndFocus(IWindow window, bool isPopUp)
		{
			if (!isPopUp)
				_window = window;
			_signalBus.Fire(new SignalActiveWindow(window));
			_signalBus.Fire(new SignalFocusWindow(window));
		}

		private IWindow GetFirstWindow()
		{
			foreach (var element in _windowsStack)
			{
				if (element is IPopUp)
					continue;
				return element;
			}

			return null;
		}
	}
}
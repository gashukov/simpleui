﻿using System;
using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace SimpleUi
{
	public class WindowsController : IWindowsController, IInitializable, IDisposable
	{
		private readonly DiContainer _container;
		private readonly SignalBus _signalBus;
		private readonly List<IWindow> _windows;
		private readonly WindowState _windowState;
		private readonly EWindowLayer _windowLayer;
		private readonly Stack<IWindow> _windowsStack = new Stack<IWindow>();
		private readonly CompositeDisposable _disposables = new CompositeDisposable();

		private IWindow _window;

		public Stack<IWindow> Windows => _windowsStack;

		public WindowsController(
			DiContainer container,
			SignalBus signalBus,
			[Inject(Source = InjectSources.Local)] List<IWindow> windows,
			[Inject(Source = InjectSources.Local)] WindowState windowState,
			EWindowLayer windowLayer
		)
		{
			_container = container;
			_signalBus = signalBus;
			_windows = windows;
			_windowState = windowState;
			_windowLayer = windowLayer;
		}

		public void Initialize()
		{
			_signalBus.GetStreamId<SignalOpenWindow>(_windowLayer).Subscribe(OnOpen).AddTo(_disposables);
			_signalBus.GetStreamId<SignalBackWindow>(_windowLayer).Subscribe(_ => OnBack()).AddTo(_disposables);
			_signalBus.GetStreamId<SignalOpenRootWindow>(_windowLayer).Subscribe(OnOpenRootWindow).AddTo(_disposables);
		}

		public void Dispose() => _disposables.Dispose();

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

		private void OnBack()
		{
			if (_windowsStack.Count == 0)
				return;

			var currentWindow = _windowsStack.Pop();
			currentWindow.Back();
			_signalBus.FireId(_windowLayer, new SignalCloseWindow(currentWindow));

			if (_windowsStack.Count == 0)
				return;
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
			_windowState.CurrentWindowName = window.Name;
			_signalBus.FireId(_windowLayer, new SignalActiveWindow(window));
			_signalBus.FireId(_windowLayer, new SignalFocusWindow(window));
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

		private void OnOpenRootWindow(SignalOpenRootWindow obj)
		{
			while (_windowsStack.Count > 1)
			{
				OnBack();
			}
		}
	}
}
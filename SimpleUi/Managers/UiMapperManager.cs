using System;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace SimpleUi.Managers {
	public class UiMapperManager : IInitializable, IDisposable {
		private readonly SignalBus _signalBus;
		private CompositeDisposable _disposable = new CompositeDisposable();

		private WindowData _windowData;
		public WindowData WindowData => _windowData;

		public UiMapperManager(SignalBus signalBus) { _signalBus = signalBus; }

		public void Initialize() {
			_signalBus.GetStream<SignalActiveWindow>().Subscribe(f => OnWindowChange(f.Window)).AddTo(_disposable);
		}

		public void Dispose() => _disposable.Dispose();

		private void OnWindowChange(IWindow window) {
			if (window == null)
				return;
			_windowData = new WindowData(window.Name, window.GetUiElements());
		}

		public void Highlight(string pathToElement) {
			var element = FindElement(pathToElement);
			element.Highlight();
		}

		public void Reset(string pathToElement) {
			var element = FindElement(pathToElement);
			element.Reset();
		}

		public int GetElementId(string pathToElement) {
			var element = FindElement(pathToElement);
			return element.Id;
		}

		private IUiElement FindElement(string pathToElement) {
			var path = new Path(pathToElement);
			return WindowData.Name != path.Window ? null : WindowData.GetElement(path.Element);
		}
	}
}
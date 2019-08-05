using System.Collections.Generic;
using SimpleUi.Interfaces;
using SimpleUi.Models;
using Zenject;

namespace SimpleUi
{
	public abstract class Window : IWindow
	{
		public abstract string Name { get; }
		public abstract void SetState(UiWindowState state);
		public abstract void Back();
		public abstract IUiElement[] GetUiElements();
	}

	public abstract class BaseWindow : Window
	{
		private readonly List<IUiController> _controllers = new List<IUiController>();

		protected void InternalConstruct(params IUiController[] controllers)
		{
			_controllers.AddRange(controllers);
		}

		public override void SetState(UiWindowState state)
		{
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].SetState(new UiControllerState(state.IsActive, state.InFocus, i));
			ProcessState();
		}

		public override void Back()
		{
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].Back();
			ProcessState();
		}

		private void ProcessState()
		{
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].ProcessStateOrder();
			for (var i = 0; i < _controllers.Count; i++)
				_controllers[i].ProcessState();
		}

		public override IUiElement[] GetUiElements()
		{
			var list = new List<IUiElement>();
			for (var i = 0; i < _controllers.Count; i++)
				list.AddRange(_controllers[i].GetUiElements());

			return list.ToArray();
		}
	}

	public abstract class Window<T1> : BaseWindow
		where T1 : IUiController
	{
		[Inject]
		public void Construct(T1 w1)
		{
			InternalConstruct(w1);
		}
	}

	public abstract class Window<T1, T2> : BaseWindow
		where T1 : IUiController
		where T2 : IUiController
	{
		[Inject]
		public void Construct(T1 w1, T2 w2)
		{
			InternalConstruct(w1, w2);
		}
	}

	public abstract class Window<T1, T2, T3> : BaseWindow
		where T1 : IUiController
		where T2 : IUiController
		where T3 : IUiController
	{
		[Inject]
		public void Construct(T1 w1, T2 w2, T3 w3)
		{
			InternalConstruct(w1, w2, w3);
		}
	}

	public abstract class Window<T1, T2, T3, T4> : BaseWindow
		where T1 : IUiController
		where T2 : IUiController
		where T3 : IUiController
		where T4 : IUiController
	{
		[Inject]
		public void Construct(T1 w1, T2 w2, T3 w3, T4 w4)
		{
			InternalConstruct(w1, w2, w3, w4);
		}
	}

	public abstract class Window<T1, T2, T3, T4, T5> : BaseWindow
		where T1 : IUiController
		where T2 : IUiController
		where T3 : IUiController
		where T4 : IUiController
		where T5 : IUiController
	{
		[Inject]
		public void Construct(T1 w1, T2 w2, T3 w3, T4 w4, T5 w5)
		{
			InternalConstruct(w1, w2, w3, w4, w5);
		}
	}
}
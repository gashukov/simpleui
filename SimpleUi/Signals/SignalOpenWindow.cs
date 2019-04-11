using System;

namespace SimpleUi.Signals {
	public class SignalOpenWindow {
		public readonly Type Type;
		public readonly string Name;

		private SignalOpenWindow(Type type) { Type = type; }

		private SignalOpenWindow(string name) { Name = name; }

		public static SignalOpenWindow Build<T>() where T : Window 
			=> new SignalOpenWindow(typeof(T));
		
		public static SignalOpenWindow Build(string name) => new SignalOpenWindow(name);
	}
}
using Example.Controller;
using SimpleUi;
using SimpleUi.Interfaces;

namespace Example {
	public class FirstWindow : Window<FirstController> {
		public override string Name => "First";
	}
	
	public class SecondWindow : Window<SecondController> {
		public override string Name => "Second";
	}
	
	public class ThirdWindow : Window<ThirdController> {
		public override string Name => "Third";
	}
	
	public class FirstPopUpWindow : Window<FirstPopUpController>, IPopUp {
		public override string Name => "FirstPopUp";
	}
	
	public class SecondPopUpWindow : Window<SecondPopUpController>, IPopUp {
		public override string Name => "SecondPopUp";
	}
	
	public class FourthWindow : Window<FourthController, FirstController, SecondController> {
		public override string Name => "Fourth";
	}
	
	public class FifthWindow : Window<FifthController, FirstController, SecondController, ThirdController> {
		public override string Name => "Fifth";
	}
}

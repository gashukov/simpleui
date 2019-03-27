using SimpleUi.Interfaces;

namespace SimpleUi {
	public class FirstWindow : Window<FirstController> {
		public override string Name => "First";
	}
	
	public class SecondWindow : Window<SecondController> {
		public override string Name => "Second";
	}
	
	public class ThirdWindow : Window<ThirdController> {
		public override string Name => "Third";
	}
	
	public class WindowTwoControllers : Window<FirstController, SecondController> {
		public override string Name => "TwoControllers";
	}
	
	public class WindowThreeControllers : Window<FirstController, SecondController, ThirdController> {
		public override string Name => "ThreeControllers";
	}

	public class FirstPopUpWindow : Window<PopUpFirstController>, IPopUp {
		public override string Name => "FirstPopUp";
	}
	
	public class SecondPopUpWindow : Window<PopUpSecondController>, IPopUp {
		public override string Name => "SecondPopUp";
	}
}

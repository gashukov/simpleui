using SimpleUi.Abstracts;

namespace SimpleUi {
	public class FirstController : TestUiController {
		public override int Order => 0;
	}
	
	public class SecondController : TestUiController {
		public override int Order => 1;
	}
	
	public class ThirdController : TestUiController {
		public override int Order => 2;
	}
	
	public class PopUpFirstController : TestUiController {
		public override int Order => 1;
	}
	
	public class PopUpSecondController : TestUiController {
		public override int Order => 2;
	}
}

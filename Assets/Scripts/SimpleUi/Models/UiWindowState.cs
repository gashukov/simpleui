namespace SimpleUi.Models {
	public class UiWindowState {
		public bool IsActive;
		public bool InFocus;
		public UiWindowState(bool isActive, bool inFocus) {
			IsActive = isActive;
			InFocus = inFocus;
		}
	}
}

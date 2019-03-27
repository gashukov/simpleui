using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts {
	public abstract class UiView : MonoBehaviour, IUiView {
		public virtual void Show() => gameObject.SetActive(true);

		public virtual void Hide() => gameObject.SetActive(false);
	}
}

using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts {
	public abstract class UiView : MonoBehaviour, IUiView {
		public virtual void Show() => gameObject.SetActive(true);

		public virtual void Hide() => gameObject.SetActive(false);
		public IUiElement[] GetUiElements() => gameObject.GetComponentsInChildren<IUiElement>();

		public void SetOrder(int index) {
			var parent = transform.parent;
			if (parent == null)
				return;
			var childsCount = parent.childCount - 1;
			transform.SetSiblingIndex(childsCount - index);
		}

		public void SetParent(Transform parent) => transform.SetParent(parent, false);
		public void Destroy() => Destroy(gameObject);
	}
}
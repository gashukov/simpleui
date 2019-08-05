﻿using SimpleUi.Interfaces;
using UnityEngine;

namespace SimpleUi.Abstracts
{
	public abstract class UiView : MonoBehaviour, IUiView
	{
		void IUiView.Show()
		{
			gameObject.SetActive(true);
			OnShow();
		}

		protected virtual void OnShow()
		{
		}

		void IUiView.Hide()
		{
			gameObject.SetActive(false);
			OnHide();
		}

		protected virtual void OnHide()
		{
		}

		void IUiView.SetParent(Transform parent)
		{
			transform.SetParent(parent, false);
		}

		void IUiView.SetOrder(int index)
		{
			var parent = transform.parent;
			if (parent == null)
				return;
			var childsCount = parent.childCount - 1;
			transform.SetSiblingIndex(childsCount - index);
		}

		IUiElement[] IUiView.GetUiElements()
		{
			return gameObject.GetComponentsInChildren<IUiElement>();
		}

		void IUiView.Destroy()
		{
			Destroy(gameObject);
		}
	}
}
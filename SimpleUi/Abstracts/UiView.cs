﻿using SimpleUi.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleUi.Abstracts
{
	public abstract class UiView : UIBehaviour, IUiView
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
			var childCount = parent.childCount - 1;
			transform.SetSiblingIndex(childCount - index);
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
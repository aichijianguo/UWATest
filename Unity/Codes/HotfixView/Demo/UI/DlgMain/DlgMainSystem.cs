using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgMain))]
	public static  class DlgMainSystem
	{

		public static void RegisterUIEvent(this DlgMain self)
		{
			self.View.E_BagButton.AddListener(() =>
			{
				self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Bag);
			});
			
			self.View.E_BattleButton.AddListener(() =>
			{
				self.DomainScene().GetComponent<UIComponent>().GetComponent<DlgBag>().AddItem().Coroutine();
			});
		}

		public static void ShowWindow(this DlgMain self, Entity contextData = null)
		{
		}

		 

	}
}

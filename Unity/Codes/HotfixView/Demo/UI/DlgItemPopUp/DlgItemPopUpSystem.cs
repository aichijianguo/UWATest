using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof(DlgItemPopUp))]
    public static class DlgItemPopUpSystem
    {

        public static void RegisterUIEvent(this DlgItemPopUp self)
        {
            self.View.E_UseButton.AddListenerAsync(self.DeleteItem);
			
            self.RegisterCloseEvent<DlgItemPopUp>(self.View.E_ClouseButton);
			
			
        }

        public static void ShowWindow(this DlgItemPopUp self, Entity contextData = null)
        {
        }

        public static void RefreshInfo(this DlgItemPopUp self, Item item,ItemContainerType type)
        {
            self.View.E_NameText.text = item.Config.Name;
            self.ItemId = item.Id;
            self.View.E_DesText.text = item.Config.Des;
        }

        // public static async ETTask OnSellItemHandle(this DlgItemPopUp self)
        // {
        //     try
        //     {
        //         int errCode = await ItemApplyHelper.SellBagItem(self.ZoneScene(), self.ItemId);
        //
        //         if (errCode != ErrorCode.ERR_Success)
        //         {
        //             Log.Error(errCode.ToString());
        //             return;
        //         }
        //
        //         var uiComponent = self.ZoneScene().GetComponent<UIComponent>();
        //         uiComponent.HideWindow(WindowID.WindowID_ItemPopUp);
        //         uiComponent.GetDlgLogic<DlgBag>().Refresh();
        //     }
        //     catch (Exception e)
        //     {
        //         Log.Error(e.ToString());
        //     }
        // }

        public static async ETTask DeleteItem(this DlgItemPopUp self)
        {
            try
            {
                int errCode = await ItemApplyHelper.DeleteItem(self.ZoneScene(), self.ItemId);

                if (errCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errCode.ToString());
                    return;
                }

                var uiComponent = self.ZoneScene().GetComponent<UIComponent>();
                uiComponent.HideWindow(WindowID.WindowID_ItemPopUp);
                uiComponent.GetDlgLogic<DlgBag>().RefreshItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            
        }

		 

    }
}
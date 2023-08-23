using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgBag))]
    public static class DlgBagSystem
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public static void RegisterUIEvent(this DlgBag self)
        {
            self.RegisterCloseEvent<DlgBag>(self.View.E_CloseButton);

            self.View.EButAButton.AddListener(() => { self.OnTopToggleSelectedHnadler(0); });
            self.View.EButBButton.AddListener(() => { self.OnTopToggleSelectedHnadler(1); });
            self.View.EButCButton.AddListener(() => { self.OnTopToggleSelectedHnadler(2); });
            self.View.EButDButton.AddListener(() => { self.OnTopToggleSelectedHnadler(3); });
            self.View.EButEButton.AddListener(() => { self.OnTopToggleSelectedHnadler(4); });
            self.View.EButFButton.AddListener(() => { self.OnTopToggleSelectedHnadler(5); });
            self.View.EButAllButton.AddListener(() => { self.OnTopToggleSelectedHnadler(6); });

            self.View.E_AddButton.AddListenerAsync(self.AddItem);

            self.View.E_ExpendButton.AddListenerAsync(self.AddBagGrid);

            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.onLoopItemRefreshHandler);
        }

        public static void ShowWindow(this DlgBag self, Entity contextData = null)
        {
            //self.View.E_WeaponToggle.IsSelected(true);
            self.OnTopToggleSelectedHnadler(6);
            var count = self.ZoneScene().GetComponent<BagComponent>().ItemDic.Count.ToString();

            Log.Error($"当前背包道具数量{count}");
        }

        public static void HideWindow(this DlgBag self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemBagItems);
        }

        public static void OnTopToggleSelectedHnadler(this DlgBag self, int index)
        {
            self.CUrrentItemType = (ItemType)index;
            self.RefreshItems();
        }

        public static void RefreshItems(this DlgBag self)
        {
            var bagComponent = self.ZoneScene().GetComponent<BagComponent>();
            List<Item> itemListTmp = new();
            if ((int)self.CUrrentItemType == 6)
            {
                itemListTmp = bagComponent.ItemDic.Values.ToList();
            }
            else
            {
                bagComponent.ItemsMap.TryGetValue((int)self.CUrrentItemType, out List<Item> itemList);
                itemListTmp = itemList;
            }

            if (itemListTmp == null)
            {
                foreach (var scrollItemBagItem in self.ScrollItemBagItems.Values)
                {
                    scrollItemBagItem.IsShowImg(false);
                }
                return;
            }
            var count = self.ZoneScene().GetComponent<BagComponent>().BagCount;
            self.AddUIScrollItems(ref self.ScrollItemBagItems, count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void onLoopItemRefreshHandler(this DlgBag self, Transform transform, int index)
        {
            var bagComponent = self.ZoneScene().GetComponent<BagComponent>();
            List<Item> itemListTmp = new();
            if ((int)self.CUrrentItemType == 6)
            {
                itemListTmp = bagComponent.ItemDic.Values.ToList();
            }
            else
            {
                bagComponent.ItemsMap.TryGetValue((int)self.CUrrentItemType, out List<Item> itemList);
                itemListTmp = itemList;
            }

            if (itemListTmp == null)
                return;
            Scroll_Item_bagItem scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);
            if (index >= itemListTmp.Count)
            {
                scrollItemBagItem.IsShowImg(false);
                return;
            }

            scrollItemBagItem.Refresh(itemListTmp[index].Id);
        }

        public static async ETTask AddItem(this DlgBag self)
        {
            await BagComponentSystemHelper.AddItem(self.ZoneScene());
            self.RefreshItems();
        }

        public static async ETTask AddBagGrid(this DlgBag self)
        {
            var count = self.ZoneScene().GetComponent<BagComponent>().BagCount;
            var preCount = count;
            var nextCount = count + 5;

            var success = await self.AddBagGridRequest(nextCount);

            if (success != ErrorCode.ERR_Success)
            {
                Log.Error(success.ToString());
                return;
            }

            self.ZoneScene().GetComponent<BagComponent>().BagCount += 5;
            self.RefreshItems();

            Log.Error($"扩充各自完毕：扩充前共{preCount}个  扩充后共{nextCount}个");
        }

        private static async ETTask<int> AddBagGridRequest(this DlgBag self, int count)
        {
            M2C_AddBagGrid m2CAddBagGrid = null;
            try
            {
                m2CAddBagGrid = (M2C_AddBagGrid)await self.ZoneScene().GetComponent<SessionComponent>().Session
                        .Call(new C2M_AddBagGrid() { BagGridCount = count });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return m2CAddBagGrid.Error;
        }
    }
}
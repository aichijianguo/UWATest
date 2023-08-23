using System;
using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public class BagComponentDeserializeSystem: DeserializeSystem<BagComponent>
    {
        public override void Deserialize(BagComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                self.AddContainer(entity as Item);
            }
        }
    }

    public static class BagComponentSystem
    {
        public static bool IsMaxLoad(this BagComponent self, Item item)
        {
            int Grid = 0;
            var list = self.ItemsMap.Values.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Grid += list[i].Count;
            }

            //(1)格子没满
            if (Grid < self.BagCount)
            {
                return false;
            }

            //（2）格子满了
            //2.1 mintype相同且叠加数量够
            if (self.ItemsMap.TryGetValue(item.Config.Type, out List<Item> itemList))
            {
                foreach (var itemTmp in itemList)
                {
                    if (itemTmp.Config.MinType == item.Config.MinType)
                    {
                        return !(itemTmp.Count < self.ItemMaxCount);
                    }
                }
            }
            else
            {
                //2.2不同则判断格子满没满则不能添加 

                return !(Grid < self.BagCount);
            }

            return true;
        }

        public static bool IsItemExist(this BagComponent self, long itemId)
        {
            self.ItemDic.TryGetValue(itemId, out Item item);

            return item != null && !item.IsDisposed;
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            self.ItemDic.TryGetValue(itemId, out Item item);
            return item;
        }

        public static bool AddContainer(this BagComponent self, Item item)
        {
            if (self.ItemDic.ContainsKey(item.Id))
            {
                return false;
            }

            if (!self.ItemsMap.TryGetValue(item.Config.Type, out List<Item> itemList))
            {
                item.Count = 1;
                self.ItemDic.Add(item.Id, item);
                self.ItemsMap.Add(item.Config.Type, new List<Item> { item });
                return true;
            }

            foreach (var tempItem in itemList)
            {
                if (tempItem.Config.MinType == item.Config.MinType)
                {
                    if (tempItem.Count < self.ItemMaxCount)
                    {
                        tempItem.Count++;
                        self.ItemDic[tempItem.Id] = tempItem;
                        return true;
                    }

                    break;
                }
            }

            item.Count = 1;
            self.ItemDic.Add(item.Id, item);
            self.ItemsMap[item.Config.Type].Add(item);
            return true;
        }

        public static bool DeledeItem(this BagComponent self, Item item, int count = 1)
        {
            if (!self.ItemsMap.TryGetValue(item.Config.Type, out List<Item> itemList))
            {
                return false;
            }

            for (int index = 0; index < itemList.Count; index++)
            {
                Item tempItem = itemList[index];
                if (self.ItemMaxCount > 1)
                {
                    if (tempItem.Config.MinType == item.Config.MinType)
                    {
                        tempItem.Count--;
                        if (tempItem.Count == 0)
                        {
                            self.RemoveItem(tempItem);
                            return true;
                        }
                        else
                        {
                            self.ItemDic[tempItem.Id] = tempItem;
                            ItemUpdateNoticeHelper.SyncDeleteItem(self.GetParent<Unit>(), item, self.message);
                        }

                        return true;
                    }
                }
                else
                {
                    self.RemoveItem(tempItem);
                    // ItemUpdateNoticeHelper.SyncDeleteItem(self.GetParent<Unit>(), item, self.message);
                    return true;
                }
            }

            return false;
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            item.Dispose();
        }

        public static Item RemodeItemNoDispose(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            return item;
        }

        private static void RemoveContainer(this BagComponent self, Item item)
        {
            self.ItemDic.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
        }

        public static bool AddItemByConfigId(this BagComponent self, int configId, int count = 1)
        {
            if (!ItemConfigCategory.Instance.Contain(configId))
            {
                return false;
            }

            if (count < 0) return false;

            for (int i = 0; i < count; i++)
            {
                var newItem = ItemFactory.Create(self, configId);
                if (!self.AddItem(newItem))
                {
                    Log.Error("添加物品失败");
                    newItem?.Dispose();
                    return false;
                }
            }

            return true;
        }

        public static bool AddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                Log.Error("item is null! ");
                return false;
            }

            if (self.IsMaxLoad(item))
            {
                Log.Error("bag is IsMaxLoad ! ");
                return false;
            }

            if (!self.AddContainer(item))
            {
                Log.Error("Add Container is Error!");
                return false;
            }

            if (item.Parent != self)
            {
                self.AddChild(item);
            }

            ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, self.message);

            return true;
        }
    }
}
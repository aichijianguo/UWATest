using System.Collections.Generic;

namespace ET
{
    public  static class BagComponentSystem
    {
        public static void Clear(this BagComponent self)
        {
            foreach (var value in self.ItemDic.Values)
            {
                value?.Dispose();
            }

            self?.ItemDic.Clear();
            self.ItemsMap.Clear();
        }
        
        public static bool AddItem(this BagComponent self, Item item)
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

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item != null)
            {
                self.ItemDic.Remove(item.Id);
                self.ItemsMap.Remove(item.Config.Type, item);
                item?.Dispose();
            }
        }
        
        public static void DeleteItem(this BagComponent self, Item item)
        {
            if (self.ItemsMap.TryGetValue(item.Config.Type, out List<Item> itemList))
            {
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
                                //self.RemoveItem(tempItem);
                            }
                            else
                            {
                                self.ItemDic[tempItem.Id] = tempItem;
                            }
                        }
                    }
                    else
                    {
                        self.RemoveItem(tempItem);
                    }

                }
            }
            
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            if (self.ItemDic.ContainsKey(itemId))
            {
                return self.ItemDic[itemId];
            }

            return null;
        }
        
    }
}
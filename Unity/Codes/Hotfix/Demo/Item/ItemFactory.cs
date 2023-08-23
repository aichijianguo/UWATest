using System;

namespace ET
{
    public static class ItemFactory
    {
        public static Item Create(Entity self, ItemInfo itemInfo)
        {
            var item = self.AddChild<Item, Int32>(itemInfo.ItemConfigId);
            item?.FromMessage(itemInfo);
            return item;

        }
    }
}
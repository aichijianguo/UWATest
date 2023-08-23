using System;

namespace ET
{
    public static class ItemFactory
    {
        public static Item Create(Entity parent, int configId)
        {
            if(!ItemConfigCategory.Instance.Contain(configId))
            {
                Log.Error($"当前所创建的物品id不存在{configId}");
                return null;
            }

            var item = parent.AddChild<Item, Int32>(configId);
            
            return item;
        }

        public static void AddComponentByItemType(Item item)
        {
            switch ((ItemType)item.Config.Type)
            {
                case ItemType.A:
                    //item.AddComponent<>()
                    break;
            }
        }
    }
}
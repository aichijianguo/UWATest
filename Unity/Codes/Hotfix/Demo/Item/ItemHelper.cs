using System.ComponentModel.Design;

namespace ET
{
    public static class ItemHelper
    {

        public static void Clear(Scene zoneScence, ItemContainerType op)
        {
            if (op == ItemContainerType.Bag)
            {
                zoneScence?.GetComponent<BagComponent>()?.Clear();
            }
        }
        public static void AddItem(Scene zoneScence, Item item, ItemContainerType type)
        {
            if (type == ItemContainerType.Bag)
            {
                zoneScence.GetComponent<BagComponent>().AddItem(item);
            }
        }
        public static Item GetItem(Scene zoneScence, long itemId, ItemContainerType type)
        {
            if (type == ItemContainerType.Bag)
            {
                return zoneScence.GetComponent<BagComponent>().GetItemById(itemId);
            }

            return null;
        }

        public static void RemodeItemById(Scene zoneScence, long itemId, ItemContainerType type)
        {
            var item = GetItem(zoneScence, itemId, type);

            if (type == ItemContainerType.Bag)
            {
                zoneScence.GetComponent<BagComponent>().RemoveItem(item);
            }
        }

        public static void DeledeItem(Scene zoneScence, long itemId, ItemContainerType type)
        {
            var item = GetItem(zoneScence, itemId, type);
            
            if (type == ItemContainerType.Bag)
            {
                zoneScence.GetComponent<BagComponent>().DeleteItem(item);
            }
        }
    }
}
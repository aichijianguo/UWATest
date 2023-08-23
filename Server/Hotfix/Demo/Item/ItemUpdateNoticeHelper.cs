namespace ET
{
    public static class ItemUpdateNoticeHelper
    {
        public static void SyncAddItem(Unit unit, Item item, M2C_ItemUpdateOpInfo message)
        {
            message.ItemInfo = item.ToMessage();
            message.op = (int)ItemOperation.Add;
            MessageHelper.SendToClient(unit,message);
        }

        public static void SyncRemoveItem(Unit unit, Item item, M2C_ItemUpdateOpInfo message)
        {
            message.ItemInfo = item.ToMessage(false);
            message.op = (int)ItemOperation.Rmove;
            MessageHelper.SendToClient(unit,message);
        }

        public static void SyncDeleteItem(Unit unit, Item item, M2C_ItemUpdateOpInfo message)
        {
            message.ItemInfo = item.ToMessage(false);
            message.op = (int)ItemOperation.Delete;
            MessageHelper.SendToClient(unit,message);
        }
        
        public static void SyncAllBagItems(Unit unit)
        {
            var m2cAddItemList=  new M2C_AllItemList() { containerType = (int)ItemContainerType.Bag };
            var bagComponet = unit.GetComponent<BagComponent>();

            foreach (var item in bagComponet.ItemDic.Values)
            {
                m2cAddItemList.ItemInfoList.Add(item.ToMessage());
            }
          
            MessageHelper.SendToClient(unit,m2cAddItemList);
        }
        
        
    }
}
using System;

namespace ET
{
    public static class ItemApplyHelper
    {
        public static async ETTask<int> SellBagItem(Scene zoneScence, long itemId)
        {
            var item = ItemHelper.GetItem(zoneScence, itemId, ItemContainerType.Bag);
            if (item == null) return ErrorCode.ERR_ItemNotExist;
            M2C_SellItem m2CSellItem = null;
            try
            {

                m2CSellItem = (M2C_SellItem)await zoneScence.GetComponent<SessionComponent>().Session.Call(new C2M_SellItem() { ItemUid = itemId });
                
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return m2CSellItem.Error;
        }
        
        public static async ETTask<int> DeleteItem(Scene zoneScence, long itemId)
        {
            var item = ItemHelper.GetItem(zoneScence, itemId, ItemContainerType.Bag);
            if (item == null) return ErrorCode.ERR_ItemNotExist;
            M2C_DeleteItem m2CSellItem = null;
            try
            {

                m2CSellItem = (M2C_DeleteItem)await zoneScence.GetComponent<SessionComponent>().Session.Call(new C2M_DeleteItem() { ItemUid = itemId });
                
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return m2CSellItem.Error;
        }
    }
}
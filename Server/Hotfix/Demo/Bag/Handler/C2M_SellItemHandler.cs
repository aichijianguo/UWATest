﻿using System;

namespace ET
{
    public class C2M_SellItemHandler:AMActorLocationRpcHandler<Unit,C2M_SellItem,M2C_SellItem>
    {
        protected override async ETTask Run(Unit unit, C2M_SellItem request, M2C_SellItem response, Action reply)
        {
            var bagComponent = unit.GetComponent<BagComponent>();
            if (!bagComponent.IsItemExist(request.ItemUid))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                reply();
                return;
            }

            var bagItem = bagComponent.GetItemById(request.ItemUid);

            //bagComponent.RemoveItem(bagItem);
            
            reply();
            
            await ETTask.CompletedTask;
        }
    }
}
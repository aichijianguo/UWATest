using System;

namespace ET
{
    public class C2M_DeleteItemHandler: AMActorLocationRpcHandler<Unit, C2M_DeleteItem, M2C_DeleteItem>
    {
        protected override async ETTask Run(Unit unit, C2M_DeleteItem request, M2C_DeleteItem response, Action reply)
        {
            var bagComponent = unit.GetComponent<BagComponent>();
            if (!bagComponent.IsItemExist(request.ItemUid))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                reply();
                return;
            }

            var bagItem = bagComponent.GetItemById(request.ItemUid);

            var success = bagComponent.DeledeItem(bagItem);
            
            response.Error = success? ErrorCode.ERR_Success : ErrorCode.ERR_ItemNotExist;

            reply();

            await ETTask.CompletedTask;
        }
    }
}
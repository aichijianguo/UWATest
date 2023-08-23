using System;

namespace ET
{
    public class C2M_AddItemHandler:AMActorLocationRpcHandler<Unit,C2M_AddItem,M2C_AddItem>
    {
        protected override async ETTask Run(Unit unit, C2M_AddItem request, M2C_AddItem response, Action reply)
        {
            var bagComponent = unit.GetComponent<BagComponent>();
            
            for (int i = 0; i < 100; i++)
            {
                bagComponent.AddItemByConfigId(RandomHelper.RandomNumber(1000, 1035));
                //bagComponent.AddItemByConfigId(1000);
            }

            response.Error = ErrorCode.ERR_Success;
            
            reply();
            
            await ETTask.CompletedTask;
            
        }
    }
}
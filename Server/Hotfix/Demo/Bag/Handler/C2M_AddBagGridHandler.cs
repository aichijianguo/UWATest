using System;

namespace ET
{
    public class C2M_AddBagGridHandler: AMActorLocationRpcHandler<Unit, C2M_AddBagGrid, M2C_AddBagGrid>
    {
        protected override async ETTask Run(Unit unit, C2M_AddBagGrid request, M2C_AddBagGrid response, Action reply)
        {
            var bagComponent = unit.GetComponent<BagComponent>();

            bagComponent.BagCount = request.BagGridCount;

            response.Error = ErrorCode.ERR_Success;

            reply();

            await ETTask.CompletedTask;
        }
    }
}
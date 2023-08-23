using System;
namespace ET
{
    public class BagComponentSystemHelper
    {
        public static async ETTask<int> AddItem(Scene zoneScence)
        {
            M2C_AddItem m2CAddItem = null;
            try
            {
                m2CAddItem = (M2C_AddItem)await zoneScence.GetComponent<SessionComponent>().Session.Call(new C2M_AddItem() {  });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return m2CAddItem.Error;
        }
    }
}
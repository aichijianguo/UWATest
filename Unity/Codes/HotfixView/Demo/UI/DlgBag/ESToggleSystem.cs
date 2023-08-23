using UnityEngine.Events;

namespace ET
{
    public static class ESToggleSystem
    {
        public static void BingAct(this ESToggle self, UnityAction action)
        {
            self.Action=action;
        }
    }
}
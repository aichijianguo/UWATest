using UnityEngine.Events;

namespace ET
{
    public static class Scroll_ItemToggleSystem
    {
        public static void BingAct(this Scroll_ItemToggle self, UnityAction action)
        {
            self.Action = action;
        }
    }
}
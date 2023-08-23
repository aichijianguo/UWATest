using ET.EventType;

namespace ET
{
    public class EnterMapFinishLoadingUI: AEvent<EventType.EnterMapFinish>
    {
        protected override void Run(EnterMapFinish a)
        {
            //a.ZoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
        }
    }
}
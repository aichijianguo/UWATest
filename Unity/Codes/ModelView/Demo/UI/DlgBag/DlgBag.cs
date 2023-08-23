using System.Collections.Generic;

namespace ET
{
    public  class DlgBag :Entity,IAwake,IUILogic
    {

        public DlgBagViewComponent View { get => this.Parent.GetComponent<DlgBagViewComponent>();}

        public Dictionary<int, Scroll_Item_bagItem> ScrollItemBagItems;

        public List<Scroll_ItemToggle> ToggleLise = new();

        public ItemType CUrrentItemType;

    }
}
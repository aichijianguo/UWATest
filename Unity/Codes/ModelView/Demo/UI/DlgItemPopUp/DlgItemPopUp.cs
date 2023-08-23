using System.Collections.Generic;

namespace ET
{
    public  class DlgItemPopUp :Entity,IAwake,IUILogic
    {

        public DlgItemPopUpViewComponent View { get => this.Parent.GetComponent<DlgItemPopUpViewComponent>();}

        //public Dictionary<int,scroite>
        public long ItemId;

        public ItemContainerType ItemContainerType = ItemContainerType.Bag;
    }
}
namespace ET
{
    public static class Scroll_Item_bagItemSystem
    {
        public static void Refresh(this Scroll_Item_bagItem self, long id)
        {
            self.IsShowImg(true);
            var item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(id);
            
            self.E_ItemNameText.text = item.Config.Name.ToString();
            self.E_CountText.text = item.Count.ToString();
            self.E_SelectButton.AddListenerWithId(self.OnShowItemEntryPopUpHandler,id);
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_bagItem self, long id)
        {
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ItemPopUp);
            
            var item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(id);
            
            self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgItemPopUp>().RefreshInfo(item,ItemContainerType.Bag);
            
        }

        public static void IsShowImg(this  Scroll_Item_bagItem self,bool show=false)
        {
            if(self.uiTransform == null)return;
            self.E_CountText.text = "Null";
            self.E_IconImage.gameObject.SetActive(show);
            self.E_ItemNameText.gameObject.SetActive(show);
            self.E_SelectButton.gameObject.SetActive(show);
            
        }
        
    }
}
namespace ET
{
    public class ItemAwakeSystem:AwakeSystem<Item,int>
    {
        public override void Awake(Item self, int a)
        {
            self.ConfigId = a;
        }
    }

    public class ItemDestorySystem: DestroySystem<Item>
    {
        public override void Destroy(Item self)
        {
            self.Quality = 0;
            self.ConfigId = 0;
        }
    }
    
    public static class ItemSystem
    {
        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.Id = itemInfo.ItemUid;
            self.ConfigId = itemInfo.ItemConfigId;
            self.Quality = itemInfo.ItemQuality;
            self.Count = itemInfo.ItemCount;

        }
    }
}
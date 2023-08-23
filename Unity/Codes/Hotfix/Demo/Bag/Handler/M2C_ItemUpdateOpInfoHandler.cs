namespace ET
{
    public class M2C_ItemUpdateOpInfoHandler: AMHandler<M2C_ItemUpdateOpInfo>
    {
        protected override void Run(Session session, M2C_ItemUpdateOpInfo message)
        {
            var opId = (ItemOperation)message.op;
            var item = ItemFactory.Create(session.ZoneScene(), message.ItemInfo);
            switch (opId)
            {
                case ItemOperation.Add:
                    ItemHelper.AddItem(session.ZoneScene(),item,(ItemContainerType)message.ContainerType);
                    break;
                case ItemOperation.Rmove:
                    ItemHelper.RemodeItemById(session.ZoneScene(),item.Id,(ItemContainerType)message.ContainerType);
                    break;
                case ItemOperation.Delete:
                    ItemHelper.DeledeItem(session.ZoneScene(),item.Id,(ItemContainerType)message.ContainerType);
                    break;
            }
        }
    }
}
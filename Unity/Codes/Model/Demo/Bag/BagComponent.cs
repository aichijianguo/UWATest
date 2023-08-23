using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
#if SERVER
    public class BagComponent:Entity,IAwake,IDestroy,IDeserialize,ITransfer
#else
    [ComponentOf(typeof (Scene))]
    public class BagComponent: Entity, IAwake, IDestroy
#endif

    {
        //        [BsonIgnore]的目的是序列化反序列化时候被忽略掉 不会存储到缓存夫 落地到数据库
#if SERVER
        [BsonIgnore]
#endif
        public Dictionary<long, Item> ItemDic = new Dictionary<long, Item>();
#if SERVER
        [BsonIgnore]
#endif
        public MultiMap<int, Item> ItemsMap = new MultiMap<int, Item>();

        //public Dictionary<int, Dictionary<int, int>> ItemDicMap = new Dictionary<int, Dictionary<int, int>>();

        public int BagCount = 25;

        public int ItemMaxCount = 999;

#if SERVER
[BsonIgnore]
        public M2C_ItemUpdateOpInfo message = new M2C_ItemUpdateOpInfo() { ContainerType = (int)ItemContainerType.Bag};
#endif
    }
}
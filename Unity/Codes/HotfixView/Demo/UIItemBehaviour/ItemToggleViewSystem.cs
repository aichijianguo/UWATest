
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_ItemToggleDestroySystem : DestroySystem<Scroll_ItemToggle> 
	{
		public override void Destroy( Scroll_ItemToggle self )
		{
			self.DestroyWidget();
		}
	}
}

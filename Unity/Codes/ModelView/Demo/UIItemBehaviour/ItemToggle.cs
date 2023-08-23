
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_ItemToggle : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public UnityAction Action;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_ItemToggle BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EBackgroundImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EBackgroundImage == null )
     				{
		    			this.m_EBackgroundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBackground");
     				}
     				return this.m_EBackgroundImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBackground");
     			}
     		}
     	}

		public UnityEngine.UI.Text ETextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_ETextText == null )
     				{
		    			this.m_ETextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText");
     				}
     				return this.m_ETextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBackgroundImage = null;
			this.m_ETextText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EBackgroundImage = null;
		private UnityEngine.UI.Text m_ETextText = null;
		public Transform uiTransform = null;
	}
}

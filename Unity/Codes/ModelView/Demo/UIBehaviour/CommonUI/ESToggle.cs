
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESToggle : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy, IAwake
	{
		public UnityEngine.UI.Image EBackgroundImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBackgroundImage == null )
     			{
		    		this.m_EBackgroundImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBackground");
     			}
     			return this.m_EBackgroundImage;
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
     			if( this.m_ETextText == null )
     			{
		    		this.m_ETextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText");
     			}
     			return this.m_ETextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBackgroundImage = null;
			this.m_ETextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EBackgroundImage = null;
		private UnityEngine.UI.Text m_ETextText = null;
		public Transform uiTransform = null;

		public UnityAction Action;
	}
}

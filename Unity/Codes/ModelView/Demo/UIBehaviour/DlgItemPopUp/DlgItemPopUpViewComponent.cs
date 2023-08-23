
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgItemPopUpViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"igmBg/E_Icon");
     			}
     			return this.m_E_IconImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameText == null )
     			{
		    		this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"igmBg/E_Icon/E_Name");
     			}
     			return this.m_E_NameText;
     		}
     	}

		public UnityEngine.UI.Button E_UseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseButton == null )
     			{
		    		this.m_E_UseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"igmBg/E_Use");
     			}
     			return this.m_E_UseButton;
     		}
     	}

		public UnityEngine.UI.Image E_UseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UseImage == null )
     			{
		    		this.m_E_UseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"igmBg/E_Use");
     			}
     			return this.m_E_UseImage;
     		}
     	}

		public UnityEngine.UI.Button E_ClouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClouseButton == null )
     			{
		    		this.m_E_ClouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"igmBg/E_Clouse");
     			}
     			return this.m_E_ClouseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ClouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClouseImage == null )
     			{
		    		this.m_E_ClouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"igmBg/E_Clouse");
     			}
     			return this.m_E_ClouseImage;
     		}
     	}

		public UnityEngine.UI.Text E_DesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DesText == null )
     			{
		    		this.m_E_DesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"igmBg/E_Des");
     			}
     			return this.m_E_DesText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImage = null;
			this.m_E_NameText = null;
			this.m_E_UseButton = null;
			this.m_E_UseImage = null;
			this.m_E_ClouseButton = null;
			this.m_E_ClouseImage = null;
			this.m_E_DesText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		private UnityEngine.UI.Button m_E_UseButton = null;
		private UnityEngine.UI.Image m_E_UseImage = null;
		private UnityEngine.UI.Button m_E_ClouseButton = null;
		private UnityEngine.UI.Image m_E_ClouseImage = null;
		private UnityEngine.UI.Text m_E_DesText = null;
		public Transform uiTransform = null;
	}
}

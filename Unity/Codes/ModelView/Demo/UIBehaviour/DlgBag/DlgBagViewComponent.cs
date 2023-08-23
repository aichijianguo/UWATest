
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgBagViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.ToggleGroup E_TopButtonToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TopButtonToggleGroup == null )
     			{
		    		this.m_E_TopButtonToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"BackGround/E_TopButton");
     			}
     			return this.m_E_TopButtonToggleGroup;
     		}
     	}

		public UnityEngine.UI.Button EButAButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButAButton == null )
     			{
		    		this.m_EButAButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButA");
     			}
     			return this.m_EButAButton;
     		}
     	}

		public UnityEngine.UI.Button EButBButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButBButton == null )
     			{
		    		this.m_EButBButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButB");
     			}
     			return this.m_EButBButton;
     		}
     	}

		public UnityEngine.UI.Button EButCButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButCButton == null )
     			{
		    		this.m_EButCButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButC");
     			}
     			return this.m_EButCButton;
     		}
     	}

		public UnityEngine.UI.Button EButDButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButDButton == null )
     			{
		    		this.m_EButDButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButD");
     			}
     			return this.m_EButDButton;
     		}
     	}

		public UnityEngine.UI.Button EButEButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButEButton == null )
     			{
		    		this.m_EButEButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButE");
     			}
     			return this.m_EButEButton;
     		}
     	}

		public UnityEngine.UI.Button EButFButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButFButton == null )
     			{
		    		this.m_EButFButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButF");
     			}
     			return this.m_EButFButton;
     		}
     	}

		public UnityEngine.UI.Button EButAllButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButAllButton == null )
     			{
		    		this.m_EButAllButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_TopButton/EButAll");
     			}
     			return this.m_EButAllButton;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGround/ContentBackGround/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_ExpendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpendButton == null )
     			{
		    		this.m_E_ExpendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/Bottom/E_Expend");
     			}
     			return this.m_E_ExpendButton;
     		}
     	}

		public UnityEngine.UI.Image E_ExpendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpendImage == null )
     			{
		    		this.m_E_ExpendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/Bottom/E_Expend");
     			}
     			return this.m_E_ExpendImage;
     		}
     	}

		public UnityEngine.UI.Text E_PageText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PageText == null )
     			{
		    		this.m_E_PageText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGround/Bottom/E_Page");
     			}
     			return this.m_E_PageText;
     		}
     	}

		public UnityEngine.UI.Button E_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddButton == null )
     			{
		    		this.m_E_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/Bottom/E_Add");
     			}
     			return this.m_E_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddImage == null )
     			{
		    		this.m_E_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/Bottom/E_Add");
     			}
     			return this.m_E_AddImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TopButtonToggleGroup = null;
			this.m_EButAButton = null;
			this.m_EButBButton = null;
			this.m_EButCButton = null;
			this.m_EButDButton = null;
			this.m_EButEButton = null;
			this.m_EButFButton = null;
			this.m_EButAllButton = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_ExpendButton = null;
			this.m_E_ExpendImage = null;
			this.m_E_PageText = null;
			this.m_E_AddButton = null;
			this.m_E_AddImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_TopButtonToggleGroup = null;
		private UnityEngine.UI.Button m_EButAButton = null;
		private UnityEngine.UI.Button m_EButBButton = null;
		private UnityEngine.UI.Button m_EButCButton = null;
		private UnityEngine.UI.Button m_EButDButton = null;
		private UnityEngine.UI.Button m_EButEButton = null;
		private UnityEngine.UI.Button m_EButFButton = null;
		private UnityEngine.UI.Button m_EButAllButton = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.Button m_E_ExpendButton = null;
		private UnityEngine.UI.Image m_E_ExpendImage = null;
		private UnityEngine.UI.Text m_E_PageText = null;
		private UnityEngine.UI.Button m_E_AddButton = null;
		private UnityEngine.UI.Image m_E_AddImage = null;
		public Transform uiTransform = null;
	}
}

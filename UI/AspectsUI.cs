using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using WeaponAspects.Weapons;

namespace WeaponAspects.UI
{
	internal class AspectsUI : UIState
	{
		UIPanel BackgroundPanel = new UIPanel();
		UIPanel Panel1 = new UIPanel();
		UIPanel Panel2 = new UIPanel();
		UIPanel Panel3 = new UIPanel();
		UIPanel Panel4 = new UIPanel();
		UIImage Sprite = new UIImage(Main.itemTexture[Main.LocalPlayer.HeldItem.type]);
		UIText Text1 = new UIText("");
		UIText Text2 = new UIText("");
		UIText Text3 = new UIText("");
		UIText Text4 = new UIText("");
		public bool[] UnlockedAspect = new bool[4];
		public Item WeaponWithAspect;
		public int[] WeaponType = new int[4];
		public bool DontConvertMultipleWeapons;

		public override void OnInitialize()
		{
			BackgroundPanel.Height.Set(540, 0);
			BackgroundPanel.Width.Set(760, 0);
			BackgroundPanel.HAlign = 0.5f;
			BackgroundPanel.VAlign = 0.5f;
			BackgroundPanel.Top.Set(0f, 0f);
			BackgroundPanel.BackgroundColor = new Color(30, 30, 30, 200);
			Append(BackgroundPanel);

			Sprite.Width.Set(0, 0);
			Sprite.Height.Set(0, 0);
			Sprite.HAlign = 0.01f;
			Sprite.VAlign = 0.01f;
			BackgroundPanel.Append(Sprite);

			Panel4.Height.Set(95, 0);
			Panel4.Width.Set(760, 0);
			Panel4.HAlign = 0.5f;
			Panel4.VAlign = 0.97f;
			Panel4.Top.Set(0f, 0f);
			Panel4.OnClick += (OnPanel4);
			Panel4.BackgroundColor = new Color(20, 20, 20, 150);
			BackgroundPanel.Append(Panel4);

			Panel3.Height.Set(95, 0);
			Panel3.Width.Set(760, 0);
			Panel3.HAlign = 0.5f;
			Panel3.VAlign = 0.72f;
			Panel3.Top.Set(0f, 0f);
			Panel3.OnClick += (OnPanel3);
			Panel3.BackgroundColor = new Color(20, 20, 20, 150);
			BackgroundPanel.Append(Panel3);

			Panel2.Height.Set(95, 0);
			Panel2.Width.Set(760, 0);
			Panel2.HAlign = 0.5f;
			Panel2.VAlign = 0.47f;
			Panel2.Top.Set(0f, 0f);
			Panel2.OnClick += (OnPanel2);
			Panel2.BackgroundColor = new Color(20, 20, 20, 150);
			BackgroundPanel.Append(Panel2);

			Panel1.Height.Set(95, 0);
			Panel1.Width.Set(760, 0);
			Panel1.HAlign = 0.5f;
			Panel1.VAlign = 0.22f;
			Panel1.Top.Set(0f, 0f);
			Panel1.OnClick += (OnPanel1);
			Panel1.BackgroundColor = new Color(20, 20, 20, 150);
			BackgroundPanel.Append(Panel1);

			Text4.HAlign = 0.01f;
			Text4.VAlign = 0.05f;
			Text4.Height.Set(0, 0);
			Text4.Width.Set(0, 0);
			Panel4.Append(Text4);

			Text3.HAlign = 0.01f;
			Text3.VAlign = 0.05f;
			Text3.Height.Set(0, 0);
			Text3.Width.Set(0, 0);
			Panel3.Append(Text3);

			Text2.HAlign = 0.01f;
			Text2.VAlign = 0.05f;
			Text2.Height.Set(0, 0);
			Text2.Width.Set(0, 0);
			Panel2.Append(Text2);

			Text1.HAlign = 0.01f;
			Text1.VAlign = 0.05f;
			Text1.Height.Set(0, 0);
			Text1.Width.Set(0, 0);
			Panel1.Append(Text1);
		}
		public override void Update(GameTime gameTime)
		{
			if (BackgroundPanel.IsMouseHovering)
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			AspectsPlayer aspectsPlayer = Main.LocalPlayer.GetModPlayer<AspectsPlayer>();
			Sprite.SetImage(Main.itemTexture[Main.LocalPlayer.HeldItem.type]);
			UnlockedAspect[0] = false;
			UnlockedAspect[1] = false;
			UnlockedAspect[2] = false;
			UnlockedAspect[3] = false;
			switch (Main.LocalPlayer.HeldItem.Name) {
				case ("Ice Blade"):
					Text1.SetText("Aspect of Ice");
					WeaponType[0] = 724;
					UnlockedAspect[0] = true;
					if (aspectsPlayer.IceBlade[0] == 1)
					{
						Text2.SetText("Aspect of Permafrost\nSwinging the blade creates a small blizzard around you");
						UnlockedAspect[1] = true;
						WeaponType[1] = ModContent.ItemType<IceBladePermafrost>();
					}
					else
						Text2.SetText("Aspect of ???");
					if (aspectsPlayer.IceBlade[1] == 1)
					{
						Text3.SetText("Aspect of Icicles\nYou can throw the blade with Right-Click, although swinging it no longer shoots icy bolts.");
						UnlockedAspect[2] = true;
					}
					else
						Text3.SetText("Aspect of ???");
					if (aspectsPlayer.IceBlade[2] == 1)
					{
						Text4.SetText("Aspect of ???");
						UnlockedAspect[3] = true;
					}
					else
						Text4.SetText("Aspect of ???");
					break;
			}
		}
		private void OnPanel1(UIMouseEvent evt, UIElement listeningElement)
		{
			if (UnlockedAspect[0] == true)
			{
				for (int i = 0; i < 58; i++)
				{
					if (Main.LocalPlayer.inventory[i] == Main.LocalPlayer.HeldItem && !DontConvertMultipleWeapons)
					{
						Main.LocalPlayer.inventory[i].netDefaults(WeaponType[0]);
						DontConvertMultipleWeapons = true;
					}
				}
				DontConvertMultipleWeapons = false;
			}
		}
		private void OnPanel2(UIMouseEvent evt, UIElement listeningElement)
		{
			if (UnlockedAspect[1] == true)
			{
				for (int i = 0; i < 58; i++)
				{
					if (Main.LocalPlayer.inventory[i] == Main.LocalPlayer.HeldItem && !DontConvertMultipleWeapons)
					{
						Main.LocalPlayer.inventory[i].netDefaults(WeaponType[1]);
						DontConvertMultipleWeapons = true;
					}
				}
				DontConvertMultipleWeapons = false;
			}
		}
		private void OnPanel3(UIMouseEvent evt, UIElement listeningElement)
		{
			if (UnlockedAspect[2] == true)
			{
				for (int i = 0; i < 58; i++)
				{
					if (Main.LocalPlayer.inventory[i] == Main.LocalPlayer.HeldItem && !DontConvertMultipleWeapons)
					{
						Main.LocalPlayer.inventory[i].netDefaults(WeaponType[2]);
						DontConvertMultipleWeapons = true;
					}
				}
				DontConvertMultipleWeapons = false;
			}
		}
		private void OnPanel4(UIMouseEvent evt, UIElement listeningElement)
		{
			if (UnlockedAspect[3] == true)
			{
				for (int i = 0; i < 58; i++)
				{
					if (Main.LocalPlayer.inventory[i] == Main.LocalPlayer.HeldItem && !DontConvertMultipleWeapons)
					{
						Main.LocalPlayer.inventory[i].netDefaults(WeaponType[3]);
						DontConvertMultipleWeapons = true;
					}
				}
				DontConvertMultipleWeapons = false;
			}
		}
	}
}
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using WeaponAspects.UI;

namespace WeaponAspects
{
	public class WeaponAspects : Mod
	{
		internal UserInterface InterfaceAspectsUI;
		internal AspectsUI AspectsUI;
		private GameTime _lastUpdateUiGameTime;
		public static ModHotKey OpenAspects;
		public override void Load()
		{
			OpenAspects = RegisterHotKey("Open Aspects Menu", "J");
			if (!Main.dedServ)
			{
				InterfaceAspectsUI = new UserInterface();

				AspectsUI = new AspectsUI();
				AspectsUI.Activate();
				InterfaceAspectsUI?.SetState(null);
			}
		}
		public override void Unload()
		{
			OpenAspects = null;
			AspectsUI = null;
		}
		public override void UpdateUI(GameTime gameTime)
		{
			if (OpenAspects.JustPressed)
			{
				if (InterfaceAspectsUI.CurrentState != null)
				{
					InterfaceAspectsUI?.SetState(null);
				}
				else
				{
					InterfaceAspectsUI?.SetState(AspectsUI);
				}
			}
			_lastUpdateUiGameTime = gameTime;
			if (InterfaceAspectsUI?.CurrentState != null)
			{
				InterfaceAspectsUI.Update(gameTime);
			}
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"MyMod: MyInterface",
					delegate
					{
						if (_lastUpdateUiGameTime != null && InterfaceAspectsUI?.CurrentState != null)
						{
							InterfaceAspectsUI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
						}
						return true;
					},
					   InterfaceScaleType.UI));
			}
		}
	}
}
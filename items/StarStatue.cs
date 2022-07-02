using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace DuckQoL.items
{
	public class StarStatue : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawn 1 stars every 3.4 seconds \n CHEAT STATION");
		}

		public override void SetDefaults()
		{
			Item.rare = 3;
			Item.value = Item.buyPrice(0, 0, 0, 1);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(438, 10)
				.AddIngredient(530, 50)
				.AddIngredient(585, 1)
				.AddTile(13)
				.Register();
		}

		int timer = 0;
		public override void UpdateInventory(Player player)
		{
			int starCount = 0;
			for (int i = 0; i < 400; i++)
			{
				if ((Main.item[i].type == 184) | (Main.item[i].type == 1735) | (Main.item[i].type == 1868))
				{
					starCount++;
				}
			}
			var source = player.GetSource_OpenItem(Type);
			if (starCount < 7)
			{
				timer++;
				if (timer > 200)
				{
					player.QuickSpawnItem(source, 184, 1);
					timer = 0;
				}
			}
		}
	}
}

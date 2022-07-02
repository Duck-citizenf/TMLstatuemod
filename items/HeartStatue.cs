using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace DuckQoL.items
{
	public class HeartStatue : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawn 3 hearts every 10 seconds");
		}

		public override void SetDefaults()
		{
			Item.rare = 3;
			Item.value = Item.buyPrice(0, 0, 0, 1);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(473, 3)
				.AddIngredient(530, 50)
				.AddIngredient(585, 1)
				.AddTile(13)
				.Register();
		}

		int timer = 0;
		public override void UpdateInventory(Player player)
		{
			int heartCount = 0;
			for (int i = 0; i < Main.item.Length; i++)
			{
				if (Main.item[i].type == ItemID.Heart | Main.item[i].type == ItemID.CandyApple | Main.item[i].type == ItemID.CandyCane)
				{
					heartCount++;
				}
			}
			var source = player.GetSource_OpenItem(Type);
			if (heartCount < 7)
			{
				timer++;
				if (timer > 600)
				{
					player.QuickSpawnItem(source, 58, 1);
					player.QuickSpawnItem(source, 58, 1);
					player.QuickSpawnItem(source, 58, 1);
					timer = 0;
				}
			}
		}
	}
}

using DuckQoL.npcs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace DuckQoL.items
{
	public class BatStatue : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawn bat inside of you every 30 seconds");
		}

		public override void SetDefaults()
		{
			Item.rare = 3;
			Item.value = Item.buyPrice(0, 0, 0, 1);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(443, 1)
				.AddIngredient(530, 50)
				.AddIngredient(585, 6)
				.AddTile(13)
				.Register();
		}
		int timer = 0;
		public override void UpdateInventory(Player player)
		{
			timer++;
			int type = ModContent.NPCType<PortBat>();
			var source = new EntitySource_ItemUse(player, Item);
			if (timer == 1800)
			{
				NPC.NewNPC(source, (int)player.position.X, (int)player.position.Y, type);
				timer = 0;
			}
		}
	}
}

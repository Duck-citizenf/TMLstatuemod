using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckQoL.items
{
	public class Omnibuff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Grants Endurance, Ironskin, Life Force Regeneration, Honey, Heart Lamp, Cozy Fire, Exquisitely Stuffed, Rage, Wrath\nIf you hold melee weapon grants: Sharpened, Tipsy\nIf you hold bow weapon grants: Archery\nIf you hold magic weapon grants: Magic Power, Mana Regeneration\nRestores 120 life");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.maxStack = 1;
			Item.rare = 1;
			Item.value = Item.buyPrice(0, 0, 0, 1);
			Item.UseSound = SoundID.Item3;
			Item.healLife = 120;
			Item.potion = true;
			Item.consumable = true;
			Item.useStyle = 2;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(2314, 30)
				.AddIngredient(678, 30)
				.AddIngredient(4034, 30)
				.AddIngredient(353, 30)
				.AddIngredient(966, 1)
				.AddIngredient(1859, 1)
				.AddIngredient(1128, 1)
				.AddIngredient(4276, 1)
				.AddIngredient(3198, 1)
				.AddTile(13)
				.Register();
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<DuckQoLPlayer>().Omnibuff = true;
			player.AddBuff(114, 2, true, false);
			player.AddBuff(5, 2, true, false);
			player.AddBuff(215, 2, true, false);
			player.AddBuff(113, 2, true, false);
			player.AddBuff(2, 2, true, false);
			player.AddBuff(48, 2, true, false);
			player.AddBuff(89, 2, true, false);
			player.AddBuff(87, 2, true, false);
			player.AddBuff(207, 2, true, false);
			player.AddBuff(115, 2, true, false);
			player.AddBuff(117, 2, true, false);
			if (player.HeldItem.CountsAsClass(DamageClass.Melee))
			{
				player.AddBuff(159, 2, true, false);
				player.AddBuff(25, 2, true, false);
			}
			if (player.HeldItem.CountsAsClass(DamageClass.Magic))
			{
				player.AddBuff(7, 2, true, false);
				player.AddBuff(6, 2, true, false);
			}
			if (Item.useAmmo == AmmoID.Arrow || Item.useAmmo == AmmoID.Stake)
			{
				player.AddBuff(16, 2, true, false);
			}
		}
		public class OmnibuffGlobalItem : GlobalItem
		{
			public override bool ConsumeItem(Item item, Player player)
			{
				if (item.healLife > 0 && player.GetModPlayer<DuckQoLPlayer>().Omnibuff)
				{
					return false;
				}
				return base.ConsumeItem(item, player);
			}
		}
	}
}

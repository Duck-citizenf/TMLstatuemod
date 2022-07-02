using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckQoL.items
{
	public class OmnibuffHardmode : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Grants Endurance, Ironskin, Life Force Regeneration, Honey, Heart Lamp, Cozy Fire, Exquisitely Stuffed, Rage, Wrath\nIf you hold melee weapon grants: Sharpened, Tipsy, Ichor\nIf you hold bow weapon grants: Archery\nIf you hold magic weapon grants: Magic Power, Mana Regeneration, Clairvoyance\nRestores 150 life");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.maxStack = 1;
			Item.rare = 3;
			Item.value = Item.buyPrice(0, 0, 0, 1);
			Item.UseSound = SoundID.Item3;
			Item.healLife = 150;
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
				.AddIngredient(ModContent.ItemType<Omnibuff>(), 1)
				.AddIngredient(499, 30)
				.AddIngredient(1356, 30)
				.AddIngredient(487, 1)
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
				player.AddBuff(76, 2, true, false);
			}
			if (player.HeldItem.CountsAsClass(DamageClass.Magic))
			{
				player.AddBuff(29, 2, true, false);
				player.AddBuff(7, 2, true, false);
				player.AddBuff(6, 2, true, false);
			}
			if (Item.useAmmo == AmmoID.Arrow || Item.useAmmo == AmmoID.Stake)
			{
				player.AddBuff(16, 2, true, false);
			}
		}
	}
}

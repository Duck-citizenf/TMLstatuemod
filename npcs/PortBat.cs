using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DuckQoL.npcs
{
	public class PortBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cave Bat");
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.CaveBat];
		}

		public override void SetDefaults()
		{
			NPC.width = 22;
			NPC.height = 18;
			NPC.damage = 13;
			NPC.defense = 2;
			NPC.lifeMax = 16;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCHit4;
			NPC.knockBackResist = 0.8f;
			NPC.aiStyle = 14;
			AIType = NPCID.CaveBat;
			AnimationType = NPCID.CaveBat;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode)
			{
				player.AddBuff(BuffID.Rabies, 1800, true, false);
			}
		}
	}
}

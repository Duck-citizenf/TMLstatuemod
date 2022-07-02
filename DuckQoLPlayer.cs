using Terraria.ModLoader;

namespace DuckQoL
{
	public class DuckQoLPlayer : ModPlayer
	{
		public bool Omnibuff;

		public override void ResetEffects()
		{
			Omnibuff = false;
		}
	}
}

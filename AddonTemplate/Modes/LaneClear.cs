using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using Settings = AddonTemplate.Config.Modes.Laneclear;
namespace AddonTemplate.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        #region OKTR CHECK SHROOMS
        private static bool Shroomed(Vector3 castposition)
        {
            return
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(a => a.Name == "Noxious Trap").Any(a => castposition.Distance(a.Position) <= 300);
        }

        private static void Rcast(Vector3 location)
        {
            if (!Shroomed(location))
            {
                SpellManager.R.Cast(location);
            }
        }
        #endregion 

        public override void Execute()
        {
            var source =
                EntityManager.MinionsAndMonsters.EnemyMinions.FirstOrDefault(s => s.IsValidTarget(SpellManager.R.Range));
            //var location = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(source, SpellManager.R.Width, (int)SpellManager.R.Range);
            if (source == null) return;
            if (Settings.UseR && SpellManager.R.IsReady())
            {
                Rcast(source.Position); 
            }
        }
    }
}

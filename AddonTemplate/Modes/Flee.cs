using EloBuddy;
using EloBuddy.SDK;
using Settings = AddonTemplate.Config.Modes.Harass;

namespace AddonTemplate.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on flee mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.R.Range, DamageType.Magical);

            if (Settings.UseW && SpellManager.W.IsReady())
            {
                SpellManager.W.Cast();
            }
            if (target != null && Settings.UseR && SpellManager.R.IsReady())
            {
                if (!Player.Instance.IsFacing(target)) // In this case if teemo is not facing the target will cast
                {
                    Chat.Print("im op");
                    var pred = SpellManager.R.GetPrediction(target);
                    SpellManager.R.Cast(pred.CastPosition);//As skillshot needs a location and for make a better cast we use the prediciton results
                }
            }
        }
    }
}

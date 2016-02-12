using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = AddonTemplate.Config.Modes.Combo;

namespace AddonTemplate.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target == null) return;

            if (Settings.UseQ && Q.IsReady())
            {
                Q.Cast(target);
            }
            if (Settings.UseW && W.IsReady())
            {
                W.Cast();
            }
            if (Settings.UseR && R.IsReady())
            {
                var pred = R.GetPrediction(target);
                R.Cast(pred.CastPosition);
            }
        }
    }
}


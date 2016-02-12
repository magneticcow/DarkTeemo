using System.Reflection;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace AddonTemplate.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }

        public override void Execute()
        {
            if (SpellManager.R.IsLearned)
            {
                SpellManager.R = new Spell.Skillshot(SpellSlot.R, (uint)new[] { 400, 650, 900 }[SpellManager.R.Level - 1], SkillShotType.Circular,
                    500, 1000, 120);
            }
        }
    }
}

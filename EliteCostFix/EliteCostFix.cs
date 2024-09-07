using System.Linq;
using BepInEx;
using RoR2;

namespace EliteCostFix
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class EliteCostFix : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "acats";
        public const string PluginName = "EliteCostFix";
        public const string PluginVersion = "1.0.1";

        public void Awake()
        {
            Log.Init(Logger);

            /*On.RoR2.CombatDirector.Init += orig =>*/
            RoR2Application.onLoad += () =>
            {
                CombatDirector.EliteTierDef normalTier1 = null;
                CombatDirector.EliteTierDef tier1WithGold = null;

                // find tier with overloading and no gilded (should be normal tier 1)
                foreach (var tier in CombatDirector.eliteTiers)
                {
                    if (
                        tier.eliteTypes.Contains(RoR2Content.Elites.Lightning)
                        && !tier.eliteTypes.Contains(DLC2Content.Elites.Aurelionite)
                    )
                    {
                        normalTier1 = tier;
                        break;
                    }
                }
                // find tier with gilded (should be the new unintentionally cheaper tier 1)
                foreach (var tier in CombatDirector.eliteTiers)
                {
                    if (tier.eliteTypes.Contains(DLC2Content.Elites.Aurelionite))
                    {
                        tier1WithGold = tier;
                        break;
                    }
                }

                if (normalTier1 == null)
                {
                    Log.Error("Unable to find elite tier 1!");
                    return;
                }

                if (tier1WithGold == null)
                {
                    Log.Error("Unable to find gilded elite tier!");
                    return;
                }

                // fix the cost
                tier1WithGold.costMultiplier = normalTier1.costMultiplier;

                // disable normal tier 1 when the new tier becomes available
                var vanillaIsAvailable = normalTier1.isAvailable;
                normalTier1.isAvailable = rules =>
                    vanillaIsAvailable(rules) && !tier1WithGold.isAvailable(rules);
            };

            /*On.RoR2.CombatDirector.AttemptSpawnOnTarget += (*/
            /*    orig,*/
            /*    self,*/
            /*    spawnTarget,*/
            /*    placementMode*/
            /*) =>*/
            /*{*/
            /*    float creditsBefore = self.monsterCredit;*/
            /*    var a = orig(self, spawnTarget, placementMode);*/
            /*    float creditsAfter = self.monsterCredit;*/
            /*    Log.Info(*/
            /*        "Spent "*/
            /*            + (creditsBefore - creditsAfter)*/
            /*            + " credits on "*/
            /*            + self.currentMonsterCard.spawnCard.name*/
            /*    );*/
            /*    return a;*/
            /*};*/
        }
    }
}

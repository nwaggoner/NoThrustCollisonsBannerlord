using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NoThrustCollisions {

    [HarmonyPatch(typeof(MissionCombatMechanicsHelper))]
    [HarmonyPatch("GetDefendCollisionResults")]
    [HarmonyAfter("mod.bannerlord.unblockablethrust")]
    class MissionCombatMechanicsHelperGetDefendCollisionResultsPatch {
        static void Postfix(Agent attackerAgent,
            Agent defenderAgent,
            CombatCollisionResult collisionResult,
            int attackerWeaponSlotIndex,
            bool isAlternativeAttack,
            StrikeType strikeType,
            Agent.UsageDirection attackDirection,
            float collisionDistanceOnWeapon,
            float attackProgress,
            bool attackIsParried,
            bool isPassiveUsageHit,
            bool isHeavyAttack,
            ref float defenderStunPeriod,
            ref float attackerStunPeriod,
            ref bool crushedThrough,
            ref bool chamber) {


            if (defenderAgent == null) {
                return;
            }
            bool isAlly = (defenderAgent.Team.IsPlayerTeam || defenderAgent.Team.IsPlayerAlly);
            bool isThrust = (strikeType == StrikeType.Thrust);

            if (isAlly && isThrust) {
                collisionResult = CombatCollisionResult.None;
                defenderStunPeriod = 0;
                attackerStunPeriod = 0;
            }

            return;
        }
    }

}

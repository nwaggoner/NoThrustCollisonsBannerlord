using SandBox.GameComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;
using TaleWorlds.ObjectSystem;

namespace NoThrustCollisions {
    public class NoThrustDamageModel : SandboxAgentApplyDamageModel {
        public NTCSettings ntcInstance;

        public NoThrustDamageModel() {
            ntcInstance = NTCSettings.Instance;
        }

        /* ----------------- MAIN FUNCTIONS ----------------- */

        public override bool IsDamageIgnored(in AttackInformation attackInformation, in AttackCollisionData collisionData) {
            
            bool result = base.IsDamageIgnored(attackInformation, collisionData);


            if (ntcInstance.noThrustCol && attackInformation.VictimAgent?.Team != null) {

                bool isAlly = (attackInformation.VictimAgent.Team.IsPlayerTeam || attackInformation.VictimAgent.Team.IsPlayerAlly);
                bool isThrust = (collisionData.StrikeType == 1 || collisionData.ThrustTipHit);

                if (isAlly && isThrust) {
                    result = true;
                }
            }

            return result;
        }



        public override float ApplyGeneralDamageModifiers(in AttackInformation attackInformation, in AttackCollisionData collisionData, float baseDamage) {
            float baseValue = base.ApplyGeneralDamageModifiers(attackInformation, collisionData, baseDamage);

            // Apply range multiplier for missile values 
            if (collisionData.IsMissile)
                baseValue *= ntcInstance.rangeMultiplier;

            // Apply mount multiplier for mount values 
            if (attackInformation.IsVictimAgentMount)
                baseValue *= ntcInstance.mountMultiplier;

            // Apply global multiplier for values 
            return baseValue * ntcInstance.damageMultiplier;
        }



        public override float CalculateAlternativeAttackDamage(in AttackInformation attackInformation, in AttackCollisionData collisionData, WeaponComponentData weapon) {

            float baseValue = base.CalculateAlternativeAttackDamage(attackInformation, collisionData, weapon);

            if(collisionData.IsMissile)
               baseValue /= ntcInstance.rangeMultiplier;

            // Apply mount multiplier for mount values 
            if (attackInformation.IsVictimAgentMount)
                baseValue /= ntcInstance.mountMultiplier;

            // Apply global multiplier for values
            return baseValue / ntcInstance.damageMultiplier;
        }

        

        public override void DecideWeaponCollisionReaction(in Blow registeredBlow, in AttackCollisionData collisionData, Agent attacker, Agent defender, in MissionWeapon attackerWeapon, bool isFatalHit, bool isShruggedOff, float momentumRemaining, out MeleeCollisionReaction colReaction) {

            base.DecideWeaponCollisionReaction(registeredBlow, collisionData, attacker, defender, attackerWeapon, isFatalHit, isShruggedOff, momentumRemaining, out colReaction);

            if (ntcInstance.noThrustCol && defender?.Team != null) {

                bool isAlly = (defender.Team.IsPlayerTeam || defender.Team.IsPlayerAlly);
                bool isThrust = (registeredBlow.StrikeType == StrikeType.Thrust || collisionData.ThrustTipHit);

                if (isAlly && isThrust) {
                    colReaction = MeleeCollisionReaction.ContinueChecking;
                }
            }   

            return;
        }    
    }

}

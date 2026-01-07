using SandBox.GameComponents;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;


namespace NoThrustCollisions {


    public class SubModule : MBSubModuleBase {

        /* ----------------- MBSUBMODULEBASE OVERRIDES ----------------- */

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject) {
            NoThrustDamageModel thrustModel = new NoThrustDamageModel();
            gameStarterObject.AddModel(thrustModel);
        }

    }
}


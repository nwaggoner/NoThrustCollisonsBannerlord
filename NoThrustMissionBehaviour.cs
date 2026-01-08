using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace NoThrustCollisions {
    public class NoThrustMissionBehaviour : MissionLogic {
        public NTCSettings ntcInstance;

        public NoThrustMissionBehaviour() {
            ntcInstance = NTCSettings.Instance;
        }

    }
}

using MCM.Abstractions;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base;
using MCM.Abstractions.Base.Global;
using System;
using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Localization;


namespace NoThrustCollisions {
    public class NTCSettings : AttributeGlobalSettings<NTCSettings> {

        private bool _useStandardOptionScreen = false;

        public override string Id => "NoThrustCollisions_v1";
        public override string DisplayName => "No Thrust Collisions";
        public override string FolderName => "NTC";
        public override string FormatType => "json2";



        [SettingPropertyFloatingInteger("{=NTCLq80DvXE}Damage Multiplier", 0.2f, 1.2f, "#0%", HintText = "{=NTCkkL55pAp}Adjust the global damage dealt in missions (Campaign/Sandbox only).", Order = 1, RequireRestart = false)]
        [SettingPropertyGroup("Damage", GroupOrder = 1)]
        public float damageMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=NTCTapTj0aE}Ranged Damage Multiplier", 0.2f, 1.2f, "#0%", HintText = "{=NTCWBIgIdaA}Adjusts damage dealt by ranged attacks (relative to 'Damage Multiplier' above).", Order = 2, RequireRestart = false)]
        [SettingPropertyGroup("Damage", GroupOrder = 1)]
        public float rangeMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=NTCIxlzD21f}Horse Damage Multiplier", 0.2f, 1.2f, "#0%", HintText = "{=NTCR5dfOmVv}Adjusts damage dealt to mounts (relative to 'Damage Multiplier' above).", Order = 3, RequireRestart = false)]
        [SettingPropertyGroup("Damage", GroupOrder = 1)]
        public float mountMultiplier { get; set; } = 1f;

        [SettingPropertyBool("{=NTCMRD1reHs}Disable Thrust Collisions", HintText = "{=NTCDgYbsASp} Disable collisisons with your allies when thrusting.... (giggity).", Order = 1, RequireRestart = false)]
        [SettingPropertyGroup("Collisions", GroupOrder = 2)]
        public bool noThrustCol { get; set; } = false;


        public bool UseStandardOptionScreen {
            get => this._useStandardOptionScreen;
            set {
                if (this._useStandardOptionScreen == value)
                    return;
                this._useStandardOptionScreen = value;
                this.OnPropertyChanged(nameof(UseStandardOptionScreen));
            }
        }
    }
}

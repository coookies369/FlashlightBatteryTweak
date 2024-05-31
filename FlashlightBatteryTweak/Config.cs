using BepInEx.Configuration;
using CSync.Lib;
using CSync.Util;
using System.Runtime.Serialization;

[DataContract]
public class Config : SyncedConfig<Config>
{
        [DataMember] public SyncedEntry<float> ProFlashlightBatteryUsage { get; private set; }
        [DataMember] public SyncedEntry<float> ProFlashlightBatteryBurst { get; private set; }
        [DataMember] public SyncedEntry<float> FlashlightBatteryUsage { get; private set; }
        [DataMember] public SyncedEntry<float> FlashlightBatteryBurst { get; private set; }

        public Config(ConfigFile cfg) : base(FlashlightBatteryTweak.MyPluginInfo.PLUGIN_GUID)
        {
                ConfigManager.Register(this);

                ProFlashlightBatteryUsage = cfg.BindSyncedEntry("ProFlashlight", "ProFlashlightBatteryUsage", 360f, "How much battery is drained while active. Counterintuitively, higher numbers drain slower. Vanilla is 300");
                ProFlashlightBatteryBurst = cfg.BindSyncedEntry("ProFlashlight", "ProFlashlightBatteryBurst", 0.05f, "What percentage of the battery is drained when turning the flashlight on");
                FlashlightBatteryUsage = cfg.BindSyncedEntry("Flashlight", "FlashlightBatteryUsage", 186f, "How much battery is drained while active. Counterintuitively, higher numbers drain slower. Vanilla is 140");
                FlashlightBatteryBurst = cfg.BindSyncedEntry("Flashlight", "FlashlightBatteryBurst", 0.03f, "What percentage of the battery is drained when turning the flashlight on");
        }
}
using BepInEx.Configuration;
using CSync.Lib;
using CSync.Util;
using System.Runtime.Serialization;

[DataContract]
public class Config : SyncedConfig2<Config>
{
        [SyncedEntryField] public SyncedEntry<float> ProFlashlightBatteryUsage;
        [SyncedEntryField] public SyncedEntry<float> ProFlashlightBatteryBurst;
        [SyncedEntryField] public SyncedEntry<float> FlashlightBatteryUsage;
        [SyncedEntryField] public SyncedEntry<float> FlashlightBatteryBurst;

        public Config(ConfigFile cfg) : base(FlashlightBatteryTweak.MyPluginInfo.PLUGIN_GUID)
        {
                ProFlashlightBatteryUsage = cfg.BindSyncedEntry(
                        new ConfigDefinition("ProFlashlight", "ProFlashlightBatteryUsage"),
                        360f,
                        new ConfigDescription("How much battery is drained while active. Counterintuitively, higher numbers drain slower. Vanilla is 300"));
                ProFlashlightBatteryBurst = cfg.BindSyncedEntry(
                        new ConfigDefinition("ProFlashlight", "ProFlashlightBatteryBurst"),
                        0.05f,
                        new ConfigDescription("What percentage of the battery is drained when turning the flashlight on"));
                FlashlightBatteryUsage = cfg.BindSyncedEntry(
                        new ConfigDefinition("Flashlight", "FlashlightBatteryUsage"),
                        186f,
                        new ConfigDescription("How much battery is drained while active. Counterintuitively, higher numbers drain slower. Vanilla is 140"));
                FlashlightBatteryBurst = cfg.BindSyncedEntry(
                        new ConfigDefinition("Flashlight", "FlashlightBatteryBurst"),
                        0.03f,
                        new ConfigDescription("What percentage of the battery is drained when turning the flashlight on"));

                ConfigManager.Register(this);
        }
}
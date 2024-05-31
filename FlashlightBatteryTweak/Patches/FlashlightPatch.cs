using HarmonyLib;
using UnityEngine;

namespace FlashlightBatteryTweak.Patches;

[HarmonyPatch(typeof(FlashlightItem))]
public class FlashlightPatch
{
    [HarmonyPatch("ItemActivate")]
    [HarmonyPrefix]
    private static void ItemActivate(bool used, FlashlightItem __instance)
    {
        var type = __instance.flashlightTypeID;
        switch (type)
        {
            case 0: //Pro
                if (used)
                {
                    __instance.insertedBattery.charge = Mathf.Clamp(__instance.insertedBattery.charge - Config.Instance.ProFlashlightBatteryBurst.Value, 0f, 1f);
                }
                __instance.itemProperties.batteryUsage = Config.Instance.ProFlashlightBatteryUsage.Value;
                break;
            case 1: //Regular
                if (used)
                {
                    __instance.insertedBattery.charge = Mathf.Clamp(__instance.insertedBattery.charge - Config.Instance.FlashlightBatteryBurst.Value, 0f, 1f);
                }
                __instance.itemProperties.batteryUsage = Config.Instance.FlashlightBatteryUsage.Value;
                break;
        }
    }
}

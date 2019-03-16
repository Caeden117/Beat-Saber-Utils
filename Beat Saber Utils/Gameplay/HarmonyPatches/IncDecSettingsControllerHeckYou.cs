using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using UnityEngine.UI;

namespace BS_Utils.Gameplay.HarmonyPatches
{
    [HarmonyPatch(typeof(IncDecSettingsController))]
    [HarmonyPatch("OnEnable", MethodType.Normal)]
    class IncDecSettingsControllerHeckYouEnable
    {
        static bool Prefix(IncDecSettingsController __instance, Button ___incButton, Button ___decButton)
        {
            try
            {
                ___incButton.onClick.AddListener(__instance.IncButtonPressed);
                ___decButton.onClick.AddListener(__instance.DecButtonPressed);
            }
            catch { }
            return false;
        }
    }

    [HarmonyPatch("OnDisable", MethodType.Normal)]
    class IndDecSettingsControllerHeckYouDisable
    {
        static bool Prefix(IncDecSettingsController __instance, Button ___incButton, Button ___decButton)
        {
            try
            {
                ___incButton.onClick.RemoveListener(__instance.IncButtonPressed);
                ___decButton.onClick.RemoveListener(__instance.DecButtonPressed);
            }
            catch { }
            return false;
        }
    }
}

using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace WalkieTalkie;

[HarmonyPatch(typeof(PassingShip), nameof(PassingShip.CommFloatMenuOption))]
public class PassingShip_CommFloatMenuOption
{
    public static void Postfix(ref FloatMenuOption __result, PassingShip __instance, Building_CommsConsole console,
        Pawn negotiator)
    {
        string text = "CallOnRadio".Translate(__instance.GetCallLabel());
        if (__instance.GetType().GetMethod("CanCommunicateWith", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.Invoke(__instance, [negotiator]) is AcceptanceReport { Accepted: true })
        {
            __result = FloatMenuUtility.DecoratePrioritizedTask(
                new FloatMenuOption(text, delegate { console.GiveUseCommsJob(negotiator, __instance); },
                    MenuOptionPriority.InitiateSocial), negotiator, (LocalTargetInfo)console);
        }
    }
}
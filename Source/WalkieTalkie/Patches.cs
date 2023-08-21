using System.Reflection;
using HarmonyLib;
using Verse;

namespace WalkieTalkie;

[StaticConstructorOnStartup]
public static class Patches
{
    static Patches()
    {
        new Harmony("trahs.walkietalkie").PatchAll(Assembly.GetExecutingAssembly());
    }
}
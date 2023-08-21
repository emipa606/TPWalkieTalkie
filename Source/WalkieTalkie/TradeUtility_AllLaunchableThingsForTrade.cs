using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace WalkieTalkie;

[HarmonyPatch(typeof(TradeUtility), "AllLaunchableThingsForTrade")]
public class TradeUtility_AllLaunchableThingsForTrade
{
    public static IEnumerable<Thing> Postfix(IEnumerable<Thing> __result, Map map, ITrader trader = null)
    {
        var yieldedThings = new HashSet<Thing>();
        foreach (var item in Building_WalkieTalkie.AllPowered(map))
        {
            foreach (var tradeableCell in item.TradeableCells)
            {
                var thingList = tradeableCell.GetThingList(map);
                foreach (var thing in thingList)
                {
                    if (thing.def.category != ThingCategory.Item || !TradeUtility.PlayerSellableNow(thing, trader) ||
                        yieldedThings.Contains(thing))
                    {
                        continue;
                    }

                    yieldedThings.Add(thing);
                    yield return thing;
                }
            }
        }
    }
}
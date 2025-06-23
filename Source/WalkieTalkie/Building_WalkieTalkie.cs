using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace WalkieTalkie;

public class Building_WalkieTalkie : Building_CommsConsole
{
    private const float TradeRadius = 3f;

    private static readonly List<IntVec3> tradeableCells = [];

    public IEnumerable<IntVec3> TradeableCells => TradeableCellsAround(Position, Map);

    private void makeMatchingStockpile()
    {
        var des = DesignatorUtility.FindAllowedDesignator<Designator_ZoneAddStockpile_Resources>();
        des.DesignateMultiCell(TradeableCells.Where(c => des.CanDesignateCell(c).Accepted));
    }

    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (var gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        if (DesignatorUtility.FindAllowedDesignator<Designator_ZoneAddStockpile_Resources>() == null)
        {
            yield break;
        }

        var commandAction = new Command_Action
        {
            action = makeMatchingStockpile,
            hotKey = KeyBindingDefOf.Misc1,
            defaultDesc = "CommandMakeBeaconStockpileDesc".Translate(),
            icon = ContentFinder<Texture2D>.Get("UI/Designators/ZoneCreate_Stockpile"),
            defaultLabel = "CommandMakeBeaconStockpileLabel".Translate()
        };
        yield return commandAction;
    }

    public static List<IntVec3> TradeableCellsAround(IntVec3 pos, Map map)
    {
        tradeableCells.Clear();
        if (!pos.InBounds(map))
        {
            return tradeableCells;
        }

        var region = pos.GetRegion(map);
        if (region == null)
        {
            return tradeableCells;
        }

        RegionTraverser.BreadthFirstTraverse(region, (_, r) => r.door == null, delegate(Region r)
        {
            foreach (var item in r.Cells)
            {
                if (item.InHorDistOf(pos, TradeRadius))
                {
                    tradeableCells.Add(item);
                }
            }

            return false;
        }, 16);
        return tradeableCells;
    }

    public static IEnumerable<Building_WalkieTalkie> AllPowered(Map map)
    {
        foreach (var item in map.listerBuildings.AllBuildingsColonistOfClass<Building_WalkieTalkie>())
        {
            var comp = item.GetComp<CompPowerTrader>();
            if (comp == null || comp.PowerOn)
            {
                yield return item;
            }
        }
    }
}
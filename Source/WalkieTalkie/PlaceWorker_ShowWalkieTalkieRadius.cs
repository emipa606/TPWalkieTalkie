using UnityEngine;
using Verse;

namespace WalkieTalkie;

public class PlaceWorker_ShowWalkieTalkieRadius : PlaceWorker
{
    public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol, Thing thing = null)
    {
        var currentMap = Find.CurrentMap;
        GenDraw.DrawFieldEdges(Building_WalkieTalkie.TradeableCellsAround(center, currentMap));
    }
}
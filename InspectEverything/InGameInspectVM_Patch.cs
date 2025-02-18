using HarmonyLib;
using Kingmaker.UI.MVVM._VM.Inspect;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace InspectEverything
{
    [HarmonyPatch(typeof(InGameInspectVM), nameof(InGameInspectVM.OnUnitHover))]
    public class InGameInspectVM_OnUnitHover_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            newInstructions[4] = new CodeInstruction(OpCodes.Brtrue_S, newInstructions[15].labels[0]);

            newInstructions[10] = new CodeInstruction(OpCodes.Nop);
            newInstructions[11] = new CodeInstruction(OpCodes.Nop);
            newInstructions[12] = new CodeInstruction(OpCodes.Nop);
            newInstructions[13] = new CodeInstruction(OpCodes.Nop);
            newInstructions[14] = new CodeInstruction(OpCodes.Nop);

            return newInstructions.AsEnumerable();
        }
    }

    [HarmonyPatch(typeof(InGameInspectVM), nameof(InGameInspectVM.OnUnitRightClick))]
    public class InGameInspectVM_OnUnitRightClick_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            newInstructions[4] = new CodeInstruction(OpCodes.Brtrue_S, newInstructions[11].labels[0]);

            newInstructions[6] = new CodeInstruction(OpCodes.Nop);
            newInstructions[7] = new CodeInstruction(OpCodes.Nop);
            newInstructions[8] = new CodeInstruction(OpCodes.Nop);
            newInstructions[9] = new CodeInstruction(OpCodes.Nop);
            newInstructions[10] = new CodeInstruction(OpCodes.Nop);

            return newInstructions.AsEnumerable();
        }
    }


    /*
    public override void OnUnitRightClick(UnitEntityView unitEntityView)
    {
        if (!Game.Instance.Player.UISettings.ShowInspect)
        {
            return;
        }
        if (!unitEntityView.EntityData.IsPlayersEnemy)
        {
            return;
        }
        this.m_HoveredUnitReference = unitEntityView.Data;
        TooltipHelper.ShowInfo(new TooltipTemplateUnitInspect(unitEntityView.EntityData));
    }
    */
}

using HarmonyLib;
using Kingmaker.UI.MVVM._VM.Tooltip.Templates;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace InspectEverything
{

    [HarmonyPatch(typeof(TooltipTemplateUnitInspect), nameof(TooltipTemplateUnitInspect.GetBody))]
    public class TooltipTemplateUnitInspect_GetBody_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            for (int i = 6; i <= 29; i++)
            {
                newInstructions[i] = new CodeInstruction(OpCodes.Nop);
            }

            return newInstructions.AsEnumerable();
        }
    }

    [HarmonyPatch(typeof(TooltipTemplateUnitInspect), nameof(TooltipTemplateUnitInspect.Prepare))]
    public class TooltipTemplateUnitInspect_Prepare_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            for (int i = 33; i <= 39; i++)
            {
                newInstructions[i] = new CodeInstruction(OpCodes.Nop);
            }

            return newInstructions.AsEnumerable();
        }
    }

}

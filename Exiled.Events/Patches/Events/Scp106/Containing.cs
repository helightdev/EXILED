// -----------------------------------------------------------------------
// <copyright file="Containing.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Scp106
{
#pragma warning disable SA1313
    using Exiled.Events.EventArgs;
    using Exiled.Events.Handlers;
    using HarmonyLib;

    /// <summary>
    /// Patches <see cref="PlayerInteract.CallCmdContain106"/>.
    /// Adds the <see cref="Scp106.Containing"/> event.
    /// </summary>
    [HarmonyPatch(typeof(PlayerInteract), nameof(PlayerInteract.CallCmdContain106))]
    internal class Containing
    {
        private static bool Prefix(CharacterClassManager __instance)
        {
            var ev = new ContainingEventArgs(API.Features.Player.Get(__instance.gameObject));

            Scp106.OnContaining(ev);

            return ev.IsAllowed;
        }
    }
}

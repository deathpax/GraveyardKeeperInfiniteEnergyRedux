using Harmony;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace com.deathpax.mods.GraveyardKeeper.InfiniteEnergyRedux  // This is usually the name of your mod.
{
    /// <summary>
    /// All code by Oldark and his original Infinite Energy mod. https://www.nexusmods.com/graveyardkeeper/mods/3
    /// 
    /// This is essentially a recompile with some references updated to support 
    /// the new version of UnityEngine used in Graveyard Keeper.
    /// </summary>
    [HarmonyPatch(typeof(PlayerComponent))]  // We're patching the PlayerComponent class.
    [HarmonyPatch("Update")]        // The PlayerComponent class's CheckEnergy method specifically.
    internal class PlayerComponent_Update_Patch
    {
        public static bool infiniteEnabled = true;

        [HarmonyPrefix]      // Run this after the default game's PlayerComponent Update method runs.
        public static bool Prefix(PlayerComponent __instance)
        {
            if (Input.GetKey(KeyCode.L))
            {
                infiniteEnabled = !infiniteEnabled;
            }

            if (PlayerComponent_Update_Patch.infiniteEnabled)
            {
                MainGame.me.player.energy = (float)MainGame.me.save.max_energy - 1;
            }

            return true;
        }
    }
}
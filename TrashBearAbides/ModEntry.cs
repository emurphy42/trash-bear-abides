﻿using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace TrashBearAbides
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Properties
        *********/
        /// <summary>The mod configuration from the player.</summary>
        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();

            Helper.Events.Player.Warped += (e, a) => addTrashBearAbides(a.NewLocation.NameOrUniqueName);
        }

        /*********
        ** Private methods
        *********/
        /// <summary>Generate adjusted copy of Trash Bear if appropriate.</summary>
        /// <param name="locationName">Name of the new location.</param>
        private void addTrashBearAbides(string locationName)
        {
            // Did player enter Cindersap Forest?
            if (locationName != "Forest")
            {
                return;
            }

            // Is standard Trash Bear already there?
            var where = Game1.currentLocation;
            if (where.getCharacterFromName("TrashBear") != null)
            {
                return;
            }

            // Is custom Trash Bear already there?
            if (where.getCharacterFromName("TrashBearAbides") != null)
            {
                return;
            }

            // Have players completed standard Trash Bear quest?
            if (!StardewValley.Network.NetWorldState.checkAnywhereForWorldStateID("trashBearDone"))
            {
                return;
            }

            // Don't add custom Trash Bear on rainy or festival days (same as standard)
            // https://github.com/veywrn/StardewValley/blob/master/StardewValley/Locations/Forest.cs
            if (Game1.isRaining || Utility.isFestivalDay(Game1.dayOfMonth, Game1.currentSeason))
            {
                return;
            }

            // Randomly choose whether to add custom Trash Bear today
            var trashBearRandom = new Random();
            if (trashBearRandom.NextDouble() < this.Config.TrashBearChance)
            {
                where.characters.Add(new CustomTrashBear());
                this.Monitor.Log($"[Trash Bear Abides] Trash Bear re-added to Cindersap Forest", LogLevel.Debug);
            }
        }
    }
}

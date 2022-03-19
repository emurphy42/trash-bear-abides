using StardewValley;
using StardewValley.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashBearAbides
{
    // https://github.com/veywrn/StardewValley/blob/master/StardewValley/Characters/TrashBear.cs
    internal class CustomTrashBear : TrashBear
    {

        // Possible future improvement: Option to randomize location
        public CustomTrashBear() : base()
        {
        }

        // Interacting with custom Trash Bear just shows a heart emote
        public override bool checkAction(Farmer who, GameLocation l)
        {
            if (sprite.Value.CurrentAnimation != null)
            {
                return false;
            }

            doEmote(Character.heartEmote);
            return false;
        }
    }
}

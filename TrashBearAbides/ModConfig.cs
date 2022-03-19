using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashBearAbides
{
    class ModConfig
    {
        // Probability of Trash Bear reappearing each (sunny non-festival) day
        public double TrashBearChance { get; set; } = .5;

        // Setting this to true performs check even if standard Trash Bear hasn't appeared yet
        // (allows testing using a newer save)
        public bool TrashBearAppearsEarly { get; set; } = false;

        // Setting this to true produces console output each time check is performed
        public bool TrashBearAbidesDebugOutput { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager
{
    public static class FleetState
    {
        public enum State
        {
            WaitingForPlayers,
            InGame,
            WrappingUpGame
        }
    }
}

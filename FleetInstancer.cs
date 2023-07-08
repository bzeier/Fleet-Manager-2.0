using FleetManager;
using System.Collections.Generic;
using System.Diagnostics;

namespace FleetManager
{
    public static class FleetInstancer
    {
        public static int MAX_FLEETS_ALLOWED = 10;
        public static int MAX_PLAYERS_PER_FLEET = 4;
        public static int FLEETS = 0;
        public static string IPAdress = "127.0.0.1";
        public static string BasePort = "7777";

        private static List<Fleet> FleetInstances = new List<Fleet>();

        public static void ShutDownAllFleets()
        {
            foreach (Fleet fleet in FleetInstances)
            {
                
                if (fleet.GetIsRunning())
                {
                    fleet.ShutDown();
                    FleetInstances.Remove(fleet);
                }
            }

            Program.mainForm.UpdateFleets();
        }

        public static void PromoteExternalFleet(FleetInfo fleet)
        {
            Fleet newfleet = new Fleet(fleet.ipaddress, fleet.port, fleet.name);
            newfleet.MyState = fleet.state;
            newfleet.Map = fleet.Map;
            newfleet.MaxPlayers = fleet.MaxPlayers;
            FleetInstances.Add(newfleet);

        }

        public static void CheckFleets()
        {
            foreach (Fleet fleet in FleetInstances)
            {
                if(!fleet.GetIsRunning())
                {
                    FleetInstances.Remove(fleet);
                }
            }

            Program.mainForm.UpdateFleets();
        }

        public static Fleet FindAvailableFleet()
        {
            foreach (Fleet fleet in FleetInstances)
            {

                if (fleet.players.Count < MAX_PLAYERS_PER_FLEET)
                    return fleet;
            }

            return null;
        }

        public static List<Fleet> GetFleets()
        {
            return FleetInstances;
        }

        public static bool RunNewFleet()
        {
            if (FleetInstances.Count + 1 > MAX_FLEETS_ALLOWED)
                return false;

            System.Diagnostics.Debug.WriteLine("Starting a new Fleet instance...");

            Fleet newFleetInstance = new Fleet(IPAdress, BasePort, Program.hostWeb.BaseAddresses[0].ToString() + "_"+ FLEETS);
            FleetInstances.Add(newFleetInstance);
            FLEETS++;
            Debug.WriteLine(FleetInstances.Count);
            Program.mainForm.UpdateFleets();

            Program.mainForm.UpdateFleetOverview();

            if (!newFleetInstance.isValid)
            {
                System.Diagnostics.Debug.WriteLine("Failed to boot up new server instance");
                return false;
            }

            return true;
        }

        public static void OnIncomingPlayer(Player player)
        {
            Fleet availableFleet = FindAvailableFleet();
            if (availableFleet == null)
            {
                RunNewFleet();
            }
            else
            {
                availableFleet.AddPlayer(player);
            }

            Debug.WriteLine("Available fleets are sufficient");
        }
    }
}

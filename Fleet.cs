using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.IO;
using static FleetManager.FleetState;

namespace FleetManager
{
    public class Fleet
    {
        public Process process;
        //Settings
            public string MyIPAdress = "Undefined";
            public string MyPort = "Undefined";
            
            public string MyName = "Server";
            public int MaxPlayers = 0;
            public string Map = "Undefined";
            
        //State
            public int MyID = 0;
            public State MyState = State.WaitingForPlayers;
            
            public bool isValid = false;
            public List<Player> players = new List<Player>();

        public Fleet(string ipadress, string port, string name)
        {
            this.MyName = name;
            this.MyIPAdress = ipadress;
            this.MyPort = port;
            this.MyID = FleetInstancer.FLEETS + 1;
            this.process = Run();
            if (this.process.HasExited)
            {
                this.isValid = false;
            }
            else if (this.GetIsRunning()) { this.isValid = true; }
        }

        public Process Run()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            //string[] files = Directory.GetFiles(path);

            Process _process = new Process
            {
                StartInfo =
              {
                  FileName = path + "/UEServerDummy.exe",
                  Arguments =  "-port=" + MyPort
              }
            };
            _process.Start();

            return _process;
        }

        public bool GetIsRunning()
        {
            return process.HasExited;
        }

        public void AddPlayer(Player player)
        {
            player.isActive = true;
            players.Add(player);
        }

        public bool ShutDown()
        {
            if (process.HasExited) return true;
            process.Kill();
            return true;
        }
    }
}

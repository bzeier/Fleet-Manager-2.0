using FleetManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace FleetManager
{
    public class Service : IService
    {
        public bool GetRequest(string request)
        {
            string requestStamp = request + "          | " + DateTime.Now;
            Program.APIRequestsLog.Add(request);
            Program.mainForm.UpdateRequestLog();

            return true;
        }

        public List<FleetInfo> GetServers(string bOnlyJoinable)
        {
            List < FleetInfo > data = new List <FleetInfo>();
            foreach(Fleet fleet in FleetInstancer.GetFleets())
            {
                if (bOnlyJoinable == "true" && fleet.MyState != 0) continue;

                FleetInfo newFleetInfo = new FleetInfo();
                newFleetInfo.name = fleet.MyName;
                newFleetInfo.ipaddress = fleet.MyIPAdress;
                newFleetInfo.port = fleet.MyPort;
                newFleetInfo.state = fleet.MyState;
                newFleetInfo.Map = fleet.Map;
                data.Add(newFleetInfo);
            }

            return data;
        }

        public bool PromoteServer(string name, string ipaddress, string port)
        {
            FleetInfo newfleet = new FleetInfo();
            newfleet.name = name;
            newfleet.ipaddress = ipaddress;
            newfleet.port = port;
            FleetInstancer.PromoteExternalFleet(newfleet);
            return true;
        }

        public USER DoLogin(string user, string pass)
        {
            try
            {
                USER data = new USER();
                if (user == "admin" && pass == "admin")
                {
                    data.username = user;
                    data.password = pass;
                    data.firstname = "admin";
                    data.lastname = "admin";
                }
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
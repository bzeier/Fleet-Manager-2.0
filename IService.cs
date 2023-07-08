using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using static FleetManager.FleetState;

namespace FleetManager
{
    [ServiceContract]
    public interface IService
    {
        /*
        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped,
             UriTemplate = "login/{username}/{password}")]
        [return: MessageParameter(Name = "Data")]
        USER DoLogin(string username, string password);
        */

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "{request}")]
        [return: MessageParameter(Name = "Data")]
        bool GetRequest(string request);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "getservers/{bOnlyJoinable}")]
        [return: MessageParameter(Name = "Data")]
        List<FleetInfo> GetServers(string bOnlyJoinable);


        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "promoteserver/{name}/{ipaddress}/{port}")]
        [return: MessageParameter(Name = "Data")]
        bool PromoteServer(string name, string ipaddress, string port);
    }



    public class USER
    {
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class FleetInfo
    {
        public string name { get; set; }
        public string ipaddress { get; set; }
        public string port { get; set; }
        public int MaxPlayers { get; set; }
        public string Map { get; set; }

        public State state { get; set; }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Xml;
using Facebook.Utility;

namespace Facebook
{
    internal sealed class NetworkParser
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        private NetworkParser() { }

        /// <summary>
        /// Uses DOM parsing to constitute a collection of Networks given the xml returned from facebook
        /// call ParseNetwork in a loop
        /// </summary>
        internal static void ParseNetworks(XmlNode networksNode, Collection<Network> networks)
        {
            if (networksNode != null)
            {
                XmlNodeList networkNodes = ((XmlElement)networksNode).GetElementsByTagName("affiliation");
                foreach (XmlNode networkNode in networkNodes)
                {
                    networks.Add(ParseNetwork(networkNode));
                }
            }            
        }
        /// <summary>
        /// Uses DOM parsing to constitute a Network given the xml returned from facebook
        /// </summary>
        public static Network ParseNetwork(XmlNode node)
        {
            Network network = new Network();
            network.Name = XmlHelper.GetNodeText(node, "name");
            network.NetworkId = XmlHelper.GetNodeText(node, "nid");
            network.Status = XmlHelper.GetNodeText(node, "status");
            if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "type")))
            {
                network.Type = (NetworkType)Enum.Parse(typeof(NetworkType), XmlHelper.GetNodeText(node, "type").Replace(" ", ""), true);
            }
            int tempInt = 0;
            if(int.TryParse(XmlHelper.GetNodeText(node, "year"), out tempInt))
            {
                network.Year = tempInt;
            }
            return network;
        }
        
    }
}

using System.Xml;

namespace Facebook.Utility {
    internal sealed class XmlHelper {
        private XmlHelper() {
        }

        /// <summary>
        /// Method to return the inner text of a node.
        /// </summary>
        /// <param name="node">The node to parse.</param>
        /// <param name="name">The node name.</param>
        /// <returns>The text containted by the node.</returns>
        internal static string GetNodeText(XmlNode node, string name) {
            if(node==null)
                return string.Empty;

            XmlElement xmlElement = node as XmlElement;

            if(xmlElement==null)
                return string.Empty;

              XmlNodeList nodeList=xmlElement.GetElementsByTagName(name);

              if (nodeList != null && nodeList.Count > 0) 
                {
                    return nodeList[0].InnerText;
                }
            return string.Empty;
        }
    }
}
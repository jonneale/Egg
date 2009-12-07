using System;
using System.Collections.ObjectModel;
using System.Xml;
using Facebook.Entity;
using Facebook.Parser;
using Facebook.Utility;

namespace Facebook.Parser {
    internal sealed class WorkParser
    {
        /// <summary>
        /// default constructor
        /// </summary>
        private WorkParser() { }

        /// <summary>
        /// Uses DOM parsing to constitute a collection of work objects given the xml returned from facebook
        /// </summary>
        internal static Collection<Work> ParseWorkHistory(XmlNode node)
        {
            Collection<Work> workHistoryList = new Collection<Work>();

            if (node != null)
            {
                foreach (XmlNode workNode in ((XmlElement)node).GetElementsByTagName("work_info"))
                {
                    workHistoryList.Add(ParseWork(workNode));
                }
            }
            return workHistoryList;;
        }
        /// <summary>
        /// Uses DOM parsing to constitute a work data object given the xml returned from facebook
        /// </summary>
        public static Work ParseWork(XmlNode node)
        {
            Work work = new Work();
            if (node != null)
            {
                work.Location = LocationParser.ParseLocation(((XmlElement)node).GetElementsByTagName("location")[0]);
                work.CompanyName = XmlHelper.GetNodeText(node, "company_name");
                work.Position = XmlHelper.GetNodeText(node, "position");
                work.Description = XmlHelper.GetNodeText(node, "description");

                DateTime tempDate;
                if (DateTime.TryParse(XmlHelper.GetNodeText(node, "start_date"), out tempDate))
                {
                    work.StartDate = tempDate;
                }

                if (DateTime.TryParse(XmlHelper.GetNodeText(node, "end_date"), out tempDate))
                {
                    work.EndDate = tempDate;
                }
            }
            return work;
        }
        
    }
}
using AbnLookup.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AbnLookup
{
    public class AbnManager
    {

        private const string myGuid = "f673b6b6-bb89-4d66-bdc7-39e9c2574a85";
        private const string History = "N";
        private const string Url = "http://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx/ABRSearchByABN?";

        private static string BuildAbnQueryString(string searchText, string history, string guid)
        {
            StringBuilder QueryString = new StringBuilder(Url);
            QueryString.Append("searchString=" + searchText);
            QueryString.Append("&includeHistoricalDetails=" + history);
            QueryString.Append("&authenticationGuid=" + guid);
            return QueryString.ToString();
        }

        public static async Task<AbnEntity> AbnSearchAsync(string searchText)
        {

            HttpClient hTTPClient = new HttpClient();
            hTTPClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await hTTPClient.GetAsync(BuildAbnQueryString(searchText, "N", myGuid));

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(content);

                // CREATE XML FILE
                XDocument xdoc = new XDocument();
                xdoc = XDocument.Parse(content);

                return ManageResponse(xdoc);

                // CREATE JSON FILE
                //string jsonText = JsonConvert.SerializeXNode(xdoc);
                //var fin = JsonConvert.DeserializeObject<Rootobject>(jsonText);

            }
            else return null;

        }

        public static AbnEntity ManageResponse(XDocument xml)
        {
            AbnEntity abn = new AbnEntity();

            abn.abnNumber = xml.Descendants().Where(p => p.Name.LocalName == "identifierValue").Select(p => p.Value).FirstOrDefault(); 
            abn.familyName = xml.Descendants().Where(p => p.Name.LocalName == "familyName").Select(p => p.Value).FirstOrDefault();
            abn.givenName = xml.Descendants().Where(p => p.Name.LocalName == "givenName").Select(p => p.Value).FirstOrDefault();
            abn.entityDescription = xml.Descendants().Where(p => p.Name.LocalName == "entityDescription").Select(p => p.Value).FirstOrDefault();
            abn.stateCode = xml.Descendants().Where(p => p.Name.LocalName == "stateCode").Select(p => p.Value).FirstOrDefault();
            abn.postCode = xml.Descendants().Where(p => p.Name.LocalName == "postcode").Select(p => p.Value).FirstOrDefault();


            var doc7 = xml.Descendants().Where(p => p.Name.LocalName == "entityStatus").FirstOrDefault();
            abn.entityStatus.effectiveFrom = doc7.Descendants().Where(p => p.Name.LocalName == "effectiveFrom").Select(p => p.Value).FirstOrDefault();
            abn.entityStatus.entityStatusCode = doc7.Descendants().Where(p => p.Name.LocalName == "entityStatusCode").Select(p => p.Value).FirstOrDefault();

            var doc8 = xml.Descendants().Where(p => p.Name.LocalName == "goodsAndServicesTax").FirstOrDefault();
            abn.goodsAndServicesTax.effectiveFrom = doc8.Descendants().Where(p => p.Name.LocalName == "effectiveFrom").Select(p => p.Value).FirstOrDefault();


            return abn;

        }
    }
}

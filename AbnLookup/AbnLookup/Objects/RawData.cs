using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AbnLookup
{
    public class Rootobject
    {
        public Xml xml { get; set; }
        public Abrpayloadsearchresults ABRPayloadSearchResults { get; set; }
    }

    public class Xml
    {
        public string version { get; set; }
        public string encoding { get; set; }
    }

    public class Abrpayloadsearchresults
    {
        public string xmlnsxsd { get; set; }
        public string xmlnsxsi { get; set; }
        public string xmlns { get; set; }
        public Request request { get; set; }
        public Response response { get; set; }
    }

    public class Request
    {
        public Identifiersearchrequest identifierSearchRequest { get; set; }
    }

    public class Identifiersearchrequest
    {
        public string authenticationGUID { get; set; }
        public string identifierType { get; set; }
        public string identifierValue { get; set; }
        public string history { get; set; }
    }

    public class Response
    {
        public string usageStatement { get; set; }
        public string dateRegisterLastUpdated { get; set; }
        public DateTime dateTimeRetrieved { get; set; }
        public Businessentity businessEntity { get; set; }
    }

    public class Businessentity
    {
        public string recordLastUpdatedDate { get; set; }
        public ABN ABN { get; set; }
        public Entitystatus entityStatus { get; set; }
        public object ASICNumber { get; set; }
        public Entitytype entityType { get; set; }
        public Goodsandservicestax goodsAndServicesTax { get; set; }
        public Mainname mainName { get; set; }
        public Maintradingname mainTradingName { get; set; }
        public Othertradingname[] otherTradingName { get; set; }
        public Mainbusinessphysicaladdress mainBusinessPhysicalAddress { get; set; }
    }

    public class ABN
    {
        public string identifierValue { get; set; }
        public string isCurrentIndicator { get; set; }
        public string replacedFrom { get; set; }
    }

    public class Entitystatus
    {
        public string entityStatusCode { get; set; }
        public string effectiveFrom { get; set; }
        public string effectiveTo { get; set; }
    }

    public class Entitytype
    {
        public string entityTypeCode { get; set; }
        public string entityDescription { get; set; }
    }

    public class Goodsandservicestax
    {
        public string effectiveFrom { get; set; }
        public string effectiveTo { get; set; }
    }

    public class Mainname
    {
        public string organisationName { get; set; }
        public string effectiveFrom { get; set; }
    }

    public class Maintradingname
    {
        public string organisationName { get; set; }
        public string effectiveFrom { get; set; }
    }

    public class Mainbusinessphysicaladdress
    {
        public string stateCode { get; set; }
        public string postcode { get; set; }
        public string effectiveFrom { get; set; }
        public string effectiveTo { get; set; }
    }

    public class Othertradingname
    {
        public string organisationName { get; set; }
        public string effectiveFrom { get; set; }
    }



}

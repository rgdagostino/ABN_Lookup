using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbnLookup.Classes
{
    public class AbnEntity
    {
        public EntityStatus entityStatus;
        public GoodsAndServicesTax goodsAndServicesTax;
        public AbnEntity()
        {
            entityStatus = new EntityStatus();
            goodsAndServicesTax = new GoodsAndServicesTax();
        }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string entityDescription { get; set; }
        public string stateCode { get; set; }
        public string postCode { get; set; }
        public string abnNumber { get; set; }

    }

    public class EntityStatus
    {
        public string entityStatusCode { get; set; }
        public string effectiveFrom { get; set; }
    }

    public class GoodsAndServicesTax
    {
        public string effectiveFrom { get; set; }
    }
}

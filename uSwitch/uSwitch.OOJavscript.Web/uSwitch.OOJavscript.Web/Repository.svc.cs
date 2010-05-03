using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using uSwitch.OOJavaScript.Web.Domain;
using System.Collections;
using System.Collections.Generic;

namespace uSwitch.OOJavaScript.Web
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Repository : IRepository
    {
        private readonly IList<Supplier> _suppliers;

        public Repository()
        {
            _suppliers = GenerateDomainObjects();
        }

        public Supplier[] GetSuppliers()
        {
            return _suppliers.ToArray();
        }

        public Supplier GetSupplier(string id)
        {
            int supplierId = int.Parse(id);
            return _suppliers.SingleOrDefault<Supplier>(x => x.Id == supplierId);
        }

        #region Data GeneratorCode
        private IList<Supplier> GenerateDomainObjects()
        {
            List<Supplier> suppliers = new List<Supplier> {
                new Supplier { Id = 1, Name = "BG", Plans = GeneratePlans("BG") },
                new Supplier { Id = 2, Name = "EDF", Plans = GeneratePlans("EDF") },
                new Supplier { Id = 3, Name = "PowerGen", Plans = GeneratePlans("PowerGen") },
                new Supplier { Id = 4, Name = "Southern electric", Plans = GeneratePlans("Southern electric") } 
            };

            return suppliers;
        }

        private IList<Plan> GeneratePlans(string supplierName)
        {
            var plans = new List<Plan>();
            for (int i = 0; i < 5; i++)
            {
                plans.Add(new Plan { Id = i, Name = string.Concat(supplierName, " - ", "plan ", i) });
            }

            return plans;
        }
        #endregion

        #region IRepository Members


        public string Test()
        {
            return "It working";
        }

        #endregion
    }
}

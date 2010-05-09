using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NHibernate;
using BensBoxing.Domain.NHibernate;
using BensBoxing.Domain.Repositories;
using BensBoxing.Domain;

namespace BensBoxing.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Repository<TClass> GetRepository<TClass>() where TClass : Entity
        {
            return new Repository<TClass>(Session);
        }

        protected ISession Session
        {
            get
            {
                if (HttpContext.Items["ISession"] == null) {
                    HttpContext.Items["ISession"] = Configure.GetSessionFactory().OpenSession();
                }
                return (ISession)HttpContext.Items["ISession"];
            }
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            Session.Flush();
            Session.Close();
        }
    }
}

using MindfireSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MindfireSolutions.CRUD_Functionality
{
  public class AuthorizeUserCredentials : FilterAttribute, IAuthorizationFilter
  {
    public string Roles { get; set; }
   
    public override object TypeId { get; }
   
    public string Users { get; set; }
    public void OnAuthorization(AuthorizationContext filterContext)
    {
      throw new NotImplementedException();
    }
  }
}
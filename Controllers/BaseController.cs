using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Sky.SelfServe.Controllers
{
	public class BaseController : Controller
	{
        //private readonly string _okMessage = "Ok";
        //private readonly string _notOkMessage = "NotOk";
		private readonly string _code = "code";
		private readonly string _message = "message";
        //private readonly int _notOkCode = -1;

        protected JsonResult BaseJson(int code, object result)
        {
            Dictionary<string, object> response = new Dictionary<string, object>
            {
                { _code, code },
                { _message, result }
            };
            return Json(response);
        }

        protected JsonResult BaseJson(HttpStatusCode code, object result)
        {
            Dictionary<string, object> response = new Dictionary<string, object>
            {
                { _code, code },
                { _message, result }
            };
            return Json(response);
        }

		protected JsonResult OkJson(object result)
        {
            return BaseJson(HttpStatusCode.OK, result);
        }
	}
}
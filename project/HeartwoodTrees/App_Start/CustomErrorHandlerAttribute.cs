// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomErrorHandlerAttribute.cs" company="Heartwood Trees Ltd Limited">
//   Copyright © heartwoodtreesltd.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines a class responsible for customising exception handling.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.App_Start
{
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using FluentValidation;

    using HeartwoodTrees.Business;

    /// <summary>
    /// Defines a class responsible for customising exception handling.
    /// </summary>
    public class CustomErrorHandlerAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Instance of the current logger.
        /// </summary>
        //private static readonly ILogger Logger = XeroLogger.GetCurrentClassLogger();

        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">
        /// The action-filter context.
        /// </param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (this.IsApiRequest(filterContext))
            {
                this.HandleApiException(filterContext);
            }
            else
            {
                //Logger.Error(filterContext.Exception, "Unhandled Server Exception");
                base.OnException(filterContext);

                filterContext.Result = null;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = false;
            }
        }

        /// <summary>
        /// Determines whether this request is an API request.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        /// <returns>
        /// <c>true</c> if the request is an API request; otherwise, <c>false</c>.
        /// </returns>
        private bool IsApiRequest(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.AcceptTypes != null
                   && filterContext.HttpContext.Request.AcceptTypes.Contains("application/json");
        }

        /// <summary>
        /// Handles the exceptions raised by the API controllers exception.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        private void HandleApiException(ExceptionContext filterContext)
        {
            var validationException = filterContext.Exception as ValidationException;
            if (validationException != null)
            {
                this.HandleValidationException(validationException, filterContext);
            }
            else
            {
                var businessValidationException = filterContext.Exception as BusinessValidationException;
                var antiForgeryException = filterContext.Exception as HttpAntiForgeryException;

                if (businessValidationException != null)
                {
                    this.HandleBusinessValidationException(businessValidationException, filterContext);
                }
                else if (antiForgeryException != null)
                {
                    this.HandleAntiForgeryException(filterContext);
                }
                else
                {
                    this.HandleUnhandledException(filterContext);
                }
            }
        }

        /// <summary>The handle anti forgery exception.</summary>
        /// <param name="filterContext">The filter context.</param>
        private void HandleAntiForgeryException(ExceptionContext filterContext)
        {
            //Logger.Error(filterContext.Exception, "AntiForgery Exception");

            const string ErrorDescription = "Security issue, please logout and try again or if problem continues please contact the development team.";

            filterContext.Result = new JsonResult
            {
                Data =
                    new
                    {
                        error = HttpContext.Current.IsDebuggingEnabled ? filterContext.Exception.Message : ErrorDescription,
                    },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }

        /// <summary>
        /// Handles the exceptions no handled by any other code.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        private void HandleUnhandledException(ExceptionContext filterContext)
        {
            //Logger.Error(filterContext.Exception, "Unhandled Server Exception");

            const string ErrorDescription = "Try again or if problem continues please contact the development team.";

            filterContext.Result = new JsonResult
            {
                Data =
                    new
                    {
                        error = HttpContext.Current.IsDebuggingEnabled ? filterContext.Exception.Message : ErrorDescription,
                    },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        /// <summary>
        /// Handles the business validation exceptions.
        /// </summary>
        /// <param name="businessValidationException">
        /// The business validation exception.
        /// </param>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        private void HandleBusinessValidationException(
            BusinessValidationException businessValidationException, ExceptionContext filterContext)
        {
            filterContext.Result = new JsonResult
            {
                Data = new { errors = new[] { businessValidationException.Message } },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        /// <summary>
        /// Handles the fluent validation exception.
        /// </summary>
        /// <param name="validationException">
        /// The validation exception.
        /// </param>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        private void HandleValidationException(ValidationException validationException, ExceptionContext filterContext)
        {
            var errorMessages = validationException.Errors.Select(m => m.ErrorMessage);
            filterContext.Result = new JsonResult
            {
                Data = new { errors = errorMessages },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;


namespace ARF_APIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = new JsonMediaTypeFormatter();
            //optional: set serializer settings here
            config.Services.Replace(typeof(IContentNegotiator), new Formatters.JsonFormt(jsonFormatter));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Linq;

namespace SimpleAuth
{
   public static class UrlUtility
    {
	   public static Uri AddParameters(this Uri url, string name,string value)
	   {
		   return url.AddParameters(new Dictionary<string, string>
		   {
			   {name,value}
		   });
	   }
	   public static Uri AddParameters(this Uri url, Dictionary<string,string> parameters)
	   {

			var query = url.Query;
			var simplePath = string.IsNullOrWhiteSpace(query) ? url.AbsoluteUri : url.AbsoluteUri.Replace(query, "");

		   var existingParams = HttpUtility.ParseQueryString(query);
		   foreach (var key in parameters)
		   {
			   existingParams[key.Key] = parameters[key.Value];
		   }
		   var newQuery = existingParams.ToString();
			var newPath = $"{simplePath}?{newQuery}";
			return new Uri(newPath);
		}
    }
}
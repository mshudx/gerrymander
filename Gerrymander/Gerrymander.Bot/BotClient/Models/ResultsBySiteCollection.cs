﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Gerrymander.Bot.Models;
using Newtonsoft.Json.Linq;

namespace Gerrymander.Bot.Models
{
    public static partial class ResultsBySiteCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<ResultsBySite> DeserializeJson(JToken inputObject)
        {
            IList<ResultsBySite> deserializedObject = new List<ResultsBySite>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                ResultsBySite resultsBySite = new ResultsBySite();
                resultsBySite.DeserializeJson(iListValue);
                deserializedObject.Add(resultsBySite);
            }
            return deserializedObject;
        }
    }
}

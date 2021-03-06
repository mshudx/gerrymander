﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Gerrymander.ResulstApi.Models;
using Newtonsoft.Json.Linq;

namespace Gerrymander.ResulstApi.Models
{
    public static partial class ResultsByPartyCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<ResultsByParty> DeserializeJson(JToken inputObject)
        {
            IList<ResultsByParty> deserializedObject = new List<ResultsByParty>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                ResultsByParty resultsByParty = new ResultsByParty();
                resultsByParty.DeserializeJson(iListValue);
                deserializedObject.Add(resultsByParty);
            }
            return deserializedObject;
        }
    }
}

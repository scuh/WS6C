using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace ZTG.Customer.Client.WP8.Helper
{
public class CustomJsonSerializer : ISerializer
{
    public CustomJsonSerializer() 
    {
        ContentType = "application/json";
    }
 
    ///
    /// Serialize the object as JSON
    ///
    /// <param name="obj" />Object to serialize
    /// JSON as String
    public string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
 
    ///
    /// Unused for JSON Serialization
    ///
    public string DateFormat { get; set; }
    ///
    /// Unused for JSON Serialization
    ///
    public string RootElement { get; set; }
    ///
    /// Unused for JSON Serialization
    ///
    public string Namespace { get; set; }
    ///
    /// Content type for serialized content
    ///
    public string ContentType { get; set; }
}
}

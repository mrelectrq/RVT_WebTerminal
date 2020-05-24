using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVTLibrary.Models
{
    [DataContract]
    public class LoginMessage
    {
        [DataMember]
        public string IDNP { get; set; }
        [DataMember]
        public string VnPassword { get; set; }

        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(LoginMessage));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }

        public static LoginMessage Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(LoginMessage));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (LoginMessage)jsonSerializer.ReadObject(ms);
                return result;
            }
        }
    }
}

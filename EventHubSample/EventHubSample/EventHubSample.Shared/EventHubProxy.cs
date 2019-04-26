using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace EventHubSample
{

    public class EventHubProxy
    {
        //TODO: Set base url
        private static readonly string _baseUri = @"[BASE SERVICEBUS URL]";

        public static void SendSBMessage(string json)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var token = GetSharedAccessSignatureToken();
                    //The Azure service expects this header value
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature",
                        token);

                    HttpContent content = new StringContent(json, Encoding.UTF8);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //TODO: Set path to message
                    var path = "[PATH TO MESSAGE ENDPOINT]";

                    var response = client.PostAsync(path, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Do something
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle issue
            }
        }

        private static string GetSharedAccessSignatureToken()
        {
            //TODO: Add Rule Name and Key
            var keyName = "[RULE NAME]";
            var key = "[KEY]";

            var expiration = (int)DateTime.UtcNow.AddMinutes(20).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var stringToSign = WebUtility.UrlEncode(_baseUri) + "\n" + expiration ;
            var signature = HmacSha256(key, stringToSign);
            var token =
                $"sr={WebUtility.UrlEncode(_baseUri)}&sig={WebUtility.UrlEncode(signature)}&se={expiration }&skn={keyName}";

            return token;
        }

        private static string HmacSha256(string key, string value)
        {
            var keyStrm = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);
            var valueStrm = CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8);

            var objMacProv = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256);
            var hash = objMacProv.CreateHash(keyStrm);
            hash.Append(valueStrm);

            return CryptographicBuffer.EncodeToBase64String(hash.GetValueAndReset());
        }
    }
}

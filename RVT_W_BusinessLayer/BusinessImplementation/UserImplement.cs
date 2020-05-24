
using RVT_W_BusinessLayer.BusinessModels;
using RVT_W_BusinessLayer.Responses;
using RVTLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RVT_W_BusinessLayer.BusinessImplementation
{
    public class UserImplement
    {
        internal async Task<RegistrationResponse> RegistrationAction (RegistrationModel data)

        {
            var request = new RegistrationMessage();
            request.IDNP = data.IDNP;
            request.Name = data.Name;
            request.Ip_address = data.Ip_address;
            request.Surname = data.Surname;
            request.Gender = data.Gender;
            request.Birth_date = data.Birth_date;
            request.Phone_Number = data.Phone_Number;
            request.Email = data.Email;
            request.RegisterDate = data.RegisterDate;
            request.Region = data.Region;

            var data_req = request.Serialize();
            var content = new StringContent(data_req, Encoding.UTF8, "application/json");



            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(cert);
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44383/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            


            var request_api = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:44383/api/Register"),
                Method = HttpMethod.Post,  
            };
            



            var response = client.PostAsync("api/Register", content);

            // if (response.IsCompletedSuccessfully)
            // {
            try
            {
                var data_resp = await response.Result.Content.ReadAsStringAsync();
                var datatype = JsonDocument.Parse(data_resp);
                
            }
            catch(AggregateException e)
            {
                
            }
            return null;
        }
        internal async Task<AuthenticationResponse> LoginAction(LoginData data)
        {
            var request = new LoginMessage();
            request.IDNP = data.IDNP;
            request.VnPassword = data.VnPassword;

            var data_req = request.Serialize();
            var content = new StringContent(data_req, Encoding.UTF8, "application/json");



            var handler = new HttpClientHandler();
            //handler.ClientCertificates.Add(cert);
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44383/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            var request_api = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:44383/api/Auth"),
                Method = HttpMethod.Post,
            };




            var response = client.PostAsync("api/Auth", content);

            // if (response.IsCompletedSuccessfully)
            // {
            try
            {

                var data_resp = await response.Result.Content.ReadAsStringAsync();
                var datatype = JsonDocument.Parse(data_resp);
            }
            catch (AggregateException e)
            {

            }
            return null;
        }


    }
}

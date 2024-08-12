using CreateDataBaseSL.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBaseSL
{
    public class DataSL
    {
        private string _Host = string.Empty;

        public DataSL(string host)
        {
            _Host = host;
        }

        public bool CreateTables(string B1Session, List<UserTablesMD> userTables)
        {
            if (userTables != null)
            {
                foreach (var tablesMD in userTables)
                {
                    UserTablesMD userTablesMD = new UserTablesMD();
                    userTablesMD.TableName = tablesMD.TableName;
                    userTablesMD.TableDescription = tablesMD.TableDescription;
                    userTablesMD.TableType = tablesMD.TableType;

                    if (IsExistTable(B1Session, tablesMD.TableName) == false)
                    {
                        string output = JsonConvert.SerializeObject(userTablesMD);
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                        RestClient restClient = new RestClient(_Host);
                        RestRequest restRequest = new RestRequest("UserTablesMD", Method.POST);
                        restRequest.RequestFormat = DataFormat.Json;
                        restRequest.AddHeader("Content-Type", "application/json");
                        restRequest.AddJsonBody(output);
                        restRequest.AddCookie("B1SESSION", B1Session);
                        IRestResponse restResponse = restClient.Execute(restRequest);
                        if (restResponse != null)
                        {
                            //return restClient.Get<RetPost>(restRequest).Data;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CreateFields(string B1Session, Dictionary<string, List<UserFieldsMD>> userFields)
        {
            try
            {
                if (userFields != null)
                {
                    foreach (var item in userFields)
                    {                        
                        foreach (var userField in item.Value)
                        {
                            if (IsFieldsInTable(B1Session, userField.TableName,userField.Name) == false)
                            {
                                UserFieldsMD fieldsMD = new UserFieldsMD();
                                fieldsMD.Name = userField.Name;
                                fieldsMD.Description = userField.Description;
                                fieldsMD.Size = userField.Size;
                                fieldsMD.EditSize = userField.EditSize == 0 ? userField.Size : userField.EditSize;
                                fieldsMD.DefaultValue = userField.DefaultValue;
                                fieldsMD.TableName = userField.TableName;
                                fieldsMD.LinkedTable = userField.LinkedTable;
                                fieldsMD.Type = userField.Type;
                                fieldsMD.SubType = userField.SubType;
                                fieldsMD.Mandatory = userField.Mandatory;

                                if (userField.ValidValues != null)
                                    fieldsMD.ValidValues = userField.ValidValues;


                                string output = JsonConvert.SerializeObject(fieldsMD);

                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                                RestClient restClient = new RestClient(_Host);
                                RestRequest restRequest = new RestRequest("UserFieldsMD", Method.POST);
                                restRequest.RequestFormat = DataFormat.Json;
                                restRequest.AddHeader("Content-Type", "application/json");
                                restRequest.AddJsonBody(output);
                                restRequest.AddCookie("B1SESSION", B1Session);
                                IRestResponse restResponse = restClient.Execute(restRequest);
                            }
                           // Console.WriteLine($"Nome: {userField.Name}, Tabela: {userField.TableName}, Descrição: {userField.Description}");
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool IsExistTable(string SessionToken, string tableName)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                RestClient restClient = new RestClient(_Host);
                //RestRequest restRequest = new RestRequest("Invoices?$filter=U_RSD_PNArmazem ne null and U_RSD_CriadoEntrega eq 'N'", Method.GET);
                RestRequest restRequest = new RestRequest($"UserTablesMD?$filter=TableName eq '{tableName}' ", Method.GET);
                restRequest.RequestFormat = DataFormat.Json;
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddCookie("B1SESSION", SessionToken);
                IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse != null)
                {
                    if (restResponse.IsSuccessful)
                    {
                        var restReturn = restClient.Get<ReturnJsonUserTablesMD>(restRequest).Data;
                        if (restReturn.value != null)
                        {
                            if (restReturn.value.Count == 0)
                                return false;
                            else
                                return true;
                        }
                       
                    }
                        
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsFieldsInTable(string SessionToken, string tableName, string fieldName)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                RestClient restClient = new RestClient(_Host);
                //RestRequest restRequest = new RestRequest("Invoices?$filter=U_RSD_PNArmazem ne null and U_RSD_CriadoEntrega eq 'N'", Method.GET);
                RestRequest restRequest = new RestRequest($"UserFieldsMD?$filter=TableName eq '{tableName}' and Name eq '{fieldName}' ", Method.GET);
               
                restRequest.RequestFormat = DataFormat.Json;
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddCookie("B1SESSION", SessionToken);
                IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse != null)
                {
                    if (restResponse.IsSuccessful)
                    {
                        
                        var restReturn = restClient.Get<ReturnJsonUserFieldMD>(restRequest).Data;
                        if (restReturn.value != null)
                        {
                            if (restReturn.value.Count == 0)
                                return false;
                            else
                                return true;
                            
                        }
                        
                            
                    }

                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

   
}

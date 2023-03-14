using AppCustomer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppCustomer.ServiceCustomer
{
    public class ManagerCustomer : Customer
    {

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            try
            {
                customer.Status_Register = 1;

                string jsonCustomer = JsonSerializer.Serialize(customer);

                var data = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                string url = "https://localhost:7171/insertCustomer";

                using HttpClient client = new HttpClient();

                var response = await client.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public int FaixaEtaria(List<Customer> customers, string faixa)
        {

            if (faixa == "jovens")

            {
                var totalFaixa = customers
                    .Where(j => (DateTime.Now.Year - j.BirthdayCustomer.Year) >= 18 &&
                                (DateTime.Now.Year - j.BirthdayCustomer.Year) <= 25).Count();

                return totalFaixa;

            }

            if (faixa == "adultos")

            {
                var totalFaixa = customers
                    .Where(j => (DateTime.Now.Year - j.BirthdayCustomer.Year) >= 26 &&
                                (DateTime.Now.Year - j.BirthdayCustomer.Year) <= 49).Count();

                return totalFaixa;

            }

            if (faixa == "velhos")

            {

                var totalFaixa = customers
                    .Where(j => DateTime.Now.Year - j.BirthdayCustomer.Year > 50).Count();

                return totalFaixa;

            }

            return 0;
        }

        public async Task<bool> UpdateCustomerStatusRegister(string buscaEmail)
        {

            var customer = await QueryCustomer(buscaEmail);
            var id = customer.Id;
            var statusCode = 0;
            customer.Status_Register = statusCode;


            string jsonCustomer = JsonSerializer.Serialize(customer);

            var data = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

            string url = $"https://localhost:7171/updateCustomer/{id}";

            using HttpClient client = new HttpClient();

            var result = await client.PutAsync(url, data);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var id = customer.Id;

            if (id > 0)
            {

                string jsonCustomer = JsonSerializer.Serialize(customer);

                var data = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                string url = $"https://localhost:7171/updateCustomer/{id}";

                using HttpClient client = new HttpClient();

                var result = await client.PutAsync(url, data);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public StringBuilder ListCustomerBuilder(List<Customer> listCustomer)
        {
            var builder = new StringBuilder();

            if (listCustomer != null)
            {
                builder.AppendLine($"NOME DO CLIENTE;"
                    + $"EMAIL;"
                    + $"DATA DE NASCIMENTO;"
                    + $"TELEFONE;"
                    + $"CELULAR;"
                    + $"ENDERECO;"
                    + $"STATUS CADASTRO;");

                foreach (var customer in listCustomer)
                {
                    var dataWithTime = customer.BirthdayCustomer.Date;
                    var dataWithOutTime = dataWithTime.ToString("d");

                    builder.AppendLine($"{customer.NameCustomer};" +
                        $" {customer.EmailCustomer};" +
                        $" {dataWithOutTime};" +
                        $" {customer.PhoneCustomer};" +
                        $" {customer.CellPhoneCustomer};" +
                        $" {customer.Address};" +
                        $"{customer.Status_Register}");
                }
                return builder;
            }
            return builder;
        }

        public List<Customer> ListAllCustomer()
        {
            List<Customer> customer = null;

            try
            {
                var url = "https://localhost:7171/allCustomer";

                using var client = new HttpClient();

                var response = client.GetAsync(url);

                var content = response.Result.Content.ReadAsStringAsync();

                var jsonString = content.Result.ToString();

                JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);
                var jsonDeserializeCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString, _jsonOptions);

                return jsonDeserializeCustomer;

            }
            catch (Exception)
            {
                return customer;
            }

        }


        public async Task<Customer> QueryCustomer(string query)
        {
            var customer = new Customer();

            try
            {
                var uri = "https://localhost:7171/query";

                var builder = new UriBuilder(uri);

                builder.Query = $"queryCustomer={query}";

                var url = builder.ToString();

                using var client = new HttpClient();

                var response = await client.GetAsync(url);

                var content = response.Content.ReadAsStringAsync();

                var jsonString = content.Result.ToString();

                JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);

                var jsonDeserializeCustomer = JsonSerializer.Deserialize<Customer>(jsonString, _jsonOptions);

            
                return jsonDeserializeCustomer;
            }
            catch (Exception)
            {
                return customer;
            }
        }
    }
}
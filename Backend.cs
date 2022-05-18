using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projects
{

    class JsonFile
    {
        public string? Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
        public bool IsEligible { get; set; }

    }

    class Account : JsonFile
    {
        public void NewAccount(string _Name, int _AccountNumber, float _Balance, bool _IsEligible, DateTimeOffset _CreatedDate)
        {
            string Path = $"{Environment.CurrentDirectory}/Account.json";

            if (File.Exists(Path) == false) File.Create(Path);

            var AccountDetails = new JsonFile
            {
                Name = _Name,
                AccountNumber = _AccountNumber,
                Balance = _Balance,
                CreatedDate = _CreatedDate,
                IsEligible = _IsEligible
            };

            string JsonString = JsonSerializer.Serialize(AccountDetails);
            Console.WriteLine(JsonString);
            File.AppendAllText(Path, JsonString);
        }
    }
}

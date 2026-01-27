using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace P2PApp.src.accounts
{
    internal class JsonBankRepo : IBankRepository
    {
        private readonly string _filePath = "bank_storage.json";

        public BankStorage Load()
        {
            if (!File.Exists(_filePath))
                return new BankStorage();

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new BankStorage();

            return JsonSerializer.Deserialize<BankStorage>(json)
                   ?? new BankStorage();
        }

        public void Save(BankStorage data)
        {
            var json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(_filePath, json);
        }
    }
}

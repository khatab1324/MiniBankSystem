using System.Text.Json;
using System.Text.Json.Serialization;
using BankSystem.Dto;
using BankSystem.Models;

namespace BankSystem.Repositories;

public static class AccountRepo
{
    static string jsonFilePath = "Data/data.json";
    static List<AccountDto>? accountFile;

    public static AccountDto CreateAccount(AccountDto account)
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        accountFile = JsonSerializer.Deserialize<List<AccountDto>>(jsonContent) ?? [];
        account.AccountId = accountFile[accountFile.Count - 1].AccountId + 1;

        accountFile.Add(account);

        Console.WriteLine(JsonSerializer.Serialize(accountFile, new JsonSerializerOptions { WriteIndented = true }));
        File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(accountFile, new JsonSerializerOptions { WriteIndented = true }));
        return account;
    }
    public static AccountDto? GetAccount(int acountId)
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        accountFile = JsonSerializer.Deserialize<List<AccountDto>>(jsonContent);
        foreach (var item in accountFile)
        {
            if (item.AccountId == acountId) return item;
        }
        return null;
    }
}

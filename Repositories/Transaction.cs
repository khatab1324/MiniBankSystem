using System.Text.Json;
using System.Text.Json.Serialization;
using BankSystem.Dto;
using BankSystem.Models;

namespace BankSystem.Repositories;

public static class TransactionRepo
{
    static string filePath = "Data/data.json";
    static AccountDto? accountJson;
    public static TransactionDto CreateTransatcion(int accountId, TransactionDto transactionDto)
    {

        var accounts = JsonSerializer.Deserialize<List<AccountDto>>(File.ReadAllText(filePath));

        foreach (var item in accounts)
        {
            if (item.AccountId == accountId)
            {
                accountJson = item;
            }
        }
        if (accountJson != null)
        {
            transactionDto.TransactionId = accountJson.Transactions.Count == 0 ? 0 : accountJson.Transactions[accountJson.Transactions.Count - 1].TransactionId + 1;
            accountJson.Transactions.Add(transactionDto);
            accountJson.Amount += transactionDto.Amount;
            File.WriteAllText(filePath, JsonSerializer.Serialize(accounts, new JsonSerializerOptions() { WriteIndented = true }));
        }
        return transactionDto;

    }
}

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
            switch (transactionDto.TransactionType)
            {
                case Enum.TransactionType.Deposit:
                    accountJson.Amount += transactionDto.Amount;
                    break;
                case Enum.TransactionType.Withdrawal:
                    accountJson.Amount -= transactionDto.Amount;
                    break;

                case Enum.TransactionType.TrasferIn:
                    accountJson.Amount += transactionDto.Amount;
                    break;

                case Enum.TransactionType.TransferOut:
                    accountJson.Amount -= transactionDto.Amount;
                    break;
                default:
                    throw new Exception("wrooooong fields");
            }
            File.WriteAllText(filePath, JsonSerializer.Serialize(accounts, new JsonSerializerOptions() { WriteIndented = true }));
        }
        return transactionDto;
    }
    public static string TransferToAnotherAccount(int SenderAccountId, int ResiverAccountId, double TransferAmount)
    {
        var fileRead = File.ReadAllText(filePath);
        var accounts = JsonSerializer.Deserialize<List<AccountDto>>(fileRead);
        foreach (var account in accounts)
        {
            if (SenderAccountId == account.AccountId)
            {
                new Transaction(SenderAccountId, TransferAmount, Enum.TransactionType.TransferOut);
            }
            else if (ResiverAccountId == account.AccountId)
            {
                new Transaction(ResiverAccountId, TransferAmount, Enum.TransactionType.TrasferIn);
            }
        }

        var SenderAccount = AccountRepo.GetAccount(SenderAccountId);
        var ResiverAccount = AccountRepo.GetAccount(ResiverAccountId);

        return $"{SenderAccount.AccountId} {SenderAccount.Amount}JD {ResiverAccount.AccountId} {ResiverAccount.Amount}JD";
    }
}

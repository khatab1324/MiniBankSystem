
using System.Text.Json;
using BankSystem.Enum;
using BankSystem.Models;
using BankSystem.Repositories;

public class Program
{
    public static void Main()
    {
        // Account account = new Account(300, TypeAccount.JD);
        // var userAccount = account.GetAccount();
        // System.Console.WriteLine(JsonSerializer.Serialize(userAccount));
        // Transaction transaction = new Transaction(2, 200, TransactionType.Deposit);
        // Transaction transaction1 = new Transaction(2, 200, TransactionType.Withdrawal);
        // Transaction transactio2 = new Transaction(2, 200, TransactionType.Deposit);
        System.Console.WriteLine(TransactionRepo.TransferToAnotherAccount(0, 2, 200));
    }
}
using BankSystem.Dto;
using BankSystem.Enum;
using BankSystem.Repositories;

namespace BankSystem.Models;

public class Account
{
    public int AccountId { get; set; }
    public double Amount { get; set; }

    public TypeAccount TypeAccount { get; set; }
    public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

    public Account(double amount, TypeAccount typeAccount)
    {
        AccountId = AccountRepo.CreateAccount(new AccountDto() { AccountId = AccountId, Amount = Amount, TypeAccount = TypeAccount, Transactions = [] }).AccountId;
        Amount = amount;
        TypeAccount = typeAccount;
    }
    public AccountDto? GetAccount(int accountid)
    {
        return AccountRepo.GetAccount(accountid);
    }
    public AccountDto? GetAccount()
    {
        return AccountRepo.GetAccount(AccountId);
    }
}
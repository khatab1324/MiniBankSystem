using BankSystem.Dto;
using BankSystem.Enum;
using BankSystem.Repositories;

namespace BankSystem.Models;

public class Transaction
{
    private static int _nextTransactionId = 0;
    public int TransactionId { get; set; }
    public double Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;

    public Transaction(int accountId, double amount, TransactionType transactionType)
    {
        this.TransactionId = TransactionRepo.CreateTransatcion(accountId, new TransactionDto() { Amount = amount, TransactionType = transactionType }).TransactionId;
        this.Amount = amount;
        this.TransactionType = transactionType;
    }





}
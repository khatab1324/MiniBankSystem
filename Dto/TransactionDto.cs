using BankSystem.Enum;

public class TransactionDto
{
    public int TransactionId { get; set; }
    public double Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
using BankSystem.Enum;

namespace BankSystem.Dto;

public class AccountDto
{
    public int AccountId { get; set; }
    public double Amount { get; set; }

    public TypeAccount TypeAccount { get; set; }
    public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

}
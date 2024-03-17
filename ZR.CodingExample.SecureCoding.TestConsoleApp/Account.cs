

using System;
namespace ZR.CodingExample.SecureCoding.TestConsoleApp;
public class Account
{
    public decimal Balance { get; set; }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient balance.");
        }

        Balance -= amount;
    }
}


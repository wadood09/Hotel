using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models.Enums;

namespace BankApp.Models.Entities
{
    public class Transfer : BaseEntity
    {
        public string RefNumber;
        public double Amount;
        public string Description;
        public TransferStatus Status;
        public string SenderAccountNumber;
        public string ReceiverAccountNumber;

        public Transfer(int sN, string refNumber, double amount, string description, TransferStatus status, string sender, string receiver ) : base(sN)
        {
            RefNumber = refNumber;
            Amount = amount;
            Description = description;
            Status = status;
            SenderAccountNumber = sender;
            ReceiverAccountNumber = receiver;
        }
    }
}
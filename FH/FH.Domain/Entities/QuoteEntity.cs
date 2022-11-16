using FH.Domain.Exceptions;
using FH.Domain.ValueObjects;
using System;

namespace FH.Domain.Entities
{
    public class QuoteEntity : BaseEntity
    {
        public string BaseCcy { get; private set; } = string.Empty;
        public string QuoteCcy { get; private set; } = string.Empty;
        public decimal Amount { get; private set; } = -1;
        public decimal QuoteAmount { get; private set; } = -1;
        public DateTime Date { get; set; } = DateTime.Now.Date;
        public decimal Value { get; set; }

        public QuoteEntity()
        {
            Id = new QuoteEntityId().Create();
        }

        public QuoteEntity(string baseCcy, string quoteCcy, decimal amount)
        {
            try
            {
                Validate(baseCcy, quoteCcy, amount);

                Id = new QuoteEntityId().Create();
                BaseCcy = baseCcy;
                QuoteCcy = quoteCcy;
                Amount = amount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static QuoteEntity CalculateQuoteAmount(SpotRate spotRate, decimal amount)
        {
            var quote = new QuoteEntity();
            quote.BaseCcy = spotRate.BaseCurrencyCode;
            quote.QuoteCcy = spotRate.ExchangeCurencyCode;
            quote.QuoteAmount = spotRate.Value * amount;
            quote.Value = spotRate.Value;

            return quote;
        }

        public override void Validate(string baseCcy, string quoteCcy, decimal amount)
        {
            if (string.IsNullOrEmpty(baseCcy))
                throw new InvalidQuoteEntityException("Base Currency must contain a value");

            if(string.IsNullOrEmpty(quoteCcy))
                throw new InvalidQuoteEntityException("Quote Currency must contain a value");

            if(amount < 0)
                throw new InvalidQuoteEntityException("Amount cannot be less than 0");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string IdNumber { get; set; }
        public String DiscountType { get; set; }
    }

    public class Card
    {
        private double fund;
        public string cardNumber;
        private readonly PersonalDetails personalDetails;
        private bool physical;

        public Card()
        {
            this.physical = true;
            Initialize();
        }

        public Card(PersonalDetails personalDetails, bool physical)
        {
            Initialize();
            this.personalDetails = personalDetails;
            this.physical = physical;
        }

        private void Initialize()
        {
            Random random = new Random();
            for (int i = 0; i <= 4; i++)
            {
                this.cardNumber += random.Next(1000, 9999);
            }

            this.fund = 0;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("You must deposit a positive amount");
            }

            this.fund += amount;
        }
        public void Charge(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("You must charge a positive amount");
            }

            double discountedAmount = ApplyDiscount(amount);

            if (this.fund - discountedAmount < 0)
            {
                throw new Exception("You do not have enough funds to make this payment");
            }

            this.fund -= discountedAmount;
        }
        private double ApplyDiscount(double applyTo)
        {
            if (this.personalDetails == null)
            {
                return applyTo;
            }

            return applyTo * (double)dictionary[this.personalDetails.DiscountType];
        }

        private readonly Dictionary<string, double> dictionary = new Dictionary<string, double>()
        {
            {"Student", 0.25},
            {"PublicServant", 0.75},
            {"Senior", 0.4},
            {"None", 1},
        };

        public override string ToString()
        {
            string result = $"Card number: {this.cardNumber}" + Environment.NewLine;
            result = result + $"Funds: {this.fund}" + Environment.NewLine;

            string type = this.physical ? "physical" : "digital";
            result = result + $"Type: {type}" + Environment.NewLine;

            if (personalDetails != null)
            {
                result = result + $"Registered to" + Environment.NewLine;
                result = result + $"Id :{this.personalDetails.IdNumber}" + Environment.NewLine;

                result = result + $"Name: {this.personalDetails.Name}" + Environment.NewLine;
                result = result + $"Surname: {this.personalDetails.SurName}" + Environment.NewLine;
                result = result + $"Discount type: {this.personalDetails.DiscountType}" + Environment.NewLine;
            }

            return result;
        }

    }
}

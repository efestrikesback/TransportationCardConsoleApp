
using Classes;
class Program
{
    private static Card card;
    static void Main(string[] args)
    {
        card = CardWizard.CreateCard();
        while (true)
        {
            PrintMainMenu();
        }

    }

    static void PrintMainMenu()
    {

        Console.WriteLine("Select and option.");
        Console.WriteLine("1 Deposit funds.");
        Console.WriteLine("2 Take a ride.");
        Console.WriteLine("3 Display account.");
        Console.WriteLine("4 Exit program.");

        int selectedOption = Convert.ToInt32(Console.ReadLine());

        if (selectedOption == 1)
        {
            Console.WriteLine("Enter amount to deposit.");
            card.Deposit(double.Parse(Console.ReadLine()));
        }

        if (selectedOption == 2)
        {
            Console.WriteLine("Enter ticket price.");
            try
            {
                double amount = double.Parse(Console.ReadLine());
                card.Charge(amount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        if (selectedOption == 3)
        {
            Console.WriteLine(card.ToString());
        }

        if (selectedOption == 4)
        {
            Environment.Exit(0);
        }
    }
}

#region  Gandalf Selection Wizard 
public class CardWizard
{
    public static Card CreateCard()
    {
        Console.WriteLine("Let's create your card...");

        Console.WriteLine("Select card type");
        Console.WriteLine("1 Digital");
        Console.WriteLine("2 Physical");
        Console.WriteLine("3 Physical anonymous");

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                return DigitalCardWizard();
            case 2:
                return PhysicalCardWizard();
            case 3:
                return new Card();
            default: throw new Exception("You can only choose 1, 2 or 3 ");
        }
    }

    private static Card PhysicalCardWizard()
    {
        Console.WriteLine("Would you like to register your card?");
        Console.WriteLine("1 Yes");
        Console.WriteLine("2 No");

        if (Convert.ToInt32(Console.ReadLine()) == 2)
        {
            return new Card();
        }

        return new Card(PersonalDetailsWizard(), true);

    }

    private static Card DigitalCardWizard()
    {
        return new Card(PersonalDetailsWizard(), false);
    }

    private static PersonalDetails PersonalDetailsWizard()
    {
        Console.WriteLine("Enter id number");
        string idNumber = Console.ReadLine();

        Console.WriteLine("Enter name");
        string name = Console.ReadLine();

        Console.WriteLine("Enter surname");
        string surname = Console.ReadLine();


        Console.WriteLine("Select discount type");
        Console.WriteLine("1 Student");
        Console.WriteLine("2 Senior");
        Console.WriteLine("3 Public servant");
        Console.WriteLine("4 No discount");

        int discountType = Convert.ToInt32(Console.ReadLine());

        PersonalDetails personalDetails = new PersonalDetails()
        {
            IdNumber = idNumber,
            Name = name,
            SurName = surname
        };

        switch (discountType)
        {
            case 1:
                personalDetails.DiscountType = "Student";
                break;
            case 2:
                personalDetails.DiscountType = "Senior";
                break;
            case 3:
                personalDetails.DiscountType = "Public servant";
                break;
            default:
                personalDetails.DiscountType = "None";
                break;
        }

        return personalDetails;
    }
}

#endregion 

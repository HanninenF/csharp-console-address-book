namespace L07;

static class Program
{
    static List<string> names = [];
    static List<string> phoneNumbers = [];

    public static void Main()
    {
        /*     Krav
        Meny
        Programmet ska visa en meny med fyra val:
        
        Lägg till kontakt
        Lista kontakter
        Sök kontakt
        Avsluta programmet */

        while (true)
        {
            Console.WriteLine("ADRESSBOK v1\n------------");
            Console.WriteLine("1) Lägg till kontakt");
            Console.WriteLine("2) Lista kontakter");
            Console.WriteLine("3) Sök kontakt");
            Console.WriteLine("Avsluta\n");
            Console.Write("Val: ");
            string input = Console.ReadLine() ?? "";
            int userSelect = int.Parse(input);

            switch (userSelect)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    ListContacts();
                    break;
                case 3:
                    SearchContact();
                    break;
                default:
                    break;
            }
        }
    }

    private static void AddContact()
    {
        string namePrompt = "var god mata in namn:";
        string phoneNumberPrompt = "var god mata in telefonnummer:";

        Console.WriteLine(namePrompt);
        string? nameInput = Console.ReadLine();

        if (nameInput != null)
        {
            names.Add(nameInput);
        }

        Console.WriteLine(phoneNumberPrompt);
        string? phoneNumberInput = Console.ReadLine();

        if (phoneNumberInput != null)
        {
            phoneNumbers.Add(phoneNumberInput);
        }
    }

    private static void ListContacts()
    {
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine($"{names[i]}: {phoneNumbers[i]}");
        }
    }

    private static void SearchContact() { }
}

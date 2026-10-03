namespace L07;

static class Program
{
    /*    static List<string> names = [];
       static List<string> phoneNumbers = []; */

    static List<Contact> contacts = [];

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
            Console.WriteLine("3) Ta bort kontakt");
            Console.WriteLine("4) Sök kontakt");
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
                    DeleteContact();
                    break;
                case 4:
                    Contact? searchResultContact = SearchContact();
                    if (searchResultContact == null)
                        Console.WriteLine("Ingen träff");
                    else
                        Console.WriteLine(
                            $"{searchResultContact.GetName()}: {searchResultContact.GetPhone()}"
                        );
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
        string nameInput = Console.ReadLine() ?? "";

        Console.WriteLine(phoneNumberPrompt);
        string? phoneNumberInput = Console.ReadLine() ?? "";
        int parsedPhoneNumber = int.Parse(phoneNumberInput);

        if (nameInput != null && phoneNumberInput != null)
        {
            Contact contact = new(nameInput, parsedPhoneNumber);

            contacts.Add(contact);
        }
    }

    private static void ListContacts()
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine($"{contacts[i].GetName()}: {contacts[i].GetPhone()}");
        }
    }

    private static void DeleteContact()
    {
        string indexPrompt = "var god mata in ett index:";

        Console.WriteLine(indexPrompt);
        string? indexInput = Console.ReadLine() ?? "";
        int index = int.Parse(indexInput);
        contacts.RemoveAt(index);
    }

    private static Contact? SearchContact()
    {
        string searchPrompt = "Var god ange sökord: ";
        Console.WriteLine(searchPrompt);

        string searchInput = Console.ReadLine() ?? "";
        Contact? searchResultContact = contacts.Find(contact => MatchesName(contact, searchInput));
        if (searchResultContact == null)
        {
            searchResultContact = contacts.Find(contact => MatchesNumber(contact, searchInput));
            if (searchResultContact != null)
                return searchResultContact;
            else
                return null;
        }
        else
            return searchResultContact;
    }

    private static bool MatchesName(Contact contact, string searchInput)
    {
        return contact.GetName().Trim().ToLower().Contains(searchInput.Trim().ToLower());
    }

    private static bool MatchesNumber(Contact contact, string searchInput)
    {
        int.TryParse(searchInput, out int input);
        return contact.GetPhone() == input;
    }
}

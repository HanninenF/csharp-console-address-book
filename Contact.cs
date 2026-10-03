namespace L07;

public class Contact(string name, int phone)
{
    string Name { get; set; } = name;
    int Phone { get; set; } = phone;

    public string GetName()
    {
        return Name;
    }

    public int GetPhone()
    {
        return Phone;
    }
}

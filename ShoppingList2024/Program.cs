Dictionary<string, decimal> items = new Dictionary<string, decimal>()
{
    {"Apple", 1.00m },
    {"Eggs", 6.25m },
    {"Bread", 8.00m },
    {"Chips", 3.00m },
    {"Ice Cream", 5.00m },
    {"Paper Towel", 3.10m },
    {"Popcorn", 6.99m },
    {"Soap", 2.30m }
};
Dictionary<string, decimal> itemsOrdered = items.OrderBy(x => x.Value).ToDictionary(StringComparer.OrdinalIgnoreCase);
List<string> cart = new List<string>();
decimal sum = 0;
bool loop = true;

while (loop)
{

    Console.WriteLine("Welcome!");
    Console.WriteLine("\n{0,-20} {1, 0}", "Items", "Price");
    Console.WriteLine("==================================");

    foreach (KeyValuePair<string, decimal> item in itemsOrdered)
    {
        Console.WriteLine("{0,-20} {1, 0}", item.Key, item.Value);
    }

    Console.WriteLine("\n\nCart:");

    foreach (string s in cart)
    {
        Console.WriteLine(s);
    }

    Console.WriteLine();

    Console.WriteLine("Your total: $" + sum);


    Console.Write("\nWhat would you like to add to your cart? ");
    string choice = Console.ReadLine().ToLower();

    if (itemsOrdered.ContainsKey(choice))
    {
        choice = CapitalizeFirstOfEveryWord(choice);

        cart.Add(choice);
        sum += itemsOrdered[choice];
        Console.WriteLine("\n" + choice + " added.");
    }
    else
    {
        Console.WriteLine("\nThat's not a valid choice");
    }

    while (true)
    {
        Console.Write("\nWould you like to add another item? (y/n) ");
        string loopChoice = Console.ReadLine().ToLower();

        if (loopChoice == "y")
        {
            Console.Clear();
            break;
        }
        else if (loopChoice == "n")
        {
            Console.Clear();
            Console.WriteLine("Finalized cart: ");

            foreach (string s in cart)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nYour total is $" + sum);
            loop = false;
            break;
        }
        else
        {
            Console.WriteLine("That is not y or n. Please select again.");
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}

static string CapitalizeFirstLetter(string s)
{
    if (string.IsNullOrEmpty(s))
    {
        return s;
    }

    return char.ToUpper(s[0]) + s.Substring(1);
}

static string CapitalizeFirstOfEveryWord(string s)
{
    string[] words = s.Split(' ');

    for (int i = 0; i < words.Length; i++)
    {
        words[i] = CapitalizeFirstLetter(words[i]);
    }

    return string.Join(" ", words);

}
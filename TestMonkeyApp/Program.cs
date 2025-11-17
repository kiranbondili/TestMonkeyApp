
using MyMonkeyApp;

/// <summary>
/// Main entry point for the Monkey Console Application.
/// </summary>
class Program
{
	static async Task Main(string[] args)
	{
		Console.WriteLine("Welcome to Monkey Console App!");

		// Simulate async fetch from monkeymcp server
		await MonkeyHelper.LoadMonkeysAsync(FetchMonkeysFromServerAsync);

		while (true)
		{
			Console.WriteLine("\nMenu:");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Search for a monkey");
			Console.WriteLine("3. Pick a random monkey");
			Console.WriteLine("4. Exit");
			Console.Write("Select an option: ");

			var input = Console.ReadLine();
			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					SearchMonkey();
					break;
				case "3":
					PickRandomMonkey();
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
		}
	}

	/// <summary>
	/// Fetches monkeys from the monkeymcp server (static data for now).
	/// </summary>
	private static async Task<List<Monkey>> FetchMonkeysFromServerAsync()
	{
		await Task.Delay(500); // Simulate network delay
		return new List<Monkey>
		{
			new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae." },
			new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus." },
			new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia" },
			new Monkey { Name = "Squirrel Monkey", Location = "Central & South America", Population = 11000, Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers." },
			new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 19000, Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae." },
			new Monkey { Name = "Howler Monkey", Location = "South America", Population = 8000, Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae." },
			new Monkey { Name = "Japanese Macaque", Location = "Japan", Population = 1000, Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each" },
			new Monkey { Name = "Mandrill", Location = "Southern Cameroon, Gabon, and Congo", Population = 17000, Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo." },
			new Monkey { Name = "Proboscis Monkey", Location = "Borneo", Population = 15000, Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo." },
			new Monkey { Name = "Sebastian", Location = "Seattle", Population = 1, Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!" },
			new Monkey { Name = "Henry", Location = "Phoenix", Population = 1, Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!" },
			new Monkey { Name = "Red-shanked douc", Location = "Vietnam", Population = 1300, Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest." },
			new Monkey { Name = "Mooch", Location = "Seattle", Population = 1, Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!" }
		};
	}

	private static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		if (monkeys.Count == 0)
		{
			Console.WriteLine("No monkeys found.");
			return;
		}
		Console.WriteLine("\nAvailable Monkeys:");
		foreach (var monkey in monkeys)
		{
			Console.WriteLine($"- {monkey.Name} ({monkey.Location}) | Population: {monkey.Population}");
		}
	}

	private static void SearchMonkey()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
		if (monkey == null)
		{
			Console.WriteLine("Monkey not found.");
			return;
		}
		Console.WriteLine($"Found: {monkey.Name} ({monkey.Location}) | Population: {monkey.Population}\nDetails: {monkey.Details}");
	}

	private static void PickRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey == null)
		{
			Console.WriteLine("No monkeys available.");
			return;
		}
		Console.WriteLine($"Random Monkey: {monkey.Name} ({monkey.Location}) | Population: {monkey.Population}\nDetails: {monkey.Details}");
	}
}

public class BackgroundOperation
{
    static WriteToFile write = new WriteToFile();

    public static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("System Menu:");
            Console.WriteLine("1. Write 'Hello World'");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await WriteToFileAsync("Hello World");
                    Console.WriteLine("Writing 'Hello World'.");
                    break;
                case "2":
                    await WriteToFileAsync(DateTime.Now.ToString("yyyy-MM-dd"));
                    Console.WriteLine("Writing current date.");
                    break;
                case "3":
                    await WriteToFileAsync($"OS: {Environment.OSVersion.Platform}, Version: {Environment.OSVersion.VersionString}");
                    Console.WriteLine("Writing OS Version.");
                    break;
                case "4":
                    Console.WriteLine("Exiting the menu.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static async Task WriteToFileAsync(string message)
    {
        await write.WriteToFileAsync(message);
    }
}

public class WriteToFile
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000); 
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}
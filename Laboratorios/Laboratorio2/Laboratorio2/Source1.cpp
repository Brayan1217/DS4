internal class Program
{
	private static void Main(string[] args)
	{
		Client client = new Client();
		client.FirstName = "Brayan";
		client.LastName = "Martinez";
		client.Age = 24;
		client.Id = 1;

		console.WriteLine(client.GetFullName());
	}
}
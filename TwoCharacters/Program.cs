class Program
{
	public static void Main()
	{
		var solution = new Solution();
		Console.WriteLine("abaacdabd: " + solution.Calculate("abaacdabd"));
		Console.WriteLine("beabeefeab: " + solution.Calculate("beabeefeab"));
	}
}
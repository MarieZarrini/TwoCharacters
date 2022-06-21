using System.Text;

public class Solution
{
	private string _input;

	public string Calculate(string input)
	{
		_input = input;
		var permutations = FindPermutations();
		return CalculateTwoCharacters(permutations);
	}


	private List<(char, char)> FindPermutations()
	{
		List<char> distinctInput = _input.Distinct().ToList();
		List<(char, char)> permutations = new();

		for (int i = 0; i <= distinctInput.Count; i++)
		{
			for (int j = i + 1; j < distinctInput.Count; j++)
				permutations.Add((distinctInput[i], distinctInput[j]));
		}

		return permutations;
	}

	private string CalculateTwoCharacters(List<(char, char)> permutations)
	{
		StringBuilder result = new(), temp = new();

		foreach (var permutation in permutations)
		{
			foreach (var character in _input)
			{
				bool isCharacterInPermutation = (character == permutation.Item1 || character == permutation.Item2);

				if (isCharacterInPermutation == false)
				{
					if (temp.Length == 0 || temp[^1] != character)
						temp.Append(character);
					else
					{
						temp.Clear();
						break;
					}
				}
			}

			bool isQualifiedForResult = temp.Length != 0 && result.Length == 0 || (temp.Length > result.Length);
			if (isQualifiedForResult)
			{
				result.Append(temp);
				temp.Clear();
			}
		}

		return result.ToString();
	}
}
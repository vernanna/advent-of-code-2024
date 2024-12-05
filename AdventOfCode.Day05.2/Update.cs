using AdventOfCode.Shared;

namespace AdventOfCode.Day05._2;

public record Update(List<int> PageNumbers)
{
    public int MiddlePageNumber => PageNumbers.ElementAt(PageNumbers.Count / 2);

    public Update WithSortedPages(List<Rule> rules)
    {
        var newPageNumbers = new List<int>();
        foreach (var pageNumber in PageNumbers)
        {
            var smallerPageNumbers = rules.Where(rule => rule.SecondPageNumber == pageNumber).Select(rule => rule.FirstPageNumber).ToList();
            var index = newPageNumbers.TakeWhile(p => smallerPageNumbers.Contains(p)).Count();
            newPageNumbers.Insert(index, pageNumber);
        }

        PageNumbers.Clear();
        PageNumbers.AddRange(newPageNumbers);

        return this;
    }

    public static Update Parse(string input)
    {
        var numbers = input.GetNumbers(",").ToList();

        return new Update(numbers);
    }
}
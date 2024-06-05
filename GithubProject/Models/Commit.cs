namespace GithubProject.Models
{
    public class Commit
    {
        public required string Message { get; set; }
        public required DateTime Date { get; set; }
        public required List<string> Archives { get; set; }

        public override string ToString()
        {
            return $"Commit: {Message}\nDate: {Date}\nFiles:\n{string.Join("\n", Archives)}";
        }
    }

}

using GithubProject.Models;

namespace GithubProject.Services
{
    public class Repository
    {
        private List<string> stagingArea = new List<string>();
        private List<Commit> localsCommits = new List<Commit>();
        private List<Commit> remoteCommits = new List<Commit>();

        public IReadOnlyList<string> StagingArea => stagingArea.AsReadOnly();
        public IReadOnlyList<Commit> LocalCommits => localsCommits.AsReadOnly();
        public IReadOnlyList<Commit> RemoteCommits => remoteCommits.AsReadOnly();

        public void Add(IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                stagingArea.Add(fileName);
                Console.WriteLine($"File {fileName} added to staging area");
            }
        }

        public void Commit(string message)
        {
            if (stagingArea.Count == 0)
            {
                Console.WriteLine("nothing to commit, working tree clean");
                return;
            }

            var commit = new Commit()
            {
                Message = message,
                Date = DateTime.Now,
                Archives = new List<string>(stagingArea)
            };

            localsCommits.Add(commit);
            stagingArea.Clear();

            Console.WriteLine($"Commit: {commit.Message}");
            Console.WriteLine($"{commit.Archives.Count} files changed");
            Console.WriteLine("Commit successfully");
        }

        public void Push()
        {
            if (localsCommits.Count == 0)
            {
                Console.WriteLine("There are no commits to submit");
            }
            else
            {
                remoteCommits.AddRange(localsCommits);
                localsCommits.Clear();

                Console.WriteLine("Local commits have been successfully pushed to the remote server.");
            }
        }

        public void Status()
        {
            Console.WriteLine("On branch main");

            if (stagingArea.Count > 0)
            {
                Console.WriteLine("Changes to be committed:");
                foreach (var file in stagingArea)
                {
                    Console.WriteLine($"  modified: {file}");
                }
            }
            else
            {
                Console.WriteLine("No changes added to commit");
            }

            if (localsCommits.Count > 0)
            {
                Console.WriteLine("Changes not yet pushed:");
                foreach (var commit in localsCommits)
                {
                    Console.WriteLine($"  commit: {commit.Message}");
                }
            }
        }

        public void Log()
        {
            if (localsCommits.Count == 0 && remoteCommits.Count == 0)
            {
                Console.WriteLine("No commits to show");
                return;
            }

            Console.WriteLine("Commit history");

            foreach (var commit in localsCommits)
            {
                Console.WriteLine(commit);
            }

            foreach (var commit in remoteCommits)
            {
                Console.WriteLine(commit);
            }

        }

        public void Revert()
        {
            if (localsCommits.Count == 0 && remoteCommits.Count == 0)
            {
                Console.WriteLine("No commits to revert.");
                return;
            }

            if (remoteCommits.Count > 0)
            {
                Commit lastRemoteCommit = remoteCommits[remoteCommits.Count - 1];
                remoteCommits.RemoveAt(remoteCommits.Count - 1);
                Console.WriteLine($"Reverted last remote commit: {lastRemoteCommit.Message}");
            }
            else if (localsCommits.Count > 0)
            {
                Commit lastLocalCommit = localsCommits[localsCommits.Count - 1];
                localsCommits.RemoveAt(localsCommits.Count - 1);
                Console.WriteLine($"Reverted last local commit: {lastLocalCommit.Message}");
            }
        }

        public void Help()
        {
            Console.WriteLine("Available commands");
            Console.WriteLine("git add <file_name> - Adds a file to the staging area");
            Console.WriteLine("git commit <message> - Commit the files in the staging area");
            Console.WriteLine("git push - Send local commits to the remote server");
            Console.WriteLine("git status - Shows the current status of the repository");
            Console.WriteLine("git log - Shows commit history");
            Console.WriteLine("git revert - Revert the last commit");
            Console.WriteLine("git help - Show this help");
            Console.WriteLine("git exit - Exit the Git interface.");
        }
    }
}

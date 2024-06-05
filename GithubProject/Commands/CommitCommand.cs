using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Class
{
    public class CommitCommand(Repository repository, string message) : ICommand
    {
        private readonly Repository _repository = repository;

        public void Execute()
        {
            _repository.Commit(message);
        }
    }
}

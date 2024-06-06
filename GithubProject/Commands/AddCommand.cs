using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Commands
{
    public class AddCommand(Repository repository, IEnumerable<string> archive) : ICommand
    {
        private readonly Repository _repository = repository;
        public void Execute()
        {
            _repository.Add(archive);
        }
    }
}

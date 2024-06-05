using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Commands
{
    public class AddCommand(Repository repository, string archive) : ICommand
    {
        private readonly Repository _repository = repository;
        public void Execute()
        {
            _repository.Add(archive);
        }
    }
}

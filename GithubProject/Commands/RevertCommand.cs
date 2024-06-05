using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Commands
{
    public class RevertCommand(Repository repository) : ICommand
    {
        private readonly Repository _repository = repository;
        public void Execute()
        {
            _repository.Revert();
        }

    }
}

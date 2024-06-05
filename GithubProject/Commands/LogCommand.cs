using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Commands
{
    public class LogCommand(Repository repository) : ICommand
    {
        private readonly Repository _repository = repository;

        public void Execute()
        {
            _repository.Log();
        }
    }
}

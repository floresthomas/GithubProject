using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Commands
{
    public class StatusCommand(Repository repository) : ICommand
    {
        public void Execute()
        {
            repository.Status();
        }
    }
}

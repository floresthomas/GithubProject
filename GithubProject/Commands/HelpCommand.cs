using GithubProject.Interfaces;
using GithubProject.Services;

namespace GithubProject.Commands
{
    public class HelpCommand(Repository repository) : ICommand
    {
        public void Execute()
        {
            Repository.Help();
        }
    }
}

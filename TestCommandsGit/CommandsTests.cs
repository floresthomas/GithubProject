using GithubProject.Class;
using GithubProject.Commands;
using GithubProject.Services;

namespace TestCommandsGit
{
    public class CommandsTests
    {
        private Repository _repository;

        public CommandsTests()
        {
            _repository = new Repository();
        }

        [Fact]
        public void AddCommand_Execute_AddsFileToRepository()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var addCommand = new AddCommand(_repository, "test.txt");
                addCommand.Execute();
                Assert.Contains("test.txt", _repository.StagingArea);
            }
        }

        [Fact]
        public void CommitCommand_Execute_CommitsStagedFiles()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _repository.Add("test.txt");
                var commitCommand = new CommitCommand(_repository, "Initial commit");
                commitCommand.Execute();
                Assert.Empty(_repository.StagingArea);
                Assert.Single(_repository.LocalCommits);
                Assert.Equal("Initial commit", _repository.LocalCommits[0].Message);
            }
        }

        [Fact]
        public void PushCommand_Execute_PushesLocalCommitsToRemote()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _repository.Add("test.txt");
                _repository.Commit("Initial commit");
                var pushCommand = new PushCommand(_repository);
                pushCommand.Execute();
                Assert.Empty(_repository.LocalCommits);
                Assert.Single(_repository.RemoteCommits);
            }
        }

        [Fact]
        public void StatusCommand_Execute_DisplaysCurrentStatus()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var statusCommand = new StatusCommand(_repository);
                statusCommand.Execute();
                var result = sw.ToString().Trim();
                Assert.Contains("On branch main", result);
            }
        }

        [Fact]
        public void LogCommand_Execute_DisplaysCommitHistory()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var logCommand = new LogCommand(_repository);
                _repository.Add("test.txt");
                _repository.Commit("Initial commit");
                logCommand.Execute();
                var result = sw.ToString().Trim();
                Assert.Contains("Commit history", result);
                Assert.Contains("Initial commit", result);
            }
        }

        [Fact]
        public void RevertCommand_Execute_RevertsLastCommit()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _repository.Add("test.txt");
                _repository.Commit("Initial commit");
                var revertCommand = new RevertCommand(_repository);
                revertCommand.Execute();
                Assert.Empty(_repository.LocalCommits);
            }
        }
    }
}
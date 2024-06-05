using GithubProject.Commands;
using GithubProject.Services;

namespace TestGit
{
    public class PushCommandTests
    {
        [Fact]
        public void PushCommand_ShouldPushCommitsToRemote()
        {
            // Arrange
            var repository = new Repository();
            repository.Add("testFile.txt");
            repository.Commit("Initial commit");
            var pushCommand = new PushCommand(repository);

            // Act
            pushCommand.Execute();

            // Assert
            Assert.Empty(repository.LocalCommits);
            Assert.Single(repository.RemoteCommits);
            Assert.Equal("Initial commit", repository.RemoteCommits[0].Message);
        }
    }
}

using GithubProject.Class;
using GithubProject.Services;

namespace TestGit
{
    public class CommitCommandTests
    {
        [Fact]
        public void CommitCommand_ShouldCreateNewCommit()
        {
            // Arrange
            var repository = new Repository();
            repository.Add("testFile.txt");
            var commitCommand = new CommitCommand(repository, "Initial commit");

            // Act
            commitCommand.Execute();

            // Assert
            Assert.Single(repository.LocalCommits);
            Assert.Equal("Initial commit", repository.LocalCommits[0].Message);
            Assert.Contains("testFile.txt", repository.LocalCommits[0].Archives);
        }
    }
}

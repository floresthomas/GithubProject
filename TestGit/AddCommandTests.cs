using GithubProject.Services;
using GithubProject.Commands;

namespace TestGit
{
    public class AddCommandTests
    {
        [Fact]
        public void AddComand_ShouldAddFileToStagingArea()
        {
            //Arrange
            var repository = new Repository();
            var addCommand = new AddCommand(repository, "testfile.txt");

            // Act
            addCommand.Execute();

            // Assert
            Assert.Contains("testFile.txt", repository.StagingArea);
        }
    }
}
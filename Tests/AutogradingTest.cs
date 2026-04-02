namespace Tests;

using System.Text.RegularExpressions;
using knightmoves;
using Xunit;

public class AutogradingTest
{
    [Fact]
    public void Should_Use_The_Keyword_Var_To_Simplify_The_Declaration_Of_ListItems(){
       var listUtil = new ListUtility();
       var actual = listUtil.Copy("first", "second", "third");

       Assert.Equal(3, actual.Count);
       Assert.Contains("first", actual);
       Assert.Contains("second", actual);
       Assert.Contains("third", actual);

       string filePath = Path.GetDirectoryName(typeof(ListUtility).Assembly.Location) + "/../../../ListUtility.cs";

        Assert.True(File.Exists(filePath), "File does not exist");

        string content = File.ReadAllText(filePath);
        Regex rx = new Regex(@"var.*listItems.*=.*new.*List<string>()");

        bool hasComment = rx.IsMatch(content);

        Assert.True(hasComment, "Should use the keyword `var` to simplify the declaration of `listItems`");

    }
}
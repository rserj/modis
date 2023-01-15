namespace Modis.Tests;

using FluentAssertions;

using Modis.Twitter.Domain.Utils;

public class HashTagParserTests
{
    [Theory]
    [InlineData("Vestibulum volutpat sodales turpis #45 #& %# ()# 0# @#% #hydroEnergy #goGreen #movie3D #movie", new string[]{"#hydroEnergy","#goGreen", "#movie" })]
    [InlineData("Beşyüz yıl boyunca varlığını sürdürmekle #goGreen kalmamış, #bike aynı zamanda pek değişmeden  #movie", new string[]{"#bike","#goGreen", "#movie" })]
    public void GetTweetTags_TestingParsing(string text, string[] expected)
    {
        HashTagParser.GetTweetTags(text).Should().Contain(expected, "should contain expected #tags");
    }
}
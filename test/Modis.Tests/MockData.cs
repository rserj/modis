namespace Modis.Tests;

using Modis.TwitterClient.Abstractions.Model;

internal static class MockData
{
    /// <summary>
    /// The Mock data.
    /// #movie - 11, #avatar - 6, #sky - 4, #newyear - 6, #tea - 8
    /// #topPop - 2, #saveWater - 1, #electro - 3, #anime - 2, #rain - 4, #snp500 - 1, #air - 3, #android - 3, #xamarintvos - 3
    /// </summary>
    internal static Tweet[] Tweets = {
                                        new Tweet { Id = "1", Text = "testing #avatar #movie" },
                                        new Tweet { Id = "2", Text = "bad weather #rain" },
                                        new Tweet { Id = "3", Text = "watch #avatar #movie" },
                                        new Tweet { Id = "4", Text = "market #snp500 #sky #movie" },
                                        new Tweet { Id = "5", Text = "testing #avatar #movie #android" },
                                        new Tweet { Id = "6", Text = "Lorem ipsum dolor sit amet, #music2023 #tea #tea" },
                                        new Tweet { Id = "7", Text = "testing #avatar #movie" },
                                        new Tweet { Id = "8", Text = "Lorem ipsum dolor sit amet, #movie #tea #air session" },
                                        new Tweet { Id = "9", Text = "testing #avatar #movie" },
                                        new Tweet { Id = "10", Text = "Lorem ipsum dolor sit amet, #newyear #tea #tea" },
                                        new Tweet { Id = "11", Text = "Lorem ipsum dolor sit amet, #topPop #movie #xamarintvos" },
                                        new Tweet { Id = "12", Text = "Lorem ipsum dolor sit amet, #rain #saveWater" },
                                        new Tweet { Id = "13", Text = "Lorem ipsum dolor sit amet, #anime #sky #movie #android" },
                                        new Tweet { Id = "14", Text = "Lorem ipsum dolor sit amet, testing #tea #avatar #movie" },
                                        new Tweet { Id = "15", Text = "Lorem ipsum dolor sit amet, #newyear #air #xamarintvos" },
                                        new Tweet { Id = "16", Text = "Lorem ipsum dolor sit amet, #sky #sky #rain   #android" },
                                        new Tweet { Id = "17", Text = "Lorem ipsum dolor sit amet, #coffee #electro" },
                                        new Tweet { Id = "18", Text = "Lorem ipsum dolor sit amet, #electro #newyear #newyear" },
                                        new Tweet { Id = "19", Text = "Lorem ipsum dolor sit amet, #topPop" },
                                        new Tweet { Id = "20", Text = "Lorem ipsum dolor sit amet, #newyear #xamarintvos" },
                                        new Tweet { Id = "21", Text = "Lorem ipsum dolor sit amet, #anime #tea" },
                                        new Tweet { Id = "22", Text = "Lorem ipsum dolor sit amet, #electro #tea" },
                                        new Tweet { Id = "23", Text = "Lorem ipsum dolor sit amet, #newyear #rain" },
                                        new Tweet { Id = "24", Text = "Lorem ipsum dolor sit amet, #air " },
                                    };

    internal static string[] Top10Tags = {
                                           "#movie", "#avatar", "#sky", "#newyear", "#tea", "#rain", "#xamarintvos",
                                           "#android", "#air", "#electro"
                                      };
}
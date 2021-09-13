using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static void Main(){
            
        }
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            string regEx = @"[\s\r\n]+";

            foreach (var line in lines)
            {
                var split = Regex.Split(line, regEx);
                
                foreach (var word in split)
                {
                    yield return word;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            string regEx = @"(?<width>\d+)x(?<height>\d+)";

            foreach (var resolution in resolutions)
            {
                var matches = Regex.Matches(resolution, regEx);

                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;
                    yield return (int.Parse(groups["width"].Value), int.Parse(groups["height"].Value));
                }
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            string regEx = "([</]{1-2})"+tag+@"([.*?]>)(?<inner>.+)\1" + tag + @"\2";

            var matches = Regex.Matches(html, regEx);

            foreach(Match match in matches)
            {
                GroupCollection group = match.Groups;
                yield return group["inner"].Value;
            }
        }
    }
}

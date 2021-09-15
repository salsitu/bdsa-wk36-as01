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
            string regEx = string.Format(@"<([{0}][^>]*)>(?<innerText>.+?)</{0}>", tag);

            foreach (Match match in Regex.Matches(html, regEx))
            {
                GroupCollection group = match.Groups;
                yield return Regex.Replace(group["innerText"].Value, "<[^>]*>", "");
            }
        }
    }
}

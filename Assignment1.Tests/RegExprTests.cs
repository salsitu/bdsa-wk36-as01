using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void Given_Stream_Of_Lines_Return_Stream_Of_Words(){
                // Arrange
                string[] expected = new [] {"Hello", "i", "would", "like", "20", "cakes", "please"}; 
                List<string> input = new List<string>{"Hello i", "would", "like 20", "cakes please"}; 
                
                // Act
                var actual = RegExpr.SplitLine(input);

                // Assert
                Assert.Equal(expected, actual);
        }
       
        [Fact]
        public void Given_String_Resolution_Return_tuples()
        {
            // Arrange
            IEnumerable<string> input = new List<string> {
                "1920x1080",
                "1024x768, 800x600, 640x480",
                "320x200, 320x240, 800x600",
                "1280x960"
            };

            IEnumerable<(int width, int height)> expected = new List<(int width, int height)> {
                (1920, 1080),
                (1024, 768),
                (800, 600),
                (640, 480),
                (320, 200),
                (320, 240),
                (800, 600),
                (1280, 960)
            };

            // Act
            var actual = RegExpr.Resolution(input);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Given_HTML_And_A_Tag_Return_Inner_Text_Of_The_Tag()
        {
            // Arrange
            string input = "<div>    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
            IEnumerable<string> expected = new List<string>{
                "theoretical computer science",
                "formal language",
                "characters",
                "pattern",
                "string searching algorithms",
                "strings"
            };
            
            // Act
            var actual = RegExpr.InnerText(input, "a");
            
            // Assert
            Assert.Equal(expected, actual);
        }

         [Fact]
        public void Given_HTML_And_A_Tag_Return_Inner_Text_Of_The_Tag_Supports_Nested_Tags()
        {
            // Arrange
            string input = "<div>    <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
            IEnumerable<string> expected = new List<string> {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};       
            
            // Act
            var actual = RegExpr.InnerText(input, "p");
            
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

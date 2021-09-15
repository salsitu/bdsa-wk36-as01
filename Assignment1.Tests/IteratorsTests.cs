using Xunit;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {

        [Fact]
        public void Return_Stream_Of_T_When_Given_Stream_Of_Stream_Of_T()
        {
            // Arrange
            int[][] matrix = {
                new [] {1, 3, 5, 7}, 
                new [] {2, 4, 6, 8}
            };
            int[] expected = {1, 3, 5, 7, 2, 4, 6, 8};

            // Act
            IEnumerable<int> actual = Iterators.Flatten<int>(matrix);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Returns_Only_Odd_Numbers_When_Given_Stream_Of_1to8_With_Odd_Predicate()
        {
            // Arrange
            int[] array = {1, 3, 5, 7, 2, 4, 6, 8};
            int[] expected = {1, 3, 5, 7};
            
            // Act
            Predicate<int> odd = Odd;
            IEnumerable<int> actual = Iterators.Filter(array, odd);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static bool Odd(int i)
        {
            return i % 2 == 1;
        }
    }
}

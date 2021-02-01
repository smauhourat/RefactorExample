using RefactorExample;
using System;
using Xunit;

namespace XUnitTestRefactorExample
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var customer = new Customer("Santiago");
            var movie1 = new Movie("Movie1", Movie.CHILDRENS);
            var movie2 = new Movie("Movie2", Movie.NEW_RELEASE);
            var rental1 = new Rental(movie1, 2);
            var rental2 = new Rental(movie2, 5);

            customer.AddRental(rental1);
            customer.AddRental(rental2);

            var result = customer.Statement();

            string expectedResult = "Rental Record for Santiago\n";
            expectedResult += "\tMovie1\t1,5\n";
            expectedResult += "\tMovie2\t15\n";
            expectedResult += "Amount owed is 16,5\n";
            expectedResult += "You earned 3 frequent renter points";

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void Test2()
        {
            var customer = new Customer("Santiago");
            var movie1 = new Movie("Movie1", Movie.CHILDRENS);
            var movie2 = new Movie("Movie2", Movie.NEW_RELEASE);
            var rental1 = new Rental(movie1, 10);
            var rental2 = new Rental(movie2, 5);

            customer.AddRental(rental1);
            customer.AddRental(rental2);

            var result = customer.Statement();

            string expectedResult = "Rental Record for Santiago\n";
            expectedResult += "\tMovie1\t10,5\n";
            expectedResult += "\tMovie2\t15\n";
            expectedResult += "Amount owed is 25,5\n";
            expectedResult += "You earned 3 frequent renter points";

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void Test3()
        {
            var customer = new Customer("Santiago");
            var movie1 = new Movie("Movie1", Movie.CHILDRENS);
            var movie2 = new Movie("Movie2", Movie.REGULAR);
            var rental1 = new Rental(movie1, 10);
            var rental2 = new Rental(movie2, 5);

            customer.AddRental(rental1);
            customer.AddRental(rental2);

            var result = customer.Statement();

            string expectedResult = "Rental Record for Santiago\n";
            expectedResult += "\tMovie1\t10,5\n";
            expectedResult += "\tMovie2\t4,5\n";
            expectedResult += "Amount owed is 15\n";
            expectedResult += "You earned 2 frequent renter points";

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void Test4()
        {
            var customer = new Customer("Santiago");
            var movie1 = new Movie("Movie1", Movie.NEW_RELEASE);
            var rental1 = new Rental(movie1, 1);

            customer.AddRental(rental1);

            var result = customer.Statement();

            string expectedResult = "Rental Record for Santiago\n";
            expectedResult += "\tMovie1\t3\n";
            expectedResult += "Amount owed is 3\n";
            expectedResult += "You earned 1 frequent renter points";

            Assert.Equal(result, expectedResult);
        }
    }
}

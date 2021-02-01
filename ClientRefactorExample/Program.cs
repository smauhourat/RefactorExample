using RefactorExample;
using System;

namespace ClientRefactorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Santiago");
            var movie1 = new Movie("Movie1", Movie.NEW_RELEASE);
            //var movie2 = new Movie("Movie2", Movie.REGULAR);
            var rental1 = new Rental(movie1, 1);
            //var rental2 = new Rental(movie2, 5);

            customer.AddRental(rental1);
            //customer.AddRental(rental2);

            var result = customer.Statement();

            Console.Write(result);
        }
    }
}

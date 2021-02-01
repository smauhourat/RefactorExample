using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorExample
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();
        public Customer(string name)
        {
            _name = name;
        }
        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }
        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (var rent in rentals)
            {
                double thisAmount = 0;

                //determine amounts for rent line
                switch (rent.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount = 2;
                        if (rent.GetDaysRented() > 2)
                            thisAmount = (rent.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount = rent.GetDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount = 1.5;
                        if (rent.GetDaysRented() > 3)
                            thisAmount = (rent.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if ((rent.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) && rent.GetDaysRented() > 1)
                    frequentRenterPoints++;

                //show figures for this rental
                result += "\t" + rent.GetMovie().GetTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";
            return result;
        }
    }
}

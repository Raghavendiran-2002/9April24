﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class BookingConfirmation
    {
        public required string BookingReference { get; set; }
        public  required Movie Movie { get; set; }
        public required DateTime ScreeningTime {get; set;}

        public required float TotalCost { get; set;} 

        public BookingConfirmation(string bookingReference, Movie movie, DateTime screenTime,  float totalCost)
        {
            BookingReference = bookingReference;
            Movie = movie;
            ScreeningTime = screenTime;
            TotalCost = totalCost;
        }
    }
}
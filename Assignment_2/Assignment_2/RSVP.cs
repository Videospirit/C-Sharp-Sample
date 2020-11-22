using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class RSVP
    {
        private static int reservations = 0;
        private string date;
        private Event e;
        private Customer c;
        private int id;

        public RSVP(Event e, Customer c)
        {
            id=++reservations;
            date = DateTime.Now.ToString(@"MM/dd/yyyy h:mm tt");
            this.e = e;
            this.c = c;
        }


        public string getDate()
        {
            return date;
        }
        public int getID()
        {
            return id;
        }
        public Event getEvent()
        {
            return e;
        }

        public Customer getCustomer()
        {
            return c;
        }

        public override string ToString()
        {
            string s = id + " RSVP for: " + c.getFirstName() + " " + c.getLastName() + "at Event: " + e.getEventName() + "made on: " + date;
            return s;
        }

    }
}

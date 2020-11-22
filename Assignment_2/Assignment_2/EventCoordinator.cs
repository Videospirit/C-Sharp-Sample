using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;
        RSVPManager RSVPMan;

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
            RSVPMan = new RSVPManager();
        }

        //customer related methods
        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getCustomerList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getCustomerInfo(id);
        }
        public bool deleteCustomer(int id)
        {
            return custMan.deleteCustomer(id);
        }

        // Event related methods
        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            bool status = eventMan.addEvent(name, venue, eventDate, maxAttendee);
            if (status)
            {
                RSVPMan.alterMax(maxAttendee);
            }
            return status;
        }

        public string eventList()
        {
            return eventMan.getEventList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getEventInfo(id);
        }

        //RSVP related methods

        public bool addRSVP(int cid, int eid)
        {
            if (custMan.customerExist(cid) && eventMan.eventExists(eid))
            {
                Event e = eventMan.getEvent(eid);
                Customer c = custMan.getCustomer(cid);
                if (e.addAttendee(c))
                {
                    RSVPMan.addRSVP(e,c);
                    return true;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class RSVPManager
    {
        private int maxRSVP;
        private int numRSVP;
        private RSVP[] RSVPList;

        public void RSVP()
        {
            maxRSVP = 0;
            numRSVP = 0;
            RSVPList = new RSVP[0];
        }

        public void alterMax(int change)
        {
            maxRSVP += change;
            Array.Resize(ref RSVPList, maxRSVP);
        }

        public bool addRSVP(Event e, Customer c)
        {
            if (numRSVP >= maxRSVP) { return false; }
            RSVP r = new RSVP(e,c);
            RSVPList[numRSVP] = r;
            numRSVP++;
            return true;
        }

        public int findRSVP(int rid)
        {
            for (int x = 0; x < numRSVP; x++)
            {
                if (RSVPList[x].getID() == rid)
                    return x;
            }
            return -1;
        }

        public bool RSVPExist(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return false; }
            return true;
        }

        public RSVP getRSVP(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return null; }
            return RSVPList[loc];
        }

        public string getRSVPInfo(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return "There is no RSVP with id " + rid + "."; }
            return RSVPList[loc].ToString();
        }

        public bool deleteRSVP(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return false; }
            RSVPList[loc] = RSVPList[numRSVP - 1];
            numRSVP--;
            return true;
        }

    }
}

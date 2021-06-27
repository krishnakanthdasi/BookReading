using BookReading.EntityDataModel;
using System.Collections.Generic;
using System.Linq;

namespace BookReading.Data
{
    public class InvitationData
    {
        private BookReadingDBContext db;

        public InvitationData()
        {
            db = new BookReadingDBContext();
        }

        public bool AddInvitation(Invitation invitation)
        {
            db.Invitations.Add(invitation);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Invitation> GetInvitation(int userId)
        {
            var output = db.Invitations.ToList().Where(d => d.UserId == userId);
            return output;
        }

        
        public bool InviteUser(int eventId, int[] userId)
        {

            Invitation invitation = new Invitation();

            for (int i = 0; i < userId.Length; i++)
            {
                invitation.EventId = eventId;
                invitation.UserId = userId[i];
                invitation.InvitationActive = 1;

                db.Invitations.Add(invitation);
                db.SaveChanges();
            }
            return true;
        }
    }
}

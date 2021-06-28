using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReading.Data;
using BookReading.EntityDataModel;

namespace BookReading.Business
{
   public class InvitationBusiness
    {
        private InvitationData invitationData;

        public InvitationBusiness()
        {
            invitationData = new InvitationData();
        }

        public bool addInvitation(Invitation invitation)
        {
            return invitationData.AddInvitation(invitation);
        }

        public IEnumerable<Invitation> getInvitation(int userId)
        {
            return invitationData.GetInvitation(userId);
        }

        
        public bool inviteUser(int eventId, int[] userId)
        {

            return invitationData.InviteUser(eventId, userId);
        }
    }
}

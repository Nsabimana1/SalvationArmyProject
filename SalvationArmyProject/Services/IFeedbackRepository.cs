using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public interface IFeedbackRepository
    {
        bool feedbackExists(Guid id);
        Feedback getFeedback(Guid id);
        string getContent(Guid id);
        int getUserId(Guid id);
        int getEventId(Guid id);
        IEnumerable<Feedback> allFeedback();
        void removeFeedback(Guid id);
        void updateFeedback(Feedback f);
    }
}

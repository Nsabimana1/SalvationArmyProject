using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public class FeedbackRepository : IFeedbackRepository
    {
        DBcontext _dBcontext;
        public FeedbackRepository(DBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public IEnumerable<Feedback> allFeedback()
        {
            return _dBcontext.Feedbacks;
        }

        public bool feedbackExists(Guid id)
        {
            var f = _dBcontext.Feedbacks.FirstOrDefault(u => u.feedbackId == id);
            return f != null;
        }

        public string getContent(Guid id)
        {
            return this.getFeedback(id).feedbackContent;
        }

        public Guid getEventId(Guid id)
        {
            return this.getFeedback(id).eventFK;
        }

        public Feedback getFeedback(Guid id)
        {
            return _dBcontext.Feedbacks.FirstOrDefault(u => u.feedbackId == id);
        }

        public Guid getUserId(Guid id)
        {
            return this.getFeedback(id).userFK;
        }

        public void removeFeedback(Guid id)
        {
            var f = this.getFeedback(id);
            _dBcontext.Feedbacks.Remove(f);
        }

        public void updateFeedback(Feedback f)
        {
            throw new NotImplementedException();
        }
    }
}

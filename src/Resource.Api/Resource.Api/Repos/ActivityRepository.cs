using Resource.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IActivityRepository
    {
        public List<ActivityDTO> GetAllGroupActivities(int groupId);
    }


    public class ActivityRepository : IActivityRepository
    {
        Kinder2021Context _context;
        public ActivityRepository(Kinder2021Context context)
        {
            _context = context;
        }


        public List<ActivityDTO> GetAllGroupActivities(int groupId)
        {
            var tempRes = _context.Activities.Where(e => e.GroupId == groupId).OrderByDescending(e => e.Id).ToList();
            var result = new List<ActivityDTO>();
            foreach (var tempi in tempRes)
            {
                result.Add(new ActivityDTO()
                {
                    ActivityDate = tempi.ActivityDatetime.ToString(),
                    Id = tempi.Id,
                    Participants = new List<StudentDTO>(),
                    AttachmentUrls = new List<string>(),
                    ActivityName = tempi.ActivityType.Name
                });

                //foreach (var stu in _context.)
                //{

                //}
            }
            return result;
        }


    }
}
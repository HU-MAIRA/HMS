using HMS_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS_MVC.Infrastructure
{
    public interface IRoomService
    {
        IList<RoomDetail> GetRoomList();

        bool AddRoomDetails(RoomDetail rdobj);

        IList<RoomDetail> FindByStatus(string status);

        bool EditRoomDetails(RoomDetail rdUpdate);

        //public void DeleteRoomDetails(string roomId);
    }
}

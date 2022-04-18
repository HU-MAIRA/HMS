using HMS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_MVC.Infrastructure
{
    public class RoomService : IRoomService
    {
        public HMSDBContext context;
        public RoomService(HMSDBContext context)
        {
            this.context = context;
        }

        //displaying all room details
        public IList<RoomDetail> GetRoomList()
        {
            IList<RoomDetail> room;

            try
            {
                room = context.Set<RoomDetail>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return room;
        }

        //Adding Room details
        public bool AddRoomDetails(RoomDetail rdobj)
        {
            context.Add<RoomDetail>(rdobj);
            context.SaveChanges();
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Updating Room details
        public bool EditRoomDetails(RoomDetail rdUpdate)
        {
            var room = FindById(rdUpdate.Roomnumber);

            room.Roomtype = rdUpdate.Roomtype;
            room.Roomstatus = rdUpdate.Roomstatus;
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Searching room by status
        public IList<RoomDetail> FindByStatus(string status)
        {
            RoomDetail stats;

            try
            {
                stats = context.Find<RoomDetail>(status);

            }
            catch (Exception ex)
            {
                throw ex;
            }
           return (IList<RoomDetail>)stats;
            //return context.RoomDetail.Where(x => x.RoomDetails.status == status).ToList();

        }

        //Searching room by id
        public RoomDetail FindById(int id)
        {

            RoomDetail ids;

            try
            {
                ids = context.Find<RoomDetail>(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ids;
            //return context.RoomDetail.Where(x => x.GetRoomList == id).FirstOrDefault();
        }


        //Deleting room
        //public ResponseModel DeleteRoomDetails(int roomId)
        //{
        //    ResponseModel model = new ResponseModel();
        //    try
        //    {
        //        int stu = FindByStatus(roomId);
        //        _context.Remove<RoomDetail>(roomId);

        //        _context.SaveChanges();
        //        model.ISuccess = true;
        //        model.Message = " Room Details removed succesfully";
        //    }

        //    catch (Exception ex)
        //    {
        //        model.ISuccess = false;
        //        model.Message = " Error:" + ex.Message;
        //    }
        //    return model;
    }
}


using TDDPOC.Domain.BaseModels;

namespace TDDPOC.Domain
{
    public class RoomBooking : RoomBookingBase
    {
        public int Id { get; set; }


        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
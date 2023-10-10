using TDDPOC.Domain;

namespace TDDPOC.Core.DataServices
{
    public interface IRoomBookingService
    {
        void SaveBooking(RoomBooking roomBooking);

        IEnumerable<Room> GetAvailableRooms(DateTime date);
        IEnumerable<Room> GetRooms();
    }
}

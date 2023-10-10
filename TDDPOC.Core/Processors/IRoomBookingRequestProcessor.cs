using TDDPOC.Core.Models;

namespace TDDPOC.Core.Processors
{
    public interface IRoomBookingRequestProcessor
    {
        RoomBookingResult BookRoom(RoomBookingRequest bookingRequest);
    }
}
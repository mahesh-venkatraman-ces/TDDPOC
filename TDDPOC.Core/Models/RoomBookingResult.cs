using TDDPOC.Core.Enums;
using TDDPOC.Domain.BaseModels;

namespace TDDPOC.Core.Models
{
    public class RoomBookingResult : RoomBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int? RoomBookingId { get; set; }
    }
}
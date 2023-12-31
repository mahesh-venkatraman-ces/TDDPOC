﻿using TDDPOC.Core.DataServices;
using TDDPOC.Domain;
using System.Collections.Generic;
using System.Linq;

namespace TDDPOC.Persistence.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly RoomBookingAppDbContext _context;

        public RoomBookingService(RoomBookingAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            return _context.Rooms.Where(q => !q.RoomBookings.Any(x => x.Date == date)).ToList();
        }

        public IEnumerable<Room> GetRooms()
        {
            throw new NotImplementedException();
        }

        public void SaveBooking(RoomBooking roomBooking)
        {
            _context.Add(roomBooking);
            _context.SaveChanges();
        }
    }
}

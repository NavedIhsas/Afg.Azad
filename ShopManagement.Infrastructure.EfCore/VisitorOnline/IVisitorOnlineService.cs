using System;
using System.Linq;
using ShopManagement.Domain.Visitors;

namespace ShopManagement.Infrastructure.EfCore.VisitorOnline
{
    public interface IVisitorOnlineService
    {
        void ConnectUser(string clientId);
        void DisconnectUser(string clientId);
        int GetCount();
        void DeleteAll();
        void DeleteAllVisitors();
    }

    public class VisitorOnlineService : IVisitorOnlineService
    {
        private readonly ShopContext _context;

        public VisitorOnlineService(ShopContext context)
        {
            _context = context;
        }

        public void ConnectUser(string clientId)
        {
            var exist = _context.OnlineVisitors.AsQueryable().FirstOrDefault(x => x.ClientId == clientId);
            if (exist != null) return;
            var add = new OnlineVisitors()
            {
                Time = DateTime.Now,
                ClientId = clientId
            };
            _context.OnlineVisitors.Add(add);
            _context.SaveChanges();
        }

        public void DisconnectUser(string clientId)
        {
            var onlineUser = _context.OnlineVisitors.FirstOrDefault(x => x.ClientId == clientId);
            if (onlineUser != null) _context.OnlineVisitors.Remove(onlineUser);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.OnlineVisitors.AsQueryable().Count();
        }

        public void DeleteAll()
        {
            var onlineUser = _context.OnlineVisitors.AsQueryable();
            _context.OnlineVisitors.RemoveRange(onlineUser);
            _context.SaveChanges();
        }


        public void DeleteAllVisitors()
        {
            var count = _context.Visitors.AsQueryable();
            _context.Visitors.RemoveRange(count);
            _context.SaveChanges();
        }
    }
}

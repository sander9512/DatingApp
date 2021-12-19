using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Message> MarkUnreadAsRead(this IQueryable<Message> query, string currentUsername) {
            var unreadMessages = query.Where(m => m.DateRead == null && m.RecipientUsername == currentUsername);

            if(unreadMessages.Any()) {
                foreach(var message in unreadMessages) {
                    message.DateRead = DateTime.UtcNow;
                }
            }
            return query;
        }
    }
}
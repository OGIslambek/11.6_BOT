using _11._6_BOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._6_BOT.Services
{
    public interface IStorage
    {
        Session GetSession(long chatId);
    }
}

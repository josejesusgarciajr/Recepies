using PersonalPlayGround.ClientInfo;
using System.Collections.Generic;

namespace PersonalPlayGround.Models
{
    public class IdentityUsersViewModel
    {
        public List<Client> AdminClients { get; set; }
        public List<Client> RegularClients { get; set; }
    }
}
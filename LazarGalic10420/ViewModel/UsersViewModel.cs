using LazarGalic10420.Business;
using LazarGalic10420.Business.Services;
using LazarGalic10420.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.ViewModel
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<AdminSelectRegisteredUsersDto> Users { get; set; }
        public UsersService _userService;

        public UsersViewModel() 
        {
            _userService = new UsersService();

            Users = new ObservableCollection<AdminSelectRegisteredUsersDto>(_userService.GetUsers());
            
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserPostDTO : UserDTO
    {
        public List<PostDTO> Posts {  get; set; }
        public UserPostDTO() 
        { 
            Posts = new List<PostDTO>();
        }
    }
}

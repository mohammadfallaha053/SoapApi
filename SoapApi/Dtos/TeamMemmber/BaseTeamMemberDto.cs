using System.ComponentModel.DataAnnotations;

namespace SoapApi.Dtos.TeamMemmber
{
    public class BaseTeamMemberDto
    {
        // public int TeamMemmberId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        public string Phone { get; set; }
        public string? Image1 { get; set; }
        public byte[]? Image2 { get; set; }

        public string? Country { get; set; }



    }
}



using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class EmailActivation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActivationCode { get; set; }
        public string Email { get; set; }
        public bool IsActivated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? ActivationDate { get; set; }

        public virtual User User { get; set; }
    }
}

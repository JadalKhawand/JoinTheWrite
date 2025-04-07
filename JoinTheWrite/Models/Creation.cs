﻿using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace JoinTheWrite.Models
{
    public class Creation
    {
        [Key]
        public Guid CreationId { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public WritingStatus Status { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime VotingStartDate { get; set; }
        public DateTime VotingEndDate { get; set; }
        public List<Contribution> Contributions { get; set; } = new List<Contribution>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}

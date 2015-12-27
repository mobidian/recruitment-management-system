﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RecruitmentManagementSystem.Core.Mappings;
using RecruitmentManagementSystem.Model;

namespace RecruitmentManagementSystem.Core.Models.Question
{
    public class QuestionCreateModel : IMapFrom<Model.Question>
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Text { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        public ICollection<Choice> Choices { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Notes { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "The {0} must be at most {1} characters long.")]
        public string Answer { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public QuestionCategory Category { get; set; }

        public ICollection<File> DeletableFile { get; set; }
    }
}
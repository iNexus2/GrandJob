﻿namespace HireMe.Entities.Models.Benchmark
{
using Ardalis.GuardClauses;
using HireMe.Entities.Enums;
using HireMe.Entities.Input;
using System;

    public class ContestantTest : BaseModel
    {
        // Main
        public string FullName { get; set; }
        public Gender Genders { get; set; }
        public DateTime? Age { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ExpiredOn { get; set; }
        public string LocationId { get; set; }

        // Details
        public string About { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
        public int? payRate { get; set; }
        public SalaryType SalaryType { get; set; }
        public int profileVisiblity { get; set; }
        public string WorkType { get; set; }
        public uint profileViews { get; set; }


        // Web presence
        public string Website { get; set; }
        public string Portfolio { get; set; }
        public string Linkdin { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }
        public string Dribbble { get; set; }

        public PackageType Promotion { get; set; }
        public double Rating { get; set; }
        public int RatingVotes { get; set; }
        public int VotedUsers { get; set; }
        public uint Views { get; set; }

        // Id
        public string ResumeFileId { get; set; }
        public string userSkillsId { get; set; }
        public string LanguagesId { get; set; }
        public int CategoryId { get; set; }
        public string PosterID { get; set; }
        public ApproveType isApproved { get; set; }
        public bool isArchived { get; set; }

        public void Update(CreateContestantInputModel viewModel, ApproveType approved, User user)
        {
            Id = viewModel.Id;

            Guard.Against.NullOrEmpty(viewModel.FullName, nameof(viewModel.FullName));
            FullName = viewModel.FullName;

            Guard.Against.NullOrEmpty(viewModel.Description, nameof(viewModel.Description));
            Description = viewModel.Description;

            Guard.Against.NullOrEmpty(viewModel.About, nameof(viewModel.About));
            About = viewModel.About;

            Genders = viewModel.Genders;
            Age = viewModel.Age;
            SalaryType = viewModel.SalaryType;
            LocationId = viewModel.LocationId;

            LanguagesId = viewModel.LanguagesId;
            Experience = viewModel.Experience;
            payRate = viewModel.payRate;
            profileVisiblity = viewModel.profileVisiblity;
            WorkType = viewModel.WorkType;

            Website = viewModel.Website;
            Portfolio = viewModel.Portfolio;
            Linkdin = viewModel.Linkdin;
            Facebook = viewModel.Facebook;
            Twitter = viewModel.Twitter;
            Github = viewModel.Github;
            Dribbble = viewModel.Dribbble;
            ResumeFileId = viewModel.ResumeFileId == null ? ResumeFileId : viewModel.ResumeFileId;

            CategoryId = viewModel.CategoryId;
            userSkillsId = viewModel.userSkillsId;
            isApproved = approved;
            isArchived = viewModel.isArchived;

            PosterID = user.Id;
            CreatedOn = DateTime.Now;
            ExpiredOn = CreatedOn.AddMonths(1);
        }

    }
}
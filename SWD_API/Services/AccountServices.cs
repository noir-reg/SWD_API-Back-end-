﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWD_API.Enums;
using SWD_API.Payload.Request.Account;
using SWD_API.Payload.Response;
using SWD_API.Payload.Response.Account;
using SWD_API.Repository.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWD_API.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IConfiguration _config;
        private readonly SWDProjectContext _db = new();

        public AccountServices(IConfiguration config)
        {
            _config = config;

        }

        public async Task<GetAccountResponse>? GetAcccountDetail(GetAccountRequest getAccountRequest)
        {


            if (getAccountRequest.Role.Equals(RoleConst.Intern, StringComparison.OrdinalIgnoreCase))
            {
                var intern = await _db.Interns.Where(x => x.Id.Equals(getAccountRequest.Id)).Include(x => x.University).Include(x => x.Major)
                .Include(x => x.Team).Include(x => x.InternshipSemester).FirstOrDefaultAsync();
                if (intern != null)
                {
                    string MajorName = null;
                    string UniversityName = null;
                    string TeamName = null;
                    string SemesterName = null;
                    if (intern.Major != null)
                    {
                        MajorName = intern.Major.Name;
                    }
                    if (intern.University != null)
                    {
                        UniversityName = intern.University.Name;
                    }
                    if (intern.Team != null)
                    {
                        TeamName = intern.Team.Name;
                    }

                    if (intern.InternshipSemester != null)
                    {
                        SemesterName = intern.InternshipSemester.Name;
                    }
                    return new GetAccountResponse
                    {
                        Id = intern.Id,
                        FullName = intern.FullName,
                        PhoneNumber = intern.PhoneNumber,
                        Dob = intern.Dob,
                        Major = MajorName,
                        University = UniversityName,
                        Team = TeamName,
                        InternshipSemester = SemesterName,
                        Gender = intern.Gender,
                        Role = intern.Role,
                        Email = intern.Email,
                        Status = intern.Status
                    };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var user = _db.Users.Where(x => x.Id.Equals(getAccountRequest.Id)).FirstOrDefault();
                if (user != null)
                {
                    return new GetAccountResponse
                    {

                        Id = user.Id,
                        FullName = user.FullName,
                        PhoneNumber = user.PhoneNumber,
                        Dob = user.Dob,
                        Gender = user.Gender,
                        Role = user.Role,
                        Email = user.Email,
                        Status = user.Status
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IList<GetAccountResponse>>? GetTeamMembers(Guid teamLeaderId)
        {
            var teamID = _db.Teams.Where(x => x.TeamLeaderId == teamLeaderId).Select(x => x.Id).FirstOrDefault();
            var list = await _db.Interns.Where(x => x.TeamId == teamID).Include(x => x.University).Include(x => x.Major)
                .Include(x => x.Team).Include(x => x.InternshipSemester).Select(x => new GetAccountResponse
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Dob = x.Dob,
                    Major = x.Major == null ? null : x.Major.Name,
                    University = x.University == null ? null : x.University.Name,
                    Team = x.Team == null ? null : x.Team.Name,
                    InternshipSemester = x.InternshipSemester == null ? null : x.InternshipSemester.Name,
                    Gender = x.Gender,
                    Role = x.Role,
                    Email = x.Email,
                    Status = x.Status


                }).ToListAsync();
            return list;
        }

        public async Task<LoginResponse>? Login(string email)
        {
            var intern = await _db.Interns.Where(x => x.Email.Equals(email)).Include(x => x.University).Include(x => x.Major)
                .Include(x => x.Team).Include(x => x.InternshipSemester).FirstOrDefaultAsync();
            var user = await _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
            if (intern != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                 new Claim(ClaimTypes.Email,intern.Email),
                new Claim(ClaimTypes.Role,intern.Role)
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);


                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
                string MajorName = null;
                string UniversityName = null;
                string TeamName = null;
                string SemesterName = null;
                if (intern.Major != null)
                {
                    MajorName = intern.Major.Name;
                }
                if (intern.University != null)
                {
                    UniversityName = intern.University.Name;
                }
                if (intern.Team != null)
                {
                    TeamName = intern.Team.Name;
                }

                if (intern.InternshipSemester != null)
                {
                    SemesterName = intern.InternshipSemester.Name;
                }

                return new LoginResponse
                {
                    AccessToken = accessToken,
                    Id = intern.Id,
                    FullName = intern.FullName,
                    PhoneNumber = intern.PhoneNumber,
                    Dob = intern.Dob,
                    Major = MajorName,
                    University = UniversityName,
                    Team = TeamName,
                    InternshipSemester = SemesterName,
                    Gender = intern.Gender,
                    Role = intern.Role,
                    Email = email,
                    Status = intern.Status
                };
            }
            else if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                 new Claim(ClaimTypes.Email,user.Email),
                 new Claim(ClaimTypes.Role,user.Role)
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);


                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                return new LoginResponse
                {
                    AccessToken = accessToken,
                    Id = user.Id,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    Dob = user.Dob,
                    Gender = user.Gender,
                    Role = user.Role,
                    Email = email,
                    Status = user.Status
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateAccountStatus(UpdateAccountStatusRequest updateAcccountStatusRequest)
        {
            if (updateAcccountStatusRequest.Role.Equals(RoleConst.Intern, StringComparison.OrdinalIgnoreCase))
            {
                var intern = await _db.Interns.Where(x => x.Id.Equals(updateAcccountStatusRequest.Id)).FirstOrDefaultAsync();
                if (intern != null)
                {
                    intern.Status = updateAcccountStatusRequest.Status;

                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                        return true;
                    else return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var user = await _db.Users.Where(x => x.Id.Equals(updateAcccountStatusRequest.Id)).FirstOrDefaultAsync();


                if (user != null)
                {
                    user.Status = updateAcccountStatusRequest.Status;

                    var result = await _db.SaveChangesAsync();
                    if (result > 0)
                        return true;
                    else return false;
                }
                else
                {
                    return false;
                }

            }
        }

        public async Task<bool> UpdateInternInfor(UpdateInternInforRequest updateInternInforRequest)
        {
            var intern = await _db.Interns.Where(x => x.Id.Equals(updateInternInforRequest.Id)).FirstOrDefaultAsync();
            if (intern != null)
            {
                var newName = updateInternInforRequest.FullName.IsNullOrEmpty() ? intern.FullName : updateInternInforRequest.FullName;
                var newUniversityId = updateInternInforRequest.UniversityId.IsNullOrEmpty() ? intern.UniversityId : Guid.Parse(updateInternInforRequest.UniversityId);
                var newDOB = updateInternInforRequest.DOB.IsNullOrEmpty() ? intern.Dob : DateTime.Parse(updateInternInforRequest.DOB);
                var newGender = updateInternInforRequest.Gender.IsNullOrEmpty() ? intern.Gender : int.Parse(updateInternInforRequest.Gender);
                var newPhoneNumber = updateInternInforRequest.PhoneNumber.IsNullOrEmpty() ? intern.PhoneNumber : updateInternInforRequest.PhoneNumber;
                var newMajorId = updateInternInforRequest.MajorId.IsNullOrEmpty() ? intern.MajorId : Guid.Parse(updateInternInforRequest.MajorId);
                intern.FullName = newName;
                intern.UniversityId = newUniversityId;
                intern.Dob = newDOB;
                intern.Gender = newGender;
                intern.PhoneNumber = newPhoneNumber;
                intern.MajorId = newMajorId;
                var result = await _db.SaveChangesAsync();

                return true;

            }
            return false;

        }
    }
}

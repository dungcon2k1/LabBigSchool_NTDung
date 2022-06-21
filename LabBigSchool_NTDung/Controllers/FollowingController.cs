﻿using LabBigSchool_NTDung.DTOs;
using LabBigSchool_NTDung.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabBigSchool_NTDung.Controllers
{
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exits!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId                        
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();

        }

    }
}

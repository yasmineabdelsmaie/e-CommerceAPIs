using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceProject.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace E_CommerceProject.Hubs
{
    [HubName("CommentHub")]
    public class CommentHub:Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Microsoft.AspNet.SignalR.Hubs.HubMethodName("AddNewComment")]
        public void AddNewComment(string Body, int productID)
        {

            Comment comment = new Comment();
            comment.Body = Body;
            comment.ProductID = productID;
            db.Comments.Add(comment);
            db.SaveChanges();
            //Notify
            Clients.All.addComment(Body);


        }
    }
}
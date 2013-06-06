using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP3_Player_wpf
{
    class PostsViewModel
    {public Posts posts{ get; set;}
       
        public PostsViewModel()
        {
            posts = new Posts { postsText = "", postsTitle = "Unknown" };
        }
 
        public string PostsTitle
        {
            get { return posts.postsTitle; }
            set { posts.postsTitle  = value; }
        } 
    }
}

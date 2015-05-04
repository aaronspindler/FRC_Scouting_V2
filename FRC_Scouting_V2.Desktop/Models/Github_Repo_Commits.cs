using System;

namespace FRC_Scouting_V2.Models
{
    internal class Github_Repo_Commits
    {
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public string sha { get; set; }

            public Commit commit { get; set; }

            public string url { get; set; }

            public string html_url { get; set; }

            public string comments_url { get; set; }

            public Author1 author { get; set; }

            public Committer1 committer { get; set; }

            public Parent[] parents { get; set; }
        }

        public class Commit
        {
            public Author author { get; set; }

            public Committer committer { get; set; }

            public string message { get; set; }

            public Tree tree { get; set; }

            public string url { get; set; }

            public int comment_count { get; set; }
        }

        public class Author
        {
            public string name { get; set; }

            public string email { get; set; }

            public DateTime date { get; set; }
        }

        public class Committer
        {
            public string name { get; set; }

            public string email { get; set; }

            public DateTime date { get; set; }
        }

        public class Tree
        {
            public string sha { get; set; }

            public string url { get; set; }
        }

        public class Author1
        {
            public string login { get; set; }

            public int id { get; set; }

            public string avatar_url { get; set; }

            public string gravatar_id { get; set; }

            public string url { get; set; }

            public string html_url { get; set; }

            public string followers_url { get; set; }

            public string following_url { get; set; }

            public string gists_url { get; set; }

            public string starred_url { get; set; }

            public string subscriptions_url { get; set; }

            public string organizations_url { get; set; }

            public string repos_url { get; set; }

            public string events_url { get; set; }

            public string received_events_url { get; set; }

            public string type { get; set; }

            public bool site_admin { get; set; }
        }

        public class Committer1
        {
            public string login { get; set; }

            public int id { get; set; }

            public string avatar_url { get; set; }

            public string gravatar_id { get; set; }

            public string url { get; set; }

            public string html_url { get; set; }

            public string followers_url { get; set; }

            public string following_url { get; set; }

            public string gists_url { get; set; }

            public string starred_url { get; set; }

            public string subscriptions_url { get; set; }

            public string organizations_url { get; set; }

            public string repos_url { get; set; }

            public string events_url { get; set; }

            public string received_events_url { get; set; }

            public string type { get; set; }

            public bool site_admin { get; set; }
        }

        public class Parent
        {
            public string sha { get; set; }

            public string url { get; set; }

            public string html_url { get; set; }
        }
    }
}
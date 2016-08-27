using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class MatchesController : Controller
    {
        private WebProjectContext db = new WebProjectContext();

        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.Away).Include(m => m.Home).Include(m => m.Referee);
            return View(matches.ToList());
        }

        // GET: Parse Matches
        public ActionResult Parse()
        {

            string Url = "http://www.bold.dk/fodbold/kamp/fc-nordsjaelland-vs-soenderjyske/8207585/";
            var myEncoding = Encoding.GetEncoding("iso-8859-1");
            HtmlWeb web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = myEncoding,
            };
            HtmlDocument htmlDoc = web.Load(Url);
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.OptionAutoCloseOnEnd = true;

            if (htmlDoc.DocumentNode != null)
            {
                // Datetime
                var date = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"match_update\"]/div[3]/div[2]").InnerText;
                date = date.Trim();
                date = date.Replace("kl. ", "");
                DateTime datetime = Convert.ToDateTime(date);

                // Goals
                var scoreString =
                    htmlDoc.DocumentNode
                        .Descendants(
                            "div")
                        .First(b => b.Attributes.Contains("class") && b.Attributes["class"].Value.Contains("score_big"))
                        .InnerText;
                scoreString = scoreString.Trim();
                scoreString = scoreString.Replace("&nbsp;", "");
                var goals = scoreString.Split(new string[] {"&ndash;"}, StringSplitOptions.None);
                var homeGoals = goals[0];
                var awayGoals = goals[1];

                // Ref
                var referee = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"match_update\"]/div[8]/div[2]").InnerText;
                referee = referee.Trim();

                // Stadium
                var stadium = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"match_update\"]/div[6]/div[2]").InnerText;
                stadium = stadium.Trim();

                // Round
                var round = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"match_update\"]/div[5]/div[2]").InnerText;
                round = round.Trim();

                // Spectators
                var spectators = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"match_update\"]/div[7]/div[2]").InnerText;
                spectators = spectators.Trim();
                
                // Teams
                var homeTeamStartup =
                    htmlDoc.DocumentNode
                        .Descendants(
                            "div")
                        .First(b => b.Attributes.Contains("class") && b.Attributes["class"].Value.Contains("lineup team_1"));
                var homeTeam = homeTeamStartup.Descendants("div").First(b => b.Attributes["class"].Value.Contains("team_name")).InnerText;

                var awayTeamStartup =
                    htmlDoc.DocumentNode
                        .Descendants(
                            "div")
                        .First(b => b.Attributes.Contains("class") && b.Attributes["class"].Value.Contains("lineup team_2"));
                var awayTeam = awayTeamStartup.Descendants("div").First(b => b.Attributes["class"].Value.Contains("team_name")).InnerText;

            }


            return View();
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.AwayTeamId = new SelectList(db.Teams, "TeamId", "Name");
            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name");
            ViewBag.RefereeId = new SelectList(db.Referees, "RefereeId", "FirstName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,Date,HomeGoals,AwayGoals,HomeTeamId,AwayTeamId,Spectators,RefereeId,Stadium")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AwayTeamId = new SelectList(db.Teams, "TeamId", "Name", match.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name", match.HomeTeamId);
            ViewBag.RefereeId = new SelectList(db.Referees, "RefereeId", "FirstName", match.RefereeId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.AwayTeamId = new SelectList(db.Teams, "TeamId", "Name", match.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name", match.HomeTeamId);
            ViewBag.RefereeId = new SelectList(db.Referees, "RefereeId", "FirstName", match.RefereeId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,Date,HomeGoals,AwayGoals,HomeTeamId,AwayTeamId,Spectators,RefereeId,Stadium")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AwayTeamId = new SelectList(db.Teams, "TeamId", "Name", match.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "TeamId", "Name", match.HomeTeamId);
            ViewBag.RefereeId = new SelectList(db.Referees, "RefereeId", "FirstName", match.RefereeId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

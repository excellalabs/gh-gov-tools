﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Konmaripo.Web.Models;
using Microsoft.Extensions.Options;
using Octokit;
using Activity = System.Diagnostics.Activity;

namespace Konmaripo.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GitHubClient _client;
        private readonly GitHubSettings _ghSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<GitHubSettings> gitHubSettings, GitHubClient client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ghSettings = gitHubSettings.Value ?? throw new ArgumentNullException(nameof(gitHubSettings));
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            // Obtain list of GitHub Repos
            // Pass through to the view
            var repos = await _client.Repository.GetAllForOrg(_ghSettings.OrganizationName, new ApiOptions());

            var resultList = repos.Select(x => new GitHubRepo(x.Name)).ToList();
            
            _logger.LogInformation("Returning {RepoCount} repositories", resultList.Count);

            return View(resultList);

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

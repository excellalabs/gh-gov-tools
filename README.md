## Konmaripo: Konmari your GitHub Org and Its Repositories

[![Build Status](https://dev.azure.com/excellaco/Konmaripo/_apis/build/status/excellalabs.konmaripo?branchName=main)](https://dev.azure.com/excellaco/Konmaripo/_build/latest?definitionId=8&branchName=main) 

![Deployment to Production](https://vsrm.dev.azure.com/excellaco/_apis/public/Release/badge/e5fb7cc0-7eab-46dc-9e97-aa657e4fe6d5/1/1)

**NOTE:** This tool is in early and experimental stages; it is not currently recommended for use.

This tool is a simple web app to allow you to look at all of the repositories in your GitHub organization and see if it's time to archive them, with automated steps to help you sunset the repository.

## Current Features

* Azure AD Auth -- delegate app access only to those you trust and ensure they're authenticated.
* Submit an issue to every repository in your organization (org-wide announcements, etc.)
* View repository information in a list at a glance (stars, commits, description, key dates)
* Archive a Repository (pins an issue to the repository and archives it)
* Delete process for a repository (downloads a .zip of repository with all branches/tags pulled, allows for you to specify a URL for archival, and allows the deletion of the repository)

## Ingredients
This tool uses: 

* .NET Core MVC web app
* Azure AD Integration
* Azure DevOps
* Docker containers
* Octokit .NET (with a GitHub Access token)

## [Planned Feature Roadmap](https://github.com/excellalabs/konmaripo/projects/1)

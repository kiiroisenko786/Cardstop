# Cardstop
The Cardstop web project is designed to be similar to other TGC retailers, with features including admin
panels for content management, user registration, and Azure hosting (of which my free credit has sadly
expired, so it will no longer be hosted on Azure)

Concepts covered include: Identity Framework, Users, Entity Framework, Migrations, Sessions, View Components,
Dependency Injection, Partial Views, Authentication, Authorization, Facebook login, Role Management,
TempData/ViewBag/ViewData, Stripe Payment Integrations, Repository Patterns, Azure Deployment

This project has some minor tweaks and elements to fix and touch up, but is has otherwise been completed using: 
C#, .NET 7 & 8, .NET MVC, HTML, CSS, JS, Ajax, SQL, SSMS, Visual Studio 2022 and Azure.

<blockquote class="imgur-embed-pub" lang="en" data-id="a/oI3H8ZC">
<a href="//imgur.com/a/oI3H8ZC">Cardstop Gallery</a></blockquote>
<script async src="//s.imgur.com/min/embed.js" charset="utf-8"></script>

## Issues Encountered

Brave browser (shields) and some ad-blocking plugins are known to cause
issues and can result in the Cardstop web project crashing.

Visual Studio 2022 Preview

-> When attempting to commit and push, error "Pipe has been ended" or "Pipe has been broken" occurs

-> Remains unresolved, fix not found

-> Workaround by using Git Bash terminal instead

Microsoft SQL Server Management Studio 19.3

-> When attempting to access local SQL server ".", the client fails to connect for an unknown reason

-> Reinstalling has previously helped but sometimes does not work.

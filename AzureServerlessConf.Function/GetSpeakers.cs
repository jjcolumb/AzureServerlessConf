using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using AzureServerlessConf.Model;

namespace AzureServerlessConf.Function
{
	public static class GetSpeakersFunction
	{
		[FunctionName("GetSpeakers")]
		public static async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = null)] HttpRequest req,
			ILogger log)
		{	

			string jsondata = @"[
	                {
					'name': 'Jose Javier Columbie',
					'initials': 'JJC',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/jose-columbie.png',
					'summary': 'Serverless Apps with Blazor WebAssembly and Azure Static Web Apps',
					'title': 'DevExpress and Microsoft MVP',
					'skills': 'C#,Xamarin,Azure,Blazor,XAF,XPO',
					'linkedin': 'https://www.linkedin.com/in/josejaviercolumbie/',
					'github': 'https://github.com/jjcolumb/',
					'twitter': 'https://twitter.com/jjcolumbie',
					'webpage': 'https://xafmarin.com/',
					'youtube': 'https://www.youtube.com/c/Josejaviercolumbie'
				},
				{
					'name': 'James Montemagno and Jon Galloway',
					'initials': 'JJ',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/joche-ojeda.jpeg',
					'summary': 'How the .NET Community Team Uses Serverless to Automate All the Things',
					'title': 'Keynote:',
					'skills': 'Software Architecture, C#, Developer Trainer',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'

				},
				{
					'name': 'Barbara Forbes',
					'initials': 'JJ',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/barbara-forbes.png',
					'summary': 'When powers combine: Azure Function & PowerShell',
					'title': 'Azure MVP',
					'skills': 'Azure, Github, C#, PowerShell',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Bjorn Peters',
					'initials': 'BP',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/bjorn-peters.png',
					'summary': 'Azure SQL Database | Up & Down on your Demand',
					'title': 'Data Platform MVP',
					'skills': 'Azure SQL, C#, PowerShell, Database',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Carlos Lopez',
					'initials': 'CL',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/cl.png',
					'summary': 'Working with Azure SQL DB Serverless',
					'title': 'Data Platform MVP',
					'skills': 'Azure SQL, C#, PowerShell, Database',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Charles Chen',
					'initials': 'CC',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/cc.png',
					'summary': 'Surfacing FDA COVID Data Using Serverless Functions and CosmosDB',
					'title': 'Founder @Zytonomy',
					'skills': 'CosmoDB, Azure Functions, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Davide Mauri',
					'initials': 'DM',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/dm.PNG',
					'summary': 'Serverless Full-Stack Kickstart',
					'title': 'Senior Program Manager, Microsoft',
					'skills': 'Azure, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Divakar Kumar',
					'initials': 'DK',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/dk.PNG',
					'summary': 'Build everything on Serverless',
					'title': 'Senior Software Engineer, H&M',
					'skills': 'Azure, .Net, MCT',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Eldert Grootenboer',
					'initials': 'EG',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/eg.PNG',
					'summary': 'Azure Integration Platform: Building Serverless Apps',
					'title': 'Azure MVP',
					'skills': 'Azure, Azure, Azure',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Emad Alashi',
					'initials': 'EA',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/ea.PNG',
					'summary': 'Build Custom Connectors for Azure Logic Apps',
					'title': 'Lead Consultant',
					'skills': 'Logics Apps, Azure, Azure Functions, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Jan-Henrik Damaschke',
					'initials': 'JHD',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/jhd.PNG',
					'summary': 'Serverless Web Apps with GraphQL, Cosmos DB and Azure Functions',
					'title': 'Azure MVP',
					'skills': 'CosmosDB, GraphQL, Azure, Logics Apps, Azure Functions, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Javier Villegas',
					'initials': 'JV',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/jv.PNG',
					'summary': 'Introduction to Azure SQL',
					'title': 'Data Platform MVP',
					'skills': 'Azure SQL,  Azure, Azure Functions, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Jonah Andersson',
					'initials': 'JA',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/ja.PNG',
					'summary': 'The Different Patterns of Azure Durable Functions',
					'title': 'Azure MVP',
					'skills': 'Azure Durable Functions,  Azure, Azure Functions, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Labrina Loving',
					'initials': 'LL',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/ll.PNG',
					'summary': 'Building a Highly Scalable Game with Azure Serverless',
					'title': 'Software Engineer',
					'skills': 'Serverless,  Azure, Azure Functions',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Marc Duiker',
					'initials': 'LL',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/md.PNG',
					'summary': 'Creating the Azure Functions Updates Twitterbot',
					'title': 'Lead Azure Consultant',
					'skills': 'Azure Functions, Serverless, Azure',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				},
				{
					'name': 'Ezhilarasi Kesavan',
					'initials': 'EK',
					'image': 'https://userprofilewalter.blob.core.windows.net/serverless/ek.png',
					'summary': 'The secret behind a reactive Azure Integration Application',
					'title': 'Lead Product Consultant',
					'skills': 'Azure, Azure Functions, Serverless',
					'linkedin': '#',
					'github': '#',
					'twitter': '#',
					'webpage': '#',
					'youtube': '#'
				}]";           
			
			var result = JsonConvert.DeserializeObject<List<Speaker>>(jsondata);

			return new OkObjectResult(result);
		}
	}
}


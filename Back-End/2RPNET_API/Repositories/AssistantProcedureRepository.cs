﻿using _2RPNET_API.Context;
using _2RPNET_API.Domains;
using _2RPNET_API.Interfaces;
using Microsoft.Playwright;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _2RPNET_API.Repositories
{
    public class AssistantProcedureRepository : IAssistantProcedureRepository
    {
        private readonly RPAContext ctx;

        public AssistantProcedureRepository()
        {
        }

        public AssistantProcedureRepository(RPAContext appContext)
        {
            ctx = appContext;
        }
        public void Create(AssistantProcedure NewProcess)
        {
            ctx.AssistantProcedures.Add(NewProcess);
            ctx.SaveChanges();
        }

        public void CreateScript(List<AssistantProcedure> assistantProcedures)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int IdAssitantProcedure)
        {
            AssistantProcedure SearchAssistant = SearchByID(IdAssitantProcedure);

            ctx.AssistantProcedures.Remove(SearchAssistant);

            ctx.SaveChanges();
        }

        public string ManipulateScript(int IdAssistant)
        {
            List<AssistantProcedure> AssistantProcedures = SearchByAssistant(IdAssistant);
            string path = "http://localhost:5000/StaticFiles/Files/Assistant" + IdAssistant + ".cs";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(@"using Microsoft.Playwright;{
                                   using System;
                                   using System.Threading.Tasks;
                                   class Program{
                                   public static async Task Main(){
                                   using var playwright = await Playwright.CreateAsync();
                                   await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                                   {
                                       Headless = true,
                                       SlowMo = 1000
                                   });
                                   var context = await browser.NewContextAsync();
                                   
                                   // Open new page
                                   var page = await context.NewPageAsync(); ");

                    foreach(AssistantProcedure Procedure in AssistantProcedures)
                    {
                        switch (Procedure.ProcedureName)
                        {
                            case "Pesquisar no google":
                                sw.WriteLine(@"await page.GotoAsync('https://www.google.com/?gws_rd=ssl%22'); \n");
                                sw.WriteLine($@"await page.FillAsync('input[title = 'Pesquisar']',{Procedure.ProcedureValue});");
                                sw.WriteLine($@"await page.PressAsync('input[title = 'Pesquisar']', 'Enter');");

                                break;
                            case "Ir para a url":
                                sw.WriteLine(@"await page.GotoAsync('http://eelslap.com/'); \n");

                                break;
                            default:
                                break;
                        }
                    }

                    sw.WriteLine($@"await page.ScreenshotAsync(new PageScreenshotOptions { Path = 'caminhodafoto.png' });");

                }
            }
            return "a";

        }

        public List<AssistantProcedure> ReadAll()
        {
            return ctx.AssistantProcedures.ToList();
        }

        public string RunProcess(int IdAssistant)
        {
            throw new System.NotImplementedException();
        }

        public List<AssistantProcedure> SearchByAssistant(int IdAssistant)
        {
            List<AssistantProcedure> listProcedures = ctx.AssistantProcedures.Where(c => c.IdAssistant == IdAssistant).ToList();
            return listProcedures.OrderBy(o => o.ProcedurePriority).ToList();
        }

        public AssistantProcedure SearchByID(int IdAssistantProcedure)
        {
            return ctx.AssistantProcedures.FirstOrDefault(c => c.IdAprocedure == IdAssistantProcedure);
        }

        public void SearchOnGoogle(AssistantProcedure assistantProcedure, string page)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int IdAssistantProcedure, AssistantProcedure NewProcess)
        {
            AssistantProcedure SearchAssistant = SearchByID(IdAssistantProcedure);

            if (NewProcess.ProcedureName != null && NewProcess.ProcedureDescription != null)
            {
                SearchAssistant.ProcedurePriority = NewProcess.ProcedurePriority;
                SearchAssistant.ProcedureName = NewProcess.ProcedureName;
                SearchAssistant.ProcedureDescription = NewProcess.ProcedureDescription;
                SearchAssistant.IdAssistant = NewProcess.IdAssistant;
            }

            ctx.AssistantProcedures.Update(SearchAssistant);

            ctx.SaveChanges();
        }


    }
}

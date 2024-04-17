using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using WebEntityFramework.Models;

#nullable disable

namespace WebEntityFramework.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.ID);
                });
            Randomizer.Seed = new Random(8675309);
            var fakerArticles = new Faker<Article>();
            fakerArticles.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticles.RuleFor(a => a.PublishDate, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 7, 31)));
            fakerArticles.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            for (int i = 0; i < 50; i++)
            {
                Article article = fakerArticles.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "PublishDate", "Content" },
                    values: new object[]
                    {
                        article.Title,
                        article.PublishDate,
                        article.Content
                    }
                    );
            }
          
            //migrationBuilder.InsertData(
            //  table: "articles",
            //  columns: new[] { "Title", "PublishDate", "Content" },
            //  values: new object[]
            //  {
            //            "Bài viết 2",
            //            new DateTime(2021,8,0),
            //            "Nội dung 2"
            //  }
            //  );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}

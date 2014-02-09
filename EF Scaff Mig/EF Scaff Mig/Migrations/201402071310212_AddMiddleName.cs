namespace EF_Scaff_Mig.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "MiddleName");
        }
    }
}

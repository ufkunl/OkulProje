using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Infrastructure.Migrations
{

    [Migration(1)]
    public class V01 : Migration
    {

        public override void Up()
        {

            Create.Table("Faculty")
                .WithColumn("ID").AsInt16().Identity().PrimaryKey()
                .WithColumn("FacultyName").AsString(128)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("UserTitle")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("UserTitleName").AsInt32()
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("User")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("FacultyID").AsInt32().ForeignKey("Faculty", "ID")
                .WithColumn("UserTitleID").AsInt32().ForeignKey("UserTitle", "ID")
                .WithColumn("UserName").AsString(20)
                .WithColumn("UserSurname").AsString(50)
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("UserNo").AsString(15)
                .WithColumn("UserAdress").AsString(256)
                .WithColumn("Password").AsString(32).NotNullable()
                .WithColumn("UserState").AsString(100)
                .WithColumn("UserQR").AsString(100)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Interest")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("InterestName").AsString(128)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("UserInterest")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("UserID").AsInt32().ForeignKey("User", "ID")
                .WithColumn("InterestID").AsInt32().ForeignKey("Interest", "ID")
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("EvetType")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("TypeName").AsString(128)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Feature")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("FeatureName").AsString(128)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Saloon")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("SaloonName").AsString(150)
                .WithColumn("SaloonQuato").AsInt32()
                .WithColumn("SaloonAdress").AsString(256)
                .WithColumn("SaloonLocation").AsString(100)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("SaloonFeature")
                .WithColumn("ID").AsInt32().Identity().PrimaryKey()
                .WithColumn("FeatureID").AsInt32().ForeignKey("Feature", "ID")
                .WithColumn("SaloonID").AsInt32().ForeignKey("Saloon", "ID")         
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

        }


        public override void Down()
        {
            Delete.Table("SaloonFeature");
            Delete.Table("Saloon");
            Delete.Table("Feature");
            Delete.Table("EvetType");
            Delete.Table("UserInterest");
            Delete.Table("Interest");
            Delete.Table("User");
            Delete.Table("UserTitle");
            Delete.Table("Faculty");

        }

    }

}

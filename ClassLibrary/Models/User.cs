using ClassLibrary.Infrastucture;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Models
{
    public class User
    {

        public int ID { get; set; }
        public Faculty Faculty { get; set; }
        public UserTitle UserTitle { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserNo { get; set; }
        public string UserAdress { get; set; }
        public string Password { get; set; }
        public string UserState { get; set; }
        public string UserQR { get; set; }
        public Boolean IsDeleted { get; set; }

        public int save()
        {

            if(this.ID == 0)
            {
                this.ID = DAL.insertSql("insert into User(FacultyID,UserTitleID,UserName,Email,UserNo,UserAdress,Password,UserState,UserQR) values(@FacultyID,@UserTitleID,@UserName,@Email,@UserNo,@UserAdress,@Password,@UserState,@UserQR)", new List<MySqlParameter>() {

                    new MySqlParameter("@FacultyID",this.Faculty.ID),
                    new MySqlParameter("@UserTitleID",this.UserTitle.ID),
                    new MySqlParameter("@UserName",this.UserName),
                    new MySqlParameter("@Email",this.Email),
                    new MySqlParameter("@UserNo",this.UserNo),
                    new MySqlParameter("@UserAdress",this.UserAdress),
                    new MySqlParameter("@Password",this.Password),
                    new MySqlParameter("@UserState",this.UserState),
                    new MySqlParameter("@UserQR",this.UserQR)

                });
            }
            else
            {
                DAL.insertSql("update User set FacultyID = @FacultyName,UserTitleID = @UserTitleID,UserName = @UserName,Email = @Email, UserNo = @UserNo,UserAdress = @UserAdress, Password = @Password,UserState = @UserState,UserQR = @UserQR where ID = @ID",
                    new List<MySqlParameter>()
                    {
                        new MySqlParameter("@FacultyID",this.Faculty.ID),
                        new MySqlParameter("@UserTitleID",this.UserTitle.ID),
                        new MySqlParameter("@UserName",this.UserName),
                        new MySqlParameter("@Email",this.Email),
                        new MySqlParameter("@UserNo",this.UserNo),
                        new MySqlParameter("@UserAdress",this.UserAdress),
                        new MySqlParameter("@Password",this.Password),
                        new MySqlParameter("@UserState",this.UserState),
                        new MySqlParameter("@UserQR",this.UserQR)
                    });

            }

            return this.ID;
        }

        public void Delete()
        {
            DAL.insertSql("update User set IsDeleted=1 Where ID=@ID", new MySqlParameter("@ID", this.ID));
            DAL.insertSql("update UserInterest set IsDeleted=1 Where UserID=@ID", new MySqlParameter("@ID", this.ID));
        }

    }
}

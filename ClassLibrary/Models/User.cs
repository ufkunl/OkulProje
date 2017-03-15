using ClassLibrary.Infrastucture;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string UserSurName { get; set; }
        public string Email { get; set; }
        public string UserNo { get; set; }
        public string UserAdress { get; set; }
        public string Password { get; set; }
        public string UserState { get; set; }
        public string UserQR { get; set; }
        public Boolean IsDeleted { get; set; }
        public List<UserInterest> UserInterests { get; set; }

        public User()
        {
            UserInterests = new List<UserInterest>();
            Faculty = new Faculty();
            UserTitle = new UserTitle();
        }


        public int save()
        {

            if(this.ID == 0)
            {

                this.UserState = "Beklemede";

                this.ID = DAL.insertSql("insert into User(FacultyID,UserTitleID,UserName,UserSurName,Email,UserNo,UserAdress,Password,UserState,UserQR) values(@FacultyID,@UserTitleID,@UserName,@UserSurName,@Email,@UserNo,@UserAdress,@Password,@UserState,@UserQR)", new List<MySqlParameter>() {

                    new MySqlParameter("@FacultyID",this.Faculty.ID),
                    new MySqlParameter("@UserTitleID",this.UserTitle.ID),
                    new MySqlParameter("@UserName",this.UserName),
                    new MySqlParameter("@UserSurName",this.UserSurName),
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
                DAL.insertSql("update User set FacultyID = @FacultyName,UserTitleID = @UserTitleID,UserName = @UserName,UserSurName = @UserSurName,Email = @Email, UserNo = @UserNo,UserAdress = @UserAdress, Password = @Password,UserState = @UserState,UserQR = @UserQR where ID = @ID",
                    new List<MySqlParameter>()
                    {
                        new MySqlParameter("@FacultyID",this.Faculty.ID),
                        new MySqlParameter("@UserTitleID",this.UserTitle.ID),
                        new MySqlParameter("@UserName",this.UserName),
                        new MySqlParameter("@UserSurName",this.UserSurName),
                        new MySqlParameter("@Email",this.Email),
                        new MySqlParameter("@UserNo",this.UserNo),
                        new MySqlParameter("@UserAdress",this.UserAdress),
                        new MySqlParameter("@Password",this.Password),
                        new MySqlParameter("@UserState",this.UserState),
                        new MySqlParameter("@UserQR",this.UserQR)
                    });

            }

            this.ClearAllInterests();

            foreach(UserInterest u in this.UserInterests)
            {
                u.User.ID = this.ID;
                u.Save();
            }

            return this.ID;
        }

        private void ClearAllInterests()
        {
            DAL.insertSql("Update UserInterest set IsDeleted = 1 Where UserId = @UserID", new MySqlParameter("@UserID", this.ID));
        }

        public void Delete()
        {
            DAL.insertSql("update User set IsDeleted=1 Where ID=@ID", new MySqlParameter("@ID", this.ID));
            ClearAllInterests();
        }


        public void LoginControl()
        {

            DataTable data = DAL.readData("select * from User where IsDeleted = 0 and Email=@Email and Password=@Password",new List<MySqlParameter> {
                    
                new MySqlParameter("@Email",this.Email),
                new MySqlParameter("@Password",this.Password)

            });

            if (data.Rows.Count == 1)
            {
                this.UserName = data.Rows[0]["UserName"].ToString();
                this.UserSurName = data.Rows[0]["UserSurName"].ToString();
                this.ID = Convert.ToInt32(data.Rows[0]["ID"]);
                this.Faculty.ID = Convert.ToInt32(data.Rows[0]["FacultyID"]);
                this.UserTitle.ID = Convert.ToInt32(data.Rows[0]["UserTitleID"]);
                this.Email = data.Rows[0]["Email"].ToString();
                this.UserNo = data.Rows[0]["UserNo"].ToString();
                this.UserAdress = data.Rows[0]["UserAdress"].ToString();
                this.Password = data.Rows[0]["Password"].ToString();
                this.UserState = data.Rows[0]["UserState"].ToString();
                this.UserQR = data.Rows[0]["UserQR"].ToString();
            }
        }




        public int sendMail()
        {
            return 0;
        }



    }
}
 
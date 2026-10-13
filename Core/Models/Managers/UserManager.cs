using System;
using Core.Models.Users;

namespace Core.Models.Managers;

public static class UserManager<T> where T : UserBase, new()
{
    public static T AddUser()
    {
        var user = new T();


        if (user is Student)
            return user;

        if (user is Teacher teacher)
        {
            teacher.Courses = [];
        }
        

        return user;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace MyExtensions
{
    public static class AccountManagementExtensions
    {

        public static String GetProperty(this Principal principal, String property)
        {
            DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
            if (directoryEntry.Properties.Contains(property))
                return directoryEntry.Properties[property].Value.ToString();
            else
                return String.Empty;
        }

        public static String GetPosition(this Principal principal)
        {
            return principal.GetProperty("title");
        }

        public static String GetDepartment(this Principal principal)
        {
            return principal.GetProperty("department");
        }

        public static String GetgroupPriority(this Principal principal)
        {
            return principal.GetProperty("groupPriority");
        }

    }
}
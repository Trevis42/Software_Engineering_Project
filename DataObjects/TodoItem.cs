﻿using Microsoft.Azure.Mobile.Server;

namespace Contact_Billing_XamarinService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}
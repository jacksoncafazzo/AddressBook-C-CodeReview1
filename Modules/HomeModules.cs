using Nancy;
using Contacts.Objects;
using System;
using System.Collections.Generic;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/add_new_friend"] = _ => {
        return View["friend-form.cshtml"];
      };
      Get["/friends_list"] = _ => {
        var allContacts = Contact.GetAll();
        return View["friend-list.cshtml", allContacts];
      };
      Post["/friend/new"] = _ => {
        int phoneInt = int.Parse(Request.Form["friend-phone"]);
        Contact newContact = new Contact(Request.Form["friend-name"], phoneInt, Request.Form["friend-address"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["friend-list.cshtml", allContacts];
      };
      Get["/friend/{id}"] = parameters => {
        var selectedContact = Contact.Find(parameters.id);
        return View["friend.cshtml", selectedContact];
      };
    }
  }
}

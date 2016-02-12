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
        Contact newContact = new Contact(Request.Form["friend-name"], Request.Form["friend-desc"], Request.Form["friend-address"], Request.Form["friend-phone"], Request.Form["friend-email"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["friend-list.cshtml", allContacts];
      };
      Get["/friend/{id}"] = parameters => {
        var selectedContact = Contact.Find(parameters.id);
        return View["friend.cshtml", selectedContact];
      };
      Get["/clear-all-friends"] = _ => {
        Contact.ClearAll();
        return View["friends-cleared.cshtml"];
      };
    }
  }
}

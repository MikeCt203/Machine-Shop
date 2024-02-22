Machine Shop in VB.Net with Full Source Code
----------------------------------------------
  This Machine Shop program was written in Visual Studio Vb.net using Microsoft Access for its database. The program was designed to manage all aspects of the day-to-day office requirements needed within the machine shop environment. 
     
The database tables have been seeded with fictious data entries to help show the capabilities of the program.
     
About the Machine Shop Program
--------------------------------
   I developed this program for my own Tool & Die company to reduce the office time required for the day-to-day paperwork. After researching systems available to me I decided that I wanted a system that could do everything necessary, written by someone that has been running this type of business for a few decades. I wanted a system with all the needed operations, connected together, eliminating redundant data entry that seems very common it the systems I looked at. I wanted all these operations linked together within one system, so at any time if I needed the bottom line of the business, I could view the data instantly and get a complete view of all operations.

History of Machine Shop Program
---------------------------------
   This program was originally written in dbase about 40 years ago. Modified thru the years for improvements. Rewritten in VB6, then in VB.net many years later. This vb.net version, was used in my company for more than a decade, improved all the time for new developments along the way. The program has been tested to the best of my ability thru those years and I believe to be very sound.
     
Features of the Machine Shop program
--------------------------------------
* Login:
The system has the capability to allow password login if needed. The login protection is not up to today’s standards but that was not an issue in my environment.    
******************
* Employee:
Allows the data entry needed for everything related to the employee, from basic information, raise history, vacation time, benefits, years with the company, etc.  There is a reference to an employee report that I never got around to completing, sorry.  
***********************
* Customer: 
Allows the data entry needed for everything related to the customer, from basic information to billing, shipping and freight options, 9 years of order history at a glance, etc.  Printing of a customer list with phone numbers. There is a reference to a customer report that I never got around to completing, very big sorry.
*************************
* Work Schedule:     Schedule with all data pertinent to orders received, listed in any order needed with the ability to be instantly summed for earnings. All orders received are checked against possible inventory instantly. All orders in of need of attention are color coded for clarification. All data pertaining to an order, can be edited from the schedule, without the need of interrupting the thought process.  The schedule is printable for use away from any computer.
*********************
* Income: 
  * Purchase Orders:    Allows quick lookup of all or only active customers. The ability to enter one or blanket orders very quickly, with different shipping dates, quantiles, and prices. Autofill on orders previously received in the past for efficiency and data integrity from order to order.   
    
  * Invoice Order:    Starts with a form that lets you select up to 3 items per Invoice if they share the same purchase order number. Once selected, the form changes to allow the opportunity to make edits to the selected items, giving the additional ability to add shipping cost, and discount if desired. For customers that requested material certification and or lot identification, the opportunity is presented within this form. The ability to change agents ( The person performing the invoicing, for traceability ) can be switch if the primary agent is unavailable. Then finally the printing of the invoice, packing slip and certificate of compliance pertaining to the selected purchase orders.
  
  * Invoice Search:  Offers the ability to search any invoices that have not been paid. This is needed when an invoice is lost in the mail, a discrepancy is found, a copy of the invoice is needed for clarification. The ability to re-print any invoice, packing slip or certificate of compliance if so needed.
     
  * Invoice Re-Invoice:  Very much like invoice search above, but offers the ability to edit the invoice, then re-print the corrected invoice, packing slip, and certificate of compliance. The printing is given the ability to be printed as a Pdf file for emailing.
      
  * Invoice Mark paid:  Form to allow an Invoice to be marked paid.
      
  * Invoice Payment Schedule:  Screen shows all invoices not paid. Totals for all the un-paid invoices and late paid invoices are shown. Phone numbers with relevant data needed are included to address the unpaid bill. 
      
  * Invoice Drawing History:  Form to allow the viewing of any invoiced item once completed. The ability to view the searched item thru the years for price differences, quantiles changes, material heats, etc. Printing of report is available.
******************     
* Banking:   All aspects of the banking process from Checks, Atm, Deposits, reconciling of the account and more. The printing of checks 

* Payroll:    Printing of all paychecks with one button when no changes needed. The ability to make temporary changes, along with the writing of individual payroll checks if needed. Tracking of all paychecks related data pertaining to all employees.  

 * Inventory:   Tracking of inventory for all customers. Inventory is connected behind the scenes, to be shown within the work schedule, and adjusted as used during the invoicing process.
 
* List Checkbook Payee:     List of all Checkbook Payee with the ability to edit any entry with changes needed. This list is self-building as checks are written. 
* System Setup:    Setup pages for all the processes related to the program. The ability to clear all the tables in the databases for a fresh start.

System Screens
-----------------
  How to setup and run the Machine Shop program
Visual Studio needs to be loaded on your computer
1.	Download the zip file.
2.	Extract the zip file to your desktop.
3.	Open this Machine Shop folder that was saved to the desktop.
4.	Double click “Machine_Shop.sln”
5.	Press [Start] in the Visual Studio taskbar.
	
Logon into Machine Shop… Option
--------------------------------
   The program has the capability build into it to allow logins from multiple users or no logons, if that is preferred. To turn on logon option 
1.	Start program.
2.	Click on “logon” far right on startup page.
3.	Click “logon Option”
4.	Enter User ID:  “Admin”     Password: “Admin”
5.	Press [OK] button.
6.	Uncheck Automatic Logon.

  At this time, you can view existing logins with the up & down arrows or erase, add new or edit existing logins.

Printing of forms not working thru out Machine shop program
-------------------------------------------------------------
   If errors pop up during and pressing of a print button
1.	 Select [ Site ] tab found on top of start page.
2.	Click System Setup.
3.	Select [ Misc ] tab.
4.	Press [ Edit ] button.
5.	Use the Printer Selection button to choose the printer for your system.
6.	Press [ Save ] button to save the changes.
7.	Try to print again.
	
Clearing Machine Shop database for new start
----------------------------------------------
  If you find you would like to reboot the system to a new beginning, without and data in the tables of the database.  ( Clean start )  Save database, if needed later.
1.	Select [ Site ] tab found on top of startup page.
2.	Select System Setup.
3.	Select [ General ] tab if not selected.
4.	Press [ System Clear ] button found on right side of form.
5.	In the Enter Code textbox type “Enter Code System Clear”
6.	Press [ System Clear ] button again.
	
  There will be a warning letting you know the tables will be cleared, and the data will be lost forever, unless you back up the database prior to doing this. Press the Continue button to complete the operation. Once the system has been cleared, you must re-Enter data into the system setup before being allowed to use the program again. It would be best to do some Screen prints of all the data under each tab so you will know what is expected for new data.
  
Closing Thoughts
------------------
  I wish I had instructions written for the operation of this program, but I don’t. There are instructions built into many forms throughout the program to aid in the operation of the software. Thru the years many people have used the program within the shop, and I don’t remember having to assist to many people that much, so either I did a good job of common sense or maybe I’m just getting older, and I don’t remember.
  
  I packaged the program with tables full of fictious data to help aid in showing of the program’s possibilities. I know the program worked perfect with the original data but as with anything when you package a program to be shared, there may be problems. It’s been years since I used this for my business after retiring, so my memory of all its capabilities and day to day running isn’t what it uses to be.  If anyone uses this program to run their own shop, I would love to hear about it. Otherwise, I hope other will learn from this and it helps someone along the way, Great. The READ ME folder found in the Machine Shop folder has this info along with Screen shots of various forms filled with data.  Enjoy
 Mike

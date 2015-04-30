# Development Challenge - Licensed Apps

This challenge allows you to demonstrate your skill in assembling a functional web application from the ground-up.  
The details are intentionally light so that you can feel free to use the tools and apply your interpretation to the specifications provided.  


### Instructions
Imagine a fictional App Store that contains many applications that will be purchased by customers.  One of the functional areas would be management of customer licenses for an application.  Please create a simple web application (use any Microsoft .NET based framework) that accomplishes the following:
    * User can manage a list of Apps - an App has a title and (Fontawesome)[http://fortawesome.github.io/Font-Awesome/] icon (css class)
	* User can manage a list of Customers - a Customer has a name, number, and email address
	* User can manage App Licenses for a Customer - a License identifies the App and Customer it is for, as well as a date range in which it is active
	* Anonymous HTTP GET requests can be sent to some url to get information as follows:
		* `\license\{app#}\{customer#}` returns and a JSON result indicating whether or not there is an active license 
		* `\license\app\{app#}` returns a list of customers with active licenses for a given App 
		* `\license\customer\{customer#}` returns a list of Apps with active licenses for a given Customer
	
* Requirements
	* Please use a Microsoft .NET web framework (e.g., MVC, Web Forms, Web API) for at least some of the solution
	* The solution should build and run without requiring any modification after being pulled from the git repo
	
* Tips
	* Do use relevant packages (e.g., Entity Framework) for back-end and front-end
	* Structure your code and files (cs, js, css) as if this were a real project with other collaborators
	* If you're running low on time, focus on functionality first, visual appearance second
	
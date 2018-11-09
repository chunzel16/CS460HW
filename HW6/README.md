## Homework5

[Repo](https://github.com/chunzel16/CS460HW)

 To write a MVC web application that uses portions of a large, complex pre-existing database.
 
 ### Restore Database
 
 First, download Microsoft SQL Server Management Studio. Use this software to restore .bak files to database files.
 I used Nuget to add Microsoft.SqlServer.Types and altered my Global.asax.cs file in order to enable all of the databases features.
 Then, Connect database to Visual Studio and create model.
 
 ### First Function
 
 First, build a search function.
 
 ```C#
 @using (Html.BeginForm("Index", "Home", FormMethod.Get, new { @class = "form-inline" }))
{
    <div class="form-group">
        <div class="input-group">

            @Html.TextBox("input", "", new { @class = "form-control", @placeholder = "Enter A Client Name", required = "required" })
            <span class="input-group-btn">
                <button class="btn btn-default " type="submit"><span class="glyphicon glyphicon-search"></span></button>
            </span>

        </div>
    </div>
```

Then I went to my Controller and added some methods to queryString to get from the input form and use it to view the database.

```
public ActionResult Index(String input)
        {
            input = Request.QueryString["input"];
            if (input == null)
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                ViewBag.show = true;
                return View(db.People.Where(search => search.FullName.Contains(input)).ToList());
            }
        }
```

To display the output, I wrote the following code in the index view.
```
if (Model.Count() == 0)
        {
            <h4>I'm sorry, your search returned no results</h4>

        }
        else
        {
            <div>
                <h4>Client Name:</h4>
            </div>
```

### Second Function

If the input name is a customer, you can access object information.

```
ViewBag.IsP = true;
                int cid = vm.Person.Customers2.FirstOrDefault().CustomerID;
                vm.Customer = db.Customers.Find(cid);
```

```
<dt>
                    Preferred Name:
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Person.PreferredName)
                </dd>

                <dt>
                    Phone Number:
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Person.PhoneNumber)
                </dd>

                <dt>
                    Fax Number:
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Person.FaxNumber)
                </dd>
```

For Purchases information, select the invoices, then the invoice lines, for the Gross Sales and Gross Profit.

```
 ViewBag.GrossSales = vm.Customer.Orders.SelectMany(il => il.Invoices).SelectMany(ils => ils.InvoiceLines).Sum(i => i.ExtendedPrice);
                ViewBag.GrossProfit = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(il => il.InvoiceLines).Sum(lp => lp.LineProfit);
                vm.InvoiceLine = vm.Customer.Orders.SelectMany(x => x.Invoices)
                                               .SelectMany(i => i.InvoiceLines)
                                               .OrderByDescending(i => i.LineProfit)
                                               .Take(10)
                                               .ToList();
```

Convert to view using the following method
```
<dd>
                        @Html.DisplayFor(model => model.Customer.Orders.Count)
                    </dd>

                    <dt>
                        Gross Sales:
                    </dt>
                    <dd>
                        @string.Format("{0:C}", ViewBag.GrossSales)
                    </dd>

                    <dt>
                        Gross Profit:
                    </dt>
                    <dd>
                        @string.Format("{0:C}", ViewBag.GrossProfit)
                    </dd>
```
```
@foreach (var results in Model.InvoiceLine)
                    {
                        <tbody>
                            <tr>
                                <td>
                                    @Html.DisplayFor(result => results.StockItemID)
                                </td>

                                <td>
                                    @Html.DisplayFor(result => results.Description)
                                </td>

                                <td>
                                    @string.Format("{0:C}", results.LineProfit)
                                </td>

                                <td>
                                    @Html.DisplayFor(result => results.Invoice.Person4.FullName)
                                </td>
```
### Final Page
Below is my final page.

<a href="https://www.youtube.com/watch?v=PWPBJCA48Qw">Homework6(Video)</a>




@ProductFeature
Feature: Product
	User is able to search for a product, add it to a basket and remove it from the basket

Background:
	Given User is on my page
	Then Cookies popup is displayed
	When User clicks allow all button on Cookies popup
	Then Cookies popup is no longer displayed

Scenario Outline: Adding & Removing Products
	Given User is on my page
	When User clicks <MenuOption> option from main menu
	Then <MenuOption> page is displayed
	When User selects <Category> category from the left side menu
	Then <Category> page is displayed
	When User selects <SubCategory> category from the left side menu
	Then <SubCategory> page is displayed
	And User selects <Product> product
	Then Product page with <Product> item is displayed
	When User sets quantity to <Quantity>
	And User clicks Add to your basket button
	Then Confirmation message is displayed
	When User clicks Go to your basket
	Then Basket page is displayed
	When User clicks Remove item
	Then Your basket is empty message is displayed

	Examples: Test data for adding products
	| MenuOption         | Category        | SubCategory     | Product                                                  | Quantity |
	| Electricals        | Coffee Machines | Coffee Grinders | John Lewis & Partners Coffee Grinder, Stainless Steel    | 3        |
	| Furniture & Lights | Living Room     | Coffee Tables   | west elm Terrace Coffee Table							| 2        |
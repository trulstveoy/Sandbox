Feature: Coffee Machine
	In order to drink coffee
	As a coffee drinker
	I want to use a coffee machine to brew some coffee

Scenario: Brew a cup of coffe
	Given I have turned on the coffe machine
	And I have added beans
	And I have added water
	When I press brew
	Then the machine should brew 1 cup of coffee

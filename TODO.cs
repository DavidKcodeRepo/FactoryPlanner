/*
This file does nothing but contains TODO notes and ideas, hopes and dreams.

Satisfactory factoryPlanner app

USER STORY
	"I want to work out how many machines with which recipe setting I need in order to make the outputs I want"
	--> I lookup the product via filtering for last output machine and selecting a recipe that creates the product.
	--> I look at resulting inputs & biproducts and balance by finding other machines that affect material balance .
		--> for this, I need my current sumproduct for each relevant material 
		--> for this, I also need to see my current selected recipes
	--> I continue this loop until I see only raw ingrediencts.

BUGS
	clear selections reset button
	if machine is taken off machine to all the the sheet should reset
	/ chemical reactior is showing nothing - FIXED
	/ fluid conditioner is showing nothing - FIXED
	/ orewasher entires are empty on selecting machine - FIXED
	Why is unticking "show all" looping several events and causing multiple view refreshes?
	selecting a machine should limit the ingredient columns to only ingredients
		-> that provide 
		-> in non zero ingredients from recipe table

	/ results and recipes dataframe should scroll lock - FIXED
	/ clicking on either scroll bar crashes th	e app - FIXED
	why is water column hidden - FIXED
	out of sync rows? how does this happen?

		why does all selection force loops on updating userSelections
		crash on zero results + scroll (add a guard to the scroller?)

FEATURES
	option to calculate lowest common multiple?
	option to calc exact balance and over / under to next machine?
	override "near as damn it to zero, to zero" / FIXED WITH CONDITIONAL FORMATTING
	add injection pane? (i.e. zero input recipes)
	do I 
	can we parse math expressions
	round result to 4th decimal place if not integer?

	show inputs of selected recipe

	save and load factories?
change recipe list?

LEARNINGS
	bind view model to view via bindings. 
	VM implemented on view model to trigger refresh
	user.resize is a continuous input and must be supressed until user is done.
	basic optimisation using continue; vastly improved performance in calculation loop by ~ x250 runtime
 */